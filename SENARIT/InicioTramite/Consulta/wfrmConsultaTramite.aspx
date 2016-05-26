<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmConsultaTramite.aspx.cs" Inherits="Consulta_ConsultaTramite" StylesheetTheme="Modal" %>

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
                    <asp:HiddenField runat="server" ID="tipoConsulta" />
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
                        </tr>
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
                        <cc1:TabPanel ID="TabPanel1" runat="server" HeaderText="Datos Residencia">
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
                                            </td>
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
                                                <asp:Label runat="server" ID="Label7" CssClass="etiqueta10">Clase Renta:</asp:Label>
                                            </td>
                                            <td align="left" width="10%">
                                                <asp:TextBox runat="server" ID="txtClaseRenta" Width="220px" Height="16px" MaxLength="50" ReadOnly="true"></asp:TextBox>
                                            </td>
                                            <td align="right" width="15%">
                                                <asp:Label runat="server" ID="Label8" CssClass="etiqueta10">Tipo Trámite:</asp:Label>
                                            </td>
                                            <td align="left" width="25%">
                                                <asp:TextBox ID="txtTipoTramite" runat="server" Width="220px" MaxLength="50" ReadOnly="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="Label13" runat="server" CssClass="etiqueta10">Sector:</asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtSector" runat="server" Width="220px" ReadOnly="true"></asp:TextBox>
                                            </td>
                                            <td align="right">
                                                <asp:Label runat="server" ID="Label14" CssClass="etiqueta10">Funcionario:</asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox runat="server" ID="txtFuncionario" Width="220px" ReadOnly="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="auto-style57">
                                                <asp:Label runat="server" ID="Label15" CssClass="etiqueta10">Fecha Inicio Tramite:</asp:Label>
                                            </td>
                                            <td align="left" class="auto-style58">
                                                <asp:TextBox runat="server" ID="txtInicioTramite" Width="220px" ReadOnly="true"></asp:TextBox>
                                            </td>
                                            <td align="right">
                                                <asp:Label runat="server" ID="Label9" CssClass="etiqueta10">Origen Trámite:</asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox runat="server" ID="txtOrigenTramite" Width="220px" ReadOnly="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="auto-style57">
                                                <asp:Label runat="server" ID="Label11" CssClass="etiqueta10">Oficina Registro:</asp:Label>
                                            </td>
                                            <td align="left" class="auto-style58">
                                                <asp:TextBox runat="server" ID="txtOficinaRegistro" Width="220px" ReadOnly="true"></asp:TextBox>
                                            </td>
                                            <td align="right">
                                                <asp:Label runat="server" ID="Label12" CssClass="etiqueta10">Oficina Notificación:</asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox runat="server" ID="txtOficinaNotificacion" Width="220px" ReadOnly="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="auto-style57">
                                                <asp:Label runat="server" ID="Label16" CssClass="etiqueta10">Tipo Inicio Trámite:</asp:Label>
                                            </td>
                                            <td align="left" class="auto-style58">
                                                <asp:TextBox runat="server" ID="txtTipoInicioTramite" Width="220px" ReadOnly="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </ContentTemplate>
                        </cc1:TabPanel>

                        <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="Datos Inicio Trámite">
                            <ContentTemplate>
                                <asp:Panel ID="Panel3" runat="server" Visible="true" CssClass="panelprincipal">
                                    <table width="100%">
                                        <tr>
                                            <td align="right" width="15%">
                                                <asp:Label runat="server" ID="Label17" CssClass="etiqueta10">Primer Apellido:</asp:Label>
                                            </td>
                                            <td align="left" width="15%">
                                                <asp:TextBox runat="server" ID="txtPrimerApellidoInicia" Width="200px" ReadOnly="true"></asp:TextBox>
                                            </td>
                                            <td align="right" width="15%">
                                                <asp:Label runat="server" ID="Label18" CssClass="etiqueta10">Segundo Apellido:</asp:Label>
                                            </td>
                                            <td align="left" width="15%">
                                                <asp:TextBox runat="server" ID="txtSegundoApellidoInicia" Width="200px" ReadOnly="true"></asp:TextBox>
                                            </td>
                                            <td align="right" width="15%">
                                                <asp:Label runat="server" ID="Label19" CssClass="etiqueta10">Apellido Casada:</asp:Label>
                                            </td>
                                            <td align="left" width="15%">
                                                <asp:TextBox runat="server" ID="txtApellidoCasadaInicia" Width="200px" ReadOnly="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label runat="server" ID="Label20" CssClass="etiqueta10">Primer Nombre:</asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox runat="server" ID="txtPrimerNombreInicia" Width="200px" ReadOnly="true"></asp:TextBox>
                                            </td>
                                            <td align="right">
                                                <asp:Label runat="server" ID="Label21" CssClass="etiqueta10">Segundo Nombre:</asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox runat="server" ID="txtSegundoNombreInicia" Width="200px" ReadOnly="true"></asp:TextBox>
                                            </td>
                                            <td align="right">
                                                <asp:Label runat="server" ID="Label25" CssClass="etiqueta10">Fecha Nacimiento:</asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox runat="server" ID="txtFechaNacimientoInicia" Width="200px" ReadOnly="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label runat="server" ID="Label22" CssClass="etiqueta10">Tipo Documento:</asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox runat="server" ID="txtTipoDocumentoInicia" Width="200px" ReadOnly="true"></asp:TextBox>
                                            </td>
                                            <td align="right">
                                                <asp:Label runat="server" ID="Label23" CssClass="etiqueta10">Número Documento:</asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtNumeroDocumentoInicia" runat="server" MaxLength="20" ReadOnly="true"></asp:TextBox>
                                                <asp:TextBox ID="txtComplementoInicia" runat="server" Width="29px" MaxLength="2" ReadOnly="true"></asp:TextBox>
                                            </td>
                                            <td align="right">
                                                <asp:Label runat="server" ID="Label24" CssClass="etiqueta10">Expedido:</asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtExpedicionInicia" runat="server" MaxLength="20" ReadOnly="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label runat="server" ID="Label26" CssClass="etiqueta10">Sexo:</asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox runat="server" ID="txtSexoInicia" Width="200px" ReadOnly="true"></asp:TextBox>
                                            </td>
                                            <td align="right">
                                                <asp:Label runat="server" ID="Label27" CssClass="etiqueta10">Estado Civil:</asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox runat="server" ID="txtEstadoCivilInicia" Width="200px" ReadOnly="true"></asp:TextBox>
                                            </td>
                                            <td align="right">&nbsp;
                                            </td>
                                            <td align="left">&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" colspan="6">
                                                <hr />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" width="10%">
                                                <asp:Label runat="server" ID="Label28" CssClass="etiqueta10">País:</asp:Label>
                                            </td>
                                            <td align="left" width="10%">
                                                <asp:TextBox runat="server" ID="txtPaisInicia" Width="200px" Height="16px" MaxLength="50" ReadOnly="true">BOLIVIA</asp:TextBox>
                                            </td>
                                            <td align="right" width="15%">
                                                <asp:Label runat="server" ID="Label29" CssClass="etiqueta10">Localidad:</asp:Label>
                                            </td>
                                            <td align="left" width="25%">
                                                <asp:TextBox ID="txtLocalidadInicia" runat="server" Width="200px" MaxLength="50" ReadOnly="true"></asp:TextBox>
                                            </td>
                                            <td align="right" width="10%">
                                                <asp:Label runat="server" ID="Label30" CssClass="etiqueta10">Dirección:</asp:Label>
                                            </td>
                                            <td align="left" width="30%">
                                                <asp:TextBox runat="server" ID="txtDireccionInicia" Width="300px" MaxLength="100" ReadOnly="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label runat="server" ID="Label31" CssClass="etiqueta10">Teléfono Fijo:</asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox runat="server" ID="txtTelefonoInicia" Width="67px" ToolTip="(Longitud 7 Digitos)" MaxLength="7" ReadOnly="true"></asp:TextBox>
                                            </td>
                                            <td align="right" class="auto-style57">
                                                <asp:Label runat="server" ID="Label32" CssClass="etiqueta10">Teléfono Celular:</asp:Label></td>
                                            <td align="left" class="auto-style58">
                                                <asp:TextBox runat="server" ID="txtCelularInicia" Width="74px" ToolTip="(Longitud 8 Digitos , Primer digito 6 o 7)" MaxLength="8" ReadOnly="true"></asp:TextBox>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="Label33" runat="server" CssClass="etiqueta10">E-Mail:</asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtEmailInicia" runat="server" Width="300px" ToolTip="(Ej. xxx@gmail.com)" ReadOnly="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label runat="server" ID="Label34" CssClass="etiqueta10"></asp:Label>
                                            </td>
                                            <td align="left">&nbsp;
                                            </td>
                                            <td align="right" class="auto-style57">
                                                <asp:Label runat="server" ID="Label35" CssClass="etiqueta10">Teléfono Referencia:</asp:Label>
                                            </td>
                                            <td align="left" class="auto-style58">
                                                <asp:TextBox runat="server" ID="txtTelRefInicia" Width="74px" ToolTip="(Longitud 8 Digitos , Primer digito 6 o 7)" MaxLength="8" ReadOnly="true"></asp:TextBox>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="Label36" runat="server" CssClass="etiqueta10"></asp:Label>
                                            </td>
                                            <td align="left">&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" colspan="6">
                                                <hr />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label runat="server" ID="Label37" CssClass="etiqueta10">Nro Poder:</asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox runat="server" ID="txtPoderInicia" Width="74px" ReadOnly="true"></asp:TextBox>
                                            </td>
                                            <td align="right" class="auto-style57">
                                                <asp:Label runat="server" ID="Label38" CssClass="etiqueta10">Administración:</asp:Label>
                                            </td>
                                            <td align="left" class="auto-style58">
                                                <asp:TextBox runat="server" ID="txtAdmInicia" Width="200px" ReadOnly="true"></asp:TextBox>
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="Label39" runat="server" CssClass="etiqueta10">Vigencia:</asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox runat="server" ID="txtPoderDesdeInicia" Width="80px" ReadOnly="true"></asp:TextBox>
                                                <asp:TextBox runat="server" ID="txtPoderHastaInicia" Width="80px" ReadOnly="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </ContentTemplate>
                        </cc1:TabPanel>

                        <cc1:TabPanel ID="TabPanel3" runat="server" HeaderText="Datos Documentos">
                            <ContentTemplate>
                                <asp:Panel ID="Panel7" runat="server" Visible="true" CssClass="panelprincipal">
                                    <table width="100%">
                                        <tr>
                                            <td align="center">
                                                <asp:GridView ID="gvDocumentos" runat="server" EnableModelValidation="True"
                                                    CellPadding="4" ForeColor="#333333" EnableTheming="True" Font-Names="Arial" Font-Size="9pt"
                                                    CssClass="mGrid" PagerStyle-CssClass="pgr" GridLines="None" AutoGenerateColumns="False"
                                                    SkinID="GridView" AlternatingRowStyle-CssClass="alt">
                                                    <Columns>
                                                        <asp:BoundField DataField="Documentos" HeaderText="Documentos" />
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

                        <cc1:TabPanel ID="TabPanel5" runat="server" HeaderText="Datos Empresa">
                            <ContentTemplate>
                                <asp:Panel ID="Panel5" runat="server" Visible="true" CssClass="panelprincipal">
                                    <table width="100%">
                                        <tr>
                                            <td align="center">
                                                <asp:GridView ID="gvEmpresaManual" runat="server" EnableModelValidation="True" Visible="false"
                                                    CellPadding="4" ForeColor="#333333" EnableTheming="True" Font-Names="Arial" Font-Size="9pt"
                                                    CssClass="mGrid" PagerStyle-CssClass="pgr" GridLines="None" AutoGenerateColumns="False"
                                                    SkinID="GridView" AlternatingRowStyle-CssClass="alt">
                                                    <Columns>
                                                        <asp:BoundField DataField="NombreEmpresa" HeaderText="Empresa" />
                                                        <asp:BoundField DataField="IdEmpresa" HeaderText="Ruc" />
                                                        <asp:BoundField DataField="Sector" HeaderText="Sector" />
                                                        <asp:BoundField DataField="PeriodoInicio" HeaderText="Fecha Ingreso" DataFormatString="{0:d}" />
                                                        <asp:BoundField DataField="PeriodoFin" HeaderText="Fecha Retiro" DataFormatString="{0:d}" />
                                                        <asp:BoundField DataField="Documento" HeaderText="Documento" />
                                                        <asp:BoundField DataField="NombreEmpresaDeclarada" HeaderText="Razón Social" />
                                                        <asp:BoundField DataField="NroPatronalRucAlt" HeaderText="Nro.Patronal/Ruc/Alter" />
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

                                                <asp:GridView ID="gvEmpresaAutomatica" runat="server" EnableModelValidation="True" Visible="false"
                                                    CellPadding="4" ForeColor="#333333" EnableTheming="True" Font-Names="Arial" Font-Size="9pt"
                                                    CssClass="mGrid" PagerStyle-CssClass="pgr" GridLines="None" AutoGenerateColumns="False"
                                                    SkinID="GridView" AlternatingRowStyle-CssClass="alt">
                                                    <Columns>
                                                        <asp:BoundField DataField="NombreEmpresa" HeaderText="Empresa" />
                                                        <asp:BoundField DataField="IdEmpresa" HeaderText="Ruc" />
                                                        <asp:BoundField DataField="Sector" HeaderText="Sector" />
                                                        <asp:BoundField DataField="Anio" HeaderText="Año" />
                                                        <asp:BoundField DataField="Mes" HeaderText="Mes" />
                                                        <asp:BoundField DataField="Documento" HeaderText="Documento" />
                                                        <asp:BoundField DataField="Monto" HeaderText="Total" />
                                                        <asp:BoundField DataField="Moneda" HeaderText="Moneda" />
                                                        <asp:BoundField DataField="ValidaPFA" HeaderText="PFA Válida" />
                                                        <asp:BoundField DataField="SeguridadSalario" HeaderText="Documento SSLP" />
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
                <asp:Button runat="server" ID="btnControlCalidad" Text="Control Calidad" CssClass="buttonsNegative" Visible="false" OnClick="btnControlCalidad_Click" CausesValidation="false" />
                <asp:Button runat="server" ID="btnCancelar" Text="Cancelar" CssClass="buttonsNegative" Visible="true" OnClick="btnCancelar_Click" CausesValidation="false" />
            </td>
        </tr>
    </table>

    <cc1:ModalPopupExtender ID="mpControlCalidad" runat="server" CancelControlID="btnNoJustificar" TargetControlID="lblObservadoi" PopupControlID="pnlJustificar" BackgroundCssClass="modalBackground">
    </cc1:ModalPopupExtender>
    <asp:Panel runat="server" ID="pnlJustificar" CssClass="panelceleste" Visible="false">
        <table align="center" cellpadding="0" cellspacing="0" width="700px">
            <tr>
                <td align="center" colspan="2">
                    <asp:Label ID="lblObservadoi" runat="server"><h2>Control de Calidad</h2></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="Label40" runat="server" CssClass="etiqueta10">Trámite:</asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox runat="server" Enabled="false" ID="txtTramitei" onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <label style="color: red">*</label>
                    <asp:Label ID="lblRevisioni" runat="server" CssClass="etiqueta10">Revisión:</asp:Label>
                </td>
                <td align="left">
                    <asp:CheckBox runat="server" ID="rdbtCheck" onKeyPress="return disableEnterKey(event)"></asp:CheckBox>
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
                    <asp:Button CssClass="buttonGreen" Text="Guardar" runat="server" ID="btnSiJustificar" OnClick="btnSiJustificar_Click" />&nbsp;
                        <asp:Button CssClass="buttonRed" Text="Cancelar" runat="server" ID="btnNoJustificar" />
                </td>
            </tr>
        </table>
    </asp:Panel>

</asp:Content>

