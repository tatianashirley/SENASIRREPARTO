<%@ Page Language="C#"  AutoEventWireup="true" CodeFile="wfrmReporteProcedimientoAutomatico.aspx.cs" Inherits="CertificacionCC_wfrmReporteProcedimientoAutomatico" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div align="center" style="background:#fff"> 
   
        <rsweb:reportviewer ID="rptFormularioAutomatico" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" AsyncRendering="False" SizeToReportContent="True" Width="100%" >
        </rsweb:reportviewer>
        <br />
         </div>
    </form>
</body>
</html>