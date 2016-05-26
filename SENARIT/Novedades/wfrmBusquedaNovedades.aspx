<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmBusquedaNovedades.aspx.cs" Inherits="Novedades_wfrmBusquedaNovedades" StylesheetTheme="Modal" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .cssHeaderImg {
            background-image: url(../Imagenes/Menu4.png);
        }

        .auto-style4 {
            width: 280px;
        }
    </style>

    <script type="text/javascript" language="javascript">
        function ModalPopup() {
            var vpRND = Math.random() * 20;
            showModalDialog('\Auxiliar\\ModRol.aspx?rn=' + vpRND, '', 'dialogWidth=640px; dialogHeight=320px; center=yes; scrollbars=no');
        }
        function checkAll(objRef) {
            var GridView = objRef.parentNode.parentNode.parentNode;
            var inputList = GridView.getElementsByTagName("input");
            for (var i = 0; i < inputList.length; i++) {
                //Get the Cell To find out ColumnIndex
                var row = inputList[i].parentNode.parentNode;
                if (inputList[i].type == "checkbox" && objRef != inputList[i]) {
                    if (objRef.checked) {
                        inputList[i].checked = true;
                    }
                    else {
                        inputList[i].checked = false;
                    }
                }
            }
        }
    </script>

</asp:Content>
<%--TODA LA TABLA--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%;" class="panelceleste">
        <tr>
            <td align="center" colspan="3">
                <asp:ImageButton ID="imgAux" runat="server" ImageUrl="~/Imagenes/w.png" />
                <asp:Label ID="lblTituloAUX" runat="server"
                    Text="Campos de Clasificador" CssClass="etiqueta20"></asp:Label>
                <asp:Label ID="lblCodigo" runat="server" Font-Size="Small" Text="1"
                    Visible="False"></asp:Label>
                <asp:Label ID="lblCodUsuario" runat="server" Font-Size="Small" Text="1"
                    Visible="False"></asp:Label>
                <asp:Label ID="lblRol" runat="server" Font-Size="Small"
                    Style="text-align: left" Text="0" Visible="False"></asp:Label>
            </td>
        </tr>
        <%--TODA LA TABLA--%>
        <tr>
            <td colspan="3">
                <table style="width: 100%;">
                    <tr>
                        <td align="right" style="width: 50%">
                            <asp:Label ID="Label2" runat="server" CssClass="etiqueta10"
                                Style="text-align: left" Text="Tipo Novedad:"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlTipoNovedad" runat="server"
                                AutoPostBack="True" Width="200px">
                            </asp:DropDownList>
                        </td>
                        <td align="right" style="width: 50%">
                            <asp:Label ID="Label1" runat="server" CssClass="etiqueta10"
                                Style="text-align: left" Text="Estado Novedad :"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlEstadoNovedad" runat="server"
                                AutoPostBack="True" Width="200px">
                                <asp:ListItem Selected="True" Value=" ">Todos</asp:ListItem>
                                <asp:ListItem Value="Elaborado">Elaborado</asp:ListItem>
                                <asp:ListItem Value="Aprobado">Aprobado</asp:ListItem>
                                <asp:ListItem Value="Rechazado">Rechazado</asp:ListItem>
                                <asp:ListItem Value="Aplicado">Aplicado</asp:ListItem>
                                <asp:ListItem Value="Eliminado">Eliminado</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="left"><label>Fecha Inicio:</label></td>
                        <td align="left">
                            <asp:TextBox ID="txtFechaInicio" runat="server"></asp:TextBox>
                            <asp:ImageButton ID="imgcalendario" runat="server" CssClass="CajaDialogo" ImageUrl="~/Imagenes/32calendario.png"  />
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFechaInicio"  Format="dd/MM/yyyy" PopupButtonID="imgcalendario">  </cc1:CalendarExtender>	
                        </td>
                        <td align="left"><label>Fecha Fin:</label></td>
                        <td align="left">
                            <asp:TextBox ID="txtFechaFin" runat="server"></asp:TextBox>
                            <asp:ImageButton ID="imgcalendario1" runat="server" CssClass="CajaDialogo" ImageUrl="~/Imagenes/32calendario.png"  />
                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtFechaFin"  Format="dd/MM/yyyy" PopupButtonID="imgcalendario">  </cc1:CalendarExtender>	
                        </td>
                        <td align="right"><asp:ImageButton runat="server" ID="imgbtnBuscar" ImageUrl="~/Imagenes/32Buscar.png" OnClick="imgbtnBuscar_Click" /></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>

        <td align="left" valign="top" style="width:10%">
            <asp:Label ID="Label7" runat="server" CssClass="etiqueta10" Style="text-align:left" Text="CUA: "></asp:Label>
            <asp:TextBox ID="TextCUA" runat="server" CssClass="texto10" MaxLength="50" Style="text-align:left" Width="100px"></asp:TextBox>  
        </td>
        <td align="left" valign="top" style="width:30%">
            <asp:ImageButton runat="server" ID="ImageButton1" ImageUrl="~/Imagenes/32recargar.png" OnClick="BuscarNUA" />
        </td>

        </tr>
        <%--TODA LA TABLA--%>
