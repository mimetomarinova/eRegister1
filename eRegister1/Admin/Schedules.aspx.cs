using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eRegister1.Admin
{
    public partial class Schedules : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
         
            if (!IsPostBack)
            {
               
                System.Data.DataTable classList = new System.Data.DataTable();
                eRegisterData.DAL oDal = new eRegisterData.DAL();
                classList = oDal.GetAllClasses();
                DropDownListClasses.DataSource = classList.DefaultView;
                DropDownListClasses.DataTextField = classList.Columns["Class"].ColumnName.ToString();
                DropDownListClasses.DataValueField = classList.Columns["ClassDevisionDetailsID"].ColumnName.ToString();
                DropDownListClasses.DataBind();
                DropDownListClasses.Items.Add(new ListItem("Моля изберете", "-1"));
                DropDownListClasses.SelectedIndex = DropDownListClasses.Items.Count - 1;

                System.Data.DataTable termList = new System.Data.DataTable();
                eRegisterData.DAL oDal1 = new eRegisterData.DAL();
                termList = oDal1.getTerm();
                DropDownListTerm.DataSource = termList.DefaultView;
                DropDownListTerm.DataTextField = termList.Columns["Term"].ColumnName.ToString();
                DropDownListTerm.DataValueField = termList.Columns["TermID"].ColumnName.ToString();
                DropDownListTerm.DataBind();
                DropDownListTerm.Items.Add(new ListItem("Моля изберете", "-1"));
                DropDownListTerm.SelectedIndex = DropDownListTerm.Items.Count - 1;

                System.Data.DataTable weekDay = new System.Data.DataTable();
                eRegisterData.DAL oDal2 = new eRegisterData.DAL();
                weekDay = oDal2.getWeekDay();
                DropDownListWeekDay.DataSource = weekDay.DefaultView;
                DropDownListWeekDay.DataTextField = weekDay.Columns["WeekDay"].ColumnName.ToString();
                DropDownListWeekDay.DataValueField = weekDay.Columns["WeekDayID"].ColumnName.ToString();
                DropDownListWeekDay.DataBind();
                DropDownListWeekDay.Items.Add(new ListItem("Моля изберете", "-1"));
                DropDownListWeekDay.SelectedIndex = DropDownListWeekDay.Items.Count - 1;

               
                GridViewSchedules.DataBind();
            }
            System.Data.DataTable schedules = new System.Data.DataTable();
            eRegisterData.DAL oDAL1 = new eRegisterData.DAL();
            schedules = oDAL1.getSchedulesByClasses(Int32.Parse(DropDownListClasses.SelectedValue), DropDownListWeekDay.SelectedItem.Text, DropDownListTerm.SelectedItem.Text);
            GridViewSchedules.DataSource = schedules.DefaultView;
           

        }
       
        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            if (DropDownListClasses.SelectedValue.Equals("-1"))
            {
                lblMessage.Text = "Моля, изберете стойност за клас!";
                return;
            }
            if (DropDownListTerm.SelectedValue.Equals("-1"))
            {
                lblMessage.Text = "Моля, изберете стойност за срок!";
                return;
            }
            if (DropDownListWeekDay.SelectedValue.Equals("-1"))
            {
                lblMessage.Text = "Моля, изберете стойност за ден от седмицата!";
                return;
            }
            System.Data.DataTable schedules = new System.Data.DataTable();
            eRegisterData.DAL oDAL1 = new eRegisterData.DAL();
            schedules = oDAL1.getSchedulesByClasses(Int32.Parse(DropDownListClasses.SelectedValue), DropDownListWeekDay.SelectedItem.Text, DropDownListTerm.SelectedItem.Text);
            GridViewSchedules.DataSource = schedules.DefaultView;
            GridViewSchedules.DataBind();
            

        }

        protected void GridViewSchedules_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewSchedules.EditIndex = -1;
            GridViewSchedules.DataBind();
        }

        protected void GridViewSchedules_RowEditing(object sender, GridViewEditEventArgs e)
        {

            GridViewSchedules.EditIndex = e.NewEditIndex;
            GridViewSchedules.DataBind();
        }

        protected void GridViewSchedules_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridViewSchedules.Rows[e.RowIndex];

            int scheduleID;
            scheduleID = Int16.Parse(((TextBox)(row.Cells[0].FindControl("TextBox3"))).Text);

            Int16 periodNum;
            periodNum = Int16.Parse(((TextBox)(row.Cells[1].FindControl("TextBox1"))).Text);

            Int16 subject;
            subject = Int16.Parse(((DropDownList)(row.Cells[2].FindControl("DropDownSubject"))).SelectedItem.Value);

            try
            {
                eRegisterData.DAL oDal = new eRegisterData.DAL();
                oDal.Schedule_Update(scheduleID, Int32.Parse(DropDownListClasses.SelectedValue), Int32.Parse(DropDownListTerm.SelectedValue), periodNum, subject, Int16.Parse(DropDownListWeekDay.SelectedValue));
            }
            catch (Exception ex) { lblMessage.Text = ex.Message; }
            GridViewSchedules.EditIndex = -1;
            GridViewSchedules.DataBind();
        }

      
    }
}