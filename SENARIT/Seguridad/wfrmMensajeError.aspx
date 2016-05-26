<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmMensajeError.aspx.cs" Inherits="Seguridad_wfrmMensajeError" StylesheetTheme="Modal" %>

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
                    <asp:Label ID="lblTitulo" runat="server" Font-Bold="True" ForeColor="#CC0000" Font-Size="17px" Text="Mensaje de Error"></asp:Label>
                </td>
                <td align="right">
                    <asp:Button ID="btnInsertar" runat="server" Text="Insertar" OnClick="btnInsertar_Click" CssClass="boton150" Visible="true"  />
                </td>
                <td></td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </div>
    <asp:Panel ID="pnlListaMensajeError" runat="server">
        <div>
            <table align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td align="center" colspan="2">&nbsp;</td>

                </tr>
                <tr>
                    <td align="right">


                        Modulo:
                        </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlIdModulo" runat="server" AppendDataBoundItems="true" AutoPostBack="True" OnSelectedIndexChanged="ddlIdModulo_SelectedIndexChanged">
                            <asp:ListItem Value="0">Seleccione...</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label15" runat="server" Text="Procedimiento: "></asp:Label>
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlIdProcedimientoLista" runat="server"  AutoPostBack="True"  Width="200px" OnSelectedIndexChanged="ddlIdProcedimientoLista_SelectedIndexChanged" >
                            
                        </asp:DropDownList>
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
                            DataKeyNames="IdMensaje" 
                            EnableTheming="True" 
                          
                            OnPageIndexChanging="gvDatos_PageIndexChanging"
                            OnRowCommand="gvDatos_RowCommand" 
                            PageSize="15" >
                            <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                            <Columns>
                                <asp:BoundField DataField="RowNumber" HeaderText="Nro" />
                                <asp:BoundField DataField="IdMensaje" HeaderText="IdMensaje" Visible="true" />
                                <asp:BoundField DataField="TextoMensaje" HeaderText="Descripcion MensajeError">
                                <HeaderStyle Width="240px" />
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>                               
                                <asp:TemplateField HeaderText="Editar">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgEditar" runat="server" CausesValidation="false" CommandArgument='<%#Eval("IdMensaje") %>' CommandName="cmdEditar" ImageUrl="~/imagenes/16modificar.png" />
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
    <asp:Panel ID="pnlRegistraMensajeError" runat="server" CssClass="panelprincipal"><%-- Style="display: none;">--%>
                    <div align="center">
                        
                        <br />
                        <table style="width:700px;">
                           
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:Label ID="Label1" runat="server" Text="Nuevo Mensaje de Error" 
                            CssClass="etiqueta20"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right"  Width="200px">
                                    &nbsp;</td>
                                <td align="left" class="auto-style6">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label13" runat="server" CssClass="etiqueta10" style="text-align: left" Text="Modulo:"></asp:Label>
                                </td>
                                <td align="left" class="auto-style6">
                                    <asp:DropDownList ID="ddlIdModuloRegistrar" runat="server"  Width="200px" AutoPostBack="True"   AppendDataBoundItems="true" OnSelectedIndexChanged="ddlIdModuloRegistrar_SelectedIndexChanged">
                                        <asp:ListItem Value="0">Seleccione...</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblProcedimiento" runat="server" CssClass="etiqueta10" style="text-align: left" Text="Procedimiento:"></asp:Label>
                                </td>
                                <td align="left" class="auto-style6">
                                    <asp:DropDownList ID="ddlIdProcedimiento" runat="server" AppendDataBoundItems="true" AutoPostBack="True" OnSelectedIndexChanged="ddlIdProcedimiento_SelectedIndexChanged" Width="200px">
                                        <asp:ListItem>Seleccione...</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblNroMensaje" runat="server" CssClass="etiqueta10" style="text-align: left" Text="Nro de Mensaje de Error:" Visible="false"></asp:Label>
                                </td>
                                <td align="left" class="auto-style6">
                                    <asp:TextBox ID="txtNroMensaje" runat="server" CssClass="texto10" MaxLength="100" Width="300px" Visible="false" ReadOnly="true"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvNroMensaje" runat="server" ControlToValidate="txtNroMensaje" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label12" runat="server" CssClass="etiqueta10" style="text-align: left" Text="Descripcion del Mensaje de Error :"></asp:Label>
                                </td>
                                <td align="left" class="auto-style6">
                                    <asp:TextBox ID="txtDescripcionMensajeError" runat="server" CssClass="texto10" MaxLength="100" Width="300px"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" FilterType="LowercaseLetters,UppercaseLetters,Numbers,Custom"  TargetControlID="txtDescripcionMensajeError" ValidChars=" :-"/>
                                    &nbsp;<asp:TextBox ID="txtIdMensaje" runat="server" CssClass="texto10" MaxLength="100" ReadOnly="True" Visible="False" Width="25px"></asp:TextBox>
                                    
                                    <asp:RequiredFieldValidator ID="rfvDescripcionMensaje" runat="server" ControlToValidate="txtDescripcionMensajeError" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                                    
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
PopupControlID="pnlRegistraMensajeError" 
BackgroundCssClass="modalBackground"> 
</cc1:ModalPopupExtender>               
      
    </asp:Panel>
    


</asp:Content>

