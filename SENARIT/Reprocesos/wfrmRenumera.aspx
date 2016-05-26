<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmRenumera.aspx.cs" Inherits="Reprocesos_wfrmRenumera" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
    var gridViewCtlId = '<%=gvAsignacionCertificados.ClientID%>';
    var gridViewCtl = null;
    var curSelRow = null;
    var curRowIdx = -1;
    function getGridViewControl() {
        if (null == gridViewCtl) {
            gridViewCtl = document.getElementById(gridViewCtlId);
        }
    }

    function onGridViewRowSelected(rowIdx) {
        var selRow = getSelectedRow(rowIdx);
        if (null != selRow) {
            curSelRow = selRow;
            var cellValue = getCellValue(rowIdx, 0);
            alert(cellValue);
        }
    }

    function getSelectedRow(rowIdx) {
        return getGridRow(rowIdx);
    }

    function getGridRow(rowIdx) {
        getGridViewControl();
        if (null != gridViewCtl) {
            return gridViewCtl.rows[rowIdx];
        }
        return null;
    }

    function getGridColumn(rowIdx, colIdx) {
        var gridRow = getGridRow(rowIdx);
        if (null != gridRow) {
            return gridRow.cells[colIdx];
        }
        return null;
    }

    function getCellValue(rowIdx, colIdx) {
        var gridCell = getGridColumn(rowIdx, colIdx);
        if (null != gridCell) {
            return gridCell.innerText;
        }
        return null;
    }
</script>
<script type="text/javascript" language="javascript">
    function chkAsignacionChecked(objRef) {
        //debugger;
        var HFchkNumeroAsignacionChecked = document.getElementById("<%= HFchkNumeroAsignacionChecked.ClientID %>");
        HFchkNumeroAsignacionChecked.value = '0';
        
        var GridView = objRef.parentNode.parentNode.parentNode;
        var inputList = GridView.getElementsByTagName("input");
        for (var i = 0; i < inputList.length; i++) {
            if (inputList[i].type == "checkbox" && inputList[i] != objRef) {
                //Distinct to the row selected
                inputList[i].disabled = objRef.checked;
            } else {
                //The row selected
                if (objRef.checked) {
                    HFchkNumeroAsignacionChecked.value = getCellValue(i + 1, 1); //Value of NumeroAsignacion Column
                }
            }
        }
    }
</script>
<asp:HiddenField ID="HFchkNumeroAsignacionChecked" runat="server" Value="0"/>
<table style="width: 100%;" class="panelceleste">
<tr>
    <td align="center">
        <asp:ImageButton ID="imgAux" runat="server" ImageUrl="~/Imagenes/16w.png" />
        <asp:Label ID="lblTituloAUX" runat="server" Text="ADMINISTRACION DE REPROCESOS - Renumeración de Certificados" CssClass="etiqueta20"> </asp:Label>
    </td>
