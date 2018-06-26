using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQHelper;
using Topshelf;

namespace DocumentCentralService
{
    public class PdfCentralService //: ServiceControl
    {
        private ConsumerQueue documentQueue;
        private ByteSequenceProcessor processor;

        public PdfCentralService()
        {
            processor = new ByteSequenceProcessor();
        }

        public bool Start(/*HostControl hostControl*/)
        {
            documentQueue = new ConsumerQueue(Constants.DocumentQueueName, Constants.DirectQueueType);
            documentQueue.DocumentRecievedHandler += Handler;
            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            documentQueue.Dispose();
            return true;
        }

        private void Handler(object sender, EventArgs args)
        {
            try
            {
                processor.ProcessSequence((byte[])sender);
            }
            catch (Exception e)
            {
                var logger = NLog.LogManager.GetCurrentClassLogger();
                logger.Error(e);
            }
        }
    }
}
