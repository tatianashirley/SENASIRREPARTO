<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmEstructuraProgramacion.aspx.cs" Inherits="CertificacionCC_wfrmEstructuraProgramacion" StylesheetTheme="Modal" Culture="Auto" UICulture="Auto"%>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    
    <style type="text/css">
        .auto-style5 {
            height: 23px;
        }
    </style>
    
    </asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
                    <asp:Button ID="btnInsertar" runat="server" Text="Insertar" OnClick="btnInsertar_Click" CssClass="boton150"  />
                </td>
                <td></td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </div>
     <asp:Panel ID="pnlConsultaEstructuraProgramacion" runat="server">
      <table width="100%" border="0" cellpadding="false" cellspacing="false">
  <tr>
    <td width="50%" align="right" class="auto-style5"></td>
    <td align="left" class="auto-style5"></td>
  </tr>
  <tr>
    <td  align="center" colspan="2">
       <asp:GridView ID="gvEstructura" runat="server"             
            AutoGenerateColumns="False" BorderColor="#DADADA" BorderStyle="Solid" BorderWidth="1px" CssClass="etiqueta8Blue" SkinID="GridView"
            EnableTheming="True" Font-Names="Arial" Font-Size="9pt" GridLines="Horizontal" 
            DataKeyNames="IdEstructura"  OnRowCommand="gvEstructura_RowCommand" 
            AllowPaging="True" PageSize="15" OnPageIndexChanging="gvEstructura_PageIndexChanging" >
                            <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                            <Columns>
                                <asp:BoundField DataField="RowNumber" HeaderText="Nro" />
                                <asp:BoundField DataField="IdEstructura" HeaderText="Id" Visible="false" />
                                <asp:BoundField DataField="Descripcion" HeaderText="Descripción"/>
                                <asp:BoundField DataField="EstadoEstructura" HeaderText="EstadoEstructura" Visible="false"/>
                                <asp:BoundField DataField="Estado" HeaderText="Estado" Visible="true"/>                                
                                <asp:TemplateField HeaderText="Editar">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgEditar" runat="server" CausesValidation="false" CommandArgument='<%#Eval("IdEstructura") %>' CommandName="cmdEditar" ImageUrl="~/imagenes/16modificar.png" ToolTip="Editar Estructura de la Programación"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Estructura Detalle">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgEditarEstructura" runat="server" CausesValidation="false" CommandArgument='<%#Eval("IdEstructura") %>' CommandName="cmdEditarEstructuraDetalle" ImageUrl="~/imagenes/16siguiente.png" ToolTip="Ver Detalle de la Estructura"/>
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
                        </asp:GridView>
        &nbsp;</td>
  </tr>
</table>
    </asp:Panel>
    <asp:Panel ID="pnlRegistroEstructura" runat="server">
      <table width="100%" border="0" cellpadding="false" cellspacing="false">
  <tr>
    <td width="50%" align="right">&nbsp;</td>
    <td align="left">&nbsp;</td>
  </tr>
  <tr>
    <td align="right">
        <asp:Label ID="Label2" runat="server" Text="Descripción: "></asp:Label>
      </td>
    <td align="left">
        <asp:TextBox ID="txtDescripcion" runat="server" Width="200px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDescripcion" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
        <asp:TextBox ID="txtIdEstructuraAct" runat="server" ReadOnly="true" Width="50" Visible="false"></asp:TextBox>
      </td>
  </tr>
          <tr>
              <td align="center" colspan="2">
                  <asp:CheckBox ID="chbEstado" runat="server" Text="Activo" Visible="false" />
              </td>
          </tr>
          <tr>
              <td align="right">
                  &nbsp;</td>
              <td align="left">
                  &nbsp;</td>
          </tr>
          <tr>
              <td align="right" >
                  <asp:Button ID="btnRegistraPanel1" runat="server" Text="Registrar" OnClick="btnRegistraPanel1_Click" visible="false" />
                  <asp:Button ID="btnActualizarPanel1" runat="server"  Text="Actualizar" Visible="false" OnClick="btnActualizarPanel1_Click" />
              </td>
              <td align="left">
                  <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CausesValidation="false" OnClick="btnLimpiar_Click" visible="false"/>
                  <asp:Button ID="btnCancelar" runat="server" CausesValidation="false"  Text="Cancelar" Visible="true" OnClick="btnCancelar_Click" />
              </td>
          </tr>
