﻿<%@ Page Language="C#"  MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmVistaDetalleDatos.aspx.cs" Inherits="Reportes_wfrmVistaDetalleDatos" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div align="center" style="background:#fff"> 
   
        <rsweb:ReportViewer ID="rptDetalleTramite" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" AsyncRendering="False" SizeToReportContent="True" >
<%--            <LocalReport ReportPath="Reportes\rptDetalleTramitePersona.rdlc" >
            </LocalReport>--%>
        </rsweb:ReportViewer>
        <br />
         </div>
    <div>
        <asp:Button runat="server" ID="btnVolver" Text="Volver" OnClick="btnVolver_Click"/>
        <asp:HiddenField ID="Tramite" runat="server" />
        <asp:HiddenField ID="Beneficio" runat="server" />
    </div>
    </asp:Content>