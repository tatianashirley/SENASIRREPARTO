<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmAprobacionTopeSalarial.aspx.cs" Inherits="CertificacionCC_wfrmAprobacionTopeSalarial" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="pnlRegistroTopes" runat="server">
        <table style="width: 100%;">
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblTitulo" runat="server" Text="Ingresar Tope Salarial"></asp:Label>
                </td>
                
            </tr>
            <tr>
                <td width="50%">&nbsp;</td>
                <td>&nbsp;</td>
                
            </tr>
            <tr>
                <td class="auto-style1" align="right">
                    <asp:Label ID="Label1" runat="server" Text="Tramite: "></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="txtTramite" runat="server"></asp:TextBox>
                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Numbers,UppercaseLetters,LowercaseLetters,Custom" ValidChars="-" TargetControlID="txtTramite" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtTramite"></asp:RequiredFieldValidator>
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" CausesValidation="false" />
                </td>
                
            </tr>
            <tr>
                <td class="auto-style1" align="right"><asp:Label ID="Label2" runat="server" Text="Periodo del Salario: "></asp:Label></td>
                <td align="left">
                    <asp:TextBox ID="txtPeriodoSalario" runat="server" OnTextChanged="txtPeriodoSalario_TextChanged" AutoPostBack="True"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPeriodoSalario" ErrorMessage="error en formato" ValidationExpression="((0[1-9]|1[012])[ /](190[0-9]|191[0-9]|192[0-9]|193[0-9]|194[0-9]|195[0-9]|196[0-9]|197[0-9]|198[0-9]|199[0-6]))|((0[1-5])[ /](1997))|((0[1-9]|1[012])[/](4[0-9]|5[0-9]|6[0-9]|7[0-9]|8[0-9]|9[0-9]))">*</asp:RegularExpressionValidator>
                </td>
            </tr>
             <tr>
                <td class="auto-style1" align="right"><asp:Label ID="Label4" runat="server" Text="Tipo Moneda: "></asp:Label></td>
                <td align="left">
                    <asp:DropDownList ID="ddlMonedaSalario" runat="server" Enabled="false">
                    </asp:DropDownList>
                    
                </td>
            </tr>
            <tr>
                <td class="auto-style1" align="right"><asp:Label ID="Label3" runat="server" Text="Cotizable: "></asp:Label></td>
                <td align="left">
                    <asp:TextBox ID="txtMonto" runat="server" onChange="redondeo2decimales(this.id)" onfocus="selecciona_value(this)" onkeyup="validadecimal(this.id)" MaxLength="20"></asp:TextBox>
                    <cc1:FilteredTextBoxExtender ID="txtSalarioCotizable_Filtro" runat="server" Enabled="True" FilterType="Custom, Numbers" TargetControlID="txtMonto" ValidChars="."/>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtMonto" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right" class="auto-style1">&nbsp;</td>
                <td align="left">&nbsp;</td>
            </tr>
            <tr>
                <td align="center" class="auto-style1" colspan="2">
                    <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" OnClick="btnRegistrar_Click" />
                    <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" OnClick="btnLimpiar_Click" CausesValidation="false" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnlListaTopeSalarial" runat="server">
        <div align="center">
        <asp:GridView ID="gvDatos" runat="server"
                        AllowPaging="True" PageSize="15"
                        AutoGenerateColumns="False"
                        EnableTheming="True"
                        Font-Names="Arial"
                        Font-Size="9pt"
                        CssClass="mGrid"
                        PagerStyle-CssClass="pgr"
                        AlternatingRowStyle-CssClass="alt"
                        GridLines="None"
                        DataKeyNames="IdTramite,IdGrupoBeneficio,IdMoneda,Moneda,Fecha,Cotizable,FechaRegistro,RegistroActivo"
                        OnRowCommand="gvDatos_RowCommand"
                        OnRowDataBound="gvDatos_RowDataBound" >

                        <Columns>
                            <asp:BoundField DataField="Fecha" HeaderText="Periodo" />
                            <asp:BoundField DataField="Cotizable" HeaderText="Cotizable" />
                            <asp:BoundField DataField="Moneda" HeaderText="Moneda" />
                            <asp:BoundField DataField="FechaRegistro" HeaderText="Fecha Registro" />
                            
                     
                            <asp:TemplateField HeaderText="Actividad">
                                <ItemTemplate>
                                    <center>
                                        <asp:ImageButton ID="imgEliminar" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdEliminar" ImageUrl="~/imagenes/nueva3/eliminar32.png" ToolTip="Eliminar Salario Cotizable" OnClientClick="return confirm('Esta seguro de eliminar el registro?');" />
                                        
                                    </center>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <div align="center" class="CajaDialogoAdvertencia">
                                <br />
                                <img src="../Imagenes/warning.gif"
                                    alt="No existen datos que correspondan al criterio especificado" />
                                <br />
                                No existen datos que correspondan al criterio especificado
                                <br />
                                <br />
                            </div>
                        </EmptyDataTemplate>
                        <SelectedRowStyle BackColor="#FFFF99" />
                    </asp:GridView>
            </div>
    </asp:Panel>
</asp:Content>

