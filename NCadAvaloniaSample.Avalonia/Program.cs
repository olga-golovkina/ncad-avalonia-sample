using Avalonia;
using System;

namespace NCadAvaloniaSample.Avalonia;


/*
 * Пусть будет филлером для случая, когда понадобится тестить окно без привязки к nanoCAD.
 * Достаточно просто назначить проект в качестве запускаемого.
 */
public static class Program
{
    [STAThread]
    public static void Main(string[] args) => BuildAvaloniaApp()
        .StartWithClassicDesktopLifetime(args);

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp() => 
        AppBuilder.Configure<App>()
                  .UsePlatformDetect()
                  .WithInterFont()
                  .LogToTrace();
}
