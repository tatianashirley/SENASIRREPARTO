<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmProgramacion.aspx.cs" Inherits="CertificacionCC_wfrmProgramacion" StylesheetTheme="Modal" Culture="Auto" UICulture="Auto"%>

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
                document.getElementById('<%=txtFechaInicio.ClientID %>').value = "";
            }
        }
         </script>
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
                document.getElementById('<%=txtFechaFinal.ClientID %>').value = "";
            }
        }
         </script>
    <style type="text/css">
        .auto-style5 {
            width: 26%;
        }
    </style>
    </asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="FondoAplicacion">
        <table width="100%" border="0" cellpadding="false" cellspacing="false">
            <tr>
                <td width="20%">
                    <asp:Label ID="lblTituloSistema" runat="server" Font-Bold="True" ForeColor="Navy" ></asp:Label>
                </td>
                <td width="60%" align="center">
                    <asp:Label ID="lblSubTitulo" runat="server" Font-Bold="True" ForeColor="#CC0000" Font-Size="17px" ></asp:Label>
                </td>
                <td align="right" width="20%">
                    <asp:Button ID="btnInsertar" runat="server" Text="Insertar"  CssClass="boton150"  />
                </td>
                <td></td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </div>
    <asp:Panel ID="pnlCabeceraMalla" runat="server">
      <table width="100%" border="0" cellpadding="false" cellspacing="false">
  <tr>
    <td width="50%" align="right">&nbsp;</td>
    <td align="left">&nbsp;</td>
  </tr>
  <tr>
    <td align="right">
        <asp:Label ID="Label2" runat="server" Text="Estructura Programación: "></asp:Label>
      </td>
    <td align="left">
        <asp:DropDownList ID="ddlEstructura" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEstructura_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlEstructura" InitialValue="0" ErrorMessage="*" />
      </td>
  </tr>
          <tr>
              <td align="right">
                  <asp:Label ID="Label5" runat="server" Text="Responsable: "></asp:Label>
              </td>
              <td align="left">
                  <asp:DropDownList ID="ddlIdUsuarioResponsable" runat="server" AutoPostBack="True">
                  </asp:DropDownList>
                  <asp:TextBox ID="txtIdRol" runat="server" Width="50px" ReadOnly="true" Visible="false"></asp:TextBox>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlIdUsuarioResponsable" InitialValue="0" ErrorMessage="*" />
              </td>
          </tr>
          <tr>
              <td align="right" valign="middle">
                  <asp:Label ID="Label3" runat="server" Text="Fecha Inicio: "></asp:Label>
              </td>
              <td align="left" valign="middle"><asp:TextBox ID="txtFechaInicio" runat="server" ></asp:TextBox>       
        <asp:ImageButton ID="imgcalendarioinicio" runat="server" CssClass="CajaDialogo" ImageUrl="~/Imagenes/32calendario.png"   CausesValidation="false"/>
        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFechaInicio"  Format="dd/MM/yyyy" PopupButtonID="imgcalendarioinicio"  OnClientDateSelectionChanged="checkDate" CssClass="cal_Theme1" >  </cc1:CalendarExtender>	
        
        <asp:RequiredFieldValidator ID="rfvFechaInicio" runat="server" ControlToValidate="txtFechaInicio" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>

                  &nbsp;<asp:Label ID="Label7" runat="server" Text="Plazo de Programación: "></asp:Label>
        <asp:DropDownList ID="ddlPlazoProgramacion" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPlazoProgramacion_SelectedIndexChanged">
        </asp:DropDownList>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlPlazoProgramacion" InitialValue="0" ErrorMessage="*" />


              </td>
          </tr>
  <tr>
    <td align="right">
        <asp:Label ID="lblFechaFinal" runat="server" Text="Fecha Final: "></asp:Label>
      </td>
    <td align="left">
        <asp:TextBox ID="txtFechaFinal" runat="server" ></asp:TextBox>
         <asp:ImageButton ID="imgcalendariofinal" runat="server" CssClass="CajaDialogo" ImageUrl="~/Imagenes/32calendario.png" />
        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtFechaFinal"  Format="dd/MM/yyyy" PopupButtonID="imgcalendariofinal" CssClass="cal_Theme1"  OnClientDateSelectionChanged="checkDate2">  </cc1:CalendarExtender>	
      
        
       
        <asp:RequiredFieldValidator ID="rfvFechaFinal" runat="server" ControlToValidate="txtFechaFinal" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
      </td>
  </tr>
          <tr>
              <td align="right">
                  &nbsp;</td>
              <td align="left">
                  <asp:Label ID="lblValidacionFechaMayo" runat="server" ForeColor="#FF3300"></asp:Label>
              </td>
          </tr>
          <tr>
              <td align="center" colspan="2" >
                  <asp:Button ID="btnActualizarCabecera" runat="server" Text="Actualizar Programacion" Width="200px" OnClick="btnActualizarCabecera_Click" Visible="false" />
                  <asp:Button ID="btnIngresarCabecera" runat="server" OnClick="btnIngresarCabecera_Click" Text="Ingresar Programación" Width="200px" />
                  <asp:Button ID="btnLimpiar" runat="server" CausesValidation="false" OnClick="btnCancelar_Click1" Text="Limpiar" Width="200px" />
              </td>
          </tr>
