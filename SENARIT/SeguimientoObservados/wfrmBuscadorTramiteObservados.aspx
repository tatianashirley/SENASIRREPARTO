<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmBuscadorTramiteObservados.aspx.cs" Inherits="SeguimientoObservados_wfrmBuscadorTramiteObservados" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div align="center">
    <asp:Label ID="Label1" runat="server" Text="Trámite" ></asp:Label>
    :
    <asp:TextBox ID="txtIdtramite" runat="server"></asp:TextBox>
    &nbsp;<br />
            &nbsp;<br />
        <asp:Button ID="btnEnviar" runat="server" OnClick="btnEnviar_Click" Text="Ingresar Actividad" Height="25px" />
        <br />
        </div>
         <asp:Panel ID="pnlListaTramitesBandeja" runat="server">
            <div align="center">
                <br />
                <p>
                    Lista de tramites Asignados ===> Cantidad: <asp:Label ID="lblCantidad" runat="server"  ForeColor="#0033cc"></asp:Label> </p>
            <asp:GridView ID="gvBandeja" runat="server"             
                        AllowPaging="True" PageSize="15"
                        AutoGenerateColumns="False"                         
                        EnableTheming="True" 
                        Font-Names="Arial" 
                        Font-Size="9pt" 
                        CssClass="mGrid"
                        PagerStyle-CssClass="pgr"
                        AlternatingRowStyle-CssClass="alt"
                        GridLines="None"
                        DataKeyNames="IdTramite,NUP,CUA,Matricula,NombreCompleto,FechaInicioTramite,TipoTramite,Regional"  
                        
                        OnPageIndexChanging="gvBandeja_PageIndexChanging"
                       >
                        <Columns>                                
                            <asp:BoundField DataField="TipoTramite" HeaderText="Tipo"  />
                            <asp:BoundField DataField="IdTramite" HeaderText="Tramite"  />
                            <asp:BoundField DataField="NUP" HeaderText="NUP" Visible="false"  />                                
                            <asp:BoundField DataField="CUA" HeaderText="CUA"  />
                            <asp:BoundField DataField="Matricula" HeaderText="Matricula"  />                                                                
                            <asp:BoundField DataField="NombreCompleto" HeaderText="NombreCompleto"/>                                      
                            <asp:BoundField DataField="FechaInicioTramite" HeaderText="Fec. Inicio Trámite"/>
                            <asp:BoundField DataField="Regional" HeaderText="Regional"/>                                  
                            <asp:BoundField DataField="Ingresos" HeaderText="# Ingresos" ItemStyle-HorizontalAlign="Center" ItemStyle-Font-Bold="true" ItemStyle-ForeColor="Red">
                                <HeaderStyle Width="50px" />
                                </asp:BoundField >        
                        </Columns>
                        <EmptyDataTemplate><div align="center" class="CajaDialogoAdvertencia">
                        <br/>
                        <img src="../Imagenes/warning.gif" alt="No existen datos que correspondan al criterio especificado" />
                        <br/>No existen datos que correspondan al criterio especificado
                        <br/><br/>
                        </div>
                         </EmptyDataTemplate>
                            <SelectedRowStyle BackColor="#FFFF99" />
                        </asp:GridView>
                </div>
        </asp:Panel>

    </asp:Content>

