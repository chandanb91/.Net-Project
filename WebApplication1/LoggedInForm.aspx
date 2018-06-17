<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoggedInForm.aspx.cs" Inherits="WebApplication1.LoggedInForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <p>
            <asp:Label ID="lblName" runat="server" ></asp:Label>
            <br />
            <asp:Label ID="lblReg" runat="server" ></asp:Label>
        </p>
        <div>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/CourseRegistration.aspx">Course Registration</asp:HyperLink>
            <br />
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/ViewCoursesRegistered.aspx">View Courses Registered</asp:HyperLink>
            <br />
            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/LoginForm1.aspx">Logout</asp:HyperLink>
        </div>
    </form>
</body>
</html>
