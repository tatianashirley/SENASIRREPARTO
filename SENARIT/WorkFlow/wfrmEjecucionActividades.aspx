<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="wfrmEjecucionActividades.aspx.cs"
    Inherits="WorkFlow_wfrmEjecucionActividades" StylesheetTheme="Modal" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style5 {
            height: 23px;
        }
        .auto-style6 {
            width: 15%;
            height: 23px;
        }
        .auto-style7 {
            width: 8%;
        }
        .auto-style9 {
            width: 283px;
        }
        .auto-style10 {
            height: 23px;
            width: 283px;
        }
        .auto-style11 {
            width: 8%;
            height: 23px;
        }
        .auto-style12 {
            width: 9%;
        }
        .auto-style13 {
            width: 28%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%;" class="panelceleste">
        <tr>
            <td align="center">
                <asp:ImageButton ID="imgAux" runat="server" ImageUrl="~/Imagenes/16w.png" />
                <asp:Label ID="lblTituloAUX" runat="server"
                    Text="EJECUCION DE ACTIVIDADES" CssClass="etiqueta20"></asp:Label>
                <asp:Label ID="lblCodigo" runat="server" Font-Size="Small" Text="1"
                    Visible="False"></asp:Label>
        
            </td>
        </tr>
        <%-- ///////////////// PANEL DE DESPLIEGE DE DATOS DE TRAMITE///////////////// --%>
        <tr>
            <td>
                <asp:Panel ID="PanelDatos" runat="server" CssClass="panelceleste" BorderStyle="Solid" BorderWidth="3">
                    <table width="100%">
                        <tr>
                            <td style="width: 15%; text-align: right">
                                <asp:Label ID="lblNroTramite" CssClass="etiqueta10" runat="server" Text="N° de Trámite"></asp:Label>
                            </td>
                            <td style="text-align: left" class="auto-style9">
                                <asp:Label ID="txtNroTramite" runat="server" BackColor="#87CEEB" Width="134px"></asp:Label>
                            </td>
                            <td style="text-align: right" class="auto-style7">
                                <asp:Label ID="lbltipoTramite" CssClass="etiqueta10" runat="server" Text="Tipo de Trámite"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:Label ID="txtTipoTramite" runat="server" BackColor="#99CCFF" Width="134px"></asp:Label>
                            </td>
                            <td style="width: 15%; text-align: right" colspan="2">
	                            <asp:ImageButton ID="imgBuscar" runat="server"  ImageUrl="~/Imagenes/32doc_clock.gif" OnClick="btnHistorialTramite_Click" ToolTip="Historial del Trámite"   /> 
	                            <asp:Label ID="lblRefres" CssClass="etiqueta8Blue" runat="server" Text="Historial del Trámite" />   
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right" class="auto-style5">
                                <asp:Label ID="lblBeneficiario" CssClass="etiqueta10" runat="server" Text="Nombre Beneficiario" />
                            </td>
                            <td style="text-align: left" class="auto-style10">
                                <asp:Label ID="txtBeneficiario" runat="server" BackColor="#99CCFF" Width="264px"></asp:Label>
                            </td>
                            <td style="text-align: right" class="auto-style11">
                                <asp:Label ID="lblCI" CssClass="etiqueta10" runat="server" Text="CI"></asp:Label>
                            </td>
                            <td style="text-align: left" class="auto-style5">
                                <asp:Label ID="txtCI" runat="server" BackColor="#99CCFF" Width="134px"></asp:Label>
                            </td>
                            <td style="width: 15%; text-align: right" colspan="2">
                            </td>
                            <td style="text-align: left" class="auto-style5">
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right" class="auto-style5">
                                <asp:Label ID="lblGrupoBeneficio" CssClass="etiqueta10" runat="server" Text="Grupo Beneficio" />
                            </td>
                            <td style="text-align: left" class="auto-style10">
                                <asp:Label ID="txtGrupoBeneficio" runat="server" BackColor="#99CCFF" Width="264px"></asp:Label>
                            </td>
                            <td style="text-align: right" class="auto-style11">
                                
                            </td>
                            <td style="text-align: left" class="auto-style5">
                                
                            </td>
                            <td style="text-align: right" class="auto-style6">
                            </td>
                            <td style="text-align: right" class="auto-style5">
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right" class="auto-style5">
                                <asp:Label ID="lblFlujo" CssClass="etiqueta10" runat="server" Text="Flujo"></asp:Label>
                            </td>
                            <td style="text-align: left" class="auto-style5" colspan="5">
                                <asp:Label ID="txtFlujo" runat="server" BackColor="#99CCFF" Height="25px" Width="625px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right" class="auto-style5">
                                <asp:Label ID="lblActividad" CssClass="etiqueta10" runat="server" Text="Actividad" />
                            </td>
                            <td style="text-align: left" class="auto-style5" colspan="5">
                                <asp:Label ID="txtActividad" runat="server" BackColor="#99CCFF" Height="25px" Width="625px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right" class="auto-style5">
                                <asp:Label ID="lblComentarios" CssClass="etiqueta10" runat="server" Text="Comentarios" />
                            </td>
                            <td style="text-align: left" class="auto-style5" colspan="5">
                                <asp:Label ID="txtComentarios" runat="server" BackColor="#99CCFF" Height="24px" Width="623px"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <%-- /////////////////     PANEL DE DATOS ADICIONALES        ///////////////// --%>
        <tr>
            <td>
                <asp:Panel ID="pnlGrilla1" runat="server" HorizontalAlign="Center" Width="100%" CssClass="panelceleste">
                    <table style="width: 100%;">
                        <tr>
                            <td align="left" valign="top">
                                <asp:Label ID="lblSubtitulo1" CssClass="texto10" Font-Bold="true" runat="server" Text="DATOS ADICIONALES"></asp:Label>
                            </td>
                            <td style="width: 20%" align="center"></td>

                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:GridView ID="gvDatosAdicionales" runat="server"
                                    AllowPaging="True" AutoGenerateColumns="false" HorizontalAlign="Center"
                                    SkinID="GridView" Width="100%" EnableTheming="True" EnableModelValidation="True"
                                    DataKeyNames="IdConcepto,Descripcion,Valor,TipoDato"
                                    OnRowCommand="gvDatosAdicionales_RowCommand" >
                                    <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                                    <Columns>
                                        <asp:BoundField DataField="IdConcepto" HeaderText="IdConcepto" />
                                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                                        <asp:BoundField DataField="Valor" HeaderText="Valor" />
                                        <asp:BoundField DataField="Comentarios" HeaderText="Comentarios" />
                                        <asp:BoundField DataField="TipoDato" HeaderText="TipoDato" Visible="false" />
                                        <asp:ButtonField ButtonType="Button" CommandName="DatosAdicionales" 
                                            ControlStyle-CssClass="etiqueta8Blue"
                                            Text="Ingresar Datos" HeaderText="Datos Adicionales" />
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <%-- /////////////////     PANEL DE DOCUMENTO REGISTRADOS    ///////////////// --%>
        <tr>
            <td>
                <asp:Panel ID="pnlGrilla2" runat="server" HorizontalAlign="Center" Width="100%" CssClass="panelceleste">
                    <table style="width: 100%;">
                        <tr>
                            <td align="left" valign="top">
                                <asp:Label ID="lblSubTitulo2" CssClass="texto10" Font-Bold="true" runat="server" Text="DOCUMENTOS REGISTRADOS"></asp:Label>
                            </td>
                            <td style="width: 20%" align="center">
                             
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:GridView ID="gvDocumento" runat="server"
                                    AllowPaging="True"
                                    AutoGenerateColumns="false"
                                    HorizontalAlign="Center"
                                    SkinID="GridView"
                                    Width="100%"
                                    EnableTheming="True"
                                    EnableModelValidation="True">
                                    <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                                    <Columns>
                                        <asp:BoundField DataField="Periodo" HeaderText="Periodo" />
                                        <asp:BoundField DataField="Moneda" HeaderText="Moneda" />
                                        <asp:BoundField DataField="DescripcionResolucion" HeaderText="Resolucion" />
                                        <asp:BoundField DataField="FechaResolucion" HeaderText="FechaResolucion" />
                                        <asp:BoundField DataField="TasaCambio" HeaderText="TasaCambio" />
                                        <asp:BoundField DataField="RegistroActivo" HeaderText="RegistroActivo" Visible="false" />
                                        <asp:BoundField DataField="Fecha" HeaderText="RegistroActivo" />
                                        <asp:ButtonField ButtonType="Button" CommandName="Documento" ControlStyle-CssClass="etiqueta8Blue"
                                        Text="Documento" HeaderText="Documento" HeaderStyle-BackColor="#99ccff"  />
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <%-- /////////////////     PANEL DE ENLACES DISPONIBLES      ///////////////// --%>
        <tr>
            <td>
                <asp:Panel ID="pnlLinks" runat="server" HorizontalAlign="Center" Width="100%" CssClass="panelceleste">
                    <table style="width: 100%;">
                        <tr>
                            <td align="left" valign="top">
                                <asp:Label ID="lblSubTitulo3" CssClass="texto10" Font-Bold="true" runat="server" Text="ENLACES DISPONIBLES"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top">
                            <asp:GridView ID="gvEnlaces" Width="100%" runat="server" AutoGenerateColumns="false" 
                                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                                    CellPadding="3" Font-Names="Verdana" Font-Size="7pt" OnRowDataBound="gvEnlaces_RowDataBound">
                                    <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                                    <AlternatingRowStyle BackColor="#F7F7F7" />
                                    <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                                    <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                                    <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                                    <SelectedRowStyle BackColor="#6495ED" Font-Bold="True" ForeColor="#333333" />
                                <Columns>
                                    <asp:BoundField DataField="Secuencia" HeaderText="Secuencia" />
                                    <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                                    <asp:TemplateField HeaderText="Enlace">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="hlkEnlace" runat="server" Text='<%# Bind("Enlace") %>' NavigateUrl='<%# Bind("Enlace") %>'></asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    <div align="center" class="CajaDialogoAdvertencia">
                                    <br/><img src="../Imagenes/warning.gif" 
                                            alt="No existen Actividades para generar su comprobante del usuario en curso." />
                                    <br/>No existen Enlaces para ejecutar.
                                    <br/><br/>
                                    </div>
                                </EmptyDataTemplate>
                            </asp:GridView>
                            </td>
                        </tr>
                    </table>

                </asp:Panel>
            </td>
        </tr>
        <%-- /////////////////     PANEL DE TRANSICIONES POSIBLES    ///////////////// --%>
        <tr>
            <td>
                <asp:Panel ID="pnlTransiciones" runat="server" HorizontalAlign="Center" Width="100%" CssClass="panelceleste">
                    <script type="text/javascript">
                        function txtCom_onchange(obj) {
                            //debugger;
                            var txtComentario = obj.value;
                            //alert(txtComentario);
                            var btnTransicion = document.getElementById('<%= btnTransicion.ClientID %>');
                            var HFCheckboxChecked = document.getElementById("<%= HFCheckboxChecked.ClientID %>");
                            if (btnTransicion && txtComentario !== '' && HFCheckboxChecked.value == 1) {
                                btnTransicion.disabled = false;
                            }
                            else {
                                btnTransicion.disabled = true;
                            }
                            return true;
                        }
                        function checkedChange2(objRef) {
                            //debugger;
                            var GridView = objRef.parentNode.parentNode.parentNode;
                            var inputList = GridView.getElementsByTagName("input");
                            var HFCheckboxChecked = document.getElementById("<%= HFCheckboxChecked.ClientID %>");
                            HFCheckboxChecked.value = 0;
                            for (var i = 0; i < inputList.length; i++) {
                                //Get the Cell To find out ColumnIndex
                                var row = inputList[i].parentNode.parentNode;
                                if (inputList[i].type == "checkbox" && objRef != inputList[i]) {
                                    if (objRef.checked) {
                                        HFCheckboxChecked.value = 1;
                                    }
                                }
                            }
                            var btnTransicion = document.getElementById('<%= btnTransicion.ClientID %>');
                            var txtComentario = document.getElementById('<%= txtComentario.ClientID %>');
                            if (btnTransicion && txtComentario.value.length > 0 && HFCheckboxChecked.value == 1) {
                                btnTransicion.disabled = false;
                            }
                            else {
                                btnTransicion.disabled = true;
                            }
                        }
                    </script>
                    <script type = "text/javascript">
                        function checkedChange(objRef) {
                            //debugger;
                            var GridView = objRef.parentNode.parentNode.parentNode;
                            var inputList = GridView.getElementsByTagName("input");
                            var HFCheckboxChecked = document.getElementById("<%= HFCheckboxChecked.ClientID %>");
                            HFCheckboxChecked.value = 0;
                            if (objRef.checked) {
                                HFCheckboxChecked.value = 1;
                            }
                            for (var i = 0; i < inputList.length; i++) {
                                if (inputList[i].type == "checkbox" && inputList[i] != objRef) {
                                    if (inputList[i].checked) {
                                        inputList[i].checked = false;
                                    }
                                }
                            }
                            var btnTransicion = document.getElementById('<%= btnTransicion.ClientID %>');
                            var txtComentario = document.getElementById('<%= txtComentario.ClientID %>');
                            if (btnTransicion && txtComentario.value.length > 0 && HFCheckboxChecked.value == 1 && objRef.checked) {
                                btnTransicion.disabled = false;
                            }
                            else {
                                btnTransicion.disabled = true;
                            }
                        }
                    </script>
                    <asp:HiddenField ID="HFCheckboxChecked" runat="server" Value="0" />
                    <table style="width: 100%;">
                        <tr>
                            <td align="left" valign="top">
                                <asp:Label ID="lblTransiciones" CssClass="texto10" Font-Bold="true"  runat="server" Text="TRANSICIONES POSIBLES"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" valign="top">
                                <asp:GridView ID="gvTransiciones" runat="server" 
                                    CellPadding="4" ForeColor="#333333" GridLines="None" SkinID="GridView">
                                    <EditRowStyle BackColor="#2461BF" />
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" Font-Bold="True"  />
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                            <asp:TemplateField ItemStyle-Width="4%" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chktrans" runat="server" onclick="checkedChange(this);" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" Width="4%" />
                                        </asp:TemplateField>
                                            <asp:TemplateField HeaderText="IdNodo">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblIdNodo" runat="server" Text='<%# Bind("IdNodo") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                                    </Columns>
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#EFF3FB" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <asp:Label ID="lblComentario" runat="server" Text="Comentario" ForeColor="MidnightBlue" CssClass="texto10"></asp:Label>
                                <asp:TextBox ID="txtComentario" runat="server" onchange="txtCom_onchange(this)" Height="53px" Width="457px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnTransicion" CssClass="boton150" runat="server" Text="Realizar Transición" OnClick="btnTransicion_Click" Width="196px" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <%-- /////////////////     PANEL DE HISTORIAL DE TRAMITES    ///////////////// --%>
        <tr>
            <td>
                <asp:Panel ID="pnlHistorialTramites" runat="server" HorizontalAlign="Center" Width="100%" CssClass="panelceleste">
                    <table style="width: 100%;">
                        <tr>
                            <td align="left" valign="top">
                                <asp:Label ID="lblTHistTram" CssClass="texto10" Font-Bold="true"  runat="server" Text="Historial del Trámite: "></asp:Label>
                                <asp:Label ID="lblHIdTramite" CssClass="texto10" Font-Bold="true"  runat="server" Text=""></asp:Label>
                                <asp:Label ID="lblT02" runat="server" Text="-"></asp:Label>
                                <asp:Label ID="lblHIdGrupoBeneficio" CssClass="texto10" Font-Bold="true"  runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" valign="top">
                                <asp:GridView ID="gvBusqMaestro" runat="server" SkinID="GridView" 
                                    DataKeyNames="IdGrupoBeneficio,NroTramite" AutoGenerateColumns="False" 
                                    Width="100%">
                                    <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                                    <Columns>
                                        <asp:BoundField DataField="Nombres" HeaderText="Nombres" />      
                                        <asp:BoundField DataField="Ap. Paterno" HeaderText="Ap. Paterno" />      
                                        <asp:BoundField DataField="Ap. Materno" HeaderText="Ap. Materno" />      
                                        <asp:BoundField DataField="Nro. Doc. Id." HeaderText="Nro. Doc. Id." />      
                                        <asp:BoundField DataField="Matrícula" HeaderText="Matrícula" />      
                                        <asp:BoundField DataField="Fec. Nac" HeaderText="Fec. Nac." DataFormatString="{0:dd/MM/yyyy}"/>      
                                        <asp:BoundField DataField="CUA" HeaderText="CUA" />      
                                        <asp:BoundField DataField="AFP" HeaderText="AFP" />      
                                        <asp:BoundField DataField="NroTramite" HeaderText="Nro. Tramite" />      
                                        <asp:BoundField DataField="IdGrupoBeneficio" HeaderText="IdGrupoBeneficio" Visible="False"/>      
                                        <asp:BoundField DataField="GrupoBeneficio" HeaderText="Grupo Beneficio" />      
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <div align="center" class="CajaDialogoAdvertencia" style="width: 1100px">
                                            <br/>
                                            <img src="../Imagenes/warning.gif" 
                                                alt="No existen registros" />
                                            <br/>
                                            Bandeja de trámites vacía.
                                            <br/>
                                            <br/>
                                        </div>
                                    </EmptyDataTemplate>
                                </asp:GridView>                        
                            </td>
                        </tr>
                        <tr>
                            <td align="center" valign="top">
                            <div style="width: 1100px; overflow-x: scroll" align="center">
                                <asp:GridView ID="gvDetalle" runat="server" 
                                    Font-Size="X-Small" Font-Bold="false" AllowPaging="True" PageSize="5" BorderColor="#DADADA" Width="2300px" 
                                    OnPageIndexChanging="gvDetalle_PageIndexChanging">
                                    <HeaderStyle CssClass="cssHeaderImg" />
                                    <EmptyDataTemplate>
                                        <div align="center" class="CajaDialogoAdvertencia" style="width: 1100px">
                                            <br/>
                                            <img src="../Imagenes/warning.gif" 
                                                            alt="No existen registros" />
                                            <br/>
                                            Bandeja de Historial vacía.
                                            <br/>
                                            <br/>
                                        </div>
                                    </EmptyDataTemplate>
                                </asp:GridView>                        
                            </div>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:ImageButton ID="imgVolver" runat="server"  ImageUrl="~/Imagenes/32Volver.png" ToolTip="Volver a la Página anterior" OnClick="btnVolver_Click" /> 
                <asp:Label ID="lblTVolver" CssClass="etiqueta8Blue" runat="server" Text="Volver" /> 
            </td>
        </tr>
    </table>    
    <%-- /////////////////   PANEL POPUP DE DATOS ADICIONALES    ///////////////// --%>
    <cc1:RoundedCornersExtender ID="pnlPopupDatos_RoundedCornersExtender" runat="server"
        Enabled="True" TargetControlID="pnlPopupDatos">
    </cc1:RoundedCornersExtender>
    <cc1:ModalPopupExtender ID="pnlPopupDatos_ModalPopupExtender" runat="server"
        Enabled="True"
        TargetControlID="lblTitulo"
        CancelControlID="btnCancelar"
        PopupControlID="pnlPopupDatos"
        BackgroundCssClass="modalBackground">
    </cc1:ModalPopupExtender>
    <asp:Panel ID="pnlPopupDatos" runat="server" CssClass="panelceleste"
        HorizontalAlign="Center" Width="60%" >
        <div>
            <asp:Label ID="lblTitulo" runat="server"
                Text="Datos Adicionales" CssClass="etiqueta20"></asp:Label>
            <table style="width: 100%;">
                <tr>
                    <td align="right" class="auto-style13">&nbsp;</td>
                    <td align="left">&nbsp;</td>
                </tr>
                <tr>
                    <td align="right" class="auto-style13">
                        <asp:Label ID="lblTitIdConcepto" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="IdConcepto :"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:Label ID="lblIdConcepto" runat="server" Text="IdConcepto"></asp:Label>
                        <asp:Label ID="lblConcepto" runat="server" Text="Concepto" Width="249px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="auto-style13">&nbsp;</td>
                    <td align="left">&nbsp;</td>
                </tr>
                <tr>
                    <td align="right" class="auto-style13">
                        <asp:Label ID="lblValor" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="Valor:"></asp:Label>
                    </td>
                    <td align="left" style="width: 25%">
                        <asp:TextBox ID="txtValor" runat="server" Width="449px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="auto-style13"></td>
                    <td align="left">&nbsp;</td>
                </tr>
                <tr>
                    <td align="right" class="auto-style13">
                    </td>
                    <td align="right" class="auto-style12">
                        <asp:Button ID="btnGrabar" runat="server" CssClass="boton150" OnClick="btnGrabar_Click" OnClientClick="javascript : return confirm('Esta seguro de grabar?');" Text="Grabar" />
                        <asp:Button ID="btnBorrar" runat="server" CssClass="boton150" OnClick="btnBorrar_Click" OnClientClick="javascript : return confirm('Esta seguro de borrar?');" Text="Borrar" />
                    </td>
                    <td align="left" style="width: 25%">
                        <asp:Button ID="btnCancelar" runat="server" CssClass="boton150" EnableTheming="True" OnClick="btnCancelar_Click" Text="Cancelar" />
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    <%-- /////////////// PANEL POPUP DE ACEPTACION DE DOCUMENTOS ///////////////// --%>
    <cc1:RoundedCornersExtender ID="pnlPopupDoc_RoundedCornersExtender" runat="server"
        Enabled="True" TargetControlID="pnlPopupDoc">
    </cc1:RoundedCornersExtender>
    <cc1:ModalPopupExtender ID="pnlPopupDoc_ModalPopupExtender" runat="server"
        Enabled="True"
        TargetControlID="lblTituloDoc"
        CancelControlID="btnCancelar"
        PopupControlID="pnlPopupDoc"
        BackgroundCssClass="modalBackground">
    </cc1:ModalPopupExtender>
    <asp:Panel ID="pnlPopupDoc" runat="server" CssClass="panelceleste"
        HorizontalAlign="Center" Width="60%">
        <div>
            <asp:Label ID="lblTituloDoc" runat="server"
                Text="Datos Documentos" CssClass="etiqueta20"></asp:Label>
            <table style="width: 100%;">
                <tr>
                    <td align="right">&nbsp;</td>
                    <td align="left">&nbsp;</td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label2" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="IdConcepto :"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">&nbsp;</td>
                    <td align="left">&nbsp;</td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label3" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="Valor:"></asp:Label>
                    </td>
                    <td align="left" style="width: 25%">
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right"></td>
                    <td align="left">&nbsp;</td>
                </tr>
                <tr>
                    <td align="right" style="width: 25%">
                        <asp:Button ID="btnAceptarDoc" runat="server" CssClass="boton150" OnClick="btnAccionarDoc_Click" OnClientClick="javascript : return confirm('Esta seguro de realizar esta accion?');" Text="Aceptar Documentos" />
                    </td>
                    <td align="left" style="width: 25%">
                        <asp:Button ID="btnCancelarDoc" runat="server" CssClass="boton150" EnableTheming="True" OnClick="btnCancelarDoc_Click" Text="Cancelar" />
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
</asp:Content>

