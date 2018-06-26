using System.Text;
using RabbitMQHelper;
using System.Threading;
using Topshelf;

namespace DocumentCreatorService
{
    public class PdfCreatorService //: ServiceControl
    {
        private DirectQueue documentQueue;
        private readonly FileSequenceProcessor fileSequenceProcessor;
        private readonly Timer timer;

        public PdfCreatorService()
        {
            timer = new Timer(Handler);
            fileSequenceProcessor = new FileSequenceProcessor();
        }

        public bool Start(/*HostControl hostControl*/)
        {
            documentQueue = new DirectQueue();
            timer.Change(0, 10000);
            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            timer.Change(Timeout.Infinite, 0);
            var result = fileSequenceProcessor.ProcessUnfinishedSequence();
            if (result != null)
                documentQueue.Send(result);
            documentQueue.Dispose();
            return true;
        }

        private void Handler(object obj)
        {
            int count = fileSequenceProcessor.Counter;
            var result = fileSequenceProcessor.ProcessFolder();
            if (result != null)
                documentQueue.Send(result);
            if (count == fileSequenceProcessor.Counter)
            {
                result = fileSequenceProcessor.ProcessUnfinishedSequence();
                if (result != null)
                    documentQueue.Send(result);
            }
        }

        
    }
}
