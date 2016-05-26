<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmRegistroDocumento.aspx.cs" Inherits="Notificaciones_wfrmRegistroDocumento" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1"%>
<%@ Register assembly="System.Web, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="System.Web.UI" tagprefix="cc2" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
            if (sender._selectedDate > new Date()) {
                alert("¡Usted no puede seleccionar una fecha futura");
                document.getElementById('<%=txtFechaDocumento.ClientID %>').value = "";
            }
        }
         </script>
    <!-- AQUI VA EL CODIGO-->
        <div>
        <table width="80%" border="0" cellpadding="false" cellspacing="false">
        <tr>
            <td colspan="5" align="left">
               <%-- <asp:ImageButton ID="imgAux" runat="server" ImageUrl="~/Imagenes/w.png" />--%>
                <asp:Label ID="Label1" runat="server" Font-Names="Arial" Font-Size="11pt"
                    Text="Búsqueda de Trámites" CssClass="etiqueta20" Font-Underline="true" Font-Bold="true" ></asp:Label>
                <asp:Label ID="lblCodigo" runat="server" Font-Size="Small" Text="1" 
                    Visible="False"></asp:Label>
                <asp:Label ID="lblCodUsuario" runat="server" Font-Size="Small" Text="1" 
                    Visible="False"></asp:Label>
                <asp:Label ID="lblRol" runat="server" Font-Size="Small" 
                    style="text-align: left" Text="0" Visible="False"></asp:Label>
            </td>
        </tr>
                    <tr>
                        <td align="right"><asp:Label runat="server" Font-Names="Arial" Font-Size="9pt">Matrícula:</asp:Label></td>
                        <td align="left">
                            <asp:TextBox ID="txtMatricula" runat="server" Font-Names="Arial" MaxLength="12" Font-Size="9pt" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>                           
                            <cc1:FilteredTextBoxExtender ID="txtMatricula_FilteredTextBoxExtender" 
                                        runat="server" FilterType="Custom, LowercaseLetters, UppercaseLetters,Numbers"
                                        TargetControlID="txtMatricula" ValidChars="'áéíóúÁÉÍÓÚñÑ ">
                            </cc1:FilteredTextBoxExtender>
                        </td>
                        <td align="right"><asp:Label runat="server" Font-Names="Arial" Font-Size="9pt">Apellido Paterno:</asp:Label></td>
                        <td align="left">
                            <asp:TextBox ID="txtPaterno" runat="server" MaxLength="20" onkeyup="this.value=this.value.toUpperCase()" Font-Names="Arial" Font-Size="9pt"></asp:TextBox>                        
                            <cc1:FilteredTextBoxExtender ID="txtPaterno_FilteredTextBoxExtender" 
                                        runat="server" FilterType="Custom, LowercaseLetters, UppercaseLetters"
                                        TargetControlID="txtPaterno" ValidChars="'áéíóúÁÉÍÓÚñÑ ">
                            </cc1:FilteredTextBoxExtender>
                        </td>
                            <td align="left" rowspan="2">&nbsp;&nbsp;&nbsp;<asp:ImageButton runat="server" ID="imgbtnBorrar" ImageUrl="~/Imagenes/ZVarios/limpiar.png" Width="35px" Height="35px" ToolTip="Limpiar Campos de Búsqueda" OnClick="imgbtnBorrar_Click"/>&nbsp;&nbsp;&nbsp;
                            <asp:ImageButton runat="server" ID="imgbtnBuscar" ImageUrl="~/Imagenes/32Buscar.png"  ToolTip="Realizar búsqueda" OnClick="imgbtnBuscar_Click" CausesValidation="false"/></td>
                    </tr>
                    <tr>
                        <td align="right"><asp:Label runat="server" Font-Names="Arial" Font-Size="9pt">Número Trámite:</asp:Label></td>
                        <td align="left">
                            <asp:TextBox ID="txtTramite" runat="server" MaxLength="15" Font-Names="Arial" Font-Size="9pt"></asp:TextBox>
<%--                            <cc1:FilteredTextBoxExtender ID="txtTramite_FilteredTextBoxExtender1" 
                                        runat="server" FilterType="Numbers"
                                        TargetControlID="txtTramite" ValidChars="QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm">
                            </cc1:FilteredTextBoxExtender>--%>
                        </td>
                        <td align="right"><asp:Label runat ="server" Font-Names="Arial" Font-Size="9pt">Apellido Materno:</asp:Label></td>
                        <td align="left">
                            <asp:TextBox ID="txtMaterno" runat="server" MaxLength="20" onkeyup="this.value=this.value.toUpperCase()" Font-Names="Arial" Font-Size="9pt"></asp:TextBox>                            
                            <cc1:FilteredTextBoxExtender ID="txtMaterno_FilteredTextBoxExtender" 
                                        runat="server" FilterType="Custom, LowercaseLetters, UppercaseLetters"
                                        TargetControlID="txtMaterno" ValidChars="'áéíóúÁÉÍÓÚñÑ ">
                            </cc1:FilteredTextBoxExtender>
                        </td>                        
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label runat="server" Font-Names="Arial" Font-Size="9pt">Documento Identidad:</asp:Label>
                        </td>
                        <td align="left"><asp:TextBox ID="txtNumeroDocumento" MaxLength="15" runat="server" ToolTip="Sólo admite números" Font-Names="Arial" Font-Size="9pt"></asp:TextBox>                     
                            <cc1:FilteredTextBoxExtender ID="txtNumeroDocumento_FilteredTextBoxExtender" 
                                        runat="server" FilterType="Numbers"
                                        TargetControlID="txtNumeroDocumento" ValidChars="">
                            </cc1:FilteredTextBoxExtender>
                        </td>
                        <td align="right"><asp:Label runat ="server" Font-Names="Arial" Font-Size="9pt">Nombre:</asp:Label></td>
                        <td align="left">
                            <asp:TextBox ID="txtNombres" runat="server"  onkeyup="this.value=this.value.toUpperCase()" Font-Names="Arial" Font-Size="9pt" MaxLength="20"></asp:TextBox>
                        </td>
                    </tr>
                <!--integrando ambas tablas en una sola para q lo reconozca el cc1-->
            <tr ><td colspan="6"><hr style="border-bottom-color:black"/></td></tr>
            <tr>
            <td align="left" colspan="6">
               <%-- <asp:ImageButton ID="imgAux" runat="server" ImageUrl="~/Imagenes/w.png" />--%>
                <asp:Label ID="Label2" runat="server" 
                    Text="Registro Seleccionado" CssClass="etiqueta20" Font-Bold="true" Font-Underline="true" Font-Names="Arial" Font-Size="9pt"></asp:Label>
            </td>
        </tr>
        <tr>
             <%--<td align="left"><asp:Label runat ="server" Font-Names="Arial" Font-Size="9pt">Documento Identidad:</asp:Label></td>--%>
             <td align="left"><asp:Label runat ="server" Font-Names="Arial" Font-Size="9pt">Fecha Nacimiento:</asp:Label></td>
             <td align="left"><asp:Label runat="server" Font-Names="Arial" Font-Size="9pt">Apellido Paterno:</asp:Label></td>
             <td align="left"><asp:Label runat="server" Font-Names="Arial" Font-Size="9pt">Apellido Materno:</asp:Label></td>
             <td align="left"><asp:Label runat="server" Font-Names="Arial" Font-Size="9pt">Nombre(s):</asp:Label></td>
        </tr>
        <tr>
            <%-- <td align="left">
                 <asp:TextBox ID="txtCIC" runat="server"  Font-Names="Arial" Font-Size="9pt" Enabled="false"></asp:TextBox>                           
             </td>--%>
             <td align="left">
                <asp:TextBox ID="txtFechaNacC" runat="server"  Font-Names="Arial" Font-Size="9pt" Enabled="false"></asp:TextBox>                           

                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtPaternoC" runat="server"  Font-Names="Arial" Font-Size="9pt" Enabled="false"></asp:TextBox>                           
   
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtMaternoC" runat="server"  Font-Names="Arial" Font-Size="9pt" Enabled="false"></asp:TextBox>                           
 
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtNombreC" runat="server"  Font-Names="Arial" Font-Size="9pt" Enabled="false"></asp:TextBox>                           

                        </td>
                        <td rowspan="4">
                            &nbsp;&nbsp;&nbsp;<asp:ImageButton runat="server" ID="imgbtnAdd" ImageUrl="~/Imagenes/ZVarios/sumar1.png"  ToolTip="Agregar Nuevo Documento" Enabled="false" OnClick="imgbtnAdd_Click" Visible="false" CausesValidation="false"/>
                            <!--&nbsp;&nbsp;&nbsp;<asp:ImageButton runat="server" ID="imgbtnAddNotas" ImageUrl="~/Imagenes/ZVarios/aniadir1.png"  ToolTip="Registrar Notas Sueltas" Width="50px" Height="50px" Enabled="false"/>-->
                        </td>
                    </tr>
                    <tr>
                        <td align="left"><asp:Label runat ="server" Font-Names="Arial" Font-Size="9pt">Documento Identidad:</asp:Label></td>
                        <td align="left"><asp:Label runat="server" Font-Names="Arial" Font-Size="9pt">Trámite:</asp:Label></td>
                        <td align="left"><asp:Label runat="server" Font-Names="Arial" Font-Size="9pt">Matrícula:</asp:Label></td>
                        <%--<td align="left"><asp:Label runat="server" Font-Names="Arial" Font-Size="9pt">Dpto Actual:</asp:Label></td>--%>
                        <%--<td align="left"><asp:Label runat="server" Font-Names="Arial" Font-Size="9pt">Funcionario:</asp:Label></td>--%>
                        <td align="left"><asp:Label runat="server" Font-Names="Arial" Font-Size="9pt">Regional:</asp:Label></td>                        
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:TextBox ID="txtCIC" runat="server"  Font-Names="Arial" Font-Size="9pt" Enabled="false"></asp:TextBox>                           
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtTramiteC" runat="server" Font-Names="Arial" Font-Size="9pt" Enabled="false"></asp:TextBox>                           

                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtMatriculaC" runat="server" Font-Names="Arial" Font-Size="9pt" Enabled="false"></asp:TextBox>                           

                        </td>
                        <%--<td align="left">
                            <%--<asp:TextBox ID="txtDptoActual" runat="server" Font-Names="Arial" Font-Size="9pt" Enabled="false"></asp:TextBox>                           
                        </td>--%>
                        <%--<td align="left">
                            <asp:TextBox ID="txtFuncionarioC" runat="server" Font-Names="Arial" Font-Size="9pt" Enabled="false"></asp:TextBox>                           

                        </td>--%>
                        <td align="left">
                            <asp:TextBox ID="txtRegional" runat="server" Font-Names="Arial" Font-Size="9pt" Enabled="false"></asp:TextBox>                           

                        </td>
                     </tr>  
                     <tr>   
                         <td align="left" colspan="4">
                            <asp:Label ID="lblCoincidencias" runat="server" CssClass="text_obs" Text="COINCIDENCIAS" 
                                Font-Underline="true" Visible="false" Font-Names="Arial" Font-Size="11pt" Font-Bold="true"></asp:Label>
                         </td>
                         <td align="right"><asp:LinkButton runat="server" Font-Names="Arial" Font-Size="9pt" ID="lnkbtnMas" Text="Volver a Resultados" OnClick="lnkbtnMas_Click" Visible="false"></asp:LinkButton></td>
                     </tr>
            <tr>
            <td width="100%" align="left" colspan="6">
                            <asp:GridView ID="gvDatos" runat="server"
                                 Font-Names="Arial" 
                                 Font-Size="9pt" 
                                 CssClass="mGrid"
                                AllowPaging="True"
                                 PagerStyle-CssClass="pgr" OnSelectedIndexChanged="gvDatos_SelectedIndexChanged"
                                 AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False" Visible="False" OnPageIndexChanging="gvDatos_PageIndexChanging"
                                 DataKeyNames="PrimerApellido,SegundoApellido,IdTramite,FechaNacimiento,Funcionario,IdGrupoBeneficio,Direccion,IdOficinaNotificacion">
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" SelectText="Mostrar"/>
                                    <%--<asp:TemplateField HeaderText="Seleccionar">
                                        <HeaderStyle Width="70px" HorizontalAlign="Center" VerticalAlign="Middle"/>
                                        <ItemTemplate>
                                            <center>
                                                <asp:ImageButton runat="server" ID="ImgSelect" ImageUrl="~/Imagenes/16siguiente.png" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdSeleccionar"/>
                                            </center>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:BoundField DataField="IdTramite" HeaderText="Trámite" />
                                    <asp:BoundField DataField="Matricula" HeaderText="Matrícula" />
                                    <asp:BoundField DataField="NumeroDocumento" HeaderText="Carnet" />
                                    <asp:BoundField DataField="PrimerApellido" HeaderText="Paterno" />
                                    <asp:BoundField DataField="SegundoApellido" HeaderText="Materno" />
                                    <asp:BoundField DataField="PrimerNombre" HeaderText="Nombre(s)" />
                                    <asp:BoundField DataField="Regional" HeaderText="Regional" />

                                    <%--<asp:BoundField DataField="Departamento" HeaderText="Departamento Documento" Visible="false"/>--%>
                                    <asp:BoundField DataField="Funcionario" HeaderText="Funcionario" Visible="false" />
                                    <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha Nacimiento" Visible="false" />
                                    <asp:BoundField DataField="IdGrupoBeneficio" HeaderText="IdGrupoBeneficio" Visible="false" />
                                    <asp:BoundField DataField="Direccion" HeaderText="Direccion" Visible="false" />
                                    <asp:BoundField DataField="IdOficinaNotificacion" HeaderText="IdRegional" Visible="false" />
                                </Columns>
                                <EmptyDataTemplate>
                                    <div align="center" class="CajaDialogoAdvertencia">
                                    <br/>
                                    <img src="../Imagenes/warning.gif" alt="No existen Datos que correspondan al criterio especificado" />
                                    <br/>No existen datos que correspondan al criterio especificado<br/><br/>
                                    </div>
                                </EmptyDataTemplate>
                                <EditRowStyle BackColor="#999999" />
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#66ffff" Font-Bold="True" ForeColor="#000000" />
                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                            </asp:GridView>
                             
                        </td>
                     </tr>
                     </table>
                </div>       
