<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmProcedimiento.aspx.cs" Inherits="Seguridad_wfrmProcedimiento" StylesheetTheme="Modal" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    
    <style type="text/css">
        .auto-style1 {
            width: 200px;
        }
        .auto-style2 {
            width: 200px;
            height: 23px;
        }
        .auto-style3 {
            height: 23px;
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
                    <asp:Label ID="lblTitulo" runat="server" Font-Bold="True" ForeColor="#CC0000" Font-Size="17px" Text="Procedimientos"></asp:Label>
                </td>
                <td align="right">
                    <asp:Button ID="btnInsertar" runat="server" Text="Insertar" OnClick="btnInsertar_Click" CssClass="boton150"  />
                </td>
                <td></td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </div>
    <asp:Panel ID="pnlListaProcedimiento" runat="server">
        <div>
            <table align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td align="center">&nbsp;</td>

                </tr>
                <tr>
                    <td align="center">


                        Modulo:
                        <asp:DropDownList ID="ddlIdModulo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlIdModulo_SelectedIndexChanged"  AppendDataBoundItems="true">
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
                            DataKeyNames="IdProcedimiento" 
                            EnableTheming="True" 
                            
                            OnPageIndexChanging="gvDatos_PageIndexChanging" 
                            OnRowCommand="gvDatos_RowCommand" 
                            PageSize="15" 
                            >
                            <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                            <Columns>
                                <asp:BoundField DataField="RowNumber" HeaderText="Nro" />
                                <asp:BoundField DataField="IdProcedimiento" HeaderText="IdProcedimiento" Visible="false" />
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre Procedimiento">
                                <HeaderStyle Width="240px" />
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Script" HeaderText="Script" Visible="true">
                                <HeaderStyle Width="240px" />
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" Visible="true">
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
                                        <asp:ImageButton ID="imgEditar" runat="server" CausesValidation="false" CommandArgument='<%#Eval("IdProcedimiento") %>' CommandName="cmdEditar" ImageUrl="~/imagenes/16modificar.png" />
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
    <div class="fondopopup">
    <asp:Panel ID="pnlRegistraProcedimiento" runat="server" CssClass="panelprincipal" ><%-- Style="display: none;">--%>
                    <div align="center">
                        
                        <br />
                        <table style="width:900;">
                           
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:Label ID="Label1" runat="server" Text="Nuevo Procedimiento" 
                            CssClass="etiqueta20"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style2">
                                    </td>
                                <td align="left" class="auto-style3">
                                    </td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style1">
                                    <asp:Label ID="Label13" runat="server" CssClass="etiqueta10" style="text-align: left" Text="Modulo:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlIdModuloRegistrar" runat="server"  Width="200px"  AppendDataBoundItems="true" AutoPostBack="True" OnSelectedIndexChanged="ddlIdModuloRegistrar_SelectedIndexChanged">
                                        <asp:ListItem Value="0">Seleccione...</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style1">
                                    <asp:Label ID="lblNroProcedimiento" runat="server" CssClass="etiqueta10" style="text-align: left" Text="Nro de Procedimiento:" Visible="false"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtNroProcedimiento" runat="server" CssClass="texto10" MaxLength="100" Width="300px" Visible="true" ReadOnly="true"></asp:TextBox>
                                    
                                    <asp:RequiredFieldValidator ID="rfvNroProcedimiento" runat="server" ControlToValidate="txtNroProcedimiento" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style1">
                                    <asp:Label ID="Label12" runat="server" CssClass="etiqueta10" style="text-align: left" Text="Nombre del Procedimiento :"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtNombreProcedimiento" runat="server" CssClass="texto10" MaxLength="100" Width="300px"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" FilterType="LowercaseLetters,UppercaseLetters,Numbers,Custom"  TargetControlID="txtNombreProcedimiento" ValidChars=" ._"/>
                                    &nbsp;<asp:TextBox ID="txtIdProcedimiento" runat="server" CssClass="texto10" MaxLength="100" ReadOnly="True" Visible="False" Width="25px"></asp:TextBox>
                                    
                                    <asp:RequiredFieldValidator ID="rfvNombreProcedimiento" runat="server" ControlToValidate="txtNombreProcedimiento" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                                    
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style1">
                                    <asp:Label ID="Label15" runat="server" CssClass="etiqueta10" style="text-align: left" Text="Script :"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtScript" runat="server"  Width="300px" MaxLength="100"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="LowercaseLetters,UppercaseLetters,Numbers,Custom"  TargetControlID="txtScript" ValidChars=" ._"/>
                                 
                                    <asp:RequiredFieldValidator ID="rfvScript" runat="server" ControlToValidate="txtScript" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style1">
                                    <asp:Label ID="Label16" runat="server" CssClass="etiqueta10" style="text-align: left" Text="Descripcion :"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtDescripcion" runat="server" CssClass="texto10" MaxLength="100" Width="300px"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtDescripcion_FilteredTextBoxExtender" runat="server" FilterType="Numbers, Custom, LowercaseLetters, UppercaseLetters" TargetControlID="txtDescripcion" ValidChars=" ._">
                                    </cc1:FilteredTextBoxExtender>
                                    <asp:RequiredFieldValidator ID="rvfDescripcion" runat="server" ControlToValidate="txtDescripcion" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>   
                            <tr>
                                <td align="right" class="auto-style1">
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
                        <asp:Button ID="btnAdicionar" runat="server" CssClass="boton150"   Text="Adicionar" OnClick="btnAdicionar_Click" />
                        <asp:Button ID="Button1" runat="server" EnableTheming="True" Text="Cancelar" CssClass="boton150" onclick="btnCancelar_Click" CausesValidation="false"/>
                    </div>   
        <cc1:ModalPopupExtender ID="pnlRegistra_ModalPopupExtender" runat="server" 
Enabled="True" 
TargetControlID="lblTitulo" 
PopupControlID="pnlRegistraProcedimiento" 
BackgroundCssClass="modalBackground"
             
            > 
         
</cc1:ModalPopupExtender>               
      
    </asp:Panel>
    
        </div>

</asp:Content>

