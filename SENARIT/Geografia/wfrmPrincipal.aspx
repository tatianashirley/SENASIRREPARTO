<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmPrincipal.aspx.cs" Inherits="wfrmPrincipal" StylesheetTheme ="Modal" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

        <script type="text/javascript" languaje ="javascript">
                function ModalPopup() {
                    var vpRND = Math.random() * 20;
                    showModalDialog('\Auxiliar\\AcercaDe.aspx?rn=' + vpRND, '', 'dialogWidth=640px; dialogHeight=240px; center=yes; scrollbars=no');
                }
        </script>

        <style type="text/css">
            .auto-style5 {
                height: 25px;
            }
            </style>

    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table style="width:100%;">
        <tr>
            <td align="center" width="100%" class="auto-style5">
                <asp:Label ID="lblTituloAUX" runat="server" 
                    Text="Principal Modulo SEGURIDAD" CssClass="etiqueta20"></asp:Label>
                <asp:Label ID="lblCodigo" runat="server" Font-Size="Small" Text="1" 
                    Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Panel ID="pnlPrincipal" runat="server" CssClass="panelprincipal" 
                    HorizontalAlign="Center" Width="100%">
                    <table style="width:100%;">
                        <tr>
                            <td valign="top" width="16%">
                                <asp:Panel ID="pnl1" runat="server">
                                    <table style="width:100%;">
                                        <tr>
                                            <td width="17%">
                                                <asp:ImageButton ID="imgFormularios" runat="server" Enabled="False" ImageUrl="~/Imagenes/menu/AcercaDe.png" style="height: 48px" />
                                                <br />
                                                <asp:LinkButton ID="lnkAcercaDe" runat="server" CssClass="link" Font-Size="Small" onclick="lnkAcercaDe_Click">AcercaDe</asp:LinkButton>
                                                <br />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                            <td valign="top">
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/Banners/GeografiaLOGO.png" />
                            </td>
                            <td valign="top" width="16%">
                                <asp:Panel ID="pnl2" runat="server">
                                    <table style="width: 100%;">
                                        <tr>
                                            <td width="17%">
                                                <asp:ImageButton ID="imgEntidades" runat="server" Enabled="False" ImageUrl="~/Imagenes/menu/Roles.png" />
                                                <br />
                                                <asp:HyperLink ID="hRoles" runat="server" CssClass="link" Font-Size="Small">Manual de Usuario</asp:HyperLink>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <br />
                                <asp:Label ID="lbl2" runat="server" Font-Size="XX-Small" Text="v DEMO SEGURIDAD 1.0"></asp:Label>
                                <br />
                                <asp:Label ID="lblModulo" runat="server" Font-Size="Small" style="text-align: left" Text="0" Visible="False"></asp:Label>
                                <asp:Label ID="lblCodUsuario" runat="server" Font-Size="Small" Text="0" Visible="False"></asp:Label>
                                <asp:Label ID="lblRol" runat="server" Font-Size="Small" style="text-align: left" Text="0" Visible="False"></asp:Label>
                                <br />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
    </table>

</asp:Content>

