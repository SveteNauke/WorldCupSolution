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

            await LoadTeamsAsync();
            await HandleFavoriteTeamChangedAsync();

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
            _ = HandleFavoriteTeamChangedAsync(); // Fire-and-forget
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

            // Prikaz igrača u panel
            pnlAllPlayers.Controls.Clear();

            foreach (var player in allPlayers)
            {
                var label = new Label
                {
                    AutoSize = true,
                    Padding = new Padding(3),
                    Margin = new Padding(5),
                    Font = new Font("Segoe UI", 9),
                    Text = $"{player.ShirtNumber} - {player.Name} ({player.Position})" + (player.Captain ? " ★" : "")
                };
                pnlAllPlayers.Controls.Add(label);
            }
        }


        private string GetFifaCodeFromSelection(string selection)
        {
            // Pretpostavka: format je "Brazil (BRA)"
            var start = selection.LastIndexOf('(') + 1;
            var length = selection.LastIndexOf(')') - start;
            return selection.Substring(start, length);
        }

    }
}