</tr>
</table>
<table style="width: 100%;" cellpadding="0" cellspacing="0" class="panelceleste">
    <tr>
        <td width="1%"></td>
        <td width="98%" align="left">
            <asp:Label ID="Label5" runat="server" Text="Certificados" CssClass="etiqueta10" Font-Bold="True"></asp:Label>
        </td>
        <td width="1%"></td>
    </tr>
    <tr>
        <td width="1%"></td>
        <td width="98%" align="left">
            <div style="vertical-align: top; left: auto; height: auto; overflow: auto; width: 1200px;" class="panelceleste">
                <asp:GridView ID="gvCertificados" runat="server" 
                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                    CellPadding="3" Font-Names="Verdana" Font-Size="8pt" AutoGenerateColumns="false"
                    DataKeyNames="IdTramite,IdTipoTramite,IdGrupoBeneficio,NroCertificado,NoFormularioCalculo,IdTipoFormularioCalculo" >
                    <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                    <AlternatingRowStyle BackColor="#F7F7F7" />
                    <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                    <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#FFDAB9" Font-Bold="True" ForeColor="#333333" />
                    <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                    <Columns>
                        <asp:TemplateField ItemStyle-Width="40px">
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemTemplate>
                                <asp:CheckBox ID="chkCertificado" runat="server" AutoPostBack="true" OnCheckedChanged="chkCertificado_CheckedChanged" >
                                </asp:CheckBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="NroCertificado" HeaderText="Nro Certificado" />
                        <asp:BoundField DataField="NroCertificadoReemplazo" HeaderText="Nro Certificado Reemplazo" />
                        <asp:BoundField DataField="NroCertificado" HeaderText="Nro Certificado" />
                        <asp:BoundField DataField="TipoCC" HeaderText="TipoCC" />
                        <asp:BoundField DataField="TipoCertificado" HeaderText="Tipo Certificado" />
                        <asp:BoundField DataField="MontoCC" HeaderText="MontoCC" />
                        <asp:BoundField DataField="MontoCCAceptado" HeaderText="MontoCC Aceptado" />
                        <asp:BoundField DataField="CursoPago" HeaderText="Curso Pago" />
                        <asp:BoundField DataField="EstadoCertificado" HeaderText="Estado Certificado" />
                    </Columns>
                    <EmptyDataTemplate><div align="center" class="CajaDialogoAdvertencia">
                        <br/><img src="../Imagenes/warning.gif" 
                                alt="No existen registros que cumplan el criterio solicitado" />
                        <br/>No existen Certificados para el tramite elegido
                        <br/><br/>
                        </div>
                    </EmptyDataTemplate>
                </asp:GridView>
            </div>
        </td>
        <td width="1%">&nbsp;</td>
    </tr>
