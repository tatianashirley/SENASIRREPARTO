<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="pruebaDatosNotificaciones.aspx.cs" Inherits="Notificaciones_pruebaDatosNotificaciones" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    IdTramite:
    <asp:TextBox ID="txtIdtramite" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; IdGrupoBeneficio:
    <asp:TextBox ID="txtIdgrupobeneficio" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="btnEnviar" runat="server" OnClick="btnEnviar_Click" Text="Notificar" />

    <asp:Button ID="btnEmision" runat="server" OnClick="btnEmisionP" Text="Emision" />

    <asp:Button ID="btnObservados" runat="server" OnClick="Observados" Text="Obs" />

        <asp:Button ID="btnRegistroDocumentos" runat="server" OnClick="RegDocumentos" Text="Notificacion JS" />
        </asp:Content>

