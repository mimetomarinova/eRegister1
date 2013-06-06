using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eRegister1.Student
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        int userID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                userID = Int32.Parse(Session["UserID"].ToString());
            }
            else { Response.Redirect("~/eRegister.aspx"); }
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("DefaultStudent.aspx");
        }

        protected void ButtonOk_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    string password = txtRepeatPassword.Text;
                    eRegisterData.DAL oDal = new eRegisterData.DAL();
                    oDal.UpdatePassword(userID, password);
                    LabelMessage.Text = "Успешно въвеждане!";
                }
                catch (Exception ex) { LabelMessage.Text = "Възникнала е грешка!"; }

            }
            else
            {
                return;
            }
        }
    }
}