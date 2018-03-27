using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace SocketHelper
{
    public static class SocketExtensions
    {
        public static string RecieveMessage(this Socket socket, int size = 0)
        {
            string result = String.Empty;
            try
            {
                if (size != 0)
                {
                    byte[] messageArray = new byte[size];
                    socket.Receive(messageArray, size, SocketFlags.None);
                    result = Encoding.UTF8.GetString(messageArray);
                }
                else
                {
                    byte[] messageArray = new byte[100];
                    var length = socket.Receive(messageArray);
                    result = Encoding.UTF8.GetString(messageArray, 0, length);
                }
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Can't recieve message. ", ex.Message);
            }
            return result;
        }

        public static void SendMessage(this Socket socket, string message)
        {
            try
            {
                var messageArray = Encoding.UTF8.GetBytes(message);
                socket.Send(messageArray, messageArray.Length, SocketFlags.None);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Can't send message.", ex.Message);
            }
        }
    }
}
