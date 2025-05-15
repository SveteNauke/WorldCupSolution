using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorldCupData.Models;

namespace WorldCupWinForms
{
    public partial class PlayerControl : UserControl
    {
        public Player Player { get; private set; }
        public bool IsFavorite { get; private set; }

        public string PlayerId => $"{Player.Name}-{Player.ShirtNumber}";

        private Label lblName;
        private Label lblDetails;

        public PlayerControl(Player player)
        {
            Player = player;
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            lblName = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Text = $"{Player.ShirtNumber} - {Player.Name}"
            };

            lblDetails = new Label
            {
                AutoSize = true,
                Text = $"{Player.Position}" + (Player.Captain ? " ★" : "")
            };

            this.Controls.Add(lblName);
            this.Controls.Add(lblDetails);

            lblName.Location = new Point(10, 10);
            lblDetails.Location = new Point(10, 30);

            this.Size = new Size(250, 60);
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Margin = new Padding(5);
            this.Padding = new Padding(5);
        }

        public void SetFavorite(bool isFavorite)
        {
            IsFavorite = isFavorite;
            this.BackColor = isFavorite ? Color.Gold : SystemColors.Control;
        }

    }
}
