using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UDPClient
{
    public class Program
    {
        static void Main(string[] args)
        {
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            var ip = IPAddress.Loopback; // gives us the local IP

            var port = 27001;

            EndPoint ep = new IPEndPoint(ip, port);

            try
            {
                while (true)
                {
                    var msg = Console.ReadLine();
                    var bytes = Encoding.UTF8.GetBytes(msg);
                    socket.SendTo(bytes, ep);
                    Console.WriteLine("Message was sent");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }
    }
}
