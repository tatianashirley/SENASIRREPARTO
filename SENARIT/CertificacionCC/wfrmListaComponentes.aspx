<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmListaComponentes.aspx.cs" Inherits="CertificacionCC_wfrmListaComponentes" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div align="center"><br /><p>
        <asp:Label ID="Label1" runat="server" Text="Lista de Componentes" Font-Bold="True"></asp:Label></p>      

    </div>
    <div align="right"><asp:Label ID="lblEstadoTramite" runat="server" Text="Label" Font-Bold="True" ForeColor="#FF3300" Visible="false"></asp:Label> <asp:ImageButton ID="imgVolver" runat="server" ImageUrl="~/Imagenes/32Volver.png" ToolTip="Volver a la Página anterior"   OnClick="btnVolver_Click" /></div>
      <asp:GridView ID="gvDatosComponentes" runat="server"
                        AllowPaging="True" PageSize="15"
                        AutoGenerateColumns="False"
                        EnableTheming="True"
                        Font-Names="Arial"
                        Font-Size="9pt"
                        CssClass="mGrid"
                        PagerStyle-CssClass="pgr"
                        AlternatingRowStyle-CssClass="alt"
                        GridLines="None"
                        DataKeyNames="IdTramite,IdGrupoBeneficio,Version,RUC,Componente,IdTipoDocSalario,TipoDocSalario,PeriodoSalario,SalarioCotizable,IdMonedaSalario,EstadoSalario,EstadoSalarioDet,IdParametrizacion,GlosaSalario,Certificado,EstadoComponente,IdEstadoComponente,Mitas,SalarioCotizableActualizado,DensidadAportes,IdSector,Sector,Codigo,DetalleGeneral"
                        OnRowCommand="gvDatosComponentes_RowCommand" 
                        OnRowDataBound="gvDatosComponentes_RowDataBound"
          >

                        <Columns>
                            <asp:BoundField DataField="Componente" HeaderText="Comp." />
                            <asp:BoundField DataField="Version" HeaderText="Version" Visible="false" />
                            <asp:BoundField DataField="RUC" HeaderText="RUC" />
                            <asp:BoundField DataField="Empresa" HeaderText="Razon Social" />
                            <asp:BoundField DataField="TipoDocSalario" HeaderText="TipoDoc Salario" />
                            <asp:BoundField DataField="PeriodoSalario" HeaderText="Periodo Salario" >
                            <HeaderStyle Width="40px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SalarioCotizable" HeaderText="Salario Cotizable">
                                <HeaderStyle Width="40px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SalarioCotizableActualizado" HeaderText="Salario Cotizable Act">
                                <HeaderStyle Width="40px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DensidadAportes" HeaderText="Densidad">
                                <HeaderStyle Width="40px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Moneda" HeaderText="Moneda" />
                            <asp:BoundField DataField="Mitas" HeaderText="Mitas" />
                            <asp:BoundField DataField="EstadoComponente" HeaderText="Estado Salario" >
                             <HeaderStyle Width="40px" />
                            </asp:BoundField>                        
                            <asp:TemplateField HeaderText="Certi" ItemStyle-Width="50px">
                                <ItemTemplate>
                                    <center>
                                        <asp:ImageButton ID="imgCerti" width="20px" height="20px" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdCerti" ImageUrl="~/Imagenes/nueva3/certificacionsalario32.png" ToolTip="Editar Salario Cotizable" />
                                        <asp:ImageButton ID="imgCertificacionSalarioCorrelativo"  width="20px" height="20px" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdCertificacionSalarioCorrelativo" ImageUrl="~/imagenes/nueva3/qr.png" ToolTip="Reporte Certificacion de Salarios" />                                        
                                        
                                    </center>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <div align="center" class="CajaDialogoAdvertencia">
                                <br />
                                <img src="../Imagenes/warning.gif"
                                    alt="No existen datos que correspondan al criterio especificado"  />
                                <br />
                                No existen datos que correspondan al criterio especificado
                                <br />
                                <br />
                            </div>
                        </EmptyDataTemplate>
                        <SelectedRowStyle BackColor="#FFFF99" />
                    </asp:GridView>
    <div>
        <asp:Label ID="lblCertificacionParcial" runat="server" Text="Label" ForeColor="Red"></asp:Label>
        <asp:ImageButton ID="btnCertificacionParcial" runat="server"
                        ImageUrl="~/Imagenes/nueva3/certificacionsalario32.png"
                        ToolTip="Confirmación de Impresión" CausesValidation="false" width="20px" height="20px" OnClick="btnCertificacionParcial_Click" Visible="false" />
        <asp:HiddenField ID="hfIdTramite" runat="server" />
        <asp:HiddenField ID="hfIdGrupoBeneficio" runat="server" />
        <asp:HiddenField ID="hfIdTipoTramite" runat="server" />
      </div>
</asp:Content>

