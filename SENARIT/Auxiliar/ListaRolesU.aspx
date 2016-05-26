<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListaRolesU.aspx.cs" Inherits="ListaRolesU" StylesheetTheme="Modal" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="App_Themes/css/Mensajes.css" rel="stylesheet" type="text/css" />
    <link href="App_Themes/css/Styles.css" rel="stylesheet" type="text/css" />
    <title></title>
    <style type="text/css">

    .cssHeaderImg
	{
	background-image : url(../Imagenes/Frames/Menu5.png);
    }

        .auto-style1 {
            height: 46px;
        }

        </style>
    <script language="JavaScript" type="text/javascript">
        var pagina;
        function redireccionar() {
            location.href = "../LoginLDAP.aspx";
        }
        setTimeout("redireccionar()", 2000000);

</script>
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
                            <td colspan="3" align="center" class="auto-style1">
                                <asp:Label ID="lblCodUsuario" runat="server" Font-Size="Small" Visible="False"></asp:Label>
                                <asp:Label ID="lblCodOficina" runat="server" Font-Size="Small" Visible="False"></asp:Label>
                                <asp:Label ID="Label1" runat="server" CssClass="etiqueta20" 
                                    Text="Bienvenido!!!"></asp:Label>
                                <asp:Label ID="lblCuentaUsuario" runat="server" Font-Size="Small" Visible="False"></asp:Label>
                                <br />
                                <asp:Label ID="Label4" runat="server" CssClass="etiqueta20" Text="Seleccione Rol para Ingresar"></asp:Label>
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
                                    <asp:GridView ID="gvDatos" runat="server" 
                                        EnableModelValidation="True" 
                                        EnableTheming="True" 
                                        HorizontalAlign="Center" 

                                        Font-Names="Arial" 
Font-Size="9pt" 
CssClass="mGrid"
PagerStyle-CssClass="pgr"
AlternatingRowStyle-CssClass="alt"
GridLines="None"
DataKeyNames="IdRol,IdModulo,FechaVigencia,FechaExpiracion"  
                                        onselectedindexchanged="gvDatos_SelectedIndexChanged" 
                                        OnRowDataBound="gvDatos_RowDataBound"  
                                        OnRowCommand="gvDatos_RowCommand"
                                        SkinID="GridView" Width="80%"
                                        
                                        >
                                        
                                        <Columns>
                                            <%--<asp:CommandField  ButtonType="Image" HeaderText="Sel" ItemStyle-Width="20%" SelectImageUrl="~/Imagenes/sig.png" ShowSelectButton="True">
                                            <ItemStyle HorizontalAlign="Center" />
                                            </asp:CommandField>  --%>
                                             <asp:TemplateField HeaderText="Sel" >                                  
                                    <ItemTemplate>
                                        <center>                                                                                
                                        
                                        <asp:ImageButton ID="imgSel" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdSeleccionar" ImageUrl="~/imagenes/sig.png" ToolTip="Seleccionar Rol" alt="Seleccionar Rol" />
                                             </center>
                                    </ItemTemplate>
                                </asp:TemplateField>                                         
                                            <asp:BoundField DataField="DescripcionRol" HeaderText="Roles Asignados" ItemStyle-Width="60%">
                                            <ItemStyle Width="60%" />
                                            </asp:BoundField>                                          
                                            <asp:BoundField DataField="FechaVigencia" HeaderText="FechaVigencia" ItemStyle-Width="10%" Visible="false">
                                            <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="FechaExpiracion" HeaderText="FechaExpiracion" ItemStyle-Width="10%" Visible="false">
                                            <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
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
                        </table>
                </asp:Panel>
                            </td>
                            <td align="center" >
                                </td>
                        </tr>
                     
                    </table>       
    </form>
</body>
</html>
