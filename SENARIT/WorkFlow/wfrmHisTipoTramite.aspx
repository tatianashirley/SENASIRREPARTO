<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmHisTipoTramite.aspx.cs" Inherits="WorkFlow_wfrmHisTipoTramite" StylesheetTheme="Modal"%>
<%@ MasterType VirtualPath="~/MasterPage.master" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        <link href="EstiloWF.css" rel="stylesheet" type="text/css" />         
        <style type="text/css">
            .auto-style1 {
                height: 17px;
            }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <asp:Panel ID="pnlTipoTram" runat="server">
            <table style="width: 100%;">
                <tr>
                    <td class="filaTit" colspan="6">
                        <asp:ImageButton ID="imgAux" runat="server" ImageUrl="~/Imagenes/16w.png" />
                        <asp:Label ID="lblTituloAUX" runat="server" CssClass="etiqueta20" Text="REGISTRO TIPO TRÁMITE"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label1" runat="server" Text="ID Tipo Trámte:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtIdTipoTramite" runat="server" CssClass="box" Width="108px"  onkeyup="this.value=this.value.toUpperCase()" MaxLength="20"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvIdTipoTramite" runat="server" ControlToValidate="txtIdTipoTramite" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                    <td align="right">
                        <asp:Label ID="Label7" runat="server" Text="Descripción:"></asp:Label>
                    </td>
                    <td align="left" colspan="3">
                        <asp:TextBox ID="txtDescripcion" runat="server" CssClass="box" Width="590px" MaxLength="100"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvDescripcion" runat="server" ControlToValidate="txtDescripcion" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label2" runat="server" Text="Trámite Superior:"></asp:Label>
                    </td>
                    <td align="left" colspan="5">
                        <asp:DropDownList ID="cboTramiteSuperior" runat="server" CssClass="box" Width="950px">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvTipoTramiteSup" runat="server" ControlToValidate="cboTramiteSuperior" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label5" runat="server" Text="Módulo:"></asp:Label>
                    </td>
                    <td align="left" colspan="5">
                        <asp:DropDownList ID="cboModulo" runat="server" CssClass="box" Width="950px">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvIdModulo" runat="server" ControlToValidate="cboModulo" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label3" runat="server" Text="Es Agrupador:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:CheckBox ID="chkEsAgrupador" runat="server"/>
                    </td>
                    <td align="right">
                        <asp:Label ID="Label9" runat="server" Text="Admite Excepciones:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:CheckBox ID="chkAdmiteExcepciones" runat="server" />
                    </td>
                    <td align="right">
                        <asp:Label ID="Label11" runat="server" Text="Admite reinicio de trámites:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:CheckBox ID="chkAdmReinicioTram" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label6" runat="server" Text="Máx días inicio trámite:"></asp:Label>
                    </td>
                    <td align="left" width="240">
                        <asp:TextBox ID="txtMaxDiasIniTram" runat="server" CssClass="box" Width="100px"></asp:TextBox>
                        <cc1:NumericUpDownExtender ID="txtMaxDiasIniTram_NumericUpDownExtender" runat="server" TargetControlID="txtMaxDiasIniTram" Minimum="1" Maximum="9999999" Width="120"/>
                        <asp:RequiredFieldValidator ID="rfvMaxDiasTram" runat="server" ControlToValidate="txtMaxDiasIniTram" ErrorMessage="*" InitialValue="0"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="ravMaxDias" runat="server" ControlToValidate="txtMaxDiasIniTram" ErrorMessage="Fuera de rango" MaximumValue="32767" MinimumValue="1" Type="Integer"></asp:RangeValidator>
                    </td>
                    <td align="right">
                        <asp:Label ID="Label8" runat="server" Text="Máx. días inactivo:"></asp:Label>
                    </td>
                    <td align="left" width="240">
                        <asp:TextBox ID="txtMaxDiasInactivo" runat="server" CssClass="box" Width="100px"></asp:TextBox>
                        <cc1:NumericUpDownExtender ID="txtMaxDiasInactivo_NumericUpDownExtender" runat="server" TargetControlID="txtMaxDiasInactivo" Minimum="1" Maximum="9999999" Width="120"/>
                        <asp:RequiredFieldValidator ID="rfvMaxDiasInac" runat="server" ControlToValidate="txtMaxDiasInactivo" ErrorMessage="*" InitialValue="0"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="ravMaxDias0" runat="server" ControlToValidate="txtMaxDiasInactivo" ErrorMessage="Fuera de rango" MaximumValue="32767" MinimumValue="1" Type="Integer"></asp:RangeValidator>
                    </td>
                    <td align="right">
                        <asp:Label ID="Label10" runat="server" Text="Grupo Restricción:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="cboGrupoRestric" runat="server" CssClass="box" Width="230px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="auto-style1"></td>
                    <td align="left" class="auto-style1"></td>
                    <td class="auto-style1"></td>
                    <td class="auto-style1"></td>
                    <td class="auto-style1"></td>
                    <td class="auto-style1"></td>
                </tr>
                <tr>
                    <td colspan="6" align="center">
                        <%--<asp:Button ID="btnNuevo" runat="server" CausesValidation="False" CssClass="btnPrin" OnClick="btnNuevo_Click" Text="Nuevo" />--%>
                        <asp:Button ID="btnGrabar" runat="server" CssClass="btnPrin" OnClick="btnGrabar_Click" Text="Grabar" />
                        <cc1:ConfirmButtonExtender ID="btnGrabar_ConfirmButtonExtender" runat="server" TargetControlID="btnGrabar" ConfirmText="¿Esta seguro de guardar/modificar el registro?">
                        </cc1:ConfirmButtonExtender>
                        <%--<asp:Button ID="btnEliminar" runat="server" CssClass="btnPrin" Enabled="False" OnClick="btnEliminar_Click" Text="Eliminar" />
                        <cc1:ConfirmButtonExtender ID="btnEliminar_ConfirmButtonExtender" runat="server" TargetControlID="btnEliminar" ConfirmText="¿Esta seguro de eliminar el registro?">
                        </cc1:ConfirmButtonExtender>--%>
                        <asp:HiddenField ID="hdfHisInstancia" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="left"></td>
                    <td align="left"></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td align="center" colspan="6">
                        <asp:GridView ID="gvTipoTramites" runat="server" OnSelectedIndexChanged="gvTipoTramites_SelectedIndexChanged" BorderColor="#DADADA" AllowPaging="True" DataKeyNames="IdHisInstancia,IdTipoTramite" OnPageIndexChanging="gvTipoTramites_PageIndexChanging">
                            <HeaderStyle CssClass="cssHeaderImg" />
                            <Columns>
                                <asp:CommandField ButtonType="Image" HeaderText="Elegir" SelectImageUrl="~/imagenes/16siguiente.png" SelectText="Seleccionar" ShowHeader="True" ShowSelectButton="True" />
                            </Columns>
                            <EmptyDataTemplate>
                                <div align="center" class="CajaDialogoAdvertencia">
                                    <br/>
                                    <img src="../Imagenes/warning.gif" 
                                        alt="No existen registros" />
                                    <br/>
                                    Bandeja de Tipo de Trámites vacía.
                                    <br/>
                                    <br/>
                                </div>
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="6"></td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="pnlLinks" runat="server" CssClass="panelceleste">
            <table style="width: 100%;">
                <tr>
                    <td colspan="3" align="left">
                    </td>
                </tr>
                <tr>
                    <td align="right" width="150">
                        <asp:Label ID="Label23" runat="server" Text="Asociar Tipo de Trámite:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:HyperLink ID="lnkTipoTramRolUsua" runat="server">Roles que Intervienen en el Tipo de Trámite</asp:HyperLink>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td align="left" width="150">
                    </td>
                    <td align="left">
                        <asp:HyperLink ID="lnkTipoTramConcepto" runat="server" Enabled="False">Conceptos Asociados al Tipo de Trámite</asp:HyperLink>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td align="left" class="auto-style9" width="150">
                    </td>
                    <td align="left" class="auto-style9">
                        <asp:HyperLink ID="lnkTipoTramTipoDoc" runat="server" Enabled="False">Tipos de Documento Asociados al Tipo de Trámite</asp:HyperLink>
                    </td>
                    <td class="auto-style9"></td>
                </tr>
                <tr>
                    <td align="left" width="150">
                        &nbsp;</td>
                    <td align="left">
                        <asp:HyperLink ID="lnkTipoTramFlujo" runat="server" Enabled="False">Flujos que Conforman el Tipo de Trámite</asp:HyperLink>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td align="left">
                        &nbsp;</td>
                    <td align="left">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </asp:Panel>

    </div>
</asp:Content>

