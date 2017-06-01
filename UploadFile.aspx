<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UploadFile.aspx.cs" Inherits="CreateFolder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <a>文件：</a>
        <input type="file" id="file1" runat="server" />
        <br />
        <asp:Button ID="Button1" runat="server" Text="上传" OnClick="Button1_Click" />
    </div>
    </form>
</body>
</html>
