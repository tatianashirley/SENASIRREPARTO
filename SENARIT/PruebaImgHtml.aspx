<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PruebaImgHtml.aspx.cs" Inherits="PruebaImgHtml" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form2" runat="server">
    <div>
        <asp:TextBox ID="txtWebsiteAddress" runat="server" Text="www.google.com" />
        <asp:Button ID="btnCreateThumbnailImage" runat="server" Text="Create Thumbnail Image" OnClick="CreateThumbnailImage" /></td>
        <asp:TextBox ID="txtWidth" runat="server" Text="200" />
        <asp:TextBox ID="txtHeight" runat="server" Text="200" />
        <asp:Image ID="imgThumbnailImage" runat="server" Visible="false" />
    </div>
    </form>
</body>

</html>






 


