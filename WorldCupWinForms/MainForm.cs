using WorldCupData.Config;
using WorldCupData.Enums;
using WorldCupData.Interfaces;
using WorldCupData.Services;

namespace WorldCupWinForms
{
    public partial class MainForm : Form
    {

        private readonly AppConfig _config;
        private readonly string favoriteTeamFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "favorite_team.txt");
        private readonly string favoritePlayersFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "favorite_players.txt");


        public MainForm(AppConfig config)
        {
            InitializeComponent();

            _config = config;
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            IDataProvider provider = new JsonDataProvider(); // or ApiDataProvider
            var matches = await provider.GetMatchesAsync(_config.Tournament);
            MessageBox.Show($"Učitanih utakmica: {matches.Count}");

            MessageBox.Show($"Jezik: {_config.Language}, Prvenstvo: {_config.Tournament}");

            pnlAllPlayers.AllowDrop = true;
            pnlFavoritePlayers.AllowDrop = true;

            pnlAllPlayers.DragEnter += Flp_DragEnter;
            pnlFavoritePlayers.DragEnter += Flp_DragEnter;

            pnlAllPlayers.DragDrop += FlpAllPlayers_DragDrop;
            pnlFavoritePlayers.DragDrop += FlpFavoritePlayers_DragDrop;


            await LoadTeamsAsync();
            await HandleFavoriteTeamChangedAsync();
            await LoadPlayersForFavoriteTeamAsync();


        }

        private void btnOpenSettings_Click(object sender, EventArgs e)
        {
            var settingsForm = new SettingsForm();
            if (settingsForm.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Settings saved. Please restart the application to apply changes.",
                                "Restart Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async Task LoadTeamsAsync()
        {
            IDataProvider provider = new JsonDataProvider();
            var results = await provider.GetTeamResultsAsync(_config.Tournament);

            var teamItems = results.Select(r => $"{r.Country} ({r.FifaCode})").ToList();
            cmbFavoriteTeam.DataSource = teamItems;

            if (File.Exists(favoriteTeamFilePath))
            {
                var saved = File.ReadAllText(favoriteTeamFilePath);
                if (teamItems.Contains(saved))
                {
                    cmbFavoriteTeam.SelectedItem = saved;
                }
            }
        }

        private void cmbFavoriteTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ = HandleFavoriteTeamChangedAsync();
        }

        private async Task HandleFavoriteTeamChangedAsync()
        {
            var selected = cmbFavoriteTeam.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selected))
                return;

            File.WriteAllText(favoriteTeamFilePath, selected);

            string fifaCode = GetFifaCodeFromSelection(selected);
            IDataProvider provider = new JsonDataProvider();

            var matches = await provider.GetMatchesAsync(_config.Tournament);

            var match = matches.FirstOrDefault(m =>
                m.HomeTeam.Code == fifaCode || m.AwayTeam.Code == fifaCode);

            if (match == null)
            {
                MessageBox.Show("Nema utakmica za ovu reprezentaciju.");
                return;
            }

            var teamStats = match.HomeTeam.Code == fifaCode ? match.HomeTeamStatistics : match.AwayTeamStatistics;

            var allPlayers = teamStats.StartingEleven.Concat(teamStats.Substitutes).ToList();
            pnlAllPlayers.Controls.Clear();

            foreach (var player in allPlayers)
            {
                var ctrl = new PlayerControl(player, fifaCode);
                ctrl.SetFavorite(false); // jer dolazi iz allPlayers

                pnlAllPlayers.Controls.Add(ctrl);
            }

        }


        private string GetFifaCodeFromSelection(string selection)
        {
            // Pretpostavka: format je "Brazil (BRA)"
            var start = selection.LastIndexOf('(') + 1;
            var length = selection.LastIndexOf(')') - start;
            return selection.Substring(start, length);
        }

        private void Flp_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(PlayerControl)))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        private void FlpAllPlayers_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetData(typeof(PlayerControl)) is PlayerControl ctrl)
            {
                ctrl.SetFavorite(false);
                pnlFavoritePlayers.Controls.Remove(ctrl);
                pnlAllPlayers.Controls.Add(ctrl);
                SaveFavoritePlayersToFile();
            }
        }

        private void FlpFavoritePlayers_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetData(typeof(PlayerControl)) is PlayerControl ctrl)
            {
                if (pnlFavoritePlayers.Controls.Count >= 3)
                {
                    MessageBox.Show("Možeš označiti najviše 3 omiljena igrača.", "Ograničenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ctrl.SetFavorite(true);
                pnlAllPlayers.Controls.Remove(ctrl);
                pnlFavoritePlayers.Controls.Add(ctrl);
                SaveFavoritePlayersToFile();
            }
        }

        private void SaveFavoritePlayersToFile()
        {
            var ids = pnlFavoritePlayers.Controls
                .OfType<PlayerControl>()
                .Select(p => p.PlayerId)
                .ToList();

            File.WriteAllLines(favoritePlayersFile, ids);
        }

        private async Task LoadPlayersForFavoriteTeamAsync()
        {
            if (!File.Exists(favoriteTeamFilePath)) return;

            var favoriteTeam = File.ReadAllText(favoriteTeamFilePath);
            var fifaCode = GetFifaCodeFromSelection(favoriteTeam);

            IDataProvider provider = new JsonDataProvider(); // ili ApiDataProvider
            var matches = await provider.GetMatchesAsync(_config.Tournament);

            // Prva utakmica gdje se pojavljuje omiljeni tim
            var match = matches.FirstOrDefault(m =>
                m.HomeTeam.Code == fifaCode || m.AwayTeam.Code == fifaCode);

            if (match == null)
            {
                MessageBox.Show("Nema utakmica za odabranu reprezentaciju.");
                return;
            }

            var teamStats = match.HomeTeam.Code == fifaCode
                ? match.HomeTeamStatistics
                : match.AwayTeamStatistics;

            var players = teamStats.StartingEleven.Concat(teamStats.Substitutes).ToList();

            // Učitaj omiljene iz .txt datoteke
            var favoriteIds = File.Exists(favoritePlayersFile)
                ? File.ReadAllLines(favoritePlayersFile).ToHashSet()
                : new HashSet<string>();

            // Očisti panele
            pnlAllPlayers.Controls.Clear();
            pnlFavoritePlayers.Controls.Clear();

            foreach (var player in players)
            {
                var ctrl = new PlayerControl(player, fifaCode); // nova instanca kontrole

                if (favoriteIds.Contains(ctrl.PlayerId))
                {
                    ctrl.SetFavorite(true);
                    pnlFavoritePlayers.Controls.Add(ctrl);
                }
                else
                {
                    pnlAllPlayers.Controls.Add(ctrl);
                }
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            var result = MessageBox.Show("Želite li stvarno zatvoriti aplikaciju?", "Zatvori", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
            {
                e.Cancel = true;
            }

            base.OnFormClosing(e);
        }

        private void btnShowRankings_Click(object sender, EventArgs e)
        {
            var selected = cmbFavoriteTeam.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selected)) return;

            var fifaCode = GetFifaCodeFromSelection(selected);

            var rankingsForm = new RankingsForm(fifaCode, _config.Tournament);
            rankingsForm.ShowDialog();
        }
    }
}
