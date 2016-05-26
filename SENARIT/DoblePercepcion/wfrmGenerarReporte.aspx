<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmGenerarReporte.aspx.cs" Inherits="DoblePercepcion_wfrmGenerarReporte" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript" language="javascript">
        $(document).ready(function () {
            //alert("Has pulsado el enlace...nAhora serás enviado a DesarrolloWeb.com");
            Funcion1();
        });
        function Funcion1() {
            var Tipo = document.getElementById('<%=ddlTipoReporte.ClientID%>').value;
            //alert(Tipo)
            if (Tipo == '364') {
                //alert('Tipo')
                document.getElementById('<%=lblSuspension.ClientID%>').style.display = 'block';
                document.getElementById('<%=pnlTipoReporte.ClientID%>').style.display = 'block';
                //document.getElementById('<%=lblSuspension.ClientID%>').visible = 'true';
                //document.getElementById('<%=pnlTipoReporte.ClientID%>').visible = 'true';
            }
            else {
               //alert('entro else')
                document.getElementById('<%=lblSuspension.ClientID%>').style.display = 'none';
                document.getElementById('<%=pnlTipoReporte.ClientID%>').style.display = 'none';
                //document.getElementById('<%=lblSuspension.ClientID%>').visible = 'false';
                //document.getElementById('<%=pnlTipoReporte.ClientID%>').visible = 'false';
            }
        }
    </script>
 </asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
                                                        <!--DESDE AQUI SE PUDE PERSONALIZAR-->
                        <div> 
                            <table>
                                <tr>
                                    <td colspan="6">
                                       <asp:Label ID="lblTituloAUX" runat="server"
                                        Text="Generar Reporte" CssClass="etiqueta20" Font-Size="16pt"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Tipo Reporte:
                                    </td>
                                    <td colspan="3">
                                        <asp:DropDownList ID="ddlTipoReporte" runat="server" onchange="Funcion1();"></asp:DropDownList>
                                    </td>
                                    <td class="auto-style6" >
                                        <asp:Label ID="lblSuspension" runat="server"
                                         Text="TIPO DE REHABILITACION" ></asp:Label>
                                    </td>
                                    <td class="auto-style7" colspan="2" align="left" >
                                         <asp:Panel ID="pnlTipoReporte" runat="server" Width="100%" HorizontalAlign="Center" > 
                                        <asp:RadioButtonList ID="rbReporte" runat="server" >
                                        <asp:ListItem Text="Rehabilitacion Doble Percepcion" Value="1" Selected="True" />
                                        <asp:ListItem Text="Rehabilitacion Suspension" Value="2"/>
                                        </asp:RadioButtonList>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                   <td>Fecha Inicio:</td>
                                 <td>
                                  <asp:TextBox ID="txtFechaInicio" runat="server" MaxLength ="10"></asp:TextBox>
                                    <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtFechaInicio" ID="RegularExpressionValidator9" ValidationExpression = "^\d{2,4}\-\d{1,2}\-\d{1,2}$" runat="server" ErrorMessage="Formato de Fecha Incorrecta"></asp:RegularExpressionValidator>
                                  
                                     <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" 
							         runat="server" FilterType="Custom, Numbers"
							          TargetControlID="txtFechaInicio" ValidChars="-/">
					                </cc1:FilteredTextBoxExtender> 
                                  </td>
                                  <td>
                                      <asp:Image ID="imgCalendarioInicio" runat="server" Height="25px" ImageUrl="~/Imagenes/32calendario.png" Width="25px" ImageAlign="Top" Style="cursor:pointer"/>
                                    <cc1:CalendarExtender ID="ceCalendarioInicio" runat="server" TargetControlID="txtFechaInicio" PopupButtonID="imgCalendarioInicio"
						               Format="yyyy-MM-dd" Enabled="True" CssClass="cal_Theme1"></cc1:CalendarExtender> 
                                  </td>
                                     <td>
                                      Fecha Fin:
                                      </td>
                                    <td>
                                      <asp:TextBox ID="txtFechaFin" runat="server" MaxLength="10"></asp:TextBox>
                                      <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtFechaFin" ID="RegularExpressionValidator1" ValidationExpression = "^\d{2,4}\-\d{1,2}\-\d{1,2}$" runat="server" ErrorMessage="Formato de Fecha Incorrecta"></asp:RegularExpressionValidator>
                                      <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" 
							         runat="server" FilterType="Custom, Numbers"
							          TargetControlID="txtFechaFin" ValidChars="-/">
					                </cc1:FilteredTextBoxExtender> 
                                      </td>
                                      <td>
                                       <asp:Image ID="imgCalendarioFin" runat="server" Height="25px" ImageUrl="~/Imagenes/32calendario.png" Width="25px" ImageAlign="Top" Style="cursor:pointer"/>
                                       <cc1:CalendarExtender ID="ceCalendarioFin" runat="server" TargetControlID="txtFechaFin" PopupButtonID="imgCalendarioFin"
						               Format="yyyy-MM-dd" Enabled="True" CssClass="cal_Theme1"></cc1:CalendarExtender> 
                                     </td>
                                </tr>

                            <tr>
                                <td></td><td>
                                    <asp:Button ID="btnGenerarReporte" runat="server" Text="Generar Reporte" OnClick="btnGenerarReporte_Click" />
                                </td>
                                 <td>
                                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
                                </td>

                            </tr>                                
                                <tr>
                                    <td colspan ="7">
                                         <div aligin="center">
                                         <asp:Panel ID="panReporte" runat="server" CssClass="panelceleste"  HorizontalAlign="Center" style="overflow-y:scroll;" Height="550px" Width="1100px" Visible="true">
                                         <rsweb:ReportViewer ID="rtpInforme" runat="server"  Height="550px" Width="1100px" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Visible="true">
                                         </rsweb:ReportViewer>
                                         </asp:Panel>
                                         </div>
                                    </td>

                                </tr>
                            </table>
                <br />


                       </div>
 
                                            <!--HASTA AQUI -->

</asp:Content>

