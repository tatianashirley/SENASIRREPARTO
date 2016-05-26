<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmAdministradorRutas.aspx.cs" Inherits="WFArticulador_wfrmAdministradorRutas" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">         
 
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <table width="100%" border="0" cellpadding="false" cellspacing="false">
            <tr>
                <td class="auto-style6">
                    <asp:Label ID="lblTituloSistema" runat="server" Font-Bold="True" ForeColor="Navy" ></asp:Label>
                </td>
                <td width="70%" align="center">
                    <asp:Label ID="lblTitulo" runat="server" Font-Bold="True" ForeColor="#CC0000" Font-Size="17px" Text="Datos del Asegurado"></asp:Label> 
                </td>
                <td align="right">
                    &nbsp;</td>
                <td></td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </div>
    <table style="width:100%;">
      
    
        <tr>
            <td align="center">
               
              
                <table align="center" width="100%"> <tr>
                    <td style="border-style: outset" align="right" bgcolor="White">   
                        <asp:ImageButton ID="btnNuevaRuta" runat="server"  ImageUrl="~/Imagenes/nueva3/nuevo32.png" ToolTip="Adicionar Ruta" OnClick="btnNuevaRuta_Click" />                        
                        <asp:ImageButton ID="btnListaRutas" runat="server"  ImageUrl="~/Imagenes/nueva3/adicioncertificacion32.png" ToolTip="Ver Rutas" OnClick="btnListaRutas_Click" />                        
                        
                    </td>
                    </tr>
                    </table>
               
            </td>
        </tr>
          <tr>
            <td>
                <asp:Panel ID="pnlNuevaRuta" runat="server" CssClass="panelceleste" Width="100%">
                   <div align="center">
                     <table style="width: 100%;" align="center">
                        <tr>
                            <td width="50%" align="right">

                                <asp:Label ID="Label1" runat="server" Text="TipoFlujo:"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlTipoFlujo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTipoFlujo_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                           
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblOrigen" runat="server" Text="Area Origen:"></asp:Label>                                
                                
                            </td>
                            
                            <td align="left">
                                <asp:DropDownList ID="ddlAreaOrigen" runat="server" OnSelectedIndexChanged="ddlAreaOrigen_SelectedIndexChanged" AutoPostBack="True">
                                </asp:DropDownList>
                                
                                
                            
                              
                            </td>
                           
                        </tr>
                         <tr>
                             <td align="right">
                                 <asp:Label ID="Label5" runat="server" Text="Rol Origen:"></asp:Label><br /> 
                                
                             </td>
                             <td align="left">
                                 <asp:DropDownList ID="ddlRolOrigen" runat="server">
                                </asp:DropDownList>
                             </td>

                         </tr>
                         <tr>
                             <td align="right">
                                 <asp:Label ID="Label2" runat="server" Text="Area Destino:"></asp:Label>

                             </td>
                             <td align="left">
                                   <asp:DropDownList ID="ddlAreaDestino" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlAreaDestino_SelectedIndexChanged">
                                </asp:DropDownList>
                             </td>
                         </tr>
                        <tr>
                            <td align="right"> <asp:Label ID="Label3" runat="server" Text="Rol Destino:"></asp:Label></td>
                            <td align="left">
                                <asp:DropDownList ID="ddlRolDestino" runat="server">
                                </asp:DropDownList>
                            </td>
                            
                        </tr>
                         <tr>
                             <td align="center" colspan="2">
                                 <asp:Label ID="Label4" runat="server" Text="Justificacion"></asp:Label>
                                 <CKEditor:CKEditorControl ID="ckeJustificacion" runat="server" BasePath="~/ckeditor"></CKEditor:CKEditorControl>
                             </td>
                         </tr>
                         <tr>
                             <td align="right">&nbsp;</td>
                             <td>&nbsp;</td>
                         </tr>
                         <tr>
                             <td align="right">
                                 <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
                             </td>
                             <td align="left">
                                 <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" OnClick="btnLimpiar_Click" />
                             </td>
                         </tr>
                    </table>
                       </div>
                    </asp:Panel>
                <asp:Panel ID="pnlListaRutas" runat="server" CssClass="panelceleste" Width="100%">
                   <div>
                       <table style="width: 100%;">
                           <tr>
                               <td  width="50%" align="right">
                                   <asp:Label ID="Label6" runat="server" Text="Tipo Flujo:"></asp:Label>
                               </td>
                               <td align="left"> 
                                   <asp:DropDownList ID="ddlTipoFlujoBusqueda" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTipoFlujoBusqueda_SelectedIndexChanged">
                                   </asp:DropDownList>
                               </td>
                              
                           </tr>
                           <tr>
                               <td align="right">
                                   <asp:Label ID="Label7" runat="server" Text="AreaOrigen"></asp:Label>
                               </td>
                               <td align="left">
                                   <asp:DropDownList ID="ddlAreaOrigenBusqueda" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlAreaOrigenBusqueda_SelectedIndexChanged">
                                   </asp:DropDownList>
                               </td>
                               
                           </tr>
                           <tr>
                               <td>&nbsp;</td>
                               <td>&nbsp;</td>
                               
                           </tr>
                       </table>
                      

                      

                       <br />
                       </div>
                    <div align="center">
                       <asp:GridView ID="gvDatosRutas" runat="server"                                    
            AutoGenerateColumns="False" 
            EnableTheming="True" 
            Font-Names="Arial" 
                        Font-Size="9pt" 
                        CssClass="mGrid"
                        PagerStyle-CssClass="pgr"
                        AlternatingRowStyle-CssClass="alt"
                        GridLines="None"
            DataKeyNames="IdRuta,IdTipoFlujo,TipoFlujo,IdAreaOrigen,AreaOrigen,IdRolOrigen,RolOrigen,IdAreaDestino,AreaDestino,IdRolDestino,RolDestino,IdUsuarioRegistro,IdEstadoRuta,RegistroActivo"  
            OnRowDataBound="gvDatosRutas_RowDataBound" 
            OnRowCommand="gvDatosRutas_RowCommand"
                           
                           
                           >
                          
                            <Columns>
                           
                                
                                <asp:BoundField DataField="RolOrigen" HeaderText="Rol Origen" Visible="true" />                                
                                <asp:BoundField DataField="AreaDestino" HeaderText="Area Destino" Visible="true" />
                                <asp:BoundField DataField="RolDestino" HeaderText="Rol Destino"  />
                               
                             
                                <asp:TemplateField HeaderText="Eliminar Ruta">
                                    <ItemTemplate>
                                        <center>                                        
                                        <asp:ImageButton ID="imgEliminar" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdEliminar" alt="Eliminar Ruta" ImageUrl="~/imagenes/nueva3/eliminar32.png" />                                                                                
                                            </center>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Deshabilitar Ruta">
                                    <ItemTemplate>
                                        <center>                                        
                                        <asp:ImageButton ID="imgDeshabilitar" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdDeshabilitar" alt="Deshabilitar Ruta" ImageUrl="~/imagenes/nueva3/bloquear32.png" />                                                                                
                                            </center>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 </Columns>
                       </asp:GridView>
                       </div>
                    </asp:Panel>
                </td>
        </tr>


    </table>
    
</asp:Content>

