<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmRegistroDeBajas.aspx.cs" Inherits="EnvioAPS_wfrmRegistroDeBajas" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style7 {
            width: 7%;
        }
        .auto-style13 {
            width: 8%;
        }
        .auto-style16 {
            width: 5%;
        }
    </style>
    <style type="text/css">
        .auto-style7 {
            width: 6%;
        }
        .auto-style9 {
            width: 14%;
        }
        .auto-style18 {
            width: 168px;
        }
        .auto-style19 {
            width: 145px;
        }
        .auto-style20 {
            width: 362px;
        }
        .auto-style21 {
            width: 134px;
        }
    </style>    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
        var teclas_especiales = [8, 39, 46, 17, 86, 9];
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
        //alert(ekeyCode); //alert(echarCode); alert(ewhich);
        var codigoCaracter = evento.charCode;// || evento.keyCode;
        var caracter = String.fromCharCode(codigoCaracter);
        //alert(caracter);

        // Comprobar si la tecla pulsada es alguna de las teclas especiales
        // (teclas de borrado y flechas horizontales)
        var tecla_especial = false;
        for (var i in teclas_especiales) {
            if (codigoCaracter == teclas_especiales[i]) {
                tecla_especial = true;
                break;
            }
        }

        // Comprobar si la tecla pulsada se encuentra en los caracteres permitidos
        // o si es una tecla especial
        var result = false;
        result = permitidos.indexOf(caracter) != -1 || tecla_especial;
        return result;
    }
