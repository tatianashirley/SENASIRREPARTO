<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmReportesNotificacion.aspx.cs" Inherits="Notificaciones_wfrmReportesNotificacion" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 140px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <table style="width: 100%;" class="panelceleste">
        <tr>
            <td align="center">
                <asp:ImageButton ID="imgAux" runat="server" ImageUrl="~/Imagenes/16w.png" />
                <asp:Label ID="lblTituloAUX" runat="server" Text="REPORTES NOTIFICACIONES" CssClass="etiqueta20"> </asp:Label>
            </td>
        </tr>
        <tr>
             <td >
                 <div>
                    <table width="100%" class="panelceleste" >
                         <tr>
                            <td style="text-align:left" width="10%">
                                <asp:Label ID="lblTipoDoc" Font-Names="Arial" Font-Size="9pt" Font-Bold="true" runat="server" Text="Tipo Documento: " /> 
                            </td>
                            
                            <td style="text-align:left" width="10%">
                                <asp:Label ID="lblTipoReporte"  CssClass="etiqueta10" Font-Names="Arial" Font-Size="9pt" Font-Bold="true" runat="server" Text="Tipo de Reporte:" /> 
                            </td>
                           
                            <td style="text-align:left" width="10%">
                                <asp:Label ID="lblRegional"  CssClass="etiqueta10"  runat="server" Text="Regional:" Font-Names="Arial" Font-Size="9pt" Font-Bold="true" /> 
                            </td>
                            
                            <td style="text-align:left" width="10%">
                                <asp:Label ID="lblFechaDesde"  CssClass="etiqueta10"  runat="server" Text="Fecha Desde:"  Font-Names="Arial" Font-Size="9pt" Font-Bold="true"/> 
                            </td>
                            
                            <td style="text-align:left" width="10%">
                                <asp:Label ID="lblFechaHasta"  CssClass="etiqueta10"  runat="server" Text="Fecha Hasta:"  Font-Names="Arial" Font-Size="9pt" Font-Bold="true"/> 
                            </td>
                            
                            <td style="width:20%; text-align:left" width="10%" rowspan="2">   
                                <asp:ImageButton ID="imgBuscar" runat="server"  ImageUrl="~/Imagenes/32Buscar.png" ToolTip="Buscar" ValidationGroup="valFecha" CausesValidation="true" OnClick="imgBuscar_Click" />
                                <asp:Label ID="lblRefres" CssClass="etiqueta8Blue" runat="server" Text="Buscar" /> 
                            </td>
                             <td style="width:20%; text-align:left" width="10%" rowspan="2">  
                                <asp:RadioButtonList ID="rbReporte" runat="server">
                                    <asp:ListItem Text="Pantalla" Value="1" Selected="True" />
                                    <asp:ListItem Text="Imprimir" Value="2"/>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align:left" width="10%"> 
                                <asp:DropDownList  ID="ddlTipoDocumento" runat="server" style="margin-bottom: 0px" Font-Names="Arial" Font-Size="9pt" Height="16px" Width="154px"></asp:DropDownList>
                            </td>

                             <td style="text-align:left" width="10%"> 
                                <asp:DropDownList  ID="ddlTipoReporte" runat="server" Font-Names="Arial" Font-Size="9pt" style="margin-bottom: 0px;" Height="16px" Width="139px" >
                                    <asp:ListItem Value="1" Text="Envio Documentos"></asp:ListItem> <%--1--%>
                                    <asp:ListItem Value="2" Text="Devolucion Documentos"></asp:ListItem> <%--2--%>
                                    <asp:ListItem Value="3" Text="Notificaciones Pendientes"></asp:ListItem> <%--3--%>
                                    <asp:ListItem Value="4" Text="Mayor a 6 Meses"></asp:ListItem> <%--4--%>
                                    <asp:ListItem Value="5" Text="Mayor a 1 mes"></asp:ListItem> <%--5--%>
                                    <asp:ListItem Value="6" Text="Plazo Vencido"></asp:ListItem> <%--6--%>
                                    <asp:ListItem Value="7" Text="En Plazo"></asp:ListItem> <%--7--%>
                                    <asp:ListItem Value="8" Text="Listado Notificaciones"></asp:ListItem> <%--8--%>
                                    <asp:ListItem Value="9" Text="Listado Recursos"></asp:ListItem> <%--9--%>
                                </asp:DropDownList> 
                            </td>

                            <td style="text-align:left" width="10%"> 
                                <asp:DropDownList  ID="ddlRegional" runat="server" style="margin-bottom: 0px;" Height="16px" Width="153px"></asp:DropDownList>
                            </td>

                            <td style="text-align:left" class="auto-style1"> 
                                <asp:TextBox  ID="txtFechaDesde" runat="server" style="margin-bottom: 0px;" Width="110px"/>
                                <cc1:CalendarExtender ID="CalendarExtender2" PopupButtonID="txtFechaDesde" runat="server" TargetControlID="txtFechaDesde" Format="dd/MM/yyyy">
                                </cc1:CalendarExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                    ErrorMessage="Ingrese una Fecha" ValidationGroup="valFecha" 
                                    ControlToValidate="txtFechaDesde" Text="*"
                                    Display="Dynamic" SetFocusOnError="true">*
                                </asp:RequiredFieldValidator>
                            </td>

                            <td style="text-align:left" width="10%"> 
                                <asp:TextBox  ID="txtFechaHasta" runat="server" style="margin-bottom: 0px;" Width="110px"/>
                                <cc1:CalendarExtender ID="CalendarExtender3" PopupButtonID="txtFechaHasta" runat="server" TargetControlID="txtFechaHasta" Format="dd/MM/yyyy">
                                </cc1:CalendarExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ErrorMessage="" ValidationGroup="valFecha" 
                                    ControlToValidate="txtFechaHasta" Text="*"
                                    Display="Dynamic" SetFocusOnError="true">*
                                </asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </table>
                </div>
             </td>
        </tr>