<tr>
            <td colspan="3" width="100%">
                <asp:Panel ID="pnlGV" runat="server" HorizontalAlign="Center" Width="100%" 
                    CssClass="panelprincipal">
                    <table style="width:100%;">
                        <tr>
                            <td>
                                <asp:GridView ID="gvNovedades" runat="server" EnableTheming="True" AllowPaging="True" PageSize="15" 
                                    HorizontalAlign="Center" OnPageIndexChanging="gvNovedades_PageIndexChanging"
                                    SkinID="GridView" Width="100%" CssClass="etiqueta8Blue" OnRowCommand="gvNovedades_RowCommand">
                                    <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                                    <Columns>
                                    <asp:TemplateField ItemStyle-Width="4%" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" >
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="chkTodos" runat="server" onclick = "checkAll(this);" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkNovedad" runat="server" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" Width="4%" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="FechaEmision" HeaderText="Fecha Ingreso" ItemStyle-Width="20%"> 
                                            <ItemStyle Width="20%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="IdActualizacion" HeaderText="Num Actualización" ItemStyle-Width="20%"> 
                                            <ItemStyle Width="20%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DescripcionActualizacion" HeaderText="Descripción" ItemStyle-Width="40%"> 
                                        <ItemStyle Width="40%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="FuncionarioRegistro" HeaderText="FuncionarioRegistro" ItemStyle-Width="20%"> 
                                        <ItemStyle Width="20%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="FuncionarioAprobacion" HeaderText="FuncionarioAprobacion" ItemStyle-Width="20%"> 
                                        <ItemStyle Width="20%" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DescEstado" HeaderText="Estado" ItemStyle-Width="20%"> 
                                        <ItemStyle Width="20%" />
                                        </asp:BoundField>

                                        <asp:buttonfield buttontype="Image" 
                                          commandname="Aprobar" 
                                          text="Aprobar" HeaderText="Apr." ImageUrl="~/Imagenes/16siguiente.png"/>

                                        <asp:buttonfield buttontype="Image" 
                                          commandname="Rechazar" 
                                          text="Rechazar" HeaderText="Rech." ImageUrl="~/Imagenes/16cancelar.png"/>

                                        <asp:buttonfield buttontype="Image" 
                                          commandname="Aplicar" 
                                          text="Aplicar" HeaderText="Apli." ImageUrl="~/Imagenes/16procesar.png" Visible="False"/>

                                        <asp:buttonfield buttontype="Image" 
                                          commandname="Eliminar" 
                                          text="Eliminar" HeaderText="Eli." ImageUrl="~/Imagenes/16eliminar.png" Visible="False"/>
                                        <asp:ButtonField ButtonType="Image" CommandName="Imprimir" HeaderText="Imp." ImageUrl="~/Imagenes/32imprimir.png" Text="Imprimir" />
                                      </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        
    </table>
</asp:Content>

