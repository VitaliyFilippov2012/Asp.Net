<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default_first.aspx.cs" Inherits="Lab3.Default_first" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        input, textarea, select {
            left: 240px;
            position: absolute;
        }

        #Radio2 { left: 260px; }

        #Select { width: 160px; }
    </style>
</head>
<body>
<form id="form1" runat="server">
    <div>
        <p>
            Элемент HTMLInputReset
            <input id="ResetButton" type="reset" value="Reset" runat="server"/>
        </p>

        <p>
            Элемент HtmlInputButton
            <input id="Button" onserverclick="Button_ServerClick" type="button" value="Button" runat="server"/>
        </p>

        <p>
            Элемент HtmlInputSubmit
            <input id="SubmitButton" onserverclick="SubmitButton_ServerClick" type="submit" value="Submit" runat="server"/>
        </p>

        <p>
            Элемент HtmlInputFile
            <input type="file" runat="server"/>
        </p>

        <p>
            Элемент HtmlInputText
            <input id="InputText" onserverchange="InputText_ServerChange" type="text" runat="server"/>
        </p>

        <p>
            Элемент HtmlInputPassword
            <input id="InputPassword" type="password" runat="server"/>
        </p>

        <p>
            Элемент HtmlInputCheckbox
            <input id="CheckBox" onserverchange="CheckBox_ServerChange" type="checkbox" runat="server"/>
        </p>

        <p>
            Элемент HtmlInputRadioButton
            <input id="Radio1" onserverchange="Radio1_ServerChange" type="radio" runat="server"/>
            <input id="Radio2" onserverchange="Radio2_ServerChange" type="radio" runat="server"/>
        </p>

        <p>
            Элемент HtmlTextArea
            <textarea id="TextArea" onserverchange="TextArea_ServerChange" runat="server" />
        </p>

        <p>
            Элемент HtmlSelect
            <select id="Select" onserverchange="Select_ServerChange" runat="server"/>
        </p>
    </div>
</form>
</body>
</html>