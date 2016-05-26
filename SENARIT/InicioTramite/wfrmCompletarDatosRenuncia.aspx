<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmCompletarDatosRenuncia.aspx.cs" Inherits="Administracion_CompletarDatosRenuncia" StylesheetTheme="Modal" %>

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
                <td width="70%" align="center">
                    <asp:Label ID="lblSubTitulo" runat="server" Font-Bold="True" ForeColor="#CC0000" Font-Size="17px"></asp:Label>
                </td>
                <td align="right" width="20%">
                    <asp:Label ID="lblTipo" runat="server" ForeColor="#CC0000"></asp:Label>
                    <asp:HiddenField runat="server" ID="hddIdTramite" />
                    <asp:HiddenField runat="server" ID="hddIdGrupoBeneficio" />
                    <asp:HiddenField runat="server" ID="hddTipo" />
                    <asp:HiddenField runat="server" ID="hddOrigen" />
                </td>
            </tr>
        </table>
    </div>

    <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0">

        <cc1:TabPanel ID="TabRenuncia" runat="server" Visible="false">
            <ContentTemplate>
                <asp:Panel ID="PanelPrerenuncia" runat="server" CssClass="panelprincipal">
                    <table align="center" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td align="right" width="15%">
                                <label class="etiqueta10">Primer Apellido:</label></td>
                            <td align="left" width="15%">
                                <asp:TextBox ID="txtPrimerApellido" runat="server" Enabled="False" Width="200px"></asp:TextBox>
                            </td>
                            <td align="right" width="15%">
                                <label class="etiqueta10">Segundo Apellido:</label></td>
                            <td align="left" width="15%">
                                <asp:TextBox ID="txtSegundoApellido" runat="server" Enabled="False" Width="200px"> </asp:TextBox>
                            </td>
                            <td align="right" width="15%">
                                <label class="etiqueta10">Apellido Casada:</label></td>
                            <td align="left" width="15%">
                                <asp:TextBox ID="txtApellidoCasada" runat="server" Enabled="False" Width="200px"> </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <label class="etiqueta10">Primer Nombre:</label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtPrimerNombre" runat="server" Enabled="False" Width="200px"></asp:TextBox>
                            </td>
                            <td align="right">
                                <label class="etiqueta10">Segundo Nombre:</label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtSegundoNombre" runat="server" Enabled="False" Width="200px"></asp:TextBox>
                            </td>
                            <td align="right">
                                <label class="etiqueta10">Fecha Nacimiento:</label></td>
                            <td align="left">
                                <asp:TextBox ID="txtFechaNac" runat="server" Enabled="False" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <label class="etiqueta10">Número Documento:</label></td>
                            <td align="left">
                                <asp:TextBox ID="txtNumeroDocumento" runat="server" Enabled="False" Width="200px"></asp:TextBox>
                            </td>
                            <td align="right">
                                <label class="etiqueta10">Matrícula:</label></td>
                            <td align="left">
                                <asp:TextBox ID="txtMatricula" runat="server" Enabled="False" Width="200px"></asp:TextBox>
                            </td>
                            <td align="right">
                                <label class="etiqueta10">CUA:</label></td>
                            <td align="left">
                                <asp:TextBox ID="txtCUA" runat="server" Enabled="False" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <label style="color: red">*</label>
                                <label class="etiqueta10">Observaciones:</label></td>
                            <td colspan="5">
                                <asp:TextBox ID="txtDescripcion" runat="server" Height="80px" TextMode="MultiLine" Width="500px" MaxLength="200" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="txtDescripcion_FilteredTextBoxExtender"
                                    runat="server" FilterType="Custom, LowercaseLetters, UppercaseLetters,Numbers"
                                    TargetControlID="txtDescripcion" ValidChars="'áéíóúÁÉÍÓÚñÑ.#/ ">
                                </cc1:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="6">&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="6">
                                <asp:Button ID="btnSiguienteRenuncia" runat="server" Text="Siguiente" OnClick="btnSiguienteRenuncia_Click" Visible="true" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </ContentTemplate>
        </cc1:TabPanel>

        <cc1:TabPanel ID="TabDocumentos" runat="server" Visible="false">
            <ContentTemplate>
                <asp:Panel ID="Panel1" runat="server" CssClass="panelprincipal">
                    <table align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td align="right" width="20%">
                                <label style="color: red">*</label>
                                <asp:Label runat="server" ID="Label4" CssClass="etiqueta10">Requisitos Indispensables:</asp:Label>
                            </td>
                            <td align="left" width="70%">
                                <asp:CheckBoxList runat="server" ID="rdbtDocs1" onKeyPress="return disableEnterKey(event)" Font-Size="Small"></asp:CheckBoxList>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right">
                                <label style="color: red">*</label>
                                <asp:Label runat="server" ID="Label7" CssClass="etiqueta10">Requisitos por Sector:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:CheckBoxList runat="server" ID="rdbtDocs2" onKeyPress="return disableEnterKey(event)" Font-Size="Small"></asp:CheckBoxList>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4">&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4">
                                <asp:Button ID="btnSiguienteDoc" runat="server" Text="Siguiente" OnClick="btnSiguienteDoc_Click" Visible="true" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </ContentTemplate>
        </cc1:TabPanel>

        <cc1:TabPanel ID="TabManual" runat="server" Visible="false">
            <ContentTemplate>
                <asp:Panel ID="Panel2" runat="server" CssClass="panelprincipal">
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
                                <asp:TextBox ID="txtFecha_Ingreso" runat="server" Width="90px" MaxLength="10" onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="cal_Theme1" TargetControlID="txtFecha_Ingreso" Format="dd/MM/yyyy" PopupButtonID="imgcalendarioIni" OnClientShowing="setDateEmp1" BehaviorID="myDateEmpDesde" />
                                <asp:ImageButton ID="imgcalendarioIni" runat="server" ImageUrl="~/Imagenes/16calendario.png" AlternateText="Click here to display calendar" />
                                <cc1:MaskedEditExtender ID="txtFecha_Ingreso_me" runat="server" TargetControlID="txtFecha_Ingreso" Mask="99/99/9999" MaskType="Date" InputDirection="LeftToRight"
                                    AutoComplete="true" UserDateFormat="DayMonthYear" CultureName="es-MX" ClearTextOnInvalid="true" ClearMaskOnLostFocus="false">
                                </cc1:MaskedEditExtender>
                            </td>
                            <td align="right">
                                <label style="color: red">*</label>
                                <asp:Label ID="Label20" runat="server" CssClass="etiqueta10">Fecha Retiro:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtFecha_Retiro" runat="server" Width="90px" MaxLength="10" onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="cal_Theme1" TargetControlID="txtFecha_Retiro" Format="dd/MM/yyyy" PopupButtonID="imgcalendarioFin" OnClientShowing="setDateEmp2" BehaviorID="myDateEmpHasta" />
                                <asp:ImageButton ID="imgcalendarioFin" runat="server" ImageUrl="~/Imagenes/16calendario.png" AlternateText="Click here to display calendar" />
                                <cc1:MaskedEditExtender ID="txtFecha_Retiro_me" runat="server" TargetControlID="txtFecha_Retiro" Mask="99/99/9999" MaskType="Date" InputDirection="LeftToRight"
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
                            <td align="center" colspan="6">&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="6">
                                <asp:Button ID="btnSiguienteEmpresa" runat="server" Text="Siguiente" OnClick="btnSiguienteEmpresa_Click" Visible="false" />
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
            <td colspan="4" align="right">
                <asp:Label ID="lblConfirmacion" runat="server" CssClass="text_obs"></asp:Label>
                <asp:HiddenField runat="server" ID="hddIdTramiteManual" />
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:ImageButton ID="imgVolver" runat="server" ImageUrl="~/Imagenes/32Volver.png" ToolTip="Volver a la Página anterior" OnClick="btnVolver_Click" Visible="false" />
                <asp:Button ID="btnRenunciaInicial" runat="server" Text="Guardar" OnClick="btnRenunciaInicial_Click" OnClientClick="efecto('cargando2')" Visible="false" Style="height: 26px" />
                <asp:Button ID="btnConfirmarRenuncia" runat="server" Text="Guardar" OnClick="btnConfirmarRenuncia_Click" OnClientClick="efecto('cargando2')" Visible="false" Style="height: 26px" />
                <asp:Button ID="btnCancelarRenuncia" runat="server" Text="Cancelar Renuncia Inicial" OnClick="btnCancelarRenuncia_Click" OnClientClick="efecto('cargando2')" Visible="false" Style="height: 26px" />
                <asp:Button ID="btnReporteRenuncia" runat="server" Text="Reporte Form-03" OnClick="btnReporteRenuncia_Click" OnClientClick="aspnetForm.target ='_blank';" Visible="false" />
                <asp:Button ID="btnReporte" runat="server" Text="Reporte" OnClick="btnReporte_Click" OnClientClick="aspnetForm.target ='_blank';" Visible="false" />
                <asp:Button ID="btnForm02" runat="server" Text="Reporte Form-02" OnClientClick="aspnetForm.target ='_blank';" OnClick="btnForm02_Click" Visible="false" />
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="buttonsNegative" Visible="true" OnClick="btnCancelar_Click" CausesValidation="false" />
            </td>
        </tr>
    </table>
    <center>
        <div id="cargando2" style="display: none;">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/ajax_loader_blue_32.GIF" />
        </div>
    </center>

</asp:Content>

