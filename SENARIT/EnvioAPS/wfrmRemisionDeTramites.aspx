<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmRemisionDeTramites.aspx.cs" Inherits="EnvioAPS_wfrmRemisionDeTramites" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
.auto-style5 {
    width: 20%;
    height: 36px;
}
.auto-style4 {
    width: 30%;
    height: 36px;
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
.panelEmergente
{
    /*background-color: lightskyblue;*/
    border: thin solid lightsteelblue;
    background-color: #dff1fc;
}
    .auto-style7 {
        width: 225px;
    }
    .auto-style9 {
        width: 25%;
    }
        .auto-style11 {
            width: 46px;
        }
        .auto-style12 {
            width: 461px;
        }
        .auto-style13 {
            width: 563px;
        }
    </style>
<script type="text/javascript">
    function mask(str, textbox, loc, delim) {
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="100%" class="panelceleste">
<tr>
    <td colspan="4" align="left">
        <asp:Label ID="Label5" runat="server" Text="Remisión de Tramites de Envios APS" CssClass="etiqueta10" Font-Bold="True"></asp:Label>
    </td>
</tr>
<tr>
    <td style="text-align:right" class="auto-style5" >
        <asp:Label ID="Label1" runat="server" CssClass="etiqueta10" Text="Fecha de Corte: "></asp:Label>
    </td>
    <td style="text-align:left" class="auto-style4">
        <asp:TextBox ID="txtFechaCorte" runat="server" 
            BackColor="#87CEEB" Width="75px"
            MaxLength="10"
            onkeypress="return jsNumbers(event, 'num')"
            onKeyUp="javascript:return mask(this.value,this,'2,5','/');" 
            onBlur="javascript:return mask(this.value,this,'2,5','/');" >
        </asp:TextBox>                            
        <cc1:TextBoxWatermarkExtender ID="txtFechaCorte_TextBoxWatermarkExtender" 
            runat="server" Enabled="True" TargetControlID="txtFechaCorte" 
            WatermarkText="__/__/____">
        </cc1:TextBoxWatermarkExtender>
        <asp:ImageButton ID="imgPopup" ImageUrl="../Imagenes/pequeños/CalendarC_16x16.png" ImageAlign="Bottom" runat="server" />
        <cc1:CalendarExtender ID="txtFechaCorte_CalendarExtender" PopupButtonID="imgPopup" runat="server" TargetControlID="txtFechaCorte"
            Format="dd/MM/yyyy">
        </cc1:CalendarExtender>
        <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txtFechaCorte"
            Operator="DataTypeCheck" 
            SetFocusOnError="True" Type="Date" Text="* Fecha de Corte Invalida">
        </asp:CompareValidator>                           							
    </td>
    <td style="text-align:right" class="auto-style5">
        <asp:Label ID="Label3" runat="server" CssClass="etiqueta10" Text="Numero de Envio: "></asp:Label>
    </td>
    <td style="text-align:left" class="auto-style4">
        <asp:DropDownList ID="ddlNumeroEnvios" runat="server" Width="109px" />
    </td>
</tr>
<tr>
    <td style="text-align:right" class="auto-style5" >
        <asp:Label ID="Label2" runat="server" Text="Entidad: " CssClass="etiqueta10"></asp:Label>
    </td>
    <td style="text-align:left" class="auto-style4">
        <asp:DropDownList ID="ddlEntidades" runat="server" />
    </td>
    <td style="text-align:right" class="auto-style5" >
        <asp:ImageButton ID="imgBuscar" runat="server"  ImageUrl="~/Imagenes/32Buscar.png" ToolTip="Buscar Datos" OnClick="imgBuscar_Click"   /> 
        <asp:Label ID="lblRefres" CssClass="etiqueta8Blue" runat="server" Text="Buscar" />
    </td>
    <td style="text-align:left" class="auto-style4">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:ImageButton ID="imgImprimir" runat="server"  ImageUrl="~/Imagenes/Menu/Impresora.png" ToolTip="Imprimir Datos" OnClick="imgImprimir_Click"   /> 
        <asp:Label ID="Label6" CssClass="etiqueta8Blue" runat="server" Text="Imprimir" />
    </td>
</tr>
<tr>
    <td colspan="4" align="center">
        <asp:GridView ID="gvEnvioDeMedios" runat="server" 
            AllowPaging="True" PageSize="5" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" 
            ForeColor="#333333" GridLines="None" SkinID="GridView" 
            OnRowCommand="gvEnvioDeMedios_RowCommand"
            OnRowDataBound="gvEnvioDeMedios_RowDataBound"
            OnPageIndexChanging="gvEnvioDeMedios_PageIndexChanging"
            OnSorting="gvEnvioDeMedios_Sorting"
            DataKeyNames="NumeroEnvio,IdEntidad" HorizontalAlign="Center">
            <Columns>
                <asp:TemplateField ItemStyle-Width="40px">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" 
                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" 
                            ToolTip="Actualizar Cite de Envío APS" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-Width="40px">
                    <ItemTemplate>
                        <asp:ImageButton ID="imgDetTramite" runat="server" 
                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                CommandName="DETALLE01"
                                ImageUrl="~/Imagenes/16AttachDocumentMoveDown.gif" CausesValidation="false" 
                                ToolTip="Ver detalle de Tramites de Envío APS"/>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-Width="40px">
                    <ItemTemplate>
                        <asp:ImageButton ID="imgRemiteTramites" runat="server" 
                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                CommandName="REMITE"
                                ImageUrl="~/Imagenes/16DocFolderMoveRight.gif" CausesValidation="false" 
                                ToolTip="Remite Tramites asocialdos al Envío a Archivo Central"/>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:BoundField DataField="NumeroEnvio" HeaderText="NumeroEnvio" SortExpression="NumeroEnvio" />
                <asp:BoundField DataField="Entidad" HeaderText="Entidad" SortExpression="Entidad" />
                <asp:BoundField DataField="NumeroCite" HeaderText="NumeroCite" SortExpression="NumeroCite" />
                <asp:BoundField DataField="FechaCite" HeaderText="FechaCite" ReadOnly="True" SortExpression="FechaCite" />
                <asp:BoundField DataField="FechaRecepcion" HeaderText="FechaRecepcion" ReadOnly="True" SortExpression="FechaRecepcion" />
                <asp:TemplateField HeaderText="ArchivoEnvioNombre" SortExpression="ArchivoEnvioNombre">
                    <ItemTemplate>
				        <asp:HyperLink ID="HyperLink1" runat="server"
					        NavigateUrl='<%# string.Format("wfrmGetFile.aspx?FC=0&NumeroEnvio={0}&IdEntidad={1}",
						        HttpUtility.UrlEncode(Eval("NumeroEnvio").ToString()), HttpUtility.UrlEncode(Eval("IdEntidad").ToString())) %>'
					        Text='<%# Eval("ArchivoEnvioNombre") %>'>
				        </asp:HyperLink>													
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="ArchivoEnvioLongitud" HeaderText="ArchivoEnvioLongitud" SortExpression="ArchivoEnvioLongitud" />
                <asp:TemplateField HeaderText="ArchivoEnvioCRCNombre" SortExpression="ArchivoEnvioCRCNombre">
                    <ItemTemplate>
				        <asp:HyperLink ID="HyperLink2" runat="server"
					        NavigateUrl='<%# string.Format("wfrmGetFile.aspx?FC=1&NumeroEnvio={0}&IdEntidad={1}",
						        HttpUtility.UrlEncode(Eval("NumeroEnvio").ToString()), HttpUtility.UrlEncode(Eval("IdEntidad").ToString())) %>'
					        Text='<%# Eval("ArchivoEnvioCRCNombre") %>'>
				        </asp:HyperLink>													
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="CRC32" HeaderText="CRC32" ReadOnly="True" SortExpression="CRC32" />
                <asp:ButtonField ButtonType="Button" Text="Reporte RM-CC-01" 
                    CommandName="Reporte01" HeaderText="Reportes" />
            </Columns>
            <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerSettings Mode="NumericFirstLast" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#dff1fc" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
            <EmptyDataTemplate>
                <div align="center" class="CajaDialogoAdvertencia">
                <br/><img src="../Imagenes/warning.gif" 
                        alt="No existen Envios que se puedan dar de Alta a la APS" />
                <br/>No existen Envios de Medios para mostrar
                <br/><br/>
                </div>
            </EmptyDataTemplate>
        </asp:GridView>
        <asp:HiddenField ID="HFmodal1" runat="server" />
        <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server"
            TargetControlID="HFmodal1" PopupControlID="pnlObservado"
            CancelControlID="btnCancel" BackgroundCssClass="modalBackground2">
        </cc1:ModalPopupExtender>
        <asp:Panel ID="pnlObservado" runat="server" CssClass="panelEmergente" Height="60%" Width="60%">
            <table cellspacing="4" style="margin-left: 0px;">
	            <tr style="background-color:#AFC6E0">
                    <td class="auto-style11"></td>
	                <td colspan="2"  align="center">Registra Recepción de Cite</td>
                    <td class="auto-style7"></td>
	            </tr>
	            <tr>
                    <td class="auto-style11"></td>
		            <td align="right" class="auto-style9">
		            NroEnvio:
		            </td>
		            <td align="left" class="auto-style13">
		            <asp:Label ID="lblNumeroEnvio" runat="server"></asp:Label>
		            </td>
                    <td class="auto-style7"></td>
	            </tr>
	            <tr>
                    <td class="auto-style11"></td>
		            <td align="right" class="auto-style9">
		            IdEntidad:
		            </td>
		            <td align="left" class="auto-style13">
		            <asp:Label ID="lblIdEntidad" runat="server"></asp:Label>
		            </td>
                    <td class="auto-style7"></td>
	            </tr>
	            <tr>
                    <td class="auto-style11"></td>
		            <td align="right" class="auto-style9">
		            Entidad:
		            </td>
		            <td align="left" class="auto-style13">
                    <asp:Label ID="lblEntidad" runat="server"></asp:Label>
		            </td>
                    <td class="auto-style7"></td>
	            </tr>
	            <tr>
                    <td class="auto-style11"></td>
		            <td align="right" class="auto-style9">
		            Numero de Cite:
		            </td>
		            <td align="left" class="auto-style13">
                        <asp:TextBox ID="txtNumeroCite" runat="server"
                            MaxLength="25">
                        </asp:TextBox>
		            </td>
                    <td class="auto-style7"></td>
	            </tr>
	            <tr>
                    <td class="auto-style11"></td>
		            <td align="right" class="auto-style9">
		            Fecha de Cite:
		            </td>
		            <td align="left" class="auto-style13">
                        <asp:TextBox ID="txtFechaCite" runat="server" 
                            BackColor="#87CEEB" Width="75px"
                            MaxLength="10"
                            onkeypress="return jsNumbers(event, 'num')"
                            onKeyUp="javascript:return mask(this.value,this,'2,5','/');" 
                            onBlur="javascript:return mask(this.value,this,'2,5','/');" >
                        </asp:TextBox>                            
                        <cc1:TextBoxWatermarkExtender ID="txtFechaCite_TextBoxWatermarkExtender" 
                            runat="server" Enabled="True" TargetControlID="txtFechaCite" 
                            WatermarkText="__/__/____">
                        </cc1:TextBoxWatermarkExtender>
                        <asp:ImageButton ID="imgPopupFechaCite" ImageUrl="../Imagenes/pequeños/CalendarC_16x16.png" ImageAlign="Bottom" runat="server" />
                        <cc1:CalendarExtender ID="txtFechaCite_CalendarExtender" PopupButtonID="imgPopupFechaCite" runat="server" TargetControlID="txtFechaCite"
                            Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                        <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="txtFechaCite"
                            Operator="DataTypeCheck" 
                            SetFocusOnError="True" Type="Date" Text="* Fecha Invalida">
                        </asp:CompareValidator>                           							
		            </td>
                    <td class="auto-style7"></td>
	            </tr>
	            <tr>
                    <td class="auto-style11"></td>
		            <td align="right" class="auto-style9">
		            Fecha de Recepción:
		            </td>
		            <td align="left" class="auto-style13">
                        <asp:TextBox ID="txtFechaRecepcion" runat="server" 
                            BackColor="#87CEEB" Width="75px"
                            MaxLength="10"
                            onkeypress="return jsNumbers(event, 'num')"
                            onKeyUp="javascript:return mask(this.value,this,'2,5','/');" 
                            onBlur="javascript:return mask(this.value,this,'2,5','/');" >
                        </asp:TextBox>                            
                        <cc1:textboxwatermarkextender ID="txtFechaRecepcion_TextBoxWatermarkExtender" 
                            runat="server" Enabled="True" TargetControlID="txtFechaRecepcion" 
                            WatermarkText="__/__/____">
                        </cc1:textboxwatermarkextender>
                        <asp:ImageButton ID="imgPopupFechaRecepcion" ImageUrl="../Imagenes/pequeños/CalendarC_16x16.png" ImageAlign="Bottom" runat="server" />
                        <cc1:calendarextender ID="txtFechaRecepcion_CalendarExtender" PopupButtonID="imgPopupFechaRecepcion" runat="server" TargetControlID="txtFechaRecepcion"
                            Format="dd/MM/yyyy">
                        </cc1:calendarextender>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtFechaRecepcion"
                            Operator="DataTypeCheck" 
                            SetFocusOnError="True" Type="Date" Text="* Fecha Invalida">
                        </asp:CompareValidator>                           							
		            </td>
                    <td class="auto-style7"></td>
	            </tr>
	            <tr>
                    <td class="auto-style11"></td>
		            <td align="right" class="auto-style9" >
		            </td>
		            <td class="auto-style13">
		            <asp:Button ID="btnGrabaCite" CommandName="Observado" runat="server" Text="Registra Cite" OnClick="btnGrabaCite_Click" />
		            <asp:Button ID="btnCancel" runat="server" Text="Cancelar" />
		            </td>
                    <td class="auto-style7"></td>
	            </tr>
            </table>
        </asp:Panel>
    </td>
