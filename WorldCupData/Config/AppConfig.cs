using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WorldCupData.Enums;

namespace WorldCupData.Config
{
    public class AppConfig
    {
        private static readonly string ConfigFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.txt");

        public Language Language { get; set; }
        public TournamentType Tournament { get; set; }

        public void Save()
        {
            try
            {
                var lines = new[]
                {
                    $"Language={Language}",
                    $"Tournament={Tournament}"

                };

                File.WriteAllLines(ConfigFilePath, lines);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Greška prilikom spremnja postavki: {ex.Message}");
            }
        }

        public static AppConfig Load()
        {
            try
            {
                if (!File.Exists(ConfigFilePath))
                {
                    return null;
                }

                var config = new AppConfig();
                var lines = File.ReadAllLines(ConfigFilePath);

                foreach (var line in lines)
                {
                    var parts = line.Split('=');

                    switch (parts[0])
                    {
                        case "Language":
                            if (Enum.TryParse(parts[1],  out Language lang))
                            {
                                config.Language = lang;
                            }
                            break;
                        case "Tournament":
                            if (Enum.TryParse(parts[1], out TournamentType tour))
                            {
                                config.Tournament = tour;
                            }
                            break;
                    }
                }

                return config;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Greška prilikom isčitavanja postavli: {ex.Message}");
                return null;
            }
        }
    }
}
