<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmActividadEnlacesAccesibles.aspx.cs" Inherits="WorkFlow_wfrmActividadEnlacesAccesibles"  StylesheetTheme="Modal"%>
<%@ MasterType VirtualPath="~/MasterPage.master"%>


<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style5 {
            height: 17px;
        }
        .auto-style6 {
            width: 50px;
            height: 17px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="pnlGral">
        <asp:Panel ID="pnlMaestro" runat="server" CssClass="pnlBody">
            <table style="width: 100%;">
            <tr>
                <td align="center" style="width: 50px">
                    &nbsp;</td>
                <td align="center" colspan="4">
                    <asp:ImageButton ID="imgAux" runat="server" Height="16px" ImageUrl="~/Imagenes/16w.png" />
                    <asp:Label ID="lblTituloAUX" runat="server" CssClass="texto12" Text="Enalces Accesibles desde una Actividad"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="auto-style10" style="width: 50px">
                    &nbsp;</td>
                <td align="right" class="auto-style10">
                    <asp:Label ID="Label1" runat="server" Text="Tipo Trámite:"></asp:Label>
                </td>
                <td align="left" colspan="3"><asp:TextBox ID="txtTipoTramite" runat="server" CssClass="box" Enabled="False" Width="900px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvTipoTramite" runat="server" ControlToValidate="txtTipoTramite" ErrorMessage="*" ValidationGroup="maestro"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right" class="auto-style10" style="width: 50px">
                    &nbsp;</td>
                <td align="right" class="auto-style10">
                    <asp:Label ID="Label2" runat="server" Text="Flujo:"></asp:Label>
                </td>
                <td align="left" colspan="3"><asp:TextBox ID="txtFlujo" runat="server" CssClass="box" Enabled="False" Width="900px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvFlujo" runat="server" ControlToValidate="txtFlujo" ErrorMessage="*" ValidationGroup="maestro"></asp:RequiredFieldValidator>
                </td>
            </tr>
                <tr>
                    <td align="right" class="auto-style10" style="width: 50px">
                        &nbsp;</td>
                    <td align="right" class="auto-style10">
                        <asp:Label ID="Label12" runat="server" Text="Actividad:"></asp:Label>
                    </td>
                    <td align="left" colspan="3">
                        <asp:TextBox ID="txtActividad" runat="server" CssClass="box" Enabled="False" Width="900px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvActividad" runat="server" ControlToValidate="txtActividad" ErrorMessage="*" ValidationGroup="maestro"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="auto-style10" style="width: 50px">
                        &nbsp;</td>
                    <td align="right" class="auto-style10">
                        <asp:Label ID="Label3" runat="server" Text="Secuencia:"></asp:Label>
                    </td>
                    <td align="left" class="auto-style9">
                        <asp:TextBox ID="txtSecuencia" runat="server" CssClass="box"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvSecuencia" runat="server" ControlToValidate="txtSecuencia" ErrorMessage="*" ValidationGroup="maestro"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="ravSecuencia" runat="server" ControlToValidate="txtSecuencia" ErrorMessage="Fuera de rango" MaximumValue="32767" MinimumValue="1" Type="Integer" ValidationGroup="maestro"></asp:RangeValidator>
                    </td>
                    <td align="right" style="width: 50px">
                        <asp:Label ID="Label4" runat="server" Text="Descripción:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtDescripcion" runat="server" Width="634px" CssClass="box" MaxLength="100"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvDescripcion" runat="server" ControlToValidate="txtDescripcion" ErrorMessage="*" ValidationGroup="maestro"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="auto-style10" style="width: 50px">
                        &nbsp;</td>
                    <td align="right" class="auto-style10">
                        <asp:Label ID="Label5" runat="server" Text="Links:"></asp:Label>
                    </td>
                    <td align="left" colspan="3">
                        <asp:TextBox ID="txtLinks" runat="server" CssClass="box" Width="900px" MaxLength="500"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvLinks" runat="server" ControlToValidate="txtLinks" ErrorMessage="*" ValidationGroup="maestro"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="auto-style10" style="width: 50px">&nbsp;</td>
                    <td align="right" class="auto-style10">
                        <asp:Label ID="Label13" runat="server" Text="Grupo Restricción:"></asp:Label>
                    </td>
                    <td align="left" colspan="3">
                        <asp:DropDownList ID="ddlGrupoRestriccion" runat="server" CssClass="box" Width="900px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="auto-style10" style="width: 50px">
                        &nbsp;</td>
                    <td align="right" class="auto-style10">
                        <asp:Label ID="Label6" runat="server" Text="Obligatorio:"></asp:Label>
                    </td>
                    <td align="left" class="auto-style9">
                        <asp:CheckBox ID="chkObli" runat="server" />
                    </td>
                    <td align="right" style="width: 50px">
                        <asp:Label ID="Label7" runat="server" Text="Activo:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:CheckBox ID="chkActivo" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="auto-style10" style="width: 50px">&nbsp;</td>
                    <td align="right" class="auto-style10">&nbsp;</td>
                    <td align="left" class="auto-style9">&nbsp;</td>
                    <td align="right" style="width: 50px">&nbsp;</td>
                    <td align="left">&nbsp;</td>
                </tr>
                <tr>
                    <td align="right" class="auto-style10" style="width: 50px">&nbsp;</td>
                    <td align="right" class="auto-style10">&nbsp;</td>
                    <td align="left" class="auto-style9">&nbsp;</td>
                    <td align="right" style="width: 50px">&nbsp;</td>
                    <td align="left">&nbsp;</td>
                </tr>
                <tr>
                    <td align="center" valign="middle" style="width: 50px">
                        &nbsp;</td>
                    <td align="center" colspan="4" valign="middle">
                        <asp:ImageButton ID="imgAtras0" runat="server" AlternateText="Atrás" CausesValidation="False" DescriptionUrl="Volver" ImageUrl="~/Imagenes/azulAtras.png" OnClick="imgAtras_Click" />
                        <asp:Button ID="btnNuevo" runat="server" CausesValidation="False" CssClass="btnPrin" OnClick="btnNuevo_Click" Text="Nuevo" ValidationGroup="maestro" Width="47px" />
                        <asp:Button ID="btnGuardar" runat="server" CssClass="btnPrin" OnClick="btnGuardar_Click" Text="Guardar" ValidationGroup="maestro" />
                        <cc1:ConfirmButtonExtender ID="btnGuardar_ConfirmButtonExtender" runat="server" ConfirmText="¿Esta seguro de guardar/modificar el registro?" TargetControlID="btnGuardar">
                        </cc1:ConfirmButtonExtender>
                        <asp:Button ID="btnEliminar" runat="server" CssClass="btnPrin" Enabled="False" OnClick="btnEliminar_Click" Text="Eliminar" ValidationGroup="maestro" />
                        <cc1:ConfirmButtonExtender ID="btnEliminar_ConfirmButtonExtender" runat="server" ConfirmText="¿Esta seguro de eliminar el registro?" TargetControlID="btnEliminar" />
                    </td>
                </tr>
                <tr>
                    <td align="right" class="auto-style5" style="width: 50px">&nbsp;</td>
                    <td align="right" class="auto-style5"></td>
                    <td align="left" class="auto-style5"></td>
                    <td align="right" class="auto-style6"></td>
                    <td align="left" class="auto-style5"></td>
                </tr>
                <tr>
                    <td align="center" style="width: 50px">
                        &nbsp;</td>
                    <td align="center" colspan="4">
                        <asp:GridView ID="gvActEnl" runat="server" AllowPaging="True" BorderColor="#DADADA" DataKeyNames="Secuencia" OnPageIndexChanging="gvActEnl_PageIndexChanging" OnSelectedIndexChanged="gvActEnl_SelectedIndexChanged">
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
                                    Bandeja de Enlaces Accesibles vacía.
                                    <br/>
                                    <br/>
                                </div>
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="auto-style10" style="width: 50px">&nbsp;</td>
                    <td align="right" class="auto-style10">&nbsp;</td>
                    <td align="left" class="auto-style9">&nbsp;</td>
                    <td align="right" style="width: 50px">&nbsp;</td>
                    <td align="left">&nbsp;</td>
                </tr>
        </table>    
        </asp:Panel>
        
        
    </div>
     <div class="pnlGral">
        <asp:Panel ID="pnlDetalle" runat="server" CssClass="pnlPest" Visible="False" >
            <table style="width: 100%;">
            <tr>
                <td colspan="4" align="center">
                    <asp:ImageButton ID="imgAux0" runat="server" Height="16px" ImageUrl="~/Imagenes/16w.png" />
                    <asp:Label ID="lblTituloAUX0" runat="server" CssClass="texto12" Text="Parámetros"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="Label10" runat="server" Text="Concepto:"></asp:Label>
                </td>
                <td align="left" style="width: 310px">
                    <asp:DropDownList ID="cboConcepto" runat="server" CssClass="box" Width="300px">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvConcepto" runat="server" ControlToValidate="cboConcepto" ErrorMessage="*" ValidationGroup="detalle"></asp:RequiredFieldValidator>
                </td>
                <td align="left">
                    <asp:CheckBox ID="chkSolicitud" runat="server" Text="Obtener de la solicitud" TextAlign="Left" />
                </td>
                <td>&nbsp;</td>
            </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label11" runat="server" Text="Comentarios:"></asp:Label>
                    </td>
                    <td align="left" colspan="2">
                        <asp:TextBox ID="txtComentarios" runat="server" CssClass="box" Width="900px" MaxLength="500"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td align="right">&nbsp;</td>
                    <td align="left" style="width: 310px">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td align="center" colspan="3">
                        <asp:Button ID="btnNuevoDet" runat="server" CausesValidation="False" CssClass="btnPrin" OnClick="btnNuevoDet_Click" Text="Nuevo" Width="47px" ValidationGroup="detalle" />
                        <asp:Button ID="btnGuardarDet" runat="server" CssClass="btnPrin" OnClick="btnGuardarDet_Click" Text="Guardar" ValidationGroup="detalle" />
                        <cc1:ConfirmButtonExtender ID="btnGuardarDet_ConfirmButtonExtender" runat="server" TargetControlID="btnGuardarDet" ConfirmText="¿Esta seguro de guardar/modificar el registro?">
                        </cc1:ConfirmButtonExtender>
                        <asp:Button ID="btnEliminarDet" runat="server" CssClass="btnPrin" Enabled="False" OnClick="btnEliminarDet_Click" Text="Eliminar" ValidationGroup="detalle"/>
                        <cc1:ConfirmButtonExtender ID="btnEliminarDet_ConfirmButtonExtender" runat="server" TargetControlID="btnEliminarDet" ConfirmText="¿Esta seguro de eliminar el registro?"/>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td align="right">&nbsp;</td>
                    <td align="left" style="width: 310px">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td align="center" colspan="3">
                        <asp:GridView ID="gvParam" runat="server" AllowPaging="True" BorderColor="#DADADA" DataKeyNames="IdConcepto" OnPageIndexChanging="gvParam_PageIndexChanging" OnSelectedIndexChanged="gvParam_SelectedIndexChanged">
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
                                    Bandeja de Parámetros vacía.
                                    <br/>
                                    <br/>
                                </div>
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td align="right">&nbsp;</td>
                    <td align="left" class="auto-style8">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
        </table>
        </asp:Panel>
        
    </div>
</asp:Content>

