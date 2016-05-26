<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmRegistraF04.aspx.cs" Inherits="Novedades_wfrmRegistraF04" StylesheetTheme="Modal" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <style type="text/css">
        .cssHeaderImg {
            background-image: url(../Imagenes/Menu4.png);
        }

        .auto-style4 {
            width: 280px;
        }
    </style>


</asp:Content>
<%--TODA LA TABLA--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
        <table id="tabla1" width="80%">
          <tr>
            <td align="center" colspan="3">
                 <asp:ImageButton ID="imgAux" runat="server" ImageUrl="~/Imagenes/w.png" />
                <asp:Label ID="lblTituloAUX" runat="server" Text="Formulario 04 - DerechoHabientes" CssClass="etiqueta20"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" colspan="3" width="80%">
                <asp:Label ID="lblNombre" runat="server" Text="Nombre" CssClass="etiqueta20"></asp:Label>
            </td>
        </tr>
        </table>
        <table id="TablaPersona" runat="server" width="80%" style="border:1px solid black">
            <tr>
                <td align="left" width="40%" style="border:1px solid black">
                    <asp:Label ID="Label11" runat="server" CssClass="etiqueta10" Style="text-align:left" Text="Código Entidad: "></asp:Label>
                        <asp:DropDownList ID="ddlEntidades_muestra" runat="server" AutoPostBack="True" Width="100px" Enabled="False" align="right">   </asp:DropDownList>
                </td>
                <td align="left" width="60%"  style="border:1px solid black">
                        <asp:DropDownList ID="ddlEntidades" runat="server" AutoPostBack="True" Width="200px" Enabled="True">   </asp:DropDownList>
                    <asp:CheckBox ID="CheckEntidad" runat="server" Visible="True" />
                </td>
            </tr>
            <tr>
                <td align="left" style="border:1px solid black">
                    <asp:Label ID="Label4" runat="server" CssClass="etiqueta10" Style="text-align:left" Text="Tipo Doc.: "></asp:Label>
                    <asp:DropDownList ID="ddlTipoDoc_muestra" runat="server" AutoPostBack="True" Width="230px" Enabled="False" align="right">   </asp:DropDownList>
                </td>
                <td align="left" style="border:1px solid black">
                    <asp:DropDownList ID="ddlTipoDoc" runat="server" AutoPostBack="True" Width="200px">   </asp:DropDownList>
                    <asp:CheckBox ID="CheckTipoDoc" runat="server" />
                </td>

            </tr>
            <tr>
                <td align="left" style="border:1px solid black">
                    <asp:Label ID="Label3" runat="server" CssClass="etiqueta10" Style="text-align:left" Text="Origen Doc.: "></asp:Label>
                    <asp:DropDownList ID="ddlOrigenDoc_muestra" runat="server" AutoPostBack="True" Width="200px" Enabled="False" align="right">   </asp:DropDownList>
                </td>
                <td align="left" style="border:1px solid black">
                    <asp:DropDownList ID="ddlOrigenDoc" runat="server" AutoPostBack="True" Width="200px">   </asp:DropDownList>
                    <asp:CheckBox ID="CheckOrigen" runat="server" />
                </td>

            </tr>
            <tr>
                <td align="left" style="border:1px solid black">
                    <asp:Label ID="Label6" runat="server" CssClass="etiqueta10" Style="text-align:left" Text="Número Doc.: "></asp:Label>
                    <asp:TextBox ID="TextNumDoc_muestra" runat="server" CssClass="texto10" MaxLength="50" Style="text-align:left" Width="100px" Enabled="False" ForeColor="Gray"></asp:TextBox>
                </td>
                <td align="left" style="border:1px solid black">
                    <asp:TextBox ID="TextNumDoc" runat="server" CssClass="texto10" MaxLength="50" Style="text-align:left" Width="100px"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextNumDoc" ErrorMessage="*Números" ForeColor="Red" ValidationExpression="^[0-9.]*"> </asp:RegularExpressionValidator>
                    <asp:CheckBox ID="CheckNumDoc" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="left" style="border:1px solid black">
                    <asp:Label ID="Label10" runat="server" CssClass="etiqueta10" Style="text-align:left" Text="Complemento: "></asp:Label>
                    <asp:TextBox ID="TextComplemento_muestra" runat="server" CssClass="texto10" MaxLength="2" Style="text-align:left" Width="50px" Enabled="False" ForeColor="Gray"></asp:TextBox>

                </td>
                <td align="left" style="border:1px solid black">
                    <asp:TextBox ID="TextComplemento" runat="server" CssClass="texto10" MaxLength="2" Style="text-align:left" Width="50px"></asp:TextBox>
                    <asp:CheckBox ID="CheckComplemento" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="left" style="border:1px solid black">
                    <asp:Label ID="Label5" runat="server" CssClass="etiqueta10" Style="text-align:left" Text="Paterno: "></asp:Label>
                    <asp:TextBox ID="TextPaterno_muestra" runat="server" CssClass="texto10" MaxLength="50" Style="text-align:left" Width="200px" Enabled="False" ForeColor="Gray"></asp:TextBox>
                </td>
                <td align="left" style="border:1px solid black">
                    <asp:TextBox ID="TextPaterno" runat="server" CssClass="texto10" MaxLength="50" Style="text-align:left" Width="200px"></asp:TextBox>
                    <asp:CheckBox ID="CheckBoxPaterno" runat="server" />
                </td>

            </tr>
            <tr>
                <td align="left" style="border:1px solid black">
                    <asp:Label ID="Label7" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="Materno: "></asp:Label>
                    <asp:TextBox ID="TextMaterno_muestra" runat="server" CssClass="texto10" MaxLength="50" Style="text-align:left" Width="200px" Enabled="False" ForeColor="Gray"></asp:TextBox>
                </td>
                <td align="left" style="border:1px solid black">
                    <asp:TextBox ID="TextMaterno" runat="server" CssClass="texto10" MaxLength="50" Style="text-align:left" Width="200px"></asp:TextBox>
                    <asp:CheckBox ID="CheckMaterno" runat="server" />
                </td>
                </tr>
            <tr>
                <td align="left" style="border:1px solid black">
                    <asp:Label ID="Label9" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="Primer Nombre: "></asp:Label>
                    <asp:TextBox ID="TextPrimer_muestra" runat="server" CssClass="texto10" MaxLength="15" Style="text-align:left" Width="200px" Enabled="False" ForeColor="Gray"></asp:TextBox>
                </td>
                <td align="left" style="border:1px solid black">
                    <asp:TextBox ID="TextPrimer" runat="server" CssClass="texto10" MaxLength="15" Style="text-align:left" Width="200px"></asp:TextBox>
                    <asp:CheckBox ID="CheckPrimer" runat="server" />
                </td>
                </tr>
            <tr>
                <td align="left" style="border:1px solid black">
                    <asp:Label ID="Label12" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="Segundo Nombre:"></asp:Label>
                    <asp:TextBox ID="TextSegundo_muestra" runat="server" CssClass="texto10" MaxLength="15" Style="text-align:left" Width="200px" Enabled="False" ForeColor="Gray"></asp:TextBox>
                </td>
                <td align="left" style="border:1px solid black">
                    <asp:TextBox ID="TextSegundo" runat="server" CssClass="texto10" MaxLength="15" Style="text-align:left" Width="200px"></asp:TextBox>
                    <asp:CheckBox ID="CheckSegundo" runat="server" />
                </td>
            </tr>
                <tr>
                <td align="left" style="border:1px solid black">
                    <asp:Label ID="Label8" runat="server" CssClass="etiqueta10" Style="text-align:left" Text="Genero: "></asp:Label>
                        <asp:DropDownList ID="ddlSexo_muestra" runat="server" AutoPostBack="True" Width="100px"  Enabled="False">   </asp:DropDownList>
                </td>
                <td align="left" style="border:1px solid black">
                        <asp:DropDownList ID="ddlSexo" runat="server" AutoPostBack="True" Width="120px">   </asp:DropDownList>
                    <asp:CheckBox ID="CheckSexo" runat="server" />
                </td>
            </tr>
            <tr>
                    <td align="left" style="border:1px solid black">
                    <asp:Label ID="Label1" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="Nacimiento: "></asp:Label>
                    <asp:TextBox ID="TextNacimiento_muestra" runat="server" CssClass="texto10" MaxLength="50" Style="text-align:left" Width="100px" Enabled="False" ForeColor="Gray"></asp:TextBox>
                </td>
                    <td align="left" style="border:1px solid black">
                    <asp:TextBox ID="TextNacimiento" runat="server" CssClass="texto10" MaxLength="50" Style="text-align:left" Width="100px" Enabled="True"></asp:TextBox>
                    <asp:ImageButton ID="imgcalendario" runat="server" CssClass="CajaDialogo" ImageUrl="~/Imagenes/32calendario.png"  />
                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TextNacimiento"  Format="dd/MM/yyyy" PopupButtonID="imgcalendario">  </cc1:CalendarExtender>	
                    <cc1:MaskedEditExtender  ID="MaskedEditExtender1" runat="server" TargetControlID="TextNacimiento"  Mask="99/99/9999" MessageValidatorTip="true" MaskType="Date"  CultureName="en-GB">  </cc1:MaskedEditExtender>	
                    <cc1:MaskedEditValidator id="MaskedEditValidator1" runat="server" ControlExtender="MaskedEditExtender1" InvalidValueMessage="Fecha Inválida" ControlToValidate="TextNacimiento" />
                    <asp:CheckBox ID="CheckBoxNacimiento" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="left" style="border:1px solid black">
                    <asp:Label ID="Label13" runat="server" CssClass="etiqueta10" Style="text-align:left" Text="Inicio de Pago: "></asp:Label>
                    <asp:TextBox ID="TextIniPago_muestra" runat="server" CssClass="texto10" MaxLength="50" Style="text-align:left" Width="200px" Enabled="False" ForeColor="Gray"></asp:TextBox>
                </td>
                <td align="left" style="border:1px solid black">
                    
                    <asp:TextBox ID="TextIniPago" runat="server" CssClass="texto10" MaxLength="50" Style="text-align:left" Width="200px"></asp:TextBox>
                    <asp:ImageButton ID="imgcalendario1" runat="server" CssClass="CajaDialogo" ImageUrl="~/Imagenes/32calendario.png"  />
                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="TextIniPago"  Format="dd/MM/yyyy" PopupButtonID="imgcalendario1">  </cc1:CalendarExtender>	
                    <cc1:MaskedEditExtender  ID="MaskedEditExtender2" runat="server" TargetControlID="TextIniPago"  Mask="99/99/9999" MessageValidatorTip="true" MaskType="Date"  CultureName="en-GB">  </cc1:MaskedEditExtender>	
                    <cc1:MaskedEditValidator id="MaskedEditValidator2" runat="server" ControlExtender="MaskedEditExtender1" InvalidValueMessage="Fecha Inválida" ControlToValidate="TextIniPago" />


                    <asp:CheckBox ID="CheckIniPago" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="left" style="border:1px solid black">
                    <asp:Label ID="Label14" runat="server" CssClass="etiqueta10" Style="text-align:left" Text="Estado DH: "></asp:Label>
                        <asp:DropDownList ID="ddlEstadoDH_muestra" runat="server" AutoPostBack="True" Width="100px" Enabled="False">   
                            <asp:ListItem Selected="True" Value="1">Activo</asp:ListItem>
                            <asp:ListItem Value="0">Inactivo</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td align="left" style="border:1px solid black">
                                    
                        <asp:DropDownList ID="ddlEstadoDH" runat="server" AutoPostBack="True" Width="100px">   
                            <asp:ListItem Selected="True" Value="1">Activo</asp:ListItem>
                            <asp:ListItem Value="0">Inactivo</asp:ListItem>
                    </asp:DropDownList>
                    <asp:CheckBox ID="CheckEstadoDH" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="left" style="border:1px solid black">
                    <asp:Label ID="Label15" runat="server" CssClass="etiqueta10" Style="text-align:left" Text="Tipo Registro: "></asp:Label>
                        <asp:DropDownList ID="ddlTipoReg_muestra" runat="server" AutoPostBack="True" Width="200px" Enabled="False">   
                            <asp:ListItem Value="1">Activo</asp:ListItem>
                            <asp:ListItem Value="0">Inactivo</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td align="left" style="border:1px solid black">
                        <asp:DropDownList ID="ddlTipoReg" runat="server" AutoPostBack="True" Width="200px">   
                            <asp:ListItem Value="1">Activo</asp:ListItem>
                            <asp:ListItem Value="0">Inactivo</asp:ListItem>
                    </asp:DropDownList>
                    <asp:CheckBox ID="CheckTipoReg" runat="server" />
                </td>
            </tr>
                <tr>
                <td align="left">
                    <asp:Button ID="Procesar" runat="server" Text="Modificar" OnClick="InsertaF04"  OnClientClick="javascript : return confirm('Esta seguro de realizar esta accion?');"/>
                    
                    <asp:Label ID="NUPAsegurado" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="NUP:" Visible="False"></asp:Label>
                </td>
                <td align="left">
                    <asp:Button ID="Button1" runat="server" Text="Volver" OnClick="VolverBuscaDH" />
                </td>
            </tr>

        </table>
</asp:Content>

