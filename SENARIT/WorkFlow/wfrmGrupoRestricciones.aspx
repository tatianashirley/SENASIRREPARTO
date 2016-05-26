<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmGrupoRestricciones.aspx.cs" Inherits="WorkFlow_wfrmGrupoRestricciones"  StylesheetTheme="Modal"%>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style5 {
            height: 25px;
        }
        .auto-style7 {
            height: 23px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="pnlGral">
        <asp:Panel ID="pnlMaestro" runat="server" CssClass="pnlBody">
            <table style="width: 100%;">
                <tr>
                    <td colspan="4" align="center"><asp:ImageButton ID="imgAux" runat="server" ImageUrl="~/Imagenes/16w.png" />
                <asp:Label ID="lblTituloAUX" runat="server"
                    Text="Registro Grupo de Restricciones" CssClass="texto12"></asp:Label></td>
                </tr>
                <tr>
                    <td align="right" style="width: 150px">
                        <asp:Label ID="Label1" runat="server" Text="ID Grupo de Restricciones"></asp:Label>
                    </td>
                    <td align="left" style="width: 270px">
                        <asp:TextBox ID="txtIdGrupRestric" runat="server" CssClass="box"></asp:TextBox>                      
                        <asp:RequiredFieldValidator ID="rfvIdGrupoRestric" runat="server" ControlToValidate="txtIdGrupRestric" ErrorMessage="*" ValidationGroup="maestro"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="ravIdGrupRest" runat="server" ControlToValidate="txtIdGrupRestric" ErrorMessage="Fuera de rango" MaximumValue="2147483647" MinimumValue="1" Type="Integer"></asp:RangeValidator>
                    </td>
                    <td align="right">
                        <asp:Label ID="Label3" runat="server" Text="Descripción:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtDescripcion" runat="server" Width="435px" CssClass="box" MaxLength="100"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfDescripcion" runat="server" ControlToValidate="txtDescripcion" ErrorMessage="*" ValidationGroup="maestro"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 150px">
                        <asp:Label ID="Label2" runat="server" Text="Comentarios:"></asp:Label>
                    </td>
                    <td align="left" colspan="3">
                        <asp:TextBox ID="txtComentarios" runat="server" Width="800px" CssClass="box" MaxLength="500"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 150px">
                        <asp:Label ID="Label4" runat="server" Text="Regla de Evaluación:"></asp:Label>
                    </td>
                    <td align="left" colspan="3" class="auto-style7">
                        <asp:TextBox ID="txtReglaEvaluacion" runat="server" Width="800px" CssClass="box" MaxLength="8000"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 150px"></td>
                    <td align="left" colspan="3"></td>
                </tr>
                <tr>
                    <td align="center" colspan="4" class="filaBtn">
                        <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="btnPrin" OnClick="btnNuevo_Click" Width="47px" CausesValidation="False" />
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btnPrin" OnClick="btnGuardar_Click" ValidationGroup="maestro" />
                        <cc1:ConfirmButtonExtender ID="btnGuardar_ConfirmButtonExtender" runat="server" TargetControlID="btnGuardar" ConfirmText="¿Esta seguro de guardar/modificar el registro?">
                        </cc1:ConfirmButtonExtender>
                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btnPrin" Enabled="False" OnClick="btnEliminar_Click" />
                        <cc1:ConfirmButtonExtender ID="btnEliminar_ConfirmButtonExtender" runat="server" TargetControlID="btnEliminar" ConfirmText="¿Esta seguro de eliminar el registro?">
                        </cc1:ConfirmButtonExtender>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="4"></td>
                </tr>
                <tr>
                    <td align="center" colspan="4">
                        <asp:GridView ID="gvGrupRestric" runat="server" DataKeyNames="IdGrupoRestriccion" OnSelectedIndexChanged="gvGrupRestric_SelectedIndexChanged" AllowPaging="True" OnPageIndexChanging="gvGrupRestric_PageIndexChanging">
                            <Columns>
                                <asp:CommandField ButtonType="Image" HeaderText="Elegir" SelectImageUrl="~/imagenes/16siguiente.png" SelectText="Seleccionar" ShowHeader="True" ShowSelectButton="True" />
                            </Columns>
                            <HeaderStyle CssClass="cssHeaderImg" />
                             <EmptyDataTemplate>
                                <div align="center" class="CajaDialogoAdvertencia">
                                    <br/>
                                    <img src="../Imagenes/warning.gif" 
                                        alt="No existen Tramites por Asignar para el usuario en curso." />
                                    <br/>
                                    Bandeja de Grupo de Restricciones vacia.
                                    <br/>
                                    <br/>
                                </div>
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="4">&nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
    </div>
    <div class="pnlGral">
         <asp:Panel ID="pnlDetalle" runat="server" Visible="False" CssClass="pnlPest">
             <table style="width: 100%;">
                <tr>
                    <td align="center" colspan="7">
                        <asp:ImageButton ID="imgAux0" runat="server" ImageUrl="~/Imagenes/16w.png" />
                        <asp:Label ID="lblTituloAUX0" runat="server" CssClass="texto12" Text="Registro Detalle Grupo de Restricciones"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 150px">
                        <asp:Label ID="Label14" runat="server" Text="Restriccion:"></asp:Label>
                    </td>
                    <td align="left" colspan="6">
                        <asp:DropDownList ID="cboRestriccion" runat="server" CssClass="box" Width="800px">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rvRestriccion" runat="server" ControlToValidate="cboRestriccion" ErrorMessage="*" ValidationGroup="detalle"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 150px">
                        <asp:Label ID="Label15" runat="server" Text="Orden:"></asp:Label>
                    </td>
                    <td align="left" style="width: 260px">
                        <asp:TextBox ID="txtOrden" runat="server"></asp:TextBox>
                        <cc1:NumericUpDownExtender ID="txtOrden_NumericUpDownExtender" runat="server" TargetControlID="txtOrden" Width="100" Minimum="0" Maximum="32767">
                        </cc1:NumericUpDownExtender>
                        <asp:RequiredFieldValidator ID="rfRestriccion0" runat="server" ControlToValidate="txtOrden" ErrorMessage="*" ValidationGroup="detalle" InitialValue="0"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="ravOrden" runat="server" ControlToValidate="txtOrden" ErrorMessage="Fuera de rango" MaximumValue="32767" MinimumValue="1" Type="Integer" ValidationGroup="detalle"></asp:RangeValidator>
                    </td>
                    <td align="right" style="width: 100px">
                        <asp:Label ID="Label16" runat="server" Text="Subgrupo:"></asp:Label>
                    </td>
                    <td align="left" style="width: 280px">
                        <asp:TextBox ID="txtSubGrupo" runat="server"></asp:TextBox>
                        <cc1:NumericUpDownExtender ID="txtSubGrupo_NumericUpDownExtender" runat="server" TargetControlID="txtSubGrupo" Width="100" Minimum="0" Maximum="32767">
                        </cc1:NumericUpDownExtender>
                        <asp:RangeValidator ID="ravSubGrupo" runat="server" ControlToValidate="txtSubGrupo" ErrorMessage="Fuera de rango" MaximumValue="32767" MinimumValue="0" Type="Integer" ValidationGroup="detalle"></asp:RangeValidator>
                    </td>
                    <td align="left">
                        <asp:CheckBox ID="chkSubGrupoInclusivo" runat="server" Text="Subgrupo inclusivo:" TextAlign="Left" />
                    </td>
                    <td align="left">&nbsp;</td>
                    <td align="left">
                        &nbsp;</td>
                </tr>
                 <tr>
                     <td align="right" style="width: 150px">
                         <asp:Label ID="Label18" runat="server" Text="Procedimiento:"></asp:Label>
                     </td>
                     <td align="left" style="width: 260px">
                         <asp:TextBox ID="txtProcedimiento" runat="server" CssClass="box"></asp:TextBox>
                         <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Numbers"  TargetControlID="txtProcedimiento"  />
                     </td>
                     <td align="right" style="width: 100px">
                         <asp:Label ID="Label19" runat="server" Text="Parámetro:"></asp:Label>
                     </td>
                     <td align="left" style="width: 280px">
                         <asp:TextBox ID="txtParametro" runat="server" CssClass="box"></asp:TextBox>
                     </td>
                     <td align="left">&nbsp;</td>
                     <td align="left">&nbsp;</td>
                     <td align="left">&nbsp;</td>
                 </tr>
                <tr>
                    <td align="right" style="width: 150px">
                        <asp:Label ID="Label17" runat="server" Text="Regla de evaluación:"></asp:Label>
                    </td>
                    <td align="left" colspan="6" style="margin-left: 280px">
                        <asp:TextBox ID="txtReglaEvaluacionDet" runat="server" CssClass="box" Width="800px" MaxLength="1000"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 150px">&nbsp;</td>
                    <td align="left" colspan="3">&nbsp;</td>
                    <td align="left">&nbsp;</td>
                    <td align="center">&nbsp;</td>
                    <td align="center">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="7" align="center" class="auto-style5">
                        <asp:Button ID="btnNuevoDet" runat="server" CssClass="btnPrin" OnClick="btnNuevoDet_Click" Text="Nuevo" CausesValidation="False" />
                        <asp:Button ID="btnGuardarDet" runat="server" CssClass="btnPrin" Text="Guardar" OnClick="btnGuardarDet_Click" ValidationGroup="detalle" />
                        <cc1:ConfirmButtonExtender ID="btnGuardarDet_ConfirmButtonExtender" runat="server" TargetControlID="btnGuardarDet" ConfirmText="¿Esta seguro de guardar/modificar el registro?">
                        </cc1:ConfirmButtonExtender>
                        <asp:Button ID="btnEliminarDet" runat="server" CssClass="btnPrin" Enabled="False" Text="Eliminar" OnClick="btnEliminarDet_Click" />
                        <cc1:ConfirmButtonExtender ID="btnEliminarDet_ConfirmButtonExtender" runat="server" TargetControlID="btnEliminarDet" ConfirmText="¿Esta seguro de eliminar el registro?">
                        </cc1:ConfirmButtonExtender>
                    </td>
                </tr>
                <tr>
                    <td align="center"></td>
                    <td align="center" colspan="3"></td>
                    <td align="center">&nbsp;</td>
                    <td align="center"></td>
                    <td align="center"></td>
                </tr>
                <tr>
                    <td colspan="7" align="center">
                        <asp:GridView ID="gvGrupoRestricDet" runat="server" AllowPaging="True" DataKeyNames="IdRestriccion" OnPageIndexChanging="gvGrupoRestricDet_PageIndexChanging" OnSelectedIndexChanged="gvGrupoRestricDet_SelectedIndexChanged">
                            <Columns>
                                <asp:CommandField ButtonType="Image" HeaderText="Elegir" SelectImageUrl="~/imagenes/16siguiente.png" SelectText="Seleccionar" ShowHeader="True" ShowSelectButton="True" />
                            </Columns>
                            <HeaderStyle CssClass="cssHeaderImg" />
                            <EmptyDataTemplate>
                                <div align="center" class="CajaDialogoAdvertencia">
                                    <br/>
                                    <img src="../Imagenes/warning.gif" 
                                        alt="No existen registros." />
                                    <br/>
                                    Bandeja de Detalle de Grupo Restricción vacia.
                                    <br/>
                                    <br/>
                                </div>
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td align="right">&nbsp;</td>
                    <td align="left" colspan="3">&nbsp;</td>
                    <td align="left">&nbsp;</td>
                    <td align="center">&nbsp;</td>
                    <td align="center">&nbsp;</td>
                </tr>
            </table>

         </asp:Panel>
    </div>
</asp:Content>

