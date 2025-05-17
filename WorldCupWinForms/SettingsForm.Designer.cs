namespace WorldCupWinForms
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            lblTournament = new Label();
            cmbTournament = new ComboBox();
            lblLanguage = new Label();
            cmbLanguage = new ComboBox();
            btnConfirm = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblTournament
            // 
            resources.ApplyResources(lblTournament, "lblTournament");
            lblTournament.Name = "lblTournament";
            // 
            // cmbTournament
            // 
            resources.ApplyResources(cmbTournament, "cmbTournament");
            cmbTournament.FormattingEnabled = true;
            cmbTournament.Name = "cmbTournament";
            // 
            // lblLanguage
            // 
            resources.ApplyResources(lblLanguage, "lblLanguage");
            lblLanguage.Name = "lblLanguage";
            // 
            // cmbLanguage
            // 
            resources.ApplyResources(cmbLanguage, "cmbLanguage");
            cmbLanguage.FormattingEnabled = true;
            cmbLanguage.Name = "cmbLanguage";
            // 
            // btnConfirm
            // 
            resources.ApplyResources(btnConfirm, "btnConfirm");
            btnConfirm.Name = "btnConfirm";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click_1;
            // 
            // btnCancel
            // 
            resources.ApplyResources(btnCancel, "btnCancel");
            btnCancel.Name = "btnCancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click_1;
            // 
            // SettingsForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnCancel);
            Controls.Add(btnConfirm);
            Controls.Add(cmbLanguage);
            Controls.Add(lblLanguage);
            Controls.Add(cmbTournament);
            Controls.Add(lblTournament);
            Name = "SettingsForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTournament;
        private ComboBox cmbTournament;
        private Label lblLanguage;
        private ComboBox cmbLanguage;
        private Button btnConfirm;
        private Button btnCancel;
    }
}