</table>
    </asp:Panel>

   <asp:Panel ID="pnlRegistroDetalleEstructura" runat="server">
      <table width="100%" border="0" cellpadding="false" cellspacing="false">
  <tr>
    <td width="50%" align="right" class="auto-style5"></td>
    <td align="left" class="auto-style5"></td>
  </tr>
  <tr>
    <td align="right">
        <asp:Label ID="Label3" runat="server" Text="Id: "></asp:Label>
      </td>
    <td align="left">
        <asp:TextBox ID="txtIdEstructura" runat="server" ReadOnly="true"></asp:TextBox>
      </td>
  </tr>
          <tr>
              <td align="right">&nbsp;</td>
              <td align="left">
                  <asp:CheckBox ID="chbSuperior" runat="server" OnCheckedChanged="chbSuperior_CheckedChanged" Text="Rol Superior" AutoPostBack="True" Checked="True" />
              </td>
          </tr>
          <tr>
              <td align="right">
                  <asp:Label ID="lblRolSuperior" runat="server" Text="Rol Superior: " Visible="false"></asp:Label>
              </td>
              <td align="left">
                  <asp:DropDownList ID="ddlIdRolSuperior" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlIdRolSuperior_SelectedIndexChanged" Visible="false">
                  </asp:DropDownList>
              </td>
          </tr>
  <tr>
    <td align="right">
        <asp:Label ID="Label5" runat="server" Text="Rol: "></asp:Label>
      </td>
    <td align="left">
        <asp:DropDownList ID="ddlIdRol" runat="server">
        </asp:DropDownList>
      </td>
  </tr>
          <tr>
              <td align="right">
                  <asp:Label ID="Label6" runat="server" Text="Cantidad Usuarios: "></asp:Label>
              </td>
              <td align="left">
                  <asp:TextBox ID="txtCantidadUsuarios" runat="server" Width="20px"></asp:TextBox>
              </td>
          </tr>
  <tr>
    <td align="right">
        &nbsp;</td>
    <td align="left">
        &nbsp;</td>
  </tr>
          <tr>
              <td align="center" colspan="2">
                  <asp:Button ID="btnRegistraPnl2" runat="server" Text="Registrar" OnClick="btnRegistraPnl1_Click" />
                  <asp:Button ID="btnLimpiarPnl2" runat="server" Text="Limpiar" OnClick="btnLimpiarPnl2_Click" />
                  <asp:Button ID="btnFinalizar" runat="server" Text="Finalizar" OnClick="btnFinalizar_Click" />
              </td>
          </tr>
          <tr>
              <td align="right" >
                  &nbsp;</td>
              <td align="left">
                  &nbsp;</td>
          </tr>
          <tr>
              <td align="center" colspan="2">
                  <asp:GridView ID="gvEstructuraDetalle" runat="server"  AutoGenerateColumns="False" BorderColor="#DADADA" BorderStyle="Solid" BorderWidth="1px" CssClass="etiqueta8Blue" DataKeyNames="IdEstructura,IdRol" EnableTheming="True" Font-Names="Arial" Font-Size="9pt" GridLines="Horizontal"  SkinID="GridView" OnSelectedIndexChanged="gvEstructuraDetalle_SelectedIndexChanged">
                      <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                      <Columns>
                          <asp:BoundField DataField="RowNumber" HeaderText="Nro" />
                          <asp:BoundField DataField="IdEstructura" HeaderText="Id" Visible="false" />
                          <asp:BoundField DataField="RolSuperior" HeaderText="Rol Superior" />
                          <asp:BoundField DataField="IdRol" HeaderText="IdRol" Visible="false" />                          
                          <asp:BoundField DataField="Rol" HeaderText="Rol" Visible="true" />                          
                          <asp:BoundField DataField="Cantidad" HeaderText="Nro de Usuarios" Visible="true" />
                          <asp:CommandField ButtonType="Image" HeaderText="Eliminar" ItemStyle-Width="10px" SelectImageUrl="../Imagenes/16eliminar.png" ShowSelectButton="True" >
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    </asp:CommandField>
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
              <td align="right">&nbsp;</td>
              <td align="left">&nbsp;</td>
          </tr>
</table>
    </asp:Panel>
    


</asp:Content>

