<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmOficinas.aspx.cs" Inherits="Seguridad_wfrmOficinas" StylesheetTheme="Modal" %>

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
                    <asp:Label ID="lblTitulo" runat="server" Font-Bold="True" ForeColor="#CC0000" Font-Size="17px" Text="Oficinas"></asp:Label>
                </td>
                <td align="right">
                    <asp:Button ID="btnInsertar" runat="server" Text="Insertar Oficinas" OnClick="btnInsertar_Click" CssClass="boton150"  />
                </td>
                <td></td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </div>
    <asp:Panel ID="pnlListaOficinas" runat="server">
        <div>
            <table align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td align="center">
                        <asp:Label ID="Label2" runat="server" Text="Oficinas :"></asp:Label>&nbsp;
                        <asp:DropDownList ID="ddlOficinaPrincipal" runat="server" OnSelectedIndexChanged="ddlIdOficinaPrincipal_SelectedIndexChanged" AppendDataBoundItems="true" AutoPostBack="True">
                                        <asp:ListItem Value="0">Seleccione...</asp:ListItem>
                        </asp:DropDownList>
                    </td>

                </tr>
                <tr>
                    <td align="center">


                        &nbsp;</td>
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
                            EnableTheming="True" 
                           
                            OnPageIndexChanging="gvDatos_PageIndexChanging" 
                            OnRowCommand="gvDatos_RowCommand" 
                            OnRowDataBound="gvDatos_RowDataBound" 
                            PageSize="15" >
                            <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                            <Columns>
                                <asp:BoundField DataField="RowNumber" HeaderText="Nro" />
                                <asp:BoundField DataField="IdOficina" HeaderText="IdOficina" Visible="false" />
                                <asp:BoundField DataField="Oficina" HeaderText="Oficina">
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
                                        <asp:ImageButton ID="imgEditar" runat="server" CausesValidation="false" CommandArgument='<%#Eval("IdOficina") %>' CommandName="cmdEditar" ImageUrl="~/imagenes/16modificar.png" />
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
  
    <asp:Panel ID="pnlRegistraOficinas" runat="server" CssClass="panelprincipal"><%-- Style="display: none;">--%>
                    <div align="center">
                        
                        <br />
                        <table style="width:900px;">
                           
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:Label ID="Label1" runat="server" Text="Oficinas" 
                            CssClass="etiqueta20"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right"  Width="200px" class="auto-style5">
                                    <asp:Label ID="Label12" runat="server" CssClass="etiqueta10" style="text-align: left" Text="Descripción Oficina :"></asp:Label>
                                </td>
                                <td align="left" class="auto-style5">
                                    <asp:TextBox ID="txtOficinas" runat="server" CssClass="texto10" MaxLength="50" Width="200px" autofocus="autofocus" ></asp:TextBox>                                    
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" FilterType="LowercaseLetters,UppercaseLetters,Numbers,Custom"  TargetControlID="txtOficinas" ValidChars=" "/>
                                    <asp:TextBox ID="txtIdOficinas" runat="server" CssClass="texto10" MaxLength="100" Width="25px" ReadOnly="True" Visible="False"></asp:TextBox>

                                    <asp:RequiredFieldValidator ID="rfvDescripcionOficinas" runat="server" ControlToValidate="txtOficinas" ErrorMessage="Ingrese la Descripcion del Oficinas" SetFocusOnError="True">*</asp:RequiredFieldValidator>

                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label13" runat="server" CssClass="etiqueta10" style="text-align: left" Text="Oficina Superior:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlOficinas" runat="server"  Width="200px"  AppendDataBoundItems="true" OnSelectedIndexChanged="ddlOficinas_SelectedIndexChanged" AutoPostBack="True">
                                        <asp:ListItem Value="0">Seleccione...</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label18" runat="server" CssClass="etiqueta10" style="text-align: left" Text="Codigo:"></asp:Label>
                                </td>
                                <td align="left">                                 
                                    &nbsp;<asp:TextBox ID="txtCodigo" runat="server" autofocus="autofocus" CssClass="texto10" MaxLength="100" Width="200px" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>                               
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="LowercaseLetters,UppercaseLetters,Numbers"  TargetControlID="txtCodigo" />
                                    <asp:RequiredFieldValidator ID="rfvCodigo" runat="server" ControlToValidate="txtCodigo" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                                    <asp:TextBox ID="txtIdDepartamento" runat="server" Enabled="False" Visible="false" ></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label19" runat="server" CssClass="etiqueta10" style="text-align: left" Text="Nivel:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtNivel" runat="server" autofocus="autofocus" CssClass="texto10" MaxLength="100" Width="200px"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server"
                                        TargetControlID="txtNivel"
                                         Mask="9"
                                         MessageValidatorTip="true"
                                         OnFocusCssClass="MaskedEditFocus"
                                         OnInvalidCssClass="MaskedEditError"
                                         MaskType="Number"
                                         InputDirection="RightToLeft"                                                                                  
                                         ErrorTooltipEnabled="True" />
                                     <cc1:MaskedEditValidator ID="MaskedEditValidator2" runat="server"
                                         ControlExtender="MaskedEditExtender2"
                                         ControlToValidate="txtNivel"
                                         IsValidEmpty="False"                                                                                 
                                         Display="Dynamic"                                         
                                        EmptyValueBlurredText="*"
                                         InvalidValueBlurredMessage="*"
                                         MaximumValueBlurredMessage="*"
                                        MinimumValueBlurredText="*"
                                         ValidationGroup="MKE" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label20" runat="server" CssClass="etiqueta10" style="text-align: left" Text="Direccion:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtDireccion" runat="server" autofocus="autofocus" CssClass="texto10" MaxLength="100" Width="200px"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="LowercaseLetters,UppercaseLetters,Numbers,Custom"  TargetControlID="txtDireccion" ValidChars=" "/>
                                    <asp:RequiredFieldValidator ID="rfvDireccion" runat="server" ControlToValidate="txtDireccion" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label15" runat="server" CssClass="etiqueta10" style="text-align: left" Text="Teléfono :"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtTelefono" runat="server" Width="200px" MaxLength="100"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" FilterType="Numbers,Custom"  TargetControlID="txtTelefono" ValidChars="()-"/>
                              
                                    <asp:RequiredFieldValidator ID="rfvTelefono" runat="server" ControlToValidate="txtTelefono" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                              
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label16" runat="server" CssClass="etiqueta10" style="text-align: left" Text="Localidad:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlIdLocalidad" runat="server">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlIdLocalidad" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>   
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label21" runat="server" CssClass="etiqueta10" style="text-align: left" Text="Flag Imprime CC:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:CheckBox ID="chbFlagCC" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label17" runat="server" CssClass="etiqueta10" style="text-align: left" Text="Tipo Oficina :"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:RadioButtonList ID="rblIdTipoOficina" runat="server">
                                        <asp:ListItem Value="34" >Oficina Central</asp:ListItem>
                                        <asp:ListItem Value="35">Administrador Depart</asp:ListItem>
                                        <asp:ListItem Value="36">Agencia Regional</asp:ListItem>

                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:CheckBox ID="chbIdEstado" runat="server" Checked="True" Text="Activo" />
                                </td>
                            </tr>
                        </table>
                        <br />
                        <asp:Button ID="btnActualizar" runat="server" CssClass="boton150"   Text="Actualizar" OnClick="btnActualizar_Click"  />
                        <asp:Button ID="btnAdicionar" runat="server" CssClass="boton150"   Text="Adicionar" OnClick="btnAdicionar_Click" />
                        <asp:Button ID="Button1" runat="server" EnableTheming="True" Text="Cancelar" CssClass="boton150" onclick="btnCancelar_Click" CausesValidation="false" />
                    </div>  
        <cc1:ModalPopupExtender ID="pnlRegistraOficinas_ModalPopupExtender" runat="server" 
Enabled="True" 
TargetControlID="lblTitulo" 
CancelControlID="btnCancelar" 
PopupControlID="pnlRegistraOficinas" 
BackgroundCssClass="modalBackground"> 
</cc1:ModalPopupExtender>               
      
    </asp:Panel>
    
      


</asp:Content>

