<%@ page title="" language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" CodeFile="wfrmRol.aspx.cs" inherits="Seguridad_wfrmRol" stylesheettheme="Modal" theme="Modal" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">    
    <script type="text/javascript" language="javascript">
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

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="FondoAplicacion">
        <table width="100%" border="0" cellpadding="false" cellspacing="false">
            <tr>
                <td>
                    <asp:Label ID="lblTituloSistema" runat="server" Font-Bold="True" ForeColor="Navy" Text="MODULO DE SEGURIDAD"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblTitulo" runat="server" Font-Bold="True" ForeColor="#CC0000" Font-Size="17px" Text="Lista de Roles"></asp:Label>
                </td>
                <td align="right">
                    <asp:Button ID="btnInsertar" runat="server" Text="Insertar Rol" OnClick="btnInsertar_Click" CssClass="boton150"  />
                </td>
                <td></td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </div>
    <asp:Panel ID="pnlListaRol" runat="server">
        <div>
            <table align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td align="center">&nbsp;</td>

                </tr>
                <tr>
                    <td align="center">Modulo:
                        <asp:DropDownList ID="ddlIdModulo" runat="server" AppendDataBoundItems="true" AutoPostBack="True" OnSelectedIndexChanged="ddlIdModulo_SelectedIndexChanged">
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
                            AutoGenerateColumns="false"
                            Font-Names="Arial" 
                            Font-Size="9pt" 
                            CssClass="mGrid"
                            PagerStyle-CssClass="pgr"
                            AlternatingRowStyle-CssClass="alt"
                            GridLines="None" 
                           
                            DataKeyNames="RowNumber,IdRol,DescripcionModulo,DescripcionRol,IdModulo,IdEstado,Estado,DetalleRol" 
                            EnableTheming="True" 
                           
                            OnPageIndexChanging="gvDatos_PageIndexChanging" 
                            OnRowCommand="gvDatos_RowCommand" 
                            OnRowDataBound="gvDatos_RowDataBound" PageSize="15" SkinID="GridView">
                            <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                            <Columns>
                                <asp:BoundField DataField="RowNumber" HeaderText="Nro" />
                                <asp:BoundField DataField="IdRol" HeaderText="IdRol" Visible="true" />
                                <asp:BoundField DataField="DescripcionModulo" HeaderText="Modulo">
                                <HeaderStyle Width="240px" />
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DescripcionRol" HeaderText="Rol" Visible="true">
                                <HeaderStyle Width="240px" />
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>                                

                                <asp:BoundField DataField="DetalleRol" HeaderText="Descripcion" Visible="true">
                                <HeaderStyle Width="240px" />
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>

                                <asp:BoundField DataField="IdEstado" HeaderText="IdEstado" Visible="true" />
                                <asp:BoundField DataField="Estado" HeaderText="Estado">
                                <HeaderStyle Width="40px" />
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Editar">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgEditar" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdEditar" ImageUrl="~/imagenes/16modificar.png" />
                                    </ItemTemplate>
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
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlRegistraRol" runat="server" CssClass="panelprincipal"><%-- Style="display: none;">--%>
                    <div align="center">
                        
                        <br />
                        <table style="width:900;">
                           
                            <tr>
                                <td align="center" colspan="2" class="auto-style6">
                                    <asp:Label ID="Label1" runat="server" Text="Rol" 
                            CssClass="etiqueta20"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style7"  >
                                    <asp:Label ID="Label12" runat="server" CssClass="etiqueta10" style="text-align: left" Text="Rol :"></asp:Label>
                                </td>
                                <td align="left" class="auto-style7">
                                    <asp:TextBox ID="txtRol" runat="server" CssClass="texto10" MaxLength="100" Width="200px" autofocus="autofocus"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" FilterType="LowercaseLetters,UppercaseLetters,Numbers,Custom"  TargetControlID="txtRol" ValidChars=" áéíóúÁÉÍÓÚ"/>
                                    <asp:RequiredFieldValidator ID="rfvRol" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtRol">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style7">
                                    <asp:Label ID="Label19" runat="server" CssClass="etiqueta10" style="text-align: left" Text="Descripción Rol :"></asp:Label>
                                </td>
                                <td align="left" class="auto-style7">
                                    <asp:TextBox ID="txtDetalleRol" runat="server" Width="400px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style5">
                                    <asp:Label ID="Label13" runat="server" CssClass="etiqueta10" style="text-align: left" Text="Modulo:"></asp:Label>
                                </td>
                                <td align="left" class="auto-style5">
                                    <asp:DropDownList ID="ddlModulo" runat="server"  Width="200px"  AppendDataBoundItems="true"  >
                                        <asp:ListItem Value="0">Seleccione...</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label18" runat="server" CssClass="etiqueta10" style="text-align: left" Text="Menu Superior:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlMenuSuperior" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMenuSuperior_SelectedIndexChanged" Width="200px"  AppendDataBoundItems="true">
                                        <asp:ListItem Value="0">Seleccione...</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            
                            <tr>
                                <td align="right" colspan="2">
                                      <asp:GridView ID="gvDatos2" runat="server" 
                                          AllowPaging="false"
                                            AutoGenerateColumns="False"                         
                                            EnableTheming="True" 
                                            Font-Names="Arial" 
                                            Font-Size="9pt" 
                                            CssClass="mGrid"
                                            PagerStyle-CssClass="pgr"
                                            AlternatingRowStyle-CssClass="alt"
                                            GridLines="None"
                                          >
                            <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                            <Columns>
                                <%--<asp:BoundField DataField="RowNumber" HeaderText="Nro" />--%>
                                <asp:TemplateField ControlStyle-Height="16"  ItemStyle-Width="5px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                <asp:CheckBox ID="chkTodos" runat="server" onclick = "checkAll(this);"  />
                                            </HeaderTemplate>    
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkTransaccion" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                <asp:BoundField DataField="IdMenu" HeaderText="IdMenu" Visible="false" />
                                <asp:BoundField DataField="IdTransaccion" HeaderText="IdTransaccion" Visible="true" />
                                <asp:BoundField DataField="MenuSuperior" HeaderText="Menu Superior">
                                    <HeaderStyle Width="240px" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Menu" HeaderText="Menu" Visible="true">
                                    <HeaderStyle Width="240px" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="URL" HeaderText="URL" Visible="true">
                                    <HeaderStyle Width="240px" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>                            
                                <asp:BoundField DataField="IdEstado" HeaderText="Estado" Visible="true">
                                    <HeaderStyle Width="40px" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>                                
                            </Columns>
                        </asp:GridView>
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
                                        <asp:ListItem Value="33">Suspendido</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <asp:Button ID="btnAdicionar" runat="server" CssClass="boton150" OnClick="btnAdicionar_Click" Text="Adicionar" />
                        <asp:Button ID="Button1" runat="server" EnableTheming="True" Text="Cancelar" CssClass="boton150" onclick="btnCancelar_Click" CausesValidation="false"/>
                    </div>                
      
    </asp:Panel>
    <cc1:ModalPopupExtender ID="pnlRegistra_ModalPopupExtender" runat="server" 