</tr>
<tr>
    <td colspan="4" align="center">
        <asp:GridView ID="gvEnvioDeMediosDetalle" runat="server" AutoGenerateColumns="false"
            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" 
            CellPadding="4" GridLines="None" SkinID="GridView" Font-Names="Verdana" Font-Size="8pt"
            AllowPaging="True" PageSize="15" 
            OnPageIndexChanging="gvEnvioDeMediosDetalle_PageIndexChanging" 
            DataKeyNames="NumeroEnvio,IdTramite" >
            <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerSettings Mode="NumericFirstLast" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#dff1fc" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <Columns>
                <asp:BoundField DataField="NumeroEnvio" HeaderText="NumeroEnvio" Visible="true" />
                <asp:BoundField DataField="NroCertificado" HeaderText="NroCertificado" Visible="true" />
                <asp:BoundField DataField="IdTramite" HeaderText="IdTramite" Visible="true" />
                <asp:BoundField DataField="DescTipoTramite" HeaderText="DescTipoTramite" Visible="true" />
                <asp:BoundField DataField="DescTipoCC" HeaderText="DescTipoCC" Visible="true" />
                <asp:BoundField DataField="NUP" HeaderText="NUP" Visible="true" />
                <asp:BoundField DataField="PrimerApellido" HeaderText="PrimerApellido" Visible="true" />
                <asp:BoundField DataField="SegundoApellido" HeaderText="SegundoApellido" Visible="true" />
                <asp:BoundField DataField="PrimerNombre" HeaderText="PrimerNombre" Visible="true" />
                <asp:BoundField DataField="SegundoNombre" HeaderText="SegundoNombre" Visible="true" />
                <asp:BoundField DataField="DescEntidadGestora" HeaderText="DescEntidadGestora" Visible="true" />
            </Columns>
            <EmptyDataTemplate><div align="center" class="CajaDialogoAdvertencia">
                <br/><img src="../Imagenes/warning.gif" 
                        alt="No existen tramites remitidos" />
                <br/>No existen tramites relacionados
                <br/><br/>
                </div>
            </EmptyDataTemplate>
        </asp:GridView>
    </td>
</tr>
</table>
</asp:Content>

