
using ImageMagick;
using System;
using System.IO;
using System.Reflection;

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

            //string name = "formulars.pdf";
            //string folder = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath);
            //string path = Path.Combine(folder, name);
            //fplPDF.SaveAs(path);
        }

    }
}