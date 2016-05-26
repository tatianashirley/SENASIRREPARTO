<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmCompletarDatos.aspx.cs" Inherits="Administracion_CompletarDatos" StylesheetTheme="Modal" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" language="javascript" src="../js/InicioTramite/registro.js"></script>
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
                    <asp:Label ID="lblProceso" runat="server" ForeColor="#CC0000"></asp:Label>
                    <asp:HiddenField runat="server" ID="hfTabla" />
                    <asp:HiddenField runat="server" ID="hddProceso" />
                    <asp:HiddenField runat="server" ID="hddCodigo" />
                    <asp:HiddenField runat="server" ID="hddObservado" />
                    <asp:HiddenField runat="server" ID="hddMatriculaORG" />
                </td>
            </tr>
        </table>
    </div>
    <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0">

        <cc1:TabPanel ID="TabDatosPersonales" runat="server" HeaderText="Datos Personales">
            <ContentTemplate>
                <asp:Panel ID="pnlRegistro" runat="server" Visible="true" CssClass="panelprincipal">
                    <table width="100%">
                        <tr>
                            <td align="right" width="15%">
                                <label style="color: red">*</label>
                                <asp:Label runat="server" ID="lblPrimerApellido" CssClass="etiqueta10">Primer Apellido:</asp:Label>
                            </td>
                            <td align="left" width="15%">
                                <asp:TextBox runat="server" ID="txtPrimerApellido" Width="200px" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="txtPrimerApellido_FilteredTextBoxExtender"
                                    runat="server" FilterType="Custom, LowercaseLetters, UppercaseLetters"
                                    TargetControlID="txtPrimerApellido" ValidChars="'áéíóúÁÉÍÓÚñÑ ">
                                </cc1:FilteredTextBoxExtender>
                            </td>
                            <td align="right" width="15%">
                                <label style="color: red">*</label>
                                <asp:Label runat="server" ID="lblSegundoApellido" CssClass="etiqueta10">Segundo Apellido:</asp:Label>
                            </td>
                            <td align="left" width="15%">
                                <asp:TextBox runat="server" ID="txtSegundoApellido" Width="200px" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="txtSegundoApellido_FilteredTextBoxExtender"
                                    runat="server" FilterType="Custom, LowercaseLetters, UppercaseLetters"
                                    TargetControlID="txtSegundoApellido" ValidChars="'áéíóúÁÉÍÓÚñÑ ">
                                </cc1:FilteredTextBoxExtender>
                            </td>
                            <td align="right" width="15%">
                                <asp:Label runat="server" ID="lblApellidoCasada" CssClass="etiqueta10">Apellido Casada:</asp:Label>
                            </td>
                            <td align="left" width="15%">
                                <asp:TextBox runat="server" ID="txtApellidoCasada" Width="200px" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="txtApellidoCasada_FilteredTextBoxExtender"
                                    runat="server" FilterType="Custom, LowercaseLetters, UppercaseLetters"
                                    TargetControlID="txtApellidoCasada" ValidChars="'áéíóúÁÉÍÓÚñÑ ">
                                </cc1:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <label style="color: red">*</label>
                                <asp:Label runat="server" ID="lblPrimerNombre" CssClass="etiqueta10">Primer Nombre:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox runat="server" ID="txtPrimerNombre" Width="200px" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="txtPrimerNombre_FilteredTextBoxExtender"
                                    runat="server" FilterType="Custom, LowercaseLetters, UppercaseLetters"
                                    TargetControlID="txtPrimerNombre" ValidChars="'áéíóúÁÉÍÓÚñÑ ">
                                </cc1:FilteredTextBoxExtender>
                            </td>
                            <td align="right">
                                <asp:Label runat="server" ID="lblSegundoNombre" CssClass="etiqueta10">Segundo Nombre:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox runat="server" ID="txtSegundoNombre" Width="200px" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
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
                                <asp:DropDownList AutoPostBack="true" CausesValidation="false" OnSelectedIndexChanged="ddlTipoDocumento_SelectedIndexChanged" runat="server" ID="ddlTipoDocumento" Width="200px" onKeyPress="return disableEnterKey(event)"></asp:DropDownList>

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
                                <asp:TextBox ID="txtComplemento" runat="server" Width="29px" MaxLength="2" onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                            </td>
                            <td align="right">
                                <label style="color: red">*</label>
                                <asp:Label runat="server" ID="lblExpedido" CssClass="etiqueta10">Expedido:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlExpedicion" runat="server" Width="150px" onKeyPress="return disableEnterKey(event)"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <label style="color: red">*</label>
                                <asp:Label runat="server" ID="lblSexo" CssClass="etiqueta10">Sexo:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:RadioButtonList runat="server" ID="rblSexo" RepeatDirection="Vertical" onKeyPress="return disableEnterKey(event)"></asp:RadioButtonList>
                            </td>
                            <td align="right">
                                <label style="color: red">*</label>
                                <asp:Label runat="server" ID="lblEstadoCivil" CssClass="etiqueta10">Estado Civil:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList runat="server" ID="ddlEstadoCivil" onKeyPress="return disableEnterKey(event)"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <label style="color: red">*</label>
                                <asp:Label runat="server" ID="lblFechaNacimiento" CssClass="etiqueta10">Fecha Nacimiento:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox runat="server" ID="txtFechaNacimiento" ToolTip="DD/MM/YYYY" onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                                <asp:ImageButton ID="imgcalendarioIni" runat="server" CssClass="CajaDialogo" ImageUrl="~/Imagenes/16calendario.png" />
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="cal_Theme1"
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
                                <asp:Label runat="server" ID="lblAFP" CssClass="etiqueta10">Fondo de Pensiones:</asp:Label>
                            </td>
                            <td>
                                <asp:RadioButtonList runat="server" ID="rblAFP" RepeatDirection="Vertical" onKeyPress="return disableEnterKey(event)"></asp:RadioButtonList>
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
                                <asp:DropDownList ID="ddlSector" runat="server" onKeyPress="return disableEnterKey(event)"></asp:DropDownList>
                            </td>
                            <td align="right">
                                <label style="color: red">*</label>
                                <asp:Label runat="server" ID="lblOficina" CssClass="etiqueta10">Oficina Notificación:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlOficinaNotificacion" runat="server" onKeyPress="return disableEnterKey(event)"></asp:DropDownList>
                            </td>
                            <td>&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="6" align="center">
                                <asp:Button runat="server" ID="btnGenerarMatricula" Text="Generar Matrícula" OnClick="btnGenerarMatricula_Click" Width="200px" CssClass="boton150" />
                                &nbsp;
                                <asp:Button runat="server" ID="btnImprimir" Text="Imprimir" OnClick="btnImprimir_Click" Width="200px" CssClass="boton150" />
                                &nbsp;
                                <asp:Button runat="server" ID="ibtnVerificar" Text="Validar" OnClick="ibtnVerificar_Click" Width="200px" CssClass="boton150" />
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
                <asp:Panel ID="pnlTituloAccesoDirecto" runat="server" BackColor="#3366CC" ForeColor="White" Visible="false">
                    Acceso Directo
                </asp:Panel>
                <asp:Panel ID="pnlAcceso" runat="server" CssClass="panelprincipal" Visible="false">
                    <table width="100%" border="0" cellpadding="false" cellspacing="false">
                        <tr>
                            <td align="center">
                                <asp:Label runat="server" ID="lblResoluciones" CssClass="text_obs" Text="Resoluciones" />
                                <asp:GridView ID="gvADResoluciones" runat="server"
                                    AutoGenerateColumns="False" BorderColor="#DADADA" BorderStyle="Solid" BorderWidth="1px"
                                    CssClass="etiqueta8Blue" EnableTheming="True" Font-Names="Arial" Font-Size="9pt" GridLines="Horizontal"
                                    SkinID="GridView">
                                    <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="TRAMITE" HeaderText="Trámite" ItemStyle-HorizontalAlign="Right" />
                                        <asp:BoundField DataField="MATRICULA" HeaderText="Mátricula" ItemStyle-HorizontalAlign="Right" />
                                        <asp:BoundField DataField="PATERNO" HeaderText="Primer Apellido" />
                                        <asp:BoundField DataField="MATERNO" HeaderText="Segundo Apellido" />
                                        <asp:BoundField DataField="NOMBRES" HeaderText="Nombres" />
                                        <asp:BoundField DataField="CARNET" HeaderText="Número Documento" ItemStyle-HorizontalAlign="Right" />
                                        <asp:BoundField DataField="FEC_DEF" HeaderText="Fecha Defunción" DataFormatString="{0:d}" ItemStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="NRO_RES" HeaderText="Nro. Resolución" ItemStyle-HorizontalAlign="Right" />
                                        <asp:BoundField DataField="CLASE_RES" HeaderText="Clase Resolución" />
                                        <asp:BoundField DataField="ESTADO_RES" HeaderText="Estado Resolución" />
                                        <asp:BoundField DataField="APROBADO" HeaderText="Aprobado" />
                                        <asp:BoundField DataField="ESTADO_TRAMITE" HeaderText="Estado Trámite" />
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
                            <td align="center">
                                <asp:Label runat="server" ID="lblConvenio" CssClass="text_obs" Text="Convenios" />
                                <asp:GridView ID="gvADConvenios" runat="server"
                                    AutoGenerateColumns="False" BorderColor="#DADADA" BorderStyle="Solid" BorderWidth="1px"
                                    CssClass="etiqueta8Blue" EnableTheming="True" Font-Names="Arial" Font-Size="9pt" GridLines="Horizontal"
                                    SkinID="GridView">
                                    <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="TRAMITE" HeaderText="Trámite" ItemStyle-HorizontalAlign="Right" />
                                        <asp:BoundField DataField="MATRICULA" HeaderText="Mátricula" ItemStyle-HorizontalAlign="Right" />
                                        <asp:BoundField DataField="PATERNO" HeaderText="Primer Apellido" />
                                        <asp:BoundField DataField="MATERNO" HeaderText="Segundo Apellido" />
                                        <asp:BoundField DataField="NOMBRES" HeaderText="Nombres" />
                                        <asp:BoundField DataField="CARNET" HeaderText="Número Documento" ItemStyle-HorizontalAlign="Right" />
                                        <asp:BoundField DataField="FEC_NAC" HeaderText="Fecha Nacimiento" DataFormatString="{0:d}" ItemStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="TIPO" HeaderText="Tipo" />
                                        <asp:BoundField DataField="NRO_CONV" HeaderText="Nro. Convenio" ItemStyle-HorizontalAlign="Right" />
                                        <asp:BoundField DataField="ANIO_CONV" HeaderText="Año Convenio" ItemStyle-HorizontalAlign="Right" />
                                        <asp:BoundField DataField="FEC_CONV" HeaderText="Fecha Convenio" DataFormatString="{0:d}" ItemStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="PORC_CONV" HeaderText="% Convenio" ItemStyle-HorizontalAlign="Right" />
                                        <asp:BoundField DataField="NRO_RES" HeaderText="Nro. Resolución" ItemStyle-HorizontalAlign="Right" />
                                        <asp:BoundField DataField="FEC_RES" HeaderText="Fecha Resolución" DataFormatString="{0:d}" ItemStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="MONTO" HeaderText="Monto Bs" />
                                        <asp:BoundField DataField="ESTADO" HeaderText="Estado Trámite" />
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
                            <td align="center">
                                <asp:Button runat="server" ID="btnSiguienteAcceso" OnClick="btnSiguienteAcceso_Click" Text="Siguiente" Width="100px" CssClass="boton150" />&nbsp;
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


                <cc1:ModalPopupExtender ID="ModalPopupExtender_COTEJAR" runat="server" CancelControlID="btnCancelarAP" TargetControlID="lblCotejamiento" PopupControlID="pnlAfiliados" BackgroundCssClass="modalBackground">
                </cc1:ModalPopupExtender>
                <asp:Panel runat="server" ID="pnlAfiliados" CssClass="panelceleste" Visible="false">
                    <table align="center" cellpadding="0" cellspacing="0" width="700px">
                        <tr>
                            <td align="center" colspan="3">
                                <asp:Label ID="lblCotejamiento" runat="server"><h2>Verificar Afiliados</h2></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;
                            </td>
                            <td align="center">
                                <label style="color: red">Datos AP</label>
                            </td>
                            <td align="center">
                                <label style="color: red">Datos Inicio Trámite</label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <label style="color: red">*</label>
                                <asp:Label ID="Label9" runat="server" CssClass="etiqueta10">NUA:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtNUA_AP" runat="server" Width="200px" onkeyup="this.value=this.value.toUpperCase()" Enabled="false"></asp:TextBox>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtNUA_IT" runat="server" Width="200px" onkeyup="this.value=this.value.toUpperCase()" Enabled="false"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <label style="color: red">*</label>
                                <label class="etiqueta10">Primer Apellido:</label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtPrimerApellido_AP" runat="server" Width="200px" onkeyup="this.value=this.value.toUpperCase()" Enabled="false"></asp:TextBox>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtPrimerApellido_IT" runat="server" Width="200px" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <label style="color: red">*</label>
                                <label class="etiqueta10">Segundo Apellido:</label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtSegundoApellido_AP" runat="server" Width="200px" onkeyup="this.value=this.value.toUpperCase()" Enabled="false"></asp:TextBox>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtSegundoApellido_IT" runat="server" Width="200px" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <label style="color: red">*</label>
                                <label class="etiqueta10">Primer Nombre:</label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtPrimerNombre_AP" runat="server" Width="200px" onkeyup="this.value=this.value.toUpperCase()" Enabled="false"></asp:TextBox>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtPrimerNombre_IT" runat="server" Width="200px" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <label style="color: red">*</label>
                                <label class="etiqueta10">Segundo Nombre:</label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtSegundoNombre_AP" runat="server" Width="200px" onkeyup="this.value=this.value.toUpperCase()" Enabled="false"></asp:TextBox>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtSegundoNombre_IT" runat="server" Width="200px" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <label style="color: red">*</label>
                                <label class="etiqueta10">Fecha Nacimiento:</label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtFechaNac_AP" runat="server" Width="200px" Enabled="false"></asp:TextBox>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtFechaNac_IT" runat="server" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" align="center">&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" align="center">
                                <asp:Button CssClass="buttonGreen" Text="Actualizar Datos" runat="server" ID="btnActualizarAP" OnClick="btnActualizarAP_Click" />&nbsp;
                        <asp:Button CssClass="buttonRed" Text="Cancelar" runat="server" ID="btnCancelarAP" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </ContentTemplate>
        </cc1:TabPanel>

        <cc1:TabPanel ID="TabResidencia" runat="server" Visible="false">
            <ContentTemplate>

                <asp:Panel ID="pnlDatosResidencia" runat="server" Visible="false" CssClass="panelprincipal">
                    <table width="100%">
                        <tr>
                            <td align="right" width="10%">
                                <label style="color: red">*</label>
                                <asp:Label runat="server" ID="lblPaisBuscar" CssClass="etiqueta10">País:</asp:Label>
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
                                <asp:Button runat="server" ID="btnSiguienteResidencia" Text="Siguiente" Width="100px" OnClick="btnSiguienteResidencia_Click" CssClass="boton150" />
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

        <cc1:TabPanel ID="TabTramite" runat="server" Visible="false">
            <ContentTemplate>
                <asp:Panel runat="server" ID="pnlPersonaInicia" Visible="false" CssClass="panelprincipal">
                    <table>
                        <tr>
                            <td align="right" width="20%">
                                <asp:Label ID="lblTramitador" runat="server" CssClass="etiqueta10">¿Quién realiza el trámite?:</asp:Label>
                            </td>
                            <td align="left" width="70%">
                                <asp:RadioButtonList runat="server" ID="rblTipoPersonaInicia" AutoPostBack="True" OnSelectedIndexChanged="rblTipoPersonaInicia_SelectedIndexChanged" onKeyPress="return disableEnterKey(event)">
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:HiddenField runat="server" ID="hdnNupIniciaTramite" />
                                <asp:Label runat="server" ID="lblNombreCompleto" Visible="false" CssClass="etiqueta10">Buscar Persona:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtNombreCompeto" Visible="false" Width="300px" MaxLength="50" onKeyPress="return disableEnterKey(event)" Enabled="false"></asp:TextBox>
                                <asp:ImageButton ID="btnBuscarTramitador" runat="server" ImageUrl="~/Imagenes/16Buscar.png" Style="height: 16px" Visible="false" OnClick="btnBuscarTramitador_Click" />
                            </td>
                        </tr>

                        <tr>
                            <td colspan="2" align="center">
                                <asp:Panel runat="server" ID="pnlNuevaPersona" Visible="false" CssClass="modalPopup">
                                    <table width="100%">
                                        <tr>
                                            <td align="right">
                                                <label style="color: red">*</label>
                                                <label class="etiqueta10">Primer Apellido:</label></td>
                                            <td align="left">
                                                <asp:TextBox runat="server" ID="txtPrimerApellidoInicia" Width="200px" MaxLength="50" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3"
                                                    runat="server" FilterType="Custom, LowercaseLetters, UppercaseLetters"
                                                    TargetControlID="txtPrimerApellidoInicia" ValidChars="'áéíóúÁÉÍÓÚñÑ ">
                                                </cc1:FilteredTextBoxExtender>
                                            </td>
                                            <td align="right">
                                                <label class="etiqueta10">Segundo Apellido:</label></td>
                                            <td align="left">
                                                <asp:TextBox runat="server" ID="txtSegundoApellidoInicia" Width="200px" MaxLength="50" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4"
                                                    runat="server" FilterType="Custom, LowercaseLetters, UppercaseLetters"
                                                    TargetControlID="txtSegundoApellidoInicia" ValidChars="'áéíóúÁÉÍÓÚñÑ ">
                                                </cc1:FilteredTextBoxExtender>
                                            </td>
                                            <td align="right">
                                                <label class="etiqueta10">Apellido Casada:</label></td>
                                            <td align="left">
                                                <asp:TextBox runat="server" ID="txtApellidoCasadaInicia" Width="200px" MaxLength="50" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5"
                                                    runat="server" FilterType="Custom, LowercaseLetters, UppercaseLetters"
                                                    TargetControlID="txtApellidoCasadaInicia" ValidChars="'áéíóúÁÉÍÓÚñÑ ">
                                                </cc1:FilteredTextBoxExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <label style="color: red">*</label>
                                                <label class="etiqueta10">Primer Nombre:</label></td>
                                            <td align="left">
                                                <asp:TextBox runat="server" ID="txtPrimerNombreInicia" Width="200px" MaxLength="50" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1"
                                                    runat="server" FilterType="Custom, LowercaseLetters, UppercaseLetters"
                                                    TargetControlID="txtPrimerNombreInicia" ValidChars="'áéíóúÁÉÍÓÚñÑ">
                                                </cc1:FilteredTextBoxExtender>

                                            </td>
                                            <td align="right">
                                                <label class="etiqueta10">Segundo Nombre:</label></td>
                                            <td align="left">
                                                <asp:TextBox runat="server" ID="txtSegundoNombreInicia" Width="200px" MaxLength="50" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2"
                                                    runat="server" FilterType="Custom, LowercaseLetters, UppercaseLetters"
                                                    TargetControlID="txtSegundoNombreInicia" ValidChars="'áéíóúÁÉÍÓÚñÑ ">
                                                </cc1:FilteredTextBoxExtender>
                                            </td>
                                            <td align="right">
                                                <label style="color: red">*</label>
                                                <label class="etiqueta10">Fecha Nacimiento:</label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox runat="server" ID="txtFechaNacimientoInicia" ToolTip="DD/MM/YYYY"></asp:TextBox>
                                                <asp:ImageButton ID="btnFechaNacimientoInicia" CssClass="CajaDialogo" runat="server" ImageUrl="~/Imagenes/16calendario.png" />
                                                <cc1:CalendarExtender ID="CalendarExtenderFechaNacimientoInicia" runat="server" CssClass="cal_Theme1"
                                                    TargetControlID="txtFechaNacimientoInicia"
                                                    Format="dd/MM/yyyy"
                                                    PopupButtonID="btnFechaNacimientoInicia">
                                                </cc1:CalendarExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <label style="color: red">*</label>
                                                <label class="etiqueta10">Tipo Documento:</label></td>
                                            <td align="left">
                                                <asp:DropDownList runat="server" ID="ddlTipoDocumentoInicia" AutoPostBack="true" CausesValidation="false" OnSelectedIndexChanged="ddlTipoDocumentoInicia_SelectedIndexChanged"></asp:DropDownList>
                                            </td>
                                            <td align="right">
                                                <label style="color: red">*</label>
                                                <label class="etiqueta10">Número Documento:</label></td>
                                            <td align="left">
                                                <asp:TextBox ID="txtNumeroDocumentoInicia" runat="server"></asp:TextBox>
                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender6"
                                                    runat="server" FilterType="Numbers"
                                                    TargetControlID="txtNumeroDocumentoInicia" ValidChars="">
                                                </cc1:FilteredTextBoxExtender>
                                                <asp:TextBox ID="txtComplementoInicia" runat="server" Width="29px" MaxLength="2"></asp:TextBox>
                                            </td>
                                            <td align="right">
                                                <label style="color: red">*</label>
                                                <label class="etiqueta10">Expedido:</label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlExpedicionInicia" runat="server" Width="150px"></asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <label style="color: red">*</label>
                                                <label class="etiqueta10">Sexo:</label></td>
                                            <td align="left">
                                                <asp:RadioButtonList runat="server" ID="rdblSexoInicia"></asp:RadioButtonList></td>
                                            <td align="right">
                                                <label class="etiqueta10">Estado Civil:</label>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList runat="server" ID="ddlEstadoCivilInicia"></asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <hr />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" width="10%">
                                                <label style="color: red">*</label>
                                                <asp:Label runat="server" ID="lblPaisInicia" CssClass="etiqueta10">País:</asp:Label>
                                            </td>
                                            <td align="left" width="15%">
                                                <asp:HiddenField runat="server" ID="hddPaisInicia" />
                                                <asp:TextBox runat="server" ID="txtPaisInicia" Width="100px" Height="16px" onkeyup="this.value=this.value.toUpperCase()" MaxLength="50" onKeyPress="return disableEnterKey(event)" Enabled="false"></asp:TextBox>
                                                <asp:ImageButton ID="imgBtnPaisInicia" runat="server" ImageUrl="~/Imagenes/16Buscar.png" OnClick="ibtnBuscarPaisInicia_Click" Style="height: 16px" />
                                            </td>
                                            <td align="right" width="15%">
                                                <label style="color: red">*</label>
                                                <asp:Label runat="server" ID="lblLocalidadInicia" CssClass="etiqueta10">Localidad:</asp:Label>
                                            </td>
                                            <td align="left" width="25%">
                                                <asp:HiddenField runat="server" ID="hddLocalidadInicia" />
                                                <asp:TextBox ID="txtLocalidadInicia" runat="server" Width="180px" onkeyup="this.value=this.value.toUpperCase()" MaxLength="50" onKeyPress="return disableEnterKey(event)" Enabled="false"></asp:TextBox>
                                                <asp:ImageButton ID="imgBtnLocalidadInicia" runat="server" ImageUrl="~/Imagenes/16Buscar.png" OnClick="ibtnBuscarLocalidadInicia_Click" Style="height: 16px" />
                                            </td>
                                            <td align="right" width="10%">
                                                <label style="color: red">*</label>
                                                <asp:Label runat="server" ID="lblDireccionInicia" CssClass="etiqueta10" onkeyup="this.value=this.value.toUpperCase()">Dirección:</asp:Label>
                                            </td>
                                            <td align="left" width="30%">
                                                <asp:TextBox runat="server" ID="txtDireccionInicia" Width="300px" MaxLength="100" onkeyup="this.value=this.value.toUpperCase()" onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" TargetControlID="txtDireccionInicia" ValidChars="0123456789.ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnoñpqrstuvwxyz#/áéíóúÁÉÍÓÚ ">
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
                                                <asp:Label runat="server" ID="lblTelefonoFijoInicia" CssClass="etiqueta10">Teléfono Fijo:</asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox runat="server" ID="txtTelefonoFijoInicia" Width="67px" ToolTip="(Longitud 7 Digitos)" MaxLength="7" onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender9"
                                                    runat="server" FilterType="Numbers"
                                                    TargetControlID="txtTelefonoFijoInicia" ValidChars="">
                                                </cc1:FilteredTextBoxExtender>
                                            </td>
                                            <td align="right" class="auto-style57">
                                                <asp:Label runat="server" ID="lblTelefonoCelularInicia" CssClass="etiqueta10">Teléfono Celular:</asp:Label></td>
                                            <td align="left" class="auto-style58">
                                                <asp:TextBox runat="server" ID="txtTelefonoCelularInicia" Width="74px" ToolTip="(Longitud 8 Digitos , Primer digito 6 o 7)" MaxLength="8" onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender10"
                                                    runat="server" FilterType="Numbers"
                                                    TargetControlID="txtTelefonoCelularInicia">
                                                </cc1:FilteredTextBoxExtender>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lblEmailInicia" runat="server" CssClass="etiqueta10">E-Mail:</asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtEmailInicia" runat="server" Width="300px" ToolTip="(Ej. xxx@gmail.com)" onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label runat="server" ID="Label37" CssClass="etiqueta10">&nbsp;</asp:Label>
                                            </td>
                                            <td align="left">&nbsp;
                                            </td>
                                            <td align="right" class="auto-style57">
                                                <asp:Label runat="server" ID="lblTelefonoReferenciaInicia" CssClass="etiqueta10">Teléfono Referencia:</asp:Label></td>
                                            <td align="left" class="auto-style58">
                                                <asp:TextBox runat="server" ID="txtTelefonoReferenciaInicia" Width="74px" ToolTip="(Longitud 8 Digitos , Primer digito 6 o 7)" MaxLength="8" onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" runat="server" FilterType="Numbers" TargetControlID="txtTelefonoReferenciaInicia"></cc1:FilteredTextBoxExtender>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="Label39" runat="server" CssClass="etiqueta10">&nbsp;</asp:Label>
                                            </td>
                                            <td align="left">&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <hr />
                                            </td>
                                        </tr>   
                                        <tr>
                                            <td align="right">
                                                <label style="color: red">*</label>
                                                <asp:Label runat="server" ID="lblPoderNotarial" CssClass="etiqueta10">Nro. Poder Notarial:</asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox runat="server" ID="txtPoderNotarial" Width="67px" MaxLength="7" onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender12"
                                                    runat="server" FilterType="Numbers"
                                                    TargetControlID="txtPoderNotarial" ValidChars="">
                                                </cc1:FilteredTextBoxExtender>
                                            </td>
                                            <td align="right" class="auto-style57">
                                                <asp:Label runat="server" ID="lblAdmPoder" CssClass="etiqueta10">Administración:</asp:Label></td>
                                            <td align="left" class="auto-style58">
                                                <asp:TextBox runat="server" ID="txtAdministracionPoder" Width="74px" MaxLength="20" onkeyup="this.value=this.value.toUpperCase()" onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="Label33" runat="server" CssClass="etiqueta10">Vigencia Poder</asp:Label>
                                            </td>
                                            <td align="left">
                                                <label style="color: red">*</label>
                                                <asp:Label ID="Label32" runat="server" CssClass="etiqueta10">del:</asp:Label>
                                                <asp:TextBox ID="txtVigenciaPoderDel" runat="server" Width="75px" onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                                                <asp:ImageButton ID="imgBtnVigenciaDel" CssClass="CajaDialogo" runat="server" ImageUrl="~/Imagenes/16calendario.png" />
                                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="cal_Theme1"
                                                    TargetControlID="txtVigenciaPoderDel"
                                                    Format="dd/MM/yyyy"
                                                    PopupButtonID="imgBtnVigenciaDel">
                                                </cc1:CalendarExtender>
                                                <asp:Label ID="Label31" runat="server" CssClass="etiqueta10">al:</asp:Label>
                                                <asp:TextBox ID="txtVigenciaPoderAl" runat="server" Width="75px" onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                                                <asp:ImageButton ID="imgBtnVigenciaAl" CssClass="CajaDialogo" runat="server" ImageUrl="~/Imagenes/16calendario.png" />
                                                <cc1:CalendarExtender ID="CalendarExtender3" runat="server" CssClass="cal_Theme1"
                                                    TargetControlID="txtVigenciaPoderAl"
                                                    Format="dd/MM/yyyy"
                                                    PopupButtonID="imgBtnVigenciaAl">
                                                </cc1:CalendarExtender>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button runat="server" ID="btnSiguienteTramite" Text="Siguiente" Width="100px" OnClick="btnSiguienteTramite_Click" CssClass="boton150" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlPersona" runat="server" CssClass="panelceleste">
                    <div style="overflow: auto; width: 700px; height: auto;">
                        <table width="100%">
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:Label runat="server" ID="lblBuscarPersona"><h3>Buscar Persona</h3></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label5" runat="server" CssClass="etiqueta10">Número Documento:</asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtBusNumDoc" runat="server" Width="200px" onkeyup="this.value=this.value.toUpperCase()" onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label6" runat="server" CssClass="etiqueta10">Primer Nombre:</asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtBusNombre" runat="server" Width="200px" onkeyup="this.value=this.value.toUpperCase()" onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label4" runat="server" CssClass="etiqueta10">Primer Apellido:</asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtBusApellido" runat="server" Width="200px" onkeyup="this.value=this.value.toUpperCase()" onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:Button ID="btnBusPersona" runat="server" Text="Buscar" CssClass="boton100" OnClick="btnBusPersona_Click" />&nbsp;
                                    <asp:Button ID="btnCancelarPersona" runat="server" Text="Cancelar" CssClass="boton100" />
                                    <asp:Button ID="btnNuevaPersona" runat="server" Text="Nueva Persona" OnClick="btnNuevaPersona_Click" CssClass="boton100" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="lblBuscarPersona" PopupControlID="pnlPersona" CancelControlID="btnCancelarPersona" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>
                                    <asp:GridView ID="gvPersonaInicio" runat="server" AutoGenerateColumns="False" EnableModelValidation="True" Width="100%"
                                        BorderColor="#DADADA" BorderStyle="Solid" BorderWidth="1px" CssClass="etiqueta8Blue" SkinID="GridView"
                                        EnableTheming="True" Font-Names="Arial" Font-Size="9pt"
                                        DataKeyNames="NUP,IdTipoDocumento,IdEstadoCivil,IdSexo,NumeroDocumento,ComplementoSEGIP,IdDocumentoExpedido,PrimerNombre,SegundoNombre,PrimerApellido,SegundoApellido,ApellidoCasada,FechaNacimiento,
                                        Direccion,Celular,CelularReferencia,Telefono,CorreoElectronico,IdPaisResidencia,IdLocalidad,localidad,pais"
                                        AllowPaging="True" PageSize="5" OnPageIndexChanging="gvPersonaInicio_PageIndexChanging" OnRowCommand="gvPersonaInicio_RowCommand" OnSelectedIndexChanging="gvPersonaInicio_SelectedIndexChanging">
                                        <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:BoundField DataField="NUP" HeaderText="ID"></asp:BoundField>
                                            <asp:BoundField DataField="IdTipoDocumento" Visible="false" HeaderText="Tipo Documento"></asp:BoundField>
                                            <asp:BoundField DataField="IdEstadoCivil" Visible="false" HeaderText="Estado Civil"></asp:BoundField>
                                            <asp:BoundField DataField="IdSexo" Visible="false" HeaderText="Sexo"></asp:BoundField>
                                            <asp:BoundField DataField="NumeroDocumento" HeaderText="Número Documento"></asp:BoundField>
                                            <asp:BoundField DataField="ComplementoSEGIP" Visible="false" HeaderText="Complemento SEGIP"></asp:BoundField>
                                            <asp:BoundField DataField="IdDocumentoExpedido" Visible="false" HeaderText="Documento Expedido"></asp:BoundField>
                                            <asp:BoundField DataField="PrimerNombre" HeaderText="Primer Nombre"></asp:BoundField>
                                            <asp:BoundField DataField="SegundoNombre" HeaderText="Segundo Nombre"></asp:BoundField>
                                            <asp:BoundField DataField="PrimerApellido" HeaderText="Primer Apellido"></asp:BoundField>
                                            <asp:BoundField DataField="SegundoApellido" HeaderText="Segundo Apellido"></asp:BoundField>
                                            <asp:BoundField DataField="ApellidoCasada" HeaderText="Apellido Casada"></asp:BoundField>
                                            <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha Nacimiento" DataFormatString="{0:d}" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                                            <asp:BoundField DataField="Direccion" HeaderText="Direccion" Visible="false"></asp:BoundField>
                                            <asp:BoundField DataField="Celular" HeaderText="Celular" Visible="false"></asp:BoundField>
                                            <asp:BoundField DataField="CelularReferencia" HeaderText="Celular Referencia" Visible="false"></asp:BoundField>
                                            <asp:BoundField DataField="Telefono" HeaderText="Telefono" Visible="false"></asp:BoundField>
                                            <asp:BoundField DataField="CorreoElectronico" HeaderText="CorreoElectronico" Visible="false"></asp:BoundField>
                                            <asp:BoundField DataField="IdPaisResidencia" HeaderText="IdPaisResidencia" Visible="false"></asp:BoundField>
                                            <asp:BoundField DataField="IdLocalidad" HeaderText="IdLocalidad" Visible="false"></asp:BoundField>
                                            <asp:BoundField DataField="localidad" HeaderText="Localidad" Visible="false"></asp:BoundField>
                                            <asp:BoundField DataField="pais" HeaderText="Pais" Visible="false"></asp:BoundField>
                                            <asp:TemplateField HeaderText="Seleccionar">
                                                <ItemTemplate>
                                                    <center>
                                                        <asp:ImageButton ID="imgPersona" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdPersona" ImageUrl="~/Imagenes/sig.png" />
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
                <cc1:ModalPopupExtender ID="mpeLocalidadInicia" runat="server" TargetControlID="lblLocalidadIniciapopup" PopupControlID="pnlLocalidadIniciaPoup" CancelControlID="btnCancelLocalidadInicia" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>
                <asp:Panel ID="pnlLocalidadIniciaPoup" runat="server" CssClass="panelceleste">
                    <div style="overflow: auto; width: 500px; height: auto;">
                        <table width="100%">
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:Label ID="lblLocalidadIniciapopup" runat="server"><h3>Buscar Localidad</h3></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label35" runat="server" CssClass="etiqueta10">Localidad:</asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtLocalidadIniciaBus" runat="server" Width="200px" onkeyup="this.value=this.value.toUpperCase()" onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:Button ID="btnBusLocalidadInicia" runat="server" Text="Buscar" OnClick="btnBusLocalidadInicia_Click" CssClass="boton100" />&nbsp;
                                    <asp:Button ID="btnCancelLocalidadInicia" runat="server" Text="Cancelar" OnClick="btnCancelLocalidadInicia_Click" CssClass="boton100" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:GridView ID="gvLocalidadInicia" runat="server" AutoGenerateColumns="False" EnableModelValidation="True" Width="100%"
                                        BorderColor="#DADADA" BorderStyle="Solid" BorderWidth="1px" CssClass="etiqueta8Blue" SkinID="GridView"
                                        EnableTheming="True" Font-Names="Arial" Font-Size="9pt" GridLines="Horizontal"
                                        AllowPaging="True" PageSize="5" OnPageIndexChanging="gvLocalidadInicia_PageIndexChanging" OnSelectedIndexChanging="gvLocalidadInicia_SelectedIndexChanging"
                                        DataKeyNames="CodigoLocalidad,NombreLocalidad" OnRowCommand="gvLocalidadInicia_RowCommand">
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

                <cc1:ModalPopupExtender ID="mpePaisInicia" runat="server" TargetControlID="lblBuscarPaisInicia" PopupControlID="pnlPaisIniciaPopup" CancelControlID="btnCancelPaisInicia" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>
                <asp:Panel ID="pnlPaisIniciaPopup" runat="server" CssClass="panelceleste">
                    <div style="overflow: auto; width: 500px; height: auto;">
                        <table width="100%">
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:Label ID="lblBuscarPaisInicia" runat="server"><h3>Buscar País</h3></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label38" runat="server" CssClass="etiqueta10">País:</asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtPaisIniciaBus" runat="server" Width="200px" onkeyup="this.value=this.value.toUpperCase()" onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:Button ID="btnBusPaisInicia" runat="server" Text="Buscar" OnClick="btnBusPaisInicia_Click" CssClass="boton100" />&nbsp;
                                    <asp:Button ID="btnCancelPaisInicia" runat="server" Text="Cancelar" OnClick="btnCancelPaisInicia_Click" CssClass="boton100" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:GridView ID="gvPaisInicia" runat="server" AutoGenerateColumns="False" EnableModelValidation="True" Width="100%"
                                        BorderColor="#DADADA" BorderStyle="Solid" BorderWidth="1px" CssClass="etiqueta8Blue" SkinID="GridView"
                                        EnableTheming="True" Font-Names="Arial" Font-Size="9pt" GridLines="Horizontal"
                                        AllowPaging="True" PageSize="5" OnPageIndexChanging="gvPaisInicia_PageIndexChanging" OnSelectedIndexChanging="gvPaisInicia_SelectedIndexChanging"
                                        DataKeyNames="CodigoPais,NombrePais" OnRowCommand="gvPaisInicia_RowCommand">
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

        <cc1:TabPanel ID="TabDocumentos" runat="server" Visible="false">
            <ContentTemplate>
                <asp:Panel ID="pnlDocumentosDetalle" runat="server" Visible="false" CssClass="panelprincipal">
                    <table width="100%">
                        <tr>
                            <td align="right" width="10%">
                                <label style="color: red">*</label>
                                <asp:Label runat="server" ID="Label7" CssClass="etiqueta10">Documentos:</asp:Label>
                            </td>
                            <td align="left" width="70%">
                                <asp:CheckBoxList runat="server" ID="rdbtDocs" onKeyPress="return disableEnterKey(event)"></asp:CheckBoxList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="6" align="center">
                                <asp:Button runat="server" ID="Button2" Text="Siguiente" Width="100px" CssClass="boton150" OnClick="Button2_Click" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </ContentTemplate>
        </cc1:TabPanel>

        <cc1:TabPanel ID="TabAutomatico" runat="server" Visible="false">
            <ContentTemplate>
                <asp:Panel ID="pnlSalarioCotizableE" runat="server" CssClass="panelprincipal">
                    <table width="100%">
                        <tr>
                            <td align="right" width="10%">
                                <label style="color: red">*</label>
                                <asp:Label ID="lblEmpresa" runat="server" CssClass="etiqueta10">Empresa:</asp:Label>
                            </td>
                            <td align="left" width="10%">
                                <asp:TextBox runat="server" ID="txtBuscarEmpresaAutomatico" Width="150px" MaxLength="150" onkeyup="this.value=this.value.toUpperCase()" onKeyPress="return disableEnterKey(event)" Enabled="false"></asp:TextBox>
                                <asp:ImageButton ID="imgBuscarEmpresaAuto" runat="server" ImageUrl="~/Imagenes/16Buscar.png" Style="height: 16px" OnClick="btnBuscarAutomatico_Click1" />
                            </td>
                            <td align="right" width="10%">
                                <asp:Label ID="lblRuc" runat="server" CssClass="etiqueta10">RUC:</asp:Label>
                            </td>
                            <td align="left" width="10%">
                                <asp:TextBox runat="server" ID="txtBuscarRUCAutomatico" MaxLength="15" Width="150px" onKeyPress="return disableEnterKey(event)" Enabled="false"></asp:TextBox>
                            </td>
                            <td align="right" width="10%">
                                <asp:Label ID="lblSectorEmpAuto" runat="server" CssClass="etiqueta10">Sector:</asp:Label>
                            </td>
                            <td align="left" width="20%">
                                <asp:HiddenField runat="server" ID="hddSectorAuto" />
                                <asp:TextBox runat="server" ID="txtSectorAuto" MaxLength="15" Width="150px" onKeyPress="return disableEnterKey(event)" Enabled="false"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <label style="color: red">*</label>
                                <asp:Label ID="Label8" runat="server" CssClass="etiqueta10">Año:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList runat="server" ID="ddlAnioAuto" Width="150px" onKeyPress="return disableEnterKey(event)" AutoPostBack="true" CausesValidation="false" OnSelectedIndexChanged="ddlAnioAuto_SelectedIndexChanged"></asp:DropDownList>
                            </td>
                            <td align="right">
                                <label style="color: red">*</label>
                                <asp:Label ID="Label11" runat="server" CssClass="etiqueta10">Mes:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList runat="server" ID="ddlMesAuto" Width="150px" onKeyPress="return disableEnterKey(event)" AutoPostBack="true" CausesValidation="false"></asp:DropDownList>
                            </td>
                            <td align="right">
                                <label style="color: red">*</label>
                                <asp:Label ID="Label15" runat="server" CssClass="etiqueta10">Documento:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList runat="server" ID="ddlDocumentoAuto" Width="150px" onKeyPress="return disableEnterKey(event)"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <label style="color: red">*</label>
                                <asp:Label ID="Label13" runat="server" CssClass="etiqueta10">Monto Total:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox runat="server" ID="txtMontoAuto" MaxLength="15" Width="150px" onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtendertxtTotal"
                                    runat="server"
                                    TargetControlID="txtMontoAuto" ValidChars="0123456789.">
                                </cc1:FilteredTextBoxExtender>
                            </td>
                            <td align="right">
                                <label style="color: red">*</label>
                                <asp:Label ID="Label14" runat="server" CssClass="etiqueta10">Copia Monto Total:</asp:Label>

                            </td>
                            <td align="left">
                                <asp:TextBox runat="server" ID="txtMontoAuto2" MaxLength="15" Width="150px" onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtendertxtCopiaTotal"
                                    runat="server"
                                    TargetControlID="txtMontoAuto2" ValidChars="0123456789.">
                                </cc1:FilteredTextBoxExtender>
                            </td>
                            <td align="right">
                                <label style="color: red">*</label>
                                <asp:Label ID="Label12" runat="server" CssClass="etiqueta10">Moneda:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList runat="server" ID="ddlMonedaAuto" Width="150px" onKeyPress="return disableEnterKey(event)"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <label style="color: red">*</label>
                                <asp:Label ID="Label25" runat="server" CssClass="etiqueta10">Seguro Social Largo Plazo:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:CheckBox ID="ckboxSeguroSocial" runat="server" Checked="false" OnCheckedChanged="ckboxSeguroSocial_CheckedChanged" AutoPostBack="true" />
                            </td>
                            <td align="right">
                                <asp:Label ID="Label26" runat="server" CssClass="etiqueta10">Sector SSLP:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList runat="server" ID="ddlSectorSSLP" Width="150px" onKeyPress="return disableEnterKey(event)" Enabled="false" AutoPostBack="true" CausesValidation="false" OnSelectedIndexChanged="ddlSectorSSLP_SelectedIndexChanged"></asp:DropDownList>
                            </td>
                            <td align="right">
                                <asp:Label ID="Label27" runat="server" CssClass="etiqueta10">Documento SSLP:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtDocumentoSSLP" runat="server" onkeyup="this.value=this.value.toUpperCase()"
                                    Width="250px" onKeyPress="return disableEnterKey(event)" Enabled="false"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label28" runat="server" CssClass="etiqueta10">Primera Fecha Afiliación:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtPFA" runat="server" onkeyup="this.value=this.value.toUpperCase()"
                                    Width="150px" onKeyPress="return disableEnterKey(event)" Enabled="false"></asp:TextBox>
                            </td>
                            <td align="right">
                                <label style="color: red">*</label>
                                <asp:Label ID="Label29" runat="server" CssClass="etiqueta10">Fecha de Afiliación Válida BD:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:CheckBox ID="ckboxPFA" runat="server" Checked="false" />
                            </td>
                            <td align="right">
                                <asp:Label ID="Label30" runat="server" CssClass="etiqueta10">Salario Referencial:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:GridView ID="gvSalarioRef" runat="server" AutoGenerateColumns="False" EnableModelValidation="True" Width="50%"
                                    BorderColor="#DADADA" BorderStyle="Solid" BorderWidth="1px" CssClass="etiqueta8Blue" SkinID="GridView"
                                    EnableTheming="True" Font-Names="Arial" Font-Size="9pt">
                                    <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="periodo" HeaderText="Periodo" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                                        <asp:BoundField DataField="salario" HeaderText="Salario" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                                    </Columns>
                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
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
                        <tr>
                            <td colspan="6">&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="6">
                                <asp:Button runat="server" ID="btnAgregarAuto" Text="Agregar" CssClass="boton150" OnClick="btnAgregarAuto_Click" Width="100px" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" align="center">
                                <asp:GridView ID="grdSalariosAutomaticos" runat="server" AutoGenerateColumns="False"
                                    CellPadding="4" EnableModelValidation="True"
                                    GridLines="None"
                                    BorderColor="#DADADA" BorderStyle="Solid" BorderWidth="1px" CssClass="etiqueta8Blue" SkinID="GridView"
                                    EnableTheming="True" Font-Names="Arial" Font-Size="9pt" DataKeyNames="Empresa,Ruc,Sector,IdSector,Mes,IdMes,Anio,Total,Moneda,IdDetalleClasificadorMon,Documento,IdDetalleClasificadorDoc,pfa,IdDocumentoSSLP,DocumentoSSLP"
                                    OnRowCommand="grdSalariosAutomaticos_RowCommand">
                                    <AlternatingRowStyle BackColor="White" />
                                    <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                                    <Columns>
                                        <asp:BoundField DataField="Empresa" HeaderText="Empresa" />
                                        <asp:BoundField DataField="Ruc" HeaderText="Ruc" />
                                        <asp:BoundField DataField="Sector" HeaderText="Sector" />
                                        <asp:BoundField DataField="IdSector" HeaderText="IdSector" Visible="false" />
                                        <asp:BoundField DataField="Anio" HeaderText="Año" />
                                        <asp:BoundField DataField="Mes" HeaderText="Mes" />
                                        <asp:BoundField DataField="IdMes" HeaderText="Id Mes" Visible="false" />
                                        <asp:BoundField DataField="Documento" HeaderText="Documento" />
                                        <asp:BoundField DataField="IdDetalleClasificadorDoc" HeaderText="Id Documento" Visible="false" />
                                        <asp:BoundField DataField="Total" HeaderText="Total" />
                                        <asp:BoundField DataField="Moneda" HeaderText="Moneda" />
                                        <asp:BoundField DataField="IdDetalleClasificadorMon" HeaderText="Id Moneda" Visible="false" />
                                        <asp:BoundField DataField="pfa" HeaderText="PFA Válida" />
                                        <asp:BoundField DataField="IdDocumentoSSLP" HeaderText="Id Documento SSLP" Visible="false" />
                                        <asp:BoundField DataField="DocumentoSSLP" HeaderText="Documento SSLP" />
                                        <asp:TemplateField HeaderText="Opciones">
                                            <ItemTemplate>
                                                <center>
                                                    <asp:ImageButton ID="imgEliminarEmpAuto" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdEliminarEmp" ImageUrl="~/imagenes/nueva3/eliminar32.png" />
                                                </center>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EditRowStyle BackColor="#2461BF" />
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#EFF3FB" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" align="center">&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" align="center">
                                <asp:Button runat="server" ID="btnSiguientePA" Text="Siguiente" Width="100px" OnClick="btnSiguientePA_Click" CssClass="boton150" Visible="false" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" align="center">&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="6" align="right">
                                <asp:Label ID="lblResultadoValidacionAutomatica" runat="server" CssClass="text_obs"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>

                <asp:Panel ID="pnlPopup" runat="server" CssClass="panelceleste">
                    <div style="overflow: auto; width: 500px; height: auto;">
                        <table width="100%">
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:Label runat="server" ID="lblEmpresaAutomatico"><h3>Buscar Empresa - Proceso Automático</h3></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblEmpAuto" runat="server" CssClass="etiqueta10">Empresa:</asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtBusEmpAuto" runat="server" Width="200px" onkeyup="this.value=this.value.toUpperCase()" onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label1" runat="server" CssClass="etiqueta10">RUC:</asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtBusRucAuto" runat="server" Width="200px" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:Button ID="btnBusEmpresaAuto" runat="server" Text="Buscar" CssClass="boton100" OnClick="btnBusEmpresaAuto_Click" />&nbsp;
                                    <asp:Button ID="btnCancel" runat="server" Text="Cancelar" CssClass="boton100" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <cc1:ModalPopupExtender ID="ModalPopupExtender" runat="server" TargetControlID="lblEmpresaAutomatico" PopupControlID="pnlPopup" CancelControlID="btnCancel" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>
                                    <asp:GridView ID="gvSeleccionarEmpresaAutomatico" runat="server" AutoGenerateColumns="False" EnableModelValidation="True" Width="100%"
                                        BorderColor="#DADADA" BorderStyle="Solid" BorderWidth="1px" CssClass="etiqueta8Blue" SkinID="GridView"
                                        EnableTheming="True" Font-Names="Arial" Font-Size="9pt"
                                        DataKeyNames="RUC,NombreEmpresa,NroPatronal,DescripcionSector,IdSector"
                                        AllowPaging="True" PageSize="5" OnPageIndexChanging="gvSeleccionarEmpresaAutomatico_PageIndexChanging" OnRowCommand="gvSeleccionarEmpresaAutomatico_RowCommand" OnSelectedIndexChanging="gvSeleccionarEmpresaAutomatico_SelectedIndexChanging">
                                        <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:BoundField DataField="RUC" HeaderText="RUC" ItemStyle-Width="4%"></asp:BoundField>
                                            <asp:BoundField DataField="NombreEmpresa" HeaderText="Nombre Empresa"></asp:BoundField>
                                            <asp:BoundField DataField="NroPatronal" HeaderText="Nro Patronal"></asp:BoundField>
                                            <asp:BoundField DataField="DescripcionSector" HeaderText="Sector"></asp:BoundField>
                                            <asp:BoundField DataField="IdSector" HeaderText="IdSector" Visible="false"></asp:BoundField>
                                            <asp:TemplateField HeaderText="Seleccionar">
                                                <ItemTemplate>
                                                    <center>
                                                        <asp:ImageButton ID="imgEmpresaAuto" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdEmpresaAuto" ImageUrl="~/Imagenes/sig.png" />
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

        <cc1:TabPanel ID="TabManual" runat="server" Visible="false">
            <ContentTemplate>
                <asp:Panel ID="PanelDatosDeclaraciondeEmpresaManualref" runat="server" Visible="false" CssClass="panelprincipal">
                    <table width="100%">
                        <tr>
                            <td align="right" width="10%">
                                <label style="color: red">*</label>
                                <asp:Label ID="lblEmpresaManuale" runat="server" CssClass="etiqueta10">Empresa:</asp:Label>
                            </td>
                            <td align="left" width="10%">
                                <asp:TextBox runat="server" ID="txtEmpresaManual" Width="150px" MaxLength="150" onkeyup="this.value=this.value.toUpperCase()" onKeyPress="return disableEnterKey(event)" Enabled="false"></asp:TextBox>
                                <asp:ImageButton ID="ibtnBuscarEmpresaManual" runat="server" ImageUrl="~/Imagenes/16Buscar.png" Style="height: 16px" OnClick="ibtnBuscarEmpresaManual_Click" />
                            </td>
                            <td align="right" width="10%">
                                <label style="color: red">*</label>
                                <asp:Label ID="lblRUCManual" runat="server" CssClass="etiqueta10">RUC:</asp:Label>
                            </td>
                            <td align="left" width="10%">
                                <asp:TextBox runat="server" ID="txtRucManual" MaxLength="15" Width="150px" onKeyPress="return disableEnterKey(event)" Enabled="false"></asp:TextBox>
                            </td>
                            <td align="right" width="10%">
                                <label style="color: red">*</label>
                                <asp:Label ID="lblSectorManual" runat="server" CssClass="etiqueta10">Sector:</asp:Label>
                            </td>
                            <td align="left" width="20%">
                                <asp:HiddenField runat="server" ID="hddSectorManual" />
                                <asp:DropDownList ID="ddlSectorEmpresaManual" runat="server" Width="100px"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <label style="color: red">*</label>
                                <asp:Label ID="Label19" runat="server" CssClass="etiqueta10">Fecha Ingreso:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtFecha_Ingreso" runat="server"
                                    Width="90px" onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarFecha_Ingreso" CssClass="cal_Theme1" runat="server" OnClientShown="ChangeCalendarView" Format="dd/MM/yyyy"
                                    TargetControlID="txtFecha_Ingreso" OnClientShowing="setDateEmp1" BehaviorID="myDateEmpDesde" PopupButtonID="ImageButton1">
                                </cc1:CalendarExtender>
                                <asp:ImageButton runat="Server" ID="ImageButton1" ImageUrl="~/Imagenes/16calendario.png" AlternateText="Click here to display calendar" />
                                <cc1:MaskedEditExtender ID="txtFecha_Ingreso_MaskedEditExtender" runat="server" TargetControlID="txtFecha_Ingreso" Mask="99/99/9999" MaskType="Date" InputDirection="LeftToRight"
                                    AutoComplete="true" UserDateFormat="DayMonthYear" CultureName="es-MX" ClearTextOnInvalid="true" ClearMaskOnLostFocus="false">
                                </cc1:MaskedEditExtender>
                            </td>
                            <td align="right">
                                <label style="color: red">*</label>
                                <asp:Label ID="Label20" runat="server" CssClass="etiqueta10">Fecha Retiro:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtFecha_Retiro" runat="server" Width="90px" onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarFecha_Retiro" CssClass="cal_Theme1" runat="server" OnClientShown="ChangeCalendarView" Format="dd/MM/yyyy"
                                    TargetControlID="txtFecha_Retiro" OnClientShowing="setDateEmp2" BehaviorID="myDateEmpHasta" PopupButtonID="ImageButton2">
                                </cc1:CalendarExtender>
                                <asp:ImageButton runat="Server" ID="ImageButton2" ImageUrl="~/Imagenes/16calendario.png" AlternateText="Click here to display calendar" />
                                <cc1:MaskedEditExtender ID="txtFecha_Retiro_MaskedEditExtender" runat="server" TargetControlID="txtFecha_Retiro" Mask="99/99/9999" MaskType="Date" InputDirection="LeftToRight"
                                    AutoComplete="true" UserDateFormat="DayMonthYear" CultureName="es-MX" ClearTextOnInvalid="true" ClearMaskOnLostFocus="false">
                                </cc1:MaskedEditExtender>
                            </td>
                            <td align="right">
                                <label style="color: red">*</label>
                                <asp:Label ID="Label21" runat="server" CssClass="etiqueta10">Documento:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList runat="server" ID="ddlDocumentoManual" Width="150px" onKeyPress="return disableEnterKey(event)"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <label style="color: red">*</label>
                                <asp:Label ID="Label23" runat="server" CssClass="etiqueta10">Razón Social:</asp:Label>

                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtRazonSocialEmpresaManual_Alternativo" runat="server" onkeyup="this.value=this.value.toUpperCase()"
                                    Width="150px" onKeyPress="return disableEnterKey(event)" Enabled="false"></asp:TextBox>
                            </td>
                            <td align="right">
                                <asp:Label ID="Label24" runat="server" CssClass="etiqueta10">Nro.Patronal/Ruc/Alter:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtNroPatronal_Ruc_Alternativo" runat="server" onkeyup="this.value=this.value.toUpperCase()"
                                    Width="150px" onKeyPress="return disableEnterKey(event)" Enabled="false"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="6">&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" align="center">
                                <asp:Button runat="server" ID="btnAgregarManual" Text="Agregar" OnClick="btnAgregarManual_Click" Width="100px" CssClass="boton150" />&nbsp;                                
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" align="center">
                                <asp:GridView ID="gvEmpresasmanuales" runat="server"
                                    AutoGenerateColumns="False" CellPadding="4" EnableModelValidation="True"
                                    GridLines="None"
                                    BorderColor="#DADADA" BorderStyle="Solid" BorderWidth="1px" CssClass="etiqueta8Blue" SkinID="GridView"
                                    EnableTheming="True" Font-Names="Arial" Font-Size="9pt" OnRowCommand="gvEmpresasmanuales_RowCommand"
                                    DataKeyNames="Empresa,Ruc,Sector,IdSector,Fecha_Ingreso,Fecha_Retiro,Documento,IdDetalleClasificadorDoc,EmpNoExis,RazonSocialEmpresaManual,NroPatronal_Ruc_Alternativo">
                                    <AlternatingRowStyle BackColor="White" />
                                    <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                                    <Columns>
                                        <asp:BoundField DataField="Empresa" HeaderText="Empresa" />
                                        <asp:BoundField DataField="Ruc" HeaderText="Ruc" />
                                        <asp:BoundField DataField="Sector" HeaderText="Sector" />
                                        <asp:BoundField DataField="IdSector" HeaderText="IdSector" Visible="false" />
                                        <asp:BoundField DataField="Fecha_Ingreso" HeaderText="Fecha Ingreso" />
                                        <asp:BoundField DataField="Fecha_Retiro" HeaderText="Fecha Retiro" />
                                        <asp:BoundField DataField="Documento" HeaderText="Documento" />
                                        <asp:BoundField DataField="IdDetalleClasificadorDoc" HeaderText="Id Documento" Visible="false" />
                                        <asp:BoundField DataField="EmpNoExis" HeaderText="Empresa No Existe" Visible="false" />
                                        <asp:BoundField DataField="RazonSocialEmpresaManual" HeaderText="Razón Social" />
                                        <asp:BoundField DataField="NroPatronal_Ruc_Alternativo" HeaderText="Nro.Patronal/Ruc/Alter" />
                                        <asp:TemplateField HeaderText="Opciones">
                                            <ItemTemplate>
                                                <center>
                                                    <asp:ImageButton ID="imgEliminarEmpManual" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdEliminarEmpManual" ImageUrl="~/imagenes/nueva3/eliminar32.png" />
                                                </center>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EditRowStyle BackColor="#2461BF" />
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#EFF3FB" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" align="center">&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" align="center">
                                <asp:Button runat="server" ID="btnSiguientePM" Text="Siguiente" Width="100px" OnClick="btnSiguientePM_Click" CssClass="boton150" Visible="false" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>

                <asp:Panel ID="pnlEmpresasManual" runat="server" CssClass="panelceleste">
                    <div style="overflow: auto; width: 500px; height: auto;">
                        <table width="100%">
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:Label runat="server" ID="lblEmpresaManual"><h3>Buscar Empresa - Proceso Manual</h3></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label2" runat="server" CssClass="etiqueta10">Empresa:</asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtBusEmpMan" runat="server" Width="200px" onkeyup="this.value=this.value.toUpperCase()" onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label3" runat="server" CssClass="etiqueta10">RUC:</asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtBusRucMan" runat="server" Width="200px" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:Button ID="btnBusEmpresaManual" runat="server" Text="Buscar" CssClass="boton100" OnClick="btnBusEmpresaManual_Click" />&nbsp;
                        <asp:Button ID="btnCancelEmpresaManual" runat="server" Text="Cancelar" CssClass="boton100" />
                                    <asp:Button ID="ibtnNuevaEmpresaManual" runat="server" Text="Nuevo" OnClick="ibtnNuevaEmpresaManual_Click" Width="100px" CssClass="boton150" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <cc1:ModalPopupExtender ID="ModalPopupExtenderEmpresasManual2" runat="server" TargetControlID="lblEmpresaManual" PopupControlID="pnlEmpresasManual" CancelControlID="btnCancelEmpresaManual" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>
                                    <asp:GridView ID="gvSeleccionarEmpresaManual" runat="server" AutoGenerateColumns="False" EnableModelValidation="True"
                                        Width="100%" DataKeyNames="RUC,NombreEmpresa,NroPatronal,DescripcionSector,IdSector" AllowPaging="True" PageSize="5"
                                        BorderColor="#DADADA" BorderStyle="Solid" BorderWidth="1px" CssClass="etiqueta8Blue" SkinID="GridView"
                                        EnableTheming="True" Font-Names="Arial" Font-Size="9pt" OnPageIndexChanging="gvSeleccionarEmpresaManual_PageIndexChanging" OnRowCommand="gvSeleccionarEmpresaManual_RowCommand" OnSelectedIndexChanging="gvSeleccionarEmpresaManual_SelectedIndexChanging">
                                        <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                                        <Columns>
                                            <asp:BoundField DataField="RUC" HeaderText="RUC" ItemStyle-Width="4%"></asp:BoundField>
                                            <asp:BoundField DataField="NombreEmpresa" HeaderText="Nombre Empresa"></asp:BoundField>
                                            <asp:BoundField DataField="NroPatronal" HeaderText="Nro Patronal"></asp:BoundField>
                                            <asp:BoundField DataField="DescripcionSector" HeaderText="Sector"></asp:BoundField>
                                            <asp:BoundField DataField="IdSector" HeaderText="IdSector" Visible="false"></asp:BoundField>
                                            <asp:TemplateField HeaderText="Seleccionar">
                                                <ItemTemplate>
                                                    <center>
                                                        <asp:ImageButton ID="imgEmpresaMan" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdEmpresaMan" ImageUrl="~/Imagenes/sig.png" />
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
                <asp:Button runat="server" ID="btnIniciarTramite" Text="Iniciar Trámite" OnClick="btnIniciarTramite_Click" Visible="false" Style="height: 26px" />
                <asp:Button ID="btnForm02" runat="server" Text="Reporte Form-02" OnClientClick="aspnetForm.target ='_blank';" Visible="false" OnClick="btnForm02_Click" />
                <asp:Button ID="btnReporte" runat="server" OnClick="btnReporte_Click" Text="Reporte" OnClientClick="aspnetForm.target ='_blank';" Visible="false" />
                <asp:Button ID="btnReportePoder" runat="server" OnClick="btnReportePoder_Click" Text="Reporte Poder" Visible="false" />
                <asp:Button runat="server" ID="btnCancelar" Text="Cancelar" CssClass="buttonsNegative" Visible="true" OnClick="btnCancelar_Click" CausesValidation="false" />
            </td>
        </tr>
    </table>
</asp:Content>

