<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmConceptosDisponiblesActividad.aspx.cs" Inherits="WorkFlow_wfrmConceptosDisponiblesActividad"  StylesheetTheme="Modal"%>
<%@ MasterType VirtualPath="~/MasterPage.master"%>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="pnlGral">
        <asp:Panel ID="pnlDatos" runat="server" CssClass="pnlBody">
            <table style="width: 100%;">
            <tr>
                <td colspan="4" align="center">
                    <asp:ImageButton ID="ImageButton1" runat="server" Height="16px" ImageUrl="~/Imagenes/16w.png" />
                    <asp:Label ID="Label2" runat="server" CssClass="texto12" Text="Conceptos Disponibles para la Actividad"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="auto-style8">
                    <asp:Label ID="Label3" runat="server" Text="Tipo Trámite:"></asp:Label>
                </td>
                <td align="left" colspan="3"><asp:TextBox ID="txtTipoTramite" runat="server" CssClass="box" Enabled="False" Width="900px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvTipoTramite" runat="server" ControlToValidate="txtTipoTramite" ErrorMessage="*" ValidationGroup="maestro"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right" class="auto-style8">
                    <asp:Label ID="Label4" runat="server" Text="Flujo:"></asp:Label>
                </td>
                <td align="left" colspan="3"><asp:TextBox ID="txtFlujo" runat="server" CssClass="box" Enabled="False" Width="900px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvFlujo" runat="server" ControlToValidate="txtFlujo" ErrorMessage="*" ValidationGroup="maestro"></asp:RequiredFieldValidator>
                </td>
            </tr>
                <tr>
                    <td align="right" class="auto-style8">
                        <asp:Label ID="Label12" runat="server" Text="Actividad:"></asp:Label>
                    </td>
                    <td align="left" colspan="3">
                        <asp:TextBox ID="txtActividad" runat="server" CssClass="box" Enabled="False" Width="900px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvActividad" runat="server" ControlToValidate="txtActividad" ErrorMessage="*" ValidationGroup="maestro"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="auto-style10">
                        <asp:Label ID="Label5" runat="server" Text="Concepto:"></asp:Label>
                    </td>
                    <td align="left" class="auto-style7" colspan="3">
                        <asp:DropDownList ID="cboConcepto" runat="server" CssClass="box" Width="900px" AutoPostBack="True" OnSelectedIndexChanged="cboConcepto_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvSecuencia" runat="server" ControlToValidate="cboConcepto" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="auto-style8">
                        <asp:Label ID="Label13" runat="server" Text="Obligatorio:"></asp:Label>
                    </td>
                    <td align="left" style="width: 100px">
                        <asp:CheckBox ID="chkObligatorio" runat="server" />
                    </td>
                    <td align="left" style="width: 200px">
                        <asp:CheckBox ID="chkModificable" runat="server" Text="Puede ser modificado por el usuario:" TextAlign="Left" />
                    </td>
                    <td align="left">
                        <asp:CheckBox ID="chkActivo" runat="server" Text="Activo:" TextAlign="Left" />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="auto-style8">
                        &nbsp;</td>
                    <td align="left" colspan="3">
                        <asp:Panel ID="pnlValores" runat="server" CssClass="panelceleste" Width="898px">
                            <table style="width:100%;">
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 120px">
                                        <asp:Label ID="Label25" runat="server" Text="Tipo Dato/Concepto:"></asp:Label>
                                    </td>
                                    <td style="width: 110px">
                                        <asp:DropDownList ID="cboTipoDato" runat="server" CssClass="box" Enabled="False" Width="100px">
                                            <asp:ListItem></asp:ListItem>
                                            <asp:ListItem Value="I">Int</asp:ListItem>
                                            <asp:ListItem Value="M">Money</asp:ListItem>
                                            <asp:ListItem Value="F">Float</asp:ListItem>
                                            <asp:ListItem Value="C">Char</asp:ListItem>
                                            <asp:ListItem Value="D">Date</asp:ListItem>
                                            <asp:ListItem Value="T">caTalog</asp:ListItem>
                                            <asp:ListItem Value="B">Boolean</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td align="right" style="width: 50px">
                                        <asp:Label ID="Label33" runat="server" Text="Valor:"></asp:Label>
                                    </td>
                                    <td style="width: 300px">
                                        <asp:MultiView ID="mvValores" runat="server">
                                            <asp:View ID="vInt" runat="server">
                                                <table style="width: 100%;">
                                                    <tr>
                                                        <td align="left">&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtValorInt" runat="server" CssClass="box"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvValInt" runat="server" ControlToValidate="txtValorInt" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                            <asp:RangeValidator ID="ravInt" runat="server" ControlToValidate="txtValorInt" ErrorMessage="Fuera de rango" MaximumValue="2147483647" MinimumValue="1" Type="Integer"></asp:RangeValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                </table>
                                            </asp:View>
                                            <asp:View ID="vMoney" runat="server">
                                                <table style="width: 100%;">
                                                    <tr>
                                                        <td align="left">&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" class="auto-style11">
                                                            <asp:TextBox ID="txtValorMoney" runat="server" CssClass="box"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvValMon" runat="server" ControlToValidate="txtValorMoney" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                            <asp:RangeValidator ID="ravMoney" runat="server" ControlToValidate="txtValorMoney" ErrorMessage="Fuera de rango" MaximumValue="922337203685477,5807" MinimumValue="1" Type="Double"></asp:RangeValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                </table>
                                            </asp:View>
                                            <asp:View ID="vFloat" runat="server">
                                                <table style="width: 100%;">
                                                    <tr>
                                                        <td align="left">&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtValorFloat" runat="server" CssClass="box"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvValFloat" runat="server" ControlToValidate="txtValorFloat" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                            <asp:RangeValidator ID="ravFloat" runat="server" ControlToValidate="txtValorFloat" ErrorMessage="Fuera de rango" MaximumValue="922337203685477,5807" MinimumValue="1" Type="Double"></asp:RangeValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="auto-style10"></td>
                                                    </tr>
                                                </table>
                                            </asp:View>
                                            <asp:View ID="vChar" runat="server">
                                                <table style="width: 100%;">
                                                    <tr>
                                                        <td align="center">&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtValorChar" runat="server" MaxLength="500" Height="16px" CssClass="box"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvValChar" runat="server" ControlToValidate="txtValorChar" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="revValorChar" runat="server" ControlToValidate="txtValorChar" ErrorMessage="Caracteres (Max. 500)" ValidationExpression="^[\s\S]{0,500}$"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">&nbsp;</td>
                                                    </tr>
                                                </table>
                                            </asp:View>
                                            <asp:View ID="vDate" runat="server">
                                                <table style="width: 100%;">
                                                    <tr>
                                                        <td align="left">&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtValorFecha" runat="server" BackColor="#87CEEB" CssClass="box" Width="75px"></asp:TextBox>
                                                            <cc1:TextBoxWatermarkExtender ID="txtValorFecha_TextBoxWatermarkExtender" runat="server" Enabled="True" TargetControlID="txtValorFecha" WatermarkText="__/__/____">
                                                            </cc1:TextBoxWatermarkExtender>
                                                            <cc1:CalendarExtender ID="txtValorFecha_CalendarExtender" runat="server" Format="dd/MM/yyyy" PopupButtonID="imgPopupDesde" TargetControlID="txtValorFecha">
                                                            </cc1:CalendarExtender>
                                                            <asp:ImageButton ID="imgPopupDesde" runat="server" ImageAlign="Bottom" ImageUrl="../Imagenes/pequeños/CalendarC_16x16.png" />
                                                            <asp:RequiredFieldValidator ID="rfvValFec" runat="server" ControlToValidate="txtValorFecha" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                </table>
                                            </asp:View>
                                            <asp:View ID="vCTalog" runat="server">
                                                <table style="width: 100%;">
                                                    <tr>
                                                        <td align="center">&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtValorCTalog" runat="server" CssClass="box"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvValCtalog" runat="server" ControlToValidate="txtValorCTalog" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                            <asp:RangeValidator ID="ravCTalog" runat="server" ControlToValidate="txtValorCTalog" ErrorMessage="Fuera de rango" MaximumValue="32767" MinimumValue="1"></asp:RangeValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">&nbsp;</td>
                                                    </tr>
                                                </table>
                                            </asp:View>
                                            <asp:View ID="vBoolean" runat="server">
                                                <table style="width: 100%;">
                                                    <tr>
                                                        <td align="center">&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:CheckBox ID="chkValorBool" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">&nbsp;</td>
                                                    </tr>
                                                </table>
                                            </asp:View>
                                        </asp:MultiView>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td align="right" class="auto-style8">&nbsp;</td>
                    <td align="left" style="width: 100px">&nbsp;</td>
                    <td align="right" style="width: 50px">&nbsp;</td>
                    <td align="left">&nbsp;</td>
                </tr>
                <tr>
                    <td align="center" colspan="4">
                        <asp:ImageButton ID="imgAtras0" runat="server" AlternateText="Atrás" CausesValidation="False" ImageUrl="~/Imagenes/azulAtras.png" OnClick="imgAtras_Click" DescriptionUrl="Volver" />
                        <asp:Button ID="btnNuevo" runat="server" CausesValidation="False" CssClass="btnPrin" OnClick="btnNuevo_Click" Text="Nuevo" Width="47px" />
                        <asp:Button ID="btnGuardar" runat="server" CssClass="btnPrin" OnClick="btnGuardar_Click" Text="Guardar" />
                        <cc1:ConfirmButtonExtender ID="btnGuardar_ConfirmButtonExtender" runat="server" ConfirmText="¿Esta seguro de guardar/modificar el registro?" TargetControlID="btnGuardar">
                        </cc1:ConfirmButtonExtender>
                        <asp:Button ID="btnEliminar" runat="server" CssClass="btnPrin" Enabled="False" OnClick="btnEliminar_Click" Text="Eliminar" />
                        <cc1:ConfirmButtonExtender ID="btnEliminar_ConfirmButtonExtender" runat="server" ConfirmText="¿Esta seguro de eliminar el registro?" TargetControlID="btnEliminar">
                        </cc1:ConfirmButtonExtender>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="auto-style8">&nbsp;</td>
                    <td align="left" style="width: 100px">&nbsp;</td>
                    <td align="right" style="width: 50px">&nbsp;</td>
                    <td align="left">&nbsp;</td>
                </tr>
                <tr>
                    <td align="center" colspan="4">
                        <asp:GridView ID="gvConcep" runat="server" AllowPaging="True" BorderColor="#DADADA" DataKeyNames="IdConcepto" OnPageIndexChanging="gvConcep_PageIndexChanging" OnSelectedIndexChanged="gvConcep_SelectedIndexChanged">
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
                                    Bandeja de Conceptos Disponibles para la Actividad vacía.
                                    <br/>
                                    <br/>
                                </div>
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="auto-style6" colspan="4">&nbsp;</td>
                </tr>
        </table>    
        </asp:Panel>
    </div>

</asp:Content>

