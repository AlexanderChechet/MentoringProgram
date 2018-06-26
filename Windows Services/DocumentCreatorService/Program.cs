﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace DocumentCreatorService
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new PdfCreatorService();
            service.Start();
            /*HostFactory.Run(
                x => {
                    x.Service<PdfCreatorService>();
                    x.SetServiceName("PdfCreatorService");
                    x.SetDescription("Create Pdf document from images");
                    x.SetDisplayName("PdfCreatorService");
                    x.StartAutomaticallyDelayed();
                    x.RunAsLocalService();
                    });*/
        }
    }
}
