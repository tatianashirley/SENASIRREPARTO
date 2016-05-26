<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmCargarArchivo.aspx.cs" Inherits="ControlInventario_wfrmCargarArchivo" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register assembly="System.Web, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="System.Web.UI" tagprefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!--PLANTILLA -->

    <table  width="100%">
         <tr>
            <td>        
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                 <asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label>
                                 <asp:FileUpload ID="FileUploadToServer" runat="server" />
                             <asp:Button ID="btnUpload" Text="Upload" runat="server" OnClick="btnUpload_Click" />
                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="btnUpload" />
                            </Triggers>
                  </asp:UpdatePanel>
                <asp:Button ID="btnBuscar" runat="server" Text="Ejecutar" Width="100px" OnClick="btnBuscar_Click"/>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="grvBatchUpload" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td width="100%" align="center" style="background-color:#5D7B9D;" >
                <FONT COLOR="white">
              <h3> REGISTRADOS EN ARCHIVO CENTRAL</h3> 
            </td>
        </tr>
        <tr>
             <td width="100%" align="center">
               <div style="overflow-x:scroll;" Width="100%">
                <asp:Label ID="lbl1" runat="server" Text=""> </asp:Label>
                <asp:GridView ID="gvUbicacion" runat="server" CellPadding="4" ForeColor="#0000ff" AutoGenerateColumns="False" Font-Size="10pt" AllowPaging="true" OnPageIndexChanging="gvUbicacion_PageIndexChanging">
                           
                           <AlternatingRowStyle BackColor="White" ForeColor="#284775"  HorizontalAlign="Center" />
                           <Columns>
                                <asp:BoundField DataField="NUMERO" HeaderText="NUMERO"  />
                                <asp:BoundField DataField="TRAMITE" HeaderText="TRAMITE" />
                                <asp:BoundField DataField="CERTIFICADO" HeaderText="CERTIFICADO" />
                                <asp:BoundField DataField="PATERNO" HeaderText="PATERNO" />
                                <asp:BoundField DataField="MATERNO" HeaderText="MATERNO" />
                                <asp:BoundField DataField="NOMBRES" HeaderText="NOMBRES" />
                                <asp:BoundField DataField="PROCEDIMIENTO" HeaderText="PROCEDIMIENTO"/>
                                <asp:BoundField DataField="DEPTO_DE_DESTINO" HeaderText="DEPTO_DE_DESTINO" />
                                <asp:BoundField DataField="Nave" HeaderText="Nave" />
                                <asp:BoundField DataField="Estante" HeaderText="Estante" />
                                <asp:BoundField DataField="CodigoCaja" HeaderText="ModificadorCodigoCaja" />
                                <asp:BoundField DataField="CajaHistorica" HeaderText="CajaHistorica" />
                                <asp:BoundField DataField="CodigoDigitalizacion" HeaderText="CodigoDigitalizacion" />
                             </Columns>
                            <EmptyDataTemplate>
                                <div align="center" class="CajaDialogoAdvertencia">
                                <br/>
                                <img src="../Imagenes/warning.gif" alt="El asegurado no cuenta con derechohabientes" />
                                <br/>No existe historial del Archivo<br/><br/>
                                </div>
                            </EmptyDataTemplate>
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                            
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333"  HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView>

                           <asp:GridView ID="gvUbicacion1" runat="server" CellPadding="4" ForeColor="#0000ff" AutoGenerateColumns="False" Font-Size="10pt" visible ="false">
                           
                           <AlternatingRowStyle BackColor="White" ForeColor="#284775"  HorizontalAlign="Center" />
                           <Columns>
                                <asp:BoundField DataField="NUMERO" HeaderText="NUMERO"  />
                                <asp:BoundField DataField="TRAMITE" HeaderText="TRAMITE" />
                                <asp:BoundField DataField="CERTIFICADO" HeaderText="CERTIFICADO" />
                                <asp:BoundField DataField="PATERNO" HeaderText="PATERNO" />
                                <asp:BoundField DataField="MATERNO" HeaderText="MATERNO" />
                                <asp:BoundField DataField="NOMBRES" HeaderText="NOMBRES" />
                                <asp:BoundField DataField="PROCEDIMIENTO" HeaderText="PROCEDIMIENTO"/>
                                <asp:BoundField DataField="DEPTO_DE_DESTINO" HeaderText="DEPTO_DE_DESTINO" />
                                <asp:BoundField DataField="Nave" HeaderText="Nave" />
                                <asp:BoundField DataField="Estante" HeaderText="Estante" />
                                <asp:BoundField DataField="CodigoCaja" HeaderText="ModificadorCodigoCaja" />
                                <asp:BoundField DataField="CajaHistorica" HeaderText="CajaHistorica" />
                                <asp:BoundField DataField="CodigoDigitalizacion" HeaderText="CodigoDigitalizacion" />
                             </Columns>
                            <EmptyDataTemplate>
                                <div align="center" class="CajaDialogoAdvertencia">
                                <br/>
                                <img src="../Imagenes/warning.gif" alt="El asegurado no cuenta con derechohabientes" />
                                <br/>No existe historial del Archivo<br/><br/>
                                </div>
                            </EmptyDataTemplate>
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                            
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333"  HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView>

                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                        <asp:Button ID="btnExportarExcelUbicados" runat="server" Text="Exportar Excel" OnClick="btnExportarExcelUbicados_Click" onclientclick="return confirm('¿Esta Seguro de Exportar el documento?');" Visible="false"/>
                        </ContentTemplate>
                        <Triggers>
                            <asp:PostBackTrigger ControlID="btnExportarExcelUbicados" />
                        </Triggers>
                        </asp:UpdatePanel>
                   </div>
            </td>
        </tr>
                <tr>
            <td width="100%" align="center" style="background-color:#5D7B9D;" >
                <FONT COLOR="white">
              <h3> ARCHIVOS QUE ESTAN EN UN 430</h3> 
            </td>
        </tr>
        <tr>
             <td width="100%" align="center">
                 <asp:Label ID="lbl2" runat="server" Text=""> </asp:Label>
                <asp:GridView ID="gv430" runat="server" CellPadding="4" ForeColor="#0000ff" AutoGenerateColumns="False" Font-Size="10pt" AllowPaging="true" OnPageIndexChanging="gv430_PageIndexChanging">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775"  HorizontalAlign="Center" />
                            <Columns>
                                 <asp:BoundField DataField="NUMERO" HeaderText="NUMERO"  />
                                <asp:BoundField DataField="TRAMITE" HeaderText="TRAMITE" />
                                <asp:BoundField DataField="CERTIFICADO" HeaderText="CERTIFICADO" />
                                <asp:BoundField DataField="PATERNO" HeaderText="PATERNO" />
                                <asp:BoundField DataField="MATERNO" HeaderText="MATERNO" />
                                <asp:BoundField DataField="NOMBRES" HeaderText="NOMBRES" />
                                <asp:BoundField DataField="PROCEDIMIENTO" HeaderText="PROCEDIMIENTO"/>
                                <asp:BoundField DataField="DEPTO_DE_DESTINO" HeaderText="DEPTO_DE_DESTINO" />
                                <asp:BoundField DataField="Id430" HeaderText="Id430" />
                                </Columns>
                            <EmptyDataTemplate>
                                <div align="center" class="CajaDialogoAdvertencia">
                                <br/>
                                <img src="../Imagenes/warning.gif" alt="El asegurado no cuenta con derechohabientes" />
                                <br/>No existe historial del Archivo<br/><br/>
                                </div>
                            </EmptyDataTemplate>
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                            
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333"  HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView>

                           <asp:GridView ID="gv4301" runat="server" CellPadding="4" ForeColor="#0000ff" AutoGenerateColumns="False" Font-Size="10pt" Visible="false">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775"  HorizontalAlign="Center" />
                            <Columns>
                                 <asp:BoundField DataField="NUMERO" HeaderText="NUMERO"  />
                                <asp:BoundField DataField="TRAMITE" HeaderText="TRAMITE" />
                                <asp:BoundField DataField="CERTIFICADO" HeaderText="CERTIFICADO" />
                                <asp:BoundField DataField="PATERNO" HeaderText="PATERNO" />
                                <asp:BoundField DataField="MATERNO" HeaderText="MATERNO" />
                                <asp:BoundField DataField="NOMBRES" HeaderText="NOMBRES" />
                                <asp:BoundField DataField="PROCEDIMIENTO" HeaderText="PROCEDIMIENTO"/>
                                <asp:BoundField DataField="DEPTO_DE_DESTINO" HeaderText="DEPTO_DE_DESTINO" />
                                <asp:BoundField DataField="Id430" HeaderText="Id430" />
                                </Columns>
                            <EmptyDataTemplate>
                                <div align="center" class="CajaDialogoAdvertencia">
                                <br/>
                                <img src="../Imagenes/warning.gif" alt="El asegurado no cuenta con derechohabientes" />
                                <br/>No existe historial del Archivo<br/><br/>
                                </div>
                            </EmptyDataTemplate>
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                            
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333"  HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView>

                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                        <asp:Button ID="btnExportarExcel430" runat="server" Text="Exportar Excel" OnClick="btnExportarExcel430_Click" onclientclick="return confirm('¿Esta Seguro de Exportar el documento?');" Visible="false"/>
                        </ContentTemplate>
                        <Triggers>
                            <asp:PostBackTrigger ControlID="btnExportarExcel430" />
                        </Triggers>
                        </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td width="100%" align="center" style="background-color:#5D7B9D;" >
                <FONT COLOR="white">
              <h3> EXPEDIENTES EN OTRAS AREAS</h3> 
            </td>
        </tr>
        <tr>
            <td width="100%" align="center">
                <asp:Label ID="lbl3" runat="server" Text=""> </asp:Label>
                <asp:GridView ID="gvOtros" runat="server" CellPadding="4" ForeColor="#0000ff" AutoGenerateColumns="False" Font-Size="10pt" AllowPaging="true" OnPageIndexChanging="gvOtros_PageIndexChanging">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775"  HorizontalAlign="Center" />
                           <Columns>
                                <asp:BoundField DataField="NUMERO" HeaderText="NUMERO"  />
                                <asp:BoundField DataField="TRAMITE" HeaderText="TRAMITE" />
                                <asp:BoundField DataField="CERTIFICADO" HeaderText="CERTIFICADO" />
                                <asp:BoundField DataField="PATERNO" HeaderText="PATERNO" />
                                <asp:BoundField DataField="MATERNO" HeaderText="MATERNO" />
                                <asp:BoundField DataField="NOMBRES" HeaderText="NOMBRES" />
                                <asp:BoundField DataField="PROCEDIMIENTO" HeaderText="PROCEDIMIENTO"/>
                                <asp:BoundField DataField="DEPTO_DE_DESTINO" HeaderText="DEPTO_DE_DESTINO" />
                                <asp:BoundField DataField="AREA_ACTUAL" HeaderText="AREA_ACTUAL" />
                                </Columns>
                            <EmptyDataTemplate>
                                <div align="center" class="CajaDialogoAdvertencia">
                                <br/>
                                <img src="../Imagenes/warning.gif" alt="El asegurado no cuenta con derechohabientes" />
                                <br/>No existe historial del Archivo<br/><br/>
                                </div>
                            </EmptyDataTemplate>
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                            
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333"  HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView>
                <asp:GridView ID="gvOtros1" runat="server" CellPadding="4" ForeColor="#0000ff" AutoGenerateColumns="False" Font-Size="10pt" Visible="false">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775"  HorizontalAlign="Center" />
                           <Columns>
                                <asp:BoundField DataField="NUMERO" HeaderText="NUMERO"  />
                                <asp:BoundField DataField="TRAMITE" HeaderText="TRAMITE" />
                                <asp:BoundField DataField="CERTIFICADO" HeaderText="CERTIFICADO" />
                                <asp:BoundField DataField="PATERNO" HeaderText="PATERNO" />
                                <asp:BoundField DataField="MATERNO" HeaderText="MATERNO" />
                                <asp:BoundField DataField="NOMBRES" HeaderText="NOMBRES" />
                                <asp:BoundField DataField="PROCEDIMIENTO" HeaderText="PROCEDIMIENTO"/>
                                <asp:BoundField DataField="DEPTO_DE_DESTINO" HeaderText="DEPTO_DE_DESTINO" />
                                <asp:BoundField DataField="AREA_ACTUAL" HeaderText="AREA_ACTUAL" />
                                </Columns>
                            <EmptyDataTemplate>
                                <div align="center" class="CajaDialogoAdvertencia">
                                <br/>
                                <img src="../Imagenes/warning.gif" alt="El asegurado no cuenta con derechohabientes" />
                                <br/>No existe historial del Archivo<br/><br/>
                                </div>
                            </EmptyDataTemplate>
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                            
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333"  HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView>
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                        <ContentTemplate>
                        <asp:Button ID="btnExpotarAreas" runat="server" Text="Exportar Excel" OnClick="btnExpotarAreas_Click" onclientclick="return confirm('¿Esta Seguro de Exportar el documento?');" Visible="false"/>
                        </ContentTemplate>
                        <Triggers>
                            <asp:PostBackTrigger ControlID="btnExpotarAreas" />
                        </Triggers>
                        </asp:UpdatePanel>
            </td>
        </tr>

        </table>

    <!------------->
</asp:Content>