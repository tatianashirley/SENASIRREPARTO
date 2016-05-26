<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmUsuario.aspx.cs" Inherits="Seguridad_wfrmUsuario" StylesheetTheme="Modal" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
     <script type="text/javascript" language="javascript">
         function checkDate2(sender, args) {
             var hoy = new Date();
             dia = hoy.getDate();
             mes = hoy.getMonth() + 1;
             anio = hoy.getFullYear();
             //ifecha = string(sender._selectedDate);
             fecha_actual = String(anio + "/" + mes + "/" + dia);
             fecha_act = new Date(fecha_actual);
             //alert(fecha_actual+'-'+fecha_act+'-'+sender._selectedDate);
             if (sender._selectedDate < fecha_act) {
                 alert("¡Usted no puede seleccionar una fecha pasada");
                 document.getElementById('<%=txtFechaExpiracion.ClientID %>').value = "";
            }
        }
         </script>
    <script type="text/javascript" language="javascript">
        function checkDate(sender, args) {
            
            var hoy = new Date();
            dia = hoy.getDate();
            mes = hoy.getMonth()+1;
            anio = hoy.getFullYear();
            //ifecha = string(sender._selectedDate);
            fecha_actual = String(anio+"/"+mes+"/"+dia);
            fecha_act = new Date(fecha_actual);
            //alert(fecha_actual+'-'+fecha_act+'-'+sender._selectedDate);
            if (sender._selectedDate < fecha_act) {
                alert("¡Usted no puede seleccionar una fecha pasada");
                document.getElementById('<%=txtFechaVigencia.ClientID %>').value = "";
             }
         }
         </script>
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
                    <asp:Label ID="lblTitulo" runat="server" Font-Bold="True" ForeColor="#CC0000" Font-Size="17px" Text="Lista Usuarios"></asp:Label>
                </td>
                <td align="right">
                    <asp:Button ID="btnInsertarModulo" runat="server" Text="Insertar Usuario" OnClick="btnInsertar_Click" />
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
                    <td align="center">
                        Busqueda Login:
                        <asp:TextBox ID="txtLogin" runat="server" Width="200px" onkeyup="this.value=this.value.toUpperCase()" autofocus="autofocus"></asp:TextBox>
                        &nbsp;<asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Buscar" />
                    </td>
                </tr>
                <tr>
                    <td align="center">


                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:GridView ID="gvDatos" runat="server" 
                            AllowPaging="True" 
                            AutoGenerateColumns="False" 
                          Font-Names="Arial" 
