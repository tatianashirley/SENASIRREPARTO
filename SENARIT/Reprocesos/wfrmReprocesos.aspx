<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmReprocesos.aspx.cs" Inherits="Reprocesos_wfrmReprocesos" %>

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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:TextBox ID="TextBox1" runat="server" Visible="false"></asp:TextBox>
<asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Imagenes/16calendario.png"  Visible="false"/>
<cc1:CalendarExtender ID="CalendarExtender3" runat="server" PopupButtonID="ImageButton1" TargetControlID="TextBox1" ></cc1:CalendarExtender>
<table style="width: 100%;" class="panelceleste">
<tr>
    <td align="center">
        <asp:ImageButton ID="imgAux" runat="server" ImageUrl="~/Imagenes/16w.png" />
        <asp:Label ID="lblTituloAUX" runat="server" Text="ADMINISTRACION DE REPROCESOS" CssClass="etiqueta20"> </asp:Label>
    </td>
</tr>
</table>
<table style="width: 100%;" cellpadding="0" cellspacing="0" class="panelceleste">
    <tr>
        <td width="1%"></td>
        <td align="left" colspan="2">
            <asp:Label ID="Label5" runat="server" Text="Formularios de Reprocesos" CssClass="etiqueta10" Font-Bold="True"></asp:Label>
        </td>
        <td width="1%"></td>
    </tr>
    <tr>
        <td width="1%"></td>
        <td align="left" colspan="2">
            <asp:Label ID="Label15"  CssClass="etiqueta10"  runat="server" Text="Numero de Tramite: " >
            </asp:Label>
            <asp:TextBox  ID="txtNumeroTramite" runat="server" 
                onkeypress="return jsNumbers(event, 'num_car')"
                MaxLength="7"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label35"  CssClass="etiqueta10"  runat="server" Text="Estado del Reproceso: " >
            </asp:Label>
            <asp:DropDownList ID="ddlEstadoReproceso" runat="server">
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label36"  CssClass="etiqueta10"  runat="server" Text="Tipo de Reproceso: " >
            </asp:Label>
            <asp:DropDownList ID="ddlTipoReproceso" runat="server">
            </asp:DropDownList>
            &nbsp;&nbsp;<br />
            <asp:Label ID="Label37"  CssClass="etiqueta10"  runat="server" Text="Bandeja de Trabajo: " />
            <asp:DropDownList ID="dllBandejaTrabajo" runat="server">
                <asp:ListItem Value="false">Todos (*)</asp:ListItem>
                <asp:ListItem Value="true">Solo Trámites en Bandeja de Trabajo</asp:ListItem>
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;
            <asp:ImageButton ID="imgBuscarReproceso" runat="server"  ImageUrl="~/Imagenes/32Buscar.png" ToolTip="Buscar Datos" 
                OnClick="imgBuscarReproceso_Click" /> 
            <asp:Label ID="Label19" CssClass="etiqueta8Blue" runat="server" Text="Buscar" /> 
        </td>
        <td width="1%"></td>
    </tr>
    <tr>
        <td width="1%"></td>
        <td align="left" colspan="2">
        </td>
        <td width="1%"></td>
    </tr>
    <tr>
        <td width="1%"></td>
        <td align="left" colspan="2">
            <div style="vertical-align: top; left: auto; height: auto; overflow: auto; width: 1200px;" class="panelceleste">
                <asp:GridView ID="gvFormulariosReprocesos" runat="server" AutoGenerateColumns="False"
                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                    CellPadding="4" GridLines="None" SkinID="GridView" Font-Names="Verdana" Font-Size="8pt"
                    DataKeyNames="NumeroTramiteCrenta,NroFormularioRepro,CodigoTipoReproceso,IdEstadoReproceso,IdTipoReproceso,NumeroResolucion,FechaResolucion,IdTramite,IdGrupoBeneficio,IdTipoTramite,NUP,NoFormularioCalculo,IdTipoFormularioCalculo,NroCertificado,RegistroAPS,CertificadoAnulado,FechaNacimiento,FechaNacimientoNueva,NroCertificadoNuevo,MontoCCAceptado,MontoCCAceptadoNuevo,RegistroAPS_Baja,RegistroAPS_Alta" 
                    OnRowCommand="gvFormulariosReprocesos_RowCommand"
                    OnRowDataBound="gvFormulariosReprocesos_RowDataBound"
                    AllowPaging="True" PageSize="10" OnPageIndexChanging="gvFormulariosReprocesos_PageIndexChanging">
                <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                <AlternatingRowStyle BackColor="#F7F7F7" />
                <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Left" />
                <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                <SelectedRowStyle BackColor="#6495ED" Font-Bold="True" ForeColor="#333333" />
                <PagerSettings Mode="NumericFirstLast" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />    
                <Columns>
                    <asp:TemplateField ItemStyle-Width="40px">
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemTemplate>
                            <asp:CheckBox ID="chkReproceso" runat="server" AutoPostBack="true" 
                                OnCheckedChanged="chkReproceso_CheckedChanged" >
                            </asp:CheckBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="40px">
                        <ItemTemplate>
                            <asp:ImageButton ID="imgCancelarReproceso" runat="server" 
                                ImageUrl="~/Imagenes/pequeños/Cancel16.png" 
                                CommandName="CANCELAR"
                                CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                onclientclick="return confirm('Esta seguro Cancelar el Reproceso?');"  />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="imgImprimeFormularioReproceso" runat="server" CausesValidation="false" 
                                CommandName="cmdImprimeFormularioReproceso" ImageUrl="~/Imagenes/16imprimir.png" 
                                OnClick="imgImprimeFormularioReproceso_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>                                                  
                    <asp:BoundField DataField="NroFormularioRepro" HeaderText="Nro" />
                    <asp:BoundField DataField="TipoReproceso" HeaderText="Tipo Reproceso" />
                    <asp:TemplateField HeaderText="Trámite">
                        <ItemTemplate>
                            <asp:ImageButton ID="imgBuscaTramite" runat="server" 
                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" 
                            CommandName="BuscaTramite"
                            ToolTip="Buscar Tramite" AlternateText='<%# Bind("IdTramite") %>' />
                        </ItemTemplate>
                        <ItemStyle Font-Bold="True" ForeColor="GhostWhite" BackColor="DarkSlateGray" />
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
                    <asp:BoundField DataField="TipoTramite" HeaderText="Procedimiento" />
                    <asp:BoundField DataField="DTipoCC" HeaderText="TipoCC" />
                    <asp:BoundField DataField="TipoBeneficio" HeaderText="Tipo Beneficio" />
                    <asp:BoundField DataField="NumeroResolucion" HeaderText="Num Res" />
                    <asp:BoundField DataField="FechaResolucion" HeaderText="Resol" DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:BoundField DataField="FechaInicioRepro" HeaderText="Inicio Reproceso" DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:BoundField DataField="EstadoReproceso" HeaderText="Estado Reproceso" />
                    <asp:BoundField DataField="NUP" HeaderText="NUP" />
                    <asp:BoundField DataField="NoFormularioCalculo" HeaderText="No Formulario Calculo" />
                    <asp:BoundField DataField="DescEstadoFormCalcCC" HeaderText="Estado Form CalcCC" />
                    <asp:BoundField DataField="NroCertificado" HeaderText="Nro Certificado" />
                    <asp:BoundField DataField="FechaCalculo" HeaderText="Fecha Calculo" DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:TemplateField HeaderText="RegistroAPS">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkRegistroAPS" runat="server" 
                                Checked='<%# Bind("RegistroAPS") %>' Enabled="false"></asp:CheckBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Curso Pago">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkCursoPago" runat="server" 
                                Checked='<%# Bind("CursoPago") %>' Enabled="false"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Cert. Anulado">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkCertificadoAnulado" runat="server" Checked='<%# Bind("CertificadoAnulado") %>' Enabled="false" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <div align="center" class="CajaDialogoAdvertencia">
                    <br/><img src="../Imagenes/warning.gif" 
                            alt="No existen Formularios de Reproceso para mostrar." />
                    <br/>No se eligieron opciones de busqueda o No existen Formularios de Reproceso que cumplan lo filtrado.
                    <br/><br/>
                    </div>
                </EmptyDataTemplate>
                </asp:GridView>
            </div>
        </td>
        <td width="1%">&nbsp;</td>
    </tr>