</script> 
<asp:TextBox ID="TextBox1" runat="server" Visible="false"></asp:TextBox>
<asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Imagenes/16calendario.png"  Visible="false"/>
<cc1:CalendarExtender ID="CalendarExtender3" runat="server" PopupButtonID="ImageButton1" TargetControlID="TextBox1" ></cc1:CalendarExtender>
     <table style="width: 100%;" class="panelceleste">
        <tr>
            <td align="center">
                <asp:ImageButton ID="imgAux" runat="server" ImageUrl="~/Imagenes/16w.png" />
                <asp:Label ID="lblTituloAUX" runat="server" Text="REGISTRO DE BAJAS" CssClass="etiqueta20"> </asp:Label>
            </td>
        </tr>
        <tr>
             <td >
                 <div>
                    <table width="100%" class="panelceleste" >
                         <tr>
                            <td style="text-align:right" class="auto-style7">
                                <asp:Label ID="lblNumeroCertificado"  CssClass="etiqueta10"  runat="server" Text="Numero Certificado: " /> 
                            </td>
                            <td style="text-align:left" class="auto-style13"> 
                                <asp:TextBox  ID="txtNumeroCertificado" runat="server" 
                                    style="margin-bottom: 0px" MaxLength="6"
                                    onkeypress="return jsNumbers(event, 'num')">
                                </asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtNumeroCertificado"></asp:RequiredFieldValidator>
                            </td>
                            <td style="text-align:right" class="auto-style16">
                                <asp:Label ID="lblClaseCC"  CssClass="etiqueta10"  runat="server" Text="Clase CC: " /> 
                            </td>
                            <td style="text-align:left" class="auto-style7"> 
                                <asp:DropDownList ID="ddlClaseCC" runat="server">
                                    <asp:ListItem Value="A">Automaticos</asp:ListItem>
                                    <asp:ListItem Value="M">Manuales</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="width:20%; text-align:left">  
                                <asp:ImageButton ID="imgBuscar" runat="server"  ImageUrl="~/Imagenes/32Buscar.png" ToolTip="Buscar Datos" OnClick="imgBuscar_Click"   /> 
                                <asp:Label ID="lblRefres" CssClass="etiqueta8Blue" runat="server" Text="Buscar" />   
                            </td>
                        </tr>
                    </table>
                </div>
             </td>
        </tr>
        <tr>
            <td>
                 <asp:Panel ID="PanelResultadoBusqueda" runat="server" CssClass="panelceleste">
                    <table width="100%" class="panelceleste" >
                        <tr>
                            <td colspan="10" align="left">
                                <asp:Label ID="Label1" runat="server" Text="SPVS" CssClass="etiqueta10" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-align: right">
                                <asp:Label ID="Label2" runat="server" Text="CI" CssClass="etiqueta10"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:Label ID="lblCI" runat="server" BackColor="#6D8EA8" Width="134px"></asp:Label>
                            </td>
                            <td class="text-align: right">
                                <asp:Label ID="Label3" runat="server" Text="NUA" CssClass="etiqueta10"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:Label ID="lblNUA" runat="server" BackColor="#6D8EA8" Width="134px"></asp:Label>
                            </td>
                            <td class="text-align: right">
                                <asp:Label ID="Label4" runat="server" Text="Paterno" CssClass="etiqueta10"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:Label ID="lblPaterno" runat="server" BackColor="#6D8EA8" Width="134px"></asp:Label>
                            </td>
                            <td class="text-align: right">
                                <asp:Label ID="Label5" runat="server" Text="Materno" CssClass="etiqueta10"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:Label ID="lblMaterno" runat="server" BackColor="#6D8EA8" Width="134px"></asp:Label>
                            </td>
                            <td class="text-align: right">
                                <asp:Label ID="Label6" runat="server" Text="Nombres" CssClass="etiqueta10"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:Label ID="lblNombres" runat="server" BackColor="#6D8EA8" Width="134px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-align: right">
                                <asp:Label ID="Label16" runat="server" Text="NUP" CssClass="etiqueta10"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:Label ID="lblNUP" runat="server" BackColor="#6D8EA8" Width="134px"></asp:Label>
                            </td>
                            <td class="text-align: right">
                                <asp:Label ID="Label7" runat="server" Text="AFP" CssClass="etiqueta10"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:Label ID="lblAFP" runat="server" BackColor="#6D8EA8" Width="134px"></asp:Label>
                            </td>
                            <td class="text-align: right">
                                <asp:Label ID="Label9" runat="server" Text="Tipo CC" CssClass="etiqueta10"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:Label ID="lblTipoCC" runat="server" BackColor="#6D8EA8" Width="134px"></asp:Label>
                            </td>
                            <td class="text-align: right">
                                <asp:Label ID="Label11" runat="server" Text="Monto CC" CssClass="etiqueta10"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:Label ID="lblMontoCC" runat="server" BackColor="#6D8EA8" Width="134px"></asp:Label>
                            </td>
                            <td class="text-align: right">
                                <asp:Label ID="Label13" runat="server" Text="Fecha CC" CssClass="etiqueta10"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:Label ID="lblFechaCC" runat="server" BackColor="#6D8EA8" Width="134px"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" class="panelceleste" >
                        <tr>
                            <td colspan="10" align="left">
                                <asp:Label ID="Label12" runat="server" Text="Datos Envio APS" CssClass="etiqueta10" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:GridView ID="gvHistorialEnvioAPS" runat="server" AutoGenerateColumns="False"
                                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                                    CellPadding="3" Font-Names="Verdana" Font-Size="7pt" 
                                    DataKeyNames="NumeroEnvio,NroCertificado">
                                <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                                <AlternatingRowStyle BackColor="#F7F7F7" />
                                <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                                <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                                <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                                <SelectedRowStyle BackColor="#6495ED" Font-Bold="True" ForeColor="#333333" />
                                <Columns>
                                    <asp:BoundField DataField="NumeroEnvio" HeaderText="Numero Envio" />
                                    <asp:BoundField DataField="NroCertificado" HeaderText="Nro Certificado" />
                                    <asp:BoundField DataField="Clase_CC" HeaderText="Clase CC" />
                                    <asp:BoundField DataField="NUP" HeaderText="NUP" />
                                    <asp:BoundField DataField="Tipo_CC" HeaderText="Tipo CC" />
                                    <asp:BoundField DataField="FechaResolucion" HeaderText="Fecha Resolucion" />
                                    <asp:BoundField DataField="NumeroResolucion" HeaderText="Numero Resolucion" />
                                    <asp:BoundField DataField="CodigoActualizacion" HeaderText="Codigo Actualizacion" />
                                </Columns>
                                <EmptyDataTemplate>
                                    <div align="center" class="CajaDialogoAdvertencia">
                                    <br/><img src="../Imagenes/warning.gif" 
                                            alt="No existen Datos de Registro de Envios APS." />
                                    <br/>No existen Datos de Registro de Envios APS.
                                    <br/><br/>
                                    </div>
                                </EmptyDataTemplate>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" class="panelceleste" >
                        <tr>
                            <td colspan="10" align="left">
                                <asp:Label ID="Label15" runat="server" Text="Datos Pago CC" CssClass="etiqueta10" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:GridView ID="gvDatosPagosCertificado" runat="server" AutoGenerateColumns="False"
                                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                                    CellPadding="3" Font-Names="Verdana" Font-Size="7pt" >
                                <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                                <AlternatingRowStyle BackColor="#F7F7F7" />
                                <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                                <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                                <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                                <SelectedRowStyle BackColor="#6495ED" Font-Bold="True" ForeColor="#333333" />
                                <Columns>
                                    <asp:BoundField DataField="NUP" HeaderText="NUP" />
                                    <asp:BoundField DataField="NumeroCertificado" HeaderText="Numero Certificado" />
                                    <asp:BoundField DataField="NUPDH" HeaderText="NUP Derecho Habiente" />
                                </Columns>
                                <EmptyDataTemplate>
                                    <div align="center" class="CajaDialogoAdvertencia">
                                    <br/><img src="../Imagenes/warning.gif" 
                                            alt="El Certificado elegido no esta en Pago." />
                                    <br/>El Certificado elegido no esta en Pago.
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
        <tr>
            <td>
                 <asp:Panel ID="PanelDatosBaja" runat="server" CssClass="panelceleste">
                    <table width="100%" class="panelceleste" >
                        <tr>
                            <td colspan="10" align="left">
                                <asp:Label ID="Label8" runat="server" Text="Datos de la Baja" CssClass="etiqueta10" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style20">
                                &nbsp;
                            </td>
                            <td class="text-align: right">
                                <asp:Label ID="Label10" runat="server" Text="Número R.A." CssClass="etiqueta10"></asp:Label>
                            </td>
                            <td style="text-align: left" class="auto-style18">
                                <asp:TextBox ID="txtNumeroRA" runat="server" 
                                    BackColor="#87CEEB" Width="74px"
                                    onkeypress="return jsNumbers(event, 'num')" 
                                    onKeyUp="javascript:return mask(this.value,this,'4','.');" 
                                    onBlur="javascript:return mask(this.value,this,'4','.');"
                                    MaxLength="7" >
                                </asp:TextBox>
                                <cc1:TextBoxWatermarkExtender ID="txtNumeroRA_WatermarkExtender" 
                                    runat="server" Enabled="True" TargetControlID="txtNumeroRA" WatermarkText="____.__">
                                </cc1:TextBoxWatermarkExtender>   
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                    ErrorMessage="0. Ingrese Número de Resolución Administrativa" 
                                    ControlToValidate="txtNumeroRA" Text="*0"
                                    ValidationGroup="RegistrarBaja">
                                </asp:RequiredFieldValidator>
                            </td>
                            <td class="auto-style19">
                                <asp:Label ID="Label14" runat="server" Text="Fecha R.A." CssClass="etiqueta10"></asp:Label>
                            </td>
                            <td style="text-align: left" class="auto-style9">
                                <asp:TextBox ID="txtFechaRA" runat="server" 
                                    BackColor="#87CEEB" Width="75px"
                                    onkeypress="return jsNumbers(event, 'num')"
                                    onKeyUp="javascript:return mask(this.value,this,'2,5','/');" 
                                    onBlur="javascript:return mask(this.value,this,'2,5','/');" 
                                    MaxLength="10">
                                </asp:TextBox>
                                <cc1:TextBoxWatermarkExtender ID="txtFechaRA_TextBoxWatermarkExtender" 
                                    runat="server" Enabled="True" TargetControlID="txtFechaRA" 
                                    WatermarkText="__/__/____">
                                </cc1:TextBoxWatermarkExtender>
                                <asp:ImageButton ID="imgPopup" ImageUrl="../Imagenes/pequeños/CalendarC_16x16.png" ImageAlign="Bottom" runat="server" />
                                <cc1:CalendarExtender ID="txtFechaRA_CalendarExtender" PopupButtonID="imgPopup" runat="server" TargetControlID="txtFechaRA"
                                    Format="dd/MM/yyyy">
                                </cc1:CalendarExtender>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtFechaRA"
                                    ErrorMessage="1. Fecha Invalida" Operator="DataTypeCheck" 
                                    SetFocusOnError="True" Type="Date" ValidationGroup="RegistrarBaja" Text="*1">
                                </asp:CompareValidator>                           							
                            </td>
                            <td class="auto-style21" >
                                <asp:Button ID="btnBajaSPVS" runat="server" Text="Baja SPVS" OnClick="btnBajaSPVS_Click" ValidationGroup="RegistrarBaja" Height="25px" />
                            </td>
                            <td style="text-align: left">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="10" align="left">
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="RegistrarBaja" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
<asp:ImageButton ID="imgVolver" runat="server"  ImageUrl="~/Imagenes/32Volver.png" ToolTip="Volver a la Página anterior" OnClick="btnVolver_Click" CausesValidation="false" /> 
<asp:Label ID="lblTVolver" CssClass="etiqueta8Blue" runat="server" Text="Volver" /> 
</asp:Content>