using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            var endPoint = new IPEndPoint(IPAddress.Loopback, 100);
            socket.Bind(endPoint);
            socket.Listen(4);
            var client = socket.Accept();
            Console.WriteLine("Connected");
            var message = "Hello";
            var messageArray = Encoding.UTF8.GetBytes(message);
            Console.WriteLine("Message send");
            client.Send(messageArray);
            Console.ReadKey();
        }
    }
}
