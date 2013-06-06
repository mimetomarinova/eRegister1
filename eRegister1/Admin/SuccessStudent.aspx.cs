using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eRegister1.Admin
{
    public partial class SuccessStudent : System.Web.UI.Page
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

            //String Classes = Request.QueryString["Classes"];
            //System.Data.DataTable classList = new System.Data.DataTable();

            //if (Classes != "")
            //{
            //    try
            //    {
            //        classList = oDAL1.GetClassStudents(Classes);
            //    }
            //    catch (Exception ex)
            //    {
            //        lblError.Text = "Възникнала е грешка!";
            //    }
            //}

            //GridViewClassList.DataSource = classList.DefaultView;
            //if (!IsPostBack)
            //{

            //    GridViewClassList.DataBind();
            //}

        }
        protected void Get_Classes(object sender, CommandEventArgs e)
        {
            Response.Redirect("SuccessStudent.aspx?Classes= " + e.CommandName);
        }

        protected void GridViewAllClasses_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewAllClasses.PageIndex = e.NewPageIndex;
            GridViewAllClasses.DataBind();
        }
    }
}