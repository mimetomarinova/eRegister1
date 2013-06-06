using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace eRegister1
{
    public partial class Teachers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DropDownListTeacher_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Data.DataTable teacherInfo = new System.Data.DataTable();
            eRegisterData.DAL oDal = new eRegisterData.DAL();
            
            foreach (ListItem c in DropDownListTeacher.Items)
                {
                
                    try
                    {
                        Panel2.Visible = true;
                        teacherInfo = oDal.getTeacherInfo(int.Parse(c.Value));
                        GridView1.DataSource = teacherInfo.DefaultView;
                        GridView1.DataBind();
                        return;
                    }
                    catch (Exception ex) { lblErr.Text = "No link to the Data Server!"; }

                }
        
        }


    }
}