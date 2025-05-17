using WorldCupData.Config;
using System.Globalization;
using System.Threading;
using WorldCupData.Enums;
using System;


namespace WorldCupWinForms
{
    internal static class Program
    {

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            ApplicationConfiguration.Initialize();

            var config = AppConfig.Load();

            if (config == null)
            {
                var settingsForm = new SettingsForm();
                if (settingsForm.ShowDialog() != DialogResult.OK)
                    return;

                config = AppConfig.Load();
            }

            var culture = config.Language == WorldCupData.Enums.Language.Croatian ? "hr" : "en";
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);


            Application.Run(new MainForm(config));
        }
    }
}