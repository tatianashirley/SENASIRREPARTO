<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmRepRMCC01.aspx.cs" Inherits="EnvioAPS_wfrmRepRMCC01" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div style="vertical-align: top; left: auto; height: auto; overflow: auto; width: 1200px;">
    <asp:Label ID="Label1" runat="server" Text="REPORTE RMCC01" CssClass="etiqueta20" ></asp:Label>
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="1012px">
    </rsweb:ReportViewer>
</div>
<asp:ImageButton ID="imgVolver" runat="server"  ImageUrl="~/Imagenes/32Volver.png" ToolTip="Volver a la Página anterior" OnClick="btnVolver_Click" /> 
<asp:Label ID="lblTVolver" CssClass="etiqueta8Blue" runat="server" Text="Volver" /> 
</asp:Content>

