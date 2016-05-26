<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmGeneracionComprobantes.aspx.cs" Inherits="WorkFlow_wfrmGeneracionComprobantes" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script language="javascript" type="text/javascript">
    window.onload = pageLoad;				
    function pageLoad() {
        //debugger;
        //alert('pageLoad');
        var HFchkActividadChecked = $get("<%=HFchkActividadChecked.ClientID %>");
        var btnGenerar = document.getElementById('<%= btnGenerar.ClientID %>');
        if (btnGenerar) {
            if (HFchkActividadChecked.value == '1' ) {
                btnGenerar.disabled = false;
            }
            else {
                btnGenerar.disabled = true;
            }
        }
    }
</script>
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
<script type="text/javascript" language="javascript">
    function chkActividadChecked(objRef) {
        //debugger;
        var GridView = objRef.parentNode.parentNode.parentNode;
        var inputList = GridView.getElementsByTagName("input");
        var HFchkActividadChecked = document.getElementById("<%= HFchkActividadChecked.ClientID %>");
        HFchkActividadChecked.value = '0';
        var headerCheckBox = inputList[0];
        for (var i = 0; i < inputList.length; i++) {
            //Get the Cell To find out ColumnIndex
            var row = inputList[i].parentNode.parentNode;
            if (inputList[i].type == "checkbox") {
                if (inputList[i].checked) {
                    HFchkActividadChecked.value = '1';
                }
            }
        }
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:HiddenField ID="HFchkActividadChecked" runat="server" Value="0" />
    <table style="width: 100%;" class="panelceleste">
        <tr>
            <td align="center">
                <asp:ImageButton ID="imgAux" runat="server" ImageUrl="~/Imagenes/16w.png" />
                <asp:Label ID="lblTituloAUX" runat="server"
                    Text="GENERACION DE COMPROBANTES DE TRASLADO DE DOCUMENTOS" CssClass="etiqueta20"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="PanelDatos" runat="server" CssClass="panelceleste">
                    <table width="100%">
                        <tr>
                            <td style="text-align: right" class="auto-style5">
                                <asp:Label ID="lblTransicion" CssClass="etiqueta10" runat="server" Text="Transición"></asp:Label>

                            </td>
                            <td style="text-align: left" colspan="2" class="auto-style6">
                                <asp:DropDownList ID="dllActividadesAceptarConCbte" runat="server" Width="461px" AutoPostBack="True" OnSelectedIndexChanged="dllActividadesAceptarConCbte_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td style="text-align: left">
                                <asp:Button ID="btnReporte430" runat="server" Text="Imprimir Reporte 430" Width="165px" OnClick="btnReporte430_Click" Visible="false"/>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right">
                                <asp:Label ID="lblProveido" CssClass="etiqueta10" runat="server" Text="Proveido General" />

                            </td>
                            <td colspan="3" style="text-align: left">
                                <asp:TextBox ID="txtProveidoGeneral" runat="server" Style="margin-bottom: 0px" Width="85%" Height="48px"></asp:TextBox>
                            </td>

                            <td style="width: 20%; text-align: right">&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td style="width: 20%">&nbsp;</td>
                            <td style="width: 20%">&nbsp;</td>
                            <td style="width: 20%">&nbsp;</td>
                            <td></td>
                        </tr>

                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <table style="width: 100%;">
                    <tr>
                        <td colspan="2" class="panelceleste">
                            <asp:GridView ID="gvActividadesParaGeneracionCbte" runat="server" AutoGenerateColumns="False"
                                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                                CellPadding="3" Font-Names="Verdana" Font-Size="7pt" 
                                OnRowDataBound="gvActividadesParaGeneracionCbte_RowDataBound"
                                OnRowCommand="gvActividadesParaGeneracionCbte_RowCommand" 
                                DataKeyNames="IdInstancia,Secuencia">
                            <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                            <AlternatingRowStyle BackColor="#F7F7F7" />
                            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                            <SelectedRowStyle BackColor="#6495ED" Font-Bold="True" ForeColor="#333333" />
                            <Columns>
                                <asp:TemplateField ItemStyle-Width="40px">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="chkboxSelectAll" runat="server" onclick="checkAll(this);" Visible="false" />
                                    </HeaderTemplate>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkActividad" runat="server" AutoPostBack="true" onclick="chkActividadChecked(this);" OnCheckedChanged="chkActividad_CheckedChanged" >
                                        </asp:CheckBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                    </HeaderTemplate>
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ibnProveido" runat="server" ImageUrl="~/Imagenes/pequeños/16EditTextDocumentAdd.gif" 
                                            CommandName="IMGProveido" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="IdInstancia">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdInstancia" runat="server" Text='<%# Bind("IdInstancia") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Secuencia">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSecuencia" runat="server" Text='<%# Bind("Secuencia") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="IdTipoTramite" HeaderText="IdTipoTramite" />
                                <asp:BoundField DataField="IdGrupoBeneficio" HeaderText="IdGrupoBeneficio" />
                                <asp:BoundField DataField="IdTramite" HeaderText="Nro. Tramite" />
                                <asp:BoundField DataField="IdFlujo" HeaderText="IdFlujo" />
                                <asp:BoundField DataField="DescFlujo" HeaderText="DescFlujo" />
                                <asp:BoundField DataField="IdNodo" HeaderText="IdNodo" />
                                <asp:BoundField DataField="Descripcion" HeaderText="Actividad" />
                                <asp:BoundField DataField="Contador" HeaderText="Contador" />
                                <asp:BoundField DataField="FechaHRInicio" HeaderText="FechaHRInicio" />
                                <asp:BoundField DataField="FechaHRFin" HeaderText="FechaHRFin" />                                        
                                <asp:BoundField DataField="Comentarios" HeaderText="Comentarios" />
                                <asp:TemplateField HeaderText="Proveido">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProveidoE" runat="server" Text='<%# Bind("Proveido") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                <div align="center" class="CajaDialogoAdvertencia">
                                <br/><img src="../Imagenes/warning.gif" 
                                        alt="No existen Actividades para generar su comprobante del usuario en curso." />
                                <br/>No existen Actividades por Asignar para el usuario en curso.
                                <br/><br/>
                                </div>
                            </EmptyDataTemplate>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="text-align:right">
                <asp:Button ID="btnGenerar" CssClass="boton150"  runat="server" Text="Generar" OnClick="btnGenerar_Click"
                    onclientclick="return confirm('Esta seguro de asignar las actividades marcadas ?');"  />
                <asp:ImageButton ID="imgVolver" runat="server"  ImageUrl="~/Imagenes/32Volver.png" ToolTip="Volver a la Página anterior" OnClick="btnCaqncelar_Click" /> 
                <asp:Label ID="lblTVolver" CssClass="etiqueta8Blue" runat="server" Text="Volver" /> 
            </td>
        </tr>
    </table>
    <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server"
        TargetControlID="lblTituloAUX" PopupControlID="pnlComentarioProveidoEspecifico"
        CancelControlID="btnCancel" BackgroundCssClass="modalBackground">
    </cc1:ModalPopupExtender>
    <asp:Panel ID="pnlComentarioProveidoEspecifico" runat="server" CssClass="panelprincipal">
        <asp:HiddenField ID="HFProveidoTrans" runat="server" Value="0" />
        <div>
        <table width="100%" cellspacing="4">
	        <tr style="background-color:#0099FF">
	            <td colspan="2"  align="center">
                    <asp:Label ID="Label2" runat="server" Text="Remite Proveido Específico para la transición"></asp:Label></td>
	        </tr>
	        <tr>
		        <td align="left" colspan="2">
                    <asp:Label ID="Label1" runat="server" Text="Ingrese Proveido"></asp:Label>
		        </td>
	        </tr>
	        <tr>
		        <td align="left" colspan="2">
                    <asp:TextBox ID="txtProveidoTrans" runat="server" Height="69px" Width="389px"></asp:TextBox>
		        </td>
	        </tr>
	        <tr>
		        <td align="left" colspan="2">
		        <asp:Label ID="lblIndexPE" runat="server" ></asp:Label>
		        </td>
	        </tr>
	        <tr>
		        <td align="left" colspan="2">
		        <asp:Label ID="lblIdInstanciaPE" runat="server" ></asp:Label>
		        </td>
	        </tr>
	        <tr>
		        <td align="left" colspan="2">
                <asp:Label ID="lblSecuenciaPE" runat="server" ></asp:Label>
		        </td>
	        </tr>
	        <tr>
		        <td align="left" colspan="2">
		        <asp:Label ID="lblNemoNodoOrigPE" runat="server" ></asp:Label>
		        </td>
	        </tr>
	        <tr>
		        <td align=right >
		        <asp:Button ID="btnProveido" CommandName="Proveido" runat="server" Text="Graba Proveido" OnClick="btnProveido_Click" />
		        </td>
		        <td>
		        <asp:Button ID="btnCancel" runat="server" Text="Cancelar" OnClick="btnCancel_Click"/>
		        </td>
	        </tr>
        </table>
    </div>
    </asp:Panel>
</asp:Content>

