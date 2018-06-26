using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentCentralService
{
    public class ByteSequenceProcessor
    {
        private int globalCounter;
        private const string OUTPUT_FOLDER_PATH = @"C:\CentralServicePdfs\";
        private const string DOCUMENT_NAME_FORMAT = "C:\\CentralServicePdfs\\Document{0}.pdf";

        public ByteSequenceProcessor()
        {
            globalCounter = 0;
            if (!Directory.Exists(OUTPUT_FOLDER_PATH))
                Directory.CreateDirectory(OUTPUT_FOLDER_PATH);
        }

        public void ProcessSequence(byte[] data)
        {
            var filename = String.Format(DOCUMENT_NAME_FORMAT, globalCounter++);
            using (var fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                fs.Write(data, 0, data.Length);
                fs.Flush();
            }
        }
    }
}
