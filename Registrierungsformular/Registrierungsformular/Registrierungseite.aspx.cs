using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataBaseWrapper;
using QRCoder;
using Word = Microsoft.Office.Interop.Word;
using System.Reflection;
using Microsoft.Office.Interop.Word;

namespace Registrierungsformular
{
    public partial class Registrierungseite : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string student = Environment.UserName;
            //string studeng = HttpContext.Current.User.Identity.Name;
            string studentEmail = student + "@htlvb.at";


            Student s = new Student(studentEmail);

            txtStudentName.Text = s.Firstname + " " + s.Lastname;
            txtStudentClass.Text = s.Class;
            txtStudentID.Text = s.Student_id;
            lblEmail.Text = s.Email;
            CheckIfBasicInfosAreEmpty();
            CreateQrCode(studentEmail);
        }

        private void CheckIfBasicInfosAreEmpty()
        {
            if (txtStudentName.Text.Length == 0)
            {
                txtStudentName.ReadOnly = false;
            }
            if (txtStudentID.Text.Length == 0)
            {
                txtStudentID.ReadOnly = false;
            }
            if (txtStudentClass.Text.Length == 0)
            {
                txtStudentClass.ReadOnly = false;
            }
        }
        public Bitmap CreateQrCode(string email)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(email, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            string url =  "Z:\\myfile.png";
            qrCodeImage.Save(url, System.Drawing.Imaging.ImageFormat.Png);

            return qrCodeImage;
        }

        protected void btnPrintAndSave_Click(object sender, EventArgs e)
        {
            object oMissing = System.Reflection.Missing.Value;
            object oEndOfDoc = "\\endofdoc"; /* \endofdoc is a predefined bookmark */

            //Start Word and create a new document.
            Word._Application oWord;
            Word._Document oDoc;
            oWord = new Word.Application();
            oWord.Visible = true;
            object oTemplate = "Z:\\SWP1\\ProjektMensSCRUM\\MensaRegister\\Registrierungsformular\\Mensaanmeldeformular_V2.docm";
            oDoc = oWord.Documents.Add(ref oTemplate, ref oMissing,
            ref oMissing, ref oMissing);
            InsertDataInDocument(oDoc);

            object bmQRCode = "qrCode";
            object position = oDoc.Bookmarks.get_Item(ref bmQRCode).Range;
            oDoc.InlineShapes.AddPicture(@"Z:\\myfile.png", ref oMissing, true, ref position);
        }

        private void InsertDataInDocument(_Document oDoc)
        {
            object bmStudentName = "studentName";
            oDoc.Bookmarks.get_Item(ref bmStudentName).Range.Text = txtStudentName.Text;
            object bmClass = "class";
            oDoc.Bookmarks.get_Item(ref bmClass).Range.Text = txtStudentClass.Text;
            object bmEmail = "email";
            oDoc.Bookmarks.get_Item(ref bmEmail).Range.Text = lblEmail.Text;
            object bmStudentID = "studentID";
            oDoc.Bookmarks.get_Item(ref bmStudentID).Range.Text = txtStudentID.Text;
            object bmAoFirstname = "aoFirstname";
            oDoc.Bookmarks.get_Item(ref bmAoFirstname).Range.Text = txtDepFirstName.Text;
            object bmAoLastname = "aoLastname";
            oDoc.Bookmarks.get_Item(ref bmAoLastname).Range.Text = txtDepLastname.Text;
            object bmZipcode = "zipcode";
            oDoc.Bookmarks.get_Item(ref bmZipcode).Range.Text = txtZipCode.Text;
            object bmCity = "city";
            oDoc.Bookmarks.get_Item(ref bmCity).Range.Text = txtCity.Text;
            object bmStreet = "street";
            oDoc.Bookmarks.get_Item(ref bmStreet).Range.Text = txtStreet.Text;
            object bmHouseNumber = "houseNumber";
            oDoc.Bookmarks.get_Item(ref bmHouseNumber).Range.Text = txtHouseNumber.Text;
            object bmIban = "iban";
            oDoc.Bookmarks.get_Item(ref bmIban).Range.Text = txtIban.Text;
            object bmBic = "bic";
            oDoc.Bookmarks.get_Item(ref bmBic).Range.Text = txtBic.Text;
        }
    }


}