</table>
    </asp:Panel>

   <asp:Panel ID="pnlRegistrosCabecera" runat="server">
      <table width="100%" border="0" cellpadding="false" cellspacing="false">
  <tr>
    <td width="50%" align="right">&nbsp;</td>
    <td align="left">&nbsp;</td>
  </tr>
  <tr>
    <td  align="center" colspan="2">
        <asp:GridView ID="gvCabecera" runat="server"             
            AutoGenerateColumns="False" 
            EnableTheming="True" 
            Font-Names="Arial" 
                        Font-Size="9pt" 
                        CssClass="mGrid"
                        PagerStyle-CssClass="pgr"
                        AlternatingRowStyle-CssClass="alt"
                        GridLines="None"
            DataKeyNames="IdProgramacion,IdUsuarioResponsable,IdEstructura,FechaInicioPrg,FechaFinalPrg,IdEstadoProgramacion,IdTipoPlazoProgramacion"  
            OnRowDataBound="gvCabecera_RowDataBound"   OnRowCommand="gvCabecera_RowCommand"    >
                            
                            <Columns>                                
                                <asp:BoundField DataField="IdProgramacion" HeaderText="Programacion" Visible="true" />
                                <asp:BoundField DataField="IdEstructura" HeaderText="IdEstructura" Visible="false" />
                                <asp:BoundField DataField="IdTipoPlazoProgramacion" HeaderText="IdTipoPlazoProgramacion" Visible="false" />                                
                                <asp:BoundField DataField="IdUsuarioResponsable" HeaderText="IdUsuarioResponsable" Visible="false" />
                                <asp:BoundField DataField="UsuarioResponsable" HeaderText="Usuario Responsable"  />
                                <asp:BoundField DataField="Rol" HeaderText="Rol" Visible="true" />
                                <asp:BoundField DataField="FechaInicioPrg" HeaderText="Fecha Inicio"/>
                                <asp:BoundField DataField="FechaFinalPrg" HeaderText="Fecha Final" />
                                <asp:BoundField DataField="UsuarioCreacion" HeaderText="Usuario Elaboracion" />
                                <asp:BoundField DataField="FechaCreacion" HeaderText="Fecha Elaboracion" />                                
                                <asp:BoundField DataField="UsuarioAprobacion" HeaderText="Usuario Aprobacion" />
                                <asp:BoundField DataField="FechaAprobacionPrg" HeaderText="Fecha Aprobacion" />
                                <asp:BoundField DataField="Estado" HeaderText="Estado"/>
                                <asp:BoundField DataField="Personas" HeaderText="Nro de Integrantes" FooterStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />                                   
                                <asp:BoundField DataField="IdEstadoProgramacion" HeaderText="EstadoProgramacion" />                  
                              <asp:TemplateField HeaderText="Equipo de Trabajo"  HeaderStyle-HorizontalAlign="Center">
                                  <HeaderStyle Width="70px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemTemplate>
                                        <center>
                                        <asp:Image ID="imgAprobada" runat="server" ImageUrl="~/imagenes/nueva3/activo32.png" alt="Programación Aprobada"/>
                                        <asp:ImageButton ID="imgElaborada" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdAprobar" alt="Aprobar Programación" ImageUrl="~/imagenes/nueva3/inactivo32.png" />
                                        <asp:ImageButton ID="imgPendiente" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdElaborarEquipo" alt="Ver equipo de trabajo" ImageUrl="~/imagenes/nueva3/siguiente32.png" />
                                        <asp:ImageButton ID="imgModificar" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdModificar" alt="Editar equipo de trabajo" ImageUrl="~/imagenes/nueva3/editar32.png" />
                                        <%--<asp:ImageButton ID="imgVisualizar" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdVisualizar" ImageUrl="~/imagenes/16Previo.png" />--%>
                                             </center>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Programacion">
                                    <ItemTemplate>
                                        <center>
                                        <asp:ImageButton ID="imgModificarCabecera" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdModificarCabecera" alt="Editar Programación" ImageUrl="~/imagenes/nueva3/editar32.png" />
                                        <asp:ImageButton ID="imgEliminar" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdEliminar" alt="Eliminar Programación" ImageUrl="~/imagenes/nueva3/eliminar32.png" />                                        
                                            </center>
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
                            <SelectedRowStyle BackColor="#FFFF99" />
                        </asp:GridView>
        &nbsp;</td>
  </tr>
