using ConfigDemo.Shared.Settings;

namespace ConfigDemo.Core;

public class MyDevice
{
    private readonly UserSettings settings;

    public MyDevice(UserSettings settings)
    {
        this.settings = settings;
    }

    public void Foo()
    {
        Console.WriteLine($"WindowSize: {settings.WindowSize}");
        Console.WriteLine($"Flag: {settings.Flag}");
        Console.WriteLine($"Interval: {settings.Interval}");
    }
}