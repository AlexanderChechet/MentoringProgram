using SocketHelper;
using System;
using System.Collections.Concurrent;
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
        private ConcurrentDictionary<Guid, Client> connectedClients;
        private ConcurrentDictionary<Guid, Socket> socketQueue;
        private Socket server;
        private IPEndPoint endPoint;

        public Server()
        {
            connectedClients = new ConcurrentDictionary<Guid, Client>();
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
                    var socket = server.Accept();
                    Task.Run(() => Initialize(socket));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Can't accept client.", ex.Message);
                }
            }
        }

        private void Initialize(Socket socket)
        {
            Socket storedSocket;
            var stringGuid = socket.RecieveMessage();
            var guid = Guid.Parse(stringGuid);
            if (!socketQueue.ContainsKey(guid))
            {
                socketQueue.TryAdd(guid, socket);
            }
            else
            {
                socketQueue.TryRemove(guid, out storedSocket);
                var storedPort = (storedSocket.RemoteEndPoint as IPEndPoint).Port;
                var port = (socket.RemoteEndPoint as IPEndPoint).Port;
                if (port == storedPort)
                    throw new ArgumentException("Wrong connection port");
                var client = new Client();
                client.Id = guid;
                if (port > storedPort)
                {
                    client.Input = socket;
                    client.Output = storedSocket;
                }
                else
                {
                    client.Input = storedSocket;
                    client.Output = socket;
                }
                client.Name = client.Input.RecieveMessage();
                connectedClients.TryAdd(client.Id, client);
                Broadcast(client.Id, $"{client.Name} connected.");
                Task.Run(() => ProcessClient(client));
            }
        }

        private void Broadcast(Guid id, string message)
        {
            Console.WriteLine("Broadcast:" + message);
            var list = connectedClients.Where(x => x.Key != id).Select(y => y.Value.Output);
            Parallel.ForEach<Socket>(list, x => x.SendMessage(message));
        }

        private void ProcessClient(Client client)
        {
            /*var clientName = RecieveMessage(socket);
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
            Console.WriteLine(clientName + " Disconnected");*/
        }

        
    }
}
