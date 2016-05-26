<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmReportePlanPagos.aspx.cs" Inherits="Convenios_wfrmReportePlanPagos" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register assembly="System.Web, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="System.Web.UI" tagprefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <!--PLANTILLA -->
    <table>
    <tr>
        <td>
             <asp:Panel ID="pnlRegistro" runat="server" Width="100%" HorizontalAlign="Center" Visible="False">
                    Fecha Inicio:
                                
                    <asp:TextBox ID="txtFechaInicio" runat="server" MaxLength ="10"></asp:TextBox>
     
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" 
						runat="server" FilterType="Custom, Numbers"
						TargetControlID="txtFechaInicio" ValidChars="-/">
					</cc1:FilteredTextBoxExtender> 
                                  
                        <asp:Image ID="imgCalendarioInicio" runat="server" Height="25px" ImageUrl="~/Imagenes/32calendario.png" Width="25px" ImageAlign="Top" Style="cursor:pointer"/>
                    <cc1:CalendarExtender ID="ceCalendarioInicio" runat="server" TargetControlID="txtFechaInicio" PopupButtonID="imgCalendarioInicio"
						Format="yyyyMM" Enabled="True" CssClass="cal_Theme1"></cc1:CalendarExtender> 
                                 
                        Fecha Fin:
                                     
                        <asp:TextBox ID="txtFechaFin" runat="server" MaxLength="10"></asp:TextBox>
                                 
                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" 
						runat="server" FilterType="Custom, Numbers"
						TargetControlID="txtFechaFin" ValidChars="-/">
					</cc1:FilteredTextBoxExtender> 
                                      
                        <asp:Image ID="imgCalendarioFin" runat="server" Height="25px" ImageUrl="~/Imagenes/32calendario.png" Width="25px" ImageAlign="Top" Style="cursor:pointer"/>
                        <cc1:CalendarExtender ID="ceCalendarioFin" runat="server" TargetControlID="txtFechaFin" PopupButtonID="imgCalendarioFin"
						Format="yyyyMM" Enabled="True" CssClass="cal_Theme1"></cc1:CalendarExtender> 
                <asp:Button ID="btnGenerarReporte" runat="server" Text="Generar Reporte" OnClick="btnGenerarReporte_Click" />
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" /> 
                </asp:Panel>
            </td><td>
                <asp:Panel ID="pnlTipoReporte" runat="server" Width="100%" HorizontalAlign="Center" Visible="False"> 
                <asp:RadioButtonList ID="rbReporte" runat="server">
                <asp:ListItem Text="FechaDeposito" Value="1" Selected="True" />
                <asp:ListItem Text="FechaRegistro" Value="2"/>
                </asp:RadioButtonList>
                </asp:Panel>
        </td>
    </tr>
        <tr>
        <td align="center" colspan="2">
            <div aligin="center">
            <asp:Panel ID="panReporte" runat="server" CssClass="panelceleste"  HorizontalAlign="Center" style="overflow-y:scroll;" Height="550px" Width="1190px" Visible="true">
            <rsweb:ReportViewer ID="rtpInforme" runat="server" Height="550px" Width="1190px" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Visible="true">
            </rsweb:ReportViewer>
            </asp:Panel>
            </div>
        </td>
    </tr>
    </table>
     <!------------->
</asp:Content>