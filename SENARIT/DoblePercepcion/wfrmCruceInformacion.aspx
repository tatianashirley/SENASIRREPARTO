<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmCruceInformacion.aspx.cs" Inherits="DoblePercepcion_wfrmCruceInformacion" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
                                                        <!--DESDE AQUI SE PUDE PERSONALIZAR-->
    
    <div id="Div1" class="cuerpo_detalle" runat="server">
    <table aligin ="center">
            <tr>
                <td aligin="center">
                     <asp:Label ID="lblTituloAUX" runat="server"
                     Text="Cruce de Planillas" CssClass="etiqueta20" Font-Size="16pt"></asp:Label>
                </td>
            </tr>           
        <tr>
          <td>
                 <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                 Archivo: <asp:FileUpload ID="fulArchivo" runat="server"  />
                                 <br />  
                                  <asp:Label ID="Label1" runat="server" Text="Tipo de archivos soportados: .TXT" Font-Size="11px"> </asp:Label>
                                 <br/><br/>
                                <asp:Button ID="btnCarga" runat="server" onclick="btnEjecutar_Click" Text="Ejecutar Cruce"  onclientclick="return confirm('¿Esta Seguro de Ejecutar el Cruce?');" />
                                 
                                <asp:Button ID="btnCancelar" runat="server" Text="Limpiar" OnClick="btnCancelar_Click" />
                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="btnCarga" />
                            </Triggers>
                  </asp:UpdatePanel>
                          </td>
        </tr>
        <tr>
            <td colspan ="2">

                <asp:Label ID="lblMuestra" runat="server" Text=""> </asp:Label>
                <br />
                 <asp:Label ID="label" runat="server" Text=""> </asp:Label>
            </td>
        </tr>
    </table>
   </div>
    <div class="cuerpo_detalle">
        <table aligin ="center">
            <tr>
                <td>
                     <asp:Label ID="lblrsultado" runat="server">Resultados Obtenidos producto del Proceso Comparativo </asp:Label>
                </td>  
            </tr>
            <tr>
                <td>
                <asp:Panel ID="panCruce" runat="server" style="overflow-x:scroll; " Width="1150px" >
                <asp:GridView ID="gvCruce" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Size="9pt" ForeColor="#333333"  Visible="False" Width="80%" OnRowCreated="gvCruce_RowCreated">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />

                    <Columns>
                       <asp:BoundField DataField="Fila" HeaderText="Nro" ></asp:BoundField>
                        <asp:BoundField DataField="NUP" HeaderText="NUP"></asp:BoundField>
                        <asp:BoundField DataField="CUA" HeaderText="CUA"></asp:BoundField>
                        <asp:BoundField DataField="Matricula" HeaderText="MATRICULA" ></asp:BoundField>
                        <asp:BoundField DataField="NumeroDocumentoS" HeaderText="NRO DOC INST. EXTERNA" HeaderStyle-BackColor="#33ccff"></asp:BoundField>
                        <asp:BoundField DataField="PrimerApellidoS" HeaderText="1° APELLIDO INST. EXTERNA" HeaderStyle-BackColor="#33ccff"></asp:BoundField>                        
                        <asp:BoundField DataField="SegundoApellidoS" HeaderText="2° APELLIDO INST. EXTERNA" HeaderStyle-BackColor="#33ccff"></asp:BoundField>
                        <asp:BoundField DataField="NOMBRESS" HeaderText="NOMBRES INST. EXTERNA" HeaderStyle-BackColor="#33ccff"></asp:BoundField> 
                        <asp:BoundField DataField="Cargo" HeaderText="CARGO" HeaderStyle-BackColor="#33ccff"></asp:BoundField>
                        <asp:BoundField DataField="NumeroDocumento" HeaderText="NRO DOC SENASIR"></asp:BoundField>
                        <asp:BoundField DataField="PrimerApellido" HeaderText="1° APELLIDO SENASIR"></asp:BoundField>
                        <asp:BoundField DataField="SegundoApellido" HeaderText="2° APELLIDO SENASIR"></asp:BoundField>
                        <asp:BoundField DataField="NOMBRES" HeaderText="NOMBRES SENASIR"></asp:BoundField>
                        <asp:BoundField DataField="Estado" HeaderText="ESTADO"></asp:BoundField>
                        <asp:BoundField DataField="Beneficio" HeaderText="BENEFICIO"></asp:BoundField>
                        <asp:BoundField  DataField="Tipo" HeaderText="TIPO"></asp:BoundField>
                    </Columns>

                    <EmptyDataTemplate>
                        <div align="center" class="CajaDialogoAdvertencia">
                        <br/>
                        <img src="../Imagenes/warning.gif" alt="EL RESULTADO DEL PROCESO COMPARATIVO NO GENERÓ COINCIDENCIA" />
                        <br/>EL RESULTADO DEL PROCESO COMPARATIVO NO GENERÓ COINCIDENCIA<br/><br/>
                        </div>
                    </EmptyDataTemplate>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"  />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
                 </asp:Panel>
                </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbltexto" runat="server" Text="Tabla de Errores" Visible ="false"></asp:Label>
                        <asp:GridView ID="gvErrores" runat="server" CellPadding="4" EnableModelValidation="True" ForeColor="#333333" Font-Names="Arial Narrow" AllowPaging="True" Font-Size="10pt" style="margin-bottom: 0px" OnPageIndexChanging="gvErrores_PageIndexChanging" >
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerSettings FirstPageImageUrl="~/Imagenes/16anterior.png" LastPageImageUrl="~/Imagenes/32siguiente.png" NextPageImageUrl="~/Imagenes/Pages/next.png" PreviousPageImageUrl="~/Imagenes/Pages/previous.png" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        </asp:GridView>

                <td>
                </tr>
                  <tr>
                    <td aligin ="center">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                        <asp:Button ID="btnExportarExcel" runat="server" Text="Exportar Excel" OnClick="btnExportarExcel_Click1" onclientclick="return confirm('¿Esta Seguro de Exportar el documento?');" Visible="false"/>
                        <asp:Button ID="btnImprimir" runat="server" Text="Imprimir" OnClick="btnImprimir_Click" Visible="false" /> 
                        </ContentTemplate>
                        <Triggers>
                            <asp:PostBackTrigger ControlID="btnExportarExcel" />
                        </Triggers>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                <td>
                    <div ID="divReporte" aligin="center" Visible="true">
                        <asp:Panel ID="panReporte" runat="server" CssClass="panelceleste"  HorizontalAlign="Center" style="overflow-y:scroll;" Height="550px" Width="1100px" Visible="false">
                              <rsweb:ReportViewer ID="rtpInforme" runat="server"  Height="550px" Width="1100px" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Visible="false">
                              </rsweb:ReportViewer>
                        </asp:Panel>
                    </div>
                </td>   
                </tr>
            </table>
        </div>
                                            <!--HASTA AQUI -->
</asp:Content>

