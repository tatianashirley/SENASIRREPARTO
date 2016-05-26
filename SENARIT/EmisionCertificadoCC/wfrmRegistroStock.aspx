<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmRegistroStock.aspx.cs" 
    Inherits="EmisionCertificadoCC_wfrmRegistroStock" StylesheetTheme="Modal" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .cssHeaderImg {
            background-image: url(../Imagenes/Menu5.png);
        }
        .auto-style5 {
            width: 18%;
        }
        .auto-style6 {
            border: thin solid #6699FF;
            background-color: #F0F8FF;
            elevation: higher;
            width: 16%;
        }
        .auto-style7 {
            width: 16%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%;" class="panelceleste">
        <tr>
            <td align="center">
                <asp:ImageButton ID="imgAux" runat="server" ImageUrl="~/Imagenes/16w.png" />
                <asp:Label ID="lblTituloAUX" runat="server" Text="STOCK DECERTIFICADOS CC" CssClass="etiqueta20"></asp:Label>
                <asp:Label ID="lblCodigo" runat="server" Font-Size="Small" Text="1" Visible="False"></asp:Label>
                <asp:Label ID="lblCodUsuario" runat="server" Font-Size="Small" Text="1" Visible="False"></asp:Label>
                <asp:Label ID="lblRol" runat="server" Font-Size="Small" Style="text-align: left" Text="0" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlGV" runat="server" HorizontalAlign="Center" Width="100%"
                    CssClass="panelceleste">
                    <table style="width: 100%;">
                        <tr>
                            <td class="auto-style7">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td  colspan="2"  align="center">
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
                            <td align="center" class="auto-style6">
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
                            <td align="right" valign="top" class="panelceleste">
                                <asp:RadioButtonList ID="rbTipoMuestra" runat="server" RepeatDirection="Horizontal" TextAlign="Left" OnSelectedIndexChanged="rbTipoMuestra_SelectedIndexChanged"
                                Width="200px" AutoPostBack="True" CssClass="etiqueta8">
                                    <asp:ListItem Value="1">Todos</asp:ListItem>
                                    <asp:ListItem Selected="True" Value="2">Solo Activos</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>

                        </tr>
                        <tr>
                            <td colspan="2" class="panelceleste">
                                <asp:GridView ID="gvStock" runat="server"
                                    AllowPaging="True"
                                    AutoGenerateColumns="false"
                                    HorizontalAlign="Center"
                                    SkinID="GridView"
                                    OnRowDataBound="gvStock_RowDataBound" Width="100%"
                                    OnRowCommand="gvStock_RowCommand"
                                    PageIndex="10"
                                    OnPageIndexChanging="gvDatos_PageIndexChanging" DataKeyNames="PartidaLote">

                                    <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />

                                    <Columns>

                                        <asp:BoundField DataField="Fecha" HeaderText="Fecha" ItemStyle-Width="11%" >
                                        <ItemStyle Width="11%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DescripcionDetalleClasificador" HeaderText="Certificado" ItemStyle-Width="15%"  >
                                        <ItemStyle Width="15%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="NumeroInicial" HeaderText="N° Inicial" ItemStyle-Width="10%"  >
                                        <ItemStyle Width="10%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Numerofinal" HeaderText="N° Final" ItemStyle-Width="10%" >
                                        <ItemStyle Width="10%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" ItemStyle-Width="10%">
                                        <ItemStyle Width="10%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Saldo" HeaderText="Saldo Stock" ItemStyle-Width="10%" >
                                        <ItemStyle Width="10%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Observacion" HeaderText="Observacion"  ItemStyle-Width="12%">
                                        <ItemStyle Width="12%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="RegistroActivo" HeaderText="Activo" Visible="false"  />
                                        <asp:BoundField DataField="PartidaLote" HeaderText="Activo" ItemStyle-Width="5%" Visible="false">
                                        <ItemStyle Width="5%" />
                                        </asp:BoundField>
                                   <asp:TemplateField HeaderText="Activo">
                                       <ItemStyle Width="4%"  HorizontalAlign="Center" />
                                       <ItemTemplate>
                                           <asp:image ID="ImgEstado" runat="server" ImageUrl="" />
                                       </ItemTemplate>
                                   </asp:TemplateField>                                        
                                        <asp:TemplateField HeaderText="Eliminar"  HeaderStyle-HorizontalAlign="Center"> 
                                    <HeaderStyle Width="70px" HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemTemplate>
                                <center>
                                    <asp:ImageButton ID="imgEliminar" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex  %>' CommandName="cmdEliminar" ImageUrl="~/Imagenes/16eliminar.png" Height="16" Width="16" ToolTip="Eliminar Registro" />
                                </center>
                            </ItemTemplate>
                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Modificar"  HeaderStyle-HorizontalAlign="Center"> 
                                    <HeaderStyle Width="70px" HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemTemplate>
                                <center>
                                    <asp:ImageButton ID="imgEditar" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex  %>' CommandName="cmdEditar" ImageUrl="~/imagenes/16modificar.png" Height="16" Width="16" ToolTip="Editar Registro" />
                                </center>
                            </ItemTemplate>
                        </asp:TemplateField>
                                    </Columns>
                                    <RowStyle HorizontalAlign="Center" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="left">
                                <asp:Label ID="lblcolor" runat="server" CssClass="etiqueta8" BackColor="DodgerBlue" Text="AGOTADO"></asp:Label>
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
                        <asp:Label ID="lblTitulo" runat="server" Text="Adicionar Stock de Correlativos"
                            CssClass="etiqueta20"></asp:Label>
                        <table style="width: 100%;">
                            <tr>
                                <td align="right" style="width: 25%"></td>
                                <td align="right" style="width: 25%">&nbsp;</td>
                                <td align="right" style="width: 25%">&nbsp;</td>
                                <td align="right" style="width: 25%">&nbsp;</td>
                            </tr>

                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblFecha" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="Fecha :"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblFechaReg" runat="server" CssClass="etiqueta10" Style="text-align: left"></asp:Label>
                                </td>

                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>

                            </tr>

                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblTipoCetificado" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="Tipo Certificado :"></asp:Label>
                                </td>
                                <td align="left" colspan="3">
                                    <asp:DropDownList ID="ddlTipoCertificado" runat="server" Width="167px" Height="16px">
                                    </asp:DropDownList>
                                </td>


                            </tr>

                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblcantidad" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="Cantidad de certificados :"></asp:Label>
                                </td>
                                <td align="left" colspan="3">
                                    <asp:TextBox ID="txtCantidad" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCantidad" ErrorMessage="*" ValidationGroup="ValStock"/>
                                    <cc1:FilteredTextBoxExtender ID="txtCantidad_FilteredTextBoxExtender" runat="server" Enabled="True" TargetControlID="txtCantidad" FilterType="Numbers">
                                    </cc1:FilteredTextBoxExtender>
                                </td>
                            </tr>

                            <tr>
                                <td align="right">
                                      <asp:Label ID="lblInicial" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="Numero Inicial:"></asp:Label>
                                </td>
                                <td align="left" style="width: 25%">  
                                    <asp:TextBox ID="txtNumInicial" runat="server" ></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" Enabled="True" TargetControlID="txtNumInicial" FilterType="Numbers">
                                    </cc1:FilteredTextBoxExtender>
                                 </td>
                                <td align="right"> 
                                     <asp:Label ID="lblFinal" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="Numero Final:"></asp:Label>
                                </td>
                                <td align="left"> <asp:TextBox ID="txtNumFinal" runat="server" ></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" Enabled="True" TargetControlID="txtNumFinal" FilterType="Numbers">
                                    </cc1:FilteredTextBoxExtender>
                                 </td>
                            </tr>

                           

                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblObservacion" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="Observacion:"></asp:Label>
                                </td>
                                <td align = "left" colspan="3">
                                    <asp:TextBox ID = "txtObservacion" runat="server" MaxLength="500" Width="478px" TextMode="MultiLine" Height="43px" Columns="50" Rows="3" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID = "RequiredFieldValidator2" runat="server" ControlToValidate="txtObservacion" ErrorMessage="*" ValidationGroup="ValStock"/>
                                    <cc1:FilteredTextBoxExtender ID= "FilteredTextBoxExtender3" runat="server" Enabled="True" TargetControlID="txtObservacion" FilterType="Numbers, UppercaseLetters, LowercaseLetters,Custom" ValidChars="\|@ª!~♀Çüä?¿~€¬ ">
                                    </cc1:FilteredTextBoxExtender>
                                </td>


                            </tr>

                            <tr>
                                <td align="right"></td>
                                <td align="left">
                                    <asp:CheckBox ID="chbEstado" runat="server" Checked="True" CssClass="etiqueta8Blue" Text="Activar" />
                                </td>
                                <td align="left">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                            </tr>

                            <tr>
                                <td align="right" style="width: 26%">&nbsp;</td>
                                <td align="right">&nbsp;</td>
                                <td align="right" style="width: 25%">
                                    <asp:Button ID="btnAccionar" runat="server" CssClass="boton150" OnClick="btnAccionar_Click" Text="Adicionar" ValidationGroup="ValStock" CausesValidation="true"/>
                                    <cc1:ConfirmButtonExtender ID="btnGrabar_ConfirmButtonExtender" runat="server" TargetControlID="btnAccionar" ConfirmText="¿Esta seguro de guardar/modificar el registro?"> 
                                    </cc1:ConfirmButtonExtender>
                                </td>
                                <td align="left" style="width: 25%">
                                    <asp:Button ID="btnCancelar" runat="server" CssClass="boton150" EnableTheming="True" OnClick="btnCancelar_Click" Text="Cancelar" CausesValidation="false"/>
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

