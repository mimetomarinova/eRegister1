using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;



namespace eRegister1
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            DataTable newsTypes;
            eRegisterData.DAL oDal = new eRegisterData.DAL();
            if (!IsPostBack)
            {
                try
                {
                    newsTypes = oDal.getNewsTitles();

                    ListView1.DataSource = newsTypes;
                    ListView1.DataBind();

                }
                catch (Exception ex) { LabelErr.Text = "No link to the Data Server!"; }

            }
        }


        protected void DataPager1_PreRender(object sender, EventArgs e)
        {
            DataTable newsTypes;
            eRegisterData.DAL oDal = new eRegisterData.DAL();
            newsTypes = oDal.getNewsTitles();
            ListView1.DataSource = newsTypes;
            ListView1.DataBind();
        }

        
    }
}


