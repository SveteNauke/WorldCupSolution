using System.Configuration;
using System.Data;
using System.IO;
using System.Windows;
using WorldCupData.Config;
using WorldCupData.Enums;

namespace WorldCupWPF;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public static AppConfig? Config { get; private set; }
    public static string? Resolution { get; private set; }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;


        Config = AppConfig.Load();
        string resolutionFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "resolution.txt");

        if (Config == null || !File.Exists(resolutionFile))
        {
            var settingsWindow = new StartupSettingsWindow();
            if (settingsWindow.ShowDialog() != true)
            {
                Shutdown();
                return;
            }

            Config = settingsWindow.SelectedConfig;
            Resolution = settingsWindow.SelectedResolution;
        }
        else
        {
            Resolution = File.ReadAllText(resolutionFile);
        }

        var mainWindow = new MainWindow(Config);

        if (Resolution == "Fullscreen")
        {
            mainWindow.WindowStyle = WindowStyle.None;
            mainWindow.WindowState = WindowState.Maximized;
        }
        else
        {
            var parts = Resolution.Split('x');
            if (parts.Length == 2 && double.TryParse(parts[0], out double width) && double.TryParse(parts[1], out double height))
            {
                mainWindow.Width = width;
                mainWindow.Height = height;
            }
        }

        mainWindow.Show();
    }
}



