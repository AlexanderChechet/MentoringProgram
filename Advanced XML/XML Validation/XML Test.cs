using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;
using System.Xml.Schema;

namespace XML_Validation
{
    [TestClass]
    public class UnitTest1
    {
        XmlReaderSettings settings;
        [TestInitialize]
        public void Init()
        {
            settings = new XmlReaderSettings();
            settings.Schemas.Add("http://library.by/catalog", @"..\..\books.xsd");
            settings.ValidationEventHandler += ValidationHandler;
            settings.ValidationFlags = settings.ValidationFlags | XmlSchemaValidationFlags.ReportValidationWarnings;
            settings.ValidationType = ValidationType.Schema;
        }
        [TestMethod]
        public void TestValidXml()
        {
            var reader = XmlReader.Create(@"..\..\validBooks.xml", settings);
            Console.WriteLine("Start test");
            while (reader.Read()) ;
            Console.WriteLine("End test");
        }

        [TestMethod]
        public void TestInvalidXml()
        {
            var reader = XmlReader.Create(@"..\..\invalidBooks.xml", settings);
            Console.WriteLine("Start test");
            while (reader.Read()) ;
            Console.WriteLine("End test");
        }

        private void ValidationHandler(object obj, ValidationEventArgs e)
        {
            Console.WriteLine($"Validation error: [{e.Exception.LineNumber}:{e.Exception.LinePosition}] {e.Exception.Message}");
        }
    }
}
