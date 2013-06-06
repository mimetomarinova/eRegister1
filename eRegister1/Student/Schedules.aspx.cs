using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace eRegister1.Student
{
    public partial class Schedules : System.Web.UI.Page
    {
        int userID;
        int studentID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                userID = Int32.Parse(Session["UserID"].ToString());
                if (!IsPostBack)
                {
                    LinkButtonFirst_Click(this, null);
                }
            }
            else { Response.Redirect("~/eRegister.aspx"); }
        }

        protected void LinkButtonFirst_Click(object sender, EventArgs e)
        {
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

            System.Data.DataTable monday = new System.Data.DataTable();

            monday = oDal.getSchedule(studentID, "Понеделник", "първи");
            GridViewMonday.DataSource = monday.DefaultView;
            GridViewMonday.DataBind();

            System.Data.DataTable tuesday = new System.Data.DataTable();
            tuesday = oDal.getSchedule(studentID, "Вторник", "първи");
            GridViewTuesday.DataSource = tuesday.DefaultView;
            GridViewTuesday.DataBind();

            System.Data.DataTable wednesday = new System.Data.DataTable();
            wednesday = oDal.getSchedule(studentID, "Сряда", "първи");
            GridViewWednesday.DataSource = wednesday.DefaultView;
            GridViewWednesday.DataBind();

            System.Data.DataTable thursday = new System.Data.DataTable();
            thursday = oDal.getSchedule(studentID, "Четвъртък", "първи");
            GridViewThursday.DataSource = thursday.DefaultView;
            GridViewThursday.DataBind();

            System.Data.DataTable friday = new System.Data.DataTable();
            friday = oDal.getSchedule(studentID, "Петък", "първи");
            GridViewFriday.DataSource = friday.DefaultView;
            GridViewFriday.DataBind();


        }

        protected void LinkButtonSecond_Click(object sender, EventArgs e)
        {
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

            System.Data.DataTable monday = new System.Data.DataTable();

            monday = oDal.getSchedule(studentID, "Понеделник", "втори");
            GridViewMonday.DataSource = monday.DefaultView;
            GridViewMonday.DataBind();

            System.Data.DataTable tuesday = new System.Data.DataTable();
            tuesday = oDal.getSchedule(studentID, "Вторник", "втори");
            GridViewTuesday.DataSource = tuesday.DefaultView;
            GridViewTuesday.DataBind();

            System.Data.DataTable wednesday = new System.Data.DataTable();
            wednesday = oDal.getSchedule(studentID, "Сряда", "втори");
            GridViewWednesday.DataSource = wednesday.DefaultView;
            GridViewWednesday.DataBind();

            System.Data.DataTable thursday = new System.Data.DataTable();
            thursday = oDal.getSchedule(studentID, "Четвъртък", "втори");
            GridViewThursday.DataSource = thursday.DefaultView;
            GridViewThursday.DataBind();

            System.Data.DataTable friday = new System.Data.DataTable();
            friday = oDal.getSchedule(studentID, "Петък", "втори");
            GridViewFriday.DataSource = friday.DefaultView;
            GridViewFriday.DataBind();
        }


    }
}