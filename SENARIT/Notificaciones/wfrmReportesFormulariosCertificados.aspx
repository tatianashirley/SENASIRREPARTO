<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmReportesFormulariosCertificados.aspx.cs" Inherits="Notificaciones_wfrmReportesFormulariosCertificados" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style2 {
            width: 207px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <table style="width: 100%;" class="panelceleste">
        <tr>
            <td align="center">
                <asp:ImageButton ID="imgAux" runat="server" ImageUrl="~/Imagenes/16w.png" />
                <asp:Label ID="lblTituloAUX" runat="server" Text="REPORTES EMISION CC" CssClass="etiqueta20"> </asp:Label>
            </td>
        </tr>
        <tr>
             <td >
                 <div>
                    <table width="100%" class="panelceleste" >
                         <tr>
                            <td style="text-align:left" width="10%">
                                <asp:Label ID="lblTipoDoc" Font-Names="Arial" Font-Size="9pt" Font-Bold="true" runat="server" Text="Tipo Reporte: " /> 
                            </td>
                            
                            <td style="text-align:left" width="10%">
                                <asp:Label ID="lblTipoReporte"  CssClass="etiqueta10" Font-Names="Arial" Font-Size="9pt" Font-Bold="true" runat="server" Text="Procedimiento:" /> 
                            </td>
                           
                            <td style="text-align:left" width="10%">
                                <asp:Label ID="lblRegional"  CssClass="etiqueta10"  runat="server" Text="Regional:" Font-Names="Arial" Font-Size="9pt" Font-Bold="true" /> 
                            </td>
                            
                            <td style="text-align:left" class="auto-style2">
                                <asp:Label ID="lblFechaDesde"  CssClass="etiqueta10"  runat="server" Text="Fecha Desde:"  Font-Names="Arial" Font-Size="9pt" Font-Bold="true"/> 
                            </td>
                            
                            <td style="text-align:left" width="10%">
                                <asp:Label ID="lblFechaHasta"  CssClass="etiqueta10"  runat="server" Text="Fecha Hasta:"  Font-Names="Arial" Font-Size="9pt" Font-Bold="true"/> 
                            </td>
                            
                            <td style="width:15%; text-align:left" width="10%" rowspan="2">   
                                <asp:ImageButton ID="imgBuscar" runat="server"  ImageUrl="~/Imagenes/32Buscar.png" ToolTip="Buscar" ValidationGroup="valFecha" CausesValidation="true" OnClick="imgBuscar_Click" />
                                <asp:Label ID="lblRefres" CssClass="etiqueta8Blue" runat="server" Text="Buscar" /> 
                            </td>
                             <td style="width:20%; text-align:left" width="10%" rowspan="2">  
                                <asp:RadioButtonList ID="rbReporte" runat="server">
                                    <asp:ListItem Text="pdf" Value="1" Selected="True" />
                                    <asp:ListItem Text="excel" Value="2"/>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align:left" width="10%"> 
                                <asp:DropDownList  ID="ddlTipoReporte" runat="server" Font-Names="Arial" Font-Size="9pt" style="margin-bottom: 0px;" Height="16px" Width="139px" >
                                    <asp:ListItem Value="0" Text="SELECIONE..."></asp:ListItem> <%--1--%>
                                    <asp:ListItem Value="1" Text="FORMULARIO CC"></asp:ListItem> <%--2--%>
                                    <asp:ListItem Value="2" Text="CERTIFICADO CC"></asp:ListItem> <%--3--%>
                                </asp:DropDownList> 
                            </td>

                             <td style="text-align:left" width="10%"> 
                                <asp:DropDownList  ID="ddlProcedimientos" runat="server" Font-Names="Arial" Font-Size="9pt" style="margin-bottom: 0px;" Height="16px" Width="139px" >
                                </asp:DropDownList> 
                            </td>

                            <td style="text-align:left" width="10%"> 
                                <asp:DropDownList  ID="ddlRegional" runat="server" style="margin-bottom: 0px;" Height="16px" Width="153px"></asp:DropDownList>
                            </td>

                            <td style="text-align:left" width="10%" > 
                                <asp:TextBox  ID="txtFechaDesde" runat="server" style="margin-bottom: 0px;" Width="95px" Enabled="false" Height="16px"/>
                                <asp:ImageButton ID="imgCalendario1" runat="server" ImageUrl="~/Imagenes/pequeños/Calendar_32x32.png" Height="20px" Width="20px" />
                                <cc1:CalendarExtender ID="CalendarExtender1" PopupButtonID="imgCalendario1" runat="server" TargetControlID="txtFechaDesde" Format="dd/MM/yyyy">
                                </cc1:CalendarExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                    ErrorMessage="Ingrese una Fecha" ValidationGroup="valFecha" 
                                    ControlToValidate="txtFechaDesde" Text="*"
                                    Display="Dynamic" SetFocusOnError="true">*
                                </asp:RequiredFieldValidator>
                            </td>

                            <td style="text-align:left" width="10%"> 
                                <asp:TextBox  ID="txtFechaHasta" runat="server" style="margin-bottom: 0px;" Width="95px" Enabled="false" Height="16px" />
                                <asp:ImageButton ID="imgCalendario2" runat="server" ImageUrl="~/Imagenes/pequeños/Calendar_32x32.png" Height="20px" Width="20px" />
                                <cc1:CalendarExtender ID="CalendarExtender2" PopupButtonID="imgCalendario2" runat="server" TargetControlID="txtFechaHasta" Format="dd/MM/yyyy">
                                </cc1:CalendarExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ErrorMessage="" ValidationGroup="valFecha" 
                                    ControlToValidate="txtFechaHasta" Text="*"
                                    Display="Dynamic" SetFocusOnError="true">*
                                </asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </table>
                </div>
             </td>
        </tr>
<%--        <tr>
            <td><asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="valFecha" /></td>
        </tr>--%>
         <tr>
            <td><asp:Label runat="server" ID="lblTotal" Font-Names="Arial" Font-Size="9pt" Font-Bold="true" Visible="false"/></td>
        </tr>
         <%--Inicio de la Grillas de Consultas--%>
         </table>  
</asp:Content>

