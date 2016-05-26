<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmBusquedaTitDH.aspx.cs" Inherits="Novedades_wfrmBusquedaNovedades" StylesheetTheme="Modal" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .cssHeaderImg {
            background-image: url(../Imagenes/Menu4.png);
        }

        .auto-style4 {
            width: 280px;
        }
    </style>

    <script type="text/javascript" language="javascript">
        function ModalPopup() {
            var vpRND = Math.random() * 20;
            showModalDialog('\Auxiliar\\ModRol.aspx?rn=' + vpRND, '', 'dialogWidth=640px; dialogHeight=320px; center=yes; scrollbars=no');
        }
        function checkAll(objRef) {
            var GridView = objRef.parentNode.parentNode.parentNode;
            var inputList = GridView.getElementsByTagName("input");
            for (var i = 0; i < inputList.length; i++) {
                //Get the Cell To find out ColumnIndex
                var row = inputList[i].parentNode.parentNode;
                if (inputList[i].type == "checkbox" && objRef != inputList[i]) {
                    if (objRef.checked) {
                        inputList[i].checked = true;
                    }
                    else {
                        inputList[i].checked = false;
                    }
                }
            }
        }
    </script>

</asp:Content>
<%--TODA LA TABLA--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%;" class="panelceleste">
        <tr>
            <td align="center" colspan="3">
                <asp:ImageButton ID="imgAux" runat="server" ImageUrl="~/Imagenes/w.png" />
                <asp:Label ID="lblTituloAUX" runat="server"
                    Text="Búsqueda de Beneficiarios - Novedades" CssClass="etiqueta20"></asp:Label>
                <asp:Label ID="lblCodigo" runat="server" Font-Size="Small" Text="1"
                    Visible="False"></asp:Label>
                <asp:Label ID="lblCodUsuario" runat="server" Font-Size="Small" Text="1"
                    Visible="False"></asp:Label>
                <asp:Label ID="lblRol" runat="server" Font-Size="Small"
                    Style="text-align: left" Text="0" Visible="False"></asp:Label>
            </td>
        </tr>
        <%--TODA LA TABLA--%>
        <tr>
            <td colspan="3">
                <table style="width: 100%;">
                    <tr>
                        <td align="left" style="width:20%">
                            <asp:Label ID="Label2" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="CUA: "></asp:Label>
                            <asp:TextBox ID="TextCua" runat="server" CssClass="texto10" MaxLength="50" Style="text-align:left" Width="100px"></asp:TextBox>
                            <asp:regularExpressionValidator ID="RegularExpressionValidator3" validationExpression="[0-9]*" controlToValidate="TextCua" errorMessage="Introducir solo números" runat="server"/>
                        </td>
                        <td align="left" style="width:40%">
                            <asp:Label ID="Label1" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="Paterno: "></asp:Label>
                            <asp:TextBox ID="TextPaterno" runat="server" CssClass="texto10" MaxLength="50" Style="text-align:left" Width="200px"></asp:TextBox>
                        </td>
                        <td align="left" style="width:60%">
                            <asp:Label ID="Label6" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="1er Nombre: "></asp:Label>
                            <asp:TextBox ID="TextNom1" runat="server" CssClass="texto10" MaxLength="50" Style="text-align:left" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 40%">
                            <asp:Label ID="Label7" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="Num ID: "></asp:Label>
                            <asp:TextBox ID="TextCI" runat="server" CssClass="texto10" MaxLength="50" Style="text-align:left" Width="200px"></asp:TextBox>
                        </td>
                        <td align="left" style="width: 40%">
                            <asp:Label ID="Label8" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="Materno: "></asp:Label>
                            <asp:TextBox ID="TextMaterno" runat="server" CssClass="texto10" MaxLength="50" Style="text-align:left" Width="200px"></asp:TextBox>
                        </td>
                        <td align="left" style="width: 40%">
                            <asp:Label ID="Label9" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="2do Nombre: "></asp:Label>
                            <asp:TextBox ID="TextNom2" runat="server" CssClass="texto10" MaxLength="50" Style="text-align:left" Width="200px"></asp:TextBox>
                        </td>                     

                        <td align="right">
                            <asp:ImageButton runat="server" ID="imgbtnBuscar" ImageUrl="~/Imagenes/32Buscar.png" OnClick="imgbtnBuscar_Click" EnableViewState="False" />
                            <asp:Label ID="Label3" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="Buscar"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="width:10%">
                            <asp:Label ID="Label4" runat="server" CssClass="etiqueta10" Style="text-align:left" Text="Tipo Certificado: "></asp:Label>
                            <asp:DropDownList ID="ddlTipoCertificado" runat="server" Style="text-align:right"
                                AutoPostBack="True" Width="100px" OnSelectedIndexChanged="ddlTipoCertificado_SelectedIndexChanged">
                                <asp:ListItem Selected="True" Value="T">Titular</asp:ListItem>
                                <asp:ListItem Value="B">Beneficiario</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td align="right">
                            <asp:ImageButton runat="server" ID="ImageButton1" ImageUrl="~/Imagenes/32Documento.png" OnClick="imgbtnLimpiar_Click" />
                            <asp:Label ID="Label5" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="Limpiar"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>

            <td align="center" valign="top" style="width: 90%">
                <asp:Label ID="lblObs" runat="server" CssClass="text_obs"></asp:Label>
            </td>
            <td align="right" valign="top" style="width: 10%">
                <asp:Panel ID="pnlNew" runat="server" Height="20px">
                    <table>
                        <tr>
                            <td style="width: 100%">
                                <asp:ImageButton ID="imgNuevo" runat="server" ImageUrl="~/Imagenes/nuevo.gif"
                                   TabIndex="10" Visible="False" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <%--TODA LA TABLA--%>
