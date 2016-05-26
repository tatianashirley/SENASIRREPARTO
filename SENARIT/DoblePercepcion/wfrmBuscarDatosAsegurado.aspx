<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmBuscarDatosAsegurado.aspx.cs" Inherits="DoblePercepcion_wfrmBuscarDatosAsegurado" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .auto-style1 {
        width: 187px;
    }
</style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
                                                        <!--DESDE AQUI SE PUDE PERSONALIZAR-->

    <div id="Div1" class="cuerpo_detalle" runat="server">
        <table>
            <tr>
                <td colspan ="5" width="100%" align="center">
                <asp:Label ID="lblTituloAUX" runat="server"
                Text="BUSCAR BENEFICIARIO" CssClass="etiqueta20" Font-Size="16pt"></asp:Label>
                </td>
            </tr>
                <tr>
                    <td class="auto-style1">
                    Primer Apellido: 
                </td>
                 <td>
                   <asp:TextBox ID="txtPrimerApellido" runat="server" onkeyup="this.value=this.value.toUpperCase()"  MaxLength="25" autofocus="autofocus"></asp:TextBox>
                  <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" 
				    runat="server" FilterType="Custom,LowercaseLetters,UppercaseLetters"
				    TargetControlID="txtPrimerApellido" ValidChars="Ññ´">
	                </cc1:FilteredTextBoxExtender>  
                </td> 
                    <td>  &nbsp;&nbsp;&nbsp;</td>
                    <td>
                      Segundo Apellido: 
                    </td>   
                <td>
                   <asp:TextBox ID="txtSegundoApellido" runat="server" onkeyup="this.value=this.value.toUpperCase()"  MaxLength="25" autofocus="autofocus"></asp:TextBox>
                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" 
				    runat="server" FilterType="Custom,LowercaseLetters,UppercaseLetters"
				    TargetControlID="txtSegundoApellido" ValidChars="Ñ´ñ">
	                </cc1:FilteredTextBoxExtender>  
                </td>
            </tr>
             <tr> 
                    <td class="auto-style1">
                    Primer Nombre: 
                </td>
                 <td>
                   <asp:TextBox ID="txtPrimerNombre" runat="server" onkeyup="this.value=this.value.toUpperCase()" MaxLength="25" autofocus="autofocus"></asp:TextBox>
                      <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" 
				    runat="server" FilterType="Custom,LowercaseLetters,UppercaseLetters"
				    TargetControlID="txtPrimerNombre" ValidChars="Ñ´ñ">
	                </cc1:FilteredTextBoxExtender>  
                 </td>
                 <td></td>
                    <td>
                      Segundo Nombre: 
                    </td>   
                <td>
                   <asp:TextBox ID="txtSegundoNombre" runat="server" onkeyup="this.value=this.value.toUpperCase()" MaxLength="25"></asp:TextBox>
                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" 
				    runat="server" FilterType="Custom,LowercaseLetters,UppercaseLetters"
				    TargetControlID="txtSegundoNombre" ValidChars="Ñ´ñ">
	                </cc1:FilteredTextBoxExtender>  
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    Documento de Identidad: 
                </td>
                 <td>
                   <asp:TextBox ID="txtCI" runat="server" onkeyup="this.value=this.value.toUpperCase()" class="txtCI" MaxLength="15" autofocus="autofocus"></asp:TextBox>
                    <cc1:FilteredTextBoxExtender ID="ftbtxtCI" 
							    runat="server" FilterType="Numbers"
							    TargetControlID="txtCI" ValidChars="">
					    </cc1:FilteredTextBoxExtender>  
                 </td>
                <td></td>
                    <td>
                      Matricula: 
                    </td>   
                <td>
                   <asp:TextBox ID="txtMatricula" runat="server" onkeyup="this.value=this.value.toUpperCase()" MaxLength="15" autofocus="autofocus"></asp:TextBox>
                   <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" 
							    runat="server" FilterType="Custom,Numbers,LowercaseLetters,UppercaseLetters"
							    TargetControlID="txtMatricula" ValidChars="Ññ">
					    </cc1:FilteredTextBoxExtender>  
                </td>
            </tr>
                 <tr>
                  <td class="auto-style1">
                    CUA: 
                </td>
                 <td>
                   <asp:TextBox ID="txtCUA" runat="server" onkeyup="this.value=this.value.toUpperCase()" MaxLength="25" autofocus="autofocus"></asp:TextBox>
                     <cc1:FilteredTextBoxExtender ID="ftetxtCUA" 
							    runat="server" FilterType="Numbers"
							    TargetControlID="txtCUA" ValidChars="">
					    </cc1:FilteredTextBoxExtender>  
                </td>
                    <td>  &nbsp;&nbsp;&nbsp;</td>
                   <td>
                       <asp:Button ID="btnBuscar" runat="server" Text="BUSCAR" OnClick="btnBuscar_Click"/>
                       &nbsp;&nbsp;&nbsp;
                       <asp:Button ID="btnLimpiar" runat="server" Text="LIMPIAR" OnClick="btnLimpiar_Click" />
                       &nbsp;&nbsp;&nbsp;
                      </td>
                     <td>
                        <asp:Button ID="btnDp" runat="server" Text="VER CASOS DP SIN CONVENIOS" Height="24px" Width="254px"  OnClick="btnDp_Click" />
                   </td>
            </tr>
        </table>
    </div>

     <div style="border-color:black ">
        <asp:Label ID="Label1" runat="server" Text="Resultados de la búsqueda">Resultados de la búsqueda</asp:Label>

    <asp:GridView ID="gvBusqueda" runat="server" CellPadding="4" ForeColor="#333333" AutoGenerateColumns="False"  OnPageIndexChanging="gvBusqueda_PageIndexChanging" OnSelectedIndexChanged="gvBusqueda_SelectedIndexChanged" Visible="False" Font-Size="10pt" AllowPaging="true">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:BoundField DataField="Fila" HeaderText="Nro" />
                        <asp:BoundField DataField="NUP" HeaderText="NUP" />
                        <asp:BoundField DataField="CUA" HeaderText="CUA" />
                        <asp:BoundField DataField="Matricula" HeaderText="Matricula" />
                        <asp:BoundField DataField="NumeroDocumento" HeaderText="Nro Documento" />
                        <asp:BoundField DataField="PrimerApellido" HeaderText="Paterno" />
                        <asp:BoundField DataField="SegundoApellido" HeaderText="Materno" />
                        <asp:BoundField DataField="PrimerNombre" HeaderText="Primer Nombre" />
                        <asp:BoundField DataField="SegundoNombre" HeaderText="Segundo Nombre"/>
                    </Columns>
                    <EmptyDataTemplate>
                        <div align="center" class="CajaDialogoAdvertencia">
                        <br/>
                        <img src="../Imagenes/warning.gif" alt="No existen pagos que correspondan al criterio especificado" />
                        <br/>No existen datos que correspondan al criterio especificado<br/><br/>
                        </div>
                    </EmptyDataTemplate>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#0066CC" Font-Bold="True" ForeColor="#CCFFFF" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>

    </div>
    <br/>
   
     <div style="border-color:black; border-top-width: 10px; border-top-color: #CC0000">
         <asp:Label ID="lblTitulo2" runat="server" Text="Casos de Doble Percepcion Rehabilitados pero sin Convenios" Visible="false">Casos de Doble Percepcion Rehabilitados pero sin Convenios</asp:Label>
         <br />
            <asp:GridView ID="gvSinDP" runat="server" CellPadding="4" ForeColor="#333333" AutoGenerateColumns="False" Visible="False" Font-Size="10pt" AllowPaging="true"  OnPageIndexChanging="gvSinDP_PageIndexChanging">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField ="Fila" HeaderText="N°"></asp:BoundField>
                        <asp:BoundField DataField ="NUP" HeaderText="NUP"></asp:BoundField>
                        <asp:BoundField DataField ="CUA" HeaderText="CUA"></asp:BoundField>
                        <asp:BoundField DataField ="Matricula" HeaderText="MATRICULA"></asp:BoundField>
                        <asp:BoundField DataField ="DescripcionDetalleClasificador" HeaderText="DOCUMENTO"></asp:BoundField>
                        <asp:BoundField DataField ="NumeroDocumento" HeaderText="NRO DOCUMENTO"></asp:BoundField>
                        <asp:BoundField DataField ="PrimerApellido" HeaderText="1° APELLIDO"></asp:BoundField>
                        <asp:BoundField DataField ="SegundoApellido" HeaderText="2° APELLIDO"></asp:BoundField>
                        <asp:BoundField DataField ="PrimerNombre" HeaderText="1° NOMBRE"></asp:BoundField>
                        <asp:BoundField DataField ="SegundoNombre" HeaderText="2° NOMBRE"></asp:BoundField>
                        <asp:BoundField DataField ="ESTADO" HeaderText="ESTADO"></asp:BoundField>

                               </Columns>
                    <EmptyDataTemplate>
                        <div align="center" class="CajaDialogoAdvertencia">
                        <br/>
                        <img src="../Imagenes/warning.gif" alt="No existen pagos que correspondan al criterio especificado" />
                        <br/>No hay casos de Doble Percepcion sin registrar<br/><br/>
                        </div>
                    </EmptyDataTemplate>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#0066CC" Font-Bold="True" ForeColor="#CCFFFF" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>



                            <asp:Button ID="btnImprimir" runat="server" Text="IMPRIMIR"  Visible="false"/> &nbsp;&nbsp
                             <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            
                            <ContentTemplate>
                                   <asp:Button ID="btnexcel" runat="server" Text="EXPORTAR EXCEL" OnClick="Button2_Click" Visible="false" />
                            </ContentTemplate>

                            <Triggers>
                                <asp:PostBackTrigger ControlID="btnexcel" runat ="server" />
                            </Triggers>
                            </asp:UpdatePanel>
               </div>

        <div style="border-color:black; border-top-width: 10px; border-top-color: #CC0000;">

            <asp:GridView ID="gvSinDP2" runat="server" CellPadding="4" ForeColor="#333333" AutoGenerateColumns="False" Visible="False" Font-Size="10pt" >
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField ="Fila" HeaderText="N°"></asp:BoundField>
                        <asp:BoundField DataField ="NUP" HeaderText="NUP"></asp:BoundField>
                        <asp:BoundField DataField ="CUA" HeaderText="CUA"></asp:BoundField>
                        <asp:BoundField DataField ="Matricula" HeaderText="MATRICULA"></asp:BoundField>
                        <asp:BoundField DataField ="DescripcionDetalleClasificador" HeaderText="DOCUMENTO"></asp:BoundField>
                        <asp:BoundField DataField ="NumeroDocumento" HeaderText="NRO DOCUMENTO"></asp:BoundField>
                        <asp:BoundField DataField ="PrimerApellido" HeaderText="1° APELLIDO"></asp:BoundField>
                        <asp:BoundField DataField ="SegundoApellido" HeaderText="2° APELLIDO"></asp:BoundField>
                        <asp:BoundField DataField ="PrimerNombre" HeaderText="1° NOMBRE"></asp:BoundField>
                        <asp:BoundField DataField ="SegundoNombre" HeaderText="2° NOMBRE"></asp:BoundField>
                        <asp:BoundField DataField ="ESTADO" HeaderText="ESTADO"></asp:BoundField>

                               </Columns>
                    <EmptyDataTemplate>
                        <div align="center" class="CajaDialogoAdvertencia">
                        <br/>
                        <img src="../Imagenes/warning.gif" alt="No existen pagos que correspondan al criterio especificado" />
                        <br/>No hay casos de Doble Percepcion sin registrar<br/><br/>
                        </div>
                    </EmptyDataTemplate>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#0066CC" Font-Bold="True" ForeColor="#CCFFFF" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>

                
              </div>
        

                                            <!--HASTA AQUI -->

</asp:Content>

