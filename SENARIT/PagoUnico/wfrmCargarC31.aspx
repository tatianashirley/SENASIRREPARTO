<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmCargarC31.aspx.cs" Inherits="PagoUnico_wfrmCargarC31" StylesheetTheme="Modal" %>
<%@ MasterType VirtualPath="~/MasterPage.master"%>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Reference Page="~/PagoUnico/wfrmGenerarMedios.aspx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <script type="text/javascript" language="javascript">

         function armarGlosa() {
             
             var sAnio = document.getElementById('<%=txtAnio.ClientID %>').value;

             if (sAnio != 0) {
                 var ddlMes = document.getElementById('<%=ddlMes.ClientID %>');
                 var selIndexMes = ddlMes.selectedIndex;
                 var selTextMes = ddlMes.options[ddlMes.selectedIndex].text;
                 document.getElementById('<%=txtGestionAfectar.ClientID%>').value = sAnio;

                 if (selIndexMes != 0) {
                     var ddlBenef = document.getElementById('<%=ddlBeneficio.ClientID %>');
                     var selIndexBenef = ddlBenef.selectedIndex;
                     var selValueBenef = ddlBenef.value;

                     if (selIndexBenef != 0) {
                         var sGlosa = 'PLANILLA PAGO ' + selValueBenef + ' - ' + selTextMes + ' ' + sAnio;
                         document.getElementById('<%=txtGlosa.ClientID %>').value = sGlosa;
                         
                         if (selValueBenef == 'PU') {
                             var ddlSeguros = document.getElementById('<%=ddlSeguros.ClientID %>');
                             ddlSeguros.value = 'IVM';
                         }
                     }
                 }
             }
         }
     </script>
    
     <style type="text/css">
         .auto-style1 {
             height: 26px;
         }
         .auto-style2 {
             width: 199px;
         }
         .auto-style3 {
             height: 26px;
             width: 199px;
         }
     </style>
    
