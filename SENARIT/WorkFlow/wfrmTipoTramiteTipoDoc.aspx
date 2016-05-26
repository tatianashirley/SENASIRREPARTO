<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmTipoTramiteTipoDoc.aspx.cs" Inherits="WorkFlow_wfrmTipoTramiteTipoDoc" StylesheetTheme="Modal"%>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="pnlGral">
        <asp:Panel ID="pnlDatos" runat="server" CssClass="pnlBody">
            <table style="width: 100%;">
                <tr>
                    <td align="center" colspan="5">
                        <asp:ImageButton ID="imgAux" runat="server" ImageUrl="~/Imagenes/16w.png" />
                        <asp:Label ID="lblTituloAUX" runat="server" CssClass="texto12" Text="Tipo de Documento Asociado al Tipo Trámite"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" width="150">
                        <asp:Label ID="Label1" runat="server" Text="Tipo Trámite:"></asp:Label>
                    </td>
                    <td align="left" colspan="3">
                        <asp:TextBox ID="txtTipoTramite" runat="server" CssClass="box" Width="800px" Enabled="False"></asp:TextBox>
                        </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td align="right" width="150">
                        <asp:Label ID="Label2" runat="server" Text="Tipo Documento:"></asp:Label>
                    </td>
                    <td align="left" colspan="3">
                        <asp:DropDownList ID="cboTipoDocumento" runat="server" CssClass="box" Width="800px">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvTipoDoc" runat="server" ControlToValidate="cboTipoDocumento" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td align="right" width="150">
                        <asp:Label ID="Label3" runat="server" Text="Comentarios:"></asp:Label>
                    </td>
                    <td align="left" colspan="3">
                        <asp:TextBox ID="txtComentarios" runat="server" CssClass="box" Width="800px" MaxLength="500"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td align="right" width="150">
                        <asp:Label ID="Label4" runat="server" Text="Orden:"></asp:Label>
                    </td>
                    <td align="left" width="200">
                        <asp:CheckBox ID="chkRegSolicitud" runat="server" Text="Se registra en la solicitud" />
                    </td>
                    <td align="left" width="200">
                        <asp:CheckBox ID="chkCaracterObli" runat="server" Text="Es de carácter obligatorio" />
                    </td>
                    <td align="left">
                        <asp:CheckBox ID="chkRegVarDocMismoTiempo" runat="server" Text="Puede registrarse varios documentos al mismo tiempo" />
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td align="right" width="150">&nbsp;</td>
                    <td align="left">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td align="center" colspan="5">
                        <asp:ImageButton ID="imgAtras0" runat="server" AlternateText="Atrás" CausesValidation="False" DescriptionUrl="Volver" ImageUrl="~/Imagenes/azulAtras.png" OnClick="imgAtras_Click" />
                        <asp:Button ID="btnNuevo" runat="server" CausesValidation="False" CssClass="btnPrin" OnClick="btnNuevo_Click" Text="Nuevo" />
                        <asp:Button ID="btnGrabar" runat="server" CssClass="btnPrin" OnClick="btnGrabar_Click" Text="Grabar" />
                        <cc1:ConfirmButtonExtender ID="btnGrabar_ConfirmButtonExtender" runat="server" TargetControlID="btnGrabar" ConfirmText="¿Esta seguro de guardar/modificar el registro?">
                        </cc1:ConfirmButtonExtender>
                        <asp:Button ID="btnEliminar" runat="server" CssClass="btnPrin" Enabled="False" OnClick="btnEliminar_Click" Text="Eliminar" />
                        <cc1:ConfirmButtonExtender ID="btnEliminar_ConfirmButtonExtender" runat="server" TargetControlID="btnEliminar" ConfirmText="¿Esta seguro de eliminar el registro?">
                        </cc1:ConfirmButtonExtender>
                    </td>
                </tr>
                <tr>
                    <td align="right" colspan="4">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td align="center" colspan="5">
                        <asp:GridView ID="gvTipTramTipDoc" runat="server" AllowPaging="True" OnPageIndexChanging="gvTipTramTipDoc_PageIndexChanging" OnSelectedIndexChanged="gvTipTramTipDoc_SelectedIndexChanged" BorderColor="#DADADA" DataKeyNames="IdTipoDocumento" Width="1130px">
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
                                    Bandeja de Tipos de Documentos Asociados al Tipo de Trámite vacía.
                                    <br/>
                                    <br/>
                                </div>
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td align="right" width="150">&nbsp;</td>
                    <td align="left">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
    </div>
</asp:Content>

