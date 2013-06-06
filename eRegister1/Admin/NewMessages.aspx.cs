using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace eRegister1.Admin
{
    public partial class NewMessages : System.Web.UI.Page
    {
        int userID;
        int studentID;
        static string filePath;
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
                    lblError.Text = ex.Message;
                }

                if (!IsPostBack)
                {
                    System.Data.DataTable teacherName = new System.Data.DataTable();
                    eRegisterData.DAL oDal = new eRegisterData.DAL();
                    teacherName = oDal.GetActors(2);
                    DropDownListTeacher.DataSource = teacherName.DefaultView;
                    DropDownListTeacher.DataTextField = teacherName.Columns["Name"].ColumnName.ToString();
                    DropDownListTeacher.DataValueField = teacherName.Columns["ActorID"].ColumnName.ToString();
                    DropDownListTeacher.DataBind();
                    DropDownListTeacher.Items.Add(new ListItem("Моля изберете", "-1"));
                    DropDownListTeacher.SelectedIndex = DropDownListTeacher.Items.Count - 1;

                    System.Data.DataTable parentName = new System.Data.DataTable();
                    eRegisterData.DAL oDal1 = new eRegisterData.DAL();
                    parentName = oDal1.GetActors(3);
                    DropDownListParent.DataSource = parentName.DefaultView;
                    DropDownListParent.DataTextField = parentName.Columns["Name"].ColumnName.ToString();
                    DropDownListParent.DataValueField = parentName.Columns["ActorID"].ColumnName.ToString();
                    DropDownListParent.DataBind();
                    DropDownListParent.Items.Add(new ListItem("Моля изберете", "-1"));
                    DropDownListParent.SelectedIndex = DropDownListParent.Items.Count - 1;

                    System.Data.DataTable studentName = new System.Data.DataTable();
                    eRegisterData.DAL oDal2 = new eRegisterData.DAL();
                    studentName = oDal2.GetActors(4);
                    DropDownListStudent.DataSource = studentName.DefaultView;
                    DropDownListStudent.DataTextField = studentName.Columns["Name"].ColumnName.ToString();
                    DropDownListStudent.DataValueField = studentName.Columns["ActorID"].ColumnName.ToString();
                    DropDownListStudent.DataBind();
                    DropDownListStudent.Items.Add(new ListItem("Моля изберете", "-1"));
                    DropDownListStudent.SelectedIndex = DropDownListStudent.Items.Count - 1;

                    System.Data.DataTable messageTypeInfo = new System.Data.DataTable();
                    eRegisterData.DAL oDal3 = new eRegisterData.DAL();
                    messageTypeInfo = oDal3.getMessageType();
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
            if (DropDownListMessageType.SelectedValue.Equals("4"))
            {
                System.Data.DataTable messageTypeInfo = new System.Data.DataTable();
                eRegisterData.DAL oDal3 = new eRegisterData.DAL();
                messageTypeInfo = oDal3.getMessageType();
                txtMessage.Text = messageTypeInfo.Select("MessageTypeID = 4")[0][2].ToString();
            }
            else
            {
                txtMessage.Text = string.Empty;
                return;
            }
        }

        protected void ButtonSend_Click(object sender, EventArgs e)
        {
            if ((DropDownListTeacher.SelectedValue.Equals("-1")) && (DropDownListStudent.SelectedValue.Equals("-1")) && (DropDownListParent.SelectedValue.Equals("-1")) &&
                (!chbAllParent.Checked) && (!chbAllStudents.Checked) && (!chbAllTeacher.Checked))
            {
                lblMessage.Text = "Моля, посочете получател!";
                return;
            }
            if (DropDownListMessageType.SelectedValue.Equals("-1"))
            {
                lblMessage.Text = "Моля, посочете тема!";
                return;
            }
            if (txtMessage.Text == string.Empty)
            {
                lblMessage.Text = "Съобщението няма съдържание!";
                return;
            }
            eRegisterData.DAL DAL = new eRegisterData.DAL();
            if ((!DropDownListTeacher.SelectedValue.Equals("-1")) || chbAllTeacher.Checked)
            {
                if (chbAllTeacher.Checked)
                {
                    foreach (ListItem teacher in DropDownListTeacher.Items)
                    {
                        if (Int32.Parse(teacher.Value) > 0)
                        {
                            DAL.CreateMessage(studentID, Int32.Parse(teacher.Value), filePath, txtMessage.Text, Int32.Parse(DropDownListMessageType.SelectedValue), 2);
                        }
                    }
                    lblMessage.Text = "Съобщението е изпратено до всички избрани.";
                }
                else
                {
                    DAL.CreateMessage(studentID, Int32.Parse(DropDownListTeacher.SelectedValue), filePath, txtMessage.Text, Int32.Parse(DropDownListMessageType.SelectedValue), 2);
                    lblMessage.Text = "Съобщението е изпратено";
                }
            }
            if ((!DropDownListParent.SelectedValue.Equals("-1"))|| chbAllParent.Checked)
            {
                if (chbAllParent.Checked)
                {
                    foreach (ListItem parent in DropDownListParent.Items)
                    {
                        if (Int32.Parse(parent.Value) > 0)
                        {
                            DAL.CreateMessage(studentID, Int32.Parse(parent.Value), filePath, txtMessage.Text, Int32.Parse(DropDownListMessageType.SelectedValue), 2);
                        }
                    }
                    lblMessage.Text = "Съобщението е изпратено до всички избрани.";
                }
                else
                {

                    DAL.CreateMessage(studentID, Int32.Parse(DropDownListParent.SelectedValue), filePath, txtMessage.Text, Int32.Parse(DropDownListMessageType.SelectedValue), 2);
                    lblMessage.Text = "Съобщението е изпратено";
                }
            }
            if ((!DropDownListStudent.SelectedValue.Equals("-1")) || chbAllStudents.Checked)
            {
                if (chbAllStudents.Checked)
                {
                    foreach (ListItem student in DropDownListStudent.Items)
                    {
                        if (Int32.Parse(student.Value) > 0)
                        {
                            DAL.CreateMessage(studentID, Int32.Parse(DropDownListStudent.SelectedValue), filePath, txtMessage.Text, Int32.Parse(DropDownListMessageType.SelectedValue), 2);
                        }
                    }
                    lblMessage.Text = "Съобщението е изпратено до всички избрани.";
                }
                else
                {

                    DAL.CreateMessage(studentID, Int32.Parse(DropDownListStudent.SelectedValue), filePath, txtMessage.Text, Int32.Parse(DropDownListMessageType.SelectedValue), 2);
                    lblMessage.Text = "Съобщението е изпратено";
                }
            }
        }

      
    }
}