<%--AQUI COMIENZA EL CODIGO DE LOS TABS--%>    
       <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="3"  OnDemand="true" Width="80%">
        <%--Tab1--%>
        <cc1:TabPanel ID="pnlDocumentos" runat="server" HeaderText="Documentos a Notificar" OnDemandMode="none"  TabIndex="1">  
            <ContentTemplate>              
            <div >

    <table>
            <tr>
                <td width="100%" align="left" colspan="6">
                <asp:Label ID="lblHistorico" Font-Names="Arial" Font-Size="11pt" runat="server" CssClass="text_obs" Text="HISTORIAL DE DOCUMENTOS" ForeColor="Red"  Visible="false"></asp:Label>
                    
                    <asp:GridView ID="gvNotificaciones" runat="server" 
                        Font-Names="Arial" 
                        Font-Size="9pt" 
                        CssClass="mGrid"
                        AllowPaging="True"
                        OnPageIndexChanging="gvDatos_PageIndexChanging2"
                        PagerStyle-CssClass="pgr"
                        PageSize="10"
                        AlternatingRowStyle-CssClass="alt"
                        AutoGenerateColumns="False" Visible="False" OnRowDataBound="gvCabecera_RowDataBound"  OnRowCommand="gvNotificar_OnRowcommand" DataKeyNames="IdTramite,IdGrupoBeneficio,IdDocumento,FechaDocumento,NroDocumento,FechaNotificacion,FechaRecurso">
                    <Columns>
                        <asp:BoundField DataField="DescripcionDocumento" HeaderText="Documento" />
                        <asp:BoundField DataField="FechaDocumento" HeaderText="Fecha Documento" />
                        <asp:BoundField DataField="NroDocumento" HeaderText="Nro Documento" />
                        <asp:BoundField DataField="FechaRegistro" HeaderText="Fecha Registro" />
                        <asp:BoundField DataField="FechaNotificacion" HeaderText="Fecha de Notificación"/>
                        <asp:BoundField DataField="FechaRecurso" HeaderText="Fecha de Recurso"/>
                        <asp:BoundField DataField="FechaVencePlazo" HeaderText="Fecha Plazo" />
                        <asp:BoundField DataField="IdDocumento" Visible="false"/>
                        <asp:BoundField DataField="IdTramite" Visible="false"/>
                        <asp:BoundField DataField="IdGrupoBeneficio" Visible="false"/>
                        <asp:BoundField DataField="DescDoc" HeaderText="Doc. a Presentar" Visible="true"/>
                        <asp:TemplateField HeaderText="Notificar - Recurso"  HeaderStyle-HorizontalAlign="Center">
                        <HeaderStyle Width="70px" HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemTemplate>
                                <center>
                                    <asp:ImageButton ID="imgElaborada" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdNotificar" ImageUrl="~/imagenes/nueva3/inactivo32.png" Visible="true" Height="16" Width="16" ToolTip="Registrar Notificación"/>
                                    <asp:ImageButton ID="imgPendiente" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdRecurso" ImageUrl="~/imagenes/nueva3/activo32.png" Visible="false" Height="16" Width="16" ToolTip="Registrar Recursos"/>
                                    <asp:ImageButton ID="imgEliminar" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdEliminar" ImageUrl="~/imagenes/nueva3/eliminar32.png" Visible="false" Height="16" Width="16"  ToolTip="Elimnar Recurs"/> 
                                    <asp:ImageButton ID="imgEditar" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex  %>' CommandName="cmdEditar" ImageUrl="~/imagenes/16modificar.png" Height="16" Width="16" ToolTip="Editar Registro" Visible="false"/>
                                </center>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Regional" HeaderText ="Regional"/>
                        <asp:BoundField DataField="EstadoEnv" HeaderText ="EstEnv"/>
                    </Columns>
                    <EmptyDataTemplate>
                        <div align="center" class="CajaDialogoAdvertencia">
                        <br/>
                        <img src="../Imagenes/warning.gif" alt="El Beneficiario no presenta Documentos registrados" />
                        <br/>El Beneficiario no presenta Documentos registrados<br/><br/>
                        </div>
                    </EmptyDataTemplate>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#0066CC" Font-Bold="True" ForeColor="#CCFFFF" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
            </td>
            </tr>
        </tr>

                     <tr align="center">

                <td align="center" colspan="6">

                <asp:Panel ID="pnlNotificacion" runat="server" CssClass="panelceleste"  HorizontalAlign="Center" Width="500px">
                    <div>
                        <asp:Label ID="lblNotificacion" runat="server" Text="Notificar Documento"
                            CssClass="etiqueta20" Font-Size="12pt" Font-Underline="True" Font-Names="Arial" ForeColor="#6699ff"></asp:Label>
                        <table style="width: 80%;">
                            <tr>
                                <td align="right"><asp:CheckBox runat="server" ID="chkhabilita" Text="A Domicilio:" AutoPostBack="True" Font-Names="Arial" Font-Size="9pt" OnCheckedChanged="chkhabilita_CheckedChanged" CssClass="etiqueta10"/></td>
                                <td align="left"><asp:DropDownList ID="ddlDomicilio" Font-Names="Arial" Font-Size="9pt" runat="server" Visible="false" >
                                    <asp:ListItem Value="31373" Text="Por Oficio"></asp:ListItem>
                                    <asp:ListItem Value="31374" Text="A Solicitud"></asp:ListItem>
                                                 </asp:DropDownList></td>    
                            </tr>
                            <tr>
                                <td colspan="2"></td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblDomicilio" Font-Names="Arial" Font-Size="9pt" runat="server" Text="Domicilio:" Visible="false" CssClass="etiqueta10"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox runat="server" Font-Names="Arial" Font-Size="9pt" ID="txtDireccion" Visible="false" Height="16px" Width="240px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2"></td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style5">
                                    <asp:Label ID="lblFechaNotificacion" Font-Names="Arial" Font-Size="9pt" runat="server" Text="Fecha Notificación" CssClass="etiqueta10"></asp:Label>
                                </td>
                                <td align="left" class="auto-style5">

                                   <asp:TextBox ID="txtFechaNotificacion" Font-Names="Arial" Font-Size="9pt" runat="server" Width="100px" MaxLength="10"></asp:TextBox>
                                    <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator8" ValidationGroup="ValNotificar" runat="server" ControlToValidate="txtFechaNotificacion" Display="Dynamic" ErrorMessage="dd/mm/aaaa" ValidationExpression="^([\d]{2})/([\d]{2})/([\d]{4})$"
                                        Font-Size="9pt" Font-Names="Arial">
                                        </asp:RegularExpressionValidator>--%>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender14" 
                                        runat="server" FilterType="Numbers,Custom"
                                        TargetControlID="txtFechaNotificacion" ValidChars="/">
                                    </cc1:FilteredTextBoxExtender>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFechaNotificacion" ErrorMessage="RequiredFieldValidator" ValidationGroup="ValNotificar">*</asp:RequiredFieldValidator>--%>
                                   <%--<asp:ImageButton ID="imgcal2" runat="server" ImageUrl="~/Imagenes/pequeños/Calendar_32x32.png" Height="20px" Width="20px" />--%>
                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" Format="dd/MM/yyyy" PopupButtonID="txtFechaNotificacion" 
                                    TargetControlID="txtFechaNotificacion" CssClass="cal_Theme1"></cc1:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2"></td>
                            </tr>
                            <tr>
                                <td valign="top" align="right" class="auto-style5">
                                    <asp:Label ID="lblObs" Font-Names="Arial" Font-Size="9pt" runat="server" Text="Observación" CssClass="etiqueta10"></asp:Label>
                                </td>
                                <td align="left" class="auto-style5">
                                    <asp:TextBox ID="txtObservacion" Font-Names="Arial" Font-Size="9pt" runat="server" TextMode="multiline" Columns="28" Rows="5"  onfocus="selecciona_value(this)" Width="240px"></asp:TextBox>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtObservacion" ErrorMessage="RequiredFieldValidator" ValidationGroup="ValNotificar">*</asp:RequiredFieldValidator>--%>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2"></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td align="left"><asp:Button ID="btnCancelarNotificar" runat="server" EnableTheming="True" CausesValidation="false"
                                         Text="Cancelar"
                                        CssClass="boton150" />
                                
                                    <asp:Button ID="btnAccionarNotificar" runat="server"
                                        Text="Aceptar" CssClass="boton150" OnClick="btnAccionarNotificar_Click" CausesValidation="true" ValidationGroup="ValNotificar"/>
                                    <cc1:ConfirmButtonExtender ID="btnGrabar_ConfirmButtonExtender" runat="server" TargetControlID="btnAccionarNotificar" ConfirmText="¿Esta seguro de guardar/modificar la Notificación?"> 
                                    </cc1:ConfirmButtonExtender>
                                </td>
                            </tr>
                        </table>

                    </div>
                </asp:Panel>
                <cc1:RoundedCornersExtender ID="RoundedCornersExtender1" runat="server"
                    Enabled="True" TargetControlID="pnlNotificacion" Radius="10" BorderColor="Black">
                </cc1:RoundedCornersExtender>
                <cc1:ModalPopupExtender ID="pnlNotificar" runat="server"
                    Enabled="True"
                    TargetControlID="lnkbtnNotificacion"
                    CancelControlID="btnCancelarNotificar"
                    PopupControlID="pnlNotificacion"
                    BackgroundCssClass="modalBackground">
                </cc1:ModalPopupExtender>
            </td>
            </tr>
                        <tr align="center">

                <td align="center" colspan="6">

                <asp:Panel ID="pnlRecurso" runat="server" CssClass="panelceleste"  HorizontalAlign="Center" Width="500px">
                    <div>
                        <asp:Label ID="lblRecurso" runat="server" Text="Registar Recurso"
                            CssClass="etiqueta20" Font-Size="12pt" Font-Underline="True" Font-Names="Arial" ForeColor="#6699ff"></asp:Label>
                        <table style="width: 80%;">
                            <tr>
                                <td></td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style5">
                                    <asp:Label ID="lblFechaRecurso" runat="server" Font-Names="Arial" Font-Size="9pt"  Text="Fecha Recurso" CssClass="etiqueta10"></asp:Label>
                                </td>
                                <td align="left" class="auto-style5">

                                   <asp:TextBox ID="txtFechaRecurso" runat="server" Width="100px"></asp:TextBox>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtFechaRecurso" ErrorMessage="RequiredFieldValidator" ValidationGroup="ValRecurso">*</asp:RequiredFieldValidator>--%>
                                  <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator9" ValidationGroup="ValRecurso" runat="server" ControlToValidate="txtFechaRecurso" Display="Dynamic" ErrorMessage="dd/mm/aaaa" ValidationExpression="^([\d]{2})/([\d]{2})/([\d]{4})$"
                                        Font-Size="9pt" Font-Names="Arial">
                                        </asp:RegularExpressionValidator>--%>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender15" 
                                        runat="server" FilterType="Numbers,Custom"
                                        TargetControlID="txtFechaRecurso" ValidChars="/">
                                    </cc1:FilteredTextBoxExtender>
                                   <%--<asp:ImageButton ID="imgcal3" runat="server" ImageUrl="~/Imagenes/pequeños/Calendar_32x32.png" Height="20px" Width="20px" />--%>
                                    <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Enabled="True" Format="dd/MM/yyyy" PopupButtonID="txtFechaRecurso" 
                                    TargetControlID="txtFechaRecurso" CssClass="cal_Theme1"></cc1:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2"></td>
                            </tr>
                            <tr>
                                <td valign="top" align="right" class="auto-style5">
                                    <asp:Label ID="lblObsR" runat="server" Text="Observación" CssClass="etiqueta10" Font-Names="Arial" Font-Size="9pt" ></asp:Label>
                                </td>
                                <td align="left" class="auto-style5">
                                    <asp:TextBox ID="txtORecurso" runat="server" TextMode="multiline" Columns="28" Rows="5"  onfocus="selecciona_value(this)"></asp:TextBox>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtORecurso" ErrorMessage="RequiredFieldValidator" ValidationGroup="ValRecurso">*</asp:RequiredFieldValidator>--%>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2"></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td align="left"><asp:Button ID="btnCancelarRecurso" runat="server" EnableTheming="True" CausesValidation="false"
                                         Text="Cancelar"
                                        CssClass="boton150" />
                                    <asp:Button ID="btnAccionarRecurso" runat="server"
                                        Text="Aceptar" CssClass="boton150" OnClick="btnAccionarRecurso_Click" ValidationGroup="ValRecurso" CausesValidation="true"/>
                                    <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="btnAccionarRecurso" ConfirmText="¿Esta seguro de guardar la presentación de Recurso?"> 
                                    </cc1:ConfirmButtonExtender>
                                </td>
                            </tr>
                        </table>

                    </div>
                </asp:Panel>
                <cc1:RoundedCornersExtender ID="pnlRecurso_RoundedCornersExtender" runat="server"
                    Enabled="True" TargetControlID="pnlRecurso" Radius="10" BorderColor="Black">
                </cc1:RoundedCornersExtender>
                <cc1:ModalPopupExtender ID="pnlRecurso_Pop" runat="server"
                    Enabled="True"
                    TargetControlID="lnkbtnRecurso"
                    CancelControlID="btnCancelarRecurso"
                    PopupControlID="pnlRecurso"
                    BackgroundCssClass="modalBackground">
                </cc1:ModalPopupExtender>
            </td>
            </tr>


            <!-- Aqui comienza ultimo popup-->

                <tr align="center">

                <td align="center" colspan="6">

                <asp:Panel ID="pnlModifica" runat="server" CssClass="panelceleste"  HorizontalAlign="Center" Width="500px">
                   <div>
                        <asp:Label ID="lblModifica" runat="server" Text="Modificar Fechas" Font-Names="Arial" ForeColor="#6699ff"
                            CssClass="etiqueta20" Font-Size="12pt" Font-Underline="True"></asp:Label>
                        <table style="width: 80%;">
                            <tr>
                                <td></td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style5">
                                    <asp:Label ID="lblFNot" runat="server" Font-Names="Arial" Font-Size="9pt"  Text="Fecha Notificacion" CssClass="etiqueta10"></asp:Label>
                                </td>
                                <td align="left" class="auto-style5">

                                   <asp:TextBox ID="txtFnot" runat="server" Width="100px"></asp:TextBox>
                                   <%--<asp:ImageButton ID="imgFecNot" runat="server" ImageUrl="~/Imagenes/pequeños/Calendar_32x32.png" Height="20px" Width="20px" />--%>
                                    <cc1:CalendarExtender ID="CalendarExtender4" runat="server" Enabled="True" Format="dd/MM/yyyy" PopupButtonID="txtFnot" 
                                    TargetControlID="txtFnot" CssClass="cal_Theme1"></cc1:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2"></td>
                            </tr>
                           
                            <tr>
                                <td align="right" class="auto-style5">
                                    <asp:Label ID="lblFrec" runat="server" Font-Names="Arial" Font-Size="9pt"  Text="Fecha Recurso" CssClass="etiqueta10"></asp:Label>
                                </td>
                                <td align="left" class="auto-style5">

                                   <asp:TextBox ID="txtFrec" runat="server" Width="100px"></asp:TextBox>
                                   <%--<asp:ImageButton ID="imgFecRec" runat="server" ImageUrl="~/Imagenes/pequeños/Calendar_32x32.png" Height="20px" Width="20px" />--%>
                                    <cc1:CalendarExtender ID="CalendarExtender5" runat="server" Enabled="True" Format="dd/MM/yyyy" PopupButtonID="txtFrec" 
                                    TargetControlID="txtFrec" CssClass="cal_Theme1"></cc1:CalendarExtender>
                                </td>
                            </tr>

                            <tr>
                                <td colspan="2"></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td align="left"><asp:Button ID="btnCancelMod" runat="server" EnableTheming="True"
                                         Text="Cancelar"
                                        CssClass="boton150" />
                                    <asp:Button ID="Button2" runat="server"
                                        OnClientClick="javascript : return confirm('Esta seguro de realizar esta accion?');"
                                        Text="Aceptar" CssClass="boton150" OnClick="btnAccionarCambios_Click"/>
                                </td>
                            </tr>
                        </table>

                    </div>
                </asp:Panel>
                <cc1:RoundedCornersExtender ID="RoundedCornersExtender2" runat="server"
                    Enabled="True" TargetControlID="pnlModifica" Radius="10" BorderColor="Black">
                </cc1:RoundedCornersExtender>
                <cc1:ModalPopupExtender ID="pnlModifica_pop" runat="server"
                    Enabled="True"
                    TargetControlID="lnkCAmbio"
                    CancelControlID="btnCancelMod"
                    PopupControlID="pnlModifica"
                    BackgroundCssClass="modalBackground">
                </cc1:ModalPopupExtender>
            </td>
            </tr>

            <tr><td><asp:Button ID="lnkbtnNotificacion" runat="server" Text="Notificación" style="display:none"></asp:Button></td>
                <td><asp:Button ID="lnkbtnRecurso" runat="server" Text="Recurso" style="display:none"></asp:Button></td>
                <td><asp:Button ID="lnkCambio" runat="server" Text="Recurso" style="display:none"></asp:Button></td>
            </tr>
                </table>

            
        </div>
            </ContentTemplate>
        </cc1:TabPanel>
           <%--Tab2--%>
        <cc1:TabPanel ID="TabPanel1" runat="server" HeaderText="Registrar Documentos" OnDemandMode="none"  TabIndex="2">  
        <ContentTemplate>              
        <div >      
            <table align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td><br /></td>
                </tr>
                <tr>
                    <td align="left"><asp:Label runat="server" ID="lblDocumento" Text="Origen:" Font-Size="9pt" Font-Names="Arial" CssClass="etiqueta10"/></td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlOrigen" Font-Names="Arial" Font-Size="9pt" OnTextChanged="ddlOrigen_TextChanged" AutoPostBack="true" Width="250px" AppendDataBoundItems="true">
                            <asp:ListItem Value="0" Text ="Seleccione..."></asp:ListItem>
                            <asp:ListItem Value="1" Text ="Comision Nacional de Prestaciones"></asp:ListItem>
                            <asp:ListItem Value="2" Text ="Recurso de Reclamcion"></asp:ListItem>
                            <asp:ListItem Value="3" Text ="Otras Areas Funcionales"></asp:ListItem>
                            <asp:ListItem Value="4" Text ="A Domicilio"></asp:ListItem>
                            <asp:ListItem Value="5" Text ="Notas de Respuesta otras Areas Funcionales"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlOrigen" ErrorMessage="RequiredFieldValidator"
                        ValidationGroup="ValRegistro">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td><br /></td>
                </tr>
                <tr>
                    <td align="left"><asp:Label ID="lblTipoDocumento" Font-Names="Arial" Font-Size="9pt" runat="server" Text="Documento: " CssClass="etiqueta10"/></td>
                    <td> <asp:DropDownList ID="ddlTipoDocumento" Font-Names="Arial" Font-Size="9pt" runat="server" Width="150px" DataTextField="DescripcionDocumento" OnTextChanged="ddlTipoDocumento_TextChanged" AutoPostBack="true"  AppendDataBoundItems="true">
                                <%--<asp:ListItem Value="0" Text ="Seleccione..."></asp:ListItem>--%>
                         </asp:DropDownList>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlTipoDocumento" ErrorMessage="RequiredFieldValidator"
                             ValidationGroup="ValRegistro">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr><td><br /></td></tr>
                <tr>
                    <td align="left"><asp:Label runat="server" ID="lblDias" Text="Días:" Font-Size="9pt" Font-Names="Arial" CssClass="etiqueta10"/><%--</td>
                    <td>--%><asp:TextBox runat="server" ID="txtDias" Width="50px"  Enabled="false"/></td>
                    <td align="left"><asp:Label runat="server" ID="lblPlazo" Text="Tipo Plazo:"  Font-Size="9pt" Font-Names="Arial" CssClass="etiqueta10"/><%--</td>
                    <td>--%><asp:TextBox runat="server" ID="txtPlazo" Width="65px" Enabled="false"/></td>
                </tr>
                <tr>
                    <td><br /></td>
                </tr>
                <tr>
                    
                </tr>
                <tr>
                    <td><asp:Label ID="lblDocInter" Font-Names="Arial" Font-Size="9pt" runat="server" CssClass="etiqueta10" Text="Documento a Interponer:"/></td>
                    <td><asp:Label ID="lblDocumentoRecurso" Font-Names="Arial" Font-Size="9pt" runat="server" CssClass="etiqueta10" Font-Bold="true"/></td>
                </tr>
                <tr>
                    <td><br /></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblFechaDocumento" Font-Names="Arial" Font-Size="9pt" runat="server" Text="Fecha Documento: " CssClass="etiqueta10" /></td>
                    <td><asp:TextBox ID="txtFechaDocumento" runat="server" Width="100px" Font-Names="Arial" Font-Size="9pt" MaxLength="10"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtFechaDocumento" ErrorMessage="RequiredFieldValidator"
                                        ValidationGroup="ValRegistro">*</asp:RequiredFieldValidator>
                                   <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ValidationGroup="ValRegistro" runat="server" ControlToValidate="txtFechaDocumento" Display="Dynamic" ErrorMessage="dd/mm/aaaa" ValidationExpression="^([\d]{2})/([\d]{2})/([\d]{4})$"
                                        Font-Size="9pt" Font-Names="Arial">
                                      </asp:RegularExpressionValidator>
                                   <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" 
                                        runat="server" FilterType="Numbers,Custom"
                                        TargetControlID="txtFechaDocumento" ValidChars="/">
                                    </cc1:FilteredTextBoxExtender>
                                   <%--<asp:ImageButton ID="imgCalendario" runat="server" ImageUrl="~/Imagenes/pequeños/Calendar_32x32.png" Height="20px" Width="20px" />--%>
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy" PopupButtonID="txtFechaDocumento"  
                                    TargetControlID="txtFechaDocumento" CssClass="cal_Theme1" OnClientDateSelectionChanged="checkDate"></cc1:CalendarExtender>
                    </td>
                </tr>
                <tr>
                    <td><br /></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblNroDocumento" Font-Names="Arial" Font-Size="9pt" runat="server" Text="Nro Documento:" CssClass="etiqueta10"/></td>
                    <td><asp:TextBox ID="txtNroDocumento" runat="server" Width="70px" MaxLength="8" TextMode="SingleLine" Font-Names="Arial" Font-Size="9pt" ></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtNroDocumento" ErrorMessage="RequiredFieldValidator"
                            ValidationGroup="ValRegistro">*</asp:RequiredFieldValidator>--%>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" 
                                        runat="server" FilterType="Numbers,Custom"
                                        TargetControlID="txtNroDocumento" ValidChars="">
                                    </cc1:FilteredTextBoxExtender>
                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender6"  runat="server" FilterType="Numbers" TargetControlID="txtNroDocumento" ValidChars=""></cc1:FilteredTextBoxExtender>
                    </td>
                    <%--<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server"
                      ControlToValidate="txtNroDocumento"
                      ErrorMessage="Nro de Documento es Requerido"
                      ForeColor="Red">
                    </asp:RequiredFieldValidator>--%>
                </tr>
                <tr>
                    <td><br /></td>
                </tr>
                <tr align="center" valign="middle">
                    <td><asp:Button runat="server" ID="btnRegistrar" Text="Registrar" ValidationGroup="ValRegistro" CausesValidation="true" OnClick="btnAccionarRegistro_Click"
                        CssClass="boton150"/>
                      <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" TargetControlID="btnRegistrar" ConfirmText="¿Esta seguro de guardar el registro del Documento"> 
                      </cc1:ConfirmButtonExtender>
                    </td><td colspan="3">
                            <asp:Button runat="server" ID="btnCancelar" Text="Cancelar" EnableTheming="True" OnClick="btnCancelar_Click" CausesValidation="false"
                                        CssClass="boton150"/></td>
                </tr>
            </table>
            <table border="0">
            <tr align="center">
                <td align="center" colspan="6">
          </table>


            </div>
            </ContentTemplate>
            </cc1:TabPanel>
           
           <%--Tab 6--%>
           <cc1:TabPanel runat="server" ID="TabPanel5" HeaderText="Notas de Respuesta">
               <ContentTemplate>
                   <div>
                       <table align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td><asp:Label runat="server" ID="lblNotaResp" Text="Fecha Documento:" Font-Size="9pt" Font-Names="Arial" CssClass="etiqueta10"/></td>
                    <td><asp:TextBox ID="txtNotaResp" runat="server" Width="100px" Font-Names="Arial" Font-Size="9pt" MaxLength="10"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ValidationGroup="ValNotas" runat="server" ControlToValidate="txtNotaResp" Display="Dynamic" ErrorMessage="dd/mm/aaaa" ValidationExpression="^([\d]{2})/([\d]{2})/([\d]{4})$"
                            Font-Size="9pt" Font-Names="Arial">
                            </asp:RegularExpressionValidator>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" 
                            runat="server" FilterType="Numbers,Custom"
                            TargetControlID="txtNotaResp" ValidChars="/">
                        </cc1:FilteredTextBoxExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtNotaResp" ErrorMessage="RequiredFieldValidator" ValidationGroup="ValNotas">*</asp:RequiredFieldValidator>
                        <cc1:CalendarExtender ID="CalendarExtender6" runat="server" Enabled="True" Format="dd/MM/yyyy" PopupButtonID="txtNotaResp" 
                        TargetControlID="txtNotaResp" CssClass="cal_Theme1"></cc1:CalendarExtender>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2"  runat="server" FilterType="Custom,Numbers" TargetControlID="txtNotaResp" ValidChars="/"></cc1:FilteredTextBoxExtender>
                    </td>
                </tr>
                <tr>
                    <td colspan="2"><br /></td>
                </tr>

                <tr>
                    <td><asp:Label ID="Label8" Font-Names="Arial" Font-Size="9pt" runat="server" Text="Nro Documento:" CssClass="etiqueta10"/></td>
                    <td><asp:TextBox ID="txtDocNro" runat="server" Width="80px" MaxLength="8" TextMode="SingleLine" Font-Names="Arial" Font-Size="9pt" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtDocNro" ErrorMessage="RequiredFieldValidator"
                            ValidationGroup="ValNotas">*</asp:RequiredFieldValidator>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" 
                            runat="server" FilterType="Numbers"
                            TargetControlID="txtDocNro" ValidChars="">
                        </cc1:FilteredTextBoxExtender>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1"  runat="server" FilterType="Numbers" TargetControlID="txtDocNro" ValidChars=""></cc1:FilteredTextBoxExtender>
                    </td>
                </tr>
                <tr>
                    <td colspan="2"><br /></td>
                </tr>
                <tr>
                    <td><asp:Label runat="server" ID="lblNoti" Text="Fecha Notificación:" Font-Size="9pt" Font-Names="Arial" CssClass="etiqueta10"/></td>
                    <td><asp:TextBox ID="txtNotResp" runat="server" Width="100px" Font-Names="Arial" Font-Size="9pt" MaxLength="10"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtNotResp" ErrorMessage="RequiredFieldValidator" ValidationGroup="ValNotas">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ValidationGroup="ValNotas" runat="server" ControlToValidate="txtNotResp" Display="Dynamic" ErrorMessage="dd/mm/aaaa" ValidationExpression="^([\d]{2})/([\d]{2})/([\d]{4})$"
                            Font-Size="9pt" Font-Names="Arial">
                            </asp:RegularExpressionValidator>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" 
                            runat="server" FilterType="Numbers,Custom"
                            TargetControlID="txtNotResp" ValidChars="/">
                        </cc1:FilteredTextBoxExtender>
                        <cc1:CalendarExtender ID="CalendarExtender7" runat="server" Enabled="True" Format="dd/MM/yyyy" PopupButtonID="txtNotResp" 
                        TargetControlID="txtNotResp" CssClass="cal_Theme1"></cc1:CalendarExtender>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3"  runat="server" FilterType="Custom,Numbers" TargetControlID="txtNotResp" ValidChars="/"></cc1:FilteredTextBoxExtender>
                    </td>
                </tr>
                <tr>
                    <td><br /></td>
                </tr>
                <tr>
                    <td valign="top"><asp:Label ID="lblObservacionNota" Font-Names="Arial" Font-Size="9pt" runat="server" Text="Observacion:" CssClass="etiqueta10"/></td>
                    <td><asp:TextBox ID="txtObsNota" runat="server" Width="150px" Height="80px" MaxLength="30" TextMode="MultiLine" Font-Names="Arial" Font-Size="9pt" ></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtObsNota" ErrorMessage="RequiredFieldValidator"
                            ValidationGroup="ValNotas">*</asp:RequiredFieldValidator>--%>
                    </td>
                </tr>
                           
                <tr align="center" valign="middle">
                    <td align="center"><asp:Button runat="server" ID="btnRegNota" Text="Registrar" CausesValidation="true" ValidationGroup="ValNotas"
                                        CssClass="boton150" OnClick="btnRegNota_Click" />
                                    <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender3" runat="server" TargetControlID="btnRegNota" ConfirmText="¿Esta seguro de registrar la nota de Respuesta?"> 
                                    </cc1:ConfirmButtonExtender>
                    </td>
                    <td align="center">
                        <asp:Button runat="server" ID="btnNotaCancel" Text="Cancelar" EnableTheming="True" OnClick="btnCancelar_Click" CausesValidation="false"
                        CssClass="boton150"/>
                    </td>
                </tr>

            </table>
            <table border="0">
            <tr align="center">
                <td align="center" colspan="6">
          </table>
                   </div>
               </ContentTemplate>
           </cc1:TabPanel>
            <%--Tab3--%>
           <cc1:TabPanel runat="server" ID="TabPanel2" HeaderText="Registrar Envío">
               <ContentTemplate>
                   <div>
                       <table id="Table1" runat="server" align="center"> 
                     <tr>   
                         <td align="left" colspan="6">
                             <asp:Label runat="server" ID ="lblRegional" Text="Para Enviar:..."  Visible="false"  CssClass="etiqueta10" Font-Bold="true" Font-Underline="true" Font-Names="Arial"></asp:Label></td>
                     </tr>
                     <tr>
                         <td width="100%" align="left" colspan="7">
                            <asp:GridView ID="gvEnvio" runat="server" CellPadding="4" ForeColor="#333333" BorderStyle="Solid"
                                Font-Names="Arial" 
                                 Font-Size="9pt" 
                                 CssClass="mGrid"
                                 AllowPaging="True"
                                 PagerStyle-CssClass="pgr"
                                 PageSize="10"
                                 OnPageIndexChanging="gvEnvio_PageIndexChanging"
                                 AutoGenerateColumns="False" Visible="False" DataKeyNames="IdDocumento,FechaDocumento,NroDocumento">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775"/>
                                <Columns>
                                    <asp:BoundField DataField="IdDocumento" HeaderText="TipoDoc" Visible="false" />
                                    <asp:BoundField DataField="DescripcionDocumento" HeaderText="Documento" />
                                    <asp:BoundField DataField="FechaDocumento" HeaderText="Fecha Documento" />
                                    <asp:BoundField DataField="NroDocumento" HeaderText="Nro Documento" />
                                    <asp:BoundField DataField="FechaRegistro" HeaderText="Fecha Registro" />
                                    <asp:TemplateField ControlStyle-Height="16"  ItemStyle-Width="5px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                <HeaderTemplate>
                                                <asp:CheckBox ID="chkTodos" runat="server" onclick = "checkAll(this);"  />
                                            </HeaderTemplate>    
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkEnvio" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    <div align="center" class="CajaDialogoAdvertencia">
                                    <br/>
                                    <img src="../Imagenes/warning.gif" alt="No existen pagos que correspondan al criterio especificado" />
                                    <br/>No existen Documentos para envío<br/><br/>
                                    </div>
                                </EmptyDataTemplate>
                                 <EditRowStyle BackColor="#999999" />
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#66ffff" Font-Bold="True" ForeColor="#000000" />
                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                            </asp:GridView>
                        </td>
                     </tr>
            <tr><td colspan="6" align="left"><asp:LinkButton runat="server" Text="VER ULTIMO ENVIO" ID="lnkMas" OnClick="UltimoEnvio"></asp:LinkButton></td></tr>
            <tr><td align="left" colspan="6"><asp:GridView ID="gvUltEnvio" runat="server" CellPadding="4" ForeColor="#333333" BorderStyle="Solid"
                                Font-Names="Arial" 
                                 Font-Size="9pt" 
                                 CssClass="mGrid"
                                AutoGenerateColumns="False" Visible="False"  OnSelectedIndexChanged="gvDatos_SelectedIndexChanged">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775"/>
                                <Columns>
                                    <%--<asp:CommandField ShowSelectButton="True" SelectText="Ver Detalle"/>--%>
                                    <asp:BoundField DataField="NumeroDocumento" HeaderText="CI" Visible="false" />
                                    <asp:BoundField DataField="FechaNacimiento" HeaderText="FechaNacimiento" Visible="false" />
                                    <asp:BoundField DataField="PrimerApellido" HeaderText="Paterno" Visible="false" />
                                    <asp:BoundField DataField="SegundoApellido" HeaderText="Materno" Visible="false" />
                                    <asp:BoundField DataField="PrimerNombre" HeaderText="Nombre" Visible="false" />
                                    <asp:BoundField DataField="Matricula" HeaderText="Matricula" Visible="false" />
                                    <asp:BoundField DataField="Regional" HeaderText="Regional" Visible="false" />
                                    <asp:BoundField DataField="OfiNot" HeaderText="OfiNot" Visible="false" />
                                    <asp:BoundField DataField="IdTramite" HeaderText="Tramite" Visible="false" />
                                    <asp:BoundField DataField="IdGrupoBeneficio" HeaderText="GrupoBeneficio" Visible="false" />
                                    <asp:BoundField DataField="IdDocumento" HeaderText="TipoDoc" Visible="false" />
                                    <asp:BoundField DataField="DescripcionDocumento" HeaderText="Documento" />
                                    <asp:BoundField DataField="FechaDocumento" HeaderText="Fecha Documento" />
                                    <asp:BoundField DataField="NroDocumento" HeaderText="Nro Documento" />
                                    <asp:BoundField DataField="FechaRegistroSistema" HeaderText="Fecha Registro" />
                                    <asp:BoundField DataField="CiteDescripcion" HeaderText="CITE" />
                                    <asp:BoundField DataField="FechaCite" HeaderText="Fecha CITE" />
                                    <asp:BoundField DataField="FechaEnvio" HeaderText="Fecha Envío" />

                                </Columns>
                                <EmptyDataTemplate>
                                    <div align="center" class="CajaDialogoAdvertencia">
                                    <br/>
                                    <img src="../Imagenes/warning.gif" alt="No existen pagos que correspondan al criterio especificado" />
                                    <br/>No existen datos que correspondan al criterio especificado<br/><br/>
                                    </div>
                                </EmptyDataTemplate>
                                 <EditRowStyle BackColor="#999999" />
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#66ffff" Font-Bold="True" ForeColor="#000000" />
                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                            </asp:GridView></td></tr>
            <tr><td colspan="6">&nbsp;</td></tr>
            
            <tr align="center">

                <td align="center" colspan="6">

                <asp:Panel ID="pnlEnvio" runat="server" CssClass="panelceleste"  HorizontalAlign="Center" Width="500px">
                    <div>
                        <asp:Label ID="Label15" runat="server" Text="Envío de Documentos"
                            Font-Size="12pt" Font-Underline="True" Font-Names="Arial" ForeColor="#6699ff"></asp:Label>
                        <table style="width: 80%;">
                            <tr>
                                <td></td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style5">
                                    <asp:Label ID="lblOficina" runat="server" Text="Oficina:" Font-Names="Arial" Font-Size="9pt"></asp:Label>
                                </td>
                                <td align="left" class="auto-style5">
                                    <asp:DropDownList ID="ddlOficina" runat="server" Width="150px" Font-Names="Arial" Font-Size="9pt"  OnTextChanged="ddlFuncionario_TextChanged"  AutoPostBack="true">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2"></td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style5">
                                    <asp:Label ID="lblCite" runat="server" Text="CITE Documento:" Font-Names="Arial" Font-Size="9pt"></asp:Label>
                                </td>
                                <td align="left" class="auto-style5">
                                    <asp:TextBox runat="server" ID="txtCite" Font-Names="Arial" Font-Size="9pt" MaxLength="30"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtCite" ErrorMessage="RequiredFieldValidator" ValidationGroup="ValEnvio" setfocusonerror="true"
                                        Font-Size="9pt" Font-Names="Arial">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2"></td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style5">
                                    <asp:Label ID="lblFechaCite" runat="server" Text="Fecha del CITE:" Font-Names="Arial" Font-Size="9pt"></asp:Label>
                                </td>
                                <td align="left" class="auto-style5">
                                   <asp:TextBox ID="txtFechaCITE" runat="server" Width="100px" MaxLength="10"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtFechaCITE" ErrorMessage="RequiredFieldValidator" ValidationGroup="ValEnvio" Font-Size="9pt" Font-Names="Arial" setfocusonerror="true">*</asp:RequiredFieldValidator>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" Enabled="True" FilterType="Numbers,Custom " TargetControlID="txtFechaCITE" ValidChars="/">
                                    </cc1:FilteredTextBoxExtender>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtFechaCITE" Display="Dynamic" ErrorMessage="dd/mm/aaaa" ValidationExpression="^([\d]{2})/([\d]{2})/([\d]{4})$" ValidationGroup="ValEnvio" Font-Size="9pt" Font-Names="Arial" setfocusonerror="true">
                                      </asp:RegularExpressionValidator>
                                   <%--<asp:ImageButton ID="imgCalendario1" runat="server" ImageUrl="~/Imagenes/pequeños/Calendar_32x32.png" Height="20px" Width="20px" />--%>
                                    <cc1:CalendarExtender ID="CalendarExtender8" runat="server" Enabled="True" Format="dd/MM/yyyy" PopupButtonID="txtFechaCITE" 
                                    TargetControlID="txtFechaCITE" CssClass="cal_Theme1"></cc1:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2"></td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style5">
                                    <asp:Label ID="lblFechaEnvio" runat="server" Text="Fecha de Envío:" Font-Names="Arial" Font-Size="9pt"></asp:Label>
                                </td>
                                <td align="left" class="auto-style5">
                                   <asp:TextBox ID="txtFechaEnvio" runat="server" Width="100px" MaxLength ="10"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtFechaEnvio" ErrorMessage="RequiredFieldValidator" ValidationGroup="ValEnvio" Font-Size="9pt" Font-Names="Arial" setfocusonerror="true">*</asp:RequiredFieldValidator>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" Enabled="True" FilterType="Numbers,Custom " TargetControlID="txtFechaEnvio" ValidChars="/">
                                    </cc1:FilteredTextBoxExtender>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtFechaEnvio" Display="Dynamic" ErrorMessage="dd/mm/aaaa" ValidationExpression="^([\d]{2})/([\d]{2})/([\d]{4})$" ValidationGroup="ValEnvio" Font-Size="9pt" Font-Names="Arial" setfocusonerror="true">
                                      </asp:RegularExpressionValidator>
                                    <asp:CompareValidator id="cvtxtStartDate" runat="server" controltocompare="txtFechaCITE" 
                                        cultureinvariantvalues="true" display="Dynamic" 
                                        enableclientscript="true" controltovalidate="txtFechaEnvio"
                                        errormessage="La fecha de envìo no puede ser menor a la fecha del CITE"
                                         type="Date" setfocusonerror="true" operator="GreaterThanEqual" text="La fecha de envìo no puede ser menor a la fecha del CITE" ValidationGroup="ValEnvio" Font-Size="9pt" Font-Names="Arial" />
                                   <%--<asp:ImageButton ID="imgCalendario" runat="server" ImageUrl="~/Imagenes/pequeños/Calendar_32x32.png" Height="20px" Width="20px" />--%>
                                    <cc1:CalendarExtender ID="CalendarExtender9" runat="server" Enabled="True" Format="dd/MM/yyyy" PopupButtonID="txtFechaEnvio" 
                                    TargetControlID="txtFechaEnvio" CssClass="cal_Theme1"></cc1:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2"></td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style5">
                                    <asp:Label ID="lblFuncionario" runat="server" Text="Funcionario:" Font-Names="Arial" Font-Size="9pt" Visible="true"></asp:Label>
                                </td>
                                <td align="left" class="auto-style5">
                                    <asp:DropDownList ID="ddlFuncionario" runat="server" Width="150px" Visible="true" Font-Names="Arial" Font-Size="9pt">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Font-Names="Arial" Font-Size="9pt" 
                                        ControlToValidate="ddlOficina" ErrorMessage="RequiredFieldValidator" ValidationGroup="ValEnvio" setfocusonerror="true">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2"></td>
                            </tr>
                                <td align="right" class="auto-style5" valign="top">
                                    <asp:Label ID="lxlObs1" runat="server" Text="Observación:" Font-Names="Arial" Font-Size="9pt"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtObsEnv" runat="server" TextMode="MultiLine" Rows="5" Columns="30"></asp:TextBox>
                                </td>
                            <tr>
                                <td></td>
                                <td align="left"><asp:Button ID="btnCancelarEnvio" runat="server" EnableTheming="True" OnClick="btnCancelarEnvio_Click"
                                         Text="Cancelar"
                                        CssClass="boton150" />
                                
                                    <asp:Button ID="btnAccionarEnvio" runat="server"
                                        Text="Aceptar" CssClass="boton150" OnClick="btnEnviar_Click" CausesValidation="true" ValidationGroup="ValEnvio"/>
                                    <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender6" runat="server" TargetControlID="btnAccionarEnvio" ConfirmText="¿Esta seguro de guardar el Envío?"> 
                                    </cc1:ConfirmButtonExtender>
                                </td>
                            </tr>
                        </table>
                    </div>
                </asp:Panel>
                <cc1:RoundedCornersExtender ID="pnlEnvio_RoundedCornersExtender" runat="server"
                    Enabled="True" TargetControlID="pnlEnvio" Radius="10" BorderColor="Black">
                </cc1:RoundedCornersExtender>
                <cc1:ModalPopupExtender ID="pnlTipoCambio_ModalPopupExtender" runat="server"
                    Enabled="True"
                    TargetControlID="btnPrueba"
                    CancelControlID="btnCancelarEnvio"
                    PopupControlID="pnlEnvio"
                    BackgroundCssClass="modalBackground">
                </cc1:ModalPopupExtender>
            </td>
            </tr>
            <tr><td align="center" colspan="6"><asp:Button ID="btnEnviar" runat="server" Text="Enviar" OnClick="btnEnviar_Click1" style="height: 26px" CausesValidation="false"></asp:Button></td>
                
            </tr>
            <tr><td align="center" colspan="6"><asp:Button ID="btnPrueba" runat="server" Text="Enviar" OnClick="btnEnviar_Click" style="display:none"></asp:Button></td>
                
            </tr>
                </table>
                   </div>
               </ContentTemplate>
           </cc1:TabPanel>
           <%--Tab4--%>
           <cc1:TabPanel runat="server" ID="TabPanel3" HeaderText="Registrar Recepcion">
               <ContentTemplate>
                   <div>
                       <table id="Table2" runat="server" align="center">
                     <tr>
                         <td width="100%" align="center" colspan="7">
                            <asp:GridView ID="GridView1" runat="server" CellPadding="4" 
                                Font-Names="Arial" 
                                 Font-Size="9pt" 
                                 CssClass="mGrid" ForeColor="#333333" AutoGenerateColumns="False" Visible="False" DataKeyNames="IdTramite,IdGrupoBeneficio,FechaDocumento,NroDocumento,IdDocumento">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:BoundField DataField="IdTramite" HeaderText="IdTramite" Visible="false"/>
                                    <asp:BoundField DataField="IdGrupoBeneficio" HeaderText="GrupoBeneficio" Visible="false"/>
                                    <asp:BoundField DataField="IdDocumento" HeaderText="IdDocumento" Visible="false"/>
                                    <asp:BoundField DataField="DescripcionDocumento" HeaderText="Documento" />
                                    <asp:BoundField DataField="FechaDocumento" HeaderText="Fecha del Documento" />
                                    <asp:BoundField DataField="NroDocumento" HeaderText="Nro de Documento" />
                                    <asp:BoundField DataField="CiteDescripcion" HeaderText="CITE" />
                                    <asp:BoundField DataField="FechaCite" HeaderText="Fecha del CITE" />
                                    <asp:BoundField DataField="FechaEnvio" HeaderText="Fecha de Envío" />
                                    <asp:BoundField DataField="FechaRecepcion" HeaderText="Fecha Recepción" />
                                    <asp:TemplateField ControlStyle-Height="16" ItemStyle-Width="5px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                <HeaderTemplate>
                                                <asp:CheckBox ID="chkTodos" runat="server" onclick = "checkAll(this);"  Visible="true"/>
                                            </HeaderTemplate>    
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkRecepcion" runat="server" Visible="true"/>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    <div align="center" class="CajaDialogoAdvertencia">
                                    <br/>
                                    <img src="../Imagenes/warning.gif" alt="No existen pagos que correspondan al criterio especificado" />
                                    <br/>No existen Documentos para recepcinonar<br/><br/>
                                    </div>
                                </EmptyDataTemplate>
                                <EditRowStyle BackColor="#999999" />
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#0066CC" Font-Bold="True" ForeColor="#CCFFFF" />
                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                            </asp:GridView>
                        </td>
                     </tr>
