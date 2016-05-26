<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmTipoTramiteConcepto.aspx.cs" Inherits="WorkFlow_wfrmTipoTramiteConcepto" StylesheetTheme="Modal"%>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="pnlGral">
        <asp:Panel ID="pnlDatos" runat="server" CssClass="pnlBody">
            <table style="width: 100%;">
                <tr>
                    <td colspan="6" align="center">
                        <asp:ImageButton ID="imgAux" runat="server" ImageUrl="~/Imagenes/16w.png" />
                        <asp:Label ID="lblTituloAUX" runat="server" CssClass="texto12" Text="Concepto Asociado a Tipo de Trámite"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" colspan="6">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="right" width="150">
                        <asp:Label ID="Label1" runat="server" Text="Tipo de Trámite:"></asp:Label>
                    </td>
                    <td align="left" colspan="5">
                        <asp:TextBox ID="txtTipoTramite" runat="server" Width="800px" CssClass="box" Enabled="False"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvIdTipoTramite" runat="server" ControlToValidate="txtTipoTramite" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" width="150">
                        <asp:Label ID="Label2" runat="server" Text="Concepto:"></asp:Label>
                    </td>
                    <td align="left" colspan="5">
                        <asp:DropDownList ID="cboConcepto" runat="server" Width="800px" OnSelectedIndexChanged="cboConcepto_SelectedIndexChanged" CssClass="box" AutoPostBack="True">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvConcepto" runat="server" ControlToValidate="cboConcepto" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" width="150">
                        <asp:Label ID="Label3" runat="server" Text="Orden:"></asp:Label>
                    </td>
                    <td align="left" style="width: 200px">
                        <asp:TextBox ID="txtOrden" runat="server" CssClass="box"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvOrden" runat="server" ControlToValidate="txtOrden" ErrorMessage="*" InitialValue="0"></asp:RequiredFieldValidator>
                        <cc1:NumericUpDownExtender ID="txtOrden_NumericUpDownExtender" runat="server" TargetControlID="txtOrden" Minimum="0" Maximum="999999999" Width="80">
                        </cc1:NumericUpDownExtender>
                        <asp:RangeValidator ID="ravMaxDias" runat="server" ControlToValidate="txtOrden" ErrorMessage="Fuera de rango" MaximumValue="32767" MinimumValue="1" Type="Integer"></asp:RangeValidator>
                    </td>
                    <td align="left" width="270">
                        <asp:CheckBox ID="chkSolicitud" runat="server" Text="Se registra en la solicitud" />
                    </td>
                    <td align="left" width="210">
                        <asp:CheckBox ID="chkModificable" runat="server" Text="Puede ser modificado por el usuario" />
                    </td>
                    <td align="left" colspan="2">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="right" width="150"></td>
                    <td align="left" style="width: 200px"></td>
                    <td align="left" width="270">
                        <asp:CheckBox ID="chkDeterminaFlujo" runat="server" Text="Interviene en la determinación del flujo al iniciar" />
                    </td>
                    <td align="left" width="210">
                        <asp:CheckBox ID="chkObligatorio" runat="server" Text="Es de carácter obligatorio" />
                    </td>
                    <td align="left" colspan="2"></td>
                </tr>
                <tr>
                    <td align="right" width="150">&nbsp;</td>
                    <td align="left" colspan="3">&nbsp;</td>
                    <td colspan="2">&nbsp;</td>
                </tr>
                <tr>
                    <td align="right" width="150">&nbsp;</td>
                    <td align="left" colspan="4">
                        <asp:Panel ID="pnlValores" runat="server" CssClass="panelceleste">
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
                                    </td >
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
                                                        <td align="left">
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
                                                        <td></td>
                                                    </tr>
                                                </table>
                                            </asp:View>
                                            <asp:View ID="vChar" runat="server">
                                                <table style="width: 100%;">
                                                    <tr>
                                                        <td align="center">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtValorChar" runat="server" MaxLength="500" Width="160px" CssClass="box"></asp:TextBox>
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
                                                            <asp:TextBox ID="txtValorFecha" runat="server" BackColor="#87CEEB" Width="75px" CssClass="box"></asp:TextBox>
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
                                                            <asp:RangeValidator ID="ravCTalog" runat="server" ControlToValidate="txtValorCTalog" ErrorMessage="Fuera de rango" MaximumValue="2147483647" MinimumValue="1"></asp:RangeValidator>
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
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td align="right" width="150" colspan="6">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center" colspan="6">
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
                    <td align="right">&nbsp;</td>
                    <td align="left">&nbsp;</td>
                    <td align="left">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td colspan="2">&nbsp;</td>
                </tr>
                <tr>
                    <td align="center" colspan="6">
                        <asp:GridView ID="gvTipoTramConcepto" runat="server" AllowPaging="True" OnPageIndexChanging="gvTipoTramConcepto_PageIndexChanging" OnSelectedIndexChanged="gvTipoTramConcepto_SelectedIndexChanged" BorderColor="#DADADA" DataKeyNames="IdTipoTramite,IdConcepto">
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
                                    Bandeja de Conceptos asociados al Tipo de Trámite vacía.
                                    <br/>
                                    <br/>
                                </div>
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td align="right">&nbsp;</td>
                    <td align="left">&nbsp;</td>
                    <td align="left">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td colspan="2">&nbsp;</td>
                </tr>
                <tr>
                    <td align="right">&nbsp;</td>
                    <td align="left" colspan="3">&nbsp;</td>
                    <td colspan="2">&nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
    </div>
</asp:Content>

