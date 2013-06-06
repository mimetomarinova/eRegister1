using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eRegister1.Admin
{
    public partial class Profil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                eRegisterData.DAL oDal = new eRegisterData.DAL();

                oDal.insertNewProfil(TextBoxProfil.Text);

                LabelMessage.Text = "Успешно въвеждане!";
                GridViewProfil.DataBind();


            }
            catch (Exception ex) { LabelMessage.Text = "Възникнала е грешка!"; }
        }
    }
}