<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmInformacion.aspx.cs" Inherits="Convenios_wfrmInformacion" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register assembly="System.Web, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="System.Web.UI" tagprefix="cc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%">
        <tr>
            <td width="100%" align="center">
                <asp:ImageButton ID="imgAux" runat="server" ImageUrl="~/Imagenes/pequeños/Favorites_32x32.png" />
                <asp:Label ID="lblTituloAUX" runat="server"
                    Text="Información de deuda" CssClass="etiqueta20" Font-Size="16pt"></asp:Label>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td width="40%" align="right" colspan="1">
                Primer Apellido: <asp:TextBox ID="txtPrimerApellido" runat="server" Width="150px" onkeyup="this.value=this.value.toUpperCase()" MaxLength="30"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" 
				runat="server" FilterType="Custom,LowercaseLetters,UppercaseLetters"
				TargetControlID="txtPrimerApellido" ValidChars="Ññ">
	            </cc1:FilteredTextBoxExtender>
            </td>
            <td width="40%" align="right" colspan="1">
                Segundo Apellido: <asp:TextBox ID="txtSegundoApellido" runat="server" Width="150px" onkeyup="this.value=this.value.toUpperCase()" MaxLength="30"></asp:TextBox>
               <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" 
				    runat="server" FilterType="Custom,LowercaseLetters,UppercaseLetters"
				    TargetControlID="txtSegundoApellido" ValidChars="ñÑ">
	                </cc1:FilteredTextBoxExtender>  
            </td>
            <td width="20%">

            </td>
        </tr>
        <tr>
            <td width="40%" align="right" colspan="1">
                Primer Nombre: <asp:TextBox ID="txtPrimerNombre" runat="server" Width="150px" onkeyup="this.value=this.value.toUpperCase()" MaxLength="30"></asp:TextBox>
                 <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" 
				    runat="server" FilterType="Custom,LowercaseLetters,UppercaseLetters"
				    TargetControlID="txtPrimerNombre" ValidChars="Ññ">
	                </cc1:FilteredTextBoxExtender> 
            </td>
            <td width="40%" align="right" colspan="1">
                Segundo Nombre: <asp:TextBox ID="txtSegundoNombre" runat="server" Width="150px" onkeyup="this.value=this.value.toUpperCase()" MaxLength="30"></asp:TextBox>
                 <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" 
				    runat="server" FilterType="Custom,LowercaseLetters,UppercaseLetters"
				    TargetControlID="txtSegundoNombre" ValidChars="Ññ">
	                </cc1:FilteredTextBoxExtender> 
            </td>
            <td width="20%">

            </td>
        </tr>
        <tr>
            <td width="40%" align="right" colspan="1">
                Documento de Identidad: <asp:TextBox ID="txtCI" runat="server" Width="150px" MaxLength="15"></asp:TextBox>
                 <cc1:FilteredTextBoxExtender ID="ftbtxtCI" 
							    runat="server" FilterType="Numbers"
							    TargetControlID="txtCI" ValidChars="">
					    </cc1:FilteredTextBoxExtender>
            </td>
            <td width="40%" align="right" colspan="1">
                Matrícula: <asp:TextBox ID="txtMatricula" runat="server" Width="150px" onkeyup="this.value=this.value.toUpperCase()" MaxLength="15"></asp:TextBox>
                 <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" 
							    runat="server" FilterType="Custom,UppercaseLetters,LowercaseLetters,Numbers"
							    TargetControlID="txtMatricula" ValidChars="Ññ">
					    </cc1:FilteredTextBoxExtender>
            </td>
            <td width="20%">

            </td>
        </tr>
        <tr>
            <td width="40%" align="right" colspan="1">
                CUA: <asp:TextBox ID="txtCUA" runat="server" Width="150px" MaxLength="15"></asp:TextBox>
                     <cc1:FilteredTextBoxExtender ID="ftetxtCUA" 
							    runat="server" FilterType="Numbers"
							    TargetControlID="txtCUA" ValidChars="">
					    </cc1:FilteredTextBoxExtender>
            </td>
            <td width="40%" align="right">
                NUP: <asp:TextBox ID="txtNUP" runat="server" Width="150px" onkeyup="this.value=this.value.toUpperCase()" ReadOnly="false" MaxLength="15"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="ftbtxtNUP" 
							    runat="server" FilterType="Numbers"
							    TargetControlID="txtNUP" ValidChars="">
					    </cc1:FilteredTextBoxExtender>
            </td>
            <td width="20%">

            </td>
        </tr>
        <tr>
            <td width="40%" align="right" colspan="1">
                Fecha Nacimiento: <asp:TextBox ID="txtFechaNacimiento" runat="server" Width="150px" ReadOnly="True"></asp:TextBox>
                <cc1:textboxwatermarkextender id="txtFechaNacimiento_TextBoxWatermarkExtender" watermarktext="Solo lectura" watermarkcssclass="MarcaAgua" runat="server" enabled="True" targetcontrolid="txtFechaNacimiento">                          
                                    </cc1:textboxwatermarkextender>
            </td>
            <td width="40%" align="right" colspan="1">
                Fecha Fallecimiento: <asp:TextBox ID="txtFechaFallecimiento" runat="server" Width="150px" onkeyup="this.value=this.value.toUpperCase()" ReadOnly="True"></asp:TextBox>
                <cc1:textboxwatermarkextender id="txtFechaFallecimiento_Textboxwatermarkextender" watermarktext="Solo lectura" watermarkcssclass="MarcaAgua" runat="server" enabled="True" targetcontrolid="txtFechaFallecimiento">                          
                                    </cc1:textboxwatermarkextender>
            </td>
            <td width="20%">

            </td>
        </tr>
        <tr>
            <td width="40%" align="right" colspan="1">
                Sexo: <asp:TextBox ID="txtSexo" runat="server" Width="150px" ReadOnly="True"></asp:TextBox>
                      <cc1:textboxwatermarkextender id="txtSexo_Textboxwatermarkextender" watermarktext="Solo lectura" watermarkcssclass="MarcaAgua" runat="server" enabled="True" targetcontrolid="txtSexo">                          
                                    </cc1:textboxwatermarkextender>
            </td>
            <td width="40%" align="right" colspan="1">
                Estado Civil: <asp:TextBox ID="txtEstadoCivil" runat="server" Width="150px" onkeyup="this.value=this.value.toUpperCase()" ReadOnly="True"></asp:TextBox>
                <cc1:textboxwatermarkextender id="txtEstadoCivil_Textboxwatermarkextender" watermarktext="Solo lectura" watermarkcssclass="MarcaAgua" runat="server" enabled="True" targetcontrolid="txtEstadoCivil">                          
                                    </cc1:textboxwatermarkextender>    
            </td>
            <td width="20%">

            </td>
        </tr>
        <tr>
            <td width="40%" align="right" colspan="1">
                Dirección actual: <asp:TextBox ID="txtDireccion" runat="server" Width="150px" onkeyup="this.value=this.value.toUpperCase()" MaxLength="150" ReadOnly="true"></asp:TextBox>
                <cc1:textboxwatermarkextender id="txtDireccion_Textboxwatermarkextender" watermarktext="Solo lectura" watermarkcssclass="MarcaAgua" runat="server" enabled="True" targetcontrolid="txtDireccion">                          
                                    </cc1:textboxwatermarkextender>    
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender23" 
				runat="server" FilterType="Custom,LowercaseLetters,UppercaseLetters,Numbers"
				TargetControlID="txtDireccion" ValidChars="#/.-,() ">
				</cc1:FilteredTextBoxExtender>
                 
            </td>
             <td width="40%" align="right" colspan="1">
                Celular: <asp:TextBox ID="txtCel" runat="server" Width="115px" MaxLength="8" ReadOnly="true"></asp:TextBox>
                <cc1:textboxwatermarkextender id="txtCel_Textboxwatermarkextender" watermarktext="Solo lectura" watermarkcssclass="MarcaAgua" runat="server" enabled="True" targetcontrolid="txtCel">                          
                                    </cc1:textboxwatermarkextender> 
                  <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender20" 
							runat="server" FilterType="Numbers"
							TargetControlID="txtCel" ValidChars="">
				</cc1:FilteredTextBoxExtender>  
                Celular-Referencial: <asp:TextBox ID="txtCelReferencial" runat="server" Width="115px" MaxLength="8" ReadOnly="true" ></asp:TextBox>
                                <cc1:textboxwatermarkextender id="txtCelReferencial_Textboxwatermarkextender" watermarktext="Solo lectura" watermarkcssclass="MarcaAgua" runat="server" enabled="True" targetcontrolid="txtCelReferencial">                          
                                    </cc1:textboxwatermarkextender> 
                 <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender21" 
				runat="server" FilterType="Numbers"
				TargetControlID="txtCelReferencial" ValidChars="">
				</cc1:FilteredTextBoxExtender>  
            </td>
            <td width="40%" align="right" colspan="1">
             Telefono: <asp:TextBox ID="txtTelefono" runat="server" Width="150px" MaxLength="8" ReadOnly="true"></asp:TextBox>
                <cc1:textboxwatermarkextender id="txtTelefono_Textboxwatermarkextender" watermarktext="Solo lectura" watermarkcssclass="MarcaAgua" runat="server" enabled="True" targetcontrolid="txtTelefono">                          
                                    </cc1:textboxwatermarkextender> 
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender22" 
				runat="server" FilterType="Numbers"
				TargetControlID="txtTelefono" ValidChars="">
				</cc1:FilteredTextBoxExtender>  
            </td>
        </tr>
        <tr>    
            <td width="40%" align="center" colspan="2">
                <asp:Button ID="cmdBuscar" runat="server" Text="Buscar" Width="100px" OnClick="cmdBuscar_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="cmdLimpiar" runat="server" Text="Limpiar" Width="100px" OnClick="cmdLimpiar_Click" />
            </td>
            <td width="20%">

            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td width="100%" align="left">
                <asp:Label ID="lblBusqueda" runat="server" Text="Resultados de la busqueda..."></asp:Label>
            </td>
        </tr>
         <tr>
            <td width="100%" align="center">

                <asp:GridView ID="gvBusqueda" runat="server" CellPadding="4" ForeColor="#333333" AutoGenerateColumns="False" DataKeyNames="Fila,EstadoCivil,Direccion,FechaNacimiento,FechaFallecimiento,Sexo,Celular,CelularReferencia,Telefono" DataSourceID="odsBuscaPersona" OnSelectedIndexChanged="gvBusqueda_SelectedIndexChanged" Visible="False" Font-Size="10pt">
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
                        <asp:BoundField DataField="SegundoNombre" HeaderText="Segundo Nombre" />
                        <asp:BoundField DataField="Beneficio" HeaderText="Beneficio" />
                        <asp:BoundField DataField="EstadoCivil" HeaderText="Estado Civil" Visible="False" />
                        <asp:BoundField DataField="Direccion" HeaderText="Direccion" Visible="False" />
                        <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha Nacimiento" Visible="False" />
                        <asp:BoundField DataField="FechaFallecimiento" HeaderText="Fecha Fallecimiento" Visible="False" />
                        <asp:BoundField DataField="Sexo" HeaderText="Sexo" Visible="False" />
                        <asp:BoundField DataField="Celular" HeaderText="Celular" Visible="False" />
                        <asp:BoundField DataField="CelularReferencia" HeaderText="CelularReferencia" Visible="False" />
                        <asp:BoundField DataField="Telefono" HeaderText="Telefono" Visible="False" />
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

                <asp:ObjectDataSource ID="odsBuscaPersona" runat="server" SelectMethod="ObtieneDatos" TypeName="wcfConvenios.Logica.clsInformacion" OldValuesParameterFormatString="original_{0}">
                    <SelectParameters>
                        <asp:Parameter Name="iIdConexion" Type="Int32" />
                        <asp:Parameter Name="cOperacion" Type="String" />
                        <asp:Parameter DefaultValue="VACIO" Name="Tipo" Type="String" />
                        <asp:Parameter Name="Paterno" Type="String" />
                        <asp:Parameter Name="Materno" Type="String" />
                        <asp:Parameter Name="Nombre1" Type="String" />
                        <asp:Parameter Name="Nombre2" Type="String" />
                        <asp:Parameter Name="NumeroDocumento" Type="String" />
                        <asp:Parameter Name="Matricula" Type="String" />
                        <asp:Parameter DefaultValue="" Name="CUA" Type="String" />
                        <asp:Parameter Name="NUP" Type="Int64" />
                        <asp:Parameter Direction="InputOutput" Name="sMensajeError" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>

            </td>
        </tr>
        <tr>
            <td width="100%" align="left">
                <asp:Label ID="lblBeneficios" runat="server" Text="Beneficios Otorgados..." Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td width="100%" align="center">

                <asp:GridView ID="gvBeneficios" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Size="9pt" ForeColor="#333333" OnRowCommand="gvBeneficios_RowCommand" OnDataBound="gvBeneficios_DataBound" Visible="False">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="NumeroCertificado" HeaderText="Certificado" />
                        <asp:BoundField DataField="Regional" HeaderText="Regional" />
                        <asp:BoundField DataField="Entidad" HeaderText="Entidad" />
                        <asp:BoundField DataField="Sector" HeaderText="Sector" />
                        <asp:BoundField DataField="Beneficio" HeaderText="Grupo Beneficio" />
                        <asp:BoundField DataField="TipoCC" HeaderText="Tipo CC" />
                        <asp:BoundField DataField="FechaSolicitud" HeaderText="Fecha Solicitud" />
                        <asp:BoundField DataField="MontoAjustado" HeaderText="Monto CC (Bs.)" />
                        <asp:BoundField DataField="PeriodoInicio" HeaderText="Periodo Inicio" />
                        <asp:BoundField DataField="Planilla" HeaderText="Planilla" />
                        <asp:BoundField DataField="Estado" HeaderText="Estado" />
                        <asp:ButtonField CommandName="cmdInformacion" Text="Ver Información" />
                        <asp:ButtonField CommandName="cmdDeuda" Text="Ver Deuda" />
                    </Columns>
                    <EmptyDataTemplate>
                        <div align="center" class="CajaDialogoAdvertencia">
                        <br/>
                        <img src="../Imagenes/warning.gif" alt="No existen Beneficios Registrados para la persona" />
                        <br/>No existen Beneficios Registrados para la persona<br/><br/>
                        </div>
                    </EmptyDataTemplate>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>

            </td>
        </tr>
        <tr>
            <td width="100%" align="left" class="auto-style5">
            <asp:LinkButton ID="lnkPagos" runat="server" OnClick="LinkButton1_Click" Font-Bold="True" ForeColor="#0066CC" Visible="False">Pagos...</asp:LinkButton>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="lnkConciliaciones" runat="server" OnClick="LinkButton2_Click" Font-Bold="True" ForeColor="#0066CC" Visible="False">Conciliaciones...</asp:LinkButton>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="lnkGrupoFamiliar" runat="server" OnClick="lnkReposiciones_Click" Font-Bold="True" ForeColor="#0066CC" Visible="False">Grupo Familiar...</asp:LinkButton>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="lnkReposiciones" runat="server" OnClick="lnkReposiciones_Click1" Font-Bold="True" ForeColor="#0066CC" Visible="False">Reposiciones...</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td width="100%" align="center" >
               <div style ="width:1000px; overflow:auto;">
                <asp:MultiView ID="MultiView1" runat="server" Visible="False">
                    <asp:View ID="Pagos" runat="server">

                        <asp:Label ID="lblPagos" runat="server" Text="Historial de Pagos" Font-Underline="True" Font-Size="14pt" ForeColor="#0066CC"></asp:Label>
                  
                        <asp:GridView ID="gvPagos" runat="server" AllowPaging="True" CellPadding="4" ForeColor="#333333" Font-Size="10pt" OnPageIndexChanging="gvPagos_PageIndexChanging">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <EmptyDataTemplate>
                                <div align="center" class="CajaDialogoAdvertencia">
                                <br/>
                                <img src="../Imagenes/warning.gif" alt="El asegurado no cuenta con registros de Pagos" />
                                <br/>El asegurado no cuenta con registros de Pagos<br/><br/>
                                </div>
                            </EmptyDataTemplate>
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView>
                  		<asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:Button ID="btnReporte" runat="server" Text="GenerarReporte" OnClick="btnReporte_Click"/>
                            <asp:RadioButton id="Resumido" Text="Resumido" Checked="True" GroupName="TipoReporte" runat="server"/>
                            <asp:RadioButton id="Completo" Text="Completo"  GroupName="TipoReporte" runat="server"/>
                        </ContentTemplate>
                        <Triggers>
                                <asp:PostBackTrigger ControlID="btnReporte" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </asp:View>
                    <asp:View ID="Conicliaciones" runat="server"  >

                        <asp:Label ID="lblConciliacion" runat="server" Text="Historial de Conciliaciones" Font-Underline="True" Font-Size="14pt" ForeColor="#0066CC"></asp:Label>
                        <div style="overflow-x:scroll; " Width="1150px">
                        <asp:GridView ID="gvConciliaciones" runat="server" AllowPaging="True" CellPadding="4" ForeColor="#333333" Font-Size="10pt" OnPageIndexChanging="gvConciliaciones_PageIndexChanging" >
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <EmptyDataTemplate>
                                <div align="center" class="CajaDialogoAdvertencia">
                                <br/>
                                <img src="../Imagenes/warning.gif" alt="El asegurado no cuenta con registros de Conciliaciones" />
                                <br/>El asegurado no cuenta con registros de Conciliaciones<br/><br/>
                                </div>
                            </EmptyDataTemplate>
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView>
                     </div>
                    </asp:View>
                    <asp:View ID="Reposiciones" runat="server">

                        <asp:Label ID="lblReposicion" runat="server" Text="Grupo Familiar" Font-Underline="True" Font-Size="14pt" ForeColor="#0066CC"></asp:Label>

                        <asp:GridView ID="gvGrupo" runat="server" CellPadding="4" ForeColor="#333333" AutoGenerateColumns="False" Font-Size="10pt">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:BoundField DataField="Fila" HeaderText="Nro." />
                                <asp:BoundField DataField="NumeroDocumento" HeaderText="Nro. Documento" />
                                <asp:BoundField DataField="PrimerApellido" HeaderText="1er Apellido" />
                                <asp:BoundField DataField="SegundoApellido" HeaderText="2do Apellido" />
                                <asp:BoundField DataField="PrimerNombre" HeaderText="1er Nombre" />
                                <asp:BoundField DataField="SegundoNombre" HeaderText="2do Nombre" />
                                <asp:BoundField DataField="Sexo" HeaderText="Sexo" />
                                <asp:BoundField DataField="Parentesco" HeaderText="Parentesco" />
                                <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha Nacimiento" />
                                <asp:BoundField DataField="FechaFallecimiento" HeaderText="Fecha Fallecimiento" />
                                <asp:BoundField DataField="EstadoDH" HeaderText="Estado DH" />
                                <asp:BoundField DataField="Invalides" HeaderText="Invalides" />
                            </Columns>
                            <EmptyDataTemplate>
                                <div align="center" class="CajaDialogoAdvertencia">
                                <br/>
                                <img src="../Imagenes/warning.gif" alt="El asegurado no cuenta con derechohabientes" />
                                <br/>El asegurado no cuenta con derechohabientes<br/><br/>
                                </div>
                            </EmptyDataTemplate>
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView>

                    </asp:View>

                  <asp:View ID="Repo" runat="server">

                        <asp:Label ID="Label1" runat="server" Text="Reposiciones" Font-Underline="True" Font-Size="14pt" ForeColor="#0066CC"></asp:Label>

                        <asp:GridView ID="gvReposiciones" runat="server" AllowPaging="True" CellPadding="4" ForeColor="#333333" Font-Size="10pt" OnPageIndexChanging="gvReposiciones_PageIndexChanging">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <EmptyDataTemplate>
                                <div align="center" class="CajaDialogoAdvertencia">
                                <br/>
                                <img src="../Imagenes/warning.gif" alt="El asegurado no cuenta con registros de Reposiciones" />
                                <br/>El asegurado no cuenta con registros de Reposiciones<br/><br/>
                                </div>
                            </EmptyDataTemplate>
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView>

                    </asp:View>

                </asp:MultiView>
                </div>
            </td>
        </tr>
        <tr>
            <td>
            <div aligin="center">
            <asp:Panel ID="panReporte" runat="server" CssClass="panelceleste"  HorizontalAlign="Center" style="overflow-y:scroll;" Height="550px" Width="1100px" Visible="false">
            <rsweb:ReportViewer ID="rtpInforme" runat="server"  Height="550px" Width="1100px" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Visible="false">
            </rsweb:ReportViewer>
            </asp:Panel>
        </div>
            </td>
        </tr>
    </table>
</asp:Content>