</table>
<br />
<asp:Panel ID="pnlFormReprocesoDatos" runat="server" Visible="false">
<table style="width: 100%;" cellpadding="0" cellspacing="0" class="panelceleste">
    <tr>
        <td width="1%"></td>
        <td width="98%" align="left">
            <asp:Label ID="Label4" runat="server" Text="Datos Estado del Reproceso" CssClass="etiqueta10" Font-Bold="True"></asp:Label>
        </td>
        <td width="1%"></td>
    </tr>
    <tr>
        <td width="1%"></td>
        <td width="98%" align="left">
            <asp:FormView ID="fvFormReprocesoDatos" runat="server" AutoGenerateRows="False">
                <ItemTemplate>
                    <table style="width: 100%;" cellpadding="0" cellspacing="0" class="panelceleste">
                        <tr>
                            <td>
                                <asp:Label ID="Label38" runat="server" Text="Primer Nombre" CssClass="etiqueta10" ></asp:Label>
                            </td>
                            <td>&nbsp;&nbsp;</td>
                            <td>
                                <asp:Label ID="Label39" runat="server" CssClass="etiqueta10" 
                                    Font-Bold="True" ForeColor="WhiteSmoke" BackColor="DimGray">
                                    <%# Eval("PrimerNombre") %>
                                </asp:Label>
                            </td>
                            <td>&nbsp;&nbsp;</td>
                            <td>
                                <asp:Label ID="Label40" runat="server" Text="Segundo Nombre" CssClass="etiqueta10" ></asp:Label>
                            </td>
                            <td>&nbsp;&nbsp;</td>
                            <td>
                                <asp:Label ID="Label41" runat="server" CssClass="etiqueta10" 
                                    Font-Bold="True" ForeColor="WhiteSmoke" BackColor="DimGray">
                                    <%# Eval("SegundoNombre") %>
                                </asp:Label>
                            </td>
                            <td>&nbsp;&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label42" runat="server" Text="Primer Apellido" CssClass="etiqueta10" ></asp:Label>
                            </td>
                            <td>&nbsp;&nbsp;</td>
                            <td>
                                <asp:Label ID="Label43" runat="server" CssClass="etiqueta10" 
                                    Font-Bold="True" ForeColor="WhiteSmoke" BackColor="DimGray">
                                    <%# Eval("PrimerApellido") %>
                                </asp:Label>
                            </td>
                            <td>&nbsp;&nbsp;</td>
                            <td>
                                <asp:Label ID="Label44" runat="server" Text="Segundo Apellido" CssClass="etiqueta10" ></asp:Label>
                            </td>
                            <td>&nbsp;&nbsp;</td>
                            <td>
                                <asp:Label ID="Label45" runat="server" CssClass="etiqueta10" 
                                    Font-Bold="True" ForeColor="WhiteSmoke" BackColor="DimGray">
                                    <%# Eval("SegundoApellido") %>
                                </asp:Label>
                            </td>
                            <td>&nbsp;&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label46" runat="server" Text="Numero de Documento" CssClass="etiqueta10" ></asp:Label>
                            </td>
                            <td>&nbsp;&nbsp;</td>
                            <td>
                                <asp:Label ID="Label47" runat="server" CssClass="etiqueta10" 
                                    Font-Bold="True" ForeColor="WhiteSmoke" BackColor="DimGray">
                                    <%# Eval("NumeroDocumento") %>
                                </asp:Label>
                            </td>
                            <td>&nbsp;&nbsp;</td>
                            <td>
                                <asp:Label ID="Label48" runat="server" Text="CUA" CssClass="etiqueta10" ></asp:Label>
                            </td>
                            <td>&nbsp;&nbsp;</td>
                            <td>
                                <asp:Label ID="Label49" runat="server" CssClass="etiqueta10" 
                                    Font-Bold="True" ForeColor="WhiteSmoke" BackColor="DimGray">
                                    <%# Eval("CUA") %>
                                </asp:Label>
                            </td>
                            <td>&nbsp;&nbsp;</td>
                        </tr>
                    </table>
                    <hr />
                    <table style="width: 100%;" cellpadding="0" cellspacing="0" class="panelceleste">
                        <tr>
                            <td>
                                <asp:Label ID="Label5" runat="server" Text="Fecha de Nacimiento" CssClass="etiqueta10" ></asp:Label>
                            </td>
                            <td>&nbsp;&nbsp;</td>
                            <td>
                                <asp:Label ID="Label25" runat="server" CssClass="etiqueta10" 
                                    Font-Bold="True" ForeColor="WhiteSmoke" BackColor="DimGray">
                                    <%# String.Format("{0:dd/MM/yyyy}", Eval("FechaNacimiento")) %>
                                </asp:Label>
                            </td>
                            <td>&nbsp;&nbsp;</td>
                            <td>
                                <asp:Label ID="Label10" runat="server" Text="3: Fecha de Nacimiento Nueva" CssClass="etiqueta10" ></asp:Label>
                            </td>
                            <td>&nbsp;&nbsp;</td>
                            <td>
                                <asp:Label ID="Label26" runat="server" CssClass="etiqueta10" 
                                    Font-Bold="True" ForeColor="WhiteSmoke" BackColor="DimGray">
                                    <%# String.Format("{0:dd/MM/yyyy}", Eval("FechaNacimientoNueva")) %>
                                </asp:Label>
                            </td>
                            <td>&nbsp;&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label11" runat="server" Text="Matricula" CssClass="etiqueta10" ></asp:Label>
                            </td>
                            <td>&nbsp;&nbsp;</td>
                            <td>
                                <asp:Label ID="Label27" runat="server" CssClass="etiqueta10" 
                                    Font-Bold="True" ForeColor="WhiteSmoke" BackColor="DimGray">
                                    <%# Eval("Matricula") %>
                                </asp:Label>
                            </td>
                            <td>&nbsp;&nbsp;</td>
                            <td>
                                <asp:Label ID="Label12" runat="server" Text="3: Matricula Nueva" CssClass="etiqueta10" ></asp:Label>
                            </td>
                            <td>&nbsp;&nbsp;</td>
                            <td>
                                <asp:Label ID="Label28" runat="server" CssClass="etiqueta10" 
                                    Font-Bold="True" ForeColor="WhiteSmoke" BackColor="DimGray">
                                    <%# Eval("MatriculaNueva") %>
                                </asp:Label>
                            </td>
                            <td>&nbsp;&nbsp;</td>
                        </tr>
                    </table>
                    <hr />
                    <table style="width: 100%;" cellpadding="0" cellspacing="0" class="panelceleste">
                        <tr>
                            <td>
                                <asp:Label ID="Label17" runat="server" Text="NroCertificado" CssClass="etiqueta10" ></asp:Label>
                            </td>
                            <td>&nbsp;&nbsp;</td>
                            <td>
                                <asp:Label ID="Label1" runat="server" ForeColor="GhostWhite" 
                                    Font-Bold="True" BackColor="DarkSlateGray">
                                    <%# Eval("NroCertificado") %></asp:Label></td>
                            <td>&nbsp;&nbsp;</td>
                            <td>
                                <asp:Label ID="Label18" runat="server" Text="4: NroCertificadoNuevo" CssClass="etiqueta10" ></asp:Label>
                            </td>
                            <td>&nbsp;&nbsp;</td>
                            <td>
                                <asp:Label ID="Label33" runat="server" CssClass="etiqueta10" 
                                    Font-Bold="True" ForeColor="WhiteSmoke" BackColor="DimGray">
                                    <%# Eval("NroCertificadoNuevo") %>
                                </asp:Label>
                            </td>
                            <td>&nbsp;&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label13" runat="server" Text="MontoCC" CssClass="etiqueta10" ></asp:Label>
                            </td>
                            <td>&nbsp;&nbsp;</td>
                            <td>
                                <asp:Label ID="Label29" runat="server" CssClass="etiqueta10" 
                                    Font-Bold="True" ForeColor="WhiteSmoke" BackColor="DimGray">
                                    <%# String.Format("{0:f2}", Eval("MontoCCAceptado")) %>
                                </asp:Label>
                            </td>
                            <td>&nbsp;&nbsp;</td>
                            <td>
                                <asp:Label ID="lblTMontoCCNuevo" runat="server" Text="MontoCCNuevo" CssClass="etiqueta10" ></asp:Label>
                            </td>
                            <td>&nbsp;&nbsp;</td>
                            <td>
                                <asp:Label ID="lblMontoCCNuevo" runat="server" CssClass="etiqueta10" 
                                    Font-Bold="True" ForeColor="WhiteSmoke" BackColor="DimGray">
                                    <%# String.Format("{0:f2}", Eval("MontoCCAceptadoNuevo")) %>
                                </asp:Label>
                                <asp:Label ID="lblMontoCCview" runat="server" CssClass="etiqueta10" 
                                    Font-Bold="True" ForeColor="WhiteSmoke" BackColor="ForestGreen">
                                    <%# String.Format("{0:f2}", Eval("MontoCCview")) %>
                                </asp:Label>
                            </td>
                            <td>&nbsp;&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label21" runat="server" Text="1: Certificado Baja APS" CssClass="etiqueta10" ></asp:Label>
                            </td>
                            <td>&nbsp;&nbsp;</td>
                            <td>
                                <asp:CheckBox ID="chkRegistroAPS_Baja" runat="server" 
                                    Checked='<%# Eval("RegistroAPS_Baja") %>' Enabled="false"></asp:CheckBox>
                            </td>
                            <td>&nbsp;&nbsp;</td>
                            <td>
                                <asp:Label ID="Label20" runat="server" Text="2: CertificadoAnulado" CssClass="etiqueta10" ></asp:Label>
                            </td>
                            <td>&nbsp;&nbsp;</td>
                            <td>
                                <asp:CheckBox ID="chkCertificadoAnulado" runat="server" 
                                    Checked='<%# Eval("CertificadoAnulado") %>' Enabled="false"></asp:CheckBox>
                            </td>
                            <td>&nbsp;&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label19" runat="server" Text="5: NumeroEnvioCertificadoNuevo" CssClass="etiqueta10" ></asp:Label>
                            </td>
                            <td>&nbsp;&nbsp;</td>
                            <td>
                                <asp:Label ID="Label34" runat="server" CssClass="etiqueta10" 
                                    Font-Bold="True" ForeColor="WhiteSmoke" BackColor="DimGray">
                                    <%# Eval("NumeroEnvioCertificadoNuevo") %>
                                </asp:Label>
                            </td>
                            <td>&nbsp;&nbsp;</td>
                            <td>
                                <asp:Label ID="Label22" runat="server" Text="5: CertificadoNuevo Alta APS" CssClass="etiqueta10" ></asp:Label>
                            </td>
                            <td>&nbsp;&nbsp;</td>
                            <td>
                                <asp:CheckBox ID="chkRegistroAPS_Alta" runat="server" 
                                    Checked='<%# Eval("RegistroAPS_Alta") %>' Enabled="false"></asp:CheckBox>
                            </td>
                            <td>&nbsp;&nbsp;</td>
                        </tr>
                    </table>
                    <hr />
                </ItemTemplate>
                <EmptyDataTemplate><div align="center" class="CajaDialogoAdvertencia">
                    <br/><img src="../Imagenes/warning.gif" 
                            alt="No existen registros que cumplan el criterio solicitado" />
                    <br/>No existen datos para el Recalculo
                    <br/><br/>
                    </div>
                </EmptyDataTemplate>
            </asp:FormView>
        </td>
        <td width="1%">&nbsp;</td>
    </tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlReprocesoRM266" runat="server" Visible="false">
