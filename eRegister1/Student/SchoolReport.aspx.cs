using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace eRegister1.Student
{
    public partial class SchoolReport : System.Web.UI.Page
    {
        int userID;
        int studentID;
        protected void Page_Load(object sender, EventArgs e)
        {
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

                    studentID = Int32.Parse(comm.ExecuteScalar().ToString());
                    conn.Close();
                }
                catch (Exception ex)
                {
                    lblMessage.Text = ex.Message;
                }
                System.Data.DataTable scoreInfo = new System.Data.DataTable();
                eRegisterData.DAL oDAL1 = new eRegisterData.DAL();
                scoreInfo = oDAL1.GetScoreInfo(studentID);
                GridViewYearScore.DataSource = scoreInfo.DefaultView;
                GridViewYearScore.DataBind();
                if (!IsPostBack)
                {
                    System.Data.DataTable termInfo = new System.Data.DataTable();
                    eRegisterData.DAL oDal = new eRegisterData.DAL();
                    termInfo = oDal.getTerm();
                    DropDownListTerm.DataSource = termInfo.DefaultView;
                    DropDownListTerm.DataTextField = termInfo.Columns["Term"].ColumnName.ToString();
                    DropDownListTerm.DataValueField = termInfo.Columns["TermID"].ColumnName.ToString();
                    DropDownListTerm.DataBind();
                    DropDownListTerm.Items.Add(new ListItem("Моля изберете", "-1"));
                    DropDownListTerm.SelectedIndex = DropDownListTerm.Items.Count - 1;

                    System.Data.DataTable subjectInfo = new System.Data.DataTable();
                    eRegisterData.DAL oDAL = new eRegisterData.DAL();
                    subjectInfo = oDAL.getSubjectInfo();
                    DropDownListSubject.DataSource = subjectInfo.DefaultView;
                    DropDownListSubject.DataTextField = subjectInfo.Columns["Name"].ColumnName.ToString();
                    DropDownListSubject.DataValueField = subjectInfo.Columns["SubjectID"].ColumnName.ToString();
                    DropDownListSubject.DataBind();
                    DropDownListSubject.Items.Add(new ListItem("Моля изберете", "-1"));
                    DropDownListSubject.SelectedIndex = DropDownListSubject.Items.Count - 1;

                    System.Data.DataTable scoreInfo1 = new System.Data.DataTable();
                    eRegisterData.DAL oDAL2 = new eRegisterData.DAL();
                    scoreInfo1 = oDAL.getTerm();
                    DropDownListYearScore.DataSource = scoreInfo1.DefaultView;
                    DropDownListYearScore.DataTextField = scoreInfo1.Columns["Term"].ColumnName.ToString();
                    DropDownListYearScore.DataValueField = scoreInfo1.Columns["TermID"].ColumnName.ToString();
                    DropDownListYearScore.DataBind();
                    DropDownListYearScore.Items.Add(new ListItem("Моля изберете", "-1"));
                    DropDownListYearScore.SelectedIndex = DropDownListYearScore.Items.Count - 1;

                    if (DropDownListYearScore.SelectedIndex == DropDownListYearScore.Items.Count - 1)
                    {
                        txtYearScore.Text = string.Empty;  
                    }

                    

                }
            }
            else { Response.Redirect("~/eRegister.aspx"); }
        }

        protected void DropDownListTerm_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (DropDownListTerm.SelectedIndex == DropDownListTerm.Items.Count - 1)
            {
                GridViewScore.DataSource = null;
                GridViewScore.DataBind();
                txtAvgSubjectScore.Text = string.Empty;
                return;
            }
            System.Data.DataTable studentScore = new System.Data.DataTable();
            eRegisterData.DAL oDAL = new eRegisterData.DAL();
            if (DropDownListSubject.SelectedValue.Equals("-1"))
            {
                studentScore = oDAL.GetStudentScores(studentID, byte.Parse(DropDownListTerm.SelectedValue), 0);
                txtAvgSubjectScore.Text = string.Empty;
            }
            else
            {
                studentScore = oDAL.GetStudentScores(studentID, byte.Parse(DropDownListTerm.SelectedValue), short.Parse(DropDownListSubject.SelectedValue));
                if (!DropDownListTerm.SelectedValue.Equals("-1"))
                {
                    txtAvgSubjectScore.Text = oDAL.GetStudentsAvgScore(studentID, byte.Parse(DropDownListTerm.SelectedValue), short.Parse(DropDownListSubject.SelectedValue));
                }
                else
                {
                    txtAvgSubjectScore.Text = string.Empty;
                }
            }
            GridViewScore.DataSource = studentScore.DefaultView;
            GridViewScore.DataBind();

        }

        protected void DropDownListSubject_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (DropDownListTerm.SelectedIndex == DropDownListTerm.Items.Count - 1)
            {
                txtAvgSubjectScore.Text = string.Empty;
                return;
            }
            System.Data.DataTable studentScore = new System.Data.DataTable();
            eRegisterData.DAL oDAL = new eRegisterData.DAL();
            if (DropDownListSubject.SelectedValue.Equals("-1"))
            {
                studentScore = oDAL.GetStudentScores(studentID, byte.Parse(DropDownListTerm.SelectedValue), 0);
                txtAvgSubjectScore.Text = string.Empty;
            }
            else
            {
                studentScore = oDAL.GetStudentScores(studentID, byte.Parse(DropDownListTerm.SelectedValue), short.Parse(DropDownListSubject.SelectedValue));
                if (!DropDownListTerm.SelectedValue.Equals("-1"))
                {
                    txtAvgSubjectScore.Text = oDAL.GetStudentsAvgScore(studentID, byte.Parse(DropDownListTerm.SelectedValue), short.Parse(DropDownListSubject.SelectedValue));
                }
                else
                {
                    txtAvgSubjectScore.Text = string.Empty;
                }
            }
            GridViewScore.DataSource = studentScore.DefaultView;
            GridViewScore.DataBind();

        }

        protected void DropDownListYearScore_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListYearScore.SelectedValue.Equals("1") || DropDownListYearScore.SelectedValue.Equals("2"))
            {

                eRegisterData.DAL DAL1 = new eRegisterData.DAL();
                txtYearScore.Text = DAL1.GetAVGScoreType(studentID, int.Parse(DropDownListYearScore.SelectedValue), 2);

            }
            else if (DropDownListYearScore.SelectedValue.Equals("3"))
            {
                eRegisterData.DAL DAL1 = new eRegisterData.DAL();
                txtYearScore.Text = DAL1.GetAVGScoreType(studentID, int.Parse(DropDownListYearScore.SelectedValue), 3);
            }
            else
            {
                txtYearScore.Text = string.Empty;
                
            }
        }
    }
}