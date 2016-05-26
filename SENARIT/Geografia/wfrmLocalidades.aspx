<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmLocalidades.aspx.cs" Inherits="wfrmLocalidades" StyleSheetTheme="Modal" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    
        .cssHeaderImg
	{
	background-image : url(../Imagenes/Frames/Menu5.png);
    }
    
       .auto-style5 {
            /*background-color: lightskyblue;*/

        border: thin solid lightsteelblue;
            background-color: #dff1fc;
            elevation: higher;
            width: 119px;
        }
    
        .auto-style6 {
            height: 25px;
        }
    
    </style>

        <script type="text/javascript" language="javascript">
            //function ModalPopup() 
            //{
            //    var vpRND = Math.random() * 20;
            //    showModalDialog('\ModalRol.aspx?rn=' + vpRND, '', 'dialogWidth=640px; dialogHeight=320px; center=yes; scrollbars=no');
            //}
        </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td align="center" colspan="4" class="auto-style6">
                <asp:ImageButton ID="imgAux" runat="server" ImageUrl="~/Imagenes/16w.png" />
                <asp:Label ID="lblTituloAUX" runat="server" 
                    Text="Localidades" CssClass="etiqueta20"></asp:Label>
                <asp:Label ID="lblCodigo" runat="server" Font-Size="Small" Text="1" 
                    Visible="False"></asp:Label>
                <asp:Label ID="lblCodUsuario" runat="server" Font-Size="Small" Text="1" 
                    Visible="False"></asp:Label>
                <asp:Label ID="lblRol" runat="server" Font-Size="Small" 
                    style="text-align: left" Text="0" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" valign="top" class="auto-style5" >
                                <asp:Panel ID="pnlNew" runat="server" Height="24px" Width="80px">
                                    <table style="width:100%;">
                                        <tr>
                                            <td align="center" width="15%">
                                                <asp:ImageButton ID="imgNuevo" runat="server" ImageUrl="~/Imagenes/nuevo.gif" 
                                                    onclick="imgNuevo_Click" TabIndex="10" />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
            </td>
            <td align="right" valign="top" class="panelprincipal" width="70%">
                        &nbsp;</td>
            <td align="right" valign="top" class="panelprincipal" width="15%">
                        <asp:RadioButtonList ID="rbTipoMuestra" runat="server"  
                              RepeatDirection="Horizontal" TextAlign="Left" 
                              AutoPostBack="True" 
                              onselectedindexchanged="rbTipoMuestra_SelectedIndexChanged" CssClass="etiqueta8Blue" >

                        <asp:ListItem Selected="True" Value="1" >Todos</asp:ListItem>
                        <asp:ListItem Value="2">Solo Activos</asp:ListItem>
                                    </asp:RadioButtonList>     
           
            </td>
        </tr>
        <tr>
            <td colspan="4" width="100%">
                <asp:Panel ID="pnlGV" runat="server" HorizontalAlign="Center" Width="100%" 
                    CssClass="panelprincipal">
                    <table style="width:100%;">
                        <tr>
                            <td valign="100%">
                                <asp:GridView ID="gvDatos" runat="server" EnableTheming="True" 
                                    HorizontalAlign="Center" onrowdatabound="gvRoles_RowDataBound" 
                                    onrowdeleting="gvRoles_RowDeleting" onrowediting="gvRoles_RowEditing" 
                                    SkinID="GridView" Width="100%" EnableModelValidation="True" CssClass="etiqueta8Blue">
                                    <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                                    <Columns>
                                        <asp:BoundField DataField="IdEstado" HeaderText="Estado" Visible="False" />
                                        <asp:BoundField DataField="IdDepartamento" HeaderText="Cod Dep" ItemStyle-Width="5%">
                                        <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="IdProvincia" HeaderText="Cod Prov" ItemStyle-Width="5%">
                                        <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="IdSeccion" HeaderText="Cod Sec" ItemStyle-Width="5%">
                                        <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="IdLocalidad" HeaderText="Cod Loc" ItemStyle-Width="5%">
                                        <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="NombreLocalidad" HeaderText="Localidad" ItemStyle-Width="70%">
                                        <ItemStyle Width="85%" />
                                        </asp:BoundField>

                                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Imagenes/16eliminar.png" HeaderText="Eli" ItemStyle-Width="5%" ShowDeleteButton="True">
                                        <ItemStyle HorizontalAlign="Center" Width="5%"/>
                                        </asp:CommandField>
                                        <asp:CommandField ButtonType="Image" EditImageUrl="~/Imagenes/16modificar.png" HeaderText="Modi" ItemStyle-Width="5%" ShowEditButton="True">
                                        <ItemStyle HorizontalAlign="Center" Width="5%"/>
                                        </asp:CommandField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Panel ID="pnlBotones" runat="server">
                                    <table style="width:100%;">
                                        <tr>
                                            <td valign="middle">
                                                <asp:Label ID="Label9" runat="server" CssClass="etiqueta8" 
                                                    style="text-align: left; font-family: Arial; font-size: x-small;" 
                                                    Text="Paginacion de:" Width="80px"></asp:Label>
                                                <asp:TextBox ID="txtRango" runat="server" 
                                                    style="text-align: center; font-size: xx-small; font-family: Arial" 
                                                    Width="25px">10</asp:TextBox>
                                            </td>
                                            <td valign="middle">
                                                <asp:Button ID="btnIni" runat="server" CssClass="boton50" 
                                                    onclick="btnIni_Click" Text="Inicio" />
                                                <asp:Button ID="btnAnt" runat="server" CssClass="boton50" 
                                                    onclick="btnAnt_Click" Text="&lt;-Ant" />
                                                <asp:TextBox ID="txtPagina" runat="server" CssClass="texto8" 
                                                    style="text-align: center; font-size: xx-small; font-family: Arial" 
                                                    Width="25px">1</asp:TextBox>
                                                <asp:Label ID="Label11" runat="server" CssClass="etiqueta8" 
                                                    style="font-family: Arial; font-size: x-small" Text="de"></asp:Label>
                                                <asp:TextBox ID="txtTotalPaginas" runat="server" CssClass="texto8" 
                                                    Enabled="False" 
                                                    style="text-align: center; font-size: xx-small; font-family: Arial" 
                                                    Width="25px"></asp:TextBox>
                                                <asp:Button ID="btnSig" runat="server" CssClass="boton50" 
                                                    onclick="btnSig_Click" Text="Sig-&gt;" />
                                                <asp:Button ID="btnFin" runat="server" CssClass="boton50" 
                                                    onclick="btnFin_Click" Text="Fin" />
                                            </td>
                                            <td valign="middle">
                                                <asp:Label ID="Label10" runat="server" CssClass="etiqueta8" 
                                                    style="font-family: Arial; font-size: x-small" Text="Total Registros:" 
                                                    Width="80px"></asp:Label>
                                                <asp:TextBox ID="txtTotal" runat="server" Enabled="False" 
                                                    style="text-align: center; font-size: xx-small; font-family: Arial" 
                                                    Width="25px"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="4" align="center">
                <asp:Label ID="lblObservaciones" runat="server" CssClass="text_obs"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="4">

                <asp:Panel ID="pnlDatos" runat="server" CssClass="panelprincipal" 
                    HorizontalAlign="Center" Width="60%">
                    <div>
                        <asp:Label ID="lblTitulo" runat="server" Text="Localidades" 
                            CssClass="etiqueta20"></asp:Label>
                        <table style="width:100%;">
                            <tr>
                                <td align="right" width="30%">
                                    <asp:Label ID="Label12" runat="server" CssClass="etiqueta10" style="text-align: left" Text="Descripcion :"></asp:Label>
                                </td>
                                <td align="left" width="70%">
                                    <asp:TextBox ID="txtDepartamento" runat="server" CssClass="texto10_Upper" MaxLength="50" Width="250px"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="txtDepartamento_FilteredTextBoxExtender" 
                                        runat="server" FilterType="Custom, LowercaseLetters, UppercaseLetters" 
                                        TargetControlID="txtDepartamento" ValidChars=" -">
                                    </cc1:FilteredTextBoxExtender>
                                </td>
                            </tr>
                        </table>
                        <asp:CheckBox ID="chbEstado" runat="server" Checked="True" 
                            Text="Activar" CssClass="etiqueta8Blue" />
                    <br />
                        <asp:Button ID="btnAccionar" runat="server" CssClass="boton150" onclick="btnAccionar_Click" OnClientClick="javascript : return confirm('Esta seguro de realizar esta accion?');" Text="Adicionar" />
                        <asp:Button ID="btnCancelar" runat="server" EnableTheming="True" 
                            onclick="btnCancelar_Click" Text="Cancelar" 
                            CssClass="boton150" />
                    </div>
                </asp:Panel>
                <cc1:RoundedCornersExtender ID="pnlDatos_RoundedCornersExtender" runat="server" 
                    Enabled="True" TargetControlID="pnlDatos" Radius="10" BorderColor="Black" >
                </cc1:RoundedCornersExtender>
                <cc1:ModalPopupExtender ID="pnlDatos_ModalPopupExtender" runat="server" 
                    DynamicServicePath="" 
                    Enabled="True" 
                    TargetControlID="lblTitulo"
                    CancelControlID = "btnCancelar"
                    PopupControlID="pnlDatos" 
                    BackgroundCssClass = "modalBackground">
                </cc1:ModalPopupExtender>

            </td>
        </tr>
        </table>
</asp:Content>

