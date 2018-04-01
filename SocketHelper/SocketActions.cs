using System;
using System.Collections.Generic;
using System.Text;

namespace SocketHelper
{
    public class SocketActions
    {
        private string RecieveMessage(Socket socket)
        {
            string result = String.Empty;
            try
            {
                byte[] messageArray = new byte[100];
                var length = socket.Receive(messageArray);
                result = Encoding.UTF8.GetString(messageArray, 0, length);
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
