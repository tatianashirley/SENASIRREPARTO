<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmArea.aspx.cs" Inherits="Seguridad_wfrmArea" StylesheetTheme="Modal" %>

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
        .auto-style8 {
        width: 359px;
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
                    <asp:Label ID="lblTitulo" runat="server" Font-Bold="True" ForeColor="#CC0000" Font-Size="17px" Text="Area"></asp:Label>
                </td>
                <td align="right">
                    <asp:Button ID="btnInsertar" runat="server" Text="Insertar Area" OnClick="btnInsertar_Click" CssClass="boton150"  />
                </td>
                <td></td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </div>
    <asp:Panel ID="pnlListaArea" runat="server">
        <div>
            <table align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td align="center" colspan="2">&nbsp;</td>

                </tr>
                <tr>
                    <td align="right" width="50%">


                        <asp:Label ID="Label18" runat="server" Text="Oficina:"></asp:Label>
                        &nbsp;
                    </td>
                    <td align="left" class="auto-style6">
                        <asp:DropDownList ID="ddlIdOficina" runat="server" AppendDataBoundItems="true" AutoPostBack="True" OnSelectedIndexChanged="ddlIdOficina_SelectedIndexChanged">
<asp:ListItem Value="0">Seleccione...</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="auto-style5">&nbsp;</td>
                    <td align="left" class="auto-style5">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center" colspan="2">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="gvDatos" runat="server" AllowPaging="True" AutoGenerateColumns="False" BorderColor="#DADADA" BorderStyle="Solid" BorderWidth="1px" CssClass="etiqueta8Blue" EnableTheming="True" Font-Names="Arial" Font-Size="9pt" GridLines="Horizontal" OnPageIndexChanging="gvDatos_PageIndexChanging" OnRowCommand="gvDatos_RowCommand" OnRowDataBound="gvDatos_RowDataBound" PageSize="15" SkinID="GridView">
                            <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                            <Columns>
                                <asp:BoundField DataField="RowNumber" HeaderText="Nro" />
                                <asp:BoundField DataField="IdArea" HeaderText="IdArea" Visible="true" />
                                <asp:BoundField DataField="AreaSuperior" HeaderText="Area Superior">
                                <HeaderStyle Width="240px" />
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Descripcion" HeaderText="Area" Visible="true">
                                <HeaderStyle Width="240px" />
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Responsable" HeaderText="Responsable" Visible="false">
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
                                        <asp:ImageButton ID="imgEditar" runat="server" CausesValidation="false" CommandArgument='<%#Eval("IdArea") %>' CommandName="cmdEditar" ImageUrl="~/imagenes/16modificar.png" />
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
    <asp:Panel ID="pnlRegistraArea" runat="server" CssClass="panelprincipal" Visible="false"><%-- Style="display: none;">--%>
                    <div align="center">
                        
                        <br />
                        <table style="width:900;">
                           
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:Label ID="Label1" runat="server" Text="Area" 
                            CssClass="etiqueta20"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right"  Width="200px">
                                    <asp:Label ID="lblOficina" runat="server" CssClass="etiqueta10" style="text-align: left" Text="Oficina:"></asp:Label>
                                </td>
                                <td align="left" class="auto-style8">
                                    <asp:DropDownList ID="ddlIdOficinaReg" runat="server" AppendDataBoundItems="true" AutoPostBack="True" OnSelectedIndexChanged="ddlIdOficinaReg_SelectedIndexChanged" Width="200px">
                                        <asp:ListItem Value="0">Seleccione...</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlIdOficinaReg" InitialValue="0" ErrorMessage="*" />

                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="200px">
                                    <asp:Label ID="lblAreaSuperior" runat="server" CssClass="etiqueta10" style="text-align: left" Text="Área Superior:"></asp:Label>
                                </td>
                                <td align="left" class="auto-style8">
                                    <asp:DropDownList ID="ddlArea" runat="server" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlArea_SelectedIndexChanged" Width="200px" AutoPostBack="True">
                                        <asp:ListItem Value="0">Seleccione...</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlArea" InitialValue="0" ErrorMessage="*" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="200px">
                                    <asp:Label ID="Label12" runat="server" CssClass="etiqueta10" style="text-align: left" Text="Descripción Área :"></asp:Label>
                                </td>
                                <td align="left" class="auto-style8">
                                    <asp:TextBox ID="txtArea" runat="server" autofocus="autofocus" CssClass="texto10" MaxLength="100" Width="200px"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtArea_FilteredTextBoxExtender" runat="server" FilterType="Numbers, Custom, LowercaseLetters, UppercaseLetters" TargetControlID="txtArea" ValidChars=" áéíóúÁÉÍÓÚ">
                                    </cc1:FilteredTextBoxExtender>
                                    <asp:TextBox ID="txtIdArea" runat="server" CssClass="texto10" MaxLength="100" ReadOnly="True" Visible="False" Width="25px"></asp:TextBox>
                                    <asp:TextBox ID="txtIdOficina" runat="server" Height="16px" Width="26px" ReadOnly="True" Visible="False"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvDescripcionArea" runat="server" ControlToValidate="txtArea" ErrorMessage="Ingrese la Descripcion del Area" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label16" runat="server" CssClass="etiqueta10" style="text-align: left" Text="Responsable :" Visible="false"></asp:Label>
                                </td>
                                <td align="left" class="auto-style8">
                                    <asp:TextBox ID="txtResponsable" runat="server" CssClass="texto10" MaxLength="100" Width="200px" Visible="false"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtResponsable_FilteredTextBoxExtender" runat="server" FilterType="Numbers, Custom, LowercaseLetters, UppercaseLetters" TargetControlID="txtResponsable" ValidChars=" ">
                                    </cc1:FilteredTextBoxExtender>
                                </td>
                            </tr>   
                            <tr>
                                <td align="right">
                                    &nbsp;</td>
                                <td align="left" class="auto-style8">
                                    <asp:CheckBox ID="chbEstado" runat="server" Checked="True"  Text="Activo"/>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <asp:Button ID="btnActualizar" runat="server" CssClass="boton150"   Text="Actualizar" OnClick="btnActualizar_Click" />
                        <asp:Button ID="btnAdicionar" runat="server" CssClass="boton150"   Text="Adicionar" OnClick="btnAdicionar_Click" />
                        <asp:Button ID="Button1" runat="server" EnableTheming="True" Text="Cancelar" CssClass="boton150" onclick="btnCancelar_Click" CausesValidation="false"/>
                    </div>   
         <cc1:ModalPopupExtender ID="pnlRegistraArea_ModalPopupExtender" runat="server"
                    Enabled="True"
                    TargetControlID="lblTitulo"                    
                    PopupControlID="pnlRegistraArea"
                    BackgroundCssClass="modalBackground">
                </cc1:ModalPopupExtender>             
      
    </asp:Panel>
        


</asp:Content>

