using System.Configuration;
using ConfigDemo.Shared;
using ConfigDemo.Shared.Settings;

Console.WriteLine("Loading configuration file...");

var config = GlobalConfigManager.Instance;

var settings = UserSettings.Instance;

Console.WriteLine("Configuration file loaded.");

Console.WriteLine($"WindowSize: {settings.WindowSize}");
Console.WriteLine($"Flag: {settings.Flag}");
Console.WriteLine($"Interval: {settings.Interval}");

Console.WriteLine("Press any key to exit...");
Console.ReadKey();