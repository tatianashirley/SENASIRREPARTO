<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmMenuVs2.aspx.cs" Inherits="Seguridad_wfrmMenuVs2" StylesheetTheme="Modal" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style5 {
            height: 19px;
        }
        .auto-style6 {
            height: 26px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="FondoAplicacion">
        <table width="100%" border="0" cellpadding="false" cellspacing="false">
            <tr>
                <td>
                    <asp:Label ID="lblTituloSistema" runat="server" Font-Bold="True" ForeColor="Navy" Text="MODULO DE SEGURIDAD"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblTitulo" runat="server" Font-Bold="True" ForeColor="#CC0000" Font-Size="17px"></asp:Label>
                </td>
                <td align="right">
                    <asp:Button ID="btnInsertar" runat="server" Text="Insertar Menu" OnClick="btnInsertar_Click" CssClass="boton150"  />
                </td>
                <td></td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </div>
    <asp:Panel ID="pnlListaMenu" runat="server">
        <div>
            <table align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td align="center" colspan="2">MENU</td>

                </tr>
                <tr>
                    <td align="right" class="auto-style6">


                        <asp:Label ID="Label18" runat="server" Text="Busqueda Menu Superior:"></asp:Label>
                        &nbsp;
                    </td>
                    <td align="left" class="auto-style6"><asp:TextBox ID="txtBMenuSuperior" runat="server" MaxLength="50"></asp:TextBox>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="right" class="auto-style5">Busqueda Menu :
                        
                    </td>
                    <td align="left" class="auto-style5"><asp:TextBox ID="txtBMenu" runat="server" MaxLength="50"></asp:TextBox>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="right" class="auto-style5">&nbsp;</td>
                    <td align="left" class="auto-style5">
                        <asp:Button ID="btnMenuSuperior" runat="server" OnClick="btnMenuSuperior_Click" Text="Buscar" />
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="gvDatos" runat="server" 
                            AllowPaging="True" 
                            AutoGenerateColumns="False" 
                            Font-Names="Arial" 
                            Font-Size="9pt" 
                            CssClass="mGrid"
                            PagerStyle-CssClass="pgr"
                            AlternatingRowStyle-CssClass="alt"
                            GridLines="None"                          
                            EnableTheming="True"                           
                            OnPageIndexChanging="gvDatos_PageIndexChanging" 
                            OnRowCommand="gvDatos_RowCommand" 
                            OnRowDataBound="gvDatos_RowDataBound" 
                            PageSize="15" 
                            >
                            <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                            <Columns>
                                <asp:BoundField DataField="RowNumber" HeaderText="Nro" />
                                <asp:BoundField DataField="IdMenu" HeaderText="IdMenu" Visible="true" />
                                <asp:BoundField DataField="MenuSuperior" HeaderText="Menu Superior">
                                <HeaderStyle Width="240px" />
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Menu" HeaderText="Menu" Visible="true">
                                <HeaderStyle Width="240px" />
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="URL" HeaderText="URL" Visible="true">
                                <HeaderStyle Width="240px" />
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="IdEstado" HeaderText="IdEstado" Visible="true">
                                <HeaderStyle Width="40px" />
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Estado" HeaderText="Estado" Visible="true">
                                <HeaderStyle Width="40px" />
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Editar">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgEditar" runat="server" CausesValidation="false" CommandArgument='<%#Eval("IdMenu") %>' CommandName="cmdEditar" ImageUrl="~/imagenes/16modificar.png" />
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
    <asp:Panel ID="pnlRegistraMenu" runat="server" CssClass="panelprincipal"><%-- Style="display: none;">--%>
                    <div align="center">
                        
                        <br />
                        <table style="width:900;">
                           
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:Label ID="Label1" runat="server" Text="Menu" 
                            CssClass="etiqueta20"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right"  Width="200px">
                                    <asp:Label ID="Label12" runat="server" CssClass="etiqueta10" style="text-align: left" Text="Descripción Menu :"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtMenu" runat="server" CssClass="texto10" MaxLength="100" Width="200px" autofocus="autofocus"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtMenu_FilteredTextBoxExtender" runat="server" FilterType="Numbers, Custom, LowercaseLetters, UppercaseLetters" TargetControlID="txtMenu" ValidChars=" ">
                                    </cc1:FilteredTextBoxExtender>
                                    <asp:TextBox ID="txtIdMenu" runat="server" CssClass="texto10" MaxLength="100" Width="25px" ReadOnly="True" Visible="False"></asp:TextBox>

                                    <asp:RequiredFieldValidator ID="rfvDescripcionMenu" runat="server" ControlToValidate="txtMenu" ErrorMessage="Ingrese la Descripcion del Menu" SetFocusOnError="True">*</asp:RequiredFieldValidator>

                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label13" runat="server" CssClass="etiqueta10" style="text-align: left" Text="Padre del Item:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlMenu" runat="server"  Width="200px"  AppendDataBoundItems="true">
                                        <asp:ListItem Value="0">Seleccione...</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label15" runat="server" CssClass="etiqueta10" style="text-align: left" Text="Orden :"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtPosicion" runat="server" Text="1" Width="50px"></asp:TextBox>
                                  <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" FilterType="Numbers"  TargetControlID="txtPosicion"  />
                                    <asp:RequiredFieldValidator ID="rfvPosicion" runat="server" ControlToValidate="txtPosicion" ErrorMessage="Es requerido este campo">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label16" runat="server" CssClass="etiqueta10" style="text-align: left" Text="URL :"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtURL" runat="server" CssClass="texto10" MaxLength="100" Width="200px">~/</asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtURL_FilteredTextBoxExtender" runat="server" FilterType="Numbers, Custom, LowercaseLetters, UppercaseLetters" TargetControlID="txtURL" ValidChars=" .~/">
                                    </cc1:FilteredTextBoxExtender>
                                    <asp:RequiredFieldValidator ID="rfvUrl" runat="server" ControlToValidate="txtURL" ErrorMessage="Es requerido este campo">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>   
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label17" runat="server" CssClass="etiqueta10" style="text-align: left" Text="Estado :"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:RadioButtonList ID="rblIdEstado" runat="server">
                                        <asp:ListItem Value="658" Selected="True">Activo Visible</asp:ListItem>
                                        <asp:ListItem Value="660">Activo No Visible</asp:ListItem>
                                        <asp:ListItem Value="659">Inactivo</asp:ListItem>

                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <asp:Button ID="btnActualizar" runat="server" CssClass="boton150"   Text="Actualizar" OnClick="btnActualizar_Click" />
                        <asp:Button ID="btnAdicionar" runat="server" CssClass="boton150"   Text="Adicionar" OnClick="btnAdicionar_Click" />
                        <asp:Button ID="Button1" runat="server" EnableTheming="True" Text="Cancelar" CssClass="boton150" onclick="btnCancelar_Click" CausesValidation="false"/>
                    </div>   
         <cc1:ModalPopupExtender ID="pnlRegistraMenu_ModalPopupExtender" runat="server"
                    Enabled="True"
                    TargetControlID="lblTitulo"                    
                    PopupControlID="pnlRegistraMenu"
                    BackgroundCssClass="modalBackground">
                </cc1:ModalPopupExtender>             
      
    </asp:Panel>
        


</asp:Content>

