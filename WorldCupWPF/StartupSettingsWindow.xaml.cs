using System.IO;
using System.Windows;
using System.Windows.Input;
using WorldCupData.Config;
using WorldCupData.Enums;

namespace WorldCupWPF
{
    /// <summary>
    /// Interaction logic for StartupSettingsWindow.xaml
    /// </summary>
    public partial class StartupSettingsWindow : Window
    {
        public AppConfig? SelectedConfig { get; private set; }
        public string? SelectedResolution { get; private set; }

        public StartupSettingsWindow()
        {
            InitializeComponent();

            cmbLanguage.ItemsSource = Enum.GetValues(typeof(Language));
            cmbTournament.ItemsSource = Enum.GetValues(typeof(TournamentType));
            cmbResolution.ItemsSource = new[]
            {
                "800x600",
                "1024x768",
                "1600x1900",
                "Fullscreen"
            };

            cmbLanguage.SelectedIndex = 0;
            cmbTournament.SelectedIndex = 0;
            cmbResolution.SelectedIndex = 0;
        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {

            SelectedConfig = new AppConfig
            {
                Language = (Language)cmbLanguage.SelectedItem,
                Tournament = (TournamentType)cmbTournament.SelectedItem
            };

            SelectedResolution = cmbResolution.SelectedItem?.ToString();
            SaveSelections();

            DialogResult = true;
            Close();
        }

        private void SaveSelections()
        {
            SelectedConfig?.Save();

            var resPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "resolution.txt");
            if (!string.IsNullOrEmpty(SelectedResolution))
            {
                File.WriteAllText(resPath, SelectedResolution);
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                BtnConfirm_Click(this, new RoutedEventArgs());
                e.Handled = true;
            }
            else if (e.Key == Key.Escape)
            {
                DialogResult = false;
                Close();
                e.Handled = true;
            }
        }

    }
}
