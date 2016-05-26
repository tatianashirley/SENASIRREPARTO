<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmReportesPU.aspx.cs" Inherits="PagoUnico_wfrmReportesPU"  StylesheetTheme="Modal"%>
<%@ MasterType VirtualPath="~/MasterPage.master" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=1.0.10618.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            height: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="pnlGral">    
        <asp:Panel ID="pnlDatos" runat="server" CssClass="pnlBody">
            <table style="width:100%;">
                <tr>
                    <td colspan="2" align="center">
                        <asp:ImageButton ID="imgAux" runat="server" ImageUrl="~/Imagenes/16w.png" />
                        <asp:Label ID="lblTitulo" runat="server" CssClass="texto12"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="auto-style1"></td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <asp:Panel ID="pnlBusqueda" runat="server">
                            <table style="width: 100%;">
                                <tr>
                                    <td align="right" style="width: 50%">
                                        <asp:Label ID="Label1" runat="server" Text="Matrícula Titular:"></asp:Label>
                                        <asp:TextBox ID="txtMatriculaTit" runat="server" CssClass="box" MaxLength="10" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvMatTit" runat="server" ControlToValidate="txtMatriculaTit" ErrorMessage="*" ValidationGroup="buscar"></asp:RequiredFieldValidator>
                                    </td>
                                    <td align="left" rowspan="2">
                                        <asp:ImageButton ID="ibtnBuscar" runat="server" ImageUrl="~/Imagenes/plomoBuscar.png" OnClick="ibtnBuscar_Click" ValidationGroup="buscar" />
                                        <asp:ImageButton ID="ibtnLimpiar" runat="server" AlternateText="Limpiar" CausesValidation="False" ImageUrl="~/Imagenes/plomoLimpiar.png" OnClick="ibtnLimpiar_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 50%">
                                        <asp:Label ID="Label4" runat="server" Text="Número del Documento:"></asp:Label>
                                        <asp:TextBox ID="txtNumDocumento" runat="server" CssClass="box" MaxLength="10"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvNumDoc" runat="server" ControlToValidate="txtNumDocumento" ErrorMessage="*" ValidationGroup="buscar"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>    
                    </td>
                </tr>
                <tr>
                    <td align="center">

                    </td>
                    <td align="left">&nbsp;</td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:GridView ID="gvBenefPU" runat="server" AutoGenerateColumns="False" BorderColor="#DADADA" DataKeyNames="NUPTitular,NUP,Tramite,NumeroCertificado,IdBeneficio,Estado,GrupoFamiliar" OnRowCommand="gvBenefPU_RowCommand">
                            <Columns>
                                <asp:BoundField DataField="IdBeneficio" HeaderText="IdBeneficio" Visible="False" />
                                <asp:BoundField DataField="BENEFICIO" HeaderText="Clase Beneficio" />                                
                                <asp:BoundField DataField="NUPTitular" HeaderText="NUPTitular" Visible="False"/>
                                <asp:BoundField DataField="CI" HeaderText="Nº Documento"/>
                                <asp:BoundField DataField="NOMBRE" HeaderText="Nombre Completo" />
                                <asp:BoundField DataField="Tramite" HeaderText="Tramite" />
                                <asp:BoundField DataField="NumeroCertificado" HeaderText="Certificado" />
                                <asp:BoundField DataField="PORCENTAJE" HeaderText="Porcentaje" >
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="MONTO_PU" HeaderText="Monto [Bs.]" DataFormatString="{0:F2}" >
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                 <asp:TemplateField HeaderText="Revisar" ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ibtnAutorizar" runat="server" CausesValidation="false" 
                                            CommandName="cmdAutorizar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" 
                                            ImageUrl="~/Imagenes/verdeAutorizar.png" Text="" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Resolución" ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ibtnAprobar" runat="server" CausesValidation="false" 
                                            CommandName="cmdAprobar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" 
                                            ImageUrl="~/Imagenes/verdeAprobar.png" Text="" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Imprimir" ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ibtnImprimir" runat="server" CausesValidation="false" 
                                            CommandName="cmdImprimir" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" 
                                            ImageUrl="~/Imagenes/verdeImprimir.png" Text="" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="Estado" HeaderText="Estado" Visible="False" />
                                <asp:BoundField DataField="GrupoFamiliar" HeaderText="GrupoFamiliar" Visible="False" />
                                <asp:BoundField DataField="NUP" HeaderText="NUP" Visible="False"/>
                            </Columns>
                            <HeaderStyle CssClass="cssHeaderImg" />
                            <EmptyDataTemplate>
                                <div align="center" class="CajaDialogoAdvertencia">
                                    <br/>
                                    <img src="../Imagenes/warning.gif" 
                                        alt="No existen registros" />
                                    <br/>
                                        Bandeja de Registros vacía. 
                                    <br/>
                                    <br/>
                                </div>
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </td>
                    <td align="left">
                        
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="pnlPopupResol" runat="server" Width="300px" CssClass="panelprincipal">
            <div class="pnlPest">
                <table style="width: 300px;">
                <tr>
                    <td colspan="2" align="center">
                        <asp:Label ID="lblTituloAUX0" runat="server" CssClass="texto12" Text="Datos de Resolución"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label2" runat="server" Text="Nª Resolución:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtNumResol" runat="server" Width="90px"></asp:TextBox>
                        <cc2:FilteredTextBoxExtender ID="txtNumResol_FilteredTextBoxExtender" runat="server" FilterType="Numbers" TargetControlID="txtNumResol">
                        </cc2:FilteredTextBoxExtender>
                        <asp:RequiredFieldValidator ID="rfvFechaResol0" runat="server" ControlToValidate="txtNumResol" ErrorMessage="*" ValidationGroup="resol"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label3" runat="server" Text="Fecha:"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtFechaResol" runat="server" Width="90px"></asp:TextBox>
                        <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" BehaviorID="_content_TextBoxWatermarkExtender1" TargetControlID="txtFechaResol" WatermarkText="__/__/____">
                        </cc1:TextBoxWatermarkExtender>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" BehaviorID="_content_CalendarExtender1" Format="dd/MM/yyyy" PopupButtonID="btnCalendario" TargetControlID="txtFechaResol">
                        </cc1:CalendarExtender>
                        <asp:ImageButton ID="btnCalendario" runat="server" ImageAlign="Bottom" ImageUrl="../Imagenes/pequeños/CalendarC_16x16.png" />
                        <asp:RequiredFieldValidator ID="rfvFechaResol" runat="server" ControlToValidate="txtFechaResol" ErrorMessage="*" ValidationGroup="resol"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="rvFechaResol" runat="server" ControlToValidate="txtFechaResol" ErrorMessage="Fuera de rango" MinimumValue="01/01/1900" Type="Date"></asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Button ID="btnRegistrarResol" runat="server" CssClass="btnPrin" OnClick="btnRegistrarResol_Click" Text="Registrar" ValidationGroup="resol" />
                        <asp:Button ID="btnCancelaResol" runat="server" Text="Cancelar" CausesValidation="False" OnClick="btnCancelaResol_Click" CssClass="btnPrin" />
                    </td>
                </tr>
            </table>
            </div>
            <cc1:ModalPopupExtender ID="popupResol" runat="server"
                TargetControlID="btnResolAprob"
                PopupControlID="pnlPopupResol"
                BackgroundCssClass="modalBackground">             
         </cc1:ModalPopupExtender>
        </asp:Panel>
        <%--<asp:Panel ID="pnlPopupCheque" runat="server" Width="440px"  CssClass="panelprincipal">
            <div>
                <table style="width: 440px;">
                    <tr>
                        <td colspan="2" align="center">
                            <asp:Label ID="Label4" runat="server" CssClass="etiqueta20" Text="Datos del Cheque"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label5" runat="server" Text="Entidad Financiera:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlEntFinan" runat="server" Width="249px" Height="16px">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvEntFinan" runat="server" ControlToValidate="ddlEntFinan" ErrorMessage="*" InitialValue="Seleccione valor ..." ValidationGroup="cheque"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label6" runat="server" Text="C31:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtC31" runat="server"></asp:TextBox>
                            <cc2:FilteredTextBoxExtender ID="txtC31_FilteredTextBoxExtender" runat="server" FilterType="Numbers" TargetControlID="txtC31">
                            </cc2:FilteredTextBoxExtender>
                            <asp:RequiredFieldValidator ID="rfvC31" runat="server" ControlToValidate="ddlEntFinan" ErrorMessage="*" ValidationGroup="cheque"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:Button ID="btnCancelarCheque" runat="server" Text="Cancelar" CausesValidation="False" OnClick="btnCancelarCheque_Click" />
                            <asp:Button ID="btnRegistrarCheque" runat="server" Text="Registrar" OnClick="btnRegistrarCheque_Click" ValidationGroup="cheque" />
                        </td>
                    </tr>
                </table>
            </div>
            <cc2:ModalPopupExtender ID="popupCheque" runat="server" BackgroundCssClass="modalBackground" Enabled="True" PopupControlID="pnlPopupCheque" TargetControlID="ibtnGenCheque">
            </cc2:ModalPopupExtender>
        </asp:Panel>--%>        
        <div>
            <asp:Panel ID="pnlReporte" runat="server" BackColor="White">
                <table style="width: 100%;">
                    <tr>
                        <td align="center">
                            <rsweb:ReportViewer ID="rptViewPU" runat="server" Width="800px" >
                            </rsweb:ReportViewer>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">&nbsp;</td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
        <asp:Button ID="btnResolAprob" runat="server" Text="" Height="1px" OnClick="btnResolAprob_Click" Width="1px"/>
    </div>
</asp:Content>