</asp:Content>
<asp:Content ID="Cuerpo" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="pnlGral">
        <asp:Panel ID="pnlDatos" runat="server" CssClass="pnlBody">
            
            <table style="width: 100%;">
                <tr>
                    <td>&nbsp;</td>
                    <td align="center" colspan="8">
                        <asp:ImageButton ID="imgAux" runat="server" ImageUrl="~/Imagenes/16w.png" />
                        <asp:Label ID="lblTituloAUX" runat="server" CssClass="texto12" Text="Registro de C31"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td align="right">&nbsp;</td>
                    <td align="left">&nbsp;</td>
                    <td align="right">&nbsp;</td>
                    <td align="left">&nbsp;</td>
                    <td align="right">&nbsp;</td>
                    <td align="left" class="auto-style2">&nbsp;</td>
                    <td align="right">&nbsp;</td>
                    <td align="left">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td align="right">
                        <asp:Label ID="Label1" runat="server" Text="Año:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtAnio" runat="server" onchange="armarGlosa();" Width="80px"></asp:TextBox>
                        <cc1:NumericUpDownExtender ID="txtAnio_NumericUpDownExtender" runat="server" Maximum="2030" Minimum="1996" TargetControlID="txtAnio" Width="80">
                        </cc1:NumericUpDownExtender>
                        <cc1:FilteredTextBoxExtender ID="txtAnio_FilteredTextBoxExtender" runat="server" FilterType="Numbers" TargetControlID="txtAnio">
                        </cc1:FilteredTextBoxExtender>
                        <asp:RequiredFieldValidator ID="rfvMaternoB" runat="server" ControlToValidate="txtAnio" ErrorMessage="*"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="ravAnio" runat="server" ControlToValidate="txtAnio" ErrorMessage="Fuera de rango" MaximumValue="2030" MinimumValue="1996" Type="Integer"></asp:RangeValidator>
                    </td>
                    <td align="right">
                        <asp:Label ID="Label2" runat="server" Text="Mes:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlMes" runat="server" CssClass="box" onchange="armarGlosa();" Width="110px">
                            <asp:ListItem Value="Seleccione valor ...">Seleccione valor ...</asp:ListItem>
                            <asp:ListItem Value="1">ENERO</asp:ListItem>
                            <asp:ListItem Value="2">FEBRERO</asp:ListItem>
                            <asp:ListItem Value="3">MARZO</asp:ListItem>
                            <asp:ListItem Value="4">ABRIL</asp:ListItem>
                            <asp:ListItem Value="5">MAYO</asp:ListItem>
                            <asp:ListItem Value="6">JUNIO</asp:ListItem>
                            <asp:ListItem Value="7">JULIO</asp:ListItem>
                            <asp:ListItem Value="8">AGOSTO</asp:ListItem>
                            <asp:ListItem Value="9">SEPTIEMBRE</asp:ListItem>
                            <asp:ListItem Value="10">OCTUBRE</asp:ListItem>
                            <asp:ListItem Value="11">NOVIEMBRE</asp:ListItem>
                            <asp:ListItem Value="12">DICIEMBRE</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvDdlMes" runat="server" ControlToValidate="ddlMes" ErrorMessage="*" InitialValue="Seleccione valor ..."></asp:RequiredFieldValidator>
                    </td>
                    <td align="right">
                        <asp:Label ID="Label3" runat="server" Text="Beneficio:"></asp:Label>
                    </td>
                    <td align="left" class="auto-style2">
                        <asp:DropDownList ID="ddlBeneficio" runat="server" CssClass="box" onchange="armarGlosa();" Width="110px">
                            <asp:ListItem>Seleccione valor ...</asp:ListItem>
                            <asp:ListItem Value="PMM">PMM</asp:ListItem>
                            <asp:ListItem Selected="True" Value="PU">PU</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvDdlBeneficio" runat="server" ControlToValidate="ddlBeneficio" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                    <td align="right">
                        <asp:Label ID="Label19" runat="server" Text="Seguros:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddlSeguros" runat="server" CssClass="box" Width="140px">
                            <asp:ListItem Value="Seleccione valor ...">Seleccione valor ...</asp:ListItem>
                            <asp:ListItem Value="IVM">Invalidez, Vejez, Muerte</asp:ListItem>
                            <asp:ListItem Value="RP">Riesgo Profesional</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvDdlSeguros" runat="server" ControlToValidate="ddlSeguros" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td align="right">
                        <asp:Label ID="Label20" runat="server" Text="Glosa:"></asp:Label>
                    </td>
                    <td align="left" colspan="3">
                        <asp:TextBox ID="txtGlosa" runat="server" CssClass="box" Width="340px" Enabled="False"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvTxtGlosa" runat="server" ControlToValidate="txtGlosa" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                    <td align="right">
                        <asp:Label ID="Label4" runat="server" Text="Nº C31:"></asp:Label>
                    </td>
                    <td align="left" class="auto-style2">
                        <asp:TextBox ID="txtC31" runat="server" CssClass="box" MaxLength="10"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="txtC31_FilteredTextBoxExtender" runat="server" FilterType="Numbers" TargetControlID="txtC31">
                        </cc1:FilteredTextBoxExtender>
                        <asp:RequiredFieldValidator ID="rfvTxtC31" runat="server" ControlToValidate="txtC31" ErrorMessage="*"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="ravInt" runat="server" ControlToValidate="txtC31" ErrorMessage="Fuera de rango" MaximumValue="2147483647" MinimumValue="1" Type="Integer"></asp:RangeValidator>
                    </td>
                    <td align="right">
                        <asp:Label ID="Label5" runat="server" Text="Nº C31 (Reversiones):"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtC31Rev" runat="server" CssClass="box" MaxLength="10" Enabled="False"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="txtC31Rev_FilteredTextBoxExtender" runat="server" FilterType="Numbers" TargetControlID="txtC31Rev">
                        </cc1:FilteredTextBoxExtender>
                        <asp:RangeValidator ID="ravInt0" runat="server" ControlToValidate="txtC31Rev" ErrorMessage="Fuera de rango" MaximumValue="2147483647" MinimumValue="0" Type="Integer"></asp:RangeValidator>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td align="right">&nbsp;</td>
                    <td align="left" colspan="3">&nbsp;</td>
                    <td align="right">&nbsp;</td>
                    <td align="left" class="auto-style2">&nbsp;</td>
                    <td align="right">&nbsp;</td>
                    <td align="left">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td align="right">
                        <asp:Label ID="Label8" runat="server" Text="Gestión a afectar:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtGestionAfectar" runat="server" Enabled="False"></asp:TextBox>
                        <cc1:NumericUpDownExtender ID="txtGestionAfectar_NumericUpDownExtender" runat="server" Maximum="2030" Minimum="1996" TargetControlID="txtGestionAfectar" Width="80">
                        </cc1:NumericUpDownExtender>
                        <cc1:FilteredTextBoxExtender ID="txtGestionAfectar_FilteredTextBoxExtender" runat="server" FilterType="Numbers" TargetControlID="txtGestionAfectar">
                        </cc1:FilteredTextBoxExtender>
                        <asp:RequiredFieldValidator ID="rfvTxtGestion" runat="server" ControlToValidate="txtGestionAfectar" ErrorMessage="*"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="ravGestionAfectar" runat="server" ControlToValidate="txtGestionAfectar" ErrorMessage="Fuera de rango" MaximumValue="2030" MinimumValue="1996" Type="Integer"></asp:RangeValidator>
                    </td>
                    <td align="right">
                        <asp:Label ID="Label9" runat="server" Text="Fuente Fmto:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtFuenteFmto" runat="server" CssClass="box" MaxLength="2" Enabled="False">10</asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="txtFuenteFmto_FilteredTextBoxExtender" runat="server" FilterType="Numbers" TargetControlID="txtFuenteFmto">
                        </cc1:FilteredTextBoxExtender>
                        <asp:RequiredFieldValidator ID="rfvTxtFuenteFmto" runat="server" ControlToValidate="txtFuenteFmto" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                    <td align="right">
                        <asp:Label ID="Label11" runat="server" Text="Total Autorizado:"></asp:Label>
                    </td>
                    <td align="left" class="auto-style2">
                        <asp:TextBox ID="txtTotAutoriz" runat="server" CssClass="box" Enabled="False">0</asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvTxtTotAutoriz" runat="server" ControlToValidate="txtTotAutoriz" ErrorMessage="*"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="ravMonHasta" runat="server" ControlToValidate="txtTotAutoriz" ErrorMessage="Fuera de rango" MaximumValue="922337203685477.58" MinimumValue="0" Type="Double"></asp:RangeValidator>
                    </td>
                    <td align="right">
                        <asp:Label ID="Label10" runat="server" Text="Total:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtTot" runat="server" CssClass="box" Enabled="False">0</asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvTxtTot" runat="server" ControlToValidate="txtTot" ErrorMessage="*"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="ravMonHasta0" runat="server" ControlToValidate="txtTot" ErrorMessage="Fuera de rango" MaximumValue="922337203685477.58" MinimumValue="0" Type="Double"></asp:RangeValidator>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td align="right">
                        <asp:Label ID="Label6" runat="server" Text="Código Entidad:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtCodEntidad" runat="server" CssClass="box" MaxLength="4" Enabled="False">0099</asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="txtCodEntidad_FilteredTextBoxExtender" runat="server" FilterType="Numbers" TargetControlID="txtCodEntidad">
                        </cc1:FilteredTextBoxExtender>
                        <asp:RequiredFieldValidator ID="rfvTxtCodEntidad" runat="server" ControlToValidate="txtCodEntidad" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                    <td align="right">
                        <asp:Label ID="Label12" runat="server" Text="Organismo:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtOrganismo" runat="server" CssClass="box" MaxLength="3" Enabled="False">111</asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="txtOrganismo_FilteredTextBoxExtender" runat="server" FilterType="Numbers" TargetControlID="txtOrganismo">
                        </cc1:FilteredTextBoxExtender>
                        <asp:RequiredFieldValidator ID="rfvTxtOrganismo" runat="server" ControlToValidate="txtOrganismo" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                    <td align="right">
                        <asp:Label ID="Label13" runat="server" Text="Dir. Administrativa:"></asp:Label>
                    </td>
                    <td align="left" class="auto-style2">
                        <asp:TextBox ID="txtDirAdmin" runat="server" CssClass="box" MaxLength="10" Enabled="False">7</asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="txtDirAdmin_FilteredTextBoxExtender" runat="server" FilterType="Numbers" TargetControlID="txtDirAdmin">
                        </cc1:FilteredTextBoxExtender>
                        <asp:RequiredFieldValidator ID="rfvTxtDirAdmin" runat="server" ControlToValidate="txtDirAdmin" ErrorMessage="*"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="ravInt1" runat="server" ControlToValidate="txtDirAdmin" ErrorMessage="Fuera de rango" MaximumValue="2147483647" MinimumValue="1" Type="Integer"></asp:RangeValidator>
                    </td>
                    <td align="right">
                        <asp:Label ID="Label14" runat="server" Text="Unidad Ejecutora:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtUnidEjec" runat="server" CssClass="box" MaxLength="10" Enabled="False">7</asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="txtUnidEjec_FilteredTextBoxExtender" runat="server" FilterType="Numbers" TargetControlID="txtUnidEjec">
                        </cc1:FilteredTextBoxExtender>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlTipoCmpte" ErrorMessage="*"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="ravInt2" runat="server" ControlToValidate="txtUnidEjec" ErrorMessage="Fuera de rango" MaximumValue="2147483647" MinimumValue="1" Type="Integer"></asp:RangeValidator>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1"></td>
                    <td align="right" class="auto-style1">
                        <asp:Label ID="Label15" runat="server" Text="Centro Proceso Datos:"></asp:Label>
                    </td>
                    <td align="left" class="auto-style1">
                        <asp:TextBox ID="txtCentroProcDat" runat="server" CssClass="box" Enabled="False">SIS</asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvTxtCentroProcDat" runat="server" ControlToValidate="txtCentroProcDat" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                    <td align="right" class="auto-style1">
                        <asp:Label ID="Label16" runat="server" Text="Instancia:"></asp:Label>
                    </td>
                    <td align="left" class="auto-style1">
                        <asp:TextBox ID="txtInstancia" runat="server" CssClass="box" Enabled="False">DV</asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvTxtInstancia" runat="server" ControlToValidate="txtInstancia" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                    <td align="right" class="auto-style1">
                        <asp:Label ID="Label17" runat="server" Text="Tipo Planilla:"></asp:Label>
                    </td>
                    <td align="left" class="auto-style3">
                        <asp:DropDownList ID="ddlTipoPlanilla" runat="server" CssClass="box" Width="110px" Enabled="False">
                            <asp:ListItem>Seleccione valor ...</asp:ListItem>
                            <asp:ListItem Selected="True">N</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvddlTipoPlanilla" runat="server" ControlToValidate="ddlTipoPlanilla" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                    <td align="right" class="auto-style1">
                        <asp:Label ID="Label18" runat="server" Text="Tipo Comprobante:"></asp:Label>
                    </td>
                    <td align="left" class="auto-style1">
                        <asp:DropDownList ID="ddlTipoCmpte" runat="server" CssClass="box" Width="110px" Enabled="False">
                            <asp:ListItem>Seleccione valor ...</asp:ListItem>
                            <asp:ListItem Selected="True">N</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvDdlTipoCmpte" runat="server" ControlToValidate="ddlTipoCmpte" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style1"></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td align="right">&nbsp;</td>
                    <td align="left">&nbsp;</td>
                    <td align="right">&nbsp;</td>
                    <td align="left">&nbsp;</td>
                    <td align="right">&nbsp;</td>
                    <td align="left" class="auto-style2">&nbsp;</td>
                    <td align="right">&nbsp;</td>
                    <td align="left">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td align="center" colspan="8">
                        <asp:Button ID="btnLimpiar" runat="server" CssClass="btnPrin" OnClick="btnLimpiar_Click" Text="Limpiar" CausesValidation="False" />
                        <asp:Button ID="btnRegistrar" runat="server" CssClass="btnPrin" OnClick="btnRegistrar_Click" Text="Registrar" Height="21px" />
                        <asp:Button ID="btnAnular" runat="server" CssClass="btnPrin" Enabled="False" OnClick="btnAnular_Click" Text="Anular" />
                        <cc1:ConfirmButtonExtender ID="btnAnular_ConfirmButtonExtender" runat="server" TargetControlID="btnAnular" ConfirmText="¿Esta seguro de anular el C31? &#10; Tenga en cuenta que significa: &#10;1) Anular los cheques asociados.&#10;2) No podrá descargar los medios generados.">
                        </cc1:ConfirmButtonExtender>
                        <%--<asp:Button ID="btnModificar" runat="server" CssClass="btnPrin" Enabled="False" OnClick="btnModificar_Click" Text="Modificar" Visible="False" />--%>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td align="center" colspan="8">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td align="center" colspan="8">
                        <div align="center">                        
                            <asp:GridView ID="gvRegC31" runat="server" AllowPaging="True" AutoGenerateColumns="False" BorderColor="#DADADA" DataKeyNames="AnioProceso,MesProceso,C31" OnPageIndexChanging="gvRegC31_PageIndexChanging" OnSelectedIndexChanged="gvRegC31_SelectedIndexChanged">
                                <HeaderStyle CssClass="cssHeaderImg" />
                                <Columns>
                                    <asp:ButtonField ButtonType="Image" CommandName="Select" HeaderText="Elegir" ImageUrl="~/imagenes/16siguiente.png" ShowHeader="True" Text="Button" />
                                    <asp:BoundField DataField="Cpl" HeaderText="Beneficio" />
                                    <asp:BoundField DataField="Seguros" HeaderText="Seguros" />
                                    <asp:BoundField DataField="AnioProceso" HeaderText="Año Proc." />
                                    <asp:BoundField DataField="MesProceso" HeaderText="Mes Proc." />
                                    <asp:BoundField DataField="Anio" HeaderText="Año" />
                                    <asp:BoundField DataField="Mes" HeaderText="Mes" />
                                    <asp:BoundField DataField="C31" HeaderText="Nº C31" />
                                    <%--<asp:BoundField DataField="C31_Rev" HeaderText="Nº C31 Rev." />--%>
                                    <asp:BoundField DataField="Glosa" HeaderText="Glosa" />
                                    <%--<asp:BoundField DataField="Aniop" HeaderText="Gestión Afectar" />--%>
                                    <%--<asp:BoundField DataField="Fte" HeaderText="Fte. Fmto." />
                                    <asp:BoundField DataField="Retension" HeaderText="Tot. Autorizado" />--%>
                                    <asp:BoundField DataField="Total" HeaderText="Total" />
                                    <%--<asp:BoundField DataField="Ent" HeaderText="Cód. Entidad" />
                                    <asp:BoundField DataField="Org" HeaderText="Organismo" />
                                    <asp:BoundField DataField="Dad" HeaderText="Dir. Admin." />
                                    <asp:BoundField DataField="Ues" HeaderText="Unid. Ejec." />
                                    <asp:BoundField DataField="Cpd" HeaderText="Cen. Proc. Dat." />
                                    <asp:BoundField DataField="Ins" HeaderText="Instancia" />
                                    <asp:BoundField DataField="Tip" HeaderText="T. Planilla" />
                                    <asp:BoundField DataField="Tco" HeaderText="T. Cmpte" />--%>
                                </Columns>
                                <EmptyDataTemplate>
                                    <div align="center" class="CajaDialogoAdvertencia">
                                        <br/>
                                        <img src="../Imagenes/warning.gif" 
                                                alt="No existen registros" />
                                        <br/>
                                        Bandeja de registro de C31 vacía.
                                        <br/>
                                        <br/>
                                    </div>
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </div>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td align="right">&nbsp;</td>
                    <td align="left">&nbsp;</td>
                    <td align="right">&nbsp;</td>
                    <td align="left">&nbsp;</td>
                    <td align="right">&nbsp;</td>
                    <td align="left" class="auto-style2">&nbsp;</td>
                    <td align="right">&nbsp;</td>
                    <td align="left">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
    &nbsp;</div>
</asp:Content>

