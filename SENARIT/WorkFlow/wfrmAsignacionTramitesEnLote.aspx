<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmAsignacionTramitesEnLote.aspx.cs" Inherits="WorkFlow_wfrmAsignacionTramitesEnLote" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">
    body{
	    background-color:#ECF5FB;
	    background-image:url(../Imagenes/Frames/Stage_BG_btm.png);
	    background-position:center bottom;
	    background-repeat:repeat-x;
	    font-family:Tahoma,Verdana,Segoe,sans-serif;
	    font-size:70%;
	    padding-bottom:20px;
    }
    .Container
    {
	    margin:auto;
	    min-height:400px;
	    background:#ffffff;
	    max-width:500px;
	    min-width:500px;
	    border:solid 1px #d4d4d4;
	    padding:0 20px 20px 20px;
    }
    .auto-style5 {
        width: 20%;
        height: 36px;
    }
    .auto-style6 {
        width: 70%;
        height: 36px;
    }
    .auto-style5 {
        height: 19px;
    }
    .highlight {text-decoration: none;color:black;background:#B8860B;}
    .modalBackground2
    {
	    background-color: Black;
	    filter: alpha(opacity=80); 
	    opacity: 0.50;
    }
    .tableBackground
    {
	    background-color:silver;
	    opacity:0.7;
    }
    .panelAuxiliar
    {
        background-color: #D3D3D3;
        border-color: #6699FF;
        border-style: solid;
        border-width: thin;
        elevation: higher;
        line-height: inherit;
    }
</style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <table style="width: 100%;" class="panelceleste">
        <tr>
            <td align="center">
                <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/WorkFlow/wfrmAsignacionTramitesPorUsuario.aspx">
                    <asp:ImageButton ID="imgAux" runat="server" ImageUrl="~/Imagenes/16w.png" />
                    <asp:Label ID="lblTituloAUX" runat="server"
                        Text="ASIGNACION DE TRAMITES POR LOTE" CssClass="etiqueta20"></asp:Label><br />
                </asp:LinkButton>
                <asp:ImageButton ID="imgAux2" runat="server" ImageUrl="~/Imagenes/16w.png" />
                <asp:Label ID="lblTituloAUX2" runat="server"
                    Text="ASIGNACION DE TRAMITES POR USUARIO" CssClass="etiqueta20"></asp:Label>
           </td>
        </tr>
        <tr>
            <td>
                <div class="panelceleste">
                    <table width="100%">
                        <tr>
                            <td>
                                <asp:DropDownList ID="ddlTransicionesDelUsuario" runat="server" 
                                    style="margin-left: 0px" Width="533px" OnSelectedIndexChanged="ddlTransicionesDelUsuario_SelectedIndexChanged"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:GridView ID="gvActividadesPorAsignar" runat="server" AutoGenerateColumns="False"
                                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                                    CellPadding="3" Font-Names="Verdana" Font-Size="7pt" 
                                    OnRowDataBound="gvActividadesPorAsignar_RowDataBound"
                                    OnPageIndexChanging ="gvActividadesPorAsignar_PageIndexChanging" 
                                    OnRowCommand="gvActividadesPorAsignar_RowCommand" 
                                    DataKeyNames="IdInstancia">
                                <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                                <AlternatingRowStyle BackColor="#F7F7F7" />
                                <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                                <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                                <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                                <SelectedRowStyle BackColor="#6495ED" Font-Bold="True" ForeColor="#333333" />
                                <Columns>
                                    <%-- <asp:BoundField DataField="NombreBeneficiario" HeaderText="Nombre Beneficiario" />
                                    <asp:BoundField DataField="nua" HeaderText="NUP" />--%>
                                    <asp:ButtonField Text="SingleClick" CommandName="SingleClick" Visible="false"/>
                                    <asp:ButtonField Text="DoubleClick" CommandName="DoubleClick" Visible="false"/>
                                    <asp:TemplateField ItemStyle-Width="40px">
                                        <HeaderTemplate>
                                            <asp:Label ID="lblUsuarioAsignado" runat="server" Text="Usuario Asignado"></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                                    <asp:DropDownList ID="ddlUsuarioAsignado" runat="server" 
                                                        Font-Size="Small" BackColor="#6495ED" AutoPostBack="True" 
                                                        OnSelectedIndexChanged="ddlUsuarioAsignado_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                        </ItemTemplate>
                                        <ItemStyle Width="40px" />
                                    </asp:TemplateField>                                                                                                                              
                                    <asp:TemplateField HeaderText="IdInstancia">
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
                                    <asp:BoundField DataField="IdTramite" HeaderText="Nro. Tramite" />
                                    <asp:BoundField DataField="IdFlujo" HeaderText="IdFlujo" />
                                    <asp:BoundField DataField="DescFlujo" HeaderText="DescFlujo" />
                                    <asp:BoundField DataField="IdNodo" HeaderText="IdNodo" />
                                    <asp:BoundField DataField="Descripcion" HeaderText="Actividad" />
                                    <asp:BoundField DataField="Contador" HeaderText="Contador" />
                                    <asp:BoundField DataField="FechaHRInicio" HeaderText="FechaHRInicio" />
                                    <asp:BoundField DataField="FechaHRFin" HeaderText="FechaHRFin" />                                        
                                    <asp:BoundField DataField="Comentarios" HeaderText="Comentarios" />
                                </Columns>
                                <EmptyDataTemplate>
                                    <div align="center" class="CajaDialogoAdvertencia">
                                    <br/><img src="../Imagenes/warning.gif" 
                                            alt="No existen Tramites por Asignar para el usuario en curso." />
                                    <br/>No existen Actividades por Asignar para el usuario en curso.
                                    <br/><br/>
                                    </div>
                                </EmptyDataTemplate>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" ForeColor="red" />
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>            
                    <img alt="progress" src="../Imagenes/ajax_loader_blue_32.gif"/>
                        Procesando ...            
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                <div class="panelAuxiliar">
                <table width="100%">
                    <tr>
                        <td align="center" colspan="2">
                            <asp:Label ID="lblTitAsigActiv" runat="server" Text="Actividades Asignadas del Usuario ________" CssClass="etiqueta20" Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                                <asp:GridView ID="gvActivUsuario" runat="server" AutoGenerateColumns="False"
                                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                                CellPadding="3" Font-Names="Verdana" Font-Size="7pt" 
                                OnRowDataBound="gvActivUsuario_RowDataBound"
                                OnPageIndexChanging ="gvActivUsuario_PageIndexChanging" 
                                OnRowCommand="gvActivUsuario_RowCommand">
                                <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                                <AlternatingRowStyle BackColor="#F7F7F7" />
                                <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                                <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                                <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                                <SelectedRowStyle BackColor="#6495ED" Font-Bold="True" ForeColor="#333333" />
                                <Columns>      
                                    <asp:BoundField DataField="IdInstancia" HeaderText="IdInstancia" />
                                    <asp:BoundField DataField="Secuencia" HeaderText="Secuencia" />
                                    <asp:BoundField DataField="IdTipoTramite" HeaderText="IdTipoTramite" />
                                    <asp:BoundField DataField="IdGrupoBeneficio" HeaderText="IdGrupoBeneficio" />
                                    <asp:BoundField DataField="IdTramite" HeaderText="Nro. Tramite" />
                                    <asp:BoundField DataField="IdFlujo" HeaderText="IdFlujo" />
                                    <asp:BoundField DataField="DescFlujo" HeaderText="DescFlujo" />
                                    <asp:BoundField DataField="IdNodo" HeaderText="IdNodo" />
                                    <%-- <asp:BoundField DataField="NombreBeneficiario" HeaderText="Nombre Beneficiario" />
                                    <asp:BoundField DataField="nua" HeaderText="NUP" />--%>
                                    <asp:BoundField DataField="Descripcion" HeaderText="Actividad" />
                                    <asp:BoundField DataField="Contador" HeaderText="Contador" />
                                    <asp:BoundField DataField="FechaHRInicio" HeaderText="FechaHRInicio" />
                                    <asp:BoundField DataField="FechaHRFin" HeaderText="FechaHRFin" />                                        
                                    <asp:BoundField DataField="Comentarios" HeaderText="Comentarios" />
                                </Columns>
                            <EmptyDataTemplate>
                                <div align="center" class="CajaDialogoAdvertencia">
                                <br/><img src="../Imagenes/warning.gif" 
                                        alt="No existen Tramites por Asignar para el usuario en curso." />
                                <br/>No existen Actividades por Asignar para el usuario en curso.
                                <br/><br/>
                                </div>
                            </EmptyDataTemplate>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:Label ID="lblIdInstancia" runat="server" Text=""></asp:Label>
                            <asp:Label ID="lblIdTipoTramite" runat="server" Text=""></asp:Label>
                            <asp:Label ID="lblIdTramite" runat="server" Text=""></asp:Label>
                            <asp:Label ID="lblIdFlujo" runat="server" Text=""></asp:Label>
                            <asp:Label ID="lblddl1" runat="server" Text=""></asp:Label>
                            <asp:Label ID="lblIdTrans" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:Label id="Message" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                        </td>
                    </tr>
                </table>
                </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="gvActividadesPorAsignar" EventName="RowCommand" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:ImageButton ID="imgVolver" runat="server"  ImageUrl="~/Imagenes/32Volver.png" ToolTip="Volver a la Página anterior" OnClick="btnCancelar_Click" /> 
                <asp:Label ID="lblTVolver" CssClass="etiqueta8Blue" runat="server" Text="Volver" /> 
                <asp:Button ID="btnAsignarActividades" CssClass="boton150" runat="server" Text="Confirmar Asignación"
                    CausesValidation="False" ToolTip="Asigna Actividades Marcadas." 
                    onclientclick="return confirm('Esta seguro de asignar las actividades marcadas ?');" 
                    OnClick="btnAsignarActividades_Click" Height="27px" Width="220px"/>
            </td>
        </tr>
    </table>
</asp:Content>

