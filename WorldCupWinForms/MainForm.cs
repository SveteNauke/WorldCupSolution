using WorldCupData.Enums;
using WorldCupData.Interfaces;
using WorldCupData.Services;

namespace WorldCupWinForms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            IDataProvider provider = new JsonDataProvider(); // or ApiDataProvider
            var matches = await provider.GetMatchesAsync(TournamentType.Men);
            MessageBox.Show($"U?itanih utakmica: {matches.Count}");
        }
    }
}
