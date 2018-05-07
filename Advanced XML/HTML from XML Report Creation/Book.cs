using System;

namespace HTML_from_XML_Report_Creation
{
    public class Book
    {
        public Book(string author, string title, string publishDate, string registrationDate)
        {
            Author = author;
            Title = title;
            PublishDate = DateTime.Parse(publishDate);
            RegistrationDate = DateTime.Parse(registrationDate);
        }
        public string Author { get; set; }
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
