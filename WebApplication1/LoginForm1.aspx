<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginForm1.aspx.cs" Inherits="WebApplication1.LoginForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="User ID"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtUserID" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="BtnLogin_Click" />
                    </td>
                    <td colspan="2">
                        <asp:Button ID="btnNewReg" runat="server" Text="New Registration" OnClick="BtnNewReg_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <asp:Label ID="lblMessage" runat="server" ForeColor="DarkRed" Font-Bold="true" ></asp:Label>
    </form>
</body>
</html>
