using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace eRegister1
{
    public partial class Schoole : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable newsTypes;
            eRegisterData.DAL oDal = new eRegisterData.DAL();
            if (!IsPostBack)
            {
                try
                {
                    newsTypes = oDal.getSchoole();

                    FormView1.DataSource = newsTypes;
                    FormView1.DataBind();

                }
                catch (Exception ex) { lblErr.Text = "No link to the Data Server!"; }

            }
        }
    }
}