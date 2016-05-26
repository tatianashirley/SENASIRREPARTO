<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmCargaInterno.aspx.cs" Inherits="PagoCC_wfrmCargaInterno" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" language="javascript">
        function ModalPopup() {
            var vpRND = Math.random() * 20;
            showModalDialog('\ModalRol.aspx?rn=' + vpRND, '', 'dialogWidth=640px; dialogHeight=320px; center=yes; scrollbars=no');
        }

        function postbackButtonClick() {
            updateProgress = $find("<%= UpdateProgress5.ClientID %>");
            window.setTimeout("updateProgress.set_visible(true)", updateProgress.get_displayAfter());
            return true;
        }
    </script>
    <style type="text/css">
        .cssHeaderImg {
            background-image: url(../Imagenes/Menu4.png);
        }
        </style>

    <%--TODA LA TABLA--%>

</asp:Content>
<%--TODA LA TABLA--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%;" class="panelceleste">
        <tr>
            <td align="center" colspan="2">
                <asp:ImageButton ID="imgAux" runat="server" ImageUrl="~/Imagenes/pequeños/Favorites_32x32.png" />
                <asp:Label ID="lblTituloAUX" runat="server"
                    Text="Carga de Medios (Interno)" CssClass="etiqueta20"></asp:Label>
                <asp:Label ID="lblCodigo" runat="server" Font-Size="Small" Text="1"
                    Visible="False"></asp:Label>
                <asp:Label ID="lblCodUsuario" runat="server" Font-Size="Small" Text="1"
                    Visible="False"></asp:Label>
                <asp:Label ID="lblRol" runat="server" Font-Size="Small"
                    Style="text-align: left" Text="0" Visible="False"></asp:Label>
            </td>
        </tr>
        <%--TODA LA TABLA--%>
        <tr>
            <td colspan="2">
                <table style="width: 100%;">
                    <tr>
                        <td align="right" width="50%">
                            <asp:Label ID="Label4" runat="server" Text="Seleccione la Entidad:"></asp:Label>
                            &nbsp
                            <asp:DropDownList ID="ddlEntidad" runat="server" Width="200px">
                            </asp:DropDownList>
                        </td>
                        <td width="50%">
                            
                            <asp:Label ID="lblMuestra" runat="server"></asp:Label>
                            
                        </td>
                    </tr>
                    <tr>
                        <td width="50%" align="right">
                                <asp:Label ID="Label3" runat="server" Text="Seleccione el tipo de medio:"></asp:Label>
                                &nbsp
                                <asp:DropDownList ID="ddlTipoMedio" runat="server" style="margin-left: 0px" Width="300px">
                                </asp:DropDownList>
                        </td>
                        <td width="50%" align="center">
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="Label2" runat="server" Text="Introduzca el periodo:"></asp:Label>
                                &nbsp
                                <asp:DropDownList ID="ddlPeriodo" runat="server" OnSelectedIndexChanged="ddlPeriodo_SelectedIndexChanged" Width="100px" AutoPostBack="True">
                                </asp:DropDownList>
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="Label5" runat="server" Text="Número de Envío:"></asp:Label>
                                &nbsp;<asp:Label ID="lblNumEnvio" runat="server" Text="0"></asp:Label>
                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="ddlPeriodo" />
                            </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td width="50%" align="right">
                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                            <ContentTemplate>
                                <asp:FileUpload ID="fulArchivo" runat="server" Enabled="False" />
                                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnCarga" runat="server" onclick="btnCarga_Click" OnClientClick="return postbackButtonClick();" Text="Cargar Archivo" Enabled="False" />
                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="btnCarga" />
                            </Triggers>
                            </asp:UpdatePanel>
                        </td>
                        <td width="50%" align="center">
                            <asp:CheckBox ID="chbMedioFinal" runat="server" Text="Como Medio Final" Enabled="False" />
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:CheckBox ID="chbSoloCRC" runat="server" Text="Comprobar CRC" Enabled="False" />
                             &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnNuevo" runat="server" Text="Nueva Carga" OnClick="btnNuevo_Click" OnClientClick="javascript : return confirm('Esta seguro de realizar una nueva carga?');" />
                        </td>
                    </tr>
                    <tr>
                        <td width="50%">
                            <asp:HiddenField ID="hfCRC" runat="server" Visible="False" />
                            <asp:HiddenField ID="hfRuta" runat="server" Visible="False" />
                            <asp:HiddenField ID="hfCantidad" runat="server" Visible="False" />
                        </td>
                        <td width="50%">
                            <asp:CheckBox ID="chbContinuo" runat="server" Text="Revisión Continua" Checked="True" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        
        

        <%--TODA LA TABLA--%>
        <tr>
            <td width="100%" align="center">

                <asp:Label ID="lblTituloGrid" runat="server" ForeColor="#0099FF" Text="Label" Visible="False"></asp:Label>

            </td>
        </tr>
        <tr>
            <td align="center">
                <div style ="width:1000px; overflow:auto;">
                    <asp:GridView ID="gvErrores2" runat="server" CellPadding="4" EnableModelValidation="True" ForeColor="#333333" Font-Names="Arial Narrow" AllowPaging="True" OnPageIndexChanging="gvErrores2_PageIndexChanging" Font-Size="10pt">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerSettings FirstPageImageUrl="~/Imagenes/16anterior.png" LastPageImageUrl="~/Imagenes/32siguiente.png" NextPageImageUrl="~/Imagenes/Pages/next.png" PreviousPageImageUrl="~/Imagenes/Pages/previous.png" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                </asp:GridView>
                </div>
            </td>
        </tr>
        <tr>
            <td width="100%" align="center">
                <div style ="width:1000px; overflow:auto;">
                <asp:GridView ID="gvErrores" runat="server" CellPadding="4" ForeColor="#333333" Font-Names="Arial Narrow" AllowPaging="True" OnPageIndexChanging="gvErrores_PageIndexChanging" Font-Size="10pt" AutoGenerateColumns="False">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="TipoMedio" HeaderText="Medio" />
                        <asp:BoundField DataField="PeriodoPlanilla" HeaderText="Periodo Planilla" />
                        <asp:BoundField DataField="Entidad" HeaderText="Entidad" />
                        <asp:BoundField DataField="CUA" HeaderText="CUA" />
                        <asp:BoundField DataField="NumeroCertificado" HeaderText="Certificado" />
                        <asp:BoundField DataField="NumeroDocumento" HeaderText="N° Documento" />
                        <asp:BoundField DataField="Transaccion" HeaderText="Trans." />
                        <asp:BoundField DataField="FechaInicio" HeaderText="Fecha Inicio" />
                        <asp:BoundField DataField="CodigoError" HeaderText="Código" />
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripción">
                        <ControlStyle Width="2000px" />
                        </asp:BoundField>
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerSettings FirstPageImageUrl="~/Imagenes/16anterior.png" LastPageImageUrl="~/Imagenes/32siguiente.png" NextPageImageUrl="~/Imagenes/Pages/next.png" PreviousPageImageUrl="~/Imagenes/Pages/previous.png" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                </asp:GridView>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:LinkButton ID="lblDescargaError" runat="server" OnClick="lblDescargaError_Click">Descarga como archivo .txt</asp:LinkButton>
                </ContentTemplate>
                <Triggers>
                     <asp:PostBackTrigger ControlID="lblDescargaError" />
                 </Triggers>
                </asp:UpdatePanel>
                </div>
            </td>
        </tr>
        <tr>
            <td>

            </td>
        </tr>
        <tr>
            <td width="100%" align="center">

                <asp:Label ID="Label11" runat="server" Text="Bandeja de Entrada Usuario Interno - Por Entidad" ForeColor="#0099FF"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center">

                <asp:GridView ID="gvBandeja" runat="server" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4"
                    DataSourceID="odsBandejaInterno" Font-Size="10pt" ForeColor="#333333" DataKeyNames="IdControlEnvio,CodigoEntidad,CodigoMedio,RutaRepositorio" OnDataBound="gvBandeja_DataBound" OnRowCommand="gvBandeja_RowCommand" >
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775"/>
                    <Columns>
                        <asp:BoundField DataField="IdControlEnvio" HeaderText="IdControlEnvio" Visible="False" />
                        <asp:BoundField DataField="CodigoEntidad" HeaderText="CEntidad" Visible="False" />
                        <asp:BoundField DataField="CodigoMedio" HeaderText="CMedio" Visible="False" />
                        <asp:BoundField DataField="Entidad" HeaderText="Entidad" />
                        <asp:BoundField DataField="TipoMedio" HeaderText="Tipo Medio" />
                        <asp:BoundField DataField="Periodo" HeaderText="Periodo" />
                        <asp:BoundField DataField="NumeroEnvio" HeaderText="Numero Envio" />
                        <asp:BoundField DataField="Estado" HeaderText="Estado" />
                        <asp:BoundField DataField="CodigoSeguridad" HeaderText="Codigo Seguridad" />
                        <asp:BoundField DataField="FechaEnvio" HeaderText="Fecha Envio" />
                        <asp:BoundField DataField="RutaRepositorio" HeaderText="Ruta" Visible="False" />
                        <asp:BoundField DataField="CantidadRegistros" HeaderText="Cantidad Registros" />
                        <asp:ButtonField CommandName="cmdRevisar" Text="Revisar" HeaderText="Revisar" />
                        <asp:ButtonField CommandName="cmdErrores" Text="Ver Errores" HeaderText="Ver Errores" />
                        <asp:ButtonField CommandName="cmdMedio" Text="Ver Medio" HeaderText="Ver Medio" />
                    </Columns>
                    <EmptyDataTemplate>
                        <div align="center" class="CajaDialogoAdvertencia">
                        <br/>
                        <img src="../Imagenes/warning.gif" alt="No existen medios pendientes para esta entidad" />
                        <br/>No existen medios pendientes para esta entidad<br/><br/>
                        </div>
                    </EmptyDataTemplate>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#3366FF" Font-Bold="True" ForeColor="#333333" BorderStyle="None" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>

                <asp:ObjectDataSource ID="odsBandejaInterno" runat="server" SelectMethod="ObtieneVista" TypeName="wcfServicioIntercambioPago.Logica.clsControlEnvios" OldValuesParameterFormatString="original_{0}" DeleteMethod="ModificaEnvio" InsertMethod="RegistraEnvio" UpdateMethod="ModificaEnvio">
                    <DeleteParameters>
                        <asp:Parameter Name="iIdConexion" Type="Int32" />
                        <asp:Parameter Name="cOperacion" Type="String" />
                        <asp:Parameter Name="Entidad" Type="String" />
                        <asp:Parameter Name="TipoMedio" Type="String" />
                        <asp:Parameter Name="Periodo" Type="String" />
                        <asp:Parameter Name="NumeroEnvio" Type="Int32" />
                        <asp:Parameter Name="Estado" Type="String" />
                        <asp:Parameter Name="CodigoSeguridad" Type="String" />
                        <asp:Parameter Name="CantidadRegistros" Type="Int32" />
                        <asp:Parameter Direction="InputOutput" Name="sMensajeError" Type="String" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="iIdConexion" Type="Int32" />
                        <asp:Parameter Name="cOperacion" Type="String" />
                        <asp:Parameter Name="IdEntidad" Type="String" />
                        <asp:Parameter Name="IdEnvio" Type="String" />
                        <asp:Parameter Name="Periodo" Type="String" />
                        <asp:Parameter Name="NumeroEnvio" Type="Int32" />
                        <asp:Parameter Name="IdEstado" Type="String" />
                        <asp:Parameter Name="CodigoSeguridad" Type="String" />
                        <asp:Parameter Name="RutaEnvio" Type="String" />
                        <asp:Parameter Name="CantidadRegistros" Type="Int32" />
                        <asp:Parameter Direction="InputOutput" Name="sMensajeError" Type="String" />
                    </InsertParameters>
                    <SelectParameters>
                        <asp:SessionParameter Name="iIdConexion" SessionField="IdConexion" Type="Int32" />
                        <asp:Parameter DefaultValue="Q" Name="cOperacion" Type="String" />
                        <asp:Parameter DefaultValue="BandejaInterno" Name="TipoVista" Type="String" />
                        <asp:ControlParameter ControlID="ddlEntidad" DefaultValue="" Name="Entidad" PropertyName="SelectedValue" Type="String" />
                        <asp:Parameter DefaultValue="PR" Name="TipoMedio" Type="String" />
                        <asp:Parameter Name="Periodo" Type="String" DefaultValue="201410" />
                        <asp:Parameter Name="Estado" Type="String" DefaultValue="X" />
                        <asp:Parameter Name="NumeroEnvio" Type="Int32" DefaultValue="1" />
                        <asp:Parameter Direction="InputOutput" Name="sMensajeError" Type="String" />
                    </SelectParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="iIdConexion" Type="Int32" />
                        <asp:Parameter Name="cOperacion" Type="String" />
                        <asp:Parameter Name="Entidad" Type="String" />
                        <asp:Parameter Name="TipoMedio" Type="String" />
                        <asp:Parameter Name="Periodo" Type="String" />
                        <asp:Parameter Name="NumeroEnvio" Type="Int32" />
                        <asp:Parameter Name="Estado" Type="String" />
                        <asp:Parameter Name="CodigoSeguridad" Type="String" />
                        <asp:Parameter Name="CantidadRegistros" Type="Int32" />
                        <asp:Parameter Direction="InputOutput" Name="sMensajeError" Type="String" />
                    </UpdateParameters>
                </asp:ObjectDataSource>

            </td>
        </tr>
        <tr>
            <td width="100%" align="center" valign="bottom" height="50px">
                <asp:Label ID="lblTituloMedio" runat="server" ForeColor="#0099FF" Text="Label" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:TextBox ID="txtCUA" runat="server" Visible="False"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar en Envío.." OnClick="btnBuscar_Click" Visible="False" />
            </td>
        </tr>
        <tr>
            <td width="100%" align="center">
                <div style ="width:1000px; overflow:auto;">
                <asp:GridView ID="gvMedios" runat="server" AllowPaging="True" CellPadding="4" ForeColor="#333333" OnPageIndexChanging="gvMedios_PageIndexChanging" OnDataBound="gvMedios_DataBound" OnRowCommand="gvMedios_RowCommand" Font-Size="10pt">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:ButtonField CommandName="cmdExcepcion" Text="Excepción" HeaderText="Forzar Excepción" />
                        <asp:ButtonField CommandName="cmdError" Text="Error" HeaderText="Forzar Error" />
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
                    <asp:HiddenField ID="hfRutaArchivoError" runat="server" />
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlDatos" runat="server" CssClass="panelceleste"  HorizontalAlign="Center" Width="700px">
                    <div>
                        <asp:Label ID="lblTitulo" runat="server" Text="Agregar Exepcion"
                            CssClass="etiqueta20"></asp:Label>
                        <table style="width: 100%;">
                            <tr>
                                <td align="right" width="30%">&nbsp;</td>
                                <td align="left" width="70%">
                                    <asp:Label ID="lblObservaciones" runat="server" CssClass="text_obs"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style5" width="30%">
                                    <asp:Label ID="Label7" runat="server" Text="Error: " CssClass="etiqueta10"></asp:Label>
                                </td>
                                <td align="left" class="auto-style5" width="70%">

                                    <asp:DropDownList ID="ddlError" runat="server" ToolTip="Seleccione codigo de error" OnSelectedIndexChanged="ddlError_SelectedIndexChanged" Width="270px" AutoPostBack="true">
                                    </asp:DropDownList>
                                    &nbsp;&nbsp;<asp:Label ID="Label1" runat="server" Text="Código Error"></asp:Label>
                                    &nbsp;&nbsp;
                                    <asp:TextBox ID="txtCodigoError" runat="server" Width="30px" ReadOnly="True"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style5" width="30%">
                                    <asp:Label ID="Label8" runat="server" Text="Justificación: " CssClass="etiqueta10"></asp:Label>
                                </td>
                                <td align="left" class="auto-style5" width="70%">

                                    <asp:TextBox ID="txtJustificacion" runat="server" Width="320px" TextMode="MultiLine" Height="60px"></asp:TextBox>

                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style5" width="30%">
                                    <asp:Label ID="Label9" runat="server" Text="Periodo Inicio: " CssClass="etiqueta10"></asp:Label>
                                </td>
                                <td align="left" class="auto-style5" width="70%">
                                    
                                    <asp:TextBox ID="txtPeriodoInicio" runat="server" Width="60px" Enabled="False"></asp:TextBox>
                                    <cc1:CalendarExtender ID="txtPeriodoInicio_CalendarExtender" runat="server" Enabled="True" Format="yyyyMM" PopupButtonID="txtPeriodoInicio" TargetControlID="txtPeriodoInicio" CssClass="cal_Theme1">
                                    </cc1:CalendarExtender>
                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Imagenes/pequeños/Calendar_32x32.png" Enabled="False" />
                                    
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style5" width="30%">
                                    <asp:Label ID="Label10" runat="server" Text="Periodo Final:" CssClass="etiqueta10"></asp:Label>
                                </td>
                                <td align="left" class="auto-style5" width="70%">

                                    <asp:TextBox ID="txtPeriodoFinal" runat="server" Width="60px" Enabled="False"></asp:TextBox>
                                    <cc1:CalendarExtender ID="txtPeriodoFinal_CalendarExtender" runat="server" Enabled="True" Format="yyyyMM" PopupButtonID="txtPeriodoFinal" TargetControlID="txtPeriodoFinal" CssClass="cal_Theme1">
                                    </cc1:CalendarExtender>
                                    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Imagenes/pequeños/Calendar_32x32.png" Enabled="False" />

                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="30%">
                                    <asp:HiddenField ID="hfIdArchivo" runat="server" />
                                </td>
                                <td align="left" width="70%">
                                   
                                </td>
                            </tr>

                            <tr>
                                <td align="right" width="30%">&nbsp;</td>
                                <td align="left" width="70%">
                                    <asp:Button ID="btnCancelar" runat="server" EnableTheming="True"
                                        OnClick="btnCancelar_Click" Text="Cancelar"
                                        CssClass="boton150" />
                                    <asp:Button ID="btnAccionar" runat="server" OnClick="btnAccionar_Click"
                                        OnClientClick="javascript : return confirm('Esta seguro de forzar esta accion?');"
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
    <asp:UpdateProgress ID="UpdateProgress5" runat="server" DisplayAfter="0" AssociatedUpdatePanelID="UpdatePanel5">
        <ProgressTemplate>
            <div class="overlay" />
            <div class="overlayContent">
                <h2>Loading...</h2>
                <img src="../App_Themes/Imagenes/ajax-loader.gif" alt="Loading" border="1" />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>


