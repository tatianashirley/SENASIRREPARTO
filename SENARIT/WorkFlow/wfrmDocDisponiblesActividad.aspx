<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmDocDisponiblesActividad.aspx.cs" Inherits="WorkFlow_wfrmDocDisponiblesActividad"  StylesheetTheme="Modal"%>
<%@ MasterType VirtualPath="~/MasterPage.master"%>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

        .auto-style9 {
            width: 100px;
            height: 25px;
        }
        .auto-style10 {
            height: 25px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="pnlGral">
        <asp:Panel ID="pnlDatos" runat="server" CssClass="pnlBody">
            <table style="width: 100%;">
            <tr>
                <td colspan="4" align="center">
                    <asp:ImageButton ID="imgAux" runat="server" Height="16px" ImageUrl="~/Imagenes/16w.png" />
                    <asp:Label ID="lblTituloAUX" runat="server" CssClass="texto12" Text="Documentos Disponibles para su Registro en la Actividad"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 100px">
                    <asp:Label ID="Label1" runat="server" Text="Tipo Trámite:"></asp:Label>
                </td>
                <td align="left" colspan="3"><asp:TextBox ID="txtTipoTramite" runat="server" CssClass="box" Enabled="False" Width="900px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvTipoTramite" runat="server" ControlToValidate="txtTipoTramite" ErrorMessage="*" ValidationGroup="maestro"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 100px">
                    <asp:Label ID="Label2" runat="server" Text="Flujo:"></asp:Label>
                </td>
                <td align="left" colspan="3"><asp:TextBox ID="txtFlujo" runat="server" CssClass="box" Enabled="False" Width="900px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvFlujo" runat="server" ControlToValidate="txtFlujo" ErrorMessage="*" ValidationGroup="maestro"></asp:RequiredFieldValidator>
                </td>
            </tr>
                <tr>
                    <td align="right" style="width: 100px">
                        <asp:Label ID="Label12" runat="server" Text="Actividad:"></asp:Label>
                    </td>
                    <td align="left" colspan="3">
                        <asp:TextBox ID="txtActividad" runat="server" CssClass="box" Enabled="False" Width="900px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvActividad" runat="server" ControlToValidate="txtActividad" ErrorMessage="*" ValidationGroup="maestro"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="auto-style9">
                        <asp:Label ID="Label3" runat="server" Text="Tipo Documento:"></asp:Label>
                    </td>
                    <td align="left" colspan="3" class="auto-style10">
                        
                        <asp:DropDownList ID="cboTipoDoc" runat="server" CssClass="box" Width="900px">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvTipoDoc" runat="server" ControlToValidate="cboTipoDoc" ErrorMessage="*" ValidationGroup="maestro"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label13" runat="server" Text="Obligatorio:"></asp:Label>
                    </td>
                    <td align="left" style="width: 100px">
                        <asp:CheckBox ID="chkObligatorio" runat="server" />
                    </td>
                    <td align="left" style="width: 300px">
                        <asp:CheckBox ID="chkModificable" runat="server" Text="Puede ser modificado por el usuario:" TextAlign="Left" />
                    </td>
                    <td align="left">
                        <asp:CheckBox ID="chkActivo" runat="server" Text="Activo:" TextAlign="Left" />
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 100px">
                    </td>
                    <td align="left" colspan="3">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center" colspan="4">
                        <asp:ImageButton ID="imgAtras0" runat="server" AlternateText="Atrás" CausesValidation="False" ImageUrl="~/Imagenes/azulAtras.png" OnClick="imgAtras_Click" DescriptionUrl="Volver" />
                        <asp:Button ID="btnNuevo" runat="server" CausesValidation="False" CssClass="btnPrin" OnClick="btnNuevo_Click" Text="Nuevo" ValidationGroup="maestro" Width="47px" />
                        <asp:Button ID="btnGuardar" runat="server" CssClass="btnPrin" OnClick="btnGuardar_Click" Text="Guardar" ValidationGroup="maestro" />
                        <cc1:ConfirmButtonExtender ID="btnGuardar_ConfirmButtonExtender" runat="server" ConfirmText="¿Esta seguro de guardar/modificar el registro?" TargetControlID="btnGuardar">
                        </cc1:ConfirmButtonExtender>
                        <asp:Button ID="btnEliminar" runat="server" CssClass="btnPrin" Enabled="False" OnClick="btnEliminar_Click" Text="Eliminar" ValidationGroup="maestro" />
                        <cc1:ConfirmButtonExtender ID="btnEliminar_ConfirmButtonExtender" runat="server" ConfirmText="¿Esta seguro de eliminar el registro?" TargetControlID="btnEliminar" />
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 100px">&nbsp;</td>
                    <td align="left" class="auto-style9">&nbsp;</td>
                    <td align="right" style="width: 50px">&nbsp;</td>
                    <td align="left">&nbsp;</td>
                </tr>
                <tr>
                    <td align="center" colspan="4">
                        <asp:GridView ID="gvTipDoc" runat="server" AllowPaging="True" BorderColor="#DADADA" DataKeyNames="IdTipoDocumento" OnPageIndexChanging="gvTipDoc_PageIndexChanging" OnSelectedIndexChanged="gvTipDoc_SelectedIndexChanged">
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
                                    Bandeja de Documentos Disponibles para la Actividad vacía.
                                    <br/>
                                    <br/>
                                </div>
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 100px">&nbsp;</td>
                    <td align="left" class="auto-style9">&nbsp;</td>
                    <td align="right" style="width: 50px">&nbsp;</td>
                    <td align="left">&nbsp;</td>
                </tr>
        </table>    
        </asp:Panel>
        
        
    </div>
</asp:Content>

