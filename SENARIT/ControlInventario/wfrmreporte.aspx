<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmreporte.aspx.cs" Inherits="ControlInventario_reporte" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register assembly="System.Web, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="System.Web.UI" tagprefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <!--PLANTILLA -->
        <div aligin="center">
        <asp:Panel ID="panReporte" runat="server" CssClass="panelceleste"  HorizontalAlign="Center" style="overflow-y:scroll;" Height="750px" Width="1000px" Visible="true">
        <rsweb:ReportViewer ID="rtpInforme" runat="server" Width="1000px"  Height="750px" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Visible="true">
        </rsweb:ReportViewer>
        </asp:Panel>
        </div>
     <!------------->
</asp:Content>