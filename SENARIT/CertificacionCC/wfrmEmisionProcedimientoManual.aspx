<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmEmisionProcedimientoManual.aspx.cs" Inherits="CertificacionCC_wfrmEmisionProcedimientoManual" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">  
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
    <style type="text/css">
        .auto-style5 {
            height: 25px;
        }
        .auto-style6 {
            height: 54px;
        }
        .auto-style7 {
            height: 48px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="FondoAplicacion">
        <table width="100%" border="0" cellpadding="false" cellspacing="false">
            <tr>
                <td width="30%">
                    <asp:Label ID="lblTituloSistema" runat="server" Font-Bold="True" ForeColor="Navy" Text="EMISION CC"></asp:Label>
                </td>
                <td width="70%" align="center">
                    <asp:Label ID="lblTitulo" runat="server" Font-Bold="True" ForeColor="#CC0000" Font-Size="17px" Text="Datos del Asegurado"></asp:Label>
                </td>
                <td align="right">
                    &nbsp;</td>
                <td></td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </div>
    <table style="width:100%;">
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style6">
                <table style="width:100%;" border="1" cellpadding="0" cellspacing="0">
                    <tr>
                        <td align="center" class="auto-style5">
                            <asp:Label ID="lblPaterno" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td align="center" class="auto-style5">
                            <asp:Label ID="lblMaterno" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td align="center" class="auto-style5">
                            <asp:Label ID="lblNombres" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" bgcolor="#CCCCCC">PATERNO</td>
                        <td align="center" bgcolor="#CCCCCC">MATERNO</td>
                        <td align="center" bgcolor="#CCCCCC">NOMBRES</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
               
                <table style="width:100%;" border="1" cellpadding="0" cellspacing="0">
                    <tr>
                        <td align="center">
                            <asp:Label ID="lblDocIdentidad" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:Label ID="lblFechaNacimiento" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:Label ID="lblFechaFallecimiento" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:Label ID="lblEstadoCivil" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:Label ID="lblRegional" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" bgcolor="#CCCCCC">DOC.IDENTIDAD</td>
                        <td align="center" bgcolor="#CCCCCC">FECHA NACIMIENTO</td>
                        <td align="center" bgcolor="#CCCCCC">FECHA FALLECIMIENTO</td>
                        <td align="center" bgcolor="#CCCCCC">ESTADO CIVIL</td>
                        <td align="center" bgcolor="#CCCCCC">REGIONAL</td>
                    </tr>
                 
                </table>
               
            </td>
        </tr>
        <tr>
            <td align="center">
               
                <table style="width:100%;" border="1" cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="auto-style5" align="center">
                            <asp:Label ID="lblMatricula" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td class="auto-style5" align="center">
                            <asp:Label ID="lblCUA" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td class="auto-style5" align="center">
                            <asp:Label ID="lblTramite" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td class="auto-style5" align="center">
                            <asp:Label ID="lblFechaInicio" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" bgcolor="#CCCCCC">MATRICULA</td>
                        <td align="center" bgcolor="#CCCCCC">CUA</td>
                        <td align="center" bgcolor="#CCCCCC">TRAMITE</td>
                        <td align="center" bgcolor="#CCCCCC">FECHA INICIO</td>
                    </tr>
                    </table>
                <table align="center" width="100%">
                     <tr>
                    <td style="border-style: outset" align="right" class="auto-style7">
                        <asp:Label ID="lblTipoReproceso" runat="server" Text="Label" Font-Bold="True" ForeColor="#FF3300" Visible="false"></asp:Label>            
                        <asp:Label ID="lblEstadoTramite" runat="server" Text="Label" Font-Bold="True" ForeColor="#FF3300" Visible="false"></asp:Label>            
                         <asp:TextBox ID="txtFechaCalculo" runat="server"></asp:TextBox>
                        <asp:ImageButton ID="imgVolver" runat="server"  ImageUrl="~/Imagenes/32Volver.png" ToolTip="Volver a la Página anterior" OnClick="btnVolver_Click"  CausesValidation="false"/>
                         <asp:ImageButton ID="btnApruebaCCR" runat="server"  
                             ImageUrl="~/Imagenes/nueva3/apruebacertificacion32.png"  
                             ToolTip="Aprobar Certificación" OnClick="btnAprobar_Click" CausesValidation="false"  />                        
                         <asp:ImageButton ID="btnRechazoCCR" runat="server"  
                             ImageUrl="~/Imagenes/nueva3/rechazacertificacion32.png"  
                             ToolTip="Rechazar Certificación" OnClick="btnConfirmacionRechazo_Click" CausesValidation="false"/>
                         <br />
                        <%-- <asp:ImageButton ID="btnRechazar" runat="server"  
                             ImageUrl="~/Imagenes/nueva3/rechazacertificacion32.png"  
                             ToolTip="Aprobar Certificación" OnClick="btnRechazar_Click" CausesValidation="false" />--%>
                        <asp:Label ID="lblObservaciones" runat="server" BackColor="White" ForeColor="#FF3300" ></asp:Label> 
                &nbsp;<asp:Label ID="lblGeneracion" runat="server" Text="Codigo de Generacion :" Visible="false"></asp:Label>
                <asp:TextBox ID="txtCodGeneracion" runat="server" TextMode="Password" ></asp:TextBox>
                         <asp:ImageButton ID="btnGenerar" runat="server" 
                             ImageUrl="~/Imagenes/nueva3/generar.png" onclick="btnGenerar_Click" 
                              ToolTip="Generar Formulario de Calculo" />
                         <asp:ImageButton ID="btnFormularioMensual" runat="server" 
                             ImageUrl="~/Imagenes/nueva3/imprimirformulariomensual32.png" onclick="btnFormularioMensual_Click" 
                             ToolTip="Imprimir Formulario Mensual" CausesValidation="false" />
                         <asp:ImageButton ID="btnFormularioGlobal" runat="server" 
                             ImageUrl="~/Imagenes/nueva3/imprimirformularioglobal32.png" 
                             ToolTip="Imprimir Formulario Global" onclick="btnFormularioGlobal_Click" CausesValidation="false"/>
                         <asp:ImageButton ID="btnConfirmacion" runat="server"  
                             ImageUrl="~/Imagenes/nueva3/confirmacionimpresionWF32.png"  
                             ToolTip="Confirmación de Impresión"  CausesValidation="false" Visible="false" />
                        
                        <br /></td>
                    </tr>
                    </table>
               
                <br />
                  <asp:GridView ID="gvDatos" runat="server"             
                        AllowPaging="True" PageSize="15"
                        AutoGenerateColumns="False"                         
                        EnableTheming="True" 
                        Font-Names="Arial" 
                        Font-Size="9pt" 
                        CssClass="mGrid"
                        PagerStyle-CssClass="pgr"
                        AlternatingRowStyle-CssClass="alt"
                        GridLines="None"
                        OnRowCommand="gvDatos_RowCommand"
                        DataKeyNames="IdTramite,IdGrupoBeneficio,Version,RUC,Componente,IdTipoDocSalario,TipoDocSalario,PeriodoSalario,SalarioCotizable,IdMonedaSalario,EstadoSalario,EstadoSalarioDet,IdEstadoComponente,Correlativo,SalarioCotizableAct,Densidad,IdTipoTramite"  
                          >
                          
                            <Columns>
                                <asp:TemplateField HeaderText="Certificación">
                                    <ItemTemplate>
                                        <center>                                                                                
                                        <asp:ImageButton ID="imgCertificacionSalario" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdCertificacionSalario" ImageUrl="~/imagenes/nueva3/certificacionsalario32.png" ToolTip="Reporte Certificacion de Salarios" />
                                             </center>
                                    </ItemTemplate>
                                </asp:TemplateField>                                
                                <asp:BoundField DataField="IdTipoTramite" HeaderText="IdTipoTramite" Visible="false" />
                                <asp:BoundField DataField="Componente" HeaderText="Componente"  />
                                <asp:BoundField DataField="Version" HeaderText="Version"  />
                                <asp:BoundField DataField="RUC" HeaderText="RUC"  />
                                <asp:BoundField DataField="Empresa" HeaderText="Razon Social"  />
                                <%--<asp:BoundField DataField="Componente" HeaderText="Componente"  />--%>
                                <asp:BoundField DataField="TipoDocSalario" HeaderText="TipoDoc Salario"  />
                                <asp:BoundField DataField="PeriodoSalario" HeaderText="Periodo Salario"/>
                                <asp:BoundField DataField="SalarioCotizable" HeaderText="Salario Cotizable" />
                                <asp:BoundField DataField="SalarioCotizableAct" HeaderText="Salario Cotizable Act" />                               
                                <asp:BoundField DataField="Densidad" HeaderText="Densidad" />
                                <asp:BoundField DataField="Moneda" HeaderText="Moneda" />
                                <asp:BoundField DataField="TipoCC" HeaderText="Tipo CC" />
                                <asp:BoundField DataField="Correlativo" HeaderText="Correlativo" />
                                <asp:BoundField DataField="EstadoSalarioDet" HeaderText="Estado Salario" />                                                                           
                                <asp:TemplateField ControlStyle-Height="16"  ItemStyle-Width="5px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                                <HeaderTemplate>
                                                <asp:CheckBox ID="chkTodos" runat="server" onclick = "checkAll(this);"  />
                                            </HeaderTemplate>    
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkAprobacion" runat="server" />
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
                <asp:Label ID="Label1" runat="server" Text="Aprobaciones"></asp:Label>
                <br />
                <asp:GridView ID="gvDatosAprobacion" runat="server"  AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="False" CssClass="mGrid" 
                    DataKeyNames="DescripcionRol,EstadoAprobacion,FechaAprueba,Componente,RUC" 
                    EnableTheming="True" Font-Names="Arial" Font-Size="9pt" GridLines="None" PagerStyle-CssClass="pgr"
                    OnRowDataBound="gvDatosAprobacion_RowDataBound" 
                     >
                    <Columns>
                        <asp:BoundField DataField="DescripcionRol" HeaderText="Rol" />
                        <asp:BoundField DataField="Componente" HeaderText="Componente" />
                        <asp:BoundField DataField="RUC" HeaderText="RUC" />
                        <asp:BoundField DataField="EstadoAprobacion" HeaderText="Estado" />                        
                        <asp:BoundField DataField="FechaAprueba" HeaderText="Fecha" />                        
                    </Columns>
                    <EmptyDataTemplate>
                        <div align="center" class="CajaDialogoAdvertencia">
      <br/>
                                <img src="../Imagenes/warning.gif" 
              alt="No existen datos que correspondan al criterio especificado" />
      <br/>No existen datos que correspondan al criterio especificado
                                <br/><br/>
                                               </div>
                    </EmptyDataTemplate>
                    <SelectedRowStyle BackColor="#FFFF99" />
                </asp:GridView>
               
                <br />
                <asp:HiddenField ID="hfIdTramite" runat="server" />
                <asp:HiddenField ID="hfIdGrupoBeneficio" runat="server" />
                <asp:HiddenField ID="hfVersion" runat="server" />
                <asp:HiddenField ID="hfFlagM" runat="server" />
                <asp:HiddenField ID="hfFlagG" runat="server" />
                    <asp:HiddenField ID="hfEstadoTramite" runat="server" />
                <asp:HiddenField ID="hfNoImpresion" runat="server" />
                <asp:HiddenField ID="hfAprobaciones" runat="server" />
 
                <br />
                
 
            </td>

        </tr>
         <tr>
             
                    <td style="border-style: outset" align="center" class="auto-style7">
                        <asp:Panel ID="pnlTransicionWF" runat="server">
                        <%-- <asp:ImageButton ID="btnRechazar" runat="server"  
                             ImageUrl="~/Imagenes/nueva3/rechazacertificacion32.png"  
                             ToolTip="Aprobar Certificación" OnClick="btnRechazar_Click" CausesValidation="false" />--%>
                
               
            
               
                
               
                        <asp:DropDownList ID="ddlListaWF" runat="server"></asp:DropDownList>
                        
               
            
               
                
               
                        <asp:RequiredFieldValidator ID="rfvListaWF" runat="server" ControlToValidate="ddlListaWF" InitialValue="0"  ErrorMessage="*"></asp:RequiredFieldValidator>
                        
               
            
               
                
               
                        <br />
                        <br />
                        <asp:Label ID="lblObservacionTransicion" runat="server" Text="Observacion de la Transicion"></asp:Label>
                        <br />
               <asp:TextBox ID="txtObservacion" runat="server" TextMode="multiline" Columns="50" Rows="5"  onfocus="selecciona_value(this)"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvObservacion" runat="server" ControlToValidate="txtObservacion" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                        <br />
                
               
                        <br />
                        
                <asp:Button ID="btnTransicion" runat="server" OnClick="btnTransicion_Click" Text="Enviar Transicion" />
                
               
            
               
                
               
                        <br />
                            </asp:Panel>
                            </td>
                 
                    </tr>

    </table>
</asp:Content>

