<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmTipoCambioConvenios.aspx.cs"
	Inherits="EmisionCertificadoCC_wfrmTipoCambioConvenios" Culture="auto" UICulture="auto" StylesheetTheme="Modal" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
	<style type="text/css">
		.CajaDialogo {}
	</style>
		<script type="text/javascript" language="javascript">
			function checkDate(sender, args) {
				if (sender._selectedDate > new Date()) {
					alert("¡Debe registrar la fecha Vigente");
					document.getElementById('<%=txtFechaCom.ClientID %>').value = "";
				}
			}
			</script>
	</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<table style="width: 60%;" class="panelceleste">
		<tr>
			<td align="center">
				<asp:ImageButton ID="imgAux" runat="server" ImageUrl="~/Imagenes/16w.png" />
				<asp:Label ID="lblTituloAUX" runat="server"
					Text="TIPO DE CAMBIO" CssClass="etiqueta20"></asp:Label>
				<asp:Label ID="lblCodigo" runat="server" Font-Size="Small" Text="1"
					Visible="False"></asp:Label>
				<asp:Label ID="lblCodUsuario" runat="server" Font-Size="Small" Text="1"
					Visible="False"></asp:Label>
				<asp:Label ID="lblRol" runat="server" Font-Size="Small"
					Style="text-align: left" Text="0" Visible="False"></asp:Label>
			   <%-- <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"> </cc1:ToolkitScriptManager>--%>
				<%--<asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True" EnableScriptLocalization="True" />--%>

			</td>
		</tr>

		<tr>
			<td>
				<asp:Panel ID="pnlGV" runat="server" HorizontalAlign="Center" Width="100%"
					CssClass="panelceleste">
					<table style="width: 100%;">
						  <tr>
							<td style="width: 20%" align="center" class="panelceleste">
								<asp:Panel ID="pnlNew" runat="server" Height="24px" Width="80px">
									<table style="width: 100%;">
										<tr>
											<td align="left">
												<asp:ImageButton ID="imgNuevo" runat="server" ImageUrl="~/Imagenes/nuevo.gif"
													TabIndex="10" OnClick="imgNuevo_Click" />
											</td>
										</tr>
									</table>
								</asp:Panel>
							</td>
						</tr>
						<tr>
							<td class="panelceleste">
								<asp:GridView ID="gvTipo" runat="server"
									AllowPaging="True"
									AutoGenerateColumns="false"
									HorizontalAlign="Center"
									OnPageIndexChanging="gvDatos_PageIndexChanging"
									SkinID="GridView"
									OnRowDataBound="gvTipo_RowDataBound"								 
									OnRowCommand="gvTipo_RowCommand" 
									Width="100%" DataKeyNames="IdMoneda,Fecha">

									<HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />

									<Columns>
										<asp:BoundField DataField="IdMoneda" HeaderText="IdMoneda" Visible="false"/> 
										<asp:BoundField DataField="Moneda" HeaderText="Moneda" /> 
										<asp:BoundField DataField="TasaCambio" HeaderText="Tipo Cambio" />
										<asp:BoundField DataField="Fecha" HeaderText="Fecha del Tipo de Cambio"/>
										<asp:BoundField DataField="ObservacionTasaCambio" HeaderText="Detalle Tipo de Cambio"/>
										<asp:BoundField DataField="RegistroActivo" HeaderText="RegistroActivo" Visible="false" />
									<asp:TemplateField HeaderText="Modificar"  HeaderStyle-HorizontalAlign="Center"> 
									<HeaderStyle Width="70px" HorizontalAlign="Center" VerticalAlign="Middle" />
							<ItemTemplate>
								<center>
									<asp:ImageButton ID="imgEditar" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex  %>' CommandName="cmdEditar" ImageUrl="~/imagenes/16modificar.png" Height="16" Width="16" ToolTip="Editar Registro" />
								</center>
							</ItemTemplate>
						</asp:TemplateField>
 
									</Columns>
								</asp:GridView>
							</td>
						</tr>
					 </table>
				</asp:Panel>
			</td>
		</tr>
		<tr>
			<td>
				<asp:Panel ID="pnlDatos" runat="server" CssClass="panelceleste" HorizontalAlign="Center" Width="60%">
						<div>
						<br />
						<asp:Label ID="lblTitulo" runat="server" Text="Adicionar Tipos de Cambios"
							CssClass="etiqueta20"></asp:Label>
						<table style="width: 100%;">
							<tr>
								<td align="right" style="width: 25%"> 
									 &nbsp;</td>
								<td align="left" style="width: 25%">
									&nbsp;</td>
								<td align="right" style="width: 10%">&nbsp;</td>
							</tr>

							<tr>
								<td align="right" style="width: 25%">
									<asp:Label ID="lblfechahoy" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="Fecha Tipo de Cambio:"></asp:Label>
								</td>
								<td align="left" style="width: 25%">
									<asp:TextBox ID="txtFechaCom" runat="server" Width="50%" Height="16px"></asp:TextBox>
									<asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtFechaCom" Display="Dynamic" ErrorMessage="--/--/----" ValidationExpression="^([\d]{2})/([\d]{2})/([\d]{4})$">
									  </asp:RegularExpressionValidator>
									<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" Enabled="True" FilterType="Numbers,Custom " TargetControlID="txtFechaCom" ValidChars="/">
									</cc1:FilteredTextBoxExtender>
									<cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" PopupButtonID="txtFechaCom" TargetControlID="txtFechaCom" OnClientDateSelectionChanged="checkDate">
									</cc1:CalendarExtender>
								</td>
								<td align="right" style="width: 10%">&nbsp;</td>
							</tr>

							<tr><td>&nbsp;</td></tr>

							<tr>
								<td align="right" style="width: 25%">
									<asp:Label ID="lblMoneda" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="Moneda :"></asp:Label>
								</td>
								<td align="left" style="width: 25%">
									<asp:DropDownList ID="ddlMoneda" runat="server" Width="51%" Height="18px">
									</asp:DropDownList>
  
								 </td>
								<td align="right" style="width: 10%">
									 &nbsp;</td>
							</tr>
							
							<tr>
								<td align="right">&nbsp;</td>
							</tr>
							<tr>
								<td align="right" >
									<asp:Label ID="lblTasaCambio" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="Tipo de Cambio :"></asp:Label>
								</td>
								<td align="left" >
									<asp:TextBox ID="txtTasaCambio" runat="server" Height="16px" MaxLength="8" Width="50%"></asp:TextBox>
									<cc1:FilteredTextBoxExtender ID="txtTasaCambio_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers, Custom" TargetControlID="txtTasaCambio" ValidChars=".">
									</cc1:FilteredTextBoxExtender>
									<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtTasaCambio" Display="Dynamic" ErrorMessage="Formato es: #.###" ValidationExpression="^([\d]{1,2}).([\d]{1,3})$">
									  </asp:RegularExpressionValidator>
								</td>
								<td align="right" >&nbsp;</td>
							</tr>
							<tr>
								<td align="right" >&nbsp;</td>
								<td align="right" >&nbsp;</td>
								<td align="right" >
									&nbsp;</td>
							</tr>
							<tr>
								<td align="right"><asp:Label ID="lblDetalle" runat="server" CssClass="etiqueta10" Style="text-align: left" Text="Detalle"></asp:Label></td>
								<td align="left"><asp:TextBox ID="txtDetalle" runat="server" TextMode="multiline" Columns="30" Rows="5"></asp:TextBox></td>
								<td align="right"  ></td>
							</tr>
														<tr>
								<td align="right"  ></td>
								<td align="left"  >
									&nbsp;</td>
								<td align="right"  ></td>
							</tr>

							<tr>
								<td align="right" style="width: 25%">
									<asp:Button ID="btnAccionar" runat="server" CssClass="boton150" OnClick="btnAccionar_Click" OnClientClick="javascript : return confirm('Esta seguro de realizar esta accion?');" Text="Adicionar" />
								</td>
								<td align="left" style="width: 10%">
									<asp:Button ID="btnCancelar" runat="server" CssClass="boton150" EnableTheming="True" OnClick="btnCancelar_Click" Text="Cancelar" />
								</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:ImageButton ID="imgVolver" runat="server"  ImageUrl="~/Imagenes/32Volver.png" ToolTip="Volver a la Página anterior" OnClick="btnVolver_Click"  CausesValidation="false"/>
                                </td>
                            </tr>
						</table>

					</div>
				</asp:Panel>
				<%--  <cc1:ModalPopupExtender ID="pnlDatos_ModalPopupExtender" runat="server" Enabled="True" TargetControlID="pnlDatos">
				</cc1:ModalPopupExtender>--%>
				<cc1:RoundedCornersExtender ID="pnlDatos_RoundedCornersExtender" runat="server"
					Enabled="True" TargetControlID="pnlDatos" Radius="10" BorderColor="Black">
				</cc1:RoundedCornersExtender>
				<cc1:ModalPopupExtender ID="pnlDatos_ModalPopupExtender" runat="server"
					Enabled="True"
					TargetControlID="lblTitulo"
					CancelControlID="btnCancelar"
					PopupControlID="pnlDatos"
					BackgroundCssClass="modalBackground">
				</cc1:ModalPopupExtender>
			</td>
		</tr>

	</table>
</asp:Content>

