using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCupData.Models;

namespace WorldCupWPF.ViewModel
{
    public class TeamDetailsViewModel
    {

        public string? Tactics { get; set; }
        public string? BallPossession { get; set; }
        public string? PassAccuracy { get; set; }
        public int FoulsCommitted { get; set; }
        public int YellowCards { get; set; }
        public int RedCards { get; set; }
        public int BallsRecovered { get; set; }
        public int Tackles { get; set; }


        public string? Country { get; set; }
        public string? FifaCode { get; set; }
        public int GamesPlayed { get; set; }
        public int Wins { get; set; }
        public int Draws { get; set; }
        public int Losses { get; set; }
        public int GoalsFor { get; set; }
        public int GoalsAgainst { get; set; }
        public int GoalDifferential => GoalsFor - GoalsAgainst;

        public string WinsDrawsLosses => $"{Wins} / {Draws} / {Losses}";
        public string GoalsSummary => $"{GoalsFor} / {GoalsAgainst} / {GoalDifferential}";

        public static TeamDetailsViewModel Create(TeamStatistics stats, TeamResult result)
        {
            return new TeamDetailsViewModel
            {

                Tactics = stats.Tactics,
                BallPossession = stats.BallPossession.HasValue ? $"{stats.BallPossession.Value}%" : "N/A",
                PassAccuracy = stats.PassAccuracy.HasValue ? $"{stats.PassAccuracy.Value}%" : "N/A",
                FoulsCommitted = stats.FoulsCommitted ?? 0,
                YellowCards = stats.YellowCards ?? 0,
                RedCards = stats.RedCards ?? 0,
                BallsRecovered = stats.BallsRecovered ?? 0,
                Tackles = stats.Tackles ?? 0,


                Country = result.Country,
                FifaCode = result.FifaCode,
                GamesPlayed = result.GamesPlayed,
                Wins = result.Wins,
                Draws = result.Draws,
                Losses = result.Losses,
                GoalsFor = result.GoalsFor,
                GoalsAgainst = result.GoalsAgainst,
            };
        }
    }

}
