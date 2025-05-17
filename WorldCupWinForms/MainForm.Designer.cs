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
            btnShowRankings = new Button();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            resources.ApplyResources(toolStrip1, "toolStrip1");
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnOpenSettings });
            toolStrip1.Name = "toolStrip1";
            // 
            // btnOpenSettings
            // 
            resources.ApplyResources(btnOpenSettings, "btnOpenSettings");
            btnOpenSettings.Alignment = ToolStripItemAlignment.Right;
            btnOpenSettings.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnOpenSettings.Name = "btnOpenSettings";
            btnOpenSettings.Click += btnOpenSettings_Click;
            // 
            // cmbFavoriteTeam
            // 
            resources.ApplyResources(cmbFavoriteTeam, "cmbFavoriteTeam");
            cmbFavoriteTeam.FormattingEnabled = true;
            cmbFavoriteTeam.Name = "cmbFavoriteTeam";
            cmbFavoriteTeam.SelectedIndexChanged += cmbFavoriteTeam_SelectedIndexChanged;
            // 
            // lblFavoriteTeam
            // 
            resources.ApplyResources(lblFavoriteTeam, "lblFavoriteTeam");
            lblFavoriteTeam.Name = "lblFavoriteTeam";
            // 
            // pnlAllPlayers
            // 
            resources.ApplyResources(pnlAllPlayers, "pnlAllPlayers");
            pnlAllPlayers.Name = "pnlAllPlayers";
            // 
            // pnlFavoritePlayers
            // 
            resources.ApplyResources(pnlFavoritePlayers, "pnlFavoritePlayers");
            pnlFavoritePlayers.Name = "pnlFavoritePlayers";
            // 
            // lblAllPlayers
            // 
            resources.ApplyResources(lblAllPlayers, "lblAllPlayers");
            lblAllPlayers.Name = "lblAllPlayers";
            // 
            // lblFavoritePlayers
            // 
            resources.ApplyResources(lblFavoritePlayers, "lblFavoritePlayers");
            lblFavoritePlayers.Name = "lblFavoritePlayers";
            // 
            // btnShowRankings
            // 
            resources.ApplyResources(btnShowRankings, "btnShowRankings");
            btnShowRankings.Name = "btnShowRankings";
            btnShowRankings.UseVisualStyleBackColor = true;
            btnShowRankings.Click += btnShowRankings_Click;
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnShowRankings);
            Controls.Add(lblFavoritePlayers);
            Controls.Add(lblAllPlayers);
            Controls.Add(pnlFavoritePlayers);
            Controls.Add(pnlAllPlayers);
            Controls.Add(lblFavoriteTeam);
            Controls.Add(cmbFavoriteTeam);
            Controls.Add(toolStrip1);
            Name = "MainForm";
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
        private Button btnShowRankings;
    }
}
