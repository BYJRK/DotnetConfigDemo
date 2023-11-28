using System.Configuration;
using ConfigDemo.Shared.Settings;

namespace ConfigDemo.Shared;

public static class GlobalSettings
{
    // 确保当前类在初始化后被使用
    private static Configuration backfield = null!;

    public static Configuration Instance
    {
        get
        {
            if (backfield is null)
                throw new NullReferenceException($"{nameof(GlobalSettings)} 未初始化。");
            return backfield;
        }
        private set => backfield = value;
    }

    public static void Setup(Configuration configuration)
    {
        var map = new ExeConfigurationFileMap
        {
            ExeConfigFilename = "ConfigDemo.dll.config"
        };
        Instance = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
        if (Instance.GetSection("userSettings") is null)
            Instance.Sections.Add("userSettings", new UserSettings());

        Instance.Save();
    }
}