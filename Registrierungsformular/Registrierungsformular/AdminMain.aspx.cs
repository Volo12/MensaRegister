using ImageMagick;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
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
            ZXing.QrCode.QRCodeReader qrReader = new ZXing.QrCode.QRCodeReader();
            string name = "formulars.pdf";
            string folder = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath);
            string path = Path.Combine(folder, name);
            //fplPDF.SaveAs(path);

            SplitPDf();


        }

        private void SplitPDf()
        {
            // Get a fresh copy of the sample PDF file
            string filename = "formulars.pdf";
            string folder = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath);
            string path = Path.Combine(folder, filename);
            fplPDF.SaveAs(path);


            // Open the file
            PdfDocument inputDocument = PdfReader.Open(path, PdfDocumentOpenMode.Import);

            List<string> codes = new List<string>(9);

            //string name = Path.GetFileNameWithoutExtension(filename);
            for (int idx = 0; idx < inputDocument.PageCount; idx++)
            {
                // Create new document
                PdfDocument outputDocument = new PdfDocument();
                outputDocument.Version = inputDocument.Version;
                outputDocument.Info.Title =
                  String.Format("Page {0} of {1}", idx + 1, inputDocument.Info.Title);
                outputDocument.Info.Creator = inputDocument.Info.Creator;

                // Add the page and save it
                string name =  Guid.NewGuid().ToString();
                while (File.Exists(folder + name + ".pdf"))
                {
                    name = Guid.NewGuid().ToString();
                }


                outputDocument.AddPage(inputDocument.Pages[idx]);
                outputDocument.Save(folder + name + ".pdf");


                PDFToImage(folder, name);
                codes.Add(DecodeImage(folder, name));
            }
        }

        private void PDFToImage(string folder, string name)
        {
            string ghostScriptPath = @"C:\Users\clemens.schmidmair\AppData\Roaming\gswin\";
            MagickNET.SetGhostscriptDirectory(ghostScriptPath);
            MagickReadSettings settings = new MagickReadSettings();
            settings.Density = new Density(300);
            using (MagickImageCollection images = new MagickImageCollection())
            {
                images.Read(folder + name + ".pdf", settings);
                using (var vertical = images.AppendVertically())
                {
                    vertical.Write(folder + name + @".png");
                }
            }
        }

        private string DecodeImage(string folder, string name)
        {
            IBarcodeReader reader = new BarcodeReader();
            var barcodeBitmap = (Bitmap)Bitmap.FromFile(folder + name + @".png");
            string result = reader.Decode(barcodeBitmap).ToString();
            return result;
        }

        protected void btnToDataBase_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminDataBase.aspx");
        }
    }
}