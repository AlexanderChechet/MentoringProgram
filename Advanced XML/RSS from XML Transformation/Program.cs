using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace RSS_from_XML_Transformation
{
    public class Program
    {

        public static void Main(string[] args)
        {
            Console.WriteLine("Enter path to file:");
            var filePath = Console.ReadLine();
            if (!File.Exists(filePath))
                throw new IOException("File not found");
            Console.WriteLine("Enter path to tranformation:");
            var transformPath = Console.ReadLine();
            if (!File.Exists(transformPath))
                throw new IOException("File not found");
            try
            {
                Transform(filePath, transformPath);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured during transformation");
            }
            Console.WriteLine("Done.");
            Console.ReadKey();
        }

        public static void Transform(string xmlFile, string xsltFile)
        {
            var transform = new XslCompiledTransform();
            transform.Load(xsltFile);
            transform.Transform(xmlFile, "result.rss");
        }
    }
}
