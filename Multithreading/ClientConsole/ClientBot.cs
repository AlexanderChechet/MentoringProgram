using SocketHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClientConsole
{
    public class ClientBot : IDisposable
    {
        private Guid id;
        private Random random;
        private Socket inputSocket;
        private Socket outputSocket;
        private string clienName;

        public ClientBot()
        {
            try
            {
                id = Guid.NewGuid();
                random = new Random();
                clienName = Constants.Names[random.Next(Constants.Names.Length)];
                var port = random.Next(100) + 100;
                var serverEndPoint = new IPEndPoint(IPAddress.Loopback, 100);
                //inputSocket
                inputSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                var localEndPoint = new IPEndPoint(IPAddress.Loopback, port);
                inputSocket.Bind(localEndPoint);
                //outputSocket
                outputSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                localEndPoint = new IPEndPoint(IPAddress.Loopback, port + 1);
                outputSocket.Bind(localEndPoint);

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
                var serverEndPoint = new IPEndPoint(IPAddress.Loopback, 100);
                inputSocket.Connect(serverEndPoint);
                inputSocket.SendMessage(id.ToString());
                outputSocket.Connect(serverEndPoint);
                outputSocket.SendMessage(id.ToString());
                outputSocket.SendMessage(clienName);
                Console.WriteLine("Connnected");
                Task.Run(() => ListenServer());
                Task.Run(() => DoWork());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Can't connect to server.", ex.Message);
            }
        }

        public void ListenServer()
        {
            while (inputSocket.Connected)
            {
                try
                {
                    var message = inputSocket.RecieveMessage();
                    Console.WriteLine(message);
                }
                catch(Exception e)
                {
                    //Console.WriteLine(e.Message);
                    Dispose();
                }
            }
        }

        public void DoWork()
        {
            while (outputSocket.Connected)
            {
                try
                {
                    Thread.Sleep(1000);
                    outputSocket.SendMessage("First");
                    Console.WriteLine("First");
                    Thread.Sleep(5000);
                    outputSocket.SendMessage("Second");
                    Console.WriteLine("Second");
                    Thread.Sleep(1000);
                    outputSocket.SendMessage("Third");
                    Console.WriteLine("Third");
                    Thread.Sleep(5000);
                }
                catch (Exception e)
                {
                    //Console.WriteLine(e.Message);
                    Dispose();
                }
            }
        }

        public void Dispose()
        {
            inputSocket.Close();
            outputSocket.Close();
        }
    }
}
