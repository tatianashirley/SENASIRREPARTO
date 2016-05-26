<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmTipoTramiteFlujo.aspx.cs" Inherits="WorkFlow_wfrmTipoTramiteFlujo" StylesheetTheme="Modal"%>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="pnlGral">
        <asp:Panel ID="pnlDatos" runat="server" CssClass="pnlBody">
            <table style="width: 100%;">
                <tr>
                    <td colspan="7" align="center">
                        <asp:ImageButton ID="imgAux" runat="server" ImageUrl="~/Imagenes/16w.png" />
                        <asp:Label ID="lblTituloAUX" runat="server" CssClass="texto12" Text="Registro de Flujo"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" width="130">
                        <asp:Label ID="Label1" runat="server" Text="Tipo de Trámite:"></asp:Label>
                    </td>
                    <td align="left" colspan="5">
                        <asp:TextBox ID="txtTipoTramite" runat="server" CssClass="box" Width="916px" Enabled="False"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvTipoTramite" runat="server" ControlToValidate="txtTipoTramite" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td align="right" width="130">
                        <asp:Label ID="Label14" runat="server" Text="ID Flujo:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtIdFlujo" runat="server" CssClass="box" Width="90px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvIdFlujo" runat="server" ControlToValidate="txtIdFlujo" ErrorMessage="*"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="ravIdFlujp" runat="server" ControlToValidate="txtIdFlujo" ErrorMessage="Fuera de rango" MaximumValue="2147483647" MinimumValue="1" Type="Integer"></asp:RangeValidator>
                    </td>
                    <td align="right">
                        <asp:Label ID="Label15" runat="server" Text="Descripción:"></asp:Label>
                    </td>
                    <td align="left" colspan="3">
                        <asp:TextBox ID="txtDescripcion" runat="server" CssClass="box" Width="560px" MaxLength="500"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvDescripcion" runat="server" ControlToValidate="txtDescripcion" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td align="right" width="130">
                        <asp:Label ID="Label3" runat="server" Text="Comentarios:"></asp:Label>
                    </td>
                    <td align="left" colspan="5">
                        <asp:TextBox ID="txtComentarios" runat="server" CssClass="box" Width="916px" MaxLength="500"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td align="right" width="130">
                        <asp:Label ID="Label4" runat="server" Text="Duración Max Días:"></asp:Label>
                    </td>
                    <td align="left" width="240">
                        <asp:TextBox ID="txtMaxDias" runat="server" Width="90px"></asp:TextBox>
                        <cc1:NumericUpDownExtender ID="txtMaxDias_NumericUpDownExtender" runat="server" TargetControlID="txtMaxDias" Minimum="1" Maximum="9999999" Width="120">
                        </cc1:NumericUpDownExtender>
                        <asp:RequiredFieldValidator ID="rfvMaxDias" runat="server" ControlToValidate="txtMaxDias" ErrorMessage="*" InitialValue="0"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="ravMaxDias" runat="server" ErrorMessage="Fuera de rango" ControlToValidate="txtMaxDias" MaximumValue="32767" MinimumValue="1" Type="Integer"></asp:RangeValidator>
                    </td>
                    <td align="right" width="110">
                        <asp:Label ID="Label10" runat="server" Text="Duración Max Horas:"></asp:Label>
                    </td>
                    <td align="left" width="240">
                        <asp:TextBox ID="txtMaxHoras" runat="server" Width="90px"></asp:TextBox>
                        <cc1:NumericUpDownExtender ID="txtMaxHoras_NumericUpDownExtender" runat="server" TargetControlID="txtMaxHoras" Minimum="1" Maximum="9999999" Width="120">
                        </cc1:NumericUpDownExtender>
                        <asp:RequiredFieldValidator ID="rfvMaxHoras" runat="server" ControlToValidate="txtMaxHoras" ErrorMessage="*" InitialValue="0"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="ravMaxHoras" runat="server" ControlToValidate="txtMaxHoras" ErrorMessage="Fuera de rango" MaximumValue="32767" MinimumValue="1" Type="Integer"></asp:RangeValidator>
                    </td>
                    <td align="right" width="100">
                        <asp:Label ID="Label11" runat="server" Text="Grupo Restricción:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="cboGrupoRestriccion" runat="server" CssClass="box" Width="200px">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvGrupoRestric" runat="server" ControlToValidate="cboGrupoRestriccion" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td align="right" width="130">
                        <asp:Label ID="Label5" runat="server" Text="Concluir al 1er rechazo:"></asp:Label>
                    </td>
                    <td align="left" width="240">
                        <asp:CheckBox ID="chkRechazo" runat="server" />
                    </td>
                    <td align="right" width="110">
                        <asp:Label ID="Label13" runat="server" Text="Prioridad:"></asp:Label>
                    </td>
                    <td align="left" width="240">
                        <asp:TextBox ID="txtPrioridad" runat="server" Width="90px"></asp:TextBox>
                        <cc1:NumericUpDownExtender ID="txtPrioridad_NumericUpDownExtender" runat="server" TargetControlID="txtPrioridad" Minimum="1" Maximum="9999999" Width="120">
                        </cc1:NumericUpDownExtender>
                        <asp:RequiredFieldValidator ID="rfvPrioridad" runat="server" ControlToValidate="txtPrioridad" ErrorMessage="*" InitialValue="0"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="ravPrioridad" runat="server" ControlToValidate="txtPrioridad" ErrorMessage="Fuera de rango" MaximumValue="255" MinimumValue="1" Type="Integer"></asp:RangeValidator>
                    </td>
                    <td align="right" width="100">
                        &nbsp;</td>
                    <td align="left">
                        &nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td align="right" width="130">
                        <asp:Label ID="Label6" runat="server" Text="Nivel Oficina:"></asp:Label>
                    </td>
                    <td align="left" width="240">
                        <asp:DropDownList ID="cboNivOficina" runat="server" CssClass="box" Width="200px">
                        </asp:DropDownList>
                    </td>
                    <td align="right" width="110">
                        <asp:Label ID="Label8" runat="server" Text="Oficina:"></asp:Label>
                    </td>
                    <td align="left" style="margin-left: 40px" width="240">
                        <asp:DropDownList ID="cboOficina" runat="server" CssClass="box" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="cboOficina_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td align="right" width="100">
                        <asp:Label ID="Label9" runat="server" Text="Área:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="cboArea" runat="server" CssClass="box" Width="200px">
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td align="right" width="130">
                        <asp:Label ID="Label7" runat="server" Text="Rol:"></asp:Label>
                    </td>
                    <td align="left" width="240">
                        <asp:DropDownList ID="cboRol" runat="server" CssClass="box" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="cboRol_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="tfvRol" runat="server" ControlToValidate="cboRol" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                    <td align="right" width="110">
                        <asp:Label ID="Label12" runat="server" Text="Usuario:"></asp:Label>
                    </td>
                    <td align="left" width="240">
                        <asp:DropDownList ID="cboUsuario" runat="server" CssClass="box" Width="200px">
                        </asp:DropDownList>
                    </td>
                    <td width="100">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td align="right" width="130">
                        &nbsp;</td>
                    <td align="left">
                        &nbsp;</td>
                    <td align="left" colspan="2">
                        &nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td align="center" colspan="7">
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
                    <td align="right">
                        &nbsp;</td>
                    <td align="left">
                        &nbsp;</td>
                    <td align="left">
                        &nbsp;</td>
                    <td align="left">
                        &nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td align="center" colspan="7">
                        <div style="width: 1100px; overflow-x: scroll" align="center">                        
                            <asp:GridView ID="gvFlujo" runat="server" AllowPaging="True" OnPageIndexChanging="gvFlujo_PageIndexChanging" OnSelectedIndexChanged="gvFlujo_SelectedIndexChanged" BorderColor="#DADADA" DataKeyNames="IdFlujo" Width="2000px" style="margin-bottom: 0px">
                                <HeaderStyle CssClass="cssHeaderImg" />
                                <Columns>
                                    <asp:CommandField ButtonType="Image" HeaderText="Elegir" SelectImageUrl="~/imagenes/16siguiente.png" SelectText="Seleccionar" ShowHeader="True" ShowSelectButton="True" />
                                </Columns>
                                <EmptyDataTemplate>
                                    <div align="center" class="CajaDialogoAdvertencia" style="width: 1100px">
                                        <br/>
                                        <img src="../Imagenes/warning.gif" 
                                            alt="No existen registros" />
                                        <br/>
                                        Bandeja de Flujo vacía.
                                        <br/>
                                        <br/>
                                    </div>
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td align="right">&nbsp;</td>
                    <td align="left">&nbsp;</td>
                    <td align="left">&nbsp;</td>
                    <td align="left">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td align="right" class="recuadro_tr">Enlaces:</td>
                    <td align="left" class="recuadro_tr">
                        <br />
                        <asp:HyperLink ID="lnkActividadFlujo" runat="server" Enabled="False">Actividades de Flujo</asp:HyperLink>
                        <br />
                        <br />
                        <asp:HyperLink ID="lnkPrecedencia" runat="server" Enabled="False">Precendencia de Actividades</asp:HyperLink>
                        <br />
                        <br />
                    </td>
                    <td align="left">&nbsp;</td>
                    <td align="left">&nbsp;&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td align="right">&nbsp;</td>
                    <td align="left">&nbsp;</td>
                    <td align="left">&nbsp;</td>
                    <td align="left">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
    </div>
</asp:Content>

