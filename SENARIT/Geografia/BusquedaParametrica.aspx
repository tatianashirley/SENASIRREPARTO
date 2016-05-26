<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BusquedaParametrica.aspx.cs" Inherits="BusquedaParametrica" StylesheetTheme="Modal" %>

<%@ Register namespace="AjaxControlToolkit" tagprefix="AjaxControlToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

        .auto-style1 {
            height: 23px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
    <tr>
        <td>&nbsp;</td>
        <td colspan="4">
            <asp:Label ID="Label5" runat="server" CssClass="etiqueta20" Text="Geografia Pagina 2"></asp:Label>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>
            <asp:Label ID="Label1" runat="server" CssClass="etiqueta10" Text="Departamento"></asp:Label>
        </td>
        <td>
            <asp:Label ID="Label2" runat="server" CssClass="etiqueta10" Text="Provincia"></asp:Label>
        </td>
        <td>
            <asp:Label ID="Label3" runat="server" CssClass="etiqueta10" Text="Seccion"></asp:Label>
        </td>
        <td>
            <asp:Label ID="Label4" runat="server" CssClass="etiqueta10" Text="Localidad"></asp:Label>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style1"></td>
        <td class="auto-style1">
            <asp:DropDownList ID="ddlDep" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDep_SelectedIndexChanged" Width="200px" CssClass="texto10">
            </asp:DropDownList>
        </td>
        <td class="auto-style1">
            <asp:DropDownList ID="ddlProv" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProv_SelectedIndexChanged" Width="200px" CssClass="texto10">
            </asp:DropDownList>
        </td>
        <td class="auto-style1">
            <asp:DropDownList ID="ddlSec" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSec_SelectedIndexChanged" Width="200px" CssClass="texto10">
            </asp:DropDownList>
        </td>
        <td class="auto-style1">
            <asp:DropDownList ID="ddlLoc" runat="server" AutoPostBack="True" Width="200px">
            </asp:DropDownList>
        </td>
        <td class="auto-style1"></td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td colspan="4">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Content>

