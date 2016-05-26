<%@ Page Language="C#" MasterPageFile="~/MasterPage.master"  AutoEventWireup="true" CodeFile="wfrmEmpresa.aspx.cs" Inherits="NovedadesReparto_wfrmEmpresa" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    
        .cssHeaderImg
	{
	background-image : url(../Imagenes/Frames/Menu5.png);
    }
    
       </style>
        <script type="text/javascript" language="javascript">
            //function ModalPopup() 
            //{
            //    var vpRND = Math.random() * 20;
            //    showModalDialog('\ModalRol.aspx?rn=' + vpRND, '', 'dialogWidth=640px; dialogHeight=320px; center=yes; scrollbars=no');
            //}
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <asp:Panel ID="pnlGV" runat="server" HorizontalAlign="Center" Width="100%" 
                    CssClass="panelprincipal">
                    <asp:Label ID="lblTitulo" runat="server" Text="EJEMPLO EMPRESAS" 
                            CssClass="etiqueta20"></asp:Label>
                    <br />
                    <br />
                    Nombre:
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    <br />
                    <br />
                    Fecha:
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    <br />
                    <br />
                    Valor:
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Button ID="Button1" runat="server" Text="Guardar" OnClick="Button1_Click" />
                <br />
                </asp:Panel>
</asp:Content>

