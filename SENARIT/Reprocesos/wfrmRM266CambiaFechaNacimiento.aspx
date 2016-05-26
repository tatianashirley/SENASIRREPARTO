<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmRM266CambiaFechaNacimiento.aspx.cs" Inherits="Reprocesos_wfrmRM266CambiaFechaNacimiento" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
    <table style="width: 100%;" cellpadding="0" cellspacing="0" class="panelceleste">
        <tr>
            <td align="center" colspan="5">
                <asp:ImageButton ID="imgAux" runat="server" ImageUrl="~/Imagenes/16w.png" />
                <asp:Label ID="lblTituloAUX" runat="server" Text="CAMBIO DE FECHA DE NACIMIENTO (RM266-Sin Certificado)" CssClass="etiqueta20"> </asp:Label>
                <asp:Label ID="lblNumeroTramite"  CssClass="etiqueta10"  runat="server" Text="Numero Tramite: " /> 
                <asp:TextBox  ID="txtNumeroTramite" runat="server" 
                    style="margin-bottom: 0px" Enabled="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align:right" colspan="2">
                &nbsp;
            </td>
            <td style="text-align:left" colspan="3"> 
                &nbsp;
            </td>
        </tr>
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
    <br />
    <table style="width: 100%;" cellpadding="0" cellspacing="0" class="panelceleste">
        <tr align="left">
            <td width="15%">
                <asp:Label ID="Label12" runat="server" Text="Numero Resolución:  " CssClass="etiqueta10" Font-Bold="True"></asp:Label>
            </td>
            <td width="30%">
                <asp:TextBox ID="txtNumeroResolucion2" runat="server" 
                    BackColor="#87CEEB" Width="75px"
                    onkeypress="return jsNumbers(event, 'num')" 
                    onKeyUp="javascript:return mask(this.value,this,'4','.');" 
                    onBlur="javascript:return mask(this.value,this,'4','.');"
                    MaxLength="7" >
                </asp:TextBox>
                <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" 
                    runat="server" Enabled="True" TargetControlID="txtNumeroResolucion2" WatermarkText="____.__">
                </cc1:TextBoxWatermarkExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ErrorMessage="1 Debe ingresar Numero de Resolucion Administrativa" 
                    ControlToValidate="txtNumeroResolucion2" ValidationGroup="ValRepro2"
                    Display="Dynamic" >*1</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr align="left">
            <td width="15%">
                <asp:Label ID="Label13" runat="server" Text="Fecha Resolución:  " CssClass="etiqueta10" Font-Bold="True"></asp:Label>
            </td>
            <td width="30%">
                <asp:TextBox ID="txtFechaResolucion2" runat="server" 
                    BackColor="#87CEEB" Width="75px"
                    onkeypress="return jsNumbers(event, 'num')"
                    onKeyUp="javascript:return mask(this.value,this,'2,5','/');" 
                    onBlur="javascript:return mask(this.value,this,'2,5','/');" 
                    MaxLength="10">
                </asp:TextBox>
                <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" 
                    runat="server" Enabled="True" TargetControlID="txtFechaResolucion2" 
                    WatermarkText="__/__/____">
                </cc1:TextBoxWatermarkExtender>
                <asp:ImageButton ID="imgFechaResolucion2" ImageUrl="../Imagenes/pequeños/CalendarC_16x16.png" ImageAlign="Bottom"
                    runat="server" />
                <cc1:CalendarExtender ID="CalendarExtender1" PopupButtonID="imgFechaResolucion2" runat="server" TargetControlID="txtFechaResolucion2"
                    Format="dd/MM/yyyy">
                </cc1:CalendarExtender>
                <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="txtFechaResolucion2"
                    ErrorMessage="0. Ingrese Fecha de Corte" Operator="DataTypeCheck" 
                    SetFocusOnError="True" Type="Date" ValidationGroup="ValRepro2" Text="*2">
                </asp:CompareValidator>                           							
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ErrorMessage="2 Debe ingresar Fecha de Resolucion Administrativa" ValidationGroup="ValRepro2" 
                    ControlToValidate="txtFechaResolucion2" Text="*2"
                    Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr align="left">
            <td width="15%">
                &nbsp;
            </td>
            <td width="30%">
                &nbsp;
            </td>
        </tr>
        <tr align="left">
            <td width="15%">
                <asp:Label ID="Label10" runat="server" Text="Nueva Fecha de Nacimiento:" CssClass="etiqueta10"></asp:Label>
            </td>
            <td width="30%">
                <asp:TextBox ID="txtFechaNacimientoNueva" runat="server" 
                    BackColor="#87CEEB" Width="75px"
                    onkeypress="return jsNumbers(event, 'num')"
                    onKeyUp="javascript:return mask(this.value,this,'2,5','/');" 
                    onBlur="javascript:return mask(this.value,this,'2,5','/');" 
                    MaxLength="10">
                </asp:TextBox>
                <cc1:TextBoxWatermarkExtender ID="txtNFechaNacimiento_TextBoxWatermarkExtender" 
                    runat="server" Enabled="True" TargetControlID="txtFechaNacimientoNueva" 
                    WatermarkText="__/__/____">
                </cc1:TextBoxWatermarkExtender>
                <asp:ImageButton ID="imgPopup" ImageUrl="../Imagenes/pequeños/CalendarC_16x16.png" ImageAlign="Bottom" runat="server" />
                <cc1:CalendarExtender ID="txtFechaNacimientoNueva_CalendarExtender" PopupButtonID="imgPopup" runat="server" TargetControlID="txtFechaNacimientoNueva"
                    Format="dd/MM/yyyy">
                </cc1:CalendarExtender>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtFechaNacimientoNueva"
                    ErrorMessage="3. Fecha Invalida" Operator="DataTypeCheck" 
                    SetFocusOnError="True" Type="Date" ValidationGroup="ValRepro2" Text="*2">
                </asp:CompareValidator>                           							
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ErrorMessage="3 Debe ingresar Numero de Resolucion Administrativa" 
                    ControlToValidate="txtFechaNacimientoNueva" ValidationGroup="ValRepro2"
                    Display="Dynamic">*3</asp:RequiredFieldValidator>
                <asp:RangeValidator runat="server" id="rngFechaNacimientoNueva" controltovalidate="txtFechaNacimientoNueva" 
                    type="Date" minimumvalue="1900-01-01" maximumvalue="2014-12-31" 
                    errormessage="4 Ingrese Fecha de Nacimiento válida!" ValidationGroup="ValRepro2">*4</asp:RangeValidator>                        
            </td>
        </tr>
        <tr align="left">
            <td width="15%">
                <asp:Label ID="Label11" runat="server" Text="Nueva Matricula:" CssClass="etiqueta10"></asp:Label>
            </td>
            <td width="30%">
                <asp:TextBox ID="txtMatriculaNueva" runat="server" BackColor="#87CEEB" Width="115px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ErrorMessage="5 Debe Generar una Matricula nueva" 
                    ControlToValidate="txtMatriculaNueva" ValidationGroup="ValRepro2"
                    Display="Dynamic">*5</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr align="left">
            <td width="15%">
            </td>
            <td width="30%">
                <asp:Button runat="server" ID="btnGenerarMatricula" Text="Generar Matrícula" 
                    OnClick="btnGenerarMatricula_Click" Width="200px" CssClass="boton150" ValidationGroup="ValRepro2" CausesValidation="false" />
                <asp:Button ID="btnCambiaFechaNacimiento" runat="server" Text="Cambiar Fecha de Nacimiento" CausesValidation="true" 
                    OnClick="btnCambiaFechaNacimientoRM266_Click" ValidationGroup="ValRepro2" />
            </td>
        </tr>
        <tr align="left">
            <td width="15%">
                <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="ValRepro2" />
            </td>
            <td width="30%">&nbsp;</td>
        </tr>
    </table>
<asp:ImageButton ID="imgVolver" runat="server"  ImageUrl="~/Imagenes/32Volver.png" ToolTip="Volver a la Página anterior" OnClick="btnVolver_Click" CausesValidation="false" /> 
<asp:Label ID="lblTVolver" CssClass="etiqueta8Blue" runat="server" Text="Volver" /> 
</asp:Content>

