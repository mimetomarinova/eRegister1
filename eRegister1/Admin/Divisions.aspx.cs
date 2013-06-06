using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eRegister1.Admin
{
    public partial class Divisions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                eRegisterData.DAL oDal = new eRegisterData.DAL();

                oDal.insertNewDivision(Char.Parse(TextBoxDivision.Text));

                LabelMessage.Text = "Успешно въвеждане!";
                GridViewDivision.DataBind();


            }
            catch (Exception ex) { LabelMessage.Text = "Възникнала е грешка!"; }
        }
    }
}