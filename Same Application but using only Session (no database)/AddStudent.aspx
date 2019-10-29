<%@ Page Title="" Language="C#" MasterPageFile="~/ACMasterPage.master" AutoEventWireup="true" CodeBehind="AddStudent.aspx.cs" Inherits="Lab3.AddStudent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h1>Add Student Records</h1>
        <asp:Table runat="server" CssClass="table" style="margin-left:0px;">
            <asp:TableRow>
                <asp:TableCell>Course:</asp:TableCell>
                <asp:TableCell><asp:DropDownList runat="server" ID="ddCourse" 
            OnSelectedIndexChanged="drpCourseSelection_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></asp:TableCell>
                <asp:TableCell></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Student Number:</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="tbStudentNumber" runat="server"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:RequiredFieldValidator runat="server" ID="rftStudentNumber" ControlToValidate="tbStudentNumber" ErrorMessage="Must Enter Student ID" Display="Dynamic" CssClass="error"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="retStudentNumber" ValidationExpression="\d+" ControlToValidate="tbStudentNumber" CssClass="error" Display="Dynamic" ErrorMessage="Must be integer!" runat="server"/>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Student Name:</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="tbStudentName" runat="server"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:requiredfieldvalidator runat="server" id="rftStudentName" controltovalidate="tbStudentName" errormessage="Must Enter Student Name" Display="Dynamic" CssClass="error"></asp:requiredfieldvalidator>
                    <asp:RegularExpressionValidator ID="retStudentName" ValidationExpression="[a-zA-Z]+\s+[a-zA-Z]+" ControlToValidate="tbStudentName" CssClass="error" Display="Dynamic" ErrorMessage="Must be in first_name last_name!" runat="server"/>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>Grade:</asp:TableCell>
                <asp:TableCell><asp:TextBox ID="tbGrade" runat="server"></asp:TextBox></asp:TableCell>
                <asp:TableCell><asp:requiredfieldvalidator runat="server" id="rftGrade" controltovalidate="tbGrade" errormessage="Must Enter Grade" Display="Dynamic" CssClass="error"></asp:requiredfieldvalidator>
                    <asp:RangeValidator ID="rgtGrade" ControlToValidate="tbGrade" MinimumValue="0" MaximumValue="100" Type="Integer" Text="The value must be grater than 0 and integer!" runat="server" Display="Dynamic" CssClass="error"></asp:RangeValidator>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        
        <asp:Button ID="bSubmit" runat="server" class="btn btn-primary" Text="Add to Course" OnClick="bSubmitStudent_Click" />
    </div>
    <br />
    <br />
    <div>            
        <asp:Table runat="server" ID="tblStudent" style="margin-left:15px;" CssClass="table table-bordered">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell CssClass="col-md-3"><a href="AddStudent.aspx?sort=id" >ID</a></asp:TableHeaderCell>
                <asp:TableHeaderCell CssClass="col-md-6"><a href="AddStudent.aspx?sort=name" >Name</a></asp:TableHeaderCell>
                <asp:TableHeaderCell CssClass="col-md-3"><a href="AddStudent.aspx?sort=grade" >Grade</a></asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>
    </div>
</asp:Content>
