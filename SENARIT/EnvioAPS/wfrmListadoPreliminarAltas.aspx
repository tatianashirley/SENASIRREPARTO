<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmListadoPreliminarAltas.aspx.cs" Inherits="EnvioAPS_wfrmListadoPreliminarAltas" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">
    .auto-style5 {
        height: 19px;
    }
    .modalBackground {
        overflow: auto;
        background-color: Black;
        filter: alpha(opacity=65);
        -moz-opacity: 0.65;
        Opacity: 0.65;
    }
    .modalBackground2
    {
	    background-color: Black;
	    filter: alpha(opacity=80); 
	    opacity: 0.50;
    }
    .tableBackground
    {
	    background-color:silver;
	    opacity:0.7;
    }
    .panelprincipal {}
    .auto-style11 {
        width: 5%;
    }
    .auto-style18 {
        width: 122px;
    }
    .auto-style19 {
        width: 24%;
    }
    .auto-style20 {
        width: 28%;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <table style="width: 100%;" class="panelceleste">
        <tr>
            <td align="center">
                <asp:ImageButton ID="imgAux" runat="server" ImageUrl="~/Imagenes/16w.png" />
                <asp:Label ID="lblTituloAUX" runat="server"
                    Text="Listado Preliminar de Altas para Envios APS" CssClass="etiqueta20"></asp:Label><br />
            </td>
        </tr>
        <tr>
            <td>
                <table align="center" cellpadding="0" cellspacing="0" class="panelceleste">
                    <tr>
                        <td align="left">
                            <asp:Label ID="Label7" runat="server" Text="Filas por página:" CssClass="etiqueta10"></asp:Label>
                            <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" 
                                OnSelectedIndexChanged="PageSize_Changed">
                                <asp:ListItem Text="100" Value="100" Selected="True" />
                                <asp:ListItem Text="150" Value="150" />
                                <asp:ListItem Text="250" Value="250" />
                            </asp:DropDownList>
                            <asp:Label ID="Label8" runat="server" Text="Fecha de Corte:" CssClass="etiqueta10"></asp:Label>

                            <asp:TextBox ID="txtFechaCorte" runat="server" ReadOnly="true" BackColor="#87CEEB" Width="75px"></asp:TextBox>
                            <cc1:TextBoxWatermarkExtender ID="txtFechaCorte_TextBoxWatermarkExtender" 
                                runat="server" Enabled="True" TargetControlID="txtFechaCorte" 
                                WatermarkText="__/__/____">
                            </cc1:TextBoxWatermarkExtender>
                            <asp:ImageButton ID="imgPopup" ImageUrl="../Imagenes/pequeños/CalendarC_16x16.png" ImageAlign="Bottom"
                                runat="server" />
                            <cc1:CalendarExtender ID="txtFechaCorte_CalendarExtender" PopupButtonID="imgPopup" runat="server" TargetControlID="txtFechaCorte"
                                Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnProcesaListadoPreliminarAltas" runat="server" Text="Procesar" OnClick="btnProcesaListadoPreliminarAltas_Click" />
                            &nbsp;<hr /><asp:Button ID="btnListadoExportaExcel" runat="server" Text="Exportar a Excel Listado" OnClick="btnListadoExportaExcel_Click"/>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="2" class="auto-style5">
                            <div style="vertical-align: top; left: auto; height: auto; overflow: auto; width: 1200px; height: 425px;" class="panelceleste">
                                <asp:GridView ID="gvListadoPreliminarAltas" runat="server" AutoGenerateColumns="False"
                                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                                CellPadding="3" Font-Names="Verdana" Font-Size="8pt" 
                                OnRowDataBound="gvListadoPreliminarAltas_RowDataBound" 
                                DataKeyNames="IdTramite,IdGrupoBeneficio,NumeroTramiteCrenta,NUP,NroCertificado,Clase_CC"
                                AllowSorting="True" OnSorting="gvListadoPreliminarAltas_Sorting" >
                                <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                                <AlternatingRowStyle BackColor="#F7F7F7" />
                                <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                                <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                                <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Observado" ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkObservado" runat="server" ForeColor="#DC143C"
                                                CausesValidation="false" CommandName="Observado" 
                                                OnClick="lnkObservado_Click" Text="Observado"></asp:LinkButton>
                                            <asp:LinkButton ID="lnkGeneraEM" runat="server" ForeColor="#0066CC"
                                                CausesValidation="false" CommandName="Envios" 
                                                OnClick="lnkGeneraEM_Click" Text="A Envios"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="NroRegistro" HeaderText="Nro Registro" />
                                    <asp:BoundField DataField="IdTramite" HeaderText="Trámite" SortExpression="IdTramite" />
                                    <asp:BoundField DataField="NumeroTramiteCrenta" HeaderText="CRENTA" SortExpression="NumeroTramiteCrenta" />
                                    <asp:BoundField DataField="NUP" HeaderText="NUP" SortExpression="NUP" />
                                    <asp:BoundField DataField="Matricula" HeaderText="Matricula" SortExpression="Matricula" />
                                    <asp:BoundField DataField="CUA" HeaderText="CUA" SortExpression="CUA" />
                                    <asp:BoundField DataField="NroCertificado" HeaderText="Nro Certificado" SortExpression="NroCertificado" />
                                    <asp:BoundField DataField="Tipo_CC" HeaderText="Tipo CC" SortExpression="Tipo_CC" />
                                    <asp:BoundField DataField="Clase_CCD" HeaderText="Clase CC" SortExpression="Clase_CCD" />
                                    <asp:BoundField DataField="cod_AfpD" HeaderText="AFP" />
                                    <asp:BoundField DataField="FechaInicioTramite" HeaderText="Fecha Inicio Tramite" />
                                    <asp:BoundField DataField="FechaGeneracion" HeaderText="Fecha Generacion" />
                                    <asp:BoundField DataField="FechaAceptacion" HeaderText="Fecha Aceptacion" />
                                    <asp:BoundField DataField="PrimerNombre" HeaderText="Primer Nombre" />
                                    <asp:BoundField DataField="SegundoNombre" HeaderText="Segundo Nombre" />
                                    <asp:BoundField DataField="PrimerApellido" HeaderText="Primer Apellido" />
                                    <asp:BoundField DataField="SegundoApellido" HeaderText="Segundo Apellido" />
                                    <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha Nacimiento" />
                                    <asp:BoundField DataField="NumeroDocumento" HeaderText="Numero Documento" />
                                    <asp:BoundField DataField="ComplementoSEGIP" HeaderText="Complemento SEGIP" />
                                    <asp:BoundField DataField="DescripcionDetalleClasificador" HeaderText="Documento" SortExpression="DescripcionDetalleClasificador" />
                                    <asp:BoundField DataField="ErrorFechaNac" HeaderText="Error FechaNac" SortExpression="ErrorFechaNac" ItemStyle-ForeColor="#DC143C" />
                                    <asp:BoundField DataField="MontosAltos" HeaderText="Montos Altos" ItemStyle-ForeColor="#DC143C" />
                                    <asp:BoundField DataField="Fecha_Calculo" HeaderText="Fecha Calculo" />
                                    <asp:BoundField DataField="Diferencias_APS_FECHA_NAC" HeaderText="Diferencias APS FECHA_NAC" SortExpression="Diferencias_APS_FECHA_NAC" ItemStyle-ForeColor="#DC143C" />
                                    <asp:BoundField DataField="Diferencias_APS_CI" HeaderText="Diferencias APS CI" SortExpression="Diferencias_APS_CI" ItemStyle-ForeColor="#DC143C" />
                                    <asp:BoundField DataField="Dif_APS_NOMBRES_APELLIDOS" HeaderText="Dif APS NOMBRES_APELLIDOS" SortExpression="Dif_APS_NOMBRES_APELLIDOS" ItemStyle-ForeColor="#DC143C" />
                                    <asp:BoundField DataField="Afiliado_APS" HeaderText="Afiliado APS" SortExpression="Afiliado_APS" />
                                    <asp:BoundField DataField="Cambio_APS_AFP" HeaderText="Cambio APS_AFP" SortExpression="Cambio_APS_AFP" ItemStyle-ForeColor="#DC143C" />
                                </Columns>
                                <EmptyDataTemplate><div align="center" class="CajaDialogoAdvertencia">
                                    <br/><img src="../Imagenes/warning.gif" 
                                            alt="No existen Envios que se puedan dar de Alta a la APS" />
                                    <br/>No existen Envios que se puedan dar de Alta a la APS
                                    <br/><br/>
                                    </div>
                                </EmptyDataTemplate>
                                </asp:GridView>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="2" class="auto-style5">
                        <asp:Repeater ID="rptPager" runat="server">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkPage" runat="server" CausesValidation="false" 
                                    Text = '<%#Eval("Text") %>' CommandArgument = '<%# Eval("Value") %>' 
                                        Enabled = '<%# Eval("Enabled") %>' OnClick = "Page_Changed" Font-Size="Small">
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:Repeater>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Certificados:   Automáticos[" CssClass="etiqueta10"></asp:Label>
                            <asp:Label ID="lblRecordCountA" runat="server" Text="" CssClass="etiqueta10"></asp:Label>
                            <asp:Label ID="Label3" runat="server" Text="]" CssClass="etiqueta10"></asp:Label>&nbsp;&nbsp;&nbsp;<asp:Label ID="Label2" runat="server" Text="Manuales[" CssClass="etiqueta10"></asp:Label> 
                            <asp:Label ID="lblRecordCountM" runat="server" Text="" CssClass="etiqueta10"></asp:Label>
                            <asp:Label ID="Label4" runat="server" Text="]" CssClass="etiqueta10"></asp:Label>&nbsp;&nbsp;&nbsp;<asp:Label ID="Label5" runat="server" Text="Total[" CssClass="etiqueta10"></asp:Label>
                            <asp:Label ID="lblRecordCount" runat="server" Text="" CssClass="etiqueta10"></asp:Label>
                            <asp:Label ID="Label6" runat="server" Text="]" CssClass="etiqueta10"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server"
        TargetControlID="lblTituloAUX" PopupControlID="pnlObservado"
        CancelControlID="btnCancel" BackgroundCssClass="modalBackground">
    </cc1:ModalPopupExtender>
    <asp:Panel ID="pnlObservado" runat="server" CssClass="panelprincipal" Height="253px" Width="643px">
        <div>
        <table width="100%" cellspacing="4">
	        <tr style="background-color:#AFC6E0">
                <td class="auto-style18">
                    &nbsp;
                </td>
	            <td colspan="2"  align="center">
                    <asp:Label ID="Label9" runat="server" Text="Remitir Tramite a Observados u otros..."></asp:Label><br />
                    <asp:Label ID="lblIdTramite" runat="server" Text="Label"></asp:Label>
	            </td>
                <td class="auto-style19">&nbsp;</td>
	        </tr>
            <tr>
                <td width="1%"></td>
                <td width="10%" align="right">
                    <asp:Label ID="Label10"  CssClass="etiqueta10"  runat="server" Text="Destino: " >
                    </asp:Label>
                </td>
                <td width="50%">
                    <asp:DropDownList ID="ddlPosiblesDestinos" runat="server" AutoPostBack="true"
                        OnSelectedIndexChanged="ddlPosiblesDestinos_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlRolUsuario" runat="server" AutoPostBack="true"
                        OnSelectedIndexChanged="ddlRolUsuario_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td width="1%">
                </td>
            </tr>
	        <tr>
                <td class="auto-style18"></td>
		        <td align="right" class="auto-style20" >
                    <asp:Label ID="lblGlosaProveido" runat="server" Text="Glosa o Proveído"></asp:Label>&nbsp;
		        </td>
		        <td align="left">
                    <asp:TextBox ID="txtProveido" runat="server" TextMode="multiline" Columns="50" Rows="5"  onfocus="selecciona_value(this)"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvProveido" runat="server" 
                        ControlToValidate="txtProveido" ValidationGroup="Proveido" 
                        ErrorMessage="Debe llenar el Proveido de la derivación"></asp:RequiredFieldValidator><br />
                    <asp:Button ID="btnDerivarObservado" runat="server" OnClick="btnDerivarObservado_Click" Text="Derivar Trámite" ValidationGroup="Proveido"  />                                            
       		        <asp:Button ID="btnCancel" runat="server" Text="Cancelar" />
		        </td>
                <td class="auto-style19"></td>
	        </tr>
        </table>
    </div>
    </asp:Panel>
</asp:Content>