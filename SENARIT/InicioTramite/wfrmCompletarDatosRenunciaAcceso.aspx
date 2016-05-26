<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmCompletarDatosRenunciaAcceso.aspx.cs" Inherits="Administracion_CompletarDatosRenunciaAcceso" StylesheetTheme="Modal" %>

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
                    <asp:HiddenField runat="server" ID="hddIdMatricula" />
                </td>
            </tr>
        </table>
    </div>

    <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0">

        <cc1:TabPanel ID="TabRenuncia" runat="server" HeaderText="Requisitos">
            <ContentTemplate>
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
                            <td align="right">&nbsp;</td>
                            <td align="left">&nbsp;</td>
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
                            <td align="right">&nbsp;</td>
                            <td align="left">&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="Panel1" runat="server" CssClass="panelceleste">
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
                                <asp:Label runat="server" ID="Label7" CssClass="etiqueta10">Requisitos por Sector:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:CheckBoxList runat="server" ID="rdbtDocs2" onKeyPress="return disableEnterKey(event)" Font-Size="Small"></asp:CheckBoxList>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:Button ID="btnSiguiente" runat="server" Text="Siguiente" OnClick="btnSiguiente_Click" Style="height: 26px" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </ContentTemplate>
        </cc1:TabPanel>
        <cc1:TabPanel ID="TabDocReq" runat="server" Visible="false">
            <ContentTemplate>
                <asp:Panel ID="Panel2" runat="server" CssClass="panelceleste">
                    <table align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td align="right" width="20%">
                                <label style="color: red">*</label>
                                <asp:Label runat="server" ID="Label1" CssClass="etiqueta10">Causa:</asp:Label>
                            </td>
                            <td align="left" width="70%">
                                <asp:RadioButtonList runat="server" ID="rdbtCausa" onKeyPress="return disableEnterKey(event)" Font-Size="Small" OnSelectedIndexChanged="rdbtCausa_SelectedIndexChanged" AutoPostBack="true" CausesValidation="false"></asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right">
                                <label style="color: red">*</label>
                                <asp:Label runat="server" ID="Label2" CssClass="etiqueta10">Requisitos por Modalidad:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:CheckBoxList runat="server" ID="rdbtDocs3" onKeyPress="return disableEnterKey(event)" Font-Size="Small"></asp:CheckBoxList>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:Button ID="btnSiguienteCausa" runat="server" Text="Siguiente" OnClick="btnSiguienteCausa_Click" Style="height: 26px" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </ContentTemplate>
        </cc1:TabPanel>
    </cc1:TabContainer>

    <table width="100%" border="0" cellpadding="false" cellspacing="false">
        <tr>
            <td colspan="4" align="right">
                <asp:Label ID="lblConfirmacion" runat="server" CssClass="text_obs"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Button ID="btnRenunciaInicial" runat="server" Text="Guardar" OnClick="btnRenunciaInicial_Click" OnClientClick="efecto('cargando2')" Style="height: 26px" Visible="false" />
                <asp:Button ID="btnReporteRenuncia" runat="server" Text="Reporte Form-03 AD" OnClick="btnReporteRenuncia_Click" OnClientClick="aspnetForm.target ='_blank';" Visible="false" />
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

