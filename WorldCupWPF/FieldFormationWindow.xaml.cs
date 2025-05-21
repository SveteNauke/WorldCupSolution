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
        public FieldFormationWindow(List<Player> homePlayers, List<Player> awayPlayers)
        {
            InitializeComponent();
            RenderFormation(homePlayers, awayPlayers);
        }

        private void RenderFormation(List<Player> homePlayers, List<Player> awayPlayers)
        {
            DrawLine(RowGoalieHome, homePlayers, "Goalie");
            DrawLine(RowDefHome, homePlayers, "Defender");
            DrawLine(RowMidHome, homePlayers, "Midfield");
            DrawLine(RowFwdHome, homePlayers, "Forward");

            DrawLine(RowGoalieAway, awayPlayers, "Goalie");
            DrawLine(RowDefAway, awayPlayers, "Defender");
            DrawLine(RowMidAway, awayPlayers, "Midfield");
            DrawLine(RowFwdAway, awayPlayers, "Forward");
        }

        private void DrawLine(UniformGrid grid, List<Player> players, string position, int minSlots = 5)
        {
            grid.Children.Clear();

            var filtered = players.Where(p => p.Position.Equals(position, StringComparison.OrdinalIgnoreCase)).ToList();
            int totalSlots = Math.Max(minSlots, filtered.Count);
            grid.Columns = totalSlots;

            int padding = totalSlots - filtered.Count;
            int leftPad = padding / 2;

            for (int i = 0; i < leftPad; i++)
                grid.Children.Add(new Label());

            foreach (var player in filtered)
            {
                var playerStack = new StackPanel
                {
                    Orientation = Orientation.Vertical,
                    HorizontalAlignment = HorizontalAlignment.Center
                };

                var image = new Image
                {
                    Width = 40,
                    Height = 40,
                    Source = new BitmapImage(new Uri("pack://application:,,,/Resources/dres.png"))
                };


                var label = new TextBlock
                {
                    Text = $"{player.ShirtNumber} {player.Name}" + (player.Captain ? " ★" : ""),
                    Foreground = Brushes.White,
                    FontSize = 12,
                    TextAlignment = TextAlignment.Center,
                    TextWrapping = TextWrapping.Wrap,
                    Width = 90,

                    Effect = new DropShadowEffect
                    {
                        Color = Colors.Black,
                        Direction = 0,
                        ShadowDepth = 1,
                        Opacity = 1
                    }

                };

                playerStack.Children.Add(image);
                playerStack.Children.Add(label);

                grid.Children.Add(playerStack);
            }

            while (grid.Children.Count < totalSlots)
                grid.Children.Add(new Label());
        }

    }
}

