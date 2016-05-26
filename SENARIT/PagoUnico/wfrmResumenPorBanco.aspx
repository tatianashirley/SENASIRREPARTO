<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmResumenPorBanco.aspx.cs" Inherits="PagoUnico_Default" StylesheetTheme="Modal" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="pnlGral">
        <asp:Panel ID="pnlDatos" runat="server">
            <table style="width: 100%;">
                <tr align="center">
                    <td colspan="7">
                        <asp:ImageButton ID="imgAux" runat="server" ImageUrl="~/Imagenes/16w.png" />
                        <asp:Label ID="lblTituloAUX" runat="server" CssClass="texto12" Text="Resumen Pago Único por Banco"></asp:Label>
                    </td>
                </tr>   
                <tr align="center">
                    <td colspan="7">&nbsp;</td>
                </tr>
                <tr>
                    <td align="right" style="width: 300px">
                        &nbsp;</td>
                    <td align="right">
                        <asp:Label ID="Label2" runat="server" Text="Año"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtAnio" runat="server"></asp:TextBox>
                        <cc1:NumericUpDownExtender ID="txtAnio_NumericUpDownExtender" runat="server" Maximum="2030" Minimum="1996" TargetControlID="txtAnio" Width="90">
                        </cc1:NumericUpDownExtender>
                        <cc1:FilteredTextBoxExtender ID="txtAnio_FilteredTextBoxExtender" runat="server" FilterType="Numbers" TargetControlID="txtAnio">
                        </cc1:FilteredTextBoxExtender>
                        <asp:RequiredFieldValidator ID="rfvtxtAnio" runat="server" ControlToValidate="txtAnio" ErrorMessage="*" InitialValue="1995" ValidationGroup="imprimir"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="ravAnio" runat="server" ControlToValidate="txtAnio" ErrorMessage="Fuera de rango" MaximumValue="2030" MinimumValue="1996" Type="Integer" ValidationGroup="imprimir"></asp:RangeValidator>
                    </td>
                    <td align="right" rowspan="3">
                        <asp:ImageButton ID="ibtnImprimir" runat="server" ImageUrl="~/Imagenes/plomoImprimir.png" OnClick="ibtnImprimir_Click" AlternateText="Imprimir" ValidationGroup="imprimir" />
                    </td>
                    <td align="left" rowspan="3">
                        <asp:ImageButton ID="ibtnLimpiar" runat="server" ImageUrl="~/Imagenes/plomoLimpiar.png" OnClick="ibtnLimpiar_Click" AlternateText="Limpiar" CausesValidation="False" />
                    </td>
                    <td align="left">
                        &nbsp;</td>
                    <td align="left" style="width: 300px">&nbsp;</td>
                </tr>
                <tr>
                    <td align="right" style="width: 300px">&nbsp;</td>
                    <td align="right">
                        <asp:Label ID="Label1" runat="server" Text="Mes:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlMes" runat="server">
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
                        <asp:RequiredFieldValidator ID="rfvDdlMes" runat="server" ControlToValidate="ddlMes" ErrorMessage="*" InitialValue="Seleccione valor ..." ValidationGroup="imprimir"></asp:RequiredFieldValidator>
                    </td>
                    <td align="left">&nbsp;</td>
                    <td align="left" style="width: 300px">&nbsp;</td>
                </tr>
                <tr>
                    <td align="right" style="width: 300px">&nbsp;</td>
                    <td align="right">
                        <asp:Label ID="Label3" runat="server" Text="Entidad Financiera:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlEntFinan" runat="server" Width="300px">
                            <asp:ListItem Value="0">Seleccione mes ...</asp:ListItem>
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
                        <asp:RequiredFieldValidator ID="rfvTipoDato1" runat="server" ControlToValidate="ddlEntFinan" ErrorMessage="*" InitialValue="Seleccione valor ..." ValidationGroup="imprimir"></asp:RequiredFieldValidator>
                    </td>
                    <td align="left">&nbsp;</td>
                    <td align="left" style="width: 300px">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 300px">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td style="width: 300px">&nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
    </div>
    <div>
        <asp:Panel ID="pnlRpt" runat="server" BackColor="White">
            <table style="width: 100%;">
                <tr>
                    <td align="center">
                        <rsweb:ReportViewer ID="rptViewResumen" runat="server" Width="800px">
                        </rsweb:ReportViewer>
                    </td>
                </tr>
            </table>
            
        </asp:Panel>
    </div>
</asp:Content>

