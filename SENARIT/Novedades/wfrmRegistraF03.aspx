<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmRegistraF03.aspx.cs" Inherits="Novedades_wfrmRegistraF02" StylesheetTheme="Modal" %>
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
                <asp:Label ID="lblNombre1" runat="server" Text="Formulario 03 - Titulares" CssClass="etiqueta20"></asp:Label>
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
                <td align="left">
                    <asp:Button ID="Procesar" runat="server" Text="Modificar" OnClick="InsertaF03" OnClientClick="javascript : return confirm('Esta seguro de realizar esta accion?');"/>
                    
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
                <td align="left">
                    <asp:Button ID="Button1" runat="server" Text="Volver" OnClick="VolverBuscaDH" />
                    <asp:Label ID="IdTitular" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="idtitular" Visible="False"></asp:Label>
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
                    <asp:Label ID="Label1" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="Fecha Solicitud: "></asp:Label>
                    <asp:TextBox ID="TextSolicitud_muestra" runat="server" CssClass="texto10" MaxLength="50" Style="text-align:left" Width="100px" Enabled="False" ForeColor="Gray"></asp:TextBox>
                </td>
                    <td align="left" style="border:1px solid black">
                    <asp:TextBox ID="TextSolicitud" runat="server" CssClass="texto10" MaxLength="50" Style="text-align:left" Width="100px" Enabled="True"></asp:TextBox>
                    <asp:ImageButton ID="imgcalendario" runat="server" CssClass="CajaDialogo" ImageUrl="~/Imagenes/32calendario.png"  />
                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TextSolicitud"  Format="dd/MM/yyyy" PopupButtonID="imgcalendario">  </cc1:CalendarExtender>	
                    <cc1:MaskedEditExtender  ID="MaskedEditExtender1" runat="server" TargetControlID="TextSolicitud"  Mask="99/99/9999" MessageValidatorTip="true" MaskType="Date"  CultureName="en-GB">  </cc1:MaskedEditExtender>	
                    <cc1:MaskedEditValidator id="MaskedEditValidator1" runat="server" ControlExtender="MaskedEditExtender1" InvalidValueMessage="Fecha Inválida" ControlToValidate="TextSolicitud" />
                    <asp:CheckBox ID="CheckBoxSolicitud" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="left" style="border:1px solid black">
                    <asp:Label ID="Label5" runat="server" CssClass="etiqueta10" Style="text-align:left" Text="Tipo Cambio 1: "></asp:Label>
                    <asp:TextBox ID="TipoCambio1_muestra" runat="server" CssClass="texto10" MaxLength="50" Style="text-align:left" Width="100px" Enabled="False" ForeColor="Gray"></asp:TextBox>
                </td>
                <td align="left" style="border:1px solid black">
                    <asp:TextBox ID="TipoCambio1" runat="server" CssClass="texto10" MaxLength="50" Style="text-align:left" Width="100px"></asp:TextBox>
                    <cc1:FilteredTextBoxExtender ID="TipoCambio1_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers, Custom" TargetControlID="TipoCambio1" ValidChars="."></cc1:FilteredTextBoxExtender>
                    <asp:CheckBox ID="CheckBoxTipo1" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="left" style="border:1px solid black">
                    <asp:Label ID="Label2" runat="server" CssClass="etiqueta10" Style="text-align:left" Text="Tipo Cambio 2: "></asp:Label>
                    <asp:TextBox ID="TipoCambio2_muestra" runat="server" CssClass="texto10" MaxLength="50" Style="text-align:left" Width="100px" Enabled="False" ForeColor="Gray"></asp:TextBox>
                </td>
                <td align="left" style="border:1px solid black">
                    <asp:TextBox ID="TipoCambio2" runat="server" CssClass="texto10" MaxLength="50" Style="text-align:left" Width="100px"></asp:TextBox>
                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" Enabled="True" FilterType="Numbers, Custom" TargetControlID="TipoCambio2" ValidChars="."></cc1:FilteredTextBoxExtender>
                    <asp:CheckBox ID="CheckBoxTipo2" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="left" style="border:1px solid black">
                    <asp:Label ID="Label7" runat="server" CssClass="etiqueta10" Style="text-align:left" Text="Tipo Ajuste: "></asp:Label>
                        <asp:DropDownList ID="ddlTipoAjuste_muestra" runat="server" AutoPostBack="True" Width="100px"  Enabled="False">   </asp:DropDownList>
                </td>
                <td align="left" style="border:1px solid black">
                        <asp:DropDownList ID="ddlTipoAjuste" runat="server" AutoPostBack="True" Width="120px">   </asp:DropDownList>
                    <asp:CheckBox ID="CheckBoxTipoAjuste" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="left" style="border:1px solid black">
                    <asp:Label ID="Label9" runat="server" CssClass="etiqueta10" Style="text-align:left" Text="% Ajuste: "></asp:Label>
                    <asp:TextBox ID="PorcentajeAjuste_muestra" runat="server" CssClass="texto10" MaxLength="50" Style="text-align:left" Width="100px" Enabled="False" ForeColor="Gray"></asp:TextBox>
                </td>
                <td align="left" style="border:1px solid black">
                    <asp:TextBox ID="PorcentajeAjuste" runat="server" CssClass="texto10" MaxLength="50" Style="text-align:left" Width="100px"></asp:TextBox>
                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" Enabled="True" FilterType="Numbers, Custom" TargetControlID="TipoCambio2" ValidChars="."></cc1:FilteredTextBoxExtender>
                    <asp:CheckBox ID="CheckBoxPorcentajeAjuste" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="left" style="border:1px solid black">
                    <asp:Label ID="Label12" runat="server" CssClass="etiqueta10" Style="text-align:left" Text="Salario Base: "></asp:Label>
                    <asp:TextBox ID="SalarioBase_muestra" runat="server" CssClass="texto10" MaxLength="50" Style="text-align:left" Width="100px" Enabled="False" ForeColor="Gray"></asp:TextBox>
                </td>
                <td align="left" style="border:1px solid black">
                    <asp:TextBox ID="SalarioBase" runat="server" CssClass="texto10" MaxLength="50" Style="text-align:left" Width="100px"></asp:TextBox>
                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" Enabled="True" FilterType="Numbers, Custom" TargetControlID="TipoCambio2" ValidChars="."></cc1:FilteredTextBoxExtender>
                    <asp:CheckBox ID="CheckBoxSalarioBase" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="left" style="border:1px solid black">
                    <asp:Label ID="Label13" runat="server" CssClass="etiqueta10" Style="text-align:left" Text="Años Insalubres: "></asp:Label>
                    <asp:TextBox ID="AniosInsalubres_muestra" runat="server" CssClass="texto10" MaxLength="50" Style="text-align:left" Width="100px" Enabled="False" ForeColor="Gray"></asp:TextBox>
                </td>
                <td align="left" style="border:1px solid black">
                    <asp:TextBox ID="AniosInsalubres" runat="server" CssClass="texto10" MaxLength="50" Style="text-align:left" Width="100px"></asp:TextBox>
                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" Enabled="True" FilterType="Numbers, Custom" TargetControlID="TipoCambio2" ValidChars="."></cc1:FilteredTextBoxExtender>
                    <asp:CheckBox ID="CheckBoxAniosInsalubres" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="left" style="border:1px solid black">
                    <asp:Label ID="Label14" runat="server" CssClass="etiqueta10" Style="text-align:left" Text="Monto Ajustado: "></asp:Label>
                    <asp:TextBox ID="MontoAjustado_muestra" runat="server" CssClass="texto10" MaxLength="50" Style="text-align:left" Width="200px" Enabled="False" ForeColor="Gray"></asp:TextBox>
                </td>
                <td align="left" style="border:1px solid black">
                    <asp:TextBox ID="MontoAjustado" runat="server" CssClass="texto10" MaxLength="50" Style="text-align:left" Width="200px"></asp:TextBox>
                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" Enabled="True" FilterType="Numbers, Custom" TargetControlID="TipoCambio2" ValidChars="."></cc1:FilteredTextBoxExtender>
                    <asp:CheckBox ID="CheckBoxMontoAjustado" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="left" style="border:1px solid black">
                    <asp:Label ID="Label17" runat="server" CssClass="etiqueta10" Style="text-align:left" Text="Estado Titular: "></asp:Label>
                        <asp:DropDownList ID="ddlRegistroActivo_muestra" runat="server" AutoPostBack="True" Width="100px" Enabled="False">   
                            <asp:ListItem Selected="True" Value="1">Activo</asp:ListItem>
                            <asp:ListItem Value="0">Inactivo</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td align="left" style="border:1px solid black">
                        <asp:DropDownList ID="ddlRegistroActivo" runat="server" AutoPostBack="True" Width="100px">   
                            <asp:ListItem Selected="True" Value="1">Activo</asp:ListItem>
                            <asp:ListItem Value="0">Inactivo</asp:ListItem>
                    </asp:DropDownList>
                    <asp:CheckBox ID="CheckBoxRegistroActivo" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="left" style="border:1px solid black">
                    <asp:Label ID="Label15" runat="server" CssClass="etiqueta10" Style="text-align:left" Text="Numero Solicitud: "></asp:Label>
                    <asp:TextBox ID="NumeroSolicitud_muestra" runat="server" CssClass="texto10" MaxLength="50" Style="text-align:left" Width="100px" Enabled="False" ForeColor="Gray"></asp:TextBox>
                </td>
                <td align="left" style="border:1px solid black">
                    <asp:TextBox ID="NumeroSolicitud" runat="server" CssClass="texto10" MaxLength="50" Style="text-align:left" Width="100px"></asp:TextBox>
                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" Enabled="True" FilterType="Numbers, Custom" TargetControlID="TipoCambio2" ValidChars="."></cc1:FilteredTextBoxExtender>
                    <asp:CheckBox ID="CheckBoxNumeroSolicitud" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="left" style="border:1px solid black">
                    <asp:Label ID="Label16" runat="server" CssClass="etiqueta10" Style="text-align:left" Text="Periodo Solicitud: "></asp:Label>
                    <asp:TextBox ID="PeriodoSolicitud_muestra" runat="server" CssClass="texto10" MaxLength="50" Style="text-align:left" Width="100px" Enabled="False" ForeColor="Gray"></asp:TextBox>
                </td>
                <td align="left" style="border:1px solid black">
                    <asp:TextBox ID="PeriodoSolicitud" runat="server" CssClass="texto10" MaxLength="50" Style="text-align:left" Width="100px"></asp:TextBox>
                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" Enabled="True" FilterType="Numbers, Custom" TargetControlID="TipoCambio2" ValidChars="."></cc1:FilteredTextBoxExtender>
                    <asp:CheckBox ID="CheckBoxPeriodoSolicitud" runat="server" />
                </td>

            </tr>
        </table>
</asp:Content>

