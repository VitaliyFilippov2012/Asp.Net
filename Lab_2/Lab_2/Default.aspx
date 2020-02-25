<%@ Page Title="Home Page" Async="true"  Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Lab_2.Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www/w3/org/1999/xhtml">

<html xmlns="http://www/w3/org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<form id="form1"  runat="server">
    <div>
        <asp:Button ID="GetButton" runat="server" OnClick="OnButtonClickGet" Text="Get" />
        <asp:Button ID="PostButton" runat="server" OnClick="OnButtonClickPost" Text="Post" />
        <asp:Button ID="PutButton" runat="server" OnClick="OnButtonClickPut" Text="Put" />
        <asp:Button ID="HeadButton" runat="server" OnClick="OnButtonClickHead" Text="Head"/>
        <br/>
        <div>
            <a href="Math.aspx">Math page</a>
            <p>
                Элемент HtmlInputText
                <input id="InputText"  type="text" runat="server" />
            </p>
            <p>
                CheckBox
                <input id="CheckBox" type="checkbox" runat="server" />
            </p>
            <p>
                Элемент HtmlInputRadioButton
                <input id="Radio1" type="radio" runat="server" />
                <input id="Radio2" type="radio" runat="server" />
            </p> 
            <p>
                Элемент HtmlInputSubmit
                <input id="SubmitButton" type="submit" value="Submit" runat="server" />
            </p>

            <br />
            <br />
            <br />
            <br />
            <asp:Label runat="server" ID="LabelResult" />
        </div>
        <br/>
        <asp:Label ID="Label" runat="server"></asp:Label>
    </div>
</form>
</body>
</html>