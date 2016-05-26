<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmTipoCambio.aspx.cs"
    Inherits="EmisionCertificadoCC_wfrmTipoCambio" Culture="auto" UICulture="auto" StylesheetTheme="Modal" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .CajaDialogo {}
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%;" class="panelceleste">
        <tr>
            <td align="center">
                <asp:ImageButton ID="imgAux" runat="server" ImageUrl="~/Imagenes/16w.png" />
                <asp:Label ID="lblTituloAUX" runat="server"
                    Text="TIPO DE CAMBIO" CssClass="etiqueta20"></asp:Label>
                <asp:Label ID="lblCodigo" runat="server" Font-Size="Small" Text="1"
                    Visible="False"></asp:Label>
                <asp:Label ID="lblCodUsuario" runat="server" Font-Size="Small" Text="1"
                    Visible="False"></asp:Label>
                <asp:Label ID="lblRol" runat="server" Font-Size="Small"
                    Style="text-align: left" Text="0" Visible="False"></asp:Label>
               <%-- <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"> </cc1:ToolkitScriptManager>--%>
                <%--<asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True" EnableScriptLocalization="True" />--%>

            </td>
        </tr>

        <tr>
            <td>
                <asp:Panel ID="pnlGV" runat="server" HorizontalAlign="Center" Width="100%"
                    CssClass="panelceleste">
                    <table style="width: 100%;">
                        <tr>
                            <td colspan="2"  align="center" >
                                <asp:Panel ID="PanelMensaje" runat="server" Width="70%" CssClass="panelsecundario">
                                    <table style="width: 100%;">
                                        <tr>
                                            <td align="center">
                                                  <asp:Label ID="lblObservaciones" runat="server" CssClass="text_obs"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                              
                            </td>
                        </tr>
                          <tr>
                            <td style="width: 20%" align="center" class="panelceleste">
                                <asp:Panel ID="pnlNew" runat="server" Height="24px" Width="80px">
                                    <table style="width: 100%;">
                                        <tr>
                                            <td align="center">
                                                <asp:ImageButton ID="imgNuevo" runat="server" ImageUrl="~/Imagenes/nuevo.gif"
                                                    TabIndex="10" OnClick="imgNuevo_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>

                            </td>

                            <td align="right" valign="top" class="panelceleste" colspan ="5">
                                <asp:RadioButtonList ID="rbTipoMuestra" runat="server"
                                    RepeatDirection="Horizontal" TextAlign="Left"
                                    OnSelectedIndexChanged="rbTipoMuestra_SelectedIndexChanged"
                                     Width="200px" AutoPostBack="True" CssClass="etiqueta8">

                                    <asp:ListItem  Value="1">Todos Gestión</asp:ListItem>
                                    <asp:ListItem Selected="True" Value="2">Vigente</asp:ListItem>
                                </asp:RadioButtonList>

                            </td>

                        </tr>
                        <tr>
                            <td colspan="2" class="panelceleste">
                                <asp:GridView ID="gvTipo" runat="server"
                                    AllowPaging="True"
                                    AutoGenerateColumns="false"
                                    HorizontalAlign="Center"
                                    SkinID="GridView"
                                    OnRowDataBound="gvTipo_RowDataBound"
                                    OnPageIndexChanging="gvTipo_PageIndexChanging"
                                    OnRowCommand="gvTipo_RowCommand" 
                                    Width="100%" DataKeyNames ="TasaCambio,Moneda   ">

                                    <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />

                                    <Columns>
                                        <asp:BoundField DataField="Moneda" HeaderText="Moneda" /> 
                                        <asp:BoundField DataField="TasaCambio" HeaderText="Tipo Cambio" />
                                        <asp:BoundField DataField="Periodo" HeaderText="Fecha de Cambio " />
                                        <asp:BoundField DataField="Resolucion" HeaderText="Resolucion" />
                                        <asp:BoundField DataField="FechaResolucion" HeaderText="FechaResolucion" />
                                        <asp:BoundField DataField="RegistroActivo" HeaderText="RegistroActivo" Visible="false" />
                                    <asp:TemplateField HeaderText="Modificar"  HeaderStyle-HorizontalAlign="Center"> 
                                    <HeaderStyle Width="70px" HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemTemplate>
                                <center>
                                    <asp:ImageButton ID="imgEditar" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex  %>' CommandName="cmdEditar" ImageUrl="~/imagenes/16modificar.png" Height="16" Width="16" ToolTip="Editar Registro" />
                                </center>
                            </ItemTemplate>
                        </asp:TemplateField>
 
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                     </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlDatos" runat="server" CssClass="panelceleste" HorizontalAlign="Center" Width="60%">
                        <div>
                        <br />
                        <asp:Label ID="lblTitulo" runat="server" Text="Adicionar Tipos de Cambios"
                            CssClass="etiqueta20"></asp:Label>
                        <table style="width: 100%;">
                            <tr>
                                <td align="right" style="width: 25%"> 
                                     &nbsp;</td>
                                <td align="left" style="width: 25%">
                                    &nbsp;</td>
                                <td align="right" style="width: 10%">&nbsp;</td>
                            </tr>

                            <tr>
                                <td align="right" style="width: 25%">
                                    <asp:Label ID="lblfechahoy" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="Fecha Tasa de Cambio:"></asp:Label>
                                </td>
                                <td align="left" style="width: 25%">
                                    <asp:TextBox ID="txtFechaCom" runat="server" Enabled="false" Width="50%" Height="16px"></asp:TextBox>
                                    <asp:Label ID="lblFechaRes" runat="server" CssClass="etiqueta10" Style="text-align: left" Visible="false"></asp:Label>
                                </td>
                                <td align="right" style="width: 10%">&nbsp;</td>
                            </tr>

                            <tr>
                                <td align="right" style="width: 25%">
                                    <asp:Label ID="lblPeriodo" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="Periodo de Cotizacion :" Visible="false"></asp:Label>
                                </td>
                                <td align="left" style="width: 25%">
                                   <asp:TextBox ID="txtPeriodo" runat="server" Width="50%" Visible="false" Height="16px"></asp:TextBox>
                                 </td>

                                <td align="right" style="width: 10%">

                                    &nbsp;</td>
                            </tr>

                            <tr>
                                <td align="right" style="width: 25%">
                                    <asp:Label ID="lblMoneda" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="Moneda :"></asp:Label>
                                </td>
                                <td align="left" style="width: 25%">
                                    <asp:DropDownList ID="ddlMoneda" runat="server" Width="52%" Height="24px">
                                    </asp:DropDownList>
  
                                 </td>
                                <td align="right" style="width: 10%">
                                     &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 25%">
                                    <asp:Label ID="lblResolucion" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="Nro.Resolucion :"></asp:Label>

                                </td>
                               
                                <td align="left" style="width: 25%">
                                    <asp:TextBox ID="txtResolucion" runat="server" Height="16px" MaxLength="6" Width="50%" OnTextChanged="txtResolucion_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtResolucion" ErrorMessage="*" ValidationGroup="ValRegistro" />
                                    <cc1:FilteredTextBoxExtender ID="txtResolucion_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers,Custom " TargetControlID="txtResolucion" ValidChars=".">
                                    </cc1:FilteredTextBoxExtender>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtResolucion" Display="Dynamic" ErrorMessage="Formato es: ###.##" ValidationExpression="^([\d]{3}).([\d]{2})$" ValidationGroup="ValRegistro">
                                      </asp:RegularExpressionValidator>
                              
                                    
                                    <asp:Label ID="lblRespuesta" runat="server" CssClass="etiqueta10" Style="text-align: left" Visible="false"></asp:Label>
                              
                                    
                                </td>
                                <td align="left" style="width: 10%">
                                    &nbsp;</td>
                            </tr>

                            <tr>
                                <td align="right" >
                                    <asp:Label ID="lblTasaCambio" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="Tasa de Cambio :"></asp:Label>
                                </td>
                                <td align="left" >
                                    <asp:TextBox ID="txtTasaCambio" runat="server" Height="16px" MaxLength="8" Width="50%"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTasaCambio" ErrorMessage="*" ValidationGroup="ValRegistro"/>
                                    <cc1:FilteredTextBoxExtender ID="txtTasaCambio_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers, Custom" TargetControlID="txtTasaCambio" ValidChars=".">
                                    </cc1:FilteredTextBoxExtender>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtTasaCambio" Display="Dynamic" ErrorMessage="Formato es: #.###" ValidationExpression="^([\d]{1,2}).([\d]{1,3})$" ValidationGroup="ValRegistro">
                                      </asp:RegularExpressionValidator>
                                </td>
                                <td align="right" >&nbsp;</td>
                            </tr>

                            <tr>
                                <td align="right"  >
                                    <asp:Label ID="lblFechaResolucion" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="Fecha Resolucion :"></asp:Label>
                                </td>
                                <td align="left"  >
                                    
                                    <asp:TextBox ID="txtDate" runat="server" Width="50%" Height="16px" MaxLength="10"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtdate" ErrorMessage="*" ValidationGroup="ValRegistro"/>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" Enabled="True" FilterType="Numbers,Custom " TargetControlID="txtDate" ValidChars="/" >
                                    </cc1:FilteredTextBoxExtender>
                                    <cc1:CalendarExtender ID="txtDate1_CalendarExtender" runat="server" Format="dd/MM/yyyy" PopupButtonID="txtDate" TargetControlID="txtDate">
                                    </cc1:CalendarExtender>
                                    <asp:CompareValidator id="cvtxtStartDate" runat="server" controltocompare="txtFechaCom" 
                                        cultureinvariantvalues="true" display="Dynamic" 
                                        enableclientscript="true" controltovalidate="txtDate"
                                        errormessage="La fecha de resolución no puede ser menor o igual a la del mes anterior"
                                         type="Date" setfocusonerror="true" operator="GreaterThan" text="La fecha de resolución no puede ser menor o igual a la del mes anterior" ValidationGroup="ValRegistro"/>
                                </td>
                                <td align="right">&nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right" >&nbsp;</td>
                                <td align="right" >&nbsp;</td>
                                <td align="right" >
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right"  ></td>
                                <td align="left"  >
                                    <asp:CheckBox ID="chbEstado" runat="server" Checked="True" CssClass="etiqueta8Blue" Text="Activar" />
                                </td>
                                <td align="right"  ></td>
                            </tr>

                            <tr>
                                <td align="right" style="width: 25%">
                                    <asp:Label ID="lblFechaR" runat="server" Text="lblFechaR" Visible="false"></asp:Label>
                                </td>
                                <td align="right" style="width: 25%">
                                    <asp:Button ID="btnAccionar" runat="server" CssClass="boton150" OnClick="btnAccionar_Click" Text="Adicionar" CausesValidation="true" ValidationGroup="ValRegistro"/>
                                    <cc1:ConfirmButtonExtender ID="btnGrabar_ConfirmButtonExtender" runat="server" TargetControlID="btnAccionar" ConfirmText="¿Esta seguro de guardar/modificar el registro?"> 
                                    </cc1:ConfirmButtonExtender>
                                </td>
                                <td align="left" style="width: 10%">
                                    <asp:Button ID="btnCancelar" runat="server"  CausesValidation="false"  CssClass="boton150" EnableTheming="True" OnClick="btnCancelar_Click" Text="Cancelar" />
                                </td>
                            </tr>

                        </table>

                    </div>
                </asp:Panel>
                <%--  <cc1:ModalPopupExtender ID="pnlDatos_ModalPopupExtender" runat="server" Enabled="True" TargetControlID="pnlDatos">
                </cc1:ModalPopupExtender>--%>
                <cc1:RoundedCornersExtender ID="pnlDatos_RoundedCornersExtender" runat="server"
                    Enabled="True" TargetControlID="pnlDatos" Radius="10" BorderColor="Black">
                </cc1:RoundedCornersExtender>
                <cc1:ModalPopupExtender ID="pnlDatos_ModalPopupExtender" runat="server"
                    Enabled="True"
                    TargetControlID="lblTitulo"
                    CancelControlID="btnCancelar"
                    PopupControlID="pnlDatos"
                    BackgroundCssClass="modalBackground">
                </cc1:ModalPopupExtender>
            </td>
        </tr>

    </table>
</asp:Content>

