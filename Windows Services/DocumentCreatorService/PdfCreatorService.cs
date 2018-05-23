using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace DocumentCreatorService
{
    public class PdfCreatorService /*: ServiceControl*/
    {
        private int counter;
        private FileSequenceProcessor fileSequenceProcessor;

        /*public bool Start(HostControl hostControl)
        {
            fileSequenceProcessor = new FileSequenceProcessor();
            counter = int.MinValue;
            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            return true;
        }*/

        public void Handler()
        {
            fileSequenceProcessor = new FileSequenceProcessor();
            fileSequenceProcessor.ProcessFolder();
        }

        
    }
}
