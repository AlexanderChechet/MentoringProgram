using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace RabbitMQHelper
{
    public class DirectQueue
    {
        public string QueueName { get; private set; }

        private IConnection connection;
        private IModel channel;
        private MessageHelper messageHelper;

        public DirectQueue() : this(Constants.DocumentQueueName)
        {
        }

        public DirectQueue(string name)
        {
            messageHelper = new MessageHelper();
            QueueName = name;
            var factory = new ConnectionFactory() { HostName = Constants.Host };
            connection = factory.CreateConnection();
            channel = connection.CreateModel();
            channel.ExchangeDeclare(QueueName, "direct");
        }

        public void Send(byte[] data)
        {
            var blocks = messageHelper.GetMessageBlocks(data);
            for (int i = 0; i < blocks.Length; i++)
            {
                channel.BasicPublish(QueueName, "", null, blocks[i].ToBytes());
            }
            
        }

        public void Dispose()
        {
            channel.Dispose();
            connection.Dispose();
        }
    }
}
