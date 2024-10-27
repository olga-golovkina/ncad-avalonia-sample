using Avalonia.Controls;
using Avalonia.Interactivity;

using NCadAvaloniaSample.Avalonia.Utils;

using System;

namespace NCadAvaloniaSample.Avalonia;

public partial class MainWindow : Window
{
    private EventHandler<RoutedEventArgs>? _windowWithOwnerLoaded;

    public MainWindow()
    {
        InitializeComponent();
    }

    public void ShowModeless(IntPtr ownerHandle)
    {
        _windowWithOwnerLoaded = (sender, _) => WindowWithOwner_Loaded(sender!, ownerHandle);

        Loaded += _windowWithOwnerLoaded;

        Show();
    }

    private void WindowWithOwner_Loaded(object sender, IntPtr ownerHandle)
    {
        if (sender is Window winSender &&
            ownerHandle is { } &&
            winSender.TryGetPlatformHandle()?.Handle is { } thisHandle)
        {
            /*
             * Обращаю внимание, что здесь нет никаких дополнительных действий, 
             * которые реализованы в методах Show* nanoCAD API, так как
             * некоторые члены класса закрыты от внешнего доступа.
             */

            /*
             * Из-за установки Owner таким способом в не срабатывает WindowStartupLocation=CenterOwner.
             * Это некритично если работа идет только с одним монитором.
             */
            WindowInteropUtils.SetOwner(thisHandle, ownerHandle);

            /*
             * По факту не работает. Окно nanoCAD все равно перехватывает фокус на себя.
             * Фокус возвращается только тогда, когда нажимается окно.
             * Activate, Topmost через WinAPI тоже не помогают.
             * Если найдется решение, то код будет обновлен.
             */
            WindowInteropUtils.SetFocus(thisHandle);
        }

        Loaded -= _windowWithOwnerLoaded;
    }
}