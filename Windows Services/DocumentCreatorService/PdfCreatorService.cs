using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace DocumentCreatorService
{
    public class PdfCreatorService : ServiceControl
    {
        private const string FOLDER_PATH = @"C:\ImagesToProcess";
        private const string PREFIX = "prefix";

        public bool Start(HostControl hostControl)
        {
            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            return true;
        }

        public static string[] CheckFolder()
        {
            return Directory.GetFiles(FOLDER_PATH);
        }

        public static void ProcessFiles(string[] files)
        {
            PdfCreator creator = null;
            int previous = -2;
            for (int i = 0; i < files.Length; i++)
            {
                var fileinfo = new FileInfo(files[i]);
                if (fileinfo.Name.Contains(PREFIX))
                {
                    int current;
                    var spritResult = fileinfo.Name.Split('_', '.');
                    if (int.TryParse(spritResult[1], out current))
                    {
                        if (current - previous < 1)
                            continue;
                        else if (current - previous > 1)
                        {
                            if (creator != null)
                                creator.Save(previous + ".pdf");
                            creator = new PdfCreator();
                            creator.AddImage(fileinfo.FullName);
                        }
                        else
                        {
                            creator.AddImage(fileinfo.FullName);
                        }
                        previous = current;
                    }
                }
            }
            if (creator != null)
                creator.Save(previous + ".pdf");
        }
    }
}
