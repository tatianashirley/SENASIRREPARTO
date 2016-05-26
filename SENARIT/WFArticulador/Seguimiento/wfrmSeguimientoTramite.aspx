<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmSeguimientoTramite.aspx.cs" Inherits="SeguimientoTramite_SeguimientoTramite" StylesheetTheme="Modal" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="FondoAplicacion">
        <table width="100%" border="0" cellpadding="false" cellspacing="false">
            <tr>
                <td width="20%">
                    <asp:Label ID="lblTituloSistema" runat="server" Font-Bold="True" ForeColor="Navy"></asp:Label>
                </td>
                <td width="60%" align="center">
                    <asp:Label ID="lblSubTitulo" runat="server" Font-Bold="True" ForeColor="#CC0000" Font-Size="17px"></asp:Label>
                </td>
                <td align="right" width="20%">
                    <asp:Label ID="lblTipo" runat="server" ForeColor="#CC0000" Visible="false"></asp:Label>
                    <asp:HiddenField runat="server" ID="hfTramite" />
                </td>
            </tr>
        </table>
    </div>
    <table width="100%" border="0" cellpadding="false" cellspacing="false">
        <tr>
            <td align="left" class="divContenedor" style="margin-left: 80px">
                <asp:Panel ID="Panel1" runat="server" class="panelsecundario" Font-Size="11pt">
                    <label onclick="ibtnOpenCloseRegistro_Click" style="color: white">
                        <asp:ImageButton ID="ibtnOpenCloseRegistro" runat="server" ImageUrl="~/Imagenes/16quitar.png" OnClick="ibtnOpenCloseRegistro_Click" />
                        INFORMACIÓN GENERAL
                    </label>
                </asp:Panel>
                <asp:Panel ID="pnlRegistro" runat="server" Visible="true" CssClass="panelprincipal">
                    <table width="100%">
                        <tr>
                            <td align="right" width="15%">
                                <asp:Label runat="server" ID="Label3" CssClass="etiqueta10">Número Trámite:</asp:Label>
                            </td>
                            <td align="left" width="15%">
                                <asp:TextBox runat="server" ID="txtIdTramite" Width="200px" ReadOnly="true"></asp:TextBox>
                            </td>
                            <td align="right" width="15%">
                                <asp:Label runat="server" ID="Label1" CssClass="etiqueta10">Número Trámite Antiguo: </asp:Label>
                            </td>
                            <td align="left" width="15%">
                                <asp:TextBox runat="server" ID="txtTramiteCrenta" Width="200px" ReadOnly="true"></asp:TextBox>
                            </td>
                            <td align="right" width="15%">
                                <asp:Label runat="server" ID="Label2" CssClass="etiqueta10">Estado Trámite</asp:Label>
                            </td>
                            <td align="left" width="15%">
                                <asp:TextBox runat="server" ID="txtEstadoTramite" Width="200px" ReadOnly="true"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="15%">
                                <asp:Label runat="server" ID="lblPrimerApellido" CssClass="etiqueta10">Primer Apellido:</asp:Label>
                            </td>
                            <td align="left" width="15%">
                                <asp:TextBox runat="server" ID="txtPrimerApellido" Width="200px" ReadOnly="true"></asp:TextBox>
                            </td>
                            <td align="right" width="15%">
                                <asp:Label runat="server" ID="lblSegundoApellido" CssClass="etiqueta10">Segundo Apellido:</asp:Label>
                            </td>
                            <td align="left" width="15%">
                                <asp:TextBox runat="server" ID="txtSegundoApellido" Width="200px" ReadOnly="true"></asp:TextBox>
                            </td>
                            <td align="right" width="15%">
                                <asp:Label runat="server" ID="lblApellidoCasada" CssClass="etiqueta10">Apellido Casada:</asp:Label>
                            </td>
                            <td align="left" width="15%">
                                <asp:TextBox runat="server" ID="txtApellidoCasada" Width="200px" ReadOnly="true"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label runat="server" ID="lblPrimerNombre" CssClass="etiqueta10">Primer Nombre:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox runat="server" ID="txtPrimerNombre" Width="200px" ReadOnly="true"></asp:TextBox>
                            </td>
                            <td align="right">
                                <asp:Label runat="server" ID="lblSegundoNombre" CssClass="etiqueta10">Segundo Nombre:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox runat="server" ID="txtSegundoNombre" Width="200px" ReadOnly="true"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label runat="server" ID="lblTipoDocumento" CssClass="etiqueta10">Tipo Documento:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox runat="server" ID="txtTipoDocumento" Width="200px" ReadOnly="true"></asp:TextBox>
                            </td>
                            <td align="right">
                                <asp:Label runat="server" ID="lblNumeroDocumento" CssClass="etiqueta10">Número Documento:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtNumeroDocumento" runat="server" MaxLength="20" ReadOnly="true"></asp:TextBox>
                                <asp:TextBox ID="txtComplemento" runat="server" Width="29px" MaxLength="2" ReadOnly="true"></asp:TextBox>
                            </td>
                            <td align="right">
                                <asp:Label runat="server" ID="lblExpedido" CssClass="etiqueta10">Expedido:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtExpedicion" runat="server" MaxLength="20" ReadOnly="true"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label runat="server" ID="lblAFP" CssClass="etiqueta10">AFP:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtAFP" ReadOnly="true"></asp:TextBox>
                            </td>
                            <td align="right">
                                <asp:Label runat="server" ID="lblCUA" CssClass="etiqueta10">CUA:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox runat="server" ID="txtCUA" ReadOnly="true"></asp:TextBox>
                            </td>
                            <td align="right">
                                <asp:Label runat="server" ID="lblMatricula" CssClass="etiqueta10">Matrícula:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox runat="server" ID="txtMatricula" ReadOnly="true"></asp:TextBox>
                            </td>
                            <tr>
                                <td align="right">
                                    <asp:Label runat="server" ID="lblSexo" CssClass="etiqueta10">Sexo:</asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox runat="server" ID="txtSexo" ReadOnly="true" />
                                </td>
                                <td align="right">
                                    <asp:Label runat="server" ID="lblEstadoCivil" CssClass="etiqueta10">Estado Civil:</asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox runat="server" ID="txtEstadoCivil" ReadOnly="true" />
                                </td>
                            </tr>

                            <tr>
                                <td align="right">
                                    <asp:Label runat="server" ID="lblFechaNacimiento" CssClass="etiqueta10">Fecha Nacimiento:</asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox runat="server" ID="txtFechaNacimiento" ToolTip="DD/MM/YYYY" ReadOnly="true"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label runat="server" ID="lblFechaFallecimiento" CssClass="etiqueta10">Fecha Defunción:</asp:Label></td>
                                <td align="left">
                                    <asp:TextBox runat="server" ID="txtFechaFallecimient" ToolTip="DD/MM/YYYY" ReadOnly="true"></asp:TextBox>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="Panel2" runat="server" class="panelsecundario" Font-Size="11pt">
                    <label onclick="ibtnOpenCloseDatosResidencia_Click" style="color: white">
                        <asp:ImageButton ID="ibtnOpenCloseDatosResidencia" runat="server" ImageUrl="~/Imagenes/16quitar.png" OnClick="ibtnOpenCloseDatosResidencia_Click" />
                        INFORMACIÓN DETALLE
                    </label>
                </asp:Panel>
                <asp:Panel ID="pnlDatosResidencia" runat="server" Visible="true" CssClass="panelprincipal">
                    <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0">



                        <cc1:TabPanel ID="TabPanel1" runat="server" HeaderText="Referencia">
                            <ContentTemplate>
                                <asp:Panel ID="Panel6" runat="server" Visible="true" CssClass="panelprincipal">
                                    <table width="100%">
                                        <tr>
                                            <td align="right" width="10%">
                                                <asp:Label runat="server" ID="lblLocalidad" CssClass="etiqueta10">País:</asp:Label>
                                            </td>
                                            <td align="left" width="10%">
                                                <asp:TextBox runat="server" ID="txtPais" Width="200px" Height="16px" MaxLength="50" ReadOnly="true">BOLIVIA</asp:TextBox>
                                            </td>
                                            <td align="right" width="15%">
                                                <asp:Label runat="server" ID="Label10" CssClass="etiqueta10">Localidad:</asp:Label>
                                            </td>
                                            <td align="left" width="25%">
                                                <asp:TextBox ID="txtLocalidad" runat="server" Width="200px" MaxLength="50" ReadOnly="true"></asp:TextBox>
                                            </td>
                                            <td align="right" width="10%">
                                                <asp:Label runat="server" ID="lblDireccion" CssClass="etiqueta10">Dirección:</asp:Label>
                                            </td>
                                            <td align="left" width="30%">
                                                <asp:TextBox runat="server" ID="txtDireccion" Width="300px" MaxLength="100" ReadOnly="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label runat="server" ID="lblTelefono" CssClass="etiqueta10">Teléfono Fijo:</asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox runat="server" ID="txtTelefono" Width="67px" ToolTip="(Longitud 7 Digitos)" MaxLength="7" ReadOnly="true"></asp:TextBox>
                                            </td>
                                            <td align="right" class="auto-style57">
                                                <asp:Label runat="server" ID="lblCelular" CssClass="etiqueta10">Teléfono Celular:</asp:Label></td>
                                            <td align="left" class="auto-style58">
                                                <asp:TextBox runat="server" ID="txtCelular" Width="74px" ToolTip="(Longitud 8 Digitos , Primer digito 6 o 7)" MaxLength="8" ReadOnly="true"></asp:TextBox>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblEmail" runat="server" CssClass="etiqueta10">E-Mail:</asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtEmail" runat="server" Width="300px" ToolTip="(Ej. xxx@gmail.com)" ReadOnly="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label runat="server" ID="Label4" CssClass="etiqueta10"></asp:Label>
                                            </td>
                                            <td align="left">&nbsp;
                                            </td>
                                            <td align="right" class="auto-style57">
                                                <asp:Label runat="server" ID="Label5" CssClass="etiqueta10">Teléfono Referencia:</asp:Label>
                                                <td align="left" class="auto-style58">
                                                    <asp:TextBox runat="server" ID="txtCelularReferencia" Width="74px" ToolTip="(Longitud 8 Digitos , Primer digito 6 o 7)" MaxLength="8" ReadOnly="true"></asp:TextBox>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="Label6" runat="server" CssClass="etiqueta10"></asp:Label>
                                                </td>
                                                <td align="left">&nbsp;
                                                </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </ContentTemplate>
                        </cc1:TabPanel>

                        <cc1:TabPanel ID="TabPanel4" runat="server" HeaderText="Datos Trámite">
                            <ContentTemplate>
                                <asp:Panel ID="Panel4" runat="server" Visible="true" CssClass="panelprincipal">
                                    <table width="100%">
                                        <tr>
                                            <td align="right" width="10%">
                                                <asp:Label runat="server" ID="Label7" CssClass="etiqueta10">Regional:</asp:Label>
                                            </td>
                                            <td align="left" width="10%">
                                                <asp:TextBox runat="server" ID="txtRegional" Width="200px" Height="16px" MaxLength="50" ReadOnly="true"></asp:TextBox>
                                            </td>
                                            <td align="right" width="15%">
                                                <asp:Label runat="server" ID="Label8" CssClass="etiqueta10">Tipo Trámite:</asp:Label>
                                            </td>
                                            <td align="left" width="25%">
                                                <asp:TextBox ID="txtTipoTramite" runat="server" Width="200px" MaxLength="50" ReadOnly="true"></asp:TextBox>
                                            </td>
                                            <td align="right" width="10%">
                                                <asp:Label runat="server" ID="Label9" CssClass="etiqueta10">Área Actual:</asp:Label>
                                            </td>
                                            <td align="left" width="30%">
                                                <asp:TextBox runat="server" ID="txtAreaActual" Width="300px" MaxLength="100" ReadOnly="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="auto-style57">
                                                <asp:Label runat="server" ID="Label15" CssClass="etiqueta10">Fecha Inicio Tramite:</asp:Label>
                                                <td align="left" class="auto-style58">
                                                    <asp:TextBox runat="server" ID="txtInicioTramite" Width="200px" ReadOnly="true"></asp:TextBox>
                                                </td>

                                                <td align="right" class="auto-style57">
                                                    <asp:Label runat="server" ID="Label12" CssClass="etiqueta10">Estado Expediente:</asp:Label></td>
                                                <td align="left" class="auto-style58">
                                                    <asp:TextBox runat="server" ID="txtEstadoExpediente" Width="200px" ReadOnly="true"></asp:TextBox>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="Label13" runat="server" CssClass="etiqueta10">Sector:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtSector" runat="server" Width="200px" ReadOnly="true"></asp:TextBox>
                                                </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label runat="server" ID="Label11" CssClass="etiqueta10">Fecha Ingreso:</asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox runat="server" ID="txtFechaIngreso" Width="200px" ReadOnly="true"></asp:TextBox>
                                            </td>
                                            <td align="right">
                                                <asp:Label runat="server" ID="Label14" CssClass="etiqueta10">Funcionario:</asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox runat="server" ID="txtFuncionario" Width="200px" ReadOnly="true"></asp:TextBox>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="Label16" runat="server" CssClass="etiqueta10">Fecha Tentativa:</asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox runat="server" ID="txtFechaTentativa" Width="200px" ReadOnly="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </ContentTemplate>
                        </cc1:TabPanel>

                        <cc1:TabPanel ID="TabPanel3" runat="server" HeaderText="Seguimiento">
                            <ContentTemplate>
                                <asp:Panel ID="Panel3" runat="server" Visible="true" CssClass="panelprincipal">
                                    <table width="100%">
                                        <tr>
                                            <td align="center">
                                                <asp:GridView ID="gvSeguimiento" runat="server" EnableModelValidation="True"
                                                    CellPadding="4" ForeColor="#333333" EnableTheming="True" Font-Names="Arial" Font-Size="9pt"
                                                    CssClass="mGrid" PagerStyle-CssClass="pgr" GridLines="None" AutoGenerateColumns="False" OnRowCommand="gvSeguimiento_RowCommand" OnRowDataBound="gvSeguimiento_RowDataBound"
                                                    DataKeyNames="IdTramite,ObsSalidaArea,FechaSalida" SkinID="GridView" AlternatingRowStyle-CssClass="alt">
                                                    <Columns>
                                                        <asp:BoundField DataField="Matricula" HeaderText="Matrícula" Visible="false" />
                                                        <asp:BoundField DataField="AreaDestino" HeaderText="Área Destino" />
                                                        <asp:BoundField DataField="UsuarioDestino" HeaderText="Usuario Destino" />
                                                        <asp:BoundField DataField="FechaIngreso" HeaderText="Fecha Ingreso" DataFormatString="{0:d}" />
                                                        <asp:BoundField DataField="FechaSalida" HeaderText="Fecha Salida" DataFormatString="{0:d}" />
                                                        <asp:BoundField DataField="ObsSalidaArea" HeaderText="Observación" Visible="false" />
                                                        <asp:TemplateField HeaderText="Ver Observaciones">
                                                            <ItemTemplate>
                                                                <center>
                                                                    <asp:ImageButton ID="imgTramite" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdTramite" ImageUrl="~/imagenes/nueva3/siguiente32.png" />
                                                                    <asp:ImageButton ID="imgBloquear" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdBloquear" ImageUrl="~/imagenes/nueva3/bloquear32.png" />
                                                                </center>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <EmptyDataTemplate>
                                                        <div align="center" class="CajaDialogoAdvertencia">
                                                            <br />
                                                            <img src="../Imagenes/warning.gif" alt="No existen datos que correspondan al criterio especificado" />
                                                            <br />
                                                            No existen datos que correspondan al criterio especificado<br />
                                                            <br />
                                                        </div>
                                                    </EmptyDataTemplate>
                                                </asp:GridView>

                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>

                                <cc1:ModalPopupExtender ID="ModalPopupExtender_Observado" runat="server" CancelControlID="btnCancelarSalida" TargetControlID="lblObserva" PopupControlID="pnlObservado" BackgroundCssClass="modalBackground">
                                </cc1:ModalPopupExtender>
                                <asp:Panel runat="server" ID="pnlObservado" CssClass="panelceleste" Visible="false">
                                    <table align="center" cellpadding="0" cellspacing="0" width="700px">
                                        <tr>
                                            <td align="center" colspan="3">
                                                <asp:Label ID="lblObserva" runat="server"><h2>Observaciones</h2></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <asp:TextBox ID="txtObsEtapa" runat="server" Height="200px" TextMode="MultiLine" Width="500px" ReadOnly="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" align="center">
                                                <asp:Button CssClass="buttonRed" Text="Cancelar" runat="server" ID="btnCancelarSalida" />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </ContentTemplate>
                        </cc1:TabPanel>

                        <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="Datos Observaciones">
                            <ContentTemplate>
                                <asp:Panel ID="Panel7" runat="server" Visible="true" CssClass="panelprincipal">
                                    <table width="100%">
                                        <tr>
                                            <td align="right" width="5%">
                                                <label class="etiqueta10">Observaciones:</label></td>
                                            <td width="95%">
                                                <asp:TextBox ID="txtDescripcion" runat="server" Height="150px" TextMode="MultiLine" Width="99%" MaxLength="200" onkeyup="this.value=this.value.toUpperCase()" ReadOnly="true"></asp:TextBox>
                                                <cc1:FilteredTextBoxExtender ID="txtDescripcion_FilteredTextBoxExtender"
                                                    runat="server" FilterType="Custom, LowercaseLetters, UppercaseLetters,Numbers"
                                                    TargetControlID="txtDescripcion" ValidChars="'áéíóúÁÉÍÓÚñÑ.#/ ">
                                                </cc1:FilteredTextBoxExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">&nbsp;</td>
                                            <td>
                                                <label class="text_obs">Detalle observación del área actual</label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="2">
                                                <asp:Button Text="Actualizar" runat="server" ID="Button1" Visible="false" OnClick="Button1_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </ContentTemplate>
                        </cc1:TabPanel>

                        <cc1:TabPanel ID="TabPanel5" runat="server" HeaderText="Documentos Emitidos">
                            <ContentTemplate>
                                <asp:Panel ID="Panel8" runat="server" Visible="true" CssClass="panelprincipal">
                                    <cc1:TabContainer ID="TabContainer2" runat="server" ActiveTabIndex="0">
                                        <cc1:TabPanel ID="TabPanel6" runat="server" HeaderText="Certificación">
                                            <ContentTemplate>
                                                <asp:Panel ID="Panel9" runat="server" Visible="true" CssClass="panelprincipal">
                                                    <table width="100%">
                                                        <tr>
                                                            <td align="center">
                                                                <div>
                                                                    <asp:Label ID="Label17" runat="server" Text="Certificación" Visible="false"></asp:Label>
                                                                </div>
                                                                <asp:GridView ID="gvCertificacion" runat="server" EnableModelValidation="True"
                                                                    CellPadding="4" ForeColor="#333333" EnableTheming="True" Font-Names="Arial" Font-Size="9pt"
                                                                    CssClass="mGrid" PagerStyle-CssClass="pgr" GridLines="None" AutoGenerateColumns="False"
                                                                    DataKeyNames="IdTramite" SkinID="GridView" AlternatingRowStyle-CssClass="alt" OnRowCommand="gvCertificacion_RowCommand">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="IdTramite" HeaderText="Trámite" Visible="True" />
                                                                        <asp:BoundField DataField="IdGrupoBeneficio" HeaderText="Grupo" Visible="False" />
                                                                        <asp:BoundField DataField="Estado" HeaderText="Estado" />
                                                                        <asp:BoundField DataField="FechaAsignacion" HeaderText="Fecha Asignación" DataFormatString="{0:d}" />
                                                                        <asp:BoundField DataField="Rol" HeaderText="Tecnico Asignado"  />
                                                                        <asp:TemplateField HeaderText="Detalle">
                                                                            <ItemTemplate>
                                                                                <center>
                                                                                    <asp:ImageButton ID="imgDetalle" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdDetalleCertificacion" ImageUrl="~/imagenes/nueva3/siguiente32.png" ToolTip="Detalle Certificacion" />
                                                                                </center>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <EmptyDataTemplate>
                                                                        <div align="center" class="CajaDialogoAdvertencia">
                                                                            <br />
                                                                            <img src="../Imagenes/warning.gif" alt="No existen datos que correspondan al criterio especificado" />
                                                                            <br />
                                                                            No existen datos que correspondan al criterio especificado<br />
                                                                            <br />
                                                                        </div>
                                                                    </EmptyDataTemplate>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </ContentTemplate>
                                        </cc1:TabPanel>


                                        <cc1:TabPanel ID="TabPanel7" runat="server" HeaderText="Salario Cotizable">
                                            <ContentTemplate>

                                                <asp:Panel ID="Panel15" runat="server" Visible="true" CssClass="panelprincipal">
                                                    <table width="100%">
                                                        <tr>
                                                            <td align="center">
                                                                <div>
                                                                    <asp:Label ID="lblSalR" runat="server" Text="Salarios Registrados" Visible="false"></asp:Label>
                                                                </div>
                                                                <asp:GridView ID="gvSalarioR" runat="server" EnableModelValidation="True"
                                                                    CellPadding="4" ForeColor="#333333" EnableTheming="True" Font-Names="Arial" Font-Size="9pt"
                                                                    CssClass="mGrid" PagerStyle-CssClass="pgr" GridLines="None" AutoGenerateColumns="False"
                                                                    DataKeyNames="IdTramite" SkinID="GridView" AlternatingRowStyle-CssClass="alt">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="Version" HeaderText="Version" />
                                                                        <asp:BoundField DataField="RUC" HeaderText="RUC Empresa" />
                                                                        <asp:BoundField DataField="NombreEmpresa" HeaderText="Nombre Empresa" />
                                                                        <asp:BoundField DataField="Componente" HeaderText="Componente" />
                                                                        <asp:BoundField DataField="DocumentoSalario" HeaderText="Documento Salario" />
                                                                        <asp:BoundField DataField="PeriodoSalario" HeaderText="Periodo Salario" DataFormatString="{0:d}" />
                                                                        <asp:BoundField DataField="SalarioCotizable" HeaderText="Salario Cotizable" />
                                                                        <asp:BoundField DataField="EstadoSalario" HeaderText="Estado Salario" />
                                                                        <asp:BoundField DataField="NoFormularioCalculo" HeaderText="No Formulario Calculo" />
                                                                        <asp:BoundField DataField="SalarioCotizableActualizado" HeaderText="SCActualizado" />
                                                                        <asp:BoundField DataField="DensidadAportes" HeaderText="Densidad Aportes" />
                                                                        <asp:BoundField DataField="FechaAfiliacion" HeaderText="Fecha Afiliacion" DataFormatString="{0:d}" />
                                                                        <asp:BoundField DataField="FechaBajaAfilia" HeaderText="Fecha Baja Afilia" DataFormatString="{0:d}" />
                                                                    </Columns>
                                                                    <EmptyDataTemplate>
                                                                        <div align="center" class="CajaDialogoAdvertencia">
                                                                            <br />
                                                                            <img src="../Imagenes/warning.gif" alt="No existen datos que correspondan al criterio especificado" />
                                                                            <br />
                                                                            No existen datos que correspondan al criterio especificado<br />
                                                                            <br />
                                                                        </div>
                                                                    </EmptyDataTemplate>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>

                                                <asp:Panel ID="Panel10" runat="server" Visible="true" CssClass="panelprincipal">
                                                    <table width="100%">
                                                        <tr>
                                                            <td align="center">
                                                                <div>
                                                                    <asp:Label ID="lblFcAl" runat="server" Text="Formulario de Cálculo" Visible="false"></asp:Label>
                                                                </div>
                                                                <asp:GridView ID="gvSalario" runat="server" EnableModelValidation="True"
                                                                    CellPadding="4" ForeColor="#333333" EnableTheming="True" Font-Names="Arial" Font-Size="9pt"
                                                                    CssClass="mGrid" PagerStyle-CssClass="pgr" GridLines="None" AutoGenerateColumns="False"
                                                                    DataKeyNames="IdTramite,IdTipoTramite,TipoCC" SkinID="GridView" AlternatingRowStyle-CssClass="alt" OnRowCommand="gvSalario_RowCommand" OnRowDataBound="gvSalario_RowDataBound">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="IdTramite" HeaderText="IdTramite" Visible="false" />
                                                                        <asp:BoundField DataField="IdTipoTramite" HeaderText="IdTipoTramite" Visible="false" />
                                                                        <asp:BoundField DataField="NoFormularioCalculo" HeaderText="N° Formulario Calculo" />
                                                                        <asp:BoundField DataField="TipoCC" HeaderText="Tipo CC" />
                                                                        <asp:BoundField DataField="CodigoFormulario" HeaderText="Tipo Formulario" />
                                                                        <asp:BoundField DataField="EstadoCalculoCC" HeaderText="Estado Calculo CC" />
                                                                        <asp:BoundField DataField="FechaResolucionCCR" HeaderText="Fecha Resolucion CC" DataFormatString="{0:d}" />
                                                                        <asp:BoundField DataField="NoResolucionCCR" HeaderText="N° Resolucion CC" />
                                                                        <asp:BoundField DataField="FechaCalculo" HeaderText="Fecha Calculo" DataFormatString="{0:d}" />
                                                                        <asp:BoundField DataField="FechaNotificacion" HeaderText="Fecha Notificacion" DataFormatString="{0:d}" />
                                                                        <asp:BoundField DataField="FechaAceptacion" HeaderText="Fecha Aceptacion" DataFormatString="{0:d}" />
                                                                        <asp:BoundField DataField="FechaGeneracion" HeaderText="Fecha Generacion" DataFormatString="{0:d}" />
                                                                        <asp:BoundField DataField="FechaRevRR" HeaderText="Fecha de Reclamacion" DataFormatString="{0:d}" />
                                                                        <asp:TemplateField HeaderText="Reportes">
                                                                            <ItemTemplate>
                                                                                <center>
                                                                                    <asp:ImageButton ID="imgFMensual" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdMensual" ImageUrl="~/imagenes/nueva3/imprimirformulariomensual32.png" ToolTip="Formulario Mensual" Visible="false" />
                                                                                    <asp:ImageButton ID="imgFGlobal" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdGlobal" ImageUrl="~/imagenes/nueva3/imprimirformularioglobal32.png" ToolTip="Formulario Global" Visible="false" />
                                                                                </center>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <EmptyDataTemplate>
                                                                        <div align="center" class="CajaDialogoAdvertencia">
                                                                            <br />
                                                                            <img src="../Imagenes/warning.gif" alt="No existen datos que correspondan al criterio especificado" />
                                                                            <br />
                                                                            No existen datos que correspondan al criterio especificado<br />
                                                                            <br />
                                                                        </div>
                                                                    </EmptyDataTemplate>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>

                                                <asp:Panel ID="Panel14" runat="server" Visible="true" CssClass="panelprincipal">
                                                    <table width="100%">
                                                        <tr>
                                                            <td align="center">
                                                                <div>
                                                                    <asp:Label ID="lblCCC1" runat="server" Text="Certificado de Compensación de Cotizaciones" Visible="false"></asp:Label>
                                                                </div>
                                                                <asp:GridView ID="gvCertificado" runat="server" EnableModelValidation="True"
                                                                    CellPadding="4" ForeColor="#333333" EnableTheming="True" Font-Names="Arial" Font-Size="9pt"
                                                                    CssClass="mGrid" PagerStyle-CssClass="pgr" GridLines="None" AutoGenerateColumns="False"
                                                                    DataKeyNames="IdTramite,IdTipoTramite" SkinID="GridView" AlternatingRowStyle-CssClass="alt" OnRowCommand="gvCertificado_RowCommand">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="IdTramite" HeaderText="IdTramite" Visible="false" />
                                                                        <asp:BoundField DataField="IdTipoTramite" HeaderText="IdTipoTramite" Visible="false" />
                                                                        <asp:BoundField DataField="TipoCC" HeaderText="Tipo CC" />
                                                                        <asp:BoundField DataField="Tramite" HeaderText="Tramite" />
                                                                        <asp:BoundField DataField="NroCertificado" HeaderText="Nro Certificado" />
                                                                        <asp:BoundField DataField="FechaEmision" HeaderText="Fecha Emision" DataFormatString="{0:d}" />
                                                                        <asp:BoundField DataField="MontoCC" HeaderText="Monto CC" />
                                                                        <asp:BoundField DataField="FechaNotificacion" HeaderText="Fecha Notificacion" DataFormatString="{0:d}" />
                                                                        <asp:BoundField DataField="FechaImpresion" HeaderText="Fecha Impresion" DataFormatString="{0:d}" />
                                                                        <asp:BoundField DataField="EstadoCertificado" HeaderText="Estado Certificado" />
                                                                        <asp:BoundField DataField="EstadoAPS" HeaderText="Estado APS" />
                                                                        <asp:BoundField DataField="NumeroEnvio" HeaderText="Numero Envio" />
                                                                        <asp:BoundField DataField="ESTADO" HeaderText="Estado Alta" /> 
                                                                        <asp:BoundField DataField="CursoPago" HeaderText="Curso Pago" />
                                                                        <asp:TemplateField HeaderText="Reportes">
                                                                            <ItemTemplate>
                                                                                <center>
                                                                                    <asp:ImageButton ID="imgCertificacionSalario" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdCertificacionSalario" ImageUrl="~/imagenes/nueva3/certificacionsalario32.png" ToolTip="Reporte Certificacion de Salarios" />
                                                                                </center>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <EmptyDataTemplate>
                                                                        <div align="center" class="CajaDialogoAdvertencia">
                                                                            <br />
                                                                            <img src="../Imagenes/warning.gif" alt="No existen datos que correspondan al criterio especificado" />
                                                                            <br />
                                                                            No existen datos que correspondan al criterio especificado<br />
                                                                            <br />
                                                                        </div>
                                                                    </EmptyDataTemplate>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>

                                            </ContentTemplate>
                                        </cc1:TabPanel>

                                        <cc1:TabPanel ID="TabPanel8" runat="server" HeaderText="EnviosAPS">
                                            <ContentTemplate>
                                                <asp:Panel ID="Panel11" runat="server" Visible="true" CssClass="panelprincipal">
                                                    <table width="100%">
                                                        <tr>
                                                            <td align="center">
                                                                <asp:GridView ID="gvEnvios" runat="server" EnableModelValidation="True"
                                                                    CellPadding="4" ForeColor="#333333" EnableTheming="True" Font-Names="Arial" Font-Size="9pt"
                                                                    CssClass="mGrid" PagerStyle-CssClass="pgr" GridLines="None" AutoGenerateColumns="False"
                                                                    DataKeyNames="IdTramite" SkinID="GridView" AlternatingRowStyle-CssClass="alt">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="Correlativo" HeaderText="Correlativo" />
                                                                        <asp:BoundField DataField="Entidad" HeaderText="Entidad" />
                                                                        <asp:BoundField DataField="NumeroCertificado" HeaderText="Numero de Certificado" />
                                                                        <asp:BoundField DataField="FechaEmisionCertificado" HeaderText="Fecha Emision Certificado" DataFormatString="{0:d}" />
                                                                        <asp:BoundField DataField="TipoCC" HeaderText="Tipo CC" />
                                                                        <asp:BoundField DataField="ClaseCC" HeaderText="Clase CC" />
                                                                        <asp:BoundField DataField="TipoIdentificacion" HeaderText="Tipo de Identificacion" />
                                                                        <asp:BoundField DataField="MontoCC" HeaderText="Monto CC" />
                                                                        <asp:BoundField DataField="TipoCambio" HeaderText="Tipo Cambio" />
                                                                        <asp:BoundField DataField="Densidad" HeaderText="Densidad" />
                                                                        <asp:BoundField DataField="SIP" HeaderText="SIP" />
                                                                        <asp:BoundField DataField="SalarioCotizableActualizado" HeaderText="SCA" />
                                                                        <asp:BoundField DataField="PeriodoSalarioCotizable" HeaderText="PeriodoSC" />
                                                                        <asp:BoundField DataField="FechaResolucion" HeaderText="Fecha Resolucion" DataFormatString="{0:d}" />
                                                                        <asp:BoundField DataField="NumeroResolucion" HeaderText="N° Resolucion" />
                                                                        <asp:BoundField DataField="CodigoActualizacion" HeaderText="Codigo Actualizacion" />

                                                                    </Columns>
                                                                    <EmptyDataTemplate>
                                                                        <div align="center" class="CajaDialogoAdvertencia">
                                                                            <br />
                                                                            <img src="../Imagenes/warning.gif" alt="No existen datos que correspondan al criterio especificado" />
                                                                            <br />
                                                                            No existen datos que correspondan al criterio especificado<br />
                                                                            <br />
                                                                        </div>
                                                                    </EmptyDataTemplate>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </ContentTemplate>
                                        </cc1:TabPanel>


                                        <cc1:TabPanel ID="TabPanel9" runat="server" HeaderText="Reprocesos">
                                            <ContentTemplate>
                                                <asp:Panel ID="Panel12" runat="server" Visible="true" CssClass="panelprincipal">
                                                    <table width="100%">
                                                        <tr>
                                                            <td align="center">
                                                                <div>
                                                                    <asp:Label ID="Label18" runat="server" Text="Certificado Anterior" Visible="False"></asp:Label>
                                                                </div>
                                                                <asp:GridView ID="gvReprocesosCerti" runat="server" EnableModelValidation="True"
                                                                    CellPadding="4" ForeColor="#333333" EnableTheming="True" Font-Names="Arial" Font-Size="9pt"
                                                                    CssClass="mGrid" PagerStyle-CssClass="pgr" GridLines="None" AutoGenerateColumns="False"
                                                                    DataKeyNames="IdTramite" SkinID="GridView" AlternatingRowStyle-CssClass="alt">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="NroCertificado" HeaderText="N° Certificado" />
                                                                        <asp:BoundField DataField="DTipoCC" HeaderText="Tipo CC" />
                                                                        <asp:BoundField DataField="MontoCCAceptado" HeaderText="Monto CC Aceptado" />
                                                                        <asp:BoundField DataField="FechaCalculo" HeaderText="Fecha Calculo" DataFormatString="{0:d}" />
                                                                        <asp:BoundField DataField="FechaInicioRepro" HeaderText="Fecha Inicio Reproceso" DataFormatString="{0:d}" />
                                                                   
                                                                    </Columns>
                                                                    <EmptyDataTemplate>
                                                                        <div align="center" class="CajaDialogoAdvertencia">
                                                                            <br />
                                                                            <img src="../Imagenes/warning.gif" alt="No existen datos que correspondan al criterio especificado" />
                                                                            <br />
                                                                            No existen datos que correspondan al criterio especificado<br />
                                                                            <br />
                                                                        </div>
                                                                    </EmptyDataTemplate>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                                <asp:Panel ID="Panel5" runat="server" Visible="true" CssClass="panelprincipal">
                                                    <table width="100%">
                                                        <tr>
                                                            <td align="center">
                                                                <div>
                                                                    <asp:Label ID="Label19" runat="server" Text="Reprocesos Iniciados" Visible="False"></asp:Label>
                                                                </div>
                                                                <asp:GridView ID="gvReprocesos" runat="server" EnableModelValidation="True"
                                                                    CellPadding="4" ForeColor="#333333" EnableTheming="True" Font-Names="Arial" Font-Size="9pt"
                                                                    CssClass="mGrid" PagerStyle-CssClass="pgr" GridLines="None" AutoGenerateColumns="False"
                                                                    DataKeyNames="IdTramite" SkinID="GridView" AlternatingRowStyle-CssClass="alt">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="NroFormularioRepro" HeaderText="N°Formulario Reproceso" />
                                                                        <asp:BoundField DataField="TipoReproceso" HeaderText="Tipo Reproceso" />
                                                                        <asp:BoundField DataField="EstadoReproceso" HeaderText="Estado Reproceso" />
                                                                        <asp:BoundField DataField="NumeroResolucion" HeaderText="Numero Resolucion" />
                                                                        <asp:BoundField DataField="FechaResolucion" HeaderText="Fecha Resolucion" DataFormatString="{0:d}" />
                                                                        <asp:BoundField DataField="NoFormularioCalculo" HeaderText="N° Formulario Calculo" />
                                                                        <asp:BoundField DataField="EstadoFormCalcCC" HeaderText="Estado Formulario Calculo"  />
                                                                        <asp:BoundField DataField="NroCertificadoNuevo" HeaderText="N° Certificado Nuevo" />
                                                                        <asp:BoundField DataField="MontoCCAceptadoNuevo" HeaderText="MontoCC Aceptado Nuevo" />
                                                                        <asp:BoundField DataField="TipoTramite" HeaderText="Tipo Tramite" />
                                                                        

                                                                    </Columns>
                                                                    <EmptyDataTemplate>
                                                                        <div align="center" class="CajaDialogoAdvertencia">
                                                                            <br />
                                                                            <img src="../Imagenes/warning.gif" alt="No existen datos que correspondan al criterio especificado" />
                                                                            <br />
                                                                            No existen datos que correspondan al criterio especificado<br />
                                                                            <br />
                                                                        </div>
                                                                    </EmptyDataTemplate>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </ContentTemplate>
                                        </cc1:TabPanel>

                                        <cc1:TabPanel ID="TabPanel10" runat="server" HeaderText="Pagos Alternativos">
                                            <ContentTemplate>
                                                <asp:Panel ID="Panel13" runat="server" Visible="true" CssClass="panelprincipal">
                                                    <table width="100%">
                                                        <tr>
                                                            <td align="center">
                                                                 <div>
                                                                    <asp:Label ID="Label20" runat="server" Text="Documento Comparativo" Visible="False"></asp:Label>
                                                                </div>
                                                                <asp:GridView ID="gvPagosA" runat="server" EnableModelValidation="True"
                                                                    CellPadding="4" ForeColor="#333333" EnableTheming="True" Font-Names="Arial" Font-Size="9pt"
                                                                    CssClass="mGrid" PagerStyle-CssClass="pgr" GridLines="None" AutoGenerateColumns="False"
                                                                    DataKeyNames="Densidad" SkinID="GridView" AlternatingRowStyle-CssClass="alt">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="Densidad" HeaderText="Densidad" />
                                                                        <asp:BoundField DataField="SalarioCotizable" HeaderText="Salario Cotizable" />
                                                                        <asp:BoundField DataField="SalarioCotizableActual" HeaderText="Salario Cotizable Actual" />
                                                                        <asp:BoundField DataField="FechaCalculo" HeaderText="Fecha Calculo" DataFormatString="{0:d}" />
                                                                        <asp:BoundField DataField="FechaEmision" HeaderText="Fecha Emision" DataFormatString="{0:d}" />
                                                                        <asp:BoundField DataField="TipoCambio" HeaderText="Tipo Cambio" />
                                                                        <asp:BoundField DataField="MontoCC" HeaderText="Monto CC" />
                                                                        <asp:BoundField DataField="MontoPMM" HeaderText="Monto PMM" />                    
                                                                        <asp:BoundField DataField="MontoPU" HeaderText="Monto PU" />
                                                                        <asp:BoundField DataField="NumeroDocumento" HeaderText="Numero Documento" />
                                                                        <asp:BoundField DataField="FechaSeleccion" HeaderText="Fecha Seleccion" DataFormatString="{0:d}"/>
                                                                       

                                                                    </Columns>
                                                                    <EmptyDataTemplate>
                                                                        <div align="center" class="CajaDialogoAdvertencia">
                                                                            <br />
                                                                            <img src="../Imagenes/warning.gif" alt="No existen datos que correspondan al criterio especificado" />
                                                                            <br />
                                                                            No existen datos que correspondan al criterio especificado<br />
                                                                            <br />
                                                                        </div>
                                                                    </EmptyDataTemplate>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                                <asp:Panel ID="Panel16" runat="server" Visible="true" CssClass="panelprincipal">
                                                    <table width="100%">
                                                        <tr>
                                                            <td align="center">
                                                                <div>
                                                                    <asp:Label ID="Label21" runat="server" Text="Pago Unico" Visible="False"></asp:Label>
                                                                </div>
                                                                <asp:GridView ID="gvPagosAPU" runat="server" EnableModelValidation="True"
                                                                    CellPadding="4" ForeColor="#333333" EnableTheming="True" Font-Names="Arial" Font-Size="9pt"
                                                                    CssClass="mGrid" PagerStyle-CssClass="pgr" GridLines="None" AutoGenerateColumns="False"
                                                                    DataKeyNames="IdTramite" SkinID="GridView" AlternatingRowStyle-CssClass="alt">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="IdTramite" HeaderText="IdTramite" Visible="False" />
                                                                        <asp:BoundField DataField="NumeroCertificado" HeaderText="Numero Certificado" />
                                                                        <asp:BoundField DataField="Documento" HeaderText="Documento" />
                                                                        <asp:BoundField DataField="FechaEmision" HeaderText="Fecha Emision" DataFormatString="{0:d}"  />
                                                                        <asp:BoundField DataField="TipoCambio" HeaderText="Tipo Cambio"  />
                                                                        <asp:BoundField DataField="Monto" HeaderText="Monto" />
                                                                        <asp:BoundField DataField="EestadoCetificadoPMMPU" HeaderText="EestadoCetificadoPMMPU"  />
                                                                  </Columns>
                                                                    <EmptyDataTemplate>
                                                                        <div align="center" class="CajaDialogoAdvertencia">
                                                                            <br />
                                                                            <img src="../Imagenes/warning.gif" alt="No existen datos que correspondan al criterio especificado" />
                                                                            <br />
                                                                            No existen datos que correspondan al criterio especificado<br />
                                                                            <br />
                                                                        </div>
                                                                    </EmptyDataTemplate>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </ContentTemplate>
                                        </cc1:TabPanel>

                                    </cc1:TabContainer>
                                </asp:Panel>
                            </ContentTemplate>
                        </cc1:TabPanel>

                    </cc1:TabContainer>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td align="right">
                <input id="HiddenIdtramite" type="hidden" runat="server" />
                <asp:Label runat="server" ID="lblCompletarInformacion" Visible="false" CssClass="text_obs"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Button runat="server" ID="btnReporte" Text="Reporte" OnClick="btnReporte_Click" CausesValidation="false" />
                &nbsp;
				<asp:Button runat="server" ID="btnCancelar" Text="Cancelar" CssClass="buttonsNegative" Visible="true" OnClick="btnCancelar_Click" CausesValidation="false" />
            </td>
        </tr>
    </table>


</asp:Content>

