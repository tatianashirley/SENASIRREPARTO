<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmRegistroEmpresas.aspx.cs" Inherits="CertificacionCC_wfrmRegistroEmpresas" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            height: 23px;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%">
        <tr>
                                <td align="right">
                                    <asp:ImageButton ID="btnBusquedaEmpresa" runat="server"  ImageUrl="~/Imagenes/nueva3/buscar32.png" ToolTip="Buscar Empresa" OnClick="btnBusquedaEmpresa_Click"  CausesValidation="false"/>
                                    <asp:ImageButton ID="btnRegistraEmpresa" runat="server"  ImageUrl="~/Imagenes/nueva3/adicioncertificacion32.png" ToolTip="Registrar Empresa"   CausesValidation="false" OnClick="btnRegistraEmpresa_Click"/>
                                   </td>
                                
                            </tr>
    </table>
    
    <asp:Panel ID="pnlRegistroEmpresa" runat="server" GroupingText="Registro" >
             <table width="100%">
                            <tr>
                                <td colspan="2" align="center">
                                    <b><asp:Label  ID="Label7" runat="server" Text="REGISTRO DE EMPRESAS" ForeColor="Red"></asp:Label></b></td>
                                
                            </tr>
                            
                            <tr>
                                <td colspan="2" align="center" class="auto-style1">
                                    </td>
                                
                            </tr>
                            <tr>
                                <td align="right">
                                    <b>
                                    <asp:Label ID="Label1" runat="server" Text="Numero RUC"></asp:Label></b></td>
                                <td align="left">
                                    <asp:TextBox ID="txtRUC" runat="server" Height="22px" Width="250px" OnTextChanged="txtRUC_TextChanged" AutoPostBack="True" MaxLength="20"></asp:TextBox>
                                &nbsp;<br />
                                    <asp:Label ID="lblError1" runat="server" ForeColor="Red" Text="La Empresa: " Visible="False"></asp:Label>
                                    <asp:Label ID="lblError2" runat="server" ForeColor="Red" Text="Label" Visible="False"></asp:Label>
