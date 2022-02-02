using System;
using System.IO;
using System.Reflection;
using ZXing;
using DataBaseWrapper;
using System.Web.Configuration;

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

            List<string> codes = new List<string>();

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
                string name = Guid.NewGuid().ToString();
                string pdfPath = folder + name + ".pdf";
                while (File.Exists(pdfPath))
                {
                    name = Guid.NewGuid().ToString();
                }

                outputDocument.AddPage(inputDocument.Pages[idx]);
                outputDocument.Save(pdfPath);


                PDFToImage(folder, name);
                //codes.Add(DecodeImage(folder, name));
                ConfirmStudent(DecodeImage(folder, name), pdfPath);
            }

        }

        private void ConfirmStudent(string email, string pdfPath)
        {
            int revision = GetRevisionFromStudent(email);
            DataBase db = new DataBase(WebConfigurationManager.ConnectionStrings["AppDb"].ConnectionString);

            pdfPath = pdfPath.Replace('\\', '/');

            string sqlCmd = "Update signed_up_users " +
                            $"Set state_id = 3, PDF_path = '{pdfPath}' " +
                            $"Where email = '{email}' AND revision = {revision};";


            db.RunNoneQuery(sqlCmd);

        }

        private int GetRevisionFromStudent(string email)
        {
            DataBase db = new DataBase(WebConfigurationManager.ConnectionStrings["AppDb"].ConnectionString);
            int revision = Convert.ToInt32(db.RunQueryScalar($"Select Max(revision) From signed_up_users Where email = '{email}'; "));

            return revision;
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

                destinationPathAndName=destinationPath + Guid.NewGuid()+".pdf";
                while(File.Exists(destinationPathAndName))
                {
                    destinationPathAndName = destinationPath + Guid.NewGuid()+".pdf";
                }
                outputDocument.Save(destinationPathAndName);                
            }

            //string name = "formulars.pdf";
            //string folder = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath);
            //string path = Path.Combine(folder, name);
            //fplPDF.SaveAs(path);
        }

        protected void btnToDataBase_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminDataBase.aspx");
        }
    }
}