<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmBuscadorTramiteEmision.aspx.cs" Inherits="EmisionCertificadoCC_wfrmBuscadorTramiteEmision" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div align="right">
        Tasa de Cambio Vigente: <asp:Label runat="server" ID="lblTipoCambio" ForeColor="blue" Font-Bold="true"></asp:Label><br />
        R.A. Vigente: <asp:Label runat="server" ID="lblResolucion" ForeColor="blue" Font-Bold="true"></asp:Label><br />
        Salario Min. Nal: <asp:Label runat="server" ID="lblNal" ForeColor="blue" Font-Bold="true"></asp:Label>
    </div>
    <div align="center">
        <br />
        <asp:Label ID="lblBuscador" runat="server" Text="Buscador de Trámites"></asp:Label><br />
        <br />
        <asp:Label ID="lblNroTram" runat="server" Text="Número de Trámite:"></asp:Label>
        <asp:TextBox ID="txtIdtramite" runat="server"></asp:TextBox>
 <%--       &nbsp;<br />--%>
        <asp:Button ID="btnEnviar" runat="server" OnClick="btn_buscar" Text="Buscar Trámite" Height="32px" ToolTip="Buscar Trámites"/>
        <br />
        <asp:CheckBox ID="chkRespuesta" runat="server" Visible="false">
        </asp:CheckBox>

         <asp:Panel ID="pnlListaTramitesBandeja" runat="server">
            <div align="center">
                <br />
                <p>
                    Lista de tramites asignados ===> Cantidad: <asp:Label ID="lblCantidad" runat="server"  ForeColor="#0033cc"></asp:Label> </p>
            <asp:GridView ID="gvBandeja" runat="server"             
                        AllowPaging="True" PageSize="15"
                        AutoGenerateColumns="False"                         
                        EnableTheming="True" 
                        Font-Names="Arial" 
                        Font-Size="10pt" 
                        CssClass="mGrid"
                        PagerStyle-CssClass="pgr"
                        AlternatingRowStyle-CssClass="alt"
                        GridLines="None"
                        DataKeyNames="IdTramite,NUP,CUA,Matricula,NombreCompleto,FechaInicioTramite,TipoTramite,Regional,FechaIngreso,EstadoTramite,IdEstadoTramite,IdTipoTramite"  
                        OnRowCommand="gvBandeja_RowCommand"
                        OnRowDataBound="gvBandeja_RowDataBound"
                        OnPageIndexChanging="gvBandeja_PageIndexChanging"
                       >
                        <Columns>                                
                            <asp:BoundField DataField="IdTipoTramite" Visible="false"/>
                            <asp:BoundField DataField="TipoTramite" HeaderText="Tipo"  />
                            <asp:BoundField DataField="IdTramite" HeaderText="Tramite"  />
                            <asp:BoundField DataField="NUP" HeaderText="NUP" Visible="false"  />                                
                            <asp:BoundField DataField="CUA" HeaderText="CUA"  />
                            <asp:BoundField DataField="Matricula" HeaderText="Matricula"  />                                                                
                            <asp:BoundField DataField="NombreCompleto" HeaderText="NombreCompleto"/>                                      
                            <asp:BoundField DataField="FechaInicioTramite" HeaderText="Inicio Tramite"/>                                  
                            <asp:BoundField DataField="Regional" HeaderText="Regional" HeaderStyle-Width="80px"/>                                  
                            <asp:BoundField DataField="EstadoTramite" HeaderText="Estado Trámite" HeaderStyle-Width="180px"/>
                            <asp:BoundField DataField="IdEstadoTramite" HeaderText="IdEstado" Visible="false"/>
                            <asp:BoundField DataField="FechaIngreso" HeaderText="Ingreso Área">
                            <HeaderStyle Width="90px" />
                            </asp:BoundField >
                            <asp:TemplateField HeaderText="Seleccionar" >                                  
                               <ItemTemplate>
                                    <center>                                                                                
                                    <asp:ImageButton ID="imgSeleccion" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdSelect" ImageUrl="~/imagenes/nueva3/siguiente32.png" ToolTip="Selección de Registro" Width="16px"/>
                               </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate><div align="center" class="CajaDialogoAdvertencia">
                        <br/>
                        <img src="../Imagenes/warning.gif" alt="No existen datos que correspondan al criterio especificado" />
                        <br/>No existen datos que correspondan al criterio especificado
                        <br/><br/>
                        </div>
                         </EmptyDataTemplate>
                            <SelectedRowStyle BackColor="#FFFF99" />
                        </asp:GridView>
                </div>
        </asp:Panel>
        <asp:GridView ID="gvFormCC" runat="server"             
                        AllowPaging="True" PageSize="1"
                        AutoGenerateColumns="False"                         
                        EnableTheming="True" 
                        Font-Names="Arial" 
                        Font-Size="9pt" 
                        CssClass="mGrid"
                        PagerStyle-CssClass="pgr"
                        AlternatingRowStyle-CssClass="alt"
                        GridLines="None"
                        DataKeyNames="IdTramite,FechaInicioTramite,Matricula,PrimerNombre,SegundoNombre,PrimerApellido,SegundoApellido,FlagM,FlagG,Aprobaciones,IdTipoTramite,TipoTramite,CertificacionSalario,TramiteInformado,AreaActual"                          
                        OnRowDataBound="gvFormCC_RowDataBound"
                        OnRowCommand="gvFormCC_RowCommand"
                       >                                  
                          
                            <Columns>                                                                
                              <asp:TemplateField HeaderText="Formularios" >                                  
                                    <ItemTemplate>
                                        <center>                                                                                
                                        <asp:ImageButton ID="imgFMensual" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdMensual" ImageUrl="~/imagenes/nueva3/imprimirformulariomensual32.png" ToolTip="Formulario Mensual" />                                        
                                        <asp:ImageButton ID="imgFGlobal" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdGlobal" ImageUrl="~/imagenes/nueva3/imprimirformularioglobal32.png" ToolTip="Formulario Global"/>                                        
                                             </center>
                                    </ItemTemplate>
                                </asp:TemplateField>               
                            </Columns>
                            <EmptyDataTemplate><div align="center" class="CajaDialogoAdvertencia">
      <br/>
                                <img src="../Imagenes/warning.gif" 
              alt="No existen datos que correspondan al criterio especificado" />
      <br/>No existen datos que correspondan al criterio especificado
                                <br/><br/>
                                               </div>
    </EmptyDataTemplate>
                            <SelectedRowStyle BackColor="#FFFF99" />
                        </asp:GridView>
    </div>
    <div align="left">
        <asp:LinkButton runat="server" ID="lblAutomaticoRenuncia" Text="Trámite en Renuncia" BackColor="Orange" Font-Names="Arial" Font-Size="9pt" Font-Bold="true" OnClick="lblAutomaticoRenuncia_Click"></asp:LinkButton><br />
        <asp:LinkButton runat="server" ID="lblManualReclamacion" BackColor="Yellow" Text="Trámite en Rec. Reclamación/Revision" Font-Names="Arial" Font-Size="9pt" Font-Bold="true" OnClick="lblManualReclamacion_Click"></asp:LinkButton><br />
        <asp:LinkButton runat="server" ID="lblReproceso" BackColor="#f98b9a" Text="Trámite en Reproceso"  Font-Names="Arial" Font-Size="9pt" Font-Bold="true" OnClick="lblReproceso_Click"></asp:LinkButton>
    </div>
</asp:Content>