Font-Size="9pt" 
CssClass="mGrid"
PagerStyle-CssClass="pgr"
AlternatingRowStyle-CssClass="alt"
GridLines="None"
                             DataKeyNames="IdUsuario"
                             EnableTheming="True" 
                            
                            OnPageIndexChanging="gvDatos_PageIndexChanging" OnRowCommand="gvDatos_RowCommand"
                             PageSize="15" >
                            <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                            <Columns>
                                <asp:BoundField DataField="RowNumber" HeaderText="Nro" />
                                <asp:BoundField DataField="IdUsuario" HeaderText="IdUsuario" Visible="false" />
                                <asp:BoundField DataField="CuentaUsuario" HeaderText="Cuenta" Visible="true">
                                <HeaderStyle Width="90px" />
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NombreCompleto" HeaderText="Nombre Completo" Visible="true">
                                <HeaderStyle Width="240px" />
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
                                <asp:BoundField DataField="Estado" HeaderText="Estado" Visible="true">
                                <HeaderStyle Width="40px" />
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TipoUsuario" HeaderText="Tipo Usuario" Visible="true">
                                <HeaderStyle Width="40px" />
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="IdEstado" HeaderText="IdEstado" Visible="false" />
                                <asp:BoundField DataField="IdTipoUsuario" HeaderText="IdTipoUsuario" Visible="false" />
                                <asp:TemplateField HeaderText="Editar">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgEditar" runat="server" CausesValidation="false" CommandArgument='<%#Eval("IdUsuario") %>' CommandName="cmdEditar" ImageUrl="~/imagenes/16modificar.png" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Restaurar Contraseña">
                                    <ItemTemplate>
                                        <asp:ImageButton  ID="imgEliminar" runat="server" CausesValidation="False" CommandArgument='<%#Eval("IdUsuario") %>' CommandName="cmdEliminar" ImageUrl="~/Imagenes/16eliminar.png" ImageAlign="AbsBottom" OnClientClick="return confirm('Esta seguro en restaurar la contraseña?');"/>
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
    <asp:Panel ID="pnlRegistro" runat="server"  CssClass="panelceleste"><%-- Style="display: none;">--%>
        <div>

            <table align="center" cellpadding="0" cellspacing="0" width="600px">
                <tr>
                    <td align="center" colspan="2">
                        <asp:Label ID="Label2" runat="server" Text="Nuevo Usuario"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">&nbsp;</td>
                </tr>
                <tr>
                    <td align="right" width="50%">
                        <asp:Label ID="Label1" runat="server" Text="Carnet:"></asp:Label>
                        </td>
                    <td align="left">
                        <asp:TextBox ID="txtCarnet" runat="server" Width="179px" autofocus="autofocus" MaxLength="8"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" FilterType="Numbers"  TargetControlID="txtCarnet" />
                        &nbsp;
                        <asp:TextBox ID="txtIdUsuario" runat="server" ReadOnly="True" Visible="false" Width="80px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvCarnet" runat="server" ControlToValidate="txtCarnet" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" width="50%">
                        <asp:Label ID="Label5" runat="server" Text="Cuenta Usuario:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtCuentaUsuario" runat="server" Width="179px" onkeyup="this.value=this.value.toUpperCase()" MaxLength="20"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="LowercaseLetters,UppercaseLetters,Numbers,Custom"  TargetControlID="txtCuentaUsuario" ValidChars="_ñÑ"/>
                        <asp:RequiredFieldValidator ID="rfvCuentaUsuario" runat="server" ControlToValidate="txtCuentaUsuario" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" width="50%">
                        <asp:Label ID="lblClaveUsuario" runat="server" Text="Clave de Usuario:" Visible="false"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtClaveUsuario" runat="server" Width="179px" Visible="false" TextMode="Password" MaxLength="10"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="LowercaseLetters,UppercaseLetters,Numbers"  TargetControlID="txtClaveUsuario"/>
                        <asp:RequiredFieldValidator ID="rfvClaveUsuario" runat="server" ControlToValidate="txtClaveUsuario" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" width="50%">
                        <asp:Label ID="Label3" runat="server" Text="Fecha de Vigencia:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtFechaVigencia" runat="server" Enabled="false"></asp:TextBox>

                        <asp:ImageButton ID="imgcalendario" runat="server" CssClass="CajaDialogo" ImageUrl="~/Imagenes/32calendario.png"  />
                     

                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtFechaVigencia"  Format="dd/MM/yyyy" PopupButtonID="imgcalendario" CssClass="cal_Theme1" Enabled="True"  OnClientDateSelectionChanged="checkDate">  </cc1:CalendarExtender>	
                        
                        <asp:RequiredFieldValidator ID="rfvFechaVigencia" runat="server" ControlToValidate="txtFechaVigencia" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                        
                        
                    </td>
                </tr>
                <tr>
                    <td align="right" width="50%">
                        <asp:Label ID="Label4" runat="server" Text="Fecha de Expiracion:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtFechaExpiracion" runat="server"  Enabled="false"></asp:TextBox>
                        <asp:ImageButton ID="imgcalendarioexpiracion" runat="server" CssClass="CajaDialogo" ImageUrl="~/Imagenes/32calendario.png" />
                     
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFechaExpiracion"  Format="dd/MM/yyyy" PopupButtonID="imgcalendarioexpiracion" CssClass="cal_Theme1" OnClientDateSelectionChanged="checkDate2" >  </cc1:CalendarExtender>	
                        <asp:CompareValidator id="cvtxtStartDate" runat="server" controltocompare="txtFechaExpiracion" cultureinvariantvalues="true" display="Dynamic" enableclientscript="true" controltovalidate="txtFechaVigencia" errormessage="La fecha de expiracion no puede ser menor igual a la de vigencia" type="Date" setfocusonerror="true" operator="LessThan" text="*"/> 
                        <asp:Button ID="btnLimpiar" runat="server" OnClick="btnLimpiar_Click" Text="Limpiar" />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="auto-style6" >
                       
                        <asp:Label ID="lblTipoUsuario" runat="server" Text="Tipo Usuario:" Visible="false"></asp:Label>
                    </td>
                    <td align="left">
                         <asp:RadioButtonList ID="rblTipoUsuario" runat="server" Visible="false">
                            <asp:ListItem Value="676" Selected="True">Interno</asp:ListItem>
                            <asp:ListItem Value="677" >Externo</asp:ListItem>
                        </asp:RadioButtonList>

                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <asp:CheckBox ID="chbEstado" runat="server" Checked="True" Text="Estado Activo" />
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" OnClick="btnActualizar_Click"  Visible="false"/>
                        <asp:Button ID="btnAceptar" runat="server" Text="Registrar" OnClick="btnRegistrar_Click" />
                        &nbsp;<asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" CausesValidation="false"/>
                    </td>
                </tr>
            </table>
            <br />
        </div>
         <cc1:ModalPopupExtender ID="pnlRegistra_ModalPopupExtender" runat="server" 
Enabled="True" 
TargetControlID="lblTitulo" 
PopupControlID="pnlRegistro" 
BackgroundCssClass="modalBackground"> 
</cc1:ModalPopupExtender>  
    </asp:Panel>
   

</asp:Content>

