<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmConsultaAdmWF.aspx.cs" Inherits="WorkFlow_wfmConsultaAdmWF" StylesheetTheme="Modal"%>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=1.0.10618.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="pnlGral">
        <asp:Panel ID="pnlMaestro" runat="server" CssClass="pnlBody">
            <table style="width: 100%;">
                <tr>
                    <td align="center" style="width: 50px">
                        &nbsp;</td>
                    <td align="center" colspan="5">
                        <asp:ImageButton ID="imgAux" runat="server" ImageUrl="~/Imagenes/16w.png" />
                        <asp:Label ID="lblTituloAUX" runat="server" CssClass="texto12" Text="Consulta Administrativa"></asp:Label>
                    </td>
                    <td style="width: 50px">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 50px">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td style="width: 200px">&nbsp;</td>
                    <td style="width: 165px">&nbsp;</td>
                    <td style="width: 330px">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td style="width: 50px">&nbsp;</td>
                </tr>
                <tr>
                    <td align="right" style="width: 50px">
                        &nbsp;</td>
                    <td align="right">
                        <asp:Label ID="Label1" runat="server" Text="Oficina:"></asp:Label>
                    </td>
                    <td align="left" style="width: 200px">
                        <asp:DropDownList ID="cboOficina" runat="server" CssClass="box" Width="160px" OnSelectedIndexChanged="cboOficina_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                    <td align="right">
                        <asp:Label ID="Label2" runat="server" Text="Área:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="cboArea" runat="server" CssClass="box" Width="180px">
                        </asp:DropDownList>
                    </td>
                    <td align="left" rowspan="4">
                        <asp:ImageButton ID="ibtnBuscar" runat="server" ImageUrl="~/Imagenes/plomoBuscar.png" OnClick="ibtnBuscar_Click" />
                        <asp:ImageButton ID="ibtnImprimir" runat="server" AlternateText="Imprimir" Enabled="False" ImageUrl="~/Imagenes/plomoImprimir.png" OnClick="ibtnImprimir_Click" />
                        <asp:ImageButton ID="ibtnLimpiar" runat="server" ImageUrl="~/Imagenes/plomoLimpiar.png" OnClick="ibtnLimpiar_Click" CausesValidation="False" />
                    </td>
                    <td style="width: 50px">&nbsp;</td>
                </tr>
                <tr>
                    <td align="right" style="width: 50px">
                        &nbsp;</td>
                    <td align="right">
                        <asp:Label ID="Label7" runat="server" Text="Cuenta de Usuario:"></asp:Label>
                    </td>
                    <td align="left" style="width: 200px">
                        <asp:TextBox ID="txtUsuario" runat="server" CssClass="box" Width="150px" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                    </td>
                    <td align="right" style="width: 165px">
                        <asp:Label ID="Label8" runat="server" Text="Cuenta de Usuario Reasignado:"></asp:Label>
                    </td>
                    <td align="left" style="width: 330px">
                        <asp:TextBox ID="txtUsuaReasignado" runat="server" CssClass="box" Width="150px" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                        <asp:Button ID="btnReasignacion" runat="server" CausesValidation="False" CssClass="btnPrin" OnClick="btnReasignacion_Click" Text="Reasignación" />
                    </td>
                    <td style="width: 50px">&nbsp;</td>
                </tr>
                <tr>
                    <td align="right" style="width: 50px">&nbsp;</td>
                    <td align="right">
                        <asp:Label ID="Label9" runat="server" Text="Fecha (Desde):"></asp:Label>
                    </td>
                    <td align="left" style="width: 200px">
                        <asp:TextBox ID="txtFechaDesde" runat="server" CssClass="box" Width="75px"></asp:TextBox>
                        <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" Enabled="True" TargetControlID="txtFechaDesde" WatermarkText="__/__/____">
                        </cc1:TextBoxWatermarkExtender>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy" PopupButtonID="btnCalendario" TargetControlID="txtFechaDesde">
                        </cc1:CalendarExtender>
                        <asp:ImageButton ID="btnCalendario" runat="server" Height="16px" ImageAlign="Bottom" ImageUrl="../Imagenes/pequeños/CalendarC_16x16.png" />
                        <asp:RequiredFieldValidator ID="rfvFecDesde" runat="server" ControlToValidate="txtFechaDesde" ErrorMessage="*" ValidationGroup="RegBenef"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revFecDesde" runat="server" ControlToValidate="txtFechaDesde" ErrorMessage="dd/mm/yyyy" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d" ValidationGroup="RegBenef"></asp:RegularExpressionValidator>
                    </td>
                    <td align="right" style="width: 165px">
                        <asp:Label ID="Label10" runat="server" Text="Fecha (Desde):"></asp:Label>
                    </td>
                    <td align="left" style="width: 165px">
                        <asp:TextBox ID="txtFechaHasta" runat="server" CssClass="box" Width="75px"></asp:TextBox>
                        <cc1:TextBoxWatermarkExtender ID="txtFechaHasta_TextBoxWatermarkExtender" runat="server" Enabled="True" TargetControlID="txtFechaHasta" WatermarkText="__/__/____">
                        </cc1:TextBoxWatermarkExtender>
                        <cc1:CalendarExtender ID="txtFechaHasta_CalendarExtender" runat="server" Enabled="True" Format="dd/MM/yyyy" PopupButtonID="btnCalendario0" TargetControlID="txtFechaHasta">
                        </cc1:CalendarExtender>
                        <asp:ImageButton ID="btnCalendario0" runat="server" Height="16px" ImageAlign="Bottom" ImageUrl="../Imagenes/pequeños/CalendarC_16x16.png" />
                        <asp:RequiredFieldValidator ID="rfvFecHasta" runat="server" ControlToValidate="txtFechaHasta" ErrorMessage="*" ValidationGroup="RegBenef"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revFecHasta" runat="server" ControlToValidate="txtFechaHasta" ErrorMessage="dd/mm/yyyy" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d" ValidationGroup="RegBenef"></asp:RegularExpressionValidator>
                    </td>
                    <td style="width: 50px">&nbsp;</td>
                </tr>
                <tr>
                    <td align="right" style="width: 50px">&nbsp;</td>
                    <td align="right">
                        <asp:Label ID="Label11" runat="server" Text="Estado:"></asp:Label>
                    </td>
                    <td align="left" style="width: 200px">
                        <asp:DropDownList ID="cboEstado" runat="server" CssClass="box" Width="160px">
                            <asp:ListItem>Seleccione valor ...</asp:ListItem>
                            <asp:ListItem Value="I">Iniciada</asp:ListItem>
                            <asp:ListItem Value="F">Finalizada</asp:ListItem>
                            <asp:ListItem Value="W">En Espera</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td align="right" style="width: 165px">&nbsp;</td>
                    <td align="left" style="width: 165px">&nbsp;</td>
                    <td style="width: 50px">&nbsp;</td>
                </tr>
                <tr>
                    <td align="right" style="width: 50px">&nbsp;</td>
                    <td align="right">&nbsp;</td>
                    <td align="left" style="width: 200px">&nbsp;</td>
                    <td align="left" style="width: 165px">&nbsp;</td>
                    <td align="left" style="width: 330px">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td style="width: 50px">&nbsp;</td>
                </tr>
                <tr>
                    <td align="center" colspan="7"> 
                   <%--     <div style="width: 1100px; overflow-x: scroll" align="center">          --%>              
                            <asp:GridView ID="gvConsultaAdm" runat="server" AllowPaging="True" AutoGenerateColumns="False" BorderColor="#DADADA" OnPageIndexChanging="gvConsultaAdm_PageIndexChanging">
                                <HeaderStyle CssClass="cssHeaderImg" />
                                <Columns>                                    
                                    <asp:BoundField DataField="IdGrupoBeneficio" HeaderText="Id. Grupo Benef.">
                                    <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="IdTramite" HeaderText="Id. Tramite" />
                                    <asp:BoundField DataField="IdInstancia" HeaderText="Id. Instancia" >
                                    <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="IdNodo" HeaderText="Id. Nodo" >
                                    <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DescIdNodo" HeaderText="Descripción Nodo" />
                                    <asp:BoundField DataField="FechaHrInicio" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha Inicio" />
                                    <asp:BoundField DataField="TiempoTranscurrido" HeaderText="Tiempo Transcurrido" />
                                    <asp:BoundField DataField="DescEstado" HeaderText="Estado" />
                                </Columns>
                                <EmptyDataTemplate>
                                    <div align="center" class="CajaDialogoAdvertencia" style="width: 1100px">
                                        <br/>
                                        <img src="../Imagenes/warning.gif" 
                                            alt="No existen registros" />
                                        <br/>
                                        Bandeja de trámites vacía.
                                        <br/>
                                        <br/>
                                    </div>
                                </EmptyDataTemplate>
                        </asp:GridView>
                        <%--  </div>   --%>                
                    </td>
                </tr>
            </table>       
        </asp:Panel>
    </div>
</asp:Content>

