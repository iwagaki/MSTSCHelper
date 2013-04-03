using System;
using System.Net.Sockets;
using System.Text;

namespace MinimizeMSTSC
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            string addr = "localhost";
            if (args.Length > 0)
                addr = args[0];

            UdpClient udpClient = new UdpClient(addr, 11000);
            Byte[] sendBytes = Encoding.ASCII.GetBytes("!");
            try
            {
                udpClient.Send(sendBytes, sendBytes.Length);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
