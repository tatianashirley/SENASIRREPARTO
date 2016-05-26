<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmRenumeracion.aspx.cs" 
    Inherits="EmisionCertificadoCC_wfrmRenumeracion" StylesheetTheme="Modal" %>
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
                    Text="Renumeracion de Certificados"
                    CssClass="etiqueta20"></asp:Label>
                <asp:Label ID="lblCodigo" runat="server" Font-Size="Small" Text="1"
                    Visible="False"></asp:Label>
                <asp:Label ID="lblCodUsuario" runat="server" Font-Size="Small" Text="1"
                    Visible="False"></asp:Label>
                <asp:Label ID="lblRol" runat="server" Font-Size="Small"
                    Style="text-align: left" Text="0" Visible="False"></asp:Label>
            <%--    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </cc1:ToolkitScriptManager>--%>
                <%--<asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True" EnableScriptLocalization="True" />--%>

            </td>
        </tr>
        <tr>
            <td>
                 <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Center" Width="100%"
                    CssClass="panelceleste">
                    <table style="width: 100%;">
<%--                        <tr>
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
                        </tr>--%>
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
                                                            <asp:BoundField  DataField="Detalle"  />
                                                            <asp:BoundField  DataField="UltimoNumeroAplicado" HeaderText="Ultimo N.Certificado"   />
                                                         </Columns>
                                                    </asp:GridView>
                                                   </td>
                                           </tr>
                                       </table>
                                   </asp:Panel>
                            </td>
                            <td width="80%">
                                <asp:Label ID="lblOficina" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="Oficina :"></asp:Label>
                                   <asp:DropDownList ID="ddlOficinacom" runat="server" 
                                       AutoPostBack="True" OnSelectedIndexChanged="ddlOficinacom_SelectedIndexChanged" 
                                       Width="450px">
                                   </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="panelceleste">
                                <asp:GridView ID="gv1" runat="server"  AutoGenerateColumns="False" HorizontalAlign="Center" SkinID="GridView"
                                      DataKeyNames="NroCertificado,IdTipoFormularioCalculo,DescripcionTipoFormulario,IdTipoCC,IdTipoTramite,FechaNotificacion,IdOficinaNotificacion,NoFormularioCalculo,Estado,FlagImprimeCC"
                                      OnRowDataBound="gvTipo_RowDataBound"
                                      OnRowCommand="gvTipo_RowCommand"
                                      Width="100%" EnableModelValidation="True">
                                   <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                                    <Columns>
                                        <asp:BoundField DataField="FlagImprimeCC" Visible="false"></asp:BoundField>  <%--    0 --%>
                                        <asp:BoundField DataField="IdTipoFormularioCalculo" Visible="false"></asp:BoundField>  <%--    1 --%>
                                        <asp:BoundField DataField="DescripcionTipoFormulario" Visible="false" />  <%--  2--%>
                                        <asp:BoundField DataField="IdTipoCC" Visible="false" >  </asp:BoundField>  <%--  3--%>
                                        <asp:BoundField DataField="IdTipoTramite"  Visible="false" ></asp:BoundField> <%--   4--%>
                                        <asp:BoundField DataField="IdOficinaNotificacion"  Visible="false" ></asp:BoundField> <%--  5--%>
                                        <asp:BoundField DataField="NroCertificado" HeaderText="Nro Certificado">  </asp:BoundField>  <%--  6--%>
                                        <asp:BoundField DataField="Estado" HeaderText="Estado Certificado">  </asp:BoundField>  <%--  7--%>
                                        <asp:BoundField DataField="Procedimiento"  HeaderText="Procedimiento"></asp:BoundField> <%--   8--%>
                                        <asp:BoundField DataField="NoFormularioCalculo" HeaderText="NoFormCalculo" > </asp:BoundField>  <%-- 9--%>
                                        <asp:BoundField DataField="TipoCC" HeaderText="TipoCC" /><%-- 10--%>
                                        <asp:BoundField DataField="MontoCC" HeaderText="Monto" /><%-- 11--%>
                                        <asp:BoundField DataField="FechaGeneracion" HeaderText="F.Generacion" /><%-- 12--%>
                                        <asp:BoundField DataField="FechaNotificacion" HeaderText="F.Notificacion" /><%--13--%>
                                        <asp:BoundField DataField="MontoCCAceptado" HeaderText="Monto Aceptado" /><%--14--%>
                                        <asp:BoundField DataField="FechaAceptacion" HeaderText="F.Aceptacion" /><%--15--%>
                                        <asp:BoundField DataField="RegistroActivo" HeaderText="RegistroActivo"  Visible="false"/><%--16--%>
                                        <asp:BoundField DataField="IdEstado" HeaderText="IdEstado"  Visible="false"/><%--17--%>
                                        <asp:BoundField DataField="Idtramite" HeaderText="Trámite" /><%--18--%>
                                        <asp:TemplateField HeaderText ="Renumera/Imprime"><%--19--%>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgReimprimir" runat="server" CausesValidation="true"
                                                    ImageUrl="~/Imagenes/32Imprimir.png" Height="32px" Width="32px"
                                                    CommandName="cmdReimprimir" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ValidationGroup="valGlosa"/>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Renumerar" ><%--20--%>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgRenumerar" runat="server" CausesValidation="true"
                                                    CommandName="cmdEmitir" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" 
                                                    ImageUrl="~/Imagenes/32RenumeraCertificado.gif" Text="" Height="32px" Width="32px" ValidationGroup="valGlosa"/>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Ver" ><%--21--%>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgVer" runat="server" CausesValidation="false" 
                                                    CommandName="cmdVer" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" Height="32px" Width="32px"
                                                    ImageUrl="~/Imagenes/32Busqueda.png" Text="" ValidationGroup="valGlosa"/>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
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
               <asp:Label runat="server" ID="lblObs" Text="Justifique la Baja:"></asp:Label>
            </td>
        </tr>
        <tr>
            <td><asp:TextBox runat="server" ID="txtObs"  TextMode="multiline" Columns="30" Rows="5" AutoPostBack="false"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ErrorMessage="" ValidationGroup="valGlosa" 
                    ControlToValidate="txtObs" Text="* Debe ingresar la Glosa de Baja"
                    Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:HiddenField ID="iIdTramite" runat="server" />
                <asp:HiddenField ID="iIdGrupoB" runat="server" />
                <asp:HiddenField ID="hfCertificadoActual" runat="server" />
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

