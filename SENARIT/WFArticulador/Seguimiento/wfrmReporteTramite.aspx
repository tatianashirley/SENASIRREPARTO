<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" 
    AutoEventWireup="true" 
    CodeFile="wfrmReporteTramite.aspx.cs" 
    Inherits="Reportes_wfrmReporteTramite" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div style="vertical-align: top; left: auto; height: auto; overflow: auto; width: 1200px;">
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="1012px">
    </rsweb:ReportViewer>
</div>
<asp:Button ID="btnVolver" runat="server" Text="Volver" OnClick="btnVolver_Click" />
</asp:Content>


