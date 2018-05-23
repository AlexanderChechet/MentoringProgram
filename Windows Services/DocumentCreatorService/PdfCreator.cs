using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Drawing;

namespace DocumentCreatorService
{
    public class PdfCreator : IDisposable
    {
        PdfDocument document;
        public PdfCreator()
        {
            this.document = new PdfDocument();
        }

        public void AddImage(Image image)
        {
            PdfPage page = this.document.AddPage();
            using (var grx = XGraphics.FromPdfPage(page))
            {
                using (var xImage = XImage.FromGdiPlusImage(ImageHelper.ResizeImage(image)))
                {
                    grx.DrawImage(xImage, 0, 0);
                }
            }
        }

        public void Dispose()
        {
            if (this.document != null)
                this.document.Close();
        }

        public void Save(string filename)
        {
            this.document.Save(filename);
        }
    }
}
