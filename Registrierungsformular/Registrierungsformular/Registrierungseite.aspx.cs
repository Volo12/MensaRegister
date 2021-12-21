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

                lblName.Text = s.Firstname + " " + s.Lastname;
                lblClass.Text = s.Klasse;
                lblId.Text = s.Student_id;
                lblEmail.Text = s.Email;
            
        }
    }


}