<table style="width: 100%;" cellpadding="0" cellspacing="0" class="panelceleste">
    <tr>
        <td width="1%"></td>
        <td width="49%" align="left">
            <asp:Label ID="Label2" runat="server" Text="Comandos Reproceso RM266" CssClass="etiqueta10" Font-Bold="True"></asp:Label>
        </td>
        <td width="1%"></td>
        <td width="48%" align="left">
            <asp:Label ID="Label6" runat="server" Text="(Ejecución)" CssClass="etiqueta10" Font-Bold="True"></asp:Label>
        </td>
        <td width="1%"></td>
    </tr>
    <tr>
        <td width="1%"></td>
        <td width="48%">
            <asp:Label ID="lblMsgRegistroAPS_Baja" runat="server" Text="* Debe dar de Baja en la APS el Certificado Original." ForeColor="Red"></asp:Label>
            <asp:Label ID="lblMsgRegistroAPS_Alta" runat="server" Text="* Debe dar de Alta en la APS el Nuevo Certificado!" ForeColor="Red"></asp:Label>            
            <table width="100%" cellpadding="0" cellspacing="0" class="panelceleste">
                <tr>
                    <td align="right">
						<asp:ImageButton ID="imgRM266BajaAPS" runat="server"  ImageUrl="~/Imagenes/32RenumeraCertificado.gif" ToolTip="Anula Certificado" OnClick="imgRM266BajaAPS_Click" /> 
						<asp:Label ID="lblBajaAPS" CssClass="etiqueta8Blue" runat="server" Text="Baja APS de Certificado Original" /> 
                    </td>
                    <td align="right">
						<asp:ImageButton ID="imgRM266AnulaCertificadoAPS" runat="server"  ImageUrl="~/Imagenes/32RenumeraCertificado.gif" ToolTip="Anula Certificado" OnClick="imgRM266AnulaCertificado_Click" /> 
						<asp:Label ID="lblRM266AnulaCertificadoAPS" CssClass="etiqueta8Blue" runat="server" Text="Anula Certificado" /> 
                    </td>
                    <td align="right">
						<asp:ImageButton ID="imgCambiarFechaNacimiento" runat="server"  ImageUrl="~/Imagenes/32RenumeraCertificado.gif" ToolTip="Cambiar Fecha Nacimiento" OnClick="imgRM266CambiarFechaNacimiento_Click" style="width: 32px" /> 
						<asp:Label ID="lblCambiarFechaNacimiento" CssClass="etiqueta8Blue" runat="server" Text="Cambiar Fecha Nacimiento" /> 
                    </td>
                    <td align="right">
						<asp:ImageButton ID="imgRM266Certificado" runat="server"  ImageUrl="~/Imagenes/32RenumeraCertificado.gif" 
                            ToolTip="Genera e Imprime Certificado" OnClick="imgRM266Certificado_Click" /> 
						<asp:Label ID="lblRM266Certificado" CssClass="etiqueta8Blue" runat="server" Text="Genera e Imprime Certificado" /> 
                    </td>
                </tr>
            </table>
        </td>
        <td width="1%"></td>
        <td width="48%">
            <asp:Panel ID="pnlRM266NuevaFechaNacimiento" runat="server" Visible="false">
            <table style="width: 100%;" cellpadding="0" cellspacing="0" class="panelceleste">
                <tr align="left">
                    <td width="15%">
                        <asp:Label ID="Label3" runat="server" Text="Nueva Fecha de Nacimiento:" CssClass="etiqueta10"></asp:Label>
                    </td>
                    <td width="30%">
                        <asp:TextBox ID="txtFechaNacimientoNueva" runat="server" BackColor="#87CEEB" Width="75px"></asp:TextBox>
                        <cc1:TextBoxWatermarkExtender ID="txtNFechaNacimiento_TextBoxWatermarkExtender" 
                            runat="server" Enabled="True" TargetControlID="txtFechaNacimientoNueva" 
                            WatermarkText="__/__/____">
                        </cc1:TextBoxWatermarkExtender>
                        <asp:ImageButton ID="imgPopup" ImageUrl="../Imagenes/pequeños/CalendarC_16x16.png" ImageAlign="Bottom" runat="server" />
                        <cc1:CalendarExtender ID="txtFechaNacimientoNueva_CalendarExtender" PopupButtonID="imgPopup" runat="server" TargetControlID="txtFechaNacimientoNueva"
                            Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                        <asp:RangeValidator runat="server" id="rngFechaNacimientoNueva" 
                            controltovalidate="txtFechaNacimientoNueva" type="Date" 
                            minimumvalue="01-01-1900" maximumvalue="31-12-2014" 
                            errormessage="* Ingrese Fecha de Nacimiento válida!" />                                                
                    </td>
                </tr>
                <tr align="left">
                    <td width="15%">
                        <asp:Label ID="Label7" runat="server" Text="Nueva Matricula:" CssClass="etiqueta10"></asp:Label>
                    </td>
                    <td width="30%">
                        <asp:TextBox ID="txtMatriculaNueva" runat="server" BackColor="#87CEEB" Width="115px"></asp:TextBox><br />
                        <asp:Label ID="lblMsgMatriculaNueva" runat="server" Text="* Generar Matricula Nueva." ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr align="left">
                    <td width="15%">
                    </td>
                    <td width="30%">
                        <asp:Button runat="server" ID="btnGenerarMatricula" Text="Generar Matrícula" OnClick="btnGenerarMatricula_Click" Width="200px" CssClass="boton150" />
                        <asp:Button ID="btnCambiaFechaNacimiento" runat="server" Text="Cambiar Fecha de Nacimiento" OnClick="btnRM266CambiaFechaNacimiento_Click" />
                    </td>
                </tr>
            </table>
            </asp:Panel>   
        </td>
        <td width="1%">&nbsp;</td>
    </tr>
