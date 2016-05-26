<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CS.aspx.cs" Inherits="CS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body
        {
            font-family: Arial;
            font-size: 10pt;
        }
        table
        {
            border: 1px solid #ccc;
            border-collapse: collapse;
            background-color: #fff;
        }
        table th
        {
            background-color: #B8DBFD;
            color: #333;
            font-weight: bold;
        }
        table th, table td
        {
            padding: 5px;
            border: 1px solid #ccc;
        }
        table, table table td
        {
            border: 0px solid #ccc;
        }
    </style>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="http://cdn.rawgit.com/niklasvh/html2canvas/master/dist/html2canvas.min.js"></script>
    <script type="text/javascript">
        function ConvertToImage() {
            html2canvas($("#dvTable")[0]).then(function (canvas) {
                var base64 = canvas.toDataURL();
                $("[id*=hfImageData]").val(base64);
                __doPostBack(btnExport.name, "");
            });
            return false;
        }
    </script>
</head>
<body onload="ConvertToImage(this)">
    <form id="form1" runat="server">
    <div id="dvTable" style = "width:489px; background-color:White;padding:5px; text-align:justify">
       
           <p align="justify">fdfdf dfjkds jfdkljf  jklj jk;kj jkkjk dfsfsd jdsfds jfdsfsdf fdsfd fdfd fdsfsd fdsfd sdf fd fdfdf dfjkds jfdkljf  jklj jk;kj jkkjk dfsfsd jdsfds jfdsfsdf fdsfd fdfd fdsfsd fdsfd sdf fd fdfdf dfjkds jfdkljf  jklj jk;kj jkkjk dfsfsd jdsfds jfdsfsdf fdsfd fdfd fdsfsd fdsfd sdf fdv fdfdf dfjkds jfdkljf  jklj jk;kj jkkjk dfsfsd jdsfds jfdsfsdf fdsfd fdfd fdsfsd fdsfd sdf fd fdfdf dfjkds jfdkljf  jklj jk;kj jkkjk dfsfsd jdsfds jfdsfsdf fdsfd fdfd fdsfsd fdsfd sdf fd</p>
       
    </div>
    <br />
    <asp:HiddenField ID="hfImageData" runat="server" />
    <asp:Button ID="btnExport" Text="Export to Image" runat="server" UseSubmitBehavior="false"
        OnClick="ExportToImage" OnClientClick="return ConvertToImage(this)" />
    
    </form>
</body>
</html>
