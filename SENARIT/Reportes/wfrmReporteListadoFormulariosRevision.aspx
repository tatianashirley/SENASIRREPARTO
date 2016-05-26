<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="wfrmReporteListadoFormulariosRevision.aspx.cs" Inherits="Reportes_wfrmReporteListadoFormulariosRevision" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div align="center" style="background:#fff"> 
   
        <rsweb:ReportViewer ID="rptListado" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" AsyncRendering="False" SizeToReportContent="True" >
<%--            <LocalReport ReportPath="Reportes\rptDetalleTramitePersona.rdlc" >
            </LocalReport>--%>
        </rsweb:ReportViewer>
        <br />
         </div>
    </asp:Content>
