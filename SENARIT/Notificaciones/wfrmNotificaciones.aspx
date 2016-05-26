<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmNotificaciones.aspx.cs" Inherits="Notificaciones_wfrmNotificaciones" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1"%>
<%@ Register assembly="System.Web, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="System.Web.UI" tagprefix="cc2" %>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<!-- AQUI VA EL CODIGO-->
	<script type="text/javascript" language="javascript">
		function checkDate(sender, args) {
			if (sender._selectedDate > new Date()) {
				alert("¡Usted no puede seleccionar una fecha futura");
				document.getElementById('<%=txtFechaNotificacion.ClientID %>').value = "";
			}
		}
	 </script>
	<script type="text/javascript" language="javascript">
			function checkDateRec(sender, args) {
				if (sender._selectedDate > new Date()) {
					alert("¡La fecha no debe ser superior a la actual");
					document.getElementById('<%=txtFechaRecurso.ClientID %>').value = "";
			}
		}
	 </script>

		<table id="Table1" runat="server" align="left">
				   
				<!--integrando ambas tablas en una sola para q lo reconozca el cc1-->
			
			<tr>
			<td align="left" colspan="6">
			   <%-- <asp:ImageButton ID="imgAux" runat="server" ImageUrl="~/Imagenes/w.png" />--%>
				<asp:Label ID="Label2" runat="server" Font-Names="Arial" Font-Size="9pt"
					Text="Datos del Beneficiario" CssClass="etiqueta20" Font-Bold="true" Font-Underline="true"></asp:Label>
				<asp:Label ID="Label3" runat="server" Font-Size="Small" Text="1" 
					Visible="False"></asp:Label>
				<asp:Label ID="Label4" runat="server" Font-Size="Small" Text="1" 
					Visible="False"></asp:Label>
				<asp:Label ID="Label5" runat="server" Font-Size="Small" 
					style="text-align: left" Text="0" Visible="False"></asp:Label>
			</td>
		</tr>
		<tr>
			 <td align="left"><asp:label runat="server"  Font-Names="Arial" Font-Size="9pt" >Documento Identidad:</asp:label></td>
			 <td align="left"><asp:label runat="server"  Font-Names="Arial" Font-Size="9pt" >Fecha Nacimiento:</asp:label></td>
			 <td align="left"><asp:label runat="server"  Font-Names="Arial" Font-Size="9pt" >Apellido Paterno:</asp:label></td>
			 <td align="left"><asp:label runat="server"  Font-Names="Arial" Font-Size="9pt" >Apellido Materno:</asp:label></td>
			 <td align="left"><asp:label runat="server"  Font-Names="Arial" Font-Size="9pt" >Nombre:</asp:label></td>
		</tr>
		<tr>
			 <td align="left">
				 <asp:TextBox ID="txtCIC" runat="server" Font-Names="Arial" Font-Size="9pt" MaxLength="15" ReadOnly="true"></asp:TextBox>                           
			 </td>
			 <td align="left">
				<asp:TextBox ID="txtFechaNacC" runat="server" Font-Names="Arial" Font-Size="9pt" MaxLength="10" ReadOnly="true"></asp:TextBox>                           

						</td>
						<td align="left">
							<asp:TextBox ID="txtPaternoC" runat="server" Font-Names="Arial" Font-Size="9pt" MaxLength="20" ReadOnly="true"></asp:TextBox>                           
   
						</td>
						<td align="left">
							<asp:TextBox ID="txtMaternoC" runat="server" Font-Names="Arial" Font-Size="9pt" MaxLength="20" ReadOnly="true"></asp:TextBox>                           
 
						</td>
						<td align="left">
							<asp:TextBox ID="txtNombreC" runat="server" Font-Names="Arial" Font-Size="9pt" MaxLength="20" ReadOnly="true"></asp:TextBox>                           

						</td>
					</tr>
					<tr>
						<td align="left"><asp:Label runat="server" Font-Names="Arial" Font-Size="9pt">Trámite:</asp:Label></td>
						<td align="left"><asp:Label runat="server" Font-Names="Arial" Font-Size="9pt">Matrícula:</asp:Label></td>
						<td align="left"><asp:Label runat="server" Font-Names="Arial" Font-Size="9pt">Área Actual:</asp:Label></td>
						<%--<td align="left"> <asp:Label runat="server" Font-Names="Arial" Font-Size="9pt">Funcionario:</asp:Label></td>--%>
						<td align="left"><asp:Label runat="server" Font-Names="Arial" Font-Size="9pt">Regional:</asp:Label></td>
					</tr>
					<tr>
						<td align="left">
							<asp:TextBox ID="txtTramiteC" runat="server" Font-Names="Arial" Font-Size="9pt" MaxLength="15" ReadOnly="true"></asp:TextBox>                           

						</td>
						<td align="left">
							<asp:TextBox ID="txtMatriculaC" runat="server" Font-Names="Arial" Font-Size="9pt" MaxLength="12" ReadOnly="true"></asp:TextBox>                           

						</td>
						<td align="left">
							<asp:TextBox ID="txtDptoActual" runat="server" Font-Names="Arial" Font-Size="9pt" MaxLength="25" ReadOnly="true"></asp:TextBox>                           
						</td>
						<%--<td align="left">
							<asp:TextBox ID="txtFuncionarioC" runat="server" Font-Names="Arial" Font-Size="9pt"></asp:TextBox>                           

						</td>--%>
						<td align="left">
							<asp:TextBox ID="txtRegional" runat="server" Font-Names="Arial" Font-Size="9pt" MaxLength="20" ReadOnly="true"></asp:TextBox>                           

						</td>
					 </tr>
			<tr ><td colspan="6"><hr style="border-bottom-color:black"/></td></tr>  
					 <tr>   
						 <td align="left" colspan="6">
							<asp:Label ID="lblCoincidencias" runat="server" CssClass="text_obs" Font-Names="Arial" Font-Size="9pt" Font-Bold="true" Text="Documentos a Notificar:" Visible="false"></asp:Label>
						 </td>
					 </tr>
					 <tr>
						 <td width="100%" align="center" colspan="7">
							<asp:GridView ID="gvDatos" runat="server" AutoGenerateColumns="False"
								 Font-Names="Arial" 
								 Font-Size="9pt"
								 CssClass="mGrid"
								 AllowPaging="True"
								 OnPageIndexChanging="gvDatos_PageIndexChanging"
								 PagerStyle-CssClass="pgr"
								 AlternatingRowStyle-CssClass="alt"
								 Visible="False" DataKeyNames="IdTramite,IdGrupoBeneficio,FechaDocumento,NroDocumento,FechaNacimiento,PrimerApellido,
								SegundoApellido,PrimerNombre,NumeroDocumento,Matricula,Regional,IdDocumento,Direccion,IdTipoTramite,FechaNotificacion,FechaRecurso,Departamento,IdCodigo,IdEstadoTramite,FechaVencePlazo" 
								OnRowDataBound="gvCabecera_RowDataBound"  OnRowCommand="gvDetalle_OnRowCommand" >
								<Columns>
									<asp:BoundField DataField="IdTramite" HeaderText="Trámite"/>    <%-- 1 --%>
									<asp:BoundField DataField="TipoCC" HeaderText="Tipo CC" Visible="true"/>  <%-- 18 --%>
									<asp:BoundField DataField="IdGrupoBeneficio" HeaderText="GrupoBeneficio" Visible="false"/>  <%-- 2 --%>
									<asp:BoundField DataField="DescripcionDocumento" HeaderText="Documento" />  <%-- 3 --%>
									<asp:BoundField DataField="FechaDocumento" HeaderText="Fecha FormCC" />  <%-- 4 --%>
									<asp:BoundField DataField="NroDocumento" HeaderText="Nro FormCC" />   <%-- 5 --%>
									<asp:BoundField DataField="FechaCalculo" HeaderText="FechaCalculo" /> <%-- 6 --%>
									<asp:BoundField DataField="FechaNotificacion" HeaderText="Fecha Notificación"/>  <%-- 7 --%>
									<asp:BoundField DataField="FechaRecurso" />    <%-- 9 --%>
									<asp:BoundField DataField="FechaVencePlazo" HeaderText="Fecha Plazo" />    <%-- 10 --%>
									<asp:BoundField DataField="NumeroDocumento" HeaderText="Carnet" Visible="false"/>   <%-- 11 --%>
									<asp:BoundField DataField="FechaNacimiento" HeaderText="Nacimiento" Visible="false"/>   <%-- 12 --%>
									<asp:BoundField DataField="PrimerApellido" HeaderText="Paterno" Visible="false"/>   <%-- 13 --%>
									<asp:BoundField DataField="SegundoApellido" HeaderText="Materno" Visible="false"/>  <%-- 14 --%>
									<asp:BoundField DataField="PrimerNombre" HeaderText="Nombre" Visible="false"/>  <%-- 15 --%>
									<asp:BoundField DataField="Matricula" HeaderText="Matricula" Visible="false"/>  <%-- 16 --%>
									<asp:BoundField DataField="Departamento" HeaderText="Dpto" Visible="false"/>    <%-- 17 --%>
									<asp:BoundField DataField="Regional" HeaderText="Regional" Visible="false"/>    <%-- 19 --%>
									<asp:BoundField DataField="IdDocumento" HeaderText="IdDocumento" Visible="false"/>  <%-- 20 --%>
									<asp:BoundField DataField="Direccion" HeaderText="Direccion" Visible="false"/>  <%-- 21 --%>
									<asp:TemplateField HeaderText="Registrar"> 
									<HeaderStyle Width="70px" HorizontalAlign="Center" VerticalAlign="Middle" />
							<ItemTemplate>
								<center>
									<asp:ImageButton ID="imgNotificacion" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdNotificar" ImageUrl="~/imagenes/nueva3/inactivo32.png" Visible="true" Height="16" Width="16" ToolTip="Registrar Notificación"/>
									<asp:ImageButton ID="imgRecurso" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdRecurso" ImageUrl="~/imagenes/nueva3/activo32.png" Visible="false" Height="16" Width="16" ToolTip="Registrar Presentación Rev/Ren/Rec"/>
									<%--<asp:ImageButton ID="imgEliminar" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdEliminar" ImageUrl="~/imagenes/nueva3/eliminar32.png" Visible="false" Height="16" Width="16" ToolTip="Eliminar Recurso"/>--%> 
									<asp:ImageButton ID="imgEditar" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex  %>' CommandName="cmdEditar" ImageUrl="~/imagenes/16modificar.png" Height="16" Width="16" ToolTip="Editar Registro" Visible="false"/>
								</center>
							</ItemTemplate>
						</asp:TemplateField>
								<asp:TemplateField HeaderText="Codigo"  HeaderStyle-HorizontalAlign="Center"> 
									<HeaderStyle Width="70px" HorizontalAlign="Center" VerticalAlign="Middle" />
									<ItemTemplate>
								<asp:ImageButton runat="server" ID="btnImprimir"  OnClientClick="aspnetForm.target ='_blank';" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdImprimir" Text="Imprimir" ImageUrl="~/imagenes/nueva3/down_32.png" ImageAlign="Middle"/>
							</ItemTemplate>
							</asp:TemplateField>
						<asp:BoundField DataField="IdTipoTramite" Visible="false"/>    <%-- 22 --%>
						<asp:BoundField DataField="IdCodigo" Visible="false"/>  <%-- 23 --%>
                        <asp:BoundField DataField="IdEstadoTramite" Visible="false"/>  <%-- 24 --%>
						  </Columns>
								<EmptyDataTemplate>
									<div align="center" class="CajaDialogoAdvertencia">
									<br/>
									<img src="../Imagenes/warning.gif" alt="No Existeen Documentos por Notificar" />
									<br/>No Existe Formulario a ser Notificado<br/><br/>
									</div>
								</EmptyDataTemplate>
								<EditRowStyle BackColor="#999999" />
								<FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
								<HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
								<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
								<RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
								<SelectedRowStyle BackColor="#66ffff" Font-Bold="True" ForeColor="#000000" />
								<SortedAscendingCellStyle BackColor="#E9E7E2" />
								<SortedAscendingHeaderStyle BackColor="#506C8C" />
								<SortedDescendingCellStyle BackColor="#FFFDF8" />
								<SortedDescendingHeaderStyle BackColor="#6F8DAE" />
							</asp:GridView>
						</td>
					 </tr>

			<tr align="center">

				<td align="center" colspan="6">

				<asp:Panel ID="pnlRegistro" runat="server" CssClass="panelceleste"  HorizontalAlign="Center" Width="500px">
					<div>
						<asp:Label ID="lblNotificacion" runat="server" Text="Notificar Formulario" Font-Names="Arial" 
							CssClass="etiqueta20" Font-Size="14pt" Font-Underline="True"></asp:Label>
						<table style="width: 80%;">
							<tr>
								<td colspan="2"></td>
							</tr>
							<tr>
								<td align="right" class="auto-style5"><asp:Label ID="lblFecCalculo" runat="server" Text="Fecha Calculo" CssClass="etiqueta10" Font-Names="Arial" Font-Size="9pt"/></td>
								<td align="left" class="auto-style5"><asp:TextBox runat="server" ID="txtFecCalculo" Enabled="false" Width="100px"></asp:TextBox></td>
							</tr>
							<tr>
								<td colspan="2"></td>
							</tr>
							<tr>
								<td align="right" class="auto-style5">
									<asp:Label ID="lblFechaNotificacion" runat="server" Text="Fecha Notificación" CssClass="etiqueta10" Font-Names="Arial" Font-Size="9pt"></asp:Label>
								</td>
								<td align="left" class="auto-style5">
								   <asp:TextBox ID="txtFechaNotificacion" runat="server" Width="100px" Font-Names="Arial" Font-Size="9pt" MaxLength="10"></asp:TextBox>
									<cc1:FilteredTextBoxExtender ID="txtFecNotificacion_FilteredTextBoxExtender1" 
										runat="server" FilterType="Numbers,Custom"
										TargetControlID="txtFechaNotificacion" ValidChars="/">
									</cc1:FilteredTextBoxExtender>
									<asp:RegularExpressionValidator ID="RegularExpressionValidator1" ValidationGroup="ValNotificacion" runat="server" ControlToValidate="txtFechaNotificacion" Display="Dynamic" ErrorMessage="dd/mm/aaaa" ValidationExpression="^([\d]{2})/([\d]{2})/([\d]{4})$"
										Font-Size="9pt" Font-Names="Arial">
									  </asp:RegularExpressionValidator>
								   <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy" PopupButtonID="txtFechaNotificacion"   OnClientDateSelectionChanged="checkDate"
								   TargetControlID="txtFechaNotificacion" CssClass="cal_Theme1"></cc1:CalendarExtender>
									<asp:CompareValidator id="cvtxtStartDate" runat="server" controltocompare="txtFecCalculo" 
										cultureinvariantvalues="true" display="Dynamic" ValidationGroup="ValNotificacion"
										enableclientscript="true" controltovalidate="txtFechaNotificacion"
										errormessage="Fecha Notificacion no puede ser menor a fecha de calculo" 
										 type="Date" setfocusonerror="true" operator="GreaterThanEqual" text="Fecha Notificacion no puede ser menor a fecha de calculo" Font-Names="Arial" Font-Size="9pt"/>
									<asp:RequiredFieldValidator runat="server" ID="rValidator1" ControlToValidate ="txtFechaNotificacion" ErrorMessage="*" SetFocusOnError="true" ValidationGroup="ValNotificacion"></asp:RequiredFieldValidator>
								</td>
							</tr>
							<tr>
								<td colspan="2"></td>
							</tr>
							<tr>
								<td valign="top" align="right" class="auto-style5">
									<asp:Label ID="lblObs" runat="server" Text="Observación" Font-Names="Arial" Font-Size="9pt" CssClass="etiqueta10"></asp:Label>
								</td>
								<td align="left" class="auto-style5">
									<asp:TextBox ID="txtONotificar" runat="server" TextMode="multiline" Columns="28" Rows="5"  onfocus="selecciona_value(this)"></asp:TextBox>
									<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" 
										runat="server" FilterType="Numbers, UppercaseLetters, LowercaseLetters,Custom"
										TargetControlID="txtONotificar" ValidChars="/()., ">
									</cc1:FilteredTextBoxExtender>
