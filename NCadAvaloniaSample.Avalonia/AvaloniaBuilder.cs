using Avalonia;

namespace NCadAvaloniaSample;

public static class AvaloniaBuilder
{
    public static bool WasntBuilt { get; private set; } = true;

    public static AppBuilder BuildApp()
    {
        var builder = AppBuilder.Configure<App>()
                                .UsePlatformDetect()
                                .WithInterFont()
                                .SetupWithoutStarting();

        WasntBuilt = false;

        return builder;
    }
}
