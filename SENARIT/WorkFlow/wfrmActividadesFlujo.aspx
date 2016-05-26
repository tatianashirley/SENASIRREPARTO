<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmActividadesFlujo.aspx.cs" Inherits="WorkFlow_wfrmActividadesFlujo" StylesheetTheme="Modal"%>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style6 {
            height: 17px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="pnlGral">
        <asp:Panel ID="pnlDatos" runat="server" CssClass="pnlBody">
            <table style="width: 100%;">
                <tr>
                    <td colspan="7" align="center">
                        <asp:ImageButton ID="imgAux" runat="server" ImageUrl="~/Imagenes/16w.png" Height="16px" />
                        <asp:Label ID="lblTituloAUX" runat="server" CssClass="texto12" Text="Registro de Actividades del Flujo"></asp:Label>
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
                    <td align="left">&nbsp;</td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label2" runat="server" Text="Flujo:"></asp:Label>
                    </td>
                    <td align="left" colspan="5">
                        <asp:TextBox ID="txtFlujo" runat="server" CssClass="box" Enabled="False" Width="900px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvTipoTramite0" runat="server" ControlToValidate="txtFlujo" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                    <td align="left">&nbsp;</td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label3" runat="server" Text="Actividad:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtActividad" runat="server" CssClass="box" Width="99px" Height="16px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvActividad" runat="server" ControlToValidate="txtActividad" ErrorMessage="*"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="ravActividad" runat="server" ControlToValidate="txtActividad" ErrorMessage="Fuera de rango" MaximumValue="32767" MinimumValue="1" Type="Integer"></asp:RangeValidator>
                    </td>
                    <td align="right">
                        <asp:Label ID="Label10" runat="server" Text="Descripción:"></asp:Label>
                    </td>
                    <td align="left" colspan="3">
                        <asp:TextBox ID="txtDescripcion" runat="server" Width="620px" CssClass="box" MaxLength="100"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="tfvDescripcion" runat="server" ControlToValidate="txtDescripcion" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                    <td align="left">&nbsp;</td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label4" runat="server" Text="Comentarios:"></asp:Label>
                    </td>
                    <td align="left" colspan="5">
                        <asp:TextBox ID="txtComentarios" runat="server" CssClass="box" Width="700px" MaxLength="500"></asp:TextBox>
                    </td>
                    <td align="left">&nbsp;</td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label6" runat="server" Text="Duración Max Días:"></asp:Label>
                    </td>
                    <td align="left" style="margin-left: 40px">
                        <asp:TextBox ID="txtMaxDias" runat="server"></asp:TextBox>
                        <cc1:NumericUpDownExtender ID="txtMaxDias_NumericUpDownExtender" runat="server" TargetControlID="txtMaxDias" Minimum="1" Maximum="9999999" Width="120">
                        </cc1:NumericUpDownExtender>
                        <asp:RequiredFieldValidator ID="rfvMaxDias" runat="server" ControlToValidate="txtMaxDias" ErrorMessage="*" InitialValue="0"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="ravMaxDias" runat="server" ControlToValidate="txtMaxDias" ErrorMessage="Fuera de rango" MaximumValue="32767" MinimumValue="1" Type="Integer"></asp:RangeValidator>
                    </td>
                    <td align="right">
                        <asp:Label ID="Label11" runat="server" Text="Duración Max Horas:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtMaxHoras" runat="server"></asp:TextBox>
                        <cc1:NumericUpDownExtender ID="txtMaxHoras_NumericUpDownExtender" runat="server" TargetControlID="txtMaxHoras"  Minimum="1" Maximum="9999999" Width="120">
                        </cc1:NumericUpDownExtender>
                        <asp:RequiredFieldValidator ID="rfvMaxHoras" runat="server" ControlToValidate="txtMaxHoras" ErrorMessage="*" InitialValue="0"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="ravMaxHoras" runat="server" ControlToValidate="txtMaxHoras" ErrorMessage="Fuera de rango" MaximumValue="32767" MinimumValue="1" Type="Integer"></asp:RangeValidator>
                    </td>
                    <td align="right">
                        <asp:Label ID="Label12" runat="server" Text="Nemónico:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtNemonico" runat="server" CssClass="box" MaxLength="20"></asp:TextBox>
                    </td>
                    <td align="left">&nbsp;</td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label8" runat="server" Text="Nivel Oficina:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="cboNivelOficina" runat="server" CssClass="box" Width="250px">
                        </asp:DropDownList>
                    </td>
                    <td align="right">
                        <asp:Label ID="Label13" runat="server" Text="Oficina:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="cboOficina" runat="server" CssClass="box" Width="250px" OnSelectedIndexChanged="cboOficina_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                    <td align="right">
                        <asp:Label ID="Label14" runat="server" Text="Área:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="cboArea" runat="server" CssClass="box" Width="250px">
                            <asp:ListItem>Seleccione valor ...</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td align="left">&nbsp;</td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label9" runat="server" Text="Rol:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="cboRol" runat="server" CssClass="box" Width="250px" OnSelectedIndexChanged="cboRol_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                    <td align="right">
                        <asp:Label ID="Label15" runat="server" Text="Usuario:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="cboUsuario" runat="server" CssClass="box" Width="250px">
                        </asp:DropDownList>
                    </td>
                    <td align="right">&nbsp;</td>
                    <td align="left">
                        <asp:CheckBox ID="chkActivo" runat="server" Text="Activo" />
                    </td>
                    <td align="left">&nbsp;</td>
                </tr>
                <tr>
                    <td align="right">&nbsp;</td>
                    <td align="left">
                        <asp:CheckBox ID="chkRechazarTram" runat="server" Text="Puede rechazar el trámite" />
                    </td>
                    <td align="right">&nbsp;</td>
                    <td align="left">
                        <asp:CheckBox ID="chkSincronizador" runat="server" Text="Es una actividad sincronizada" />
                    </td>
                    <td align="right">&nbsp;</td>
                    <td align="left">&nbsp;</td>
                    <td align="left">&nbsp;</td>
                </tr>
                <tr>
                    <td align="right">&nbsp;</td>
                    <td align="left">
                        <asp:CheckBox ID="chkActividadFicticia" runat="server" Text="Es una actividad ficticia" />
                    </td>
                    <td align="right">&nbsp;</td>
                    <td align="left">
                        <asp:CheckBox ID="chkActividadTerminal" runat="server" Text="Es una actividad terminal (éxito)" />
                    </td>
                    <td align="right">&nbsp;</td>
                    <td align="left">&nbsp;</td>
                    <td align="left">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style6"></td>
                    <td class="auto-style6"></td>
                    <td class="auto-style6"></td>
                    <td class="auto-style6"></td>
                    <td class="auto-style6"></td>
                    <td class="auto-style6"></td>
                    <td class="auto-style6"></td>
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
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="7" align="center">
                        <div style="width: 1100px; overflow-x: scroll" align="center">
                            <asp:GridView ID="gvActiFlujo" runat="server" AllowPaging="True" BorderColor="#DADADA" DataKeyNames="IdNodo" OnPageIndexChanging="gvActiFlujo_PageIndexChanging" OnSelectedIndexChanged="gvActiFlujo_SelectedIndexChanged" Width="2000px">
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
                                        Bandeja de Actividades de Flujo vacía.
                                        <br/>
                                        <br/>
                                    </div>
                                </EmptyDataTemplate>
                            </asp:GridView>
                       </div>
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
                    <td align="right" class="recuadro_tr">Enlaces:</td>
                    <td align="left" class="recuadro_tr">
                        <br />
                        <asp:HyperLink ID="lnkEnlaces" runat="server" Enabled="False">Enlaces accesibles desde la actividad</asp:HyperLink>
                        <br />
                        <br />
                        <asp:HyperLink ID="lnkConcepto" runat="server" Enabled="False">Conceptos (Datos Adicionales) disponibles para la actividad</asp:HyperLink>
                        <br />
                        <br />
                        <asp:HyperLink ID="lnkTipDoc" runat="server" Enabled="False">Tipos de Documento disponibles para su registro desde la actividad </asp:HyperLink>
                        <br />
                    </td>
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

