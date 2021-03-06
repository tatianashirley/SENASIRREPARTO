﻿<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmPreRenunciaAutomatica.aspx.cs" Inherits="InicioTramite_wfrmPreRenunciaAutomatica" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" language="javascript" src="../js/jquery-1.11.0.min.js"></script>
    <script type="text/javascript" language="javascript" src="../js/InicioTramite/comunes.js"></script>
</asp:Content>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="FondoAplicacion">
        <table width="100%" border="0" cellpadding="false" cellspacing="false">
            <tr>
                <td width="20%">
                    <asp:Label ID="lblTituloSistema" runat="server" Font-Bold="True" ForeColor="Navy"></asp:Label>
                </td>
                <td width="70%" align="center">
                    <asp:Label ID="lblSubTitulo" runat="server" Font-Bold="True" ForeColor="#CC0000" Font-Size="17px"></asp:Label>
                </td>
                <td width="10%" align="right">&nbsp;
                    <asp:HiddenField runat="server" ID="hddTipo" />
                </td>
            </tr>
        </table>
    </div>
    <asp:Panel ID="pnlCabeceraMalla" runat="server">
        <table width="100%" border="0" cellpadding="false" cellspacing="false">
            <tr>
                <td align="right" width="30%">
                    <label class="etiqueta10">Primer Apellido:</label>
                </td>
                <td align="left" width="10%">
                    <asp:TextBox ID="txtPaternoBuscar" runat="server" MaxLength="50" onkeyup="this.value=this.value.toUpperCase()" autofocus="autofocus" Width="200px" onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                    <cc1:FilteredTextBoxExtender ID="txtPaternoBuscar_FilteredTextBoxExtender"
                        runat="server" FilterType="Custom, LowercaseLetters, UppercaseLetters"
                        TargetControlID="txtPaternoBuscar" ValidChars="'áéíóúÁÉÍÓÚñÑ ">
                    </cc1:FilteredTextBoxExtender>
                </td>
                <td align="right" width="10%">
                    <label class="etiqueta10">Segundo Apellido:</label>
                </td>
                <td align="left" width="30%">
                    <asp:TextBox ID="txtMaternoBuscar" runat="server" MaxLength="50" onkeyup="this.value=this.value.toUpperCase()" Width="200px" onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                    <cc1:FilteredTextBoxExtender ID="txtMaternoBuscar_FilteredTextBoxExtender"
                        runat="server" FilterType="Custom, LowercaseLetters, UppercaseLetters"
                        TargetControlID="txtMaternoBuscar" ValidChars="'áéíóúÁÉÍÓÚñÑ ">
                    </cc1:FilteredTextBoxExtender>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <label class="etiqueta10">Primer Nombre:</label>
                </td>
                <td align="left">
                    <asp:TextBox ID="txtPrimerNormbreBuscar" runat="server" MaxLength="50" onkeyup="this.value=this.value.toUpperCase()" Width="200px" onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1"
                        runat="server" FilterType="Custom, LowercaseLetters, UppercaseLetters"
                        TargetControlID="txtPrimerNormbreBuscar" ValidChars="'áéíóúÁÉÍÓÚñÑ ">
                    </cc1:FilteredTextBoxExtender>
                </td>
                <td align="right">
                    <label class="etiqueta10">Segundo Nombre:</label>
                </td>
                <td align="left">
                    <asp:TextBox ID="txtSegundoNombreBuscar" runat="server" MaxLength="50" onkeyup="this.value=this.value.toUpperCase()" Width="200px" onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2"
                        runat="server" FilterType="Custom, LowercaseLetters, UppercaseLetters"
                        TargetControlID="txtSegundoNombreBuscar" ValidChars="'áéíóúÁÉÍÓÚñÑ ">
                    </cc1:FilteredTextBoxExtender>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <label class="etiqueta10">Número Documento:</label>
                </td>
                <td align="left">
                    <asp:TextBox ID="txtNumDocBuscar" runat="server" MaxLength="30" Width="200px" onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                    <cc1:FilteredTextBoxExtender ID="txtNumDocBuscar_FilteredTextBoxExtender"
                        runat="server" FilterType="Numbers"
                        TargetControlID="txtNumDocBuscar">
                    </cc1:FilteredTextBoxExtender>
                </td>
                <td align="right">
                    <label class="etiqueta10">NUA:</label>
                </td>
                <td align="left">
                    <asp:TextBox ID="txtCuaBuscar" runat="server" MaxLength="30" Width="200px" onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                    <cc1:FilteredTextBoxExtender ID="txtCuaBuscar_FilteredTextBoxExtender"
                        runat="server" FilterType="Numbers"
                        TargetControlID="txtCuaBuscar">
                    </cc1:FilteredTextBoxExtender>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <label class="etiqueta10">Número Trámite</label>
                </td>
                <td align="left">
                    <asp:TextBox ID="txtNumTramiteBuscar" runat="server" MaxLength="30" Width="200px" onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                </td>
                <td align="right">
                    <label class="etiqueta10">Matrícula</label>
                </td>
                <td align="left">
                    <asp:TextBox ID="txtMatriculaBuscar" runat="server" MaxLength="30" Width="200px" onKeyPress="return disableEnterKey(event)"></asp:TextBox>
                    <cc1:FilteredTextBoxExtender ID="txtMatriculaBuscar_FilteredTextBoxExtender1"
                        runat="server" FilterType="Custom, LowercaseLetters, UppercaseLetters,Numbers"
                        TargetControlID="txtPaternoBuscar" ValidChars="'áéíóúÁÉÍÓÚñÑ ">
                    </cc1:FilteredTextBoxExtender>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <label style="color: red">*</label>
                    <label class="etiqueta10">Tipo Renuncia</label>
                </td>
                <td align="left">
                    <asp:DropDownList runat="server" ID="ddlTipoRenuncia" Width="200px" onKeyPress="return disableEnterKey(event)"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="4" align="center">
                    <asp:RadioButton GroupName="rbtOpcion" ID="rbtPreIniciados" runat="server" Text="Renuncia Inicial" onKeyPress="return disableEnterKey(event)" />&nbsp;&nbsp;
                    <asp:RadioButton GroupName="rbtOpcion" ID="rbtRenunciados" runat="server" Text="Renunciados" onKeyPress="return disableEnterKey(event)" />
                </td>
            </tr>
            <tr>
                <td colspan="4">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="4" align="center">
                    <asp:Button runat="server" ID="imgbtnBuscar" OnClick="imgbtnBuscar_Click" Text="Buscar" Width="200px" />
                    <asp:Button runat="server" ID="imgbtnBorrar" OnClick="imgbtnBorrar_Click" Text="Limpiar" Width="200px" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnlRegistrosCabecera" runat="server">
        <table width="100%" border="0" cellpadding="false" cellspacing="false">
            <tr>
                <td align="center">
                    <asp:GridView ID="gvBusquedaTramiteCC" runat="server"
                        EnableModelValidation="True"
                        CellPadding="4" AllowPaging="True" PageSize="10"
                        ForeColor="#333333" EnableTheming="True" Font-Names="Arial" Font-Size="9pt"
                        CssClass="mGrid" PagerStyle-CssClass="pgr" GridLines="None" AutoGenerateColumns="False" OnPageIndexChanging="gvBusquedaTramiteCC_PageIndexChanging" OnRowCommand="gvBusquedaTramiteCC_RowCommand" OnRowDataBound="gvBusquedaTramiteCC_RowDataBound" OnSelectedIndexChanging="gvBusquedaTramiteCC_SelectedIndexChanging"
                        DataKeyNames="IdTramite,NUP,PrimerNombre,SegundoNombre,PrimerApellido,SegundoApellido,FechaNacimiento,CUA,Matricula,NumeroDocumento,ComplementoSEGIP,IdGrupoBeneficio,TramiteObservaciones">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="IdTramite" HeaderText="Trámite" ItemStyle-HorizontalAlign="Right" />
                            <asp:BoundField DataField="NUP" HeaderText="NUP" Visible="false" ItemStyle-HorizontalAlign="Right" />
                            <asp:BoundField DataField="PrimerNombre" HeaderText="Primer Nombre" />
                            <asp:BoundField DataField="SegundoNombre" HeaderText="Segundo Nombre" />
                            <asp:BoundField DataField="PrimerApellido" HeaderText="Primer Apellido" />
                            <asp:BoundField DataField="SegundoApellido" HeaderText="Segundo Apellido" />
                            <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha Nacimiento" DataFormatString="{0:d}" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="CUA" HeaderText="NUA" ItemStyle-HorizontalAlign="Right" />
                            <asp:BoundField DataField="Matricula" HeaderText="Matrícula" ItemStyle-HorizontalAlign="Right" />
                            <asp:BoundField DataField="NumeroDocumento" HeaderText="Número Documento" ItemStyle-HorizontalAlign="Right" />
                            <asp:BoundField DataField="ComplementoSEGIP" HeaderText="Complemento SEGIP" ItemStyle-HorizontalAlign="Left" Visible="false" />
                            <asp:BoundField DataField="NumeroTramiteCrenta" HeaderText="Número Trámite Antiguo" ItemStyle-Width="8px" ItemStyle-HorizontalAlign="Right" />
                            <asp:BoundField DataField="IdEstadoTramite" HeaderText="IdEstadoTramite" Visible="false" />
                            <asp:BoundField DataField="IdGrupoBeneficio" HeaderText="IdGrupoBeneficio" Visible="false" />
                            <asp:BoundField DataField="TramiteObservaciones" HeaderText="Observaciones" />
                            <asp:TemplateField HeaderText="Trámite">
                                <ItemTemplate>
                                    <center>
                                        <asp:ImageButton ID="imgTramite" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdTramite" ImageUrl="~/imagenes/nueva3/siguiente32.png" />
                                        <asp:ImageButton ID="imgBloquear" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdBloquear" ImageUrl="~/imagenes/nueva3/bloquear32.png" />
                                    </center>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <div align="center" class="CajaDialogoAdvertencia">
                                <br />
                                <img src="../Imagenes/warning.gif" alt="No existen datos que correspondan al criterio especificado" />
                                <br />
                                No existen datos que correspondan al criterio especificado<br />
                                <br />
                            </div>
                        </EmptyDataTemplate>
                        <SelectedRowStyle BackColor="#FFFF99" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerSettings Mode="NumericFirstLast" PageButtonCount="10" FirstPageText="Primera" LastPageText="Última" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </asp:Panel>

</asp:Content>
