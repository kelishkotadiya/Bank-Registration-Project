using AlgonquinCollege.Registration.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab3
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LinkButton home = (LinkButton)Master.FindControl("btnHome");
            BulletedList addCourse = (BulletedList)Master.FindControl("topMenu");
            BulletedList addStudent = (BulletedList)Master.FindControl("topMenu");
            addCourse.Items.Clear();
            addStudent.Items.Clear();
            addCourse.Items.Add(new ListItem("Add Courses"));
            addStudent.Items.Add(new ListItem("Add Student Records"));
            home.Click += home_Click;
            addCourse.Click += addCourse_Click;
            addStudent.Click += addStudent_Click;
        }
        void home_Click(object sender, EventArgs e)
        {
            
        }
        void addStudent_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddStudent.aspx");
        }
        void addCourse_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddCourse.aspx");
        }
    }
}