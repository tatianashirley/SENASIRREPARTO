<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmBandejaAsignacion.aspx.cs" Inherits="Asignacion_Principal" StylesheetTheme="Modal" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" language="javascript" src="../js/InicioTramite/registro.js"></script>
    <script type="text/javascript">
        function chkAll(objRef) {
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
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="FondoAplicacion">
        <table width="100%" border="0" cellpadding="false" cellspacing="false">
            <tr>
                <td width="20%">
                    <asp:Label ID="lblTituloSistema" runat="server" Font-Bold="True" ForeColor="Navy"></asp:Label>
                </td>
                <td width="60%" align="center">
                    <asp:Label ID="lblSubTitulo" runat="server" Font-Bold="True" ForeColor="#CC0000" Font-Size="17px"></asp:Label>
                </td>
                <td align="right" width="20%">
                    <asp:HiddenField runat="server" ID="hfTabla" />
                    <asp:HiddenField runat="server" ID="hddProceso" />
                    <asp:HiddenField runat="server" ID="hddCodigo" />
                    <asp:HiddenField runat="server" ID="hddObservado" />
                    <asp:HiddenField runat="server" ID="hddElimina" />
                </td>
            </tr>
        </table>
    </div>
    <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0">

        <cc1:TabPanel ID="TabAsignacion" runat="server" HeaderText="Asignación Trámites Registro CC">
            <ContentTemplate>
                <asp:Panel ID="pnlAsignacion" runat="server" CssClass="panelprincipal">
                    <table width="100%">
                        <tr>
                            <td align="right" width="25%">
                                <label style="color: red">*</label>
                                <asp:Label ID="lblUsuarioDestino" runat="server" CssClass="etiqueta10">Usuario Destino:</asp:Label>
                            </td>
                            <td align="left" width="15%">
                                <asp:DropDownList runat="server" ID="ddlUsuarioDestino" Width="150px" onKeyPress="return disableEnterKey(event)" AutoPostBack="true" OnSelectedIndexChanged="ddlUsuarioDestino_SelectedIndexChanged"></asp:DropDownList>
                            </td>
                            <td align="right" width="15%">
                                <label style="color: red">*</label>
                                <asp:Label ID="lblAreaDestino" runat="server" CssClass="etiqueta10">Tipo Actividad:</asp:Label>
                            </td>
                            <td align="left" width="25%">
                                <asp:DropDownList runat="server" ID="ddlAreaDestino" Width="150px" onKeyPress="return disableEnterKey(event)" AutoPostBack="true" OnSelectedIndexChanged="ddlAreaDestino_SelectedIndexChanged"></asp:DropDownList>
                            </td>                            
                        </tr>
                        <tr>
                            <td align="right">
                                <label style="color: red">*</label>
                                <asp:Label ID="lblTramite" runat="server" CssClass="etiqueta10">Trámite:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox runat="server" ID="txtTramite" Width="150px" MaxLength="15" onkeyup="this.value=this.value.toUpperCase()" onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                                <asp:ImageButton ID="btnBuscarTramite" runat="server" ImageUrl="~/Imagenes/16Buscar.png" Style="height: 16px" OnClick="btnBuscarTramite_Click" />
                                <cc1:FilteredTextBoxExtender ID="txtTramite_FilteredTextBoxExtender"
                                    runat="server" FilterType="Numbers"
                                    TargetControlID="txtTramite">
                                </cc1:FilteredTextBoxExtender>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblObservacion" runat="server" CssClass="etiqueta10">Observación:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtObservacion" runat="server" onkeyup="this.value=this.value.toUpperCase()"
                                    Width="250px" onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" align="center">
                                <asp:Button runat="server" ID="btnAgregarManual" Text="Agregar" OnClick="btnAgregarManual_Click" Width="100px" CssClass="boton150" />&nbsp;                                
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" align="center">
                                <asp:GridView ID="gvTramites" runat="server"
                                    AutoGenerateColumns="False" CellPadding="4" EnableModelValidation="True"
                                    GridLines="None"
                                    BorderColor="#DADADA" BorderStyle="Solid" BorderWidth="1px" CssClass="etiqueta8Blue" SkinID="GridView"
                                    EnableTheming="True" Font-Names="Arial" Font-Size="9pt" OnRowCommand="gvTramites_RowCommand"
                                    DataKeyNames="IdTipoClasificador,TipoClasificador,IdUsuario,Usuario,IdTramite,TipoTramite,FechaInicioTramite,NumeroTramiteCrenta,Nombre,Matricula,Sector,Observaciones">
                                    <AlternatingRowStyle BackColor="White" />
                                    <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                                    <Columns>
                                        <asp:BoundField DataField="IdTipoClasificador" HeaderText="Trámite" Visible="false" />
                                        <asp:BoundField DataField="TipoClasificador" HeaderText="Tipo Actividad" />
                                        <asp:BoundField DataField="IdUsuario" HeaderText="IdUsuario" Visible="false" />
                                        <asp:BoundField DataField="Usuario" HeaderText="Usuario" />
                                        <asp:BoundField DataField="IdTramite" HeaderText="Trámite" />
                                        <asp:BoundField DataField="TipoTramite" HeaderText="Tipo Trámite" />
                                        <asp:BoundField DataField="FechaInicioTramite" HeaderText="Fecha Inicio" DataFormatString="{0:d}" />
                                        <asp:BoundField DataField="NumeroTramiteCrenta" HeaderText="CRENTA" />
                                        <asp:BoundField DataField="Nombre" HeaderText="Nombre Completo" />
                                        <asp:BoundField DataField="Matricula" HeaderText="Matrícula" />
                                        <asp:BoundField DataField="Sector" HeaderText="Sector" />
                                        <asp:BoundField DataField="Observaciones" HeaderText="Observaciones" />
                                        <asp:TemplateField HeaderText="Opciones">
                                            <ItemTemplate>
                                                <center>
                                                    <asp:ImageButton ID="imgEliminarTramite" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdEliminarTramite" ImageUrl="~/imagenes/nueva3/eliminar32.png" />
                                                </center>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EditRowStyle BackColor="#2461BF" />
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#EFF3FB" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" align="center">&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" align="center">
                                <asp:Button runat="server" ID="btnSiguientePM" Text="Siguiente" Width="100px" OnClick="btnSiguientePM_Click" CssClass="boton150" Visible="false" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>

                <asp:Panel ID="pnlBusquedaTramites" runat="server" CssClass="panelceleste">
                    <div style="overflow: auto; width: 500px; height: auto;">
                        <table width="100%">
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:Label runat="server" ID="lblEmpresaManual"><h3>Trámites</h3></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <cc1:ModalPopupExtender ID="mpeDatosTramite" runat="server" TargetControlID="lblEmpresaManual" PopupControlID="pnlBusquedaTramites" CancelControlID="btnCancelBusTramite" BackgroundCssClass="modalBackground"></cc1:ModalPopupExtender>
                                    <asp:GridView ID="gvSeleccionarTramite" runat="server" AutoGenerateColumns="False" EnableModelValidation="True"
                                        Width="100%" DataKeyNames="IdTramite,TipoTramite,FechaInicioTramite,NumeroTramiteCrenta,Nombre,Matricula,Sector"
                                        AllowPaging="True" PageSize="5" BorderColor="#DADADA" BorderStyle="Solid" BorderWidth="1px" CssClass="etiqueta8Blue" SkinID="GridView"
                                        EnableTheming="True" Font-Names="Arial" Font-Size="9pt" OnPageIndexChanging="gvSeleccionarTramite_PageIndexChanging" OnSelectedIndexChanging="gvSeleccionarTramite_SelectedIndexChanging">
                                        <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                                        <Columns>
                                            <asp:TemplateField ItemStyle-Width="40px">
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="chkAll" runat="server" onclick="chkAll(this);" />
                                                </HeaderTemplate>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkTramite" runat="server"></asp:CheckBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="IdTramite" HeaderText="Trámite" />
                                            <asp:BoundField DataField="TipoTramite" HeaderText="Tipo Trámite" />
                                            <asp:BoundField DataField="FechaInicioTramite" HeaderText="Fecha Inicio" DataFormatString="{0:d}" />
                                            <asp:BoundField DataField="NumeroTramiteCrenta" HeaderText="CRENTA" />
                                            <asp:BoundField DataField="Nombre" HeaderText="Nombre Completo" />
                                            <asp:BoundField DataField="Matricula" HeaderText="Matrícula" />
                                            <asp:BoundField DataField="Sector" HeaderText="Sector" />
                                        </Columns>
                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <PagerSettings Mode="NumericFirstLast" PageButtonCount="10" FirstPageText="Primera" LastPageText="Última" />
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                        <EmptyDataTemplate>
                                            <div align="center" class="CajaDialogoAdvertencia">
                                                <br />
                                                <img src="../Imagenes/warning.gif"
                                                    alt="No existen datos que correspondan al criterio especificado" />
                                                <br />
                                                No existen datos que correspondan al criterio especificado
                                                                                        <br />
                                            </div>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label3" runat="server" CssClass="etiqueta10">Observaciones:</asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtObservaciones" runat="server" Width="200px" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:Button ID="btnConfirmar" runat="server" Text="Agregar" CssClass="boton100" OnClick="btnConfirmar_Click" />&nbsp;
                                    <asp:Button ID="btnCancelBusTramite" runat="server" Text="Cancelar" CssClass="boton100" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </asp:Panel>

            </ContentTemplate>
        </cc1:TabPanel>

        <cc1:TabPanel ID="TabPanelCancelacion" runat="server" HeaderText="Cancelar Asignación Trámites Registro CC">
            <ContentTemplate>
                <asp:Panel ID="pnlCancelacion" runat="server" CssClass="panelprincipal">
                    <table width="100%">
                        <tr>
                            <td align="right" width="25%">
                                <label style="color: red">*</label>
                                <asp:Label ID="Label2" runat="server" CssClass="etiqueta10">Usuario Destino:</asp:Label>
                            </td>
                            <td align="left" width="15%">
                                <asp:DropDownList runat="server" ID="ddlUsuarioAsignacion" Width="150px" onKeyPress="return disableEnterKey(event)"></asp:DropDownList>
                                <td align="right">
                                    <label style="color: red">*</label>
                                    <asp:Label ID="Label4" runat="server" CssClass="etiqueta10">Código Asignación:</asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox runat="server" ID="txtGrupoAsignacion" Width="150px" MaxLength="10" onkeyup="this.value=this.value.toUpperCase()" onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1"
                                        runat="server" FilterType="Numbers"
                                        TargetControlID="txtGrupoAsignacion">
                                    </cc1:FilteredTextBoxExtender>
                                </td>
                        </tr>
                        <tr>
                            <td colspan="4">&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" align="center">
                                <asp:Button runat="server" ID="btnBuscarGrupo" Text="Buscar" OnClick="btnBuscarGrupo_Click" Width="100px" CssClass="boton150" />&nbsp;                                
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" align="center">
                                <asp:GridView ID="gvAsignaciones" runat="server"
                                    AutoGenerateColumns="False" CellPadding="4" EnableModelValidation="True"
                                    GridLines="None"
                                    BorderColor="#DADADA" BorderStyle="Solid" BorderWidth="1px" CssClass="etiqueta8Blue" SkinID="GridView"
                                    EnableTheming="True" Font-Names="Arial" Font-Size="9pt" OnRowCommand="gvAsignaciones_RowCommand"
                                    DataKeyNames="IdAsignacion,IdGrupoAsignacion,FechaAsignacion,IdTramite,TipoTramite,FechaInicioTramite,NumeroTramiteCrenta,Nombre,Matricula,Sector">
                                    <AlternatingRowStyle BackColor="White" />
                                    <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                                    <Columns>
                                        <asp:BoundField DataField="IdAsignacion" HeaderText="IdAsignacion" Visible="false" />
                                        <asp:BoundField DataField="IdGrupoAsignacion" HeaderText="Asignación" />
                                        <asp:BoundField DataField="FechaAsignacion" HeaderText="Fecha Asignación" DataFormatString="{0:d}" />
                                        <asp:BoundField DataField="IdTramite" HeaderText="Trámite" />
                                        <asp:BoundField DataField="TipoTramite" HeaderText="Tipo Trámite" />
                                        <asp:BoundField DataField="FechaInicioTramite" HeaderText="Fecha Inicio" DataFormatString="{0:d}" />
                                        <asp:BoundField DataField="NumeroTramiteCrenta" HeaderText="CRENTA" />
                                        <asp:BoundField DataField="Nombre" HeaderText="Nombre Completo" />
                                        <asp:BoundField DataField="Matricula" HeaderText="Matrícula" />
                                        <asp:BoundField DataField="Sector" HeaderText="Sector" />
                                        <asp:TemplateField HeaderText="Opciones">
                                            <ItemTemplate>
                                                <center>
                                                    <asp:ImageButton ID="imgEliminarTramite" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdEliminarTramite" ImageUrl="~/imagenes/nueva3/eliminar32.png" />
                                                </center>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EditRowStyle BackColor="#2461BF" />
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#EFF3FB" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" align="center">&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" align="center">
                                <asp:Button runat="server" ID="btnSiguiente2" Text="Siguiente" Width="100px" OnClick="btnSiguiente2_Click" CssClass="boton150" Visible="false" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>

            </ContentTemplate>
        </cc1:TabPanel>

        <cc1:TabPanel ID="TabPanelRecepcion" runat="server" HeaderText="Recepción Trámites Registro CC">
            <ContentTemplate>
                <asp:Panel ID="pnlRecepccion" runat="server" CssClass="panelprincipal">
                    <table width="100%">
                        <tr>
                            <td align="center">
                                <asp:GridView ID="gvRecepcion" runat="server"
                                    AutoGenerateColumns="False" CellPadding="4" EnableModelValidation="True"
                                    GridLines="None"
                                    BorderColor="#DADADA" BorderStyle="Solid" BorderWidth="1px" CssClass="etiqueta8Blue" SkinID="GridView"
                                    EnableTheming="True" Font-Names="Arial" Font-Size="9pt" 
                                    DataKeyNames="IdAsignacion,IdGrupoAsignacion,FechaAsignacion,IdTramite,TipoTramite,FechaInicioTramite,NumeroTramiteCrenta,Nombre,Matricula,Sector">
                                    <AlternatingRowStyle BackColor="White" />
                                    <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                                    <Columns>
                                        <asp:TemplateField ItemStyle-Width="40px">
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="chkAll" runat="server" onclick="chkAll(this);" />
                                            </HeaderTemplate>
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkAsignacion" runat="server"></asp:CheckBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="IdAsignacion" HeaderText="Id" />
                                        <asp:BoundField DataField="IdGrupoAsignacion" HeaderText="Asignación" />
                                        <asp:BoundField DataField="FechaAsignacion" HeaderText="Fecha Asignación" DataFormatString="{0:g}" />
                                        <asp:BoundField DataField="IdTramite" HeaderText="Trámite" />
                                        <asp:BoundField DataField="TipoTramite" HeaderText="Tipo Trámite" />
                                        <asp:BoundField DataField="FechaInicioTramite" HeaderText="Fecha Inicio" DataFormatString="{0:d}" />
                                        <asp:BoundField DataField="NumeroTramiteCrenta" HeaderText="CRENTA" />
                                        <asp:BoundField DataField="Nombre" HeaderText="Nombre Completo" />
                                        <asp:BoundField DataField="Matricula" HeaderText="Matrícula" />
                                        <asp:BoundField DataField="Sector" HeaderText="Sector" />                                        
                                        <asp:BoundField DataField="Observacion" HeaderText="Observaciones" />                                        
                                    </Columns>
                                    <EditRowStyle BackColor="#2461BF" />
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#EFF3FB" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button runat="server" ID="btnRecepcionar" Text="Aceptar" Width="100px" OnClick="btnRecepcionar_Click" CssClass="boton150" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>

            </ContentTemplate>
        </cc1:TabPanel>

    </cc1:TabContainer>
    <table width="100%" border="0" cellpadding="false" cellspacing="false">
        <tr>
            <td align="right">
                <input id="HiddenIdtramite" type="hidden" runat="server" />
                <asp:Label runat="server" ID="lblCompletarInformacion" Visible="false" CssClass="text_obs"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Button runat="server" ID="btnIniciarTramite" Text="Guardar" Visible="false" OnClick="btnIniciarTramite_Click" Style="height: 26px" />
                <asp:Button runat="server" ID="btnIniciarTramite2" Text="Guardar" Visible="false" OnClick="btnIniciarTramite2_Click" Style="height: 26px" />
                <asp:Button runat="server" ID="btnReporteAsignacion" Text="Reporte" Visible="false" OnClick="btnReporteAsignacion_Click" Style="height: 26px" />
                <asp:Button runat="server" ID="btnCancelar" Text="Cancelar" CssClass="buttonsNegative" OnClick="btnCancelar_Click" CausesValidation="false" />
            </td>
        </tr>
    </table>
</asp:Content>

