<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmInsertarListarModulo.aspx.cs" Inherits="Seguridad_wfrmInsertarListarModulo" StylesheetTheme="Modal" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>

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
                    <asp:Label ID="lblTitulo" runat="server" Font-Bold="True" ForeColor="#CC0000" Font-Size="17px" Text="Lista Modulos y Servicios"></asp:Label>
                </td>
                <td align="right">
                    <asp:Button ID="btnInsertarModulo" runat="server" Text="Insertar Modulo" OnClick="btnInsertarModulo_Click" />
                </td>
                <td></td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </div>
    <asp:Panel ID="Panel1" runat="server">
        <div>
            <table align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td align="center">&nbsp;</td>

                </tr>
                <tr>
                    <td colspan="2">

                        <asp:GridView ID="gvDatos" runat="server" 
                            AutoGenerateColumns="False" 
                            Font-Names="Arial" 
Font-Size="9pt" 
CssClass="mGrid"
PagerStyle-CssClass="pgr"
AlternatingRowStyle-CssClass="alt"
GridLines="None"
                            OnRowCommand="gvDatos_RowCommand"   
                            OnRowDataBound="gvDatos_RowDataBound"   
                           
                            EnableTheming="true" 
                             
                            OnPageIndexChanging="gvDatos_PageIndexChanging"  
                            AllowPaging = "true" 
                            PageSize="15">                        
                            <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                            <Columns>
                                <asp:BoundField DataField="RowNumber" HeaderText="Nro" />
                                <asp:BoundField DataField="IdModulo" HeaderText="IdModulo" Visible="true" />
                                <asp:BoundField DataField="DescripcionModulo" HeaderText="Descripcion Modulo o Servicio">
                                    <HeaderStyle Width="240px" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SiglaModulo" HeaderText="Sigla Modulo" Visible="true">
                                    <HeaderStyle Width="40px" />
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
                                        <asp:ImageButton ID="imgEditar" runat="server" CausesValidation="false" CommandArgument='<%#Eval("IdModulo") %>' CommandName="cmdEditar" ImageUrl="~/imagenes/16modificar.png" />
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
    <asp:Panel ID="pnlRegistroModulo" runat="server" CssClass="panelceleste" ><%-- Style="display: none;">--%>
        <div>
            
            <table align="center" cellpadding="0" cellspacing="0" width="600px">
                <tr>
                    <td align="center" colspan="2">
                        <asp:Label ID="Label3" runat="server" Text="Nuevo Modulo o Servicio"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">&nbsp;</td>
                </tr>
                <tr>
                    <td align="right" width="50%">
                        <asp:Label ID="Label1" runat="server" Text="Abreviatura:"></asp:Label>
                        </td>
                    <td align="left">
                        <asp:TextBox ID="txtAbreviatura" runat="server" Width="179px" MaxLength="3" onkeyup="this.value=this.value.toUpperCase()" autofocus="autofocus"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" FilterType="LowercaseLetters,UppercaseLetters"  TargetControlID="txtAbreviatura" />
                        <asp:RequiredFieldValidator ID="rfvAbreviatura" runat="server" ErrorMessage="Ingrese Abreviatura" ControlToValidate="txtAbreviatura">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label2" runat="server" Text="Detalle Modulo o Servicio:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtDetalleModulo" runat="server" Width="179px" ></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="LowercaseLetters,UppercaseLetters,Custom"  TargetControlID="txtDetalleModulo" ValidChars=" "/>
                        <asp:TextBox ID="txtIdModulo" runat="server" ReadOnly="True" Width="20px" Visible="false"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvDetalleModulo" runat="server" ErrorMessage="Ingrese Detalle del Modulo" ControlToValidate="txtDetalleModulo">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="auto-style6" >
                       
                        <asp:Label ID="lblTipo" runat="server" Text="Tipo:" Visible="false"></asp:Label>
                    </td>
                    <td align="left">
                         <asp:RadioButtonList ID="rblTipo" runat="server" Visible="false">
                            <asp:ListItem Value="1">Servicio</asp:ListItem>
                            <asp:ListItem Value="2" Selected="True">Modulo</asp:ListItem>
                        </asp:RadioButtonList>

                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <asp:CheckBox ID="chbEstado" runat="server" Checked="True" Text="Activo" />
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" OnClick="btnActualizar_Click"  Visible="false" />
                        <asp:Button ID="btnAceptar" runat="server" Text="Registrar" OnClick="btnRegistrar_Click" />
                        &nbsp;<asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" CausesValidation="false" />
                    </td>
                </tr>
            </table>
            <br />
        </div>
        <cc1:ModalPopupExtender ID="pnlRegistroModulo_ModalPopupExtender" runat="server"
                    Enabled="True"
                    TargetControlID="lblTitulo"                    
                    PopupControlID="pnlRegistroModulo"
                    BackgroundCssClass="modalBackground">
                </cc1:ModalPopupExtender>
    </asp:Panel>    
                


</asp:Content>

