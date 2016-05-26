<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmSeguimientoObservados.aspx.cs" Inherits="SeguimientoObservados_wfrmSeguimientoObservados" Culture="auto" UICulture="auto" StylesheetTheme="Modal" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        
        .auto-style6 {
            height: 45px;
        }
        .auto-style7 {
            width: 190px;
            height: 45px;
        }
        
        .auto-style9 {
            width: 210px;
        }
        
        .auto-style10 {
            width: 256px;
        }
        
        </style>
  <script type="text/javascript" language="javascript">
    //  function ModalPopup() {

    //    var vpRND = Math.random() * 20;
    //    showModalDialog('\wfrmModalSeguimiento.aspx?Accion=nuevo&rn=' + vpRND, '', 'dialogWidth=850px; dialogHeight=450px; center=yes; scrollbars=no');
    //}

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server" >
    <table  style="width: 100%"  class="panelceleste">
        <tr>
            <td> 
            
            </td>
            <td  align="center" style="width:100%">
                <asp:ImageButton ID="imgAux" runat="server" ImageUrl="~/Imagenes/16w.png" Height="16px" Width="16px"  Visible="false"/>
                <asp:Label ID="lblCodigo1" runat="server" Font-Size="Small" Visible="False"></asp:Label>
                <asp:Label ID="lblCodigo" runat="server" Font-Size="Small" Text="1"
                    Visible="False"></asp:Label>
                <asp:Label ID="lblCodUsuario" runat="server" Font-Size="Small" Text="1"
                    Visible="False"></asp:Label>
                <asp:Label ID="lblRol" runat="server" Font-Size="Small"
                    Style="text-align: left" Text="0" Visible="False"></asp:Label>

            </td>
        </tr>
         <tr>
            <td> 
          <asp:Panel ID="pnlBotones" runat="server" CssClass="panelceleste"  Width="100%" Height="250px" BorderColor="Window">
                    <div>
                        <table style="width: 100%; " >
                            <tr>
                                <td align="center">
                                     <asp:Label ID="lblet" runat="server" CssClass="etiqueta8Red" Text="Revisiones"></asp:Label>
                                    <asp:ImageButton ID="imgRevision" runat="server" Height="40px" ImageUrl="~/Imagenes/32usuariosegui.png"
                                         Width="50px"  ToolTip="Revisiones de Tramite" BorderColor="Red"  BorderWidth="2px" OnClick="imgRevision_Click" />
                                    
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                     <asp:Label ID="lblrep" runat="server" CssClass="etiqueta8Red" Text="Reporte Seguimiento"></asp:Label>
                                       <asp:ImageButton ID="imgReporte" runat="server" Height="40px" ImageUrl="~/Imagenes/32Documento.png" 
                                         Width="50px" ToolTip="Ver Reporte de Seguimiento" BorderColor="Red"  BorderWidth="2px" OnClick="imgReporte_Click" />
                                </td>
                            </tr>
                             <tr>
                                <td align="center">
                                     <asp:Label ID="Label2" runat="server" CssClass="etiqueta8Red" Text="Listado Seguimientos"></asp:Label>
                                       <asp:ImageButton ID="ImageButton1" runat="server" Height="40px" ImageUrl="~/Imagenes/informes.jpg"
                                         Width="50px" ToolTip="Ver Reporte de Listado Seguimiento por fechas" BorderColor="Red"  BorderWidth="2px" OnClick="imgReporteListado_Click" />
                                </td>
                            </tr>

                        </table>
                    </div>
                 </asp:Panel>
            </td>
           <td  >
                <asp:Panel ID="pnlDatos" runat="server" CssClass="panelceleste"
                      Width="100%">
                    <div>
                         <table style="width: 100%;"  >
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lblTitulo" runat="server" CssClass="etiqueta8Blue" Font-Bold="true"   Text="-    DATOS DEL TRÁMITE"></asp:Label>
                                </td>
                                <td align="right" style="width:15%">
                                    &nbsp;</td>
                                <td align="right" style="width:15%">
                                    &nbsp;</td>
                                <td align="right" style="width:15%">
                                    &nbsp;</td>
                                <td align="right" style="width:15%">
                                    &nbsp;</td>
                                <td align="right" style="width:15%">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lblMatricula" runat="server" CssClass="etiqueta8Blue" Text="Matrícula :"></asp:Label>
                                </td>
                                <td align="left" >
                                     <asp:Label ID="lblNrotramite" runat="server" CssClass="etiqueta8Blue" Text="N° Trám. Expediente - Nº Trám. BD :"></asp:Label>
                                </td>
                                <td align="left" >
                                    <asp:Label ID="lblTipotramite" runat="server" CssClass="etiqueta8Blue" Text="Tipo Trámite  :"></asp:Label>
                                </td>
