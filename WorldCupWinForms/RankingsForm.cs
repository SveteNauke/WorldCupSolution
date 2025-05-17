using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WorldCupData.Enums;
using WorldCupData.Interfaces;
using WorldCupData.Models;
using WorldCupData.Services;

namespace WorldCupWinForms
{
    public partial class RankingsForm : Form
    {
        private readonly string _fifaCode;
        private readonly TournamentType _tournament;
        private readonly IDataProvider _provider;

        public RankingsForm(string fifaCode, TournamentType tournament)
        {
            InitializeComponent();
            _fifaCode = fifaCode;
            _tournament = tournament;
            _provider = new JsonDataProvider(); // ili ApiDataProvider

            this.Load += RankingsForm_Load_1; // ⬅️ Ovo dodaj!
        }

        private async void RankingsForm_Load_1(object sender, EventArgs e)
        {
            var matches = await _provider.GetMatchesAsync(_tournament);
            var teamMatches = matches
                .Where(m => m.HomeTeam.Code == _fifaCode || m.AwayTeam.Code == _fifaCode)
                .ToList();

            FillScorers(teamMatches);
            FillCards(teamMatches);
            FillAttendance(teamMatches);
            // Sljedeće: FillCards(teamMatches); FillAttendance(teamMatches);
        }

        private void FillScorers(List<Match> matches)
        {
            var goalEvents = new List<TeamEvent>();

            foreach (var match in matches)
            {
                if (match.HomeTeam.Code == _fifaCode)
                    goalEvents.AddRange(match.HomeTeamEvents.Where(e => e.TypeOfEvent == "goal"));

                if (match.AwayTeam.Code == _fifaCode)
                    goalEvents.AddRange(match.AwayTeamEvents.Where(e => e.TypeOfEvent == "goal"));
            }

            var grouped = goalEvents
                .GroupBy(e => e.Player)
                .Select(g => new
                {
                    Player = g.Key,
                    Goals = g.Count()
                })
                .OrderByDescending(g => g.Goals)
                .ToList();

            lvScorers.Items.Clear();
            foreach (var g in grouped)
            {
                var item = new ListViewItem(g.Player);
                item.SubItems.Add(g.Goals.ToString());
                lvScorers.Items.Add(item);
            }
        }

        private void FillCards(List<Match> matches)
        {
            var cardEvents = new List<TeamEvent>();

            foreach (var match in matches)
            {
                if (match.HomeTeam.Code == _fifaCode)
                    cardEvents.AddRange(match.HomeTeamEvents.Where(e => e.TypeOfEvent == "yellow-card"));

                if (match.AwayTeam.Code == _fifaCode)
                    cardEvents.AddRange(match.AwayTeamEvents.Where(e => e.TypeOfEvent == "yellow-card"));
            }

            var grouped = cardEvents
                .GroupBy(e => e.Player)
                .Select(g => new
                {
                    Player = g.Key,
                    Cards = g.Count()
                })
                .OrderByDescending(g => g.Cards)
                .ToList();

            lvCards.Items.Clear();
            foreach (var g in grouped)
            {
                var item = new ListViewItem(g.Player);
                item.SubItems.Add(g.Cards.ToString());
                lvCards.Items.Add(item);
            }
        }

        private void FillAttendance(List<Match> matches)
        {
            var attendanceMatches = matches
                .Where(m => m.Attendance is not null)
                .OrderByDescending(m => m.Attendance)
                .ToList();

            lvAttendance.Items.Clear();
            foreach (var match in attendanceMatches)
            {
                var item = new ListViewItem(match.Venue);
                item.SubItems.Add(match.Attendance);
                item.SubItems.Add(match.HomeTeam.Country);
                item.SubItems.Add(match.AwayTeam.Country);
                lvAttendance.Items.Add(item);
            }
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
