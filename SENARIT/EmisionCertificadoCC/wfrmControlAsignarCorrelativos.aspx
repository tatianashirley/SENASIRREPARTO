<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmControlAsignarCorrelativos.aspx.cs" Inherits="EmisionCertificadoCC_wfrmControlAsignarCorrelativos" StylesheetTheme="Modal" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .cssHeaderImg {
            background-image: url(../Imagenes/Menu5.png);
        }
       
        .auto-style5 {
            width: 20%;
        }
        .auto-style6 {
            border: thin solid #6699FF;
            background-color: #F0F8FF;
            elevation: higher;
            line-height: inherit;
            width: 20%;
        }
       
    </style>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%;" class="panelceleste">
        <tr>
            <td align="center">
                <asp:ImageButton ID="imgAux" runat="server" ImageUrl="~/Imagenes/16w.png" />
                <asp:Label ID="lblTituloAUX" runat="server" Text="Asignar Certificados a Oficinas" CssClass="etiqueta20"></asp:Label>
                <asp:Label ID="lblCodigo" runat="server" Font-Size="Small" Text="1" Visible="False"></asp:Label>
                <asp:Label ID="lblCodUsuario" runat="server" Font-Size="Small" Text="1" Visible="False"></asp:Label>
                <asp:Label ID="lblRol" runat="server" Font-Size="Small" Style="text-align: left" Text="0" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlGV" runat="server" HorizontalAlign="Center" Width="100%" CssClass="panelceleste">
                    <table style="width: 100%;">
                        <tr>
                            <td align="right" style="width: 20%">&nbsp;</td>
                            <td align="left" class="auto-style5">&nbsp;</td>
                            <td align="left" style="width: 60%"></td>
                        </tr>
                           <tr>
                               <td colspan="2">
                                   <asp:Panel ID="pnlInformacion" runat="server" CssClass="panelceleste" Width="80%">
                                       <table style="width: 100%;">
                                           <tr>
                                               <td align="center">
                                                   <asp:Label ID="lblInfor" runat="server" CssClass="etiqueta8Blue" Style="text-align: left" Text="INFORMACION DE STOCK:"></asp:Label>
                                               </td>
                                           </tr>
                                           <tr>
                                               <td align="center">
                                                   <asp:GridView ID="gvSaldos" runat="server"  SkinID="GridView" AutoGenerateColumns="False" EnableModelValidation="True">

                                                       <Columns>
                                                           <asp:BoundField  DataField="descripcion"  />
                                                           <asp:BoundField  DataField="saldo" HeaderText="Saldo"   />
                                                         </Columns>
                                                      </asp:GridView>
                                                   </td>
                                           </tr>
                                       </table>
                                   </asp:Panel>
                               </td>
                               <td  >
                                   <asp:Label ID="lblOficinacom" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="Oficina :"></asp:Label>
                                   <asp:DropDownList ID="ddlOficinacom" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlOficinacom_SelectedIndexChanged" Width="450px">
                                   </asp:DropDownList>
                                  
                               </td>
                        </tr>
                        <tr>
                            <td colspan="3">
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
                            <td align="center" class="panelceleste" >
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
                           <td align="center" valign="top" class="auto-style6">
                               <asp:CheckBox ID="ckAgotado" runat="server"  Checked="false" CssClass="etiqueta8Blue" Text="Mostrar Agotados"  AutoPostBack="True" OnCheckedChanged="ckAgotado_CheckedChanged"/>
                            </td>
                        </tr>
                      
                        <tr>
                            <td colspan="3" class="panelceleste">
                                <asp:GridView ID="gvCorrelativo" runat="server"
                                    AllowPaging="True"
                                    AutoGenerateColumns="false"
                                    HorizontalAlign="Center"
                                    SkinID="GridView"
                                    OnPageIndexChanging="gvDatos_PageIndexChanging"
                                    OnRowDataBound="gvCorrelativo_RowDataBound"
                                    OnRowCommand="gvCorrelativo_RowCommand" DataKeyNames="NumeroAsignacion"
                                     Width="100%"
                                    PageSize="10"
                                    PagerStyle-CssClass="pgr">

                                    <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />

                                    <Columns>
                                         <asp:BoundField  HeaderText="Stock" ItemStyle-Width="8%" ItemStyle-Font-Bold="true" ItemStyle-BorderColor="Black"/>
                                        <asp:BoundField DataField="Oficina" HeaderText="Oficina" ItemStyle-Width="15%" />
                                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" ItemStyle-Width="5%"/>
                                        <asp:BoundField DataField="NumeroInicial" HeaderText="N° Inicio" ItemStyle-Width="5%" />
                                        <asp:BoundField DataField="NumeroFinal" HeaderText="N° Fin" ItemStyle-Width="5%"/>
                                        <asp:BoundField DataField="UltimoNumeroAplicado" HeaderText="Valor Actual" ItemStyle-Width="5%"/>
                                        <asp:BoundField DataField="Saldo" HeaderText="Saldo" ItemStyle-Width="5%"/>
                                        <asp:BoundField DataField="TipoCertificado" HeaderText="Tipo Certificado" ItemStyle-Width="10%" ItemStyle-Font-Bold="true" ItemStyle-BackColor="Gray" ItemStyle-ForeColor="White" ItemStyle-BorderColor="Black"/>
                                        <asp:BoundField DataField="FechaAsignacion" HeaderText="F. Asignacion" ItemStyle-Width="10%"/>
                                        <asp:BoundField DataField="FechaEnvio" HeaderText="F. Envio" ItemStyle-Width="10%" />
                                        <asp:BoundField DataField="Observacion" HeaderText="Observacion" ItemStyle-Width="25%"/>
                                        <asp:BoundField DataField="RegistroActivo" HeaderText="Activo" Visible="false" ItemStyle-Width="3%"/>
                                        <asp:BoundField DataField="NumeroAsignacion" HeaderText="Activo" ItemStyle-Width="3%" Visible="false"/>
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
                                <EmptyDataTemplate>
                                    <div align="center" class="CajaDialogoAdvertencia">
                                    <br/>
                                    <img src="../Imagenes/warning.gif" alt="No Existeen Documentos por Notificar" />
                                    <br/>No Existen Asignaciones para esta Oficina<br/><br/>
                                    </div>
                                </EmptyDataTemplate>
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
                        <asp:Label ID="lblTitulo" runat="server" Text="Asignar Correlativos a Oficinas"
                            CssClass="etiqueta20"></asp:Label>
                        <table style="width: 100%;">
                            <tr>
                                <td align="right" class="auto-style8"></td>
                                <td align="right" class="auto-style9"></td>
                                <td align="right" class="auto-style10"></td>
                                <td align="right" class="auto-style11"></td>
                            </tr>

                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblFechaAsignacion" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="Fecha Asignacion :"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtFechaReg" runat="server" CssClass="etiqueta10" Style="text-align: left" Enabled="false" Height="16px" Width="116px"></asp:TextBox>
                                </td>

                                <td align="left" colspan="2">
                                    <asp:Label ID="lblFechaEnvio" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="Fecha Envio :"></asp:Label>
                                    <asp:TextBox ID="txtDate" runat="server" Height="16px" Width="116px" MaxLength="10"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDate" ErrorMessage="*" ValidationGroup="ValAsignacion"
                                        Font-Size="9pt" Font-Names="Arial"/>
                                    <asp:CompareValidator id="cvtxtStartDate" runat="server" controltocompare="txtFechaReg" ValidationGroup="ValAsignacion" Font-Size ="9pt" Font-Names="Arial"
                                        cultureinvariantvalues="true" display="Dynamic" 
                                        enableclientscript="true" controltovalidate="txtDate"
                                        errormessage=""
                                         type="Date" setfocusonerror="true" operator="GreaterThanEqual" text="Fecha de Envío no puede ser menor a la de Registro"/>
                                      <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationGroup="ValAsignacion" runat="server" ControlToValidate="txtDate" Display="Dynamic" ErrorMessage="dd/mm/aaaa" ValidationExpression="^([\d]{2})/([\d]{2})/([\d]{4})$"
                                        Font-Size="9pt" Font-Names="Arial">
                                      </asp:RegularExpressionValidator>
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server"
                                        TargetControlID="txtDate"
                                        Format="dd/MM/yyyy"
                                        PopupButtonID="txtDate">
                                    </cc1:CalendarExtender>
                                </td>
                                <td align="left">
                                    
                                </td>

                            </tr>

                            <tr>
                                <td align="right">&nbsp;</td>
                                <td align="left" colspan="3">&nbsp;</td>


                            </tr>

                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblTipoCetificado" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="Tipo Certificado :"></asp:Label>
                                </td>
                                <td align="left" colspan="3">
                                    <asp:DropDownList ID="ddlTipoCertificado" runat="server" Width="420px">
                                    </asp:DropDownList>
                                </td>
                            </tr>

                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblOficina" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="Oficina :"></asp:Label>
                                </td>
                                <td align="left" colspan="3">
                                    <asp:DropDownList ID="ddlOficina" runat="server" Width="420px">
                                    </asp:DropDownList>
                                </td>

                            </tr>

                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblNumInicial0" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="Cantidad:"></asp:Label>
                                </td>
                                <td align="left" style="width: 25%">
                                    <asp:TextBox ID="txtCantidad" runat="server" MaxLength="4"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCantidad" ErrorMessage="*" Font-Size="9pt" Font-Names="Arial" ValidationGroup="ValAsignacion"/>
                                    <cc1:FilteredTextBoxExtender ID="txtCantidad_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtCantidad">
                                    </cc1:FilteredTextBoxExtender>
                                </td>
                                <td align="right">
                                    &nbsp;</td>
                                <td align="left">
                                    &nbsp;</td>
                            </tr>

                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblNumInicial" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="Numero Inicial :"></asp:Label>
                                </td>
                                <td align="left" style="width: 25%">
                                    <asp:TextBox ID="txtNumInicial" runat="server"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtNumInicial_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtNumInicial">
                                    </cc1:FilteredTextBoxExtender>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblNumFinal" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="Numero Final :"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtNumFinal" runat="server" Height="16px" Width="110px"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtNumFinal_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtNumFinal">
                                    </cc1:FilteredTextBoxExtender>
                                </td>
                            </tr>

                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblObservacion" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="Observacion:"></asp:Label>
                                </td>
                                <td align="left" colspan="3">
                                    <asp:TextBox ID="txtObservacion" runat="server" MaxLength="500" Width="410px" TextMode="MultiLine" Columns="40" Rows="4" onkeyup="this.value=this.value.toUpperCase()" ></asp:TextBox>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtObservacion" ErrorMessage="*" Font-Size="9pt" Font-Names="Arial" ValidationGroup="ValAsignacion"/>--%>
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
                                <td align="right" style="width: 25%">&nbsp;</td>
                                <td align="right">&nbsp;</td>
                                <td align="right" style="width: 25%">
                                    <asp:Button ID="btnAccionar" runat="server" CssClass="boton150" OnClick="btnAccionar_Click" Text="Adicionar" CausesValidation="true" ValidationGroup="ValAsignacion"/>
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