</table>
</asp:Panel>                                
<asp:Panel ID="pnlReproceso28888" runat="server" Visible="false">
<table style="width: 100%;" cellpadding="0" cellspacing="0" class="panelceleste">
    <tr>
        <td width="1%"></td>
        <td width="49%" align="left">
            <asp:Label ID="Label8" runat="server" Text="Comandos Reproceso D.S.28888" CssClass="etiqueta10" Font-Bold="True"></asp:Label>
        </td>
        <td width="1%"></td>
        <td width="48%" align="left">
            <asp:Label ID="Label9" runat="server" Text="(Ejecución)" CssClass="etiqueta10" Font-Bold="True"></asp:Label>
        </td>
        <td width="1%"></td>
    </tr>
    <tr>
        <td width="1%"></td>
        <td width="48%">
            <asp:Label ID="lblMsg28888EnProceso" runat="server" Text="Reproceso DS28888 en Certificación-Emisión..." ForeColor="Green" Font-Bold="true"></asp:Label>
            <asp:Label ID="lblMsg28888RegistroAPS_Baja" runat="server" Text="* Debe dar de Baja en la APS el Certificado Original." ForeColor="Red"></asp:Label>
            <asp:Label ID="lblMsg28888RegistroAPS_Alta" runat="server" Text="* Debe dar de Alta en la APS el Nuevo Certificado!" ForeColor="Red"></asp:Label>            
            <table width="100%" cellpadding="0" cellspacing="0" class="panelceleste">
                <tr>
                    <td align="right">
						<asp:ImageButton ID="img28888BajaAPS" runat="server"  ImageUrl="~/Imagenes/32RenumeraCertificado.gif" ToolTip="Baja APS" OnClick="img28888BajaAPS_Click" /> 
						<asp:Label ID="lbl28888BajaAPS" CssClass="etiqueta8Blue" runat="server" Text="Baja APS" /> 
                    </td>
                    <td align="right">
						<asp:ImageButton ID="img28888HabilitaReproceso" runat="server"  ImageUrl="~/Imagenes/32RenumeraCertificado.gif" 
                            ToolTip="Habilita Reproceso" OnClick="img28888HabilitaReproceso_Click" />  
						<asp:Label ID="lbl28888HabilitaReproceso" CssClass="etiqueta8Blue" runat="server" Text="Habilita Reproceso" /> 
                    </td>
                    <td align="right">
						<asp:ImageButton ID="img28888Certificado" runat="server"  ImageUrl="~/Imagenes/32RenumeraCertificado.gif" 
                            ToolTip="Genera e Imprime Certificado" Enabled="false"/> 
						<asp:Label ID="lbl28888Certificado" CssClass="etiqueta8Blue" runat="server" Text="Genera e Imprime Certificado" Enabled="false" /> 
                    </td>
                </tr>
            </table>
        </td>
        <td width="1%"></td>
        <td width="48%">
            <asp:Panel ID="pnlImprimeCertificado28888" runat="server" Visible="false">
                <asp:GridView ID="gvGImpCertificados" runat="server" AutoGenerateColumns="False"
                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                    CellPadding="4" GridLines="None" SkinID="GridView" Font-Names="Verdana" Font-Size="8pt"
                    DataKeyNames="NoFormularioCalculo" 
                    AllowPaging="True" PageSize="10" >
                <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                <AlternatingRowStyle BackColor="#F7F7F7" />
                <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Left" />
                <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                <SelectedRowStyle BackColor="#6495ED" Font-Bold="True" ForeColor="#333333" />
                <PagerSettings Mode="NumericFirstLast" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />    
                <Columns>
                    <asp:BoundField DataField="NoFormularioCalculo" HeaderText="No Formulario Calculo" />
                    <asp:BoundField DataField="MontoCC" HeaderText="Monto CC" />
                    <asp:BoundField DataField="TipoCC" HeaderText="TipoCC" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="imgImprimeCertificado" runat="server" CausesValidation="false" 
                                CommandName="IMPRIMECERTIFICADO" ImageUrl="~/Imagenes/32imprimir.png" 
                                OnClick="imgImprimeCertificado28888_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>                                                  
                </Columns>
                </asp:GridView>
            </asp:Panel>             
        </td>
        <td width="1%">&nbsp;</td>
    </tr>