<tr><td colspan="6" align="left"><asp:LinkButton runat="server" Text="VER ULTIMA RECEPCION" ID="lnkRecepcion" OnClick="UltimaRecepcion"></asp:LinkButton></td></tr>
     <tr>
                <td width="100%" align="left" colspan="7">
                    <asp:GridView ID="gvUltRecepcion" runat="server" CellPadding="4" 
                        Font-Names="Arial" 
                        Font-Size="9pt" 
                        CssClass="mGrid"
                        ForeColor="#333333" AutoGenerateColumns="False" Visible="False" DataKeyNames="">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:BoundField DataField="TipoDocumento" HeaderText="Documento" />
                                    <asp:BoundField DataField="FechaDocumento" HeaderText="Fecha del Documento" />
                                    <asp:BoundField DataField="NroDocumento" HeaderText="Nro de Documento" />
                                    <asp:BoundField DataField="FechaRegistroSistema" HeaderText="Fecha de Registro" />
                                    <asp:BoundField DataField="CiteDescripcion" HeaderText="CITE" />
                                    <asp:BoundField DataField="FechaCite" HeaderText="Fecha del CITE" />
                                    <asp:BoundField DataField="FechaEnvio" HeaderText="Fecha de Envío" />
                                    <asp:BoundField DataField="FechaRecepcion" HeaderText="Fecha Recepción" />
                                </Columns>
                                <EmptyDataTemplate>
                                    <div align="center" class="CajaDialogoAdvertencia">
                                    <br/>
                                    <img src="../Imagenes/warning.gif" alt="No existen pagos que correspondan al criterio especificado" />
                                    <br/>No existen datos que correspondan al criterio especificado<br/><br/>
                                    </div>
                                </EmptyDataTemplate>
                                <EditRowStyle BackColor="#999999" />
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#0066CC" Font-Bold="True" ForeColor="#CCFFFF" />
                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                            </asp:GridView></td>
            </tr>
            <tr align="center">

                <td align="center" colspan="6">

                <asp:Panel ID="pnlRecepcionar" runat="server" CssClass="panelceleste"  HorizontalAlign="Center" Width="500px">
                    <div>
                        <asp:Label ID="lblRecepcion" runat="server" Text="Recepcionar Documento(s)"
                            Font-Size="12pt" Font-Underline="True" Font-Names="Arial" ForeColor="#6699ff"></asp:Label>
                        <table style="width: 80%;">
                           
                           
                            <tr>
                                <td colspan="2"></td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style5">
                                    <asp:Label ID="lblFechaRecepcion" runat="server" Text="Fecha de Recepcion:" Font-Names="Arial" Font-Size="9pt"></asp:Label>

                                   <asp:TextBox ID="txtFechaRecepcion" runat="server" Width="100px" Font-Names="Arial" Font-Size="9pt" MaxLength="10"></asp:TextBox>
                                   <cc1:FilteredTextBoxExtender ID="txtFecNotificacion_FilteredTextBoxExtender1" 
                                        runat="server" FilterType="Numbers,Custom"
                                        TargetControlID="txtFechaRecepcion" ValidChars="/">
                                    </cc1:FilteredTextBoxExtender>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtFechaRecepcion" ErrorMessage="RequiredFieldValidator" ValidationGroup="ValRecepcion" Font-Size="9pt" Font-Names="Arial" SetFocusOnError="true">*</asp:RequiredFieldValidator>
                                   <%--<asp:ImageButton ID="imgCalendario1" runat="server" ImageUrl="~/Imagenes/pequeños/Calendar_32x32.png" Height="20px" Width="20px" />--%>
                                    <cc1:CalendarExtender ID="CalendarExtender10" runat="server" Enabled="True" Format="dd/MM/yyyy" PopupButtonID="txtFechaRecepcion" 
                                    TargetControlID="txtFechaRecepcion" CssClass="cal_Theme1"></cc1:CalendarExtender>
                                </td>
                            </tr>
                            
                            <tr>
                                <td></td>
                            </tr>
                                                        <tr>
                                <td></td>
                            </tr>
                            <tr>
                                <td align="center"><asp:Button ID="btnCancelarRecepcion" runat="server" EnableTheming="True"
                                         Text="Cancelar"
                                        CssClass="boton150" CausesValidation="false" />
                                
                                    <asp:Button ID="btnAccionarRecepcion" runat="server"
                                        Text="Aceptar" CssClass="boton150" OnClick="btnAccionarRecepcion_Click" CausesValidation="true" ValidationGroup="ValRecepcion"/>
                                    <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender5" runat="server" TargetControlID="btnAccionarRecepcion" ConfirmText="¿Esta seguro de guardar la Recepción?"> 
                                    </cc1:ConfirmButtonExtender>
                                </td>
                            </tr>
                        </table>

                    </div>
                </asp:Panel>
                <cc1:RoundedCornersExtender ID="pnlRecepcion_RoundedCornersExtender" runat="server"
                    Enabled="True" TargetControlID="pnlRecepcionar" Radius="10" BorderColor="Black">
                </cc1:RoundedCornersExtender>
                <cc1:ModalPopupExtender ID="pnlREcepcion_ModalPopupExtender" runat="server"
                    Enabled="True"
                    TargetControlID="lnkPop"
                    CancelControlID="btnCancelarRecepcion"
                    PopupControlID="pnlRecepcionar"
                    BackgroundCssClass="modalBackground">
                </cc1:ModalPopupExtender>
            </td>
            </tr>
            <tr><td align="center" colspan="6">
                <asp:ImageButton ID="imgbtnRecepcionar" runat="server" ToolTip="Registar Recepcion de Documentos" ImageUrl="~/Imagenes/ZVarios/notificar.png" Width="50px" Height="50px" OnClick="imgbtnRecepcionar_Click" Visible="false" CausesValidation="false">
                </asp:ImageButton>
                </td>
            </tr>

            <tr><td align="center" colspan="6">
                <asp:Button ID="lnkPop" runat="server" Text="MRLBJE" style="display:none"></asp:Button>
                </td>
            </tr>
                </table>
                   </div>
               </ContentTemplate>
           </cc1:TabPanel>
           <%--Tab5--%>
           <cc1:TabPanel runat="server" ID="TabPanel4" HeaderText="Registrar Devolucion">
               <ContentTemplate>
                   <div>
                   <table id="Table3" runat="server" align="center">
                     <tr>
                         <td width="100%" align="center" colspan="7">
                            <asp:GridView ID="gvDevoluciones" runat="server" CellPadding="4" 
                                Font-Names="Arial" 
                                 Font-Size="9pt" 
                                 CssClass="mGrid" ForeColor="#333333" AutoGenerateColumns="False" Visible="False" DataKeyNames="IdTramite,IdGrupoBeneficio,IdDocumento,FechaDocumento,NroDocumento">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:BoundField DataField="IdTramite" HeaderText="IdTramite" Visible="false"/>
                                    <asp:BoundField DataField="IdGrupoBeneficio" HeaderText="GrupoBeneficio" Visible="false"/>
                                    <asp:BoundField DataField="IdDocumento" HeaderText="IdDocumento" Visible="false"/>
                                    <asp:BoundField DataField="DescripcionDocumento" HeaderText="Documento" />
                                    <asp:BoundField DataField="FechaDocumento" HeaderText="Fecha del Documento" />
                                    <asp:BoundField DataField="NroDocumento" HeaderText="Nro de Documento" />
                                    <asp:BoundField DataField="CiteDescripcion" HeaderText="CITE" />
                                    <asp:BoundField DataField="FechaCite" HeaderText="Fecha del CITE" />
                                    <asp:BoundField DataField="FechaEnvio" HeaderText="Fecha de Envío" />
                                    <asp:BoundField DataField="FechaRecepcion" HeaderText="Fecha Recepción" />
                                    <asp:TemplateField ControlStyle-Height="16" ItemStyle-Width="5px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                <HeaderTemplate>
                                                <asp:CheckBox ID="chkTodos" runat="server" onclick = "checkAll(this);"  Visible="true"/>
                                            </HeaderTemplate>    
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkDevolucion" runat="server" Visible="true"/>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    <div align="center" class="CajaDialogoAdvertencia">
                                    <br/>
                                    <img src="../Imagenes/warning.gif" alt="No existen pagos que correspondan al criterio especificado" />
                                    <br/>No existen Documentos para devolución<br/><br/>
                                    </div>
                                </EmptyDataTemplate>
                                <EditRowStyle BackColor="#999999" />
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#0066CC" Font-Bold="True" ForeColor="#CCFFFF" />
                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                            </asp:GridView>
                        </td>
                     </tr>
     <tr>
                <td width="100%" align="left" colspan="7">
                    <asp:LinkButton runat="server" ID="lnkUltDev" Text="ULTIMOS DOCUMENTOS DEVUELTOS" OnClick="lnkmas_Click"></asp:LinkButton></td>
            </tr>
            <tr>
                <td width="100%" align="center" colspan="7">
                    <asp:GridView ID="gvDevolucion" runat="server" 
                        Font-Names="Arial" 
                        Font-Size="9pt" 
                          CssClass="mGrid"
                        CellPadding="4" ForeColor="#333333" AutoGenerateColumns="False" Visible="False" DataKeyNames="">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:BoundField DataField="TipoDocumento" HeaderText="Documento" />
                                    <asp:BoundField DataField="FechaDocumento" HeaderText="Fecha del Documento" />
                                    <asp:BoundField DataField="NroDocumento" HeaderText="Nro de Documento" />
                                    <asp:BoundField DataField="FechaRegistroSistema" HeaderText="Fecha de Registro" />
                                    <asp:BoundField DataField="CiteDescripcion" HeaderText="CITE" />
                                    <asp:BoundField DataField="FechaCite" HeaderText="Fecha del CITE" />
                                    <asp:BoundField DataField="FechaEnvio" HeaderText="Fecha de Envío" />
                                    <asp:BoundField DataField="CiteDev" HeaderText="Cite DEvolución" />
                                    <asp:BoundField DataField="FecCiteDev" HeaderText="Fecha CITE de Devolución" />
                                </Columns>
                                <EmptyDataTemplate>
                                    <div align="center" class="CajaDialogoAdvertencia">
                                    <br/>
                                    <img src="../Imagenes/warning.gif" alt="No existen pagos que correspondan al criterio especificado" />
                                    <br/>No existen datos que correspondan al criterio especificado<br/><br/>
                                    </div>
                                </EmptyDataTemplate>
                                <EditRowStyle BackColor="#999999" />
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#0066CC" Font-Bold="True" ForeColor="#CCFFFF" />
                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                            </asp:GridView></td>
            </tr>
            <tr align="center">

                <td align="center" colspan="6">

                <asp:Panel ID="PanelDevolucion" runat="server" CssClass="panelceleste"  HorizontalAlign="Center" Width="500px">
                    <div>
                        <asp:Label ID="Label3" runat="server" Text="Devolver Documento(s)"
                            Font-Size="12pt" Font-Underline="True" Font-Names="Arial" ForeColor="#6699ff"></asp:Label>
                        <table style="width: 80%;">
                           
   
                            <tr>
                                <td colspan="2"></td>
                            </tr>

                              <tr>
                                <td align="right" class="auto-style5">
                                    <asp:Label ID="lblCiteDev" runat="server" Text="CITE de Devolución:" Font-Names="Arial" Font-Size="9pt"></asp:Label>
                                </td><td align="left" class="auto-style5">
                                   <asp:TextBox ID="txtCiteDev" runat="server" Font-Names="Arial" Font-Size="9pt" MaxLength="30"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtCiteDev" ErrorMessage="RequiredFieldValidator" ValidationGroup="ValDevolucion" Font-Size="9pt" Font-Names="Arial"  SetFocusOnError="true">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>

                            <tr>
                                <td></td>
                            </tr>

                            <tr>
                                <td align="right" class="auto-style5">
                                    <asp:Label ID="lblFechaCiteDev" runat="server" Text="Fecha CITE de Devolución:" Font-Names="Arial" Font-Size="9pt"></asp:Label>
                                </td>
                                <td align="left"  class="auto-style5">
                                   <asp:TextBox ID="txtFEchaCiteDev" runat="server" Font-Names="Arial" Font-Size="9pt"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtFEchaCiteDev" ErrorMessage="RequiredFieldValidator"
                                        ValidationGroup="ValDevolucion" Font-Size="9pt" Font-Names="Arial"  SetFocusOnError="true">*</asp:RequiredFieldValidator>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender12" 
                                        runat="server" FilterType="Numbers,Custom"
                                        TargetControlID="txtFEchaCiteDev" ValidChars="/">
                                    </cc1:FilteredTextBoxExtender>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" ValidationGroup="ValDevolucion" runat="server" ControlToValidate="txtFEchaCiteDev" Display="Dynamic" ErrorMessage="dd/mm/aaaa" ValidationExpression="^([\d]{2})/([\d]{2})/([\d]{4})$" SetFocusOnError="true"
                                        Font-Size="9pt" Font-Names="Arial">
                                      </asp:RegularExpressionValidator>
                                   <%--<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Imagenes/pequeños/Calendar_32x32.png" Height="20px" Width="20px" />--%>
                                    <cc1:CalendarExtender ID="CalendarExtender11" runat="server" Enabled="True" Format="dd/MM/yyyy" PopupButtonID="txtFEchaCiteDev" 
                                    TargetControlID="txtFEchaCiteDev" CssClass="cal_Theme1"></cc1:CalendarExtender>
                                </td>
                            </tr>

                            <tr>
                                <td></td>
                            </tr>
                              <tr>
                                <td align="right" class="auto-style5">
                                    <asp:Label ID="lblFechaDevolucion" runat="server" Text="Fecha Devolución:" Font-Names="Arial" Font-Size="9pt"></asp:Label>
                                </td>
                                <td align="left"  class="auto-style5">
                                   <asp:TextBox ID="txtFechaDevolucion" runat="server" Font-Names="Arial" Font-Size="9pt"></asp:TextBox>
                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtFechaDevolucion" ErrorMessage="RequiredFieldValidator"
                                       ValidationGroup="ValDevolucion" Font-Size="9pt" Font-Names="Arial"  SetFocusOnError="true">*</asp:RequiredFieldValidator>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender13" 
                                        runat="server" FilterType="Numbers,Custom"
                                        TargetControlID="txtFechaDevolucion" ValidChars="/">
                                    </cc1:FilteredTextBoxExtender>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator7" ValidationGroup="ValDevolucion" runat="server" ControlToValidate="txtFechaDevolucion" Display="Dynamic" ErrorMessage="dd/mm/aaaa" ValidationExpression="^([\d]{2})/([\d]{2})/([\d]{4})$"  SetFocusOnError="true"
                                        Font-Size="9pt" Font-Names="Arial">
                                      </asp:RegularExpressionValidator>
                                   <%--<asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Imagenes/pequeños/Calendar_32x32.png" Height="20px" Width="20px" />--%>
                                    <cc1:CalendarExtender ID="CalendarExtender12" runat="server" Enabled="True" Format="dd/MM/yyyy" PopupButtonID="txtFechaDevolucion" 
                                    TargetControlID="txtFechaDevolucion" CssClass="cal_Theme1"></cc1:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style5" valign="top">
                                    <asp:Label ID="lblObs1" runat="server" Text="Observación:" Font-Names="Arial" Font-Size="9pt"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtObsEnvio" runat="server" TextMode="MultiLine" Rows="5" Columns="30"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right"  class="auto-style5"><asp:Button ID="btnCancelarDevolucion" runat="server" EnableTheming="True"
                                         Text="Cancelar"
                                        CssClass="boton150" CausesValidation="false"/>
                                </td>
                                <td align="center"  class="auto-style5">
                                    <asp:Button ID="btnDevolucion" runat="server"
                                        Text="Aceptar" CssClass="boton150" OnClick="btnAccionarDevolucion_Click" ValidationGroup="ValDevolucion" CausesValidation="true" />
                                    <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender4" runat="server" TargetControlID="btnDevolucion" ConfirmText="¿Esta seguro de guardar la Devolución"> 
                                    </cc1:ConfirmButtonExtender>
                                </td>
                            </tr>
                        </table>

                    </div>
                </asp:Panel>
                <cc1:RoundedCornersExtender ID="RoundedCornersExtender3" runat="server"
                    Enabled="True" TargetControlID="PanelDevolucion" Radius="10" BorderColor="Black">
                </cc1:RoundedCornersExtender>
                <cc1:ModalPopupExtender ID="pnlDevolver_ModalPopupExtender" runat="server"
                    Enabled="True"
                    TargetControlID="lnbShow"
                    CancelControlID="btnCancelarDevolucion"
                    PopupControlID="PanelDevolucion"
                    BackgroundCssClass="modalBackground">
                </cc1:ModalPopupExtender>
            </td>
            </tr>
            <tr><td align="center" colspan="6">
                <asp:ImageButton ID="imgbtnDevolver" runat="server" ToolTip="Registar Devolución de Documentos" ImageUrl="~/Imagenes/ZVarios/Reporte2.png" Width="50px" Height="50px" Visible="false" OnClick="imgbtnDevolver_Click" CausesValidation="false">
                </asp:ImageButton>
                </td>
            </tr>
            <tr><td colspan="6"><asp:LinkButton ID="lnbShow" runat="server" style="display:none"></asp:LinkButton></td></tr>
                </table>

                   </div>
               </ContentTemplate>
           </cc1:TabPanel>
       </cc1:TabContainer>
         <table>
               <tr>
                <td colspan="6" align="left">
                    <asp:HiddenField runat="server" ID="Tram"/>
                    <asp:HiddenField runat="server" ID="gruBen"/>
                    <asp:HiddenField runat="server" ID="FechaDoc"/>
                    <asp:HiddenField runat="server" ID="NroDoc"/>
                    <asp:HiddenField runat="server" ID="IdDoc"/>
                    <asp:HiddenField runat="server" ID="Direccion"/>
                    <asp:HiddenField runat="server" ID="IdOfNot"/>
                </td>
            </tr>
         </table>
    <!-- AQUI VA EL CODIGO-->

</asp:Content>

<asp:Content ID="Content3" runat="server" contentplaceholderid="head">
    <style type="text/css">
        #Table1 {
            margin-right: 0px;
        }
    </style>
</asp:Content>


