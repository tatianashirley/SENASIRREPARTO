<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmListaFormulariosCC.aspx.cs" Inherits="CertificacionCC_wfrmListaFormulariosCC" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <script type="text/javascript" language="javascript">
         function checkDate(sender, args) {
             if (sender._selectedDate > new Date()) {
                 alert("¡Usted no puede seleccionar una fecha superior");
                 document.getElementById('<%=txtFechaFin.ClientID %>').value = "";
            }
        }
         </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <br />
<asp:Panel ID="pnlOpcionBusqueda" runat="server"  BackColor="White" GroupingText="Parametro de Busqueda" Width="100%">
        <div align="center">
        <table style="width:100%;">
            <tr>
                <td  align="center" colspan="2" >
                    <asp:Label ID="Label1" runat="server" Text="Ingresar fechas a visualizar" ></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" width="50%">&nbsp;</td>
                <td align="left">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" width="50%">
                    <asp:Label ID="Label2" runat="server" Text="De:"></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="txtFechaInicio" runat="server"></asp:TextBox>
                    <asp:ImageButton ID="imgcalendarioinicio" runat="server" CssClass="CajaDialogo" ImageUrl="~/Imagenes/32calendario.png"   CausesValidation="false"/>
                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFechaInicio"  Format="dd/MM/yyyy" PopupButtonID="imgcalendarioinicio"  CssClass="cal_Theme1" >  </cc1:CalendarExtender>	
                    <asp:RequiredFieldValidator ID="rfvFechaInicio" runat="server" ControlToValidate="txtFechaInicio" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>

                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="Label3" runat="server" Text="A:"></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="txtFechaFin" runat="server"></asp:TextBox>
                     <asp:ImageButton ID="imgcalendariofin" runat="server" CssClass="CajaDialogo" ImageUrl="~/Imagenes/32calendario.png"   CausesValidation="false"/>
                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtFechaFin"  Format="dd/MM/yyyy" PopupButtonID="imgcalendariofin"  OnClientDateSelectionChanged="checkDate" CssClass="cal_Theme1" >  </cc1:CalendarExtender>	
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFechaFin" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>

                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
                </td>
                <td align="left">
                    <asp:Button ID="btnLimpiar" runat="server" OnClick="btnLimpiar_Click" Text="Limpiar" />
                </td>
            </tr>
        </table>
            </div>
    </asp:Panel>
</asp:Content>

