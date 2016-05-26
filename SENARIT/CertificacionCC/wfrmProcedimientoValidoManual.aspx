<%@ page title="" language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" CodeFile="wfrmProcedimientoValidoManual.aspx.cs" inherits="CertificacionCC_wfrmProcedimientoValidoManual" theme="Modal" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">         
    <style type="text/css">
        .auto-style1 {
            height: 55px;
        }
        .auto-style3 {
            height: 34px;
        }
        .auto-style4 {
            width: 210px;
        }
    .auto-style5 {
        height: 34px;
        width: 126px;
    }
    .auto-style8 {
        height: 34px;
        width: 109px;
    }
    .auto-style9 {
        height: 55px;
        width: 109px;
    }
    .auto-style10 {
        width: 109px;
    }
    .auto-style11 {
        width: 301px;
    }
        .auto-style12 {
            width: 113px;
        }
        .auto-style13 {
            width: 101px;
        }
        .auto-style14 {
            width: 107px;
        }
        .auto-style15 {
            width: 102px;
        }
        .auto-style16 {
            width: 98px;
        }
        .auto-style17 {
            width: 77px;
        }
    </style>
    <script type="text/javascript" language="javascript">
        function checkDate(sender, args) {

            var hoy = new Date();
            dia = hoy.getDate();
            mes = hoy.getMonth() + 1;
            anio = hoy.getFullYear();
            //ifecha = string(sender._selectedDate);
            fecha_actual = String(anio + "/" + mes + "/" + dia);
            fecha_act = new Date(fecha_actual);
            alert(fecha_actual+'-'+fecha_act+'-'+sender._selectedDate);
            if (sender._selectedDate < fecha_act) {
                alert("¡Usted no puede seleccionar una fecha pasada");
                document.getElementById('<%=txtPeriodoSalario.ClientID %>').value = "";
            }
        }
         </script>
    <script language="javascript" type="text/javascript">
        function fnAceptar() {
            //alert('El Contenido del TextBox es: ' + document.getElementById("txtNombre").value);
            alert('La Aprobación se realizo con exito');
           
        }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:TextBox ID="TextBox1" runat="server" Visible="false"></asp:TextBox>
            <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Imagenes/16calendario.png"  Visible="false"/>
            <cc1:CalendarExtender ID="CalendarExtender3" runat="server" PopupButtonID="ImageButton1" TargetControlID="TextBox1" ></cc1:CalendarExtender>
    <div class="FondoAplicacion">
        <table width="100%" border="0" cellpadding="false" cellspacing="false">
            <tr>
                <td width="30%">
                    <asp:Label ID="lblTituloSistema" runat="server" Font-Bold="True" ForeColor="Navy" Text="CERTIFICACION DE SALARIO AUTOMATICO"></asp:Label>
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
     <asp:Panel ID="description_HeaderPanel" runat="server" style="cursor: pointer;">
        <div class="heading">
           <asp:ImageButton ID="Description_ToggleImage" runat="server"  ImageUrl="~/Imagenes/collapse.jpg"   Enabled="false"/>
            <asp:Label ID="lblDatosAsegurado" runat="server" Text="Label" Font-Bold="True" ForeColor="#CC0000" Font-Size="17px"></asp:Label>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlDatosAsegurado" runat="server">
    <table style="width:100%;">
        <tr>
            <td>
                <asp:HiddenField ID="hfIdTramite" runat="server" />
                <asp:HiddenField ID="hfIdGrupoBeneficio" runat="server" />
                <asp:HiddenField ID="hfVersion" runat="server" />
                </td>
        </tr>
        <tr>
            <td>
                <table style="width:100%;" border="1" cellpadding="0" cellspacing="0" class="mTable">
                    <tr>
                        <td align="center" >
                            <asp:Label ID="lblPaterno" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td align="center" >
                            <asp:Label ID="lblMaterno" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td align="center" >
                            <asp:Label ID="lblNombres" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th align="center" >PATERNO</th>
                        <th align="center" >MATERNO</th>
                        <th align="center" >NOMBRES</th>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
               
                <table style="width:100%;" border="1" cellpadding="0" cellspacing="0"  class="mTable">
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
                        <th align="center" >DOC.IDENTIDAD</th>
                        <th align="center" >FECHA NACIMIENTO</th>
                        <th align="center" >FECHA FALLECIMIENTO</th>
                        <th align="center" >ESTADO CIVIL</th>
                        <th align="center" >REGIONAL</th>
                    </tr>
                 
                </table>
               
            </td>
        </tr>
        <tr>
            <td align="center">
               
                <table style="width:100%;" border="1" cellpadding="0" cellspacing="0" class="mTable">
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
                        <th align="center" >MATRICULA</th>
                        <th align="center" >CUA</th>
                        <th align="center" >TRAMITE</th>
                        <th align="center">FECHA INICIO<asp:Label ID="lblFechaAsignacion" runat="server" Text="Label" Visible="false"></asp:Label></th>
                    </tr>
                    </table>
               
                <br />
                <br />
               
            </td>
        </tr>

    </table>
        </asp:Panel>
    <cc1:CollapsiblePanelExtender ID="cpeDesc" runat="Server"
        TargetControlID="pnlDatosAsegurado"        
        ExpandControlID="description_HeaderPanel"
        CollapseControlID="description_HeaderPanel"
        TextLabelID="lblDatosAsegurado"
        CollapsedText="Datos del Asegurado"
        Collapsed="True"
        ImageControlID="description_ToggleImage"  
        CollapsedImage="~/Imagenes/collapse.jpg"
        ExpandedImage="~/Imagenes/expand.jpg"        
        ExpandedText="Cerrar contenido"
        ExpandDirection="Vertical"/> 
    <div align="left">
        <div align="right">
             <asp:HiddenField ID="hfEstadoTramite" runat="server" />
                       
                        <asp:Label ID="lblTipoReproceso" runat="server" Text="Label" Font-Bold="True" ForeColor="#FF3300" Visible="false"></asp:Label>            
                        

                        <asp:Label ID="lblEstadoTramite" runat="server" Text="Label" Font-Bold="True" ForeColor="#FF3300" Visible="false"></asp:Label>            
              
                        <asp:ImageButton ID="imgVolver" runat="server"  ImageUrl="~/Imagenes/32Volver.png" ToolTip="Volver a la Página anterior" OnClick="btnVolver2_Click" /> 

        </div>
     <table> 
         
          <td style="border-style: outset" align="center" bgcolor="White" valign="middle" >               
                        <asp:ImageButton ID="btnInsertarCertificacion" runat="server"  ImageUrl="~/Imagenes/nueva3/nuevo32.png"  ToolTip="Nueva Certificación" OnClick="btnInsertarCertificacion_Click"  Visible="false"/>
                        <br />
              <asp:Label ID="lblInsertarCertificacion" runat="server" Text="Empresas para el Componente" Font-Bold="True"></asp:Label>
              </td>
          <td style="border-style: outset" align="center" bgcolor="White" valign="middle" >               
                        <asp:ImageButton ID="btnReprobar" runat="server"  ImageUrl="~/Imagenes/nueva3/rechazacertificacion32.png"  ToolTip="Rechaza Certificación" OnClick="btnRechaza_Click" OnClientClick="return confirm('Esta seguro de reprobar el tramite?');" />
                        <br />
              <asp:Label ID="lblReprobar" runat="server" Text="Rechazar Certificación" Font-Bold="True"></asp:Label>
              </td>
          <td style="border-style: outset" align="center" bgcolor="White" valign="middle" >               
                        <asp:ImageButton ID="btnAprobar" runat="server"  ImageUrl="~/Imagenes/nueva3/apruebacertificacion32.png"  ToolTip="Aprobar Certificación" OnClick="btnAprobar_Click" OnClientClick="return confirm('Esta seguro de la aprobación del tramite?');"/>
              <br />
              <asp:Label ID="lblAprobar" runat="server" Text="Aprobar Certificación" Font-Bold="True"></asp:Label>
              </td>
          <td style="border-style: outset" align="center" bgcolor="White" valign="middle" >               
                        <asp:ImageButton ID="btnApruebaCertificacion" runat="server"  ImageUrl="~/Imagenes/nueva3/apruebacertificacion32.png"  ToolTip="Aprobacion Final" OnClick="btnApruebaCertificacion_Click" />
              <br />
              <asp:Label ID="lblApruebaCertificacion" runat="server" Text="Aprobar Certificación" Font-Bold="True"></asp:Label>
              </td>
          <td style="border-style: outset" align="center" bgcolor="White" valign="middle" >               
                        <asp:ImageButton ID="btnImpresionCertificacion" runat="server"  
                             ImageUrl="~/Imagenes/nueva3/certificacionsalario32.png"  
                             ToolTip="Ver Certificación" onclick="btnImpresionCertificacion_Click" CausesValidation="false" />
              <br />
              <asp:Label ID="lblImpresionCertificacion" runat="server" Text="Impresión Certificación" Font-Bold="True" Visible="false"></asp:Label>
              </td>
          <td style="border-style: outset" align="center" bgcolor="White" valign="middle" >               
                        <asp:ImageButton ID="btnImprimeCorrelativo" runat="server"  
                             ImageUrl="~/Imagenes/nueva3/imprimecorrelativo32.png"  
                             ToolTip="Imprimir Correlativo" onclick="btnImprimeCorrelativo_Click" CausesValidation="false" visible="false"/>
              <br />
              <asp:Label ID="lblImprimeCorrelativo" runat="server" Text="Impresión Correlativo" Font-Bold="True" Visible="false"></asp:Label>
              </td>
          <td style="border-style: outset" align="center" bgcolor="White" valign="middle" >               
                        <asp:ImageButton ID="btnIngresarInforme" runat="server"  ImageUrl="~/Imagenes/verdeImprimir.png" ToolTip="Adicionar Informe" OnClick="btnAdicionarInforme_Click" />                        
              <br />
              <asp:Label ID="lblIngresarInforme" runat="server" Text="Agregar Informe" Font-Bold="True"></asp:Label>
              </td>
         <%-- <td style="border-style: outset" align="right" bgcolor="White" valign="middle">               
                        <asp:ImageButton ID="btnTraObservado" runat="server"  ImageUrl="~/Imagenes/nueva3/observado.png" ToolTip="Adicionar Informe" OnClick="btnTraObservado_Click" />                        
              </td>--%>
          
                    </tr>
                    </table>
        </div>
    <%--<cc1:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="cal_Theme1" Format="MM/yyyy" PopupButtonID="imgcalendarioinicio" TargetControlID="txtPeriodoSalario">
                    </cc1:CalendarExtender>--%>
    <asp:Panel ID="pnlComponentesOld" runat="server">
    <table style="width: 100%;" align="center">
        <tr>
            <td align="center">
              
                 <asp:GridView ID="gvDatos" runat="server"             
                        AllowPaging="True" PageSize="15"
                        AutoGenerateColumns="False" 
                        OnPageIndexChanging="gvDatos_PageIndexChanging"
                        EnableTheming="True" 
                        Font-Names="Arial" 
                        Font-Size="9pt" 
                        CssClass="mGrid"
                        PagerStyle-CssClass="pgr"
                        AlternatingRowStyle-CssClass="alt"
                        GridLines="None"
                        DataKeyNames="IdTramite,IdGrupoBeneficio,Version,RUC,Componente,IdTipoDocSalario,TipoDocSalario,PeriodoSalario,SalarioCotizable,IdMonedaSalario,EstadoSalario,EstadoSalarioDet,IdParametrizacion,IdEstadoComponente"  
                        OnRowDataBound="gvDatos_RowDataBound"   OnRowCommand="gvDatos_RowCommand"    >
                          
                            <Columns>                                
                                <asp:BoundField DataField="Componente" HeaderText="Componente"  />
                                <asp:BoundField DataField="Version" HeaderText="Version"  />
                                <asp:BoundField DataField="RUC" HeaderText="RUC"  />
                                <asp:BoundField DataField="Empresa" HeaderText="Razon Social"  />
                                <%--<asp:BoundField DataField="Componente" HeaderText="Componente"  />--%>
                                <asp:BoundField DataField="TipoDocSalario" HeaderText="TipoDoc Salario"  />
                                <asp:BoundField DataField="PeriodoSalario" HeaderText="Periodo Salario"/>
                                <asp:BoundField DataField="SalarioCotizable" HeaderText="Salario Cotizable" >
                                <HeaderStyle Width="40px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Moneda" HeaderText="Moneda" />
                                <asp:BoundField DataField="EstadoSalarioDet" HeaderText="Estado Salario" />                                             
                              <asp:TemplateField HeaderText="Certificar" Visible="false">
                                  
                                    <ItemTemplate>
                                        <center>   
                                                                                                                       
                                        <asp:ImageButton ID="imgCertificar" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdCertificar" ImageUrl="~/imagenes/nueva3/siguiente32.png" ToolTip="Certificar Salario" OnClientClick="return confirm('Esta seguro de la operación que realizara?');" />
                                        

                                            
                                        
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
                </td>           
        </tr>
        <tr>
            <td>&nbsp;</td>            
        </tr>
   
      
    </table>
        </asp:Panel> 
     <asp:Panel ID="pnlComponentesNew" runat="server">
    <table style="width: 100%;" align="center">
        <tr>
            <td align="center">
                 Certificacion del Tramite<br />
                 <br />
                
                 <asp:GridView ID="gvDatosComponentes" runat="server"             
                        AllowPaging="True" PageSize="15"
                        AutoGenerateColumns="False" 
                        OnPageIndexChanging="gvDatos_PageIndexChanging"
                        EnableTheming="True" 
                        Font-Names="Arial" 
                        Font-Size="9pt" 
                        CssClass="mGrid"
                        PagerStyle-CssClass="pgr"
                        AlternatingRowStyle-CssClass="alt"
                        GridLines="None"
                        DataKeyNames="IdTramite,IdGrupoBeneficio,Version,RUC,Componente,IdTipoDocSalario,TipoDocSalario,PeriodoSalario,SalarioCotizable,IdMonedaSalario,EstadoSalario,EstadoSalarioDet,IdParametrizacion,GlosaSalario,Certificado,EstadoComponente,IdEstadoComponente,SalarioCotizableActualizado,DensidadAportes"  
                        OnRowCommand="gvDatosComponentes_RowCommand" OnRowDataBound="gvDatosComponentes_RowDataBound" 
                       >
                          
                            <Columns>                                
                                <asp:BoundField DataField="Componente" HeaderText="Componente" />
                                <asp:BoundField DataField="Version" HeaderText="Version"  />                                
                                <asp:BoundField DataField="RUC" HeaderText="RUC"  />
                                <asp:BoundField DataField="Empresa" HeaderText="Razon Social">
                                    <HeaderStyle Width="80px" />
                                    </asp:BoundField >
                                <%--<asp:BoundField DataField="Componente" HeaderText="Componente"  />--%>
                                <asp:BoundField DataField="TipoDocSalario" HeaderText="TipoDoc Salario"  >
                                    <HeaderStyle Width="100px" />
                                    </asp:BoundField >
                                <asp:BoundField DataField="PeriodoSalario" HeaderText="Periodo Salario">
                                    <HeaderStyle Width="40px" />
                                    </asp:BoundField >
                                <asp:BoundField DataField="SalarioCotizable" HeaderText="Salario Cotizable" >
                                <HeaderStyle Width="40px" />
                                </asp:BoundField>                                
                                <asp:BoundField DataField="SalarioCotizableActualizado" HeaderText="Salario Cotizable Act" >
                                <HeaderStyle Width="40px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DensidadAportes" HeaderText="Densidad" >
                                <HeaderStyle Width="40px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Moneda" HeaderText="Moneda" />
                                <asp:BoundField DataField="EstadoComponente" HeaderText="Estado Salario" />                                             
                                <asp:BoundField DataField="GlosaSalario" HeaderText="Glosa" ItemStyle-Font-Size="7" ItemStyle-HorizontalAlign="Justify">
                                <HeaderStyle Width="300px" />
                                </asp:BoundField>
                              <asp:TemplateField HeaderText="Editar - Eliminar">
                                    <ItemTemplate>
                                        <center>                                                                                
                                        <asp:ImageButton ID="imgEditar" width="20px" height="20px" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdEditar" ImageUrl="~/imagenes/nueva3/editar32.png"  ToolTip="Editar Certificación"/>
                                        <asp:ImageButton ID="imgEliminar" width="20px" height="20px" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdEliminar" ImageUrl="~/imagenes/nueva3/eliminar32.png" ToolTip="Eliminar Certificación" OnClientClick="return confirm('Esta seguro de eliminar la certificación?');"/>
                                        
                                             </center>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Certi" ItemStyle-Width="50px">
                                <ItemTemplate>
                                    <center>
                                        <asp:ImageButton ID="imgCerti" width="20px" height="20px" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdCerti" ImageUrl="~/Imagenes/nueva3/certificacionsalario32.png" ToolTip="Editar Salario Cotizable" />
                                        <asp:ImageButton ID="imgCertificacionSalarioCorrelativo"  width="20px" height="20px" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdCertificacionSalarioCorrelativo" ImageUrl="~/imagenes/nueva3/qr.png" ToolTip="Reporte Certificacion de Salarios" />
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
                </td>           
        </tr>
        
      
    </table>
        </asp:Panel>  
    <asp:Panel ID="pnlFormularioModifica" runat="server" CssClass="panelceleste" Width="100%">                
        <asp:Panel ID="pnlBusqueda" runat="server" Visible="false">
        <table style="width: 100%" align="center" visible="false">
            <tr>
                <td align="right" width="10%">&nbsp;</td>
                <td align="right" width="30%">
                    <asp:Label ID="Label1" runat="server" Text="Label" >Busqueda Razon Social:</asp:Label></td>
                <td align="left" width="60%">
                    <asp:TextBox ID="txtDescripcionRUC" runat="server" Width="500px" OnTextChanged="txtDescripcionRUC_TextChanged" ></asp:TextBox>
                     <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" enabled="True"
                                servicepath="~/BuscarRazonSocial.asmx" minimumprefixlength="2" servicemethod="wsBuscarRazonSocial"
                                enablecaching="true" targetcontrolid="txtDescripcionRUC" usecontextkey="True" completionsetcount="10"
                                completioninterval="200" >
                    </cc1:AutoCompleteExtender>
                    &nbsp;</td>
            </tr>
            </table>
        </asp:Panel>
            
        <table style="width: 100%" align="center">            
            <tr>
                <td align="right" class="auto-style8">
                    <asp:CheckBox runat="server" Text="Editar" ID="chkRuc" AutoPostBack="True" OnCheckedChanged="chkRuc_CheckedChanged"   />
                    &nbsp;==&gt;</td>
                <td align="right" class="auto-style3">RUC:</td>
                <td align="left" class="auto-style3">
                    <asp:TextBox ID="txtRUC" runat="server" autofocus="autofocus" ReadOnly="true"  onfocus="selecciona_value(this)"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtRUC" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                </td>
                <td align="left" class="auto-style3"></td>
                <td align="left" class="auto-style3"></td>
            </tr>
            <tr>
                <td align="right" class="auto-style9"></td>
                <td align="right" class="auto-style1">Detalle RUC:</td>
                <td align="left" class="auto-style1">
                    <asp:TextBox ID="txtDetRUC" runat="server" ReadOnly="true" Width="405px" onfocus="selecciona_value(this)"></asp:TextBox>
                </td>
                <td align="left" class="auto-style1">&nbsp;</td>
                <td align="left" class="auto-style1">
                    
                </td>
            </tr>
            <tr>
                <td align="right" class="auto-style9">&nbsp;</td>
                <td align="right" class="auto-style1">Sector: </td>
                <td align="left" class="auto-style1">
                    <asp:TextBox ID="txtSector" runat="server" Visible="False"></asp:TextBox>
                    <asp:TextBox ID="txtDescripcionSector" runat="server" ></asp:TextBox>
                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" enabled="True"
                                servicepath="~/BuscarSector.asmx" minimumprefixlength="2" servicemethod="wsBuscarSector"
                                enablecaching="true" targetcontrolid="txtDescripcionSector" usecontextkey="True" completionsetcount="10"
                                completioninterval="200" >
                    </cc1:AutoCompleteExtender>


                </td>
                <td align="left" class="auto-style1">&nbsp;</td>
                <td align="left" class="auto-style1">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" class="auto-style10">&nbsp;</td>
                <td align="right">Tipo Documento Presentado:&nbsp;</td>
                <td align="left">
                    <asp:DropDownList ID="ddlTipoDocumento" runat="server">
                    </asp:DropDownList>
                </td>
                <td align="left">&nbsp;</td>
                <td align="left">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" valign="top" class="auto-style10">&nbsp;</td>
                <td align="right" valign="top">&nbsp;</td>
                <td align="left">
                    <asp:CheckBox ID="chbCertificado" runat="server" Text="Certificado" AutoPostBack="True" OnCheckedChanged="chbCertificado_CheckedChanged" Checked="True"  Enabled="false"/>
                </td>
                <td align="left">&nbsp;</td>
                <td align="left">&nbsp;</td>
            </tr>
            <tr >
                <td align="right" class="auto-style10">&nbsp;</td>
                <td align="right">
                    <%--<cc1:MaskedEditExtender ID="meePeriodoSalario" runat="server" TargetControlID="txtPeriodoSalario" Mask="99/9999" MaskType="None" ClearTextOnInvalid="False" UserDateFormat="None" />--%>
        
        



                    Periodo Salario:</td>
                <td align="left">
                    <asp:TextBox ID="txtPeriodoSalario" runat="server"  MaxLength="7" OnTextChanged="txtPeriodoSalario_TextChanged" AutoPostBack="True"   ></asp:TextBox>
                     
                    <%--<cc1:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="cal_Theme1" Format="MM/yyyy" PopupButtonID="imgcalendarioinicio" TargetControlID="txtPeriodoSalario">
                    </cc1:CalendarExtender>--%>
                    <%--<cc1:MaskedEditExtender ID="meePeriodoSalario" runat="server" TargetControlID="txtPeriodoSalario" Mask="99\/9999" MaskType="None" ClearTextOnInvalid="false"  />--%>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="error en formato" ValidationExpression="((0[1-9]|1[012])[ /](19[012345678][0-9]|19[9][012345]))|((0[1-9]|1[0])[ /](1996))|((0[1-9]|1[012])[/](1[0-9]|2[0-9]|3[0-9]|4[0-9]|5[0-9]|6[0-9]|7[0-9]|8[0-9]|9[0-9]))|((0[1-9]|1[0])[ /](96))" ControlToValidate="txtPeriodoSalario">El periodo del salario no debe ser mayor a Oct/96</asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPeriodoSalario" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                </td>
                    <%--<cc1:MaskedEditValidator ID="MaskedEditValidator5" runat="server"
             ControlExtender="meePeriodoSalario"
            ControlToValidate="txtPeriodoSalario"
            EmptyValueMessage="Date is required"
            InvalidValueMessage="Date is invalid"
            Display="Dynamic"
           TooltipMessage="Input a date"
            EmptyValueBlurredText="*"
            InvalidValueBlurredMessage="*"
            ValidationGroup="MKE" />--%>

                <td align="left">&nbsp;</td>
                <td align="left">&nbsp;</td>

            </tr>
            <tr>
                <td align="right" class="auto-style10">&nbsp;</td>
                <td align="right">
                   <%-- <cc1:MaskedEditExtender runat="server" TargetControlID="txtSalarioCotizable" Mask="999,999.99"  InputDirection = "RightToLeft" AcceptNegative="Left"  />--%>
                    &nbsp;</td>
                <td align="left">
                    <table><tr><td style="TEXT-ALIGN: left" class="auto-style11"><asp:RadioButton ID="rdbCertSalMin" 
                runat="server" GroupName="aplica" Text="Salario Minimo" AutoPostBack="True" 
                oncheckedchanged="rdbCertSalMin_CheckedChanged" /></td></tr>                 
                 <tr><td style="TEXT-ALIGN: left" class="auto-style11"><asp:RadioButton ID="rdbCertDS29537" 
                         runat="server" GroupName="aplica" Text="D.S. 29537 - D.S. 822 Art. 74" 
                         AutoPostBack="True" oncheckedchanged="rdbCertDS29537_CheckedChanged" /></td></tr>
                 <tr><td style="TEXT-ALIGN: left" class="auto-style11"><asp:RadioButton ID="rdbCertNormal" runat="server" 
                         GroupName="aplica" Text="Normal" AutoPostBack="True" 
                         oncheckedchanged="rdbCertNormal_CheckedChanged" Checked="True" /></td></tr>                 
