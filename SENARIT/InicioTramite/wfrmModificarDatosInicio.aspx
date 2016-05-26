<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmModificarDatosInicio.aspx.cs" Inherits="InicioTramite_ModificarDatosInicio" StylesheetTheme="Modal" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="../js/jquery.js"></script>
    <script type="text/javascript" language="javascript">
        //habilita cambio de años en el calendario
        function ChangeCalendarView(sender, args) {
            sender._switchMode("years", true);
        }
        function setDate(sender, args) {
            var d = new Date(); //Hoy
            d.setYear(d.getFullYear() - 19); //19 años atras 
            $find("myDate").set_selectedDate(d);
        }
    </script>

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
                    <asp:HiddenField runat="server" ID="hfNUP" />
                    <asp:HiddenField runat="server" ID="hddTipo" />
                </td>
            </tr>
        </table>
    </div>
    <table width="100%" border="0" cellpadding="false" cellspacing="false">
        <tr>
            <td align="left" class="divContenedor" style="margin-left: 80px">
                <asp:Panel ID="Panel5" runat="server" BackColor="#3366CC">
                    <label style="color: white">
                        DATOS TRÁMITE
                    </label>
                </asp:Panel>
                <asp:Panel ID="Panel6" runat="server" CssClass="panelprincipal">
                    <table width="100%">
                        <tr>
                            <td align="right" width="15%">
                                <asp:Label runat="server" ID="Label1" CssClass="etiqueta10">Número Trámite:</asp:Label>
                            </td>
                            <td align="left" width="80%">
                                <asp:TextBox runat="server" ID="txtNroTramite" Width="200px" Enabled="false"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="Panel1" runat="server" BackColor="#3366CC">
                    <label onclick="ibtnOpenCloseRegistro_Click" style="color: white">
                        <asp:ImageButton ID="ibtnOpenCloseRegistro" runat="server" ImageUrl="~/Imagenes/16quitar.png" OnClick="ibtnOpenCloseRegistro_Click" />
                        DATOS PERSONALES
                    </label>
                </asp:Panel>
                <asp:Panel ID="pnlRegistro" runat="server" Visible="true" CssClass="panelprincipal">
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
                                <asp:Label runat="server" ID="lblTipoDocumento" CssClass="etiqueta10">Tipo Documento:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList runat="server" ID="ddlTipoDocumento" Width="200px" autofocus="autofocus"></asp:DropDownList>
                            </td>
                            <td align="right">
                                <asp:Label runat="server" ID="lblNumeroDocumento" CssClass="etiqueta10">Número Documento:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtNumeroDocumento" runat="server" MaxLength="20"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="txtNumeroDocumento_FilteredTextBoxExtender"
                                    runat="server" FilterType="Numbers"
                                    TargetControlID="txtNumeroDocumento" ValidChars="">
                                </cc1:FilteredTextBoxExtender>
                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator11" ControlToValidate="ddlExpedicion">*</asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtComplemento" runat="server" Width="29px" MaxLength="2"></asp:TextBox>
                            </td>
                            <td align="right">
                                <asp:Label runat="server" ID="lblExpedido" CssClass="etiqueta10">Expedido:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlExpedicion" runat="server" Width="150px"></asp:DropDownList>
                            </td>
                        </tr>

                        <tr>
                            <td align="right">
                                <asp:Label runat="server" ID="lblAFP" CssClass="etiqueta10">AFP:</asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList runat="server" ID="ddlAFP"></asp:DropDownList>
                            </td>
                            <td align="right">
                                <asp:Label runat="server" ID="lblCUA" CssClass="etiqueta10">CUA:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox runat="server" ID="txtCUA"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="txtCUA_FilteredTextBoxExtender"
                                    runat="server" FilterType="Numbers"
                                    TargetControlID="txtCUA" ValidChars="">
                                </cc1:FilteredTextBoxExtender>
                            </td>
                            <td align="right">
                                <asp:Label runat="server" ID="lblMatricula" CssClass="etiqueta10">Matrícula:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox runat="server" ID="txtMatricula">0</asp:TextBox>
                                <asp:TextBox runat="server" ID="txtMatriculaGenerada" Visible="false"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">&nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlManual" runat="server" BackColor="#3366CC">
                    <label onclick="ibtnOpenCloseDatosResidencia_Click" style="color: white">
                        <asp:ImageButton ID="ibtnOpenCloseDatosResidencia" runat="server" ImageUrl="~/Imagenes/16quitar.png" OnClick="ibtnOpenCloseDatosResidencia_Click" />
                        DATOS INICIO TRAMITE
                    </label>
                </asp:Panel>
                <asp:Panel ID="pnlPersonaInicia" runat="server" CssClass="panelprincipal">
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
                                                <cc1:CalendarExtender ID="CalendarExtenderFechaNacimientoInicia" runat="server"
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
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>

                <asp:Panel ID="Panel3" runat="server" BackColor="#3366CC">
                    <label onclick="ibtnOpenCloseDatosMotivo_Click" style="color: white">
                        <asp:ImageButton ID="ibtnOpenCloseDatosMotivo" runat="server" ImageUrl="~/Imagenes/16quitar.png" OnClick="ibtnOpenCloseDatosMotivo_Click" />
                        DATOS MOTIVO
                    </label>
                </asp:Panel>
                <asp:Panel ID="Panel4" runat="server" CssClass="panelprincipal">
                    <table width="100%">
                        <tr>
                            <td align="right">
                                <label style="color: red">*</label>
                                <label class="etiqueta10">Motivo:</label></td>
                            <td colspan="5">
                                <asp:TextBox ID="txtDescripcion" runat="server" Height="40px" TextMode="MultiLine" Width="463px" MaxLength="200" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="txtDescripcion_FilteredTextBoxExtender"
                                    runat="server" FilterType="Custom, LowercaseLetters, UppercaseLetters,Numbers"
                                    TargetControlID="txtDescripcion" ValidChars="'áéíóúÁÉÍÓÚñÑ.#/ ">
                                </cc1:FilteredTextBoxExtender>
                            </td>
                        </tr>
                    </table>
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
                <asp:Button runat="server" ID="btnIniciarTramite" Text="Guardar" OnClick="btnIniciarTramite_Click" />
                <asp:Button runat="server" ID="btnForm02" Text="Reporte Form-02" OnClientClick="aspnetForm.target ='_blank';" Visible="false" />
                <asp:Button runat="server" ID="btnReporte" Text="Reporte" OnClientClick="aspnetForm.target ='_blank';" Visible="false" />
                <asp:Button runat="server" ID="btnCancelar" Text="Cancelar" CssClass="buttonsNegative" Visible="true" OnClick="btnCancelar_Click" CausesValidation="false" />
            </td>
        </tr>
    </table>

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
                            DataKeyNames="NUP,IdTipoDocumento,IdEstadoCivil,IdSexo,NumeroDocumento,ComplementoSEGIP,IdDocumentoExpedido,PrimerNombre,SegundoNombre,PrimerApellido,SegundoApellido,ApellidoCasada,FechaNacimiento"
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
</asp:Content>

