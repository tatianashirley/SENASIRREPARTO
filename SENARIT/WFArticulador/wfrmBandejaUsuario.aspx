<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmBandejaUsuario.aspx.cs" Inherits="WFArticulador_wfrmBandejaUsuario" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
body{
	background-color:#ECF5FB;
	background-image:url(Images/Stage_BG_btm.png);
	background-position:center bottom;
	background-repeat:repeat-x;
	font-family:Tahoma,Verdana,Segoe,sans-serif;
	font-size:70%;
	padding-bottom:20px;
}

.Container
{
	margin:auto;
	min-height:400px;
	background:#ffffff;
	max-width:500px;
	min-width:500px;
	border:solid 1px #d4d4d4;
	padding:0 20px 20px 20px;
}

.ToolBar
{
	border:solid 1px #d4d4d4;
	padding:10px;
	margin-bottom:20px;
}

.GridContainer
{
	background:#ECF5FB;
	min-height:300px;
	border:solid 1px #d4d4d4;
}

.ModalPopupBG
{
	background-color: #666699;
	filter: alpha(opacity=50);
	opacity: 0.7;
}

.popup_Container {
	background-color:#fffeb2;
	border:2px solid #000000;
	padding: 5px 5px 5px 5px;
    max-height: 500px; overflow: auto;
    max-width: 1100px; overflow: auto;
}
.popupConfirmation
{
	width: 400px;
	height: 250px;
}
.popupExtense
{
	width: 1100px;
	height: 650px;
}
.popup_Titlebar {
	background-color: #4169E1;
	height: 29px;
}

.popup_Body
{
	padding:15px 15px 15px 15px;
	font-family:Arial;
	font-weight:bold;
	font-size:12px;
	color:#000000;
	line-height:15pt;
	clear:both;
	padding:20px;
}

.TitlebarLeft 
{
	float:left;
	padding-left:5px;
	padding-top:5px;
	font-family:Arial, Helvetica, sans-serif;
	font-weight:bold;
	font-size:12px;
	color:#FFFFFF;
}
.TitlebarRight 
{
	background:url(Images/cross_icon_normal.png);
	background-position:right;
	background-repeat:no-repeat;
	height:15px;
	width:16px;
	float:right;
	cursor:pointer;
	margin-right:5px;
	margin-top:5px;
}