</table>
    </asp:Panel>
    <asp:Panel ID="pnlRegistrarMalla" runat="server">

      <table width="100%" border="0" cellpadding="false" cellspacing="false">
  <tr>
    <td width="50%" align="center" colspan="2">
        <asp:Label ID="Label1" runat="server" Text="Programación Automatica"></asp:Label>
        <asp:Label ID="lblNroProgramacion1" runat="server" ></asp:Label>
        &nbsp;</td>
  </tr>
          <tr>
              <td align="right" class="auto-style5">&nbsp;</td>
              <td align="left">&nbsp;</td>
          </tr>
  <tr>
    <td align="center" colspan="2">
        <asp:GridView ID="gvMallaAutomatica" runat="server"             
            AutoGenerateColumns="False" BorderColor="#DADADA" BorderStyle="Solid" BorderWidth="1px" CssClass="etiqueta8Blue" SkinID="GridView"
            EnableTheming="True" Font-Names="Arial" Font-Size="9pt" GridLines="Horizontal" 
            DataKeyNames="IdUsuario"  
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
                                <asp:BoundField DataField="IdUsuario" HeaderText="IdUsuario"  Visible="true" />
                                <asp:BoundField DataField="CuentaUsuario" HeaderText="Cuenta Usuario"  />
                                <asp:BoundField DataField="IdRol" HeaderText="IdRol" Visible="true"/>
                                <asp:BoundField DataField="Rol" HeaderText="Rol" Visible="true"/>
                                <asp:BoundField DataField="IdUsuarioSuperior" HeaderText="IdUsuarioSuperior" Visible="true"/>
                                <asp:BoundField DataField="NombreCompletoUsuario" HeaderText="Nombre Completo Usuario" />
                                <asp:BoundField DataField="DatosCompletosUsuario" HeaderText="Datos Usuario" />
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
        &nbsp;</td>
  </tr>
          <tr>
              <td align="center" witdh="50%" colspan="2">
                  <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" CausesValidation="false"/>&nbsp;<asp:Button ID="btnRechazar" runat="server" CausesValidation="false" OnClick="btnRechazar_Click" Text="Rechazar" />
                  &nbsp;<asp:Button ID="btnLimpiarPnl1" runat="server" CausesValidation="false" OnClick="btnLimpiarPnl_Click" Text="Limpiar" />
              </td>
          </tr>
</table>

    </asp:Panel>
    
      <asp:Panel ID="pnlRegistrarMallaRechazada" runat="server">

      <table width="100%" border="0" cellpadding="false" cellspacing="false">
  <tr>
    <td width="50%" align="center" colspan="2">
        <asp:Label ID="Label6" runat="server" Text="Programación Asistida"></asp:Label>&nbsp;
        <asp:Label ID="lblNroProgramacion2" runat="server" ></asp:Label>
    </td>
  </tr>
          <tr>
              <td align="right" class="auto-style5">&nbsp;</td>
              <td align="left">&nbsp;</td>
          </tr>
  <tr>
    <td align="center" colspan="2">
        <asp:GridView ID="gvEstructuraMallaAsistida" runat="server"             
            AutoGenerateColumns="False" BorderColor="#DADADA" BorderStyle="Solid" BorderWidth="1px" CssClass="etiqueta8Blue" SkinID="GridView"
            EnableTheming="True" Font-Names="Arial" Font-Size="9pt" GridLines="Horizontal" 
            DataKeyNames="IdUsuario"  
            >
                            <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                            <Columns> 
                                 <asp:TemplateField ControlStyle-Height="16"  ItemStyle-Width="5px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                <asp:CheckBox ID="chkTodos" runat="server" onclick = "checkAll(this);"  />
                                            </HeaderTemplate>    
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkRolAsistida" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>                               
                                <asp:BoundField DataField="IdUsuario" HeaderText="IdUsuario"  Visible="true" />
                                <asp:BoundField DataField="CuentaUsuario" HeaderText="Cuenta Usuario"  />
                                <asp:BoundField DataField="IdRol" HeaderText="IdRol" Visible="true"/>
                                <asp:BoundField DataField="Rol" HeaderText="Rol" Visible="true"/>                                
                                <asp:BoundField DataField="NombreCompletoUsuario" HeaderText="Nombre Completo Usuario" />
                                <asp:BoundField DataField="DatosCompletosUsuario" HeaderText="Datos Usuario" />
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
        &nbsp;</td>
  </tr>
          <tr>
              <td align="center" witdh="50%" colspan="2">
                  <asp:Button ID="btnAceptarAsistido" runat="server" Text="Aceptar" OnClick="btnAceptarAsistida_Click" CausesValidation="false"/>&nbsp;<asp:Button ID="btnLimpiarPnl0" runat="server" CausesValidation="false" OnClick="btnLimpiarPnl_Click" Text="Limpiar" />
              </td>
          </tr>
