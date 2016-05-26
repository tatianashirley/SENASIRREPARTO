<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmReporteFormularioRevision.aspx.cs" Inherits="Reportes_wfrmReporteFormularioRevision" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div align="center" style="background:#fff"> 
   
        <rsweb:ReportViewer ID="rptFormularioRevision" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" AsyncRendering="False" SizeToReportContent="True" >
<%--            <LocalReport ReportPath="Reportes\rptDetalleTramitePersona.rdlc" >
            </LocalReport>--%>
        </rsweb:ReportViewer>
        <br />
         </div>

    </asp:Content>