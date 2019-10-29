using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookStoreEF;

public partial class BookOrders : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Redirect unauthenticated user to the Default page.
        if(Session["studentNumber"] == null)
        {
            Response.Redirect("Default.aspx");
        }
        
        using (BookStoreDBEntities entityContext = new BookStoreDBEntities())
        {
            //Get the ordered book list of the authenticated user.
            String studentNumber = Session["studentNumber"].ToString();
            Student students = (from student in entityContext.Students
                                    where student.StudentNum == studentNumber
                                    select student).FirstOrDefault<Student>();

            String id = Request.Params["id"];
            String action = Request.Params["action"];

            //If the user clicked the delete link of a book,
            //delete the selected book from the user's order
            if (!String.IsNullOrEmpty(id) && action == "Delete")
            {
                Book books1 = (from book in entityContext.Books
                              where book.BookID == id
                              select book).FirstOrDefault<Book>();

                /*if (books != null)
                {
                    entityContext.Books.Remove(books);
                    entityContext.SaveChanges();
                }*/

                if (students != null && books1 != null)
                {
                    students.Books.Remove(books1);
                    entityContext.SaveChanges();
                }
                
            }

            //If the user clicked a book's title, show the description of the book (use ShowBookDescrition method)

            if (!String.IsNullOrEmpty(id) && action == "ShowDescription")
            {
                Book books = (from book in entityContext.Books
                              where book.BookID == id
                              select book).FirstOrDefault<Book>();
                
                if (books != null)
                {
                    ShowBookDescription(books);
                }
            }

            //Display the book list of the user's order (use ShowBooks method)
            if(students != null)
            {
                ShowBooks(students.Books.ToList());
            }
            
        }
        

    }

 #region Helper methods
    private void ShowBookDescription(Book book)
    {
        pnlDescription.Visible = true;
        lblTitle.Text = book.Title;
        lblDescription.Text = book.Description;
    }

    private void ShowBooks(List<Book> books)
    {
        if (books == null || books.Count == 0)
        {
            TableRow lastRow = new TableRow();
            TableCell lastRowCell = new TableCell();
            lastRowCell.Text = "You have not ordered any book yet";
            lastRowCell.ForeColor = System.Drawing.Color.Red;
            lastRowCell.ColumnSpan = 3;
            lastRowCell.HorizontalAlign = HorizontalAlign.Center;
            lastRow.Cells.Add(lastRowCell);
            tblCourses.Rows.Add(lastRow);
        }
        else
        {
            foreach (Book book in books)
            {
                TableRow row = new TableRow();

                TableCell cell = new TableCell();
                cell.Text = book.BookID;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = "<a href='BookOrders.aspx?action=ShowDescription&id=" + book.BookID + "' title='Show this book&#39;s description'>" + book.Title +"</a>";
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = "<a class='deleteBookOrder' href='BookOrders.aspx?action=Delete&id=" + book.BookID + "' title='Delete this book from your order'>Delete</a>";
                row.Cells.Add(cell);
                tblCourses.Rows.Add(row);
            }
        }
    }
#endregion
}