<%--                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtONotificar" ErrorMessage="RequiredFieldValidator" ValidationGroup="ValNotificacion"
										Font-Size="9pt" Font-Names="Arial">*</asp:RequiredFieldValidator>--%>
								</td>
							</tr>
							<tr>
								<td colspan="2"></td>
							</tr>
							<tr>
							   <td>
								   <%--  <asp:Button ID="btnAccionarNotificar" runat="server" Text="Aceptar" OnClick="btnAccionarNotificar_Click"/>--%>
								</td>
								<td align="left">
								
									<asp:Button ID="btnAccionarNotificar" runat="server" Font-Names="Arial" Font-Size="9pt" ValidationGroup ="ValNotificacion" CausesValidation="true"
										Text="Aceptar" CssClass="boton150" OnClick="btnAccionarNotificar_Click"/>

									<cc1:ConfirmButtonExtender ID="btnGrabar_ConfirmButtonExtender" runat="server" TargetControlID="btnAccionarNotificar" ConfirmText="¿Esta seguro de guardar/modificar la Notificación?"> 
									</cc1:ConfirmButtonExtender>
									<asp:Button ID="btnCancelarNotificar" runat="server" CssClass="boton150" EnableTheming="True" Font-Names="Arial" Font-Size="9pt" Text="Cancelar" CausesValidation="false"/>
								</td>
							</tr>
						</table>

					</div>
				</asp:Panel>
				<cc1:RoundedCornersExtender ID="pnlRegistro_RoundedCornersExtender" runat="server"
					Enabled="True" TargetControlID="pnlRegistro" Radius="10" BorderColor="Black">
				</cc1:RoundedCornersExtender>
				<cc1:ModalPopupExtender ID="pnlNotificar" runat="server"
					Enabled="True"
					TargetControlID="lnkbtnNotificacion"
					CancelControlID="btnCancelarNotificar"
					PopupControlID="pnlRegistro"
					BackgroundCssClass="modalBackground">
				</cc1:ModalPopupExtender>
			</td>
			</tr>
			<tr align="center">

				<td align="center" colspan="6">

				<asp:Panel ID="pnlRecurso" runat="server" CssClass="panelceleste"  HorizontalAlign="Center" Width="500px">
					<div>
						<asp:Label ID="lblRecurso" runat="server"  Font-Names="Arial" 
							CssClass="etiqueta20" Font-Size="14pt" Font-Underline="True"></asp:Label>
						<table style="width: 80%;">
							<tr>
								<td colspan="2"><asp:RadioButtonList ID="rbAutmatico" runat="server" Visible ="false">
									<asp:ListItem Text="Revision" Value="1" Selected="True" />
									<asp:ListItem Text="Renuncia" Value="2"/>
								</asp:RadioButtonList></td>
							</tr>
							<tr>
								<td align="right" class="auto-style5">
									<asp:Label ID="lblFechaRecurso" runat="server" Text="Fecha Presentación" CssClass="etiqueta10" Font-Names="Arial" Font-Size="9pt"></asp:Label>
								</td>
								<td align="left" class="auto-style5">

								   <asp:TextBox ID="txtFechaRecurso" runat="server" Width="100px" Font-Names="Arial" Font-Size="9pt" MaxLength="10"></asp:TextBox>
									  <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ValidationGroup="ValRecurso" runat="server" ControlToValidate="txtFechaRecurso" Display="Dynamic" ErrorMessage="dd/mm/aaaa" ValidationExpression="^([\d]{2})/([\d]{2})/([\d]{4})$"
										Font-Size="9pt" Font-Names="Arial">
									  </asp:RegularExpressionValidator>
									<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtFechaRecurso" ErrorMessage="RequiredFieldValidator" ValidationGroup="ValRecurso"
										>*</asp:RequiredFieldValidator>
									<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" 
										runat="server" FilterType="Numbers,Custom"
										TargetControlID="txtFechaRecurso" ValidChars="/">
									</cc1:FilteredTextBoxExtender>
									<cc1:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" Format="dd/MM/yyyy" PopupButtonID="txtFechaRecurso" 
									TargetControlID="txtFechaRecurso" CssClass="cal_Theme1"  OnClientDateSelectionChanged="checkDateRec"></cc1:CalendarExtender>
								</td>
							</tr>
							<tr>
								<td colspan="2"></td>
							</tr>
							<tr>
								<td valign="top" align="right" class="auto-style5">
									<asp:Label ID="lblObsR" runat="server" Text="Observación" CssClass="etiqueta10" Font-Names="Arial" Font-Size="9pt"></asp:Label>
								</td>
								<td align="left" class="auto-style5">
									<asp:TextBox ID="txtORecurso" runat="server" TextMode="multiline" Columns="28" Rows="5"  onfocus="selecciona_value(this)"></asp:TextBox>
