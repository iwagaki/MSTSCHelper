using System;
using System.Runtime.InteropServices;

namespace MaximizeMSTSC
{
    static class Program
    {
        private const int SW_SHOWNORMAL = 1;
        private const int SW_SHOWMINIMIZED = 2;
        private const int SW_SHOWMAXIMIZED = 3;

        [STAThread]
        static void Main()
        {
            showMSTSC(SW_SHOWMAXIMIZED);
        }

        static void showMSTSC(int nCmdShow)
        {
            IntPtr hWnd = FindWindow("TscShellContainerClass", null);
            if (!hWnd.Equals(IntPtr.Zero))
                ShowWindowAsync(hWnd, nCmdShow);
        }

        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);
    }
}
