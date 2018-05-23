using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DocumentCreatorService
{
    public class FileSequenceProcessor
    {
        private List<string> sequence;
        private int counter;
        private int pdfCounter;
        private List<string> processList;
        private const string CORUPTED_FOLDER_PATH = @"C:\ServiceCoruptedFiles\";
        private const string OUTPUT_FOLDER_PATH = @"C:\ServicePdfs\";
        private const string INPUT_FOLDER_PATH = @"C:\ServiceImages\";
        private const string PREFIX = "img";

        private string inputFolder;
        private string outputFolder;
        private string coruptedFolder;
        private string prefix;


        public FileSequenceProcessor(string prefix = PREFIX, string inputFolder = INPUT_FOLDER_PATH, string outputFolder = OUTPUT_FOLDER_PATH, string coruptedFolder = CORUPTED_FOLDER_PATH)
        {
            this.inputFolder = inputFolder;
            this.outputFolder = outputFolder;
            this.coruptedFolder = coruptedFolder;
            this.prefix = prefix;
            this.pdfCounter = 1;
            this.counter = int.MinValue;
            processList = new List<string>();
        }

        public void ProcessFolder()
        {
            if (Directory.Exists(inputFolder))
            {
                var files = Directory.GetFiles(inputFolder);
                if (files.Any())
                {
                    foreach (var file in files)
                    {
                        if (processList.Contains(file))
                            continue;
                        processList.Add(file);
                        var info = new FileInfo(file);
                        if (!info.Name.ToLowerInvariant().StartsWith(prefix))
                            continue;

                        var nameSplit = info.Name.Split('_', '.');
                        int number;
                        if (!int.TryParse(nameSplit[1], out number))
                            continue;

                        if (number - counter == 1)
                        {
                            sequence.Add(file);
                        }
                        else
                        {
                            if (sequence != null)
                                ProcessSequence(sequence);
                            sequence = new List<string>();
                            sequence.Add(file);
                        }
                        counter = number;
                    }
                }
            }
        }

        private void ProcessSequence(List<string> files)
        {
            try
            {
                using (var pdfCreator = new PdfCreator())
                {
                    foreach (var file in files)
                    {
                        using (var image = ProcessImage(file))
                        {
                            pdfCreator.AddImage(image);
                        }
                    }
                    pdfCreator.Save($"{outputFolder}doc_{pdfCounter++}.pdf");
                }
            }
            catch (IOException e)
            {
                // some troubles with file system
            }
            catch (Exception e)
            {
                CopyCoruptedFiles(files);
            }
            files.ForEach(x => File.Delete(x));
        }

        private Image ProcessImage(string path)
        {
            int tryCounter = 0;
            while (true)
            {
                try
                {
                    var image = Image.FromFile(path);
                    return image;
                }
                catch (IOException e)
                {
                    if (tryCounter > 3)
                        throw;
                }
                tryCounter++;
            }
        }

        private void CopyCoruptedFiles(List<string> files)
        {
            foreach (var file in files)
            {
                var info = new FileInfo(file);
                File.Move(info.FullName, coruptedFolder + info.Name);
            }
        }
    }
}
