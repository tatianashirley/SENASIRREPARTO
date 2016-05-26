<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmBandejaTramites.aspx.cs" Inherits="WorkFlow_wfrmBandejaTramites" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <style type="text/css">
         .auto-style5 {
             width: 11%;
             height: 36px;
         }
         .auto-style6 {
             width: 70%;
             height: 36px;
         }
         .auto-style7 {
             width: 6%;
         }
         .auto-style8 {
             width: 11%;
         }
         .auto-style9 {
             width: 13%;
         }
     </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <table style="width: 100%;" class="panelceleste">
        <tr>
            <td align="center">
                <asp:ImageButton ID="imgAux" runat="server" ImageUrl="~/Imagenes/16w.png" />
                <asp:Label ID="lblTituloAUX" runat="server"
                    Text="BANDEJA DE TRAMITES" CssClass="etiqueta20"></asp:Label>
              </td>
        </tr>
        <tr>
            <td >
            <table width="100%" class="panelceleste">
                <tr>
                    <td style="text-align:right" class="auto-style5">
                        <asp:Label ID="lblTramite" CssClass="etiqueta10"  runat="server" Text="N° de Trámite"></asp:Label>

                    </td>
                    <td style="text-align:left" colspan="3" class="auto-style6">
                        <asp:TextBox  ID="txtTramite" runat="server" style="margin-bottom: 0px" Width="20%"    ></asp:TextBox>
                    </td>
                        <td  style="width:20%; text-align:left">
                        </td>
                </tr>
                <tr>
                    <td style="text-align:right" class="auto-style8"> 
                        <asp:Label ID="lblBeneficiario" CssClass="etiqueta10" runat="server" Text="Nombre Beneficiario" />

                    </td>
                    <td colspan="3" style="text-align:left">
                        <asp:TextBox ID="txtBeneficiario" runat="server" style="margin-bottom: 0px" Width="65%"    ></asp:TextBox> 
                    </td>
                              
                        <td  style="width:20%; text-align:left">
                        </td>
                </tr>
                    <tr>
                    <td style="text-align:right" class="auto-style8">
                        <asp:Label ID="lblDesde"  CssClass="etiqueta10"  runat="server" Text="Desde" /> 
                    </td>
                    <td style="text-align:left" class="auto-style9">
                        <asp:TextBox ID="txtDateIni" runat="server" BackColor="#87CEEB" Width="75px"></asp:TextBox>
                        <cc1:TextBoxWatermarkExtender ID="txtDateIni_TextBoxWatermarkExtender" 
                            runat="server" Enabled="True" TargetControlID="txtDateIni" WatermarkText="__/__/____">
                        </cc1:TextBoxWatermarkExtender>
                        <asp:ImageButton ID="imgPopup" ImageUrl="../Imagenes/pequeños/CalendarC_16x16.png" ImageAlign="Bottom" runat="server" />
                        <cc1:CalendarExtender ID="txtDateIni_CalendarExtender" PopupButtonID="imgPopup" runat="server" TargetControlID="txtDateIni"
                            Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                    </td>
                    <td style="text-align:left" class="auto-style9">
                        <asp:Label ID="lblHasta"  CssClass="etiqueta10"  runat="server" Text="Hasta" />
                        <asp:TextBox ID="txtDateFin" runat="server" BackColor="#87CEEB" Width="75px"></asp:TextBox>
                        <cc1:TextBoxWatermarkExtender ID="txtDateFin_TextBoxWatermarkExtender" 
                            runat="server" Enabled="True" TargetControlID="txtDateFin" 
                            WatermarkText="__/__/____">
                        </cc1:TextBoxWatermarkExtender>
                        <asp:ImageButton ID="imgPopup2" ImageUrl="../Imagenes/pequeños/CalendarC_16x16.png" ImageAlign="Bottom" runat="server" />
                        <cc1:CalendarExtender ID="txtDateFin_CalendarExtender" PopupButtonID="imgPopup2" runat="server" TargetControlID="txtDateFin"
                            Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                    </td>
                    <td style="text-align:left" class="auto-style7"> 
                            <asp:ImageButton ID="imgBuscar" runat="server"  ImageUrl="~/Imagenes/32Buscar.png" OnClick="imgBuscar_Click" ToolTip="Buscar Datos"   /> 
                            <asp:Label ID="lblRefres" CssClass="etiqueta8Blue" runat="server" Text="Buscar" /><br />
                            <asp:DropDownList ID="ddlFiltroActividades" runat="server" Width="461px" AutoPostBack="True" OnSelectedIndexChanged="ddlFiltroActividades_SelectedIndexChanged">
                            </asp:DropDownList>                               
                    </td>
                        <td  style="width:20%; text-align:left">  
                        </td>
                </tr>

                <tr>
                    <td class="auto-style8">&nbsp;</td>
                    <td class="auto-style9">&nbsp;</td>
                    <td class="auto-style9">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td>
                        </td>
                </tr>

            </table>
            </td>
        </tr>
        <tr>
            <td>
            <table style="width: 100%;" class="panelceleste">
                <tr>
                    <td colspan="2">                           
                        <asp:GridView ID="gvTramite" runat="server"
                            AutoGenerateColumns="False" HorizontalAlign="Center" SkinID="GridView"
                            OnRowDataBound="gvTramite_RowDataBound"
                            Width="100%" DataKeyNames="IdInstancia,Secuencia,IdTramite,IdGrupoBeneficio,FlagArchivo" 
                            OnPageIndexChanging ="gvTramite_PageIndexChanging"  
                            OnRowCommand="gvTramite_RowCommand">
                            <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                            <Columns>
                                <asp:TemplateField HeaderText="Historial">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgHistorial" runat="server" ImageUrl="~/Imagenes/32History.png"
                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" 
                                        CommandName="Historial"
                                        ToolTip="Historial del Trámite" /> 
                                </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Instancia">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdInstancia" runat="server" Text='<%# Bind("IdInstancia") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Secuencia">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSecuencia" runat="server" Text='<%# Bind("Secuencia") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="IdTipoTramite" HeaderText="IdTipoTramite" />
                                <asp:BoundField DataField="IdGrupoBeneficio" HeaderText="IdGrupoBeneficio" />
                                <asp:BoundField DataField="NombreBeneficiario" HeaderText="NombreBeneficiario" />
                                <asp:BoundField DataField="IdTramite" HeaderText="Nro. Tramite" ItemStyle-BackColor="#87CEEB" />
                                <asp:BoundField DataField="IdFlujo" HeaderText="IdFlujo" Visible="false" />
                                <asp:BoundField DataField="DescFlujo" HeaderText="DescFlujo" />
                                <asp:BoundField DataField="IdNodo" HeaderText="IdNodo" Visible="false" />
                                <asp:BoundField DataField="Descripcion" HeaderText="Actividad" Visible="true" />
                                <asp:BoundField DataField="Contador" HeaderText="Contador" Visible="false" />
                                <asp:BoundField DataField="FechaHRInicio" HeaderText="FechaHRInicio" />
                                <asp:BoundField DataField="FechaHRFin" HeaderText="FechaHRFin" Visible="false" />                                        
                                <asp:BoundField DataField="Comentarios" HeaderText="Comentarios" />
                                <asp:BoundField DataField="EstadoCod" HeaderText="EstadoCod" Visible="false" />
                                <asp:BoundField DataField="FlagArchivo" HeaderText="FlagArchivo" Visible="false" />
                                <asp:TemplateField HeaderText="Asig/Activ" ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButton4" runat="server" CausesValidation="false" 
                                            CommandName="cmdAsignar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" 
                                            ImageUrl="~/Imagenes/16usuariosalida.png" Text="" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Gen/Cmbte" ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButton3" runat="server" CausesValidation="false" 
                                            CommandName="cmdGenera" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" 
                                            ImageUrl="~/Imagenes/16usuariosegui.png" Text="" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Act/Cmbte" ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="false" 
                                            CommandName="cmdComprobante" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" 
                                            ImageUrl="~/Imagenes/16usuariotraslado.png" Text="" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ejecutar" ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="false" 
                                            CommandName="cmdActividades" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" 
                                            ImageUrl="~/imagenes/16siguiente.png" Text="" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <EmptyDataTemplate>
                            <div align="center" class="CajaDialogoAdvertencia">
                            <br/><img src="../Imagenes/warning.gif" 
                                    alt="No existen Tramites por Asignar para el usuario en curso." />
                            <br/>Bandeja de Trámites vacia o No existen Tramites que cumplan el criterio de busqueda.
                            <br/><br/>
                            </div>
                        </EmptyDataTemplate>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
            <asp:Panel ID="pnlHistorialTramites" runat="server" HorizontalAlign="Center" Width="100%" CssClass="panelceleste">
                <table style="width: 100%;">
                    <tr>
                        <td align="left" valign="top">
                            <asp:Label ID="lblTHistTram" CssClass="texto10" Font-Bold="true"  runat="server" Text="Historial del Trámite: "></asp:Label>
                            <asp:Label ID="lblHIdTramite" CssClass="texto10" Font-Bold="true"  runat="server" Text=""></asp:Label>
                            <asp:Label ID="lblT02" runat="server" Text="-"></asp:Label>
                            <asp:Label ID="lblHIdGrupoBeneficio" CssClass="texto10" Font-Bold="true"  runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" valign="top">
                            <asp:GridView ID="gvBusqMaestro" runat="server" SkinID="GridView" 
                                DataKeyNames="IdGrupoBeneficio,NroTramite" AutoGenerateColumns="False" 
                                Width="100%">
                                <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                                <Columns>
                                    <asp:BoundField DataField="Nombres" HeaderText="Nombres" />      
                                    <asp:BoundField DataField="Ap. Paterno" HeaderText="Ap. Paterno" />      
                                    <asp:BoundField DataField="Ap. Materno" HeaderText="Ap. Materno" />      
                                    <asp:BoundField DataField="Nro. Doc. Id." HeaderText="Nro. Doc. Id." />      
                                    <asp:BoundField DataField="Matrícula" HeaderText="Matrícula" />      
                                    <asp:BoundField DataField="Fec. Nac" HeaderText="Fec. Nac." DataFormatString="{0:dd/MM/yyyy}"/>      
                                    <asp:BoundField DataField="CUA" HeaderText="CUA" />      
                                    <asp:BoundField DataField="AFP" HeaderText="AFP" />      
                                    <asp:BoundField DataField="NroTramite" HeaderText="Nro. Tramite" />      
                                    <asp:BoundField DataField="IdGrupoBeneficio" HeaderText="IdGrupoBeneficio" Visible="False"/>      
                                    <asp:BoundField DataField="GrupoBeneficio" HeaderText="Grupo Beneficio" />      
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
                        </td>
                    </tr>
                    <tr>
                        <td align="center" valign="top">
                        <div style="width: 1100px; overflow-x: scroll" align="center">
                            <asp:GridView ID="gvDetalle" runat="server" 
                                Font-Size="X-Small" Font-Bold="false" AllowPaging="True" PageSize="5" BorderColor="#DADADA" Width="2300px" 
                                OnPageIndexChanging="gvDetalle_PageIndexChanging">
                                <HeaderStyle CssClass="cssHeaderImg" />
                                <EmptyDataTemplate>
                                    <div align="center" class="CajaDialogoAdvertencia" style="width: 1100px">
                                        <br/>
                                        <img src="../Imagenes/warning.gif" 
                                                        alt="No existen registros" />
                                        <br/>
                                        Bandeja de Historial vacía.
                                        <br/>
                                        <br/>
                                    </div>
                                </EmptyDataTemplate>
                            </asp:GridView>                        
                        </div>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>

