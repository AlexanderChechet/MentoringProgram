using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerConsole
{
    public class Server
    {
        private Dictionary<Socket, string> connectedClients;
        private Socket server;
        private IPEndPoint endPoint;

        public Server()
        {
            connectedClients = new Dictionary<Socket, string>();
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            endPoint = new IPEndPoint(IPAddress.Loopback, 100);
            server.Bind(endPoint);
        }

        public void Start()
        {
            server.Listen(4);
            while (true)
            {
                try
                {
                    var client = server.Accept();
                    ProcessClient(client);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Can't accept client.", ex.Message);
                }
            }
        }

        private void Broadcast(Socket sender, string message)
        {
            Console.WriteLine("Broadcast:" + message);
            var list = connectedClients.Where(x => x.Key != sender).Select(y => y.Key);
            Parallel.ForEach<Socket>(list, x => SendMessage(x, message));
        }

        private void ProcessClient(Socket socket)
        {
            var clientName = RecieveMessage(socket);
            Console.WriteLine(clientName + " Connected");
            connectedClients.Add(socket, clientName);
            Broadcast(socket, clientName + "connected");
            SendMessage(socket, "PROCESSED");
            if (socket.Connected)
            {
                try
                {
                    var message = RecieveMessage(socket);
                    Broadcast(socket, message);
                    SendMessage(socket, "PROCESSED");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Can't process cliet message.", ex.Message);
                } 
            }
            Console.WriteLine(clientName + " Disconnected");
        }

        private string RecieveMessage(Socket socket)
        {
            string result = String.Empty;
            try
            {
                byte[] messageArray = new byte[100];
                var length = socket.Receive(messageArray);
                result = Encoding.UTF8.GetString(messageArray);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Can't recieve message. ", ex.Message);
            }
            return result;
        }

        private void SendMessage(Socket socket, string message)
        {
            try
            {
                var messageArray = Encoding.UTF8.GetBytes(message);
                socket.Send(messageArray);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Can't send message.", ex.Message);
            }
        }
    }
}
