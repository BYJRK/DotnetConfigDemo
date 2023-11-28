using System.Configuration;
using ConfigDemo.Core;
using ConfigDemo.Shared;

Console.WriteLine("Loading configuration file...");

var settings = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

GlobalSettings.Setup(settings);

Console.WriteLine("Configuration file loaded.");

var device = new MyDevice();
device.Foo();
device.ModifyParams();

GlobalSettings.Instance.Save();

Console.WriteLine("Press any key to exit...");
Console.ReadKey();