<%--        <tr>
            <td><asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="valFecha" /></td>
        </tr>--%>
         <tr>
            <td><asp:Label runat="server" ID="lblTotal" Font-Names="Arial" Font-Size="9pt" Font-Bold="true" Visible="false"/></td>
        </tr>
         <%--Inicio de la Grillas de Consultas--%>
         <tr>
             <td align="center">
                 <asp:GridView ID="gvEnvioDevolucion" runat="server"
                                    AutoGenerateColumns="False" BorderColor="#DADADA" BorderStyle="Solid" BorderWidth="1px"
                                    CssClass="etiqueta8Blue" EnableTheming="True" Font-Names="Arial" Font-Size="9pt" GridLines="Horizontal"
                                    SkinID="GridView">
                                    <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="Matricula" HeaderText="Matricula" /> <%--0--%>
                                        <asp:BoundField DataField="IdTramite" HeaderText="Tramite" /> <%--1--%>
                                        <asp:BoundField DataField="Beneficio" HeaderText="Tipo_Tram" /> <%--2--%>
                                        <asp:BoundField DataField="FechaSistema" HeaderText="Fecha_Sis" /> <%--3--%>
                                        <asp:BoundField DataField="Nombres" HeaderText="Nombres" DataFormatString="{0:d}" /> <%--4--%>
                                        <asp:BoundField DataField="EstadoNot" HeaderText="Estado_Not" /> <%--5--%>
                                        <asp:BoundField DataField="FechaDocumento" HeaderText="FechaDoc" /> <%--6--%>
                                        <asp:BoundField DataField="NroDocumento" HeaderText="NroDoc" /> <%--7--%>
                                        <asp:BoundField DataField="Documento" HeaderText="Documento" /> <%--8--%>
                                        <asp:BoundField DataField="FechaNot" HeaderText="FecNot" /> <%--9--%>
                                        <asp:BoundField DataField="FechaRec" HeaderText="FecRec" /> <%--10--%>
                                        <asp:BoundField DataField="CiteEnv" HeaderText="Cite" /> <%--11--%>
                                        <asp:BoundField DataField="FechaEnvio" HeaderText="Fecha" /> <%--12--%>
                                        <asp:BoundField DataField="FechaDevolucion" HeaderText="Fecha" /> <%--13--%>
                                        <asp:BoundField DataField="Obs" HeaderText="Obs" /> <%--14--%>
                                        <asp:BoundField DataField="EstadoEnv" HeaderText="EstEnv" /><%--15--%>
                                        <asp:BoundField DataField="Regional" HeaderText="Regional" /> <%--16--%>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <div align="center" class="CajaDialogoAdvertencia">
                                            <br />
                                            <img src="../Imagenes/warning.gif"
                                                alt="No existen datos que correspondan al criterio especificado" />
                                            <br />
                                            No existen datos que correspondan al criterio especificado
                                        <br />
                                            <br />
                                        </div>
                                    </EmptyDataTemplate>
                                </asp:GridView>               
             </td>             
         </tr>
         <tr>
             <td align="center">
                 <asp:GridView ID="gvPendientesMesDocs" runat="server"
                                    AutoGenerateColumns="False" BorderColor="#DADADA" BorderStyle="Solid" BorderWidth="1px"
                                    CssClass="etiqueta8Blue" EnableTheming="True" Font-Names="Arial" Font-Size="9pt" GridLines="Horizontal"
                                    SkinID="GridView">
                                    <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="Matricula" HeaderText="Matricula" /> <%--0--%>
                                        <asp:BoundField DataField="IdTramite" HeaderText="Tramite" /> <%--1--%>
                                        <asp:BoundField DataField="Beneficio" HeaderText="Tipo_Tram" /> <%--2--%>
                                        <asp:BoundField DataField="FechaSistema" HeaderText="Fecha_Sis" /> <%--3--%>
                                        <asp:BoundField DataField="Nombres" HeaderText="Nombres" DataFormatString="{0:d}" /> <%--4--%>
                                        <asp:BoundField DataField="EstadoNot" HeaderText="Estado_Not" /> <%--5--%>
                                        <asp:BoundField DataField="FechaDocumento" HeaderText="FechaDoc" /> <%--6--%>
                                        <asp:BoundField DataField="NroDocumento" HeaderText="NroDoc" /> <%--7--%>
                                        <asp:BoundField DataField="Documento" HeaderText="Documento" /> <%--8--%>
                                        <asp:BoundField DataField="CiteEnv" HeaderText="Cite" /> <%--9--%>
                                        <asp:BoundField DataField="Fechaenvio" HeaderText="Fecha" /> <%--10--%>
                                        <asp:BoundField DataField="Obs" HeaderText="Obs" /> <%--11--%>
                                        <asp:BoundField DataField="EstadoEnv" HeaderText="EstadoEnv" /> <%--12--%>
                                        <asp:BoundField DataField="NroDias" HeaderText="NroDias" /> <%--13--%>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <div align="center" class="CajaDialogoAdvertencia">
                                            <br />
                                            <img src="../Imagenes/warning.gif"
                                                alt="No existen datos que correspondan al criterio especificado" />
                                            <br />
                                            No existen datos que correspondan al criterio especificado
                                        <br />
                                            <br />
                                        </div>
                                    </EmptyDataTemplate>
                                </asp:GridView>               
             </td>             
         </tr>
                  <tr>
             <td align="center">
                 <asp:GridView ID="gvPlazosDocs" runat="server"
                                    AutoGenerateColumns="False" BorderColor="#DADADA" BorderStyle="Solid" BorderWidth="1px"
                                    CssClass="etiqueta8Blue" EnableTheming="True" Font-Names="Arial" Font-Size="9pt" GridLines="Horizontal"
                                    SkinID="GridView">
                                    <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="Matricula" HeaderText="Matricula" /> <%--0--%>
                                        <asp:BoundField DataField="IdTramite" HeaderText="Tramite" /> <%--1--%>
                                        <asp:BoundField DataField="Beneficio" HeaderText="Tipo_Tram" /> <%--2--%>
                                        <asp:BoundField DataField="FechaSistema" HeaderText="Fecha_Sis" /> <%--3--%>
                                        <asp:BoundField DataField="Nombres" HeaderText="Nombres" DataFormatString="{0:d}" /> <%--4--%>
                                        <asp:BoundField DataField="EstadoNot" HeaderText="Estado_Not" /> <%--5--%>
                                        <asp:BoundField DataField="FechaDocumento" HeaderText="FechaDoc" /> <%--6--%>
                                        <asp:BoundField DataField="NroDocumento" HeaderText="NroDoc" /> <%--7--%>
                                        <asp:BoundField DataField="Documento" HeaderText="Documento" /> <%--8--%>
                                        <asp:BoundField DataField="FechaNot" HeaderText="FecNot" /> <%--9--%>
                                        <asp:BoundField DataField="FechaRec" HeaderText="FecRec" /> <%--10--%>
                                        <asp:BoundField DataField="CiteDev" HeaderText="CiteDev" /> <%--11--%>
                                        <asp:BoundField DataField="FechaDev" HeaderText="FechaDev" /> <%--12--%>
                                        <asp:BoundField DataField="EstadoEnv" HeaderText="EstadoEnv" /> <%--13--%>
                                        <asp:BoundField DataField="DiasTranscurridos" HeaderText="DiasTranscurridos" /> <%--14--%>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <div align="center" class="CajaDialogoAdvertencia">
                                            <br />
                                            <img src="../Imagenes/warning.gif"
                                                alt="No existen datos que correspondan al criterio especificado" />
                                            <br />
                                            No existen datos que correspondan al criterio especificado
                                        <br />
                                            <br />
                                        </div>
                                    </EmptyDataTemplate>
                                </asp:GridView>               
             </td>             
         </tr>
                <tr>
             <td align="center">
                 <asp:GridView ID="gvListaNotificaciones" runat="server"
                                    AutoGenerateColumns="False" BorderColor="#DADADA" BorderStyle="Solid" BorderWidth="1px"
                                    CssClass="etiqueta8Blue" EnableTheming="True" Font-Names="Arial" Font-Size="9pt" GridLines="Horizontal"
                                    SkinID="GridView">
                                    <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="Matricula" HeaderText="Matricula" /> <%--0--%>
                                        <asp:BoundField DataField="IdTramite" HeaderText="Tramite" /> <%--1--%>
                                        <asp:BoundField DataField="Beneficio" HeaderText="Tipo_Tram" /> <%--2--%>
                                        <asp:BoundField DataField="FechaSistema" HeaderText="Fecha_Sis" /> <%--3--%>
                                        <asp:BoundField DataField="Nombres" HeaderText="Nombres" DataFormatString="{0:d}" /> <%--4--%>
                                        <asp:BoundField DataField="EstadoNot" HeaderText="Estado_Not" /> <%--5--%>
                                        <asp:BoundField DataField="FechaDocumento" HeaderText="FechaDoc" /> <%--6--%>
                                        <asp:BoundField DataField="NroDocumento" HeaderText="NroDoc" /> <%--7--%>
                                        <asp:BoundField DataField="Documento" HeaderText="Documento" /> <%--8--%>
                                        <asp:BoundField DataField="FechaNot" HeaderText="FecNot" /> <%--9--%>
                                        <asp:BoundField DataField="FechaRec" HeaderText="FecRec" /> <%--10--%>
                                        <asp:BoundField DataField="CiteEnv" HeaderText="CiteDev" /> <%--11--%>
                                        <asp:BoundField DataField="FechaEnv" HeaderText="FechaDev" /> <%--12--%>
                                        <asp:BoundField DataField="Obs" HeaderText="Obs" /> <%--13--%>
                                        <asp:BoundField DataField="CiteDev" HeaderText="CiteEnv" /> <%--14--%>
                                        <asp:BoundField DataField="FechaDev" HeaderText="FechaDev" /> <%--15--%>
                                        <asp:BoundField DataField="EstadoEnv" HeaderText="EstadoEnv" /> <%--16--%>
                                        <asp:BoundField DataField="Regional" HeaderText="Regional" /> <%--17--%>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <div align="center" class="CajaDialogoAdvertencia">
                                            <br />
                                            <img src="../Imagenes/warning.gif"
                                                alt="No existen datos que correspondan al criterio especificado" />
                                            <br />
                                            No existen datos que correspondan al criterio especificado
                                        <br />
                                            <br />
                                        </div>
                                    </EmptyDataTemplate>
                                </asp:GridView>               
             </td>             
         </tr>
            <tr>
             <td align="center">
                 <asp:GridView ID="gvListaRecursos" runat="server"
                                    AutoGenerateColumns="False" BorderColor="#DADADA" BorderStyle="Solid" BorderWidth="1px"
                                    CssClass="etiqueta8Blue" EnableTheming="True" Font-Names="Arial" Font-Size="9pt" GridLines="Horizontal"
                                    SkinID="GridView">
                                    <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="Matricula" HeaderText="Matricula" /> <%--0--%>
                                        <asp:BoundField DataField="IdTramite" HeaderText="Tramite" /> <%--1--%>
                                        <asp:BoundField DataField="Beneficio" HeaderText="Tipo_Tram" /> <%--2--%>
                                        <asp:BoundField DataField="FechaSistema" HeaderText="Fecha_Sis" /> <%--3--%>
                                        <asp:BoundField DataField="Nombres" HeaderText="Nombres" DataFormatString="{0:d}" /> <%--4--%>
                                        <asp:BoundField DataField="EstadoNot" HeaderText="Estado_Not" /> <%--5--%>
                                        <asp:BoundField DataField="FechaDocumento" HeaderText="FechaDoc" /> <%--6--%>
                                        <asp:BoundField DataField="NroDocumento" HeaderText="NroDoc" /> <%--7--%>
                                        <asp:BoundField DataField="Documento" HeaderText="Documento" /> <%--8--%>
                                        <asp:BoundField DataField="FechaNot" HeaderText="FecNot" /> <%--9--%>
                                        <asp:BoundField DataField="FechaRec" HeaderText="FecRec" /> <%--10--%>
                                        <asp:BoundField DataField="Obs" HeaderText="Obs" /> <%--11--%>
                                        <asp:BoundField DataField="EstadoEnv" HeaderText="EstadoEnv" /> <%--12--%>
                                        <asp:BoundField DataField="Regional" HeaderText="Regional" /> <%--13--%>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <div align="center" class="CajaDialogoAdvertencia">
                                            <br />
                                            <img src="../Imagenes/warning.gif"
                                                alt="No existen datos que correspondan al criterio especificado" />
                                            <br />
                                            No existen datos que correspondan al criterio especificado
                                        <br />
                                            <br />
                                        </div>
                                    </EmptyDataTemplate>
                                </asp:GridView>               
             </td>             
         </tr>
   </table>  
</asp:Content>

