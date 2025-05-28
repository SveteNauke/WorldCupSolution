using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WorldCupData.Models;
using WorldCupWPF.ViewModel;

namespace WorldCupWPF
{
    /// <summary>
    /// Interaction logic for TeamDetailsWindow.xaml
    /// </summary>
    public partial class TeamDetailsWindow : Window
    {
        public TeamDetailsWindow(TeamDetailsViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var storyboard = (Storyboard)this.Resources["FadeInStoryboard"];
            storyboard.Begin(this);
        }
    }
}