</table>
                    </td>
                <td align="left">&nbsp;</td>
                <td align="left">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" class="auto-style10">
                    <asp:CheckBox ID="chkSalarioCotizable" runat="server" AutoPostBack="True" OnCheckedChanged="chkSalarioCotizable_CheckedChanged" Text="Editar" />
                    &nbsp;==&gt;</td>
                <td align="right"><%-- <cc1:MaskedEditExtender runat="server" TargetControlID="txtSalarioCotizable" Mask="999,999.99"  InputDirection = "RightToLeft" AcceptNegative="Left"  />--%>Salario Cotizable:</td>
                <td align="left">
                    <asp:TextBox ID="txtSalarioCotizable" runat="server" onChange="redondeo2decimales(this.id)" onfocus="selecciona_value(this)" onkeyup="validadecimal(this.id)" OnTextChanged="txtSalarioCotizable_TextChanged" ReadOnly="true" AutoPostBack="True"></asp:TextBox>
                    <cc1:FilteredTextBoxExtender ID="txtSalarioCotizable_Filtro" runat="server" Enabled="True" FilterType="Custom, Numbers" TargetControlID="txtSalarioCotizable" ValidChars=".">
                    </cc1:FilteredTextBoxExtender>
                    <%-- <cc1:MaskedEditExtender runat="server" TargetControlID="txtSalarioCotizable" Mask="999,999.99"  InputDirection = "RightToLeft" AcceptNegative="Left"  />--%><%--<cc1:FilteredTextBoxExtender ID="TxtTelefono_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Custom, Numbers" 
