<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmRegistroTramite.aspx.cs" Inherits="wfrmRegistroTramite" StylesheetTheme="Modal" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" language="javascript" src="../js/InicioTramite/comunes.js"></script>
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
                <td width="10%" align="right">
                    <asp:Label ID="lblPrecision" runat="server" Font-Bold="True" Font-Size="10px"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <asp:Panel ID="pnlCabeceraMalla" runat="server">
        <table width="100%" border="0" cellpadding="false" cellspacing="false">
            <tr>
                <td align="right" width="25%">
                    <label class="etiqueta10">Primer Apellido:</label></td>
                <td align="left" width="10%">
                    <asp:TextBox ID="txtPrimerApellido" runat="server" onkeyup="this.value=this.value.toUpperCase()" Width="200px" MaxLength="30" onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                    <cc1:FilteredTextBoxExtender ID="txtPrimerApellido_FilteredTextBoxExtender"
                        runat="server" FilterType="Custom, LowercaseLetters, UppercaseLetters"
                        TargetControlID="txtPrimerApellido" ValidChars="'áéíóúÁÉÍÓÚñÑ ">
                    </cc1:FilteredTextBoxExtender>
                </td>
                <td align="right" width="10%">
                    <label class="etiqueta10">Segundo Apellido:</label></td>
                <td align="left" width="30%">
                    <asp:TextBox ID="txtSegundoApellido" runat="server" onkeyup="this.value=this.value.toUpperCase()" Width="200px" MaxLength="30" onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                    <cc1:FilteredTextBoxExtender ID="txtSegundoApellido_FilteredTextBoxExtender"
                        runat="server" FilterType="Custom, LowercaseLetters, UppercaseLetters"
                        TargetControlID="txtSegundoApellido" ValidChars="'áéíóúÁÉÍÓÚñÑ ">
                    </cc1:FilteredTextBoxExtender>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <label class="etiqueta10">Primer Nombre:</label></td>
                <td align="left">
                    <asp:TextBox ID="txtPrimerNombre" runat="server" onkeyup="this.value=this.value.toUpperCase()" Width="200px" MaxLength="30" onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                    <cc1:FilteredTextBoxExtender ID="txtPrimerNombre_FilteredTextBoxExtender"
                        runat="server" FilterType="Custom, LowercaseLetters, UppercaseLetters"
                        TargetControlID="txtPrimerNombre" ValidChars="'áéíóúÁÉÍÓÚñÑ">
                    </cc1:FilteredTextBoxExtender>
                </td>
                <td align="right">
                    <label class="etiqueta10">Segundo Nombre:</label></td>
                <td align="left">
                    <asp:TextBox ID="txtSegundoNombre" runat="server" onkeyup="this.value=this.value.toUpperCase()" Width="200px" MaxLength="30" onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                    <cc1:FilteredTextBoxExtender ID="txtSegundoNombre_FilteredTextBoxExtender"
                        runat="server" FilterType="Custom, LowercaseLetters, UppercaseLetters"
                        TargetControlID="txtSegundoNombre" ValidChars="'áéíóúÁÉÍÓÚñÑ ">
                    </cc1:FilteredTextBoxExtender>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:CheckBox ID="chkbPorDocumento" runat="server" Checked="false" OnCheckedChanged="chkbPorDocumento_CheckedChanged" AutoPostBack="true" Text="Número Documento:" CssClass="etiqueta10" onKeyPress="return disableEnterKey(event)" />
                </td>
                <td align="left">
                    <asp:TextBox ID="txtNumeroDocumento" runat="server" Width="200px" MaxLength="20" onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                    <cc1:FilteredTextBoxExtender ID="txtNumeroDocumento_FilteredTextBoxExtender"
                        runat="server" FilterType="Numbers"
                        TargetControlID="txtNumeroDocumento" ValidChars="">
                    </cc1:FilteredTextBoxExtender>
                </td>
                <td align="right">
                    <label class="etiqueta10">Fecha Nacimiento:</label></td>
                <td align="left" class="auto-style5">
                    <asp:TextBox ID="txtFechaNacimiento" runat="server" MaxLength="10" onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                    <cc1:CalendarExtender ID="CalendarExtender1" CssClass="cal_Theme1" runat="server" TargetControlID="txtFechaNacimiento" PopupButtonID="ImageButton1" OnClientShown="ChangeCalendarView" Format="dd/MM/yyyy"  OnClientShowing="setDate" BehaviorID="myDate"  />
                    <asp:ImageButton runat="Server" ID="ImageButton1" ImageUrl="~/Imagenes/16calendario.png" AlternateText="Click here to display calendar" />
                    <cc1:MaskedEditExtender ID="txtFechaNacimiento_MaskedEditExtender" runat="server" TargetControlID="txtFechaNacimiento" Mask="99/99/9999" MaskType="Date" InputDirection="LeftToRight"
                        AutoComplete="true" UserDateFormat="DayMonthYear" CultureName="es-MX" ClearTextOnInvalid="true" ClearMaskOnLostFocus="false">
                    </cc1:MaskedEditExtender>
                </td>
            </tr>
            <tr>
                <td colspan="4">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="4" align="center">
                    <asp:Button runat="server" ID="imgbtnBuscar" OnClick="imgbtnBuscar_Click" OnClientClick="efecto('cargando')" Text="Buscar" Width="200px" CssClass="boton150" />&nbsp;
                    <asp:Button runat="server" ID="imgbtnBorrar" OnClick="imgbtnBorrar_Click" Text="Limpiar" Width="200px" CssClass="boton150" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <center>
        <div id="cargando" style="display: none;">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/ajax_loader_blue_32.GIF" />
        </div>
    </center>
    <asp:Panel ID="pnlRegistrosCabecera" runat="server">
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
                            <asp:BoundField DataField="fechaafiliacion" HeaderText="Fecha Afiliación" DataFormatString="{0:d}" ItemStyle-HorizontalAlign="Center" />
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

</asp:Content>

