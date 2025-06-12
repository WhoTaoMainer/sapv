using Microsoft.AspNetCore.Mvc;
using PdfSharpCore.Pdf;
using PdfSharpCore.Drawing;
using Svg.Skia;
using SkiaSharp;
using System.Text;


namespace Kursach_MVC.Controllers
{
    [Route("[controller]/[action]")]
    public class PatternController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ExportToPdf([FromBody] string svgContent)
        {
            byte[] pdfBytes = ConvertSvgToMultipagePdf(svgContent);
            return File(pdfBytes, "application/pdf", "vykroika.pdf");
        }

        public static byte[] ConvertSvgToMultipagePdf(string svgContent)
        {
            const int dpi = 72;
            const float pageWidthPt = 595f;  // A4
            const float pageHeightPt = 842f;
            const float marginMm = 10f;
            const float mmToPt = 72f / 25.4f;
            float marginPt = marginMm * mmToPt;
            float usableWidth = pageWidthPt - 2 * marginPt;
            float usableHeight = pageHeightPt - 2 * marginPt;

            var svg = new SKSvg();
            svg.FromSvg(svgContent);
            var picture = svg.Picture;
            var bounds = picture.CullRect;

            float svgWidth = bounds.Width;
            float svgHeight = bounds.Height;
            float tileWidth = usableWidth;
            float tileHeight = usableHeight;

            int tilesX = (int)Math.Ceiling(svgWidth / tileWidth);
            int tilesY = (int)Math.Ceiling(svgHeight / tileHeight);

            var document = new PdfDocument();

            for (int y = 0; y < tilesY; y++)
            {
                for (int x = 0; x < tilesX; x++)
                {
                    var page = document.AddPage();
                    page.Width = pageWidthPt;
                    page.Height = pageHeightPt;

                    using var gfx = XGraphics.FromPdfPage(page);
                    using var surface = SKSurface.Create(new SKImageInfo((int)pageWidthPt, (int)pageHeightPt));
                    var canvas = surface.Canvas;
                    canvas.Clear(SKColors.White);

                    float xOffset = x * tileWidth;
                    float yOffset = y * tileHeight;
                    float scale = Math.Min(usableWidth / tileWidth, usableHeight / tileHeight);

                    canvas.Translate(marginPt, marginPt);
                    canvas.Scale(scale);
                    canvas.Translate(-xOffset, -yOffset);
                    canvas.DrawPicture(picture);
                    canvas.Flush();

                    using var img = surface.Snapshot();
                    using var data = img.Encode(SKEncodedImageFormat.Png, 100);
                    using var ms = new MemoryStream();
                    data.SaveTo(ms);
                    ms.Seek(0, SeekOrigin.Begin);

                    var xImage = XImage.FromStream(() => ms);
                    gfx.DrawImage(xImage, 0, 0, page.Width, page.Height);
                }
            }

            using var outputStream = new MemoryStream();
            document.Save(outputStream, false);
            return outputStream.ToArray();
        }
    }
}
