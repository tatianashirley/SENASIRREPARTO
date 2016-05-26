<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmTipoTramiteRolUsuario.aspx.cs" Inherits="WorkFlow_wfrmTipoTramiteRolUsuario" StylesheetTheme="Modal" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"> 
</asp:Content>
<asp:Content ID="ContentDatos" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="pnlGral">
        <asp:Panel ID="pnlMaestro" runat="server" CssClass="pnlBody">
            <table style="width: 100%;">
            <tr>
                <td colspan="4" align="center">
                    <asp:ImageButton ID="imgAux" runat="server" ImageUrl="~/Imagenes/16w.png" />
                    <asp:Label ID="lblTituloAUX" runat="server" CssClass="texto12" Text="Usuarios Asociados al Tipo de Trámite"></asp:Label>
                </td>
            </tr>
                <tr>
                    <td align="right" colspan="4">
                        &nbsp;</td>
                </tr>
            <tr>
                <td align="right" style="width: 150px">
                    <asp:Label ID="Label1" runat="server" Text="Tipo de Trámite:"></asp:Label>
                </td>
                <td align="left" colspan="3">
                    <asp:TextBox ID="txtTipoTramite" runat="server" Enabled="False" Width="800px" CssClass="box"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvTipoTramite" runat="server" ControlToValidate="txtTipoTramite" ErrorMessage="*" ValidationGroup="maestro"></asp:RequiredFieldValidator>
                </td>
            </tr>
                <tr>
                    <td align="right" style="width: 150px">
                        <asp:Label ID="Label2" runat="server" Text="Rol:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="cboRol" runat="server" Width="310px" CssClass="box">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvRol" runat="server" ControlToValidate="cboRol" ErrorMessage="*" ValidationGroup="maestro"></asp:RequiredFieldValidator>
                    </td>
                    <td align="right">
                        <asp:Label ID="Label3" runat="server" Text="Rol Superior:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="cboRolSuperior" runat="server" Width="310px" CssClass="box">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvRolSup" runat="server" ControlToValidate="cboRolSuperior" ErrorMessage="*" ValidationGroup="maestro" InitialValue="Seleccione valor ..."></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cvRoles" runat="server" ControlToCompare="cboRolSuperior" ControlToValidate="cboRol" ErrorMessage="Los roles deben ser diferentes" ValidationGroup="maestro" Operator="NotEqual"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 150px">
                        <asp:Label ID="Label12" runat="server" Text="Único:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:CheckBox ID="chkUnico" runat="server" />
                    </td>
                    <td align="right">&nbsp;</td>
                    <td align="left">&nbsp;</td>
                </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
                <tr>
                    <td colspan="4" align="center" style="bottom: auto">
                        <asp:ImageButton ID="imgAtras" runat="server" AlternateText="Atrás" DescriptionUrl="Volver" ImageUrl="~/Imagenes/azulAtras.png" OnClick="imgAtras_Click" />
                        <asp:Button ID="btnNuevo" runat="server" CausesValidation="False" CssClass="btnPrin" OnClick="btnNuevo_Click" Text="Nuevo" ValidationGroup="maestro" />
                        <asp:Button ID="btnGuardar" runat="server" CssClass="btnPrin" OnClick="btnGuardar_Click" Text="Grabar" ValidationGroup="maestro" />
                        <cc1:ConfirmButtonExtender ID="btnGuardar_ConfirmButtonExtender" runat="server" TargetControlID="btnGuardar" ConfirmText="¿Esta seguro de guardar/modificar el registro?">
                        </cc1:ConfirmButtonExtender>
                        <asp:Button ID="btnEliminar" runat="server" CssClass="btnPrin" Enabled="False" OnClick="btnEliminar_Click" Text="Eliminar" ValidationGroup="maestro" />
                        <cc1:ConfirmButtonExtender ID="btnEliminar_ConfirmButtonExtender" runat="server" TargetControlID="btnEliminar" ConfirmText="¿Esta seguro de eliminar el registro?">
                        </cc1:ConfirmButtonExtender>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="4" align="center">                        
                        <asp:GridView ID="gvTipoTramRol" runat="server" AllowPaging="True" OnPageIndexChanging="gvTipoTramRol_PageIndexChanging" OnSelectedIndexChanged="gvTipoTramRol_SelectedIndexChanged" AutoGenerateColumns="False" DataKeyNames="IdRol">
                            <Columns>
                                <asp:CommandField ButtonType="Image" HeaderText="Elegir" SelectImageUrl="~/imagenes/16siguiente.png" SelectText="Seleccionar" ShowHeader="True" ShowSelectButton="True" />
                                <asp:BoundField DataField="IdRol" HeaderText="IdRol" />
                                <asp:BoundField DataField="DescripcionRol" HeaderText="Rol" />
                                <asp:BoundField DataField="IdRolSup" HeaderText="IdRolSup" />
                                <asp:BoundField DataField="DescripcionRolSup" HeaderText="Rol Superior" />
                                <asp:BoundField DataField="Nivel" HeaderText="Nivel" />
                                <asp:CheckBoxField DataField="FlagUnico" HeaderText="Flag Unico" SortExpression="FlagUnico" />
                            </Columns>
                            <HeaderStyle CssClass="cssHeaderImg" />
                            <EmptyDataTemplate>
                                <div align="center" class="CajaDialogoAdvertencia">
                                    <br/>
                                    <img src="../Imagenes/warning.gif" 
                                        alt="No existen registros." />
                                    <br/>
                                    Bandeja Roles asociados al Tipo Trámite vacía.
                                    <br/>
                                    <br/>
                                </div>
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
        </table>
        </asp:Panel>
    </div>
    <div class="pnlGral">        
         <asp:Panel ID="pnlDetalle" runat="server" CssClass="pnlPest" Visible="false">                         
            <table style="width: 100%;">
            <tr>
                <td colspan="4" align="center">
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Imagenes/16w.png" />
                    <asp:Label ID="Label6" runat="server" CssClass="texto12" Text="Usuarios con el Rol Asociados al Tipo de Trámite"></asp:Label>
                </td>
            </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td align="right" width="150" style="width: 150px">
                        <asp:Label ID="Label10" runat="server" Text="Usuario:"></asp:Label>
                    </td>
                    <td align="left" colspan="3">
                        <asp:DropDownList ID="cboUsuario" runat="server" Width="800px" CssClass="box">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" ControlToValidate="cboUsuario" ErrorMessage="*" ValidationGroup="detalle"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" width="150" style="width: 150px">
                        <asp:Label ID="Label11" runat="server" Text="Usuario Superior:"></asp:Label>
                    </td>
                    <td align="left" colspan="3">
                        <asp:DropDownList ID="cboUsuarioSup" runat="server" Width="800px" CssClass="box">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvÙsuarioSup" runat="server" ControlToValidate="cboUsuarioSup" ErrorMessage="*" ValidationGroup="detalle" InitialValue="Seleccione valor ..."></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cvUsuarios" runat="server" ControlToCompare="cboUsuarioSup" ControlToValidate="cboUsuario" ErrorMessage="Los usuarios deben ser diferentes" Operator="NotEqual" ValidationGroup="detalle"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" width="150" style="width: 150px">&nbsp;</td>
                    <td align="left" colspan="3">&nbsp;</td>
                </tr>
                <tr>
                    <td align="center" colspan="4">
                        <asp:Button ID="btnNuevoDet" runat="server" CausesValidation="False" CssClass="btnPrin" OnClick="btnNuevoDet_Click" Text="Nuevo" />
                        <asp:Button ID="btnGrabarDet" runat="server" CssClass="btnPrin" OnClick="btnGrabarDet_Click" Text="Grabar" ValidationGroup="detalle" Width="49px" />
                        <cc1:ConfirmButtonExtender ID="btnGrabarDet_ConfirmButtonExtender" runat="server" TargetControlID="btnGrabarDet" ConfirmText="¿Esta seguro de guardar/modificar el registro?">
                        </cc1:ConfirmButtonExtender>
                        <asp:Button ID="btnEliminarDet" runat="server" CssClass="btnPrin" Enabled="False" OnClick="btnEliminarDet_Click" Text="Eliminar" ValidationGroup="detalle" />
                        <cc1:ConfirmButtonExtender ID="btnEliminarDet_ConfirmButtonExtender" runat="server" TargetControlID="btnEliminarDet" ConfirmText="¿Esta seguro de eliminar el registro?">
                        </cc1:ConfirmButtonExtender>
                    </td>
                </tr>
                <tr>
                    <td align="right">&nbsp;</td>
                    <td align="left" colspan="3">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="4" align="center">
                        <br />
                        <asp:GridView ID="gvTipoTramUsuaRol" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="IdUsuario" OnPageIndexChanging="gvTipoTramUsuaRol_PageIndexChanging" OnSelectedIndexChanged="gvTipoTramUsuaRol_SelectedIndexChanged">
                            <Columns>
                                <asp:CommandField ButtonType="Image" HeaderText="Elegir" SelectImageUrl="~/imagenes/16siguiente.png" SelectText="Seleccionar" ShowHeader="True" ShowSelectButton="True" />
                                <asp:BoundField DataField="IdUsuario" HeaderText="IdUsuario" />
                                <asp:BoundField DataField="CuentaUsuario" HeaderText="Cuenta Usuario" />
                                <asp:BoundField DataField="IdUsuarioSuperior" HeaderText="IdUsuarioSuperior" />
                                <asp:BoundField DataField="CuentaUsuarioSuperior" HeaderText="Cuenta Usuario Superior" />
                                <asp:BoundField DataField="Estado" HeaderText="Estado" />
                            </Columns>
                            <HeaderStyle CssClass="cssHeaderImg" />
                            <EmptyDataTemplate>
                                <div align="center" class="CajaDialogoAdvertencia">
                                    <br/>
                                    <img src="../Imagenes/warning.gif" 
                                        alt="No existen registros." />
                                    <br/>
                                    Bandeja Roles Usuarios asociados al Tipo de Trámite vacía.
                                    <br/>
                                    <br/>
                                </div>
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">&nbsp;</td>
                </tr>
        </table>
        </asp:Panel>
    </div>
</asp:Content>

