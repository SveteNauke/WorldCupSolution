using WorldCupData.Config;
using WorldCupData.Enums;
using WorldCupData.Interfaces;
using WorldCupData.Services;

namespace WorldCupWinForms
{
    public partial class MainForm : Form
    {

        private readonly AppConfig _config;

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
    }
}
