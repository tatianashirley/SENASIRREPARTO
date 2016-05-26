<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmReprogramacion.aspx.cs" Inherits="CertificacionCC_reprogramacion" StylesheetTheme="Modal" Culture="Auto" UICulture="Auto"%>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="FondoAplicacion">
        <table width="100%" border="0" cellpadding="false" cellspacing="false">
            <tr>
                <td width="20%">
                    <asp:Label ID="lblTituloSistema" runat="server" Font-Bold="True" ForeColor="Navy" ></asp:Label>
                </td>
                <td width="60%" align="center">
                    <asp:Label ID="lblSubTitulo" runat="server" Font-Bold="True" ForeColor="#CC0000" Font-Size="17px" ></asp:Label>
                </td>
                <td align="right" width="20%">
                    &nbsp;</td>
                <td></td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </div>
      <asp:Panel ID="pnlListaUsuariosBloqueados" runat="server">
      <table width="100%" border="0" cellpadding="false" cellspacing="false">
  <tr>
    <td width="50%" align="right">&nbsp;</td>
    <td align="left">&nbsp;</td>
  </tr>
  <tr>
    <td align="center" colspan="2">

        <%--OnRowDataBound="gvListaProgramacionMalla_RowDataBound" OnRowCommand="gvListaProgramacionMalla_RowCommand" --%>
        <asp:GridView ID="gvListaUsuariosBloqueados" runat="server"             
            AutoGenerateColumns="False" BorderColor="#DADADA" BorderStyle="Solid" BorderWidth="1px" CssClass="etiqueta8Blue" SkinID="GridView"
            EnableTheming="True" Font-Names="Arial" Font-Size="9pt" GridLines="Horizontal" 
            DataKeyNames="IdProgramacion,IdUsuario,IdRol,IdEstadoProgramacion"  OnRowCommand="gvListaUsuariosBloqueados_RowCommand" 
            >
                            <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                            <Columns>
                                <asp:BoundField DataField="RowNumber" HeaderText="Nro" />
                                <asp:BoundField DataField="IdProgramacion" HeaderText="Programacion" Visible="true" />
                                <asp:BoundField DataField="IdUsuario" HeaderText="IdUsuario"  Visible="false" />
                                <asp:BoundField DataField="CuentaUsuario" HeaderText="Cuenta Usuario"  />
                                <asp:BoundField DataField="IdRol" HeaderText="IdRol" Visible="false"/>
                                <asp:BoundField DataField="Rol" HeaderText="Rol" Visible="true"/>                                
                                <asp:BoundField DataField="NombreCompletoUsuario" HeaderText="Nombre Completo Usuario" />
                                <asp:BoundField DataField="DatosCompletosUsuario" HeaderText="Datos Usuario" />
                                <asp:BoundField DataField="NroTramites" HeaderText="Nro de Tramites" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="IdEstadoProgramacion" HeaderText="IdEstadoProgramacion"  />
                                <asp:BoundField DataField="Estado" HeaderText="Estado"  />
                                <asp:TemplateField HeaderText="Archivo Transitorio" ItemStyle-Width="50">
                                    <ItemTemplate>
                                        <center>
                                        <asp:ImageButton ID="imgEliminarMalla" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdArchivoTransitorio" ImageUrl="~/imagenes/16ArchivoTransitorio.png"  ToolTip="Reasignar a archivo transitorio"/>
                                        </center>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Seleccione..."><ItemTemplate><center><asp:ImageButton ID="imgAsignarVerificador" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdAsignarVerificador" ImageUrl="~/imagenes/16EquipoTrabajo.png" ToolTip="Reasignar a un Verificador" /></center></ItemTemplate></asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate><div align="center" class="CajaDialogoAdvertencia">
      <br/>
                                <img src="../Imagenes/warning.gif" 
              alt="No existen datos que correspondan al criterio especificado" />
      <br/>No existen datos que correspondan al criterio especificado
                                <br/><br/>
                                               </div>
    </EmptyDataTemplate>
                        </asp:GridView></td>
  </tr>    
