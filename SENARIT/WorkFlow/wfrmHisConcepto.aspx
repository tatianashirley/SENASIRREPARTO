<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmHisConcepto.aspx.cs" Inherits="WorkFlow_wfrmHisConcepto" StylesheetTheme="Modal"%>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">  
     <link href="EstiloWF.css" rel="stylesheet" type="text/css" /> 
     <style type="text/css">
         .auto-style5 {
             height: 26px;
         }
     </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <asp:Panel ID="pnlConcepto" runat="server">
            <table style="width: 100%;">
                <tr>
                    <td colspan="4" align="center">
                         <asp:ImageButton ID="imgAux" runat="server" ImageUrl="~/Imagenes/16w.png" />
                         <asp:Label ID="lblTituloAUX" runat="server" Text="REGISTRO DE CONCEPTOS" CssClass="etiqueta20"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label1" runat="server" Text="ID Concepto:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtIdConcepto" runat="server" CssClass="box" onkeyup="this.value=this.value.toUpperCase()" MaxLength="20" Width="150px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvIdConcepto" runat="server" ControlToValidate="txtIdConcepto" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                    <td align="right">
                        <asp:Label ID="Label3" runat="server" Text="Descripción:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtDescripcion" runat="server" Width="450px" MaxLength="500" CssClass="box"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvDescripcion" runat="server" ControlToValidate="txtDescripcion" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label2" runat="server" Text="Comentarios:"></asp:Label>
                    </td>
                    <td align="left" colspan="3">
                        <asp:TextBox ID="txtComentarios" runat="server" Width="850px" MaxLength="500" CssClass="box"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label4" runat="server" Text="Tipo de Dato:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="cboTipoDato" runat="server" OnSelectedIndexChanged="cboTipoDato_SelectedIndexChanged" AutoPostBack="true" CssClass="box">
                            <asp:ListItem>Seleccione valor ...</asp:ListItem>
                            <asp:ListItem Value="I">Int</asp:ListItem>
                            <asp:ListItem Value="M">Money</asp:ListItem>
                            <asp:ListItem Value="F">Float</asp:ListItem>
                            <asp:ListItem Value="C">Char</asp:ListItem>
                            <asp:ListItem Value="D">Date</asp:ListItem>
                            <asp:ListItem Value="T">caTalog</asp:ListItem>
                            <asp:ListItem Value="B">Boolean</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvTipoDato" runat="server" ControlToValidate="cboTipoDato" ErrorMessage="*" InitialValue="Seleccione valor ..."></asp:RequiredFieldValidator>
                    </td>
                    <td align="right">
                        <asp:Label ID="Label8" runat="server" Text="Longitud:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtLongitud" runat="server" CssClass="box" Enabled="False"></asp:TextBox>
                        <asp:RangeValidator ID="ravLongitud" runat="server" ControlToValidate="txtLongitud" ErrorMessage="Fuera de rango" MaximumValue="32767" MinimumValue="1" Type="Integer"></asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="auto-style5">
                        <asp:Label ID="Label9" runat="server" Text="Alias:"></asp:Label>
                    </td>
                    <td align="left" style="margin-left: 80px">
                        <asp:TextBox ID="txtAlias" runat="server" CssClass="box" MaxLength="50"></asp:TextBox>
                    </td>
                    <td align="right">
                        <asp:Label ID="Label6" runat="server" Text="Mayúscula:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:CheckBox ID="chkMayuscula" runat="server" Enabled="False" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label5" runat="server" Text="Tipo Clasificador"></asp:Label>
                    </td>
                    <td align="left" style="margin-left: 40px">
                        <asp:TextBox ID="txtTipoClasificador" runat="server" CssClass="box" Enabled="False"></asp:TextBox>
                        <asp:RangeValidator ID="ravTipoClasificador" runat="server" ControlToValidate="txtTipoClasificador" ErrorMessage="Fuera de rango" MaximumValue="2147483647" MinimumValue="1" Type="Integer"></asp:RangeValidator>
                    </td>
                    <td align="right">
                        <asp:Label ID="Label7" runat="server" Text="Máscara:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtMascara" runat="server" CssClass="box" MaxLength="30" Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right"></td>
                    <td align="left"></td>
                    <td align="right"></td>
                    <td align="left"></td>
                </tr>
                <tr>
                    <td align="center" colspan="4">
                        <asp:Button ID="btnGrabar" runat="server" Text="Grabar" OnClick="btnGrabar_Click" CssClass="btnPrin" />
                        <cc1:ConfirmButtonExtender ID="btnGrabar_ConfirmButtonExtender" runat="server" TargetControlID="btnGrabar" ConfirmText="¿Esta seguro de guardar/modificar el registro?"> 
                        </cc1:ConfirmButtonExtender>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="4">&nbsp;</td>
                </tr>
                <tr>
                    <td align="center" colspan="4">
                        <asp:GridView ID="gvConcepto" runat="server" BorderColor="#DADADA" OnSelectedIndexChanged="gvConcepto_SelectedIndexChanged" AllowPaging="True" OnPageIndexChanging="gvConcepto_PageIndexChanging" DataKeyNames="IdHisInstancia,IdConcepto">
                            <Columns>
                                <asp:ButtonField ButtonType="Image" CommandName="Select" HeaderText="Elegir" ImageUrl="~/imagenes/16siguiente.png" ShowHeader="True" Text="Button" />
                            </Columns>
                            <HeaderStyle CssClass="cssHeaderImg" />
                            <EmptyDataTemplate>
                                <div align="center" class="CajaDialogoAdvertencia">
                                    <br/>
                                    <img src="../Imagenes/warning.gif" 
                                        alt="No existen registros" />
                                    <br/>
                                    Bandeja de Conceptos Historicos vacia.
                                    <br/>
                                    <br/>
                                </div>
                            </EmptyDataTemplate>
                        </asp:GridView>

                        <asp:HiddenField ID="hdfHisInstancia" runat="server" />

                        <br />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>   
</asp:Content>

