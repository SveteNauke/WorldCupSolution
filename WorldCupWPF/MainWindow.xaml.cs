using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WorldCupData.Config;
using WorldCupData.Interfaces;
using WorldCupData.Models;
using WorldCupData.Enums;
using WorldCupData.Services;

namespace WorldCupWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AppConfig _config;
        private readonly IDataProvider _provider = new JsonDataProvider();
        private List<Match> _matches;
        private bool _isDataLoaded = false;

        public MainWindow(AppConfig config)
        {
            InitializeComponent();
            _config = config;
            LoadDataAsync();
        }

        private async 
        Task
        LoadDataAsync()
        {
            var results = await _provider.GetTeamResultsAsync(_config.Tournament);
            var items = results.Select(r => $"{r.Country} ({r.FifaCode})").ToList();
            cmbFavoriteTeam.ItemsSource = items;

            // Učitaj favorite iz file-a
            var favPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "favorite_team.txt");
            if (File.Exists(favPath))
            {
                var saved = File.ReadAllText(favPath);
                if (items.Contains(saved))
                    cmbFavoriteTeam.SelectedItem = saved;
            }

            _matches = await _provider.GetMatchesAsync(_config.Tournament);
            _isDataLoaded = true;
        }

        private void cmbFavoriteTeam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!_isDataLoaded) return;

            var selected = cmbFavoriteTeam.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selected)) return;

            var favCode = GetFifaCode(selected);
            var opponents = _matches
                .Where(m => m.HomeTeam.Code == favCode || m.AwayTeam.Code == favCode)
                .Select(m => m.HomeTeam.Code == favCode ? $"{m.AwayTeam.Country} ({m.AwayTeam.Code})" : $"{m.HomeTeam.Country} ({m.HomeTeam.Code})")
                .Distinct()
                .ToList();

            cmbOpponent.ItemsSource = opponents;
            if (opponents.Count > 0)
                cmbOpponent.SelectedIndex = 0;

            ShowResult();
        }

        private void cmbOpponent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!_isDataLoaded) return;
            ShowResult();
        }

        private void ShowResult()
        {
            var fav = cmbFavoriteTeam.SelectedItem?.ToString();
            var opp = cmbOpponent.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(fav) || string.IsNullOrEmpty(opp)) return;

            var favCode = GetFifaCode(fav);
            var oppCode = GetFifaCode(opp);

            var match = _matches.FirstOrDefault(m =>
                (m.HomeTeam.Code == favCode && m.AwayTeam.Code == oppCode) ||
                (m.HomeTeam.Code == oppCode && m.AwayTeam.Code == favCode));

            if (match == null) txtResult.Text = "Nema rezultata";
            else txtResult.Text = $"{match.HomeTeam.Goals} : {match.AwayTeam.Goals}";
        }

        private string GetFifaCode(string selection)
        {
            var start = selection.LastIndexOf('(') + 1;
            var length = selection.LastIndexOf(')') - start;
            return selection.Substring(start, length);
        }

        private void BtnFavoriteInfo_Click(object sender, RoutedEventArgs e)
        {
            var fav = cmbFavoriteTeam.SelectedItem?.ToString();
            var opp = cmbOpponent.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(fav) || string.IsNullOrEmpty(opp)) return;

            var favCode = GetFifaCode(fav);
            var oppCode = GetFifaCode(opp);

            var match = _matches.FirstOrDefault(m =>
                (m.HomeTeam.Code == favCode && m.AwayTeam.Code == oppCode) ||
                (m.HomeTeam.Code == oppCode && m.AwayTeam.Code == favCode));

            if (match == null) return;

            var stats = match.HomeTeam.Code == favCode
                ? match.HomeTeamStatistics
                : match.AwayTeamStatistics;

            if (stats != null)
            {
                var win = new TeamDetailsWindow(stats);
                win.Owner = this;
                win.ShowDialog();
            }
        }

        private void BtnOpponentInfo_Click(object sender, RoutedEventArgs e)
        {
            var fav = cmbFavoriteTeam.SelectedItem?.ToString();
            var opp = cmbOpponent.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(fav) || string.IsNullOrEmpty(opp)) return;

            var favCode = GetFifaCode(fav);
            var oppCode = GetFifaCode(opp);

            var match = _matches.FirstOrDefault(m =>
                (m.HomeTeam.Code == favCode && m.AwayTeam.Code == oppCode) ||
                (m.HomeTeam.Code == oppCode && m.AwayTeam.Code == favCode));

            if (match == null) return;

            var stats = match.HomeTeam.Code == oppCode
                ? match.HomeTeamStatistics
                : match.AwayTeamStatistics;

            if (stats != null)
            {
                var win = new TeamDetailsWindow(stats);
                win.Owner = this;
                win.ShowDialog();
            }
        }

        private void BtnShowStatistics_Click(object sender, RoutedEventArgs e)
        {
            var fav = cmbFavoriteTeam.SelectedItem?.ToString();
            var opp = cmbOpponent.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(fav) || string.IsNullOrEmpty(opp)) return;

            var favCode = GetFifaCode(fav);
            var oppCode = GetFifaCode(opp);

            var match = _matches.FirstOrDefault(m =>
                (m.HomeTeam.Code == favCode && m.AwayTeam.Code == oppCode) ||
                (m.HomeTeam.Code == oppCode && m.AwayTeam.Code == favCode));

            if (match == null) return;

            var homePlayers = match.HomeTeamStatistics?.StartingEleven ?? new List<Player>();
            var awayPlayers = match.AwayTeamStatistics?.StartingEleven ?? new List<Player>();

            string homeName = match.HomeTeamCountry;
            string awayName = match.AwayTeamCountry;

            var formationWindow = new FieldFormationWindow(homePlayers, awayPlayers, homeName, awayName);
            formationWindow.ShowDialog();

        }


        private async void BtnReopenSettings_Click(object sender, RoutedEventArgs e)
        {
            var settingsWindow = new StartupSettingsWindow();
            if (settingsWindow.ShowDialog() == true)
            {
                // Učitaj ponovno konfiguraciju
                _config = AppConfig.Load();

                //// Primijeni lokalizaciju (ručno jer WPF ne koristi ApplyResources kao Forms)
                //Title = _config.Language != Language.Croatian ? "Main Form" : "Glavna forma";
                //((Label)this.FindName("lblFavorite"))!.Content = _config.Language == Language.Croatian ? "Omiljena reprezentacija:" : "Favorite team:";
                //((Label)this.FindName("lblOpponent"))!.Content = _config.Language == Language.Croatian ? "Protivnik:" : "Opponent:";

                // Ponovno učitaj podatke s novim prvenstvom
                _isDataLoaded = false;
                await LoadDataAsync();
            }
        }
    }
}


