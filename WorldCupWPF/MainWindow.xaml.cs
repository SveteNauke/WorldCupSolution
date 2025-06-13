
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using WorldCupData.Config;
using WorldCupData.Interfaces;
using WorldCupData.Models;
using WorldCupData.Services;
using WorldCupWPF.ViewModel;

namespace WorldCupWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AppConfig _config;
        private  IDataProvider _provider = new ApiDataProvider();
        private List<Match>? _matches;
        private bool _isDataLoaded = false;
        private List<TeamResult>? _teamResults;

        public MainWindow(AppConfig config)
        {
            InitializeComponent();
            _config = config;
           _ = LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            try
            {
                LoadingOverlay.Visibility = Visibility.Visible;
                _isDataLoaded = false;
                try
                {
                    _teamResults = await _provider.GetTeamResultsAsync(_config.Tournament);
                }
                catch
                {
                    _provider = new JsonDataProvider();
                    _teamResults = await _provider.GetTeamResultsAsync(_config.Tournament);
                }


                var results = await _provider.GetTeamResultsAsync(_config.Tournament);
                _teamResults = results;

                var items = results.Select(r => $"{r.Country} ({r.FifaCode})").ToList();
                cmbFavoriteTeam.ItemsSource = items;

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
            catch (Exception ex)
            {
                MessageBox.Show("Error when reading file " + ex.Message, "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                LoadingOverlay.Visibility = Visibility.Collapsed;
            }
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

            if (match == null)
            {
                txtResult.Text = "Nema rezultata";
                return;
            }

            txtResult.Text = $"{match.HomeTeam.Goals} : {match.AwayTeam.Goals}";

            AssignTeamCodeToPlayers(match.HomeTeamStatistics, match.HomeTeam.Code);
            AssignTeamCodeToPlayers(match.AwayTeamStatistics, match.AwayTeam.Code);
        }


        private string GetFifaCode(string selection)
        {
            var start = selection.LastIndexOf('(') + 1;
            var length = selection.LastIndexOf(')') - start;
            return selection.Substring(start, length);
        }

        private void BtnFavoriteInfo_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateSelections(out string favCode, out string oppCode))
                return;

            var match = _matches.FirstOrDefault(m =>
                (m.HomeTeam.Code == favCode && m.AwayTeam.Code == oppCode) ||
                (m.HomeTeam.Code == oppCode && m.AwayTeam.Code == favCode));

            if (match == null) return;

            var stats = match.HomeTeam.Code == favCode
                ? match.HomeTeamStatistics
                : match.AwayTeamStatistics;

            var result = _teamResults.FirstOrDefault(t => t.FifaCode == favCode);

            if (stats != null && result != null)
            {
                var viewModel = TeamDetailsViewModel.Create(stats, result);
                var win = new TeamDetailsWindow(viewModel);
                win.Owner = this;
                win.ShowDialog();
            }
        }

        private void BtnOpponentInfo_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateSelections(out string favCode, out string oppCode))
                return;


            var match = _matches.FirstOrDefault(m =>
                (m.HomeTeam.Code == favCode && m.AwayTeam.Code == oppCode) ||
                (m.HomeTeam.Code == oppCode && m.AwayTeam.Code == favCode));

            if (match == null) return;

            var stats = match.HomeTeam.Code == oppCode
                ? match.HomeTeamStatistics
                : match.AwayTeamStatistics;


            var result = _teamResults.FirstOrDefault(t => t.FifaCode == oppCode);

            if (stats != null && result != null)
            {
                var viewModel = TeamDetailsViewModel.Create(stats, result);
                var win = new TeamDetailsWindow(viewModel);
                win.Owner = this;
                win.ShowDialog();
            }
        }

        private bool ValidateSelections(out string favCode, out string oppCode)
        {
            favCode = null;
            oppCode = null;

            var fav = cmbFavoriteTeam.SelectedItem?.ToString();
            var opp = cmbOpponent.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(fav) || string.IsNullOrEmpty(opp))
            {
                MessageBox.Show("Please choose a team!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            favCode = GetFifaCode(fav);
            oppCode = GetFifaCode(opp);
            return true;
        }

        private void BtnShowStatistics_Click(object sender, RoutedEventArgs e)
        {
            var fav = cmbFavoriteTeam.SelectedItem?.ToString();
            var opp = cmbOpponent.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(fav))
            {
                MessageBox.Show("Please choose a team first!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

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
                _config = AppConfig.Load();
                _isDataLoaded = false;

                ApplyResolution();

                cmbFavoriteTeam.ItemsSource = null;
                cmbFavoriteTeam.Items.Clear();
                cmbFavoriteTeam.SelectedIndex = -1;

                cmbOpponent.ItemsSource = null;
                cmbOpponent.Items.Clear();
                cmbOpponent.SelectedIndex = -1;
                txtResult.Text = "";

                await LoadDataAsync();
            }
        }

        private void ApplyResolution()
        {
            var resPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "resolution.txt");
            if (!File.Exists(resPath)) return;

            var res = File.ReadAllText(resPath);
            if (res.Equals("Fullscreen", StringComparison.OrdinalIgnoreCase))
            {
                WindowState = WindowState.Maximized;
                WindowStyle = WindowStyle.None;
            }
            else if (res.Contains("x"))
            {
                var parts = res.Split('x');
                if (parts.Length == 2 &&
                    int.TryParse(parts[0], out int width) &&
                    int.TryParse(parts[1], out int height))
                {
                    Width = width;
                    Height = height;
                    WindowState = WindowState.Normal;
                    WindowStyle = WindowStyle.SingleBorderWindow;
                }
            }
        }


        private void AssignTeamCodeToPlayers(TeamStatistics stats, string teamCode)
        {
            if (stats == null)
            {
                return;
            }

            foreach (var player in stats.StartingEleven)
            {
                player.TeamCode = teamCode;
            }

            foreach (var player in stats.Substitutes)
            {
                player.TeamCode = teamCode;
            }

        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (!this.IsLoaded || !this.IsVisible)
                return;

            var result = MessageBox.Show("Are you sure you want to close the app?", "Potvrda", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result != MessageBoxResult.Yes)
            {
                e.Cancel = true;
            }

            base.OnClosing(e);

        }

    }
}


