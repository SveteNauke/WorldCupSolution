namespace WorldCupWinForms
{
    partial class RankingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ListViewItem listViewItem1 = new ListViewItem("");
            ListViewItem listViewItem2 = new ListViewItem("");
            lblTitle = new Label();
            tabRankings = new TabControl();
            tabScorers = new TabPage();
            lvScorers = new ListView();
            colScorerName = new ColumnHeader();
            colScorerGoals = new ColumnHeader();
            btnClose = new Button();
            tabCards = new TabPage();
            lvCards = new ListView();
            colCardPlayerName = new ColumnHeader();
            colCardCount = new ColumnHeader();
            tabAttendance = new TabPage();
            lvAttendance = new ListView();
            colVenue = new ColumnHeader();
            colAttendance = new ColumnHeader();
            colHomeTeam = new ColumnHeader();
            colAwayTeam = new ColumnHeader();
            tabRankings.SuspendLayout();
            tabScorers.SuspendLayout();
            tabCards.SuspendLayout();
            tabAttendance.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(85, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Rank list";
            // 
            // tabRankings
            // 
            tabRankings.Controls.Add(tabScorers);
            tabRankings.Controls.Add(tabCards);
            tabRankings.Controls.Add(tabAttendance);
            tabRankings.Dock = DockStyle.Fill;
            tabRankings.Location = new Point(0, 25);
            tabRankings.Name = "tabRankings";
            tabRankings.SelectedIndex = 0;
            tabRankings.Size = new Size(800, 425);
            tabRankings.TabIndex = 1;
            // 
            // tabScorers
            // 
            tabScorers.Controls.Add(lvScorers);
            tabScorers.Controls.Add(btnClose);
            tabScorers.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabScorers.Location = new Point(4, 24);
            tabScorers.Name = "tabScorers";
            tabScorers.Padding = new Padding(3);
            tabScorers.Size = new Size(792, 397);
            tabScorers.TabIndex = 0;
            tabScorers.Text = "Scorers";
            tabScorers.UseVisualStyleBackColor = true;
            // 
            // lvScorers
            // 
            lvScorers.Columns.AddRange(new ColumnHeader[] { colScorerName, colScorerGoals });
            lvScorers.FullRowSelect = true;
            lvScorers.Items.AddRange(new ListViewItem[] { listViewItem1, listViewItem2 });
            lvScorers.Location = new Point(8, 16);
            lvScorers.Name = "lvScorers";
            lvScorers.Size = new Size(776, 312);
            lvScorers.TabIndex = 1;
            lvScorers.UseCompatibleStateImageBehavior = false;
            lvScorers.View = View.Details;
            // 
            // colScorerName
            // 
            colScorerName.Text = "Player";
            colScorerName.Width = 200;
            // 
            // colScorerGoals
            // 
            colScorerGoals.Text = "Goals";
            colScorerGoals.TextAlign = HorizontalAlignment.Center;
            colScorerGoals.Width = 80;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(652, 347);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(132, 42);
            btnClose.TabIndex = 0;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click_1;
            // 
            // tabCards
            // 
            tabCards.Controls.Add(lvCards);
            tabCards.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabCards.Location = new Point(4, 24);
            tabCards.Name = "tabCards";
            tabCards.Padding = new Padding(3);
            tabCards.Size = new Size(792, 397);
            tabCards.TabIndex = 1;
            tabCards.Text = "Cards";
            tabCards.UseVisualStyleBackColor = true;
            // 
            // lvCards
            // 
            lvCards.Columns.AddRange(new ColumnHeader[] { colCardPlayerName, colCardCount });
            lvCards.FullRowSelect = true;
            lvCards.Location = new Point(10, 19);
            lvCards.Name = "lvCards";
            lvCards.Size = new Size(776, 329);
            lvCards.TabIndex = 0;
            lvCards.UseCompatibleStateImageBehavior = false;
            lvCards.View = View.Details;
            // 
            // colCardPlayerName
            // 
            colCardPlayerName.Text = "Player";
            colCardPlayerName.Width = 200;
            // 
            // colCardCount
            // 
            colCardCount.Text = "Yellow Cards";
            colCardCount.Width = 100;
            // 
            // tabAttendance
            // 
            tabAttendance.Controls.Add(lvAttendance);
            tabAttendance.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabAttendance.Location = new Point(4, 24);
            tabAttendance.Name = "tabAttendance";
            tabAttendance.Size = new Size(792, 397);
            tabAttendance.TabIndex = 2;
            tabAttendance.Text = "Attendance";
            tabAttendance.UseVisualStyleBackColor = true;
            // 
            // lvAttendance
            // 
            lvAttendance.Columns.AddRange(new ColumnHeader[] { colVenue, colAttendance, colHomeTeam, colAwayTeam });
            lvAttendance.FullRowSelect = true;
            lvAttendance.Location = new Point(8, 14);
            lvAttendance.Name = "lvAttendance";
            lvAttendance.Size = new Size(776, 329);
            lvAttendance.TabIndex = 1;
            lvAttendance.UseCompatibleStateImageBehavior = false;
            lvAttendance.View = View.Details;
            // 
            // colVenue
            // 
            colVenue.Text = "Venue";
            colVenue.Width = 200;
            // 
            // colAttendance
            // 
            colAttendance.Text = "Attendance";
            colAttendance.Width = 100;
            // 
            // colHomeTeam
            // 
            colHomeTeam.Text = "Home Team";
            colHomeTeam.Width = 150;
            // 
            // colAwayTeam
            // 
            colAwayTeam.Text = "Away Team";
            colAwayTeam.Width = 150;
            // 
            // RankingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabRankings);
            Controls.Add(lblTitle);
            Name = "RankingsForm";
            Text = "RankingsForm";
            Load += RankingsForm_Load_1;
            tabRankings.ResumeLayout(false);
            tabScorers.ResumeLayout(false);
            tabCards.ResumeLayout(false);
            tabAttendance.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private TabControl tabRankings;
        private TabPage tabScorers;
        private TabPage tabCards;
        private TabPage tabAttendance;
        private ListView lvScorers;
        private Button btnClose;
        private ColumnHeader colScorerName;
        private ColumnHeader colScorerGoals;
        private ListView lvCards;
        private ColumnHeader colCardPlayerName;
        private ColumnHeader colCardCount;
        private ListView lvAttendance;
        private ColumnHeader colVenue;
        private ColumnHeader colAttendance;
        private ColumnHeader colHomeTeam;
        private ColumnHeader colAwayTeam;
    }
}