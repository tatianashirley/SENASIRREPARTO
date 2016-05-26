<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmTransaccion.aspx.cs" Inherits="Seguridad_wfrmTransaccion" StylesheetTheme="Modal" %>

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
                    <asp:Label ID="lblTitulo" runat="server" Font-Bold="True" ForeColor="#CC0000" Font-Size="17px" Text="Transacciones"></asp:Label>
                </td>
                <td align="right">
                    <asp:Button ID="btnInsertar" runat="server" Text="Insertar" OnClick="btnInsertar_Click" CssClass="boton150"  />
                </td>
                <td></td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </div>
    <asp:Panel ID="pnlListaTransaccion" runat="server">
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
                        &nbsp;Procedimiento :
                        <asp:DropDownList ID="ddlIdProcedimientoBusqueda" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlIdProcedimientoBusqueda_SelectedIndexChanged" Width="200px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="center">&nbsp;</td>
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
                            DataKeyNames="IdTransaccion" 
                            
                            OnPageIndexChanging="gvDatos_PageIndexChanging" 
                            OnRowCommand="gvDatos_RowCommand" 
                            PageSize="15" 
                            >
                            <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                            <Columns>
                                <asp:BoundField DataField="RowNumber" HeaderText="Nro" />
                                <asp:BoundField DataField="IdTransaccion" HeaderText="Transaccion" Visible="true" />
                                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion Transaccion">
                                <HeaderStyle Width="240px" />
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="IdProcedimiento" HeaderText="Procedimiento" Visible="true">
                                <HeaderStyle Width="40px" />
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FlagLog" HeaderText="FlagLog" Visible="true">
                                <HeaderStyle Width="40px" />
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="OperacionTrn" HeaderText="OperacionTrn" Visible="true">
                                <HeaderStyle Width="40px" />
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SegsTimeout" HeaderText="SegsTimeout" Visible="true">
                                <HeaderStyle Width="40px" />
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
                                        <asp:ImageButton ID="imgEditar" runat="server" CausesValidation="false" CommandArgument='<%#Eval("IdTransaccion") %>' CommandName="cmdEditar" ImageUrl="~/imagenes/16modificar.png" />
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
    <asp:Panel ID="pnlRegistraTransaccion" runat="server" CssClass="panelprincipal"><%-- Style="display: none;">--%>
                    <div align="center">
                        
                        <br />
                        <table style="width:900;">
                           
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:Label ID="Label1" runat="server" Text="Nueva Transaccion" 
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
                                    <asp:Label ID="Label13" runat="server" CssClass="etiqueta10" style="text-align: left" Text="Modulo:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlIdModuloRegistrar" runat="server"  Width="200px" AutoPostBack="True" OnSelectedIndexChanged="ddlIdModuloRegistrar_SelectedIndexChanged"  AppendDataBoundItems="true">
                                        <asp:ListItem Value="0">Seleccione...</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label18" runat="server" CssClass="etiqueta10" style="text-align: left" Text="Procedimiento:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlIdProcedimiento" runat="server" Width="200px" AppendDataBoundItems="true" AutoPostBack="True" OnSelectedIndexChanged="ddlIdProcedimiento_SelectedIndexChanged">
                                        <asp:ListItem >Seleccione...</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblNroTransaccion" runat="server" CssClass="etiqueta10" style="text-align: left" Text="Nro Transaccion:" Visible="false"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtNroTransaccion" runat="server" CssClass="texto10" MaxLength="100" Width="300px" Visible="false"  ReadOnly="true"></asp:TextBox>                                    
                                    <asp:RequiredFieldValidator ID="rfvNroTransaccion" runat="server" ControlToValidate="txtNroTransaccion" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label19" runat="server" CssClass="etiqueta10" style="text-align: left" Text="Flag Log:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:CheckBox ID="cbFlag" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label12" runat="server" CssClass="etiqueta10" style="text-align: left" Text="Descripcion de Transaccion :"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtDescripcionTransaccion" runat="server" CssClass="texto10" MaxLength="100" Width="300px"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" FilterType="LowercaseLetters,UppercaseLetters,Numbers,Custom"  TargetControlID="txtDescripcionTransaccion" ValidChars=" "/>
                                    &nbsp;<asp:TextBox ID="txtIdTransaccion" runat="server" CssClass="texto10" MaxLength="100" ReadOnly="True" Visible="False" Width="50px"></asp:TextBox>
                                    
                                    <asp:RequiredFieldValidator ID="rfvDescripcionTranscripcion" runat="server" ControlToValidate="txtDescripcionTransaccion" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                                    
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label15" runat="server" CssClass="etiqueta10" style="text-align: left" Text="Operacion Trn :"></asp:Label>
                                </td>
                                <td align="left">                                
                                    <asp:TextBox ID="txtOperacion" runat="server" CssClass="texto10" MaxLength="1" Width="300px" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="LowercaseLetters,UppercaseLetters"  TargetControlID="txtOperacion" />
                                    <asp:RequiredFieldValidator ID="rfvOperacion" runat="server" ControlToValidate="txtOperacion" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label16" runat="server" CssClass="etiqueta10" style="text-align: left" Text="Segs Timeout :"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtSegsTimeout" runat="server" CssClass="texto10" MaxLength="10" Width="300px"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtSegsTimeout_FilteredTextBoxExtender" runat="server" FilterType="Numbers" TargetControlID="txtSegsTimeout" >
                                    </cc1:FilteredTextBoxExtender>
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
                        <asp:Button ID="btnAdicionar" runat="server" CssClass="boton150"   Text="Adicionar" OnClick="btnAdicionar_Click" />
                        <asp:Button ID="Button1" runat="server" EnableTheming="True" Text="Cancelar" CssClass="boton150" onclick="btnCancelar_Click" CausesValidation="false"/>
                    </div>   
        <cc1:ModalPopupExtender ID="pnlRegistra_ModalPopupExtender" runat="server" 
Enabled="True" 
TargetControlID="lblTitulo" 
PopupControlID="pnlRegistraTransaccion" 
BackgroundCssClass="modalBackground"> 
</cc1:ModalPopupExtender>
                       
      
    </asp:Panel>
        




</asp:Content>

