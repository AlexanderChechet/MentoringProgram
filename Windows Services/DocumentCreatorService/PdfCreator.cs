using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Drawing;
using System.IO;

namespace DocumentCreatorService
{
    public class PdfCreator : IDisposable
    {
        readonly PdfDocument document;
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
            document?.Close();
        }

        public byte[] GetDocument()
        {
            byte[] result = null;
            using (var ms = new MemoryStream())
            {
                this.document.Save(ms, true);
                result = ms.ToArray();
            }
            return result;
        }
    }
}
