using AlgonquinCollege.Registration.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lab3;

namespace Lab3
{
    public partial class AddStudent : System.Web.UI.Page
    {
        List<Course> Courses = new List<Course>();
        protected void Page_Load(object sender, EventArgs e)
        {
            LinkButton home = (LinkButton)Master.FindControl("btnHome");
            BulletedList addCourse = (BulletedList)Master.FindControl("topMenu");
            addCourse.Items.Clear();
            addCourse.Items.Add(new ListItem("Add Course"));
            home.Click += home_Click;
            addCourse.Click += addCourse_Click;
            if (Session["Courses"] == null)
            {
                Response.Redirect("AddCourse.aspx");
            }
            Courses = Session["Courses"] as List<Course>;
            if (!IsPostBack)
            {
                Courses.Sort((c1, c2) => c1.CourseNumber.CompareTo(c2.CourseNumber));
                foreach (Course course in Courses)
                {
                    ListItem item = new ListItem(course.ToString(), course.CourseNumber);
                    ddCourse.Items.Add(item);
                }
            }
            String sort = Request.Params["sort"];
            if (!String.IsNullOrEmpty(sort))
            {
                createStudentTable(Courses, sort);
            }
            else
            {
                createStudentTable(Courses);
            }
            
        }

        void home_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
        void addCourse_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddCourse.aspx");
        }

        protected void bSubmitStudent_Click(object sender, EventArgs e)
        {
            Courses = Session["Courses"] as List<Course>;
            if (Courses == null)
            {
                Courses = new List<Course>();
            }
            foreach (Course course in Courses)
            {
                if(course.CourseNumber == ddCourse.SelectedItem.Value)
                {
                    course.AddStudent(new Student(tbStudentNumber.Text, tbStudentName.Text, tbGrade.Text));
                    tbStudentNumber.Text = "";
                    tbStudentName.Text = "";
                    tbGrade.Text = "";
                    Session["Courses"] = Courses;
                    createStudentTable(Courses);
                }
            }
        }

        protected void drpCourseSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            createStudentTable(Courses);
        }

        public void createStudentTable(List<Course> courses, string sort = "id")
        {
            for (int i = tblStudent.Rows.Count - 1; i > 0; i--)
            {
                tblStudent.Rows.RemoveAt(i);
            }

            foreach (Course course in courses)
            {
                if (course.CourseNumber == ddCourse.SelectedItem.Value)
                {
                    if (course.IsEmpty)
                    {
                        TableRow emptyDataRow = new TableRow();
                        TableCell emptyDataCell = new TableCell();
                        emptyDataCell.Text = "No Students in the system yet.";
                        emptyDataCell.HorizontalAlign = HorizontalAlign.Center;
                        emptyDataCell.ColumnSpan = 3;
                        emptyDataCell.CssClass = "error";
                        emptyDataRow.Cells.Add(emptyDataCell);
                        tblStudent.Rows.Add(emptyDataRow);
                    }
                    else
                    {
                        List<Student> students = course.GetStudents();
                        if (sort == "id")
                        {
                            students.Sort((c1, c2) => c1.Id.CompareTo(c2.Id));
                        }
                        else if (sort == "name")
                        {
                            students.Sort((c1, c2) => c1.Name.CompareTo(c2.Name));
                        }
                        else if (sort == "grade")
                        {
                            students.Sort((c1, c2) => c1.Grade.CompareTo(c2.Grade));
                        }
                        if (Session["order"] != null && (string)Session["order"] == "descending")
                        {
                            students.Reverse();
                            Session["order"] = "ascending";
                        }
                        else
                        {
                            Session["order"] = "descending";
                        }
                        foreach (Student student in students)
                        {
                            TableRow tblRow = new TableRow();
                            TableCell tblCellID = new TableCell();
                            TableCell tblCellName = new TableCell();
                            TableCell tblCellGrade = new TableCell();

                            tblCellID.Text = student.Id;
                            tblRow.Cells.Add(tblCellID);
                            tblCellName.Text = student.Name;
                            tblRow.Cells.Add(tblCellName);
                            tblCellGrade.Text = student.Grade.ToString();
                            tblRow.Cells.Add(tblCellGrade);
                            tblStudent.Rows.Add(tblRow);
                        }
                    }
                }
            }
        }
    }
}