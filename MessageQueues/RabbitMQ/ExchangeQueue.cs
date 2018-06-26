using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Framing;

namespace RabbitMQHelper
{
    public class ExchangeQueue : IDisposable
    {
        public string QueueName { get; private set; }

        private IConnection connection;
        private IModel channel;

        public ExchangeQueue() : this(Constants.ConfigurationQueueName)
        {
        }

        public ExchangeQueue(string name)
        {
            QueueName = name;
            var factory = new ConnectionFactory() { HostName = Constants.Host };
            connection = factory.CreateConnection();
            channel = connection.CreateModel();
            channel.ExchangeDeclare(QueueName, "fanout");
        }

        public void Publish(byte[] data)
        {
            channel.BasicPublish(QueueName, "", null, data);
        }

        public void Dispose()
        {
            channel.Dispose();
            connection.Dispose();
        }
    }
}
