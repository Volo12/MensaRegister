using ImageMagick;
using System;
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
            fplPDF.SaveAs(path);

            PDFToImage(folder, name);

            DecodeImage(folder);
        }

        private void PDFToImage(string folder, string name)
        {
            string ghostScriptPath = @"C:\Users\clemens.schmidmair\AppData\Roaming\gswin\";
            MagickNET.SetGhostscriptDirectory(ghostScriptPath);
            MagickReadSettings settings = new MagickReadSettings();
            settings.Density = new Density(300);
            using (MagickImageCollection images = new MagickImageCollection())
            {
                images.Read(folder + @"\" + name + @"\", settings);
                using (var vertical = images.AppendVertically())
                {
                    vertical.Write(folder + @"\image.png");
                }
            }
        }

        private void DecodeImage(string folder)
        {
            IBarcodeReader reader = new BarcodeReader();
            var barcodeBitmap = (Bitmap)Bitmap.FromFile(folder + @"\image.png");
            string result = reader.Decode(barcodeBitmap).ToString();
        }

        protected void btnToDataBase_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminDataBase.aspx");
        }
    }
}