<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BusquedaPredictiva.aspx.cs" Inherits="BusquedaPredictiva" StylesheetTheme="Modal" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Geografia Prueba 1" CssClass="etiqueta20"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Localidad" CssClass="etiqueta10"></asp:Label>
                <asp:TextBox ID="txtBuscarLocalidad" runat="server" Width="300px" CssClass="texto10_Upper"></asp:TextBox>
                   <cc1:autocompleteextender ID="txtBuscarLocalidad_AutoCompleteExtender" runat="server" 
                    completioninterval="10" 
                    completionsetcount="1" 
                    EnableCaching="True" 
                    Enabled="True" 
                    MinimumPrefixLength="1" 
                    ServiceMethod="wsBuscarLocalidad" 
                    servicepath="~/BuscarLocalidad.asmx" 
                    TargetControlID="txtBuscarLocalidad" 
                    UseContextKey="True"
                    CompletionListCssClass="completionList " 
                    CompletionListHighlightedItemCssClass="listItem" 
                    CompletionListItemCssClass="itemHighlighted">
                   </cc1:autocompleteextender>

                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Imagenes/16Buscar.png" OnClick="ImageButton1_Click" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td align="center">
                <asp:GridView ID="gvGeo" runat="server" AutoGenerateColumns="False" EnableModelValidation="True" OnSelectedIndexChanged="gvGeo_SelectedIndexChanged" SkinID="GridView">
                    <Columns>
                        <asp:CommandField ButtonType="Image" HeaderText="Seleccionar" ItemStyle-Width="10%" SelectImageUrl="~/Imagenes/sig.png" ShowSelectButton="True">
                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:CommandField>
                        <asp:BoundField DataField="IdDepartamento" HeaderText="ID" ItemStyle-Width="2%">
                        <ItemStyle Width="2%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="NombreDepartamento" HeaderText="Departamento" ItemStyle-Width="18%">
                        <ItemStyle Width="18%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="IdProvincia" HeaderText="ID" ItemStyle-Width="2%">
                        <ItemStyle Width="2%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="NombreProvincia" HeaderText="Provincia" ItemStyle-Width="18%">
                        <ItemStyle Width="18%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="IdSeccion" HeaderText="ID" ItemStyle-Width="2%">
                        <ItemStyle Width="2%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="NombreSeccionMunicipal" HeaderText="Seccion" ItemStyle-Width="28%">
                        <ItemStyle Width="28%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="IdLocalidad" HeaderText="ID" InsertVisible="false" ItemStyle-Width="2%">
                        <ItemStyle Width="2%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="NombreLocalidad" HeaderText="Localidad" ItemStyle-Width="18%">
                        <ItemStyle Width="18%" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="lblIDs" runat="server" Text="dep:"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>

