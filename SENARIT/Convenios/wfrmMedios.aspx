<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmMedios.aspx.cs" Inherits="Convenios_wfrmMedios" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register assembly="System.Web, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="System.Web.UI" tagprefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!--PLANTILLA -->
       <table width="100%">
        <tr>
            <td width="100%" align="center">
                <asp:ImageButton ID="imgAux" runat="server" ImageUrl="~/Imagenes/pequeños/Favorites_32x32.png" />
                <asp:Label ID="lblTituloAUX" runat="server"
                    Text="Generarcion de Medios" CssClass="etiqueta20" Font-Size="16pt"></asp:Label>
            </td>
        </tr>
    </table>

     <table>
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Actualizar Estados"></asp:Label>
                </td>
                <td><asp:Button ID="btnActualizarEstados" runat="server" Text="Actualizar" Enabled ="true" OnClick="btnActualizarEstados_Click" /></td>
            </tr>
  

            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Generar vista previa de Medio"></asp:Label>
                </td>
                <td><asp:Button ID="btnVistaPreviaMedio" runat="server" Text="Vista Previa" OnClick="btnVistaPreviaMedio_Click" /></td>
            </tr>
         <tr>
             <td colspan ="4">
                 <div style="width:1200px; height:800px; overflow: scroll;">
                <asp:GridView ID="gvMedio" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Size="9pt" ForeColor="#333333">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="Fila" HeaderText="Nro." />
                        <asp:BoundField DataField="COD_FUEN" HeaderText="Entidad" />
                        <asp:BoundField DataField="NUA" HeaderText="NUA" />
                        <asp:BoundField DataField="NO_CERTI" HeaderText="Nro. Certiicado" />
                        <asp:BoundField DataField="IDENTIFICADOR" HeaderText="Carnet" />
                        <asp:BoundField DataField="PATERNO" HeaderText="Paterno" />
                        <asp:BoundField DataField="MATERNO" HeaderText="Materno" />
                        <asp:BoundField DataField="NOMBRES" HeaderText="Nombres" />
                        <asp:BoundField DataField="TIPO_CONV" HeaderText="Tipo de Convenio" />
                        <asp:BoundField DataField="NRO_CONV" HeaderText="Nro. Convenio"  />
                        <asp:BoundField DataField="ANIO_CONV" HeaderText="Añio de Convenio" />
                        <asp:BoundField DataField="FECHA_CONV" HeaderText="Fecha de Convenion" />
                        <asp:BoundField DataField="PORCENTAJE_DESCUENTO" HeaderText="% Descuento" />
                        <asp:BoundField DataField="ESTADO" HeaderText="Estado" />
                        <asp:BoundField DataField="NRO_RESOLUCION" HeaderText="Nro. Resolucion" />
                        <asp:BoundField DataField="FECHA_RESOLUCION" HeaderText="Fecha Resolucion" />
                        <asp:BoundField DataField="MONTO_TOTAL_DEUDA" HeaderText="Monto Total Deuda" />
                        <asp:BoundField DataField="MONTO_AMORTIZADO" HeaderText="Monto Amortizado" />
                        <asp:BoundField DataField="TIPO_CC" HeaderText="Tipo CC" />
                        <asp:BoundField DataField="ID_TIPO_DEUDA" HeaderText="Tipo Deuda" />
                        <asp:BoundField DataField="PERIODO_ENVIO" HeaderText="Period Envio" />
                        </Columns>
                    <EmptyDataTemplate>
                        <div align="center" class="CajaDialogoAdvertencia">
                        <br/>
                        <img src="../Imagenes/warning.gif" alt="La persona no cuenta con Deudas Registradas" />
                        <br/>NO EXISTE REGISTOS<br/><br/>
                        </div>
                    </EmptyDataTemplate>
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
                 </div>
             </td>
         </tr>
         <td colspan="3">
             Resumen de Casos:
            <asp:GridView ID="gvResumen" runat="server" AutoGenerateColumns="False"  CellPadding="4" Font-Size="9pt" ForeColor="#333333">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="Fila" HeaderText="Nro"/>
                <asp:BoundField DataField="COD_FUEN" HeaderText="Entidad"/>
                <asp:BoundField DataField="TIPO_CONV" HeaderText="Tipo de Convenio"/>
                <asp:BoundField DataField="CantidadDeCasos" HeaderText="Cantidad de Casos" />
            </Columns>
            <EmptyDataTemplate>
                <div align="center" class="CajaDialogoAdvertencia">
                <br/>
                <img src="../Imagenes/warning.gif" alt="No existen Tipos de Cambio para la fecha Especificada" />
                <br/>No existen registros<br/><br/>
                </div>
            </EmptyDataTemplate>
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
         <tr>
            <td>
              <asp:Label ID="Label2" runat="server" Text="  Generar Medio en TXT"></asp:Label>
            </td>
            <td>
                <asp:Button ID="btnMedioTxt" runat="server" Text="GENERAR" Enabled="false" OnClick="btnMedioTxt_Click"/>
            </td>
        </tr>
         <tr>
              <td>
              <asp:Label ID="lbl1" runat="server" Text="CRC: " Visible="false"></asp:Label>
             </td>
             <td>
                 <asp:Label ID="lblCRCtxt" runat="server" Text="" Visible="false"></asp:Label>
             </td>
             <td>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                <asp:LinkButton ID="lbltxtDescarga" runat="server" OnClick="lbltxtDescarga_Click" Visible="false">Descarga como archivo .txt</asp:LinkButton>
                </ContentTemplate>
                <Triggers>
                <asp:PostBackTrigger ControlID="lbltxtDescarga" />
                </Triggers>
                </asp:UpdatePanel>
             </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                <asp:LinkButton ID="lbltxtDescargaCRC" runat="server" OnClick="lbltxtDescargaCRC_Click" Visible="false">Descarga CRC como archivo .txt</asp:LinkButton>
                </ContentTemplate>
                <Triggers>
                <asp:PostBackTrigger ControlID="lbltxtDescargaCRC" />
                </Triggers>
                </asp:UpdatePanel>
             </td>
         </tr>
        <tr>
            <td>
              <asp:Label ID="Label3" runat="server" Text="  Generar Medio en EXCEL" ></asp:Label>

            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                <asp:Button ID="btnMedioExcel" runat="server" Text="GENERAR" Enabled="false" OnClick="btnMedioExcel_Click"/>
                </ContentTemplate>
                <Triggers>
                <asp:PostBackTrigger ControlID="btnMedioExcel" />
                </Triggers>
                </asp:UpdatePanel>
                
            </td>
        </tr>
         <tr>
           <td>
              <asp:Label ID="Label5" runat="server" Text="ACTUALIZAR ESTADOS PARTE 2" Visible="true"></asp:Label>
           </td>
             <td>
                 <asp:Button ID="btnActualizarParteEstado2" runat="server" Text="Actualizar" Enabled ="false" OnClick="btnActualizarParteEstado2_Click" Visible="true" />
             </td>
         </tr>
    <tr>
        <td colspan="2">
            Personas que cambiaran de Estado
            <asp:GridView ID="gvCambioEstado" runat="server" AutoGenerateColumns="False"  CellPadding="4" Font-Size="9pt" ForeColor="#333333">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="Fila" HeaderText="Nro"/>
                <asp:BoundField DataField="Nombre" HeaderText="Nombre"/>
                <asp:BoundField DataField="EstadoAnterior" HeaderText="Estado Anterior"/>
                <asp:BoundField DataField="NuevoEstado" HeaderText="Nuevo Estado" />
            </Columns>
            <EmptyDataTemplate>
                <div align="center" class="CajaDialogoAdvertencia">
                <br/>
                <img src="../Imagenes/warning.gif" alt="No existen Tipos de Cambio para la fecha Especificada" />
                <br/>No existen registros<br/><br/>
                </div>
            </EmptyDataTemplate>
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
        <td colspan="2">
            Resumen de Cambio de Estados
              <asp:GridView ID="gvCantidadDeCasos" runat="server" AutoGenerateColumns="False"  CellPadding="4" Font-Size="9pt" ForeColor="#333333">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="Fila" HeaderText="Nro"/>
                <asp:BoundField DataField="EstadoAnterior" HeaderText="Estado Anterior"/>
                <asp:BoundField DataField="NuevoEstado" HeaderText="Nuevo Estado" />
                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad de Casos"/>
            </Columns>
            <EmptyDataTemplate>
                <div align="center" class="CajaDialogoAdvertencia">
                <br/>
                <img src="../Imagenes/warning.gif" alt="No existen Tipos de Cambio para la fecha Especificada" />
                <br/>No existen registros<br/><br/>
                </div>
            </EmptyDataTemplate>
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
            <asp:Button ID="btnActualizar" runat="server" Text="Confirmar" Enabled ="true" OnClick="btnActualizar_Click" Visible="false" />
        </td>
    </tr>
         <tr>
             <td colspan ="4">
                 <asp:Panel runat="server"  ID="pnlMensaje" CssClass="panelceleste" HorizontalAlign="Center">
                    <table align="center" cellpadding="0" cellspacing="0" width="700px">
                        <tr>
                            <td align="center" colspan="2">
                                <h2><asp:Label ID="lblMensaje" runat="server"></asp:Label></h2>
                            </td>
                        </tr>
                        <tr>
                        <td>
                            <cc1:RoundedCornersExtender ID="RoundedCornersExtender3" runat="server"
                            Enabled="True" TargetControlID="pnlMensaje" Radius="10" BorderColor="Black">
                            </cc1:RoundedCornersExtender>
                            <cc1:ModalPopupExtender ID="ModalPopupExtender3pnlMensaje" runat="server" CancelControlID="btnAcepetar" TargetControlID="lblMensaje" PopupControlID="pnlMensaje" BackgroundCssClass="modalBackground" Enabled="True">
                            </cc1:ModalPopupExtender>
                        </td>
                        </tr>
                        <tr>
                        <td colspan="2" align="center">
                            <asp:Button CssClass="buttonRed" Text="Aceptar" runat="server" ID="btnAcepetar" />
                        </td>
                        </tr>
                    </table>
                </asp:Panel>
             </td>
         </tr>
    </table>
    <!------------->
</asp:Content>