</table>
</asp:Panel>
<asp:Panel ID="pnlReprocesoReclamaciones" runat="server" Visible="false">
<table style="width: 100%;" cellpadding="0" cellspacing="0" class="panelceleste">
    <tr>
        <td width="1%"></td>
        <td width="49%" align="left">
            <asp:Label ID="Label23" runat="server" Text="Comandos Reproceso RECLAMACIONES" CssClass="etiqueta10" Font-Bold="True"></asp:Label>
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
            <asp:Label ID="lblMsgReclamacionesEnProceso" runat="server" Text="Reproceso RECLAMACIONES en Certificación-Emisión..." ForeColor="Green" Font-Bold="true"></asp:Label>
            <asp:Label ID="lblMsgReclamacionesRegistroAPS_Baja" runat="server" Text="* Debe dar de Baja en la APS el Certificado Original." ForeColor="Red"></asp:Label>
            <asp:Label ID="lblMsgReclamacionesRegistroAPS_Alta" runat="server" Text="* Debe dar de Alta en la APS el Nuevo Certificado!" ForeColor="Red"></asp:Label>            
            <table width="100%" cellpadding="0" cellspacing="0" class="panelceleste">
                <tr>
                    <td align="right">
						<asp:ImageButton ID="imgReclamacionesBajaAPS" runat="server"  ImageUrl="~/Imagenes/32RenumeraCertificado.gif" ToolTip="Baja APS" OnClick="imgReclamacionesBajaAPS_Click" /> 
						<asp:Label ID="lblReclamacionesBajaAPS" CssClass="etiqueta8Blue" runat="server" Text="Baja APS" /> 
                    </td>
                    <td align="right">
						<asp:ImageButton ID="imgReclamacionesHabilitaReproceso" runat="server"  ImageUrl="~/Imagenes/32RenumeraCertificado.gif" ToolTip="Habilita Reproceso" OnClick="imgReclamacionesHabilitaReproceso_Click" />  
						<asp:Label ID="lblReclamacionesHabilitaReproceso" CssClass="etiqueta8Blue" runat="server" Text="Habilita Reproceso" /> 
                    </td>
                    <td align="right">
						<asp:ImageButton ID="imgReclamacionesCertificado" runat="server"  ImageUrl="~/Imagenes/32RenumeraCertificado.gif" 
                            ToolTip="Genera e Imprime Certificado" /> 
						<asp:Label ID="lblReclamacionesCertificado" CssClass="etiqueta8Blue" runat="server" Text="Genera e Imprime Certificado" /> 
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
                                <asp:BoundField DataField="NumeroTramiteCrenta" HeaderText="Tramite" Visible="true" 
                                    ItemStyle-Font-Bold="True" ItemStyle-ForeColor="WhiteSmoke" ItemStyle-BackColor="DimGray"/>
                                <asp:BoundField DataField="IdTramite" HeaderText="IdTramite" />      
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

