<%@ page title="" language="C#" masterpagefile="~/ACMasterPage.Master" autoeventwireup="true" codefile="BookOrders.aspx.cs" inherits="BookOrders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" type="text/css" href="/App_Themes/SiteStyles.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server"> 
    <div class="row vertical-margin">
        <div class="col-md-10 col-md-offset-1">
        <h3>You have ordered the following book(s):</h3>
        </div>
    </div>
    <div class="row vertical-margin">
         <div class="col-md-10 col-md-offset-1">
            <asp:Table runat="server" ID="tblCourses" CssClass="table">
            <asp:TableRow>
                <asp:TableHeaderCell>Code</asp:TableHeaderCell>
                <asp:TableHeaderCell>Title</asp:TableHeaderCell>
                <asp:TableHeaderCell>&nbsp;</asp:TableHeaderCell>
            </asp:TableRow>
            </asp:Table>
        </div>
     </div>
    <asp:Panel runat="server" ID="pnlDescription" Visible ="false">
        <div class="row vertical-margin">
            <div class="col-md-10 col-md-offset-1">
               <h3><asp:Label runat="server" ID="lblTitle"></asp:Label></h3>
            </div>
        </div>
        <div class="row vertical-margin">
            <div class="col-md-10 col-md-offset-1">
                <asp:Label runat="server" ID="lblDescription"></asp:Label>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" Runat="Server">
    <script>
        $(document).ready(function () {
            $(".deleteBookOrder").on('click', function () {
                if (!confirm("The selected book will be deleted from your orders!")) {
                    return false;
                }
            });
        });
    </script>
</asp:Content>

