<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmCambiarPassword.aspx.cs" Inherits="Seguridad_wfrmCambiarPassword" StylesheetTheme="Modal" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
   
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server" EnableViewState="False">
    <div class="FondoAplicacion">
        <table width="100%" border="0" cellpadding="false" cellspacing="false">
            <tr>
                <td>
                    <asp:Label ID="lblTituloSistema" runat="server" Font-Bold="True" ForeColor="Navy" Text="MODULO DE SEGURIDAD"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblTitulo" runat="server" Font-Bold="True" ForeColor="#CC0000" Font-Size="17px" Text="Cambiar Contraseña Usuarios"></asp:Label>
                </td>
                <td align="right">
                    &nbsp;</td>
                <td></td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </div>
    
    <asp:Panel ID="pnlRegistro" runat="server" CssClass="panelprincipal"><%-- Style="display: none;">--%>
        <div>

            <table align="center" cellpadding="0" cellspacing="0" width="80%">
                <tr>
                    <td align="center" colspan="2">
                        <h2>Cambiar Contraseña Usuario Externo</h2>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">&nbsp;</td>
                </tr>
            
                <tr>
                    <td align="right" width="50%">
                        <asp:Label ID="Label5" runat="server" Text="Contraseña Nueva:"></asp:Label>
                    </td>
                    <td align="left">
                      
                    
                        <asp:TextBox ID="txtClaveN" runat="server" TextMode="Password" MaxLength="10" EnableViewState="False" ></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" FilterType="LowercaseLetters,UppercaseLetters,Numbers,Custom"  TargetControlID="txtClaveN" ValidChars=" "/>
                      
                    
                    </td>
                </tr>
                <tr>
                    <td align="right" width="50%">
                        <asp:Label ID="Label2" runat="server" Text="Confirmación Contraseña Nueva:"></asp:Label>
                    </td>
                    <td align="left">
                        
                        <asp:TextBox ID="txtConfirmaClaveNueva" runat="server" TextMode="Password" MaxLength="10"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="LowercaseLetters,UppercaseLetters,Numbers,Custom"  TargetControlID="txtConfirmaClaveNueva" ValidChars=" "/>
                        
                    </td>
                </tr>
               
               
               
                <tr>
                    <td align="center" colspan="2">
                        <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" OnClick="btnActualizar_Click"  />
                        &nbsp;<asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
                    </td>
                </tr>
            </table>
          
        </div>
    </asp:Panel>



</asp:Content>

