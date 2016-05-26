<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmHistorialEjecucion.aspx.cs" Inherits="WorkFlow_wfrmHistorialEjecucion" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style5 {
            height: 23px;
        }

        .auto-style6 {
            width: 15%;
            height: 23px;
        }
        .auto-style7 {
            width: 8%;
        }
        .auto-style9 {
            width: 283px;
        }
        .auto-style10 {
            height: 23px;
            width: 283px;
        }
        .auto-style11 {
            width: 8%;
            height: 23px;
        }
        .auto-style12 {
            width: 435px;
        }
        .auto-style13 {
            height: 23px;
            width: 418px;
        }
        .auto-style14 {
            height: 23px;
            width: 435px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%;" class="panelceleste">
        <tr>
            <td align="center">
                <asp:ImageButton ID="imgAux" runat="server" ImageUrl="~/Imagenes/16w.png" />
                <asp:Label ID="lblTituloAUX" runat="server"
                    Text="HISTORIAL DE EJECUCION DE ACTIVIDADES" CssClass="etiqueta20"></asp:Label>
                <asp:Label ID="lblCodigo" runat="server" Font-Size="Small" Text="1"
                    Visible="False"></asp:Label>
        
            </td>
        </tr>
        <%-- ///////////////// PANEL DE DESPLIEGE DE DATOS DE TRAMITE///////////////// --%>
        <tr>
            <td>
                <asp:Panel ID="PanelDatos" runat="server" CssClass="panelceleste" BorderStyle="Solid" BorderWidth="3">
                    <table width="100%">
                        <tr>
                            <td style="width: 15%; text-align: right">
                                <asp:Label ID="lblNroTramite" CssClass="etiqueta10" runat="server" Text="N° de Tramite"></asp:Label>
                            </td>
                            <td style="text-align: left" class="auto-style9">
                                <asp:Label ID="txtNroTramite" runat="server" BackColor="#99CCFF" Width="134px"></asp:Label>
                            </td>
                            <td style="text-align: right" class="auto-style7">
                                <asp:Label ID="lbltipoTramite" CssClass="etiqueta10" runat="server" Text="Tipo de Tramite"></asp:Label>
                            </td>
                            <td style="text-align: left" class="auto-style12">
                                <asp:Label ID="txtTipoTramite" runat="server" BackColor="#99CCFF" Width="134px"></asp:Label>
                            </td>
                            <td style="width: 15%; text-align: right" colspan="2">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="text-align: right" class="auto-style5">
                                <asp:Label ID="lblBeneficiario" CssClass="etiqueta10" runat="server" Text="Nombre Beneficiario" />
                            </td>
                            <td style="text-align: left" class="auto-style10">
                                <asp:Label ID="txtBeneficiario" runat="server" BackColor="#99CCFF" Width="264px"></asp:Label>
                            </td>
                            <td style="text-align: right" class="auto-style11">
                                <asp:Label ID="lblCI" CssClass="etiqueta10" runat="server" Text="CI"></asp:Label>
                            </td>
                            <td style="text-align: left" class="auto-style14">
                                <asp:Label ID="txtCI" runat="server" BackColor="#99CCFF" Width="134px"></asp:Label>
                            </td>
                            <td style="text-align: right" class="auto-style6">
                                <asp:ImageButton ID="imgVolver" runat="server"  ImageUrl="~/Imagenes/32Volver.png" ToolTip="Volver a la Página anterior" OnClick="btnVolver_Click" /> 
                                <asp:Label ID="lblTVolver" CssClass="etiqueta8Blue" runat="server" Text="Volver" /> 
                            </td>
                            <td style="text-align: left" class="auto-style5">
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right" class="auto-style5">
                                <asp:Label ID="lblGrupoBeneficio" CssClass="etiqueta10" runat="server" Text="Grupo Beneficio" />
                            </td>
                            <td style="text-align: left" class="auto-style10">
                                <asp:Label ID="txtGrupoBeneficio" runat="server" BackColor="#99CCFF" Width="264px"></asp:Label>
                            </td>
                            <td style="text-align: right" class="auto-style11">
                                
                            </td>
                            <td style="text-align: left" class="auto-style14">
                                
                            </td>
                            <td style="text-align: right" class="auto-style6">
                            </td>
                            <td style="text-align: right" class="auto-style5">
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right" class="auto-style5">
                                <asp:Label ID="lblFlujo" CssClass="etiqueta10" runat="server" Text="Flujo"></asp:Label>
                            </td>
                            <td style="text-align: left" class="auto-style5" colspan="5">
                                <asp:Label ID="txtFlujo" runat="server" BackColor="#99CCFF" Height="25px" Width="625px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right" class="auto-style5">
                                <asp:Label ID="lblActividad" CssClass="etiqueta10" runat="server" Text="Actividad" />
                            </td>
                            <td style="text-align: left" class="auto-style5" colspan="5">
                                <asp:Label ID="txtActividad" runat="server" BackColor="#99CCFF" Height="25px" Width="625px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right" class="auto-style5">
                                <asp:Label ID="lblComentarios" CssClass="etiqueta10" runat="server" Text="Comentarios" />
                            </td>
                            <td style="text-align: left" class="auto-style5" colspan="5">
                                <asp:Label ID="txtComentarios" runat="server" BackColor="#99CCFF" Height="24px" Width="623px"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlGrilla" runat="server" HorizontalAlign="Center" Width="100%"
                    CssClass="panelceleste">
                    <table style="width: 100%;">
                        <tr>
                           <td colspan="2" class="panelceleste">                           
                                 <asp:GridView ID="gvHistorialEjecucion" runat="server"
                                    AutoGenerateColumns="False"
                                    HorizontalAlign="Center"
                                    SkinID="GridView"
                                    Width="100%" DataKeyNames="IdInstancia,Secuencia" >
                                    <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                                    <Columns>      
                                        <asp:TemplateField HeaderText="Instancia">
                                            <ItemTemplate>
                                                <asp:Label ID="lblIdInstancia" runat="server" Text='<%# Bind("IdInstancia") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Secuencia">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSecuencia" runat="server" Text='<%# Bind("Secuencia") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="IdTipoTramite" HeaderText="IdTipoTramite" />
                                        <asp:BoundField DataField="IdGrupoBeneficio" HeaderText="IdGrupoBeneficio" />
                                        <asp:BoundField DataField="NombreBeneficiario" HeaderText="NombreBeneficiario" />
                                        <asp:BoundField DataField="IdTramite" HeaderText="Nro. Tramite" />
                                        <asp:BoundField DataField="IdFlujo" HeaderText="IdFlujo" Visible="false" />
                                        <asp:BoundField DataField="DescFlujo" HeaderText="DescFlujo" />
                                        <asp:BoundField DataField="IdNodo" HeaderText="IdNodo" Visible="false" />
                                        <asp:BoundField DataField="Descripcion" HeaderText="Actividad" />
                                        <asp:BoundField DataField="Contador" HeaderText="Contador" Visible="false" />
                                        <asp:BoundField DataField="FechaHRInicio" HeaderText="FechaHRInicio" />
                                        <asp:BoundField DataField="FechaHRFin" HeaderText="FechaHRFin" Visible="false" />                                        
                                        <asp:BoundField DataField="Comentarios" HeaderText="Comentarios" />
                                    </Columns>
                                <EmptyDataTemplate>
                                    <div align="center" class="CajaDialogoAdvertencia">
                                    <br/><img src="../Imagenes/warning.gif" 
                                            alt="No existen Tramites por Asignar para el usuario en curso." />
                                    <br/>Bandeja de Tramites vacia o No existen Tramites que cumplan el criterio de busqueda.
                                    <br/><br/>
                                    </div>
                                </EmptyDataTemplate>
                                </asp:GridView>
                           </td>
                        </tr>
                     </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>

