using System.Configuration;
using ConfigDemo.Shared.Settings;

namespace ConfigDemo.Shared;

public static class GlobalConfigManager
{
    public static Configuration Instance { get; }

    static GlobalConfigManager()
    {
        var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ConfigDemo.dll");
        Console.WriteLine(path);
        Instance = ConfigurationManager.OpenExeConfiguration(path);
        if(Instance.GetSection("userSettings") is null)
            Instance.Sections.Add("userSettings", new UserSettings());
        Instance.Save();
    }
}