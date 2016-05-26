<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmBusquedaFCCyCS.aspx.cs" Inherits="CertificacionCC_wfrmBusquedaFCCyCS" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">   
 
    <asp:Panel ID="pnlOpcionBusqueda" runat="server"  BackColor="White" GroupingText="Parametro de Busqueda" Width="100%">
        <div align="center">
        <table style="width:100%;">
            <tr>
                <td  align="center" colspan="2" >
                    <asp:Label ID="lblTituloBusqueda" runat="server" ></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" width="50%">&nbsp;</td>
                <td align="left">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" width="50%">
                    <asp:Label ID="lblTramite" runat="server" Text="Tramite:"></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="txtTramite" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
            </div>
    </asp:Panel>
  
     <asp:Panel ID="pnlBotones" runat="server" GroupingText="Acciones" 
                        Width="100%" BackColor="White">
         <div align="center">
            <asp:Button ID="btn_busqueda" runat="server" Text="Buscar" Width="160px" OnClick="btn_busqueda_Click" 
                            />
                        <asp:Button ID="btn_borrar_resultados" runat="server" 
                            Text="Borrar Resultados" Width="160px" OnClick="btn_borrar_resultados_Click"  />
                    
                       
               
             </div>
                            </asp:Panel>
    <asp:Panel ID="pnlResultados" runat="server" GroupingText="Resultados de Busqueda" 
                        Width="100%" BackColor="White">
        <div align="center">
               <asp:GridView ID="gvDatosBusqueda" runat="server"             
                        AllowPaging="True" PageSize="10"
                        AutoGenerateColumns="False"                         
                        EnableTheming="True" 
                        Font-Names="Arial" 
                        Font-Size="9pt" 
                        CssClass="mGrid"
                        PagerStyle-CssClass="pgr"
                        AlternatingRowStyle-CssClass="alt"
                        GridLines="None"
                        DataKeyNames="IdTramite,FechaInicioTramite,Matricula,PrimerNombre,SegundoNombre,PrimerApellido,SegundoApellido,FlagM,FlagG,Aprobaciones,IdTipoTramite,TipoTramite,CertificacionSalario,TramiteInformado,AreaActual"                          
                        OnRowCommand="gvDatosBusqueda_RowCommand"    
                        OnRowDataBound="gvDatosBusqueda_RowDataBound"              
                       >                                  
                          
                            <Columns>                                                                
                                <asp:BoundField DataField="IdTramite" HeaderText="IdTramite"  />                                
                                <asp:BoundField DataField="Matricula" HeaderText="Matricula"  />
                                <asp:BoundField DataField="FechaInicioTramite" HeaderText="Fecha Inicio Tramite"  />                                                                
                                <asp:BoundField DataField="TipoTramite" HeaderText="Tipo Tramite"  />
                                <asp:BoundField DataField="PrimerNombre" HeaderText="Primer Nombre"  />
                                <asp:BoundField DataField="SegundoNombre" HeaderText="Segundo Nombre"  />
                                <asp:BoundField DataField="PrimerApellido" HeaderText="Primer Apellido"  />
                                <asp:BoundField DataField="SegundoApellido" HeaderText="Segundo Apellido"  />                                
                                <asp:BoundField DataField="AreaActual" HeaderText="Asigando..."  />
                              <asp:TemplateField HeaderText="Reportes" >                                  
                                    <ItemTemplate>
                                        <center>                                                                                
                                        <asp:ImageButton ID="imgInforme" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdInforme" ImageUrl="~/imagenes/32TramiteAcepta.gif" ToolTip="Ver Informe" />
                                        <asp:ImageButton ID="imgCertificacionSalario" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdCertificacionSalario" ImageUrl="~/imagenes/nueva3/certificacionsalario32.png" ToolTip="Reporte Certificacion de Salarios" />                                        
                                        
                                        <asp:ImageButton ID="imgFMensual" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdMensual" ImageUrl="~/imagenes/nueva3/imprimirformulariomensual32.png" ToolTip="Formulario Mensual" />                                        
                                        <asp:ImageButton ID="imgFGlobal" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdGlobal" ImageUrl="~/imagenes/nueva3/imprimirformularioglobal32.png" ToolTip="Formulario Global"/>                                        
                                             </center>
                                    </ItemTemplate>
                                </asp:TemplateField>               
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
</asp:Content>

