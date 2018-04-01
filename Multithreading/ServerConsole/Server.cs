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
            socketQueue = new ConcurrentDictionary<Guid, Socket>();
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
            var stringGuid = socket.RecieveMessage(36);
            var guid = Guid.Parse(stringGuid);
            if (!socketQueue.ContainsKey(guid))
            {
                if (socketQueue.TryAdd(guid, socket))
                    Console.WriteLine("Add");
                else
                    Console.WriteLine("Add error");
            }
            else
            {
                Console.WriteLine("Init");
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
            try
            {
                Parallel.ForEach<Socket>(list, x => x.SendMessage(message));
            }
            catch (Exception e)
            {
                Console.WriteLine("Can't broadcast message to all clients. Unhandled exception: " + e);
            }
            
        }
        private void ProcessClient(Client client)
        {
            while (client.Input.Connected)
            {
                try
                {
                    var message = client.Input.RecieveMessage();
                    Console.WriteLine($"Message from {client.Name}: {message}");
                    Broadcast(client.Id, $"{client.Name}: {message}");
                }
                catch (Exception e)
                {
                    Client a;
                    connectedClients.TryRemove(client.Id, out a);
                    client.Dispose();
                }
            }
        }

        
    }
}
