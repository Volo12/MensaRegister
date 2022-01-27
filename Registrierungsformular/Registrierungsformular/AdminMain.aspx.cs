using System;
using System.IO;
using System.Reflection;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

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
            // Open the file
            PdfDocument inputDocument = PdfReader.Open(@"Z:\SWP1\ProjektMensSCRUM\originalPdf.pdf",PdfDocumentOpenMode.Import);

            string destinationPath = @"Z:\SWP1\ProjektMensSCRUM\splittedPdfs\";
            string destinationPathAndName;
            for (int idx = 0; idx < inputDocument.PageCount; idx++)
            {
                // Create new document
                PdfDocument outputDocument = new PdfDocument();
                outputDocument.Version = inputDocument.Version;
                outputDocument.Info.Title =
                  String.Format("Page {0} of {1}", idx + 1, inputDocument.Info.Title);
                outputDocument.Info.Creator = inputDocument.Info.Creator;

                // Add the page and save it
                outputDocument.AddPage(inputDocument.Pages[idx]);

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