<%@ Page Language="C#"  AutoEventWireup="true" CodeFile="wfrmReporteProcedimientoManual.aspx.cs" Inherits="CertificacionCC_wfrmReporteProcedimientoManual" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div align="center" style="background:#fff"  >    

        <rsweb:ReportViewer ID="rptFormularioManual" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" AsyncRendering="False" SizeToReportContent="True" Width="100%" >
        </rsweb:ReportViewer>
        <br />
         </div>
    </form>
</body>
</html>






