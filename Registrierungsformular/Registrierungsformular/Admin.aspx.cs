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
            lblInfo.Text = DecodeText(name);

        }
        private string DecodeText(string sFileName)
        {
            DmtxImageDecoder decoder = new DmtxImageDecoder();
            System.Drawing.Bitmap oBitmap = new System.Drawing.Bitmap(sFileName);
            List<string> oList = decoder.DecodeImage(oBitmap);

            StringBuilder sb = new StringBuilder();
            sb.Length = 0;
            foreach (string s in oList)
            {
                sb.Append(s);
            }
            return sb.ToString();
        }



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