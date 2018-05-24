using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace DocumentCreatorService
{
    public class FileSequenceProcessor
    {
        private List<string> sequence;
        
        private int pdfCounter;
        
        private const string CORUPTED_FOLDER_PATH = @"C:\ServiceCoruptedFiles\";
        private const string OUTPUT_FOLDER_PATH = @"C:\ServicePdfs\";
        private const string INPUT_FOLDER_PATH = @"C:\ServiceImages\";
        private const string PREFIX = "img";

        private readonly List<string> processList;
        private readonly string inputFolder;
        private readonly string outputFolder;
        private readonly string coruptedFolder;
        private readonly string prefix;


        public int Counter { get; set; }

        public FileSequenceProcessor(string prefix = PREFIX, string inputFolder = INPUT_FOLDER_PATH, string outputFolder = OUTPUT_FOLDER_PATH, string coruptedFolder = CORUPTED_FOLDER_PATH)
        {
            this.inputFolder = inputFolder;
            this.outputFolder = outputFolder;
            this.coruptedFolder = coruptedFolder;
            this.prefix = prefix;
            this.pdfCounter = 1;
            Counter = int.MinValue;
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

                        if (number - Counter == 1)
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
                        Counter = number;
                    }
                }
            }
        }

        public void ProcessUnfinishedSequence()
        {
            if (sequence != null && sequence.Count > 0)
            {
                ProcessSequence(sequence);
                sequence = new List<string>();
                Counter = int.MinValue;
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
            catch (IOException)
            {
                throw;
            }
            catch (Exception)
            {
                CopyCoruptedFiles(files);
            }
            files.ForEach(File.Delete);
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
