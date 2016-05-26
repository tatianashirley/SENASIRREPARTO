<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" 
    AutoEventWireup="true" 
    CodeFile="wfrmReporteFormulario430.aspx.cs" 
    Inherits="Reportes_wfrmReporteFormulario430" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div align="center" style="background:#fff"> 
   
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" AsyncRendering="False" SizeToReportContent="True" >
<%--            <LocalReport ReportPath="Reportes\rptDetalleTramitePersona.rdlc" >
            </LocalReport>--%>
        </rsweb:ReportViewer>
        <br />
         </div>
    </asp:Content>


