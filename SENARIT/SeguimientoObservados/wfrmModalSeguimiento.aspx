<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wfrmModalSeguimiento.aspx.cs" Inherits="SeguimientoObservados_wfrmModalSeguimiento" 
    StylesheetTheme="Modal" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript">
        function cerrarpagina() {
            window.close();
            return false;
        }

    </script>
  
    <style type="text/css">
        .auto-style1 {
            height: 20px;
        }
        .auto-style2 {
            height: 10px;
        }
    </style>
  
</head>
<body>
    <form id="form1" runat="server" style="width:100%">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table  style="width: 100%; vertical-align:central" >
            <tr>
                <td>
                   <asp:Label ID="lblCodigo1" runat="server" Font-Size="Small" Visible="False"></asp:Label>
                    <asp:Panel ID="pnlGV" runat="server" HorizontalAlign="Center" Width="100%"
                        CssClass="panelceleste" >
                        <table style="width: 100%;">
                            <tr>
                                <td colspan="2" style="text-align:center; background-color: #99CCFF;" >
                                    <asp:Label ID="lblSeguimiento" runat="server" Text="SEGUIMIENTO A TRAMITES OBSERVADOS" CssClass="etiqueta20 "></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align:center" colspan="2" >
                                    <asp:Panel ID="PanelMensaje" runat="server" CssClass="panelsecundario" Width="100%" HorizontalAlign="Center">
                                        <table style="width: 100%; text-align:center">
                                            <tr>
                                                <td style="text-align:center; width:90%">
                                                    <asp:Label ID="lblObservaciones" runat="server" CssClass="text_obs"></asp:Label>
                                                </td>
                                                  <td style="text-align: right;  width:10%"> 
                                                    <asp:ImageButton ID="imgCerrar" runat="server" ImageUrl="~/Imagenes/16salir.jpg"  OnClientClick="return cerrarpagina();"   />
                                                    <asp:Label ID="Label1" runat="server" CssClass="etiqueta8"
                                                                Style="text-align: left" Text="Salir"></asp:Label>
                                                 </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 20%; text-align:center" class="panelceleste">
                                    <asp:Panel ID="pnlNew" runat="server" Height="27px" Width="117px">
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

                                <td class="panelceleste" >
                                    <asp:RadioButtonList ID="rbTipoMuestra" runat="server"
                                        RepeatDirection="Horizontal"  TextAlign="Right"
                                        OnSelectedIndexChanged="rbTipoMuestra_SelectedIndexChanged"
                                        Width="207px" AutoPostBack="True" CssClass="etiqueta8" Height="18px">

                                        <asp:ListItem Selected="True" Value="1">Todos</asp:ListItem>
                                        <asp:ListItem Value="2">Solo Activos</asp:ListItem>
                                    </asp:RadioButtonList>
                               </td>
                            </tr>
                            <tr>
                                <td colspan="2" class="panelceleste">
                                    <asp:GridView ID="gvTipo" runat="server" CssClass="panelceleste"
                                        AllowPaging="True"
                                        AutoGenerateColumns="false"
                                        HorizontalAlign="Center"
                                        SkinID="GridView"
                                        OnRowDataBound="gvTipo_RowDataBound"
                                        OnRowEditing="gvTipo_RowEditing"
                                        OnRowCommand="gvTipo_RowCommand"
                                        OnPageIndexChanging="gvTipo_PageIndexChanging"
                                        Width="100%" BorderStyle="Solid" Style="margin-left: 0px" OnRowDeleting="gvTipo_RowDeleting" PagerSettings-PageButtonCount="5" PageSize="4">

                                        <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />

                                        <Columns>
                                            <asp:ButtonField ButtonType="Button" CommandName="Ver" ControlStyle-CssClass="etiqueta8Blue"
                                                Text="Ver" HeaderText="Formulario de Revision" ItemStyle-Width="5%" >
                                            <ControlStyle CssClass="etiqueta8Blue" />
                                            <ItemStyle Width="5%" />
                                            </asp:ButtonField>
                                            <asp:BoundField DataField="IdFormulario" HeaderText="N° Formulario" ItemStyle-Width="5%">
                                                <ItemStyle Width="5%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="FechaFormulario" HeaderText="Fecha" ItemStyle-Width="10%">
                                                <ItemStyle Width="10%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="TipoAccion" HeaderText="Tipo" ItemStyle-Width="20%">
                                                <ItemStyle Width="20%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="HojaRuta" HeaderText="Hoja de Ruta" ItemStyle-Width="5%">
                                                <ItemStyle Width="5%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Gestion" HeaderText="Gestion" ItemStyle-Width="5%">
                                                <ItemStyle Width="10%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="NumeroFojas" HeaderText="Fojas" ItemStyle-Width="15%">
                                                <ItemStyle Width="5%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="TextoObservacion" HeaderText="Observacion" ItemStyle-Width="30%">
                                                <ItemStyle Width="30%" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="RegistroActivo" HeaderText="Activo" ItemStyle-Width="4%">
                                                <ItemStyle Width="4%" />
                                            </asp:BoundField>


                                            <asp:CommandField ButtonType="Image" EditImageUrl="~/Imagenes/modificar.png"
                                                HeaderText="Modificar" ItemStyle-Width="3%" ShowEditButton="True">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:CommandField>
                                            <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Imagenes/eliminar.png"
                                                HeaderText="Eliminar" ShowDeleteButton="True" ItemStyle-Width="3%">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:CommandField>
                                        </Columns>
                                        <PagerSettings PageButtonCount="5" />
                                        <RowStyle HorizontalAlign="Center" />
                                    </asp:GridView>
                                </td>
                            </tr>
                           
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td></td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Panel ID="Panelpopup" runat="server" CssClass="panelsecundario" HorizontalAlign="Center" Width="100%" Visible="false" BorderColor="#0066FF" BorderStyle="Solid">
                        <div>
                                                  
                          <table style="width: 100%;">
                                <tr>
                                    <td style="text-align: center; font-size: large; background-color: #66CCFF;" colspan="5">
                                    <asp:Label ID="lblTitulopopup" runat="server" CssClass="etiqueta10Blue" Text="REVISIONES"></asp:Label>   
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 10%;" >
                                           <asp:Label ID="lblTipoAccion" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="Tipo Accion:"></asp:Label>
                                    </td>
                                    <td style="text-align: left;width: 30% ">
                                        
                                        <asp:DropDownList ID="ddlTipoAccion" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTipoAccion_SelectedIndexChanged" Width="95%">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="background-color: #66CCFF;">
                                        <asp:Label ID="lblHojaRuta" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="Hoja de Ruta:"></asp:Label>
                                       </td>
                                    <td style=" text-align:left; background-color: #66CCFF;" >
                                        <asp:TextBox ID="txtHojaRuta" runat="server" Enabled="false" Width="50%"></asp:TextBox>
                                        <asp:DropDownList ID="ddlGestion" runat="server" Enabled="false" Width="40%">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="background-color: #66CCFF;" >
                                        
                                        <asp:ImageButton ID="imgBuscar" runat="server" Enabled="false" ImageUrl="~/Imagenes/32Buscar.png" OnClick="imgBuscar_Click" />
                                        <asp:Label ID="lblObser" runat="server" CssClass="etiqueta6"></asp:Label>
                                        
                                    </td>
                                   
                                </tr>
                                 <tr>
                                     <td>&nbsp;</td>
                                     <td style="text-align: right; ">&nbsp;</td>
                                     <td style="background-color: #66CCFF">
                                         <asp:Label ID="lblDescripcionDoc" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="Descripcion Documento:"></asp:Label>
                                     </td>
                                     <td colspan="2" style=" text-align:left; background-color: #66CCFF"> 
                                         <asp:TextBox ID="txtDescripcionDoc" runat="server" Width="99%" Enabled="false" TextMode="MultiLine"></asp:TextBox>

                                     </td>
                                   
                                </tr>
                                 <tr>
                                     <td>&nbsp;</td>
                                     <td style="text-align: right; ">&nbsp;</td>
                                     <td>&nbsp;</td>
                                     <td>&nbsp;</td>
                                     <td>&nbsp;</td>
                                   
                                </tr>
                                 <tr>
                                     <td>
                                         <asp:Label ID="lblNombre" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="Nombre Interesado:"></asp:Label>
                                 
                                     </td>
                                     <td style="text-align: left; " colspan="2">
                                             <asp:TextBox ID="txtNombreInteresado" runat="server" Width="90%"></asp:TextBox>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNombreInteresado" ErrorMessage="Es necesario el Nombre de Interesado" validationgroup="InfoGroup">
                                        </asp:RequiredFieldValidator>
                                             </td>
                                     
                                     <td style="text-align: right; ">
                                         <asp:Label ID="lblFojas" runat="server" CssClass="etiqueta10" Text="Fojas Expediente:"></asp:Label>
                                     </td>
                                     <td style="text-align: left; " >
                                         <asp:TextBox ID="txtFojas" runat="server" Enabled="false" Width="50%"></asp:TextBox>
                                         <cc1:FilteredTextBoxExtender ID="txtFojas_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers " TargetControlID="txtFojas">
                                         </cc1:FilteredTextBoxExtender>
                                     </td>
                                     
                                </tr>

                             
                                <tr>
                                    
                                    <td style="text-align: right;">
                                        <asp:Label ID="lblObservacion" runat="server" CssClass="etiqueta10" Text="Observacion:"></asp:Label>
                                    </td>

                                    <td colspan="4" style="text-align: left; ">
                                        <asp:TextBox ID="txtObservacion" runat="server" Width="90%" TextMode="MultiLine"></asp:TextBox>
                                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtObservacion" ErrorMessage="Es necesario la observacion" validationgroup="InfoGroup">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                   
                                </tr>



                                <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td colspan="2" style="text-align: right; background-color: #66CCFF;">
                                       
                                        <asp:Button ID="btnAccionar" runat="server" CausesValidation="true" CssClass="boton150A" OnClick="btnAccionar_Click" OnClientClick="javascript : return confirm('Esta seguro de realizar esta accion?');" Text="Adicionar" ValidationGroup="InfoGroup" />
                                        <asp:Button ID="btnCancelar" runat="server" CssClass="boton150A" EnableTheming="True" OnClick="btnCancelar_Click" Text="Cancelar" />
                                        <asp:Button ID="btnImportar" runat="server" CssClass="boton150A" EnableTheming="True" Text="Importar" Visible="false" />
                                       
                                    </td>
                                </tr>

                            </table>

                        </div>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Panel ID="Panel1" runat="server">
                        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="727px">
                            <LocalReport ReportPath="Reportes\ReporteFormularioRevision.rdlc">
                                <DataSources>
                                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DsFormularioR" />
                                </DataSources>
                            </LocalReport>
                        </rsweb:ReportViewer>
                         <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" OnSelecting="ObjectDataSource1_Selecting" SelectMethod="GetData" TypeName="dtsReporteFormularioRevisionTableAdapters.PR_FormularioRevisionObtenerTableAdapter">
                             <SelectParameters>
                                 <asp:Parameter Name="cod" Type="Int32" />
                             </SelectParameters>
                        </asp:ObjectDataSource>
                    </asp:Panel>
                    <cc1:ModalPopupExtender ID="Panel1_ModalPopupExtender" runat="server" DynamicServicePath="" Enabled="True" TargetControlID="Panel1">
                    </cc1:ModalPopupExtender>
                </td>
            </tr>
        </table>
       

    </form>
</body>
</html>
