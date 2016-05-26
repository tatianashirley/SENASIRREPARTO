<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmDevoluciones.aspx.cs" Inherits="Notificaciones_wfrmDevoluciones" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1"%>


<%@ Register assembly="System.Web, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="System.Web.UI" tagprefix="cc2" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript" language="javascript">
        function checkAll(objRef) {
            var GridView = objRef.parentNode.parentNode.parentNode;
            var inputList = GridView.getElementsByTagName("input");
            for (var i = 0; i < inputList.length; i++) {
                //Get the Cell To find out ColumnIndex
                var row = inputList[i].parentNode.parentNode;
                if (inputList[i].type == "checkbox" && objRef != inputList[i]) {
                    if (objRef.checked) {
                        inputList[i].checked = true;
                    }
                    else {
                        inputList[i].checked = false;
                    }
                }
            }
        }
    </script>
    <!-- AQUI VA EL CODIGO-->
  
        <table id="Table1" runat="server" align="left">
                        <tr>
                <td align ="center">
                    <asp:ImageButton ID="imgAux" runat="server" ImageUrl="~/Imagenes/16w.png" />
                <asp:Label ID="lblTituloAUX" runat="server"
                    Text="Devolucion de Formularios de Compension de Cotizaciones"
                    CssClass="etiqueta20"></asp:Label></td>
            </tr>
                    <tr>
                         <td align="left" colspan="6">
                            <asp:Label runat ="server" ID="lblDev" Text="REGISTRO DE DEVOLUCION DE FORMULARIOS CC..." Font-Names="Arial" Font-Size="9pt" Font-Bold="true"></asp:Label> </td>
                     </tr>
                     <tr>
                         <td width="100%" align="center" colspan="7">
                            <asp:GridView ID="gvDatos" runat="server" CellPadding="4" 
                                Font-Names="Arial" 
                                 Font-Size="9pt" 
                                 CssClass="mGrid" ForeColor="#333333" AutoGenerateColumns="False" Visible="False" DataKeyNames="IdTramite,IdGrupoBeneficio,IdDocumento,FechaDocumento,NroDocumento">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:BoundField DataField="IdTramite" HeaderText="IdTramite" Visible="false"/>
                                    <asp:BoundField DataField="IdGrupoBeneficio" HeaderText="GrupoBeneficio" Visible="false"/>
                                    <asp:BoundField DataField="IdDocumento" HeaderText="IdDocumento" Visible="false"/>
                                    <asp:BoundField DataField="DescripcionDocumento" HeaderText="Documento" />
                                    <asp:BoundField DataField="FechaDocumento" HeaderText="Fecha del Documento" />
                                    <asp:BoundField DataField="NroDocumento" HeaderText="Nro de Documento" />
                                    <asp:BoundField DataField="CiteDescripcion" HeaderText="CITE" />
                                    <asp:BoundField DataField="FechaCite" HeaderText="Fecha del CITE" />
                                    <asp:BoundField DataField="FechaEnvio" HeaderText="Fecha de Envío" />
                                    <asp:BoundField DataField="FechaRecepcion" HeaderText="Fecha Recepción" />
                                    <asp:TemplateField ControlStyle-Height="16" ItemStyle-Width="5px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                <HeaderTemplate>
                                                <asp:CheckBox ID="chkTodos" runat="server" onclick = "checkAll(this);"  Visible="true"/>
                                            </HeaderTemplate>    
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkRecepcion" runat="server" Visible="true"/>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    <div align="center" class="CajaDialogoAdvertencia">
                                    <br/>
                                    <img src="../Imagenes/warning.gif" alt="No existen pagos que correspondan al criterio especificado" />
                                    <br/>No existen datos que correspondan al criterio especificado<br/><br/>
                                    </div>
                                </EmptyDataTemplate>
                                <EditRowStyle BackColor="#999999" />
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#0066CC" Font-Bold="True" ForeColor="#CCFFFF" />
                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                            </asp:GridView>
                        </td>
                     </tr>
     <tr>
                <td width="100%" align="left" colspan="7">
                    <asp:LinkButton runat="server" ID="lnkmas" Text="ULTIMOS DOCUMENTOS DEVUELTOS" OnClick="lnkmas_Click"></asp:LinkButton></td>
            </tr>
            <tr>
                <td width="100%" align="center" colspan="7">
                    <asp:GridView ID="gvDevolucion" runat="server" 
                        Font-Names="Arial" 
                        Font-Size="9pt" 
                          CssClass="mGrid"
                        CellPadding="4" ForeColor="#333333" AutoGenerateColumns="False" Visible="False" DataKeyNames="">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:BoundField DataField="TipoDocumento" HeaderText="Documento" />
                                    <asp:BoundField DataField="FechaDocumento" HeaderText="Fecha del Documento" />
                                    <asp:BoundField DataField="NroDocumento" HeaderText="Nro de Documento" />
                                    <asp:BoundField DataField="FechaRegistroSistema" HeaderText="Fecha de Registro" />
                                    <asp:BoundField DataField="CiteDescripcion" HeaderText="CITE" />
                                    <asp:BoundField DataField="FechaCite" HeaderText="Fecha del CITE" />
                                    <asp:BoundField DataField="FechaEnvio" HeaderText="Fecha de Envío" />
                                    <asp:BoundField DataField="CiteDev" HeaderText="Cite DEvolución" />
                                    <asp:BoundField DataField="FecCiteDev" HeaderText="Fecha CITE de Devolución" />
                                </Columns>
                                <EmptyDataTemplate>
                                    <div align="center" class="CajaDialogoAdvertencia">
                                    <br/>
                                    <img src="../Imagenes/warning.gif" alt="No existen pagos que correspondan al criterio especificado" />
                                    <br/>No existen datos que correspondan al criterio especificado<br/><br/>
                                    </div>
                                </EmptyDataTemplate>
                                <EditRowStyle BackColor="#999999" />
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#0066CC" Font-Bold="True" ForeColor="#CCFFFF" />
                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                            </asp:GridView></td>
            </tr>
            <tr align="center">

                <td align="center" colspan="6">

                <asp:Panel ID="pnlRecepcionar" runat="server" CssClass="panelceleste"  HorizontalAlign="Center" Width="500px">
                    <div>
                        <asp:Label ID="lblRecepcion" runat="server" Text="Devolver Documento(s)"
                            Font-Size="12pt" Font-Underline="True" Font-Names="Arial" ForeColor="#6699ff"></asp:Label>
                        <table style="width: 80%;">
                           
   
                            <tr>
                                <td colspan="2"></td>
                            </tr>

                              <tr>
                                <td align="right" class="auto-style5">
                                    <asp:Label ID="lblCiteDev" runat="server" Text="CITE de Devolución:" Font-Names="Arial" Font-Size="9pt"></asp:Label>
                                </td><td align="left" class="auto-style5">
                                   <asp:TextBox ID="txtCiteDev" runat="server" Font-Names="Arial" Font-Size="9pt"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCiteDev" ErrorMessage="RequiredFieldValidator" SetFocusOnError="true"
                                        Font-Size="9pt" Font-Names="Arial" ValidationGroup="ValDevolucion">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>

                            <tr>
                                <td></td>
                            </tr>

                            <tr>
                                <td align="right" class="auto-style5">
                                    <asp:Label ID="lblFechaCiteDev" runat="server" Text="Fecha CITE de Devolución:" Font-Names="Arial" Font-Size="9pt"></asp:Label>
                                </td>
                                <td align="left"  class="auto-style5">
                                   <asp:TextBox ID="txtFEchaCiteDev" runat="server" Font-Names="Arial" Font-Size="9pt"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFEchaCiteDev" ErrorMessage="RequiredFieldValidator"
                                        Font-Size="9pt" Font-Names="Arial" ValidationGroup="ValDevolucion" SetFocusOnError="true">*</asp:RequiredFieldValidator>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" Enabled="True" FilterType="Numbers,Custom " TargetControlID="txtFEchaCiteDev" ValidChars="/">
                                    </cc1:FilteredTextBoxExtender>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtFEchaCiteDev" Display="Dynamic" ErrorMessage="dd/mm/aaaa" ValidationExpression="^([\d]{2})/([\d]{2})/([\d]{4})$"
                                        Font-Size="9pt" Font-Names="Arial" ValidationGroup="ValDevolucion" SetFocusOnError="true"></asp:RegularExpressionValidator>
                                   <%--<asp:ImageButton ID="imgCalendario1" runat="server" ImageUrl="~/Imagenes/pequeños/Calendar_32x32.png" Height="20px" Width="20px" />--%>
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy" PopupButtonID="txtFEchaCiteDev" 
                                    TargetControlID="txtFEchaCiteDev" CssClass="cal_Theme1"></cc1:CalendarExtender>
                                </td>
                            </tr>

                            <tr>
                                <td></td>
                            </tr>
                              <tr>
                                <td align="right" class="auto-style5">
                                    <asp:Label ID="lblFechaDevolucion" runat="server" Text="Fecha Devolución:" Font-Names="Arial" Font-Size="9pt"></asp:Label>
                                </td>
                                <td align="left"  class="auto-style5">
                                   <asp:TextBox ID="txtFechaDevolucion" runat="server" Font-Names="Arial" Font-Size="9pt"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtFechaDevolucion" ErrorMessage="RequiredFieldValidator"
                                        Font-Size="9pt" Font-Names="Arial" ValidationGroup="ValDevolucion" SetFocusOnError="true">*</asp:RequiredFieldValidator>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" Enabled="True" FilterType="Numbers,Custom " TargetControlID="txtFechaDevolucion" ValidChars="/">
                                    </cc1:FilteredTextBoxExtender>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtFechaDevolucion" Display="Dynamic" ErrorMessage="dd/mm/aaaa" ValidationExpression="^([\d]{2})/([\d]{2})/([\d]{4})$"
                                        Font-Size="9pt" Font-Names="Arial" ValidationGroup="ValDevolucion" SetFocusOnError="true"></asp:RegularExpressionValidator>
                                    <asp:CompareValidator id="cvtxtStartDate" runat="server" controltocompare="txtFEchaCiteDev" 
                                        cultureinvariantvalues="true" display="Dynamic" 
                                        enableclientscript="true" controltovalidate="txtFechaDevolucion"
                                        errormessage="La fecha de envìo no puede ser menor a la fecha del CITE"
                                         type="Date" setfocusonerror="true" operator="GreaterThanEqual" text="La fecha de envìo no puede ser menor a la fecha del CITE"
                                        Font-Size="9pt" Font-Names="Arial" ValidationGroup="ValDevolucion"/>
                                   <%--<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Imagenes/pequeños/Calendar_32x32.png" Height="20px" Width="20px" />--%>
                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" Format="dd/MM/yyyy" PopupButtonID="txtFechaDevolucion" 
                                    TargetControlID="txtFechaDevolucion" CssClass="cal_Theme1"></cc1:CalendarExtender>
                                </td>
                            </tr>

                            <tr>
                                <td></td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style5" valign="top">
                                    <asp:Label ID="lblObs1" runat="server" Text="Observación:" Font-Names="Arial" Font-Size="9pt"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtObsEnv" runat="server" TextMode="MultiLine" Rows="5" Columns="30"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right"  class="auto-style5"><asp:Button ID="btnCancelarRecepcion" runat="server" EnableTheming="True"
                                         Text="Cancelar"
                                        CssClass="boton150" />
                                </td>
                                <td align="center"  class="auto-style5">
                                    <asp:Button ID="btnAccionarRecepcion" runat="server"
                                        Text="Aceptar" CssClass="boton150" OnClick="btnAccionarRecepcion_Click" ValidationGroup ="ValDevolucion" CausesValidation="true"/>
                                    <cc1:ConfirmButtonExtender ID="btnGrabar_ConfirmButtonExtender" runat="server" TargetControlID="btnAccionarRecepcion" ConfirmText="¿Esta seguro de guardar la devolución?"> 
                                    </cc1:ConfirmButtonExtender>
                                </td>
                            </tr>
                        </table>

                    </div>
                </asp:Panel>
                <cc1:RoundedCornersExtender ID="pnlRecepcion_RoundedCornersExtender" runat="server"
                    Enabled="True" TargetControlID="pnlRecepcionar" Radius="10" BorderColor="Black">
                </cc1:RoundedCornersExtender>
                <cc1:ModalPopupExtender ID="pnlREcepcion_ModalPopupExtender" runat="server"
                    Enabled="True"
                    TargetControlID="lnbShow"
                    CancelControlID="btnCancelarRecepcion"
                    PopupControlID="pnlRecepcionar"
                    BackgroundCssClass="modalBackground">
                </cc1:ModalPopupExtender>
            </td>
            </tr>
            <tr><td align="center" colspan="6">
                <asp:ImageButton ID="imgbtnRecepcionar" runat="server" ToolTip="Registar Devolución de Documentos" ImageUrl="~/Imagenes/ZVarios/Reporte2.png" Width="50px" Height="50px" Visible="false" OnClick="imgbtnRecepcionar_Click">
                </asp:ImageButton>
                </td>
            </tr>
            <tr><td colspan="6"><asp:LinkButton ID="lnbShow" runat="server" style="display:none"></asp:LinkButton></td></tr>
                </table>

                
    
    <!-- AQUI VA EL CODIGO-->

</asp:Content>