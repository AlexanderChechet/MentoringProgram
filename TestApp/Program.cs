using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using RabbitMQHelper;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var consumer = new ConsumerQueue(Constants.DocumentQueueName, Constants.DirectQueueType);
            consumer.DocumentRecievedHandler += Handler;
            Console.ReadKey();
            consumer.Dispose();
        }

        private static void Handler(object sender, EventArgs args)
        {
            var message = Encoding.UTF8.GetString((byte[]) sender);
            Console.WriteLine(message);
        }
    }
}
