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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RankingsForm));
            lblTitle = new Label();
            tabRankings = new TabControl();
            tabScorers = new TabPage();
            btnPdf = new Button();
            btnPreview = new Button();
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
            printDialog1 = new PrintDialog();
            printDocument1 = new System.Drawing.Printing.PrintDocument();
            printPreviewDialog1 = new PrintPreviewDialog();
            tabRankings.SuspendLayout();
            tabScorers.SuspendLayout();
            tabCards.SuspendLayout();
            tabAttendance.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            resources.ApplyResources(lblTitle, "lblTitle");
            lblTitle.Name = "lblTitle";
            // 
            // tabRankings
            // 
            resources.ApplyResources(tabRankings, "tabRankings");
            tabRankings.Controls.Add(tabScorers);
            tabRankings.Controls.Add(tabCards);
            tabRankings.Controls.Add(tabAttendance);
            tabRankings.Name = "tabRankings";
            tabRankings.SelectedIndex = 0;
            // 
            // tabScorers
            // 
            resources.ApplyResources(tabScorers, "tabScorers");
            tabScorers.Controls.Add(btnPdf);
            tabScorers.Controls.Add(btnPreview);
            tabScorers.Controls.Add(lvScorers);
            tabScorers.Controls.Add(btnClose);
            tabScorers.Name = "tabScorers";
            tabScorers.UseVisualStyleBackColor = true;
            // 
            // btnPdf
            // 
            resources.ApplyResources(btnPdf, "btnPdf");
            btnPdf.Name = "btnPdf";
            btnPdf.UseVisualStyleBackColor = true;
            btnPdf.Click += btnPdf_Click;
            // 
            // btnPreview
            // 
            resources.ApplyResources(btnPreview, "btnPreview");
            btnPreview.Name = "btnPreview";
            btnPreview.UseVisualStyleBackColor = true;
            btnPreview.Click += btnPreview_Click;
            // 
            // lvScorers
            // 
            resources.ApplyResources(lvScorers, "lvScorers");
            lvScorers.Columns.AddRange(new ColumnHeader[] { colScorerName, colScorerGoals });
            lvScorers.FullRowSelect = true;
            lvScorers.Items.AddRange(new ListViewItem[] { (ListViewItem)resources.GetObject("lvScorers.Items"), (ListViewItem)resources.GetObject("lvScorers.Items1") });
            lvScorers.Name = "lvScorers";
            lvScorers.UseCompatibleStateImageBehavior = false;
            lvScorers.View = View.Details;
            // 
            // colScorerName
            // 
            resources.ApplyResources(colScorerName, "colScorerName");
            // 
            // colScorerGoals
            // 
            resources.ApplyResources(colScorerGoals, "colScorerGoals");
            // 
            // btnClose
            // 
            resources.ApplyResources(btnClose, "btnClose");
            btnClose.Name = "btnClose";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click_1;
            // 
            // tabCards
            // 
            resources.ApplyResources(tabCards, "tabCards");
            tabCards.Controls.Add(lvCards);
            tabCards.Name = "tabCards";
            tabCards.UseVisualStyleBackColor = true;
            // 
            // lvCards
            // 
            resources.ApplyResources(lvCards, "lvCards");
            lvCards.Columns.AddRange(new ColumnHeader[] { colCardPlayerName, colCardCount });
            lvCards.FullRowSelect = true;
            lvCards.Name = "lvCards";
            lvCards.UseCompatibleStateImageBehavior = false;
            lvCards.View = View.Details;
            // 
            // colCardPlayerName
            // 
            resources.ApplyResources(colCardPlayerName, "colCardPlayerName");
            // 
            // colCardCount
            // 
            resources.ApplyResources(colCardCount, "colCardCount");
            // 
            // tabAttendance
            // 
            resources.ApplyResources(tabAttendance, "tabAttendance");
            tabAttendance.Controls.Add(lvAttendance);
            tabAttendance.Name = "tabAttendance";
            tabAttendance.UseVisualStyleBackColor = true;
            // 
            // lvAttendance
            // 
            resources.ApplyResources(lvAttendance, "lvAttendance");
            lvAttendance.Columns.AddRange(new ColumnHeader[] { colVenue, colAttendance, colHomeTeam, colAwayTeam });
            lvAttendance.FullRowSelect = true;
            lvAttendance.Name = "lvAttendance";
            lvAttendance.UseCompatibleStateImageBehavior = false;
            lvAttendance.View = View.Details;
            // 
            // colVenue
            // 
            resources.ApplyResources(colVenue, "colVenue");
            // 
            // colAttendance
            // 
            resources.ApplyResources(colAttendance, "colAttendance");
            // 
            // colHomeTeam
            // 
            resources.ApplyResources(colHomeTeam, "colHomeTeam");
            // 
            // colAwayTeam
            // 
            resources.ApplyResources(colAwayTeam, "colAwayTeam");
            // 
            // printDialog1
            // 
            printDialog1.UseEXDialog = true;
            // 
            // printPreviewDialog1
            // 
            resources.ApplyResources(printPreviewDialog1, "printPreviewDialog1");
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.Name = "printPreviewDialog1";
            // 
            // RankingsForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabRankings);
            Controls.Add(lblTitle);
            Name = "RankingsForm";
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
        private PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private Button btnPreview;
        private PrintPreviewDialog printPreviewDialog1;
        private Button btnPdf;
    }
}