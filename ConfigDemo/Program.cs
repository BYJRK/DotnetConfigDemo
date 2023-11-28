using System.Configuration;
using ConfigDemo.Core;
using ConfigDemo.Shared;
using ConfigDemo.Shared.Settings;

Console.WriteLine("Loading configuration file...");

var config = GlobalSettings.Instance;

var settings = UserSettings.Instance;

Console.WriteLine("Configuration file loaded.");

var device = new MyDevice(settings);
device.Foo();

Console.WriteLine("Press any key to exit...");
Console.ReadKey();