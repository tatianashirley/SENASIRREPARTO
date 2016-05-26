<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmIngresarInforme.aspx.cs" Inherits="CertificacionCC_wfrmIngresarInforme" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <table align="center" width="100%"> <tr>
                    <td style="border-style: outset" align="right" bgcolor="White">                           
                            <asp:HiddenField ID="hfIdTramite" runat="server" />
    <asp:HiddenField ID="hfIdGrupoBeneficio" runat="server" />
                        <asp:Label ID="lblPaterno" runat="server" Text="Label" Visible="false"></asp:Label>
                        <asp:Label ID="lblMaterno" runat="server" Text="Label" Visible="false"></asp:Label>
                        <asp:Label ID="lblNombres" runat="server" Text="Label" Visible="false"></asp:Label>
                        <asp:Label ID="lblMatricula" runat="server" Text="Label" Visible="false"></asp:Label>
                        <asp:Label ID="lblFechaInicio" runat="server" Text="Label" Visible="false"></asp:Label>
                        <asp:Label ID="lblFechaAsignacion" runat="server" Text="Label" Visible="false"></asp:Label>
                    </td>
                    </tr>
                    </table>    
    <asp:Panel ID="pnlListaInformes" runat="server">
        <asp:Label ID="lblTituloInformes" runat="server" Text="Lista Informes" Style="font-weight: 700"></asp:Label>
            <br />
    <asp:GridView ID="gvDatosInformes" runat="server"
                AllowPaging="True" PageSize="15"
                AutoGenerateColumns="False"
                EnableTheming="True"
                Font-Names="Arial"
                Font-Size="9pt"
                CssClass="mGrid"
                PagerStyle-CssClass="pgr"
                AlternatingRowStyle-CssClass="alt"
                GridLines="None"
                DataKeyNames="IdTramite,IdGrupoBeneficio,NroControl,Informe,Verificador,Revisor,FechaInforme,IdRolRevisor,RegistroActivo,IdUsuarioRegistro,NroCrenta,IdTipoInforme,TipoInforme,EstadoRegistro"
                OnRowCommand="gvDatosInformes_RowCommand"
                OnRowDataBound="gvDatosInformes_RowDataBound">

                <Columns>
                    <asp:BoundField DataField="IdTramite" HeaderText="Tramite" />
                    <asp:BoundField DataField="NroControl" HeaderText="Nro de Control" Visible="true" />
                    <asp:BoundField DataField="TipoInforme" HeaderText="Tipo Informe" Visible="true" />
                    <asp:BoundField DataField="FechaInforme" HeaderText="Fecha del Informe" />
                    <asp:BoundField DataField="Verificador" HeaderText="Login Ver." />
                    <asp:BoundField DataField="Revisor" HeaderText="Login Rev." />
                    <asp:BoundField DataField="EstadoRegistro" HeaderText="Estado" />
                    <asp:TemplateField HeaderText="Actividad">
                        <ItemTemplate>
                            <center>                                

                                <asp:Button ID="imgVer" runat="server" Text="Imprimir" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdVer" ImageUrl="~/imagenes/32TramiteAcepta.gif" ToolTip="Visualilzar Informe" alt="Visualizar Informe" />
                                
                            </center>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <div align="center" class="CajaDialogoAdvertencia">
                        <br />
                        <img src="../Imagenes/warning.gif"
                            alt="No existen datos que correspondan al criterio especificado" />
                        <br />
                        No existen datos que correspondan al criterio especificado
                                <br />
                        <br />
                    </div>
                </EmptyDataTemplate>
                <SelectedRowStyle BackColor="#FFFF99" />
            </asp:GridView>

    </asp:Panel>
        <asp:Panel ID="pnlEditarInforme" runat="server" Visible="false" HorizontalAlign="Center">
        <asp:Label ID="Label2" runat="server" Text="Informe del tramite" Style="font-weight: 700"></asp:Label>
        <br />
        <CKEditor:CKEditorControl ID="ckeInforme" runat="server" Height="500px"></CKEditor:CKEditorControl>
        <br />

        &nbsp;<br />
    </asp:Panel>
    
</asp:Content>

