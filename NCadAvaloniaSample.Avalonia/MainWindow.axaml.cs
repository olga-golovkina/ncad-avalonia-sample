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
             * ������� ��������, ��� ����� ��� ������� �������������� ��������, 
             * ������� ����������� � ������� Show* nanoCAD API, ��� ���
             * ��������� ����� ������ ������� �� �������� �������.
             */

            /*
             * ��-�� ��������� Owner ����� �������� � �� ����������� WindowStartupLocation=CenterOwner.
             * ��� ���������� ���� ������ ���� ������ � ����� ���������.
             */
            WindowInteropUtils.SetOwner(thisHandle, ownerHandle);

            /*
             * �� ����� �� ��������. ���� nanoCAD ��� ����� ������������� ����� �� ����.
             * ����� ������������ ������ �����, ����� ���������� ����.
             * Activate, Topmost ����� WinAPI ���� �� ��������.
             * ���� �������� �������, �� ��� ����� ��������.
             */
            WindowInteropUtils.SetFocus(thisHandle);
        }

        Loaded -= _windowWithOwnerLoaded;
    }
}