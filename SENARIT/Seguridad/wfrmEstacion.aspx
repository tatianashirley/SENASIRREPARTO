<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmEstacion.aspx.cs" Inherits="Seguridad_wfrmEstacion" StylesheetTheme="Modal" %>

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
                    <asp:Label ID="lblTitulo" runat="server" Font-Bold="True" ForeColor="#CC0000" Font-Size="17px" Text="Estaciones"></asp:Label>
                </td>
                <td align="right">
                    <asp:Button ID="btnInsertar" runat="server" Text="Insertar" OnClick="btnInsertar_Click" CssClass="boton150"  />
                </td>
                <td></td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </div>
    <asp:Panel ID="pnlListaEstacion" runat="server">
        <div>
            <table align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td align="center">&nbsp;</td>

                </tr>
                <tr>
                    <td align="center">


                        <asp:Label ID="Label2" runat="server" Text="Oficina: "></asp:Label>
                        <asp:DropDownList ID="ddlIdOficina" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlIdOficina_SelectedIndexChanged"  AppendDataBoundItems="true">
                                        <asp:ListItem Value="0">Seleccione...</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="center">&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="gvDatos" runat="server" 
                            AllowPaging="True" 
                            AutoGenerateColumns="False"
                            Font-Names="Arial" 
                            Font-Size="9pt" 
                            CssClass="mGrid"
                            PagerStyle-CssClass="pgr"
                            AlternatingRowStyle-CssClass="alt"
                            GridLines="None" 
                            DataKeyNames="IdEstacion"                             
                            OnPageIndexChanging="gvDatos_PageIndexChanging" 
                            OnRowCommand="gvDatos_RowCommand" PageSize="15">
                            <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                            <Columns>
                                <asp:BoundField DataField="RowNumber" HeaderText="Nro" />
                                <asp:BoundField DataField="IdEstacion" HeaderText="IdEstacion" Visible="false" />
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre Estacion">
                                <HeaderStyle Width="240px" />
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="IPAddress" HeaderText="Direccion IP" Visible="true">
                                <HeaderStyle Width="240px" />
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="MACAddress" HeaderText="MAC" Visible="true">
                                <HeaderStyle Width="240px" />
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="IdEstado" HeaderText="IdEstado" Visible="false">
                                <HeaderStyle Width="40px" />
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Estado" HeaderText="Estado" Visible="true">
                                <HeaderStyle Width="40px" />
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Editar">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgEditar" runat="server" CausesValidation="false" CommandArgument='<%#Eval("IdEstacion") %>' CommandName="cmdEditar" ImageUrl="~/imagenes/16modificar.png" />
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
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlRegistraEstacion" runat="server" CssClass="panelprincipal"><%-- Style="display: none;">--%>
                    <div align="center">
                        
                        <br />
                        <table style="width:900;">
                           
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:Label ID="Label1" runat="server" Text="Nueva Estacion" 
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
                                    <asp:Label ID="Label13" runat="server" CssClass="etiqueta10" style="text-align: left" Text="Oficina:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlIdOficinaRegistrar" runat="server"  Width="200px"  AppendDataBoundItems="true" AutoPostBack="True" OnSelectedIndexChanged="ddlIdOficinaRegistrar_SelectedIndexChanged" >
                                        <asp:ListItem Value="0">Seleccione...</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label12" runat="server" CssClass="etiqueta10" style="text-align: left" Text="Nombre de la Estación :"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtNombreEstacion" runat="server" CssClass="texto10" MaxLength="50" Width="300px"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="LowercaseLetters, UppercaseLetters,Numbers,Custom"  TargetControlID="txtNombreEstacion" ValidChars="_"/>
                                    &nbsp;<asp:TextBox ID="txtIdEstacion" runat="server" CssClass="texto10" MaxLength="100" ReadOnly="True" Visible="False" Width="25px"></asp:TextBox>
                                    
                                    <asp:RequiredFieldValidator ID="rfvNombreEstacion" runat="server" ControlToValidate="txtNombreEstacion" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                                    
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label18" runat="server" CssClass="etiqueta10" style="text-align: left" Text="Direccón IP :"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtIp" runat="server" CssClass="texto10" MaxLength="15" Width="300px"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtTasaCambio_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers, Custom" TargetControlID="txtIp" ValidChars=".">
                                    </cc1:FilteredTextBoxExtender>
                                    <asp:RegularExpressionValidator Display = "Dynamic" 
                                        ControlToValidate = "txtIp" 
                                        ID="RegularExpressionValidator1"
                                        ValidationExpression="(([0-9][0-9][0-9])[.]([0-9][0-9][0-9])[.]([0-9][0-9][0-9])[.]([0-9][0-9][0-9]))" runat="server" ErrorMessage="Este formato: ###.###.###.###">
                                      </asp:RegularExpressionValidator>
                                    
                                     
                                    <asp:RequiredFieldValidator ID="rfvIp" runat="server" ControlToValidate="txtIp" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label19" runat="server" CssClass="etiqueta10" style="text-align: left" Text="Mac :"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtMac" runat="server" CssClass="texto10" MaxLength="50" Width="300px"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" FilterType="LowercaseLetters,UppercaseLetters,Numbers,Custom"  TargetControlID="txtMac" ValidChars="-"/>
                                     <asp:RegularExpressionValidator Display = "Dynamic" 
                                        ControlToValidate = "txtMac" 
                                        ID="RegularExpressionValidator2"
                                        ValidationExpression="(([a-zA-Z0-9][a-zA-Z0-9][-][a-zA-Z0-9][a-zA-Z0-9][-][a-zA-Z0-9][a-zA-Z0-9][-][a-zA-Z0-9][a-zA-Z0-9][-][a-zA-Z0-9][a-zA-Z0-9][-][a-zA-Z0-9][a-zA-Z0-9][-][a-zA-Z0-9][a-zA-Z0-9][-][a-zA-Z0-9][a-zA-Z0-9]))" runat="server" ErrorMessage="Este formato: ##.##.##.##.##.##.##.##.">
                                      </asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="rfvMac" runat="server" ControlToValidate="txtMac" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label17" runat="server" CssClass="etiqueta10" style="text-align: left" Text="Estado :"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:RadioButtonList ID="rblIdEstado" runat="server">
                                        <asp:ListItem Value="31" Selected="True">Activo</asp:ListItem>                                        
                                        <asp:ListItem Value="32">Inactivo</asp:ListItem>

                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <asp:Button ID="btnActualizar" runat="server" CssClass="boton150"   Text="Actualizar" OnClick="btnActualizar_Click" />
                        <asp:Button ID="btnAdicionar" runat="server" CssClass="boton150"   Text="Adicionar" OnClick="btnAdicionar_Click"  />
                        <asp:Button ID="Button1" runat="server" EnableTheming="True" Text="Cancelar" CssClass="boton150" onclick="btnCancelar_Click" CausesValidation="false" />
                    </div>  
         <cc1:ModalPopupExtender ID="pnlRegistra_ModalPopupExtender" runat="server" 
Enabled="True" 
TargetControlID="lblTitulo" 
PopupControlID="pnlRegistraEstacion" 
BackgroundCssClass="modalBackground"> 
</cc1:ModalPopupExtender>                
      
    </asp:Panel>
   
</asp:Content>

