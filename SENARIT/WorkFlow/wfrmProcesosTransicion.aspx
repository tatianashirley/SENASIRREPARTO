<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmProcesosTransicion.aspx.cs" Inherits="WorkFlow_wfrmProcesosTransicion"  StylesheetTheme="Modal"%>
<%@ MasterType VirtualPath="~/MasterPage.master"%>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="pnlGral">
        <asp:Panel ID="pnlMaestro" runat="server" CssClass="pnlBody">
            <table style="width: 100%;">
            <tr>
                <td colspan="5" align="center">
                    <asp:ImageButton ID="imgAux" runat="server" Height="16px" ImageUrl="~/Imagenes/16w.png" />
                    <asp:Label ID="lblTituloAUX" runat="server" CssClass="texto12" Text="Procesos a ejecutarse al momento de realizar la transición"></asp:Label>
                </td>
                <td align="center">&nbsp;</td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="Label1" runat="server" Text="Tipo Trámite:"></asp:Label>
                </td>
                <td align="left" colspan="5"><asp:TextBox ID="txtTipoTramite" runat="server" CssClass="box" Enabled="False" Width="900px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvTipoTramite" runat="server" ControlToValidate="txtTipoTramite" ErrorMessage="*" ValidationGroup="maestro"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="Label2" runat="server" Text="Flujo:"></asp:Label>
                </td>
                <td align="left" colspan="5"><asp:TextBox ID="txtFlujo" runat="server" CssClass="box" Enabled="False" Width="900px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvFlujo" runat="server" ControlToValidate="txtFlujo" ErrorMessage="*" ValidationGroup="maestro"></asp:RequiredFieldValidator>
                </td>
            </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label14" runat="server" Text="Actividad Predecesora:"></asp:Label>
                    </td>
                    <td align="left" colspan="5">
                        <asp:DropDownList ID="cboActPredecesora" runat="server" CssClass="box" Enabled="False" Width="900px">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="tfvActPred" runat="server" ControlToValidate="cboActividad" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label12" runat="server" Text="Actividad:"></asp:Label>
                    </td>
                    <td align="left" colspan="5">
                        <asp:DropDownList ID="cboActividad" runat="server" CssClass="box" Enabled="False" Width="900px">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="tfvActividad" runat="server" ControlToValidate="cboActividad" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label3" runat="server" Text="Secuencia:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtSecuencia" runat="server" CssClass="box"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvSecuencia" runat="server" ControlToValidate="txtSecuencia" ErrorMessage="*" ValidationGroup="maestro"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="ravSecuencia" runat="server" ControlToValidate="txtSecuencia" ErrorMessage="Fuera de rango" MaximumValue="32767" MinimumValue="1" Type="Integer" ValidationGroup="maestro"></asp:RangeValidator>
                    </td>
                    <td align="right" class="auto-style1">
                        <asp:Label ID="Label4" runat="server" Text="Procedimiento:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtProcedimiento" runat="server" Width="200px" CssClass="box"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvProcedimiento" runat="server" ControlToValidate="txtProcedimiento" ErrorMessage="*" ValidationGroup="maestro"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="ravProcedimiento" runat="server" ControlToValidate="txtProcedimiento" ErrorMessage="Fuera de rango" MaximumValue="2147483647" MinimumValue="1" Type="Integer" ValidationGroup="maestro"></asp:RangeValidator>
                    </td>
                    <td align="right">
                        <asp:Label ID="Label18" runat="server" Text="Debe reportar éxito"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:CheckBox ID="chkExito" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label15" runat="server" Text="Operación:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtOperacion" runat="server" CssClass="box" Width="50px" onkeyup="this.value=this.value.toUpperCase()" MaxLength="1"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvProcedimiento0" runat="server" ControlToValidate="txtOperacion" ErrorMessage="*" ValidationGroup="maestro"></asp:RequiredFieldValidator>
                    </td>
                    <td align="right" class="auto-style1">
                        <asp:Label ID="Label16" runat="server" Text="Comprobante aceptación documentos"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:CheckBox ID="chkCmpteAcepDoc" runat="server" />
                    </td>
                    <td align="right">
                        <asp:Label ID="Label17" runat="server" Text="Se aplica en la aceptación del trámite en el cbte. de traslado"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:CheckBox ID="chkAceptacion" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="right">&nbsp;</td>
                    <td align="left">&nbsp;</td>
                    <td align="right">&nbsp;</td>
                    <td align="left">&nbsp;</td>
                    <td align="left">&nbsp;</td>
                    <td align="left">&nbsp;</td>
                </tr>
                <tr>
                    <td align="center" colspan="6">
                        <asp:ImageButton ID="imgAtras" runat="server" AlternateText="Atrás" CausesValidation="False" ImageUrl="~/Imagenes/azulAtras.png" OnClick="imgAtras_Click" DescriptionUrl="Volver" />
                        <asp:Button ID="btnNuevo" runat="server" CausesValidation="False" CssClass="btnPrin" OnClick="btnNuevo_Click" Text="Nuevo" ValidationGroup="maestro" Width="47px" />
                        <asp:Button ID="btnGrabar" runat="server" CssClass="btnPrin" OnClick="btnGrabar_Click" Text="Grabar" ValidationGroup="maestro" />
                        <cc1:ConfirmButtonExtender ID="btnGrabar_ConfirmButtonExtender" runat="server" ConfirmText="¿Esta seguro de guardar/modificar el registro?" TargetControlID="btnGrabar">
                        </cc1:ConfirmButtonExtender>
                        <asp:Button ID="btnEliminar" runat="server" CssClass="btnPrin" Enabled="False" OnClick="btnEliminar_Click" Text="Eliminar" ValidationGroup="maestro" />
                        <cc1:ConfirmButtonExtender ID="btnEliminar_ConfirmButtonExtender" runat="server" ConfirmText="¿Esta seguro de eliminar el registro?" TargetControlID="btnEliminar" />
                    </td>
                </tr>
                <tr>
                    <td align="right">&nbsp;</td>
                    <td align="left">&nbsp;</td>
                    <td align="right" class="auto-style1">&nbsp;</td>
                    <td align="left">&nbsp;</td>
                    <td align="left">&nbsp;</td>
                    <td align="left">&nbsp;</td>
                </tr>
                <tr>
                    <td align="center" colspan="5">
                        <asp:GridView ID="gvProcesos" runat="server" AllowPaging="True" BorderColor="#DADADA" OnPageIndexChanging="gvProcesos_PageIndexChanging" OnSelectedIndexChanged="gvProcesos_SelectedIndexChanged" DataKeyNames="Secuencia,IdProcedimiento">
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
                                    Bandeja de Procesos a Ejecutarse en la Transición Nodo vacía.
                                    <br/>
                                    <br/>
                                </div>
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </td>
                    <td align="center">&nbsp;</td>
                </tr>
                <tr>
                    <td align="right">&nbsp;</td>
                    <td align="left">&nbsp;</td>
                    <td align="right" class="auto-style1">&nbsp;</td>
                    <td align="left">&nbsp;</td>
                    <td align="left">&nbsp;</td>
                    <td align="left">&nbsp;</td>
                </tr>
        </table>    
        </asp:Panel>
    </div>
    
    <div class="pnlGral">
        <asp:Panel ID="pnlDetalle" CssClass="pnlPest" runat="server" Visible="False">
            <table style="width: 100%;">
                <tr>
                    <td colspan="4" align="center">
                        <asp:ImageButton ID="imgAux0" runat="server" Height="16px" ImageUrl="~/Imagenes/16w.png" />
                        <asp:Label ID="lblTituloAUX0" runat="server" CssClass="texto12" Text="Parámetros"></asp:Label>
                    </td>
                    <td align="center">&nbsp;</td>
                    <td align="center">&nbsp;</td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label5" runat="server" Text="Parámetro:"></asp:Label></td>
                    <td align="left" style="width: 300px">
                        <asp:TextBox ID="txtParam" runat="server" CssClass="box" MaxLength="50" Width="200px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvParam" runat="server" ControlToValidate="txtParam" ErrorMessage="*" ValidationGroup="detalle"></asp:RequiredFieldValidator>
                    </td>
                    <td align="right">
                        <asp:Label ID="Label13" runat="server" Text="Concepto:" CssClass="box"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="cboConcepto" runat="server" CssClass="box" Width="350px"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvConcepto" runat="server" ControlToValidate="cboConcepto" ErrorMessage="*" ValidationGroup="detalle"></asp:RequiredFieldValidator>
                    </td>
                    <td align="right">
                        <asp:Label ID="Label19" runat="server" Text="Solicitud:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:CheckBox ID="chkSolicitud" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="4" align="center">
                        <asp:Button ID="btnNuevoDet" runat="server" CausesValidation="False" CssClass="btnPrin" Text="Nuevo" ValidationGroup="detalle" OnClick="btnNuevoDet_Click" />
                        <asp:Button ID="btnGrabarDet" runat="server" CssClass="btnPrin" Text="Grabar" ValidationGroup="detalle" OnClick="btnGrabarDet_Click" />
                        <cc1:ConfirmButtonExtender ID="btnGrabarDet_ConfirmButtonExtender" runat="server" TargetControlID="btnGrabarDet" ConfirmText="¿Esta seguro de guardar/modificar el registro?">
                        </cc1:ConfirmButtonExtender>
                        <asp:Button ID="btnEliminarDet" runat="server" CssClass="btnPrin" Enabled="False" Text="Eliminar" ValidationGroup="detalle" OnClick="btnEliminarDet_Click" />
                        <cc1:ConfirmButtonExtender ID="btnEliminarDet_ConfirmButtonExtender" runat="server" TargetControlID="btnEliminarDet" ConfirmText="¿Esta seguro de eliminar el registro?">
                        </cc1:ConfirmButtonExtender>
                    </td>
                    <td align="center">&nbsp;</td>
                    <td align="center">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="4">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="4" align="center">
                        <asp:GridView ID="gvParam" runat="server" AllowPaging="True" BorderColor="#DADADA" DataKeyNames="IdParametro" OnPageIndexChanging="gvParam_PageIndexChanging" OnSelectedIndexChanged="gvParam_SelectedIndexChanged">
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
                                    Bandeja de Parámetros vacía.
                                    <br/>
                                    <br/>
                                </div>
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </td>
                    <td align="center">&nbsp;</td>
                    <td align="center">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="4">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table> 
        </asp:Panel>
    </div>
   
</asp:Content>



