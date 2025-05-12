using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCupData.Enums;
using WorldCupData.Interfaces;
using WorldCupData.Models;

namespace WorldCupData.Services
{
    public class JsonDataProvider : IDataProvider
    {
    private string BasePath => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");

        private string GetFolder(TournamentType tournament)
        {
            return tournament == TournamentType.Men ? "men" : "women";
        }

        public async Task<List<TeamResult>> GetTeamResultsAsync(TournamentType tournament)
        {
            var path = Path.Combine(BasePath, GetFolder(tournament), "results.json");
            if (!File.Exists(path))
                throw new FileNotFoundException($"JSON file not found at: {path}");
            var json = await File.ReadAllTextAsync(path);
            return JsonConvert.DeserializeObject<List<TeamResult>>(json);
        }

        public async Task<List<Match>> GetMatchesAsync(TournamentType tournament)
        {
            var path = Path.Combine(BasePath, GetFolder(tournament), "matches.json");
            if (!File.Exists(path))
                throw new FileNotFoundException($"JSON file not found at: {path}");
            var json = await File.ReadAllTextAsync(path);
            return JsonConvert.DeserializeObject<List<Match>>(json);
        }

        public async Task<List<Match>> GetMatchesByTeamAsync(TournamentType tournament, string fifaCode)
        {
            var matches = await GetMatchesAsync(tournament);
            return matches.Where(m =>
                m.HomeTeam.Code.Equals(fifaCode, StringComparison.OrdinalIgnoreCase) ||
                m.AwayTeam.Code.Equals(fifaCode, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}
