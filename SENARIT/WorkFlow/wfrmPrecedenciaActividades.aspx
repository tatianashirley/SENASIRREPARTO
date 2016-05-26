<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmPrecedenciaActividades.aspx.cs" Inherits="WorkFlow_wfrmPrecedenciaActividades"  StylesheetTheme="Modal"%>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="pnlGral">
        <asp:Panel ID="pnlDatos" runat="server" CssClass="pnlBody">
            <table style="width: 100%;">
                <tr>
                    <td colspan="7" align="center">
                        <asp:ImageButton ID="imgAux" runat="server" ImageUrl="~/Imagenes/16w.png" />
                        <asp:Label ID="lblTituloAUX" runat="server" CssClass="texto12" Text="Registro Precedencia de Actividades del Flujo"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label1" runat="server" Text="Tipo de Trámite:"></asp:Label>
                    </td>
                    <td align="left" colspan="5">
                        <asp:TextBox ID="txtTipoTramite" runat="server" CssClass="box" Enabled="False" Width="900px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvTipoTramite" runat="server" ControlToValidate="txtTipoTramite" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                    <td align="left">&nbsp;</td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label2" runat="server" Text="Flujo:"></asp:Label>
                    </td>
                    <td align="left" colspan="5">
                        <asp:TextBox ID="txtFlujo" runat="server" CssClass="box" Enabled="False" Width="900px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvFlujo" runat="server" ControlToValidate="txtFlujo" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                    <td align="left">&nbsp;</td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label3" runat="server" Text="Actividad:"></asp:Label>
                    </td>
                    <td align="left" colspan="5">
                        <asp:DropDownList ID="cboActividad" runat="server" CssClass="box" Width="900px">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="tfvActividad" runat="server" ControlToValidate="cboActividad" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                    <td align="left">&nbsp;</td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label16" runat="server" Text="Actividad Predecesora:"></asp:Label>
                    </td>
                    <td align="left" colspan="5">
                        <asp:DropDownList ID="cboActPredecesora" runat="server" CssClass="box" Width="900px">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="tfvTipoRestriccion0" runat="server" ControlToValidate="cboActPredecesora" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                    <td align="left">&nbsp;</td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label19" runat="server" Text="Descripción:"></asp:Label>
                    </td>
                    <td align="left" colspan="5">
                        <asp:TextBox ID="txtDescrip" runat="server" CssClass="box" MaxLength="500" Width="900px"></asp:TextBox>
                    </td>
                    <td align="left">&nbsp;</td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label6" runat="server" Text="Restricciones de Transición:"></asp:Label>
                    </td>
                    <td align="left" style="margin-left: 40px">
                        <asp:DropDownList ID="cboRestricTransicion" runat="server" CssClass="box" Width="250px">
                        </asp:DropDownList>
                    </td>
                    <td align="right" style="margin-left: 40px">
                        &nbsp;</td>
                    <td align="left">
                        &nbsp;</td>
                    <td align="right">
                        &nbsp;</td>
                    <td align="left">
                        &nbsp;</td>
                    <td align="left">&nbsp;</td>
                </tr>
                <tr>
                    <td align="right">
                        &nbsp;</td>
                    <td align="left" style="width: 350px">
                        <asp:CheckBox ID="chkGeneraCmpte" runat="server" Text="Genera comprobantes de traslado de documentos" />
                    </td>
                    <td align="right">
                        &nbsp;</td>
                    <td align="left">
                        <asp:CheckBox ID="chkManual" runat="server" Text="La transición se realiza desde la badeja de ejecución de trámites" />
                    </td>
                    <td align="right">&nbsp;</td>
                    <td align="left">
                        &nbsp;</td>
                    <td align="left">&nbsp;</td>
                </tr>
                <tr>
                    <td align="right">&nbsp;</td>
                    <td align="left" style="width: 350px">
                        <asp:CheckBox ID="chkImpriCmpte" runat="server" Text="Impresión obligatoria del comprobante de traslado de documentos" />
                    </td>
                    <td align="right">&nbsp;</td>
                    <td align="left">
                        <asp:CheckBox ID="chkAlerta" runat="server" Text="La transición genera una alerta para el destinatario" />
                    </td>
                    <td align="right">&nbsp;</td>
                    <td align="left">&nbsp;</td>
                    <td align="left">&nbsp;</td>
                </tr>
                <tr>
                    <td align="right">&nbsp;</td>
                    <td align="left" style="width: 350px">
                        <asp:CheckBox ID="chkTransMasiva" runat="server" Text="La transición debe realizarse a través de una asignación" />
                    </td>
                    <td align="right">&nbsp;</td>
                    <td align="left">
                        <asp:CheckBox ID="chkAnonimo" runat="server" Text="La transición se efectúa a un grupo de usuarios" />
                    </td>
                    <td align="right">&nbsp;</td>
                    <td align="left">&nbsp;</td>
                    <td align="left">&nbsp;</td>
                </tr>
                <tr>
                    <td align="right">&nbsp;</td>
                    <td align="left" style="width: 350px">
                        <asp:CheckBox ID="chkRetroceso" runat="server" Text="Retroceso:" />
                    </td>
                    <td align="right">&nbsp;</td>
                    <td align="left">
                        <asp:CheckBox ID="chkUsuarioActual" runat="server" Text="Usuario Actual" />
                    </td>
                    <td align="right">&nbsp;</td>
                    <td align="left">&nbsp;</td>
                    <td align="left">&nbsp;</td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label17" runat="server" Text="Actividades Paralelas:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtActParalelas" runat="server" CssClass="box"></asp:TextBox>
                        <asp:RangeValidator ID="ravActParalela" runat="server" ControlToValidate="txtActParalelas" ErrorMessage="Fuera de rango" MaximumValue="32767" MinimumValue="1" Type="Integer"></asp:RangeValidator>
                    </td>
                    <td>
                        <asp:Label ID="Label18" runat="server" Text="Regla Actividades Paralelas:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtReglaActParalelas" runat="server" CssClass="box" Width="380px" MaxLength="100"></asp:TextBox>
                    </td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label11" runat="server" Text="Mensaje:"></asp:Label>
                    </td>
                    <td align="left" colspan="3">
                        <asp:TextBox ID="txtMensajeAlerta" runat="server" CssClass="box" Width="900px" MaxLength="1000"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="7" align="center">
                        <asp:ImageButton ID="imgAtras0" runat="server" AlternateText="Atrás" CausesValidation="False" ImageUrl="~/Imagenes/azulAtras.png" OnClick="imgAtras_Click" DescriptionUrl="Volver" />
                        <asp:Button ID="btnNuevo" runat="server" CausesValidation="False" CssClass="btnPrin" OnClick="btnNuevo_Click" Text="Nuevo" />
                        <asp:Button ID="btnGrabar" runat="server" CssClass="btnPrin" OnClick="btnGrabar_Click" Text="Grabar" />
                        <cc1:ConfirmButtonExtender ID="btnGrabar_ConfirmButtonExtender" runat="server" ConfirmText="¿Esta seguro de guardar/modificar el registro?" TargetControlID="btnGrabar">
                        </cc1:ConfirmButtonExtender>
                        <asp:Button ID="btnEliminar" runat="server" CssClass="btnPrin" Enabled="False" OnClick="btnEliminar_Click" Text="Eliminar" />
                        <cc1:ConfirmButtonExtender ID="btnEliminar_ConfirmButtonExtender" runat="server" ConfirmText="¿Esta seguro de eliminar el registro?" TargetControlID="btnEliminar">
                        </cc1:ConfirmButtonExtender>
                    </td>
                </tr>
                <tr>
                    <td colspan="4"></td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td colspan="7" align="center">
                        <div style="width: 1100px; overflow-x: scroll" align="center">                        
                            <asp:GridView ID="gvPrecedAct" runat="server" AllowPaging="True" OnPageIndexChanging="gvPrecedAct_PageIndexChanging" OnSelectedIndexChanged="gvPrecedAct_SelectedIndexChanged" DataKeyNames="IdNodo,IdNodoPred" Width="2000px" AutoGenerateColumns="False">
                                <HeaderStyle CssClass="cssHeaderImg" />
                                <Columns>
                                    <asp:CommandField ButtonType="Image" HeaderText="Elegir" SelectImageUrl="~/imagenes/16siguiente.png" SelectText="Seleccionar" ShowHeader="True" ShowSelectButton="True" />
                                    <asp:BoundField DataField="IdNodo" HeaderText="Id.Nodo"/>
                                    <asp:BoundField DataField="DescIdNodo" HeaderText="Descripción Nodo"/>
                                    <asp:BoundField DataField="IdNodoPred" HeaderText="Id.Nodo Pred."/>
                                    <asp:BoundField DataField="DescIdNodoPred" HeaderText="Desc. Nodo Pred."/>
                                    <asp:BoundField DataField="IdGrupoRestriccion" HeaderText="Id.Grupo Restric."/>
                                    <asp:BoundField DataField="FLagGeneraCbteRspldo" HeaderText="Gen.Cmpte.Resp."/>
                                    <asp:BoundField DataField="FlagImrimeCbteRspldo" HeaderText="Imp.Cmpte.Resp."/>
                                    <asp:BoundField DataField="FlagTransicionMasiva" HeaderText="Trans.Masiva"/>
                                    <asp:BoundField DataField="NodoParalelo" HeaderText="Nodo Paralelo"/>
                                    <asp:BoundField DataField="ReglaNodoParalelo" HeaderText="Regla Nodo Paralelo"/>
                                    <asp:BoundField DataField="FlagManual" HeaderText="Manual"/>
                                    <asp:BoundField DataField="FlagAlerta" HeaderText="Alerta"/>
                                    <asp:BoundField DataField="MensajeAlerta" HeaderText="Mensaje Alerta"/>
                                    <asp:BoundField DataField="FlagAnonimo" HeaderText="Anónimo"/>
                                    <asp:BoundField DataField="FlagRetroceso" HeaderText="Retroceso"/>
                                    <asp:BoundField DataField="FlagUsuarioActual" HeaderText="Usuario Actual"/>
                                    <asp:BoundField DataField="Descripcion" HeaderText="Descripción"/>
                                </Columns>
                                <EmptyDataTemplate>
                                    <div align="center" class="CajaDialogoAdvertencia">
                                        <br/>
                                        <img src="../Imagenes/warning.gif" 
                                            alt="No existen registros" />
                                        <br/>
                                        Bandeja de Actividades Predecesoras vacía.
                                        <br/>
                                        <br/>
                                    </div>
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink ID="lnkEnlaces" runat="server" Enabled="False" Visible="False">Enlaces que deben ser visitados en forma previa a la transición</asp:HyperLink>
                    </td>
                    <td>
                        <asp:HyperLink ID="lnkDocumentos" runat="server" Enabled="False" Visible="False">Documentos que deben registrarse en forma previa a la transición</asp:HyperLink>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td align="right" class="recuadro_tr">Enlaces:</td>
                    <td align="left" class="recuadro_tr">
                        <asp:HyperLink ID="lnkProcesos" runat="server" Enabled="False">Procesos a ejecutarse al momento de realizar la transición</asp:HyperLink>
                        <br />
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </asp:Panel>

    </div>
</asp:Content>


