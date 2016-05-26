<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListaOficinasU.aspx.cs" Inherits="ListaOficinasU" StylesheetTheme="Modal" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

    .cssHeaderImg
	{
	background-image : url(../Imagenes/Frames/Menu5.png);
    }

        </style>
</head>
<body>

    <form id="form2" runat="server">
    <table style="width:100%;">
                        <tr>
                            <td align="center">
                                &nbsp;</td>
                            <td align="center">
                                &nbsp;</td>
                            <td align="center">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" >
                                </td>
                            <td align="center" >
                <asp:Panel ID="pnlLogin" runat="server" Width="60%" CssClass="panelprincipal2">
                    <table style="width:100%;">
                        <tr>
                            <td colspan="3" align="center">
                                <asp:Label ID="lblCodUsuario" runat="server" Font-Size="Small" Visible="False"></asp:Label>
                                <asp:Label ID="lblOficina" runat="server" Font-Size="Small" Visible="False"></asp:Label>
                                <asp:Label ID="Label1" runat="server" CssClass="etiqueta20" Text="Bienvenido!!!"></asp:Label>
                                <asp:Label ID="lblCuentaUsuario" runat="server" Font-Size="Small" Visible="False"></asp:Label>
                                <br />
                                <asp:Label ID="Label4" runat="server" CssClass="etiqueta20" Text="Seleccione Oficina a Ingresar"></asp:Label>
                                <asp:Label ID="lblContador" runat="server" Font-Size="Small" Visible="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" rowspan="2">
                                <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/32usuario.png" />
                            </td>
                            <td align="center">
                                <asp:Label ID="lblNombreCompleto" runat="server" CssClass="etiqueta10"></asp:Label>
                            </td>
                            <td align="center" rowspan="2">
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/32usuario.png" />
                            </td>

                        </tr>
                        <tr>
                            <td align="center">
                                    <asp:GridView ID="gvDatos" runat="server" EnableTheming="True" 
                                    HorizontalAlign="Center" SkinID="GridView" 
                                        EnableModelValidation="True" 
                                        onselectedindexchanged="gvDatos_SelectedIndexChanged" Width="80%" 
                                        OnRowDataBound="gvDatos_RowDataBound" 
                                        >

                                    <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                                    <Columns>
                                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/Imagenes/sig.png" 
                                            HeaderText="Sel" ItemStyle-Width="20%" ShowSelectButton="True">
                                        <ItemStyle HorizontalAlign="Center" />
                                        </asp:CommandField>

                                        <asp:BoundField DataField="Oficina" HeaderText="Oficinas Asignadas" 
                                            ItemStyle-Width="60%">
                                        <ItemStyle Width="60%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="IdOficina" HeaderText="Id" ItemStyle-Width="20%" >
                                        <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                    </Columns>
                                    </asp:GridView>
                                    <tr>
                                        <td align="center" colspan="3">
                                            <asp:Label ID="Label2" runat="server" Text="Fecha Actual:" CssClass="etiqueta8" 
                                                Font-Size="X-Small"></asp:Label>
                                            <asp:Label ID="lblFechaActual" runat="server" CssClass="etiqueta8" 
                                                Font-Size="X-Small"></asp:Label>
                                            <asp:Label ID="Label3" runat="server" Text="Fecha Modificacion:" 
                                                CssClass="etiqueta8" Font-Size="X-Small" Visible="False"></asp:Label>
                                            <asp:Label ID="lblFechaModificacion" runat="server" CssClass="etiqueta8" 
                                                Font-Size="X-Small" Visible="False"></asp:Label>
                                            <br />
                                            <asp:Label ID="lblObservaciones" runat="server" CssClass="text_obs">
                                            </asp:Label>
                                        </td>
                                    </tr>
                                </asp:Panel>
                            </td>
                            <td align="center" >
                                </td>
                        </tr>
                        <tr>
                            <td align="center">
                                &nbsp;</td>
                            <td align="center">
                                &nbsp;</td>
                            <td align="center">
                                &nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
            <td>
    </form>
</body>
</body>
</html>
