<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmReasignaTramite.aspx.cs" Inherits="Seguridad_wfrmUsuario" StylesheetTheme="Modal" %>
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
     <style type="text/css">
         #TextArea1 {
             width: 567px;
             margin-left: 0px;
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
                    <asp:Label ID="lblTituloSistema" runat="server" Font-Bold="True" ForeColor="Navy" Text="REASIGNACION HACIA ARCHIVO TRANSITORIO"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblTitulo" runat="server" Font-Bold="True" ForeColor="#CC0000" Font-Size="17px" Text="Trámites a Asignar"></asp:Label>
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
                        <td align="left" style="width:30%" valign="middle">
                            <asp:Label ID="Label2" runat="server" Text="Fecha Inicio: "></asp:Label>
                            <asp:TextBox ID="txtFechaInicio" runat="server"></asp:TextBox>
                            <asp:ImageButton ID="imgcalendarioinicio" runat="server" CausesValidation="false" CssClass="CajaDialogo" ImageUrl="~/Imagenes/32calendario.png" />
                            <cc1:CalendarExtender ID="CalendarExtender4" runat="server" CssClass="cal_Theme1" Format="dd/MM/yyyy" PopupButtonID="imgcalendarioinicio" TargetControlID="txtFechaInicio">
                            </cc1:CalendarExtender>
                        </td>
                        <td align="left" style="width:30%" valign="middle">
                            <asp:Label ID="Label6" runat="server" Text="Fecha Fin: "></asp:Label>
                            <asp:TextBox ID="txtFechaFin" runat="server"></asp:TextBox>
                            <asp:ImageButton ID="imgcalendariofin" runat="server" CausesValidation="false" CssClass="CajaDialogo" ImageUrl="~/Imagenes/32calendario.png" />
                            <cc1:CalendarExtender ID="CalendarExtender5" runat="server" CssClass="cal_Theme1" Format="dd/MM/yyyy" PopupButtonID="imgcalendariofin" TargetControlID="txtFechaFin">
                            </cc1:CalendarExtender>
                        </td>
                        <td align="left" style="width:15%" valign="middle">
                            <asp:Label ID="Label17" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="Clasif. Inicio: "></asp:Label>
                            <asp:DropDownList ID="ddlClasifInicio" runat="server" AutoPostBack="True" Enabled="True" Width="150px">
                            </asp:DropDownList>
                        </td>
                        <td align="left" style="width:15%" valign="middle">
                            <asp:Label ID="Label7" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="Clasif. Fin: "></asp:Label>
                            <asp:DropDownList ID="ddlClasifFin" runat="server" AutoPostBack="True" Enabled="True" Width="150px">
                            </asp:DropDownList>
                        </td>
                        <td align="left" style="width:15%" valign="middle">
                            <asp:Label ID="Label12" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="# Registros: "></asp:Label>
                            <asp:TextBox ID="txtnumregistros" runat="server" MaxLength="3" Width="50px">0</asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server" FilterType="Numbers" TargetControlID="txtnumregistros" />
                        </td>
                    </tr>
                </table>
                     <hr align="center" width="100%">
            <table align="center" cellpadding="0" cellspacing="0">
                    <tr>
                    <td align="left" style="width:18%" valign="middle">
                        <asp:Label ID="Label9" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="Documento: "></asp:Label>
                        <asp:TextBox ID="txtDocumento" runat="server" MaxLength="15" Width="100px"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" FilterType="Numbers" TargetControlID="txtDocumento" />
                    </td>
                    <td align="left" style="width:15%" valign="middle">
                        <asp:Label ID="Label10" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="Tramite/Matricula: "></asp:Label>
                        <asp:TextBox ID="txtTramite" runat="server" MaxLength="15" Width="100px"></asp:TextBox>
                        <%--<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Numbers" TargetControlID="txtTramite" />--%>
                    </td>
                    <td align="left" style="width:20%" valign="middle">
                        <asp:Label ID="Label11" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="CUA: " Visible="False"></asp:Label>
                        <asp:TextBox ID="txtCUA" runat="server" MaxLength="15" Width="100px" Visible="False">0</asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" FilterType="Numbers" TargetControlID="txtCUA" />
                    </td>
                    <td align="right">
                        <asp:ImageButton ID="imgbtnBuscar" runat="server" ImageUrl="~/Imagenes/32Buscar.png" OnClick="imgbtnBuscar_Click" />
                    </td>
                    <td align="right">
                        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Imagenes/32Documento.png" OnClick="imgbtnLimpiar_Click" />
                        <asp:Label ID="Label4" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="Limpiar"></asp:Label>
                    </td>
                        <td align="center">&nbsp;</td>
                    </tr>
                    <tr>
                        <td align="left" style="width:18%" valign="middle">&nbsp;</td>
                        <td align="right" style="width:15%" valign="middle">&nbsp;</td>
                        <td align="left" style="width:20%" valign="middle">
                            &nbsp;</td>
                        <td align="right">&nbsp;</td>
                        <td align="right">&nbsp;</td>
                        <td align="center">&nbsp;</td>
                    </tr>
                    <tr>
                        <td align="left" style="width:18%" valign="middle">&nbsp;</td>
                        <td align="right" style="width:15%" valign="middle">Devolución  :&nbsp; </td>
                        
                        <td align="left" style="width:20%" valign="middle">
                                 <asp:RadioButtonList ID="rblTipoAsignacion" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rblTipoAsignacion_SelectedIndexChanged">
                                     <asp:ListItem Value="E">Verificador</asp:ListItem>
                                <asp:ListItem Value="C">Control de Calidad</asp:ListItem>
                            </asp:RadioButtonList>
                            &nbsp;

                        </td>


                        <td align="left" colspan="2">Observaciones:<br />
                            <asp:TextBox id="txtObservaciones" TextMode="multiline" Columns="50" Rows="5" runat="server" />
                        </td>
                        <td align="center">&nbsp;</td>
                    </tr>
                    <tr>
                        <td align="left" style="width:18%" valign="middle">&nbsp;</td>
                        <td align="right" style="width:15%" valign="middle">Reasignación:  </td>
                        <td align="left" style="width:20%" valign="middle">
                            <asp:DropDownList ID="ddlUsuariosCC" runat="server" AppendDataBoundItems="true">
                            </asp:DropDownList>
                        </td>
                        <td align="right">&nbsp;</td>
                        <td align="right">&nbsp;</td>
                        <td align="center">&nbsp;</td>
                    </tr>
                    <tr>
                        
                        <td align="right">&nbsp;</td>
                        <td align="right">&nbsp;</td>
                        <td align="center">&nbsp;</td>
                    </tr>
                    <tr>
                        <td align="left" style="width:18%" valign="middle">&nbsp;</td>
                        <td align="left" style="width:15%" valign="middle">&nbsp;</td>
                        <td align="left" style="width:20%" valign="middle">&nbsp;</td>
                        <td align="right">&nbsp;</td>
                        <td align="right">&nbsp;</td>
                        <td align="center">&nbsp;</td>
                    </tr>
                    <tr>
                        <td align="left" style="width:18%" valign="middle">&nbsp;</td>
                        <td align="left" style="width:15%" valign="middle">&nbsp;</td>
                        <td align="left" style="width:20%" valign="middle">&nbsp;</td>
                        <td align="right">&nbsp;</td>
                        <td align="right">&nbsp;</td>
                        <td align="center">&nbsp;</td>
                    </tr>
                    <tr>
                        <td align="center" colspan="5">
                            <asp:GridView ID="gvDatos" runat="server" AllowPaging="True" AutoGenerateColumns="False" BorderColor="#DADADA" BorderStyle="Solid" BorderWidth="1px" CssClass="mGrid" DataKeyNames="IdTramiteAsignado" EnableTheming="True" Font-Names="Arial" Font-Size="9pt" GridLines="Horizontal" OnPageIndexChanging="gvDatos_PageIndexChanging" OnRowCommand="gvDatos_RowCommand" OnSelectedIndexChanged="gvDatos_SelectedIndexChanged" PageSize="15" SkinID="GridView" Width="1000px">

                                <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                                <Columns>
                                    <asp:BoundField DataField="fila" HeaderText="Nro" />
                                    <asp:BoundField DataField="TipoRol" HeaderText="Tipo">
                                    </asp:BoundField>
                                    <asp:TemplateField ControlStyle-Height="16" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5px">
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="chkTodos" runat="server" onclick="checkAll(this);" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkTramite" runat="server" />
                                        </ItemTemplate>
                                        <ControlStyle Height="16px" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" Width="5px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="CuentaUsuario" HeaderText="Usuario" />
                                    <asp:BoundField DataField="Matricula" HeaderText="Matricula" Visible="true">
                                    <HeaderStyle Width="40px" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Tramite" HeaderText="Tramite" Visible="true">
                                    <HeaderStyle Width="40px" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="NumeroTramiteCrenta" HeaderText="Tram.Crenta">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CUA" HeaderText="CUA" Visible="true">
                                    <HeaderStyle Width="40px" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Nacimiento" HeaderText="Nacimiento" Visible="true">
                                    <HeaderStyle Width="40px" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Documento" HeaderText="Documento" Visible="False" >
                                    <HeaderStyle Width="40px" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" Visible="true" >
                                    <HeaderStyle Width="400px" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TipoTramite" HeaderText="Tipo" Visible="true" />
                                    <asp:BoundField DataField="Sector" HeaderText="Sector" Visible="true" />
                                    <asp:BoundField DataField="InicioTramite" HeaderText="Inicio Tramite">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="AreaOrigen" HeaderText="Origen" />
                                    <asp:BoundField DataField="FechaAsignacion" HeaderText="Fecha Asig" >
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Clasificacion" HeaderText="Clasificacion" >
                                    <HeaderStyle Width="400px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="NivelClasifica" HeaderText="Nivel" Visible="False" />
                                    <asp:BoundField DataField="IdClasificacionTramite" HeaderText="Clasif" Visible="False" />
                                    <asp:BoundField DataField="IdTramiteAsignado" HeaderText="IdAsig" Visible="False" />
                                    <asp:BoundField DataField="ObservacionAsignacion" HeaderText="Observacion" />
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
                            <asp:Button ID="btnEnviar" runat="server" OnClick="btnEnviar_Click" Text="Asignar" />
                        </td>
                    </tr>
            </table>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlRegistro" runat="server"  CssClass="panelceleste"><%-- Style="display: none;">--%>
        <div>

            <table align="center" cellpadding="0" cellspacing="0" width="600px">
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

