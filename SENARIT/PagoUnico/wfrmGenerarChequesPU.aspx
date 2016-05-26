<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmGenerarChequesPU.aspx.cs" Inherits="PagoUnico_wfrmGenerarChequesPU" StylesheetTheme="Modal" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ MasterType VirtualPath="~/MasterPage.master"%>

<%@ Register assembly="System.Web, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="System.Web.UI" tagprefix="cc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript" language="javascript">

        var minimoCheck = 1;
        function checkAll(objRef) {
            var cont = 0;
            var gridviewAnul = objRef.parentNode.parentNode.parentNode;
            var inputList = gridviewAnul.getElementsByTagName("input");
            for (var i = 0; i < inputList.length; i++) {
                var row = inputList[i].parentNode.parentNode;
                if (inputList[i].type == "checkbox" && objRef != inputList[i]) {
                    if (objRef.checked) {
                        inputList[i].checked = true;
                        cont = inputList.length - 1;
                    }
                    else {
                        inputList[i].checked = false;
                        cont = 0;
                    }
                }
            }               
        }

    </script>

    <style type="text/css">
        .auto-style1 {
            width: 193px;
        }
        .auto-style2 {
            width: 132px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="pnlGral" align="center">
         <br />
         <table style="width:100%;" class="pnlBody">
                             <tr>
                                 <td>&nbsp;</td>
                                 <td>&nbsp;</td>
                                 <td style="width: 230px">&nbsp;</td>
                                 <td style="width: 150px">&nbsp;</td>
                                 <td>&nbsp;</td>
                                 <td style="width: 100px">&nbsp;</td>
                                 <td>&nbsp;</td>
                                 <td>&nbsp;</td>
                             </tr>
                             <tr>
                                 <td align="right" style="width: 200px">
                                     &nbsp;</td>
                                 <td align="right" style="width: 200px">
                                     <asp:Label ID="Label10" runat="server" Text="Año Proceso:"></asp:Label>
                                 </td>
                                 <td style="width: 230px" align="left">
                                     <asp:TextBox ID="txtAnio" runat="server" Width="40px"></asp:TextBox>
                                     <cc1:NumericUpDownExtender ID="txtAnio_NumericUpDownExtender" runat="server" BehaviorID="_content_txtAnio_NumericUpDownExtender" Maximum="2030" Minimum="1996" RefValues="" ServiceDownMethod="" ServiceDownPath="" ServiceUpMethod="" Tag="" TargetButtonDownID="" TargetButtonUpID="" TargetControlID="txtAnio" Width="90">
                                     </cc1:NumericUpDownExtender>
                                     <cc1:FilteredTextBoxExtender ID="txtAnio_FilteredTextBoxExtender" runat="server" BehaviorID="_content_txtAnio_FilteredTextBoxExtender" FilterType="Numbers" TargetControlID="txtAnio">
                                     </cc1:FilteredTextBoxExtender>
                                     <asp:RequiredFieldValidator ID="rfvtxtAnio" runat="server" ControlToValidate="txtAnio" ErrorMessage="*" InitialValue="1995"></asp:RequiredFieldValidator>
                                     <asp:RangeValidator ID="ravAnio" runat="server" ControlToValidate="txtAnio" ErrorMessage="Fuera de rango" MaximumValue="2030" MinimumValue="1996" Type="Integer"></asp:RangeValidator>
                                 </td>
                                 <td align="right" style="width: 150px">
                                     <asp:Label ID="Label2" runat="server" Text="Mes Proceso:"></asp:Label>
                                 </td>
                                 <td style="width: 200px" align="left">
                                     <asp:DropDownList ID="ddlMes" runat="server" CssClass="box">
                                         <asp:ListItem Value="Seleccione valor ...">Seleccione valor ...</asp:ListItem>
                                         <asp:ListItem Value="1">Enero</asp:ListItem>
                                         <asp:ListItem Value="2">Febrero</asp:ListItem>
                                         <asp:ListItem Value="3">Marzo</asp:ListItem>
                                         <asp:ListItem Value="4">Abril</asp:ListItem>
                                         <asp:ListItem Value="5">Mayo</asp:ListItem>
                                         <asp:ListItem Value="6">Junio</asp:ListItem>
                                         <asp:ListItem Value="7">Julio</asp:ListItem>
                                         <asp:ListItem Value="8">Agosto</asp:ListItem>
                                         <asp:ListItem Value="9">Septiembre</asp:ListItem>
                                         <asp:ListItem Value="10">Octubre</asp:ListItem>
                                         <asp:ListItem Value="11">Noviembre</asp:ListItem>
                                         <asp:ListItem Value="12">Diciembre</asp:ListItem>
                                     </asp:DropDownList>
                                     <asp:RequiredFieldValidator ID="rfvDdlMes" runat="server" ControlToValidate="ddlMes" ErrorMessage="*" InitialValue="Seleccione valor ..."></asp:RequiredFieldValidator>
                                 </td>
                                 <td align="right" style="width: 100px">
                                     <asp:Label ID="Label9" runat="server" Text="C31:"></asp:Label>
                                 </td>
                                 <td style="width: 200px" align="left">
                                     <asp:TextBox ID="txtC31" runat="server" CssClass="box" Enabled="False" Height="16px"></asp:TextBox>
                                 </td>
                                 <td style="width: 200px">
                                     &nbsp;</td>
                             </tr>
                             <tr>
                                 <td align="right" style="width: 200px">
                                     &nbsp;</td>
                                 <td align="right" style="width: 200px">
                                     &nbsp;</td>
                                 <td style="width: 230px">
                                     &nbsp;</td>
                                 <td align="right" style="width: 150px">
                                     &nbsp;</td>
                                 <td style="width: 200px">
                                     &nbsp;</td>
                                 <td align="right" style="width: 100px">
                                     &nbsp;</td>
                                 <td style="width: 200px">
                                     &nbsp;</td>
                                 <td style="width: 200px">
                                     &nbsp;</td>
                             </tr>
             </table>

         <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Width="978px">
             <cc1:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                 <HeaderTemplate>
                     Generar Cheques
                 </HeaderTemplate>
                 <ContentTemplate>
                     <div class="pnlPest">
                        <table style="width:100%;">
                            <tr>
                                <td>&nbsp;</td>
                                <td align="center" colspan="2"></td>
                                <td>&nbsp;</td>
                            </tr>   
                                        <tr>
                                            <td rowspan="3">&nbsp;</td>
                                            <td align="right" style="width: 600px">
                                                &nbsp;</td>
                                            <td align="left" rowspan="3">
                                                <asp:ImageButton ID="ibtnBuscarPeGenCheque" runat="server" AlternateText="Buscar Pendientes de Generar Cheque" ImageUrl="~/Imagenes/plomoBuscarPenGenCheque.png" OnClick="ibtnBuscarPeGenCheque_Click" />
                                                <asp:ImageButton ID="ibtnGenCheque" runat="server" AlternateText="Generar Cheque" Enabled="False" ImageUrl="~/Imagenes/plomoCheque.png" OnClick="ibtnGenCheque_Click" style="height: 67px" />
                                                <cc1:ConfirmButtonExtender ID="ibtnGenCheque_ConfirmButtonExtender" runat="server" TargetControlID="ibtnGenCheque" ConfirmText="¿Esta seguro de Generar los cheques?">
                                                </cc1:ConfirmButtonExtender>
                                            </td>
                                            <td rowspan="3">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="width: 600px">
                                                <asp:Label ID="Label11" runat="server" Text="Entidad Financiera:"></asp:Label>
                                            <asp:DropDownList ID="ddlEntFinan" runat="server" Width="249px" CssClass="box" Enabled="False">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvEntFinan" runat="server" ControlToValidate="ddlEntFinan" ErrorMessage="*" InitialValue="Seleccione valor ..." ValidationGroup="cheque"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="width: 600px">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td align="center" colspan="2">&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td align="center" colspan="2">
                                                  <asp:GridView ID="gvPendientes" runat="server" AutoGenerateColumns="False" BorderColor="#DADADA">
                                                   <HeaderStyle CssClass="cssHeaderImg" />
                                                    <Columns>
                                                        <asp:BoundField DataField="IdBeneficio" HeaderText="IdBeneficio" Visible="False" />
                                                        <asp:BoundField DataField="Descripcion" HeaderText="Clase Beneficio" />
                                                        <asp:BoundField DataField="NUPTitular" HeaderText="NUPTitular" Visible="False" />
                                                        <asp:BoundField DataField="NUP" HeaderText="NUP" Visible="False"/>
                                                        <asp:BoundField DataField="CI" HeaderText="Nº Documento"/>
                                                        <asp:BoundField DataField="NOMBRE" HeaderText="Nombre Completo" />
                                                        <asp:BoundField DataField="Tramite" HeaderText="Tramite" />
                                                        <asp:BoundField DataField="NroCerti" HeaderText="Certificado" />
                                                        <asp:BoundField DataField="PORCENTAJE" HeaderText="Porcentaje">
                                                        <ItemStyle HorizontalAlign="Right" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="MONTO" DataFormatString="{0:F2}" HeaderText="Monto [Bs.]">
                                                        <ItemStyle HorizontalAlign="Right" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="FechaCalculo" HeaderText="Fecha Cálculo" DataFormatString="{0:dd/MM/yyyy}" />
                                                    </Columns>
                                                    <EmptyDataTemplate>
                                                        <div align="center" class="CajaDialogoAdvertencia">
                                                            <br/>
                                                            <img src="../Imagenes/warning.gif" alt="No existen registros" />
                                                            <br/>
                                                            Bandeja de Cheques Pendientes de Generación vacía.
                                                            <br/>
                                                            <br/>
                                                        </div>
                                                    </EmptyDataTemplate>
                                                </asp:GridView>
                                            </td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td align="center" colspan="2">&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                    </table>  
                     </div>
                 </ContentTemplate>
             </cc1:TabPanel>
             <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                 <HeaderTemplate>
                     Anular Cheques
                 </HeaderTemplate>
                 <ContentTemplate>
                     <div class="pnlPest">
                         <table>
                             <tr>
                                 <td align="center" colspan="6">
                                     <asp:ImageButton ID="ibtnBuscar" runat="server" AlternateText="Buscar" ImageUrl="~/Imagenes/plomoBuscar.png" ValidationGroup="Anular" OnClick="ibtnBuscar_Click"/>
                                     <asp:ImageButton ID="ibtnAnularCheques" runat="server" AlternateText="Anular Cheques" Enabled="False" ImageUrl="~/Imagenes/plomoChequeAnulado.png" OnClick="ibtnAnularCheques_Click"/>
                                     <cc1:ConfirmButtonExtender ID="ibtnAnularCheques_confirmButtonExtender" runat="server" TargetControlID="ibtnAnularCheques" ConfirmText="¿Esta seguro de Anular los cheques?">
                                     </cc1:ConfirmButtonExtender>
                                 </td>
                             </tr>
                             <tr>
                                 <td align="center" colspan="6">&nbsp;</td>
                             </tr>
                             <tr>
                                 <td align="center" colspan="6">
                                     <asp:GridView ID="gvAnularCheque" runat="server" AutoGenerateColumns="False" BorderColor="#DADADA" DataKeyNames="NumeroCheque,NumeroBanco">
                                         <Columns>
                                             <asp:TemplateField>
                                                 <HeaderTemplate>
                                                     <asp:CheckBox ID="chkSelectAll" runat="server" onclick="checkAll(this);" />
                                                 </HeaderTemplate>
                                                 <ItemTemplate>
                                                     <asp:CheckBox ID="chkCheque" runat="server" AutoPostBack="true" /> 
                                                 </ItemTemplate>
                                                 <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="40px" />
                                             </asp:TemplateField>
                                             <asp:BoundField DataField="CLASEBENEFICIO" HeaderText="IdBeneficio" Visible="False" />
                                             <asp:BoundField DataField="NUP" HeaderText="NUP" Visible="False"/>
                                             <asp:BoundField DataField="CI" HeaderText="Nº Documento"/>
                                             <asp:BoundField DataField="NOMBRE" HeaderText="Nombre Completo" />
                                             <asp:BoundField DataField="NumeroCheque" HeaderText="Nº Cheque" />
                                             <asp:BoundField DataField="NumeroBanco" HeaderText="Nº Banco" />
                                             <asp:BoundField DataField="Debe" DataFormatString="{0:F2}" HeaderText="Debe [Bs.]">
                                             <ItemStyle HorizontalAlign="Right" />
                                             </asp:BoundField>
                                              <asp:BoundField DataField="Haber" DataFormatString="{0:F2}" HeaderText="Haber [Bs.]">
                                             <ItemStyle HorizontalAlign="Right" />
                                             </asp:BoundField>
                                             <asp:BoundField DataField="FechaEmision" HeaderText="FechaEmision" DataFormatString="{0:dd/MM/yyyy}" />
                                             <asp:BoundField DataField="ESTADOCHEQUE" HeaderText="Estado" />
                                         </Columns>
                                         <EmptyDataTemplate>
                                             <div align="center" class="CajaDialogoAdvertencia">
                                                 <br/>
                                                 <img src="../Imagenes/warning.gif" alt="No existen registros" />
                                                 <br/>
                                                 Bandeja de Cheques Generados vacía.
                                                 <br/>
                                                 <br/>
                                             </div>
                                         </EmptyDataTemplate>
                                         <HeaderStyle CssClass="cssHeaderImg" />
                                     </asp:GridView>
                                 </td>
                             </tr>
                             <tr>
                                 <td>&nbsp;</td>
                                 <td>&nbsp;</td>
                                 <td>&nbsp;</td>
                                 <td>&nbsp;</td>
                                 <td>&nbsp;</td>
                                 <td>&nbsp;</td>
                             </tr>
                         </table>
                     </div>
                 </ContentTemplate>
             </cc1:TabPanel>
         </cc1:TabContainer>
         <asp:Panel ID="pnlDatos" runat="server" CssClass="pnlBody">
             
         </asp:Panel>
     </div>
        
            

</asp:Content>

