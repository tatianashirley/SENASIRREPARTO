<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmRegistroReprocesos.aspx.cs" Inherits="Reprocesos_wfrmRegistroReprocesos" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript" src="../js/jquery-1.8.3.min.js"></script>
    <script type="text/javascript">
        $("[src*=plus]").live("click", function () {
            $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
            $(this).attr("src", "../Imagenes/16minus.png");
        });
        $("[src*=minus]").live("click", function () {
            $(this).attr("src", "../Imagenes/16plus.png");
            $(this).closest("tr").next().remove();
        });
    </script>
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
    function jsNumbers(elEvento, permitidos) {
        // Variables que definen los caracteres permitidos
        var numeros = "0123456789";
        var caracteres = " abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ";
        var numeros_caracteres = numeros + caracteres;
        var teclas_especiales = [8, 37, 39, 46, 17, 86, 9];
        // 8=BackSpace, 46=Supr, 37=flecha izquierda=%, 39=flecha derecha, 17=Ctrl,86=v,9=Tab

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
        //alert(ekeyCode); alert(echarCode); alert(ewhich);
        var codigoCaracter = evento.charCode;// || evento.keyCode;
        var caracter = '';

        // Comprobar si la tecla pulsada es alguna de las teclas especiales
        // (teclas de borrado y flechas horizontales)
        var tecla_especial = false;
        if (ekeyCode > 0) tecla_especial = true; // teclas especiales
        else {
            caracter = String.fromCharCode(codigoCaracter);
        }

        // Comprobar si la tecla pulsada se encuentra en los caracteres permitidos
        // o si es una tecla especial
        return permitidos.indexOf(caracter) != -1 || tecla_especial;
    }
