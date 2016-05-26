<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmModificarDatosEmpresa.aspx.cs" Inherits="InicioTramite_ModificarDatosEmpresa" StylesheetTheme="Modal" %>

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
                    <asp:HiddenField runat="server" ID="hddMatriculaORG" />
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
                                <asp:Label runat="server" ID="Label4" CssClass="etiqueta10">Número Trámite:</asp:Label>
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
                <asp:Panel ID="pnlManual" runat="server" BackColor="#3366CC" Visible="false">
                    <label onclick="ibtnOpenCloseDatosResidencia_Click" style="color: white">
                        <asp:ImageButton ID="ibtnOpenCloseDatosResidencia" runat="server" ImageUrl="~/Imagenes/16quitar.png" OnClick="ibtnOpenCloseDatosResidencia_Click" />
                        DATOS EMPRESAS MANUAL
                    </label>
                </asp:Panel>
                <asp:Panel ID="PanelDatosDeclaraciondeEmpresaManualref" runat="server" CssClass="panelprincipal" Visible="false">
                    <table width="100%">
                        <tr>
                            <td colspan="6" align="center">
                                <asp:GridView ID="gvEmpresasmanuales" runat="server"
                                    AutoGenerateColumns="False" CellPadding="4" EnableModelValidation="True"
                                    GridLines="None"
                                    BorderColor="#DADADA" BorderStyle="Solid" BorderWidth="1px" CssClass="etiqueta8Blue" SkinID="GridView"
                                    EnableTheming="True" Font-Names="Arial" Font-Size="9pt" OnRowCommand="gvEmpresasmanuales_RowCommand" OnRowDataBound="gvEmpresasmanuales_RowDataBound"
                                    DataKeyNames="IdEmpresaPersona,Empresa,Ruc,Sector,IdSector,Fecha_Ingreso,Fecha_Retiro,Documento,IdDetalleClasificadorDoc,EmpNoExis,RazonSocialEmpresaManual,NroPatronal_Ruc_Alternativo">
                                    <AlternatingRowStyle BackColor="White" />
                                    <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                                    <Columns>
                                        <asp:BoundField DataField="IdEmpresaPersona" HeaderText="ID" Visible="false" />
                                        <asp:BoundField DataField="Empresa" HeaderText="Empresa" />
                                        <asp:BoundField DataField="Ruc" HeaderText="Ruc" />
                                        <asp:BoundField DataField="Sector" HeaderText="Sector" />
                                        <asp:BoundField DataField="IdSector" HeaderText="IdSector" Visible="false" />
                                        <asp:BoundField DataField="Fecha_Ingreso" HeaderText="Fecha Ingreso" DataFormatString="{0:d}" ItemStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="Fecha_Retiro" HeaderText="Fecha Retiro" DataFormatString="{0:d}" ItemStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="Documento" HeaderText="Documento" />
                                        <asp:BoundField DataField="IdDetalleClasificadorDoc" HeaderText="Id Documento" Visible="false" />
                                        <asp:BoundField DataField="EmpNoExis" HeaderText="Empresa No Existe" Visible="false" />
                                        <asp:BoundField DataField="RazonSocialEmpresaManual" HeaderText="Razón Social" />
                                        <asp:BoundField DataField="NroPatronal_Ruc_Alternativo" HeaderText="Nro.Patronal/Ruc/Alter" />
                                        <asp:TemplateField HeaderText="Opciones">
                                            <ItemTemplate>
                                                <center>
                                                    <asp:ImageButton ID="imgModificarEmpManual" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdModificarEmpManual" ImageUrl="~/imagenes/nueva3/editar32.png" />
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
                            <td colspan="6">
                                <hr />
                            </td>
                        </tr>                        
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
                                <asp:TextBox ID="txtFecha_Ingreso" runat="server" MaxLength="10"
                                    Width="90px" onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarFecha_Ingreso" runat="server" OnClientShown="ChangeCalendarView" Format="dd/MM/yyyy"
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
                                <asp:TextBox ID="txtFecha_Retiro"  MaxLength="10" runat="server" Width="90px" onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarFecha_Retiro" runat="server" OnClientShown="ChangeCalendarView" Format="dd/MM/yyyy"
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
                                <asp:Label ID="Label22" runat="server" CssClass="etiqueta10">Información Adicional:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:CheckBox ID="ckboxHabilitaEmpresaManual" runat="server" Checked="false" OnCheckedChanged="ckboxHabilitaEmpresaManual_CheckedChanged" AutoPostBack="true" />
                            </td>
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
                        </tr>
                        <tr>
                            <td colspan="6">
                                <br />
                            </td>
                        </tr>    
                        <tr>
                            <td colspan="6" align="center">
                                <asp:Button runat="server" ID="btnNuevo" Text="Nuevo" OnClick="btnNuevo_Click" Width="100px" CssClass="boton150" />&nbsp;                                                                
                                <asp:Button runat="server" ID="btnAgregarManual" Text="Agregar" OnClick="btnAgregarManual_Click" Width="100px" CssClass="boton150" />
                            </td>
                        </tr>                       

                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlAuto" runat="server" BackColor="#3366CC" Visible="false">
                    <label onclick="ibtnOpenCloseDatosAuto_Click" style="color: white">
                        <asp:ImageButton ID="ibtnOpenCloseDatosAuto" runat="server" ImageUrl="~/Imagenes/16quitar.png" OnClick="ibtnOpenCloseDatosAuto_Click" />
                        DATOS EMPRESAS AUTOMÁTICO
                    </label>
                </asp:Panel>
                <asp:Panel ID="pnlSalarioCotizableE" runat="server" CssClass="panelprincipal" Visible="false">
                    <table width="100%">
                        <tr>
                            <td colspan="6" align="center">
                                <asp:GridView ID="grdSalariosAutomaticos" runat="server" AutoGenerateColumns="False"
                                    CellPadding="4" EnableModelValidation="True"
                                    GridLines="None"
                                    BorderColor="#DADADA" BorderStyle="Solid" BorderWidth="1px" CssClass="etiqueta8Blue" SkinID="GridView"
                                    EnableTheming="True" Font-Names="Arial" Font-Size="9pt" DataKeyNames="IdEmpresaPersona,Empresa,Ruc,Sector,IdSector,Mes,IdMes,Anio,Total,Moneda,IdDetalleClasificadorMon,Documento,IdDetalleClasificadorDoc,pfa,IdDocumentoSSLP,DocumentoSSLP"
                                    OnRowCommand="grdSalariosAutomaticos_RowCommand" OnRowDataBound="grdSalariosAutomaticos_RowDataBound">
                                    <AlternatingRowStyle BackColor="White" />
                                    <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                                    <Columns>
                                        <asp:BoundField DataField="IdEmpresaPersona" HeaderText="ID" Visible="false" />
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
                                                    <asp:ImageButton ID="imgModificarEmpAuto" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdModificarEmp" ImageUrl="~/imagenes/nueva3/editar32.png" />
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
                            <td colspan="6">
                                <hr />
                            </td>
                        </tr>
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
                                <asp:DropDownList runat="server" ID="ddlMesAuto" Width="150px" onKeyPress="return disableEnterKey(event)"></asp:DropDownList>
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
                            <td colspan="6">
                                <br />
                            </td>
                        </tr>    
                        <tr>
                            <td colspan="6" align="center">
                                <asp:Button runat="server" ID="btnNuevoAuto" Text="Nuevo" OnClick="btnNuevoAuto_Click" Width="100px" CssClass="boton150" />&nbsp;                                                                
                                <asp:Button runat="server" ID="btnAgregarAuto" Text="Agregar" CssClass="boton150" OnClick="btnAgregarAuto_Click" Width="100px" />
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
				<asp:Label ID="lblResultadoValidacionAutomatica" runat="server" CssClass="text_obs"></asp:Label>
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

    <cc1:ModalPopupExtender ID="ModalPopupExtenderEmpresasManual2" runat="server" TargetControlID="lblEmpresaManual" PopupControlID="pnlEmpresasManual" CancelControlID="btnCancelEmpresaManual" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>
    <asp:Panel ID="pnlEmpresasManual" runat="server" CssClass="panelceleste" Visible="false">
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

                    </td>
                </tr>
                <tr>
                    <td colspan="2">
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
    <cc1:ModalPopupExtender ID="ModalPopupExtender" runat="server" TargetControlID="lblEmpresaAutomatico" PopupControlID="pnlPopup" CancelControlID="btnCancel" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>
    <asp:Panel ID="pnlPopup" runat="server" CssClass="panelceleste" Visible="false">
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
</asp:Content>