<%--                                <td align="left" >
                                    <asp:Label ID="lblProcedimiento" runat="server" CssClass="etiqueta8Blue" Text="Procedimiento:"></asp:Label>
                                     </td>--%>
                                 <td align="left">
                                     <asp:Label ID="lblFechaInicio" runat="server" CssClass="etiqueta8Blue" Text="Fecha Inicio Trámite:"></asp:Label>
                                 </td>
                                <td align="left" ><asp:Label ID="lblCtdIngresos" runat="server" CssClass="etiqueta8Blue" Text="#INGRESOS AL ÁREA:" Font-Bold="true"></asp:Label></td>
                                <td align="left" ><asp:Label ID="lblRegional" runat="server" CssClass="etiqueta8Blue" Text="Regional Trámite"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:TextBox ID="txtMatricula" runat="server"  Width="124px" ReadOnly="true" Height="16px"></asp:TextBox>
                                </td>
                                <td align="left" >
                                        <asp:TextBox ID="txtTramite" runat="server" Width="162px" ReadOnly="true" Height="16px" ></asp:TextBox>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtTipotramite" runat="server" Width="124px" ReadOnly="true" Height="16px"></asp:TextBox>
                                </td>

                                 <td align="left">
                                     <asp:TextBox ID="txtFechaInicio" runat="server" Width="124px" ReadOnly="true" Height="16px"></asp:TextBox>
                                 </td>
                                <td align="left" >
                                    <asp:TextBox ID="txtNroIngresos" runat="server" Width="50px" ReadOnly="true" Height="16px" Font-Bold="true" ForeColor="Red"></asp:TextBox>
                                </td>
                                <td align="left" ><asp:TextBox ID="txtRegional" runat="server" Width="105px" ReadOnly="true" Height="16px" Font-Bold="true" ForeColor="BLUE"></asp:TextBox></td>
                            </tr>
                            <tr>
                                 <td align="left" >&nbsp;</td>
                            </tr>
                            <tr>
                                <td align="center" style="width:15%">
                                    <asp:Label ID="lblTitulo0" runat="server" CssClass="etiqueta8Blue" Font-Bold="true"  Text="-    DATOS DE LA PERSONA"></asp:Label>
                                </td>
                               
                                <td align="left" style="width:15%" >&nbsp;</td>
                                <td align="left" style="width:15%" >&nbsp;</td>
                                <td align="left" style="width:15%" >&nbsp;</td>
                                <td align="left" style="width:15%">&nbsp;</td>
                                <td align="left" style="width:15%" >&nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label ID="lblApPaterno" runat="server" CssClass="etiqueta8Blue" Text="Ap. Paterno:"></asp:Label>
                                </td>
                                <td align="left" >
                                     <asp:Label ID="lblApMaterno" runat="server" CssClass="etiqueta8Blue"  Text="Ap. Materno:"></asp:Label>
                               </td>
                                <td align="left" >
                                     <asp:Label ID="lblPNombre" runat="server" CssClass="etiqueta8Blue" Text="Primer Nombre:"></asp:Label>
                                  </td>
                                <td align="left">
                                    <asp:Label ID="lblSNombre" runat="server" CssClass="etiqueta8Blue" Text="Segundo Nombre:"></asp:Label>

                                </td>
                                <td align="left">
                                    <asp:Label ID="lblFono" runat="server" CssClass="etiqueta8Blue" Text="Telf./Cel./Tel. Ref.:"></asp:Label>
                                 </td>
                                <td align="left">
                                   
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:TextBox ID="txtApPaterno" runat="server" Width="124px" ReadOnly="true" Height="16px"></asp:TextBox>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtApMaterno" runat="server" Width="124px" ReadOnly="true" Height="16px"></asp:TextBox>
                                    </td>
                                <td align="left" >
                                    <asp:TextBox ID="txtPNombre" runat="server" Width="124px" ReadOnly="true" Height="16px"></asp:TextBox>
                                </td>
                                <td align="left" >
                                    <asp:TextBox ID="txtSNombre" runat="server" Width="124px" ReadOnly="true" Height="16px"></asp:TextBox>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtFono" runat="server" Width="180px" ReadOnly="true" Height="16px"></asp:TextBox>
                                </td>
                                <td align="left">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="left"> 
                                    <asp:Label ID="lblSexo" runat="server" CssClass="etiqueta8Blue"  Text="Sexo:"></asp:Label>

                                </td>
                                <td align="left">
                                    
                                 <asp:Label ID="lblDireccion" runat="server" CssClass="etiqueta8Blue"  Text="Dirección:"></asp:Label>  
                                </td>
                                <td align="left">
  
                                </td>
                                <td align="left">
                                     <asp:Label ID="lblNroDocumento" runat="server" CssClass="etiqueta8Blue" Text="N° Documento:"></asp:Label>
                                </td>
                                  <td align="left">
                                       <asp:Label ID="lblTipoDoc" runat="server" CssClass="etiqueta8Blue" Text="Tipo Doc.:"></asp:Label>
                                  </td>
                                <td align="left">
                                     &nbsp;</td>
                            </tr>
                             <tr>
                                 <td align="left">
                                     <asp:TextBox ID="txtSexo" runat="server" Width="124px" ReadOnly="true" Height="16px"></asp:TextBox>
                                 </td>
                                
                                 <td align="left" colspan="2">
                                     <asp:TextBox ID="txtDireccion" runat="server" Width="302px" ReadOnly="true" Height="16px"></asp:TextBox>
                                 </td>
                                 <td align="left">
                                     <asp:TextBox ID="txtNroDoc" runat="server" Width="126px" ReadOnly="true" Height="16px"></asp:TextBox>
                                 </td>
                                 <td align="left">
                                     <asp:TextBox ID="txtTipoDoc" runat="server" Width="126px" ReadOnly="true" Height="16px"></asp:TextBox>
                                 </td>
                                 <td align="left">&nbsp;</td>
                             </tr>
                             <tr>
                                 <td align="left">
                                     <asp:Label ID="lblFechaNac" runat="server" CssClass="etiqueta8Blue" Text="Fecha Nacimiento:"></asp:Label>
                                 </td>
                                 <td align="left">
                                     <asp:Label ID="lblFEchaFall" runat="server" CssClass="etiqueta8Blue" Text="Fecha Fallecimiento:"></asp:Label>
                                 </td>
                                 <td align="left">
                                     <asp:Label ID="lblEstadoCivil" runat="server" CssClass="etiqueta8Blue" Text="Estado Civil:"></asp:Label>
                                 </td>
                                 <td align="left">
                                      <asp:Label ID="lblCUA" runat="server" CssClass="etiqueta8Blue" Text="CUA:"></asp:Label>
                                     
                                     
                                 </td>
                                 <td align="left">
                                    <asp:Label ID="lblAFP" runat="server" CssClass="etiqueta8Blue" Text="AFP:"></asp:Label>
                                 </td>
                                 <td align="left">
                                   
                                 </td>
                             </tr>
                            <tr>
                                <td align="left">
                                    <asp:TextBox ID="txtFechaNac" runat="server" Width="112px" ReadOnly="true" Height="16px"></asp:TextBox>
                                </td>
                                <td align="left" >
                                    <asp:TextBox ID="txtFechaFall" runat="server" Width="125px" ReadOnly="true" Height="16px"></asp:TextBox>                                 
                                 </td>
                                <td align="left" >
                                     <asp:TextBox ID="txtEstadocivil" runat="server" Width="120px" ReadOnly="true" Height="16px"></asp:TextBox>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtCua" runat="server" Width="129px" ReadOnly="true" Height="16px"></asp:TextBox>
                                </td>
                                 <td align="left" >
                                     <asp:TextBox ID="txtAfp" runat="server" Width="140px" ReadOnly="true" Height="16px"></asp:TextBox>
                                </td>
                                <td align="left">
                                    
                                </td>
                            </tr>
                        </table>
                    </div>
                </asp:Panel>
                    <%--Panel de grilla--%>
                    <asp:Panel ID="pnlGV" runat="server" HorizontalAlign="Center" Width="100%"
                        CssClass="panelceleste" Visible="false" >
                        <table style="width: 100%;">
                            <tr>
                                <td colspan="4" style="text-align:center; background-color: #99CCFF;" >
                                    <asp:Label ID="lblSeguimiento" runat="server" Text="SEGUIMIENTO A TRAMITES OBSERVADOS" CssClass="etiqueta20 "></asp:Label>
                                </td>
                            </tr>
                             <tr>
                                <td style="width:10%; text-align:center" class="panelceleste">
                                 <asp:Panel ID="pnlNew" runat="server" >
                                        <table style="width: 100%;">
                                            <tr>
                                                <td style="text-align:center">
                                                    <asp:ImageButton ID="imgNuevo" runat="server" ImageUrl="~/Imagenes/nuevarevision1.png"
                                                        TabIndex="10" OnClick="imgNuevoRevision_Click" Height="20px" Width="103px" />
                                                </td>
                                                <%-- OnClientClick="ModalPopup();"--%>
                                            </tr>
                                        </table>
                                    </asp:Panel>

                                </td>

                                <td class="panelceleste" style="text-align:center; width:40%" >
                                     <asp:Label ID="lblObservaciones" runat="server" CssClass="text_obs"></asp:Label>
                               </td>
                                <td class="panelceleste"  style="text-align:center; width:20%" ><asp:RadioButtonList ID="rbTipoMuestra" runat="server"
                                        RepeatDirection="Horizontal"  TextAlign="Right"
                                        OnSelectedIndexChanged="rbTipoMuestra_SelectedIndexChanged"
                                        Width="207px" AutoPostBack="True" CssClass="etiqueta8" Height="18px">

                                        <%--<asp:ListItem Selected="True" Value="1">Todos</asp:ListItem>--%>
                                        <asp:ListItem Value="2" Selected="True">Solo Activos</asp:ListItem>
                                    </asp:RadioButtonList></td>
                                <td class="panelceleste"  style="text-align:center; width:10%" >
                                    <asp:ImageButton ID="imgCerrar" runat="server" ImageUrl="~/Imagenes/32anterior.png"   ToolTip="Volver al Formulario de Datos"  OnClick="imgCerrar_Click"  />
                                   

                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" class="panelceleste" style="width:100%">
                                    <asp:GridView ID="gvTipo" runat="server"
                                         AllowPaging="true"
                                        AutoGenerateColumns="false"
                                             HorizontalAlign="Center"
                                        SkinID="GridView"
                                        CssClass="panelceleste"
                                        OnRowDataBound="gvTipo_RowDataBound"
                                        Width="100%"
                                        EnableTheming="True"
                                        OnPageIndexChanging="gvTipo_PageIndexChanging"
                                         EnableModelValidation="True"
                                        OnRowCommand="gvTipo_RowCommand"
                                        PageSize="5" DataKeyNames="TextoObservacion">
                                        <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                                        <Columns>
                                            <asp:ButtonField ButtonType="Button" CommandName="Ver" ControlStyle-CssClass="etiqueta8Blue"
                                                Text="Ver" HeaderText="Reporte" ItemStyle-Width="5%" >
                                             <ControlStyle CssClass="etiqueta8Blue" />  </asp:ButtonField>
                                            <asp:BoundField DataField="IdFormulario" HeaderText="N°Form" ItemStyle-Width="5%">
                                                <ItemStyle Width="5%"  HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="FechaFormulario" HeaderText="Fecha">
                                                <ItemStyle Width="10%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="TipoAccion" HeaderText="Tipo Accion" >
                                                <ItemStyle Width="20%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="HojaRuta" HeaderText="N°HR"  >
                                                <ItemStyle Width="5%"   HorizontalAlign="Center"/>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Gestion" HeaderText="Gestion" >
                                                <ItemStyle Width="10%"  HorizontalAlign="Center"/>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="NumeroFojas" HeaderText="Fojas" >
                                                <ItemStyle Width="5%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="TextoObservacion" HeaderText="Observacion" Visible="false">
                                                <ItemStyle Width="10%" />
                                            </asp:BoundField>
                                            <asp:ButtonField HeaderText="Observacion"  runat ="server"   Text="Ver" CommandName="cmdVer" CausesValidation="false">
                                                <ItemStyle Width="5%" />
                                            </asp:ButtonField>
                                            <asp:BoundField DataField="CuentaUsuario"  runat ="server"  ItemStyle-Width="15px" HeaderText ="Usuario"/>
                                            <asp:BoundField DataField="RegistroActivo" HeaderText="Activo" Visible ="false">
                                                <ItemStyle Width="4%"  HorizontalAlign="Center" />
                                            </asp:BoundField>
                                   <asp:TemplateField HeaderText="Activo">
                                       <ItemStyle Width="4%"  HorizontalAlign="Center" />
                                       <ItemTemplate>
                                           <asp:image ID="ImgEstado" runat="server" ImageUrl="" />
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Editar">
                                       <ItemStyle Width="5%"  HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgEditar" runat="server" CausesValidation="false" CommandArgument='<%#Eval("IdFormulario") %>' CommandName="cmdEditar" ImageUrl="~/imagenes/16modificar.png" />
                                    </ItemTemplate>
                                   </asp:TemplateField> 
                                   <asp:TemplateField HeaderText="Eliminar">
                                       <ItemStyle Width="5%"  HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgEliminar" runat="server" CausesValidation="false" 
                                            CommandArgument='<%#Eval("IdFormulario") %>' CommandName="cmdEliminar" ImageUrl="~/imagenes/16eliminar.png" />
                                    </ItemTemplate>
                                   </asp:TemplateField> 
                                        </Columns>
                                    </asp:GridView>
                              
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" style="text-align:center; background-color: #99CCFF;" >
                                    <asp:Label ID="Label3" runat="server" Text="VISITAS DE LA PERSONA" CssClass="etiqueta20 "></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" class="panelceleste" style="width:100%">
                                    <asp:GridView ID="gvVisitas" runat="server"
                                         AllowPaging="true"
                                        AutoGenerateColumns="false"
                                             HorizontalAlign="Center"
                                        SkinID="GridView"
                                        CssClass="panelceleste"
                                        Width="100%"
                                        EnableTheming="True"
                                        OnPageIndexChanging="gvTipo_PageIndexChanging"
                                         EnableModelValidation="True"
                                        PageSize="5"
                                        OnRowCommand="gvVisitas_RowCommand"
                                        DataKeyNames="IdTramite,IdGrupoBeneficio,FechaRev,CodFicha,Observacion">
                                        <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                                        <Columns>
                                            <asp:ButtonField ButtonType="Button" CommandName="VerVisita" ControlStyle-CssClass="etiqueta8Blue"
                                                Text="Ver" HeaderText="Reporte" ItemStyle-Width="5%" >
                                             <ControlStyle CssClass="etiqueta8Blue" />  </asp:ButtonField>
                                            <asp:BoundField DataField="IdTramite" Visible="false"/>
                                            <asp:BoundField DataField="IdGrupoBeneficio" Visible="false"/>
                                            <asp:BoundField DataField="CodFicha" HeaderText="FichaAtn" >
                                                <ItemStyle Width="10%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Beneficiario" HeaderText="Beneficiario"  >
                                                <ItemStyle Width="25%"   HorizontalAlign="Center"/>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DptoAnt" HeaderText="DptoOrigen">
                                                <ItemStyle Width="15%"  HorizontalAlign="Center"/>
                                            </asp:BoundField>
                                            <asp:BoundField DataField="FechaRev" HeaderText="FechaRev" >
                                                <ItemStyle Width="5%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Observacion" HeaderText="Observacion" Visible="false">
                                                <ItemStyle Width="10%" />
                                            </asp:BoundField>
                                            <asp:ButtonField HeaderText="Observacion"  runat ="server"   Text="Ver" CommandName="cmdVerVisita" CausesValidation="false">
                                                <ItemStyle Width="5%" />
                                            </asp:ButtonField>
                                            <asp:BoundField DataField="Usuario"  runat ="server"  ItemStyle-Width="10px" HeaderText ="Usuario"/>
                                            <asp:BoundField DataField="Regional"  runat ="server"  ItemStyle-Width="10px" HeaderText ="RegAtn"/>
                                            <asp:BoundField DataField="RegistroActivo" HeaderText="Activo" Visible ="false">
                                                <ItemStyle Width="4%"  HorizontalAlign="Center" />
                                            </asp:BoundField>

                                        </Columns>
                                    </asp:GridView>
                              
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>

                 <%--Panel para añadir revision--%>
                    <asp:Panel ID="pnlRevision" runat="server" CssClass="panelceleste" HorizontalAlign="Center" Width="100%" Visible="false" BorderColor="#0066FF" BorderStyle="Solid">
                        <div>
                          <table style="width: 100%;">
                                <tr>
                                    <td style="text-align: center; font-size: large; background-color: #66CCFF;" colspan="6">
                                    <asp:Label ID="lblTitulopopup" runat="server" CssClass="etiqueta10Blue" Text="REVISIONES U OBSERVACIONES"></asp:Label>   
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right; width: 8%;" >
                                           <asp:Label ID="lblTipoAccion" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="Tipo Accion:"></asp:Label>
                                    </td>
                                    <td style="text-align: left;width: 20% ">
                                        
                                        <asp:DropDownList ID="ddlTipoAccion" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTipoAccion_SelectedIndexChanged" Width="95%">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="text-align: left;width: 10%;background-color: #C6ECFF;">
                                        <asp:Label ID="lblHojaRuta" runat="server" CssClass="etiqueta10" Style="text-align: left"  Visible="false" Text="Hoja de Ruta:"></asp:Label>
                                       </td>
                                    <td style=" text-align:left; background-color: #C6ECFF;" class="auto-style9"  >
                                        <asp:TextBox ID="txtHojaRuta" runat="server" Visible="false"  Width="70px"></asp:TextBox>
                                        <cc1:FilteredTextBoxExtender ID="txtHojaRuta_FilteredTextBoxExtender" runat="server" TargetControlID="txtHojaRuta"
                                         FilterType="Numbers" Enabled="True" >
                                        </cc1:FilteredTextBoxExtender>

                                        <asp:DropDownList ID="ddlGestion" runat="server" Visible="false"  Width="100px">
                                          </asp:DropDownList>
                                       
                                    </td>
                                    <td style="text-align:left; background-color: #C6ECFF; " class="auto-style10">
                                         <asp:ImageButton ID="imgBuscar" runat="server" Visible="false"  ImageUrl="~/Imagenes/32Buscar.png" OnClick="imgBuscar_Click" />
                                        <asp:Label ID="lblBuscar" runat="server" CssClass="texto8" Visible="false"  Style="text-align: left" Text="Buscar"></asp:Label>
                                         <asp:Label ID="lblObser" Visible="false"  runat="server" CssClass="etiqueta8Red"></asp:Label>
                                    </td>
                                    <td style="width: 15%;  text-align:left;  background-color: #C6ECFF;" >
                                        <asp:Label ID="lblFecha" runat="server" CssClass="etiqueta10" Style="text-align: left"  Visible="false" Text="Fecha:"></asp:Label>
                                       
                                        <asp:TextBox ID="txtFecha" runat="server" Visible="false" Width="90px" Enabled="false" MaxLength="10"></asp:TextBox>
                                        
                                       
                                    </td>
                                   
                                </tr>
                                 <tr>
                                     <td style="text-align: right;" >
                                         <asp:Label ID="lblArea" Visible="false"  runat="server" CssClass="etiqueta10" Style="text-align: left" Text="Area:"></asp:Label>
                                     </td>
                                   
                                     <td style="text-align: left; ">
                                         <asp:DropDownList ID="ddlArea" runat="server"   Visible="false" AutoPostBack="True"  Width="95%">
                                        </asp:DropDownList>
                                     </td>
                                     <td style="background-color: #C6ECFF">
                                         <asp:Label ID="lblDescripcionDoc" Visible="false"  runat="server" CssClass="etiqueta10" Style="text-align: left" Text="Descripcion:"></asp:Label>
                                     </td>
                                     <td colspan="3" style="text-align:right; background-color: #C6ECFF"> 
                                         <asp:TextBox ID="txtDescripcionDoc"  runat="server" Width="99%" Visible="false"  TextMode="MultiLine" Height="34px" ReadOnly="true"></asp:TextBox>

                                     </td>
                                   
                                </tr>
                                 <tr>
                                     <td style="text-align: right;" class="auto-style6">
                                         <asp:Label ID="lblNombre" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="Interesado y/o apoderado:"></asp:Label>
                                 
                                     </td>
                                     <td style="text-align: left; " colspan="2" class="auto-style6">
                                             <asp:TextBox ID="txtNombreInteresado" runat="server" Width="99%"></asp:TextBox>
                                         
                                             </td>
                                     
                                     <td style="text-align: left; " class="auto-style7" colspan="1">
                                         <asp:ImageButton ID="imgCopia" runat="server" ImageUrl="~/Imagenes/16recargar.png"  ToolTip="Coloca automatricamente el nombre del interesado"  OnClick="imgCopia_Click" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"  CssClass="texto8" ControlToValidate="txtNombreInteresado" ErrorMessage="Complete Nombre Interesado" validationgroup="InfoGroup">
                                        </asp:RequiredFieldValidator>
                                     </td>
                                     <td><table  style="width: 100%;"><tr><td  style="width: 50%;">
                                         <asp:Label ID="lblObs" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="Tipo Observación:">
                                         </asp:Label></td>
                                         <td><asp:DropDownList ID="ddlObs" runat="server" Width="95%">
                                        </asp:DropDownList></td></tr></table></td>
                                     <td style="text-align: left; " class="auto-style6" >
                                        <table width="100%">
                                            <tr><td>
                                                 <asp:Label ID="lblFojas" runat="server" CssClass="etiqueta10" Text="Fojas:" Visible="false"></asp:Label>
                                                 <asp:TextBox ID="txtFojas" runat="server" Visible="false" Width="50%"></asp:TextBox>
                                                 <cc1:FilteredTextBoxExtender ID="txtFojas_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers " TargetControlID="txtFojas">
                                                 </cc1:FilteredTextBoxExtender>
                                            </td></tr>
                                            <tr><td>
                                                 <asp:Label ID="lblFicha" runat="server" CssClass="etiqueta10" Text="Ficha:" Visible="false"></asp:Label>
                                                 <asp:TextBox ID="txtFicha" runat="server" Visible="false" Width="50%"></asp:TextBox>
