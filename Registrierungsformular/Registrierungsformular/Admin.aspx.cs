//using BitMiracle.Docotic.Pdf;
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
            string name = "formulars.pdf";
            string folder = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath);
            string path = Path.Combine(folder, name);
            string imageName = "\\formular_image.png";
            fplPDF.SaveAs(path);
            //SplitPDF("formulars.pdf");
            pdftoimage(path, imageName);

            string code = DecodeQrCode(folder, imageName);
            lblInfo.Text = code;
            

        }

        private void pdftoimage(string path, string imageName)
        {
            string ghostScriptPath = @"C:\Users\clemens.schmidmair\AppData\Roaming\gswin\";
            MagickNET.SetGhostscriptDirectory(ghostScriptPath);
            MagickReadSettings settings = new MagickReadSettings();
            settings.Density = new Density(300);
            string folder = Path.GetDirectoryName(path);
            using (MagickImageCollection images = new MagickImageCollection())
            {
                images.Read(path, settings);
                using (var vertical = images.AppendVertically())
                {
                    vertical.Write(folder + imageName);
                }
            }
        }

        private string DecodeQrCode(string path, string fileName)
        {
            IBarcodeReader reader = new BarcodeReader();
            var barcodeBitmap = (Bitmap)Bitmap.FromFile(path + fileName);
            string result = reader.Decode(barcodeBitmap).ToString();
            return result;
        }

       
    }
}