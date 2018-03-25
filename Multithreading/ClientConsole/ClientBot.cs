using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientConsole
{
    public class ClientBot : IDisposable
    {
        private Random random;
        private Socket socket;
        private string clienName;
        private IPEndPoint localEndPoint;
        private IPEndPoint serverEndPoint;

        public ClientBot()
        {
            try
            {
                random = new Random();
                clienName = Constants.Names[random.Next(Constants.Names.Length)];
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                localEndPoint = new IPEndPoint(IPAddress.Loopback, 100 + random.Next(100));
                serverEndPoint = new IPEndPoint(IPAddress.Loopback, 100);
                socket.Bind(localEndPoint);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Can't create socket.", ex.Message);
            }
        }

        public void Start()
        {
            try
            {
                socket.Connect(serverEndPoint);
                DoWork();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Can't connect to server.", ex.Message);
            }
        }

        private void DoWork()
        {
            SendMessage(clienName);
            RecieveMessage();
        }

        private void RecieveMessage()
        {
            try
            {
                byte[] messageArray = new byte[100];
                var length = socket.Receive(messageArray);
                var message = Encoding.UTF8.GetString(messageArray);
                Console.WriteLine(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Can't recieve message. ", ex.Message);
            }
        }

        private void SendMessage(string message)
        {
            try
            {
                var messageArray = Encoding.UTF8.GetBytes(message);
                Console.WriteLine("Message send");
                socket.Send(messageArray);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Can't send message.", ex.Message);
            }
        }

        public void Dispose()
        {
            socket.Close();
        }
    }
}
