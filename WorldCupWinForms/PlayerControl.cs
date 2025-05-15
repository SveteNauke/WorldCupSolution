using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WorldCupData.Models;

namespace WorldCupWinForms
{
    public partial class PlayerControl : UserControl
    {
        public Player Player { get; private set; }
        public bool IsFavorite { get; private set; }
        public string PlayerId => $"{Player.Name}-{Player.ShirtNumber}";

        private PictureBox picPlayer;
        private Label lblName;
        private Label lblDetails;

        private readonly string _teamCode;

        public PlayerControl(Player player, string teamCode)
        {
            Player = player;
            _teamCode = teamCode;

            InitializeComponent();
            SetupUI();
        }
        private void SetupUI()
        {
            this.Size = new Size(280, 70);
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Margin = new Padding(5);
            this.Padding = new Padding(5);

            picPlayer = new PictureBox
            {
                Size = new Size(50, 50),
                Location = new Point(5, 10),
                SizeMode = PictureBoxSizeMode.Zoom
            };

            lblName = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Location = new Point(65, 10),
                Text = $"{Player.ShirtNumber} - {Player.Name}"
            };

            lblDetails = new Label
            {
                AutoSize = true,
                Location = new Point(65, 30),
                Text = $"{Player.Position}" + (Player.Captain ? " ★" : "")
            };

            this.Controls.Add(picPlayer);
            this.Controls.Add(lblName);
            this.Controls.Add(lblDetails);

            LoadPlayerImage();

            this.MouseDown += PlayerControl_MouseDown;
            lblName.MouseDown += PlayerControl_MouseDown;
            lblDetails.MouseDown += PlayerControl_MouseDown;
            picPlayer.MouseDown += PlayerControl_MouseDown;
        }

        private void LoadPlayerImage()
        {
            string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", $"{_teamCode}-{Player.ShirtNumber}.jpg");
            string fallback = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "default.jpg");

            if (File.Exists(imagePath))
                picPlayer.Image = Image.FromFile(imagePath);
            else if (File.Exists(fallback))
                picPlayer.Image = Image.FromFile(fallback);
            else
                picPlayer.BackColor = Color.LightGray; // ako baš nema slike

            Console.WriteLine($"Trying to load: {imagePath}");

        }

        private void PlayerControl_MouseDown(object sender, MouseEventArgs e)
        {
            this.DoDragDrop(this, DragDropEffects.Move);
        }

        public void SetFavorite(bool isFavorite)
        {
            IsFavorite = isFavorite;
            this.BackColor = isFavorite ? Color.Pink : SystemColors.Control;
        }

    }
}
