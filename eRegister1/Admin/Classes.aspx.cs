using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eRegister1.Admin
{
    public partial class Classes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LabelMessage.Visible = false;
        }

        protected void buttonSave_Click(object sender, EventArgs e)
        {
           
                try
                {
                    eRegisterData.DAL oDal = new eRegisterData.DAL();

                    oDal.insertNewClasses(Int32.Parse(TextBoxClasses.Text));
                    LabelMessage.Visible = true;
                    LabelMessage.Text = "Успешно въвеждане!";
                    GridViewClasses.DataBind();


                }
                catch (Exception ex) { LabelMessage.Text = "Възникнала е грешка!"; }
            }
        }
    }
