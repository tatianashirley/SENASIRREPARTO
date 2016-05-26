<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmEmisionCertificado.aspx.cs" 
    Inherits="EmisionCertificadoCC_wfrmEmisionCertificado" StylesheetTheme="Modal" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .cssHeaderImg {
            background-image: url(../Imagenes/Menu5.png);
        }
        .auto-style5 {
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%;" class="panelceleste">
        <tr>
            <td align="center">
                <asp:ImageButton ID="imgAux" runat="server" ImageUrl="~/Imagenes/16w.png" />
                <asp:Label ID="lblTituloAUX" runat="server"
                    Text="Emision de Certificados CC"
                    CssClass="etiqueta20"></asp:Label>
                <asp:Label ID="lblCodigo" runat="server" Font-Size="Small" Text="1"
                    Visible="False"></asp:Label>
                <asp:Label ID="lblCodUsuario" runat="server" Font-Size="Small" Text="1"
                    Visible="False"></asp:Label>
                <asp:Label ID="lblRol" runat="server" Font-Size="Small"
                    Style="text-align: left" Text="0" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                 <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Center" Width="100%"
                    CssClass="panelceleste">
                    <table style="width: 100%;">
                        <tr>
                            <td colspan="2"  align="center" class="auto-style5" >
                                <asp:Panel ID="PanelMensaje" runat="server" Width="70%" CssClass="panelsecundario">
                                    <table style="width: 100%;">
                                        <tr>
                                            <td align="center">
                                                  <asp:Label ID="lblObser" runat="server" CssClass="text_obs"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                              </td>
                        </tr>
                        <tr>
                            <td width="20%" >
                                 <asp:Panel ID="pnlInformacion" runat="server" CssClass="panelceleste"  Width="100%">
                                       <table align="center">
                                           <tr>
                                               <td align="center">
                                                   <asp:Label ID="lblInfor" runat="server" CssClass="etiqueta8Blue" Style="text-align: left" Text="ULTIMO NUM. DE CERTIFICADOS:"></asp:Label>
                                               </td>
                                           </tr>
                                           <tr>
                                               <td align="center">
                                                   <asp:GridView ID="gvUltimo" runat="server"  SkinID="GridView" >
                                                         <Columns>
                                                            <asp:BoundField  DataField="TipoCertificado"  />
                                                             <asp:BoundField  DataField="NumeroInicial"  HeaderText="Num. Inicial"/>
                                                             <asp:BoundField  DataField="NumeroFinal"  HeaderText="Num. Final" />
                                                            <asp:BoundField  DataField="UltimoNumeroAplicado" HeaderText="Sgte. Nro Cert."   />
                                                         </Columns>
                                                    </asp:GridView>
                                                   </td>
                                           </tr>
                                       </table>
                                   </asp:Panel>
                            </td>
                            <td width="80%">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="panelceleste">
                                <asp:GridView ID="gvTipo" runat="server"  AutoGenerateColumns="False" HorizontalAlign="Center" SkinID="GridView"
                                      DataKeyNames="IdTipoFormularioCalculo,DescripcionTipoFormulario,IdTipoCC,IdTipoTramite,FechaNotificacion"
                                      OnRowDataBound="gvTipo_RowDataBound"
                                      OnRowCommand="gvTipo_RowCommand"
                                      Width="100%" EnableModelValidation="True">
                                   <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                                    <Columns>
                                        <asp:BoundField DataField="IdTipoFormularioCalculo" ></asp:BoundField>  <%--    0 --%>
                                        <asp:BoundField DataField="DescripcionTipoFormulario" />  <%--  1--%>
                                        <asp:BoundField DataField="IdTipoCC" >  </asp:BoundField>  <%--  2--%>
                                        <asp:BoundField DataField="IdTipoTramite"  ></asp:BoundField> <%--   3--%>
                                        <asp:BoundField DataField="NumeroTramiteCrenta" HeaderText="CRENTA" ItemStyle-BackColor="Orange"/><%--4--%>
                                        <asp:BoundField DataField="Idtramite" HeaderText="NroTrámite" /><%--5--%>
                                        <asp:BoundField DataField="NoFormularioCalculo" HeaderText="NoFormCalculo" > </asp:BoundField>  <%-- 6--%>
                                        <asp:BoundField DataField="TipoCC" HeaderText="TipoCC" /><%-- 7--%>
                                        <asp:BoundField DataField="MontoCC" HeaderText="Monto CC Form" /><%-- 8--%>
                                        <asp:BoundField DataField="FechaGeneracion" HeaderText="F.Generacion FormCC" /><%-- 9--%>
                                        <asp:BoundField DataField="FechaNotificacion" HeaderText="F.Notificacion" /><%--10--%>
                                        <asp:BoundField DataField="MontoCCAceptado" HeaderText="Monto CC Aceptado" ItemStyle-BackColor="Orange"/><%--11--%>
                                        <asp:BoundField DataField="FechaAceptacion" HeaderText="F.Impresion" /><%--12--%>
                                        <asp:BoundField DataField="NroCertificado" HeaderText="Nro CertCC" ItemStyle-BackColor="Orange" /><%--13--%>
                                        <asp:BoundField DataField="RegistroActivo" HeaderText="RegistroActivo"  Visible="false"/><%--14--%>
                                        <asp:BoundField DataField="IdEstado" HeaderText="IdEstado"  Visible="false"/><%--15--%>
                                        <asp:buttonfield buttontype="Button" commandname="Emitir" ControlStyle-CssClass="etiqueta8Blue" 
                                          text="Emitir" HeaderText="Emitir"  /><%--16--%>
                                       <asp:buttonfield buttontype="Button" commandname="Imprimir" ControlStyle-CssClass="etiqueta8Blue"  
                                          text="Imprimir" HeaderText="Imprimir" /> <%--17--%>
                                       <asp:buttonfield buttontype="Button"  commandname="Ver" ControlStyle-CssClass="etiqueta8Blue"  
                                          text="Ver" HeaderText="Ver" /> <%--18--%>
                                    </Columns>
                                </asp:GridView>
                           </td>
                        </tr>
                     </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:HiddenField ID="iIdTramite" runat="server" />
                <asp:HiddenField ID="iIdGrupoB" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

