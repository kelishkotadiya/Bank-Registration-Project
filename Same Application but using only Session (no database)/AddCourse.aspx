<%@ Page Title="" Language="C#" MasterPageFile="~/ACMasterPage.master" AutoEventWireup="true" CodeBehind="AddCourse.aspx.cs" Inherits="Lab3.AddCourse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h1>Course Registration</h1>
        <asp:Table runat="server" CssClass="table" style="margin-left:0px;">
            <asp:TableRow>
                <asp:TableCell>Course Number:</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="tbCourseNumber" runat="server"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:RequiredFieldValidator runat="server" ID="rftCourseNumber" ControlToValidate="tbCourseNumber" ErrorMessage="Must Enter Course Number" CssClass="error"></asp:RequiredFieldValidator></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Course Name:</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="tbCourseName" runat="server"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:requiredfieldvalidator runat="server" id="rftCourseName" controltovalidate="tbCourseName" errormessage="Must Enter Course Name" CssClass="error"></asp:requiredfieldvalidator></asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        
        <asp:Button ID="bSubmit" runat="server" class="btn btn-primary" Text="Submit Course Information" OnClick="bSubmitCourse_Click" />
    </div>
    <br />
    <br />
    <div>            
        <asp:Table runat="server" ID="tblCourse" style="margin-left:15px;" CssClass="table table-bordered">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell CssClass="col-md-4"><a href="AddCourse.aspx?sort=code" >Course Code</a></asp:TableHeaderCell>
                <asp:TableHeaderCell CssClass="col-md-8"><a href="AddCourse.aspx?sort=title" >Course Title</a></asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>
    </div>
</asp:Content>
