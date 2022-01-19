//using BitMiracle.Docotic.Pdf;
using DataMatrix.net;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZXing;

namespace Registrierungsformular
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //fplPDF.PostedFile.SaveAs("formulars.pdf");

            //if (fplPDF.HasFile)
            //{
            //    lblInfo.Text = fplPDF.FileName;
            //}

        }

        protected void btnSavePDF_Click(object sender, EventArgs e)
        {
            string name = "formulars.pdf";
            string folder = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath);
            string path = Path.Combine(folder, name);
            fplPDF.SaveAs(path);
            //SplitPDF("formulars.pdf");
            //PDFToImage(path);

            string code = DecodeQrCode(path, "page_0.jpg");
            lblInfo.Text = code;
            

        }

        //private void PDFToImage(string path)
        //{
        //    PdfDocument doc = new PdfDocument();
        //    doc.LoadFromFile(@"D:\test.pdf");
        //    List<string> list = new List<string>();
        //    for (int i = 0; i < doc.Pages.Count; i++)
        //    {
        //        System.Drawing.Image bmp = doc.SaveAsImage(i);
        //        string fileName = string.Format("Page-{0}.png", i + 1);
        //        bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);
        //        list.Add(fileName);
        //    }
        //}

        private string DecodeQrCode(string path, string fileName)
        {
            IBarcodeReader reader = new BarcodeReader();
            var barcodeBitmap = (Bitmap)Bitmap.FromFile(path + fileName);
            string result = reader.Decode(barcodeBitmap).ToString();
            return result;
        }

        //private void PDFToImage(string sFileName)
        //{
        //    using (var pdf = new PdfDocument(sFileName))
        //    {
        //        PdfDrawOptions options = PdfDrawOptions.Create();
        //        options.BackgroundColor = new PdfRgbColor(255, 255, 255);
        //        options.HorizontalResolution = 300;
        //        options.VerticalResolution = 300;

        //        for (int i = 0; i < pdf.PageCount; ++i)
        //            pdf.Pages[i].Save(sFileName+$"page_{i}.jpg", options);
                
        //    }
        //}





        //void SplitPDF(string filename)
        //{
        //    BarcodeEngine barcodeEngine = new BarcodeEngine();
        //    List<int> PageNumbers = new List<int>();
        //    using (RasterCodecs codecs = new RasterCodecs())
        //    {
        //        int totalPages = codecs.GetTotalPages(filename);
        //        for (int page = 1; page <= totalPages; page++)
        //            using (RasterImage image = codecs.Load(filename, page))
        //            {
        //                BarcodeData barcodeData = barcodeEngine.Reader.ReadBarcode(image, LogicalRectangle.Empty, BarcodeSymbology.QR);
        //                if (barcodeData != null) // QR Barcode found on this image
        //                    PageNumbers.Add(page);
        //            }
        //    }

        //    int firstPage = 1;
        //    PDFFile pdfFile = new PDFFile(filename);
        //    //Loop through and split the PDF according to the barcodes
        //    for (int i = 0; i < PageNumbers.Count; i++)
        //    {
        //        string outputFile = $"{Path.GetDirectoryName(filename)}\\{Path.GetFileNameWithoutExtension(filename)}_{i}.pdf";
        //        pdfFile.ExtractPages(firstPage, PageNumbers[i] - 1, outputFile);
        //        firstPage = PageNumbers[i]; //set the first page to the next page
        //    }
        //    //split the rest of the PDF based on the last barcode
        //    if (firstPage != 1)
        //        pdfFile.ExtractPages(firstPage, -1, $"{Path.GetDirectoryName(filename)}\\{Path.GetFileNameWithoutExtension(filename)}_rest.pdf");
        //}
    }
}