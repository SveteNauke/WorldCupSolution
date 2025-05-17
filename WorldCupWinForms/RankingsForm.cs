using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using WorldCupData.Enums;
using WorldCupData.Interfaces;
using WorldCupData.Models;
using WorldCupData.Services;

namespace WorldCupWinForms
{
    public partial class RankingsForm : Form
    {
        private readonly string _fifaCode;
        private readonly TournamentType _tournament;
        private readonly IDataProvider _provider;

        public RankingsForm(string fifaCode, TournamentType tournament)
        {
            InitializeComponent();
            _fifaCode = fifaCode;
            _tournament = tournament;
            _provider = new JsonDataProvider();

            //this.Load += RankingsForm_Load_1;
            printDocument1.PrintPage += printDocument1_PrintPage;
        }

        private async void RankingsForm_Load_1(object sender, EventArgs e)
        {
            var matches = await _provider.GetMatchesAsync(_tournament);
            var teamMatches = matches
                .Where(m => m.HomeTeam.Code == _fifaCode || m.AwayTeam.Code == _fifaCode)
                .ToList();

            FillScorers(teamMatches);
            FillCards(teamMatches);
            FillAttendance(teamMatches);
        }

        private void FillScorers(List<Match> matches)
        {
            var goalEvents = new List<TeamEvent>();

            foreach (var match in matches)
            {
                if (match.HomeTeam.Code == _fifaCode)
                    goalEvents.AddRange(match.HomeTeamEvents.Where(e => e.TypeOfEvent == "goal"));

                if (match.AwayTeam.Code == _fifaCode)
                    goalEvents.AddRange(match.AwayTeamEvents.Where(e => e.TypeOfEvent == "goal"));
            }

            var grouped = goalEvents
                .GroupBy(e => e.Player)
                .Select(g => new
                {
                    Player = g.Key,
                    Goals = g.Count()
                })
                .OrderByDescending(g => g.Goals)
                .ToList();

            lvScorers.Items.Clear();
            foreach (var g in grouped)
            {
                var item = new ListViewItem(g.Player);
                item.SubItems.Add(g.Goals.ToString());
                lvScorers.Items.Add(item);
            }
        }

        private void FillCards(List<Match> matches)
        {
            var cardEvents = new List<TeamEvent>();

            foreach (var match in matches)
            {
                if (match.HomeTeam.Code == _fifaCode)
                    cardEvents.AddRange(match.HomeTeamEvents.Where(e => e.TypeOfEvent == "yellow-card"));

                if (match.AwayTeam.Code == _fifaCode)
                    cardEvents.AddRange(match.AwayTeamEvents.Where(e => e.TypeOfEvent == "yellow-card"));
            }

            var grouped = cardEvents
                .GroupBy(e => e.Player)
                .Select(g => new
                {
                    Player = g.Key,
                    Cards = g.Count()
                })
                .OrderByDescending(g => g.Cards)
                .ToList();

            lvCards.Items.Clear();
            foreach (var g in grouped)
            {
                var item = new ListViewItem(g.Player);
                item.SubItems.Add(g.Cards.ToString());
                lvCards.Items.Add(item);
            }
        }

        private void FillAttendance(List<Match> matches)
        {
            var attendanceMatches = matches
                .Where(m => m.Attendance is not null)
                .OrderByDescending(m => m.Attendance)
                .ToList();

            lvAttendance.Items.Clear();
            foreach (var match in attendanceMatches)
            {
                var item = new ListViewItem(match.Venue);
                item.SubItems.Add(match.Attendance);
                item.SubItems.Add(match.HomeTeam.Country);
                item.SubItems.Add(match.AwayTeam.Country);
                lvAttendance.Items.Add(item);
            }
        }
        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            float x = 50;
            float y = 50;
            float lineHeight = 20;

            ExportView(lvScorers, e.Graphics, ref x, ref y, lineHeight, "Top Scorers");
            ExportView(lvCards, e.Graphics, ref x, ref y, lineHeight, "Yellow Cards");
            ExportView(lvAttendance, e.Graphics, ref x, ref y, lineHeight, "Attendance");

            e.HasMorePages = false;
        }

        private void ExportView(ListView lv, Graphics g, ref float x, ref float y, float lineHeight, string title)
        {
            Font bold = new Font("Arial", 10, FontStyle.Bold);
            Font normal = new Font("Arial", 10);

            g.DrawString(title, bold, Brushes.Black, x, y);
            y += lineHeight;

            // Headers
            for (int i = 0; i < lv.Columns.Count; i++)
            {
                g.DrawString(lv.Columns[i].Text, bold, Brushes.Black, x + i * 150, y);
            }

            y += lineHeight;

            // Rows
            foreach (ListViewItem item in lv.Items)
            {
                for (int i = 0; i < item.SubItems.Count; i++)
                {
                    g.DrawString(item.SubItems[i].Text, normal, Brushes.Black, x + i * 150, y);
                }
                y += lineHeight;
            }

            y += 30;
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;

            printPreviewDialog1.Width = 1000;
            printPreviewDialog1.Height = 800;
            printPreviewDialog1.PrintPreviewControl.Zoom = 1.0;

            printPreviewDialog1.ShowDialog();
        }

        private void btnPdf_Click(object sender, EventArgs e)
        {
            ExportToPdf();
        }

        private void ExportToPdf()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                saveFileDialog.Title = "Save PDF";
                saveFileDialog.FileName = "Rankings.pdf";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    printDocument1.PrinterSettings.PrinterName = "Microsoft Print to PDF";
                    printDocument1.PrinterSettings.PrintToFile = true;
                    printDocument1.PrinterSettings.PrintFileName = saveFileDialog.FileName;

                    try
                    {
                        printDocument1.Print();
                        MessageBox.Show("Exported successfully to PDF!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error exporting PDF: " + ex.Message);
                    }
                }
            }
        }


    }
}
