<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmTramitesClasificados.aspx.cs" Inherits="Seguridad_wfrmUsuario" StylesheetTheme="Modal" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
        <asp:TextBox ID="TextBox1" runat="server" Visible="false"></asp:TextBox>
            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Imagenes/16calendario.png"  Visible="false"/>
            <cc1:CalendarExtender ID="CalendarExtender3" runat="server" PopupButtonID="ImageButton1" TargetControlID="TextBox1" ></cc1:CalendarExtender>
    <div class="FondoAplicacion">
        <table width="100%" border="0" cellpadding="false" cellspacing="false">
            <tr>
                <td>
                    <asp:Label ID="lblTituloSistema" runat="server" Font-Bold="True" ForeColor="Navy" Text="MODULO DE CERTIFICACION"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblTitulo" runat="server" Font-Bold="True" ForeColor="#CC0000" Font-Size="17px" Text="Trámites Clasificados"></asp:Label>
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
                        <asp:TextBox ID="txtDocumento" runat="server" MaxLength="15" Width="100px" ></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" FilterType="Numbers" TargetControlID="txtDocumento" />
                    </td>
                    <td align="left" style="width:15%" valign="middle">
                        <asp:Label ID="Label10" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="Tramite/Matricula: "></asp:Label>
                        <asp:TextBox ID="txtTramite" runat="server" MaxLength="15" Width="100px"></asp:TextBox>
                       <%-- <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Numbers" TargetControlID="txtTramite" />--%>
                    </td>
                    <td align="left" style="width:20%" valign="middle">
                        <asp:Label ID="Label11" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="CUA: " Visible="False"></asp:Label>
                        <asp:TextBox ID="txtCUA" runat="server" MaxLength="15" Width="100px" Visible="False">0</asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" FilterType="Numbers" TargetControlID="txtCUA" />
                    </td>
                    <td align="right">
                        <asp:ImageButton ID="imgbtnBuscar" runat="server" ImageUrl="~/Imagenes/nueva3/buscar32.png" OnClick="imgbtnBuscar_Click" />
                    </td>
                    <td align="right">
                        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Imagenes/32Documento.png" OnClick="imgbtnLimpiar_Click" />
                        <asp:Label ID="Label4" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="Limpiar"></asp:Label>
                    </td>
                        <td align="center">&nbsp;</td>
                    </tr>
                    <tr>
                        <td align="center" colspan="5">
                            <asp:GridView ID="gvDatos" 
                                runat="server" 
                                EnableTheming="True"
                                AllowPaging="True" 
                                PageSize="15"  Width="100%"
                                AutoGenerateColumns="False" 
                                
                                     CssClass="mGrid"
                                    PagerStyle-CssClass="pgr"
                                    AlternatingRowStyle-CssClass="alt"
                                    GridLines="None"  
                                DataKeyNames="Tramite,Nombre,CUA,IdClasificacionTramite,IdTramiteClasificado" 
                                  
                                OnPageIndexChanging="gvDatos_PageIndexChanging" 
                                OnRowCommand="gvDatos_RowCommand" 
                                OnSelectedIndexChanged="gvDatos_SelectedIndexChanged"                                
                                
                                >
                                
                                <AlternatingRowStyle CssClass="alt" />
                                <Columns>
                                    <asp:BoundField DataField="IdTramiteClasificado" HeaderText="Tramite" Visible="False" />
                                    <asp:BoundField DataField="fila" HeaderText="Nro" />
                                    <asp:BoundField DataField="Matricula" HeaderText="Matricula" Visible="true">
                                    <HeaderStyle Width="40px" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Tramite" HeaderText="Tramite" Visible="true">
                                    <HeaderStyle Width="40px" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="NumeroTramiteCrenta" HeaderText="Tram.Crenta" Visible="true">
                                    <HeaderStyle Width="40px" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="EstadoTramite" HeaderText="Estado" SortExpression="EstadoTramite" />
                                    <asp:BoundField DataField="CUA" HeaderText="CUA" Visible="true">
                                    <HeaderStyle Width="40px" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Nacimiento" HeaderText="Nacimiento" Visible="true">
                                    <HeaderStyle Width="40px" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" Visible="true">
                                    <HeaderStyle Width="400px" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TipoTramite" HeaderText="Tipo" Visible="true" />
                                    <asp:BoundField DataField="Sector" HeaderText="Sector" Visible="true" />
                                    <asp:BoundField DataField="InicioTramite" HeaderText="Inicio Tramite" />
                                    <asp:BoundField DataField="AreaOrigen" HeaderText="Origen" />
                                    <asp:BoundField DataField="FechaClasif" HeaderText="Fecha Clasif" />
                                    <asp:BoundField DataField="Clasificacion" HeaderText="Clasificacion">
                                    <HeaderStyle Width="400px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="NivelClasifica" HeaderText="Nivel" />
                                    <asp:BoundField DataField="UsuarioRegistro" HeaderText="Usuario Reg." />
                                    <asp:BoundField DataField="FechaModif" HeaderText="Fecha Modif." />
                                    <asp:BoundField DataField="UsuarioModif" HeaderText="Usuario Mod." />
                                    <asp:BoundField DataField="IdClasificacionTramite" HeaderText="IdClasificacionTramite" Visible="False" />
                                    <asp:TemplateField HeaderText="Editar" Visible="False"></asp:TemplateField>
                                    <asp:TemplateField HeaderText="Editar" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgEditar" runat="server" CausesValidation="false" CommandArgument='<%#Eval("IdTramiteClasificado") %>' CommandName="cmdEditar" ImageUrl="~/imagenes/16modificar.png" />
                                        </ItemTemplate>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgSeleccion" runat="server" CommandName="Select" ImageUrl="~/imagenes/nueva3/editar32.png" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
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
                                <PagerStyle CssClass="pgr" />
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
                        <h2>Modificación Clasificación</h2>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">&nbsp;</td>
                </tr>
                <tr>
                    <td align="right" width="50%">
                        <asp:Label ID="Label1" runat="server" Text="Trámite:"></asp:Label>
                        </td>
                    <td align="left">
                        <asp:TextBox ID="txtTramite1" runat="server" Width="200px" autofocus="autofocus" ReadOnly="True"></asp:TextBox>
                        &nbsp;
                        <asp:TextBox ID="txtIdTramite" runat="server" ReadOnly="True" Visible="False" Width="80px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" width="10%">
                        <asp:Label ID="Label5" runat="server" Text="Nombre:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtNombre" runat="server" Width="500px" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" width="50%">
                        <asp:Label ID="lblClaveUsuario" runat="server" Text="CUA:" Visible="true"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtCUA1" runat="server" Width="179px" Visible="true" ReadOnly="True" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" width="50%">
                        <asp:Label ID="Label3" runat="server" Text="Clasificación:" Visible="true"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlClasif" runat="server"  Width="150px"  Enabled="True">   </asp:DropDownList>
                    </td>
                </tr>
                 <tr>

                    <td align="center" colspan="2">
                        <asp:Button ID="btnActualizar" runat="server" OnClick="btnActualizar_Click" Text="Actualizar" Visible="false" />
                        &nbsp;<asp:Button ID="btnCancelar" runat="server" CausesValidation="false" OnClick="btnCancelar_Click" Text="Cancelar" />
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

