using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace eRegister1.Admin
{
    public partial class AvSuccess : System.Web.UI.Page
    {
        static int userID;
        static int adminID;
        int SchoolID;
        protected void Page_Load(object sender, EventArgs e)
        {
             
            lblMessage.Visible = false;

            if (Session["UserID"] != null)
            {
                userID = Int32.Parse(Session["UserID"].ToString());

                eRegisterData.DAL DAL = new eRegisterData.DAL();
                SqlConnection conn = DAL.getSubject();
                SqlCommand comm = new SqlCommand();

                try
                {
                    conn.Open();
                    comm.Connection = conn;
                    comm.CommandText = @" SELECT ActorID
                                      FROM Actors
                                      WHERE UserID='" + userID + "'";

                    adminID = Int32.Parse(comm.ExecuteScalar().ToString());
                    conn.Close();
                }
                catch (Exception ex)
                {
                    lblMessage.Text = ex.Message;
                }

                DataTable scholInfo;
                eRegisterData.DAL oDal = new eRegisterData.DAL();
                scholInfo = oDal.getSchooleInfo(adminID);
                SchoolID = Int32.Parse(scholInfo.Rows[0][0].ToString());

               
            }
            else { Response.Redirect("~/eRegister.aspx"); }
        }

        protected void GridViewAvgsubjectScore_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewAvgsubjectScore.PageIndex = e.NewPageIndex;
            GridViewAvgsubjectScore.DataBind();

        }

        protected void GridViewAvgClassScore_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewAvgClassScore.PageIndex = e.NewPageIndex;
            GridViewAvgClassScore.DataBind();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable avgSchoolScore;
            DataTable avgSubjectsScore;
            DataTable avgClassesScore;
            eRegisterData.DAL oDal = new eRegisterData.DAL();

            avgSchoolScore = oDal.AvgSchoolScore(SchoolID, Int16.Parse(DropDownList1.SelectedItem.Value));
            txtSchoolName.Text = avgSchoolScore.Rows[0][0].ToString();
            txtAvgSchoolScore.Text = avgSchoolScore.Rows[0][1].ToString();

            avgSubjectsScore = oDal.AvgSubjectYearScore(SchoolID, Int16.Parse(DropDownList1.SelectedItem.Value));
            GridViewAvgsubjectScore.DataSource = avgSubjectsScore.DefaultView;
            GridViewAvgsubjectScore.DataBind();

            avgClassesScore = oDal.AvgClassesScore(SchoolID, Int16.Parse(DropDownList1.SelectedItem.Value));
            GridViewAvgClassScore.DataSource = avgClassesScore.DefaultView;
            GridViewAvgClassScore.DataBind();
        }
    }
}