<%--                                                 <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" Enabled="True" FilterType="Numbers " TargetControlID="txtFicha">
                                                 </cc1:FilteredTextBoxExtender>--%>
                                            </td></tr>
                                        </table>
                                     </td>
                                     
                                </tr>
                                <tr>
                                    
                                    <td style="text-align: right;">
                                        <asp:Label ID="lblObservacion" runat="server" CssClass="etiqueta10" Text="Detalle Revisión:"></asp:Label>
                                    </td>

                                    <td colspan="5" style="text-align: left;">
                                        <asp:TextBox ID="txtObservacion" runat="server" Width="99%" TextMode="MultiLine" Height="180px" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                                        <br />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="texto8"  ControlToValidate="txtObservacion" ErrorMessage="Complete Detalle Revisión" validationgroup="InfoGroup">
                                        </asp:RequiredFieldValidator>

                                    </td>                                 
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td colspan="3" style="text-align: right; ">
                                       
                                        <asp:Button ID="btnAccionar" runat="server" CausesValidation="true" CssClass="boton150A" OnClick="btnAccionar_Click" OnClientClick="javascript : return confirm('Esta seguro de realizar esta accion?');" Text="Adicionar" ValidationGroup="InfoGroup" />
                                        <asp:Button ID="btnCancelar" runat="server" CssClass="boton150A" EnableTheming="True" OnClick="btnCancelar_Click" Text="Cancelar" />
                                       
                                    </td>
                                </tr>
                         </table>
                       </div>
                    </asp:Panel>
                <%--Panel para poner fechas --%>
                    <asp:Panel ID="pnlFechas" runat="server" CssClass="panelceleste" 
                        HorizontalAlign="Center" Width="60%"  BorderColor="#0066FF" BorderStyle="Solid">
                        <div>
                          <table style="width: 100%;">
                                <tr>
                                    <td style="text-align: center; font-size: large; background-color: #66CCFF;" colspan="4">
                                    <asp:Label ID="Label1" runat="server" CssClass="etiqueta10Blue" Text="LISTA DE FORMULARIOS DE REVISION"></asp:Label>   
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right; width: 20%;" >
                                           &nbsp;</td>
                                    <td style="text-align: left;width: 30% " colspan="2">
                                        <asp:RadioButtonList ID="rbnExportFormato" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="1">PDF</asp:ListItem>
                                            <asp:ListItem Value="2">EXCEL</asp:ListItem>
                                        </asp:RadioButtonList>
                                        &nbsp;</td>
