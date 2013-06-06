using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eRegister1.Admin
{
    public partial class EditTeachers : System.Web.UI.Page
    {
        static String Teachers = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Data.DataTable allTeachers = new System.Data.DataTable();
            eRegisterData.DAL oDAL1 = new eRegisterData.DAL();

            try
            {
                allTeachers = oDAL1.GetActors(2);
                GridViewAllTeachers.DataSource = allTeachers.DefaultView;
                GridViewAllTeachers.DataBind();
            }
            catch (Exception ex) { lblError.Text = "Възникнала е грешка!"; }

            Teachers = Request.QueryString["Teachers"];
            System.Data.DataTable classList = new System.Data.DataTable();

            if (Teachers != "")
            {
                try
                {
                    classList = oDAL1.EditTeacherInfo(Teachers);
                }
                catch (Exception ex)
                {
                    lblError.Text = "Възникнала е грешка!";
                }
            }

            DetailsViewTeacherInfo.DataSource = classList.DefaultView;
            if (!IsPostBack)
            {

                DetailsViewTeacherInfo.DataBind();
            }

        }

        protected void Get_Teachers(object sender, CommandEventArgs e)
        {
            Response.Redirect("EditTeachers.aspx?Teachers= " + e.CommandName);
        }

        protected void GridViewAllTeachers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewAllTeachers.PageIndex = e.NewPageIndex;
            GridViewAllTeachers.DataBind();

        }

        protected void DetailsViewTeacherInfo_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
        {
            DetailsViewTeacherInfo.PageIndex = e.NewPageIndex;

            DetailsViewTeacherInfo.DataBind();
        }

        protected void DetailsViewTeacherInfo_ModeChanging(object sender, DetailsViewModeEventArgs e)
        {
            DetailsViewTeacherInfo.ChangeMode(DetailsViewMode.Edit);

            DetailsViewTeacherInfo.DataBind();
        }

        protected void DetailsViewTeacherInfo_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
               
            string fName;
            fName = ((TextBox)(DetailsViewTeacherInfo.FindControl("txtName"))).Text;
            string mName;
            mName=((TextBox)(DetailsViewTeacherInfo.FindControl("txtMName"))).Text;
            string lName;
            lName = ((TextBox)(DetailsViewTeacherInfo.FindControl("txtLName"))).Text;
            string email;
            email = ((TextBox)(DetailsViewTeacherInfo.FindControl("txtEmail"))).Text;
            string phone;
            phone = ((TextBox)(DetailsViewTeacherInfo.FindControl("txtPhone"))).Text;
            int classID;
            classID = Int32.Parse(((DropDownList)DetailsViewTeacherInfo.FindControl("DropDownListClass")).SelectedItem.Value);

            try
            {
                eRegisterData.DAL oDal = new eRegisterData.DAL();
                oDal.EditTeacher_Update(Int32.Parse(Teachers), fName, mName, lName, email, phone, classID);
            }
            catch (Exception ex) { lblError.Text = ex.Message; }
            DetailsViewTeacherInfo.ChangeMode(DetailsViewMode.ReadOnly); 
            DetailsViewTeacherInfo.DataBind();
        }


    }
}