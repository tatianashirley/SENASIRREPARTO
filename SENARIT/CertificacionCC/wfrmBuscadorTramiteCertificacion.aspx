<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmBuscadorTramiteCertificacion.aspx.cs" Inherits="CertificacionCC_wfrmBuscadorTramiteCertificacion" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div align="center">
        <br />
        Buscador de Tramites<br />
        <br />
    <asp:Label ID="Label1" runat="server" Text="IdTramite" ></asp:Label>
    :
    <asp:TextBox ID="txtIdtramite" runat="server"></asp:TextBox>
    &nbsp;<br />
    <asp:Button ID="btnEnviar" runat="server" OnClick="btnEnviar_Click" Text="Ingresar Actividad" />
        <br />
        <br />
        <br />
        <hr width="80%" />
        <div style="font-size: small; color: #0000FF;" align="left">* El tramite que tiene menos o igual a tres rechazos por parte del revisor, control de calidad, responsable; se encuentra en color amarillo<br />
            ** El tramite que tiene mas tres rechazos por parte del revisor, control de calidad, responsable; se encuentra en color rojo

        </div>
        <asp:Panel ID="pnlListaTramitesBandeja" runat="server">
            <div align="center">
                <br />
                <p>
                    Lista de tramites asignados ===> Cantidad: <asp:Label ID="lblCantidad" runat="server"  ForeColor="#0033cc"></asp:Label> </p>
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
                        DataKeyNames="IdTramite,NUP,CUA,Matricula,NombreCompleto,FechaInicioTramite,Rebotes,FechaAsignacion,Dias,TipoTramite,DescripcionSector"  
                        OnRowDataBound="gvBandeja_RowDataBound" 
                        OnPageIndexChanging="gvBandeja_PageIndexChanging"
                        OnRowCommand="gvBandeja_RowCommand"
                       >
                          
                            <Columns>  
                                 <asp:TemplateField HeaderText="Seleccionar..." >                                  
                                    <ItemTemplate>
                                        <center>                                                                                
                                        <asp:ImageButton ID="imgSeleccionar" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdSeleccionar" ImageUrl="~/imagenes/nueva3/siguiente32.png" ToolTip="Editar Registro" alt="Editar Aporte" />
                                        
                                             </center>
                                    </ItemTemplate>
                                </asp:TemplateField>                                    
                                <asp:BoundField DataField="TipoTramite" HeaderText="Tipo"  />
                                <asp:BoundField DataField="NumeroTramiteCrenta" HeaderText="Tramite Crenta"  />
                                <asp:BoundField DataField="DescripcionSector" HeaderText="Sector"  />
                                <asp:BoundField DataField="IdTramite" HeaderText="Tramite" Visible="false"  />
                                <asp:BoundField DataField="NUP" HeaderText="NUP" Visible="false"  />                                
                                <asp:BoundField DataField="CUA" HeaderText="CUA"  />
                                <asp:BoundField DataField="Matricula" HeaderText="Matricula"  />                                                                
                                <asp:BoundField DataField="NombreCompleto" HeaderText="NombreCompleto"/>                                      
                                <asp:BoundField DataField="FechaInicioTramite" HeaderText="Inicio Tramite"/>                                  
                                <asp:BoundField DataField="FechaAsignacion" HeaderText="Fecha Asignacion">
                                 <HeaderStyle Width="40px" />
                                    </asp:BoundField >
                                <asp:BoundField DataField="Rebotes" HeaderText="Nro de Rechazos" ItemStyle-HorizontalAlign="Center">
                                    <HeaderStyle Width="40px" />
                                    </asp:BoundField >
                                <asp:BoundField DataField="Dias" HeaderText="Dias" ItemStyle-HorizontalAlign="Center" Visible="false">
                                    <HeaderStyle Width="40px" />
                                    </asp:BoundField >
                                  
                                                          
                            </Columns>
                            <EmptyDataTemplate><div align="center" class="CajaDialogoAdvertencia">
      <br/>
                                <img src="../Imagenes/warning.gif" 
              alt="No existen datos que correspondan al criterio especificado" />
      <br/>No existen datos que correspondan al criterio especificado
                                <br/><br/>
                                               </div>
    </EmptyDataTemplate>
                            <SelectedRowStyle BackColor="#FFFF99" />
                        </asp:GridView>
                </div>
        </asp:Panel>
        </div>
    </asp:Content>

