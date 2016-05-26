<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmRepNovedadesMod.aspx.cs" Inherits="EnvioAPS_wfrmRepNovedadesMod" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type="text/javascript">
    $(document).ready(function () {
        $("#BtnImprimir").click(imprimirDiv);    //Asociando la función "imprimirDiv" al clic del botón para Imprimir Reporte
    });

    function imprimirDiv() {
        var divImprimir = $("div[id$='ReportDiv']").parent();        //Obteniendo el padre del DIV que contiene al reporte
        var estilos = $("head style[id$='ReportControl_styles']");    //Obteniendo los estilos del reporte
        newWin = window.open("");        //Abriendo una nueva ventana

        //Construyendo el HTML de la nueva ventana, con los estilos del reporte y el div que contiene el reporte
        newWin.document.write('<html xmlns="http://www.w3.org/1999/xhtml"><head><style type="text/css">' + estilos.html() + '</style></head><body>' + divImprimir.html() + '</body>');
        newWin.document.close();        //Finalizando la escritura
        newWin.print();        //Imprimir contenido de nueva ventana
        newWin.close();        //Cerrar nueva ventana
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div align="center">
<asp:ImageButton ID="BtnImprimir" runat="server" Text="Imprimir" CausesValidation="False" OnClientClick="return false;" UseSubmitBehavior="False" ImageUrl="~/Imagenes/16imprimir.png" Height="16px" Width="17px" /> <asp:Label ID="lblImprimir" runat="server" Text="Imprimir Reporte"></asp:Label>
<rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="800px" 
    AsyncRendering="False" SizeToReportContent="True" OnInit="ReportViewer1_Init" OnLoad="ReportViewer1_Load">
    <LocalReport ReportPath="Novedades\repNovedadesId.rdlc">
        <DataSources>
            <rsweb:ReportDataSource DataSourceId="DsNovedadesId" Name="DataSet1" />
        </DataSources>
    </LocalReport>
</rsweb:ReportViewer>
<br />
<asp:ImageButton ID="imgVolver" runat="server"  ImageUrl="~/Imagenes/32Volver.png" ToolTip="Volver a la Página anterior" OnClick="VolverBuscaNoves" /> 
<asp:Label ID="lblTVolver" CssClass="etiqueta8Blue" runat="server" Text="Volver" /> 
<asp:ObjectDataSource ID="DsNovedadesId" runat="server" OnSelecting="DsNovedadesId_Selecting" SelectMethod="ReporteNovedadesIdTabla" TypeName="wcfNovedades.Logica.clsNovedades">
    <SelectParameters>
        <asp:Parameter DefaultValue="" Name="IdActualizacion" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
</div>
</asp:Content>

