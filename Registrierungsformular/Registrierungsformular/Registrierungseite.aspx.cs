using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataBaseWrapper;

namespace Registrierungsformular
{
    public partial class Registrierungseite : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string student = Environment.UserName;
            string studentEmail = student + "@htlvb.at";


            Student s = new Student(studentEmail);

            txtStudentName.Text = s.Firstname + " " + s.Lastname;
            txtStudentClass.Text = s.Class;
            txtStudentID.Text = s.Student_id;
            lblEmail.Text = s.Email;
            CheckIfBasicInfosAreEmpty();
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
    }


}