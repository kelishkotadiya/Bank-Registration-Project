using AlgonquinCollege.Registration.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab3
{
    public partial class AddCourse : System.Web.UI.Page
    {
        List<Course> Courses = new List<Course>();
        protected void Page_Load(object sender, EventArgs e)
        {
            LinkButton home = (LinkButton)Master.FindControl("btnHome");
            BulletedList addStudent = (BulletedList)Master.FindControl("topMenu");
            addStudent.Items.Clear();
            addStudent.Items.Add(new ListItem("Add Student Records"));
            home.Click += home_Click;
            addStudent.Click += addStudent_Click;

            Courses = Session["Courses"] as List<Course>;
            String sort = Request.Params["sort"];
            if (!String.IsNullOrEmpty(sort))
            {
                createCourseTable(Courses, sort);
            }
            else
            {
                createCourseTable(Courses);
            }
            
        }
        void home_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
        void addStudent_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddStudent.aspx");
        }
        protected void bSubmitCourse_Click(object sender, EventArgs e)
        {
            Courses = Session["Courses"] as List<Course>;
            if(Courses == null)
            {
                Courses = new List<Course>();
            }
            string courseNumber = tbCourseNumber.Text.ToString();
            string courseName = tbCourseName.Text.ToString();
            Courses.Add(new Course(courseNumber, courseName, new List<Student>()));
            Session["Courses"] = Courses;
            createCourseTable(Courses);
            tbCourseNumber.Text = "";
            tbCourseName.Text = "";
        }

        public void createCourseTable(List<Course> courses, string sort = "code")
        {
            for(int i = tblCourse.Rows.Count - 1; i > 0; i--)
            {
                tblCourse.Rows.RemoveAt(i);
            }

            if (courses == null || courses.Count() == 0)
            {
                TableRow emptyDataRow = new TableRow();
                TableCell emptyDataCell = new TableCell();
                emptyDataCell.Text = "No Courses in the system yet.";
                emptyDataCell.HorizontalAlign = HorizontalAlign.Center;
                emptyDataCell.ColumnSpan = 2;
                emptyDataCell.CssClass = "error";
                emptyDataRow.Cells.Add(emptyDataCell);
                tblCourse.Rows.Add(emptyDataRow);
            }
            else
            {
                if(sort == "code")
                {
                    courses.Sort((c1, c2) => c1.CourseNumber.CompareTo(c2.CourseNumber));
                }
                else if (sort == "title")
                {
                    courses.Sort((c1, c2) => c1.CourseName.CompareTo(c2.CourseName));
                }
                if(Session["order"] != null && (string)Session["order"] == "descending")
                {
                    courses.Reverse();
                    Session["order"] = "ascending";
                }
                else
                {
                    Session["order"] = "descending";
                }
                foreach (Course course in courses)
                {
                    TableRow tblRow = new TableRow();
                    TableCell tblCellCode = new TableCell();
                    TableCell tblCellName = new TableCell();

                    tblCellCode.Text = course.CourseNumber;
                    tblRow.Cells.Add(tblCellCode);
                    tblCellName.Text = course.CourseName;
                    tblRow.Cells.Add(tblCellName);
                    tblCourse.Rows.Add(tblRow);
                }
            }
        }
    }
}