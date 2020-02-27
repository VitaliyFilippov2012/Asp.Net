<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Lab_1._Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www/w3/org/1999/xhtml">

<html xmlns="http://www/w3/org/1999/xhtml">
    <head runat="server">
        <title></title>
    </head>
<body>
<form id="form1"  runat="server">
<div>
    <asp:Button ID="Button1" runat="server" OnClick="OnButtonClickSave" Text="Save" />
    <asp:Button ID="Button2" runat="server" OnClick="OnButtonClickRestore" Text="Restore" />
    <asp:Button ID="Button3" runat="server" OnClick="OnButtonClickClear" Text="Clear" />
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:DropDownList ID="DropDownList1" runat="server">
    </asp:DropDownList>
    <asp:Label ID="Label1" runat="server" Text="Text"></asp:Label>
    <br />
    <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" Text="Тискани ка меня, дружочак" OnCheckedChanged="CheckBox1_CheckedChanged"/>
    <br />
    <asp:Label ID="Label2" runat="server"></asp:Label>
</div>
</form>
</body>
</html>
