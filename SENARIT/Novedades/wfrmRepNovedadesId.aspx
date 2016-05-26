<%@ Page Title="" Language="C#"  AutoEventWireup="true" CodeFile="wfrmRepNovedadesId.aspx.cs" Inherits="Novedades_wfrmRepNovedadesId" StylesheetTheme="Modal" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>




<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
   

     <script type="text/javascript" src="../js/jquery-1.10.1.min.js"></script> 
   <%-- <script type="text/javascript" src="../js/jquery.maskedinput.js"></script> 
    <script type="text/javascript" src="../js/jquery.alphanumeric.js"></script>
    <script type="text/javascript">
        window.onload = function () {
            window.frames['ReportFrame<%= ReportViewer1.ClientID %>'].
            window.frames['report'].
                document.getElementById('oReportCell').
                    style.width = '100%';
    }
    </script>--%>
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
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
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
        <asp:Button ID="Button1" runat="server" Text="Volver" OnClick="VolverBuscaNoves" />
        <asp:ObjectDataSource ID="DsNovedadesId" runat="server" OnSelecting="DsNovedadesId_Selecting" SelectMethod="ReporteNovedadesIdTabla" TypeName="wcfNovedades.Logica.clsNovedades">
            <SelectParameters>
                <asp:Parameter DefaultValue="" Name="IdActualizacion" Type="Int32" />
            </SelectParameters>
    </asp:ObjectDataSource>
    </div>
    
    </div>
    </form>
</body>
</html>