TargetControlID="txtSalarioCotizable" ValidChars=",">
</cc1:FilteredTextBoxExtender>--%><%--<cc1:MaskedEditExtender ID="meeDecimales" runat="server" TargetControlID="txtSalarioCotizable" Mask="$999,999.00"--%><%--MaskType="Number" InputDirection="RightToLeft" />    --%>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtSalarioCotizable" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                </td>
                <td align="left">&nbsp;</td>
                <td align="left">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" class="auto-style10">&nbsp;</td>
                <td align="right">Salario Cotizable Actualizado:</td>
                <td align="left">
                    <asp:TextBox ID="txtSalarioCotizableActualizado" runat="server" ReadOnly="true"></asp:TextBox>
                </td>
                <td align="left">&nbsp;</td>
                <td align="left">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" class="auto-style10">&nbsp;</td>
                <td align="right">Moneda Salario:</td>
                <td align="left">
                    <asp:DropDownList ID="ddlMonedaSalario" runat="server">
                    </asp:DropDownList>
                </td>
                <td align="left">&nbsp;</td>
                <td align="left">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" class="auto-style10">&nbsp;</td>
                <td align="right">Parametrizacion:</td>
                <td align="left">
                    <asp:DropDownList ID="ddlParametrizacion" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlParametrizacion_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td align="left">&nbsp;</td>
                <td align="left">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" valign="top" class="auto-style10">&nbsp;</td>
                <td align="right" valign="top">Glosa Salario:</td>
                <td align="left">
                    <asp:TextBox ID="txtGlosaSalario" runat="server" Style="text-transform: uppercase" TextMode="multiline" Columns="50" Rows="5"  onfocus="selecciona_value(this)"></asp:TextBox>
                    <%--<CKEditor:CKEditorControl ID="txtGlosaSalario" runat="server" Height="100px" Width="700px"  ToolbarStartupExpanded="false"></CKEditor:CKEditorControl>--%>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtGlosaSalario" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                </td>
                <td align="left">&nbsp;</td>
                <td align="left">&nbsp;</td>
            </tr>
            
            <tr>
                <td align="right" valign="top" class="auto-style10">&nbsp;</td>
                <td align="right" valign="top">&nbsp;</td>
                <td align="left">
                    <asp:HiddenField ID="hdfOperacion" runat="server" />
                </td>
                <td align="left">&nbsp;</td>
                <td align="left">&nbsp;</td>
            </tr>
            <tr>
                <td align="center" valign="top" colspan="3">
                    <asp:Button ID="btnInsertar" runat="server" OnClick="btnInsertar_Click" Text="Guardar Certi." Width="100px" OnClientClick="return confirm('Esta seguro de registrar la certificación?');"/>
                    <asp:Button ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" Text="Cancelar" CausesValidation="false" />
    
                </td>
                <td align="center" valign="top">&nbsp;</td>
                <td align="center" valign="top">&nbsp;</td>
            </tr>
        </table>

    </asp:Panel>
    <%--Lista componentes registrados en certificacion--%>
   
      <asp:Panel ID="pnlInformes" runat="server" >
        <div align="center">
            <asp:Label ID="lblTituloInformes" runat="server" Text="Lista Informes" style="font-weight: 700"></asp:Label>
            <br /><br />
            <div style="font-size: small; color: #0000FF;" align="left">* El registro del informe se encuentra en color naranja cuando el informe se encuentra LEVANTADO<br />
                   <br /> 
                    

        </div>
            <br />
        
           <asp:GridView ID="gvDatosInformes" runat="server"
                AllowPaging="True" PageSize="15"
                AutoGenerateColumns="False"
                EnableTheming="True"
                Font-Names="Arial"
                Font-Size="9pt"
                CssClass="mGrid"
                PagerStyle-CssClass="pgr"
                AlternatingRowStyle-CssClass="alt"
                GridLines="None"
                DataKeyNames="IdTramite,IdGrupoBeneficio,NroControl,Informe,Verificador,Revisor,FechaInforme,IdRolRevisor,RegistroActivo,IdUsuarioRegistro,NroCrenta,IdTipoInforme,TipoInforme,EstadoRegistro"
                OnRowCommand="gvDatosInformes_RowCommand"
                OnRowDataBound="gvDatosInformes_RowDataBound">

                <Columns>
                    <asp:BoundField DataField="IdTramite" HeaderText="Tramite" />
                    <asp:BoundField DataField="NroControl" HeaderText="Nro de Control" Visible="true" />
                    <asp:BoundField DataField="TipoInforme" HeaderText="Tipo Informe" Visible="true" />
                    <asp:BoundField DataField="FechaInforme" HeaderText="Fecha del Informe" />
                    <asp:BoundField DataField="Verificador" HeaderText="Login Ver." />
                    <asp:BoundField DataField="Revisor" HeaderText="Login Rev." />
                    <asp:BoundField DataField="EstadoRegistro" HeaderText="Estado" />
                    <asp:TemplateField HeaderText="Actividad">
                        <ItemTemplate>
                            <center>
                                <asp:Button ID="imgEditar" runat="server" Text="Editar" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdEditar"  ToolTip="Editar Informe" alt="Editar Informe" />
                                <asp:Button ID="imgLevantar" runat="server" Text="Levantar" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdLevantar"  ToolTip="Levantar Informe" alt="Levantar Informe" OnClientClick="return confirm('Esta seguro de levantar el informe?');" />
                                <asp:Button ID="imgEliminar" runat="server" Text="Eliminar" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdEliminar"  ToolTip="Eliminar Informe" alt="Eliminar Informe" OnClientClick="return confirm('Esta seguro de eliminar el informe?');" />
                                

                                <asp:Button ID="imgVer" runat="server" Text="Imprimir" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdVer" ImageUrl="~/imagenes/32TramiteAcepta.gif" ToolTip="Visualilzar Informe" alt="Visualizar Informe" />
                                
                            </center>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <div align="center" class="CajaDialogoAdvertencia">
                        <br />
                        <img src="../Imagenes/warning.gif"
                            alt="No existen datos que correspondan al criterio especificado" />
                        <br />
                        No existen datos que correspondan al criterio especificado
                                <br />
                        <br />
                    </div>
                </EmptyDataTemplate>
                <SelectedRowStyle BackColor="#FFFF99" />
            </asp:GridView>
        </div>
    </asp:Panel>
        <asp:Panel ID="pnlEditarInforme" runat="server" Visible="false" HorizontalAlign="Center">
    <asp:Label ID="Label2" runat="server" Text="Informe del tramite" style="font-weight: 700"></asp:Label>
    <br />
            <div align="center">
        <asp:RadioButtonList ID="rbTipoInforme" runat="server">
            <asp:ListItem Value="1">Observado</asp:ListItem>
            <asp:ListItem Value="2">Certificado</asp:ListItem>

        </asp:RadioButtonList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="rbTipoInforme">Seleccione una opción</asp:RequiredFieldValidator>
            </div>
    <%--<CKEditor:CKEditorControl ID="ckeInforme" runat="server"></CKEditor:CKEditorControl>--%>
            <asp:TextBox ID="ckeInforme" runat="server" Columns="50" Height="238px" onfocus="selecciona_value(this)" Rows="5" Style="text-transform: uppercase" TextMode="multiline" Width="702px"></asp:TextBox>
    <br />
    
            <asp:Button ID="btnActualizar" runat="server" Text="Actualizar Informe" OnClick="btnActualizar_Click" Visible="false" />
            <asp:Button ID="btnInsertarInforme" runat="server" Text="Insertar Informe" OnClick="btnIngresarInforme_Click" Visible="false" />
    
&nbsp;<asp:Button ID="btnCancelarInforme" runat="server" OnClick="btnCancelarInforme_Click" Text="Cancelar" CausesValidation="false" />
    <br />
        </asp:Panel>

   
</asp:Content>

