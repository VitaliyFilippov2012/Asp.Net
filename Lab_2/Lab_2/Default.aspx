<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Lab_2.Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www/w3/org/1999/xhtml">

<html xmlns="http://www/w3/org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<form id="form1"  runat="server">
    <div>
        <asp:Button ID="Button1" runat="server" OnClick="OnButtonClickGet" Text="Get" />
        <asp:Button ID="Button2" runat="server" OnClick="OnButtonClickOpt" Text="Options" />
        <asp:Button ID="Button3" runat="server" OnClick="OnButtonClickPost" Text="Post" />
        <br/>
        <br/>
        <asp:Label ID="Label" runat="server"></asp:Label>
    </div>
</form>
</body>
</html>