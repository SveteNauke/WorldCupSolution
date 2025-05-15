using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorldCupData.Config;
using WorldCupData.Enums;

namespace WorldCupWinForms
{
    public partial class SettingsForm : Form
    {

        public SettingsForm()
        {
            InitializeComponent();

            this.AcceptButton = btnConfirm;
            this.CancelButton = btnCancel;

            cmbLanguage.DataSource = Enum.GetValues(typeof(Language));
            cmbTournament.DataSource = Enum.GetValues(typeof(TournamentType));
        }

        private void btnConfirm_Click_1(object sender, EventArgs e)
        {
            if (cmbLanguage.SelectedItem == null || cmbTournament.SelectedItem == null)
            {
                MessageBox.Show("Please select both language and tournament.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var config = new AppConfig
            {
                Language = (Language)cmbLanguage.SelectedItem,
                Tournament = (TournamentType)cmbTournament.SelectedItem
            };

            config.Save();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
