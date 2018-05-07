using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Xsl;

namespace HTML_from_XML_Report_Creation
{
    class Program
    {
        public static void Main(string[] args)
        {
            Transform(@"../../HTML.xslt", @"../../books.xml");
        }

        public static void Transform(string xsltFile, string xmlFile)
        {
            var transform = new XslCompiledTransform();
            var args = new XsltArgumentList();
            args.AddExtensionObject("http://epam.com/xslt/ext", new XsltTransformHelper());
            transform.Load(xsltFile);
            using (var writer = XmlWriter.Create("result.html"))
            {
                transform.Transform(xmlFile, args, writer);
            }
        }
    }
}
