<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmCompletarDatosReporte.aspx.cs" Inherits="InicioTramite_CompletarDatosReporte" StylesheetTheme="Modal" %>

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

    <asp:Panel ID="PanelPrerenuncia" runat="server" CssClass="panelceleste">
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
                    <asp:Label ID="Label1" runat="server" CssClass="etiqueta10">Tipo Reporte:</asp:Label>
                </td>
                <td align="left">
                    <asp:DropDownList runat="server" ID="ddlTipoReporte" Width="150px" onKeyPress="return disableEnterKey(event)" OnSelectedIndexChanged="ddlTipoReporte_SelectedIndexChanged" CausesValidation="false" AutoPostBack="true"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <label style="color: red">*</label>
                    <label class="etiqueta10">Observaciones:</label></td>
                <td colspan="5">
                    <asp:TextBox ID="txtDescripcion" runat="server" Height="150px" TextMode="MultiLine" Width="600px" MaxLength="200" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
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
                <td colspan="4" align="right">
                    <asp:Label ID="lblConfirmacion" runat="server" CssClass="text_obs"></asp:Label>
                    <asp:HiddenField runat="server" ID="hddIdTramiteManual" />
                </td>
            </tr>
            <tr>
                <td align="center" colspan="6">
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" OnClientClick="efecto('cargando2')" Style="height: 26px" />
                    <asp:Button ID="btnReporte" runat="server" Text="Reporte" OnClick="btnReporte_Click" Visible="false" />
                    <asp:Button ID="imgVolver" runat="server" Text="Cancelar" CssClass="buttonsNegative" Visible="true" OnClick="btnVolver_Click" CausesValidation="false" />
                </td>
            </tr>
        </table>
        <center>
            <div id="cargando2" style="display: none;">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/ajax_loader_blue_32.GIF" />
            </div>
        </center>
    </asp:Panel>

</asp:Content>

