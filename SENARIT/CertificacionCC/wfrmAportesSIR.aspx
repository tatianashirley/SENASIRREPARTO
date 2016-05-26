<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmAportesSIR.aspx.cs" Inherits="CertificacionCC_wfrmAportesSIR" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">         
    <style type="text/css">
        .auto-style3 {
            height: 34px;
        }
        .auto-style4 {
            height: 26px;
        }
        .mGrid {}
        .auto-style6 {
            height: 27px;
        }
        .auto-style7 {
            width: 50%;
        }
        .auto-style8 {
            height: 21px;
        }
        .auto-style9 {
            width: 157px;
        }
        .auto-style12 {
            width: 106px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:TextBox ID="TextBox1" runat="server" Visible="false"></asp:TextBox>
            <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Imagenes/16calendario.png"  Visible="false"/>
            <cc1:CalendarExtender ID="CalendarExtender3" runat="server" PopupButtonID="ImageButton1" TargetControlID="TextBox1" ></cc1:CalendarExtender>
    <div class="FondoAplicacion">
        <table width="100%" border="0" cellpadding="false" cellspacing="false">
            <tr>
                <td class="auto-style7" align="center">
                    <asp:Label ID="lblTituloSistema" runat="server" Font-Bold="True" ForeColor="Navy" Text="CERTIFICACION DE SALARIO PROCEDIMIENTO MANUAL"></asp:Label>
                </td>
               
            </tr>
        </table>
    </div>
    
    <asp:Panel ID="description_HeaderPanel" runat="server" style="cursor: pointer;">
        <div class="heading">
            <asp:ImageButton ID="Description_ToggleImage" runat="server"  ImageUrl="~/Imagenes/collapse.jpg"  Enabled="false" />
            <asp:Label ID="lblDatosAsegurado" runat="server" Text="Label" Font-Bold="True" ForeColor="#CC0000" Font-Size="17px"></asp:Label>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlDatosAsegurado" runat="server"  >
    <table style="width:100%;">
        <tr>
            <td>
                &nbsp;</td>
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
                        <td  align="center">
                            <asp:Label ID="lblMatricula" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td align="center" >
                            <asp:Label ID="lblCUA" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td align="center" >
                            <asp:Label ID="lblTramite" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td align="center" >
                            <asp:Label ID="lblFechaInicio" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th align="center" class="auto-style8" >MATRICULA</th>
                        <th align="center" class="auto-style8" >CUA</th>
                        <th align="center" class="auto-style8" >TRAMITE</th>
                        <th align="center" class="auto-style8">FECHA INICIO</th>
                    </tr>
                    </table>


              
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

   <asp:Panel ID="Panel2" runat="server">
       <div align="left">
        <table> <tr>
                     <td style="border-style: outset" align="center" >
                        <asp:ImageButton ID="btnInsertarSalarioCotizable" runat="server" 
                             ImageUrl="~/Imagenes/nueva3/nuevo32.png" onclick="btnInsertarSalarioCotizable_Click" 
                            ToolTip="Agregar Razon Social" CausesValidation="false"/>
                         <br />
                         <asp:Label ID="lblEmpresas" runat="server" Text="Empresas para el Componente" Font-Bold="True"></asp:Label>
                       </td>
                       <td style="border-style: outset" align="center" >
                          <asp:ImageButton ID="btnGuardaCert" runat="server" 
                             ImageUrl="~/Imagenes/nueva3/adicioncertificacion32.png" 
                             ToolTip="Adicionar Aporte" onclick="btnGuardaCert_Click" />
                           <br />
                           <asp:Label ID="lblAportes" runat="server" Text="Registro de Aporte(s)" Font-Bold="True"></asp:Label>
                       </td>
                       <td style="border-style: outset" align="center">
                            <asp:ImageButton ID="btnVerCabecera" runat="server" 
                             ImageUrl="~/Imagenes/nueva3/ver32.png" onclick="btnVerCabecera_Click" ToolTip="Ver Cabecera" CausesValidation="false"/> 
                           <br />
                            <strong>Ver Salario(s) </strong>
                       </td>
                       <td style="border-style: outset" align="center">
                            <asp:ImageButton ID="btnGeneracion" runat="server" 
                             ImageUrl="~/Imagenes/nueva3/generar.png" onclick="btnGeneracion_Click" 
                              ToolTip="Registrar Salario" OnClientClick="return confirm('Esta seguro de registrar el salario?');"/>  
                           <br />
                           <asp:Label ID="lblSalario" runat="server" Text="Registrar Salario" Font-Bold="True"></asp:Label>
                       </td>            
                    
                 </tr>
                 
               </table>
           </div>
    </asp:Panel>
   

    <asp:Panel ID="pnlFormularioModifica" runat="server" CssClass="panelceleste" Width="100%">                
        <asp:Panel ID="pnlBusqueda" runat="server" Visible="false">
        <table style="width: 100%" align="center" visible="false">
            <tr>
                <td colspan="3" align="center">
                    <asp:Label ID="Label2" runat="server" Text="Agregar Empresas Involucradas en la Certificación" Font-Bold="True"></asp:Label> <br /> <br />
                </td>
            </tr>
            <tr>
                <td align="right" width="10%">&nbsp;</td>
                <td align="right" width="30%">
                    Busqueda Razon Social:</td>
                <td align="left" width="60%">
                    <asp:TextBox ID="txtDescripcionRUC" runat="server" Width="500px" OnTextChanged="txtDescripcionRUC_TextChanged" ></asp:TextBox>
                     <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" enabled="True"
                                servicepath="~/BuscarRazonSocial.asmx" minimumprefixlength="2" servicemethod="wsBuscarRazonSocial"
                                enablecaching="true" targetcontrolid="txtDescripcionRUC" usecontextkey="True" completionsetcount="10"
                                completioninterval="200" >
                    </cc1:AutoCompleteExtender>
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center" colspan="3">
                    <asp:GridView ID="gvDatosRuc" runat="server"             
                        AllowPaging="True" PageSize="5"
                        AutoGenerateColumns="False"                         
                        EnableTheming="True" 
                        Font-Names="Arial" 
                        Font-Size="9pt" 
                        CssClass="mGrid"
                        PagerStyle-CssClass="pgr"
                        AlternatingRowStyle-CssClass="alt"
                        GridLines="None" Width="636px"
                        DataKeyNames="RUC,Descripcion,Sector"  
                        OnRowCommand="gvDatosRuc_RowCommand"
                        
                       >
                          
                            <Columns>                                                                
                                <asp:BoundField DataField="RUC" HeaderText="RUC"  />
                                <asp:BoundField DataField="Descripcion" HeaderText="Razon Social"  />                                                                                                
                                <asp:BoundField DataField="Sector" HeaderText="Sector" />    
                                                                                                                                   
                              <asp:TemplateField HeaderText="Eliminar" >                                  
                                    <ItemTemplate>
                                        <center>                                                                                                                        
                                        <asp:ImageButton ID="imgEliminarRuc" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdEliminar" ImageUrl="~/imagenes/nueva3/eliminar32.png" ToolTip="Eliminar Registro" />
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
            <tr><td colspan="3"><hr width="90%"/></td></tr>
            <tr><td colspan="3" align="right">
                <asp:ImageButton ID="btnSiguiente" runat="server"  ImageUrl="~/Imagenes/nueva3/siguiente32.png"  OnClick="btnSiguiente_Click" ToolTip="Agregar Aporte" /><br />
                Adicionar Aporte(s)
                </td></tr>
            <tr>
                <td align="right" class="auto-style3">
                    &nbsp;</td>
                <td align="right" class="auto-style3">&nbsp;</td>
                <td align="left" class="auto-style3">
                    &nbsp;</td>
                <td align="left" class="auto-style3"></td>
                <td align="left" class="auto-style3"></td>
            </tr>
            </table>
        </asp:Panel>
            <a name="arriba"></a>
<div align="left"><a href="#abajo">Ir a la parte de abajo</a></div>
    <asp:Panel ID="pnlComponentesNew" runat="server">
    <table style="width: 100%;" align="center">
        <tr>
            <td align="center">
                <asp:Label ID="Label3" runat="server" Text=" Certificacion del Tramite" Font-Bold="True"></asp:Label><br />
                 <asp:Label ID="lblNumeroComponente" runat="server" Font-Bold="True" Text="Label" Visible="False"></asp:Label>
                 <br />
                 <br />
                
                 <asp:GridView ID="gvDatosComponentes" runat="server"
                        AutoGenerateColumns="False"                         
                        EnableTheming="True" 
                        Font-Names="Arial" 
                        Font-Size="9pt" 
                        CssClass="mGrid"
                        PagerStyle-CssClass="pgr"
                        AlternatingRowStyle-CssClass="alt"
                        GridLines="None"
                        DataKeyNames="IdTramite,IdGrupoBeneficio,Version,RUC,NombreEmpresa,DescripcionSector,Componente,FechaAfiliacion,FechaBajaAfilia,IdParametrizacion,GlosaCertificacion,AnioCotiza,MesesCotiza,PeriodoVerificado,Certificado,EstadoSalario"  
                        OnRowCommand="gvDatosComponentes_RowCommand" OnRowDataBound="gvDatosComponentes_RowDataBound" 
                       >
                          
                            <AlternatingRowStyle CssClass="alt" />
                            <Columns>
                                <asp:BoundField DataField="Componente" HeaderText="Comp." ItemStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Version" HeaderText="Version" ItemStyle-HorizontalAlign="Center" Visible="false">
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="RUC" HeaderText="RUC" ItemStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NombreEmpresa" HeaderText="Razon Social" ItemStyle-HorizontalAlign="Center">
                                <HeaderStyle Width="80px" />
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FechaAfiliacion" HeaderText="Afiliacion" ItemStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FechaBajaAfilia" HeaderText="Baja" ItemStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Certificado" HeaderText="Certificado" ItemStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="GlosaCertificacion" HeaderText="Glosa" HtmlEncode="False" HtmlEncodeFormatString="False" ItemStyle-Font-Size="7" ItemStyle-HorizontalAlign="Justify">
                                <HeaderStyle Width="250px" />
                                <ItemStyle Font-Size="7pt" HorizontalAlign="Justify" />
                                </asp:BoundField>
                                <asp:BoundField DataField="AnioCotiza" HeaderText="Año(s)" ItemStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="MesesCotiza" HeaderText="Mes(s)" ItemStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Editar - Eliminar">
                                    <ItemTemplate>
                                        <center>
                                            <asp:ImageButton ID="imgEditar" runat="server" alt="Editar Aporte" CausesValidation="false" CommandArgument="<%#((GridViewRow)Container).RowIndex %>" CommandName="cmdEditar" ImageUrl="~/imagenes/nueva3/editar32.png" ToolTip="Editar Registro" />
                                            <asp:ImageButton ID="imgEliminar" runat="server" alt="Eliminar Aporte" CausesValidation="false" CommandArgument="<%#((GridViewRow)Container).RowIndex %>" CommandName="cmdEliminar" ImageUrl="~/imagenes/nueva3/eliminar32.png" OnClientClick="return confirm('Esta seguro de eliminar el registro?');" ToolTip="Eliminar Registro" />
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
                            <PagerStyle CssClass="pgr" />
                            <SelectedRowStyle BackColor="#FFFF99" />
                        </asp:GridView>
                </td>           
        </tr>
        <tr>
            <td align="center">
                <br />
                <asp:HiddenField ID="hfIdTramite" runat="server" />
                <asp:HiddenField ID="hfIdGrupoBeneficio" runat="server" />
                <asp:HiddenField ID="hfVersion" runat="server" />
                <asp:HiddenField ID="hfRUC" runat="server" />
                <asp:HiddenField ID="hfComponente" runat="server" />
                <asp:HiddenField ID="hfFechaAfiliacion" runat="server" />
            </td>            
        </tr>
      
        <tr>
            <td>&nbsp;</td>
        </tr>
      
    </table>
        </asp:Panel>
      <asp:Panel ID="pnlBotonesInferior" runat="server">
       <%--  <table align="right" width="100%"> <tr>
                     <td style="border-style: outset" align="right">
                         <asp:ImageButton ID="btn1" runat="server" 
                             ImageUrl="~/Imagenes/nueva3/nuevo32.png" onclick="btnInsertarSalarioCotizable_Click" 
                            ToolTip="Agregar Razon Social" CausesValidation="false"/>
                         <asp:ImageButton ID="btn2" runat="server" 
                             ImageUrl="~/Imagenes/nueva3/adicioncertificacion32.png" 
                             ToolTip="Adicionar Aporte" onclick="btnGuardaCert_Click" />
                         <asp:ImageButton ID="ImageButton4" runat="server" 
                             ImageUrl="~/Imagenes/nueva3/ver32.png" onclick="btnVerCabecera_Click" ToolTip="Ver Cabecera" CausesValidation="false"/>
                         <asp:ImageButton ID="btnGeneracion2" runat="server" 
                             ImageUrl="~/Imagenes/nueva3/generar.png" onclick="btnGeneracion_Click" 
                              ToolTip="Registrar Salario" OnClientClick="return confirm('Esta seguro de registrar el salario?');"/>
                         <br /></td>
            
                    
                 </tr>
               </table>--%>
          <asp:Panel ID="pnlBotonesAuxiliares" runat="server" Visible="false">
          <div align="left">
              <table > <tr>
                     <td style="border-style: outset" align="center" class="auto-style9">
                          <asp:ImageButton ID="btn1" runat="server" 
                             ImageUrl="~/Imagenes/nueva3/nuevo32.png" onclick="btnInsertarSalarioCotizable_Click" 
                            ToolTip="Agregar Razon Social" CausesValidation="false"/><br />
                          <strong>Seleccion de Empresas para el Componente </strong>
                       </td>
                       <td style="border-style: outset" align="center" class="auto-style12">
                          <asp:ImageButton ID="btn2" runat="server" 
                             ImageUrl="~/Imagenes/nueva3/adicioncertificacion32.png" 
                             ToolTip="Adicionar Aporte" onclick="btnGuardaCert_Click" /><br />
                           <strong>Registro de Aporte(s) </strong>
                       </td>
                       <td style="border-style: outset" align="center">
                            <asp:ImageButton ID="ImageButton4" runat="server" 
                             ImageUrl="~/Imagenes/nueva3/ver32.png" onclick="btnVerCabecera_Click" ToolTip="Ver Componente(s)" CausesValidation="false"/><br />
                            <strong>Ver Componente(s) </strong>
                       </td>
                       <td style="border-style: outset" align="center">
                             <asp:ImageButton ID="btnGeneracion2" runat="server" 
                             ImageUrl="~/Imagenes/nueva3/generar.png" onclick="btnGeneracion_Click" 
                              ToolTip="Registrar Salario" OnClientClick="return confirm('Esta seguro de registrar el salario?');"/><br />
                           <asp:Label ID="lblSalario2" runat="server" Text="Registrar Salario" Font-Bold="True"></asp:Label>
                       </td>            
                    
                 </tr>
                 
               </table>
              </div>
              </asp:Panel>
    </asp:Panel>   
        
<div align="left"><a href="#arriba">Ir a la parte de arriba</a></div>

        <asp:Panel ID="pnlInsertaDetalle" runat="server" Visible="true"  CssClass="panelprincipal">  
        <table style="width: 100%" align="center">            
            
            <tr>
                <td align="right" class="auto-style6">&nbsp;</td>
                <td align="right" class="auto-style6">
                    <asp:Label ID="lblMenuRazon" runat="server" Text="Razon Social: " Visible="false"></asp:Label>
                    <asp:Label ID="lblRUC" runat="server" Text="RUC:" Visible="false"></asp:Label>
                </td>
                <td align="left" class="auto-style6">
                    <asp:TextBox ID="txtRUC" runat="server" autofocus="autofocus" onfocus="selecciona_value(this)" ReadOnly="true" Visible="false"></asp:TextBox>
                    &nbsp;<asp:DropDownList ID="ddlRazonSocial" runat="server">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" InitialValue="0" runat="server" ErrorMessage="*" ControlToValidate="ddlRazonSocial"></asp:RequiredFieldValidator>
                </td>
                <td align="left" class="auto-style6">&nbsp;</td>
                <td align="left" class="auto-style6">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" class="auto-style6">&nbsp;</td>
                <td align="right" class="auto-style6">
                    <asp:Label ID="lblDescripcionRuc" runat="server" Text="Razon Social:" Visible="false"></asp:Label>
                </td>
                <td align="left" class="auto-style6">
                    <asp:TextBox ID="txtDetRUC" runat="server" onfocus="selecciona_value(this)" ReadOnly="true" Visible="false" Width="405px"></asp:TextBox>
                    &nbsp;<asp:Label ID="lblSector" runat="server" Text="Sector:" Visible="false"></asp:Label>
                    <asp:TextBox ID="txtSector" runat="server" ReadOnly="true" Visible="false"></asp:TextBox>
                </td>
                <td align="left" class="auto-style6">&nbsp;</td>
                <td align="left" class="auto-style6">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" valign="top">&nbsp;</td>
                <td align="right" valign="top">&nbsp;</td>
                <td align="left">
                    <asp:CheckBox ID="chbCertificado" runat="server" Text="Certificado" AutoPostBack="true" OnCheckedChanged="chbCertificado_CheckedChanged" Checked="True" />
                </td>
                <td align="left">&nbsp;</td>
                <td align="left">&nbsp;</td>
            </tr>
            <tr>
                <td align="right">&nbsp;</td>
                <td align="right">Fecha Inicio</td>
                <td align="left">
                    <asp:TextBox ID="txtFechaAfiliacion" AutoPostBack="True" runat="server" MaxLength="7" ReadOnly="false" OnTextChanged="txtFechaAfiliacion_TextChanged"></asp:TextBox>                    
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtFechaAfiliacion" ErrorMessage="error en formato" ValidationExpression="((0[1-9]|1[012])[ /](190[0-9]|191[0-9]|192[0-9]|193[0-9]|194[0-9]|195[0-9]|196[0-9]|197[0-9]|198[0-9]|199[0-6]))|((0[1-5])[ /](1997))|((0[1-9]|1[012])[/](4[0-9]|5[0-9]|6[0-9]|7[0-9]|8[0-9]|9[0-9]))">*</asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFechaAfiliacion"  ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                    Fecha Baja:
                    <asp:TextBox ID="txtFechaBaja" runat="server" AutoPostBack="True" MaxLength="7" OnTextChanged="txtFechaBaja_TextChanged" ReadOnly="false"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtFechaBaja" ErrorMessage="error en formato" ValidationExpression="((0[1-9]|1[012])[ /](190[0-9]|191[0-9]|192[0-9]|193[0-9]|194[0-9]|195[0-9]|196[0-9]|197[0-9]|198[0-9]|199[0-6]))|((0[1-5])[ /](1997))|((0[1-9]|1[012])[/](4[0-9]|5[0-9]|6[0-9]|7[0-9]|8[0-9]|9[0-9]))">*</asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFechaBaja" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
     
                    <asp:HiddenField ID="hfFechaInicioAnt" runat="server" />
                    <asp:HiddenField ID="hfFechaBajaAnt" runat="server" />
     
                </td>
     
                <td align="left">&nbsp;</td>
                <td align="left">&nbsp;</td>
            </tr>
            <tr>
                <td align="right">&nbsp;</td>
                <td align="right">&nbsp;</td>
                <td align="left">
                    <asp:Label ID="Label1" runat="server" Text="Ingresar Fechas en este formato 1)mm/YYYY 2) mm/YY  ej. 01/1992;01/92" Font-Size="Small" ForeColor="#FF3300"></asp:Label>
                    </td>
                <td align="left">&nbsp;</td>
                <td align="left">&nbsp;</td>
            </tr>
            <tr>
                <td align="right">&nbsp;</td>
                <td align="right">&nbsp;</td>
                <td align="left">Años :
                    <asp:Label ID="lblAnios" runat="server"></asp:Label>
                    &nbsp;Meses:
                    <asp:Label ID="lblMeses" runat="server" ></asp:Label>
                    <asp:Label ID="lblMensajeNegativo" runat="server" Text="Label" ForeColor="Red"></asp:Label>
                    <asp:Label ID="lblCooperativa" runat="server" Text="Label" ForeColor="Red"></asp:Label>
                </td>
                <td align="left">&nbsp;</td>
                <td align="left">&nbsp;</td>
            </tr>
            <tr>
                <td align="right">&nbsp;</td>
                <td align="right">Parametrizacion:</td>
                <td align="left">
                    <asp:DropDownList ID="ddlParametrizacion" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlParametrizacion_SelectedIndexChanged" Width="350px">
                    </asp:DropDownList>
                </td>
                <td align="left">&nbsp;</td>
                <td align="left">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" valign="top">&nbsp;</td>
                <td align="right" valign="top">Glosa:</td>
                <td align="left">
                    <asp:TextBox ID="txtGlosaSalario" runat="server" Style="text-transform: uppercase" TextMode="multiline" Columns="50" Rows="5" ></asp:TextBox>
                    
                     <%--<CKEditor:CKEditorControl ID="txtGlosaSalario" runat="server" Height="100px" Width="700px"  ToolbarStartupExpanded="false"></CKEditor:CKEditorControl>--%>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtGlosaSalario"  ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                </td>
                <td align="left">&nbsp;</td>
                <td align="left">&nbsp;</td>
            </tr>
           
            <tr>
                <td align="right" valign="top">&nbsp;</td>
                <td align="right" valign="top">&nbsp;</td>
                <td align="left">
                    <asp:HiddenField ID="hdfOperacion" runat="server" />
                </td>
                <td align="left">&nbsp;</td>
                <td align="left">&nbsp;</td>
            </tr>
            <tr>
                <td align="center" valign="top" colspan="3">
                    &nbsp;<asp:Button ID="btnInsertar" runat="server" OnClick="btnInsertar_Click" Text="Enviar" Width="100px"/>
                    <asp:Button ID="btnCancelar" runat="server" CausesValidation="false" OnClick="btnCancelar_Click" Text="Cancelar" />
                </td>
                <td align="center" valign="top">&nbsp;</td>
                <td align="center" valign="top">&nbsp;</td>
            </tr>
        </table>
             <cc1:ModalPopupExtender ID="pnlFormularioModifica_ModalPopupExtender" runat="server" 
Enabled="True" 
TargetControlID="lblTituloSistema" 
PopupControlID="pnlInsertaDetalle" 
BackgroundCssClass="modalBackground"> 
</cc1:ModalPopupExtender>
<cc1:DragPanelExtender ID="DragPanelExtender1" runat="server"
DragHandleID="pnlInsertaDetalle" TargetControlID="pnlInsertaDetalle" > 
</cc1:DragPanelExtender> 

            </asp:Panel> 

    </asp:Panel>

   <a name="abajo"></a>

   
</asp:Content>

