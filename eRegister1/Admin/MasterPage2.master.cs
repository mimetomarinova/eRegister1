using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace eRegister1
{
    public partial class MasterPage2 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                Control form = Master.FindControl("NavigationMenu");
                form.Visible = false;
     

                int userID = Int32.Parse(Session["UserID"].ToString());
                eRegisterData.DAL oDal = new eRegisterData.DAL();
                SqlConnection conn = oDal.getSubject();
                SqlCommand comm = new SqlCommand();

                conn.Open();
                comm.Connection = conn;
                comm.CommandText = "Select FirstName + ' ' + LastName as Name from Actors where UserID='" + userID + "'";

                string actorName = comm.ExecuteScalar().ToString();
                LabelAdmin.Text = actorName;
            }
            else { Response.Redirect("~/eRegister.aspx"); }
        }

      
        protected void LinkButtonExit_Click(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                Session.Abandon();
                Response.Redirect("~/eRegister.aspx");
            }
        }
    }
}