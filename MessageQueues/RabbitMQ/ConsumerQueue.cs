using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitMQHelper
{
    public class ConsumerQueue : IDisposable
    {
        private string queueName;

        private IConnection connection;
        private IModel channel;
        private EventingBasicConsumer consumer;
        private MessageHelper messageHelper;

        public EventHandler DocumentRecievedHandler;

        public ConsumerQueue(string exchange, string type)
        {
            messageHelper = new MessageHelper();
            var factory = new ConnectionFactory() {HostName = Constants.Host};
            connection = factory.CreateConnection();
            channel = connection.CreateModel();
            channel.ExchangeDeclare(exchange, type);
            queueName = channel.QueueDeclare().QueueName;
            channel.QueueBind(queueName, exchange, "");
            consumer = new EventingBasicConsumer(channel);
            consumer.Received += Recieve;
            channel.BasicConsume(queueName, true, consumer);
        }

        private void Recieve(object sender, BasicDeliverEventArgs args)
        {
            byte[] data;
            if (messageHelper.TryGetMessageFromBlocks(args.Body.FromBytes(), out data))
            {
                DocumentRecievedHandler(data, null);
            }
        }

        public void Dispose()
        {
            channel.Dispose();
            connection.Dispose();
        }
    }
}