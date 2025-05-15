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
            lblTournament.AutoSize = true;
            lblTournament.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTournament.Location = new Point(55, 66);
            lblTournament.Name = "lblTournament";
            lblTournament.Size = new Size(148, 32);
            lblTournament.TabIndex = 0;
            lblTournament.Text = "Tournament:";
            // 
            // cmbTournament
            // 
            cmbTournament.FormattingEnabled = true;
            cmbTournament.Location = new Point(209, 75);
            cmbTournament.Name = "cmbTournament";
            cmbTournament.Size = new Size(121, 23);
            cmbTournament.TabIndex = 1;
            // 
            // lblLanguage
            // 
            lblLanguage.AutoSize = true;
            lblLanguage.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLanguage.Location = new Point(80, 136);
            lblLanguage.Name = "lblLanguage";
            lblLanguage.Size = new Size(123, 32);
            lblLanguage.TabIndex = 2;
            lblLanguage.Text = "Language:";
            // 
            // cmbLanguage
            // 
            cmbLanguage.FormattingEnabled = true;
            cmbLanguage.Location = new Point(209, 145);
            cmbLanguage.Name = "cmbLanguage";
            cmbLanguage.Size = new Size(121, 23);
            cmbLanguage.TabIndex = 3;
            // 
            // btnConfirm
            // 
            btnConfirm.Location = new Point(80, 283);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(250, 45);
            btnConfirm.TabIndex = 4;
            btnConfirm.Text = "Confirm";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click_1;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(80, 344);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(250, 45);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click_1;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(434, 431);
            Controls.Add(btnCancel);
            Controls.Add(btnConfirm);
            Controls.Add(cmbLanguage);
            Controls.Add(lblLanguage);
            Controls.Add(cmbTournament);
            Controls.Add(lblTournament);
            Name = "SettingsForm";
            Text = "SettingsForm";
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