using System.Configuration;

namespace ConfigDemo.Shared.Settings;

public sealed class UserSettings : ConfigurationSection
{
    public static UserSettings Instance { get; } = (UserSettings)GlobalConfigManager.Instance.GetSection("userSettings");
    
    [ConfigurationProperty("windowSize", DefaultValue = "100x100")]
    public string WindowSize
    {
        get => (string)this["windowSize"];
        set => this["windowSize"] = value;
    }

    [ConfigurationProperty("flag", DefaultValue = false)]
    public bool Flag
    {
        get => (bool)this["flag"];
        set => this["flag"] = value;
    }

    [ConfigurationProperty("interval", DefaultValue = 100)]
    public int Interval
    {
        get => (int)this["interval"];
        set => this["interval"] = value;
    }
}