<%--                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtORecurso" ErrorMessage="RequiredFieldValidator" ValidationGroup="ValRecurso"
										Font-Size="9pt" Font-Names="Arial">*</asp:RequiredFieldValidator>.--%>
									<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" 
										runat="server" FilterType="Numbers, UppercaseLetters, LowercaseLetters,Custom"
										TargetControlID="txtORecurso" ValidChars=".,()/%" FilterMode="InvalidChars">
									</cc1:FilteredTextBoxExtender>
								</td>
							</tr>
							<tr>
								<td colspan="2"></td>
							</tr>
							<tr>
								<td></td>
								<td align="left">
								
									<asp:Button ID="btnAccionarRecurso" runat="server"
										Text="Aceptar" CssClass="boton150" OnClick="btnAccionarRecurso_Click" ValidationGroup="ValRecurso" CausesValidation="true"/>
									<cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="btnAccionarRecurso" ConfirmText="¿Esta seguro de guardar la presentación de recurso?"> 
									</cc1:ConfirmButtonExtender>
									<asp:Button ID="btnCancelarRecurso" runat="server" CssClass="boton150" EnableTheming="True" Text="Cancelar" CausesValidation="false"/>
								</td>
							</tr>
						</table>

					</div>
				</asp:Panel>
				<cc1:RoundedCornersExtender ID="pnlRecurso_RoundedCornersExtender" runat="server"
					Enabled="True" TargetControlID="pnlRecurso" Radius="10" BorderColor="Black">
				</cc1:RoundedCornersExtender>
				<cc1:ModalPopupExtender ID="pnlRecurso_Pop" runat="server"
					Enabled="True"
					TargetControlID="lnkbtnRecurso"
					CancelControlID="btnCancelarRecurso"
					PopupControlID="pnlRecurso"
					BackgroundCssClass="modalBackground">
				</cc1:ModalPopupExtender>
			</td>
			</tr>

			<%--<!--PRUEBA DE GRID EN POPUP-->--%>


			<tr><td><asp:Button ID="lnkbtnNotificacion" runat="server" Text="Notificación" style="display:none"></asp:Button></td>
				<td><asp:Button ID="lnkbtnRecurso" runat="server" Text="Recurso" style="display:none"></asp:Button></td>
				<td><asp:Button ID="Button1" runat="server" Text="Recurso" style="display:none"></asp:Button></td>
			</tr>
			<tr>
				<td colspan="6" align="left">
					<asp:HiddenField runat="server" ID="Tram"/>
					<asp:HiddenField runat="server" ID="gruBen"/>
					<asp:HiddenField runat="server" ID="FechaDoc"/>
					<asp:HiddenField runat="server" ID="NroDoc"/>
					<asp:HiddenField runat="server" ID="IdDoc"/>
					<asp:HiddenField runat="server" ID="Direccion"/>
					<asp:HiddenField runat="server" ID="TipoTram"/>
				    <asp:HiddenField runat="server" ID="FecPlazo"  />
				</td>
			</tr>
		   </table>

				
	
	<!-- AQUI VA EL CODIGO-->

</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="head">
	<style type="text/css">
		.boton150 {
			height: 25px;
		}
	</style>
</asp:Content>