&nbsp;<asp:Label ID="lblError3" runat="server" ForeColor="Red" Text="ya se encuentra registrada" Visible="False"></asp:Label>
                                </td>
                            </tr>
                             <tr>
                                <td align="right">
                                    <b>
                                    <asp:Label ID="Label2" runat="server" Text="Nombre de la Empresa"></asp:Label></b></td>
                                <td align="left">
                                    <asp:TextBox ID="txtNombreEmpresa" onkeyup="this.value=this.value.toUpperCase()" runat="server" Height="54px" Width="350px" TextMode="multiline" Columns="50" Rows="5" MaxLength="100" ></asp:TextBox>

                                    <cc1:FilteredTextBoxExtender ID="txtNombreEmpresa_FilteredTextBoxExtender" runat="server" Enabled="True" TargetControlID="txtNombreEmpresa" FilterType="LowercaseLetters,UppercaseLetters,Numbers,Custom" ValidChars=". &nbsp; ' -&quot;" >
                                    </cc1:FilteredTextBoxExtender>

                                    <%--<asp:RequiredFieldValidator ID="rfvNombreEmpresa" runat="server" ControlToValidate="txtNombreEmpresa" ErrorMessage="*"></asp:RequiredFieldValidator>--%>

                                 </td>
                            </tr>
                             <tr>
                                <td align="right">
                                    <b>
                                    <asp:Label ID="Label3" runat="server" Text="Campo Aplicacion/Sector"></asp:Label></b></td>
                                <td align="left">
                                    <asp:TextBox ID="txtSector" runat="server" Width="250px" onkeyup="this.value=this.value.toUpperCase()" MaxLength="100" AutoPostBack="True" OnTextChanged="txtSector_TextChanged"></asp:TextBox>
                                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" enabled="True"
                                servicepath="~/BuscarSector.asmx" minimumprefixlength="2" servicemethod="wsBuscarSector"
                                enablecaching="true" targetcontrolid="txtSector" usecontextkey="True" completionsetcount="10"
                                completioninterval="200" >
                    </cc1:AutoCompleteExtender>
                                     
                                    <%--<asp:RequiredFieldValidator ID="rfvSector" runat="server" ControlToValidate="txtSector" ErrorMessage="*"></asp:RequiredFieldValidator>--%>
                                     
                                 </td>
                            </tr>
                             <tr>
                                <td  align="right" width="50%">
                                    <b>
                                    <asp:Label ID="Label4" runat="server" Text="Patronal"></asp:Label></b></td>
                                <td align="left">
                                    <asp:TextBox ID="txtPatronal" runat="server" onkeyup="this.value=this.value.toUpperCase()" MaxLength="20" AutoPostBack="True"></asp:TextBox>
                                 </td>
                            </tr>
                             <tr>
                                <td align="center" colspan="2">
                                    <asp:CheckBox ID="chbSalarioConvenio" runat="server" style="font-weight: 700" Text="Salario Convenio" />
                                    <br />
                                    <asp:CheckBox ID="chbEstado" runat="server" style="font-weight: 700" Text="Activo" Visible="false"/>
                                 </td>
                            </tr>
                             <tr>
                                <td align="center" colspan="2">
                                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" Visible="false" OnClick="btnGuardar_Click" style="height: 26px" />
                                    <asp:HiddenField ID="hfOperacion" runat="server" />
                                 </td>
                                
                            </tr>
                            
                        </table> 
        </asp:Panel>

                <asp:Panel ID="pnlBusqueda" runat="server"  >
                <table align="center" >
                    <tr>
                        <td align="center">
                            <asp:Panel ID="Panel2" runat="server" BackColor="White" BorderColor="White"
                GroupingText="Opciones de Busqueda" Height="96px" Width="200px">                    
                               
                                <asp:RadioButtonList ID="rblBusquedas" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rblBusquedas_SelectedIndexChanged">
                                    <asp:ListItem Value="1">Sector</asp:ListItem>
                                    <asp:ListItem Value="2">Nombre de Empresa</asp:ListItem>
                                    <asp:ListItem Value="3">Numero de Ruc</asp:ListItem>
                                </asp:RadioButtonList>
                    </asp:Panel>
                             
                        </td>
                        </tr>
                    <tr>
                        <td align="center">
                             <table width="100%" style="height: 151px">
                            <tr>
                                <td colspan="2" align="center">
                                    <b>
                                    <br />
                                    <asp:Label  ID="Label5" runat="server" Text="BUSQUEDA" ForeColor="Red"></asp:Label></b></td>
                                
                            </tr>
                            <tr>
                                <td colspan="2" align="center" class="auto-style1">
                                    </td>
                                
                            </tr>
                            <tr>
                                <td align="right" width="50%">
                                    <b>
                                    <asp:Label ID="lblRucBusqueda" runat="server" Text="Numero RUC" Visible="false"></asp:Label>
                                
                                    <asp:Label ID="lblEmpresaBusqueda" runat="server" Text="Nombre de la Empresa" Visible="false"></asp:Label>
                                
                                    <asp:Label ID="lblSectorBusqueda" runat="server" Text="Campo Aplicacion/Sector" Visible="false"></asp:Label>
                                </td>
                                <td align="left" width="50%">
                                    <asp:TextBox ID="txtRucBusqueda" runat="server" Height="22px" Width="250px"  MaxLength="20" Visible="false"></asp:TextBox>
                                
                                    <asp:TextBox ID="txtNombreEmpresaBusqueda" runat="server" Columns="50" Height="54px" MaxLength="100" onkeyup="this.value=this.value.toUpperCase()" Rows="5" TextMode="multiline" Visible="false" Width="350px"></asp:TextBox>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNombreEmpresaBusqueda" ErrorMessage="*"></asp:RequiredFieldValidator>--%>
                                
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" Enabled="True" FilterType="LowercaseLetters,UppercaseLetters,Numbers,Custom" TargetControlID="txtNombreEmpresaBusqueda" ValidChars=". &nbsp; ' -&quot;">
                                    </cc1:FilteredTextBoxExtender>
                                    <asp:TextBox ID="txtSectorBusqueda" runat="server" MaxLength="100" onkeyup="this.value=this.value.toUpperCase()" Visible="false" Width="250px"></asp:TextBox>
                                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" completioninterval="200" completionsetcount="10" enablecaching="true" enabled="True" minimumprefixlength="2" servicemethod="wsBuscarSector" servicepath="~/BuscarSector.asmx" targetcontrolid="txtSectorBusqueda" usecontextkey="True">
                                    </cc1:AutoCompleteExtender>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtSectorBusqueda" ErrorMessage="*"></asp:RequiredFieldValidator>--%>
                                
                                </td>
                                </tr>
                                 <tr>
                                     <td colspan="2">
                                         <asp:Panel ID="pnl_busq" runat="server" GroupingText="Acciones" Height="62px"
                        Width="721px" BackColor="White">
            <asp:Button ID="btn_busqueda" runat="server" Text="Buscar" Width="160px" OnClick="btn_busqueda_Click" 
                            />
           <asp:Button ID="btn_limpiar_celdas" runat="server" Text="Limpiar Celdas" Width="160px" OnClick="btn_limpiar_celdas_Click" 
                            />
                        <asp:Button ID="btn_borrar_resultados" runat="server" 
                            Text="Borrar Resultados" Width="160px" OnClick="btn_borrar_resultados_Click" />
                    
                       
               
                            </asp:Panel>
                                     </td>
                                 </tr>
                        
                    <tr>
                        <td colspan="2">
                             <asp:GridView ID="gvDatosBusqueda" runat="server"             
                        AllowPaging="True" PageSize="10"
                        AutoGenerateColumns="False"                         
                        EnableTheming="True" 
                        Font-Names="Arial" 
                        Font-Size="9pt" 
                        CssClass="mGrid"
                        PagerStyle-CssClass="pgr"
                        AlternatingRowStyle-CssClass="alt"
                        GridLines="None"
                        DataKeyNames="RUC,NombreEmpresa,NroPatronal,IdSector,Sector,SalarioConvenio,Estado"  
                        OnPageIndexChanging="gvDatosBusqueda_PageIndexChanging"
                        OnRowCommand="gvDatosBusqueda_RowCommand"
                       
                       >
                                  <%--OnRowCommand="gvDatosComponentes_RowCommand" OnRowDataBound="gvDatosComponentes_RowDataBound" --%>
                          
                            <Columns>                                
                                <asp:BoundField DataField="RUC" HeaderText="RUC"  />
                                <asp:BoundField DataField="NombreEmpresa" HeaderText="NombreEmpresa"  />                                
                                <asp:BoundField DataField="NroPatronal" HeaderText="NroPatronal"  />
                                <asp:BoundField DataField="Sector" HeaderText="Sector"  />                                
                                <asp:BoundField DataField="SalarioConvenio" HeaderText="SalarioConvenio"  />
                                <asp:BoundField DataField="Estado" HeaderText="Estado"/>                                         
                              <asp:TemplateField HeaderText="Editar" >                                  
                                    <ItemTemplate>
                                        <center>                                                                                
                                        <asp:ImageButton ID="imgEditar" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdEditar" ImageUrl="~/imagenes/nueva3/editar32.png" ToolTip="Editar Razon Social" />                                        
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
                        </td>

                    </tr>
                      
                                 <tr>
                                   <td colspan="2">
                                       &nbsp;</td>
                                 </tr>
                </table>
                            </td>
                        </table>
        </asp:Panel>

               
</asp:Content>

