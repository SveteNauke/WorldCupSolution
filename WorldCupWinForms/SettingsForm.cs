using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;
using WorldCupData.Config;
using WorldCupData.Enums;
using WorldCupWinForms.Localization;


namespace WorldCupWinForms
{
    public partial class SettingsForm : Form
    {

        public Language SelectedLanguage { get; private set; }
        public TournamentType SelectedTournament { get; private set; }

        public SettingsForm(Language language)
        {
            LocalizationHelper.SetCulture(language);
            InitializeComponent();

            LocalizationHelper.ApplyLocalization(this);

            AcceptButton = btnConfirm;
            CancelButton = btnCancel;

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

            SelectedLanguage = (Language)cmbLanguage.SelectedItem;
            SelectedTournament = (TournamentType)cmbTournament.SelectedItem;

            var config = new AppConfig
            {
                Language = SelectedLanguage,
                Tournament = SelectedTournament
            };

            config.Save();

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
