<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmBuscadorDeTramites.aspx.cs" Inherits="Reprocesos_wfrmBuscadorDeTramites" %>

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
<style type="text/css">
  #modalContainer {
  	background-color:transparent;
  	position:absolute;
  	width:100%;
  	height:100%;
  	top:0px;
  	left:0px;
  	z-index:10000;
  }
  #modalContainer2 {
  	background-color:transparent;
  	position:absolute;
  	width:100%;
  	height:100%;
  	top:0px;
  	left:0px;
  	z-index:10000;
  	background-image:url(../Imagenes/32Alert01.png); /* required by MSIE to prevent actions on lower z-index elements */
  }  
  #alertBox {
  	position:relative;
  	width:800px;    /* MessageBox with */
  	min-height:400px; /* MessageBox height*/
  	margin-top:50px;
  	border:2px solid #000;
  	background-color:#F2F5F6;
  	background-image:url(../Imagenes/32Info3.png);
  	background-repeat:no-repeat;
  	background-position:20px 30px;
  }
  #alertBox2 {
  	position:relative;
  	width:300px;
  	min-height:100px;
  	margin-top:50px;
  	border:2px solid #000;
  	background-color:#F2F5F6;
  	background-image:url(../Imagenes/32Alert01.png);
  	background-repeat:no-repeat;
  	background-position:20px 30px;
  }  
  #modalContainer > #alertBox {
  	position:fixed;
  }
  
  #alertBox h1 {
  	margin:0;
  	font:bold 0.9em verdana,arial;
  	background-color:#78919B;
  	color:#FFF;
  	border-bottom:1px solid #000;
  	padding:2px 0 2px 5px;
  }
  
  #alertBox p {
  	font:0.7em verdana,arial;
  	height:300px;  /* OK button row possition */
  	padding-left:5px;
  	margin-left:55px;
  }
  
  #alertBox #closeBtn {
  	display:block;
  	position:relative;
  	margin:5px auto;
  	padding:3px;
  	border:2px solid #000;
  	width:170px;
  	font:0.7em verdana,arial;
  	text-transform:uppercase;
  	text-align:center;
  	color:#FFF;
  	background-color:#78919B;
  	text-decoration:none;
  }
  
  /* unrelated styles */
  
  #mContainer {
  	position:relative;
  	width:600px;
  	margin:auto;
  	padding:5px;
  	border-top:2px solid #000;
  	border-bottom:2px solid #000;
  	font:0.7em verdana,arial;
  }
  
  h1,h2 {
  	margin:0;
  	padding:4px;
  	font:bold 1.5em verdana;
  	border-bottom:1px solid #000;
  }
  
  code {
  	font-size:1.2em;
  	color:#069;
  }
  
  #credits {
  	position:relative;
  	margin:25px auto 0px auto;
  	width:350px; 
  	font:0.7em verdana;
  	border-top:1px solid #000;
  	border-bottom:1px solid #000;
 	height:90px;
 	padding-top:4px;
 }
 
 #credits img {
 	float:left;
 	margin:5px 10px 5px 0px;
 	border:1px solid #000000;
 	width:80px;
 	height:79px;
 }
 
 .important {
 	background-color:#F5FCC8;
 	padding:2px;
 }
 
 code span {
 	color:green;
 }
</style>
<script type="text/javascript">
    var ALERT_TITLE = "Información!";
    var ALERT_BUTTON_TEXT = "Ok";

    if (document.getElementById) {
        window.alert = function (txt) {
            createCustomAlert(txt);
        }
    }

    function createCustomAlert(txt) {
        d = document;

        if (d.getElementById("modalContainer")) return;

        mObj = d.getElementsByTagName("body")[0].appendChild(d.createElement("div"));
        mObj.id = "modalContainer";
        mObj.style.height = d.documentElement.scrollHeight + "px";

        alertObj = mObj.appendChild(d.createElement("div"));
        alertObj.id = "alertBox";
        if (d.all && !window.opera) alertObj.style.top = document.documentElement.scrollTop + "px";
        alertObj.style.left = (d.documentElement.scrollWidth - alertObj.offsetWidth) / 2 + "px";
        alertObj.style.visiblity = "visible";

        h1 = alertObj.appendChild(d.createElement("h1"));
        h1.appendChild(d.createTextNode(ALERT_TITLE));

        msg = alertObj.appendChild(d.createElement("p"));
        //msg.appendChild(d.createTextNode(txt));
        msg.innerHTML = txt;

        btn = alertObj.appendChild(d.createElement("a"));
        btn.id = "closeBtn";
        btn.appendChild(d.createTextNode(ALERT_BUTTON_TEXT));
        btn.href = "#";
        btn.focus();
        btn.onclick = function () { removeCustomAlert(); return false; }

        alertObj.style.display = "block";
    }

    function removeCustomAlert() {
        document.getElementsByTagName("body")[0].removeChild(document.getElementById("modalContainer"));
    }
