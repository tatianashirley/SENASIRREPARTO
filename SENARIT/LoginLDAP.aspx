<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginLDAP.aspx.cs" Inherits="LoginLDAP" StylesheetTheme="Modal" %>

<%@ Register namespace="AjaxControlToolkit" tagprefix="AjaxControlToolkit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
<head runat="server">
    <link rel="stylesheet" href="/App_Themes/format.css" />
    <script type="text/javascript">

        function selecciona_value(objInput) {

            var valor_input = objInput.value;
            var longitud = valor_input.length;

            if (objInput.setSelectionRange) {
                objInput.focus();
                objInput.setSelectionRange(0, longitud);
            }
            else if (objInput.createTextRange) {
                var range = objInput.createTextRange();
                range.collapse(true);
                range.moveEnd('character', longitud);
                range.moveStart('character', 0);
                range.select();
            }
        }

    </script>   
    <title></title>
    <style type="text/css">
        .style1 {
            height: 29px;
        }

        .style2 {
            height: 24px;
        }

        .auto-style1 {
            height: 36px;
        }
    </style>
    <script type="text/javascript">
        function SelectAll(id) {
            id.focus(); id.select()
        }
        function focusNext(elemActual, elemSiguiente, evt) {
            if (evt != null) {
                evt = (evt) ? evt : event;
                var charCode = (evt.charCode) ? evt.charCode : ((evt.which) ? evt.which : evt.keyCode);
                if (charCode == 13 || charCode == 3) {

                    if (document.getElementById(elemSiguiente).type == 'submit') {
                        // averigua si es un button

                        document.getElementById(elemSiguiente).click();

                        evt.keyCode = 0;
                        return false;
                    }
                    else {
                        document.getElementById(elemSiguiente).focus();
                        evt.keyCode = 0;
                        return false;
                    }
                }
            }
        }
    </script>
</head>
<body>
<form id="form1" runat="server">
    <table style="width: 100%;">
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td align="center">
                <asp:panel id="pnlLogin" runat="server" width="600px" cssclass="panelprincipal2">
                    <table style="width:100%;">
                        <tr>
                            <td colspan="4" align="center">
                                <asp:Label ID="lblCon" runat="server" Font-Size="Small" Text="0" 
                                    Visible="False"></asp:Label>
                                <asp:Label ID="Label1" runat="server" CssClass="etiqueta20" 
                                    Text="Inicio de Sesion"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" rowspan="3" width="10%">
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/32usuario.png" />
                            </td>
                            <td align="right" width="40%" class="auto-style1">
                                <asp:Label ID="Label2" runat="server" CssClass="etiqueta8Blue" Text="Login :"></asp:Label>
                            </td>
                            <td align="left" width="40%" class="auto-style1">
                                <asp:TextBox ID="txtLogin" runat="server" CssClass="texto10" autofocus="autofocus" onkeyup="this.value=this.value.toUpperCase()" MaxLength="30"></asp:TextBox>
                            </td>
                            <td align="center" rowspan="3" width="10%">
                                <asp:Image ID="img1" runat="server" ImageUrl="~/Imagenes/32llaves.png" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right" >
                                <asp:Label ID="lblPass" runat="server" CssClass="etiqueta8Blue" Text="Password :"></asp:Label>
                            </td>
                            <td align="left" >
                                <asp:TextBox ID="txtPassword" runat="server" CssClass="texto10" 
                                    TextMode="Password" MaxLength="30"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblPass0" runat="server" CssClass="etiqueta8Blue" Text="Dominio :"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtDomi" runat="server" CssClass="texto10" MaxLength="30" >SENASIR</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4">
                                <asp:Button ID="btnAceptar" runat="server" CssClass="boton100" 
                                    onclick="btnAceptar_Click" Text="Aceptar" />
                                <asp:Button ID="btnCancelar" runat="server" CssClass="boton100" 
                                    onclick="btnCancelar_Click" Text="Cancelar" />
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                &nbsp;</td>
                            <td align="center" colspan="2">
                                <asp:Label ID="lblObservaciones" runat="server" CssClass="text_obs"></asp:Label>
                                <br />
                                <asp:Label ID="lblObservaciones2" runat="server" CssClass="text_obs" Visible="false"></asp:Label>
                            </td>
                            <td align="center">
                                &nbsp;</td>
                        </tr>
                    </table>
                </asp:panel>
            </td>
        </tr>
        <tr>
            <td>
                <div id="ctr" align="center">
                    <div class="login">
                    </div>
                </div>
            </td>
        </tr>
    </table>
</form>
</body>
</html>
