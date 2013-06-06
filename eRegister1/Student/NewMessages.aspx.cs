using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


namespace eRegister1.Student
{
    public partial class NewMessages : System.Web.UI.Page
    {
        int userID;
        int studentID;
        static string filePath;
        static int messageFrom = 0;
        static string messageID = string.Empty;
        //static int messageTo = 0;
        static int StatusID = 0;
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
                System.Data.DataTable teacherNameInfo = new System.Data.DataTable();
                eRegisterData.DAL oDal = new eRegisterData.DAL();
                if (!IsPostBack)
                {
                                     
                    teacherNameInfo = oDal.GetTeacherList(studentID);
                    DropDownListTeacher.DataSource = teacherNameInfo.DefaultView;
                    DropDownListTeacher.DataTextField = teacherNameInfo.Columns["TeacherName"].ColumnName.ToString();
                    DropDownListTeacher.DataValueField = teacherNameInfo.Columns["TeacherID"].ColumnName.ToString();
                    DropDownListTeacher.DataBind();
                    DropDownListTeacher.Items.Add(new ListItem("Моля изберете", "-1"));
                    DropDownListTeacher.SelectedIndex = DropDownListTeacher.Items.Count - 1;
   
                }
                messageID = Request.QueryString["messageID"];
                if (messageID != string.Empty)
                {
                    StatusID = oDal.MessageStatusID(messageID);
                    if (StatusID == 1)
                    {
                        System.Data.DataTable dt = oDal.MessageDraft(messageID);
                        
                        DropDownListTeacher.ClearSelection();

                        ListItem selectedListItem = DropDownListTeacher.Items.FindByValue(dt.Rows[0][0].ToString());
                        if (selectedListItem != null)
                        {
                            selectedListItem.Selected = true;

                        }
                        txtMessage.Text = dt.Rows[0][1].ToString();
                    }
                    else
                    {
                        try
                        {
                            messageFrom = oDal.MessageReply(messageID);

                        }
                        catch (Exception ex)
                        {
                            lblError.Text = "No link to the Data Server!";
                        }
                        DropDownListTeacher.ClearSelection();
                        ListItem selectedListItem = DropDownListTeacher.Items.FindByValue(messageFrom.ToString());
                        if (selectedListItem != null)
                        {
                            selectedListItem.Selected = true;
                            DropDownListTeacher.Enabled = false;
                        }
                        else
                        {
                            
                        }
                    }
                }
            }
            else { Response.Redirect("~/eRegister.aspx"); }
        }

        protected void ButtonAttach_Click(object sender, EventArgs e)
        {

            if (!FileUploadHomework.HasFile)
            {
                lblError.Text = "Изберете файл";
            }
            else
            {

                string fileName = Server.HtmlEncode(FileUploadHomework.FileName);
                string extension = System.IO.Path.GetExtension(fileName);
                if ((extension == ".docx") || (extension == ".doc") || (extension == ".xls"))
                {
                    filePath = Server.MapPath("~/Uploads/") + fileName;
                    FileUploadHomework.SaveAs(filePath);
                    lblError.Text = "<b>Файлът е добавен </b><br/> ";
                    lblError.Text += "Име: " + FileUploadHomework.FileName + "<br/>";
                    lblError.Text += "Размер: " + FileUploadHomework.PostedFile.ContentLength + " bytes <br/>";
                }
                else
                {
                    lblError.Text = "Файлът трябва да е с разширение .doc, .xls, или .docx ";

                }

            }

        }

        protected void ButtonSend_Click(object sender, EventArgs e)
        {
            if (DropDownListTeacher.SelectedValue.Equals("-1"))
            {
                lblMessage.Text = "Моля, посочете получател!";

            }
            else if (txtMessage.Text == string.Empty)
            {
                lblMessage.Text = "Съобщението няма съдържание!";
            }

            else
            {
                eRegisterData.DAL DAL = new eRegisterData.DAL();
                if (StatusID != 1)
                {
                    DAL.CreateMessage(studentID, Int32.Parse(DropDownListTeacher.SelectedValue), filePath, txtMessage.Text, 1, 2, Int32.Parse(messageID));
                    StatusID = 0;
                }
                else
                {
                    DAL.CreateMessage(studentID, Int32.Parse(DropDownListTeacher.SelectedValue), filePath, txtMessage.Text, 1, 2);
                }
                lblMessage.Text = "Съобщението е изпратено";
                txtMessage.Text = string.Empty;
            }
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            if (DropDownListTeacher.SelectedIndex == DropDownListTeacher.Items.Count - 1)
            {
                lblMessage.Text = "Моля, посочете получател!";

            }
            else if (txtMessage.Text == string.Empty)
            {
                lblMessage.Text = "Съобщението няма съдържание!";
            }

            else
            {
                eRegisterData.DAL DAL = new eRegisterData.DAL();
                DAL.CreateMessage(studentID, Int32.Parse(DropDownListTeacher.SelectedValue), filePath, txtMessage.Text, 1, 1);
                lblMessage.Text = "Съобщението е запазено";
            }
        }
    }
}