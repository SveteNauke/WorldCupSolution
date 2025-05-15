namespace WorldCupWinForms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            toolStrip1 = new ToolStrip();
            btnOpenSettings = new ToolStripButton();
            cmbFavoriteTeam = new ComboBox();
            lblFavoriteTeam = new Label();
            pnlAllPlayers = new FlowLayoutPanel();
            pnlFavoritePlayers = new FlowLayoutPanel();
            lblAllPlayers = new Label();
            lblFavoritePlayers = new Label();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnOpenSettings });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 25);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // btnOpenSettings
            // 
            btnOpenSettings.Alignment = ToolStripItemAlignment.Right;
            btnOpenSettings.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnOpenSettings.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnOpenSettings.Image = (Image)resources.GetObject("btnOpenSettings.Image");
            btnOpenSettings.ImageTransparentColor = Color.Magenta;
            btnOpenSettings.Name = "btnOpenSettings";
            btnOpenSettings.Size = new Size(23, 22);
            btnOpenSettings.Text = "Settings";
            btnOpenSettings.Click += btnOpenSettings_Click;
            // 
            // cmbFavoriteTeam
            // 
            cmbFavoriteTeam.FormattingEnabled = true;
            cmbFavoriteTeam.Location = new Point(203, 55);
            cmbFavoriteTeam.Name = "cmbFavoriteTeam";
            cmbFavoriteTeam.Size = new Size(179, 23);
            cmbFavoriteTeam.TabIndex = 1;
            cmbFavoriteTeam.SelectedIndexChanged += cmbFavoriteTeam_SelectedIndexChanged;
            // 
            // lblFavoriteTeam
            // 
            lblFavoriteTeam.AutoSize = true;
            lblFavoriteTeam.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFavoriteTeam.Location = new Point(42, 48);
            lblFavoriteTeam.Name = "lblFavoriteTeam";
            lblFavoriteTeam.RightToLeft = RightToLeft.No;
            lblFavoriteTeam.Size = new Size(143, 30);
            lblFavoriteTeam.TabIndex = 2;
            lblFavoriteTeam.Text = "Favorite team:";
            // 
            // pnlAllPlayers
            // 
            pnlAllPlayers.Location = new Point(42, 137);
            pnlAllPlayers.Name = "pnlAllPlayers";
            pnlAllPlayers.Size = new Size(350, 377);
            pnlAllPlayers.TabIndex = 3;
            // 
            // pnlFavoritePlayers
            // 
            pnlFavoritePlayers.Location = new Point(414, 137);
            pnlFavoritePlayers.Name = "pnlFavoritePlayers";
            pnlFavoritePlayers.Size = new Size(350, 377);
            pnlFavoritePlayers.TabIndex = 4;
            // 
            // lblAllPlayers
            // 
            lblAllPlayers.AutoSize = true;
            lblAllPlayers.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAllPlayers.Location = new Point(54, 113);
            lblAllPlayers.Name = "lblAllPlayers";
            lblAllPlayers.Size = new Size(82, 21);
            lblAllPlayers.TabIndex = 0;
            lblAllPlayers.Text = "All players";
            // 
            // lblFavoritePlayers
            // 
            lblFavoritePlayers.AutoSize = true;
            lblFavoritePlayers.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFavoritePlayers.Location = new Point(414, 113);
            lblFavoritePlayers.Name = "lblFavoritePlayers";
            lblFavoritePlayers.Size = new Size(119, 21);
            lblFavoritePlayers.TabIndex = 5;
            lblFavoritePlayers.Text = "Favorite Players";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 537);
            Controls.Add(lblFavoritePlayers);
            Controls.Add(lblAllPlayers);
            Controls.Add(pnlFavoritePlayers);
            Controls.Add(pnlAllPlayers);
            Controls.Add(lblFavoriteTeam);
            Controls.Add(cmbFavoriteTeam);
            Controls.Add(toolStrip1);
            Name = "MainForm";
            Text = "Form1";
            Load += MainForm_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton btnOpenSettings;
        private ComboBox cmbFavoriteTeam;
        private Label lblFavoriteTeam;
        private FlowLayoutPanel pnlAllPlayers;
        private FlowLayoutPanel pnlFavoritePlayers;
        private Label lblAllPlayers;
        private Label lblFavoritePlayers;
    }
}
