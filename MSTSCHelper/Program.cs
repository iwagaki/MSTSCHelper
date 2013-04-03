using System;
using System.Runtime.InteropServices;
using System.Net.Sockets;
using System.Net;

namespace MSTSCHelper
{
    static class Program
    {
        private const int SW_SHOWNORMAL = 1;
        private const int SW_SHOWMINIMIZED = 2;
        private const int SW_SHOWMAXIMIZED = 3;

        private const int LISTEN_PORT = 11000;

        [STAThread]
        static void Main()
        {
            Boolean done = false;
            UdpClient listener = new UdpClient(LISTEN_PORT);
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, LISTEN_PORT);

            try
            {
                while (!done)
                {
                    listener.Receive(ref groupEP);
                    showMSTSC(SW_SHOWMINIMIZED);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
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
