<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmUsuarioAsignacion.aspx.cs" Inherits="Seguridad_wfrmUsuarioAsignacion" StylesheetTheme="Modal" %>

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
    <script type="text/javascript" language="javascript">
    function checkDate(sender, args) {
            if (sender._selectedDate < new Date()) {
                alert("¡Usted no puede seleccionar una fecha pasada");
                document.getElementById('<%=txtFechaExpiracion.ClientID %>').value = "";
            }
    }
         </script>
    <style type="text/css">
        .auto-style5 {
            height: 34px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server"> 
     <asp:TextBox ID="TextBox1" runat="server" Visible="false"></asp:TextBox>
            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Imagenes/16calendario.png"  Visible="false"/>
            <cc1:CalendarExtender ID="CalendarExtender3" runat="server" PopupButtonID="ImageButton1" TargetControlID="TextBox1" ></cc1:CalendarExtender>
    <div class="FondoAplicacion">
        <table width="100%" border="0" cellpadding="false" cellspacing="false">
            <tr>
                <td>
                    <asp:Label ID="lblTituloSistema" runat="server" Font-Bold="True" ForeColor="Navy" Text="MODULO DE SEGURIDAD"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblTitulo" runat="server" Font-Bold="True" ForeColor="#CC0000" Font-Size="17px"></asp:Label>
                </td>
                <td align="right">
                    <asp:Button ID="btnVolverBusqueda" runat="server" Text="Buscar Usuario"  CssClass="boton150" OnClick="btnVolverBusqueda_Click" CausesValidation="false" />
                </td>
                <td></td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </div>
      <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0"  OnDemand="true" Width="100%">
    <cc1:TabPanel ID="pnlBusquedaUsuario" runat="server" HeaderText="Busqueda Usuario" OnDemandMode="none"  TabIndex="1">  
        <ContentTemplate>              
        <div >
        <table width="100%" border="0" cellpadding="false" cellspacing="false">
            <tr>
                
                <td  align="right" width="50%" class="auto-style5">
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="Navy" Text="Busqueda de Usuario Interno:"></asp:Label>
                    
                    </td>
                <td align="left" class="auto-style5">
                    <asp:TextBox ID="txtBusquedaUsuario" runat="server" Height="20px" Width="200px" on onkeyup="this.value=this.value.toUpperCase()" MaxLength="250"></asp:TextBox>

                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" FilterType="LowercaseLetters,UppercaseLetters,Numbers,Custom"  TargetControlID="txtBusquedaUsuario" ValidChars="_ñÑ "/>
                    &nbsp;<asp:Button ID="btnBuscarUsuario" runat="server" Text="Buscar" OnClick="btnBuscarUsuario_Click" />
                </td>

             
                
             
            </tr>
            <tr>
                <td align="right" >
                    <asp:Label ID="Label19" runat="server" Font-Bold="True" ForeColor="Navy" Text="Busqueda Login Interno:"></asp:Label>
                   
                </td>
                <td align="left">
                     <asp:TextBox ID="txtBusquedaLogin" runat="server" Height="20px" Width="200px" onkeyup="this.value=this.value.toUpperCase()" MaxLength="50"></asp:TextBox>
                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="LowercaseLetters,UppercaseLetters,Numbers,Custom"  TargetControlID="txtBusquedaLogin" ValidChars="_ñÑ"/>
                    &nbsp;<asp:Button ID="btnBuscarLogin" runat="server" Text="Buscar" OnClick="btnBuscarLogin_Click"/>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="Label20" runat="server" Font-Bold="True" ForeColor="Navy" Text="Busqueda Login Externo:"></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="txtBusquedaLoginExterno" runat="server" Height="20px" Width="200px" onkeyup="this.value=this.value.toUpperCase()" MaxLength="50"></asp:TextBox>
                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="LowercaseLetters,UppercaseLetters,Numbers,Custom"  TargetControlID="txtBusquedaLoginExterno" ValidChars="_ñÑ"/>
                    <asp:Button ID="btnBuscarLoginExterno" runat="server" OnClick="btnBuscarLoginExterno_Click" Text="Buscar" />
                </td>
            </tr>
            </table>
            </div>
            </ContentTemplate>
        </cc1:TabPanel>
    <cc1:TabPanel ID="pnlListaUsuarios" runat="server" HeaderText="Lista Usuarios" TabIndex="2" OnDemandMode="Always">
        <ContentTemplate>
        <div>
            <table width="100%" border="0" cellpadding="false" cellspacing="false">

            <tr>
                <td align="center">
                    &nbsp;</td>
                <td></td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:GridView ID="gvListaUsuarios" 
                        runat="server" 
                        AutoGenerateColumns="False"  
                       Font-Names="Arial" 
Font-Size="9pt" 
CssClass="mGrid"
PagerStyle-CssClass="pgr"
AlternatingRowStyle-CssClass="alt"
GridLines="None"
                        AllowPaging="True"  
                        OnPageIndexChanging="gvListaUsuarios_PageIndexChanging" 
                         PageSize="15" 
                        EnableTheming="True" 
                     
                        OnSelectedIndexChanged="gvListaUsuarios_SelectedIndexChanged">
                            <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                            <Columns>                                
                                <asp:CommandField ButtonType="Image" HeaderText="Sel" SelectImageUrl="~/Imagenes/sig.png" ShowSelectButton="True">
                                                    <ItemStyle HorizontalAlign="Center" Width="10px" />
                                                    </asp:CommandField>
                                <asp:BoundField DataField="IdUsuario" HeaderText="IdUsuario" />
                                <asp:BoundField DataField="Carnet" HeaderText="CI" />
                                <asp:BoundField DataField="NombreCompleto" HeaderText="Nombre Completo">
                                    <HeaderStyle Width="240px" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>                                                
                                <asp:BoundField DataField="CuentaUsuario" HeaderText="Login">
                                    <HeaderStyle Width="40px" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>                                
                                
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
            </ContentTemplate>
        </cc1:TabPanel>     
     <cc1:TabPanel ID="pnlUsuarioModuloRol" runat="server"  HeaderText="Lista Oficina y Roles" OnDemandMode="Always"  TabIndex="3">
         <ContentTemplate>
        <div>
            <table width="100%" border="0" cellpadding="false" cellspacing="false">

            <tr>
                <td align="center" colspan="2">
                    <asp:Label ID="Label1" runat="server" Text="Lista de Oficina asignada al Usuario:"></asp:Label>&nbsp;<asp:Label ID="lblNombreCompleto" runat="server" Text="Label"></asp:Label>
                    &nbsp; Login:
                    <asp:Label ID="lblLogin" runat="server" Text="Label"></asp:Label>
                    <asp:Button ID="btnAsignar" runat="server" Text="Asignar Oficina - Rol"  CssClass="boton150" OnClick="btnAsignar_Click"  Visible="false" Width="200px" CausesValidation="false" />
                
                </td>
            </tr>
                <tr>
                    <td align="center">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <asp:GridView ID="gvUsuarioOficina" runat="server" 
                            AutoGenerateColumns="False" 
                           Font-Names="Arial" 
Font-Size="9pt" 
CssClass="mGrid"
PagerStyle-CssClass="pgr"
AlternatingRowStyle-CssClass="alt"
GridLines="None"
                             DataKeyNames="IdUsuario,IdOficina,IdArea"
                             EnableTheming="True" 
                          
                             OnSelectedIndexChanged="gvUsuarioModuloRol_SelectedIndexChanged" 
                            >
                            <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                            <Columns>
                                <asp:BoundField DataField="RowNumber" HeaderText="No" Visible="true" />
                                <asp:BoundField DataField="IdOficina" HeaderText="IdOficina" Visible="false" />
                                <asp:BoundField DataField="Oficina" HeaderText="Oficina" Visible="true" />
                                <asp:BoundField DataField="IdArea" HeaderText="IdArea" Visible="false" />
                                <asp:BoundField DataField="Area" HeaderText="Area" Visible="true" />
                                <asp:BoundField DataField="IdUsuario" HeaderText="IdUsuario" Visible="false" />
                                <asp:BoundField DataField="CuentaUsuario" HeaderText="CuentaUsuario" Visible="true" />
                             
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
                        <asp:HiddenField ID="hfIdOficina" runat="server" />
                        <asp:HiddenField ID="hfIdArea" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="center">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <asp:Label ID="Label23" runat="server" Text="Lista de Roles Asignados al Usuario:"></asp:Label>
                        &nbsp;<asp:Label ID="lblNombreCompleto0" runat="server" Text="Label"></asp:Label>
                        &nbsp; Login:
                        <asp:Label ID="lblLogin0" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:GridView ID="gvUsuarioModuloRol" 
                        DataKeyNames="Carnet,IdUsuario,IdRol,IdRolUsuario" runat="server" 
                        AutoGenerateColumns="False" 
                       Font-Names="Arial" 
Font-Size="9pt" 
CssClass="mGrid"
PagerStyle-CssClass="pgr"
AlternatingRowStyle-CssClass="alt"
GridLines="None"
                        EnableTheming="True" 
                      
                         OnSelectedIndexChanged="gvUsuarioModuloRol_SelectedIndexChanged"
                        OnRowCommand="gvUsuarioModuloRol_RowCommand"
                        >
                            <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                            <Columns>                                
                                <asp:BoundField DataField="RowNumber" HeaderText="No" Visible="true" />
                                <asp:BoundField DataField="Carnet" HeaderText="CI" Visible="false" />
                                <asp:BoundField DataField="IdUsuario" HeaderText="Codigo Usuario" Visible="false" />
                                <asp:BoundField DataField="IdRol" HeaderText="Codigo Rol" Visible="false" />
                                <asp:BoundField DataField="IdRolUsuario" HeaderText="IdRolUsuario" Visible="false" />
                              <%--  <asp:BoundField DataField="Oficina" HeaderText="Oficina">
                                    <HeaderStyle Width="80px" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField> 
                                <asp:BoundField DataField="Area" HeaderText="Area">
                                    <HeaderStyle Width="80px" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField> --%>
                                <asp:BoundField DataField="DescripcionModulo" HeaderText="Modulo">
                                    <HeaderStyle Width="240px" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>                                                
                                <asp:BoundField DataField="DescripcionRol" HeaderText="Rol" Visible="true">
                                    <HeaderStyle Width="40px" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField> 
                                <asp:BoundField DataField="FechaVigencia" HeaderText="Fecha Vigencia" Visible="true">
                                    <HeaderStyle Width="40px" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField> 
                                <asp:BoundField DataField="FechaExpiracion" HeaderText="Fecha Expiracion" Visible="true">
                                    <HeaderStyle Width="40px" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>                                                                
                                <asp:BoundField DataField="IdEstado" HeaderText="Estado" Visible="true">
                                    <HeaderStyle Width="40px" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField> 
                                <asp:BoundField DataField="Estado" HeaderText="Estado" Visible="true">
                                    <HeaderStyle Width="40px" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField> 
                               <asp:TemplateField HeaderText="Eliminar">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgEliminar" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdEliminar" ImageUrl="~/imagenes/16eliminar.png"  OnClientClick="return confirm('Esta seguro de eliminar el registro?');" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                               <%-- <asp:CommandField ButtonType="Image" HeaderText="Habilita/Desabilita Estado" ItemStyle-Width="10px" SelectImageUrl="../Imagenes/16eliminar.png" ShowSelectButton="True">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    </asp:CommandField>--%>
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
             </ContentTemplate>
        </cc1:TabPanel>
     <cc1:TabPanel ID="pnlAsignaRol" runat="server"  HeaderText="Alta de Oficina y Rol" OnDemandMode="Always" TabIndex="4">        
         <ContentTemplate>
        <div>
            <table width="100%" border="0" cellpadding="false" cellspacing="false">

            <tr>
                <td align="right"  class="auto-style5" width="50%">
                    Oficina:</td>
                <td align="left">
                    <asp:DropDownList ID="ddlIdOficina" runat="server" OnSelectedIndexChanged="ddlIdOficina_SelectedIndexChanged" AutoPostBack="true" CausesValidation="false"  AppendDataBoundItems="true" >
                                        <%--<asp:ListItem Value="0">Seleccione...</asp:ListItem>--%>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="ddlIdOficina" InitialValue="0" ErrorMessage="*" />
                </td>
            </tr>
                <tr>
                    <td align="right" class="auto-style5" width="50%">Area:</td>
                    <td align="left" class="auto-style5">
                        <asp:DropDownList ID="ddlIdArea" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlIdArea_SelectedIndexChanged"  AppendDataBoundItems="true" CausesValidation="false">
                                        <%--<asp:ListItem Value="0">Seleccione...</asp:ListItem>--%>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlIdArea" InitialValue="0" ErrorMessage="*" />
                    </td>
                </tr>
                <tr>
                    <td align="center" class="auto-style5" colspan="2" width="50%">
                        <asp:Label ID="Label24" ForeColor="Red" runat="server" Text="Solo se debe llenar hasta esta parte en caso de ser nueva asignacion de Oficina"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="auto-style5" width="50%">
                        <asp:Label ID="Label3" runat="server" Text="Seleccione Modulo a Asignar:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlModulo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlModulo_SelectedIndexChanged" Width="200px"  AppendDataBoundItems="true" CausesValidation="false">
                                        <asp:ListItem Value="0">Seleccione...</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Label ID="lblCarnet" runat="server" Text="Label" Visible="false" ></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label21" runat="server" Text="Fecha de Expiracion:"></asp:Label>
                    </td>
                    <td align="left"><div>
                        <asp:TextBox ID="txtFechaExpiracion" runat="server"  Enabled="false"></asp:TextBox>
                        <%--<cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" AcceptNegative="Left" DisplayMoney="Left" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtFechaExpiracion" />--%>
                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="cal_Theme1" Enabled="True" Format="dd/MM/yyyy" PopupButtonID="imgcalendario" TargetControlID="txtFechaExpiracion" OnClientDateSelectionChanged="checkDate">
                        </cc1:CalendarExtender>                        
                        <asp:ImageButton ID="imgcalendario" runat="server" CssClass="CajaDialogo" ImageUrl="~/Imagenes/32calendario.png" />     

                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFechaExpiracion"  Format="dd/MM/yyyy" PopupButtonID="imgcalendario" CssClass="cal_Theme1" Enabled="True">  </cc1:CalendarExtender>	
                        
                        
                        </div>
                    </td>
                </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:GridView ID="gvAsignaRol" runat="server" 
                        AutoGenerateColumns="False"   
                        Font-Names="Arial" 
Font-Size="9pt" 
CssClass="mGrid"
PagerStyle-CssClass="pgr"
AlternatingRowStyle-CssClass="alt"
GridLines="None"
                        
                         EnableTheming="True" 
                        
                        >
                            <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                            <Columns>                                
                                <asp:TemplateField ControlStyle-Height="16"  ItemStyle-Width="5px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                <asp:CheckBox ID="chkTodos" runat="server" onclick = "checkAll(this);"  />
                                            </HeaderTemplate>    
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkRol" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                <asp:BoundField DataField="IdRol" HeaderText="Codigo Rol" Visible="true" />
                                <asp:BoundField DataField="DescripcionModulo" HeaderText="Modulo">
                                    <HeaderStyle Width="240px" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>                                                
                                <asp:BoundField DataField="DescripcionRol" HeaderText="Rol" Visible="true">
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
                <tr>
                    <td align="center" colspan="2">&nbsp;</td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <asp:Button ID="btnAsignarRol" runat="server" OnClick="btnAsignarRol_Click" Text="Asignar" />
                    </td>
                </tr>
        </table>
    </div>
         </ContentTemplate>
        </cc1:TabPanel>
        </cc1:TabContainer>
 
</asp:Content>

