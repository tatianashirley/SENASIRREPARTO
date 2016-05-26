<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmIntercambioCarga.aspx.cs" Inherits="PagoCC_wfrmIntercambioCarga" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" language="javascript">
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
        .auto-style1
        {
            height: 23px;
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
                    Text="Intercambio - Carga" CssClass="etiqueta20"></asp:Label>
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
                        <td width="50%">
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
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
                        <td width="50%">
                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                            <ContentTemplate>
                            <asp:FileUpload ID="FileUpload1" runat="server" ToolTip="Seleccione el archivo para la carga" Enabled="False" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnCargar" runat="server" OnClick="btnCargar_Click" OnClientClick="return postbackButtonClick();" Text="Cargar Archivo" Enabled="False" />
                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="btnCargar" />
                            </Triggers>
                            </asp:UpdatePanel>
                        </td>
                        <td width="50%">
                            <asp:CheckBox ID="chbMedioFinal" runat="server" Text="Como Medio Final" Enabled="False" />
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnNuevo" runat="server" Text="Nueva Carga" OnClick="btnNuevo_Click" OnClientClick="javascript : return confirm('Esta seguro de realizar una nueva carga?');" />
                        </td>
                    </tr>
                    <tr>
                        <td width="50%">
&nbsp;&nbsp;<asp:HiddenField ID="hfCantidad" runat="server" />
&nbsp;<asp:HiddenField ID="hfCRC" runat="server" />
                            <asp:HiddenField ID="hfRuta" runat="server" />
                        </td>
                        <td width="50%">
                        &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        
        

        <%--TODA LA TABLA--%>
        <tr>
            <td width="100%" align="center" class="auto-style1">

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
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="Label11" runat="server" Text="Bandeja de Medios en Proceso" ForeColor="#0099FF"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                <asp:GridView ID="gvBandeja" runat="server" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataSourceID="odsBandejaExterno" Font-Size="Small" ForeColor="#333333" DataKeyNames="IdControlEnvio,CodigoEntidad,CodigoMedio,RutaRepositorio" OnDataBound="gvBandeja_DataBound" OnRowCommand="gvBandeja_RowCommand" >
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775"/>
                    <Columns>
                        <asp:BoundField DataField="IdControlEnvio" HeaderText="IdControlEnvio" Visible="False" />
                        <asp:BoundField DataField="IdEntidad" Visible="False" />
                        <asp:BoundField DataField="IdTipoMedio" Visible="False" />
                        <asp:BoundField DataField="Entidad" HeaderText="Entidad" />
                        <asp:BoundField DataField="TipoMedio" HeaderText="Tipo Medio" />
                        <asp:BoundField DataField="Periodo" HeaderText="Periodo" />
                        <asp:BoundField DataField="NumeroEnvio" HeaderText="Numero Envio" />
                        <asp:BoundField DataField="Estado" HeaderText="Estado" />
                        <asp:BoundField DataField="CodigoSeguridad" HeaderText="Codigo Seguridad" />
                        <asp:BoundField DataField="FechaEnvio" HeaderText="FechaEnvio" />
                        <asp:BoundField DataField="RutaRepositorio" HeaderText="Ruta" Visible="False" />
                        <asp:BoundField DataField="CantidadRegistros" HeaderText="Cantidad Registros" />
                        <asp:ButtonField ButtonType="Image" CommandName="cmdDescargar" ImageUrl="~/Imagenes/iconos16x16/Download_16x16.png" Text="Descargar..." HeaderText="Descargas" />
                    </Columns>
                    <EmptyDataTemplate>
                        <div align="center" class="CajaDialogoAdvertencia">
                        <br/>
                        <img src="../Imagenes/warning.gif" alt="No existen medios pendientes para este periodo" />
                        <br/>No existen medios pendientes para este periodo<br/><br/>
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
                </ContentTemplate>
                <Triggers>
                     <asp:PostBackTrigger ControlID="gvBandeja" />
                 </Triggers>
                </asp:UpdatePanel>
                <asp:ObjectDataSource ID="odsBandejaExterno" runat="server" SelectMethod="ObtieneVista" TypeName="wcfServicioIntercambioPago.Logica.clsControlEnvios" OldValuesParameterFormatString="original_{0}" DeleteMethod="ModificaEnvio" InsertMethod="RegistraEnvio" UpdateMethod="ModificaEnvio">
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
                        <asp:Parameter DefaultValue="BandejaExterno" Name="TipoVista" Type="String" />
                        <asp:ControlParameter ControlID="ddlEntidad" DefaultValue="" Name="Entidad" PropertyName="SelectedValue" Type="String" />
                        <asp:Parameter DefaultValue="PR" Name="TipoMedio" Type="String" />
                        <asp:Parameter Name="Periodo" Type="String" DefaultValue="201411" />
                        <asp:Parameter Name="Estado" Type="String" DefaultValue="X" />
                        <asp:Parameter Name="NumeroEnvio" Type="Int32" DefaultValue="1" />
                        <asp:Parameter DefaultValue="" Direction="InputOutput" Name="sMensajeError" Type="String" />
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
            <td align="center" width="100%">
                <asp:Panel ID="pnlDetalleConcil" Width="100%" runat="server">
                    <table align="center">
                         <tr>
                            <td width="100%">
                                <asp:Label ID="lblDetalle" runat="server" ForeColor="#0099FF" Text="Detalle Casos Conciliados" Visible="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="gvResumenConcil" runat="server" CellPadding="4" Font-Size="10pt" ForeColor="#333333" Visible="False">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
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
                            </td>
                        </tr>
                        <tr>
                            <td>

                                <asp:Label ID="lblMontos" runat="server" ForeColor="#0099FF" Text="Montos Finales de la Conciliación" Visible="False"></asp:Label>

                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="gvMontosActas" runat="server" CellPadding="4" Font-Size="10pt" ForeColor="#333333" Visible="False">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
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
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
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


