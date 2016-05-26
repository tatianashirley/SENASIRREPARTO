<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmAfiliadoAP.aspx.cs" Inherits="InicioTramite_AfiliadoAP" StylesheetTheme="Modal" %>

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
                <asp:Panel ID="Panel1" runat="server" BackColor="#3366CC">
                    <label onclick="ibtnOpenCloseRegistro_Click" style="color: white">
                        <asp:ImageButton ID="ibtnOpenCloseRegistro" runat="server" ImageUrl="~/Imagenes/16quitar.png" OnClick="ibtnOpenCloseRegistro_Click" />
                        DATOS AFILIADO
                    </label>
                </asp:Panel>
                <asp:Panel ID="pnlRegistro" runat="server" Visible="true" CssClass="panelprincipal">
                    <table width="100%">
                        <tr>
                            <td align="right" width="15%">
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
                                <asp:DropDownList runat="server" ID="ddlTipoDocumento" Width="200px" autofocus="autofocus"></asp:DropDownList>
                            </td>
                            <td align="right">
                                <label style="color: red">*</label>
                                <asp:Label runat="server" ID="lblNumeroDocumento" CssClass="etiqueta10">Número Documento:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtNumeroDocumento" runat="server" MaxLength="20"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="txtNumeroDocumento_FilteredTextBoxExtender"
                                    runat="server" FilterType="Numbers"
                                    TargetControlID="txtNumeroDocumento" ValidChars="">
                                </cc1:FilteredTextBoxExtender>                                
                            </td>                            
                            <td align="right">
                                <label style="color: red">*</label>
                                <asp:Label runat="server" ID="lblFechaNacimiento" CssClass="etiqueta10">Fecha Nacimiento:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox runat="server" ID="txtFechaNacimiento" ToolTip="DD/MM/YYYY"></asp:TextBox>
                                <asp:ImageButton ID="imgcalendarioIni" runat="server" CssClass="CajaDialogo" ImageUrl="~/Imagenes/16calendario.png" />
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="cal_Theme1"
                                    TargetControlID="txtFechaNacimiento"
                                    Format="dd/MM/yyyy"
                                    PopupButtonID="imgcalendarioIni">
                                </cc1:CalendarExtender>
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
                                <asp:Label runat="server" ID="lblAFP" CssClass="etiqueta10">AFP:</asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList runat="server" ID="ddlAFP"></asp:DropDownList>
                            </td>
                            <td align="right">
                                <label style="color: red">*</label>
                                <asp:Label runat="server" ID="lblCUA" CssClass="etiqueta10">NUA:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox runat="server" ID="txtCUA" MaxLength="15"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="txtCUA_FilteredTextBoxExtender"
                                    runat="server" FilterType="Numbers"
                                    TargetControlID="txtCUA" ValidChars="">
                                </cc1:FilteredTextBoxExtender>
                            </td>                           
                        </tr>
                        <tr>
                            <td colspan="6">&nbsp;</td>
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
                                <asp:TextBox ID="txtDescripcion" runat="server" Height="40px" TextMode="MultiLine" Width="463px" MaxLength="50" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
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
                <asp:Button runat="server" ID="btnCancelar" Text="Cancelar" CssClass="buttonsNegative" Visible="true" OnClick="btnCancelar_Click" CausesValidation="false" />
            </td>
        </tr>
    </table>
    
</asp:Content>

