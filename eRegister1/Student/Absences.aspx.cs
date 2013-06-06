using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace eRegister1.Student
{
    public partial class Absences : System.Web.UI.Page
    {
        int userID;
        int studentID;
        int excused = 0;
        string unexcused = String.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                userID = Int32.Parse(Session["UserID"].ToString());
               
                eRegisterData.DAL oDal = new eRegisterData.DAL();
                SqlConnection conn = oDal.getSubject();
                SqlCommand comm = new SqlCommand();

                try
                {
                    conn.Open();
                    comm.Connection = conn;
                    comm.CommandText = @" SELECT ActorID
                                      FROM Actors
                                      WHERE UserID='" + userID + "'";

                    studentID = Int32.Parse(comm.ExecuteScalar().ToString());
                    conn.Close();
                }
                catch (Exception ex)
                {
                    lblMessage.Text = ex.Message;
                }

                excused = oDal.getExcusedAbsences(studentID);
                switch (excused)
                {
                    case 0:
                        TextBoxExcused.Text = "-";
                        break;
                    default:
                        TextBoxExcused.Text = excused.ToString();
                        break;
                }

                eRegisterData.DAL DAL = new eRegisterData.DAL();
                unexcused = DAL.getInexcusablyAbsences(studentID);
                switch (unexcused)
                {
                    case "0":
                        TextBoxUnexcused.Text = "-";
                        break;
                    default:
                        TextBoxUnexcused.Text = unexcused;
                        break;
                }
               
                System.Data.DataTable inexcusablyInfo = new System.Data.DataTable();
                eRegisterData.DAL oDAL = new eRegisterData.DAL();
                inexcusablyInfo = oDAL.getInexcusablyInfo(studentID);
                GridViewAbsences.DataSource = inexcusablyInfo.DefaultView;
                GridViewAbsences.DataBind();

            }
            else { Response.Redirect("~/eRegister.aspx"); }

        }
    }
}