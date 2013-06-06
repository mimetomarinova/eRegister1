using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eRegister1.Admin
{
    public partial class Absence : System.Web.UI.Page
    {
        string dateFrom;
        string dateTo;
        static int minAbsence;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            dateFrom = DateTime.Parse(txtDateFrom.Text).ToString("dd MMMM yyyy 'г.'");
            dateTo = DateTime.Parse(txtDateTo.Text).ToString("dd MMMM yyyy 'г.'");
            minAbsence = Int32.Parse(txtMinAbsence.Text);
            System.Data.DataTable absence = new System.Data.DataTable();
            eRegisterData.DAL oDAL = new eRegisterData.DAL();

            absence = oDAL.GetAbsenceInfo(dateFrom, dateTo, minAbsence);
            GridViewAbsence.DataSource = absence.DefaultView;
            GridViewAbsence.DataBind();
        }
    }
}