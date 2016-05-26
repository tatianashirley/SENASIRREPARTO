<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmRegistraF02.aspx.cs" Inherits="Novedades_wfrmRegistraF02" StylesheetTheme="Modal" %>
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
     <asp:ImageButton ID="ImageButton2" runat="server" CssClass="CajaDialogo" ImageUrl="~/Imagenes/32calendario.png" visible="false" />
                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="TextFechaRa"  Format="dd/MM/yyyy" PopupButtonID="imgcalendario">  </cc1:CalendarExtender>

<asp:TextBox ID="TextBox1" runat="server" CssClass="texto10" MaxLength="8" Style="text-align:left" Width="70px" Visible="false"></asp:TextBox>
<asp:ImageButton ID="ImageButton1" runat="server" CssClass="CajaDialogo" ImageUrl="~/Imagenes/32calendario.png" Visible="false"  />

    <table style="width: 100%;" class="panelceleste">
        <tr>
            <td align="center" colspan="3">
                 <asp:ImageButton ID="imgAux" runat="server" ImageUrl="~/Imagenes/w.png" />
                <asp:Label ID="lblTituloAUX" runat="server" Text="Formulario 02 - Diferencias" CssClass="etiqueta20"></asp:Label>
            </td>
        </tr>
        <%-- grilla --%>
        <tr>
            <td colspan="3">
                <table style="width: 75%;">
                    <tr>
                        <td align="right" style="width: 50%">
                            <asp:Label ID="Label2" runat="server" CssClass="etiqueta10"
                                Style="text-align: left" Text="Nro Certificado:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                ControlToValidate="txtNroCerti" ErrorMessage="*Ingrese Valores Numericos"
                                ForeColor="Red"
                                ValidationExpression="^[0-9]*">
                            </asp:RegularExpressionValidator>
                            <asp:TextBox ID="txtNroCerti" runat="server" CssClass="texto10"
                                        MaxLength="50" Width="200px" ></asp:TextBox>
                            </td>
                        <td align="right" style="width: 50%">
                            <asp:Label ID="Label1" runat="server" CssClass="etiqueta10"
                                Style="text-align: left" Text="Clase CC :"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlTipoCC" runat="server"
                                AutoPostBack="True" Width="200px">
                                <asp:ListItem Selected="True" Value="A">Automático</asp:ListItem>
                                <asp:ListItem Value="M">Manual</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td align="left">
                            &nbsp;</td>
                        <td align="right"><asp:ImageButton runat="server" ID="imgbtnBuscar" ImageUrl="~/Imagenes/32Buscar.png" OnClick="imgbtnBuscar_Click" /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <%-- grid inicial (solo muestra datos)--%>
        <tr>
            <td colspan="3">
                <asp:Panel ID="pnlGrillaDatos" runat="server" HorizontalAlign="Center" Width="100%"
                    CssClass="panelceleste">
                    <table style="width: 75%;">
                        <tr>
                            <td align="left" colspan="3">
                                <asp:Label ID="Label3" runat="server" Text="Datos Certificado"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%-- grilla --%>
                                <asp:GridView ID="gvCertificado" runat="server" EnableTheming="True" AllowPaging="True" PageSize="15" 
                                    HorizontalAlign="Left"  Width="75%" AutoGenerateColumns="False"                                      
                                    Font-Names="Arial" 
                                     Font-Size="9pt" 
                                     CssClass="mGrid"
                                    PagerStyle-CssClass="pgr"
                                    AlternatingRowStyle-CssClass="alt"
                                    GridLines="None">
                                    <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                                    <Columns>
                                        <asp:BoundField DataField="Matricula" HeaderText="Matricula" > 
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Width="10%" HorizontalAlign="Left"/>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Matricula_cys" HeaderText="Matricula CyS" Visible="False" > 
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Width="10%" HorizontalAlign="Left"/>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Tramite" HeaderText="Tramite" > 
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Width="10%" HorizontalAlign="Left"/>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Estado" HeaderText="Estado" > 
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Width="10%" HorizontalAlign="Left"/>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Certificado" HeaderText="Nro. Certi."> 
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Width="10%" HorizontalAlign="Left"/>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ClaseCC" HeaderText="Clase CC" > 
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Width="10%" HorizontalAlign="Left"/>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="FechaEmision" HeaderText="Fecha Emisión"> 
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Width="10%" HorizontalAlign="Left"/>
                                        </asp:BoundField>

                                    </Columns>
                                    <EmptyDataTemplate><div align="center" class="CajaDialogoAdvertencia">
                                          <br/>
                                                                    <img src="../Imagenes/warning.gif" 
                                                  alt="No existen datos que correspondan al criterio especificado" />
                                          <br/>No existen datos que correspondan al criterio especificado
                                                                    <br/><br/>
                                                                                   </div>
                                        </EmptyDataTemplate>
                                </asp:GridView>
                            </td>

                        </tr>

                    </table>
                </asp:Panel>
            </td>
        </tr>
        <%-- grid inicial (solo muestra datos)--%>
        <tr>
            <td colspan="3">
                <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Center" Width="100%"
                    CssClass="panelceleste">
                    <table style="width:75%;">
                        <tr>
                            <td align="left" colspan="3">
                                <asp:Label ID="LabelTitular" runat="server" Text="Datos Titular"></asp:Label>
                            </td>
                        </tr>
                   </table>
