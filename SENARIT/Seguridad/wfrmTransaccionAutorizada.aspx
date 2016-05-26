<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmTransaccionAutorizada.aspx.cs" Inherits="Seguridad_wfrmTransaccionAutorizada" StylesheetTheme="Modal" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
   
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="FondoAplicacion">
        <table width="100%" border="0" cellpadding="false" cellspacing="false">
            <tr>
                <td>
                    <asp:Label ID="lblTituloSistema" runat="server" Font-Bold="True" ForeColor="Navy" Text="MODULO DE SEGURIDAD"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblTitulo" runat="server" Font-Bold="True" ForeColor="#CC0000" Font-Size="17px" Text="Transacciones Autorizadas"></asp:Label>
                </td>
                <td align="right">
                    <asp:Button ID="btnInsertar" runat="server" Text="Insertar" OnClick="btnInsertar_Click" CssClass="boton150"  />
                </td>
                <td></td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </div>
    <asp:Panel ID="pnlListaTransaccionAutorizada" runat="server" >
        <div>
            <table align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td align="center">&nbsp;</td>

                </tr>
                <tr>
                    <td align="center">


                        Modulo:
                        <asp:DropDownList ID="ddlIdModulo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlIdModulo_SelectedIndexChanged" AppendDataBoundItems="true">
                                        <asp:ListItem Value="0">Seleccione...</asp:ListItem>
                        </asp:DropDownList>
                        &nbsp;Rol:
                        <asp:DropDownList ID="ddlIdRolBusqueda" runat="server"  Width="200px" AppendDataBoundItems="true" AutoPostBack="True" OnSelectedIndexChanged="ddlIdRolBusqueda_SelectedIndexChanged" >
                                        <asp:ListItem Value="0">Seleccione...</asp:ListItem>
                                    </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="center">&nbsp;</td>
                </tr>
                <tr>
                    <td align="center">&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="gvDatos" runat="server" 
                            AllowPaging="true" 
                            AutoGenerateColumns="False" 
                            Font-Names="Arial" 
Font-Size="9pt" 
CssClass="mGrid"
PagerStyle-CssClass="pgr"
AlternatingRowStyle-CssClass="alt"
GridLines="None"
                            DataKeyNames="IdRol,IdTransaccion" 
                            EnableTheming="True" 
                            
                            OnPageIndexChanging="gvDatos_PageIndexChanging"  
                            PageSize="15"   
                            OnRowCommand="gvDatos_RowCommand"                         
                            OnSelectedIndexChanged="gvDatos_SelectedIndexChanged"  >
                            <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                            <Columns>
                                <asp:BoundField DataField="RowNumber" HeaderText="Nro" />
                                <asp:BoundField DataField="IdRol" HeaderText="IdRol" Visible="true" />
                                <asp:BoundField DataField="IdTransaccion" HeaderText="IdTransaccion" Visible="true" />                                
                                <asp:BoundField DataField="IdModulo" HeaderText="IdModulo" Visible="false" />                                
                                
                                <asp:BoundField DataField="NombreRol" HeaderText="Descripcion Rol" Visible="true">
                                <HeaderStyle Width="240px" />
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NombreTransaccion" HeaderText="Descripcion Transaccion">
                                <HeaderStyle Width="240px" />
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Eliminar">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgEliminar" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdEliminar" ImageUrl="~/imagenes/16eliminar.png"  OnClientClick="return confirm('Esta seguro de eliminar el registro?');" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <%-- <asp:CommandField ButtonType="Image" HeaderText="Elimina" ItemStyle-Width="10px" SelectImageUrl="../Imagenes/16eliminar.png" ShowSelectButton="True">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    </asp:CommandField>--%>
                            </Columns>
                            <EmptyDataTemplate><div align="center" class="CajaDialogoAdvertencia">
      <br/>
                                <img src="../Imagenes/warning.gif" 
              alt="No existen datos que correspondan al criterio especificado" />
      <br/>No existen datos que correspondan al criterio especificado
                                <br/><br/>
                                               </div>
    </EmptyDataTemplate>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    <div class="fondopopup">
    <asp:Panel ID="pnlRegistraTransaccionAutorizada" runat="server"  CssClass="panelprincipal"><%-- Style="display: none;">--%>
                    <div align="center">
                        
                        <br />
                        <table style="width:900;">
                           
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:Label ID="Label1" runat="server" Text="Nueva TransaccionAutorizada" 
                            CssClass="etiqueta20"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right"  Width="200px">
                                    &nbsp;</td>
                                <td align="left">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label13" runat="server" CssClass="etiqueta10" style="text-align: left" Text="Modulo:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlIdModuloRegistrar" runat="server"  Width="200px" AutoPostBack="True" OnSelectedIndexChanged="ddlIdModuloRegistrar_SelectedIndexChanged" AppendDataBoundItems="true">
                                        <asp:ListItem Value="0">Seleccione...</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label20" runat="server" CssClass="etiqueta10" style="text-align: left" Text="Procedimiento:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlProcedimiento" runat="server" OnSelectedIndexChanged="ddlProcedimiento_SelectedIndexChanged" AutoPostBack="True" AppendDataBoundItems="true">
                                         <%--<asp:ListItem Value="0">Seleccione...</asp:ListItem>--%>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label19" runat="server" CssClass="etiqueta10" style="text-align: left" Text="Rol:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlIdRol" runat="server"  Width="200px" AppendDataBoundItems="true" >
                                        <asp:ListItem Value="0">Seleccione...</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label18" runat="server" CssClass="etiqueta10" style="text-align: left" Text="Transaccion:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlIdTransaccion" runat="server" Width="200px" AppendDataBoundItems="true">
                                        <asp:ListItem Value="0">Seleccione...</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                        <br />
                        
                        <asp:Button ID="btnAdicionar" runat="server" CssClass="boton150"   Text="Adicionar" OnClick="btnAdicionar_Click" />
                        <asp:Button ID="Button1" runat="server" EnableTheming="True" Text="Cancelar" CssClass="boton150" onclick="btnCancelar_Click" CausesValidation="false"/>
                    </div>     
        <cc1:ModalPopupExtender ID="pnlRegistra_ModalPopupExtender" runat="server" 
Enabled="True" 
TargetControlID="lblTitulo" 
PopupControlID="pnlRegistraTransaccionAutorizada" 
BackgroundCssClass="modalBackground"> 
</cc1:ModalPopupExtender>              
      
    </asp:Panel>
    </div>
    


</asp:Content>

