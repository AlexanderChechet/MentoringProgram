using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace DocumentCentralService
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new PdfCentralService();
            service.Start();
            /*HostFactory.Run(
                x => {
                    x.Service<PdfCentralService>();
                    x.SetServiceName("PdfCentralService");
                    x.SetDescription("Central service for Pdf documents");
                    x.SetDisplayName("PdfCentralService");
                    x.StartAutomaticallyDelayed();
                    x.RunAsLocalService();
                });*/
        }
    }
}
