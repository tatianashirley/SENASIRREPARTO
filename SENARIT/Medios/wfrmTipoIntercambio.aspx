<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmTipoIntercambio.aspx.cs"
    Inherits="Medios_wfrmTipoIntercambio" StylesheetTheme="Modal" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" language="javascript">
        function ModalPopup() {
            var vpRND = Math.random() * 20;
            showModalDialog('\ModalRol.aspx?rn=' + vpRND, '', 'dialogWidth=640px; dialogHeight=320px; center=yes; scrollbars=no');
        }

        function Validar() {
            //if (document.getElementById('<%=txtAlta.ClientID%>').length>0)
            var texto = document.getElementById('<%=txtAlta.ClientID%>').value;
            //if (/^[201301-202012]$/.test(texto)) {
            var anio = texto.substring(0, 4);
            var mes = texto.substring(4, 2);
            valor = new Date(anio, mes, "01");

            if (!isNaN(valor)) {
                alert('No es un periodo valido');
                document.getElementById('<%=btnAccionar.ClientID%>').disabled;
            }
        }
        function Validar2() {
            var texto = document.getElementById('<%=txtBaja.ClientID%>').value;
            var anio = texto.substring(0, 4);
            var mes = texto.substring(4, 2);
            valor = new Date(anio, mes, "01");
            if (!isNaN(valor)) {
                alert('No es un periodo valido');
                document.getElementById('<%=btnAccionar.ClientID%>').disabled;
            }
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
            width: 50%;
            height: 26px;
        }
        .auto-style7
        {
            height: 26px;
        }
        .auto-style8
        {
            width: 100%;
        }
        .auto-style9
        {
            height: 23px;
            width: 100%;
        }
        .auto-style10
        {
            color: #000000;
        }
        .auto-style11
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
                    Text="Medios de Intercambio" CssClass="etiqueta20"></asp:Label>
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
                            <td align="right" class="auto-style8">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="left" class="auto-style8">
                                <asp:ImageButton ID="imgNuevo" runat="server" ImageUrl="~/Imagenes/nuevo.gif" OnClick="imgNuevo_Click" TabIndex="10" ToolTip="Nuevo Tipo de Intercambio" />
                                <asp:ImageButton ID="imgRegistros" runat="server" ImageUrl="~/Imagenes/pequeños/Add_32x32.png" OnClick="imgRegistros_Click" ToolTip="Agregar campos intercambio" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style9">
                                <asp:GridView ID="gvTiposIntercambio" runat="server" CellPadding="4" ForeColor="#333333"
                                    AutoGenerateColumns="False" DataSourceID="odsIntercambioMedio" DataKeyNames="IdArchivo" SkinID="GridView" OnRowCommand="gvwTiposIntercambio_RowCommand" Font-Size="10pt" PageSize="20" AllowSorting="True" OnDataBound="gvTiposIntercambio_DataBound">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:BoundField DataField="IdArchivo" HeaderText="Id Archivo" SortExpression="IdArchivo" Visible="False" />
                                        <asp:BoundField DataField="IdTransaccion" HeaderText="Trans." SortExpression="IdTransaccion" />
                                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" >
                                        </asp:BoundField>
                                        <asp:BoundField DataField="PrefijoNombreArchivo" HeaderText="Prefijo" SortExpression="PrefijoNombreArchivo" />
                                        <asp:BoundField DataField="FormatoMedio" HeaderText="Formato" SortExpression="FormatoMedio" />
                                        <asp:BoundField DataField="CodigoTipoMedio" HeaderText="Codigo Medio" SortExpression="CodigoTipoMedio" />
                                        <asp:BoundField DataField="Extencion" HeaderText="Extencion" SortExpression="Extencion" />
                                        <asp:BoundField DataField="ExpresionRegular" HeaderText="Expresión Regular" SortExpression="ExpresionRegular">
                                        </asp:BoundField>
                                        <asp:BoundField DataField="TablaDestinoTemporal" HeaderText="Tabla Temp." SortExpression="TablaDestinoTemporal" />
                                        <asp:BoundField DataField="TablaDestinoFinal" HeaderText="Tabla Fin" SortExpression="TablaDestinoFinal" />
                                        <asp:BoundField DataField="NombreProcedimiento" HeaderText="Proc." SortExpression="NombreProcedimiento" >
                                            <HeaderStyle Font-Overline="False" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="PeriodoAlta" HeaderText="Alta" SortExpression="PeriodoAlta" />
                                        <asp:BoundField DataField="PeriodoBaja" HeaderText="Baja" SortExpression="PeriodoBaja" />
                                        <asp:BoundField DataField="RegistroActivo" HeaderText="Estado" SortExpression="RegistroActivo" />
                                        <asp:ButtonField ButtonType="Image" CommandName="cmdEditar" ImageUrl="~/Imagenes/iconos16x16/Edit_16x16.png" Text="Editar" HeaderText="Editar"></asp:ButtonField>
                                        <asp:ButtonField ButtonType="Image" CommandName="cmdDesactivar" ImageUrl="~/Imagenes/iconos16x16/Delete_16x16.png" Text="Activar/ Desactivar" HeaderText="Activación"></asp:ButtonField>
                                    </Columns>
                                    <EditRowStyle BackColor="#999999" />
                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <sortedascendingcellstyle backcolor="#E9E7E2" />
                                    <sortedascendingheaderstyle backcolor="#506C8C" />
                                    <sorteddescendingcellstyle backcolor="#FFFDF8" />
                                    <sorteddescendingheaderstyle backcolor="#6F8DAE" />
                                </asp:GridView>
                                <asp:ObjectDataSource ID="odsIntercambioMedio" runat="server" InsertMethod="RegistraTipoMedio" SelectMethod="ListarTipoMedio" TypeName="wcfServicioIntercambioPago.Logica.clsIntercambio" UpdateMethod="ModificaTipoMedio" DeleteMethod="ModificaTipoMedio" OldValuesParameterFormatString="original_{0}">
                                    <DeleteParameters>
                                        <asp:Parameter Name="iIdConexion" Type="Int32" />
                                        <asp:Parameter Name="cOperacion" Type="String" />
                                        <asp:Parameter Name="Tipo" Type="String" />
                                        <asp:Parameter Name="IdArchivo" Type="Int32" />
                                        <asp:Parameter Name="IdTransaccion" Type="Int32" />
                                        <asp:Parameter Name="Descripcion" Type="String" />
                                        <asp:Parameter Name="Prefijo" Type="String" />
                                        <asp:Parameter Name="Formato" Type="String" />
                                        <asp:Parameter Name="TipoMedio" Type="String" />
                                        <asp:Parameter Name="Extension" Type="String" />
                                        <asp:Parameter Name="ExpReg" Type="String" />
                                        <asp:Parameter Name="TTemporal" Type="String" />
                                        <asp:Parameter Name="TFinal" Type="String" />
                                        <asp:Parameter Name="Procedimiento" Type="String" />
                                        <asp:Parameter Name="Alta" Type="String" />
                                        <asp:Parameter Name="Baja" Type="String" />
                                        <asp:Parameter Direction="InputOutput" Name="sMensajeError" Type="String" />
                                    </DeleteParameters>
                                    <InsertParameters>
                                        <asp:Parameter Name="iIdConexion" Type="Int32" />
                                        <asp:Parameter Name="cOperacion" Type="String" />
                                        <asp:Parameter Name="IdTransaccion" Type="Int32" />
                                        <asp:Parameter Name="Descripcion" Type="String" />
                                        <asp:Parameter Name="Prefijo" Type="String" />
                                        <asp:Parameter Name="Formato" Type="String" />
                                        <asp:Parameter Name="TipoMedio" Type="String" />
                                        <asp:Parameter Name="Extension" Type="String" />
                                        <asp:Parameter Name="ExpReg" Type="String" />
                                        <asp:Parameter Name="TTemporal" Type="String" />
                                        <asp:Parameter Name="TFinal" Type="String" />
                                        <asp:Parameter Name="Procedimiento" Type="String" />
                                        <asp:Parameter Name="Alta" Type="String" />
                                        <asp:Parameter Name="Baja" Type="String" />
                                        <asp:Parameter Direction="InputOutput" Name="sMensajeError" Type="String" />
                                    </InsertParameters>
                                    <SelectParameters>
                                        <asp:SessionParameter Name="iIdConexion" SessionField="IdConexion" Type="Int32" />
                                        <asp:Parameter DefaultValue="Q" Name="cOperacion" Type="String" />
                                        <asp:Parameter DefaultValue="0" Name="IdArchivo" Type="Int32" />
                                        <asp:Parameter Name="Tipo" Type="String" DefaultValue="TODOS" />
                                        <asp:Parameter Direction="InputOutput" Name="sMensajeError" Type="String" />
                                    </SelectParameters>
                                    <UpdateParameters>
                                        <asp:Parameter Name="iIdConexion" Type="Int32" />
                                        <asp:Parameter Name="cOperacion" Type="String" />
                                        <asp:Parameter Name="Tipo" Type="String" />
                                        <asp:Parameter Name="IdArchivo" Type="Int32" />
                                        <asp:Parameter Name="IdTransaccion" Type="Int32" />
                                        <asp:Parameter Name="Descripcion" Type="String" />
                                        <asp:Parameter Name="Prefijo" Type="String" />
                                        <asp:Parameter Name="Formato" Type="String" />
                                        <asp:Parameter Name="TipoMedio" Type="String" />
                                        <asp:Parameter Name="Extension" Type="String" />
                                        <asp:Parameter Name="ExpReg" Type="String" />
                                        <asp:Parameter Name="TTemporal" Type="String" />
                                        <asp:Parameter Name="TFinal" Type="String" />
                                        <asp:Parameter Name="Procedimiento" Type="String" />
                                        <asp:Parameter Name="Alta" Type="String" />
                                        <asp:Parameter Name="Baja" Type="String" />
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
                                <td align="right" class="auto-style6">
                                    <asp:Label ID="lblNombreClasificador" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="Tipo Intercambio :"></asp:Label>
                                </td>
                                <td align="left" class="auto-style7">
                                    <asp:DropDownList ID="ddlTipoMedio" runat="server" Width="300px">
                                    </asp:DropDownList>
                                    <span class="auto-style11">*</span></td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style7">
                                    <asp:Label ID="Label3" runat="server" Text="Descripción :" CssClass="etiqueta10"></asp:Label>
                                </td>
                                <td align="left" class="auto-style7">

                                    <asp:TextBox ID="txtDescripcion" runat="server" Width="300px" MaxLength="120"></asp:TextBox>

                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label4" runat="server" Text="Prefijo :" CssClass="etiqueta10"></asp:Label>
                                </td>
                                <td align="left">

                                    <asp:TextBox ID="txtPrefijo" runat="server" Width="50px" MaxLength="6"></asp:TextBox>

                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style5">
                                    <asp:Label ID="Label5" runat="server" Text="Formato :" CssClass="etiqueta10"></asp:Label>
                                </td>
                                <td align="left" class="auto-style5">

                                    <asp:TextBox ID="txtFormato" runat="server" MaxLength="30"></asp:TextBox>

                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style5">
                                    <asp:Label ID="Label6" runat="server" Text="Extensión :" CssClass="etiqueta10"></asp:Label>
                                </td>
                                <td align="left" class="auto-style5">

                                    <asp:TextBox ID="txtExtension" runat="server" Width="50px" MaxLength="5"></asp:TextBox>
                                    <cc1:textboxwatermarkextender id="Textboxwatermarkextender3" watermarktext=".txt" watermarkcssclass="MarcaAgua" runat="server" enabled="True" targetcontrolid="txtExtension">                          
                                    </cc1:textboxwatermarkextender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style5">
                                    <asp:Label ID="Label7" runat="server" Text="Expresión Regular :" CssClass="etiqueta10"></asp:Label>
                                </td>
                                <td align="left" class="auto-style5">

                                    <asp:TextBox ID="txtExpReg" runat="server" Width="300px" MaxLength="200"></asp:TextBox>

                                    <span class="auto-style11">*</span></td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style5">
                                    <asp:Label ID="Label8" runat="server" Text="Tabla Temporal :" CssClass="etiqueta10"></asp:Label>
                                </td>
                                <td align="left" class="auto-style5">
                                    <asp:TextBox ID="txtTablaTemp" runat="server" Width="150px" CssClass="auto-style10" MaxLength="100"></asp:TextBox>
                                    <cc1:textboxwatermarkextender id="txtObservaciones_TextBoxWatermarkExtender" watermarktext="Esquema.Tabla" watermarkcssclass="MarcaAgua" runat="server" enabled="True" targetcontrolid="txtTablaTemp">                          
                                    </cc1:textboxwatermarkextender>
                                    <span class="auto-style11">*</span></td>                                      
                            </tr>
                            <tr>
                                <td align="right" class="auto-style5">
                                    <asp:Label ID="Label9" runat="server" Text="Tabla Final :" CssClass="etiqueta10"></asp:Label>
                                </td>
                                <td align="left" class="auto-style5">

                                    <asp:TextBox ID="txtTablaFin" runat="server" Width="150px" MaxLength="100"></asp:TextBox>
                                    <cc1:textboxwatermarkextender id="Textboxwatermarkextender1" watermarktext="Esquema.Tabla" watermarkcssclass="MarcaAgua" runat="server" enabled="True" targetcontrolid="txtTablaFin">                          
                                    </cc1:textboxwatermarkextender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style5">
                                    <asp:Label ID="Label10" runat="server" Text="Procedimiento :" CssClass="etiqueta10"></asp:Label>
                                </td>
                                <td align="left" class="auto-style5">

                                    <asp:TextBox ID="txtProcedimiento" runat="server" Width="150px" MaxLength="100"></asp:TextBox>
                                    <cc1:textboxwatermarkextender id="Textboxwatermarkextender2" watermarktext="Esquema.procedimiento" watermarkcssclass="MarcaAgua" runat="server" enabled="True" targetcontrolid="txtProcedimiento">                          
                                    </cc1:textboxwatermarkextender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style5">
                                    <asp:Label ID="Label11" runat="server" Text="Periodo Alta :" CssClass="etiqueta10"></asp:Label>
                                </td>
                                <td align="left" class="auto-style5">

                                    <asp:TextBox ID="txtAlta" runat="server" Width="50px" MaxLength="6" onblur="Validar();" onkeypress="return permite(event, 'num')"></asp:TextBox>
                                    <cc1:CalendarExtender ID="txtAlta_CalendarExtender" runat="server" Enabled="True" Format="yyyyMM" PopupButtonID="txtAlta" TargetControlID="txtAlta" CssClass="cal_Theme1">
                                    </cc1:CalendarExtender>
                                    <asp:ImageButton ID="ImageButton1" runat="server" Enabled="False" ImageUrl="~/Imagenes/pequeños/Calendar_32x32.png" />

                                    <span class="auto-style11">*</span></td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style5">
                                    <asp:Label ID="Label12" runat="server" Text="Periodo Baja :" CssClass="etiqueta10"></asp:Label>
                                </td>
                                <td align="left" class="auto-style5">

                                    <asp:TextBox ID="txtBaja" runat="server" Width="50px" MaxLength="6" onblur="Validar2();" onkeypress="return permite(event, 'num')"></asp:TextBox>
                                    <cc1:CalendarExtender ID="txtBaja_CalendarExtender" runat="server" Enabled="True" Format="yyyyMM" PopupButtonID="txtBaja" TargetControlID="txtBaja" CssClass="cal_Theme1">
                                    </cc1:CalendarExtender>
                                    <asp:ImageButton ID="ImageButton2" runat="server" Enabled="False" ImageUrl="~/Imagenes/pequeños/Calendar_32x32.png" />

                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 50%">
                                    <asp:HiddenField ID="hdIdArchivo" runat="server" Value="0" />
                                </td>
                                <td align="left">
                                    <!--<asp:CheckBox ID="chbEstado" runat="server" Checked="True"
                                        Text="Activar" CssClass="etiqueta8Blue" />-->
                                </td>
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

