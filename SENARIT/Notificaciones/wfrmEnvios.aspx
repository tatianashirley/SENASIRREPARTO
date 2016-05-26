<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmEnvios.aspx.cs" Inherits="Notificaciones_wfrmEnvios" %>
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
                <td align ="center" colspan="5">
                    <asp:ImageButton ID="imgAux" runat="server" ImageUrl="~/Imagenes/16w.png" />
                <asp:Label ID="lblTituloAUX" runat="server"
                    Text="Envio de Formularios de Compension de Cotizaciones"
                    CssClass="etiqueta20"></asp:Label></td>
            </tr>
            <tr>
            <td align="left" colspan="6">
               <%-- <asp:ImageButton ID="imgAux" runat="server" ImageUrl="~/Imagenes/w.png" />--%>
                <asp:Label ID="Label2" runat="server" 
                    Text="Datos del Beneficiario" CssClass="etiqueta20" Font-Bold="true" Font-Underline="true"></asp:Label>
            </td>
        </tr>
        <tr>
             <%--<td align="left"><asp:Label runat="server" Font-Names="Arial" Font-Size="9pt">Documento Identidad:</asp:Label></td>--%>
             <td align="left"><asp:Label runat="server" Font-Names="Arial" Font-Size="9pt">Fecha Nacimiento:</asp:Label></td>
             <td align="left"><asp:Label runat="server" Font-Names="Arial" Font-Size="9pt">Apellido Paterno:</asp:Label></td>
             <td align="left"><asp:Label runat="server" Font-Names="Arial" Font-Size="9pt">Apellido Materno:</asp:Label></td>
             <td align="left"><asp:Label runat ="server" Font-Names="Arial" Font-Size="9pt">Nombre(s):</asp:Label></td>
        </tr>
        <tr>
             <%--<td align="left">
                 <asp:TextBox ID="txtCIC" runat="server" Font-Names="Arial" Font-Size="9pt" Enabled="false"></asp:TextBox>                           
             </td>--%>
             <td align="left">
                <asp:TextBox ID="txtFechaNacC" runat="server" Font-Names="Arial" Font-Size="9pt" Enabled="false"></asp:TextBox>                           

                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtPaternoC" runat="server" Font-Names="Arial" Font-Size="9pt" Enabled="false"></asp:TextBox>                           
   
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtMaternoC" runat="server" Font-Names="Arial" Font-Size="9pt" Enabled="false"></asp:TextBox>                           
 
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtNombreC" runat="server" Font-Names="Arial" Font-Size="9pt" Enabled="false"></asp:TextBox>                           

                        </td>
                    </tr>
                    <tr>
                        <td align="left"><asp:Label ID="Label1" runat="server" Font-Names="Arial" Font-Size="9pt">Documento Identidad:</asp:Label></td>
                        <td align="left"><asp:Label runat="server" Font-Names="Arial" Font-Size="9pt">Trámite:</asp:Label></td>
                        <td align="left"><asp:Label runat="server" Font-Names="Arial" Font-Size="9pt">Matrícula:</asp:Label></td>
                        <%--<td align="left"><asp:Label runat="server" Font-Names="Arial" Font-Size="9pt">Dpto Actual:</asp:Label></td>--%>
                        <td align="left"><asp:Label runat="server" Font-Names="Arial" Font-Size="9pt">Regional:</asp:Label></td>   
                        <td align="left">&nbsp;</td>                     
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:TextBox ID="txtCIC" runat="server" Font-Names="Arial" Font-Size="9pt" Enabled="false"></asp:TextBox>                           
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtTramiteC" runat="server" Font-Names="Arial" Font-Size="9pt" Enabled="false"></asp:TextBox>                           

                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtMatriculaC" runat="server" Font-Names="Arial" Font-Size="9pt" Enabled="false"></asp:TextBox>                           

                        </td>
