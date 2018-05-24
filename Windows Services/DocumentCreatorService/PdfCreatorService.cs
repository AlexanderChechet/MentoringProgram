using System.Threading;
using Topshelf;

namespace DocumentCreatorService
{
    public class PdfCreatorService : ServiceControl
    {
        private readonly FileSequenceProcessor fileSequenceProcessor;
        private readonly Timer timer;

        public PdfCreatorService()
        {
            timer = new Timer(Handler);
            fileSequenceProcessor = new FileSequenceProcessor();
        }

        public bool Start(HostControl hostControl)
        {
            timer.Change(0, 10000);
            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            timer.Change(Timeout.Infinite, 0);
            fileSequenceProcessor.ProcessUnfinishedSequence();
            return true;
        }

        private void Handler(object obj)
        {
            int count = fileSequenceProcessor.Counter;
            fileSequenceProcessor.ProcessFolder();
            if (count == fileSequenceProcessor.Counter)
                fileSequenceProcessor.ProcessUnfinishedSequence();
        }

        
    }
}
