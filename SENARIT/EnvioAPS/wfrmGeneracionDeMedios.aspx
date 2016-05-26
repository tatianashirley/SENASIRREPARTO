<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmGeneracionDeMedios.aspx.cs" Inherits="EnvioAPS_wfrmGeneracionDeMedios" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
.auto-style5 {
    height: 19px;
}
.modalBackground2
{
	background-color: Black;
	filter: alpha(opacity=80); 
	opacity: 0.50;
}
.tableBackground
{
	background-color:silver;
	opacity:0.7;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script  type="text/javascript" >
        function submitBandejaPreliminarButton() {
            //debugger;
            var HFbandejaEnvios = document.getElementById("<%= HFbandejaEnvios.ClientID %>");
            HFbandejaEnvios.value = '1';
            return true;
        }
        function submitBandejaXButton() {
            //debugger;
            var HFbandejaEnvios = document.getElementById("<%= HFbandejaEnvios.ClientID %>");
            HFbandejaEnvios.value = '0';
            return true;
        }
    </script>
    <asp:HiddenField ID="HFbandejaEnvios" runat="server" Value="0" />
     <table style="width: 100%;" class="panelceleste">
        <tr>
            <td align="center">
                <asp:ImageButton ID="imgAux" runat="server" ImageUrl="~/Imagenes/16w.png" />
                <asp:Label ID="lblTituloAUX" runat="server" Text="GENERACION DE ENVIOS Y MEDIOS" CssClass="etiqueta20"> </asp:Label>
            </td>
        </tr>
        <tr>
             <td >
                <asp:Panel ID="pnlDatos" runat="server" HorizontalAlign="Center" Width="100%" CssClass="panelceleste">
                    <table width="100%">
                    <tr>
                        <td align="left" class="auto-style5">
                         &nbsp;
                        </td>
                        <td align="left" class="auto-style5">
                         &nbsp;
                        </td>
                        <td>&nbsp;&nbsp;&nbsp;</td>
                        <td align="center" colspan="2" class="auto-style5">
                            <asp:Label ID="Label7" runat="server" Text="Automatico" CssClass="etiqueta10"></asp:Label>
                        </td>
                        <td align="left" class="auto-style5">
                        </td>
                        <td>&nbsp;</td>
                        <td align="left" class="auto-style5">
                            &nbsp;
                            <asp:Label ID="Label8" runat="server" Text="Manual" CssClass="etiqueta10"></asp:Label>
                        </td>
                        <td align="left" class="auto-style5">
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label2" runat="server" Text="Clase de envio: " CssClass="etiqueta10"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddnClaseEnvio" runat="server" 
                                OnSelectedIndexChanged="ddnClaseEnvio_SelectedIndexChanged" AutoPostBack="True"
                                onclick="return submitBandejaXButton();">
                                <asp:ListItem Value="A">Altas</asp:ListItem>
                                <asp:ListItem Value="M">Modificaciones</asp:ListItem>
                                <asp:ListItem Value="B">Bajas</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>&nbsp;&nbsp;&nbsp;</td>
                        <td align="right">
                            <asp:Label ID="Label3" runat="server" Text="Nro. R.A.: " CssClass="etiqueta10"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtRA_A" runat="server" 
                                BackColor="#87CEEB" Width="74px"
                                onkeypress="return jsNumbers(event, 'num')" 
                                onKeyUp="javascript:return mask(this.value,this,'4','.');" 
                                onBlur="javascript:return mask(this.value,this,'4','.');"
                                MaxLength="7" >
                            </asp:TextBox>
                            <cc1:TextBoxWatermarkExtender ID="txtRA_A_WatermarkExtender" 
                                runat="server" Enabled="True" TargetControlID="txtRA_A" WatermarkText="____.__">
                            </cc1:TextBoxWatermarkExtender>                                
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="txtRA_A" ErrorMessage="1. Ingrese Numero de R.A. (Automatico)" 
                                ValidationGroup="GenerarEnvio">*1</asp:RequiredFieldValidator>
                        </td>
                        <td>&nbsp;</td>
                        <td align="right">
                            <asp:Label ID="Label5" runat="server" Text="Nro. R.A.: " CssClass="etiqueta10"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtRA_M" runat="server" 
                                BackColor="#87CEEB" Width="74px"
                                onkeypress="return jsNumbers(event, 'num')"
                                onKeyUp="javascript:return mask(this.value,this,'4','.');" 
                                onBlur="javascript:return mask(this.value,this,'4','.');"
                                MaxLength="7">
                            </asp:TextBox>
                            <cc1:TextBoxWatermarkExtender ID="txtRA_M_WatermarkExtender" 
                                runat="server" Enabled="True" TargetControlID="txtRA_M" WatermarkText="____.__">
                            </cc1:TextBoxWatermarkExtender>                                
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ControlToValidate="txtRA_M" ErrorMessage="3. Ingrese Numero de R.A. (Manual)" 
                                ValidationGroup="GenerarEnvio">*3</asp:RequiredFieldValidator>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label1" runat="server" Text="Fecha de Corte: " CssClass="etiqueta10"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtFechaCorte" runat="server" 
                                BackColor="#87CEEB" Width="75px"
                                onkeypress="return jsNumbers(event, 'num')"
                                onKeyUp="javascript:return mask(this.value,this,'2,5','/');" 
                                onBlur="javascript:return mask(this.value,this,'2,5','/');" 
                                MaxLength="10">
                            </asp:TextBox>
                            <cc1:TextBoxWatermarkExtender ID="txtFechaCorte_TextBoxWatermarkExtender" 
                                runat="server" Enabled="True" TargetControlID="txtFechaCorte" 
                                WatermarkText="__/__/____">
                            </cc1:TextBoxWatermarkExtender>
                            <asp:ImageButton ID="imgPopup" ImageUrl="../Imagenes/pequeños/CalendarC_16x16.png" ImageAlign="Bottom" runat="server" />
                            <cc1:CalendarExtender ID="txtFechaCorte_CalendarExtender" PopupButtonID="imgPopup" runat="server" TargetControlID="txtFechaCorte"
                                Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                            <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="txtFechaCorte"
                                ErrorMessage="0. Ingrese Fecha de Corte" Operator="DataTypeCheck" 
                                SetFocusOnError="True" Type="Date" ValidationGroup="GenerarEnvio" Text="*0">
                            </asp:CompareValidator>                           							
                        </td>
                        <td>&nbsp;&nbsp;&nbsp;</td>
                        <td align="right">
                            <asp:Label ID="Label4" runat="server" Text="Fecha R.A.: " CssClass="etiqueta10"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtFechaRA_A" runat="server" 
                                BackColor="#87CEEB" Width="75px"
                                MaxLength="10" 
                                onkeypress="return jsNumbers(event, 'num')"
                                onKeyUp="javascript:return mask(this.value,this,'2,5','/');" 
                                onBlur="javascript:return mask(this.value,this,'2,5','/');" >
                            </asp:TextBox>                            
                            <cc1:TextBoxWatermarkExtender ID="txtFechaRA_A_TextBoxWatermarkExtender" 
                                runat="server" Enabled="True" TargetControlID="txtFechaRA_A" 
                                WatermarkText="__/__/____">
                            </cc1:TextBoxWatermarkExtender>
                            <asp:ImageButton ID="imgPopup2" ImageUrl="../Imagenes/pequeños/CalendarC_16x16.png" ImageAlign="Bottom"
                                runat="server" />
                            <cc1:CalendarExtender ID="txtFechaRA_A_CalendarExtender" PopupButtonID="imgPopup2" runat="server" TargetControlID="txtFechaRA_A"
                                Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtFechaRA_A"
                                ErrorMessage="1. Ingrese Fecha de R.A. (Automatico)" Operator="DataTypeCheck" 
                                SetFocusOnError="True" Type="Date" ValidationGroup="GenerarEnvio" Text="*1">
                            </asp:CompareValidator>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="txtFechaRA_A" ErrorMessage="2. Ingrese Fecha de R.A. (Automatico)" 
                                ValidationGroup="GenerarEnvio">*2</asp:RequiredFieldValidator>							                           							
                        </td>
                        <td>&nbsp;</td>
                        <td align="right">
                            <asp:Label ID="Label6" runat="server" Text="Fecha R.A.: " CssClass="etiqueta10"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtFechaRA_M" runat="server"
                                BackColor="#87CEEB" Width="75px" MaxLength="10"
                                onkeypress="return jsNumbers(event, 'num')" 
                                onKeyUp="javascript:return mask(this.value,this,'2,5','/');" 
                                onBlur="javascript:return mask(this.value,this,'2,5','/');" >
                            </asp:TextBox>
                            <cc1:TextBoxWatermarkExtender ID="txtFechaRA_M_TextBoxWatermarkExtender" 
	                            runat="server" Enabled="True" TargetControlID="txtFechaRA_M" 
	                            WatermarkText="__/__/____">
                            </cc1:TextBoxWatermarkExtender>
                            <asp:ImageButton ID="imgPopup3" ImageUrl="../Imagenes/pequeños/CalendarC_16x16.png" ImageAlign="Bottom"
	                            runat="server" />
                            <cc1:CalendarExtender ID="txtFechaRA_M_CalendarExtender" PopupButtonID="imgPopup3" runat="server" TargetControlID="txtFechaRA_M"
	                            Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                            <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtFechaRA_M"
                                ErrorMessage="2. Ingrese Fecha de R.A. (Manual)" Operator="DataTypeCheck" 
                                SetFocusOnError="True" Type="Date" ValidationGroup="GenerarEnvio" Text="*2">
                            </asp:CompareValidator>
							<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                ControlToValidate="txtFechaRA_M" ErrorMessage="4. Ingrese Fecha de R.A. (Manual)" 
                                ValidationGroup="GenerarEnvio">*4</asp:RequiredFieldValidator>							                           							
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td align="center" colspan="9" class="auto-style5">
                            <asp:Button ID="btnBandejaPreliminar" runat="server" Text="Bandeja Preliminares" OnClick="btnBandejaPreliminar_Click" OnClientClick="return submitBandejaPreliminarButton();"/>
                            <asp:Button ID="btnGeneraEnvio" runat="server" Text="Generar Envio" OnClick="btnGeneraEnvio_Click" ValidationGroup="GenerarEnvio" />
                            <asp:Button ID="btnBandejaEnvios" runat="server" Text="Bandeja de Envios" OnClick="btnBandejaEnvios_Click" OnClientClick="return submitBandejaXButton();" />
                            <asp:Button ID="btnRemiteAltas" runat="server" Text="Remite Envios" OnClick="btnRemiteAltas_Click" />
                            <asp:Label ID="lblAutomatico" runat="server" Text=""></asp:Label>
                            <asp:Label ID="lblManual" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="9" class="auto-style5">
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="GenerarEnvio" />                
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    </table>
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
                </asp:Panel>
             </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlGrid1" runat="server" Visible="False" HorizontalAlign="Center" Width="100%" CssClass="panelceleste">
                    <table width="100%">
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Label ID="lblTitulo2" runat="server" Text="Bandeja de Envios" CssClass="etiqueta20"></asp:Label><br />
                                <asp:GridView ID="gvEnvios" runat="server" AutoGenerateColumns="False" CellPadding="4" 
                                    DataKeyNames="NumeroEnvio" ForeColor="#333333" GridLines="None" SkinID="GridView" 
                                    OnRowCommand="gvEnvios_RowCommand" OnRowDataBound="gvEnvios_RowDataBound">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:CommandField ShowSelectButton="True" />
                                        <asp:TemplateField HeaderText="NumeroEnvio" >
                                            <ItemTemplate>
                                                <asp:Label ID="lblNumeroEnvio" runat="server" Text='<%# Bind("NumeroEnvio") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="CodigoActualizacion" HeaderText="Actualizacion"  />
                                        <asp:BoundField DataField="Gestion" HeaderText="Gestion" />
                                        <asp:BoundField DataField="Mes" HeaderText="Mes" />
                                        <asp:BoundField DataField="FechaCorte" HeaderText="FechaCorte" DataFormatString="{0:d}" />
                                        <asp:CheckBoxField DataField="RegistroActivo" HeaderText="RegistroActivo" Visible="false" />
                                        <asp:BoundField DataField="TAutomaticos" HeaderText="Automaticos" ItemStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="TManuales" HeaderText="Manuales" ItemStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="TotalTramites" HeaderText="Total Tramites" ItemStyle-HorizontalAlign="Center" />
                                        <asp:TemplateField HeaderText="Ejecutar" ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:Button ID="btnGenerarMedios" runat="server" CausesValidation="false" CommandName="Generar" Text="Generar Medios" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:ButtonField ButtonType="Button" Text="Reporte RM-CC-01" 
                                            CommandName="Reporte01" HeaderText="Reportes" />
                                    </Columns>
                                    <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                                    <AlternatingRowStyle BackColor="White" />
                                    <EditRowStyle BackColor="#2461BF" />
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#dff1fc" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    <EmptyDataTemplate>
                                        <div align="center" class="CajaDialogoAdvertencia">
                                        <br/><img src="../Imagenes/warning.gif" 
                                                alt="No existen Envios que se puedan dar de Alta a la APS" />
                                        <br/>No existen Envios registrados para la Fecha de Corte ingresada
                                        <br/><br/>
                                        </div>
                                    </EmptyDataTemplate>
                                </asp:GridView>
                                <asp:GridView ID="gvDetalleEnvioAPS" runat="server" CellPadding="4" ForeColor="#333333" 
                                    GridLines="None" SkinID="GridView"  AutoGenerateColumns="False" 
                                    DataKeyNames="NumeroEnvio,Fila,IdActualizacion" 
                                    OnRowCommand="gvDetalleEnvioAPS_RowCommand" OnRowDataBound="gvDetalleEnvioAPS_RowDataBound">
                                    <AlternatingRowStyle BackColor="White" />
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:TemplateField ItemStyle-Width="40px">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImageButton1" runat="server" 
                                                    ImageUrl="~/Imagenes/32cortar.png" 
                                                    CommandName="EXCLUIR"
                                                    CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                    onclientclick="return confirm('Esta seguro de excluir el Certificado ?');"  />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="NumeroEnvio" >
                                            <ItemTemplate>
                                                <asp:Label ID="lblNumeroEnvio" runat="server" Text='<%# Bind("NumeroEnvio") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fila" >
                                            <ItemTemplate>
                                                <asp:Label ID="lblFila" runat="server" Text='<%# Bind("Fila") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="IdTramite" HeaderText="Trámite" />
                                        <asp:BoundField DataField="Clase_CC" HeaderText="Clase_CC" />
                                        <asp:BoundField DataField="Tipo_CC" HeaderText="Tipo_CC" />
                                        <asp:BoundField DataField="NroCertificado" HeaderText="NroCertificado" />
                                        <asp:BoundField DataField="NUP" HeaderText="NUP" />
                                        <asp:BoundField DataField="FechaResolucion" HeaderText="FechaResolucion" DataFormatString="{0:d}" />
                                        <asp:BoundField DataField="NumeroResolucion" HeaderText="NumeroResolucion" />
                                        <asp:CheckBoxField DataField="RegistroActivo" HeaderText="RegistroActivo" Visible="false" />
                                        <asp:TemplateField HeaderText="Actualizacion" >
                                            <ItemTemplate>
                                                <asp:HyperLink ID="hlkActualizacion" runat="server" 
                                                    Text='<%# Bind("CodigoActualizacion") %>'>
                                                </asp:HyperLink>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="PrimerNombre" HeaderText="Primer Nombre" />
                                        <asp:BoundField DataField="SegundoNombre" HeaderText="Segundo Nombre" />
                                        <asp:BoundField DataField="PrimerApellido" HeaderText="Primer Apellido" />
                                        <asp:BoundField DataField="SegundoApellido" HeaderText="Segundo Apellido" />
                                    </Columns>
                                    <EditRowStyle BackColor="#2461BF" />
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#dff1fc" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlGrid2" runat="server" Visible="False" HorizontalAlign="Center" Width="100%" CssClass="panelceleste">
					<asp:Label ID="lblTitBandejaPreliminares" runat="server" Text="Bandeja de Preliminares" CssClass="etiqueta20"></asp:Label>
                    <div style="vertical-align: top; left: auto; height: auto; overflow: auto; width: 1200px;">
                        <table align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td align="left">&nbsp;<asp:Label ID="Label16" runat="server" Text="Filas por página:" CssClass="etiqueta10"></asp:Label> 
                                <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" 
                                    OnSelectedIndexChanged="ddlPageSize_Changed">
                                    <asp:ListItem Text="10" Value="10" Selected="True" />                                    
                                    <asp:ListItem Text="50" Value="50" />
                                    <asp:ListItem Text="100" Value="100" />
                                </asp:DropDownList>
                                &nbsp;&nbsp;&nbsp;
                                &nbsp;&nbsp;&nbsp;<asp:Label ID="Label9" runat="server" Text="Certificados:   Automáticos[" CssClass="etiqueta10"></asp:Label>
                                    <asp:Label ID="lblRecordCountA" runat="server" Text="" CssClass="etiqueta10"></asp:Label>
                                <asp:Label ID="Label10" runat="server" Text="]" CssClass="etiqueta10"></asp:Label>&nbsp;&nbsp;&nbsp;<asp:Label ID="Label11" runat="server" Text="Manuales[" CssClass="etiqueta10"></asp:Label> 
                                    <asp:Label ID="lblRecordCountM" runat="server" Text="" CssClass="etiqueta10"></asp:Label>
                                <asp:Label ID="Label12" runat="server" Text="]" CssClass="etiqueta10"></asp:Label>&nbsp;&nbsp;&nbsp;<asp:Label ID="Label13" runat="server" Text="Total[" CssClass="etiqueta10"></asp:Label>
                                    <asp:Label ID="lblRecordCount" runat="server" Text="" CssClass="etiqueta10"></asp:Label>
                                <asp:Label ID="Label14" runat="server" Text="]" CssClass="etiqueta10"></asp:Label>&nbsp;<hr />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" colspan="2" class="auto-style5">
                                    <asp:GridView ID="gvPreliminarEnvios" runat="server"
                                        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                                        CellPadding="3" Font-Names="Verdana" Font-Size="8pt"
                                        OnRowDataBound="gvPreliminarEnvios_RowDataBound" 
                                        DataKeyNames="IdTramite,NUP,NroCertificado,Clase_CC">
                                        <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                                        <AlternatingRowStyle BackColor="#F7F7F7" />
                                        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                                        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                                        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                                        <Columns>
                                            <asp:TemplateField ItemStyle-Width="40px">
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="chkAll" runat="server" AutoPostBack="true" OnCheckedChanged="chkboxSelectAll_CheckedChanged" />
                                                </HeaderTemplate>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkPE" runat="server" ></asp:CheckBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Mostrar">
                                            <ItemTemplate>
                                                <asp:HyperLink ID="hlkMostrar" runat="server">Mostrar</asp:HyperLink>
                                            </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <div align="center" class="CajaDialogoAdvertencia">
                                            <br/><img src="../Imagenes/warning.gif" 
                                                    alt="No existen Envios que se puedan dar de Alta a la APS" />
                                            <br/>No existen Certificados que se puedan Enviar a la APS
                                            <br/><br/>
                                            </div>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" colspan="2" class="auto-style5">
                                <asp:Repeater ID="rptPager" runat="server">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkPage" runat="server" 
                                            Text = '<%#Eval("Text") %>' CommandArgument = '<%# Eval("Value") %>' 
                                                Enabled = '<%# Eval("Enabled") %>' OnClick = "rptPage_Changed" Font-Size="Small">
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:Repeater>
                                </td>
                            </tr>
                        </table>
                    </div>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>

