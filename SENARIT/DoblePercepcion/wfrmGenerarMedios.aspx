<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmGenerarMedios.aspx.cs" Inherits="DoblePercepcion_wfrmGenerarMedios" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style5 {
            width: 564px;
        }
        .auto-style6 {
            width: 112px;
        }
        .auto-style7 {
            width: 133px;
        }
        .auto-style8 {
            width: 77px;
        }
        .auto-style9 {
            width: 63px;
        }
        .auto-style10 {
            width: 128px;
        }
        .auto-style11 {
            width: 25px;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
                                                        <!--DESDE AQUI SE PUDE PERSONALIZAR-->

    <div style="border:solid;border-color:black;" aligin ="center"> 
                          
                            <table class="auto-style5">
                                <tr>
                                    <td colspan="6">
                                         <asp:Label ID="lblTituloAUX" runat="server"
                                         Text="Generar Medios" CssClass="etiqueta20" Font-Size="16pt"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style6">
                                        Tipo Medio:
                                    </td>
                                    <td colspan="5">

                                         <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                 <asp:DropDownList ID="ddlTipoReporte" runat="server" OnSelectedIndexChanged="ddlTipoReporte_SelectedIndexChanged" AutoPostBack="true" ></asp:DropDownList>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:PostBackTrigger ControlID="ddlTipoReporte"  />
                                            </Triggers>
                                       </asp:UpdatePanel>

                                    </td>
                                </tr>
                                 <tr>
                                     <td class="auto-style6">
                                        LISTA DE AFP'S
                                    </td>
                                    <td class="auto-style7">
                                        <asp:CheckBoxList ID="cblAFP" runat="server" Visible="true"></asp:CheckBoxList>
                                    </td>
                                      <td class="auto-style6">
                                        <asp:Label ID="lblSuspension" runat="server"
                                         Text="TIPO DE REHABILITACION" Visible="true"></asp:Label>
                                    </td>
                                    <td class="auto-style7" colspan="2">
                                        <asp:CheckBoxList ID="cblTipoSuspension" runat="server" Visible="true"></asp:CheckBoxList>
                                    </td>
                                </tr>
                                <tr>
                                   <td class="auto-style6">Fecha Inicio:</td>
                                 <td class="auto-style7">
                                  <asp:TextBox ID="txtFechaInicio" runat="server" MaxLength="10"></asp:TextBox>
                                  <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtFechaInicio" ID="RegularExpressionValidator9" ValidationExpression = "^\d{2,4}\-\d{1,2}\-\d{1,2}$" runat="server" ErrorMessage="Formato de Fecha Incorrecta"></asp:RegularExpressionValidator>
                                  <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" 
							         runat="server" FilterType="Custom, Numbers"
							          TargetControlID="txtFechaInicio" ValidChars="-">
					                </cc1:FilteredTextBoxExtender>  
                                 
                                 </td>
                                  <td class="auto-style8">
                                    <asp:Image ID="imgCalendarioInicio" runat="server" Height="25px" ImageUrl="~/Imagenes/32calendario.png" Width="25px" ImageAlign="Top" Style="cursor:pointer"/>
                                    <cc1:CalendarExtender ID="CalendarExtender8" runat="server" Enabled="True" TargetControlID="txtFechaInicio" PopupButtonID="imgCalendarioInicio"
													    Format="yyyy-MM-dd" CssClass="cal_Theme1"></cc1:CalendarExtender> 
                                  </td>
                                     <td class="auto-style9">
                                      Fecha Fin:
                                      </td>
                                    <td class="auto-style10">
                                      <asp:TextBox ID="txtFechaFin" runat="server"></asp:TextBox>
                                   <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtFechaFin" ID="RegularExpressionValidator1" ValidationExpression = "^\d{2,4}\-\d{1,2}\-\d{1,2}$" runat="server" ErrorMessage="Formato de Fecha Incorrecta"></asp:RegularExpressionValidator>
                                  <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" 
							         runat="server" FilterType="Custom, Numbers"
							          TargetControlID="txtFechaFin" ValidChars="-">
					                </cc1:FilteredTextBoxExtender>  
                                 
                                      </td>
                                      <td class="auto-style11">
                                        <asp:Image ID="imgCalendarioFin" runat="server" Height="25px" ImageUrl="~/Imagenes/32calendario.png" Width="25px" ImageAlign="Top" Style="cursor:pointer"/>
                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" TargetControlID="txtFechaFin" PopupButtonID="imgCalendarioFin"
													    Format="yyyy-MM-dd" CssClass="cal_Theme1"></cc1:CalendarExtender> 

                                      </td>
                                </tr>
                                <tr>
                                    <td class="auto-style6">
                                        CRC
                                    </td>
                                    <td colspan ="3">
                                        <asp:Label ID="lblCRC" runat="server" Text=""></asp:Label>
                                    </td>
                                  </tr>

                            <tr>
            
                                <td class="auto-style7">
                                    <asp:Button ID="btnGenerarReporte" runat="server" Text="Generar  Medio" OnClick="btnGenerarReporte_Click" />
                                </td>
                                 <td class="auto-style8">
                                    <asp:Button ID="btnCancelar" runat="server" Text="Limpiar" OnClick="btnCancelar_Click" />
                                </td>

                            </tr>
                                <tr>
                                      <td class="auto-style6" colspan="2">
                                      <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                      <ContentTemplate>
                                      <asp:LinkButton ID="lblDescarga" runat="server" OnClick="lblDescarga_Click" Visible="false">Descarga como archivo .txt</asp:LinkButton>
                                      </ContentTemplate>
                                      <Triggers>
                                      <asp:PostBackTrigger ControlID="lblDescarga" />
                                      </Triggers>
                                      </asp:UpdatePanel>
                                </td>
                                    <td colspan="3">
                                       <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                      <ContentTemplate>
                                      <asp:LinkButton ID="lblDescargaCRC" runat="server" OnClick="lblDescargaCRC_Click" Visible="false">Descarga CRC como archivo .txt</asp:LinkButton>
                                      </ContentTemplate>
                                      <Triggers>
                                      <asp:PostBackTrigger ControlID="lblDescargaCRC" />
                                      </Triggers>
                                      </asp:UpdatePanel>
                                    </td>
                                </tr>                                

                            </table>
    
                       </div>


            
                                            <!--HASTA AQUI -->
</asp:Content>

