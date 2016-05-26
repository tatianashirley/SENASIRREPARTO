<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmCompletarDatosFFAA.aspx.cs" Inherits="InicioTramite_wfrmCompletarDatosFFAA" StylesheetTheme="Modal" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" language="javascript" src="../js/jquery.js"></script>
    <script type="text/javascript" language="javascript" src="../js/InicioTramite/registroFFAA.js"></script>
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
                    <asp:Label ID="lblTipo" runat="server" ForeColor="#CC0000"></asp:Label>
                    <asp:HiddenField runat="server" ID="hfTabla" />
                </td>
            </tr>
        </table>
    </div>
    <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0">

        <cc1:TabPanel ID="TabDatosPersonales" runat="server" HeaderText="Datos Personales">
            <ContentTemplate>

                <asp:Panel ID="pnlRegistro" runat="server" Visible="true" CssClass="panelceleste">
                    <table width="100%">
                        <tr>
                            <td align="right" width="15%">
                                <asp:Label runat="server" ID="lblPrimerApellido" CssClass="etiqueta10">Primer Apellido:</asp:Label>
                            </td>
                            <td align="left" width="15%">
                                <asp:TextBox runat="server" ID="txtPrimerApellido" Width="200px"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="txtPrimerApellido_FilteredTextBoxExtender"
                                    runat="server" FilterType="Custom, LowercaseLetters, UppercaseLetters"
                                    TargetControlID="txtPrimerApellido" ValidChars="'áéíóúÁÉÍÓÚñÑ ">
                                </cc1:FilteredTextBoxExtender>
                            </td>
                            <td align="right" width="15%">
                                <asp:Label runat="server" ID="lblSegundoApellido" CssClass="etiqueta10">Segundo Apellido:</asp:Label>
                            </td>
                            <td align="left" width="15%">
                                <asp:TextBox runat="server" ID="txtSegundoApellido" Width="200px"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="txtSegundoApellido_FilteredTextBoxExtender"
                                    runat="server" FilterType="Custom, LowercaseLetters, UppercaseLetters"
                                    TargetControlID="txtSegundoApellido" ValidChars="'áéíóúÁÉÍÓÚñÑ ">
                                </cc1:FilteredTextBoxExtender>
                            </td>
                            <td align="right" width="15%">
                                <asp:Label runat="server" ID="lblApellidoCasada" CssClass="etiqueta10">Apellido Casada:</asp:Label>
                            </td>
                            <td align="left" width="15%">
                                <asp:TextBox runat="server" ID="txtApellidoCasada" Width="200px"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="txtApellidoCasada_FilteredTextBoxExtender"
                                    runat="server" FilterType="Custom, LowercaseLetters, UppercaseLetters"
                                    TargetControlID="txtApellidoCasada" ValidChars="'áéíóúÁÉÍÓÚñÑ ">
                                </cc1:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label runat="server" ID="lblPrimerNombre" CssClass="etiqueta10">Primer Nombre:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox runat="server" ID="txtPrimerNombre" Width="200px"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="txtPrimerNombre_FilteredTextBoxExtender"
                                    runat="server" FilterType="Custom, LowercaseLetters, UppercaseLetters"
                                    TargetControlID="txtPrimerNombre" ValidChars="'áéíóúÁÉÍÓÚñÑ">
                                </cc1:FilteredTextBoxExtender>
                            </td>
                            <td align="right">
                                <asp:Label runat="server" ID="lblSegundoNombre" CssClass="etiqueta10">Segundo Nombre:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox runat="server" ID="txtSegundoNombre" Width="200px"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="txtSegundoNombre_FilteredTextBoxExtender"
                                    runat="server" FilterType="Custom, LowercaseLetters, UppercaseLetters"
                                    TargetControlID="txtSegundoNombre" ValidChars="'áéíóúÁÉÍÓÚñÑ ">
                                </cc1:FilteredTextBoxExtender>
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right">
                                <label style="color: red">*</label>
                                <asp:Label runat="server" ID="lblTipoDocumento" CssClass="etiqueta10">Tipo Documento:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList runat="server" ID="ddlTipoDocumento" Width="200px" autofocus="autofocus"></asp:DropDownList>
                            </td>
                            <td align="right">
                                <label style="color: red">*</label>
                                <asp:Label runat="server" ID="lblNumeroDocumento" CssClass="etiqueta10">Número Documento:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtNumeroDocumento" runat="server" MaxLength="20" onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="txtNumeroDocumento_FilteredTextBoxExtender"
                                    runat="server" FilterType="Numbers"
                                    TargetControlID="txtNumeroDocumento" ValidChars="">
                                </cc1:FilteredTextBoxExtender>
                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator11" ControlToValidate="ddlExpedicion">*</asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtComplemento" runat="server" Width="29px" MaxLength="2" onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                            </td>
                            <td align="right">
                                <label style="color: red">*</label>
                                <asp:Label runat="server" ID="lblExpedido" CssClass="etiqueta10">Expedido:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlExpedicion" runat="server" Width="150px"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <label style="color: red">*</label>
                                <asp:Label runat="server" ID="lblSexo" CssClass="etiqueta10">Sexo:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:RadioButtonList runat="server" ID="rblSexo" RepeatDirection="Vertical"></asp:RadioButtonList>
                            </td>
                            <td align="right">
                                <label style="color: red">*</label>
                                <asp:Label runat="server" ID="lblEstadoCivil" CssClass="etiqueta10">Estado Civil:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList runat="server" ID="ddlEstadoCivil"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <label style="color: red">*</label>
                                <asp:Label runat="server" ID="lblFechaNacimiento" CssClass="etiqueta10">Fecha Nacimiento:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox runat="server" ID="txtFechaNacimiento" ToolTip="DD/MM/YYYY" onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtenderFechaNacimiento" runat="server" CssClass="cal_Theme1"
                                    TargetControlID="txtFechaNacimiento">
                                </cc1:CalendarExtender>
                                <asp:ImageButton ID="imgcalendarioIni" runat="server" CssClass="CajaDialogo" ImageUrl="~/Imagenes/16calendario.png" />
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server"
                                    TargetControlID="txtFechaNacimiento"
                                    Format="dd/MM/yyyy"
                                    PopupButtonID="imgcalendarioIni">
                                </cc1:CalendarExtender>
                            </td>
                            <td align="right">
                                <asp:Label runat="server" ID="lblFechaFallecimiento" CssClass="etiqueta10">Fecha Defunción:</asp:Label></td>
                            <td align="left">
                                <asp:TextBox runat="server" ID="txtFechaFallecimient" ToolTip="DD/MM/YYYY" onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                                <asp:ImageButton ID="btncalendarff" runat="server" CssClass="CajaDialogo" ImageUrl="~/Imagenes/16calendario.png" />
                                <cc1:CalendarExtender ID="CalendarExtendertxtFechaFallecimient" runat="server" CssClass="cal_Theme1"
                                    TargetControlID="txtFechaFallecimient"
                                    Format="dd/MM/yyyy"
                                    PopupButtonID="btncalendarff">
                                </cc1:CalendarExtender>
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <label style="color: red">*</label>
                                <asp:Label runat="server" ID="lblAFP" CssClass="etiqueta10">AFP:</asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList runat="server" ID="ddlAFP"></asp:DropDownList>
                            </td>
                            <td align="right">
                                <label style="color: red">*</label>
                                <asp:Label runat="server" ID="lblCUA" CssClass="etiqueta10">CUA:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox runat="server" ID="txtCUA" onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="txtCUA_FilteredTextBoxExtender"
                                    runat="server" FilterType="Numbers"
                                    TargetControlID="txtCUA" ValidChars="">
                                </cc1:FilteredTextBoxExtender>
                            </td>
                            <td align="right">
                                <label style="color: red">*</label>
                                <asp:Label runat="server" ID="lblMatricula" CssClass="etiqueta10">Matrícula:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox runat="server" ID="txtMatricula" onKeyPress="return disableEnterKey(event)">0</asp:TextBox>
                                <asp:TextBox runat="server" ID="txtMatriculaGenerada" Visible="false"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <label style="color: red">*</label>
                                <asp:Label runat="server" ID="lblSector" CssClass="etiqueta10">Sector Laboral:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlSector" runat="server"></asp:DropDownList>
                            </td>
                            <td align="right">
                                <label style="color: red">*</label>
                                <asp:Label runat="server" ID="lblOficina" CssClass="etiqueta10">Oficina Notificación:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlOficinaNotificacion" runat="server"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="6" align="center">
                                <asp:Button runat="server" ID="btnGenerarMatricula" Text="Generar Matrícula" OnClick="btnGenerarMatricula_Click" Width="200px" />
                                <asp:Button runat="server" ID="btnImprimir" Text="Imprimir" OnClick="btnImprimir_Click" Width="200px" />
                                <asp:Button runat="server" ID="ibtnVerificar" Text="Validar" OnClick="ibtnVerificar_Click" OnClientClick="efecto('cargando')" Width="200px" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <center>
                    <div id="cargando" style="display: none;">
                        <asp:Image ID="Imagecargando" runat="server" ImageUrl="~/Imagenes/ajax_loader_blue_32.GIF" />
                    </div>
                </center>
                <asp:Panel ID="Panel8" runat="server" BackColor="#3366CC" ForeColor="White">
                    SIMILITUDES
                </asp:Panel>
                <asp:Panel ID="pnlDatosSimilares" runat="server" CssClass="panelprincipal">
                    <table width="100%" border="0" cellpadding="false" cellspacing="false">
                        <tr>
                            <td align="center">
                                <asp:GridView ID="gv_ValidaDatosRepetidos" runat="server"
                                    AutoGenerateColumns="False" BorderColor="#DADADA" BorderStyle="Solid" BorderWidth="1px"
                                    CssClass="etiqueta8Blue" EnableTheming="True" Font-Names="Arial" Font-Size="9pt" GridLines="Horizontal"
                                    DataKeyNames="TRAMITE,TIPO,CARNET,TMATRICULA,NUA,PATERNO,MATERNO,NOMBRE,FECHA_NAC,CAMPOAPLI_DES,DHMATRICULA,ESTADO_TDES"
                                    SkinID="GridView" OnRowDataBound="gv_ValidaDatosRepetidos_RowDataBound">
                                    <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="TRAMITE" HeaderText="Trámite" ItemStyle-HorizontalAlign="Right" />
                                        <asp:BoundField DataField="TIPO" HeaderText="Tipo" />
                                        <asp:BoundField DataField="CARNET" HeaderText="Número Documento" ItemStyle-HorizontalAlign="Right" />
                                        <asp:BoundField DataField="TMATRICULA" HeaderText="Mátricula" ItemStyle-HorizontalAlign="Right" />
                                        <asp:BoundField DataField="NUA" HeaderText="CUA" ItemStyle-HorizontalAlign="Right" />
                                        <asp:BoundField DataField="PATERNO" HeaderText="Primer Apellido" />
                                        <asp:BoundField DataField="MATERNO" HeaderText="Segundo Apellido" />
                                        <asp:BoundField DataField="NOMBRE" HeaderText="Nombres" />
                                        <asp:BoundField DataField="FECHA_NAC" HeaderText="Fecha Nacimiento" DataFormatString="{0:d}" ItemStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="CAMPOAPLI_DES" HeaderText="Sector Laboral" />
                                        <asp:BoundField DataField="DHMATRICULA" HeaderText="DH Mátricula" />
                                        <asp:BoundField DataField="ESTADO_TDES" HeaderText="Estado" />
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <div align="center" class="CajaDialogoAdvertencia">
                                            <br />
                                            <img src="../Imagenes/warning.gif"
                                                alt="No existen datos que correspondan al criterio especificado" />
                                            <br />
                                            No existen datos que correspondan al criterio especificado
                                        <br />
                                            <br />
                                        </div>
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label runat="server" ID="lblSimilitud" Visible="false" CssClass="text_obs"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button runat="server" ID="ibtnPermitir" Text="Permitir" OnClick="ibtnPermitir_Click" Width="100px" CssClass="boton150" />&nbsp;
                                <asp:Button runat="server" ID="ibtnDenegar" Text="Denegar" OnClick="ibtnDenegar_Click" Width="100px" CssClass="boton150" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>

                <cc1:ModalPopupExtender ID="ModalPopupExtender3" runat="server" CancelControlID="btnNoJustificar" TargetControlID="lblObservadoi" PopupControlID="pnlJustificar" BackgroundCssClass="modalBackground">
                </cc1:ModalPopupExtender>
                <asp:Panel runat="server" ID="pnlJustificar" CssClass="panelceleste" Visible="false">
                    <table align="center" cellpadding="0" cellspacing="0" width="700px">
                        <tr>
                            <td align="center" colspan="2">
                                <asp:Label ID="lblObservadoi" runat="server"><h2>Justificación Inicio Trámite</h2></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <label style="color: red">*</label>
                                <asp:Label ID="lblMotivoi" runat="server" CssClass="etiqueta10">Motivo:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtMotivoi" runat="server" Width="200px" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <label style="color: red">*</label>
                                <label class="etiqueta10">Autorizador:</label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtAutorizadori" runat="server" Width="200px" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <label style="color: red">*</label>
                                <label class="etiqueta10">Observaciones:</label></td>
                            <td align="left">
                                <asp:TextBox ID="txtObservacioni" runat="server" Height="100px" TextMode="MultiLine" Width="300px" MaxLength="200" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="txtObservacioni_FilteredTextBoxExtender"
                                    runat="server" FilterType="Custom, LowercaseLetters, UppercaseLetters,Numbers"
                                    TargetControlID="txtObservacioni" ValidChars="'áéíóúÁÉÍÓÚñÑ.#/ ">
                                </cc1:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button CssClass="buttonGreen" Text="Si, Continuar" runat="server" ID="btnSiJustificar" OnClick="btnSiJustificar_Click" />&nbsp;
                        <asp:Button CssClass="buttonRed" Text="No, Verificar" runat="server" ID="btnNoJustificar" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>

            </ContentTemplate>
        </cc1:TabPanel>

        <cc1:TabPanel ID="TabDatosResidencia" runat="server" HeaderText="" Visible="false">
            <ContentTemplate>

                <asp:Panel ID="pnlDatosResidencia" runat="server" Visible="false" CssClass="panelceleste">
                    <table width="100%">
                        <tr>
                            <td align="right" width="10%">
                                <label style="color: red">*</label>
                                <asp:Label runat="server" ID="lblLocalidad" CssClass="etiqueta10">País:</asp:Label>
                            </td>
                            <td align="left" width="15%">
                                <asp:HiddenField runat="server" ID="hdnIdPais" />
                                <asp:TextBox runat="server" ID="txtBuscarPais" Width="100px" Height="16px" onkeyup="this.value=this.value.toUpperCase()" MaxLength="50" onKeyPress="return disableEnterKey(event)" Enabled="false"></asp:TextBox>
                                <asp:ImageButton ID="ibtnBuscarPais" runat="server" ImageUrl="~/Imagenes/16Buscar.png" OnClick="ibtnBuscarPais_Click" Style="height: 16px" />
                            </td>
                            <td align="right" width="15%">
                                <label style="color: red">*</label>
                                <asp:Label runat="server" ID="Label10" CssClass="etiqueta10">Localidad:</asp:Label>
                            </td>
                            <td align="left" width="25%">
                                <asp:HiddenField runat="server" ID="hdnIdLocalidad" />
                                <asp:TextBox ID="txtBuscarLocalidad" runat="server" Width="180px" onkeyup="this.value=this.value.toUpperCase()" MaxLength="50" onKeyPress="return disableEnterKey(event)" Enabled="false"></asp:TextBox>
                                <asp:ImageButton ID="ibtnBuscarLocalidad" runat="server" ImageUrl="~/Imagenes/16Buscar.png" OnClick="ibtnBuscarLocalidad_Click" Style="height: 16px" />
                            </td>
                            <td align="right" width="10%">
                                <label style="color: red">*</label>
                                <asp:Label runat="server" ID="lblDireccion" CssClass="etiqueta10" onkeyup="this.value=this.value.toUpperCase()">Dirección:</asp:Label>
                            </td>
                            <td align="left" width="30%">
                                <asp:TextBox runat="server" ID="txtDireccion" Width="300px" MaxLength="100" onkeyup="this.value=this.value.toUpperCase()" onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtendertxtDireccion"
                                    runat="server"
                                    TargetControlID="txtDireccion" ValidChars="0123456789.ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnoñpqrstuvwxyz#/áéíóúÁÉÍÓÚ ">
                                </cc1:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label runat="server" ID="lblTelefono" CssClass="etiqueta10">Teléfono Fijo:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox runat="server" ID="txtTelefono" Width="67px" ToolTip="(Longitud 7 Digitos)" MaxLength="7" onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="txtTelefono_FilteredTextBoxExtender"
                                    runat="server" FilterType="Numbers"
                                    TargetControlID="txtTelefono" ValidChars="">
                                </cc1:FilteredTextBoxExtender>
                            </td>
                            <td align="right" class="auto-style57">
                                <asp:Label runat="server" ID="lblCelular" CssClass="etiqueta10">Teléfono Celular:</asp:Label></td>
                            <td align="left" class="auto-style58">
                                <asp:TextBox runat="server" ID="txtCelular" Width="74px" ToolTip="(Longitud 8 Digitos , Primer digito 6 o 7)" MaxLength="8" onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="txtCelular_FilteredTextBoxExtender"
                                    runat="server" FilterType="Numbers"
                                    TargetControlID="txtCelular">
                                </cc1:FilteredTextBoxExtender>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblEmail" runat="server" CssClass="etiqueta10">E-Mail:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtEmail" runat="server" Width="300px" ToolTip="(Ej. xxx@gmail.com)" onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label runat="server" ID="Label16" CssClass="etiqueta10">&nbsp;</asp:Label>
                            </td>
                            <td align="left">&nbsp;
                            </td>
                            <td align="right" class="auto-style57">
                                <asp:Label runat="server" ID="Label17" CssClass="etiqueta10">Teléfono Referencia:</asp:Label></td>
                            <td align="left" class="auto-style58">
                                <asp:TextBox runat="server" ID="txtCelular2" Width="74px" ToolTip="(Longitud 8 Digitos , Primer digito 6 o 7)" MaxLength="8" onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server" FilterType="Numbers" TargetControlID="txtCelular2"></cc1:FilteredTextBoxExtender>
                            </td>
                            <td align="right">
                                <asp:Label ID="Label18" runat="server" CssClass="etiqueta10">&nbsp;</asp:Label>
                            </td>
                            <td align="left">&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" align="center">
                                <asp:Button runat="server" ID="btnSiguienteResidencia" Text="Siguiente" Width="100px" OnClick="btnSiguienteResidencia_Click" />
                            </td>
                        </tr>
                    </table>

                </asp:Panel>
                <cc1:ModalPopupExtender ID="ModalPopupExtender_LOCALIDAD" runat="server" TargetControlID="lblLocalidadpopup" PopupControlID="pnlLocalidadPoup" CancelControlID="btnCancelLocalidad" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>
                <asp:Panel ID="pnlLocalidadPoup" runat="server" CssClass="panelceleste">
                    <div style="overflow: auto; width: 500px; height: auto;">
                        <table width="100%">
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:Label ID="lblLocalidadpopup" runat="server"><h3>Buscar Localidad</h3></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblBusLocalidad" runat="server" CssClass="etiqueta10">Localidad:</asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtBusLocalidad" runat="server" Width="200px" onkeyup="this.value=this.value.toUpperCase()" onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:Button ID="btnBusLocalidad" runat="server" Text="Buscar" OnClick="btnBusLocalidad_Click" CssClass="boton100" />&nbsp;
                        <asp:Button ID="btnCancelLocalidad" runat="server" Text="Cancelar" OnClick="btnCancelLocalidad_Click" CssClass="boton100" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:GridView ID="gvGeo" runat="server" AutoGenerateColumns="False" EnableModelValidation="True" Width="100%"
                                        BorderColor="#DADADA" BorderStyle="Solid" BorderWidth="1px" CssClass="etiqueta8Blue" SkinID="GridView"
                                        EnableTheming="True" Font-Names="Arial" Font-Size="9pt" GridLines="Horizontal"
                                        AllowPaging="True" PageSize="5" OnPageIndexChanging="gvGeo_PageIndexChanging" OnSelectedIndexChanging="gvGeo_SelectedIndexChanging"
                                        DataKeyNames="CodigoLocalidad,NombreLocalidad" OnRowCommand="gvGeo_RowCommand">
                                        <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:BoundField DataField="CodigoLocalidad" Visible="true" HeaderText="ID" InsertVisible="false" ItemStyle-Width="4%" />
                                            <asp:BoundField DataField="NombreLocalidad" HeaderText="Localidad" ItemStyle-Width="20%" HeaderStyle-HorizontalAlign="Center" />
                                            <asp:BoundField DataField="IdSeccion" Visible="false" HeaderText="ID" ItemStyle-Width="4%" />
                                            <asp:BoundField DataField="NombreSeccionMunicipal" HeaderText="Sección" ItemStyle-Width="25%" HeaderStyle-HorizontalAlign="Center" />
                                            <asp:BoundField DataField="IdProvincia" Visible="false" HeaderText="ID" ItemStyle-Width="4%" />
                                            <asp:BoundField DataField="NombreProvincia" HeaderText="Provincia" ItemStyle-Width="18%" HeaderStyle-HorizontalAlign="Center" />
                                            <asp:BoundField DataField="IdDepartamento" Visible="false" HeaderText="ID" ItemStyle-Width="4%" />
                                            <asp:BoundField DataField="NombreDepartamento" HeaderText="Departamento" ItemStyle-Width="18%" HeaderStyle-HorizontalAlign="Center" />
                                            <asp:BoundField DataField="IdLocalidad" Visible="false" HeaderText="Loc" ItemStyle-Width="4%" />
                                            <asp:TemplateField HeaderText="Seleccionar">
                                                <ItemTemplate>
                                                    <center>
                                                        <asp:ImageButton ID="imgLocalidad" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdLocalidad" ImageUrl="~/Imagenes/sig.png" />
                                                    </center>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <PagerSettings Mode="NumericFirstLast" PageButtonCount="10" FirstPageText="Primera" LastPageText="Última" />
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                        <EmptyDataTemplate>
                                            <div align="center" class="CajaDialogoAdvertencia">
                                                <br />
                                                <img src="../Imagenes/warning.gif"
                                                    alt="No existen datos que correspondan al criterio especificado" />
                                                <br />
                                                No existen datos que correspondan al criterio especificado
                                                                                        <br />
                                            </div>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </div>
                </asp:Panel>

                <cc1:ModalPopupExtender ID="ModalPopupExtender_Pais" runat="server" TargetControlID="lblBuscarPais" PopupControlID="pnlPaisPopup" CancelControlID="btnCancelPais" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>
                <asp:Panel ID="pnlPaisPopup" runat="server" CssClass="panelceleste">
                    <div style="overflow: auto; width: 500px; height: auto;">
                        <table width="100%">
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:Label ID="lblBuscarPais" runat="server"><h3>Buscar País</h3></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblPais" runat="server" CssClass="etiqueta10">País:</asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtBusPais" runat="server" Width="200px" onkeyup="this.value=this.value.toUpperCase()" onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:Button ID="btnBusPais" runat="server" Text="Buscar" OnClick="btnBusPais_Click" CssClass="boton100" />&nbsp;
                        <asp:Button ID="btnCancelPais" runat="server" Text="Cancelar" OnClick="btnCancelPais_Click" CssClass="boton100" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:GridView ID="gvPais" runat="server" AutoGenerateColumns="False" EnableModelValidation="True" Width="100%"
                                        BorderColor="#DADADA" BorderStyle="Solid" BorderWidth="1px" CssClass="etiqueta8Blue" SkinID="GridView"
                                        EnableTheming="True" Font-Names="Arial" Font-Size="9pt" GridLines="Horizontal"
                                        AllowPaging="True" PageSize="5" OnPageIndexChanging="gvPais_PageIndexChanging" OnSelectedIndexChanging="gvPais_SelectedIndexChanging"
                                        DataKeyNames="CodigoPais,NombrePais" OnRowCommand="gvPais_RowCommand">
                                        <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:BoundField DataField="CodigoPais" HeaderText="ID" Visible="true" InsertVisible="false" ItemStyle-Width="20%" />
                                            <asp:BoundField DataField="NombrePais" HeaderText="Pais" ItemStyle-Width="70%" HeaderStyle-HorizontalAlign="Center" />
                                            <asp:TemplateField HeaderText="Seleccionar">
                                                <ItemTemplate>
                                                    <center>
                                                        <asp:ImageButton ID="imgPais" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdPais" ImageUrl="~/Imagenes/sig.png" />
                                                    </center>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <PagerSettings Mode="NumericFirstLast" PageButtonCount="10" FirstPageText="Primera" LastPageText="Última" />
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                        <EmptyDataTemplate>
                                            <div align="center" class="CajaDialogoAdvertencia">
                                                <br />
                                                <img src="../Imagenes/warning.gif"
                                                    alt="No existen datos que correspondan al criterio especificado" />
                                                <br />
                                                No existen datos que correspondan al criterio especificado
                                                                                        <br />
                                            </div>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </div>
                </asp:Panel>

            </ContentTemplate>
        </cc1:TabPanel>

        <cc1:TabPanel ID="TabSalario" runat="server" HeaderText="" Visible="false">
            <ContentTemplate>

                <asp:Panel ID="pnlSalarioCotizableE" runat="server" CssClass="panelceleste">
                    <table width="100%">
                        <tr>
                            <td align="right" width="20%">
                                <asp:Label ID="lblSalarioffaa" runat="server" CssClass="etiqueta10">Salario:</asp:Label>
                            </td>
                            <td align="left" width="15%">
                                <asp:TextBox ID="txtSalarioffaa" runat="server" BackColor="#CCCCCC" Enabled="False" Width="91px"></asp:TextBox>
                            </td>
                            <td align="right" width="10%">
                                <asp:Label ID="lblPeriodo" runat="server" CssClass="etiqueta10">Periodo:</asp:Label>
                            </td>
                            <td align="left" width="15%">
                                <asp:TextBox ID="txtPeriodo" runat="server" BackColor="#CCCCCC" Enabled="False"></asp:TextBox>
                            </td>
                            <td align="right" width="10%">
                                <asp:Label ID="lblContinuo" runat="server" CssClass="etiqueta10">Continuo:</asp:Label>
                            </td>
                            <td align="left" width="15%">
                                <asp:TextBox ID="txtContinuo" runat="server" BackColor="#CCCCCC" Enabled="False"></asp:TextBox>
                            </td>
                        </tr>
                    </table>

                </asp:Panel>

                <asp:Panel ID="pnlCasoObservado" runat="server" CssClass="panelceleste" Visible="false">
                    <table class="auto-style36" cellpadding="0" cellspacing="0">
                        <tr>
                            <td colspan="2" align="center">
                                <h3>Trámite Observado</h3>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">Observaciones:</td>
                            <td align="right">
                                <asp:TextBox ID="txtCasoObservacion" runat="server" Height="79px" Width="325px" TextMode="MultiLine" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <div id="divMensaje0" class="wrapper" visible="false">
                                    <div class="box">
                                        <form class="formBox">
                                            <div class="label">
                                                <p id="pTituloCasoobs" runat="server" class="first">
                                                    <asp:Image ID="imgMensaje0" runat="server" ImageUrl="~/Imagenes/32MensajeAdvertencia.png" />
                                                    <label id="lblTitulo0">¿Está seguro de continuar?</label>
                                                    <asp:Image ID="Image6" runat="server" ImageUrl="~/Imagenes/32MensajeAdvertencia.png" />
                                                </p>
                                                <p id="pMensajeCasoObs" class="second">
                                                    Si usted continúa, este trámite estará observado.
                                                </p>
                                            </div>
                                            <div class="buttonForm">
                                                <asp:Button ID="btn2AceptaCasoObs" runat="server" CssClass="buttonGreen" Text="Si, Continuar" OnClick="btn2AceptaCasoObs_Click" />
                                                &nbsp;
                        <asp:Button ID="btnCancelaCasoObs" runat="server" CssClass="buttonRed" Text="No, Verificar" />
                                            </div>
                                        </form>
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <cc1:ModalPopupExtender ID="ModalPopupExtender_CasosObs" runat="server" BackgroundCssClass="modalBackground" CancelControlID="btnCancelaCasoObs" PopupControlID="pnlCasoObservado" TargetControlID="btnObservarTramite"></cc1:ModalPopupExtender>

            </ContentTemplate>
        </cc1:TabPanel>

    </cc1:TabContainer>
    <table width="100%" border="0" cellpadding="false" cellspacing="false">
        <tr>
            <td align="right">
                <input id="HiddenIdtramite" type="hidden" runat="server" />
                <asp:Label runat="server" ID="lblCompletarInformacion" Visible="false" CssClass="text_obs"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Button runat="server" ID="btnObservarTramite" Text="Observar Trámite" Visible="false" OnClick="btnObservarTramite_Click" />
                <asp:Button runat="server" ID="btnIniciarTramite" Text="Iniciar Trámite" OnClick="btnIniciarTramite_Click" OnClientClick="efecto('cargando2')" Visible="false" />
                <asp:Button ID="btnForm02" runat="server" Text="Reporte Form-02" OnClientClick="aspnetForm.target ='_blank';" Visible="false" OnClick="btnForm02_Click" />
                <asp:Button ID="btnReporte" runat="server" OnClick="btnReporte_Click" Text="Reporte" OnClientClick="aspnetForm.target ='_blank';" Visible="false" />
                <asp:Button runat="server" ID="btnCancelar" Text="Cancelar" CssClass="buttonsNegative" Visible="true" OnClick="btnCancelar_Click" CausesValidation="false" />
            </td>
        </tr>
    </table>
    <center>
        <div id="cargando2" style="display: none;">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/ajax_loader_blue_32.GIF" />
        </div>
    </center>
</asp:Content>

