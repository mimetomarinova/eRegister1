using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace eRegister1.Student
{
    public partial class Draft : System.Web.UI.Page
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

                System.Data.DataTable draftMessage = new System.Data.DataTable();
                eRegisterData.DAL oDAL1 = new eRegisterData.DAL();
                draftMessage = oDAL1.GetAllTemplates(studentID);
                GridViewDraft.DataSource = draftMessage.DefaultView;
                GridViewDraft.DataBind();
            }
            else { Response.Redirect("~/eRegister.aspx"); }
        }

        protected void GridViewDraft_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewDraft.PageIndex = e.NewPageIndex;
            GridViewDraft.DataBind();
        }

        protected void GridViewDraft_SelectedIndexChanged(object sender, EventArgs e)
        {
            String messageID;
            messageID = GridViewDraft.SelectedRow.Cells[0].Text;
            Response.Redirect("~/Student/NewMessages.aspx?messageID=" + messageID, true);
        }

      
    }
}