</script>
<script type = "text/javascript">
    function checkedChange(objRef) {
        var GridView = objRef.parentNode.parentNode.parentNode;
        var inputList = GridView.getElementsByTagName("input");
        for (var i = 0; i < inputList.length; i++) {
            if (inputList[i].type == "checkbox" && inputList[i] != objRef) {
                inputList[i].disabled = objRef.checked;
            }
        }
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
                <asp:Label ID="lblTituloAUX" runat="server" Text="REGISTRO DE REPROCESOS" CssClass="etiqueta20"> </asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlDatosAfiliado" runat="server" Visible="false">
                    <table align="center" cellpadding="0" cellspacing="0" class="panelceleste">
                        <tr>
                            <td align="left">
                                <asp:Label ID="Label7" runat="server" Text="Filas por página:" CssClass="etiqueta10" Visible="false"></asp:Label>
                                <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" Visible="false" 
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
                                    OnRowCommand="gvDatosAfiliado_RowCommand" >
                                    <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                                    <AlternatingRowStyle BackColor="#F7F7F7" />
                                    <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                                    <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                                    <SelectedRowStyle BackColor="#FFDAB9" Font-Bold="True" ForeColor="#333333" />
                                    <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                                    <Columns>
                                        <asp:TemplateField ItemStyle-Width="40px">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="imgDetTramite" runat="server" 
                                                    CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                        CommandName="DETALLE01"
                                                        ImageUrl="~/Imagenes/16AttachDocumentMoveUp.gif" CausesValidation="false" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="NumFila" HeaderText="Num Fila" Visible="true" />
                                        <asp:BoundField DataField="IdTramite" HeaderText="IdTramite" Visible="true" />
                                        <asp:BoundField DataField="TipoTramite" HeaderText="Tipo Tramite" Visible="true" />
                                        <asp:BoundField DataField="IdEstadoObjetoProceso" HeaderText="IdEstadoObjetoProceso" Visible="false" />
                                        <asp:BoundField DataField="DescripcionEstadoObjeto" HeaderText="Estado Del Tramite" Visible="true" />
                                        <asp:BoundField DataField="NumeroTramiteCrenta" HeaderText="CRENTA" Visible="true" />                                        
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
    <asp:HyperLink ID="hlkTramiteEnReproceso" runat="server" ForeColor="Green" Font-Bold="true">* TRAMITE EN REPROCESO</asp:HyperLink>
    <asp:Label ID="lblMsgRenunciaCCAutomáticaFFAA" runat="server" Text="* Renuncia CC Automática FFAA" ForeColor="Green" Font-Bold="true"></asp:Label>
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
                        CellPadding="3" Font-Names="Verdana" Font-Size="8pt" AutoGenerateColumns="true">
                        <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                        <AlternatingRowStyle BackColor="#F7F7F7" />
                        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#FFDAB9" Font-Bold="True" ForeColor="#333333" />
                        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                        <Columns>
                            <asp:BoundField DataField="NoFormularioCalculo" HeaderText="NoFormularioCalculo" Visible="true" ItemStyle-BackColor="#FFDAB9" ItemStyle-ForeColor="#333333" ItemStyle-Font-Bold="true"/>
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
                        CellPadding="3" Font-Names="Verdana" Font-Size="8pt" AutoGenerateColumns="true">
                        <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                        <AlternatingRowStyle BackColor="#F7F7F7" />
                        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#FFDAB9" Font-Bold="True" ForeColor="#333333" />
                        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                        <Columns>
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
                        CellPadding="3" Font-Names="Verdana" Font-Size="8pt" AutoGenerateColumns="true">
                        <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                        <AlternatingRowStyle BackColor="#F7F7F7" />
                        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#FFDAB9" Font-Bold="True" ForeColor="#333333" />
                        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                        <Columns>
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
                        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                        CellPadding="3" Font-Names="Verdana" Font-Size="8pt" AutoGenerateColumns="False"
                        DataKeyNames="IdTramite,IdGrupoBeneficio,NroCertificado,RegistroAPS,CursoPago,IdTipoCC,NoFormularioCalculo,FechaCalculo,FechaEmision,MontoCCAceptado,SalarioCotizableActualizadoTotal,DensidadTotal,SIP_impresion,IdTipoFormularioCalculo" 
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
                                    <asp:Image ID="imgPlus" runat="server" style="cursor: pointer" src="../Imagenes/16plus.png"/>
                                    <asp:Panel ID="pnlEnviosAPS" runat="server" Style="display: none">
                                        <asp:GridView ID="gvEnviosAPS" runat="server"
                                            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                                            CellPadding="3" Font-Names="Verdana" Font-Size="8pt" AutoGenerateColumns="false">
                                            <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                                            <AlternatingRowStyle BackColor="#F7F7F7" />
                                            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                                            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                                            <SelectedRowStyle BackColor="#FFDAB9" Font-Bold="True" ForeColor="#333333" />
                                            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                                            <Columns>
                                                <asp:BoundField DataField="NumeroEnvio" HeaderText="Numero Envio" />
                                                <asp:BoundField DataField="FechaResolucion" HeaderText="Fecha Resolucion" />
                                                <asp:BoundField DataField="NumeroResolucion" HeaderText="Numero Resolucion" />
                                                <asp:BoundField DataField="CodigoActualizacion" HeaderText="Codigo Actualizacion" />
                                            </Columns>
                                            <EmptyDataTemplate><div align="center" class="CajaDialogoAdvertencia">
                                                <br/><img src="../Imagenes/warning.gif" 
                                                        alt="No existen registros que cumplan el criterio solicitado" />
                                                <br/>No existen Envios APS para el Certificado elegido
                                                <br/><br/>
                                                </div>
                                            </EmptyDataTemplate>
                                        </asp:GridView>
                                    </asp:Panel>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:HiddenField ID="HFestadoCertificado" runat="server" Value = '<%#Eval("EstadoCertificado")%>' />
                                    <asp:CheckBox ID="chkCertificado" runat="server" onclick="checkedChange(this);" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="imgRenumeraCertificadoCC" runat="server" CausesValidation="false" 
                                    CommandName="cmdRenumeraCertificadoCC" ImageUrl="~/Imagenes/16imprimir.png" 
                                    OnClick="imgRenumeraCertificadoCC_Click" />
                                <asp:ImageButton ID="imgFormularioCalculoCC" runat="server" CausesValidation="false" 
                                    CommandName="cmdFormularioCalculoCC" ImageUrl="~/Imagenes/16icon_applied.png" 
                                    OnClick="imgFormularioCalculoCC_Click" />
                            </ItemTemplate>
                            </asp:TemplateField>                                                  
                            <asp:BoundField DataField="NoFormularioCalculo" HeaderText="NoFormCalc" />
                            <asp:BoundField DataField="NroCertificado" HeaderText="Nro Certificado" />
                            <asp:BoundField DataField="NroCertificadoReemplazo" HeaderText="Nro Certificado Reemplazo" />
                            <asp:BoundField DataField="DTipoCC" HeaderText="TipoCC" />
                            <asp:BoundField DataField="TipoCertificado" HeaderText="Tipo Certificado" />
                            <asp:BoundField DataField="FechaCalculo" HeaderText="Fecha Calculo" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="FechaEmision" HeaderText="Fecha Emision" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="TipoCambio1" HeaderText="Tipo Cambio" DataFormatString="{0:F2}" />
                            <asp:BoundField DataField="MontoCC" HeaderText="MontoCC" DataFormatString="{0:F2}" />
                            <asp:BoundField DataField="MontoCCAceptado" HeaderText="MontoCC Aceptado" DataFormatString="{0:F2}" />
                            <asp:BoundField DataField="SalarioCotizableActualizadoTotal" HeaderText="Salario Cotizable Actualizado Total" DataFormatString="{0:F2}" />
                            <asp:BoundField DataField="DensidadTotal" HeaderText="Densidad Total" DataFormatString="{0:F2}" />
                            <asp:BoundField DataField="SIP_impresion" HeaderText="SIP_impresion" DataFormatString="{0:F2}" />
                            <asp:BoundField DataField="PeriodoSalario" HeaderText="Periodo Salario" DataFormatString="{0:F2}" />
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
                </div>
            </td>
            <td width="1%">&nbsp;</td>
        </tr>
    </table>
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
        <tr align="left">
            <td width="1%">&nbsp;</td>
            <td width="15%" align="right">
                <asp:Label ID="lblTipoReproceso" runat="server" Text="Tipo de Reproceso:  " CssClass="etiqueta10" Font-Bold="True"></asp:Label>
            </td>
            <td width="20%">
                <asp:DropDownList ID="ddlTipoReproceso" runat="server" OnSelectedIndexChanged="ddlTipoReproceso_SelectedIndexChanged" AutoPostBack="True" Width="205px">
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
                    BackColor="#87CEEB" Width="75px"></asp:TextBox>
                <cc1:TextBoxWatermarkExtender ID="txtNumeroResolucion_WatermarkExtender" 
                    runat="server" Enabled="True" TargetControlID="txtNumeroResolucion" WatermarkText="____.__">
                </cc1:TextBoxWatermarkExtender>
                <cc1:MaskedEditExtender ID="txtNumeroResolucion_MaskedEditExtender" runat="server" 
                    TargetControlID="txtNumeroResolucion" Mask="9999.99"
                    MessageValidatorTip="True"
                    OnFocusCssClass="MaskedEditFocus"
                    OnInvalidCssClass="MaskedEditError"
                    InputDirection="LeftToRight"
                    ErrorTooltipEnabled="True" ClearMaskOnLostFocus="True" >
                </cc1:MaskedEditExtender>                  
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
</asp:Content>

