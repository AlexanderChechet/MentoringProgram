using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQHelper
{
    public static class Constants
    {
        public const string DocumentQueueName = "DocumentsQueue";
        public const string ConfigurationQueueName = "ConfigurationQueue";
        public const string Host = "localhost";
        public const string FanoutQueueType = "fanout";
        public const string DirectQueueType = "direct";
    }
}
