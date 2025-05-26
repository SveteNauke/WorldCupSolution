using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WorldCupData.Models;

namespace WorldCupWPF
{
    /// <summary>
    /// Interaction logic for FieldFormationWindow.xaml
    /// </summary>
    public partial class FieldFormationWindow : Window
    {
        public FieldFormationWindow(List<Player> homePlayers, List<Player> awayPlayers, string homeTeamName, string awayTeamName)
        {
            InitializeComponent();
            MatchTitle.Text = $"{homeTeamName.ToUpper()} vs {awayTeamName.ToUpper()}";
            RenderFormation(homePlayers, awayPlayers);
        }

        private void RenderFormation(List<Player> homePlayers, List<Player> awayPlayers)
        {
            DrawLine(RowGoalieHome, homePlayers, "Goalie", 1);
            DrawLine(RowDefHome, homePlayers, "Defender", 5);
            DrawLine(RowMidHome, homePlayers, "Midfield", 5);
            DrawLine(RowFwdHome, homePlayers, "Forward", 3);

            DrawLine(RowGoalieAway, awayPlayers, "Goalie", 1);
            DrawLine(RowDefAway, awayPlayers, "Defender", 5);
            DrawLine(RowMidAway, awayPlayers, "Midfield", 5);
            DrawLine(RowFwdAway, awayPlayers, "Forward", 3);
        }

        private void DrawLine(StackPanel panel, List<Player> players, string position, int expectedCount)
        {
            panel.Children.Clear();

            var matchingPlayers = players.Where(p => p.Position == position).ToList();

            foreach (var player in matchingPlayers)
            {
                var playerStack = new StackPanel
                {
                    Orientation = Orientation.Vertical,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Margin = new Thickness(10, 0, 10, 0)
                };

                var shirtImage = new Image
                {
                    Source = new BitmapImage(new Uri("pack://application:,,,/Resources/dres.png")),
                    Width = 50,
                    Height = 50
                };

                var nameText = new TextBlock
                {
                    Text = $"{player.ShirtNumber} {player.Name}",
                    Foreground = Brushes.White,
                    FontSize = 12,
                    TextAlignment = TextAlignment.Center,
                    TextWrapping = TextWrapping.Wrap,
                };

                playerStack.Children.Add(shirtImage);
                playerStack.Children.Add(nameText);
                panel.Children.Add(playerStack);

            }
        }

    }
}

