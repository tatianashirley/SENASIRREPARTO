<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmReporteTipoObservacion.aspx.cs" Inherits="SeguimientoObservados_wfrmReporteTipoObservacion" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 140px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <table style="width: 100%;" class="panelceleste">
        <tr>
            <td align="center">
                <asp:ImageButton ID="imgAux" runat="server" ImageUrl="~/Imagenes/16w.png" />
                <asp:Label ID="lblTituloAUX" runat="server" Text="LISTADOS POR TIPO OBSERVACION" CssClass="etiqueta20"> </asp:Label>
            </td>
        </tr>
        <tr>
             <td >
                 <div>
                    <table width="100%" class="panelceleste" >
                         <tr>
                            <td style="text-align:left" width="10%">
                                <asp:Label ID="lblTipoDoc" Font-Names="Arial" Font-Size="9pt" Font-Bold="true" runat="server" Text="Tipo Observación: " /> 
                            </td>
                           
                            <td style="text-align:left" width="10%">
                                <asp:Label ID="lblRegional"  CssClass="etiqueta10"  runat="server" Text="Regional:" Font-Names="Arial" Font-Size="9pt" Font-Bold="true" /> 
                            </td>
                            
                            <td style="text-align:left" width="10%">
                                <asp:Label ID="lblFechaDesde"  CssClass="etiqueta10"  runat="server" Text="Fecha Desde:"  Font-Names="Arial" Font-Size="9pt" Font-Bold="true"/> 
                            </td>
                            
                            <td style="text-align:left" width="10%">
                                <asp:Label ID="lblFechaHasta"  CssClass="etiqueta10"  runat="server" Text="Fecha Hasta:"  Font-Names="Arial" Font-Size="9pt" Font-Bold="true"/> 
                            </td>
                            
                            <td style="width:20%; text-align:left" width="10%" rowspan="2">   
                                <asp:ImageButton ID="imgBuscar" runat="server"  ImageUrl="~/Imagenes/32Buscar.png" ToolTip="Buscar" ValidationGroup="valFecha" CausesValidation="true" OnClick="imgBuscar_Click" OnClientClick="aspnetForm.target ='_blank';"/>
                                <asp:Label ID="lblRefres" CssClass="etiqueta8Blue" runat="server" Text="Buscar" /> 
                            </td>
                            <td style="width:20%; text-align:left" rowspan="2">
                                <asp:RadioButtonList runat="server" ID="rbReporte" AutoPostBack="true" OnSelectedIndexChanged="rbReporte_SelectedIndexChanged">
                                    <asp:ListItem Value="1" Text="Listado por Tipo de Observación" Selected="True"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="Listado para envío a Regionales"></asp:ListItem>
                                    <asp:ListItem Value="3" Text="Listado de ingresos al área"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align:left" width="10%"> 
                                <asp:DropDownList  ID="ddlObservacion" runat="server" style="margin-bottom: 0px" Font-Names="Arial" Font-Size="9pt" Height="25px" Width="154px"></asp:DropDownList>
                            </td>



                            <td style="text-align:left" width="10%"> 
                                <asp:DropDownList  ID="ddlRegional" runat="server" style="margin-bottom: 0px;" Height="25px" Width="153px"></asp:DropDownList>
                            </td>

                            <td style="text-align:left" class="auto-style1"> 
                                <asp:TextBox  ID="txtFechaDesde" runat="server" style="margin-bottom: 0px;" Width="110px" MaxLength="10"/>
                                <cc1:CalendarExtender ID="CalendarExtender2" PopupButtonID="txtFechaDesde" runat="server" TargetControlID="txtFechaDesde" Format="dd/MM/yyyy">
                                </cc1:CalendarExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                    ErrorMessage="Ingrese una Fecha" ValidationGroup="valFecha" 
                                    ControlToValidate="txtFechaDesde" Text="*"
                                    Display="Dynamic" SetFocusOnError="true">*
                                </asp:RequiredFieldValidator>
                                    <cc1:FilteredTextBoxExtender ID="txtFecNotificacion_FilteredTextBoxExtender1" 
                                        runat="server" FilterType="Numbers,Custom"
                                        TargetControlID="txtFechaDesde" ValidChars="/">
                                    </cc1:FilteredTextBoxExtender>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationGroup="ValFecha" runat="server" ControlToValidate="txtFechaDesde" Display="Dynamic" ErrorMessage="dd/mm/aaaa" ValidationExpression="^([\d]{2})/([\d]{2})/([\d]{4})$"
                                        Font-Size="9pt" Font-Names="Arial">
                                      </asp:RegularExpressionValidator>
                            </td>

                            <td style="text-align:left" width="10%"> 
                                <asp:TextBox  ID="txtFechaHasta" runat="server" style="margin-bottom: 0px;" Width="110px" MaxLength="10"/>
                                <cc1:CalendarExtender ID="CalendarExtender3" PopupButtonID="txtFechaHasta" runat="server" TargetControlID="txtFechaHasta" Format="dd/MM/yyyy">
                                </cc1:CalendarExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ErrorMessage="" ValidationGroup="valFecha" 
                                    ControlToValidate="txtFechaHasta" Text="*"
                                    Display="Dynamic" SetFocusOnError="true">*
                                </asp:RequiredFieldValidator>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" 
                                        runat="server" FilterType="Numbers,Custom"
                                        TargetControlID="txtFechaHasta" ValidChars="/">
                                    </cc1:FilteredTextBoxExtender>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ValidationGroup="ValFecha" runat="server" ControlToValidate="txtFechaHasta" Display="Dynamic" ErrorMessage="dd/mm/aaaa" ValidationExpression="^([\d]{2})/([\d]{2})/([\d]{4})$"
                                        Font-Size="9pt" Font-Names="Arial">
                                      </asp:RegularExpressionValidator>
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

