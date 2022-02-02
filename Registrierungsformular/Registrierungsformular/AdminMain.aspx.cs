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