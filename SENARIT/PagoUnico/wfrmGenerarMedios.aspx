<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmGenerarMedios.aspx.cs" Inherits="PagoUnico_wfrmGenerarMedios" StylesheetTheme="Modal" %>
<%@ MasterType VirtualPath="~/MasterPage.master"%>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="pnlGral">
        <asp:Panel ID="pnlDatos" runat="server" CssClass="pnlBody">
            <table style="width: 100%;">
                <tr>
                    <td align="right" style="width: 110px">
                        &nbsp;</td>
                    <td align="center" colspan="11">
                        <asp:ImageButton ID="imgAux" runat="server" ImageUrl="~/Imagenes/16w.png" />
                        <asp:Label ID="lblTituloAUX" runat="server" CssClass="texto12" Text="Generar Medios"></asp:Label>
                    </td>
                    <td align="left" style="width: 110px">                        
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="right" style="width: 110px">&nbsp;</td>
                    <td align="right">&nbsp;</td>
                    <td align="left" colspan="3">&nbsp;</td>
                    <td align="right">&nbsp;</td>
                    <td align="left">&nbsp;</td>
                    <td align="right">&nbsp;</td>
                    <td align="left" colspan="2">&nbsp;</td>
                    <td align="left">&nbsp;</td>
                    <td align="left">&nbsp;</td>
                    <td align="left" style="width: 110px">&nbsp;</td>
                </tr>
                <tr>
                    <td align="right" style="width: 110px">&nbsp;</td>
                    <td align="right">
                        <asp:Label ID="Label1" runat="server" Text="Medio a generar:"></asp:Label>
                    </td>
                    <td align="left" colspan="3">
                        <asp:DropDownList ID="ddlTipoMedio" runat="server" CssClass="box" Width="110px">
                            <asp:ListItem>Seleccione valor ...</asp:ListItem>
                            <asp:ListItem>C31</asp:ListItem>
                            <asp:ListItem>pgb</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvTipoDato" runat="server" ControlToValidate="ddlTipoMedio" ErrorMessage="*" InitialValue="Seleccione valor ..."></asp:RequiredFieldValidator>
                    </td>
                    <td align="right">
                        <asp:Label ID="Label3" runat="server" Text="Año Proceso:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtAnioProc" runat="server" Width="90px"></asp:TextBox>
                        <cc1:NumericUpDownExtender ID="txtAnioProc_NumericUpDownExtender" runat="server" Maximum="2030" Minimum="1996" TargetControlID="txtAnioProc" Width="90">
                        </cc1:NumericUpDownExtender>
                        <cc1:FilteredTextBoxExtender ID="txtAnioProc_FilteredTextBoxExtender" runat="server" FilterType="Numbers" TargetControlID="txtAnioProc">
                        </cc1:FilteredTextBoxExtender>
                        <asp:RequiredFieldValidator ID="rfvtxtAnioProc" runat="server" ControlToValidate="txtAnioProc" ErrorMessage="*" InitialValue="1995"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="ravAnioProc" runat="server" ControlToValidate="txtAnioProc" ErrorMessage="Fuera de rango" MaximumValue="2030" MinimumValue="1996" Type="Integer"></asp:RangeValidator>
                    </td>
                    <td align="right">
                        <asp:Label ID="Label2" runat="server" Text="Mes Proceso:"></asp:Label>
                    </td>
                    <td align="left" colspan="2">
                        <asp:DropDownList ID="ddlMesProc" runat="server" CssClass="box">
                            <asp:ListItem Value="Seleccione valor ...">Seleccione valor ...</asp:ListItem>
                            <asp:ListItem Value="1">Enero</asp:ListItem>
                            <asp:ListItem Value="2">Febrero</asp:ListItem>
                            <asp:ListItem Value="3">Marzo</asp:ListItem>
                            <asp:ListItem Value="4">Abril</asp:ListItem>
                            <asp:ListItem Value="5">Mayo</asp:ListItem>
                            <asp:ListItem Value="6">Junio</asp:ListItem>
                            <asp:ListItem Value="7">Julio</asp:ListItem>
                            <asp:ListItem Value="8">Agosto</asp:ListItem>
                            <asp:ListItem Value="9">Septiembre</asp:ListItem>
                            <asp:ListItem Value="10">Octubre</asp:ListItem>
                            <asp:ListItem Value="11">Noviembre</asp:ListItem>
                            <asp:ListItem Value="12">Diciembre</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvDdlMesProc" runat="server" ControlToValidate="ddlMesProc" ErrorMessage="*" InitialValue="Seleccione valor ..."></asp:RequiredFieldValidator>
                    </td>
                    <td align="left">
                        <asp:Label ID="Label4" runat="server" Text="Nº C31:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtC31" runat="server" CssClass="box" Enabled="False" MaxLength="10"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="txtC31_FilteredTextBoxExtender" runat="server" FilterType="Numbers" TargetControlID="txtC31">
                        </cc1:FilteredTextBoxExtender>
                    </td>
                    <td align="left" style="width: 110px"></td>
                </tr>
                <tr>
                    <td align="right" style="width: 110px">&nbsp;</td>
                    <td align="right">&nbsp;</td>
                    <td align="left" colspan="3">&nbsp;</td>
                    <td align="right"">&nbsp;</td>
                    <td align="left">&nbsp;</td>
                    <td align="right">&nbsp;</td>
                    <td align="left" colspan="2">&nbsp;</td>
                    <td align="left">&nbsp;</td>
                    <td align="left">&nbsp;</td>
                    <td align="left" style="width: 110px">&nbsp;</td>
                </tr>
                <tr>
                    <td align="right" style="width: 110px">&nbsp;</td>
                    <td align="right" colspan="2">
                        &nbsp;</td>
                    <td align="right">&nbsp;</td>
                    <td align="right">
                        &nbsp;</td>
                    <td align="right"">
                        <asp:ImageButton ID="ibtnLimpiar" runat="server" AlternateText="Limpiar campos" CausesValidation="False" ImageUrl="~/Imagenes/plomoLimpiar.png" OnClick="ibtnLimpiar_Click" />
                    </td>
                    <td align="left">
                        
                    <td align="right">
                        
                        <asp:ImageButton ID="ibtnGenerarMedio" runat="server" AlternateText="Generar Medio" ImageUrl="~/Imagenes/plomoRegistrar.png" OnClick="ibtnGenerarMedio_Click" />
                        </td>
                    <td align="right">
                        <asp:UpdatePanel ID="upnlDescargarMedio" runat="server">
                            <ContentTemplate>
                                <asp:ImageButton ID="ibtnDescargarMedio" runat="server" AlternateText="Descargar medio" ImageUrl="~/Imagenes/plomoDescargarMedio.png" OnClick="ibtnDescargarMedio_Click" />
                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="ibtnDescargarMedio" />
                            </Triggers>
                        </asp:UpdatePanel>                         
                    </td>
                    </td>
                    <td align="right">
                        <asp:UpdatePanel ID="upnlDescargarCRC" runat="server">
                            <ContentTemplate>
                                <asp:ImageButton ID="ibtnDescargarCRC" runat="server" AlternateText="Descargar medio" ImageUrl="~/Imagenes/plomoDescargarCRC.png" OnClick="ibtnDescargarCRC_Click" />
                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="ibtnDescargarCRC" />
                            </Triggers>
                        </asp:UpdatePanel>  
                    </td>
                    <td align="right">&nbsp;</td>
                    <td align="right">&nbsp;</td>
                    <td align="left" style="width: 110px">&nbsp;</td>
                </tr>
                <tr>
                    <td align="right" style="width: 110px">&nbsp;</td>
                    <td align="center" colspan="9">
                    </td>
                    <td align="center">&nbsp;</td>
                    <td align="center">&nbsp;</td>
                    <td style="width: 110px">&nbsp;</td>
                </tr>
                <tr>
                    <td align="right" style="width: 110px">&nbsp;</td>
                    <td align="right">&nbsp;</td>
                    <td align="left" colspan="3">&nbsp;</td>
                    <td align="left"">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td colspan="2">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td style="width: 110px">&nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
    </div>

</asp:Content>

