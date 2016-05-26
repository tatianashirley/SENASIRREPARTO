<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmRecepciones.aspx.cs" Inherits="Notifiaciones_wfrmRecepciones" %>
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
                    Text="Recepcion de Formularios de Compension de Cotizaciones"
                    CssClass="etiqueta20"></asp:Label></td>
            </tr>
                    <tr>
                         <td align="left" colspan="6">
                             <asp:Label runat="server" ID ="lblRecepcionar" Text="Por Recepcionar:..." Visible="false" Font-Names="Arial" Font-Size="9pt" Font-Bold="true"></asp:Label></td>
                     </tr>
                     <tr>
                         <td width="100%" align="center" colspan="7">
                            <asp:GridView ID="gvDatos" runat="server" CellPadding="4" 
                                Font-Names="Arial" 
                                 Font-Size="9pt" 
                                 CssClass="mGrid" ForeColor="#333333" AutoGenerateColumns="False" Visible="False" DataKeyNames="IdTramite,IdGrupoBeneficio,FechaDocumento,NroDocumento,IdDocumento">
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
                <td align="left"><asp:Label runat="server" Text="Documentos Recepcionados" Visible="false" ID="lblRecepcionados" Font-Names="Arial" Font-Size="9pt" Font-Bold="true"></asp:Label></td>
            </tr>
     <tr>
                <td width="100%" align="left" colspan="7">
                    <asp:GridView ID="gvDatosRec" runat="server" CellPadding="4" 
                        Font-Names="Arial" 
                        Font-Size="9pt" 
                        CssClass="mGrid"
                        ForeColor="#333333" AutoGenerateColumns="False" Visible="False" DataKeyNames="">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:BoundField DataField="TipoDocumento" HeaderText="Documento" />
                                    <asp:BoundField DataField="FechaDocumento" HeaderText="Fecha del Documento" />
                                    <asp:BoundField DataField="NroDocumento" HeaderText="Nro de Documento" />
                                    <asp:BoundField DataField="FechaRegistroSistema" HeaderText="Fecha de Registro" />
                                    <asp:BoundField DataField="DescripcionCite" HeaderText="CITE" />
                                    <asp:BoundField DataField="FechaCite" HeaderText="Fecha del CITE" />
                                    <asp:BoundField DataField="FechaEnvio" HeaderText="Fecha de Envío" />
                                    <asp:BoundField DataField="UsuarioDestino" HeaderText="Funcionario" />
                                    <asp:BoundField DataField="FechaRecepcion" HeaderText="Fecha Recepción" />
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
                        <asp:Label ID="lblRecepcion" runat="server" Text="Recepcionar Documento(s)"
                            Font-Size="12pt" Font-Underline="True" Font-Names="Arial" ForeColor="#6699ff"></asp:Label>
                        <table style="width: 80%;">
                           
                           
                            <tr>
                                <td colspan="2"></td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style5">
                                    <asp:Label ID="lblFechaRecepcion" runat="server" Text="Fecha de Recepcion:" Font-Names="Arial" Font-Size="9pt"></asp:Label>

                                   <asp:TextBox ID="txtFechaRecepcion" runat="server" Width="100px" Font-Names="Arial" Font-Size="9pt"></asp:TextBox>
                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFechaRecepcion" ErrorMessage="RequiredFieldValidator"
                                       Font-Size="9pt" Font-Names="Arial" ValidationGroup="ValRecepcion">*</asp:RequiredFieldValidator>
                                   <%--<asp:ImageButton ID="imgCalendario1" runat="server" ImageUrl="~/Imagenes/pequeños/Calendar_32x32.png" Height="20px" Width="20px" />--%>
                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" Format="dd/MM/yyyy" PopupButtonID="txtFechaRecepcion" 
                                    TargetControlID="txtFechaRecepcion" CssClass="cal_Theme1"></cc1:CalendarExtender>
                                </td>
                            </tr>
                            
                            <tr>
                                <td></td>
                            </tr>
                                                        <tr>
                                <td></td>
                            </tr>
                            <tr>
                                <td align="center"><asp:Button ID="btnCancelarRecepcion" runat="server" EnableTheming="True"
                                         Text="Cancelar"
                                        CssClass="boton150" />
                                
                                    <asp:Button ID="btnAccionarRecepcion" runat="server"
                                        Text="Aceptar" CssClass="boton150" OnClick="btnAccionarRecepcion_Click" CausesValidation="true" ValidationGroup="ValRecepcion"/>
                                    <cc1:ConfirmButtonExtender ID="btnGrabar_ConfirmButtonExtender" runat="server" TargetControlID="btnAccionarRecepcion" ConfirmText="¿Esta seguro de guardar la recepción?"> 
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
                    TargetControlID="lnkPop"
                    CancelControlID="btnCancelarRecepcion"
                    PopupControlID="pnlRecepcionar"
                    BackgroundCssClass="modalBackground">
                </cc1:ModalPopupExtender>
            </td>
            </tr>
            <tr><td align="center" colspan="6">
                <asp:ImageButton ID="imgbtnRecepcionar" runat="server" ToolTip="Registar Recepcion de Documentos" ImageUrl="~/Imagenes/ZVarios/notificar.png" Width="50px" Height="50px" OnClick="imgbtnRecepcionar_Click" Visible="false">
                </asp:ImageButton>
                </td>
            </tr>
            <tr>
                <td align="left" colspan="6"><asp:LinkButton runat="server" Text="Ir a Notificación" OnClick="Unnamed1_Click" Visible="false"></asp:LinkButton></td>
            </tr>
            <tr><td align="center" colspan="6">
                <asp:Button ID="lnkPop" runat="server" Text="MRLBJE" style="display:none"></asp:Button>
                </td>
            </tr>
                </table>

                
    
    <!-- AQUI VA EL CODIGO-->

</asp:Content>