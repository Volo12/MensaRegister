using System;
using System.Data;
using System.Web.Configuration;
using DataBaseWrapper;

namespace Registrierungsformular
{
    public class Student
    {
        string email;
        string firstname;
        string lastname;
        string _class;
        string student_id;

        public Student(string email)
        {
            ExtractData(email);
        }

        public string Email
        {
            get { return email; }
        }
        public string Firstname
        {
            get { return firstname; }
        }
        public string Lastname
        {
            get { return lastname; }

        }
        public string Class
        {
            get { return _class; }
        }
        public string Student_id
        {
            get { return student_id; }
        }

        private void ExtractData(string email)
        {
            if (email == null)
            {
                throw new ArgumentNullException();
            }
            this.email = email;
           
            DataBase db = new DataBase(WebConfigurationManager.ConnectionStrings["AppDb"].ConnectionString);
            DataTable dt = db.RunQuery($"SELECT* from Students Where email = '{email}';");
            this.firstname = dt.Rows[0][1].ToString();
            this.lastname = dt.Rows[0][2].ToString();
            this._class = dt.Rows[0][3].ToString();
            this.student_id = dt.Rows[0][4].ToString();


        }
    }
}