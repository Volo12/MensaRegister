using System;
using System.Drawing;
using QRCoder;
using Word = Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Word;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Interop;
using System.Threading;
=======
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace Registrierungsformular
{
    public partial class Registrierungseite : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string student = Environment.UserName;
            string studentEmail = student + "@htlvb.at";                    // Email aus UserName erstellen

            Student s = new Student(studentEmail);                          // Daten des Schülers aus DB auslesen

            txtStudentName.Text = s.Firstname + " " + s.Lastname;
            txtStudentClass.Text = s.Class;
            txtStudentID.Text = s.Student_id;
            lblEmail.Text = s.Email;

            CheckIfBasicInfosAreEmpty();
        }

        /// <summary>
        /// Check if StudentName, StudentId, StudentClass is in DB. If not, the student can insert it himself.
        /// </summary>
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

            return qrCodeImage;
        }

        protected void btnPrintAndSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                object oMissing = System.Reflection.Missing.Value;
                object oEndOfDoc = "\\endofdoc"; /* \endofdoc is a predefined bookmark */

                //Start Word and create a new document.
                Word._Application oWord;
                Word._Document oDoc;
                oWord = new Word.Application();
                oWord.Visible = true;
                object oTemplate = "Z:\\SWP1\\ProjektMensSCRUM\\MensaRegister\\Registrierungsformular\\Mensaanmeldeformular_V2.docm";
                oDoc = oWord.Documents.Add(ref oTemplate, ref oMissing, ref oMissing, ref oMissing);
                InsertDataInDocument(oDoc);

                Bitmap qrCode = CreateQrCode(lblEmail.Text);
                InsertQRCodeInDoc(oDoc, qrCode);
            }
            else
                lblInfo.Text = "Bitte alle Mussfelder ausfüllen!";
        }

        /// <summary>
        /// Inserts QRCode in Document without saving it in a directory. Must use a thread to use the Clipboard.SetImage Method.
        /// </summary>
        /// <param name="oDoc"></param>
        /// <param name="qrCode"></param>
        private void InsertQRCodeInDoc(_Document oDoc, Bitmap qrCode)
        {
            Thread t = new Thread((ThreadStart)(() =>
            {
                Clipboard.SetImage(GetBitmapSource(qrCode));
            }));
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();

            object bmQRCode = "qrCode";
            oDoc.Bookmarks.get_Item(ref bmQRCode).Range.Paste();
        }

        /// <summary>
        /// Inserting the data in the word document.
        /// </summary>
        /// <param name="oDoc"></param>
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
        public BitmapSource GetBitmapSource(Bitmap bitmap)
        {
            BitmapSource bitmapSource = Imaging.CreateBitmapSourceFromHBitmap
            (
                bitmap.GetHbitmap(),
                IntPtr.Zero,
                Int32Rect.Empty,
                BitmapSizeOptions.FromEmptyOptions()
            );

            return bitmapSource;
        }
    }


}