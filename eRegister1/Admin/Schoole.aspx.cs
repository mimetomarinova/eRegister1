using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using eRegisterData;
using System.Data.SqlClient;

namespace eRegister1.Admin
{
    public partial class Schoole : System.Web.UI.Page
    {
        static int userID;
        static int adminID;
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

            }
            else { Response.Redirect("~/eRegister.aspx"); }
        }
        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/DefaultAdmin.aspx");
        }
        protected void ButtonEdit_Click(object sender, EventArgs e)
        {
            FormViewSchoole.ChangeMode(FormViewMode.Edit);
            DataTable scholInfo;
            eRegisterData.DAL oDal = new eRegisterData.DAL();

            scholInfo = oDal.getSchooleInfo(adminID);

            FormViewSchoole.DataSource = scholInfo;
            FormViewSchoole.DataBind();

            System.Data.DataTable schooleInfo = new System.Data.DataTable();



            schooleInfo = oDal.getSchools();
            ((DropDownList)FormViewSchoole.FindControl("DropDownSchools")).DataSource = schooleInfo.DefaultView;
            ((DropDownList)FormViewSchoole.FindControl("DropDownSchools")).DataTextField = schooleInfo.Columns["SchooName"].ColumnName.ToString();
            ((DropDownList)FormViewSchoole.FindControl("DropDownSchools")).DataValueField = schooleInfo.Columns["SchoolID"].ColumnName.ToString();
            ((DropDownList)FormViewSchoole.FindControl("DropDownSchools")).DataBind();

            System.Data.DataTable schoolInfo = new System.Data.DataTable();
            eRegisterData.DAL oDAL1 = new eRegisterData.DAL();
            schoolInfo = oDAL1.getSchooleInfo(adminID);

            ListItem selectedListItem = ((DropDownList)FormViewSchoole.FindControl("DropDownSchools")).Items.FindByValue(schoolInfo.Rows[0][0].ToString());
            if (selectedListItem != null)
            {
                selectedListItem.Selected = true;
                ((DropDownList)FormViewSchoole.FindControl("DropDownSchools")).Enabled = false;

            }
            ListItem selectedListCity = ((DropDownList)FormViewSchoole.FindControl("DropDownList1")).Items.FindByValue(schoolInfo.Rows[0][2].ToString());
            if (selectedListCity != null)
            {
                selectedListCity.Selected = true;

            }

            ((TextBox)FormViewSchoole.FindControl("txtAddress")).Text = schoolInfo.Rows[0][4].ToString();
            ((TextBox)FormViewSchoole.FindControl("txtMission")).Text = schoolInfo.Rows[0][5].ToString();
            ((TextBox)FormViewSchoole.FindControl("txtStrategy")).Text = schoolInfo.Rows[0][6].ToString();
            ((TextBox)FormViewSchoole.FindControl("txtVision")).Text = schoolInfo.Rows[0][7].ToString();


        }

        protected void ButtonInsert_Click(object sender, EventArgs e)
        {
            try
            {
                eRegisterData.DAL oDal = new eRegisterData.DAL();

                oDal.insertNewSchool(((TextBox)FormViewSchoole.FindControl("txtSchoole")).Text, ((TextBox)FormViewSchoole.FindControl("txtAddress")).Text,
                Int32.Parse(((DropDownList)FormViewSchoole.FindControl("DropDownListCity")).SelectedItem.Value), ((TextBox)FormViewSchoole.FindControl("txtMission")).Text,
                ((TextBox)FormViewSchoole.FindControl("txtStrategy")).Text, ((TextBox)FormViewSchoole.FindControl("txtVision")).Text);
                lblMessage.Visible = true;
                lblMessage.Text = "Успешно въвеждане!";
                ((TextBox)FormViewSchoole.FindControl("txtSchoole")).Text = string.Empty;
                ((TextBox)FormViewSchoole.FindControl("txtAddress")).Text = string.Empty;
                ((TextBox)FormViewSchoole.FindControl("txtMission")).Text = string.Empty;
                ((TextBox)FormViewSchoole.FindControl("txtStrategy")).Text = string.Empty;
                ((TextBox)FormViewSchoole.FindControl("txtVision")).Text = string.Empty;

            }
            catch (Exception ex) { lblMessage.Text = "Възникнала е грешка!"; }

        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {

            try
            {
                eRegisterData.DAL oDal = new eRegisterData.DAL();

                oDal.UpdateSchool(Int32.Parse(((DropDownList)FormViewSchoole.FindControl("DropDownSchools")).SelectedItem.Value), ((DropDownList)FormViewSchoole.FindControl("DropDownSchools")).SelectedItem.Text, ((TextBox)FormViewSchoole.FindControl("txtAddress")).Text,
                Int32.Parse(((DropDownList)FormViewSchoole.FindControl("DropDownList1")).SelectedItem.Value), ((TextBox)FormViewSchoole.FindControl("txtMission")).Text,
                ((TextBox)FormViewSchoole.FindControl("txtStrategy")).Text, ((TextBox)FormViewSchoole.FindControl("txtVision")).Text);
                lblMessage.Visible = true;
                lblMessage.Text = "Успешна редакция!";

            }
            catch (Exception ex) { lblMessage.Text = "Възникнала е грешка!"; }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Schoole.aspx");
        }



    }









}
