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
using WorldCupData.Models;

namespace WorldCupWPF
{
    /// <summary>
    /// Interaction logic for PlayerWindow.xaml
    /// </summary>
    public partial class PlayerWindow : Window
    {
        public PlayerWindow(Player player)
        {
            InitializeComponent();

            playerName.Text = player.Name;
            shirtNumber.Text = $"Shirt Number: {player.ShirtNumber}";
            position.Text = $"Position: {player.Position}";
            captain.Visibility = player.Captain ? Visibility.Visible : Visibility.Collapsed;


            string imagePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", $"{player.TeamCode}-{player.ShirtNumber}.jpg");
            string fallbackPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "Default.jpg");

            if (!File.Exists(imagePath))
            {
                imagePath = fallbackPath;
            }

            try
            {
                imgPlayer.Source = new BitmapImage(new Uri(imagePath));
            }
            catch (Exception)
            {

                MessageBox.Show("Failed to load image");
            }
        }
    }
}
