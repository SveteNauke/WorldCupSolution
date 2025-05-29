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
        Application.Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;

        base.OnStartup(e);
        System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;

        AppConfig? config;
        string? resolution;
        string resolutionFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "resolution.txt");


        if (!File.Exists(AppConfig.ConfigFilePath) || !File.Exists(resolutionFile))
        {
            var startupWindow = new StartupSettingsWindow();
            bool? result = startupWindow.ShowDialog();

            if (result != true || startupWindow.SelectedConfig == null)
            {
                Shutdown();
                return;
            }

            config = startupWindow.SelectedConfig;
            resolution = startupWindow.SelectedResolution;
        }
        else
        {
            config = AppConfig.Load();
            resolution = File.ReadAllText(resolutionFile);
        }

        Config = config;
        Resolution = resolution;

        var mainWindow = new MainWindow(Config);

        if (resolution == "Fullscreen")
        {
            mainWindow.WindowStyle = WindowStyle.None;
            mainWindow.WindowState = WindowState.Maximized;
        }
        else
        {
            var parts = resolution.Split('x');
            if (parts.Length == 2 && double.TryParse(parts[0], out double width) && double.TryParse(parts[1], out double height))
            {
                mainWindow.Width = width;
                mainWindow.Height = height;
                mainWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            }
        }

        MainWindow = mainWindow;
        mainWindow.Show();
    }

}