</table>
    </asp:Panel>

    <%--PANEL RE ASIGNACION VERIFICADORES--%>
     <asp:Panel ID="pnlListaUsuarios" runat="server">
      <table width="100%" border="0" cellpadding="false" cellspacing="false">
  <tr>
    <td width="50%" align="right">&nbsp;</td>
    <td align="left">&nbsp;</td>
  </tr>
  <tr>
    <td width="50%" align="right">
        <asp:Label ID="lblIngreseProgramacion" runat="server" Text="Ingrese la programación a la que asignara:"></asp:Label>
      </td>
    <td align="left">
        <asp:TextBox ID="txtIdProgramacion" runat="server"></asp:TextBox>
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
      </td>
  </tr>
   <tr>
    <td align="right">&nbsp;</td>
    <td align="left">&nbsp;</td>
  </tr>
  
          <tr>
              <td align="center" colspan="2" >
                  <asp:GridView ID="gvListaProgramacionMalla" runat="server" AutoGenerateColumns="False" BorderColor="#DADADA" BorderStyle="Solid" BorderWidth="1px" CssClass="etiqueta8Blue" 
                      DataKeyNames="IdProgramacion,IdUsuario,IdRol,IdEstadoProgramacion" EnableTheming="True" Font-Names="Arial" Font-Size="9pt" GridLines="Horizontal" 
                      OnRowCommand="gvListaProgramacionMalla_RowCommand"  SkinID="GridView" >
                      <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                      <Columns>
                          <asp:BoundField DataField="RowNumber" HeaderText="Nro" />
                          <asp:BoundField DataField="IdProgramacion" HeaderText="Programacion" Visible="false" />
                          <asp:BoundField DataField="IdUsuario" HeaderText="IdUsuario" Visible="false" />
                          <asp:BoundField DataField="CuentaUsuario" HeaderText="Cuenta Usuario" />
                          <asp:BoundField DataField="IdRol" HeaderText="IdRol" Visible="false" />
                          <asp:BoundField DataField="Rol" HeaderText="Rol" Visible="true"/>
                          <asp:BoundField DataField="NombreCompletoUsuario" HeaderText="Nombre Completo Usuario"  />
                          <asp:BoundField DataField="DatosCompletosUsuario" HeaderText="Datos Usuario" />
                          <asp:BoundField DataField="IdEstadoProgramacion" HeaderText="IdEstadoProgramacion" />
                          <asp:BoundField DataField="Estado" HeaderText="Estado" />
                          <asp:TemplateField HeaderText="Seleccione...">
                              <ItemTemplate>
                                  <center>
                                      <asp:ImageButton ID="imgSelecciona" runat="server" CausesValidation="false" CommandArgument="<%#((GridViewRow)Container).RowIndex %>" CommandName="cmdSelecciona" ImageUrl="~/imagenes/sig.png" ToolTip="Seleccionar Verificador" />
                                      
                                  </center>
                              </ItemTemplate>
                          </asp:TemplateField>
                      </Columns>
                      <EmptyDataTemplate>
                          <div align="center" class="CajaDialogoAdvertencia">
                              <br/>
                              <img src="../Imagenes/warning.gif" 
              alt="No existen datos que correspondan al criterio especificado" />
                              <br/>
                              No existen datos que correspondan al criterio especificado
                              <br/>
                              <br/>
                          </div>
                      </EmptyDataTemplate>
                  </asp:GridView>
              </td>
          </tr>
          <tr>
              <td align="right" width="50%">&nbsp;</td>
              <td align="left">&nbsp;</td>
          </tr>
          <tr>
              <td align="right" width="50%">&nbsp;</td>
              <td align="left">&nbsp;</td>
          </tr>
  
</table>
    </asp:Panel>

</asp:Content>

