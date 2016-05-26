<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="parametrosdatosasegurados.aspx.cs" Inherits="CertificacionCC_parametrosdatosasegurados" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:Label ID="Label1" runat="server" Text="IdTramite" ></asp:Label>
    :
    <asp:TextBox ID="txtIdtramite" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; IdGrupoBeneficio:
    <asp:TextBox ID="txtIdgrupobeneficio" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="btnEnviar" runat="server" OnClick="btnEnviar_Click" Text="Demo Emision" />

    <asp:Button ID="brnEnviarValidoManual" runat="server" OnClick="btnEnviar2_Click" Text="Demo Valido Manual" />

    <asp:Button ID="btnEmisionManual" runat="server"  Text="Demo Emision Manual" OnClick="btnEmisionManual_Click" />

    <asp:Button ID="btnProcedimientoManual" runat="server"  Text="ProcedimientoManual" OnClick="btnProcedimientoManual_Click" />

    <asp:Button ID="btnProcedimientoManual0" runat="server"  Text="ProcedimientoManual_Rev_CC" OnClick="btnProcedimientoManual0_Click" />

    </asp:Content>

