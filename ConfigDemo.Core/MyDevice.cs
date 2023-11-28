using ConfigDemo.Shared.Settings;

namespace ConfigDemo.Core;

public class MyDevice
{
    private readonly UserSettings settings = UserSettings.Instance;

    public void Foo()
    {
        Console.WriteLine($"WindowSize: {settings.WindowSize}");
        Console.WriteLine($"Flag: {settings.Flag}");
        Console.WriteLine($"Interval: {settings.Interval}");
    }

    public void ModifyParams()
    {
        settings.Interval = 1024;
        settings.Flag = false;
    }
}