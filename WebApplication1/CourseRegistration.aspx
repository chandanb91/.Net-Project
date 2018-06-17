<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CourseRegistration.aspx.cs" Inherits="WebApplication1.CourseRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:Label ID="lblUserName" runat="server"></asp:Label>
            <br />
            <br />

        </div>
        <asp:Label ID="lblRegID" runat="server" Text="Registration ID"></asp:Label>
&nbsp;
        <asp:Label ID="lblRegIDValue" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Course Name"></asp:Label>

        &nbsp;

        <asp:DropDownList ID="ddlCourseName" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="COURSE_NAME" DataValueField="COURSE_CD" OnSelectedIndexChanged="ddlCourseName_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
        <asp:Label ID="lblDuration" runat="server" Text="Duration"></asp:Label>
&nbsp;
        <asp:DropDownList ID="ddlDuration" runat="server" DataTextField="DURATION" DataValueField="COURSE_CD">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="BtnSubmit" runat="server" Text="Submit" OnClick="BtnSubmit_Click" />
        <asp:Button ID="BtnBack" runat="server" Text="Back" OnClick="BtnBack_Click" />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCS %>" SelectCommand="SELECT * FROM [COURSE_MASTER]"></asp:SqlDataSource>
        <br />
        <br />
        <asp:Label ID="lblMessage" runat="server" ForeColor="DarkGreen" Font-Bold="true"></asp:Label>
    </form>
</body>
</html>
