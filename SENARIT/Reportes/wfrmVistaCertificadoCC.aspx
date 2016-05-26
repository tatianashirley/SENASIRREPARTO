<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" 
    AutoEventWireup="true"
     CodeFile="wfrmVistaCertificadoCC.aspx.cs" 
    Inherits="Reportes_wfrmVistaCertificadoCC" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >

     <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" style="margin-right: 0px" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="807px">
         <LocalReport ReportPath="Reportes\VistaPreviaCertificadoCC.rdlc">
             <DataSources>
                 <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DsVistaCertificado" />
             </DataSources>
         </LocalReport>
     </rsweb:ReportViewer>
    <table style="width: 85%;" class="panelceleste" >
        <tr>
            <td align="center">
                 <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" OnSelecting="ObjectDataSource1_Selecting" SelectMethod="GetData" TypeName="dtsVistaCertificadoCCTableAdapters.PR_CertificadoCCVistaDatosTableAdapter">
                     <SelectParameters>
                         <asp:Parameter Name="Tramite" Type="Int32" />
                         <asp:Parameter Name="GrupoB" Type="Int32" />
                         <asp:Parameter Name="TipoForm" Type="Int32" />
                         <asp:Parameter Name="NoFormCalculo" Type="Int32" />
                         <asp:Parameter Name="Certi" Type="Int32" />
                         <asp:Parameter Name="Montoaceptado" Type="String" />
                     </SelectParameters>
                 </asp:ObjectDataSource>
             </td>
         </tr>
        <tr>
            <td>

                <asp:Button ID="Button1" runat="server" Text="Salir"   Width="100"  OnClientClick="window.close()"/>

            </td>
        </tr>
        </table>

   
    
   
</asp:Content>

