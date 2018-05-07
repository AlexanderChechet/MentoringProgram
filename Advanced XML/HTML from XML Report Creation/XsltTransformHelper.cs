using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTML_from_XML_Report_Creation
{
    
    public class XsltTransformHelper
    {
        private List<string> genres;
        public XsltTransformHelper()
        {
            genres = new List<string>();
        }
        public void AddGenre(string genre)
        {
            if (!genres.Contains(genre))
                genres.Add(genre);
        }

        public string GetGenre()
        {
            return genres[0];
        }

        public bool MoveNext()
        {
            genres.RemoveAt(0);
            return genres.Any();
        }


    }
}