</table>

    </asp:Panel>
    <asp:Panel ID="pnlModificaProgramacion" runat="server" Visible="false">

      <table width="100%" border="0" cellpadding="false" cellspacing="false">
  <tr>
    <td width="50%" align="center" colspan="2">
        <asp:Label ID="lblModificaVisualiza" runat="server" Text="Detalle de la Programación "></asp:Label>
        <asp:Label ID="lblNroProgramacion" runat="server" ></asp:Label>
    </td>
  </tr>
          <tr>
              <td align="right" class="auto-style5">&nbsp;</td>
              <td align="left">&nbsp;</td>
          </tr>
  <tr>
    <td align="center" colspan="2">
        <asp:GridView ID="gvListaProgramacionMalla" runat="server"             
            AutoGenerateColumns="False" BorderColor="#DADADA" BorderStyle="Solid" BorderWidth="1px" CssClass="etiqueta8Blue" SkinID="GridView"
            EnableTheming="True" Font-Names="Arial" Font-Size="9pt" GridLines="Horizontal" 
            DataKeyNames="IdProgramacion,IdUsuario,IdRol,IdEstadoProgramacion,FechaInicioParte,FechaConclusionParte"  OnRowDataBound="gvListaProgramacionMalla_RowDataBound" OnRowCommand="gvListaProgramacionMalla_RowCommand"  
            >
                            <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                            <Columns>
                                <asp:BoundField DataField="RowNumber" HeaderText="Nro" />
                                <asp:BoundField DataField="IdProgramacion" HeaderText="Id" Visible="false" />
                                <asp:BoundField DataField="IdUsuario" HeaderText="IdUsuario"  Visible="false" />
                                <asp:BoundField DataField="CuentaUsuario" HeaderText="Cuenta Usuario"  />                                
                                <asp:BoundField DataField="IdRol" HeaderText="IdRol" Visible="false"/>                                
                                <asp:BoundField DataField="Rol" HeaderText="Rol" Visible="true"/>                                
                                <asp:BoundField DataField="NombreCompletoUsuario" HeaderText="Nombre Completo Usuario" />
                                <asp:BoundField DataField="DatosCompletosUsuario" HeaderText="Datos Usuario" />
                                <asp:BoundField DataField="IdEstadoProgramacion" HeaderText="IdEstadoProgramacion"  />
                                <asp:BoundField DataField="Estado" HeaderText="Estado"  />
                                <asp:TemplateField HeaderText="Seleccione...">
                                    <ItemTemplate>
                                        <center>
                                        <asp:ImageButton ID="imgEliminarMalla" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdEliminar" alt="Eliminar del equipo de trabajo"  ImageUrl="~/imagenes/nueva3/eliminar32.png" />
                                        <asp:ImageButton ID="imgBloqueadoMalla" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdBloqueado" alt="Bloquear miembro del equipo de trabajo" ImageUrl="~/imagenes/nueva3/stop32.png" />
                                            <asp:ImageButton ID="imgAprobarMalla" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdAprobar" alt="Aprobar miembro del equipo de trabajo" ImageUrl="~/imagenes/nueva3/bloquear32.png" />
                                            </center>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="FechaInicioParte" HeaderText="Inicio Prg" Visible="true"/>
                                <asp:TemplateField HeaderText="Reprogramacion">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkDetalles" runat="server" CausesValidation="False" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdReprogramacion">Re-programacion....</asp:LinkButton>
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
        <br />
        <asp:Label ID="Label8" runat="server" Text="Usuarios que no se ecuentran registrados en una programación"></asp:Label>
        <br />
        <br />
        <asp:GridView ID="gvModificaProgramacion" runat="server"             
            AutoGenerateColumns="False" BorderColor="#DADADA" BorderStyle="Solid" BorderWidth="1px" CssClass="etiqueta8Blue" SkinID="GridView"
            EnableTheming="True" Font-Names="Arial" Font-Size="9pt" GridLines="Horizontal" 
            DataKeyNames="IdUsuario"  
            >
                            <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                            <Columns> 
                                 <asp:TemplateField ControlStyle-Height="16"  ItemStyle-Width="5px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                <asp:CheckBox ID="chkTodos" runat="server" onclick = "checkAll(this);"  />
                                            </HeaderTemplate>    
                                                <ItemTemplate>                                                  
                                                    <asp:CheckBox  ID="chkRolAsistida" runat="server"/>
                                                </ItemTemplate>
                                            </asp:TemplateField> 
                                
                                <asp:BoundField DataField="IdUsuario" HeaderText="IdUsuario"  Visible="true" />
                                <asp:BoundField DataField="CuentaUsuario" HeaderText="Cuenta Usuario"  />
                                <asp:BoundField DataField="IdRol" HeaderText="IdRol" Visible="true"/>
                                <asp:BoundField DataField="Rol" HeaderText="Rol" Visible="true"/>                                
                                <asp:BoundField DataField="NombreCompletoUsuario" HeaderText="Nombre Completo Usuario" />
                                <asp:BoundField DataField="DatosCompletosUsuario" HeaderText="Datos Usuario" />
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
        &nbsp;</td>
  </tr>
          <tr>
              <td align="center" witdh="50%" colspan="2">
                  <asp:Button ID="btnAdicionar" runat="server" CausesValidation="false"  Text="Aceptar" OnClick="btnAdicionar_Click" />
                  <asp:Button ID="btnLimpiarPnl" runat="server" OnClick="btnLimpiarPnl_Click" Text="Limpiar" CausesValidation="false" />
                  &nbsp;</td>
          </tr>
          <tr>
              <td align="center" colspan="2" witdh="50%">¿Agregar un usuario rompiendo la estructura de la programación? ==&gt;
                  <asp:Button ID="btnNuevo" runat="server" CausesValidation="false"  Text="Nuevo" OnClick="btnNuevo_Click" />
              </td>
          </tr>
          