Enabled="True" 
TargetControlID="lblTitulo" 
PopupControlID="pnlRegistraRol" 
BackgroundCssClass="modalBackground"> 
</cc1:ModalPopupExtender>  
     <asp:Panel ID="pnlActualizaRol" runat="server" CssClass="panelprincipal"><%-- Style="display: none;">--%>
                    <div align="center">
                        
                        <br />
                        <table style="width:900;">
                           
                            <tr>
                                <td align="center" colspan="2" class="auto-style6">
                                    <asp:Label ID="Label2" runat="server" Text="Actualiza Rol" 
                            CssClass="etiqueta20"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right"  Width="200px">
                                    <asp:Label ID="Label3" runat="server" CssClass="etiqueta10" style="text-align: left" Text="Rol :"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtRolAct" runat="server" CssClass="texto10" MaxLength="100" Width="200px" autofocus="autofocus"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Numbers, Custom, LowercaseLetters, UppercaseLetters" TargetControlID="txtRolAct" ValidChars=" áéíóúÁÉÍÓÚ">
                                    </cc1:FilteredTextBoxExtender>
                                    <asp:TextBox ID="txtIdRolAct" runat="server" ReadOnly="True" Width="25px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvDescripcionRolAct" runat="server" ErrorMessage="Campo Requerido" ControlToValidate="txtIdRolAct">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="200px">
                                    <asp:Label ID="Label20" runat="server" CssClass="etiqueta10" style="text-align: left" Text="Descripción Rol :"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtDetalleRolAct" runat="server" Width="400px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style5">
                                    <asp:Label ID="Label4" runat="server" CssClass="etiqueta10" style="text-align: left" Text="Modulo:"></asp:Label>
                                </td>
                                <td align="left" class="auto-style5">
                                    <asp:DropDownList ID="ddlIdModuloAct" runat="server"  Width="200px"    >
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label5" runat="server" CssClass="etiqueta10" style="text-align: left" Text="Menu Superior:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlIdMenuSuperiorAct" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMenuSuperiorAct_SelectedIndexChanged" Width="200px"  AppendDataBoundItems="true">
                                        <%--<asp:ListItem Value="0">Seleccione...</asp:ListItem>--%>
                                        
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            
                            <tr>
                                <td align="right" colspan="2">
                                      <asp:GridView ID="gvListaRolesAct" runat="server" AutoGenerateColumns="False"   AllowPaging="True"  
                                          OnPageIndexChanging="gvListaRolesAct_PageIndexChanging"  
                                          PageSize="10" SkinID="GridView" 
                                          EnableTheming="True" 
                                          Font-Names="Arial" 
                        Font-Size="9pt" 
                        CssClass="mGrid"
                        PagerStyle-CssClass="pgr"
                        AlternatingRowStyle-CssClass="alt"
                        GridLines="None"
                                          OnSelectedIndexChanged="gvListaRolesAct_SelectedIndexChanged"
                                          DataKeyNames="IdTransaccion,IdModulo"
                                          OnRowCommand="gvListaRolesAct_RowCommand"
                                          >
                            <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                            <Columns>
                                <asp:TemplateField ControlStyle-Height="16"  ItemStyle-Width="5px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                <asp:CheckBox ID="chkTodos" runat="server" onclick = "checkAll(this);"  />
                                            </HeaderTemplate>    
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkTransaccion" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                <%--<asp:BoundField DataField="RowNumber" HeaderText="Nro" />--%>
                            
                                <asp:CheckBoxField DataField="RolSel" HeaderText="Activo" ReadOnly="True"    />
                                <asp:BoundField DataField="IdMenu" HeaderText="IdMenu" Visible="false" />
                                <asp:BoundField DataField="IdTransaccion" HeaderText="IdTransaccion" Visible="true" />
                                <asp:BoundField DataField="MenuSuperior" HeaderText="Menu Superior">
                                    <HeaderStyle Width="240px" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Menu" HeaderText="Menu" Visible="true">
                                    <HeaderStyle Width="240px" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="URL" HeaderText="URL" Visible="true">
                                    <HeaderStyle Width="240px" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>                            
                                <asp:BoundField DataField="IdEstado" HeaderText="Estado" Visible="true">
                                    <HeaderStyle Width="40px" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Eliminar">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgEliminar" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdEliminar" ImageUrl="~/imagenes/16eliminar.png"  OnClientClick="return confirm('Esta seguro de eliminar el registro?');" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                  
                                <%-- <asp:CommandField ButtonType="Image" HeaderText="Eliminar" ItemStyle-Width="10%" SelectImageUrl="../Imagenes/16eliminar.png" ShowSelectButton="True">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:CommandField>          --%>                   
                            </Columns>
                        </asp:GridView>
                                </td>
                            </tr>
                            
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label6" runat="server" CssClass="etiqueta10" style="text-align: left" Text="Estado :"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:RadioButtonList ID="rblIdEstadoAct" runat="server" >
                                        <asp:ListItem Value="31" Selected="True">Activo</asp:ListItem>
                                        <asp:ListItem Value="32">Inactivo</asp:ListItem>
                                        <asp:ListItem Value="33">Suspendido</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <asp:Button ID="btnActualizar" runat="server" CssClass="boton150"   Text="Actualizar"   OnClick="btnActualizar_Click" Visible="false" />
                        <asp:Button ID="btnCancelarAct" runat="server" EnableTheming="True" Text="Cancelar" CssClass="boton150" onclick="btnCancelar_Click"  CausesValidation="false"/>
                    </div> 
         <cc1:ModalPopupExtender ID="pnlActualiza_ModalPopupExtender" runat="server" 
Enabled="True" 
TargetControlID="lblTitulo" 

PopupControlID="pnlActualizaRol" 
BackgroundCssClass="modalBackground"> 
</cc1:ModalPopupExtender>                   
      
    </asp:Panel>
    


</asp:Content>

