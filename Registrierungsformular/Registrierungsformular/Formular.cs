using DataBaseWrapper;
using QRCoder;
using System;
using System.Web.Configuration;

namespace Registrierungsformular
{
    public class Formular
    {
        string email;
        int revision;
        int state_id;
        string ao_firstname;
        string ao_lastname;
        string street;
        string house_number;
        string zipcode;
        string city;
        string iban;
        string bic;
        string PDF_path;

        public Formular(string email, string ao_firstname, string ao_lastname, string street, string house_number, string zipcode, string city, string iban, string bic)
        {
            this.email = email;
            this.ao_firstname = ao_firstname;
            this.ao_lastname = ao_lastname;
            this.street = street;
            this.house_number = house_number;
            this.zipcode = zipcode;
            this.city = city;
            this.iban = iban;
            this.bic = bic;
            this.revision = GetRevision();
            this.state_id = 1;

        }

        public string Email
        {
            get { return email; }
        }
        public void LoadToDataBank()
        {
            string sql = GetSqlCommand();

            DataBase db = new DataBase(WebConfigurationManager.ConnectionStrings["AppDb"].ConnectionString);
            db.RunNoneQuery(sql);

        }

        private string GetSqlCommand()
        {
            string sql;
            if (bic.Length > 0)
                sql = $"Insert INTO signed_up_users(email, revision, state_id, ao_firstname, ao_lastname, street, house_number, zipcode, city, IBAN, BIC) " +
                            $"Values('{Email}', {revision}, {state_id}, '{ao_firstname}', '{ao_lastname}', '{street}', '{house_number}', '{zipcode}', '{city}', '{iban}', '{bic}')";
            else
                sql = $"Insert INTO signed_up_users(email, revision, state_id, ao_firstname, ao_lastname, street, house_number, zipcode, city, IBAN) " +
                            $"Values('{Email}', {revision}, {state_id}, '{ao_firstname}', '{ao_lastname}', '{street}', '{house_number}', '{zipcode}', '{city}', '{iban}')";
            return sql;
        }

        private int GetRevision()
        {
            DataBase db = new DataBase(WebConfigurationManager.ConnectionStrings["AppDb"].ConnectionString);
            string oldRevision = Convert.ToString(db.RunQueryScalar($"Select Max(revision) From signed_up_users Where email = '{Email}'; "));
            int newRevision;
            if (oldRevision == "")
            {
                newRevision= 1;
            }
            else
            {
                newRevision = Convert.ToInt32(oldRevision) + 1;
            }
            return newRevision;
        }
    }


}