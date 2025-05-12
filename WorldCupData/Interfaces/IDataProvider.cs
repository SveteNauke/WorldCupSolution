using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCupData.Enums;
using WorldCupData.Models;

namespace WorldCupData.Interfaces
{
    public interface IDataProvider
    {
        Task<List<TeamResult>> GetTeamResultsAsync(TournamentType tournament);
        Task<List<Match>> GetMatchesAsync(TournamentType tournament);
        Task<List<Match>> GetMatchesByTeamAsync(TournamentType tournament, string fifaCode);
    }
}
