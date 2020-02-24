<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Math.aspx.cs" Inherits="Lab_2.Math" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script>
        function sendRequest() {
            var xmlHttp = new XMLHttpRequest();
            var x = document.getElementById("XTextBox").value;
            var y = document.getElementById("YTextBox").value;
            var resultTextBox = document.getElementById("ResultTextBox");
            var postData = "x=" + x + "&y=" + y;

            xmlHttp.onreadystatechange = function () {
                if (xmlHttp.readyState == 4 && xmlHttp.status == 200) {
                    resultTextBox.value = xmlHttp.responseText;
                }
            }

            xmlHttp.open("POST", "http://localhost:55444/sum.math", true);
            xmlHttp.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
            xmlHttp.setRequestHeader("Content-length", postData.length);
            xmlHttp.send(postData);
        }
    </script>
</head>
<body>
<form id="form1" runat="server">
    <div>
        <asp:TextBox runat="server" TextMode="Number" ID="XTextBox" />
        +
        <asp:TextBox runat="server" TextMode="Number" ID="YTextBox" />
        =
        <asp:TextBox runat="server" ID="ResultTextBox" />
        <br />
        <br />
        <button type="button" onclick="sendRequest()">Sum</button>
    </div>
</form>
</body>
</html>