</table>

    </asp:Panel>
    <asp:Panel ID="pnlNuevoUsuarioProgramacion" runat="server" Visible="false">
        <table width="100%" border="0" cellpadding="false" cellspacing="false">
        <tr>
              <td align="center" colspan="2" witdh="50%">Seleccione Nivel a Ingresar<br />
                  </td>
          </tr>
          <tr>
              <td align="center" colspan="2" witdh="50%">
                  <asp:DropDownList ID="ddlListaEstructura" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlListaEstructura_SelectedIndexChanged">
                  </asp:DropDownList>
              </td>
          </tr>
          <tr>
              <td align="center" colspan="2" witdh="50%">
                  &nbsp;</td>
          </tr>
          <tr>
              <td align="center" colspan="2" witdh="50%">
                  <asp:GridView ID="gvListaxRol" runat="server" AutoGenerateColumns="False" BorderColor="#DADADA" BorderStyle="Solid" BorderWidth="1px" CssClass="etiqueta8Blue" DataKeyNames="IdUsuario" EnableTheming="True" Font-Names="Arial" Font-Size="9pt" GridLines="Horizontal" SkinID="GridView">
                      <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                      <Columns>
                          <asp:TemplateField ControlStyle-Height="16" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5px">
                              <HeaderTemplate>
                                  <asp:CheckBox ID="chkTodos" runat="server" onclick="checkAll(this);" />
                              </HeaderTemplate>
                              <ItemTemplate>
                                  <asp:CheckBox ID="chkNuevo" runat="server" />
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:BoundField DataField="IdUsuario" HeaderText="IdUsuario" Visible="true" />
                          <asp:BoundField DataField="CuentaUsuario" HeaderText="Cuenta Usuario" />
                          <asp:BoundField DataField="IdRol" HeaderText="IdRol" Visible="true" />
                          <asp:BoundField DataField="Rol" HeaderText="Rol" Visible="true" />
                          <asp:BoundField DataField="NombreCompletoUsuario" HeaderText="Nombre Completo Usuario" />
                          <asp:BoundField DataField="DatosCompletosUsuario" HeaderText="Datos Usuario" />
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
                  <br />
                  <asp:Button ID="btnAdicionarSnProgramacion" runat="server" CausesValidation="false" OnClick="btnAdicionarNuevo_Click" Text="Aceptar" />
                  <asp:Button ID="btnLimpiarPnl2" runat="server" CausesValidation="false" OnClick="btnLimpiarPnl_Click" Text="Limpiar" />
              </td>
          </tr>
        </table>

    </asp:Panel>

</asp:Content>

