using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace eRegister1.Student
{
    public partial class Massages : System.Web.UI.Page
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
                System.Data.DataTable message = new System.Data.DataTable();
                eRegisterData.DAL oDAL1 = new eRegisterData.DAL();

                message = oDAL1.GetUsersMessages(studentID, 0);

                GridViewMessages.DataSource = message.DefaultView;
                GridViewMessages.DataBind();
                if (!IsPostBack)
                {
                    System.Data.DataTable messageTypeInfo = new System.Data.DataTable();
                    eRegisterData.DAL oDal = new eRegisterData.DAL();
                    messageTypeInfo = oDal.getMessageType();

                    DropDownListMessageType.DataSource = messageTypeInfo.DefaultView;
                    DropDownListMessageType.DataTextField = messageTypeInfo.Columns["Type"].ColumnName.ToString();
                    DropDownListMessageType.DataValueField = messageTypeInfo.Columns["MessageTypeID"].ColumnName.ToString();
                    DropDownListMessageType.DataBind();
                    DropDownListMessageType.Items.Add(new ListItem("Моля изберете", "-1"));
                    DropDownListMessageType.SelectedIndex = DropDownListMessageType.Items.Count - 1;
                }

            }
            else { Response.Redirect("~/eRegister.aspx"); }
        }

        protected void DropDownListMessageType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListMessageType.SelectedIndex == DropDownListMessageType.Items.Count - 1)
            {
                System.Data.DataTable message = new System.Data.DataTable();
                eRegisterData.DAL oDAL1 = new eRegisterData.DAL();
                message = oDAL1.GetUsersMessages(studentID, 0);
                GridViewMessages.DataSource = message.DefaultView;
                GridViewMessages.DataBind();

            }

            else
            {
                System.Data.DataTable messageType = new System.Data.DataTable();
                eRegisterData.DAL oDAL = new eRegisterData.DAL();
                messageType = oDAL.GetUsersMessages(studentID, Int32.Parse(DropDownListMessageType.SelectedValue));
                GridViewMessages.DataSource = messageType.DefaultView;
                GridViewMessages.DataBind();
            }
        }

        protected void GridViewMessages_SelectedIndexChanged(object sender, EventArgs e)
        {
            String messageID;
            messageID = GridViewMessages.SelectedRow.Cells[0].Text;
            Response.Redirect("~/Student/NewMessages.aspx?messageID=" + messageID, true);
        }

        protected void GridViewMessages_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewMessages.PageIndex = e.NewPageIndex;
            GridViewMessages.DataBind();
        }




    }
}