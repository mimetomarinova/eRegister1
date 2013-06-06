using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace eRegister1.Admin
{
    public partial class ClassDevisionDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Data.DataTable allClasses = new System.Data.DataTable();
            eRegisterData.DAL oDAL1 = new eRegisterData.DAL();

            try
            {
                allClasses = oDAL1.GetAllClasses();
                GridViewAllClasses.DataSource = allClasses.DefaultView;
                GridViewAllClasses.DataBind();
            }
            catch (Exception ex) { lblError.Text = "Възникнала е грешка!"; }

            String Classes = Request.QueryString["Classes"];
            System.Data.DataTable classList = new System.Data.DataTable();

            if (Classes != "")
            {
                try
                {
                    classList = oDAL1.GetClassStudents(Classes);
                }
                catch (Exception ex)
                {
                    lblError.Text = "Възникнала е грешка!";
                }
            }

            GridViewClassList.DataSource = classList.DefaultView;
            if (!IsPostBack)
            {

                GridViewClassList.DataBind();
            }
        }

        protected void Get_Classes(object sender, CommandEventArgs e)
        {
            Response.Redirect("ClassDevisionDetails.aspx?Classes= " + e.CommandName);
        }

        protected void GridViewAllClasses_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            GridViewAllClasses.PageIndex = e.NewPageIndex;
            GridViewAllClasses.DataBind();

        }

        protected void GridViewClassList_RowEditing(object sender, GridViewEditEventArgs e)
        {

            GridViewClassList.EditIndex = e.NewEditIndex;

            GridViewClassList.DataBind();
        }

        protected void GridViewClassList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewClassList.PageIndex = e.NewPageIndex;
            GridViewClassList.DataBind();
        }

        protected void GridViewClassList_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewClassList.EditIndex = -1;
            GridViewClassList.DataBind();
        }

        protected void GridViewClassList_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridViewClassList.Rows[e.RowIndex];
            int idStudent;
            idStudent = Int32.Parse(((TextBox)(row.Cells[0].FindControl("TextBox4"))).Text);
            int number;
            number = Int32.Parse(((TextBox)(row.Cells[1].FindControl("TextBox2"))).Text);
            String name;
            name = ((TextBox)(row.Cells[2].FindControl("TextBox3"))).Text;
            DateTime dateOfChange;
            dateOfChange = Convert.ToDateTime(((TextBox)(row.Cells[3].FindControl("TextBox1"))).Text);
            int classList;
            classList =Int32.Parse(((DropDownList)(row.Cells[4].FindControl("DropDownListAllClasses"))).SelectedItem.Value);
            char[] separators = new char[] {' '};
            string[] arr = name.Trim().Split(separators, StringSplitOptions.RemoveEmptyEntries);
            if (arr.Length != 3)
            {
                lblError.Text = "Въведена е некоректна стойност за полето \"Име\".";
                return;
            }
            String FirstName = arr[0];
            String MiddleName = arr[1];
            String LastName = arr[2];

            try
            {
                eRegisterData.DAL oDal = new eRegisterData.DAL();
                oDal.StudentsClass_Update(idStudent, FirstName, MiddleName, LastName, number, dateOfChange, classList);
            }
            catch (Exception ex) { lblError.Text = ex.Message; }
            GridViewClassList.EditIndex = -1;
            GridViewClassList.DataBind();
        }


    }
}