<%--                        <td align="left">
                            <asp:TextBox ID="txtDptoActual" runat="server" Font-Names="Arial" Font-Size="9pt" Enabled="false"></asp:TextBox>                           
                        </td>--%>
                        <td align="left">
                            <asp:TextBox ID="txtRegional" runat="server" Font-Names="Arial" Font-Size="9pt" Enabled="false"></asp:TextBox>                           

                        </td>
                        <td align="left">
                            &nbsp;</td>
                     </tr>
            <tr ><td colspan="6"><hr style="border-bottom-color:black"/></td></tr>  
                     <tr>   
                         <td align="left" colspan="6">
                             <asp:Label runat="server" ID ="lblRegional" Text="DOCUMENTOS LISTOS PARA ENVIO A REGIONALES" Visible="true"  CssClass="etiqueta20" Font-Bold="true" Font-Underline="true"></asp:Label></td>
                     </tr>
                     <tr>
                         <td width="100%" align="left" colspan="7">
                            <asp:GridView ID="gvEnvio" runat="server" CellPadding="4" ForeColor="#333333" BorderStyle="Solid"
                                Font-Names="Arial" 
                                 Font-Size="9pt" 
                                 CssClass="mGrid"
                                 AllowPaging="True"
                                 PagerStyle-CssClass="pgr"
                                 PageSize="20"
                                 OnPageIndexChanging="gvEnvio_PageIndexChanging"
                                 AutoGenerateColumns="False" Visible="False" DataKeyNames="NumeroDocumento,FechaDocumento,FechaNacimiento,NroDocumento,PrimerApellido,SegundoApellido,PrimerNombre,Matricula,Regional,IdTramite,IdGrupoBeneficio,IdDocumento,OfiNot"
                                 OnSelectedIndexChanged="gvDatos_SelectedIndexChanged">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775"/>
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" SelectText="Ver Detalle"/>
                                    <asp:BoundField DataField="OfiNot" HeaderText="OfiNot" Visible="false" />
                                    <asp:BoundField DataField="NumeroDocumento" HeaderText="CI" Visible="false" />
                                    <asp:BoundField DataField="FechaNacimiento" HeaderText="FechaNacimiento" Visible="false" />
                                    <asp:BoundField DataField="PrimerApellido" HeaderText="Paterno" Visible="false" />
                                    <asp:BoundField DataField="SegundoApellido" HeaderText="Materno" Visible="false" />
                                    <asp:BoundField DataField="PrimerNombre" HeaderText="Nombre" Visible="false" />
                                    <asp:BoundField DataField="Matricula" HeaderText="Matricula" Visible="false" />
                                    <asp:BoundField DataField="Regional" HeaderText="Regional" Visible="false" />
                                    <asp:BoundField DataField="IdTramite" HeaderText="Tramite" Visible="false" />
                                    <asp:BoundField DataField="IdGrupoBeneficio" HeaderText="GrupoBeneficio" Visible="false" />
                                    <asp:BoundField DataField="IdDocumento" HeaderText="TipoDoc" Visible="false" />
                                    <asp:BoundField DataField="DescripcionDocumento" HeaderText="Documento" />
                                    <asp:BoundField DataField="FechaDocumento" HeaderText="Fecha Documento" />
                                    <asp:BoundField DataField="NroDocumento" HeaderText="Nro Documento" />
                                    <asp:BoundField DataField="FechaRegistro" HeaderText="Fecha Registro" />
                                    <asp:TemplateField ControlStyle-Height="16"  ItemStyle-Width="5px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" Visible="true">
                                                <HeaderTemplate>
                                                <asp:CheckBox ID="chkTodos" runat="server" onclick = "checkAll(this);"  />
                                            </HeaderTemplate>    
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkEnvio" runat="server" />
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
                                <SelectedRowStyle BackColor="#66ffff" Font-Bold="True" ForeColor="#000000" />
                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                            </asp:GridView>
                        </td>
                     </tr>
            <tr><td colspan="6" align="left"><asp:LinkButton runat="server" Text="VER ULTIMO ENVIO" ID="lnkMas" OnClick="UltimoEnvio"></asp:LinkButton></td></tr>
            <tr><td align="left" colspan="6"><asp:GridView ID="gvUltEnvio" runat="server" CellPadding="4" ForeColor="#333333" BorderStyle="Solid"
                                Font-Names="Arial" 
                                 Font-Size="9pt" 
                                 CssClass="mGrid"
                                AutoGenerateColumns="False" Visible="False"  OnSelectedIndexChanged="gvDatos_SelectedIndexChanged">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775"/>
                                <Columns>
                                    <%--<asp:CommandField ShowSelectButton="True" SelectText="Ver Detalle"/>--%>
                                    <asp:BoundField DataField="NumeroDocumento" HeaderText="CI" Visible="false" />
                                    <asp:BoundField DataField="FechaNacimiento" HeaderText="FechaNacimiento" Visible="false" />
                                    <asp:BoundField DataField="PrimerApellido" HeaderText="Paterno" Visible="false" />
                                    <asp:BoundField DataField="SegundoApellido" HeaderText="Materno" Visible="false" />
                                    <asp:BoundField DataField="PrimerNombre" HeaderText="Nombre" Visible="false" />
                                    <asp:BoundField DataField="Matricula" HeaderText="Matricula" Visible="false" />
                                    <asp:BoundField DataField="Regional" HeaderText="Regional" Visible="false" />
                                    <asp:BoundField DataField="OfiNot" HeaderText="OfiNot" Visible="false" />
                                    <asp:BoundField DataField="IdTramite" HeaderText="Tramite" Visible="false" />
                                    <asp:BoundField DataField="IdGrupoBeneficio" HeaderText="GrupoBeneficio" Visible="false" />
                                    <asp:BoundField DataField="IdDocumento" HeaderText="TipoDoc" Visible="false" />
                                    <asp:BoundField DataField="DescripcionDocumento" HeaderText="Documento" />
                                    <asp:BoundField DataField="FechaDocumento" HeaderText="Fecha Documento" />
                                    <asp:BoundField DataField="NroDocumento" HeaderText="Nro Documento" />
                                    <asp:BoundField DataField="FechaRegistroSistema" HeaderText="Fecha Registro" />
                                    <asp:BoundField DataField="CiteDescripcion" HeaderText="CITE" />
                                    <asp:BoundField DataField="FechaCite" HeaderText="Fecha CITE" />
                                    <asp:BoundField DataField="FechaEnvio" HeaderText="Fecha Envío" />

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
                                <SelectedRowStyle BackColor="#66ffff" Font-Bold="True" ForeColor="#000000" />
                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                            </asp:GridView></td></tr>
     <tr>
                <td width="100%" align="center" colspan="7">
                    &nbsp;</td>
            </tr>
            <tr align="center">

                <td align="center" colspan="6">

                <asp:Panel ID="pnlEnvio" runat="server" CssClass="panelceleste"  HorizontalAlign="Center" Width="500px">
                    <div>
                        <asp:Label ID="lblNotificacion" runat="server" Text="Envío de Documentos"
                            Font-Size="12pt" Font-Underline="True" Font-Names="Arial" ForeColor="#6699ff"></asp:Label>
                        <table style="width: 80%;">
                            <tr>
                                <td></td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style5">
                                    <asp:Label ID="lblOficina" runat="server" Text="Oficina:" Font-Names="Arial" Font-Size="9pt"></asp:Label>
                                </td>
                                <td align="left" class="auto-style5">
                                    <asp:DropDownList ID="ddlOficina" runat="server" Width="150px" Font-Names="Arial" Font-Size="9pt"  OnTextChanged="ddlFuncionario_TextChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Font-Names="Arial" Font-Size="9pt" ControlToValidate="ddlOficina" ErrorMessage="RequiredFieldValidator" ValidationGroup="ValEnvio" setfocusonerror="true">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2"></td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style5">
                                    <asp:Label ID="lblCite" runat="server" Text="CITE Documento:" Font-Names="Arial" Font-Size="9pt"></asp:Label>
                                </td>
                                <td align="left" class="auto-style5">
                                    <asp:TextBox runat="server" ID="txtCite" Font-Names="Arial" Font-Size="9pt" MaxLength="30" Height="16px" Width="241px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Font-Names="Arial" Font-Size="9pt" ControlToValidate="txtCite" ErrorMessage="RequiredFieldValidator"
                                         ValidationGroup="ValEnvio" setfocusonerror="true">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2"></td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style5">
                                    <asp:Label ID="lblFechaCite" runat="server" Text="Fecha del CITE:" Font-Names="Arial" Font-Size="9pt"></asp:Label>
                                </td>
                                <td align="left" class="auto-style5">
                                   <asp:TextBox ID="txtFechaCITE" runat="server" Width="100px" MaxLength="10"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFechaCITE" Font-Names="Arial" Font-Size="9pt" 
                                        ErrorMessage="RequiredFieldValidator" ValidationGroup="ValEnvio" setfocusonerror="true">*</asp:RequiredFieldValidator>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" Enabled="True" FilterType="Numbers,Custom " TargetControlID="txtFechaCITE" ValidChars="/">
                                    </cc1:FilteredTextBoxExtender>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtFechaCITE" Display="Dynamic" Font-Names="Arial" Font-Size="9pt" ErrorMessage="dd/mm/aaaa" 
                                        ValidationExpression="^([\d]{2})/([\d]{2})/([\d]{4})$" ValidationGroup="ValEnvio" setfocusonerror="true">
                                      </asp:RegularExpressionValidator>
                                   <%--<asp:ImageButton ID="imgCalendario1" runat="server" ImageUrl="~/Imagenes/pequeños/Calendar_32x32.png" Height="20px" Width="20px" />--%>
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy" PopupButtonID="txtFechaCITE" 
                                    TargetControlID="txtFechaCITE" CssClass="cal_Theme1"></cc1:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2"></td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style5">
                                    <asp:Label ID="lblFechaEnvio" runat="server" Text="Fecha de Envío:" Font-Names="Arial" Font-Size="9pt"></asp:Label>
                                </td>
                                <td align="left" class="auto-style5">
                                   <asp:TextBox ID="txtFechaEnvio" runat="server" Width="100px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFechaEnvio" ErrorMessage="RequiredFieldValidator" ValidationGroup="ValEnvio" Font-Names="Arial" Font-Size="9pt" setfocusonerror="true">*</asp:RequiredFieldValidator>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" Enabled="True" FilterType="Numbers,Custom " TargetControlID="txtFechaEnvio" ValidChars="/">
                                    </cc1:FilteredTextBoxExtender>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" Font-Names="Arial" Font-Size="9pt" runat="server" ControlToValidate="txtFechaEnvio" Display="Dynamic" ErrorMessage="dd/mm/aaaa" ValidationExpression="^([\d]{2})/([\d]{2})/([\d]{4})$" ValidationGroup="ValEnvio" setfocusonerror="true">
                                      </asp:RegularExpressionValidator>
                                    <asp:CompareValidator id="cvtxtStartDate" runat="server" controltocompare="txtFechaCITE" 
                                        cultureinvariantvalues="true" display="Dynamic" 
                                        enableclientscript="true" controltovalidate="txtFechaEnvio"
                                        errormessage="La fecha de envìo no puede ser menor a la fecha del CITE"
                                         type="Date" setfocusonerror="true" operator="GreaterThanEqual" text="fecha Envío debe ser mayor o igual a fecha CITE" Font-Size="9pt" Font-Names="Arial" ValidationGroup="ValEnvio"/>
                                   <%--<asp:ImageButton ID="imgCalendario" runat="server" ImageUrl="~/Imagenes/pequeños/Calendar_32x32.png" Height="20px" Width="20px" />--%>
                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" Format="dd/MM/yyyy" PopupButtonID="txtFechaEnvio" 
                                    TargetControlID="txtFechaEnvio" CssClass="cal_Theme1"></cc1:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2"></td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style5">
                                    <asp:Label ID="lblFuncionario" runat="server" Text="Funcionario:" Font-Names="Arial" Font-Size="9pt" Visible="true"></asp:Label>
                                </td>
                                <td align="left" class="auto-style5">
                                    <asp:DropDownList ID="ddlFuncionario" runat="server" Width="150px" Visible="true" Font-Names="Arial" Font-Size="9pt" OnTextChanged="ddlFuncionario_TextChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Font-Names="Arial" Font-Size="9pt" 
                                        ControlToValidate="ddlOficina" ErrorMessage="RequiredFieldValidator" ValidationGroup="ValEnvio" setfocusonerror="true">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2"></td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style5" valign="top">
                                    <asp:Label ID="lblObs1" runat="server" Text="Observación:" Font-Names="Arial" Font-Size="9pt"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtObsEnvio" runat="server" TextMode="MultiLine" Rows="5" Columns="30"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td align="left"><asp:Button ID="btnCancelarEnvio" runat="server" EnableTheming="True" OnClick="btnCancelarEnvio_Click"
                                         Text="Cancelar"
                                        CssClass="boton150" />
                                
                                    <asp:Button ID="btnAccionarEnvio" runat="server"
                                        Text="Aceptar" CssClass="boton150" OnClick="btnEnviar_Click" CausesValidation="true" ValidationGroup="ValEnvio"/>
                                    <cc1:ConfirmButtonExtender ID="btnGrabar_ConfirmButtonExtender" runat="server" TargetControlID="btnAccionarEnvio" ConfirmText="¿Esta seguro de guardar el envío?"> 
                                    </cc1:ConfirmButtonExtender>
                                </td>
                            </tr>
                        </table>

                    </div>
                </asp:Panel>
                <cc1:RoundedCornersExtender ID="pnlEnvio_RoundedCornersExtender" runat="server"
                    Enabled="True" TargetControlID="pnlEnvio" Radius="10" BorderColor="Black">
                </cc1:RoundedCornersExtender>
                <cc1:ModalPopupExtender ID="pnlTipoCambio_ModalPopupExtender" runat="server"
                    Enabled="True"
                    TargetControlID="btnPrueba"
                    CancelControlID="btnCancelarEnvio"
                    PopupControlID="pnlEnvio"
                    BackgroundCssClass="modalBackground">
                </cc1:ModalPopupExtender>
            </td>
            </tr>
            <tr><td align="center" colspan="6"><asp:Button ID="btnEnviar" runat="server" Text="Enviar" OnClick="btnEnviar_Click1" style="height: 26px" Visible="false"></asp:Button></td>
                
            </tr>
            <tr><td align="center" colspan="6"><asp:Button ID="btnPrueba" runat="server" Text="Enviar" OnClick="btnEnviar_Click" style="display:none"></asp:Button></td>
                
            </tr>
                </table>

                
    
    <!-- AQUI VA EL CODIGO-->

</asp:Content>