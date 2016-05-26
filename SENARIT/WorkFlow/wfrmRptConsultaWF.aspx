<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmRptConsultaWF.aspx.cs" Inherits="WorkFlow_wfrmRptConsultaWF" StylesheetTheme="Modal"%>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <asp:Panel ID="pnlRpt" runat="server" BackColor="White">
            <table style="width: 100%;">
                <tr>
                    <td align="center">
                        <asp:ImageButton ID="imgAtras" runat="server" AlternateText="Atrás" DescriptionUrl="Volver" ImageUrl="~/Imagenes/azulAtras.png" OnClick="imgAtras_Click" />
                    </td>
                <tr>
                    <td align="center">
                        <rsweb:ReportViewer ID="rptViewConsultaWF" runat="server" Height="800px" Width="1100px">
                        </rsweb:ReportViewer>
                    </td>
           </table>
        </asp:Panel>
    </div>
</asp:Content>

