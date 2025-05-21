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
                grid.Children.Add(new Label()); // prazno za poravnanje

            foreach (var player in filtered)
            {
                var label = new Label
                {
                    Content = $"{player.ShirtNumber} {player.Name}" + (player.Captain ? " ★" : ""),
                    Foreground = Brushes.White,
                    Background = Brushes.Transparent,
                    FontSize = 14,
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    VerticalContentAlignment = VerticalAlignment.Center
                };
                grid.Children.Add(label);
            }

            while (grid.Children.Count < totalSlots)
                grid.Children.Add(new Label());
        }
    }
}

