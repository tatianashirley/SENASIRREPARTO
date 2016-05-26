<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmConsultaWF.aspx.cs" Inherits="WorkFlow_wfmConsultaWF" StylesheetTheme="Modal"%>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=1.0.10618.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 268px;
        }
        .auto-style2 {
            width: 108px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="pnlGral">
        <asp:Panel ID="pnlMaestro" runat="server" CssClass="pnlBody">
            <table style="width: 100%;">
                <tr>
                    <td colspan="5" align="center">
                        <asp:ImageButton ID="imgAux" runat="server" ImageUrl="~/Imagenes/16w.png" />
                        <asp:Label ID="lblTituloAUX" runat="server" CssClass="texto12" Text="Consulta WorkFlow "></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td style="width: 165px">&nbsp;</td>
                    <td style="width: 165px">&nbsp;</td>
                    <td style="width: 330px">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label1" runat="server" Text="Número Trámite:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtTramite" runat="server" CssClass="box" Width="150px"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" FilterType="Numbers" TargetControlID="txtTramite"  />
                    </td>
                    <td align="right">
                        <asp:Label ID="Label2" runat="server" Text="Nº Documento Identidad:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtDocIdenti" runat="server" CssClass="box" Width="150px"></asp:TextBox>
                    </td>
                    <td align="left" rowspan="2">
                        <asp:ImageButton ID="ibtnBuscar" runat="server" ImageUrl="~/Imagenes/plomoBuscar.png" OnClick="ibtnBuscar_Click" />
                        <asp:ImageButton ID="ibtnImprimir" runat="server" AlternateText="Imprimir" Enabled="False" ImageUrl="~/Imagenes/plomoImprimir.png" OnClick="ibtnImprimir_Click" />
                        <asp:ImageButton ID="ibtnLimpiar" runat="server" ImageUrl="~/Imagenes/plomoLimpiar.png" OnClick="ibtnLimpiar_Click" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label7" runat="server" Text="Nombre del Titular:"></asp:Label>
                    </td>
                    <td align="left" style="width: 165px">
                        <asp:TextBox ID="txtPaterno" runat="server" CssClass="box" Width="150px" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                    </td>
                    <td align="left" style="width: 165px">
                        <asp:TextBox ID="txtMaterno" runat="server" CssClass="box" Width="150px" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                    </td>
                    <td align="left" style="width: 330px">
                        <asp:TextBox ID="txtNombres" runat="server" CssClass="box" Width="300px" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td align="right">&nbsp;</td>
                    <td align="left" style="width: 165px">
                        <asp:Label ID="Label4" runat="server" Text="Apellido Paterno"></asp:Label>
                    </td>
                    <td align="left" style="width: 165px">
                        <asp:Label ID="Label5" runat="server" Text="Apellido Materno"></asp:Label>
                    </td>
                    <td align="left" style="width: 330px">
                        <asp:Label ID="Label6" runat="server" Text="Nombres"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td align="right">&nbsp;</td>
                    <td align="left" style="width: 165px">&nbsp;</td>
                    <td align="left" style="width: 165px">&nbsp;</td>
                    <td align="left" style="width: 330px">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td align="center" colspan="6"> 
                   <%--     <div style="width: 1100px; overflow-x: scroll" align="center">          --%>              
                            <asp:GridView ID="gvBusqMaestro" runat="server" AllowPaging="True" BorderColor="#DADADA" DataKeyNames="IdGrupoBeneficio,NroTramite" OnSelectedIndexChanged="gvBusqMaestro_SelectedIndexChanged" AutoGenerateColumns="False" OnPageIndexChanging="gvBusqMaestro_PageIndexChanging" Width="1100px">
                                <HeaderStyle CssClass="cssHeaderImg" />
                                <Columns>
                                    <asp:CommandField ButtonType="Image" HeaderText="Elegir" SelectImageUrl="~/imagenes/16siguiente.png" SelectText="Seleccionar" ShowHeader="True" ShowSelectButton="True" />
                                    <asp:BoundField DataField="Nombres" HeaderText="Nombres" />      
                                    <asp:BoundField DataField="Ap. Paterno" HeaderText="Ap. Paterno" />      
                                    <asp:BoundField DataField="Ap. Materno" HeaderText="Ap. Materno" />      
                                    <asp:BoundField DataField="Nro. Doc. Id." HeaderText="Nro. Doc. Id." />      
                                    <asp:BoundField DataField="Matrícula" HeaderText="Matrícula" />      
                                    <asp:BoundField DataField="Fec. Nac" HeaderText="Fec. Nac." DataFormatString="{0:dd/MM/yyyy}"/>      
                                    <asp:BoundField DataField="CUA" HeaderText="CUA" />      
                                    <asp:BoundField DataField="AFP" HeaderText="AFP" />      
                                    <asp:BoundField DataField="OficinaRegistro" HeaderText="Regional" />      
                                    <asp:BoundField DataField="Sector" HeaderText="Sector" />      
                                    <asp:BoundField DataField="NroTramite" HeaderText="Nro. Tramite" />      
                                    <asp:BoundField DataField="IdGrupoBeneficio" HeaderText="IdGrupoBeneficio" Visible="False"/>      
                                    <asp:BoundField DataField="GrupoBeneficio" HeaderText="Grupo Beneficio" />      
                                    <asp:BoundField DataField="EstadoTrámite" HeaderText="Estado Tramite" />      
                                </Columns>
                                <EmptyDataTemplate>
                                    <div align="center" class="CajaDialogoAdvertencia" style="width: 1100px">
                                        <br/>
                                        <img src="../Imagenes/warning.gif" 
                                            alt="No existen registros" />
                                        <br/>
                                        Bandeja de trámites vacía.
                                        <br/>
                                        <br/>
                                    </div>
                                </EmptyDataTemplate>
                            </asp:GridView>     
                      <%--  </div>   --%>                
                    </td>
                </tr>
            </table>       
        </asp:Panel>
    </div>
    <div align="center" class="pnlGral">
        <asp:Panel ID="pnlDetalle" runat="server" CssClass="pnlPest" Visible="False" HorizontalAlign="Center">
            <table style="width: 100%;">
                <tr>
                    <td align="center">
                        <div style="width: 1100px; overflow-x: scroll" align="center">
                            <asp:GridView ID="gvDetalle" runat="server" AllowPaging="True" BorderColor="#DADADA" OnSelectedIndexChanged="gvBusqMaestro_SelectedIndexChanged" Width="2300px" OnPageIndexChanging="gvDetalle_PageIndexChanging">
                                <HeaderStyle CssClass="cssHeaderImg" />
                                <EmptyDataTemplate>
                                    <div align="center" class="CajaDialogoAdvertencia" style="width: 1100px">
                                        <br/>
                                        <img src="../Imagenes/warning.gif" 
                                                        alt="No existen registros" />
                                        <br/>
                                        Bandeja de Historial vacía.
                                        <br/>
                                        <br/>
                                    </div>
                                </EmptyDataTemplate>
                            </asp:GridView>                        
                        </div>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>

</asp:Content>