<tr>
            <td colspan="3" width="100%">
                <asp:Panel ID="pnlGV" runat="server" HorizontalAlign="Center" Width="100%" 
                    CssClass="panelprincipal">
                    <table style="width:100%;">
                        <tr>
                            <td>
                                <asp:GridView ID="gvNovedades" runat="server" EnableTheming="True" AllowPaging="True" PageSize="15" 
                                    HorizontalAlign="Center" OnPageIndexChanging="gvNovedades_PageIndexChanging"
                                    SkinID="GridView" Width="100%" CssClass="etiqueta8Blue" 
                                    OnSelectedIndexChanged="gvNovedades_SelectedIndexChanged" DataKeyNames="Tipo,Certificado,IdTipoCertificado,NUP">
                                    <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                                    <Columns>
                                        <asp:BoundField DataField="Tipo" HeaderText="Tipo" ItemStyle-Width="20%"> <ItemStyle Width="4%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="fila" HeaderText="Fila" ItemStyle-Width="20%"> <ItemStyle Width="2%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="NUA" HeaderText="CUA" ItemStyle-Width="40%"><ItemStyle Width="10%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CI" HeaderText="Num. Doc." ItemStyle-Width="20%"><ItemStyle Width="10%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="IdTipoDocumento" HeaderText="Tipo" ItemStyle-Width="20%"><ItemStyle Width="10%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Paterno" HeaderText="Paterno" ItemStyle-Width="20%"> <ItemStyle Width="20%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Materno" HeaderText="Materno" ItemStyle-Width="20%"> <ItemStyle Width="20%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="PrimerNombre" HeaderText="1er Nombre" ItemStyle-Width="20%"> <ItemStyle Width="20%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="SegundoNombre" HeaderText="2do Nombre" ItemStyle-Width="20%"> <ItemStyle Width="20%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="FechaNac" HeaderText="Nacimiento" ItemStyle-Width="20%"> <ItemStyle Width="20%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Certificado" HeaderText="Nro Certi" ItemStyle-Width="20%"> <ItemStyle Width="25%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="TipoCertificado" HeaderText="Tipo Certi" ItemStyle-Width="20%"> <ItemStyle Width="20%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="TipoBeneficio" HeaderText="Tipo Benefic" ItemStyle-Width="20%"> <ItemStyle Width="20%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="IdTipoCertificado" HeaderText="IdTipoCertificado" ItemStyle-Width="20%" Visible="False"> <ItemStyle Width="20%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="NUP" HeaderText="NUP" ItemStyle-Width="20%" Visible="False"> <ItemStyle Width="20%" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Crear" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:ImageButton Id="imgSeleccion" runat="server" CommandName="Select" ImageUrl="~/Imagenes/16siguiente.png" />
                                            </ItemTemplate>

                                            <ItemStyle HorizontalAlign="Center" />

                                        </asp:TemplateField>
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
                    </table>
                </asp:Panel>
            </td>
        </tr>
        
    </table>
</asp:Content>

