using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Security;
using System.Web.UI.WebControls;
using BookStoreEF;
public partial class Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LinkButton btnLogout = (LinkButton)Master.FindControl("btnLogout");
        btnLogout.Visible = false;
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string studentNum = txtStudentNum.Text;
        string password = txtPassword.Text;

        using (BookStoreDBEntities entityContext = new BookStoreDBEntities())
        {
            //Authenicate the user's credential againt data stored 
            //in the Student table in the Registration DB by searching 
            //for the student with the user entered studentNum and password
            Student students = (from student in entityContext.Students
                                where student.StudentNum == studentNum && student.Password == password
                                select student).FirstOrDefault<Student>();
            if (students != null)
            {
                Session["studentNumber"] = txtStudentNum.Text;
                Response.Redirect("BookOrders.aspx");
            }
            else
            {
                lblLoginError.Text = "Incorrect Student Number and/or Password!";
                txtPassword.Text = "";
            }

            

        }
    }
}