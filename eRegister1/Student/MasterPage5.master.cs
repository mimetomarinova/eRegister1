using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace eRegister1.Student
{
    public partial class MasterPage5 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                Control menu = Master.FindControl("NavigationMenu");
                menu.Visible = false;
     
                int userID = Int32.Parse(Session["UserID"].ToString());
                 eRegisterData.DAL oDal = new eRegisterData.DAL();
                    SqlConnection conn = oDal.getSubject();
                    SqlCommand comm = new SqlCommand();
                    try
                    {
                        conn.Open();
                        comm.Connection = conn;
                        comm.CommandText = @" Select FirstName + ' ' + LastName  
                                          from Actors  
                                          where UserID='" + userID + "'";

                        string actorName = comm.ExecuteScalar().ToString();
                        lblNameStudent.Text = actorName;

                        SqlCommand cmd = new SqlCommand();
                        comm.Connection = conn;
                        comm.CommandText = @" SELECT Convert(Varchar(20), t4.Class) + t5.Division as Class
                                          FROM  Actors AS t1 INNER JOIN
                                          ClassStudents AS t2 ON t2.StudentID = t1.ActorID INNER JOIN
                                          ClassDevisionDetails AS t3 ON t3.ClassDevisionDetailsID = t2.ClassDevisionDetailsID INNER JOIN
                                          Classes AS t4 ON t4.ClassID = t3.ClassID INNER JOIN
                                          Divisions AS t5 ON t5.DivisionID = t3.DivID 
                                          where UserID='" + userID + "'";

                        string classDivision = comm.ExecuteScalar().ToString();
                        lblClass.Text = classDivision;
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        lblNameStudent.Text = ex.Message;
                    }
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