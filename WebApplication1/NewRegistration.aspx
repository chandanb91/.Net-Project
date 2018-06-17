<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewRegistration.aspx.cs" Inherits="WebApplication1.NewRegistration" %>

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
                    <td class="auto-style1">
                        <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="NameValidator" runat="server"
                          ControlToValidate="txtName"
                          ValidationExpression="^[a-zA-Z'.\s]{1,50}" 
                          ErrorMessage="No Numbers or Special Characters Allowed">
                        </asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="DOB"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtDOB" runat="server"></asp:TextBox>
                        <asp:ImageButton ID="CalendarImageButton" runat="server" Height="24px" ImageUrl="~/Images/Calendar-icon.png" Width="23px" OnClick="CalendarImageButton_Click" />
                        <asp:Calendar ID="calDOB" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" OnSelectionChanged="calDOB_SelectionChanged" Width="220px" OnDayRender="calDOB_DayRender">
                            <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                            <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                            <OtherMonthDayStyle ForeColor="#999999" />
                            <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                            <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                            <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                            <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                            <WeekendDayStyle BackColor="#CCCCFF" />
                        </asp:Calendar>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Gender"></asp:Label>
                    </td>
                    <td colspan="2">
                    <asp:RadioButton ID="rbtnMale" runat="server" GroupName="gender" Text="M" /><asp:RadioButton ID="rtbnFemale" runat="server" GroupName="gender" Text="F" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Mobile No."></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtMobile" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="mobileNoValidator1" runat="server" 
                         ControlToValidate="txtMobile" ErrorMessage="Please enter Valid Number"
                         ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="Address"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine"></asp:TextBox>
                        <asp:CustomValidator ID="AddressCustomValidator" runat="server" 
                          ControlToValidate="txtAddress" 
                          ErrorMessage="Special Characters not allowed" ForeColor="Red"
                          OnServerValidate="AddressCustomValidator_ServerValidate">
                        </asp:CustomValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="Email ID"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="emailIDValidator" runat="server"
                         ControlToValidate="txtEmail" ErrorMessage="Please Enter Valid Email ID" 
                         ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                        </asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label7" runat="server" Text="District Name"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:DropDownList ID="ddlDistrict" runat="server" 
                          DataTextField="District_Name" DataValueField="District_cd" 
                          OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label8" runat="server" Text="Taluk Name"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:DropDownList ID="ddlTaluk" runat="server" 
                          DataTextField="Taluk_Name" DataValueField="Taluk_cd"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                   <td>
                    </td>
                    <td colspan="2">
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                        <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <asp:Label ID="lblMessage" runat="server" ForeColor="DarkRed" Font-Bold="true"></asp:Label>
    </form>
</body>
</html>
