using DataBaseWrapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Registrierungsformular
{
    public partial class AdminDataBase : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                FillDdlState();
                FillDdlClass();
            }
        }

        private void FillDdlClass()
        {
            DataTable dt;
            using (DataBase db = new DataBase(WebConfigurationManager.ConnectionStrings["AppDb"].ConnectionString))
            {
                dt = db.RunQuery("SELECT students.class FROM signed_up_users " +
                    "LEFT JOIN students " +
                    "ON signed_up_users.email = students.email " +
                    "GROUP BY class "+
                    "ORDER BY class");
            }
            ddlClass.DataValueField = "class";
            ddlClass.DataTextField = "class";

            ddlClass.DataSource = dt;
            ddlClass.DataBind();

            ddlClass.Items.Insert(0, new ListItem("Alle Klassen", "-1"));
        }

        private void FillDdlState()
        {
            DataTable dt;
            using (DataBase db = new DataBase(WebConfigurationManager.ConnectionStrings["AppDb"].ConnectionString))
            {
                dt = db.RunQuery("SELECT * from states");
            }

            ddlState.DataValueField = "state_id";
            ddlState.DataTextField = "description";

            ddlState.DataSource = dt;
            ddlState.DataBind();
            
            ddlState.Items.Insert(0,new ListItem("alle Status", "-1"));
        }


        private void FillGridViewData(string selectedValue)
        {
            DataTable dt;
            string sql = "SELECT firstname as Vorname,lastname as Nachname,class as Klasse,students.email as Email, states.description as Status FROM signed_up_users " +
                    "LEFT JOIN students " +
                    "ON signed_up_users.email = students.email " +
                    "LEFT JOIN states " +
                    "ON signed_up_users.state_id=states.state_id ";

            if(ddlState.SelectedValue!="-1")
            {
                sql += $"WHERE states.state_id = {ddlState.SelectedValue} ";
                if(ddlClass.SelectedValue!="-1")
                {
                    sql += $"AND class='{ddlClass.SelectedValue}'";
                }
            }
            else if (ddlClass.SelectedValue != "-1")
            {
                sql += $"WHERE class='{ddlClass.SelectedValue}'";
            }


            using (DataBase db = new DataBase(WebConfigurationManager.ConnectionStrings["AppDb"].ConnectionString))
            {
                dt = db.RunQuery(sql);
            }
            grvData.DataSource = dt;
            grvData.DataBind();
        }

        protected void btnRun_Click(object sender, EventArgs e)
        {
                FillGridViewData(ddlState.SelectedValue);
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminMain.aspx");
        }
    }
}