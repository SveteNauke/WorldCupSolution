using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WorldCupData.Enums;
using WorldCupData.Interfaces;
using WorldCupData.Models;

namespace WorldCupData.Services
{
    public class ApiDataProvider : IDataProvider
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        private string BaseUrl(TournamentType tournament)
        {
            return tournament == TournamentType.Men
                ? "https://worldcup-vua.nullbit.hr/men"
                : "https://worldcup-vua.nullbit.hr/women";
        }
        public async Task<List<TeamResult>> GetTeamResultsAsync(TournamentType tournament)
        {
            var url = $"{BaseUrl(tournament)}/teams/results";
            var json = await _httpClient.GetStringAsync(url);
            return JsonConvert.DeserializeObject<List<TeamResult>>(json);
        }

        public async Task<List<Match>> GetMatchesAsync(TournamentType tournament)
        {
            var url = $"{BaseUrl(tournament)}/matches";
            var json = await _httpClient.GetStringAsync(url);
            return JsonConvert.DeserializeObject<List<Match>>(json);
        }

        public async Task<List<Match>> GetMatchesByTeamAsync(TournamentType tournament, string fifaCode)
        {
            var url = $"{BaseUrl(tournament)}/matches/country?fifa_code={fifaCode}";
            var json = await _httpClient.GetStringAsync(url);
            return JsonConvert.DeserializeObject<List<Match>>(json);
        }

    }
}
