<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmTipoRegistro.aspx.cs"
    Inherits="Medios_wfrmTipoRegistro" StylesheetTheme="Modal" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" language="javascript">
        function ModalPopup() {
            var vpRND = Math.random() * 20;
            showModalDialog('\ModalRol.aspx?rn=' + vpRND, '', 'dialogWidth=640px; dialogHeight=320px; center=yes; scrollbars=no');
        }
        function permite(elEvento, permitidos) {
            // Variables que definen los caracteres permitidos
            var numeros = "0123456789";
            var caracteres = " abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ";
            var numeros_caracteres = numeros + caracteres;
            var teclas_especiales = [8, 9];//en convenios agreagr el 75<-- y 77 -->
            // 8 = BackSpace, 46 = Supr, 37 = flecha izquierda, 39 = flecha derecha


            // Seleccionar los caracteres a partir del parámetro de la función
            switch (permitidos) {
                case 'num':
                    permitidos = numeros;
                    break;
                case 'car':
                    permitidos = caracteres;
                    break;
                case 'num_car':
                    permitidos = numeros_caracteres;
                    break;
            }

            // Obtener la tecla pulsada 
            var evento = elEvento || window.event;
            var codigoCaracter = evento.charCode || evento.keyCode;
            var caracter = String.fromCharCode(codigoCaracter);

            // Comprobar si la tecla pulsada es alguna de las teclas especiales
            // (teclas de borrado y flechas horizontales)
            var tecla_especial = false;
            for (var i in teclas_especiales) {
                if (codigoCaracter == teclas_especiales[i]) {
                    tecla_especial = true;
                    break;
                }
            }

            // Comprobar si la tecla pulsada se encuentra en los caracteres permitidos
            // o si es una tecla especial
            return permitidos.indexOf(caracter) != -1 || tecla_especial;
        }

    </script>

    <style type="text/css">
        .auto-style5
        {
            height: 23px;
        }
        .auto-style6
        {
            color: #CC0000;
        }
        .auto-style7
        {
            color: #FF0000;
        }
        </style>

    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%;" class="panelceleste">
        <tr>
            <td align="center">
                <asp:ImageButton ID="imgAux" runat="server" ImageUrl="~/Imagenes/16w.png" />
                <asp:Label ID="lblTituloAUX" runat="server"
                    Text="Estructuras de Intercambio" CssClass="etiqueta20"></asp:Label>
                <asp:Label ID="lblCodigo" runat="server" Font-Size="Small" Text="1"
                    Visible="False"></asp:Label>
                <asp:Label ID="lblCodUsuario" runat="server" Font-Size="Small" Text="1"
                    Visible="False"></asp:Label>
                <asp:Label ID="lblRol" runat="server" Font-Size="Small"
                    Style="text-align: left" Text="0" Visible="False"></asp:Label>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Panel ID="pnlGV" runat="server" HorizontalAlign="Center" Width="100%"
                    CssClass="panelceleste">
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 100%" align="center">
                                <asp:DropDownList ID="ddlMedios" runat="server" Width="250px" AutoPostBack="True">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 100%">
                                <asp:ImageButton ID="imgNuevo" runat="server" ImageUrl="~/Imagenes/nuevo.gif" OnClick="imgNuevo_Click" TabIndex="10" ToolTip="Nuevo Campo Intercambio" />
                                <asp:ImageButton ID="imgAtras" runat="server" ImageUrl="~/Imagenes/pequeños/Undo_32x32.png" OnClick="imgAtras_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style5" align="center">
                                <asp:GridView ID="gvRegistros" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                                    AutoGenerateColumns="False" DataSourceID="odsRegistro" SkinID="GridView" DataKeyNames="IdRegistro" Font-Size="10pt" OnRowCommand="gvRegistros_RowCommand" OnDataBound="gvRegistros_DataBound" AllowSorting="True">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775"/>
                                    <Columns>
                                        <asp:BoundField DataField="IdRegistro" HeaderText="IdRegistro" SortExpression="IdRegistro" Visible="False" />
                                        <asp:BoundField DataField="IdArchivo" HeaderText="IdMedio" SortExpression="IdArchivo" Visible="False" />
                                        <asp:BoundField DataField="NombreCampo" HeaderText="Campo Medio" SortExpression="NombreCampo" />
                                        <asp:BoundField DataField="TipoDato" HeaderText="Tipo Dato" SortExpression="TipoDato" />
                                        <asp:BoundField DataField="Tamaño" HeaderText="Longitud" SortExpression="Tamaño" />
                                        <asp:BoundField DataField="Tabla" HeaderText="Tabla" SortExpression="Tabla" />
                                        <asp:BoundField DataField="Campo" HeaderText="Campo" SortExpression="Campo" />
                                        <asp:BoundField DataField="Observacion" HeaderText="Observacion" SortExpression="Observacion" />
                                        <asp:BoundField DataField="ExpresionRegular" HeaderText="Expresión Regular" SortExpression="ExpresionRegular" />
                                        <asp:BoundField DataField="RegistroActivo" HeaderText="Estado" SortExpression="RegistroActivo" />
                                        <asp:ButtonField ButtonType="Image" CommandName="cmdEditar" ImageUrl="~/Imagenes/iconos16x16/Edit_16x16.png" Text="Editar" HeaderText="Editar"></asp:ButtonField>
                                        <asp:ButtonField ButtonType="Image" CommandName="cmdDesactivar" ImageUrl="~/Imagenes/iconos16x16/Delete_16x16.png" Text="Desactivar" HeaderText="Activación"></asp:ButtonField>
                                    </Columns>
                                    <EditRowStyle BackColor="#999999" />
                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                </asp:GridView>
                                <asp:ObjectDataSource ID="odsRegistro" runat="server" DeleteMethod="ModificaCampoMedio" InsertMethod="RegistraCampoMedio" SelectMethod="ListarCampoMedio" TypeName="wcfServicioIntercambioPago.Logica.clsIntercambio" UpdateMethod="ModificaCampoMedio" OldValuesParameterFormatString="original_{0}">
                                    <DeleteParameters>
                                        <asp:Parameter Name="iIdConexion" Type="Int32" />
                                        <asp:Parameter Name="cOperacion" Type="String" />
                                        <asp:Parameter Name="Tipo" Type="String" />
                                        <asp:Parameter Name="IdRegistro" Type="Int32" />
                                        <asp:Parameter Name="TipoMedio" Type="String" />
                                        <asp:Parameter Name="NombreCampo" Type="String" />
                                        <asp:Parameter Name="TipoDato" Type="String" />
                                        <asp:Parameter Name="Tamaño" Type="Int32" />
                                        <asp:Parameter Name="Tabla" Type="String" />
                                        <asp:Parameter Name="Campo" Type="String" />
                                        <asp:Parameter Name="Observacion" Type="String" />
                                        <asp:Parameter Name="ExpReg" Type="String" />
                                        <asp:Parameter Direction="InputOutput" Name="sMensajeError" Type="String" />
                                    </DeleteParameters>
                                    <InsertParameters>
                                        <asp:Parameter Name="iIdConexion" Type="Int32" />
                                        <asp:Parameter Name="cOperacion" Type="String" />
                                        <asp:Parameter Name="TipoMedio" Type="String" />
                                        <asp:Parameter Name="NombreCampo" Type="String" />
                                        <asp:Parameter Name="TipoDato" Type="String" />
                                        <asp:Parameter Name="Tamaño" Type="Int32" />
                                        <asp:Parameter Name="Tabla" Type="String" />
                                        <asp:Parameter Name="Campo" Type="String" />
                                        <asp:Parameter Name="Observacion" Type="String" />
                                        <asp:Parameter Name="ExpReg" Type="String" />
                                        <asp:Parameter Direction="InputOutput" Name="sMensajeError" Type="String" />
                                    </InsertParameters>
                                    <SelectParameters>
                                        <asp:SessionParameter Name="iIdConexion" SessionField="IdConexion" Type="Int32" />
                                        <asp:Parameter DefaultValue="Q" Name="cOperacion" Type="String" />
                                        <asp:Parameter DefaultValue="0" Name="IdArchivo" Type="Int32" />
                                        <asp:ControlParameter ControlID="ddlMedios" DefaultValue="" Name="Tipo" PropertyName="SelectedValue" Type="String" />
                                        <asp:Parameter Direction="InputOutput" Name="sMensajeError" Type="String" />
                                    </SelectParameters>
                                    <UpdateParameters>
                                        <asp:Parameter Name="iIdConexion" Type="Int32" />
                                        <asp:Parameter Name="cOperacion" Type="String" />
                                        <asp:Parameter Name="Tipo" Type="String" />
                                        <asp:Parameter Name="IdRegistro" Type="Int32" />
                                        <asp:Parameter Name="TipoMedio" Type="String" />
                                        <asp:Parameter Name="NombreCampo" Type="String" />
                                        <asp:Parameter Name="TipoDato" Type="String" />
                                        <asp:Parameter Name="Tamaño" Type="Int32" />
                                        <asp:Parameter Name="Tabla" Type="String" />
                                        <asp:Parameter Name="Campo" Type="String" />
                                        <asp:Parameter Name="Observacion" Type="String" />
                                        <asp:Parameter Name="ExpReg" Type="String" />
                                        <asp:Parameter Direction="InputOutput" Name="sMensajeError" Type="String" />
                                    </UpdateParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlDatos" runat="server" CssClass="panelceleste"  HorizontalAlign="Center" Width="700px">
                    <div>
                        <asp:Label ID="lblTitulo" runat="server" Text="Medios de Intercambio"
                            CssClass="etiqueta20"></asp:Label>
                        <table style="width: 100%;">
                            <tr>
                                <td align="right" style="width: 50%">&nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="lblObservaciones" runat="server" CssClass="text_obs"></asp:Label></td>
                            </tr>

                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label3" runat="server" Text="Nombre Campo Origen :" CssClass="etiqueta10"></asp:Label>
                                </td>
                                <td align="left">

                                    <asp:TextBox ID="txtNombreCampo" runat="server" Width="300px" MaxLength="50"></asp:TextBox>

                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label4" runat="server" Text="Tipo de Dato :" CssClass="etiqueta10"></asp:Label>
                                </td>
                                <td align="left">

                                    <asp:DropDownList ID="ddlTipoDato" runat="server" Width="150px">
                                    </asp:DropDownList>

                                    <span class="auto-style7">*</span></td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style5">
                                    <asp:Label ID="Label5" runat="server" Text="Longitud :" CssClass="etiqueta10"></asp:Label>
                                </td>
                                <td align="left" class="auto-style5">

                                    <asp:TextBox ID="txtTamaño" runat="server" Width="50px" MaxLength="3" onkeypress="return permite(event, 'num')">0</asp:TextBox>

                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style5">
                                    <asp:Label ID="Label6" runat="server" Text="Tabla :" CssClass="etiqueta10"></asp:Label>
                                </td>
                                <td align="left" class="auto-style5">

                                    <asp:TextBox ID="txtTabla" runat="server" Width="300px" MaxLength="50"></asp:TextBox>
                                    <cc1:textboxwatermarkextender id="txtTabla_TextBoxWatermarkExtender" watermarktext="Esquema.Tabla" watermarkcssclass="MarcaAgua" runat="server" enabled="True" targetcontrolid="txtTabla">                          
                                    </cc1:textboxwatermarkextender>
                                    <span class="auto-style7">*</span></td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style5">
                                    <asp:Label ID="Label7" runat="server" Text="Campo :" CssClass="etiqueta10"></asp:Label>
                                </td>
                                <td align="left" class="auto-style5">

                                    <asp:TextBox ID="txtCampo" runat="server" Width="300px" MaxLength="50"></asp:TextBox>

                                    <span class="auto-style7">*</span></td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style5">
                                    <asp:Label ID="Label8" runat="server" Text="Observación :" CssClass="etiqueta10"></asp:Label>
                                </td>
                                <td align="left" class="auto-style5">

                                    <asp:TextBox ID="txtObservacion" runat="server" Width="300px" MaxLength="100"></asp:TextBox>

                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style5">
                                    <asp:Label ID="Label9" runat="server" Text="Expresión Regular:" CssClass="etiqueta10"></asp:Label>
                                </td>
                                <td align="left" class="auto-style5">

                                    <asp:TextBox ID="txtExpReg" runat="server" Width="300px" MaxLength="150"></asp:TextBox>

                                    <span class="auto-style6">*</span></td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 50%">
                                    <asp:HiddenField ID="hfIdArchivo" runat="server" Value="0" />
                                </td>
                                <td align="left">
                                    &nbsp;</td>
                            </tr>

                            <tr>
                                <td align="right" style="width: 50%">&nbsp;</td>
                                <td align="left">
                                    <asp:Button ID="btnCancelar" runat="server" EnableTheming="True"
                                        OnClick="btnCancelar_Click" Text="Cancelar"
                                        CssClass="boton150" />
                                    <asp:Button ID="btnAccionar" runat="server" OnClick="btnAccionar_Click"
                                        OnClientClick="javascript : return confirm('Esta seguro de realizar esta accion?');"
                                        Text="Adicionar" CssClass="boton150" />
                                </td>
                            </tr>

                        </table>

                    </div>
                </asp:Panel>
                <cc1:RoundedCornersExtender ID="pnlDatos_RoundedCornersExtender" runat="server"
                    Enabled="True" TargetControlID="pnlDatos" Radius="10" BorderColor="Black">
                </cc1:RoundedCornersExtender>
                <cc1:ModalPopupExtender ID="pnlDatos_ModalPopupExtender" runat="server"
                    Enabled="True"
                    TargetControlID="lblTitulo"
                    CancelControlID="btnCancelar"
                    PopupControlID="pnlDatos"
                    BackgroundCssClass="modalBackground">
                </cc1:ModalPopupExtender>
            </td>
        </tr>
       
    </table>
</asp:Content>

