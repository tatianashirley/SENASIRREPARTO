<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmCargarInformacionAsegurado.aspx.cs" Inherits="DoblePercepcion_wfrmCargarInformacionAsegurado" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1"%>
<%@ Register assembly="System.Web, Version=4.0.0.0, Culture= neutral , PublicKeyToken=b03f5f7f11d50a3a" namespace="System.Web.UI" tagprefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript" language="javascript">
               function BloquearSuspension() {
            
            if (document.getElementById('<%=txtPerioRehabilitacionM.ClientID%>').value != "") {
                  document.getElementById('<%=txtNroReferenciaRehabilitacionM.ClientID%>').disabled = false;
                document.getElementById('<%=txaObservacionRehabilitacion.ClientID%>').disabled = false;
            }
            else {
                document.getElementById('<%=txtNroReferenciaRehabilitacionM.ClientID%>').value = '';
                document.getElementById('<%=txaObservacionRehabilitacion.ClientID%>').value = '';
                document.getElementById('<%=txtNroReferenciaRehabilitacionM.ClientID%>').disabled = true;
                document.getElementById('<%=txaObservacionRehabilitacion.ClientID%>').disabled = true;
            }
        }
        function textboxMultilineMaxLength(txt, maxLen) {
            try {
                if (txt.value.length > (maxLen - 1)) return false;
            } catch (e) {
                alert(e.GetText());
            }
        }
        function Actualizar(IdElemento) {
            var fin = IdElemento.lastIndexOf('.')
            if (IdElemento.substring(3, fin) == 'txtFechaRehabilitacion')
            {

                var txtFechaSuspencion = document.getElementById('<%=txtFechaSuspencion.ClientID%>').value//.replace(",", ".");
                var txtFechaRehabilitacion = document.getElementById('<%=txtFechaRehabilitacion.ClientID%>').value//.replace(",", ".");
                if ((txtFechaRehabilitacion.substring(0, 4) - txtFechaSuspencion.substring(0, 4)) >= 3) {
                    alert('LA FECHA DE REHABILITACIÓN ES 3 AÑOS MAYOR A LA DE SUSPENSION!!!!!!!!!!!!!!!!!!!!!!');
                }
              }
        }
        </script>

    <style type="text/css">
        .auto-style5 {
            text-decoration: underline;
        }
        .panelceleste {}
        .auto-style10 {
            height: 35px;
            width: 71px;
        }
        .auto-style11 {
            width: 375px;
            height: 35px;
        }
        .auto-style12 {
            width: 375px;
        }
        .auto-style13 {
            width: 170px;
        }
        .auto-style14 {
            width: 255px;
        }
        .auto-style17 {
            width: 300px;
        }
        .auto-style18 {
            width: 102px;
        }
        .auto-style19 {
            width: 265px;
        }
        .auto-style22 {
            width: 71px;
        }
        .auto-style23 {
            width: 72px;
        }
        .auto-style24 {
            width: 98px;
        }
        .auto-style25 {
            width: 97px;
        }
        .auto-style27 {
            width: 90px;
        }
        .auto-style28 {
            width: 218px;
        }
        .auto-style29 {
            width: 95px;
        }
        .boton150 {}
        .auto-style32 {
            width: 159px;
        }
        .auto-style34 {
            width: 79px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<!--DESDE AQUI SE PUDE PERSONALIZAR-->
	 
	<div>
		      <asp:Label ID="lblTituloAUX" runat="server"
              Text="Datos Personas del Titular" CssClass="etiqueta20" Font-Size="16pt"></asp:Label>

			<table>
			<TR>
				<td> NUP: 
				</td>
				<td>
					<asp:TextBox ID="txtNup" runat="server" ReadOnly="true"></asp:TextBox>
			   </td>
			   <td>
				   CUA: 
				</td>
				<td>
					<asp:TextBox ID="txtCUA" runat="server" ReadOnly="true"></asp:TextBox>
			   </td>
				<td>
					Matricula: 
				</td>
			  <td>
					<asp:TextBox ID="txtMatricula" runat="server" ReadOnly="true"></asp:TextBox>
			   </td>
			</TR>
			<TR>
				<td>
					Documento: 
				</td>
				<td>
					<asp:TextBox ID="txtDocumento" runat="server" ReadOnly="true"></asp:TextBox>
			   </td>
			   <td>
				   Número Documento: 
				</td>
				<td>
					<asp:TextBox ID="txtNroDocumento" runat="server" ReadOnly="true"></asp:TextBox>
			   </td>
				<td>
					Expedido en: 
				</td>
			  <td>
					<asp:TextBox ID="txtExpedido" runat="server" ReadOnly="true"></asp:TextBox>
			   </td>
			</TR>

		   <TR>
				<td>
					Primer Apellido: 
				</td>
				<td>
					<asp:TextBox ID="txtPrimerApellido" runat="server" ReadOnly="true"></asp:TextBox>
			   </td>
			   <td>
				   Primer Nombre: 
				</td>
				<td>
					<asp:TextBox ID="txtPrimerNombre" runat="server" ReadOnly="true"></asp:TextBox>
			   </td>
				<td>
				   Fecha Nacimiento: 
				</td>
			  <td>
					<asp:TextBox ID="txtFechaNacimiento" runat="server" type="text" ReadOnly="true"></asp:TextBox>
			   </td>
			</TR>
		   
			 <TR>
				<td>
					Segundo Apellido: 
				</td>
				<td>
					<asp:TextBox ID="txtSegundoApellido" runat="server" ReadOnly="true"></asp:TextBox>
			   </td>
			   <td>
				   Segundo Nombre: 
				</td>
				<td>
					<asp:TextBox ID="txtSegundoNombre" runat="server" ReadOnly="true"></asp:TextBox>
			   </td>
				<td>
				   Sexo: 
				</td>
			  <td>
					<asp:TextBox ID="txtSexo" runat="server" ReadOnly="true"></asp:TextBox>
			   </td>
			</TR>
		<TR>
				<td>
				   Estado Civil: 
				</td>
				<td>
					<asp:TextBox ID="txtEstadoCivil" runat="server" ReadOnly="true" ></asp:TextBox>
			   </td>
			   <td>
				   Direccion Actual: 
				</td>
				<td>
					<asp:TextBox ID="txtDireccionActual" runat="server" ReadOnly="true"></asp:TextBox>
			   </td>
				<td>
				   Fecha Fallecido: 
				</td>
			  <td>
					<asp:TextBox ID="txtFechaFallecimiento" runat="server" type="text" ReadOnly="true" Height="22px" ></asp:TextBox>
			   </td>
			 </TR>
			 <tr>
				 <td> </td>
				 <td> </td>
				 <td> </td>
				 <td></td>
					   
				 <td> <asp:Button ID="btnLimpiar" runat="server" Text="LIMPIAR" OnClick="btnLimpiar_Click" /></td>
				 <td>
				   <asp:LinkButton ID="lnkSuspencionPreventiva" runat="server" Visible="false" OnClick="lnkSuspencionPreventiva_Click">Suspension Preventiva</asp:LinkButton>
				 </td>
			 </tr>
		</table>

	</div>
	   
		 <div>
             <asp:Label ID="lblBeneficios" runat="server"
              Text="Beneficios Otorgados..." CssClass="etiqueta20" Font-Size="16pt"></asp:Label>

				 <asp:GridView ID="gvBeneficios" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Size="8pt" ForeColor="#333333"  Visible="False" OnRowCommand="gvBeneficios_RowCommand" DataKeyNames="IdEstadoBeneficio,IdBeneficio,NumeroCertificado">
					<AlternatingRowStyle BackColor="White" ForeColor="#284775" />
					<Columns>
							<asp:BoundField DataField="NumeroCertificado" HeaderText="N° CERTIFICADO"></asp:BoundField>
							<asp:BoundField DataField="Beneficio" HeaderText="GRUPO BENEFICIO"></asp:BoundField>
							<asp:BoundField DataField="TipoCC" HeaderText="TIPO CC"></asp:BoundField>
							<asp:BoundField DataField="FechaSolicitud" HeaderText="FECHA SOLICITUD"></asp:BoundField>
							<asp:BoundField DataField="MontoAjustado" HeaderText="MONTO CC EN BS."></asp:BoundField>
							<asp:BoundField DataField="PeriodoInicio" HeaderText="PERIODO INICIO"></asp:BoundField>
							<asp:BoundField DataField="Planilla" HeaderText="PLANILLA"></asp:BoundField>
							<asp:BoundField DataField="Estado" HeaderText="ESTADO BENEFICIO"></asp:BoundField>
							<asp:BoundField DataField="IdEstadoBeneficio" HeaderText="IdEstadoBenefisio" Visible="false"></asp:BoundField>
							<asp:ButtonField CommandName="cmdModificar" Text="Modificar" />
							<asp:ButtonField CommandName="cmdDetalle" Text="Detalle" />
                            <asp:BoundField DataField="IdBeneficio" HeaderText="IdBeneficio" Visible="false"></asp:BoundField>
                            <asp:BoundField DataField="IdTipoBeneficiario" HeaderText="Tipo" Visible="True"></asp:BoundField>
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
		</div>
    <br />
    <asp:Panel ID="Panel1" runat="server" style="overflow-x:scroll; " Width="1150px">
    <divss>
     <asp:Label ID="lblConvenios" runat="server"
              Text="Convenios de la Persona" CssClass="etiqueta20" Font-Size="16pt" Visible="false"></asp:Label>
            <asp:GridView ID="gvConvenios" runat="server" CellPadding="4" ForeColor="#333333" Font-Size="10pt" Visible="false">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <EmptyDataTemplate>
                <div align="center" class="CajaDialogoAdvertencia">
                <br/>
                <img src="../Imagenes/warning.gif" alt="El asegurado no cuenta con registros de Convenios" />
                <br/>El asegurado no cuenta con registros de Convenios<br/><br/>
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
         </divss>
        </asp:Panel>
   <br />
    		 <div>
            <asp:Label ID="lbTituloDH" runat="server"
              Text="Derecho Habientes del Titular" CssClass="etiqueta20" Font-Size="16pt" Visible="false"></asp:Label>

				 <asp:GridView ID="gvDH" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Size="8pt" ForeColor="#333333"  Visible="False" OnRowCommand="gvDH_RowCommand">
					<AlternatingRowStyle BackColor="White" ForeColor="#284775" />
					<Columns>
							<asp:BoundField DataField="CUA" HeaderText="CUA"></asp:BoundField>
							<asp:BoundField DataField="NUP" HeaderText="NUP TITULAR"></asp:BoundField>
							<asp:BoundField DataField="NUPDH" HeaderText="NUP DH"></asp:BoundField>
							<asp:BoundField DataField="PrimerApellido" HeaderText="PRIMER APELLIDO"></asp:BoundField>
							<asp:BoundField DataField="SegundoApellido" HeaderText="SEGUNDO APELLIDO"></asp:BoundField>
							<asp:BoundField DataField="Nombres" HeaderText="NOMBRES"></asp:BoundField>
							<asp:BoundField DataField="Parentesco" HeaderText="PARENTESCO"></asp:BoundField>
							<asp:BoundField DataField="NumeroDocumento" HeaderText="NUMERO DOCUMENTO"></asp:BoundField>
                            <asp:BoundField DataField="DescripcionDetalleClasificador" HeaderText="ESTADO BENEFICIO"></asp:BoundField>
							<asp:ButtonField CommandName="cmdDetalle" Text="Ver Detalle"/>
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
		</div>


	   <div>
		   <asp:Panel ID="panPagos" runat="server" Visible="true" >
		   <table>
			   <tr>
				   <td colspan ="2">
                   <asp:Label ID="Label34" runat="server"
                    Text="Pagos y Conciliacion" CssClass="etiqueta20" Font-Size="16pt"></asp:Label>
						
				   </td>
			   </tr>
			  <tr>
				  <td>Entrada</td>
				  <td><asp:TextBox ID="txtRangoEPC" runat="server" MaxLength ="10"></asp:TextBox> 
					  <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender21" 
					runat="server" FilterType="Custom,Numbers"
					TargetControlID="txtRangoEPC" ValidChars="/">
					    </cc1:FilteredTextBoxExtender>
				  </td>
				  <td>
					  <asp:Image ID="Image3" runat="server" Height="25px" ImageUrl="~/Imagenes/32calendario.png" Width="25px" ImageAlign="Top" Style="cursor:pointer"/>
                      	<cc1:CalendarExtender ID="CalendarExtender20" runat="server" TargetControlID="txtRangoEPC" PopupButtonID="Image3"
						Format="dd/MM/yyyy" Enabled="True" CssClass="cal_Theme1"></cc1:CalendarExtender>
				  <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtRangoEPC" ID="RegularExpressionValidator19" ValidationExpression = "^\d{1,2}\/\d{1,2}\/\d{2,4}$" runat="server" ErrorMessage="Formato de Fecha Incorrecta"></asp:RegularExpressionValidator>
				  </td>
				  <td>Salida</td>
				  <td> <asp:TextBox ID="txtRangoSPC" runat="server" MaxLength="10"></asp:TextBox>
				 <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender20" 
					runat="server" FilterType="Custom,Numbers"
					TargetControlID="txtRangoSPC" ValidChars="/">
					    </cc1:FilteredTextBoxExtender>  

				  </td>
				  <td><asp:Image ID="Image4" runat="server" Height="25px" ImageUrl="~/Imagenes/32calendario.png" Width="25px" ImageAlign="Top" Style="cursor:pointer"/>
                      <cc1:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtRangoSPC" PopupButtonID="Image4"
						Format="dd/MM/yyyy" Enabled="True" CssClass="cal_Theme1"></cc1:CalendarExtender>

					  <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtRangoSPC" ID="RegularExpressionValidator20" ValidationExpression = "^\d{1,2}\/\d{1,2}\/\d{2,4}$" runat="server" ErrorMessage="Formato de Fecha Incorrecta"></asp:RegularExpressionValidator>
				  </td>

			  </tr>
		   </table>
		
           
         <asp:Button ID="btnPC" runat="server" Text="Aceptar" OnClick="btnPC_Click"/> 
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
           </asp:Panel>
		   
												   
	<!-- aqui comienza el primer TabContainer-->            
		</div>
		   
<!-- DESDE AQUIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII-->        
	<table>
		              
        <tr>
			<td>
				<div>

					<cc1:TabContainer ID="tcDetalle" runat="server" ActiveTabIndex="1">
					<cc1:TabPanel ID="tbpnlDepositos" runat="server">
					<HeaderTemplate>
					PAGOS
					</HeaderTemplate>
					<ContentTemplate>
					<asp:Panel ID="panDepositos" runat="server" style="overflow-x:scroll; " Width="1150px">
				  
					<asp:GridView ID="gvPagos" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Size="9pt" ForeColor="#333333"  Visible="False"  AllowPaging="true"  OnPageIndexChanging="gvPagos_PageIndexChanging">
					<AlternatingRowStyle BackColor="White" ForeColor="#284775" />

					<Columns>
								<asp:BoundField DataField="CorrelativoPlanillaCC" HeaderText="N°"></asp:BoundField>
								<asp:BoundField DataField="PeriodoSolicitud" HeaderText="PERIODO"></asp:BoundField>
								<asp:BoundField DataField="CodigoPlanilla" HeaderText="PLANILLA"></asp:BoundField>
								<asp:BoundField DataField="CodigoTransaccion" HeaderText="COD TRANS"></asp:BoundField>
								<asp:BoundField HeaderText="TRANSACCION"></asp:BoundField>
								<asp:BoundField DataField="Monto" HeaderText="MONTO BS."></asp:BoundField>
								<asp:BoundField DataField="FechaInicio" HeaderText="FECHA INI"></asp:BoundField>
								<asp:BoundField DataField="FechaFin" HeaderText="FECHA FIN"></asp:BoundField>
								<asp:BoundField DataField="Regional" HeaderText="REGIONAL"></asp:BoundField>
					</Columns>

					<EmptyDataTemplate>
						<div align="center" class="CajaDialogoAdvertencia">
						<br/>
						<img src="../Imagenes/warning.gif" alt="No existen PAGOS Registrados para la persona" />
						<br/>No existen PAGOS Registrados para la persona<br/><br/>
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
						
	   <!--    -------------------------------------------------------------------------------------                         -->                  


					</asp:Panel>
					</ContentTemplate>

					</cc1:TabPanel>
					<cc1:TabPanel ID="tbpnlHistRecup" runat="server" >
					<HeaderTemplate>
						CONCILIACION PAGO CC
					</HeaderTemplate>
					<ContentTemplate>

					<asp:Panel ID="panHistRecup" runat="server" style="overflow-x:scroll; " Width="1150px" >
				   

				  <asp:GridView ID="gvConciliacion" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Size="9pt" ForeColor="#333333"  Visible="False"  AllowPaging="true" OnPageIndexChanging="gvConciliacion_PageIndexChanging">
					<AlternatingRowStyle BackColor="White" ForeColor="#284775" />

					<Columns>
								<asp:BoundField DataField="Entidad" HeaderText="ENTIDAD"></asp:BoundField>
								<asp:BoundField DataField="PLanilla" HeaderText="PLANILLA"></asp:BoundField>
								<asp:BoundField DataField="NUP" HeaderText="NUP" Visible="false"></asp:BoundField>
								<asp:BoundField DataField="CUA" HeaderText="CUA" Visible="false"></asp:BoundField>
								<asp:BoundField DataField="NumeroDocumento" HeaderText="NUMERO DE DOCUMENTO" Visible="false"></asp:BoundField>
								<asp:BoundField DataField="CorrelativoPlanillaCC" HeaderText="CORRELATIVO PLANILLA CC" Visible="false"></asp:BoundField>
								<asp:BoundField DataField="PeriodoSolicitud" HeaderText="PERIODO SOLICITUD"></asp:BoundField>
								<asp:BoundField DataField="FechaInicio" HeaderText="FECHA INICIO"></asp:BoundField>
								<asp:BoundField DataField="FechaPago" HeaderText="FECHA PAGO"></asp:BoundField>
								<asp:BoundField DataField="IdCodigoRegional" HeaderText="CODIGO REGIONAL"></asp:BoundField>
								<asp:BoundField DataField="NumeroCheque" HeaderText="NRO. CHEQUE"></asp:BoundField>
								<asp:BoundField DataField="MontoSolicitado" HeaderText="MONTO SOLICITADO"></asp:BoundField>
								<asp:BoundField DataField="MontoDescuentoConvenio" HeaderText="MONTO DESCUENTO CONVENIO"></asp:BoundField>
								<asp:BoundField DataField="MontoDesembolsadoEntidad" HeaderText="MONTO DE  DESEMBOLSO A LA ENTIDAD"></asp:BoundField>
								<asp:BoundField DataField="MontoPagoEGS" HeaderText="MontoPagoEGS"></asp:BoundField>
								<asp:BoundField DataField="MontoPagoComision" HeaderText="COMISION"></asp:BoundField>
								<asp:BoundField DataField="MontoPagadoPensionNeto" HeaderText="PAGADO PENSION NETO"></asp:BoundField>
								<asp:BoundField DataField="MontoPagadoObservaciones" HeaderText="OBSERVACIONES DE PAGO"></asp:BoundField>
								<asp:BoundField DataField="MontoPagadoMasaHereditaria" HeaderText="PAGADO MASA HEREDITARIA" Visible="false"></asp:BoundField>
								<asp:BoundField DataField="MontoDevolucionTGN" HeaderText="DEVOLUCION TGN"></asp:BoundField>
								<asp:BoundField DataField="FechaDevolucion" HeaderText="FECHA DEVOLUCION"></asp:BoundField>
								<asp:BoundField DataField="Devolucion" HeaderText="DEVOLUCION"></asp:BoundField>
								<asp:BoundField DataField="EstadoConciliacion" HeaderText="ESTADO CONCILIACION"></asp:BoundField>
								<asp:BoundField DataField="FechaRevision" HeaderText="FECHA REVISION"></asp:BoundField>
							   
					</Columns>

					<EmptyDataTemplate>
						<div align="center" class="CajaDialogoAdvertencia">
						<br/>
						<img src="../Imagenes/warning.gif" alt="No existen CONCILIACION Registrados para la persona" />
						<br/>No existen CONCILIACION Registrados para la persona<br/><br/>
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
					</asp:Panel>
					</ContentTemplate>
					</cc1:TabPanel>                            
					</cc1:TabContainer>
				</div>
			</td>
		</tr>
        <tr>
			<td>
				<div>
					<cc1:TabContainer ID="tabInformacion" runat="server" ActiveTabIndex="0" Visible="false" >
					<cc1:TabPanel ID="TabPanel6" runat="server">
						<HeaderTemplate>
							SUSPENSIONES Y REHABILITACIONES
					   </HeaderTemplate>
						 <ContentTemplate>
						 <asp:Panel ID="Panel6" runat="server" style="overflow-x:scroll; " Width="1150px" >

						  <asp:GridView ID="gvSuspencion" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Size="9pt" ForeColor="#333333"  Visible="False"  OnRowCommand="gvSuspencion_RowCommand" DataKeyNames="IdSuspencionBeneficio,RegistroActivo,IdNorma" OnDataBound="gvSuspencion_DataBound">
						  <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
						  <Columns>
				   
								<asp:BoundField DataField="IdSuspencionBeneficio" HeaderText="IdSuspencionBeneficio" Visible="false"></asp:BoundField>
								<asp:BoundField DataField="IdTipoSuspension" HeaderText="ESTADO"></asp:BoundField>
								<asp:BoundField DataField="IdNorma" HeaderText="NORMA"></asp:BoundField>
								<asp:BoundField DataField="FechaSuspension" HeaderText="FECHA SUSPENSION"></asp:BoundField>
								<asp:BoundField DataField="FechaRehabilitacion" HeaderText="FECHA REHABILITACION"></asp:BoundField>
								<asp:BoundField DataField="ObservacionesSuspension" HeaderText="OBSERVACIONES SUSPENSION"  HtmlEncode="False"></asp:BoundField>
								<asp:BoundField DataField="ObservacionesRehabilitacion" HeaderText="OBSERVACIONES REHABILITACION"  HtmlEncode="False"></asp:BoundField>
								<asp:BoundField DataField="IdUsuarioSuspension" HeaderText="USUARIO SUSPENSION"></asp:BoundField>
								<asp:BoundField DataField="IdUsuarioRehabilitacion" HeaderText="USUARIO REHABILITACION"></asp:BoundField>
                                <asp:BoundField DataField="RegistroActivo" HeaderText="REGISTRO" Visible="false"></asp:BoundField>
                                <asp:BoundField DataField="NroReferenciaSuspension" HeaderText="NRO REFERENCIA SUSPENSION"></asp:BoundField>
							    <asp:BoundField DataField="NroReferenciaRehabilitacion" HeaderText="NRO REFERENCIA REHABILITACION"></asp:BoundField>
								<asp:ButtonField CommandName="cmdModificarSuspension" Text="Modificar" />
								<asp:BoundField DataField="IdNorma" HeaderText="IdNorma" Visible="false"></asp:BoundField>
								
							  </Columns>
								<EmptyDataTemplate>
									<div align="center" class="CajaDialogoAdvertencia">
									<br/>
									<img src="../Imagenes/warning.gif" alt="No existen SUSPENSIONES Y REHABILITACIONES Registrados para la persona" />
									<br/>No existen SUSPENSIONES Y REHABILITACIONES Registrados para la persona<br/><br/>
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
					</asp:Panel>
			</ContentTemplate>
			</cc1:TabPanel>
				   
		<cc1:TabPanel ID="TabPanel7" runat="server" >
				<HeaderTemplate>
					DOCUMENTOS REGISTRADOS
				</HeaderTemplate>
							 
			<ContentTemplate>
							<asp:Panel ID="Panel7" runat="server" style="overflow-x:scroll; " Width="1150px">

								<asp:GridView ID="gvDocumentos" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Size="9pt" ForeColor="#333333"  Visible="False"  AllowPaging="true"  OnRowCommand="gvDocumentos_RowCommand" DataKeyNames="IdSuspensionBeneficio,IdDocumento,RegistroActivo" OnDataBound="gvDocumentos_DataBound" OnPageIndexChanging="gvDocumentos_PageIndexChanging">
								<AlternatingRowStyle BackColor="White" ForeColor="#284775" />
								<Columns>
								
										<asp:BoundField DataField="IdSuspensionBeneficio" HeaderText="IdSuspensionBeneficio" Visible="false"></asp:BoundField>
										<asp:BoundField DataField="IdDocumento" HeaderText="IdDocumento" Visible="false"></asp:BoundField>
										<asp:BoundField DataField="IdTipoDocumento" HeaderText="TIPO DOCUMENTO"></asp:BoundField>
										<asp:BoundField DataField="IdGrupoDocumento" HeaderText="CLASE DE DOCUMENTO"></asp:BoundField>
										<asp:BoundField DataField="NumeroDocumento" HeaderText="NRO HOJA DE RUTA/DOCUMENTO"></asp:BoundField>
										<asp:BoundField DataField="FechaDocumento" HeaderText="FECHA DEL DOCUMENTO"></asp:BoundField>
										<asp:BoundField DataField="Referencia" HeaderText="REFERENCIA" HtmlEncode="False"></asp:BoundField>
										<asp:BoundField DataField="Observaciones" HeaderText="OBSERVACIONES"  HtmlEncode="False"></asp:BoundField>
										<asp:BoundField DataField="RegistroActivo" HeaderText="REGISTRO" Visible="false"></asp:BoundField>
										<asp:ButtonField CommandName="cmdModificarDocumento" Text="Modificar"  />
								</Columns>

								<EmptyDataTemplate>
									<div align="center" class="CajaDialogoAdvertencia">
									<br/>
									<img src="../Imagenes/warning.gif" alt="No existen DOCUMENTOS Registrados para la persona" />
									<br/>No existen DOCUMENTOS Registrados para la persona<br/><br/>
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
						</asp:Panel>
			</ContentTemplate>

			</cc1:TabPanel> 


							  <cc1:TabPanel ID="TabPanel8" runat="server" >
							  <HeaderTemplate>
							   PERIODOS
							  </HeaderTemplate>
									<ContentTemplate>
									   <asp:Panel ID="Panel8" runat="server" style="overflow-x:scroll; " Width="1150px">
										 <asp:GridView ID="gvPeriodosIncurridos" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Size="9pt" ForeColor="#333333"  Visible="False"  AllowPaging="true" OnPageIndexChanging="gvPeriodosIncurridos_PageIndexChanging" DataKeyNames="IdSuspension,IdInstitucionM,RegistroActivo" OnRowCommand="gvPeriodosIncurridos_RowCommand" OnDataBound="gvPeriodosIncurridos_DataBound">
											<AlternatingRowStyle BackColor="White" ForeColor="#284775" />

											<Columns>
														<asp:BoundField DataField="IdSuspension" HeaderText="IdSuspension" Visible="false"></asp:BoundField>
														<asp:BoundField DataField="IdInstitucionM" HeaderText="IdInstitucionM" Visible="false"></asp:BoundField>
														<asp:BoundField DataField="IdInstitucion" HeaderText="INSTITUCION"></asp:BoundField>
														<asp:BoundField DataField="PeriodoInicioInstitucion" HeaderText="PERIODO INICIO INSTITUCION" Visible="false"></asp:BoundField>
														<asp:BoundField DataField="PeriodoFinInstitucion" HeaderText="PERIODO FIN INSTITUCION" Visible="false"></asp:BoundField>
														<asp:BoundField DataField="PeriodoInicioSuspension" HeaderText="PERIODO INICIO SUSPENSION"></asp:BoundField>
														<asp:BoundField DataField="PeriodoFinSuspension" HeaderText="PERIODO INICIO REHABILITACION"></asp:BoundField>
														<asp:BoundField DataField="Observaciones" HeaderText="OBSERVACIONES"  HtmlEncode="False"></asp:BoundField>
														<asp:BoundField DataField="RegistroActivo" HeaderText="REGISTRO" Visible="false"></asp:BoundField>
														<asp:ButtonField CommandName="cmdModificarPeriodo" Text="Modificar" />
											 
											</Columns>

										   <EmptyDataTemplate>
												<div align="center" class="CajaDialogoAdvertencia">
												<br/>
												<img src="../Imagenes/warning.gif" alt="No existen PERIODOS  Registrados para la persona" />
												<br/>No existen PERIODOS Registrados para la persona<br/><br/>
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
									</asp:Panel>
								   </ContentTemplate>
						 </cc1:TabPanel>  
						 </cc1:TabContainer>
				</div>
			</td>
		</tr>
		<tr>
			<td>
				  <div>
					<cc1:TabContainer ID="tctSuspencionPreventiva" runat="server" ActiveTabIndex="1" Visible="false">
					<cc1:TabPanel ID="TabPanel9" runat="server">
					<HeaderTemplate>
					SUSPENSIONES PREVENTIVAS
					</HeaderTemplate>
					<ContentTemplate>
					<asp:Panel ID="Panel9" runat="server" style="overflow-x:scroll; " Width="1150px" >
				    <asp:GridView ID="gvSuspencionPreventiva" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Size="7pt" ForeColor="#333333"  Visible="False"  DataKeyNames="IdSuspensionPreventiva,IdInstitucion,IdNormaId" OnDataBound="gvSuspencionPreventiva_DataBound" OnRowCommand="gvSuspencionPreventiva_RowCommand">
					<AlternatingRowStyle BackColor="White" ForeColor="#284775" />
					<Columns>
							<asp:BoundField DataField="IdSuspensionPreventiva" HeaderText="IdSuspensionPreventiva" Visible="false" ></asp:BoundField>
							<asp:BoundField DataField="IdNorma" HeaderText="NORMA"></asp:BoundField>
                            <asp:BoundField DataField="NombreInstitucion" HeaderText="NOMBRE DE INSTITUCION"></asp:BoundField>
							<asp:BoundField DataField="IdInstitucion" HeaderText="IdInstitucion" Visible="false"></asp:BoundField>
							<asp:BoundField DataField="NroReferenciaSuspensionPreventiva" HeaderText="NRO REFERENCIA SUSPENSION PREVENTIVA"></asp:BoundField>
							<asp:BoundField DataField="NroReferenciaDesactivacion" HeaderText="NRO REFERENCIA REHABILITACION PREVENTIVA"></asp:BoundField>
							<asp:BoundField DataField="ObservacionesSuspension" HeaderText="OBSERVACION SUSPENSION"></asp:BoundField>
							<asp:BoundField DataField="ObservacionesDesactivacion" HeaderText="OBSERVACION REHABILITACION"></asp:BoundField>
							<asp:BoundField DataField="FechaSuspensionPreventiva" HeaderText="FECHA SUSPENSION"></asp:BoundField>
							<asp:BoundField DataField="FechaDesactivacion" HeaderText="FECHA REHABILITACION"></asp:BoundField>
							<asp:BoundField DataField="PeriodoInicioSuspension" HeaderText="PERIODO INICIO SUSPENSION"></asp:BoundField>
							<asp:BoundField DataField="PeriodoFinSuspension" HeaderText="PERIODO INICIO REHABILITACION"></asp:BoundField>
							<asp:BoundField DataField="IdUsuarioSuspensionPreventiva" HeaderText="USUARIO SUSPENSION"></asp:BoundField>
							<asp:BoundField DataField="IdUsuarioDesactivacion" HeaderText="USUARIO REHABILITACION"></asp:BoundField>
							<asp:BoundField DataField="RegistroActivo" HeaderText="ESTADO REGISTRO"></asp:BoundField>
                            <asp:BoundField DataField="IdNormaId" HeaderText="IdNormaId" Visible="false"></asp:BoundField>
							<asp:ButtonField CommandName="cmdModificar" Text="Modificar" />
							<asp:ButtonField CommandName="cmdRehabilitar" Text="Rehabilitar" />
															 
					</Columns>
					<EmptyDataTemplate>

						<div align="center" class="CajaDialogoAdvertencia">
						<br/>
						<img src="../Imagenes/warning.gif" alt="No existe Suspensiones Preventiva para la persona" />
						<br/>No existe Suspensiones Preventiva para la persona<br/><br/>
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
						
	   <!--    -------------------------------------------------------------------------------------                         -->                  


					</asp:Panel>
					</ContentTemplate>

					</cc1:TabPanel>
					<cc1:TabPanel ID="TabPanel10" runat="server" >
					<HeaderTemplate>
						DOCUMENTOS SUSPENSION PREVENTIVA
					</HeaderTemplate>
					<ContentTemplate>

					<asp:Panel ID="Panel10" runat="server" style="overflow-x:scroll; " Width="1150px">
				   

						 <asp:GridView ID="gvDocumentosPreventivos" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Size="9pt" ForeColor="#333333"  Visible="False"  AllowPaging="true"  DataKeyNames="IdSuspensionPeventiva,IdDocumento,RegistroActivo,IdGrupoDocumento" OnRowCommand="gvDocumentosPreventivos_RowCommand" OnDataBound="gvDocumentosPreventivos_DataBound" OnPageIndexChanging="gvDocumentosPreventivos_PageIndexChanging">
								<AlternatingRowStyle BackColor="White" ForeColor="#284775" />
								<Columns>
									
									<asp:BoundField DataField="IdSuspensionPeventiva" HeaderText="IdSuspensionPeventiva" Visible="false"></asp:BoundField>
									<asp:BoundField DataField="IdDocumento" HeaderText="IdDocumento" Visible="false"></asp:BoundField>
									   <asp:BoundField DataField="IdTipoDocumento" HeaderText="TIPO DOCUMENTO"></asp:BoundField>
									   <asp:BoundField DataField="IdGrupoDocumento" HeaderText="GRUPO DOCUMENTO" Visible="false"></asp:BoundField>
									   <asp:BoundField DataField="Grupo" HeaderText="GRUPO DOCUMENTO"></asp:BoundField>
										<asp:BoundField DataField="NumeroDocumento" HeaderText="NRO HOJA DE RUTA/DOCUMENTO"></asp:BoundField>
										<asp:BoundField DataField="FechaDocumento" HeaderText="FECHA DEL DOCUMENTO"></asp:BoundField>
										<asp:BoundField DataField="Referencia" HeaderText="REFERENCIA"></asp:BoundField>
										<asp:BoundField DataField="Observaciones" HeaderText="OBSERVACIONES"></asp:BoundField>
										<asp:BoundField DataField="RegistroActivo" HeaderText="RegistroActivo" Visible="false" ></asp:BoundField>
										<asp:ButtonField CommandName="cmdModificarDocumento" Text="Modificar" />
								</Columns>

								<EmptyDataTemplate>
									<div align="center" class="CajaDialogoAdvertencia">
									<br/>
									<img src="../Imagenes/warning.gif" alt="No existen DOCUMENTOS Registrados para la persona" />
									<br/>No existen DOCUMENTOS Registrados para la persona<br/><br/>
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


			  
					</asp:Panel>
					</ContentTemplate>
					</cc1:TabPanel>                            
					</cc1:TabContainer>
				</div>

			</td>
		</tr>


		</table>
<!-- HASTA AQUIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII-->        
  

  <div>
<!-- aqui termina el primer TabContainer-->
				   <asp:Button ID="btnRegistro" runat="server" Text="NUEVO REGISTRO" style="display:none"/>    
				 <asp:Panel ID="panDatos" runat="server" CssClass="panelceleste"  HorizontalAlign="Center" style="overflow-y:scroll; margin-top: 0px;" Height="550px" Width="750px">
							   <div>
									
										<div>
											<div align="center" > <asp:Label ID="lb1" runat="server" Text="Label">1. Modificar Estado:</asp:Label>
												 <asp:Label ID="lbIdEstadoBeneficio" runat="server" Text="Label" Visible="false"></asp:Label>
                                                <br />Nota: Todos los campos marcados por (<font color="red">*</font>) son campos obligatorios de registrar 
											</div> 
											   <table  align="center" style="border-color:black;width:600px; border:double">
											<tr>
												<td>
													<asp:Label ID="lb2" runat="server" Text="Label">Estado Actual: </asp:Label>
												</td>
												<td>
													<asp:TextBox ID="txtActivo" runat="server" ReadOnly="true" Width="281px"></asp:TextBox>
												</td>
											</tr>
											<tr>
												<td>
													<asp:Label ID="lb3" runat="server" Text="Label">Nuevo Estado: </asp:Label>
												</td>
											   <td>
													  <asp:DropDownList ID="ddlNuevoEstado" AutoPostBack="true"  runat="server" DataTextField="Estado" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlNuevoEstado_SelectedIndexChanged" Width="250px">
															<asp:ListItem Value="0">Seleccione...</asp:ListItem>
													  </asp:DropDownList>
												      <font color="red">*</font></td>

											</tr>
											<tr>
												<td>
													<asp:Label ID="lb4" runat="server" Text="Label">Norma: </asp:Label>
												</td>
												<td>
													<asp:DropDownList ID="ddlnorma" runat="server" AutoPostBack="false" style="height: 22px" Width="250px">
													</asp:DropDownList> <asp:Label ID="lblobligatorio3" runat="server" Text="*" ForeColor="Red">*</asp:Label>
													<asp:TextBox ID="txtnorma" runat="server" Visible="false" Width="250px"></asp:TextBox>
												</td>
											</tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label32" runat="server" Text="Label">Institución: </asp:Label>
                                                    </td>
                                                    <td>
                                                         <asp:DropDownList ID="ddlInstitucion" runat="server" Width="250px">
														</asp:DropDownList>
												     </td>
                                                </tr>
										</table>
										</div>
                                       <div>
                                           <table align="center" style="border-style: groove; border-color: #000000">
                                    <tr>
                                     <td colspan="4" class="auto-style5"><strong>PERIODOS </strong> <asp:Label ID="lblNroCertificado" runat="server" Text="" Visible="false"></asp:Label> </td>
									</tr>
									<tr> 
													<td >
														Periodo Inicio Suspension:
													</td>
													<td class="auto-style32">
														<asp:TextBox ID="txtFechaSuspencion" runat="server" placeholder="[AAAMM]" Height="24px" Width="75px"></asp:TextBox>
                                                        <asp:Image ID="Image6" runat="server" Height="25px" ImageUrl="~/Imagenes/32calendario.png" Width="25px" ImageAlign="Top" Style="cursor:pointer"/>
                                                        <asp:Label ID="lblobligatorio1" runat="server" Text="*" ForeColor="Red">*</asp:Label>
														<asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtFechaSuspencion" ID="RegularExpressionValidator7" ValidationExpression = "((([2][0-9][0-9][0-9]))(0[123456789]|10|11|12))$" runat="server" ErrorMessage="Periodo Incorrecto"></asp:RegularExpressionValidator>
                                                        <cc1:CalendarExtender ID="CalendarExtender8" runat="server" Enabled="True" TargetControlID="txtFechaSuspencion" PopupButtonID="Image6"
													    Format="yyyyMM" CssClass="cal_Theme1"></cc1:CalendarExtender> 
                                                        <cc1:FilteredTextBoxExtender ID="txtNumeroDocumento_FilteredTextBoxExtender" 
																runat="server" FilterType="Numbers"
																TargetControlID="txtFechaSuspencion" ValidChars="">
													    </cc1:FilteredTextBoxExtender>
													 </td>
													   <td class="auto-style34">
														Periodo Inicio Rehabilitacion:
													</td>
													<td >
														<asp:TextBox ID="txtFechaRehabilitacion" runat="server" placeholder="[AAAAMM]" Width="75px" Height="18px" onchange="Actualizar('<%=txtFechaRehabilitacion.ClientID%>');"></asp:TextBox>
														<asp:Image ID="Image7" runat="server" Height="25px" ImageUrl="~/Imagenes/32calendario.png" Width="25px" ImageAlign="Top" Style="cursor:pointer"/>
                                                        <asp:Label ID="lblobligatorio2" runat="server" Text="*" ForeColor="Red">*</asp:Label>
                                                        <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtFechaRehabilitacion" ID="RegularExpressionValidator8" ValidationExpression = "^((([2][0-9][0-9][0-9]))(0[123456789]|10|11|12))$" runat="server" ErrorMessage="Periodo Incorrecto"></asp:RegularExpressionValidator>
                                                        <cc1:CalendarExtender ID="CalendarExtender9" runat="server" TargetControlID="txtFechaRehabilitacion" PopupButtonID="Image7"
													    Format="yyyyMM" Enabled="True" CssClass="cal_Theme1"></cc1:CalendarExtender> 
                                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" 
																runat="server" FilterType="Numbers"
																TargetControlID="txtFechaRehabilitacion" ValidChars="">
														</cc1:FilteredTextBoxExtender>
													</td>
                  								</tr>
                                               <tr> 
													<td class="auto-style22">
													   Nro. de Referencia Suspension:
													</td><td class="auto-style32" >
														<asp:TextBox ID="txtNroReferenciaSuspencion" runat="server" placeholder="[Numero de Refrencia]"></asp:TextBox>
														 <asp:Label ID="lblObligatorio4" runat="server" Text="*" ForeColor="Red">*</asp:Label>
                                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" 
																runat="server" FilterType="Numbers"
																TargetControlID="txtNroReferenciaSuspencion" ValidChars="">
														</cc1:FilteredTextBoxExtender>                                                     
														
													</td>
													
													   <td class="auto-style34">
														Nro. de Referencia de Rehabilitacion:
													</td>
													<td class="auto-style14">
														<asp:TextBox ID="txtNroReferenciaRehabilitacion" runat="server" placeholder="[Numero de Refrencia]"></asp:TextBox>
													   <asp:Label ID="lblObligatorio5" runat="server" Text="*" ForeColor="Red">*</asp:Label>
                                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" 
																runat="server" FilterType="Numbers"
																TargetControlID="txtNroReferenciaRehabilitacion" ValidChars="">
														</cc1:FilteredTextBoxExtender>
													</td>
                                                 
												</tr>
                                               <tr> 
									    <td colspan="2" >
										    Observacion:
									    </td>
									    <td colspan="2" class="auto-style5">
										   <asp:TextBox ID="txtObservacioni" runat="server" Height="20px"  Width="400px" MaxLength="200" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                                            <cc1:FilteredTextBoxExtender ID="txtObservacioni_FilteredTextBoxExtender"
                                                runat="server" FilterType="Custom, LowercaseLetters, UppercaseLetters,Numbers"
                                                TargetControlID="txtObservacioni" ValidChars="'áéíóúÁÉÍÓÚñÑ.#/ ">
                                            </cc1:FilteredTextBoxExtender>
									    </td>
									</tr>
                                           </table>
                                       </div>
									   <div>
										  <div align="center" > <asp:Label ID="Label6" runat="server" Text="lb5">2. Registrar Documento:</asp:Label></div>
										<table align="center" style="border-color:black;width:700px; border:double;">
											<tr>
												<td class="auto-style10">
													<asp:Label ID="lb6" runat="server" Text="">Típo Documento: </asp:Label>
												</td>
												<td class="auto-style11">
													 <asp:DropDownList ID="ddlTDocumento" Width="130px" runat="server" Height="22px" >
													 </asp:DropDownList>
												     <font color="red">*</font></td>
											</tr>
											<tr>
												<td class="auto-style22">
												   Nro. Hoja de Ruta: 
												</td>
												 <td class="auto-style12">
													<asp:TextBox ID="txtNroDocumento1" runat="server" ></asp:TextBox>
												     <font color="red">*</font></td>
												<td>
												  Fecha Documento:
												</td>
													 <td class="auto-style14">
													<asp:TextBox ID="txtFechaActual" runat="server" Height="16px" Width="80px"  MaxLength="10"></asp:TextBox>
														  <font color="red">*</font><asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtFechaActual" ID="RegularExpressionValidator9" ValidationExpression = "^\d{1,2}\/\d{1,2}\/\d{2,4}$" runat="server" ErrorMessage="Formato de Fecha Incorrecta"></asp:RegularExpressionValidator>
                                                   <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender22" 
					                                runat="server" FilterType="Custom,Numbers"
					                                TargetControlID="txtFechaActual" ValidChars="/">
					                                    </cc1:FilteredTextBoxExtender>
												</td>
												<td>
													<asp:Image ID="imgCalendario" runat="server" Height="25px" ImageUrl="~/Imagenes/32calendario.png" Width="25px" ImageAlign="Top" Style="cursor:pointer"/>
												    
                                                    <cc1:CalendarExtender ID="CalendarExtender6" runat="server" TargetControlID="txtFechaActual" PopupButtonID="imgCalendario"
						OnClientDateSelectionChanged="function hideCalendar(cb) { cb.hide(); }" CssClass="cal_Theme1"></cc1:CalendarExtender>
												   
												</td>
											</tr>
											<tr>
												<td class="auto-style22">
													<asp:Label ID="referencia" runat="server" Text="Label">Referencia del Documento: </asp:Label>
												</td>
												<td class="auto-style12" colspan="3">
													<asp:TextBox ID="txtReferenciai" runat="server" Height="20px"  Width="450px" MaxLength="200" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                                                    <cc1:FilteredTextBoxExtender ID="txtReferenciai_FilteredTextBoxExtender"
                                                        runat="server" FilterType="Custom, LowercaseLetters, UppercaseLetters,Numbers"
                                                        TargetControlID="txtReferenciai" ValidChars="'áéíóúÁÉÍÓÚñÑ.#/ ">
                                                    </cc1:FilteredTextBoxExtender>
												</td>
											</tr>

											<tr>
												<td class="auto-style22">
													<asp:Label ID="lb9" runat="server" Text="Label">Observaciones del Documento: </asp:Label>
												</td>
												<td class="auto-style12" colspan="3">
													<asp:TextBox ID="txaObservacioni" runat="server" Height="20px"  Width="450px" MaxLength="200" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                                                    <cc1:FilteredTextBoxExtender ID="txaObservacioni_FilteredTextBoxExtender"
                                                        runat="server" FilterType="Custom, LowercaseLetters, UppercaseLetters,Numbers"
                                                        TargetControlID="txaObservacioni" ValidChars="'áéíóúÁÉÍÓÚñÑ.#/ ">
                                                    </cc1:FilteredTextBoxExtender>
												</td>
											</tr>
										

											 
                   								<tr>
														<td class="auto-style22"></td>
														<td class="auto-style12"></td>
														<td></td>
														<td class="auto-style14">
															<asp:LinkButton ID="lblMasDocumentos" runat="server" OnClick="lblMasDocumentos_Click" Visible="false">
                                                                
                                                                <asp:Label ID="lblMasDoc" runat="server" Text="Mas documentos " Visible="false">Mas documentos </asp:Label>
															</asp:LinkButton>
                                                         <asp:Button ID="Button1" runat="server" Visible =" true"
			                                            OnClientClick="javascript : return confirm('Esta seguro de realizar esta accion?');" 
			                                            Text="Agregar Documento" CssClass="boton150" OnClick="btnAgregarDoc_Click" Width="197px"/>
														</td>
                                                      
											</tr>
                                            <tr>
                                                <td colspan="4">
                                                    <asp:GridView ID="gvDocTempNormales" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Size="8pt" ForeColor="#333333"  Visible="False" OnRowCommand="gvDocTempNormales_RowCommand" DataKeyNames="IdDocumento">
					                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
					                                <Columns>
							                        <asp:BoundField DataField="Fila" HeaderText="NRO"></asp:BoundField>
                                                    <asp:BoundField DataField="TipoDocumento" HeaderText="TIPO DOCUMENTO"></asp:BoundField>
							                        <asp:BoundField DataField="NumeroDocumento" HeaderText="NUMERO DOCUMENTO"></asp:BoundField>
							                        <asp:BoundField DataField="FechaDocumento" HeaderText="FECHA DOCUMENTO"></asp:BoundField>
							                        <asp:BoundField DataField="Referencia" HeaderText="REFERENCIA"></asp:BoundField>
							                        <asp:BoundField DataField="Observaciones" HeaderText="OBSERVACIONES"></asp:BoundField>
                                                    <asp:BoundField DataField="IdDocumento" HeaderText="ID Documento" Visible="false"></asp:BoundField>
                                                    <asp:ButtonField ButtonType="Image" CommandName="cmdEliminar" ImageUrl="~/Imagenes/16eliminar.png" Text="Eliminar" />
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
                                                <td colspan="5">
                                        <asp:Panel ID="MasDocumentos" aligin ="center" runat="server" Visible="false" >
										<div >
											<table  align="center" style="border-color:black;width:700px; border:double"  >
											<tr>
												<td class="auto-style23">
													<asp:Label ID="Label14" runat="server" Text="">Típo Documento: </asp:Label>
												</td>
												<td class="auto-style17">
													 <asp:DropDownList ID="ddldocumentoextra" Width="200px" runat="server" Height="22px">
													 </asp:DropDownList>
												     <font color="red">*</font></td>
											</tr>
											<tr>
												<td class="auto-style23">
												   Nro. Hoja de Ruta: 
												</td>
												 <td class="auto-style17">
													
													  <asp:TextBox ID="txtdocumentoextra" runat="server" Width="128px"></asp:TextBox>                     
												   
												 
												      <font color="red">*</font></td>
										   
												<td class="auto-style24">
												  Fecha Documento:
												</td>
													 <td class="auto-style13">
													<asp:TextBox ID="txtfechadocumentoextra" runat="server" Height="16px" Width="80px" MaxLength="10"></asp:TextBox>
														  <font color="red">*</font><asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtfechadocumentoextra" ID="RegularExpressionValidator12" ValidationExpression = "^\d{1,2}\/\d{1,2}\/\d{2,4}$" runat="server" ErrorMessage="Formato de Fecha Incorrecta"></asp:RegularExpressionValidator>
                                                         <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender23" 
					                                runat="server" FilterType="Custom,Numbers"
					                                TargetControlID="txtfechadocumentoextra" ValidChars="/">
					                                    </cc1:FilteredTextBoxExtender>
												</td>
												<td>
													<asp:Image ID="imgcalendario2" runat="server" Height="25px" ImageUrl="~/Imagenes/32calendario.png" Width="25px" ImageAlign="Top" Style="cursor:pointer"/>
													<cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtfechadocumentoextra" PopupButtonID="imgcalendario2"
													OnClientDateSelectionChanged="function hideCalendar(cb) { cb.hide(); }"  CssClass="cal_Theme1"></cc1:CalendarExtender> 
												   
												</td>
											</tr>
											<tr>
												<td class="auto-style23">
													<asp:Label ID="Label16" runat="server" Text="Label">Referencia: </asp:Label>
												</td>
												<td class="auto-style17">
													<textarea id="txaReferenciadocumentoextra" cols="20" rows="2" runat ="server"> </textarea>
												</td>
											</tr>

											<tr>
												<td class="auto-style23">
													<asp:Label ID="Label17" runat="server" Text="Label">Observaciones del Documento: </asp:Label>
												</td>
												<td class="auto-style17">
													<textarea id="txaObservacionDocumentoExtra" cols="20" rows="2" runat ="server"></textarea>
												</td>
												<td class="auto-style24">

												</td>
												<td colspan="2">
													<asp:LinkButton ID="lblMasDocumentos1" runat="server"  OnClick ="lblMasDocumentos1_Click">
														<asp:Label ID="lblMasDoc1" runat="server" Text="Mas documentos ">Mas documentos </asp:Label>
													</asp:LinkButton>
												</td>
											</tr>
											</table>
											
										</div>
                                      
								   </asp:Panel>
                                        </td>
                                            </tr>

                                            <tr>
                                                <td colspan ="5">
                                      <asp:Panel ID="MasDocumentos1" aligin ="center" runat="server" Visible="false" >
										<div >
											<table  align="center" style="border-color:black;width:700px; border:double"  >
											<tr>
												<td class="auto-style18">
													<asp:Label ID="Label24" runat="server" Text="">Típo Documento: </asp:Label>
												</td>
												<td class="auto-style19">
													 <asp:DropDownList ID="ddldocumentoextra1" Width="200px" runat="server" Height="22px">
													 </asp:DropDownList>
												    <font color="red">*</font></td>
											</tr>
											<tr>
												<td class="auto-style18">
												   Nro. Hoja de Ruta: 
												</td>
												 <td class="auto-style19">
													  <asp:TextBox ID="txtdocumentoextra1" runat="server"></asp:TextBox>                     
												      <font color="red">*</font></td>
												<td class="auto-style25">
												  Fecha Documento:
												</td>
													 <td class="auto-style13">
													<asp:TextBox ID="txtfechadocumentoextra1" runat="server" Height="16px" Width="90px" MaxLength="10"></asp:TextBox>
														  <font color="red">*</font>
														  <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtfechadocumentoextra1" ID="RegularExpressionValidator18" ValidationExpression = "^\d{1,2}\/\d{1,2}\/\d{2,4}$" runat="server" ErrorMessage="Formato de Fecha Incorrecta"></asp:RegularExpressionValidator>
                                                          <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender24" 
					                                runat="server" FilterType="Custom,Numbers"
					                                TargetControlID="txtfechadocumentoextra1" ValidChars="/">
					                                    </cc1:FilteredTextBoxExtender>
												</td>
												<td>
													<asp:Image ID="Image5" runat="server" Height="25px" ImageUrl="~/Imagenes/32calendario.png" Width="25px" ImageAlign="Top" Style="cursor:pointer"/>
													<cc1:CalendarExtender ID="CalendarExtender7" runat="server" TargetControlID="txtfechadocumentoextra1" PopupButtonID="Image5"
													OnClientDateSelectionChanged="function hideCalendar(cb) { cb.hide(); } " CssClass="cal_Theme1"></cc1:CalendarExtender> 
												   
												</td>
											</tr>
											<tr>
												<td class="auto-style18">
													<asp:Label ID="Label27" runat="server" Text="Label">Referencia: </asp:Label>
												</td>
												<td class="auto-style19">
													<textarea id="txaReferenciadocumentoextra1" cols="20" rows="2" runat ="server"> </textarea>
												</td>
											</tr>

											<tr>
												<td class="auto-style18">
													<asp:Label ID="Label29" runat="server" Text="Label">Observaciones del Documento: </asp:Label>
												</td>
												<td class="auto-style19">
													<textarea id="txaObservacionDocumentoExtra1" cols="20" rows="2" runat ="server"></textarea>
												</td>
											</tr>
											</table>
										</div>
								   </asp:Panel>
                                    </td>
                                     </tr>
									</table>
                                    
										   
										</div>
								   <br />
                                        
									<asp:Panel ID="pnlInsitucion" runat="server" Visible="False" Width="100%" HorizontalAlign="Center">		
                                    <div align="center">      
                                    <asp:Label ID="Label2" runat="server" Text="Label" >Registrar Periodos Incurridos:</asp:Label>
									<asp:CheckBox ID="checkinsitucion" runat="server" AutoPostBack="true"  OnCheckedChanged="checkinsitucion_CheckedChanged" /> 
									<asp:Label ID="Label10" runat="server" Text="Label" >3. Periodos Incurridos:</asp:Label></div>
                                    <table  align="center" style="border-color:black;width:600px; border:double">
									<tr>
					    				<td>
										    Institucion:
										</td>
									</tr>
				                    <tr> 
					    				<td>
							    			Periodo Inicio institucion:
										</td>
										<td>
	    									<asp:TextBox ID="txtPeriodoInicioInstitucion" runat="server" placeholder="[PERIODO INICIO]" style="height: 22px"></asp:TextBox>
                                            <asp:Image ID="Image17" runat="server" Height="25px" ImageUrl="~/Imagenes/32calendario.png" Width="25px" ImageAlign="Top" Style="cursor:pointer"/>
                                            <cc1:CalendarExtender ID="CalendarExtender19" runat="server" TargetControlID="txtPeriodoInicioInstitucion" PopupButtonID="Image17"
                                                             						   Format="yyyyMM" Enabled="True" CssClass="cal_Theme1"></cc1:CalendarExtender> 
											<asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtPeriodoInicioInstitucion" ID="RegularExpressionValidator1" ValidationExpression = "^[0-9]{6,6}$" runat="server" ErrorMessage="Periodo Incorrecto"></asp:RegularExpressionValidator>
											<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" 
																runat="server" FilterType="Numbers"
																TargetControlID="txtPeriodoInicioInstitucion" ValidChars="">
											</cc1:FilteredTextBoxExtender>                                                     
										</td>
										<td>
										    Periodo Fin institucion:
										</td>
										<td>
								            <asp:TextBox ID="txtPerioFinInstitucion" runat="server" placeholder="[PERIODO FIN]"></asp:TextBox>
								            <asp:Image ID="Image16" runat="server" Height="25px" ImageUrl="~/Imagenes/32calendario.png" Width="25px" ImageAlign="Top" Style="cursor:pointer"/>
													    
                                                <cc1:CalendarExtender ID="CalendarExtender18" runat="server" TargetControlID="txtPerioFinInstitucion" PopupButtonID="Image16"
                                                             	            Format="yyyyMM" Enabled="True" CssClass="cal_Theme1"></cc1:CalendarExtender> 	
                                                        
                                            <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtPerioFinInstitucion" ID="RegularExpressionValidator2" ValidationExpression = "^[0-9]{6,6}$" runat="server" ErrorMessage="Periodo Incorrecto"></asp:RegularExpressionValidator>
								            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" 
											            runat="server" FilterType="Numbers"
											            TargetControlID="txtPerioFinInstitucion" ValidChars="">
								            </cc1:FilteredTextBoxExtender>
										</td>
								    </tr>
									
								 </table>
                                </asp:Panel>
                           <asp:Button ID="btnAccionarND" runat="server" OnClick="btnAceptar_Click"
								OnClientClick="javascript : return confirm('Esta seguro de realizar esta accion?');"
								Text="Aceptar" CssClass="boton150" />
								<asp:Button ID="btnCerrar" runat="server" Text="Cerrar"  CssClass="boton150" OnClick="btnCerrar_Click"/>
								</div>
                             </asp:Panel>    
			        <cc1:RoundedCornersExtender ID="RoundedCornersExtender1" runat="server"
				    Enabled="True" TargetControlID="panDatos" Radius="10" BorderColor="Black">
			        </cc1:RoundedCornersExtender>

					<cc1:ModalPopupExtender ID="mpeNuevoRegistro" runat="server"
					Enabled="True"
					TargetControlID="btnRegistro"
					CancelControlID="btnCerrar"
					PopupControlID="panDatos"
					BackgroundCssClass="modalBackground">
				    </cc1:ModalPopupExtender>	
		
	<br />
  			<asp:Button ID="btnmodificasuspencion" runat="server" Text="Modificar" style="display:none"/>    
			<asp:Panel ID="pansuspencion" runat="server" CssClass="panelceleste"  HorizontalAlign="Center" Width="972px" Height="368px">
			<div style="height: 353px; width: 902px; margin-left: 0px">
			<asp:Label ID="Label15" runat="server">  </asp:Label>
			   		<div>
					<div align="center" > <asp:Label ID="Label3" runat="server" Text="Label">1. Modificar Suspension:</asp:Label></div> 
					<asp:Label ID="lblIdSuspencion" runat="server" Text="" Visible="false"></asp:Label>
					<table  align="center" style="border-color:black;width:600px; border:double">
					<tr>
						<td>
						<asp:Label ID="Label4" runat="server" Text="Label">Estado Actual: </asp:Label>
						</td>
						<td>
						<asp:TextBox ID="txtEstadoM" runat="server" ReadOnly="true" Width="270px"></asp:TextBox>
						</td>
					</tr>
					<tr>
						<td>
						<asp:Label ID="Label7" runat="server" Text="Label">Norma: </asp:Label>
						</td>
						<td>
						<asp:DropDownList ID="ddlnormaM" runat="server">
						</asp:DropDownList>
						</td>
					</tr>
						<tr>
						  <td>
							<asp:Label ID="Label5" runat="server" Text="Label">Observacion de Suspension: </asp:Label>
						</td>
						  <td>
							  <textarea id="txaObsercacionSuspencion" cols="20" rows="2" runat ="server" onkeyup="this.value=this.value.toUpperCase()"></textarea>
						</td>

						</tr>
						 <tr>
						  <td>
							<asp:Label ID="Label9" runat="server" Text="Label">Observacion de Rehabilitacion: </asp:Label>
						</td>
						  <td>
							  <textarea id="txaObservacionRehabilitacion" cols="20" rows="2" runat ="server"  disabled = "true" onkeyup="this.value=this.value.toUpperCase()"></textarea>
						</td>

						</tr>
						<tr> 
						<td>
						Periodo Inicio Suspension:
						</td>
						<td>
						<asp:TextBox ID="txtPerioSuspencionM" runat="server" placeholder="[PERIODO INICIO]" MaxLength="6"></asp:TextBox>
						<asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtPerioSuspencionM" ID="RegularExpressionValidator3" ValidationExpression = "^((([2][0-9][0-9][0-9]))(0[123456789]|10|11|12))$" runat="server" ErrorMessage="Periodo Incorrecto"></asp:RegularExpressionValidator>
                        
                        <asp:Image ID="Image10" runat="server" Height="25px" ImageUrl="~/Imagenes/32calendario.png" Width="25px" ImageAlign="Top" Style="cursor:pointer"/>
						<cc1:CalendarExtender ID="CalendarExtender12" runat="server" TargetControlID="txtPerioSuspencionM" PopupButtonID="Image10"
						Format="yyyyMM" Enabled="True" CssClass="cal_Theme1"></cc1:CalendarExtender>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" 
						        runat="server" FilterType="Numbers"
						        TargetControlID="txtPerioSuspencionM" ValidChars="">
			            </cc1:FilteredTextBoxExtender>                                                     
						
						</td>
						<td>
						Periodo Inicio Rehabilitacion:
						</td>
						<td><asp:TextBox ID="txtPerioRehabilitacionM" runat="server" placeholder="[PERIODO FIN]" MaxLength="6" onchange="BloquearSuspension()"></asp:TextBox>
						
                        <asp:Image ID="Image15" runat="server" Height="25px" ImageUrl="~/Imagenes/32calendario.png" Width="25px" ImageAlign="Top" Style="cursor:pointer"/>
													    
                        <cc1:CalendarExtender ID="CalendarExtender17" runat="server" TargetControlID="txtPerioRehabilitacionM" PopupButtonID="Image15"
					    Format="yyyyMM" Enabled="True" CssClass="cal_Theme1"></cc1:CalendarExtender> 

						<asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtPerioRehabilitacionM" ID="RegularExpressionValidator4" ValidationExpression = "^((([2][0-9][0-9][0-9]))(0[123456789]|10|11|12))$" runat="server" ErrorMessage="Periodo Incorrecto"></asp:RegularExpressionValidator>
						<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" 
								runat="server" FilterType="Numbers"
								TargetControlID="txtPerioRehabilitacionM" ValidChars="">
					    </cc1:FilteredTextBoxExtender>                                                     
					</td>
					</tr>
					<tr> 
						<td>
						Numero de Referencia Suspension:
						</td>
						<td>
						<asp:TextBox ID="txtNroReferenciaSuspencionM" runat="server" placeholder="[Numero de Refrencia]" MaxLength="6"></asp:TextBox>
					   
					   <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" 
						runat="server" FilterType="Numbers"
						TargetControlID="txtNroReferenciaSuspencionM" ValidChars="">
						</cc1:FilteredTextBoxExtender>
							 </td>
						<td>
						Numero de Referencia de Rehabilitacion:
						</td>
						<td>
						<asp:TextBox ID="txtNroReferenciaRehabilitacionM" runat="server" placeholder="[Numero de Refrencia]" MaxLength="6"  disabled = "true"></asp:TextBox>
						<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" 
						runat="server" FilterType="Numbers"
						TargetControlID="txtNroReferenciaRehabilitacionM" ValidChars="">
						</cc1:FilteredTextBoxExtender>
						</td>
					</tr>
				</table>
				<asp:Button ID="bntModificaSuspencion" runat="server" OnClick="bntModificaSuspencion_Click"
				OnClientClick="javascript : return confirm('Esta seguro de realizar esta accion?');"
				Text="Aceptar" CssClass="boton150" />
				<asp:Button ID="btncerrarsuspencion" runat="server" Text="Cerrar"  CssClass="boton150"/>
				</div>
			</div>
			</asp:Panel>
			<cc1:RoundedCornersExtender ID="RoundedCornersExtender2" runat="server"
			Enabled="True" TargetControlID="pansuspencion" Radius="10" BorderColor="Black">
			</cc1:RoundedCornersExtender>
			<cc1:ModalPopupExtender ID="mpmodificaSuspencion" runat="server"
			Enabled="True"
			TargetControlID="btnmodificasuspencion"
			CancelControlID="btncerrarsuspencion"
			PopupControlID="pansuspencion"
			BackgroundCssClass="modalBackground">
			</cc1:ModalPopupExtender>	

			<asp:Button ID="btnModificaDocumento" runat="server" Text="Modificar" style="display:none"/>    
			<asp:Panel ID="panModificacionDocumento" runat="server" CssClass="panelceleste"  HorizontalAlign="Center" Width="980px">
				<div>
        		<div>
			<div align="center" > <asp:Label ID="Label8" runat="server" Text="lb5"> Modificar Documento:</asp:Label></div>
			<asp:Label ID="lblIdSuspencionm" runat="server" Text="" Visible="false"></asp:Label>
			<asp:Label ID="lblIdDocumetnom" runat="server" Text="" Visible="false"></asp:Label>
				 <table align="center" style="border-style: double; border-width: medium; border-color: inherit; width:600px; height: 204px;">
				<tr>
					<td>
						<asp:Label ID="Label11" runat="server" Text="">Típo Documento: </asp:Label>
					</td>
					<td>
							<asp:DropDownList ID="ddlTipoDocumentoM" Width="200px" runat="server">
							</asp:DropDownList>
					</td>
					<td>
						<asp:Label ID="lblDocumento" runat="server" Text=""></asp:Label>
					</td>                
				
				</tr>
				<tr>
					<td>
						Nro. Hoja de Ruta: 
					</td>
						<td>
						<asp:TextBox ID="txtNroDocumentoM" runat="server" MaxLength="6"></asp:TextBox>
						 <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender27" 
				        runat="server" FilterType="Custom,UppercaseLetters,LowercaseLetters,Numbers"
				        TargetControlID="txtNroDocumentoM" ValidChars="-/">
				        </cc1:FilteredTextBoxExtender>
					</td>
										   
					<td>
						Fecha Documento:
					</td>
							<td>
						<asp:TextBox ID="txtFechaDocumentoM" runat="server" MaxLength="10"></asp:TextBox>
                          <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender30" 
				            runat="server" FilterType="Numbers,Custom"
				            TargetControlID="txtFechaDocumentoM" ValidChars="/-">
				            </cc1:FilteredTextBoxExtender>
						<asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtFechaDocumentoM" ID="RegularExpressionValidator10" ValidationExpression = "^\d{1,2}\/\d{1,2}\/\d{2,4}$" runat="server" ErrorMessage="Formato de Fecha Incorrecta"></asp:RegularExpressionValidator>
					</td>
					<td>
						<asp:Image ID="imgcalendario1" runat="server" Height="25px" ImageUrl="~/Imagenes/32calendario.png" Width="25px" ImageAlign="Top" Style="cursor:pointer"/>
						<cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFechaDocumentoM" PopupButtonID="imgcalendario1"
						OnClientDateSelectionChanged="function hideCalendar(cb) { cb.hide(); }" CssClass="cal_Theme1"></cc1:CalendarExtender>
						 
					</td>
				</tr>
				<tr>
					<td>
						<asp:Label ID="Label12" runat="server" Text="Label">Referencia: </asp:Label>
					</td>
					<td>
						<textarea id="txtReferenciaM" cols="20" rows="2" runat ="server" onkeyup="this.value=this.value.toUpperCase()"> </textarea>
					</td>
				</tr>

				<tr>
					<td>
						<asp:Label ID="Label13" runat="server" Text="Label">Observaciones: </asp:Label>
					</td>
					<td>
						<textarea id="txaObservacionDocumentoM" cols="20" rows="2" runat ="server" onkeyup="this.value=this.value.toUpperCase()"></textarea>
					</td>
				</tr>
 
			</table>
			<asp:Button ID="btnModificaDocumentoA" runat="server" 
			OnClientClick="javascript : return confirm('Esta seguro de realizar esta accion?');"
			Text="Aceptar" CssClass="boton150" OnClick="btnModificaDocumentoA_Click"/>
			<asp:Button ID="btncierraDocumento" runat="server" Text="Cerrar"  CssClass="boton150"/>
		   </div>
			
			 </div>
			</asp:Panel>


			<cc1:RoundedCornersExtender ID="RoundedCornersExtender3" runat="server"
			Enabled="True" TargetControlID="panModificacionDocumento" Radius="10" BorderColor="Black">
			</cc1:RoundedCornersExtender>
			<cc1:ModalPopupExtender ID="mpeModificaDocumento" runat="server"
			Enabled="True"
			TargetControlID="btnModificaDocumento"
			CancelControlID="btncierraDocumento"
			PopupControlID="panModificacionDocumento"
			BackgroundCssClass="modalBackground">
			</cc1:ModalPopupExtender>	
		  <asp:Button ID="btnModificaPeridoIncurrido" runat="server" Text="Modificar" style="display:none"/>    
		  <asp:Panel ID="panModificaciaPeriodo" runat="server" CssClass="panelceleste"  HorizontalAlign="Center" Width="980px">
			<div>
			<div>
			<div align="center" > <asp:Label ID="Label18" runat="server" Text="lb5"> Modificar Periodos Incurridos:</asp:Label></div>
			<asp:Label ID="lblIdsuspencionP" runat="server" Text="" Visible="false"></asp:Label>
			<asp:Label ID="lblIdinstitucion" runat="server" Text="" Visible="false"></asp:Label>
				<table  align="center" style="border-color:black;width:600px; border:double">
					<tr>
						<td>
							Institucion:
						</td>
						<td>
							<asp:DropDownList ID="ddlInstitucionM" runat="server">
							</asp:DropDownList>
						</td>
					</tr>
					
                    <tr visible="false"> 
						<td visible="false">
						 <asp:Label ID="Label1" runat="server" Text="" Visible="false"> Periodo Inicio institucion:</asp:Label>
						</td>
						<td >
							<asp:TextBox ID="txtPeriodoInicioInstitucionM" runat="server" placeholder="[PERIODO INICIO]" MaxLength="6" visible="false"></asp:TextBox>
							<asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtPeriodoInicioInstitucionM" ID="RegularExpressionValidator5" ValidationExpression = "^[0-9]{6,6}$" runat="server" ErrorMessage="Periodo Incorrecto"></asp:RegularExpressionValidator>
							
                            <asp:Image ID="Image11" runat="server" Height="25px" ImageUrl="~/Imagenes/32calendario.png" Width="25px" ImageAlign="Top" Style="cursor:pointer" visible="false"/>
													    
                            <cc1:CalendarExtender ID="CalendarExtender13" runat="server" TargetControlID="txtPeriodoInicioInstitucionM" PopupButtonID="Image11" 
						   Format="yyyyMM" Enabled="True" CssClass="cal_Theme1"></cc1:CalendarExtender> 

                            						
                             <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" 
																runat="server" FilterType="Numbers"
																TargetControlID="txtPeriodoInicioInstitucionM" ValidChars="">
													</cc1:FilteredTextBoxExtender>                                                     
						
						</td>
						<td>
							<asp:Label ID="Label33" runat="server" Text="" Visible="false">Periodo Fin institucion:</asp:Label>
						</td>
						<td>
							<asp:TextBox ID="txtPeriodoFinInstitucion" runat="server" placeholder="[PERIODO FIN]" MaxLength="6" visible="false"></asp:TextBox>
							<asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtPeriodoFinInstitucion" ID="RegularExpressionValidator6" ValidationExpression = "^[0-9]{6,6}$" runat="server" ErrorMessage="Periodo Incorrecto"></asp:RegularExpressionValidator>
							
                            <asp:Image ID="Image12" runat="server" Height="25px" ImageUrl="~/Imagenes/32calendario.png" Width="25px" ImageAlign="Top" Style="cursor:pointer" visible="false"/>
													    
                            <cc1:CalendarExtender ID="CalendarExtender14" runat="server" TargetControlID="txtPeriodoFinInstitucion" PopupButtonID="Image12"
						    Format="yyyyMM" Enabled="True" CssClass="cal_Theme1"></cc1:CalendarExtender> 

                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" 
									runat="server" FilterType="Numbers"
									TargetControlID="txtPeriodoFinInstitucion" ValidChars="">
						    </cc1:FilteredTextBoxExtender>
						</td>
					</tr>

					<tr visible="false"> 
						<td>
							<asp:Label ID="Label35" runat="server" Text="" Visible="false">Observaciones:</asp:Label>
						</td>
						<td>
							<textarea id="txaObservacionPeriodo" cols="20" rows="2" runat="server" visible="false"></textarea>
						</td>
					</tr>



				</table>
				<br />


			<asp:Button ID="btnModificaPeriodo" runat="server" 
			OnClientClick="javascript : return confirm('Esta seguro de realizar esta accion?');"
			Text="Aceptar" CssClass="boton150" OnClick="btnModificaPeriodo_Click"/>
			
			<asp:Button ID="btnPeriodosIncurridos" runat="server" Text="Cerrar"  CssClass="boton150"/>
			</div>
		   
			 </div>
			</asp:Panel>
			<cc1:RoundedCornersExtender ID="RoundedCornersExtender4" runat="server"
			Enabled="True" TargetControlID="panModificaciaPeriodo" Radius="10" BorderColor="Black">
			</cc1:RoundedCornersExtender>
			
			<cc1:ModalPopupExtender ID="mpeModificaPeriodo" runat="server"
			Enabled="True"
			TargetControlID="btnModificaPeridoIncurrido"
			CancelControlID="btnPeriodosIncurridos"
			PopupControlID="panModificaciaPeriodo"
			BackgroundCssClass="modalBackground">
			</cc1:ModalPopupExtender>
		  <asp:Button ID="btnSP" runat="server" Text="Modificar" style="display:none"/>    
		  <asp:Panel ID="panSP" runat="server" CssClass="panelceleste"  HorizontalAlign="Center" Height="500px" Width="850px" style="overflow-y:scroll; ">
			<div>
			<div>
			<div align="center"> <asp:Label ID="Label20" runat="server" Text="lb5"> Registrar Suspension Preventiva</asp:Label></div>
			    Nota: Todos los campos marcados por (<font color="red">*</font>) son campos obligatorios de registrar 
                <table  align="center" style="border-color:black;width:800px; border:double">
					<tr>
						<td class="auto-style29">
							Estado:
						</td>
						<td colspan =" 2">
							<asp:TextBox ID="txtEstadoSP" runat="server" Width =" 200px"></asp:TextBox>
						</td>
						<td>
						<asp:Label ID="lblIdSuspencionPreventivaS" runat="server" Text="" Visible="false"></asp:Label>
					</td>
					</tr>
				<tr>
						<td class="auto-style29">
							Institucion:
						</td>
						<td colspan ="3">
							<asp:DropDownList ID="ddlInsitucionSP" runat="server">
							</asp:DropDownList>
						    <font color="red">*</font></td>
					</tr>
                    <tr>
						<td class="auto-style29">
							Norma:
						</td>
						<td colspan ="3">
							<asp:DropDownList ID="ddlNormaPreventiva" runat="server">
							</asp:DropDownList>
						    <font color="red">*</font></td>
					</tr>
    			<tr>
					<td class="auto-style29">Periodo de Suspension</td>
					<td>
						<asp:TextBox ID="txtPeriodoSuspencionSP" runat="server" MaxLength="6"></asp:TextBox>
						<asp:Image ID="Image13" runat="server" Height="25px" ImageUrl="~/Imagenes/32calendario.png" Width="25px" ImageAlign="Top" Style="cursor:pointer"/><font color="red">*</font>
													    
                        <cc1:CalendarExtender ID="CalendarExtender15" runat="server" TargetControlID="txtPeriodoSuspencionSP" PopupButtonID="Image13"
					    Format="yyyyMM" Enabled="True" CssClass="cal_Theme1"></cc1:CalendarExtender> 
						<asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtPeriodoSuspencionSP" ID="RegularExpressionValidator14" ValidationExpression = "^((([2][0-9][0-9][0-9]))(0[123456789]|10|11|12))$" runat="server" ErrorMessage="Periodo Incorrecto"></asp:RegularExpressionValidator>
                        
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender12" 
								runat="server" FilterType="Numbers"
								TargetControlID="txtPeriodoSuspencionSP" ValidChars="">
					    </cc1:FilteredTextBoxExtender>                                                     
					</td>
				<td class="auto-style24">Periodo de Rehabilitacion</td>
					<td>
						<asp:TextBox ID="txtPeriodoRehabilitacionSP" runat="server" MaxLength="6" ></asp:TextBox>
                        <asp:Image ID="Image14" runat="server" Height="25px" ImageUrl="~/Imagenes/32calendario.png" Width="25px" ImageAlign="Top" Style="cursor:pointer"/><font color="red"></font>
													    
                        <cc1:CalendarExtender ID="CalendarExtender16" runat="server" TargetControlID="txtPeriodoRehabilitacionSP" PopupButtonID="Image14"
					    Format="yyyyMM" Enabled="True" CssClass="cal_Theme1"></cc1:CalendarExtender> 
						<asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtPeriodoRehabilitacionSP" ID="RegularExpressionValidator15" ValidationExpression = "^((([2][0-9][0-9][0-9]))(0[123456789]|10|11|12))$" runat="server" ErrorMessage="Periodo Incorrecto"></asp:RegularExpressionValidator>
													 <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender13" 
																runat="server" FilterType="Numbers"
																TargetControlID="txtPeriodoRehabilitacionSP" ValidChars="">
													</cc1:FilteredTextBoxExtender>                                                     

					</td>

				</tr>

					<tr>  
					  <td class="auto-style29">
							Nro de Referencia de Suspension 
						</td>
						<td>
							<asp:TextBox ID="txtNureroSuspencionsP" runat="server" MaxLength="5"></asp:TextBox>
                            <asp:Label ID="lblObligatorio6" runat="server" Text="*" ForeColor="Red">*</asp:Label>
							<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender14" 
																runat="server" FilterType="Numbers"
																TargetControlID="txtNureroSuspencionsP" ValidChars="">
													</cc1:FilteredTextBoxExtender>                                                     

						  </td>
  
					  <td class="auto-style24">
							Nro de Referencia de Rehabilitacion 
						</td>
						<td>
							<asp:TextBox ID="txtNureroRehabilitacionSP" runat="server" MaxLength="5" ></asp:TextBox>
                            <asp:Label ID="lblObligatorio7" runat="server" Text="*" ForeColor="Red">*</asp:Label>
													   <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender15" 
																runat="server" FilterType="Numbers"
																TargetControlID="txtNureroRehabilitacionSP" ValidChars="">
													</cc1:FilteredTextBoxExtender>       
						  </td>
					</tr>

					<tr> 
						<td class="auto-style29">
							Observaciones de Suspensiones:
						</td>
						<td>
                            <asp:TextBox ID="txaObservacionSuspencionSPi" runat="server" Height="20px"  Width="300px" MaxLength="200" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="txaObservacionSuspencionSPi_FilteredTextBoxExtender"
                                runat="server" FilterType="Custom, LowercaseLetters, UppercaseLetters,Numbers"
                                TargetControlID="txaObservacionSuspencionSPi" ValidChars="'áéíóúÁÉÍÓÚñÑ.#/ ">
                            </cc1:FilteredTextBoxExtender>
						</td>
						<td class="auto-style24">
							Observaciones de Rehabilitacion:
						</td>
						<td>
                            <asp:TextBox ID="txaObservacionRehabilitacionSPi" runat="server" Height="20px"  Width="300px" MaxLength="200" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="txaObservacionRehabilitacionSPi_FilteredTextBoxExtender"
                                runat="server" FilterType="Custom, LowercaseLetters, UppercaseLetters,Numbers"
                                TargetControlID="txaObservacionRehabilitacionSPi" ValidChars="'áéíóúÁÉÍÓÚñÑ.#/ ">
                            </cc1:FilteredTextBoxExtender>
						</td>
					</tr>

				</table>
				<br/>
				 <div align="center"> <asp:Label ID="Label22" runat="server" Text="lb5"> Registrar Documentos Suspension Preventiva</asp:Label></div>
				<table align="center" style="border-color:black;width:800px; border:double;">
				<tr>
					<td>
						<asp:Label ID="Label23" runat="server" Text="">Típo Documento: </asp:Label>
					</td>
					<td class="auto-style28">
							<asp:DropDownList ID="ddlTipoDocumentoSP" Width="180px" runat="server" Height="22px" style="margin-right: 0px">
							</asp:DropDownList><font color="red">*</font>
					</td>
					
				</tr>
				<tr>
					<td>
						Nro. Hoja de Ruta: 
					</td>
						<td class="auto-style28">
						<asp:TextBox ID="txtNroDocumentoSP" runat="server" MaxLength="20" ></asp:TextBox>
						  <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender28" 
				        runat="server" FilterType="Custom,UppercaseLetters,LowercaseLetters,Numbers"
				        TargetControlID="txtNroDocumentoSP" ValidChars="/-">
				        </cc1:FilteredTextBoxExtender>
					        <font color="red">*</font></td>
										   
					<td class="auto-style27">
						Fecha Documento:
					</td>
							<td>
						<asp:TextBox ID="txtFechaDocumentoSP" runat="server" MaxLength="10" style="margin-left: 0px"></asp:TextBox>
                             <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender31" 
				            runat="server" FilterType="Numbers,Custom"
				            TargetControlID="txtFechaDocumentoSP" ValidChars="/">
				            </cc1:FilteredTextBoxExtender>
								   <font color="red">*</font><asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtFechaDocumentoSP" ID="RegularExpressionValidator11" ValidationExpression = "^\d{1,2}\/\d{1,2}\/\d{2,4}$" runat="server" ErrorMessage="Formato de Fecha Incorrecta"></asp:RegularExpressionValidator>
					</td>
					<td>
						<asp:Image ID="Image1" runat="server" Height="25px" ImageUrl="~/Imagenes/32calendario.png" Width="25px" ImageAlign="Top" Style="cursor:pointer"/>
						<cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtFechaDocumentoSP" PopupButtonID="Image1"
						OnClientDateSelectionChanged="function hideCalendar(cb) { cb.hide(); }" CssClass="cal_Theme1"></cc1:CalendarExtender>
						 
					</td>
				</tr>
				<tr>
					<td>
						<asp:Label ID="Label25" runat="server" Text="Label">Referencia: </asp:Label>
					</td>
					<td class="auto-style28">
						<textarea id="txaReferenciaDocumentoSP" cols="20" rows="2" runat ="server" onkeyup="this.value=this.value.toUpperCase()"> </textarea>
					</td>
				</tr>

				<tr>
					<td>
						<asp:Label ID="Label26" runat="server" Text="Label">Observaciones: </asp:Label>
					</td>
					<td class="auto-style28">
						<textarea id="txaObservacionDocumentoSP" cols="20" rows="2" runat ="server" onkeyup="this.value=this.value.toUpperCase()"></textarea>
					</td>
                    <td class="auto-style27">
						<asp:Button ID="btnAgregarDocTemp" runat="server" Visible =" true"
			            OnClientClick="javascript : return confirm('Esta seguro de realizar esta accion?');" 
			            Text="Agregar Documento" CssClass="boton150" OnClick="btnAgregarDocTemp_Click" Width="208px"/>
					</td>
				</tr>
                    <tr>
                        <td colspan="5">
                             <asp:GridView ID="gvDocTemp" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames ="IdDocumento" Font-Size="8pt" ForeColor="#333333"  Visible="False" OnRowCommand="gvDocTemp_RowCommand" >
					            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
					            <Columns>
							            <asp:BoundField DataField="Fila" HeaderText="NRO"></asp:BoundField>
							            <asp:BoundField DataField="TipoDocumento" HeaderText="TIPO DOCUMENTO"></asp:BoundField>
							            <asp:BoundField DataField="NumeroDocumento" HeaderText="NUMERO DOCUMENTO"></asp:BoundField>
							            <asp:BoundField DataField="FechaDocumento" HeaderText="FECHA DOCUMENTO"></asp:BoundField>
							            <asp:BoundField DataField="Referencia" HeaderText="REFERENCIA"></asp:BoundField>
							            <asp:BoundField DataField="Observaciones" HeaderText="OBSERVACIONES"></asp:BoundField>
                                        <asp:BoundField DataField="IdDocumento" HeaderText="ID DOCUMENTO" Visible="false"></asp:BoundField>
                                        <asp:ButtonField ButtonType="Image" CommandName="cmdEliminar" ImageUrl="~/Imagenes/16eliminar.png" Text="Eliminar" />
					            </Columns>
					            <EmptyDataTemplate>
						            <div align="center" class="CajaDialogoAdvertencia">
						            <br/>
						            <img src="../Imagenes/warning.gif" alt="No existen documentos Registrados para la suspension" />
						            <br/>"No existen documentos Registrados para la suspension<br/><br/>
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
 
			</table>
				
			<asp:Button ID="btnSuspencionPreventiva" runat="server" Visible =" true"
			OnClientClick="javascript : return confirm('Esta seguro de realizar esta accion?');" OnClick="btnSuspencionPreventiva_Click"
			Text="Aceptar" CssClass="boton150"/>
			
		   <asp:Button ID="btnRegistrarRehabilitacion" runat="server"  Visible="false"
			OnClientClick="javascript : return confirm('Esta seguro de realizar esta accion?');" OnClick="btnRegistrarRehabilitacion_Click"
			Text="ACEPTAR" CssClass="boton150"/>

			<asp:Button ID="btncerraSuspencionPreventica" runat="server" Text="Cerrar"  CssClass="boton150"/>
			</div>
			 </div>
			</asp:Panel>
			<cc1:RoundedCornersExtender ID="RoundedCornersExtender6" runat="server"
			Enabled="True" TargetControlID="panSP" Radius="10" BorderColor="Black">
			</cc1:RoundedCornersExtender>
			<cc1:ModalPopupExtender ID="mpeSP" runat="server"
			Enabled="True"
			TargetControlID="btnSP"
			CancelControlID="btncerraSuspencionPreventica"
			PopupControlID="panSP"
			BackgroundCssClass="modalBackground">
			</cc1:ModalPopupExtender>
			<asp:Button ID="btnModificaPreventiva" runat="server" Text="Modificar" style="display:none"/>    
			<asp:Panel ID="panModificaPreventiva" runat="server" CssClass="panelceleste"  HorizontalAlign="Center" Width="980px">
			<div>
			<div>
			<div align="center"> <asp:Label ID="Label21" runat="server" Text="lb5"> Modificar Suspension Preventiva</asp:Label></div>
				<asp:Label ID="lblIdSuspensionPreventiva" runat="server" Text="" Visible ="false"></asp:Label>
				<asp:Label ID="lblIdDocumento" runat="server" Text="" Visible ="false"></asp:Label>
				 <table  align="center" style="border-color:black;width:600px; border:double">
					<tr>
						<td>
							Estado:
						</td>
						<td>
							<asp:TextBox ID="TextBox1" runat="server" Text="SUSPENSION PREVENTIVA" Width="226px"></asp:TextBox>
						</td>
						<td>
							<asp:Label ID="lblIdSuspencionPreventiva" runat="server" Text="" Visible="false"></asp:Label>
						</td>
								  </tr>
				<tr>
						<td>
							Institucion:
						</td>
						<td colspan ="3">
							<asp:DropDownList ID="ddlInsitucionSPM" runat="server">
							</asp:DropDownList>
						</td>
					</tr>
				<tr>
					<td>Periodo de Suspension</td>
					<td>
						<asp:TextBox ID="txtPeriodoSuspencionSPM" runat="server" MaxLength="6"></asp:TextBox>

						    <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtPeriodoSuspencionSPM" ID="RegularExpressionValidator16" ValidationExpression = "^((([2][0-9][0-9][0-9]))(0[123456789]|10|11|12))$" runat="server" ErrorMessage="Periodo Incorrecto"></asp:RegularExpressionValidator>
						    
                            <asp:Image ID="Image8" runat="server" Height="25px" ImageUrl="~/Imagenes/32calendario.png" Width="25px" ImageAlign="Top" Style="cursor:pointer"/>
													    
                            <cc1:CalendarExtender ID="CalendarExtender10" runat="server" TargetControlID="txtPeriodoSuspencionSPM" PopupButtonID="Image8"
							Format="yyyyMM" Enabled="True" CssClass="cal_Theme1"></cc1:CalendarExtender> 
                            
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender16" 
								runat="server" FilterType="Numbers"
								TargetControlID="txtPeriodoSuspencionSPM" ValidChars="">
					    </cc1:FilteredTextBoxExtender>                                                     
						
					</td>
				<td>Periodo de Rehabilitacion</td>
					<td>
						<asp:TextBox ID="txtPeriodoDesactivacionSPM" runat="server" MaxLength="6" ></asp:TextBox>
						<asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtPeriodoDesactivacionSPM" ID="RegularExpressionValidator17" ValidationExpression = "^((([2][0-9][0-9][0-9]))(0[123456789]|10|11|12))$" runat="server" ErrorMessage="Periodo Incorrecto"></asp:RegularExpressionValidator>
						<asp:Image ID="Image9" runat="server" Height="25px" ImageUrl="~/Imagenes/32calendario.png" Width="25px" ImageAlign="Top" Style="cursor:pointer"/>
													    
                        <cc1:CalendarExtender ID="CalendarExtender11" runat="server" TargetControlID="txtPeriodoDesactivacionSPM" PopupButtonID="Image9"
					    Format="yyyyMM" Enabled="True" CssClass="cal_Theme1"></cc1:CalendarExtender> 
                             
                        

                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender17" 
								runat="server" FilterType="Numbers"
								TargetControlID="txtPeriodoDesactivacionSPM" ValidChars="">
					    </cc1:FilteredTextBoxExtender>    
					</td>

				</tr>

					<tr>  
					  <td>
							Nro de Referencia de Suspension 
						</td>
						<td>
							<asp:TextBox ID="txtNroReferenciaSupencionSPM" runat="server"></asp:TextBox>
							<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender18" 
																runat="server" FilterType="Numbers"
																TargetControlID="txtNroReferenciaSupencionSPM" ValidChars="">
													</cc1:FilteredTextBoxExtender>    
						  </td>
  
					  <td>
							Nro de Referencia de Rehabilitacion 
						</td>
						<td>
							<asp:TextBox ID="txtNroReferenciaRehabilitacionSPM" runat="server" MaxLength="5"></asp:TextBox>
							<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender19" 
																runat="server" FilterType="Numbers"
																TargetControlID="txtNroReferenciaRehabilitacionSPM" ValidChars="">
													</cc1:FilteredTextBoxExtender>  
						  </td>
					</tr>

					<tr> 
						<td>
							Observaciones de Suspensiones:
						</td>
						<td>
							<asp:TextBox ID="txtObservacionSuspencionSPM" runat="server" Height="50px"  Width="300px" MaxLength="4" onkeyup="this.value=this.value.toUpperCase()" TextMode="MultiLine"
                                onkeypress="return textboxMultilineMaxLength(this,500)"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="txtObservacionSuspencionSPM_FilteredTextBoxExtender"
                                runat="server" FilterType="Custom, LowercaseLetters, UppercaseLetters,Numbers"
                                TargetControlID="txtObservacionSuspencionSPM" ValidChars="'áéíóúÁÉÍÓÚñÑ.#/ ">
                            </cc1:FilteredTextBoxExtender>

						</td>
						<td>
							Observaciones de Rehabilitacion:
						</td>
						<td>
							
                             <asp:TextBox ID="txtObservacionDesactivacionSPM" runat="server" Height="50px"  Width="300px" MaxLength="200" onkeyup="this.value=this.value.toUpperCase()" TextMode="MultiLine"></asp:TextBox>

                            <cc1:FilteredTextBoxExtender ID="txtObservacionDesactivacionSPM_FilteredTextBoxExtender"
                                runat="server" FilterType="Custom, LowercaseLetters, UppercaseLetters,Numbers"
                                TargetControlID="txtObservacionDesactivacionSPM" ValidChars="'áéíóúÁÉÍÓÚñÑ.#/ " >
                            </cc1:FilteredTextBoxExtender>
						</td>
					</tr>

				</table>

			<asp:Button ID="btnModificaSuspencionPreventiva" runat="server" 
			OnClientClick="javascript : return confirm('Esta seguro de realizar esta accion?');" 
			Text="Aceptar" CssClass="boton150" OnClick="btnModificaSuspencionPreventiva_Click"/>

			<asp:Button ID="btnCierraPreventiva" runat="server" Text="Cerrar"  CssClass="boton150"/>
			</div>
			 </div>
			</asp:Panel>
			<cc1:RoundedCornersExtender ID="RoundedCornersExtender5" runat="server"
			Enabled="True" TargetControlID="panModificaPreventiva" Radius="10" BorderColor="Black">
			</cc1:RoundedCornersExtender>
			<cc1:ModalPopupExtender ID="mpeModificaPreventiva" runat="server"
			Enabled="True"
			TargetControlID="btnModificaPreventiva"
			CancelControlID="btnCierraPreventiva"
			PopupControlID="panModificaPreventiva"
			BackgroundCssClass="modalBackground">
			</cc1:ModalPopupExtender>
				
			<asp:Button ID="btnModificaDocumentoSPM" runat="server" Text="Modificar" style="display:none"/>    
			<asp:Panel ID="panModificaDocumentoSPM" runat="server" CssClass="panelceleste"  HorizontalAlign="Center" Width="980px">
				<div>
				
			<div>
			<div align="center" > <asp:Label ID="Label19" runat="server" Text="lb5"> Modificar Documento:</asp:Label></div>
					  <table align="center" style="border-color:black;width:600px; border:double;">
				<tr>
					<td>
						<asp:Label ID="Label28" runat="server" Text="">Típo Documento: </asp:Label>
					</td>
					<td>
							<asp:DropDownList ID="ddlTipoDocumentoSPM" Width="200px" runat="server">
							</asp:DropDownList>
					</td>
					<td>
						<asp:Label ID="lblDocumentoSPM" runat="server" Text=""></asp:Label>
					</td>                
				
				</tr>
				<tr>
					<td>
						Nro. Hoja de Ruta: 
					</td>
						<td>
						<asp:TextBox ID="txtNroDocumentoSPM" runat="server" MaxLength ="20" ></asp:TextBox>
							  <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender29" 
				        runat="server" FilterType="Custom,UppercaseLetters,LowercaseLetters,Numbers"
				        TargetControlID="txtNroDocumentoSPM" ValidChars="/-">
				        </cc1:FilteredTextBoxExtender>
					</td>
										   
					<td>
						Fecha Documento:
					</td>
							<td>
						<asp:TextBox ID="txtFechaDocumentoSPM" runat="server" MaxLength="10"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender32" 
				            runat="server" FilterType="Numbers,Custom"
				            TargetControlID="txtFechaDocumentoSPM" ValidChars="/-">
				            </cc1:FilteredTextBoxExtender>
						<asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtFechaDocumentoM" ID="RegularExpressionValidator13" ValidationExpression = "^\d{1,2}\/\d{1,2}\/\d{2,4}$" runat="server" ErrorMessage="Formato de Fecha Incorrecta"></asp:RegularExpressionValidator>
					</td>
					<td>
						<asp:Image ID="Image2" runat="server" Height="25px" ImageUrl="~/Imagenes/32calendario.png" Width="25px" ImageAlign="Top" Style="cursor:pointer"/>
						<cc1:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtFechaDocumentoSPM" PopupButtonID="Image2"
						OnClientDateSelectionChanged="function hideCalendar(cb) { cb.hide(); }"></cc1:CalendarExtender>
						 
					</td>
				</tr>
				<tr>
					<td>
						<asp:Label ID="Label30" runat="server" Text="Label">Referencia: </asp:Label>
					</td>
					<td>
						<textarea id="txareferenciaSPM" cols="20" rows="2" runat ="server" onkeyup="this.value=this.value.toUpperCase()"> </textarea>
					</td>
				</tr>

				<tr>
					<td>
						<asp:Label ID="Label31" runat="server" Text="Label">Observaciones: </asp:Label>
					</td>
					<td>
						<textarea id="txaObservacionDocumentoSPM" cols="20" rows="2" runat ="server" onkeyup="this.value=this.value.toUpperCase()"></textarea>
					</td>
				</tr>
 
			</table>
			<asp:Button ID="btnModificarSPM" runat="server" 
			OnClientClick="javascript : return confirm('Esta seguro de realizar esta accion?');"
			Text="Aceptar" CssClass="boton150" OnClick="btnModificarSPM_Click" />
			<asp:Button ID="btnCerrarSPM" runat="server" Text="Cerrar"  CssClass="boton150"/>
		   </div>
			
			 </div>
			</asp:Panel>
			<cc1:RoundedCornersExtender ID="RoundedCornersExtender7" runat="server"
			Enabled="True" TargetControlID="panModificaDocumentoSPM" Radius="10" BorderColor="Black">
			</cc1:RoundedCornersExtender>
			<cc1:ModalPopupExtender ID="mpeModificaDocumentoSPM" runat="server"
			Enabled="True"
			TargetControlID="btnModificaDocumentoSPM"
			CancelControlID="btnCerrarSPM"
			PopupControlID="panModificaDocumentoSPM"
			BackgroundCssClass="modalBackground">
			</cc1:ModalPopupExtender>	
       <asp:ImageButton ID="btnIrAtras" runat="server" ImageUrl="~/Imagenes/32anterior.png" Height="17px" Width="16px" OnClick="btnIrAtras_Click"/>
											<!--HASTA AQUI -->
      VOLVER A BUSCAR BENEFICIARIO
      
       <div aligin="center">
        <asp:Panel ID="panReporte" runat="server" CssClass="panelceleste"  HorizontalAlign="Center" style="overflow-y:scroll;" Height="550px" Width="1100px" Visible="false">
        <rsweb:ReportViewer ID="rtpInforme" runat="server"  Height="550px" Width="1100px" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Visible="false">
        </rsweb:ReportViewer>
        </asp:Panel>
        </div>
      </asp:Content>

