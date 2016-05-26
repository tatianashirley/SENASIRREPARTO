<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmEnlacesFormaPrevia.aspx.cs" Inherits="WorkFlow_wfrmEnlacesFormaPrevia" StylesheetTheme="Modal"%>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style5 {
            height: 30px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="pnlGral">
        <asp:Panel ID="pnlDatos" runat="server" CssClass="pnlBody">
            <table style="width: 100%;">
                <tr>
                    <td colspan="7" align="center">
                        <asp:ImageButton ID="imgAux" runat="server" ImageUrl="~/Imagenes/16w.png" />
                        <asp:Label ID="lblTituloAUX" runat="server" CssClass="texto12" Text="Enlaces que deben ser visitados en forma previa a la ejecución de la transición"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label1" runat="server" Text="Tipo de Trámite:"></asp:Label>
                    </td>
                    <td align="left" colspan="5">
                        <asp:TextBox ID="txtTipoTramite" runat="server" CssClass="box" Enabled="False" Width="900px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvTipoTramite" runat="server" ControlToValidate="txtTipoTramite" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                    <td align="left"></td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label2" runat="server" Text="Flujo:"></asp:Label>
                    </td>
                    <td align="left" colspan="5">
                        <asp:TextBox ID="txtFlujo" runat="server" CssClass="box" Enabled="False" Width="900px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvFlujo" runat="server" ControlToValidate="txtFlujo" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                    <td align="left">&nbsp;</td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label16" runat="server" Text="Actividad Predecesora:"></asp:Label>
                    </td>
                    <td align="left" colspan="5">
                        <asp:DropDownList ID="cboActPredecesora" runat="server" CssClass="box" Width="900px" Enabled="False">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="tfvTipoRestriccion1" runat="server" ControlToValidate="cboActPredecesora" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                    <td align="left">&nbsp;</td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label3" runat="server" Text="Actividad:"></asp:Label>
                    </td>
                    <td align="left" colspan="5">
                        <asp:DropDownList ID="cboActividad" runat="server" CssClass="box" Width="900px" Enabled="False">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="tfvActividad" runat="server" ControlToValidate="cboActividad" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                    <td align="left">&nbsp;</td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label6" runat="server" Text="Enlace:"></asp:Label>
                    </td>
                    <td align="left" style="margin-left: 40px">
                        <asp:DropDownList ID="cboEnlace" runat="server" CssClass="box" Width="900px">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="tfvEnlace" runat="server" ControlToValidate="cboEnlace" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                    <td align="right" style="margin-left: 40px">
                        &nbsp;</td>
                    <td align="left">
                        &nbsp;</td>
                    <td align="right">
                        &nbsp;</td>
                    <td align="left">
                        &nbsp;</td>
                    <td align="left">&nbsp;</td>
                </tr>
                <tr>
                    <td align="right">&nbsp;</td>
                    <td align="left" style="margin-left: 40px">&nbsp;</td>
                    <td align="right" style="margin-left: 40px">&nbsp;</td>
                    <td align="left">&nbsp;</td>
                    <td align="right">&nbsp;</td>
                    <td align="left">&nbsp;</td>
                    <td align="left">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="7" align="center">
                        <asp:ImageButton ID="imgAtras0" runat="server" AlternateText="Atrás" CausesValidation="False" ImageUrl="~/Imagenes/azulAtras.png" OnClick="imgAtras_Click" DescriptionUrl="Volver" />
                        <asp:Button ID="btnNuevo" runat="server" CausesValidation="False" CssClass="btnPrin" OnClick="btnNuevo_Click" Text="Nuevo" />
                        <asp:Button ID="btnGrabar" runat="server" CssClass="btnPrin" OnClick="btnGrabar_Click" Text="Grabar" />
                        <cc1:ConfirmButtonExtender ID="btnGrabar_ConfirmButtonExtender" runat="server" ConfirmText="¿Esta seguro de guardar/modificar el registro?" TargetControlID="btnGrabar">
                        </cc1:ConfirmButtonExtender>
                        <asp:Button ID="btnEliminar" runat="server" CssClass="btnPrin" Enabled="False" OnClick="btnEliminar_Click" Text="Eliminar" />
                        <cc1:ConfirmButtonExtender ID="btnEliminar_ConfirmButtonExtender" runat="server" ConfirmText="¿Esta seguro de eliminar el registro?" TargetControlID="btnEliminar">
                        </cc1:ConfirmButtonExtender>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5" colspan="4"></td>
                    <td class="auto-style5"></td>
                    <td class="auto-style5"></td>
                    <td class="auto-style5"></td>
                </tr>
                <tr>
                    <td colspan="7" align="center">
                        <asp:GridView ID="gvEnlacesVP" runat="server" AllowPaging="True" OnPageIndexChanging="gvEnlacesVP_PageIndexChanging" OnSelectedIndexChanged="gvEnlacesVP_SelectedIndexChanged" DataKeyNames="Secuencia">
                            <HeaderStyle CssClass="cssHeaderImg" />
                            <Columns>
                                <asp:CommandField ButtonType="Image" HeaderText="Elegir" SelectImageUrl="~/imagenes/16siguiente.png" SelectText="Seleccionar" ShowHeader="True" ShowSelectButton="True" />
                            </Columns>
                            <EmptyDataTemplate>
                                <div align="center" class="CajaDialogoAdvertencia">
                                    <br/>
                                    <img src="../Imagenes/warning.gif" 
                                        alt="No existen registros" />
                                    <br/>
                                    Bandeja de Enlaces Visitados de Forma Previa vacía.
                                    <br/>
                                    <br/>
                                </div>
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </asp:Panel>

    </div>
</asp:Content>

