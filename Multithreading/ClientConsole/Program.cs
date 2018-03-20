using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            var localEndPoint = new IPEndPoint(IPAddress.Loopback, 101);
            var serverEndPoint = new IPEndPoint(IPAddress.Loopback, 100);
            socket.Bind(localEndPoint);
            Console.WriteLine("Try to connect");
            socket.Connect(serverEndPoint);
            Console.WriteLine("Connected");
            byte[] messageArray = new byte[100];
            var length = socket.Receive(messageArray);
            var message = Encoding.UTF8.GetString(messageArray);
            Console.WriteLine($"Message recieved : {message}");
            Console.ReadKey();
        }
    }
}
