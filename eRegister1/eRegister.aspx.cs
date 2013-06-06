using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace eRegister1
{
    public partial class eRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void ButtonLogIn_Click(object sender, EventArgs e)
        {
            int userID = 0;
            string userName = txtUserName.Text;
            string password = txtPassword.Text;

            eRegisterData.DAL oDal = new eRegisterData.DAL();
            SqlConnection conn = oDal.getSubject();

            SqlCommand cmd = new SqlCommand();

            SqlParameter paramUserName = new SqlParameter("@UserName", userName);
            paramUserName.SqlDbType = SqlDbType.VarChar;
            SqlParameter paramPassword = new SqlParameter("@Password", password);
            paramUserName.SqlDbType = SqlDbType.VarChar;
            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "sp_LogIN";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(paramUserName);
                cmd.Parameters.Add(paramPassword);

                
                if (cmd.ExecuteScalar() == null)
                {
                    lblMessage.Text = "Грешен потребител или парола";
                    return;
                }
                else
                {
                    userID = (Int32)cmd.ExecuteScalar();
                }

                SqlCommand sqlcmd = new SqlCommand();

                SqlParameter paramUserID = new SqlParameter("@UserID", userID);
                paramUserID.SqlDbType = SqlDbType.Int;
                sqlcmd.Connection = conn;
                sqlcmd.CommandText = "sp_UserType";
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.Add(paramUserID);
                int userTypeID = Int32.Parse(sqlcmd.ExecuteScalar().ToString());


                if (userTypeID == 1)
                {
                    Session["UserID"] = userID.ToString();
                    Response.Redirect("~/Admin/DefaultAdmin.aspx");
                }
                else if (userTypeID == 4)
                {
                    Session["UserID"] = userID.ToString();
                    Response.Redirect("~/Student/DefaultStudent.aspx");
                }
                conn.Close();
            }
            catch (Exception ex) 
            { 
                lblMessage.Text = ex.Message; 
            }

        }
    }
}