</script>
<script type="text/javascript">
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
</script> 
<style type="text/css">
    .auto-style1 {
        height: 97px;
    }
    .auto-style2 {
        width: 334px;
    }
    .auto-style3 {
        height: 97px;
        width: 334px;
    }
    .auto-style5 {
        width: 160px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:TextBox ID="TextBox1" runat="server" Visible="false"></asp:TextBox>
<asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Imagenes/16calendario.png"  Visible="false"/>
<cc1:CalendarExtender ID="CalendarExtender3" runat="server" PopupButtonID="ImageButton1" TargetControlID="TextBox1" ></cc1:CalendarExtender>
     <table style="width: 100%;" class="panelceleste">
        <tr>
            <td align="center">
                <asp:ImageButton ID="imgAux" runat="server" ImageUrl="~/Imagenes/16w.png" />
                <asp:Label ID="lblTituloAUX" runat="server" Text="BUSCADOR DE TRAMITES" CssClass="etiqueta20"> </asp:Label>
            </td>
        </tr>
        <tr>
             <td >
                 <asp:Panel ID="pnlBusqueda" runat="server" Visible="true" DefaultButton="imgBuscar" Width="100%">
                    <table width="100%" class="panelceleste" >
                        <tr>
                            <td style="text-align:right">
                                <asp:Label ID="lblNumeroTramite"  CssClass="etiqueta10"  runat="server" Text="Numero Tramite: " /> 
                            </td>
                            <td style="text-align:left"> 
                                <asp:TextBox  ID="txtNumeroTramite" runat="server" 
                                    style="margin-bottom: 0px" onkeypress="return jsNumbers(event, 'num')"
                                    MaxLength="7"></asp:TextBox>
                            </td>
                            <td style="text-align:right">
                                <asp:Label ID="lblPaterno"  CssClass="etiqueta10"  runat="server" Text="Paterno: " /> 
                            </td>
                            <td style="text-align:left"> 
                                <asp:TextBox  ID="txtPaterno" runat="server" style="margin-bottom: 0px; text-transform: uppercase"></asp:TextBox>
                            </td>
                            <td style="text-align:right">
                                <asp:Label ID="lblMaterno"  CssClass="etiqueta10"  runat="server" Text="Materno: " /> 
                            </td>
                            <td style="text-align:left"> 
                                <asp:TextBox  ID="txtMaterno" runat="server" style="margin-bottom: 0px; text-transform: uppercase"></asp:TextBox>
                            </td>
                            <td style="text-align:right">
                                <asp:Label ID="lblNombres"  CssClass="etiqueta10"  runat="server" Text="Nombres: " /> 
                            </td>
                            <td style="text-align:left"> 
                                <asp:TextBox  ID="txtNombres" runat="server" style="margin-bottom: 0px; text-transform: uppercase"></asp:TextBox>
                            </td>
                            <td style="width:20%; text-align:left">  
                                <asp:ImageButton ID="imgBuscar" runat="server"  
                                    ImageUrl="~/Imagenes/32Buscar.png" ToolTip="Buscar Datos" 
                                    OnClick="imgBuscar_Click" /> 
                                <asp:Label ID="lblRefres" CssClass="etiqueta8Blue" runat="server" Text="Buscar" /> 
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align:right">
                                <asp:Label ID="lblDescEstadoObjeto"  CssClass="etiqueta10"  runat="server" Text="Estado de Tramite: " /> 
                            </td>
                            <td style="text-align:left" colspan="9">
                                <asp:DropDownList ID="dllEstadoTramite" runat="server">
                                    <asp:ListItem Value="-1">Todos (*)</asp:ListItem>
                                    <asp:ListItem Value="1">Registrado</asp:ListItem>
                                    <asp:ListItem Value="3">Pendiente para Certificacion</asp:ListItem>
                                    <asp:ListItem Value="8">Certificacion Concluida</asp:ListItem>
                                    <asp:ListItem Value="13">Tramite concluido</asp:ListItem>
                                    <asp:ListItem Value="23">Tramite en Recurso</asp:ListItem>
                                    <asp:ListItem Value="30">Formulario de Cálculo Emitido</asp:ListItem>
                                    <asp:ListItem Value="32">Certificado Emitido</asp:ListItem>
                                    <asp:ListItem Value="39">Renuncia CC Automática</asp:ListItem>
                                    <asp:ListItem Value="41">Error</asp:ListItem>
                                    <asp:ListItem Value="42">Tramite en Reproceso</asp:ListItem>
                                    <asp:ListItem Value="46">Tramite Reprocesado</asp:ListItem>
                                    <asp:ListItem Value="53">Pre-Renuncia CC Automática</asp:ListItem>
                                    <asp:ListItem Value="61">Anulacion de Tramite por R.A.</asp:ListItem>
                                    <asp:ListItem Value="62">Migrado con incosistencias</asp:ListItem>
                                </asp:DropDownList>
                                &nbsp;&nbsp;
                                <asp:Label ID="Label4"  CssClass="etiqueta10"  runat="server" Text="Estado del Certificado: " /> 
                                <asp:DropDownList ID="dllEstadoCertificado" runat="server">
                                    <asp:ListItem Value="-1">Todos (*)</asp:ListItem>
                                    <asp:ListItem Value="0">Inicial</asp:ListItem>
                                    <asp:ListItem Value="12">Registro APS</asp:ListItem>
                                    <asp:ListItem Value="33">Certificado Generado</asp:ListItem>
                                    <asp:ListItem Value="34">Certificado Impreso</asp:ListItem>
                                    <asp:ListItem Value="36">Certificado Anulado por Reimpresión</asp:ListItem>
                                    <asp:ListItem Value="37">Baja APS</asp:ListItem>
                                    <asp:ListItem Value="38">Certificado Anulado por Reproceso</asp:ListItem>
                                    <asp:ListItem Value="41">Error</asp:ListItem>
                                    <asp:ListItem Value="61">Anulación de Trámite por R.A.</asp:ListItem>
                                </asp:DropDownList>
                                &nbsp;&nbsp;
                                <asp:Label ID="Label6"  CssClass="etiqueta10"  runat="server" Text="Bandeja de Trabajo: " />
                                <asp:DropDownList ID="dllBandejaTrabajo" runat="server">
                                    <asp:ListItem Value="false">Todos (*)</asp:ListItem>
                                    <asp:ListItem Value="true">Solo Trámites en Bandeja de Trabajo</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
             </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlDatosAfiliado" runat="server" Visible="false">
                    <table align="center" cellpadding="0" cellspacing="0" class="panelceleste">
                        <tr>
                            <td align="left">
                                <asp:Label ID="Label7" runat="server" Text="Filas por página:" CssClass="etiqueta10"></asp:Label>
                                <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" 
                                    OnSelectedIndexChanged="PageSize_Changed">
                                    <asp:ListItem Text="10" Value="10" />
                                    <asp:ListItem Text="25" Value="25" />
                                    <asp:ListItem Text="50" Value="50" />
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="2" class="auto-style5">
                            <div style="vertical-align: top; left: auto; height: auto; overflow: auto; width: 1200px;" class="panelceleste">
                                <asp:GridView ID="gvDatosAfiliado" runat="server"
                                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                                    CellPadding="3" Font-Names="Verdana" Font-Size="8pt" AutoGenerateColumns="false"
                                    DataKeyNames="IdTramite,IdEstadoObjetoProceso,NUP,IdGrupoBeneficio,IdTipoTramite,RegistroActivo"
                                    OnRowCommand="gvDatosAfiliado_RowCommand" 
                                    AllowSorting="True" OnSorting="gvDatosAfiliado_Sorting" >
                                    <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                                    <AlternatingRowStyle BackColor="#F7F7F7" />
                                    <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                                    <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                                    <SelectedRowStyle BackColor="#FFDAB9" Font-Bold="True" ForeColor="#333333" />
                                    <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                    <Columns>
                                        <asp:TemplateField ItemStyle-Width="40px">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgDetTramite" runat="server" 
                                                    CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                        CommandName="DETALLE01"
                                                        ImageUrl="~/Imagenes/16AttachDocumentMoveDown.gif" CausesValidation="false" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="NumFila" HeaderText="Num Fila" Visible="true" />
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
                                        <asp:BoundField DataField="TipoTramite" HeaderText="Tipo Tramite" Visible="true" SortExpression="TipoTramite" />
                                        <asp:BoundField DataField="IdEstadoObjetoProceso" HeaderText="IdEstadoObjetoProceso" Visible="false" />
                                        <asp:BoundField DataField="DescripcionEstadoObjeto" HeaderText="Estado Del Tramite" Visible="true" SortExpression="DescripcionEstadoObjeto" />
                                        <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha Nac" DataFormatString="{0:dd/MM/yyyy}" Visible="true" />                                        
                                        <asp:BoundField DataField="Matricula" HeaderText="Matricula" Visible="true" />
                                        <asp:BoundField DataField="NUP" HeaderText="NUP" Visible="true" />
                                        <asp:BoundField DataField="NumDoc" HeaderText="NumDoc" Visible="true" />
                                        <asp:BoundField DataField="PrimerApellido" HeaderText="Primer Apellido" Visible="true" />
                                        <asp:BoundField DataField="SegundoApellido" HeaderText="Segundo Apellido" Visible="true" />
                                        <asp:BoundField DataField="PrimerNombre" HeaderText="Primer Nombre" Visible="true" />
                                        <asp:BoundField DataField="NCertificados" HeaderText="NCertificados" Visible="false" />
                                        <asp:TemplateField HeaderText="RegistroActivo" Visible="true" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkRegistroActivo" runat="server" Checked='<%# Bind("RegistroActivo") %>' Enabled="false"/>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate><div align="center" class="CajaDialogoAdvertencia">
                                        <br/><img src="../Imagenes/warning.gif" 
                                                alt="No existen registros que cumplan el criterio solicitado" />
                                        <br/>No existen registros que cumplan el criterio solicitado
                                        <br/><br/>
                                        </div>
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="2" class="auto-style5">
                            <asp:Repeater ID="rptPager" runat="server">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkPage" runat="server" 
                                        Text = '<%#Eval("Text") %>' CommandArgument = '<%# Eval("Value") %>' 
                                            Enabled = '<%# Eval("Enabled") %>' OnClick = "Page_Changed" Font-Size="Small">
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:Repeater>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
    <asp:Panel ID="pnlDetalle01" runat="server" Visible="false">
    <asp:Label ID="lblMsgRegistroActivo" runat="server" Text="* TRAMITE INACTIVO" ForeColor="Red" Font-Bold="true"></asp:Label>
    <asp:HyperLink ID="hlkTramiteEnReproceso" runat="server" Text="* TRAMITE EN REPROCESO" ForeColor="Green" Font-Bold="true"></asp:HyperLink>        
    <asp:Label ID="lblMsgRenunciaCCAutomáticaFFAA" runat="server" Text="* Renuncia CC Automática FFAA" ForeColor="Green" Font-Bold="true"></asp:Label>
    <table style="width: 100%;" cellpadding="0" cellspacing="0" class="panelceleste">
        <tr>
            <td width="1%"></td>
            <td width="49%" align="left">
                <asp:Label ID="lblTitDatosAfiliado" runat="server" Text="Datos del Afiliado" CssClass="etiqueta10" Font-Bold="True"></asp:Label>
            </td>
            <td width="1%"></td>
            <td width="48%" align="left">
                <asp:Label ID="lblTitEstadoBeneficio" runat="server" Text="Estado del Beneficio" CssClass="etiqueta10" Font-Bold="True"></asp:Label>
            </td>
            <td width="1%"></td>
        </tr>
        <tr>
            <td width="1%"></td>
            <td width="49%">
                <table width="100%" cellpadding="0" cellspacing="0" class="panelceleste">
                    <tr>
                        <td align="left">
                            <table cellpadding="0" cellspacing="0" class="panelceleste">
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblTPrimerApellido" runat="server" Text="Primer Apellido:" CssClass="etiqueta10"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblPrimerApellido" runat="server" Text="" BackColor="#99CCFF" Width="134px"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblTSegundoApellido" runat="server" Text="Segundo Apellido:" CssClass="etiqueta10"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblSegundoApellido" runat="server" Text="" BackColor="#99CCFF" Width="134px"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblTPrimerNombre" runat="server" Text="Primer Nombre:" CssClass="etiqueta10"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblPrimerNombre" runat="server" Text="" BackColor="#99CCFF" Width="134px"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblTSegundoNombre" runat="server" Text="Segundo Nombre:" CssClass="etiqueta10"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblSegundoNombre" runat="server" Text="" BackColor="#99CCFF" Width="134px"></asp:Label>
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="lblTSexo" runat="server" Text="Sexo:" CssClass="etiqueta10"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblSexo" runat="server" Text="" BackColor="#99CCFF" Width="134px"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblTitNUP" runat="server" Text="NUP:" CssClass="etiqueta10"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblNUP" runat="server" Text="" BackColor="#99CCFF" Width="134px"></asp:Label>
                                    </td>
                                    <td align="right" width="30%">
                                        <asp:Label ID="lblTitCUA" runat="server" Text="CUA:" CssClass="etiqueta10"></asp:Label>
                                    </td>
                                    <td align="left" width="20%">
                                        <asp:Label ID="lblCUA" runat="server" Text="" BackColor="#99CCFF" Width="134px"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblTitFechaNac" runat="server" Text="F.Nacimiento:" CssClass="etiqueta10"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblFechaNacimiento" runat="server" Text="" BackColor="#99CCFF" Width="134px"></asp:Label>
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="lblTitFechaFallecimiento" runat="server" Text="F.Fallecimiento:" CssClass="etiqueta10"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblFechaFallecimiento" runat="server" Text="" BackColor="#99CCFF" Width="134px"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblTitEstadoCivil" runat="server" Text="Estado Civil:" CssClass="etiqueta10"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblEstadoCivil" runat="server" Text="" BackColor="#99CCFF" Width="134px"></asp:Label>
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="lblTitEntidadGestora" runat="server" Text="Entidad Gestora:" CssClass="etiqueta10"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblEntidadGestora" runat="server" Text="" BackColor="#99CCFF" Width="134px"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
            <td width="1%"></td>
            <td width="48%">
                <table cellpadding="0" cellspacing="0" class="panelceleste">
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblTitNombreSubBeneficio" runat="server" Text="Sub Beneficio:" CssClass="etiqueta10"></asp:Label>
                        </td>
                        <td align="left" colspan="4">
                            <asp:Label ID="lblNombreSubBeneficio" runat="server" Text="" BackColor="#99CCFF" Width="484px"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblTitSector" runat="server" Text="Sector:" CssClass="etiqueta10"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblSector" runat="server" Text="" BackColor="#99CCFF" Width="134px"></asp:Label>
                        </td>
                        <td align="right">
                        </td>
                        <td align="left">
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblTitOficinaRegistro" runat="server" Text="Oficina Registro:" CssClass="etiqueta10"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblOficinaRegistro" runat="server" Text="" BackColor="#99CCFF" Width="134px"></asp:Label>
                        </td>
                        <td align="right">
                            <asp:Label ID="lblTitOficinaNotificacion" runat="server" Text="Oficina Notificación:" CssClass="etiqueta10"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblOficinaNotificacion" runat="server" Text="" BackColor="#99CCFF" Width="134px"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" >
                            <asp:Label ID="lblTitFechaInicioTramite" runat="server" Text="F.InicioTramite:" CssClass="etiqueta10"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblFechaInicioTramite" runat="server" Text="" BackColor="#99CCFF" Width="134px"></asp:Label>
                        </td>
                        <td align="right">
                            <asp:Label ID="lblTitDescEstObjeto" runat="server" Text="Descripcion Estado:" CssClass="etiqueta10"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblDescripcionEstadoObjeto" runat="server" Text="" BackColor="#99CCFF" Width="134px"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" >
                            &nbsp;
                        </td>
                        <td align="left">
                            &nbsp;
                        </td>
                        <td align="right">
                            &nbsp;
                        </td>
                        <td align="left">
                            &nbsp;
                        </td>
                    </tr>
                </table>                                                
            </td>
            <td width="1%">&nbsp;</td>
        </tr>
    </table>
    <table style="width: 100%;" cellpadding="0" cellspacing="0" class="panelceleste">
        <tr>
            <td width="1%"></td>
            <td width="58%" align="left">
                <asp:Label ID="Label5" runat="server" Text="Salario Cotizable" CssClass="etiqueta10" Font-Bold="True"></asp:Label>
            </td>
            <td width="1%"></td>
        </tr>
        <tr>
            <td width="1%"></td>
            <td width="58%" align="left">
                <div style="vertical-align: top; left: auto; height: auto; overflow: auto; width: 1200px;" class="panelceleste">
                    <asp:GridView ID="gvSalarioCotizable" runat="server"
                        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                        CellPadding="3" Font-Names="Verdana" Font-Size="8pt" AutoGenerateColumns="false">
                        <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                        <AlternatingRowStyle BackColor="#F7F7F7" />
                        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#FFDAB9" Font-Bold="True" ForeColor="#333333" />
                        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                        <Columns>
                            <asp:BoundField DataField="NoFormularioCalculo" HeaderText="No Formulario Calculo" 
                                Visible="true" ItemStyle-BackColor="#FFDAB9" ItemStyle-ForeColor="#333333" ItemStyle-Font-Bold="true"/>
                            <asp:BoundField DataField="Version" HeaderText="Versión" />
                            <asp:BoundField DataField="RUC" HeaderText="RUC" />
                            <asp:BoundField DataField="Componente" HeaderText="Componente" />
                            <asp:BoundField DataField="TipoDocSalario" HeaderText="Tipo Doc Salario" />
                            <asp:BoundField DataField="PeriodoSalario" HeaderText="Periodo Salario" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="SalarioCotizable" HeaderText="Salario Cotizable" />
                            <asp:BoundField DataField="SalarioCotizableActualizado" HeaderText="Salario Cotizable Actualizado" />
                            <asp:BoundField DataField="DensidadAportes" HeaderText="Densidad Aportes" />
                            <asp:BoundField DataField="MonedaSalario" HeaderText="Moneda Salario" />
                            <asp:TemplateField HeaderText="Registro Activo">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkRegistroActivo" runat="server" Checked='<%# Bind("RegistroActivo") %>' Enabled="false"/>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate><div align="center" class="CajaDialogoAdvertencia">
                            <br/><img src="../Imagenes/warning.gif" 
                                    alt="No existen registros de Salario Cotizable" />
                            <br/>No existen registros de Salario Cotizable
                            <br/><br/>
                            </div>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </div>
            </td>
            <td width="1%">&nbsp;</td>
        </tr>
        <tr>
            <td width="1%"></td>
            <td width="58%" align="left">
                <asp:Label ID="Label1" runat="server" Text="Actualizacion CC" CssClass="etiqueta10" Font-Bold="True"></asp:Label>
            </td>
            <td width="1%"></td>
        </tr>
        <tr>
            <td width="1%"></td>
            <td width="58%" align="left">
                <div style="vertical-align: top; left: auto; height: auto; overflow: auto; width: 1200px;" class="panelceleste">
                    <asp:GridView ID="gvActualizacionCC" runat="server"
                        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                        CellPadding="3" Font-Names="Verdana" Font-Size="8pt" AutoGenerateColumns="false">
                        <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                        <AlternatingRowStyle BackColor="#F7F7F7" />
                        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#FFDAB9" Font-Bold="True" ForeColor="#333333" />
                        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                        <Columns>
                            <asp:BoundField DataField="Version" HeaderText="Versión" />
                            <asp:BoundField DataField="RUC" HeaderText="RUC" />
                            <asp:BoundField DataField="Componente" HeaderText="Componente" />
                            <asp:BoundField DataField="FechaAfiliacion" HeaderText="Fecha Afiliación" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="DescripcionCertificacion" HeaderText="Descripcion Certificación" />
                            <asp:BoundField DataField="FechaBajaAfilia" HeaderText="Fecha Baja Afiliación" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="IdUsuarioRegistro" HeaderText="Usuario Registro" />
                            <asp:BoundField DataField="FechaRegistro" HeaderText="Fecha Registro" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="AnioCotiza" HeaderText="Año Cotización" />
                            <asp:BoundField DataField="MesesCotiza" HeaderText="Meses Cotizados" />
                            <asp:TemplateField HeaderText="Registro Activo">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkRegistroActivo" runat="server" Checked='<%# Bind("RegistroActivo") %>' Enabled="false"/>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate><div align="center" class="CajaDialogoAdvertencia">
                            <br/><img src="../Imagenes/warning.gif" 
                                    alt="No existen registros de Actualizacion CC" />
                            <br/>No existen registros de Actualizacion CC
                            <br/><br/>
                            </div>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </div>
            </td>
            <td width="1%">&nbsp;</td>
        </tr>
        <tr>
            <td width="1%"></td>
            <td width="58%" align="left">
                <asp:Label ID="Label2" runat="server" Text="Formularios de Calculo CC" CssClass="etiqueta10" Font-Bold="True"></asp:Label>
            </td>
            <td width="1%"></td>
        </tr>
        <tr>
            <td width="1%"></td>
            <td width="58%" align="left">
                <div style="vertical-align: top; left: auto; height: auto; overflow: auto; width: 1200px;" class="panelceleste">
                    <asp:GridView ID="gvFormularioCalculoCC" runat="server"
                        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                        CellPadding="3" Font-Names="Verdana" Font-Size="8pt" AutoGenerateColumns="false">
                        <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                        <AlternatingRowStyle BackColor="#F7F7F7" />
                        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#FFDAB9" Font-Bold="True" ForeColor="#333333" />
                        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                        <Columns>
                            <asp:BoundField DataField="NoFormularioCalculo" HeaderText="No Formulario Cálculo" />
                            <asp:BoundField DataField="DescripcionTipoFormulario" HeaderText="Descripción_Tipo_Formulario" />
                            <asp:BoundField DataField="TipoCC" HeaderText="TipoCC" />
                            <asp:BoundField DataField="NoResolucionCCR" HeaderText="No Resolución CCR" />
                            <asp:BoundField DataField="FechaResolucionCCR" HeaderText="Fecha Resolucion CCR" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="PeriodoSalario" HeaderText="Periodo Salario" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="MontoCC" HeaderText="MontoCC" />
                            <asp:BoundField DataField="DensidadTotal" HeaderText="Densidad Total" />
                            <asp:BoundField DataField="SalarioCotizableActualizadoTotal" HeaderText="Salario Cotizable Actualizado Total" />
                            <asp:BoundField DataField="TipoActSal" HeaderText="Tipo Act Sal" />
                            <asp:BoundField DataField="FechaGeneracion" HeaderText="Fecha Generación" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="FechaCalculo" HeaderText="Fecha Cálculo" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="IdUsuarioGeneracion" HeaderText="Usuario Generacion" />
                            <asp:BoundField DataField="IdUsuarioNotificacion" HeaderText="Usuario Notificacion" />
                            <asp:BoundField DataField="FechaNotificacion" HeaderText="Fecha Notificación" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="MontoCCAceptado" HeaderText="MontoCC Aceptado" />
                            <asp:BoundField DataField="FechaAceptacion" HeaderText="Fecha Aceptación" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="IdUsuarioAceptacion" HeaderText="Usuario Aceptación" />
                            <asp:BoundField DataField="SIP_impresion" HeaderText="SIP_impresion" />
                            <asp:BoundField DataField="DescripcionEstadoObjeto" HeaderText="Descripción Estado Objeto" />
                            <asp:BoundField DataField="FechaImpresion" HeaderText="Fecha Impresión" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:TemplateField HeaderText="Registro Activo">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkRegistroActivo" runat="server" Checked='<%# Bind("RegistroActivo") %>' Enabled="false"/>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate><div align="center" class="CajaDialogoAdvertencia">
                            <br/><img src="../Imagenes/warning.gif" 
                                    alt="No existen Formularios de Calculo CC asociados al trámite" />
                            <br/>No existen Formularios de Calculo CC asociados al trámite
                            <br/><br/>
                            </div>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </div>
            </td>
            <td width="1%">&nbsp;</td>
        </tr>
        <tr>
            <td width="1%"></td>
            <td width="58%" align="left">
                <asp:Label ID="Label3" runat="server" Text="Certificados" CssClass="etiqueta10" Font-Bold="True"></asp:Label>
            </td>
            <td width="1%"></td>
        </tr>
        <tr>
            <td width="1%"></td>
            <td width="58%" align="left">
                <div style="vertical-align: top; left: auto; height: auto; overflow: auto; width: 1200px;" class="panelceleste">
                    <asp:GridView ID="gvCertificados" runat="server"
                        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" 
                        CellPadding="4" GridLines="None" SkinID="GridView" Font-Names="Verdana" Font-Size="8pt"
                        BorderWidth="1px" AutoGenerateColumns="False"
                        DataKeyNames="IdTramite,IdGrupoBeneficio,NroCertificado,EstadoCertificado,RegistroAPS,CursoPago,IdTipoCC,NoFormularioCalculo,FechaCalculo,FechaEmision,MontoCCAceptado,SalarioCotizableActualizadoTotal,DensidadTotal,SIP_impresion,IdTipoFormularioCalculo" 
                        OnRowDataBound="gvCertificados_RowDataBound">
                        <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                        <AlternatingRowStyle BackColor="#F7F7F7" />
                        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#FFDAB9" Font-Bold="True" ForeColor="#333333" />
                        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:HiddenField ID="HFestadoCertificado" runat="server" Value = '<%#Eval("EstadoCertificado")%>' />
                                    <asp:CheckBox ID="chkCertificado" runat="server"
                                      AutoPostBack="true" OnCheckedChanged="chkCertificado_CheckedChanged" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="imgViewCertificadoCC" runat="server" CausesValidation="false" 
                                    CommandName="cmdViewCertificadoCC" ImageUrl="~/Imagenes/16imprimir.png" 
                                    OnClick="imgViewCertificadoCC_Click" />
                                <asp:ImageButton ID="imgFormularioCalculoCC" runat="server" CausesValidation="false" 
                                    CommandName="cmdFormularioCalculoCC" ImageUrl="~/Imagenes/16icon_applied.png" 
                                    OnClick="imgFormularioCalculoCC_Click" />
                            </ItemTemplate>
                            </asp:TemplateField>                                                  
                            <asp:BoundField DataField="NoFormularioCalculo" HeaderText="No Formulario Cálculo" />
                            <asp:BoundField DataField="NroCertificado" HeaderText="Nro Certificado" />
                            <asp:BoundField DataField="NroCertificadoReemplazo" HeaderText="Nro Certificado Reemplazo" />
                            <asp:BoundField DataField="DTipoCC" HeaderText="TipoCC" />
                            <asp:BoundField DataField="TipoCertificado" HeaderText="Tipo Certificado" />
                            <asp:BoundField DataField="FechaCalculo" HeaderText="Fecha Calculo" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="FechaEmision" HeaderText="Fecha Emision" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="TipoCambio1" HeaderText="Tipo Cambio" />
                            <asp:BoundField DataField="MontoCC" HeaderText="MontoCC" />
                            <asp:BoundField DataField="MontoCCAceptado" HeaderText="MontoCC Aceptado" />
                            <asp:BoundField DataField="SalarioCotizableActualizadoTotal" HeaderText="Salario Cotizable Actualizado Total" />
                            <asp:BoundField DataField="DensidadTotal" HeaderText="Densidad Total" />
                            <asp:BoundField DataField="SIP_impresion" HeaderText="SIP_impresion" />
                            <asp:BoundField DataField="PeriodoSalario" HeaderText="Periodo Salario" DataFormatString="{0:dd/MM/yyyy}"/>
                            <asp:TemplateField HeaderText="Registro APS">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkRegistroAPS" runat="server" Checked='<%# Bind("RegistroAPS") %>' Enabled="false"/>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Curso Pago">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkCursoPago" runat="server" Checked='<%# Bind("CursoPago") %>' Enabled="false"/>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="EstadoCertificado" HeaderText="EstadoCertificado" Visible="false" />
                            <asp:BoundField DataField="DescripcionEstadoObjeto" HeaderText="Estado Certificado" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <tr class="panelceleste">
                                        <td colspan = '999'>
                                    <asp:GridView ID="gvEnviosAPS" runat="server"
                                        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" 
                                        CellPadding="4" GridLines="None" SkinID="GridView" Font-Names="Verdana" Font-Size="8pt"
                                        BorderWidth="1px" AutoGenerateColumns="false">
                                        <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                                        <AlternatingRowStyle BackColor="#F7F7F7" />
                                        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                                        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                                        <SelectedRowStyle BackColor="#FFDAB9" Font-Bold="True" ForeColor="#333333" />
                                        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                                        <Columns>
                                            <asp:BoundField DataField="NumeroEnvio" HeaderText="Numero Envio" />
                                            <asp:BoundField DataField="FechaResolucion" HeaderText="Fecha Resolucion" DataFormatString="{0:dd/MM/yyyy}"/>
                                            <asp:BoundField DataField="NumeroResolucion" HeaderText="Numero Resolucion" />
                                            <asp:BoundField DataField="CodigoActualizacion" HeaderText="Codigo Actualizacion" />
                                        </Columns>
                                    </asp:GridView>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate><div align="center" class="CajaDialogoAdvertencia">
                            <br/><img src="../Imagenes/warning.gif" 
                                    alt="No existen registros que cumplan el criterio solicitado" />
                            <br/>No existen Certificados para el tramite elegido
                            <br/><br/>
                            </div>
                        </EmptyDataTemplate>
                    </asp:GridView>
                    <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="1 Seleccione Certificado" Text="1* Seleccione Certificado" ValidationGroup="ValRepro"></asp:CustomValidator>
                    <asp:CustomValidator ID="CustomValidator3" runat="server" ErrorMessage="5 Certificado en Pago: No está permitido Cambiar Fecha Nacimiento" Text="5* Certificado en Pago: No está permitido Cambiar Fecha Nacimiento" ValidationGroup="ValRepro"></asp:CustomValidator>
                    <asp:Label ID="lblMsgTramiteNoEnBandejaTrabajo" runat="server" Text="* TRAMITE NO SE ENCUENTRA EN BANDEJA DE TRABAJO" ForeColor="#ffff00" BackColor="BlueViolet" Font-Bold="true"></asp:Label>
                </div>
            </td>
            <td width="1%">&nbsp;</td>
        </tr>
    </table>
    <table style="width: 100%;" cellpadding="0" cellspacing="0" class="panelceleste">
        <tr align="left">
            <td width="1%">&nbsp;</td>
            <td width="15%" align="right">
                <asp:Label ID="lblTipoReproceso" runat="server" Text="Tipo de Reproceso:  " CssClass="etiqueta10" Font-Bold="True"></asp:Label>
            </td>
            <td width="20%">
                <asp:DropDownList ID="ddlTipoReproceso" runat="server" 
                    OnSelectedIndexChanged="ddlTipoReproceso_SelectedIndexChanged" AutoPostBack="True" Width="205px">
                </asp:DropDownList>
                <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="2 Seleccione Tipo de Reproceso" Text="*2" ValidationGroup="ValRepro"></asp:CustomValidator>
            </td>
            <td width="1%"></td>
            <td width="45%">
                &nbsp;
            </td>
            <td width="8%">
            </td>
        </tr>
    </table>
    </asp:Panel>
    <asp:Panel ID="pnlDetalle02" runat="server">
    <table style="width: 100%;" cellpadding="0" cellspacing="0" class="panelceleste">
        <tr>
            <td width="1%">&nbsp;</td>
            <td width="15%" align="right">
                <asp:Label ID="lblTNumeroResolucion" runat="server" Text="Numero Resolución:  " CssClass="etiqueta10" Font-Bold="True"></asp:Label>
            </td>
            <td width="20%">
                <asp:TextBox ID="txtNumeroResolucion" runat="server" 
                    BackColor="#87CEEB" Width="75px"
                    onkeypress="return jsNumbers(event, 'num')" 
                    onKeyUp="javascript:return mask(this.value,this,'4','.');" 
                    onBlur="javascript:return mask(this.value,this,'4','.');"
                    MaxLength="7" >
                </asp:TextBox>
                <cc1:TextBoxWatermarkExtender ID="txtNumeroResolucion_WatermarkExtender" 
                    runat="server" Enabled="True" TargetControlID="txtNumeroResolucion" WatermarkText="____.__">
                </cc1:TextBoxWatermarkExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ErrorMessage="3 Debe ingresar Numero de Resolucion Administrativa" ControlToValidate="txtNumeroResolucion" 
                    ValidationGroup="ValRepro">*3</asp:RequiredFieldValidator>
            </td>
            <td width="1%">&nbsp;</td>
            <td width="45%">&nbsp;</td>
            <td width="8%">&nbsp;</td>
        </tr>
        <tr>
            <td width="1%">&nbsp;</td>
            <td width="15%" align="right">
                <asp:Label ID="lblTFechaResolucion" runat="server" Text="Fecha Resolución:  " CssClass="etiqueta10" Font-Bold="True"></asp:Label>
            </td>
            <td width="20%">
            <asp:TextBox ID="txtFechaResolucion" runat="server" BackColor="#87CEEB" Width="75px"></asp:TextBox>
            <cc1:TextBoxWatermarkExtender ID="txtFechaResolucion_TextBoxWatermarkExtender" 
                runat="server" Enabled="True" TargetControlID="txtFechaResolucion" 
                WatermarkText="__/__/____">
            </cc1:TextBoxWatermarkExtender>
            <asp:ImageButton ID="imgFechaResolucion" ImageUrl="../Imagenes/pequeños/CalendarC_16x16.png" ImageAlign="Bottom"
                runat="server" />
            <cc1:CalendarExtender ID="Calendar1" PopupButtonID="imgFechaResolucion" runat="server" TargetControlID="txtFechaResolucion"
                Format="dd/MM/yyyy">
            </cc1:CalendarExtender>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ErrorMessage="4 Debe ingresar Fecha de Resolucion Administrativa" 
                ValidationGroup="ValRepro" ControlToValidate="txtFechaResolucion" Text="*4"></asp:RequiredFieldValidator>
            </td>
            <td width="1%">&nbsp;</td>
            <td width="45%">
                <asp:Button ID="btnGeneraFormularioReproceso" runat="server" Text="Genera Formulario Reproceso" OnClick="btnGeneraFormularioReproceso_Click" ValidationGroup="ValRepro" />
            </td>
            <td width="8%">&nbsp;</td>
        </tr>
        <tr>
            <td width="1%">&nbsp;</td>
            <td width="15%" align="right">
            </td>
            <td width="20%">                
            </td>
            <td width="1%">&nbsp;</td>
            <td width="45%">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="ValRepro" />
            </td>
            <td width="8%">&nbsp;</td>
        </tr>
    </table>
    </asp:Panel>
    <asp:Panel ID="pnlRenumeracion" runat="server">
    <table style="width: 100%;" cellpadding="0" cellspacing="0" class="panelceleste">
        <tr>
            <td width="1%"></td>
            <td width="49%" align="left">
                <asp:Label ID="Label23" runat="server" Text="Comandos Renumeración de Certificados" CssClass="etiqueta10" Font-Bold="True"></asp:Label>
            </td>
            <td width="1%"></td>
            <td width="48%" align="left">
                <asp:Label ID="Label24" runat="server" Text="(Ejecución)" CssClass="etiqueta10" Font-Bold="True"></asp:Label>
            </td>
            <td width="1%"></td>
        </tr>
        <tr>
            <td width="1%"></td>
            <td width="48%">
                <table width="100%" cellpadding="0" cellspacing="0" class="panelceleste">
                    <tr>
                        <td align="right">
						    <asp:ImageButton ID="imgRenumeraCertificado" runat="server" 
                                ImageUrl="~/Imagenes/32RenumeraCertificado.gif" ToolTip="Genera e Imprime Certificado"
                                OnClick="imgRenumeraCertificado_Click" onclientclick="return confirm('Esta seguro de Renumerar el Certificado señalado ?');" /> 
						    <asp:Label ID="lblRenumeraCertificado" CssClass="etiqueta8Blue" runat="server" Text="RUMERA Certificado" /> 
                        </td>
                    </tr>
                </table>
            </td>
            <td width="1%"></td>
            <td width="48%">&nbsp;</td>
            <td width="1%">&nbsp;</td>
        </tr>
    </table>
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
                                <asp:BoundField DataField="NumeroTramiteCrenta" HeaderText="CRENTA" Visible="true" 
                                    ItemStyle-Font-Bold="True" ItemStyle-ForeColor="WhiteSmoke" ItemStyle-BackColor="DimGray"/>
                                <asp:BoundField DataField="IdTramite" HeaderText="Trámite" />      
                                <asp:BoundField DataField="Matricula" HeaderText="Matricula" />
                                <asp:BoundField DataField="AreaDestino" HeaderText="Area Destino" />      
                                <asp:BoundField DataField="UsuarioDestino" HeaderText="Usuario Destino" />      
                                <asp:BoundField DataField="FechaIngreso" HeaderText="Fecha Ingreso" DataFormatString="{0:dd/MM/yyyy}"/>      
                                <asp:BoundField DataField="FechaSalida" HeaderText="Fecha Salida" DataFormatString="{0:dd/MM/yyyy}"/>      
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

