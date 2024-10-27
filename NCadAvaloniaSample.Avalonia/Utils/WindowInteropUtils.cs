using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NCadAvaloniaSample.Avalonia.Utils;

internal static class WindowInteropUtils
{
    private const int GWL_HWNDPARENT = -8;

    [DllImport("user32.dll", SetLastError = true)]
    private static extern IntPtr SetWindowLongPtr(IntPtr hWnd, int nIndex, IntPtr newLong);

    [DllImport("user32.dll", SetLastError = true)]
    private static extern IntPtr SetWindowLong(IntPtr hWnd, int nIndex, IntPtr newLong);

    [DllImport("user32.dll")]
    private static extern bool SetForegroundWindow(IntPtr hWnd);

    public static nint SetOwner(IntPtr childHandle, IntPtr ownerHandle) => IntPtr.Size == 8
        ? SetWindowLongPtr(childHandle, GWL_HWNDPARENT, ownerHandle)
        : SetWindowLong(childHandle, GWL_HWNDPARENT, ownerHandle);

    public static bool SetFocus(IntPtr hWnd) => SetForegroundWindow(hWnd);
}
