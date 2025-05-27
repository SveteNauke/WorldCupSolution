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
using WorldCupData.Enums;

namespace WorldCupWPF
{
    /// <summary>
    /// Interaction logic for StartupSettingsWindow.xaml
    /// </summary>
    public partial class StartupSettingsWindow : Window
    {
        public AppConfig SelectedConfig { get; private set; }
        public string SelectedResolution { get; private set; }

        public StartupSettingsWindow()
        {
            InitializeComponent();

            cmbLanguage.ItemsSource = Enum.GetValues(typeof(Language));
            cmbTournament.ItemsSource = Enum.GetValues(typeof(TournamentType));
            cmbResolution.ItemsSource = new[]
            {
                "800x600",
                "1000x700",
                "1920x1080",
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

            SelectedConfig.Save();
            SelectedResolution = cmbResolution.SelectedItem.ToString();

            File.WriteAllText("resolution.txt", SelectedResolution);

            DialogResult = true;
            Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
