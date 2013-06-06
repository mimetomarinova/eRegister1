using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eRegister1
{
    public partial class NewsDetail : System.Web.UI.Page
    {
        static string prevPage = String.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Data.DataTable newsDetails = new System.Data.DataTable();
            eRegisterData.DAL oDal = new eRegisterData.DAL();
            string newID = Request.Params["newID"];
            int newIDParam = Int32.Parse(newID);


             if (!IsPostBack)
            { 
                 prevPage = Request.UrlReferrer.ToString();
                try
                {
                    newsDetails = oDal.getNewsByNewID(newIDParam);
                }
                catch (Exception ex)
                {
                    lblErr.Text = "No link to the Data Server!";
                }
                FormView1.DataSource = newsDetails.DefaultView;
                FormView1.DataBind();
             }
        }
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect(prevPage);
        }
    }
}