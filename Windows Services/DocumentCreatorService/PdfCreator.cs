using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Drawing;

namespace DocumentCreatorService
{
    public class PdfCreator
    {
        PdfDocument document;
        public PdfCreator()
        {
            this.document = new PdfDocument();
        }

        public void AddImage(string path)
        {
            PdfPage page = this.document.AddPage();
            var grx = XGraphics.FromPdfPage(page);
            var image = Image.FromFile(path);
            using (var xImage = XImage.FromGdiPlusImage(ImageHelper.ResizeImage(image)))
            {
                grx.DrawImage(xImage, 0, 0);
            }
        }

        public void Save(string filename)
        {
            this.document.Save(filename);
        }
    }
}
