﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmModificarDatosAPO.aspx.cs" Inherits="InicioTramite_ModificarDatosAPO" StylesheetTheme="Modal" %>

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
        function efecto() {
            $('#cargando').show();
        }
        function efecto2() {
            $('#cargando2').show();
        }
        function efecto3() {
            $('#cargando3').show();
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
                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator11" ControlToValidate="ddlExpedicion">*</asp:RequiredFieldValidator>
                                <asp:TextBox ID="txtComplemento" runat="server" Width="29px" MaxLength="2"></asp:TextBox>
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
                                <asp:TextBox runat="server" ID="txtFechaNacimiento" ToolTip="DD/MM/YYYY"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtenderFechaNacimiento" runat="server"
                                    TargetControlID="txtFechaNacimiento" OnClientShowing="setDate" BehaviorID="myDate">
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
                                <asp:TextBox runat="server" ID="txtFechaFallecimient" ToolTip="DD/MM/YYYY"></asp:TextBox>
                                <asp:ImageButton ID="btncalendarff" runat="server" CssClass="CajaDialogo" ImageUrl="~/Imagenes/16calendario.png" />
                                <cc1:CalendarExtender ID="CalendarExtendertxtFechaFallecimient" runat="server"
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
                                <asp:TextBox runat="server" ID="txtCUA"></asp:TextBox>
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
                                <asp:TextBox runat="server" ID="txtMatricula">0</asp:TextBox>
                                <asp:TextBox runat="server" ID="txtMatriculaGenerada" Visible="false"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">&nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="Panel2" runat="server" BackColor="#3366CC">
                    <label onclick="ibtnOpenCloseDatosResidencia_Click" style="color: white">
                        <asp:ImageButton ID="ibtnOpenCloseDatosResidencia" runat="server" ImageUrl="~/Imagenes/16quitar.png" OnClick="ibtnOpenCloseDatosResidencia_Click" />
                        DATOS RESIDENCIA
                    </label>
                </asp:Panel>
                <asp:Panel ID="pnlDatosResidencia" runat="server" CssClass="panelprincipal">
                    <table width="100%">
                        <tr>
                            <td align="right" width="10%">
                                <label style="color: red">*</label>
                                <asp:Label runat="server" ID="lblLocalidad" CssClass="etiqueta10">País:</asp:Label>
                            </td>
                            <td align="left" width="10%">
                                <asp:TextBox runat="server" ID="txtPais" Width="200px" Height="16px" onkeyup="this.value=this.value.toUpperCase()" MaxLength="50">BOLIVIA</asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="txtPais_FilteredTextBoxExtender"
                                    runat="server" FilterType="Custom, LowercaseLetters, UppercaseLetters"
                                    TargetControlID="txtPais" ValidChars="'áéíóúÁÉÍÓÚñÑ ">
                                </cc1:FilteredTextBoxExtender>
                            </td>
                            <td align="right" width="15%">
                                <label style="color: red">*</label>
                                <asp:Label runat="server" ID="Label10" CssClass="etiqueta10">Localidad:</asp:Label>
                            </td>
                            <td align="left" width="25%">
                                <asp:HiddenField runat="server" ID="hdnIdLocalidad" />
                                <asp:TextBox ID="txtBuscarLocalidad" runat="server" Width="200px" onkeyup="this.value=this.value.toUpperCase()" MaxLength="50"></asp:TextBox>
                                <asp:ImageButton ID="ibtnBuscarLocalidad" runat="server" ImageUrl="~/Imagenes/16Buscar.png" OnClick="ibtnBuscarLocalidad_Click" Style="height: 16px" />
                            </td>
                            <td align="right" width="10%">
                                <label style="color: red">*</label>
                                <asp:Label runat="server" ID="lblDireccion" CssClass="etiqueta10" onkeyup="this.value=this.value.toUpperCase()">Dirección:</asp:Label>
                            </td>
                            <td align="left" width="30%">
                                <asp:TextBox runat="server" ID="txtDireccion" Width="300px" MaxLength="100" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
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
                                <asp:TextBox runat="server" ID="txtTelefono" Width="67px" ToolTip="(Longitud 7 Digitos)" MaxLength="7"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="txtTelefono_FilteredTextBoxExtender"
                                    runat="server" FilterType="Numbers"
                                    TargetControlID="txtTelefono" ValidChars="">
                                </cc1:FilteredTextBoxExtender>
                            </td>
                            <td align="right" class="auto-style57">
                                <asp:Label runat="server" ID="lblCelular" CssClass="etiqueta10">Teléfono Celular:</asp:Label></td>
                            <td align="left" class="auto-style58">
                                <asp:TextBox runat="server" ID="txtCelular" Width="74px" ToolTip="(Longitud 8 Digitos , Primer digito 6 o 7)" MaxLength="8"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="txtCelular_FilteredTextBoxExtender"
                                    runat="server" FilterType="Numbers"
                                    TargetControlID="txtCelular">
                                </cc1:FilteredTextBoxExtender>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblEmail" runat="server" CssClass="etiqueta10">E-Mail:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtEmail" runat="server" Width="300px" ToolTip="(Ej. xxx@gmail.com)"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">&nbsp;
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlSimilitud" runat="server" BackColor="#3366CC" Visible="false">
                    <label onclick="ibtnOpenCloseDatosResidencia_Click" style="color: white">
                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Imagenes/16quitar.png" OnClick="ibtnOpenCloseDatosResidencia_Click" />
                        SIMILITUDES
                    </label>
                </asp:Panel>
                <asp:Panel ID="pnlSimilitudes" runat="server" CssClass="panelprincipal" Visible="false">
                    <table width="100%" border="0" cellpadding="false" cellspacing="false" class="table">
                        <tr>
                            <td align="center" colspan="2">
                                <asp:GridView ID="gvPersona" runat="server"
                                    EnableModelValidation="True" AllowPaging="True" PageSize="10"
                                    AutoGenerateColumns="False" OnPageIndexChanging="gvPersona_PageIndexChanging"
                                    CellPadding="4"
                                    ForeColor="#333333"
                                    OnSelectedIndexChanging="gvPersona_SelectedIndexChanging"
                                    EnableTheming="True"
                                    Font-Names="Arial"
                                    Font-Size="9pt"
                                    CssClass="mGrid"
                                    PagerStyle-CssClass="pgr"
                                    GridLines="None" OnRowCommand="gvPersona_RowCommand"
                                    DataKeyNames="nup,primerNombre,segundoNombre,paterno,materno,casada,fechanacimiento,nua,matricula,carnet,complementoSEGIP,Habilitado,Tabla" OnRowDataBound="gvPersona_RowDataBound">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="nup" HeaderText="NUP" Visible="false" />
                                        <asp:BoundField DataField="primerNombre" HeaderText="Primer Nombre" />
                                        <asp:BoundField DataField="segundoNombre" HeaderText="Segundo Nombre" />
                                        <asp:BoundField DataField="paterno" HeaderText="Primer Apellido" />
                                        <asp:BoundField DataField="materno" HeaderText="Segundo Apellido" />
                                        <asp:BoundField DataField="casada" HeaderText="Apellido Casada" />
                                        <asp:BoundField DataField="fechanacimiento" HeaderText="Fecha Nacimiento" DataFormatString="{0:d}" ItemStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="nua" HeaderText="CUA" ItemStyle-HorizontalAlign="Right" />
                                        <asp:BoundField DataField="matricula" HeaderText="Matrícula" ItemStyle-HorizontalAlign="Right" />
                                        <asp:BoundField DataField="carnet" HeaderText="Número Documento" ItemStyle-HorizontalAlign="Right" />
                                        <asp:BoundField DataField="complementoSEGIP" HeaderText="Complemento SEGIP" ItemStyle-HorizontalAlign="Left" />
                                        <asp:BoundField DataField="Habilitado" HeaderText="Prestación Habilitada" FooterStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="tabla" HeaderText="Tabla" Visible="false" />
                                        <asp:TemplateField HeaderText="Trámite">
                                            <ItemTemplate>
                                                <center>
                                                    <asp:ImageButton ID="imgTramite" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdTramite" ImageUrl="~/imagenes/nueva3/siguiente32.png" />
                                                    <asp:ImageButton ID="imgBloquear" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdBloquear" ImageUrl="~/imagenes/nueva3/bloquear32.png" />
                                                    <asp:ImageButton ID="ImgActualizar" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdActualizar" ImageUrl="~/imagenes/nueva3/editar32.png" />
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
                                    <SelectedRowStyle BackColor="#FFFF99" />
                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <PagerSettings Mode="NumericFirstLast" PageButtonCount="10" FirstPageText="Primera" LastPageText="Última" />
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                </asp:GridView>
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
                <asp:Button runat="server" ID="btnVerificar" Text="Verificar" OnClick="btnVerificar_Click" OnClientClick="efecto2()" />
                <asp:Button runat="server" ID="btnCancelar" Text="Cancelar" CssClass="buttonsNegative" Visible="true" OnClick="btnCancelar_Click" CausesValidation="false" />
            </td>
        </tr>
    </table>
    <center>
        <div id="cargando2" style="display: none;">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/ajax_loader_blue_32.GIF" />
        </div>
    </center>

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
                        <asp:TextBox ID="txtBusLocalidad" runat="server" Width="200px" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
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
                            DataKeyNames="IdLocalidad,NombreLocalidad" OnRowCommand="gvGeo_RowCommand">
                            <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="IdLocalidad" Visible="true" HeaderText="ID" InsertVisible="false" ItemStyle-Width="4%" />
                                <asp:BoundField DataField="NombreLocalidad" HeaderText="Localidad" ItemStyle-Width="20%" HeaderStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="IdSeccion" Visible="false" HeaderText="ID" ItemStyle-Width="4%" />
                                <asp:BoundField DataField="NombreSeccionMunicipal" HeaderText="Sección" ItemStyle-Width="25%" HeaderStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="IdProvincia" Visible="false" HeaderText="ID" ItemStyle-Width="4%" />
                                <asp:BoundField DataField="NombreProvincia" HeaderText="Provincia" ItemStyle-Width="18%" HeaderStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="IdDepartamento" Visible="false" HeaderText="ID" ItemStyle-Width="4%" />
                                <asp:BoundField DataField="NombreDepartamento" HeaderText="Departamento" ItemStyle-Width="18%" HeaderStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="CodigoLocalidad" Visible="false" HeaderText="Loc" ItemStyle-Width="4%" />
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

</asp:Content>

