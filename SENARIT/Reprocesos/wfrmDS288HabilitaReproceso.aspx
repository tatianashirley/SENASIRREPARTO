<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmDS288HabilitaReproceso.aspx.cs" Inherits="Reprocesos_wfrmDS288HabilitaReproceso" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table style="width: 100%;" class="panelceleste">
<tr>
    <td align="center">
        <asp:ImageButton ID="imgAux" runat="server" ImageUrl="~/Imagenes/16w.png" />
        <asp:Label ID="lblTituloAUX" runat="server" Text="DS28888 - Habilita Reproceso" CssClass="etiqueta20"> </asp:Label>
    </td>
</tr>
</table>
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
                    CellPadding="3" Font-Names="Verdana" Font-Size="8pt" AutoGenerateColumns="true"
                    DataKeyNames="IdTramite">
                    <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                    <AlternatingRowStyle BackColor="#F7F7F7" />
                    <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                    <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#FFDAB9" Font-Bold="True" ForeColor="#333333" />
                    <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSalarioCotizable" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
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
</table>
<asp:ImageButton ID="imgVolver" runat="server"  ImageUrl="~/Imagenes/32Volver.png" ToolTip="Volver a la Página anterior" OnClick="btnVolver_Click" /> 
<asp:Label ID="lblTVolver" CssClass="etiqueta8Blue" runat="server" Text="Volver" /> 
</asp:Content>

