<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmControlDeudas.aspx.cs" Inherits="Convenios_wfrmControlDeudas" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register assembly="System.Web, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="System.Web.UI" tagprefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            height: 64px;
        }
        .auto-style2 {
            height: 64px;
            width: 137px;
        }
        .auto-style3 {
            width: 137px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <!--PLANTILLA -->
    <table>
        <tr>
            <td colspan ="4" align="center">
               <asp:Label ID="lblTituloAUX" runat="server"
                    Text="CONTROL DE PAGO DE LA DEUDA" CssClass="etiqueta20" Font-Size="16pt"></asp:Label>
            </td>
        </tr>
                                        <tr>
                                   <td class="auto-style1">Fecha Inicio:</td>
                                 <td class="auto-style1" >
                                  <asp:TextBox ID="txtFechaInicio" runat="server" MaxLength="10"></asp:TextBox>
                                     <asp:Image ID="imgCalendarioInicio" runat="server" Height="25px" ImageUrl="~/Imagenes/32calendario.png" Width="25px" ImageAlign="Top" Style="cursor:pointer"/>
                                  <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtFechaInicio" ID="RegularExpressionValidator9" ValidationExpression = "^\d{1,4}\-\d{1,2}\-\d{1,2}$" runat="server" ErrorMessage="Formato de Fecha Incorrecta"></asp:RegularExpressionValidator>
                                  <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" 
							         runat="server" FilterType="Custom, Numbers"
							          TargetControlID="txtFechaInicio" ValidChars="-">
					                </cc1:FilteredTextBoxExtender>  
                 
                                   
                                    <cc1:CalendarExtender ID="CalendarExtender8" runat="server" Enabled="True" TargetControlID="txtFechaInicio" PopupButtonID="imgCalendarioInicio"
													    Format="yyyy-MM-dd" CssClass="cal_Theme1"></cc1:CalendarExtender> 
                                  </td>
                                     <td class="auto-style2">
                                      Fecha Fin:
                                      </td>
                                    <td class="auto-style1" colspan="2">
                                      <asp:TextBox ID="txtFechaFin" runat="server"></asp:TextBox>
                                        <asp:Image ID="imgCalendarioFin" runat="server" Height="25px" ImageUrl="~/Imagenes/32calendario.png" Width="25px" ImageAlign="Top" Style="cursor:pointer"/>
                                   <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtFechaFin" ID="RegularExpressionValidator1" ValidationExpression = "^\d{1,4}\-\d{1,2}\-\d{1,2}$" runat="server" ErrorMessage="Formato de Fecha Incorrecta"></asp:RegularExpressionValidator>
                                  <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" 
							         runat="server" FilterType="Custom, Numbers"
							          TargetControlID="txtFechaFin" ValidChars="-">
					                </cc1:FilteredTextBoxExtender>  
                                        
                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" TargetControlID="txtFechaFin" PopupButtonID="imgCalendarioFin"
													    Format="yyyy-MM-dd" CssClass="cal_Theme1"></cc1:CalendarExtender> 

                                      </td>
                                </tr>
        <tr>
            <td>
                Elija el Periodo
            </td>
            <td>
                Año
                <asp:DropDownList ID="ddlAnio" runat="server" Width="80px">
    			</asp:DropDownList>
            </td>
            <td class="auto-style3">
                Tipo
                <asp:DropDownList ID="ddTipo" runat="server" Width="80px">
    			</asp:DropDownList>
            </td>
             <td>
                Tipo Convenio
                <asp:DropDownList ID="ddlTipoConvenio" runat="server" Width="200px">
    			</asp:DropDownList>
            </td>
            <td>
                 <asp:Button ID="btnAceptar" runat="server" Text="Ver Casos"  Width="87px" Visible="true" OnClick="btnAceptar_Click"/>
                 <asp:Button ID="btnVolver" runat="server" Text="Volver"  Width="87px" Visible="false" OnClick="btnVolver_Click" />
            </td>
        </tr>
        <tr>
           <td colspan="5">
               <asp:Panel ID="pnlConvenio" runat="server" Visible="true"  style="overflow-x:scroll; " Width="1150px" >
               <table>
                <tr>
                    <td>
                      
                        <asp:GridView ID="gvControl" runat="server" AutoGenerateColumns="False" AllowPaging="True" CellPadding="4" Font-Size="7pt" ForeColor="#333333"  OnPageIndexChanging="gvControl_PageIndexChanging" OnRowCommand="gvControl_RowCommand" >
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:BoundField DataField="Nombre" HeaderText="NOMBRE" />
                                <asp:BoundField DataField="CUA" HeaderText="CUA" />
                                <asp:BoundField DataField="FechaRegistroDeuda" HeaderText="AÑIO-CONVENIO" />
                                <asp:BoundField DataField="NumeroLiquidacion" HeaderText="NUMERO-DE-LIQUIDACION" />
                                <asp:BoundField DataField="Regional" HeaderText="REGIONAL" />
                                <asp:BoundField DataField="NUPAsegurado" HeaderText="NUP" />
                                <asp:BoundField DataField="IdCuota" HeaderText="CUOTA" />
                                <asp:BoundField DataField="TipoPago" HeaderText="TIPOPAGO" />
                                <asp:BoundField DataField="Periodo" HeaderText="PERIODO" />
                                <asp:BoundField DataField="PeriodoRealizoDeposito" HeaderText="PERIODO-REALIZO-DEPOSITO" />
                                <asp:BoundField DataField="MontoBsHaber" HeaderText="MONTO-COUTA" />
                                <asp:BoundField DataField="MontoDepositoRealizado" HeaderText="MONTO-DEPOSITADO" />
                                <asp:BoundField DataField="NumeroDeposito" HeaderText="NUMERO-DEPOSITO" />
                                <asp:BoundField DataField="TipoMoneda" HeaderText="TIPO-MONEDA" />
                                <asp:BoundField DataField="NombreCuenta" HeaderText="CUENTA" />
                                <asp:BoundField DataField="CuentaUsuario" HeaderText="USUARIO-REGISTRADO" />
                                <asp:BoundField DataField="FechaRegistroDeposito" HeaderText="FECHA-REGISTRO-DEPOSITO" />
                                <asp:BoundField DataField="TipoDeuda" HeaderText="TIPO-DEUDA" />
                                <asp:BoundField DataField="SaldoDeuda" HeaderText="SALDO-DEUDA" />
                                <asp:BoundField DataField="ESTADO" HeaderText="ESTADO" />
                                <asp:ButtonField CommandName="cmdDetalle" Text="Detalle" />

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
                            <PagerSettings FirstPageImageUrl="~/Imagenes/16anterior.png" LastPageImageUrl="~/Imagenes/32siguiente.png" NextPageImageUrl="~/Imagenes/Pages/next.png" PreviousPageImageUrl="~/Imagenes/Pages/previous.png" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView>
                        <br/>
                        <asp:Button ID="btnExportar" runat="server" Text="Exportar"  Width="120px" Visible="false" OnClick="btnExportar_Click"/>
                      
                    </td>
                </tr>
           </table>
       </asp:Panel>
           </td> 
        </tr>
       <tr>
           <td colspan="4">
               <asp:Panel ID="PnlDetalle" runat="server" Visible="false">
               <table>
                <tr>
                    <td align="center">
                        <asp:Label ID="lblSubTitulo" runat="server" Font-Bold="True" ForeColor="#CC0000" Font-Size="17px" Visible="false">Detalle del Deposito</asp:Label>
                    </td>
                </tr>
                <tr>    
                    <td>
                        <div style="height:600px; width:100%;overflow:scroll ">
                        <asp:GridView ID="gvDetalle" runat="server" AutoGenerateColumns="False" AllowPaging="True" CellPadding="4" Font-Size="7pt" ForeColor="#333333" OnPageIndexChanging="gvDetalle_PageIndexChanging" OnRowDataBound="gvDetalle_RowDataBound">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:BoundField DataField="Nombre" HeaderText="NOMBRE" />
                                <asp:BoundField DataField="CUA" HeaderText="CUA" />
                                <asp:BoundField DataField="FechaRegistroDeuda" HeaderText="AÑIO-CONVENIO" />
                                <asp:BoundField DataField="NumeroLiquidacion" HeaderText="NUMERO-DE-LIQUIDACION" />
                                <asp:BoundField DataField="Regional" HeaderText="REGIONAL" />
                                <asp:BoundField DataField="NUPAsegurado" HeaderText="NUP" />
                                <asp:BoundField DataField="IdCuota" HeaderText="CUOTA" />
                                <asp:BoundField DataField="TipoPago" HeaderText="TIPOPAGO" />
                                <asp:BoundField DataField="Periodo" HeaderText="PERIODO" />
                                <asp:BoundField DataField="PeriodoRealizoDeposito" HeaderText="PERIODO-REALIZO-DEPOSITO" />
                                <asp:BoundField DataField="MontoBsHaber" HeaderText="MONTO-COUTA" />
                                <asp:BoundField DataField="MontoDepositoRealizado" HeaderText="MONTO-DEPOSITADO" />
                                <asp:BoundField DataField="NumeroDeposito" HeaderText="NUMERO-DEPOSITO" />
                                <asp:BoundField DataField="TipoMoneda" HeaderText="TIPO-MONEDA" />
                                <asp:BoundField DataField="NombreCuenta" HeaderText="CUENTA" />
                                <asp:BoundField DataField="CuentaUsuario" HeaderText="USUARIO-REGISTRADO" />
                                <asp:BoundField DataField="FechaRegistroDeposito" HeaderText="FECHA-REGISTRO-DEPOSITO" />
                                <asp:BoundField DataField="ESTADO" HeaderText="ESTADO" />
                      
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
                            <PagerSettings FirstPageImageUrl="~/Imagenes/16anterior.png" LastPageImageUrl="~/Imagenes/32siguiente.png" NextPageImageUrl="~/Imagenes/Pages/next.png" PreviousPageImageUrl="~/Imagenes/Pages/previous.png" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView>
                        <br/>
                        <asp:Button ID="Button1" runat="server" Text="Exportar"  Width="120px" Visible="false" OnClick="btnExportar_Click"/>
                        </div>

                    </td>
                </tr>
           </table>
            </asp:Panel>
           </td> 
        </tr>

    </table>
     <!------------->
</asp:Content>