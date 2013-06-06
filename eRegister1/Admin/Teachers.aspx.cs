using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using eRegisterData;
namespace eRegister1.Admin
{
    public partial class Teachers : System.Web.UI.Page
    {
        static int actorID = 0;
        static string teacherName = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Wizard1_NextButtonClick(object sender, WizardNavigationEventArgs e)
        {
            
            if (Wizard1.ActiveStepIndex == 1)
            {
                eRegisterData.DAL oDal = new eRegisterData.DAL();
                try
                {
                    if (ListBoxSubjects.Items.Count > 0)
                    {
                        for (int i = 0; i < ListBoxSubjects.Items.Count; i++)
                        {
                            if (ListBoxSubjects.Items[i].Selected)
                            {
                                string selectedItem = ListBoxSubjects.Items[i].Value;
                                oDal.TeacherSubject_Insert(actorID, Int32.Parse(selectedItem));
                            }
                        }
                    }
                }
                catch (Exception ex) { lblMessage.Text = "Възникнала е грешка!"; Wizard1.ActiveStepIndex = 1; }
                Wizard1.ActiveStepIndex = 2;
            }
            if (Wizard1.ActiveStepIndex == 0)
            {
                try
                {
                    eRegisterData.DAL oDal = new eRegisterData.DAL();

                    actorID = oDal.AddTeacher(((TextBox)FormView1.FindControl("UserNameTextBox")).Text, ((TextBox)FormView1.FindControl("FirstNameTextBox")).Text,
                            ((TextBox)FormView1.FindControl("MiddleNameTextBox")).Text, ((TextBox)FormView1.FindControl("LastNameTextBox")).Text, bool.Parse(((RadioButtonList)FormView1.FindControl("RadioButtonList1")).SelectedItem.Value),
                            String.Empty, ((TextBox)FormView1.FindControl("EGNTextBox")).Text, ((TextBox)FormView1.FindControl("emailTextBox")).Text, false, ((TextBox)FormView1.FindControl("PhoneNumberTextBox")).Text,
                            Int32.Parse(((DropDownList)FormView1.FindControl("DropDownList4")).SelectedItem.Value), 0);

                    if (actorID == 0)
                    {
                        lblMessage.Text = "Учителят не е добавен успешно.";
                        Wizard1.ActiveStepIndex = 0;
                    }
                    else
                    {
                        lblMessage.Text = "Учителят беше добавен успешно.";
                        teacherName = ((TextBox)FormView1.FindControl("FirstNameTextBox")).Text + " " + ((TextBox)FormView1.FindControl("MiddleNameTextBox")).Text + " " + ((TextBox)FormView1.FindControl("LastNameTextBox")).Text;
                    }

                }
                    
                catch (Exception ex) { lblMessage.Text = "Възникнала е грешка!"; }
                
                Wizard1.ActiveStepIndex = 1;
                txtTeacher.Text = teacherName;
            }

        }

        protected void Wizard1_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        {
            try
            {
                eRegisterData.DAL oDal = new eRegisterData.DAL();
                oDal.TeacherClass_Insert(actorID, Int32.Parse(DropDownListAllClasses.SelectedItem.Value));
                teacherName = string.Empty;
                actorID = 0;
                Response.Redirect("~/Admin/Teachers.aspx");
            }
            catch
            {
                lblMessageClass.Text = "Възникнала е грешка!";
                Wizard1.ActiveStepIndex = 2;
            }
        }
    }
}