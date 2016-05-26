<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmActividadesConCbte.aspx.cs" Inherits="WorkFlow_wfrmActividadesConCbte" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type="text/javascript" language="javascript">
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%;" class="panelceleste">
        <tr>
            <td align="center">
                <asp:ImageButton ID="imgAux" runat="server" ImageUrl="~/Imagenes/16w.png" />
                <asp:Label ID="lblTituloAUX" runat="server"
                    Text="ACTIVIDADES A ACEPTARSE CON COMPROBANTE" CssClass="etiqueta20"></asp:Label>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Panel ID="PanelDatos" runat="server" CssClass="panelceleste">
                    <table width="100%">
                        <tr>
                            <td style="text-align: right" class="auto-style5">
                                <asp:Label ID="lblOrigen" CssClass="etiqueta10" runat="server" Text="Origen"></asp:Label>
                            </td>
                            <td style="text-align: left" colspan="2" class="auto-style6">
                                <asp:DropDownList ID="dllCbtesPendientesXUsuario" runat="server" Width="461px" AutoPostBack="True" OnSelectedIndexChanged="dllActividad_SelectedIndexChanged">
                                </asp:DropDownList></td>
                            <td style="text-align: right" class="auto-style5">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label6" runat="server" Text="Comprobante" CssClass="etiqueta10"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:Label ID="Label5" runat="server" Text="Fecha Registro" CssClass="etiqueta10"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:Label ID="Label4" runat="server" Text="Comentario General" CssClass="etiqueta10"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:Label ID="Label3" runat="server" Text="Descripción Area Origen" CssClass="etiqueta10"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="Descripción Area Destino" CssClass="etiqueta10"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblIdComprobante" runat="server" BackColor="#B0C4DE" Width="151px"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:Label ID="lblFechaRegistro" runat="server" BackColor="#B0C4DE" Width="151px"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:Label ID="lblComentarioGeneral" runat="server" BackColor="#B0C4DE" Width="151px"></asp:Label>
                            </td>
                            <td style="width: 20%">
                                <asp:Label ID="lblDescAreaOrigen" runat="server" BackColor="#B0C4DE" Width="151px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblDescAreaDestino" runat="server" BackColor="#B0C4DE" Width="151px"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <table style="width: 100%;">
                    <tr>
                        <td colspan="2" class="panelceleste">
                            <asp:GridView ID="gvActividadesConCbte" runat="server"
                                AutoGenerateColumns="False"
                                HorizontalAlign="Center"
                                SkinID="GridView"
                                Width="100%" DataKeyNames="IdInstancia,Secuencia" >
                                <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                                <Columns>
                                    <asp:TemplateField ItemStyle-Width="40px">
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="chkboxSelectAll" runat="server" onclick="checkAll(this);" />
                                        </HeaderTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkActividad" runat="server" 
                                                AutoPostBack="true" >
                                            </asp:CheckBox>
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
                                    <asp:BoundField DataField="IdGrupoBeneficio" HeaderText="IdGrupoBeneficio" />
                                    <asp:BoundField DataField="NombreBeneficiario" HeaderText="NombreBeneficiario" />
                                    <asp:BoundField DataField="IdTramite" HeaderText="Nro. Tramite" />
                                    <asp:BoundField DataField="Comentario" HeaderText="Comentario" />
                                    <asp:BoundField DataField="FlagAceptacion" HeaderText="FlagAceptacion" Visible="false" />
                                </Columns>
                            <EmptyDataTemplate>
                                <div align="center" class="CajaDialogoAdvertencia">
                                <br/><img src="../Imagenes/warning.gif" 
                                        alt="No existen Tramites por Asignar para el usuario en curso." />
                                <br/>Bandeja de Actividades con Comprobante vacia.
                                <br/><br/>
                                </div>
                            </EmptyDataTemplate>
                            </asp:GridView>                                
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnConfirmar" CssClass="boton150" runat="server" Text="Confirmar Recepcion" 
                                OnClick="btnConfirmar_Click" onclientclick="return confirm('Esta seguro de ACEPTAR las actividades marcadas ?');" Width="178px" />
                            <asp:ImageButton ID="imgVolver" runat="server"  ImageUrl="~/Imagenes/32Volver.png" ToolTip="Volver a la Página anterior" OnClick="btnVolver_Click" /> 
                            <asp:Label ID="lblTVolver" CssClass="etiqueta8Blue" runat="server" Text="Volver" /> 
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