</table>
<table style="width: 100%;" cellpadding="0" cellspacing="0" class="panelceleste">
    <tr>
        <td width="1%"></td>
        <td width="49%" align="left">
            <asp:Label ID="Label2" runat="server" Text="Instrucción Interna" CssClass="etiqueta10" Font-Bold="True"></asp:Label>
        </td>
        <td width="1%"></td>
        <td width="48%" align="left">
            <asp:Label ID="Label6" runat="server" Text="Asignacion de Certificados" CssClass="etiqueta10" Font-Bold="True"></asp:Label>
        </td>
        <td width="1%"></td>
    </tr>
    <tr>
        <td width="1%"></td>
        <td width="49%">
            <table cellpadding="0" cellspacing="0" class="panelceleste">
                <tr>
                    <td align="right">
                        <asp:Label ID="Label8" runat="server" Text="Numero :" CssClass="etiqueta10"></asp:Label>
                    </td>
                    <td align="left" class="auto-style2">
                        <asp:TextBox ID="txtNumeroInstrucInterna" runat="server" BackColor="#87CEEB" Width="75px"></asp:TextBox>
                    </td>
                    <td align="right">
                        <asp:Label ID="Label9" runat="server" Text="Fecha :" CssClass="etiqueta10"></asp:Label>
                    </td>
                    <td align="left">
						<asp:TextBox ID="txtFInstrucInterna" runat="server" BackColor="#87CEEB" Width="75px"></asp:TextBox>
						<cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" 
							runat="server" Enabled="True" TargetControlID="txtFInstrucInterna" 
							WatermarkText="__/__/____">
						</cc1:TextBoxWatermarkExtender>
						<asp:ImageButton ID="ImageButton3" ImageUrl="../Imagenes/pequeños/CalendarC_16x16.png" ImageAlign="Bottom" runat="server" />
						<cc1:CalendarExtender ID="CalendarExtender1" PopupButtonID="ImageButton3" runat="server" TargetControlID="txtFInstrucInterna"
							Format="dd/MM/yyyy">
						</cc1:CalendarExtender>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="auto-style1">
                        <asp:Label ID="Label11" runat="server" Text="Glosa :" CssClass="etiqueta10"></asp:Label>
                    </td>
                    <td align="left" class="auto-style3">
                        <asp:TextBox ID="txtGlosaInstrucInterna" runat="server" Text="" Height="71px" Width="291px" BackColor="#87CEEB"></asp:TextBox>
                    </td>
                    <td align="right" class="auto-style1">
                        &nbsp;&nbsp;
                    </td>
                    <td align="left" class="auto-style1">
                        &nbsp;&nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        &nbsp;&nbsp;
                    </td>
                    <td align="left" colspan="4">
                        &nbsp;&nbsp;
                    </td>
                </tr>
            </table>
        </td>
        <td width="1%"></td>
        <td width="48%">
            <table cellpadding="0" cellspacing="0" class="panelceleste">
                <tr>
                    <td align="left">
                        <div style="vertical-align: top; left: auto; height: auto; overflow: auto; width: 650px;" class="panelceleste">
                            <asp:GridView ID="gvAsignacionCertificados" runat="server"
                                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                                CellPadding="3" Font-Names="Verdana" Font-Size="8pt" AutoGenerateColumns="False"
                                DataKeyNames="NumeroAsignacion,IdOficina,IdTipoTramite">
                                <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                                <AlternatingRowStyle BackColor="#F7F7F7" />
                                <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                                <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                                <SelectedRowStyle BackColor="#FFDAB9" Font-Bold="True" ForeColor="#333333" />
                                <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                                <Columns>
                                    <asp:TemplateField ItemStyle-Width="40px">
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkAsignacion" runat="server" onclick="chkAsignacionChecked(this);">
                                            </asp:CheckBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="NumeroAsignacion">
                                        <ItemTemplate>
                                            <asp:Label ID="lblNumeroAsignacion" runat="server" Text='<%# Bind("NumeroAsignacion") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="IdOficina" HeaderText="IdOficina" />
                                    <asp:BoundField DataField="Clase_CC" HeaderText="Clase_CC" />
                                    <asp:BoundField DataField="FechaAsignacion" HeaderText="FechaAsignacion" />
                                    <asp:BoundField DataField="FechaEnvio" HeaderText="FechaEnvio" />
                                    <asp:BoundField DataField="NumeroInicial" HeaderText="NumeroInicial" />
                                    <asp:BoundField DataField="NumeroFinal" HeaderText="NumeroFinal" />
                                    <asp:BoundField DataField="UltimoNumeroAplicado" HeaderText="UltimoNumeroAplicado" />
                                    <asp:BoundField DataField="Observacion" HeaderText="Observacion" />
                                </Columns>
                                <EmptyDataTemplate><div align="center" class="CajaDialogoAdvertencia">
                                    <br/><img src="../Imagenes/warning.gif" 
                                            alt="No existen Certificados Asignados a su Area" />
                                    <br/>No existen Certificados Asignados a su Area
                                    <br/><br/>
                                    </div>
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td align="right">
						<asp:ImageButton ID="imgRenumera" runat="server"  ImageUrl="~/Imagenes/32imprimir.png" ToolTip="Imprimir Certificado Renumerado" OnClick="imgRenumera_Click"   /> 
						<asp:Label ID="Label10" CssClass="etiqueta8Blue" runat="server" Text="Renumera" /> 
                    </td>
                    <td align="right">
						<asp:ImageButton ID="imgVerCertificado" runat="server"  ImageUrl="~/Imagenes/32imprimir.png" ToolTip="Ver Certificado Renumerado" OnClick="imgVerCertificado_Click"   /> 
						<asp:Label ID="Label1" CssClass="etiqueta8Blue" runat="server" Text="Ver" /> 
                    </td>
                </tr>
            </table>                                
        </td>
        <td width="1%">&nbsp;</td>
    </tr>
</table>
<asp:ImageButton ID="imgVolver" runat="server"  ImageUrl="~/Imagenes/32Volver.png" ToolTip="Volver a la Página anterior" OnClick="btnVolver_Click" /> 
<asp:Label ID="lblTVolver" CssClass="etiqueta8Blue" runat="server" Text="Volver" /> 
</asp:Content>