<table id="TablaPersona" runat="server" style="width:80%">
                <tr>
                    <td align="left" width="60%"  style="border:1px solid black">
                        <asp:Label ID="Label11" runat="server" CssClass="etiqueta10" Style="text-align:left" Text="Código Entidad: "></asp:Label>
                        <asp:DropDownList ID="ddlEntidades" runat="server" AutoPostBack="True" Width="200px" Enabled="False" Visible="False">   </asp:DropDownList>
                        <asp:TextBox ID="Text_AFP" runat="server" CssClass="texto10" Enabled="False" ForeColor="Gray" MaxLength="50" Style="text-align:left" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                            <tr>
                                <td align="left" style="border:1px solid black">
                                    <asp:Label ID="Label15" runat="server" CssClass="etiqueta10" Style="text-align:left" Text="Paterno: "></asp:Label>
                                    <asp:TextBox ID="TextTipoCC" runat="server" CssClass="texto10" MaxLength="50" Style="text-align:left" Width="10px" Visible="false"></asp:TextBox>
                                    <asp:TextBox ID="TextPaterno_muestra" runat="server" CssClass="texto10" MaxLength="50" Style="text-align:left" Width="200px" Enabled="False" ForeColor="Gray"></asp:TextBox>

                                </td>
                                <td align="left" style="border:1px solid black">
                                    <asp:TextBox ID="TextPaterno" runat="server" CssClass="texto10" MaxLength="50" Style="text-align:left" Width="200px"></asp:TextBox>
                                    <asp:CheckBox ID="CheckBoxPaterno" runat="server" />
                                </td>
                             </tr>
                             <tr>
                                <td align="left" style="border:1px solid black">
                                    <asp:Label ID="Label5" runat="server" CssClass="etiqueta10" Style="text-align:left" Text="Materno: "></asp:Label>
                                    <asp:TextBox ID="TextMaterno_muestra" runat="server" CssClass="texto10" MaxLength="50" Style="text-align:left" Width="200px" Enabled="False" ForeColor="Gray"></asp:TextBox>
                                </td>
                                <td align="left" style="border:1px solid black">
                                    <asp:TextBox ID="TextMaterno" runat="server" CssClass="texto10" MaxLength="50" Style="text-align:left" Width="200px"></asp:TextBox>
                                    <asp:CheckBox ID="CheckMaterno" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="border:1px solid black">
                                    <asp:Label ID="Label16" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="Primer Nombre: "></asp:Label>
                                    <asp:TextBox ID="TextPrimerNombre_muestra" runat="server" CssClass="texto10" MaxLength="50" Style="text-align:left" Width="200px" Enabled="False" ForeColor="Gray"></asp:TextBox>
                                </td>
                                <td align="left" style="border:1px solid black">
                                    <asp:TextBox ID="TextPrimerNombre" runat="server" CssClass="texto10" MaxLength="50" Style="text-align:left" Width="200px"></asp:TextBox>
                                    <asp:CheckBox ID="CheckPrimer" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="border:1px solid black">
                                    <asp:Label ID="Label7" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="Segundo Nombre: "></asp:Label>
                                    <asp:TextBox ID="TextSegundoNombre_muestra" runat="server" CssClass="texto10" MaxLength="50" Style="text-align:left" Width="200px" Enabled="False" ForeColor="Gray"></asp:TextBox>
                                </td>
                                <td align="left" style="border:1px solid black">
                                    <asp:TextBox ID="TextSegundoNombre" runat="server" CssClass="texto10" MaxLength="50" Style="text-align:left" Width="200px"></asp:TextBox>
                                    <asp:CheckBox ID="CheckSegundo" runat="server" />
                                </td>
                             </tr>
                            <tr>
                                <td align="left" style="border:1px solid black">
                                    <asp:Label ID="Label8" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="CUA: "></asp:Label>
                                    <asp:TextBox ID="TextCUA_muestra" runat="server" CssClass="texto10" MaxLength="15" Style="text-align:left" Width="200px" Enabled="False" ForeColor="Gray"></asp:TextBox>
                                </td>
                                <td align="left" style="border:1px solid black">
                                    <asp:TextBox ID="TextCUA" runat="server" CssClass="texto10" MaxLength="15" Style="text-align:left" Width="200px"></asp:TextBox>
                                    <asp:regularExpressionValidator ID="RegularExpressionValidator3" validationExpression="[0-9]*" controlToValidate="TextCUA" errorMessage="Introducir solo números" runat="server"/>
                                    <asp:CheckBox ID="CheckCUA" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="border:1px solid black">
                                    <asp:Label ID="Label17" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="Documento: "></asp:Label>
                                    <asp:TextBox ID="TextCI_muestra" runat="server" CssClass="texto10" MaxLength="10" Style="text-align:left" Width="200px" Enabled="False" ForeColor="Gray"></asp:TextBox>
                                </td>
                                <td align="left" style="border:1px solid black">
                                    <asp:TextBox ID="TextCI" runat="server" CssClass="texto10" MaxLength="10" Style="text-align:left" Width="200px"></asp:TextBox>
                                    <asp:regularExpressionValidator ID="RegularExpressionValidator2" validationExpression="[0-9]*" controlToValidate="TextCI" errorMessage="Introducir solo números" runat="server"/>
                                    <asp:CheckBox ID="CheckCI" runat="server" />
                                </td>
                             </tr>
                            <tr>
                                <td align="left" style="border:1px solid black">
                                    <asp:Label ID="Label9" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="Tipo Doc.: "></asp:Label>
                                    <asp:DropDownList ID="ddlTipoDocumento_muestra" runat="server" AutoPostBack="True" Width="200px" Enabled="False" >   </asp:DropDownList>
                                </td>
                                <td align="left" style="border:1px solid black">
                                    <asp:DropDownList ID="ddlTipoDocumento" runat="server" AutoPostBack="True" Width="200px">   </asp:DropDownList>
                                    <asp:CheckBox ID="CheckTipo" runat="server" />
                                </td>

                            </tr>
                            <tr>
                                <td align="left" style="border:1px solid black">
                                    <asp:Label ID="Label10" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="Ext. Documento: "></asp:Label>
                                    <asp:DropDownList ID="ddlExtDocumento_muestra" runat="server" AutoPostBack="True" Width="150px" Enabled="False">   </asp:DropDownList>
                                </td>
                                <td align="left" style="border:1px solid black">
                                    <asp:DropDownList ID="ddlExtDocumento" runat="server" AutoPostBack="True" Width="150px">   </asp:DropDownList>
                                    <asp:CheckBox ID="CheckExt" runat="server" />
                                </td>
                             </tr>
                            <tr>
                                <td align="left" style="border:1px solid black">
                                    <asp:Label ID="Label4" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="Complemento:"></asp:Label>
                                    <asp:TextBox ID="TextAlfa_muestra" runat="server" CssClass="texto10" MaxLength="2" Style="text-align:left" Width="50px" Enabled="False" ForeColor="Gray"></asp:TextBox>
                                </td>
                                <td align="left" style="border:1px solid black">
                                    <asp:TextBox ID="TextAlfa" runat="server" CssClass="texto10" MaxLength="2" Style="text-align:left" Width="50px"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="TextAlfa" ErrorMessage="*No caracteres especiales" ForeColor="Red" ValidationExpression="^[0-9A-Za-z]*"> </asp:RegularExpressionValidator>
                                    <asp:CheckBox ID="CheckAlfa" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" >
                                    <asp:Label ID="Label13" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="Numero RA:"></asp:Label>
                                    <asp:TextBox ID="TextNumRa" runat="server" CssClass="texto10" MaxLength="7" Style="text-align:left" Width="50px"></asp:TextBox>
                                    <cc1:MaskedEditExtender  ID="MaskExtender2" runat="server" TargetControlID="TextNumRa" Mask="9999,99" MessageValidatorTip="true" MaskType="Number">  </cc1:MaskedEditExtender>	
                                </td>
                                <td align="left" style="width: 50%">
                                    <asp:Label ID="Label14" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="Fecha RA:"></asp:Label>
                                    <asp:TextBox ID="TextFechaRa" runat="server"></asp:TextBox>
                                    <asp:ImageButton ID="imgcalendario" runat="server" CssClass="CajaDialogo" ImageUrl="~/Imagenes/32calendario.png"  />
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TextFechaRa"  Format="dd/MM/yyyy" PopupButtonID="imgcalendario">  </cc1:CalendarExtender>	
                                    
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 50%">
                                    <asp:Button ID="Procesar" runat="server" Text="Modificar APS" OnClick="InsertaF02" OnClientClick="javascript : return confirm('Esta seguro de realizar esta accion?');"/>
                                    <asp:Label ID="NUP" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="NUP:" Visible="False"></asp:Label>
                                </td>
                             </tr>
                        </table>
                </asp:Panel>
            </td>
        </tr>
    
    
</asp:Content>

