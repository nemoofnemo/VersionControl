<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="testPage_test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../js/jquery-3.2.1.min.js"></script>
</head>
<body>
    <div id="div1" runat="server"></div>
    <form id="form1" runat="server">
        <div>
            <input type="file" id="file1" runat="server" />
            <p />
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