.popup_Buttons
{
	margin:10px;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript">
function jsNumbers(elEvento, permitidos) {
    // Variables que definen los caracteres permitidos
    //debugger;
    var numeros = "0123456789";
    var caracteres = " abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ";
    var numeros_caracteres = numeros + caracteres;
    var teclas_especiales = [8, 46, 37, 39, 17, 86, 9];
    // 8=BackSpace, 46=Supr, 37=flecha izquierda=%, 39=flecha derecha, 17=Ctrl,86=v,9=Tab,13=Enter

    // Seleccionar los caracteres a partir del parámetro de la función
    switch (permitidos) {
        case 'num':
            permitidos = numeros;
            break;
        case 'car':
            permitidos = caracteres;
            break;
        case 'num_car':
            permitidos = numeros_caracteres;
            break;
    }

    // Obtener la tecla pulsada
    var evento = elEvento || window.event;
    var ekeyCode = evento.keyCode;
    var echarCode = evento.charCode;
    var ewhich = evento.which;            
    var codigoCaracter = evento.charCode;// || evento.keyCode;
    var caracter = String.fromCharCode(codigoCaracter);
    //alert(ekeyCode); alert(echarCode); alert(ewhich); alert(caracter);
    //alert('ekeyCode=' + ekeyCode + ' echarCode=' + echarCode + ' ewhich=' + ewhich + ' charCode=' + caracter);

    // Comprobar si la tecla pulsada es alguna de las teclas especiales
    // (teclas de borrado y flechas horizontales)
    var tecla_especial = false;
    for (var i in teclas_especiales) {
        if (ekeyCode == teclas_especiales[i]) {
            tecla_especial = true;
            break;
        }
    }
    //alert(tecla_especial);

    // Comprobar si la tecla pulsada se encuentra en los caracteres permitidos
    // o si es una tecla especial
    var resultado = false;
    resultado = permitidos.indexOf(caracter) != -1 || tecla_especial;
    //return result;
    //alert(resultado);

    return resultado;
}
function mask(str, textbox, loc, delim) {
    //debugger;
    var locs = loc.split(',');
    for (var i = 0; i <= locs.length; i++) {
        for (var k = 0; k <= str.length; k++) {
            if (k == locs[i]) {
                if (str.substring(k, k + 1) != delim) {
                    str = str.substring(0, k) + delim + str.substring(k, str.length)
                }
            }
        }
    }
    textbox.value = str
}
</script>
<script type="text/javascript">
    function ActiveTabChanged(sender, e) {
        //debugger;
    }

    function Panel1Click(sender, e) {
        //debugger;
        var HFPanel1 = document.getElementById("<%= HFPanel1.ClientID %>");
            HFPanel1.value = Math.floor(Math.random() * 11);
            __doPostBack('<%=HFPanel1.UniqueID%>', HFPanel1.value);
    }
    function Panel3Click(sender, e) {
        //debugger;
        var HFPanel3 = document.getElementById("<%= HFPanel3.ClientID %>");
        HFPanel3.value = Math.floor(Math.random() * 11);
        __doPostBack('<%=HFPanel3.UniqueID%>', HFPanel3.value);
    }
</script>
<script type = "text/javascript">
    function chkAll(objRef) {
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
<script type="text/javascript">
    function resizemultilineTextBox(txt) {
        txt.style.height = "1px";
        txt.style.height = (1 + txt.scrollHeight) + "px";
    }
</script> 
<table style="width: 100%;" class="panelceleste">
<tr>
    <td align="center">
        <asp:ImageButton ID="imgAux" runat="server" ImageUrl="~/Imagenes/16w.png" />
        <asp:Label ID="lblTituloAUX" runat="server"
            Text="BANDEJA DE TRAMITES" CssClass="etiqueta20"></asp:Label>
    </td>
</tr>
</table>
<asp:HiddenField ID="HFPanel1" runat="server" Value="0" OnValueChanged="HFPanel1_ValueChanged" />
<asp:HiddenField ID="HFPanel3" runat="server" Value="0" OnValueChanged="HFPanel3_ValueChanged" />
<cc1:TabContainer runat="server" ID="Tabs" OnClientActiveTabChanged="ActiveTabChanged" >
    <cc1:TabPanel runat="server" ID="Panel1" HeaderText="Bandeja de Entrada" OnClientClick="Panel1Click">
        <ContentTemplate>
            <table style="width: 100%;" cellpadding="0" cellspacing="0" class="panelceleste">
            <tr>
                <td width="1%"></td>
                <td width="78%" align="right">
                    <asp:Panel ID="panSearchBE" runat="server" 
                            DefaultButton="imgBuscar" Width="100%" >
                    <asp:Label ID="lblNumeroTramite"  CssClass="etiqueta10"  runat="server" Text="Numero Tramite: " >
                    </asp:Label>
                    <asp:TextBox  ID="txtNumeroTramite" runat="server" 
                        style="margin-bottom: 0px" onkeypress="return jsNumbers(event, 'num_car')"
                        MaxLength="12">
                    </asp:TextBox>
                    <asp:ImageButton ID="imgBuscar" runat="server"  ImageUrl="~/Imagenes/32Buscar.png" ToolTip="Buscar Datos" 
                        OnClick="imgBuscar_Click" /> 
                    <asp:Label ID="lblRefres" CssClass="etiqueta8Blue" runat="server" Text="Buscar" /> 
                    <asp:ImageButton ID="imgImprimeModificaciones" runat="server"  
                        ImageUrl="~/Imagenes/32imprimir.png" ToolTip="Imprime Bandeja de Entrada" 
                        OnClick="imgImprimeBandejaEntrada_Click" Visible="false" />
                    <asp:Label ID="lblImprimeModificaciones" CssClass="etiqueta8Blue" runat="server" Text="Reporte Bandeja de Entrada" Visible="false" />                      
                    </asp:Panel>
                </td>
                <td width="1%"></td>
                <td width="9%">
                </td>
                <td width="10%">
                </td>
                <td width="1%"></td>
            </tr>
            <tr>
                <td width="1%"></td>
                <td width="78%" align="left">
                    <hr />
                </td>
                <td width="1%"></td>
                <td width="9%">
                </td>
                <td width="10%">
                </td>
                <td width="1%"></td>
            </tr>
            <tr>
                <td width="1%"></td>
                <td width="78%" align="left">
                    <asp:Label ID="Label5" runat="server" Text="Bandeja de Entrada" CssClass="etiqueta10" Font-Bold="True"></asp:Label>
                    <asp:GridView ID="gvBandejaEntrada" runat="server" AutoGenerateColumns="false"
                        BorderStyle="None" GridLines="None" SkinID="GridView" Font-Names="Verdana" Font-Size="8pt"
                        BackColor="White" BorderColor="#CCCCCC" BorderWidth="1px" 
                        CellPadding="3" 
                        OnRowCommand="gvBandejaEntrada_RowCommand" 
                        DataKeyNames="Id430,CuentaUsuario,IdUsuarioOrigen,IdAreaOrigen,FechaIngreso"
                        AllowPaging="True" PageSize="20" 
                        OnPageIndexChanging="gvBandejaEntrada_PageIndexChanging"
                        AllowSorting="True" 
                        OnSorting="gvBandejaEntrada_Sorting">
                        <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                        <AlternatingRowStyle BackColor="#F7F7F7" />
                        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#FFDAB9" Font-Bold="True" ForeColor="#333333" />
                        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <PagerSettings Mode="NumericFirstLast" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        <Columns>
                            <asp:BoundField DataField="Id430" HeaderText="F430" Visible="true" SortExpression="Id430" />
                            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" Visible="true" SortExpression="Descripcion" />
                            <asp:BoundField DataField="CuentaUsuario" HeaderText="Usuario Origen" Visible="true" SortExpression="CuentaUsuario" />
                            <asp:BoundField DataField="FechaIngreso" HeaderText="Fecha Ingreso" Visible="true" SortExpression="FechaIngreso" DataFormatString="{0:d}"/>
                            <asp:BoundField DataField="CantidadExpedientes" HeaderText="Cantidad Expedientes" Visible="true" SortExpression="CantidadExpedientes" />
                            <asp:BoundField DataField="Proveido" HeaderText="Proveido" Visible="true" />
                            <asp:TemplateField ItemStyle-Width="40px">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgDetTramite" runat="server" 
                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                            CommandName="DETALLE01"
                                            ImageUrl="~/Imagenes/16AttachDocumentMoveDown.gif" CausesValidation="false" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="40px">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgImprime430xls" runat="server" 
                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                            CommandName="IMPRIME430xls"
                                            ImageUrl="~/Imagenes/reportes/excel32.jpg" CausesValidation="false" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="40px">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgImprime430pdf" runat="server" 
                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                            CommandName="IMPRIME430pdf"
                                            ImageUrl="~/Imagenes/reportes/pdf32.png" CausesValidation="false" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate><div align="center" class="CajaDialogoAdvertencia">
                            <br/><img src="../Imagenes/warning.gif" 
                                    alt="No existen tramites remitidos" />
                            <br/>No existen tramites remitidos
                            <br/><br/>
                            </div>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </td>
                <td width="1%"></td>
                <td width="9%">
                </td>
                <td width="10%">
                </td>
                <td width="1%"></td>
            </tr>
            </table>
            <table style="width: 100%;" cellpadding="0" cellspacing="0" class="panelceleste">
            <tr>
                <td width="1%"></td>
                <td width="98%" align="left">
                    <asp:Label ID="Label1" runat="server" Text="Detalle de Trámites recibidos" CssClass="etiqueta10" Font-Bold="True"></asp:Label>
                    <asp:GridView ID="gvBandejaEntradaDetalle" runat="server" AutoGenerateColumns="False"
                        BorderStyle="None" GridLines="None" SkinID="GridView" Font-Names="Verdana" Font-Size="8pt"
                        BackColor="White" BorderColor="#CCCCCC" BorderWidth="1px" 
                        CellPadding="3" 
                        OnRowCommand="gvBandejaEntradaDetalle_RowCommand" 
                        DataKeyNames="Id430,IdTramite,IdTipoTramite" >
                        <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                        <AlternatingRowStyle BackColor="#F7F7F7" />
                        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#FFDAB9" Font-Bold="True" ForeColor="#333333" />
                        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <Columns>
                            <asp:TemplateField ItemStyle-Width="40px">
                                <HeaderTemplate>
                                    <asp:CheckBox ID="chkAll" runat="server" onclick = "chkAll(this);" />
                                </HeaderTemplate>
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkTramite" runat="server" ></asp:CheckBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Id430" HeaderText="F430" Visible="true" />
                            <asp:BoundField DataField="Fila" HeaderText="Fila" Visible="true" />
                            <asp:BoundField DataField="AreaOrigen-AreaDestino" HeaderText="AreaOrigen - AreaDestino" Visible="true" />
                            <asp:TemplateField HeaderText="CRENTA">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgHistorial" runat="server" 
                                    CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" 
                                    CommandName="Historial"
                                    ToolTip="Historial del Trámite" AlternateText='<%# Bind("NumeroTramiteCrenta") %>' />
                                </ItemTemplate>
                                <ItemStyle Font-Bold="True" ForeColor="WhiteSmoke" BackColor="DimGray" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="IdTramite" HeaderText="Trámite" Visible="true" />
                            <asp:BoundField DataField="TipoTramite" HeaderText="Procedimiento" Visible="true" />
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre Completo" Visible="true" />
                            <asp:BoundField DataField="FechaIngreso" HeaderText="Fecha Ingreso" Visible="true" DataFormatString="{0:d}" />
                            <asp:BoundField DataField="Regional" HeaderText="Regional" Visible="true" />
                            <asp:BoundField DataField="EstadoTramite" HeaderText="Estado Tramite" Visible="true" />
                            <asp:BoundField DataField="Sector" HeaderText="Sector" Visible="true" />
                            <asp:BoundField DataField="ObsSalidaArea" HeaderText="Obs Salida Area" Visible="true" />
                        </Columns>
                        <EmptyDataTemplate><div align="center" class="CajaDialogoAdvertencia">
                            <br/><img src="../Imagenes/warning.gif" 
                                    alt="No existen tramites remitidos" />
                            <br/>No existen tramites remitidos
                            <br/><br/>
                            </div>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </td>
                <td width="1%" ></td>
            </tr>
            <tr>
                <td width="1%"></td>
                <td width="98%" colspan="4">
                    <asp:ImageButton ID="imgTramiteAcepta" runat="server"  
                        ImageUrl="~/Imagenes/32TramiteAcepta.gif" ToolTip="Aceptar Tramites marcados"
                        OnClick="imgTramiteAcepta_Click" onclientclick="return confirm('Esta seguro de recepcionar los tramites marcados ?');" /> 
                    <asp:Label ID="lblAceptar" CssClass="etiqueta8Blue" runat="server" Text="Aceptar" />
                    <asp:ImageButton ID="imgTramiteRechaza" runat="server"
                        ImageUrl="~/Imagenes/32TramiteRechaza.gif" ToolTip="Rechazar Tramites marcados"
                        OnClick="imgTramiteRechaza_Click" onclientclick="return confirm('Esta seguro de rechazar los tramites marcados ?');" />
                    <asp:Label ID="lblRechazar" CssClass="etiqueta8Blue" runat="server" Text="Rechazar" />
                </td>
                <td width="1%" style="text-align:left" class="auto-style7">
                </td>
            </tr>
            </table>
        </ContentTemplate>
    </cc1:TabPanel>
    <cc1:TabPanel runat="server" ID="Panel2" HeaderText="Bandeja de Trabajo" >
        <ContentTemplate>
            <table style="width: 100%;" cellpadding="0" cellspacing="0" class="panelceleste">
            <tr>
                <td width="1%"></td>
                <td width="10%" align="left">
                    <asp:Label ID="Label6" runat="server" Text="Bandeja de Trabajo" CssClass="etiqueta10" Font-Bold="True"></asp:Label>
                </td>
                <td width="50%">
                    <asp:Label ID="lblAux01" runat="server" Text=""></asp:Label>
                </td>
                <td width="1%"></td>
            </tr>
            <tr>
                <td width="1%"></td>
                <td width="10%" align="left">
                </td>
                <td width="50%">
                    <asp:Panel ID="panelSearchBT2" runat="server" 
                        DefaultButton="imgBuscarTrabajo2" Width="100%" >
                    <asp:Label ID="Label25"  CssClass="etiqueta10"  runat="server" Text="Numero Tramite: " >
                    </asp:Label>
                    <asp:TextBox  ID="txtNumeroTramiteTrabajo" runat="server" 
                        style="margin-bottom: 0px" onkeypress="return jsNumbers(event, 'num_car')"
                        MaxLength="12"></asp:TextBox>
                    <asp:ImageButton ID="imgBuscarTrabajo2" runat="server"  
                        ImageUrl="~/Imagenes/32Buscar.png" ToolTip="Buscar Datos" 
                        OnClick="imgBuscarTrabajo_Click" /> 
                    <asp:Label ID="Label26" CssClass="etiqueta8Blue" runat="server" Text="Buscar" />
                    <asp:ImageButton ID="imgImprimeBandejaTrabajoXLS" runat="server" 
                        ImageUrl="~/Imagenes/reportes/excel32.jpg" ToolTip="Exporta a EXCEL Reporte Bandeja de Trabajo"
                        OnClick="imgImprimeBandejaTrabajoXLS_Click" />
                    <asp:ImageButton ID="imgImprimeBandejaTrabajoPDF" runat="server"  
                        ImageUrl="~/Imagenes/reportes/pdf32.png" ToolTip="Imprime Reporte Bandeja de Trabajo" 
                        OnClick="imgImprimeBandejaTrabajoPDF_Click" />
                    <asp:Label ID="Label29" CssClass="etiqueta8Blue" runat="server" Text="Reporte Bandeja de Trabajo" />                      
                   </asp:Panel>
                </td>
                <td width="1%"></td>
            </tr>
            <tr>
                <td width="1%"></td>
                <td width="10%" align="left">
                </td>
                <td width="50%">
                    <hr />
                </td>
                <td width="1%"></td>
            </tr>
            <tr>
                <td width="1%" colspan="2"></td>
                <td width="97%" align="center">
                    <asp:Label ID="lblTitBandejaTrabajo" runat="server" Text="Detalle de Trámites Aceptados" CssClass="etiqueta10" Font-Bold="True"></asp:Label>
                    <asp:GridView ID="gvBandejaAceptados" runat="server" AutoGenerateColumns="false"
                        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                        CellPadding="3" Font-Names="Verdana" Font-Size="8pt" 
                        DataKeyNames="IdTramite,NumeroTramiteCrenta,IdUsuarioActividad,t430"
                        AllowPaging="True" PageSize="10"
                        AllowSorting="True"
                        OnSorting="gvBandejaAceptados_Sorting" 
                        OnPageIndexChanging="gvBandejaAceptados_PageIndexChanging" 
                        OnRowDataBound="gvBandejaAceptados_RowDataBound"
                        OnRowCommand="gvBandejaAceptados_RowCommand" >
                        <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                        <AlternatingRowStyle BackColor="#F7F7F7" />
                        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#FFDAB9" Font-Bold="True" ForeColor="#333333" />
                        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <PagerSettings Mode="NumericFirstLast" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        <Columns>
                            <asp:TemplateField HeaderText="CRENTA">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgHistorial" runat="server" 
                                    CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" 
                                    CommandName="Historial"
                                    ToolTip="Historial del Trámite" AlternateText='<%# Bind("NumeroTramiteCrenta") %>' />
                                </ItemTemplate>
                                <ItemStyle Font-Bold="True" ForeColor="WhiteSmoke" BackColor="DimGray" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="IdTramite" HeaderText="Trámite" Visible="true" SortExpression="IdTramite" />
                            <asp:BoundField DataField="TipoTramite" HeaderText="Procedimiento" Visible="true" />
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre Completo" Visible="true" />
                            <asp:BoundField DataField="FechaIngreso" HeaderText="Fecha Ingreso" Visible="true" SortExpression="FechaIngreso" DataFormatString="{0:d}" />
                            <asp:BoundField DataField="Regional" HeaderText="Regional" Visible="true" SortExpression="Regional" />
                            <asp:BoundField DataField="EstadoTramite" HeaderText="Estado Tramite" Visible="true" />
                            <asp:BoundField DataField="Sector" HeaderText="Sector" Visible="true" SortExpression="Sector"/>
                            <asp:BoundField DataField="t430" HeaderText="t430" Visible="true" />
                        </Columns>
                        <EmptyDataTemplate><div align="center" class="CajaDialogoAdvertencia">
                            <br/><img src="../Imagenes/warning.gif" 
                                    alt="No existen tramites pre seleccionados para derivarse" />
                            <br/>No existen tramites pre seleccionados para derivarse
                            <br/><br/>
                            </div>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </td>
                <td width="1%">
                </td>
            </tr>
            <tr>
                <td width="1%"><hr /></td>
                <td width="10%" align="left">
                    <hr />
                </td>
                <td width="50%"><hr /></td>
                <td width="1%"><hr /></td>
            </tr>
            </table>
        </ContentTemplate>
    </cc1:TabPanel>
    <cc1:TabPanel runat="server" ID="PanelD" HeaderText="Derivación de Tramites" >
        <ContentTemplate>
            <table style="width: 100%;" cellpadding="0" cellspacing="0" class="panelceleste">
            <tr>
                <td width="1%"></td>
                <td width="10%" align="left">
                    <asp:Label ID="Label20" runat="server" Text="Asignación" CssClass="etiqueta10" Font-Bold="True"></asp:Label>
                </td>
                <td width="50%"></td>
                <td width="1%"></td>
            </tr>
            <tr>
                <td width="1%"></td>
                <td width="10%" align="right">
                    <asp:Label ID="Label10"  CssClass="etiqueta10"  runat="server" Text="Destino: " >
                    </asp:Label>
                </td>
                <td width="50%">
                    <asp:DropDownList ID="ddlPosiblesDestinos" runat="server" AutoPostBack="true"
                        OnSelectedIndexChanged="ddlPosiblesDestinos_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlRolUsuario" runat="server" AutoPostBack="true"
                        OnSelectedIndexChanged="ddlRolUsuario_SelectedIndexChanged">
                    </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblUltimoTramiteInsertado"  CssClass="etiqueta10"  runat="server" 
                        BackColor="Yellow" ForeColor="BlueViolet"
                        Visible="false" ></asp:Label>
                </td>
                <td width="1%">
                </td>
            </tr>
            <tr>
                <td width="1%"></td>
                <td width="10%" align="right">
                    <asp:Label ID="Label8"  CssClass="etiqueta10"  runat="server" Text="Tramite: " >
                    </asp:Label>
                </td>
                    <td width="50%">
                        <asp:Panel ID="panSearchDT" runat="server" 
                                DefaultButton="imgBuscarTramite" Width="100%" >
                            <asp:TextBox  ID="txtTramiteEnvia" runat="server" 
                                style="margin-bottom: 0px" onkeypress="return jsNumbers(event, 'num_car')"
                                MaxLength="12"></asp:TextBox>
                            <asp:Label ID="Label24"  CssClass="etiqueta10"  runat="server" Text="Proveído Específico: " >
                            </asp:Label>
                            <asp:TextBox ID="txtProeidoEspecifico" runat="server"
                                TextMode="MultiLine" Width="312px"
                                onkeyup="resizemultilineTextBox(this)">
                            </asp:TextBox>
                            <asp:ImageButton ID="imgBuscarTramite" runat="server"  ImageUrl="~/Imagenes/32adicionar.png" 
                                ToolTip="Buscar e Insertar Tramite" OnClick="imgBuscarTramite_Click" 
                                Enabled="false" /> 
                            <asp:Label ID="Label9" CssClass="etiqueta8Blue" runat="server" Text="Buscar e Insertar Tramite" />
                        </asp:Panel>
                    </td>
                <td width="1%">
                    <asp:Button ID="btnVerBandejaTrabajo" runat="server" Text="Bandeja de Trabajo Filtrada" 
                        OnClick="btnVerBandejaTrabajoFiltrada_Click" Enabled="false" />
                </td>
            </tr>
            <tr>
                <td width="1%" colspan="2"></td>
                <td width="97%" align="center">
                    <asp:Label ID="lblDetalleTramitesDerivarse" runat="server" 
                        Text="Detalle de Trámites para derivarse" CssClass="etiqueta10" 
                        Font-Bold="True" Visible="false"></asp:Label>
                    <asp:GridView ID="gvBandejaTrabajo" runat="server" AutoGenerateColumns="false"
                        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                        CellPadding="3" Font-Names="Verdana" Font-Size="8pt" 
                        DataKeyNames="IdTramite,IdUsuarioActividad,t430"
                        AllowPaging="True" PageSize="10" 
                        AllowSorting="True"
                        OnSorting="gvBandejaTrabajo_Sorting"
                        OnPageIndexChanging="gvBandejaTrabajo_PageIndexChanging" 
                        OnRowDataBound="gvBandejaTrabajo_RowDataBound"
                        OnRowCommand="gvBandejaTrabajo_RowCommand" >
                        <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                        <AlternatingRowStyle BackColor="#F7F7F7" />
                        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#FFDAB9" Font-Bold="True" ForeColor="#333333" />
                        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <PagerSettings Mode="NumericFirstLast" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        <Columns>
                            <asp:TemplateField ItemStyle-Width="40px">
                                <HeaderTemplate>
                                    <asp:CheckBox ID="chkAll" runat="server" onclick = "chkAll(this);" />
                                </HeaderTemplate>
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkTramite" runat="server" ></asp:CheckBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="CRENTA">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgHistorial" runat="server" 
                                    CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" 
                                    CommandName="Historial"
                                    ToolTip="Historial del Trámite" AlternateText='<%# Bind("NumeroTramiteCrenta") %>' />
                                </ItemTemplate>
                                <ItemStyle Font-Bold="True" ForeColor="WhiteSmoke" BackColor="DimGray" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="IdTramite" HeaderText="Trámite" Visible="true" SortExpression="IdTramite" />
                            <asp:BoundField DataField="TipoTramite" HeaderText="Procedimiento" Visible="true" />
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre Completo" Visible="true" />
                            <asp:BoundField DataField="FechaIngreso" HeaderText="Fecha Ingreso" Visible="true"
                                SortExpression="FechaIngreso" DataFormatString="{0:d}" />
                            <asp:BoundField DataField="Regional" HeaderText="Regional" Visible="true" SortExpression="Regional" />
                            <asp:BoundField DataField="EstadoTramite" HeaderText="Estado Tramite" Visible="true" />
                            <asp:BoundField DataField="Sector" HeaderText="Sector" Visible="true" />
                        </Columns>
                        <EmptyDataTemplate><div align="center" class="CajaDialogoAdvertencia">
                            <br/><img src="../Imagenes/warning.gif" 
                                    alt="No existen tramites pre seleccionados para derivarse" />
                            <br/>No existen tramites pre seleccionados para derivarse
                            <br/><br/>
                            </div>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </td>
                <td width="1%">
                    <asp:ImageButton ID="imgPreEnvio" runat="server"  
                        ImageUrl="~/Imagenes/32TramiteAcepta.gif" ToolTip="Pre Envio y Validación"
                        OnClick="imgPreEnvio_Click" Enabled="false" /> 
                    <asp:Label ID="Label11" CssClass="etiqueta8Blue" runat="server" Text="Pre Envio y Validación" />
                </td>
            </tr>
            <tr>
                <td width="1%" colspan="2"></td>
                <td width="97%" align="center">
                    <asp:Label ID="Label7" runat="server" Text="Detalle de Trámites seleccionados para derivarse" CssClass="etiqueta10" Font-Bold="True"></asp:Label>
                    <asp:GridView ID="gvBandejaEnvio" runat="server" AutoGenerateColumns="false"
                        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                        CellPadding="3" Font-Names="Verdana" Font-Size="8pt" 
                        DataKeyNames="IdTramite" OnRowCommand="gvBandejaEnvio_RowCommand" >
                        <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                        <AlternatingRowStyle BackColor="#F7F7F7" />
                        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#FFDAB9" Font-Bold="True" ForeColor="#333333" />
                        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <Columns>
                            <asp:TemplateField ItemStyle-Width="40px">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImageButton1" runat="server" 
                                        ImageUrl="~/Imagenes/32cortar.png" 
                                        CommandName="EXCLUIR"
                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                </HeaderTemplate>
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemTemplate>
                                    <asp:ImageButton ID="imbProveido" runat="server" ImageUrl="~/Imagenes/pequeños/16EditTextDocumentAdd.gif" 
                                        CommandName="IMGProveido" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Numerador" HeaderText="Numerador" Visible="true" />
                            <asp:BoundField DataField="IdRuta" HeaderText="Ruta" Visible="true" />
                            <asp:TemplateField HeaderText="CRENTA">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgHistorial" runat="server" 
                                    CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" 
                                    CommandName="Historial"
                                    ToolTip="Historial del Trámite" AlternateText='<%# Bind("NumeroTramiteCrenta") %>' />
                                </ItemTemplate>
                                <ItemStyle Font-Bold="True" ForeColor="WhiteSmoke" BackColor="DimGray" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="IdTramite" HeaderText="Trámite" Visible="true" />
                            <asp:BoundField DataField="Matricula" HeaderText="Matricula" Visible="true" />
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre Completo" Visible="true" />
                            <asp:BoundField DataField="FechaIngreso" HeaderText="Fecha Ingreso" Visible="true" DataFormatString="{0:d}" />
                            <asp:TemplateField HeaderText="Proveído">
                                <ItemTemplate>
                                    <asp:Label ID="lblProveidoE" runat="server" Text='<%# Bind("ObsSalidaArea") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate><div align="center" class="CajaDialogoAdvertencia">
                            <br/><img src="../Imagenes/warning.gif" 
                                    alt="No existen tramites seleccionados para derivar" />
                            <br/>No existen tramites seleccionados para derivar
                            <br/><br/>
                            </div>
                        </EmptyDataTemplate>
                    </asp:GridView>                    
                </td>
                <td width="1%"></td>
            </tr>
            <tr>
                <td width="1%"></td>
                <td width="10%" align="right">
                </td>
                <td width="50%">
                    <asp:Label ID="Label12"  CssClass="etiqueta10"  runat="server" Text="Fecha de Envío: "></asp:Label>
                    <asp:TextBox ID="txtFechaAsignacion" runat="server" BackColor="#87CEEB" Width="75px" Enabled="false"></asp:TextBox>
                    <cc1:TextBoxWatermarkExtender ID="txtFechaAsignacion_TextBoxWatermarkExtender" 
                        runat="server" Enabled="True" TargetControlID="txtFechaAsignacion" 
                        WatermarkText="__/__/____">
                    </cc1:TextBoxWatermarkExtender>
                    <asp:ImageButton ID="imgPopup" ImageUrl="../Imagenes/pequeños/CalendarC_16x16.png" ImageAlign="Bottom"
                        runat="server" Enabled="false" />
                    <cc1:CalendarExtender ID="txtFechaAsignacion_CalendarExtender" PopupButtonID="imgPopup" runat="server" TargetControlID="txtFechaAsignacion"
                        Format="dd/MM/yyyy">
                    </cc1:CalendarExtender>
                    <br />
                    <asp:Label ID="Label16"  CssClass="etiqueta10"  runat="server" Text="Proveido General: "></asp:Label>
                    <asp:TextBox runat="server" ID="txtProveidoGeneral" TextMode="MultiLine" Columns="50" Rows="10" Text="" />
                    <br />
                    <asp:ImageButton ID="imgEnvioTramite" runat="server"  
                        ImageUrl="~/Imagenes/32TramiteAcepta.gif" ToolTip="Asignar los Tramites"
                        OnClick="imgEnvioTramite_Click" 
                        onclientclick="return confirm('Esta seguro de asignar los tramites ?');"
                        Enabled="false" /> 
                    <asp:Label ID="Label13" CssClass="etiqueta8Blue" runat="server" Text="Efectuar Envio" />
                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="ValRepro2" />
                    <asp:ImageButton ID="imgImprime430GeneradoPDF" runat="server" 
		                    ImageUrl="~/Imagenes/reportes/pdf32.png" ToolTip="Imprimir F430"
                        OnClick="imgImprime430GeneradoPDF_Click" 
                        Visible="false" /> 
                    <asp:Label ID="lblImprime430Generadopdf" CssClass="etiqueta8Blue" runat="server" 
                        Text="Imprimir el F430 generado" Visible="false" /><br />
                </td>
                <td width="1%">
                </td>
            </tr>
            <tr>
                <td width="1%"><hr /></td>
                <td width="10%" align="left">
                    <hr />
                </td>
                <td width="50%"><hr /></td>
                <td width="1%"><hr /></td>
            </tr>
            </table>
        </ContentTemplate>
    </cc1:TabPanel>
    <cc1:TabPanel runat="server" ID="Panel3" HeaderText="Bandeja de Salida" OnClientClick="Panel3Click">
        <ContentTemplate>
            <table style="width: 100%;" cellpadding="0" cellspacing="0" class="panelceleste">
            <tr>
                <td width="1%"></td>
                <td width="78%" align="right">
                    <asp:Panel ID="panel5" runat="server" 
                        DefaultButton="imgBuscarSalida" Width="100%" >
                    <asp:Label ID="Label15"  CssClass="etiqueta10"  runat="server" Text="Numero Tramite: " >
                    </asp:Label>
                    <asp:TextBox  ID="txtNumeroTramiteSalida" runat="server" 
                        style="margin-bottom: 0px" onkeypress="return jsNumbers(event, 'num_car')"
                        MaxLength="12"></asp:TextBox>
                    <asp:ImageButton ID="imgBuscarSalida" runat="server"  ImageUrl="~/Imagenes/32Buscar.png" ToolTip="Buscar Datos" 
                        OnClick="imgBuscarSalida_Click" Enabled="false"/> 
                    <asp:Label ID="Label19" CssClass="etiqueta8Blue" runat="server" Text="Buscar" />
                    <asp:ImageButton ID="imgImprimeBandejaSalida" runat="server"  
                        ImageUrl="~/Imagenes/32imprimir.png" ToolTip="Imprime Bandeja de Salida" 
                        OnClick="imgImprimeBandejaSalida_Click" Visible="false" />
                    <asp:Label ID="lblImprimeBandejaSalida" CssClass="etiqueta8Blue" runat="server" Text="Reporte Bandeja de Salida" Visible="false" />                                               
                    </asp:Panel>
                </td>
                <td width="1%"></td>
                <td width="9%">
                </td>
                <td width="10%">
                </td>
                <td width="1%"></td>
            </tr>
            <tr>
                <td width="1%"></td>
                <td width="78%" align="left">
                    <hr />
                </td>
                <td width="1%"></td>
                <td width="9%">
                </td>
                <td width="10%">
                </td>
                <td width="1%"></td>
            </tr>
            <tr>
                <td width="1%"></td>
                <td width="78%" align="left">
                    <asp:Label ID="Label14" runat="server" Text="Bandeja de Salida" CssClass="etiqueta10" Font-Bold="True"></asp:Label>
                    <asp:GridView ID="gvBandejaSalida" runat="server" AutoGenerateColumns="false"
                        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                        CellPadding="3" Font-Names="Verdana" Font-Size="8pt" SkinID="GridView"
                        OnRowCommand="gvBandejaSalida_RowCommand" 
                        DataKeyNames="Id430,CuentaUsuario,IdUsuarioDestino,IdAreaDestino,FechaIngreso"
                        AllowPaging="True" PageSize="20" 
                        OnPageIndexChanging="gvBandejaSalida_PageIndexChanging"
                        AllowSorting="True" 
                        OnSorting="gvBandejaSalida_Sorting">
                        <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                        <AlternatingRowStyle BackColor="#F7F7F7" />
                        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#FFDAB9" Font-Bold="True" ForeColor="#333333" />
                        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <PagerSettings Mode="NumericFirstLast" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        <Columns>
                            <asp:BoundField DataField="Id430" HeaderText="F430" Visible="true" SortExpression="Id430" />
                            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" Visible="true" SortExpression="Descripcion" />
                            <asp:BoundField DataField="CuentaUsuario" HeaderText="Usuario Origen" Visible="true" SortExpression="CuentaUsuario" />
                            <asp:BoundField DataField="FechaIngreso" HeaderText="Fecha Ingreso" Visible="true" SortExpression="FechaIngreso" DataFormatString="{0:d}"/>
                            <asp:BoundField DataField="CantidadExpedientes" HeaderText="Cantidad Expedientes" Visible="true" SortExpression="CantidadExpedientes" />
                            <asp:BoundField DataField="Proveido" HeaderText="Proveido" Visible="true" ItemStyle-Width="315px" />
                            <asp:TemplateField ItemStyle-Width="40px">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgDetTramite" runat="server" 
                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                            CommandName="DETALLE01"
                                            ImageUrl="~/Imagenes/16AttachDocumentMoveDown.gif" CausesValidation="false" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="40px">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgImprime430xls" runat="server" 
                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                            CommandName="IMPRIME430xls"
                                            ImageUrl="~/Imagenes/reportes/excel32.jpg" CausesValidation="false" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Width="40px">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgImprime430pdf" runat="server" 
                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                            CommandName="IMPRIME430pdf"
                                            ImageUrl="~/Imagenes/reportes/pdf32.png" CausesValidation="false" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate><div align="center" class="CajaDialogoAdvertencia">
                            <br/><img src="../Imagenes/warning.gif" 
                                    alt="No existen tramites remitidos" />
                            <br/>No existen tramites remitidos
                            <br/><br/>
                            </div>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </td>
                <td width="1%"></td>
                <td width="9%">
                </td>
                <td width="10%">
                </td>
                <td width="1%"></td>
            </tr>
            </table>
            <table style="width: 100%;" cellpadding="0" cellspacing="0" class="panelceleste">
            <tr>
                <td width="1%"></td>
                <td width="98%" align="left">
                    <asp:Label ID="Label23" runat="server" Text="Detalle de Trámites enviados" CssClass="etiqueta10" Font-Bold="True"></asp:Label>
                    <asp:GridView ID="gvBandejaSalidaDetalle" runat="server" AutoGenerateColumns="false"
                        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                        CellPadding="3" Font-Names="Verdana" Font-Size="7pt"
                        OnRowCommand="gvBandejaSalidaDetalle_RowCommand" 
                        DataKeyNames="Id430,IdTramite,IdTipoTramite" >
                        <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                        <AlternatingRowStyle BackColor="#F7F7F7" />
                        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#FFDAB9" Font-Bold="True" ForeColor="#333333" />
                        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <Columns>
                            <asp:TemplateField ItemStyle-Width="40px">
                                <HeaderTemplate>
                                    <asp:CheckBox ID="chkAll" runat="server" onclick = "chkAll(this);" />
                                </HeaderTemplate>
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkTramite" runat="server" ></asp:CheckBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Id430" HeaderText="F430" Visible="true" />
                            <asp:BoundField DataField="Fila" HeaderText="Fila" Visible="true" />
                            <asp:BoundField DataField="AreaOrigen-AreaDestino" HeaderText="AreaOrigen - AreaDestino" Visible="true" />
                            <asp:TemplateField HeaderText="Tramite">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgHistorial" runat="server" 
                                    CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" 
                                    CommandName="Historial"
                                    ToolTip="Historial del Trámite" AlternateText='<%# Bind("NumeroTramiteCrenta") %>' />
                                </ItemTemplate>
                                <ItemStyle Font-Bold="True" ForeColor="WhiteSmoke" BackColor="DimGray" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="IdTramite" HeaderText="Trámite" Visible="true" />
                            <asp:BoundField DataField="TipoTramite" HeaderText="Procedimiento" Visible="true" />
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre Completo" Visible="true" />
                            <asp:BoundField DataField="FechaIngreso" HeaderText="Fecha Ingreso" Visible="true" DataFormatString="{0:d}" />
                            <asp:BoundField DataField="Regional" HeaderText="Regional" Visible="true" />
                            <asp:BoundField DataField="EstadoTramite" HeaderText="Estado Tramite" Visible="true" />
                            <asp:BoundField DataField="Sector" HeaderText="Sector" Visible="true" />
                            <asp:BoundField DataField="ObsSalidaArea" HeaderText="Obs Salida Area" Visible="true" />
                        </Columns>
                        <EmptyDataTemplate><div align="center" class="CajaDialogoAdvertencia">
                            <br/><img src="../Imagenes/warning.gif" 
                                    alt="No existen tramites remitidos" />
                            <br/>No existen tramites remitidos
                            <br/><br/>
                            </div>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </td>
                <td width="1%" ></td>
            </tr>
            <tr>
                <td width="1%"></td>
                <td width="98%" colspan="4">
                    <asp:ImageButton ID="imgTramiteCancela" runat="server"
                        ImageUrl="~/Imagenes/32TramiteRechaza.gif" ToolTip="Cancelar Tramites enviados"
                        OnClick="imgTramiteCancela_Click" onclientclick="return confirm('Esta seguro de Cancelar los tramites marcados ?');" />
                    <asp:Label ID="lblCancelar" CssClass="etiqueta8Blue" runat="server" Text="Cancelar" />
                </td>
                <td width="1%" style="text-align:left" class="auto-style7">
                </td>
            </tr>
            </table>
        </ContentTemplate>
    </cc1:TabPanel>
    <cc1:TabPanel runat="server" ID="Panel4" HeaderText="Seguimiento" >
        <ContentTemplate>
            <table style="width: 100%;" cellpadding="0" cellspacing="0" class="panelceleste">
            <tr>
                <td width="1%"></td>
                <td width="78%" align="right">
                    <asp:Panel ID="panSearchSE" runat="server" 
                            DefaultButton="imgBuscarSeguimiento" Width="100%" >
                    <asp:Label ID="Label2"  CssClass="etiqueta10"  runat="server" Text="Numero Tramite: " >
                    </asp:Label>
                    <asp:TextBox  ID="txtNumeroTramiteSeguimiento" runat="server" 
                        style="margin-bottom: 0px" onkeypress="return jsNumbers(event, 'num_car')"
                        MaxLength="12"></asp:TextBox>
                    <asp:ImageButton ID="imgBuscarSeguimiento" runat="server"  ImageUrl="~/Imagenes/32Buscar.png" ToolTip="Buscar Datos" 
                        OnClick="imgBuscarSeguimiento_Click" /> 
                    <asp:Label ID="Label3" CssClass="etiqueta8Blue" runat="server" Text="Buscar" />
                    </asp:Panel> 
                </td>
                <td width="1%"></td>
                <td width="9%">
                </td>
                <td width="10%">
                </td>
                <td width="1%"></td>
            </tr>
            <tr>
                <td width="1%"></td>
                <td width="78%" align="left">
                    <hr />
                </td>
                <td width="1%"></td>
                <td width="9%">
                </td>
                <td width="10%">
                </td>
                <td width="1%"></td>
            </tr>
            <tr>
                <td width="1%"></td>
                <td width="78%" align="left">
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="Label22" runat="server" Text="Desde: " CssClass="etiqueta10"></asp:Label>
                                <asp:TextBox ID="txtDesde" runat="server" 
                                    BackColor="#87CEEB" Width="75px"
                                    onkeypress="return jsNumbers(event, 'num')"
                                    onKeyUp="javascript:return mask(this.value,this,'2,5','/');" 
                                    onBlur="javascript:return mask(this.value,this,'2,5','/');" 
                                    MaxLength="10">
                                </asp:TextBox>
                                <cc1:TextBoxWatermarkExtender ID="txtDesde_TextBoxWatermarkExtender" 
                                    runat="server" Enabled="True" TargetControlID="txtDesde" 
                                    WatermarkText="__/__/____">
                                </cc1:TextBoxWatermarkExtender>
                                <asp:ImageButton ID="ImageButton5" ImageUrl="../Imagenes/pequeños/CalendarC_16x16.png" ImageAlign="Bottom" runat="server" />
                                <cc1:CalendarExtender ID="txtDesde_CalendarExtender" PopupButtonID="ImageButton5" runat="server" TargetControlID="txtDesde"
                                    Format="dd/MM/yyyy">
                                </cc1:CalendarExtender>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </td>
                            <td>
                                <asp:Label ID="Label27" runat="server" Text="Hasta: " CssClass="etiqueta10"></asp:Label>
                                <asp:TextBox ID="txtHasta" runat="server" 
                                    BackColor="#87CEEB" Width="75px"
                                    onkeypress="return jsNumbers(event, 'num')"
                                    onKeyUp="javascript:return mask(this.value,this,'2,5','/');" 
                                    onBlur="javascript:return mask(this.value,this,'2,5','/');" 
                                    MaxLength="10">
                                </asp:TextBox>
                                <cc1:TextBoxWatermarkExtender ID="txtHasta_TextBoxWatermarkExtender" 
                                    runat="server" Enabled="True" TargetControlID="txtHasta" 
                                    WatermarkText="__/__/____">
                                </cc1:TextBoxWatermarkExtender>
                                <asp:ImageButton ID="ImageButton6" ImageUrl="../Imagenes/pequeños/CalendarC_16x16.png" ImageAlign="Bottom" runat="server" />
                                <cc1:CalendarExtender ID="CalendarExtender1" PopupButtonID="ImageButton6" runat="server" TargetControlID="txtHasta"
                                    Format="dd/MM/yyyy">
                                </cc1:CalendarExtender>
                            </td>
                            <td>
                                <asp:ImageButton ID="ImageButton4" runat="server"  ImageUrl="~/Imagenes/32Procesar.png" ToolTip="Buscar Datos" 
                                    OnClick="imgSeguimientoTramites_Click" /> 
                                <asp:Label ID="Label28" CssClass="etiqueta8Blue" runat="server" Text="Seguimiento de Tramites" /> 
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:GridView ID="gvSeguimientoTramite" runat="server" AutoGenerateColumns="true"
                                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                                    CellPadding="3" Font-Names="Verdana" Font-Size="8pt">
                                    <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                                    <AlternatingRowStyle BackColor="#F7F7F7" />
                                    <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                                    <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                                    <SelectedRowStyle BackColor="#FFDAB9" Font-Bold="True" ForeColor="#333333" />
                                    <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    <Columns>
                                    </Columns>
                                    <EmptyDataTemplate><div align="center" class="CajaDialogoAdvertencia">
                                        <br/><img src="../Imagenes/warning.gif" 
                                                alt="No existen tramites remitidos" />
                                        <br/>No existen tramites remitidos
                                        <br/><br/>
                                        </div>
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </td>
                <td width="1%"></td>
                <td width="9%">
                </td>
                <td width="10%">
                </td>
                <td width="1%"></td>
            </tr>
            <tr>
                <td width="1%"></td>
                <td width="78%" align="left">
                    <hr />
                </td>
                <td width="1%"></td>
                <td width="9%">
                </td>
                <td width="10%">
                </td>
                <td width="1%"></td>
            </tr>
            </table>
        </ContentTemplate>
    </cc1:TabPanel>
</cc1:TabContainer>
<cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server"
    TargetControlID="lblTituloAUX" PopupControlID="pnlComentarioProveidoEspecifico"
    CancelControlID="btnCancel" BackgroundCssClass="modalBackground">
</cc1:ModalPopupExtender>
<asp:Panel ID="pnlComentarioProveidoEspecifico" runat="server" CssClass="panelprincipal">
<asp:HiddenField ID="HFProveidoTrans" runat="server" Value="0" />
<div>
<table width="100%" >
	<tr style="background-color:#0099FF">
	    <td colspan="2"  align="center">
            <asp:Label ID="Label17" runat="server" Text="Remite Proveido Específico para la transición"></asp:Label></td>
	</tr>
	<tr>
		<td align="left" colspan="2">
            <asp:Label ID="Label18" runat="server" Text="Ingrese Proveido"></asp:Label>
		</td>
	</tr>
	<tr>
		<td align="left" colspan="2">
            <asp:TextBox ID="txtProveidoTrans" runat="server" Height="69px" Width="389px"></asp:TextBox>
		</td>
	</tr>
	<tr>
		<td align="right" >
		<asp:Button ID="btnProveido" CommandName="Proveido" runat="server" Text="Graba Proveido" OnClick="btnProveido_Click" />
		</td>
		<td>
		<asp:Button ID="btnCancel" runat="server" Text="Cancelar" OnClick="btnCancel_Click"/>
		</td>
	</tr>
</table>
</div>
</asp:Panel>
<cc1:ModalPopupExtender ID="ModalPopupExtender2" runat="server" 
    TargetControlID="imgAux" PopupControlID="pnlHisTramites" BackgroundCssClass="ModalPopupBG"
    CancelControlID="btnVolver" Drag="true" PopupDragHandleControlID="PopupHeader">
</cc1:ModalPopupExtender>
<div id="pnlHisTramites" style="display: none;" class="popupExtense" >
    <div class="popup_Container">
        <div class="popup_Titlebar" id="PopupHeader">
            <div class="TitlebarLeft">
                <asp:Label ID="lblTHistTram" CssClass="texto10" Font-Bold="true"  runat="server" Text="Historial del Trámite: "></asp:Label>
                <asp:Label ID="lblHIdTramite" CssClass="texto10" Font-Bold="true"  runat="server" Text=""></asp:Label>
            </div>
            <div class="TitlebarRight"></div>
        </div>
        <div class="popup_Body">
            <table style="width: 100%;">
                <tr>
                    <td align="center" valign="top">
                        <asp:GridView ID="gvBusqMaestro" runat="server" SkinID="GridView" 
                            DataKeyNames="IdTramite" AutoGenerateColumns="False" 
                            Width="100%">
                            <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                            <Columns>
                                <asp:BoundField DataField="Id430" HeaderText="Id430" />
                                <asp:BoundField DataField="NumeroTramiteCrenta" HeaderText="CRENTA" Visible="true" 
                                    ItemStyle-Font-Bold="True" ItemStyle-ForeColor="WhiteSmoke" ItemStyle-BackColor="DimGray"/>                                
                                <asp:BoundField DataField="IdTramite" HeaderText="Trámite" />      
                                <asp:BoundField DataField="Matricula" HeaderText="Matricula" />
                                <asp:BoundField DataField="AreaDestino" HeaderText="Area Destino" />      
                                <asp:BoundField DataField="UsuarioDestino" HeaderText="Usuario Destino" />      
                                <asp:BoundField DataField="FechaIngreso" HeaderText="Fecha Ingreso" DataFormatString="{0:d}" />      
                                <asp:BoundField DataField="FechaSalida" HeaderText="Fecha Salida" DataFormatString="{0:d}" />      
                                <asp:BoundField DataField="EstadoTramite" HeaderText="Estado Tramite" />      
                                <asp:BoundField DataField="ObsSalidaArea" HeaderText="Obs Salida Area" />      
                            </Columns>
                            <EmptyDataTemplate>
                                <div align="center" class="CajaDialogoAdvertencia" style="width: 1100px">
                                    <br/>
                                    <img src="../Imagenes/warning.gif" 
                                        alt="Historial de movimientos del tramite" />
                                    <br/>
                                    No existe historial de movimientos del tramite.
                                    <br/>
                                    <br/>
                                </div>
                            </EmptyDataTemplate>
                        </asp:GridView>                        
                    </td>
                </tr>
            </table>
        </div>
        <div class="popup_Buttons">
            <input id="btnVolver" value="Volver" type="button" />
        </div>
    </div>
</div>
</asp:Content>