<%--                                    <td style="text-align:right;width: 20%;">
                                        &nbsp;</td>--%>
                                    <td style=" text-align:left;width: 30%; "  >
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="text-align: right; width: 18%;">
                                        <asp:Label ID="lblFechaIni" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="Fecha Inicial:"></asp:Label>
                                    </td>
                                    <td style="text-align: left;width: 25% ">
                                           <asp:ImageButton ID="imgcalendarioIni" runat="server" CssClass="CajaDialogo" ImageUrl="~/Imagenes/32calendario.png"  />
                                           <asp:TextBox ID="txtDateIni" runat="server" Width="63%" MaxLength="10" Height="17px" Enabled="false"></asp:TextBox >

                                    <cc1:FilteredTextBoxExtender ID="txtFecNotificacion_FilteredTextBoxExtender1" 
                                        runat="server" FilterType="Numbers,Custom"
                                        TargetControlID="txtDateIni" ValidChars="/">
                                    </cc1:FilteredTextBoxExtender>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationGroup="ValFechas" runat="server" ControlToValidate="txtDateIni" Display="Dynamic" ErrorMessage="dd/mm/aaaa" ValidationExpression="^([\d]{2})/([\d]{2})/([\d]{4})$"
                                        Font-Size="9pt" Font-Names="Arial">
                                      </asp:RegularExpressionValidator>
                                           <cc1:CalendarExtender ID="CalendarExtender1" runat="server"
                                                TargetControlID="txtDateIni"
                                                Format="dd/MM/yyyy"
                                                PopupButtonID="imgcalendarioIni" >
                                            </cc1:CalendarExtender>
                                    </td>
                                    <td style="text-align:right;width: 10%;">
                                        <asp:Label ID="lblFechaFin" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="Fecha Final:" Visible="false"></asp:Label>
                                    </td>
                                    <td style=" text-align:left; ">
                                        <asp:ImageButton ID="imgcalendarioFin" runat="server" CssClass="CajaDialogo" ImageUrl="~/Imagenes/32calendario.png" />
                                        <asp:TextBox ID="txtDateFin" runat="server" Width="100px" MaxLength="10" Enabled="false"></asp:TextBox>


                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" 
                                        runat="server" FilterType="Numbers,Custom"
                                        TargetControlID="txtDateFin" ValidChars="/">
                                    </cc1:FilteredTextBoxExtender>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ValidationGroup="ValFechas" runat="server" ControlToValidate="txtDateFin" Display="Dynamic" ErrorMessage="dd/mm/aaaa" ValidationExpression="^([\d]{2})/([\d]{2})/([\d]{4})$"
                                        Font-Size="9pt" Font-Names="Arial">
                                    </asp:RegularExpressionValidator>
                                         <cc1:CalendarExtender ID="CalendarExtender2" runat="server"
                                                TargetControlID="txtDateFin"
                                                Format="dd/MM/yyyy"
                                                PopupButtonID="imgcalendarioFin" >
                                            </cc1:CalendarExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td style="text-align: right; ">
                                        &nbsp;</td>
                                       <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:Button ID="btnGenerar" runat="server"  CssClass="boton150A" OnClick="btnGenerar_Click"  Text="Generar"  
                                            CausesValidation="true" ValidationGroup="ValFechas"/>
                                    </td>
                                    <td style="text-align: right; ">
                                        <asp:Button ID="btnCanGenerar" runat="server" CssClass="boton150A" EnableTheming="True" OnClick="btnCancelarGenerar_Click" Text="Cancelar" CausesValidation="false"/>
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                         </table>
                       </div>
                    </asp:Panel>
                <cc1:ModalPopupExtender ID="ModalPopupExtender_Observado" runat="server" CancelControlID="btnCancelarSalida" TargetControlID="lblObserva" PopupControlID="pnlObservado" BackgroundCssClass="modalBackground">
                                </cc1:ModalPopupExtender>
                                <asp:Panel runat="server" ID="pnlObservado" CssClass="panelceleste" Visible="false">
                                    <table align="center" cellpadding="0" cellspacing="0" width="700px">
                                        <tr>
                                            <td align="center" colspan="3">
                                                <asp:Label ID="lblObserva" runat="server"><h2>Detalle Revisión</h2></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <asp:TextBox ID="txtObsEtapa" runat="server" Height="200px" TextMode="MultiLine" Width="500px" ReadOnly="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" align="center">
                                                <asp:Button CssClass="buttonRed" Text="Cancelar" runat="server" ID="btnCancelarSalida" />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                <cc1:RoundedCornersExtender ID="pnlFechas_RoundedCornersExtender" runat="server" 
                    Enabled="True" TargetControlID="pnlFechas" Radius="10" BorderColor="Black">
                </cc1:RoundedCornersExtender>
                
                <cc1:ModalPopupExtender ID="pnlFechas_ModalPopupExtender" runat="server" 
                    Enabled="True"
                   
                    TargetControlID="imageButton1"
                    CancelControlID="btnCanGenerar"
                    PopupControlID="pnlFechas"
                    BackgroundCssClass="modalBackground">
                </cc1:ModalPopupExtender>
            </td>

        </tr>
        <tr>
            <td>
                <asp:HiddenField runat="server" ID="Tram"/>
                <asp:HiddenField runat="server" ID="gruBen"/>
                <asp:HiddenField runat="server" ID="hdfFormulario"/>
            </td>
        </tr>
     </table>
</asp:Content>

