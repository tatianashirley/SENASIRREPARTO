<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmInventario.aspx.cs" Inherits="ControlInventario_Inventario" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1"%>
<%@ Register assembly="System.Web, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="System.Web.UI" tagprefix="cc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" type="text/css" href="css/style.css"  />
        
    <script type="text/javascript" src="js/modernizr.custom.04022.js"></script>
    <style type="text/css">
        body {
        font-size: 15px;
        }
        .auto-style5 {
            width: 235px;
            height: 55px;
        }
        .auto-style6 {
            width: 215px;
        }
        .auto-style7 {
            width: 179px;
        }
        .auto-style10 {
            width: 228px;
        }
        .auto-style13 {
            width: 154px;
            height: 2px;
        }
        .auto-style14 {
            width: 228px;
            height: 2px;
        }
        .auto-style15 {
            width: 154px;
        }
        .auto-style20 {
            width: 266px;
        }
        .auto-style27 {
            width: 79px;
            height: 55px;
        }
        .auto-style28 {
            width: 148px;
            height: 55px;
        }
        .auto-style31 {
            width: 50px;
            height: 55px;
        }
        .auto-style34 {
            width: 187px;
            height: 55px;
        }
        .auto-style35 {
            width: 149px;
        }
        .auto-style36 {
            width: 149px;
            height: 55px;
        }
        .auto-style37 {
            width: 79px;
        }
        .auto-style39 {
            width: 91px;
            }
        .auto-style42 {
            width: 82px;
        }
        .auto-style44 {
            width: 162px;
            }
        .auto-style48 {
            width: 147px;
        }
    </style>
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

            function ValidarEstante()
            {
                 var nave = document.getElementById('<%=ddlNave1.ClientID%>').value;
                 alert(nave);
                 var estante = document.getElementById('<%=txtEstante1.ClientID%>').value;
                 alert(estante);
                 //getControls();
                 //var ctlGridViewProducts = document.getElementById('<%=gvUbicacion.ClientID%>');
                 alert(nave - 1);
                 //var currRow = ctlGridViewProducts.rows[nave - 1];

                 var GridView = document.getElementById('<%=gvUbicacion.ClientID%>');
                 var FirstName = GridView.rows[2].cells[1].children[0];
                 alert(FirstName);
                 // var minE = getCellValue(nave - 1, 1) //(grid.rows[nave - 1].cells[1].value);
                 //alert(minE);
                 //var maxE = getCellValue(nave - 1, 2)//(grid.rows[nave-1].cells[2].value);
                 //alert(maxE);
                 if (estante <= minE || estante >= maxE)
                 {
                     alert("Error al generar el reporte", "El codigo de estante esta fuera de rango porfavor revise la tabla de parametros gracias.");
                 }
            }

            var gridViewCtlId = '<%=gvUbicacion.ClientID%>';
            //var ctlGridViewProducts = null;

            function getControls() {
                if (null == ctlGridViewProducts) {
                    alert('entro1');
                    ctlGridViewProducts = document.getElementById(gridViewCtlId);
                }
            }

        </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
                                            <!--DESDE AQUI SE PUDE PERSONALIZAR-->
     <table width="100%">
        <tr>
            <td width="100%" align="center" style="background-color:#5D7B9D;" >
                <FONT COLOR="white">
                <label onclick="btnOpenCloseBusqueda_Click"><h3><asp:ImageButton ID="btnOpenCloseBusqueda" runat="server" ImageUrl="~/Imagenes/16quitar.png" OnClick="btnOpenCloseBusqueda_Click" /> BUSQUEDA DE ARCHIVO</h3></label>
            </td>
        </tr>
    </table>
    <asp:Panel ID="pnlBusqueda" runat="server" Visible="true" Width="100%" HorizontalAlign="Center" Enabled="true">
    <table width="100%">
        <tr>
            <td  align="right" colspan="1" class="auto-style1">
                Primer Apellido: <asp:TextBox ID="txtPrimerApellido" Width="150px" runat ="server" onkeyup="this.value=this.value.toUpperCase()" MaxLength="20"></asp:TextBox>
                
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" 
				runat="server" FilterType="LowercaseLetters,UppercaseLetters"
				TargetControlID="txtPrimerApellido" ValidChars="">
	            </cc1:FilteredTextBoxExtender>  

            </td>
            <td width="40%" align="right" colspan="1">
                Segundo Apellido: <asp:TextBox ID="txtSegundoApellido"  Width="150px" runat="server" onkeyup="this.value=this.value.toUpperCase()" MaxLength="20"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" 
				runat="server" FilterType="LowercaseLetters,UppercaseLetters"
				TargetControlID="txtSegundoApellido" ValidChars="">
	            </cc1:FilteredTextBoxExtender>  
            </td>
            <td class="auto-style1" >

            </td>
        </tr>
        <tr>
            <td width="40%" align="right" colspan="1">
                Nombres: <asp:TextBox ID="txtNombres1" runat="server" Width="150px" onkeyup="this.value=this.value.toUpperCase()" MaxLength="10"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" 
				runat="server" FilterType="LowercaseLetters,UppercaseLetters"
				TargetControlID="txtNombres1" ValidChars="">
	            </cc1:FilteredTextBoxExtender> 
            </td>
            <td width="40%" align="right" colspan="1">
                Nro Tramite: <asp:TextBox ID="txtNroTramite" runat="server" Width="150px"  MaxLength="10"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" 
				runat="server" FilterType="Custom,Numbers,LowercaseLetters,UppercaseLetters"
				TargetControlID="txtNroTramite" ValidChars="/-">
	            </cc1:FilteredTextBoxExtender> 
            </td>
            <td width="20%">

            </td>
        </tr>
        <tr>
            <td width="40%" align="right" colspan="1">
                Documento de Identidad: <asp:TextBox ID="txtCI" runat="server" Width="150px" MaxLength="15" ></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="ftetxtCI" 
							    runat="server" FilterType="Numbers"
							    TargetControlID="txtCI" ValidChars="">
				</cc1:FilteredTextBoxExtender> 
            </td>
            <td width="40%" align="right" colspan="1">
                Matrícula: <asp:TextBox ID="txtMatricula" runat="server" Width="150px" onkeyup="this.value=this.value.toUpperCase()" MaxLength="15"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" 
				runat="server" FilterType="Numbers,LowercaseLetters,UppercaseLetters"
				TargetControlID="txtMatricula" ValidChars="">
	            </cc1:FilteredTextBoxExtender> 

            </td>
            <td width="20%">

            </td>
        </tr>
        <tr>
            <td width="40%" align="center" colspan="2">
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" Width="100px" OnClick="btnBuscar_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" Width="100px" OnClick="btnLimpiar_Click1"  />
            </td>
            <td width="20%">
            </td>
        </tr>
    </table>
    </asp:Panel>
    <table width="100%">
        <tr>
            <td width="100%" align="center" style="background-color:#5D7B9D;" >
                <FONT COLOR="white">
              <label onclick="btnOpenCloseCoincidencias_Click"><h3><asp:ImageButton ID="btnOpenCloseCoincidencias" runat="server" ImageUrl="~/Imagenes/16quitar.png" OnClick="btnOpenCloseCoincidencias_Click" /> COINCIDENCIAS DE BUSQUEDA</h3></label>  
            </td>
        </tr>
        <tr>
            <td width="100%" align="center">
            <asp:Panel ID="pnlCoincidencias" runat="server" Visible="true" Width="100%" HorizontalAlign="Center" Enabled="true">
            <table  width="100%">
                <tr>
                 <td width="100%" align="center">

                <asp:GridView ID="gvBusqueda" runat="server" CellPadding="4" ForeColor="#0000ff" AutoGenerateColumns="False" Visible="False" Font-Size="9pt" OnSelectedIndexChanged="gvBusqueda_SelectedIndexChanged" Font-Names="Arial" DataKeyNames="IdBeneficio">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:BoundField DataField="Fila" HeaderText="Nro" />
                        <asp:BoundField DataField="Tramite" HeaderText="Tramite" />
                        <asp:BoundField DataField="Matricula" HeaderText="Matricula" />
                        <asp:BoundField DataField="NumeroDocumento" HeaderText="Nro Documento" />
                        <asp:BoundField DataField="PrimerApellido" HeaderText="Paterno" />
                        <asp:BoundField DataField="SegundoApellido" HeaderText="Materno" />
                        <asp:BoundField DataField="PrimerNombre" HeaderText="Primer Nombre" />
                        <asp:BoundField DataField="SegundoNombre" HeaderText="Segundo Nombre" />
                        <asp:BoundField DataField="Beneficio" HeaderText="Beneficio" />
                        <asp:BoundField DataField="AreaEncuentra" HeaderText="AreaEncuentraTramite" />
                        <asp:BoundField DataField="EstadoTramite" HeaderText="EstadoTramite" />
                        <asp:BoundField DataField="IdBeneficio" HeaderText="IdBeneficio" Visible="false"/>

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
                    
                    <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#0066CC" Font-Bold="True" ForeColor="#CCFFFF" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
            </td>
        </tr>
    </table>
    </asp:Panel>
    </td>
     </tr>

        <tr>
            <td align="center" style="background-color:#5D7B9D;">
            <FONT COLOR="white">
            <label onclick="btnOpenCloseResultado_Click"><h3><asp:ImageButton ID="btnOpenCloseResultado" runat="server" ImageUrl="~/Imagenes/16quitar.png" OnClick="btnOpenCloseResultado_Click" /> RESULTADOS DE BUSQUEDA</h3></label>
            </td>
        </tr>
         <tr>
            <td width="100%" align="center">
                 <asp:Panel ID="pnlResultado" runat="server" Visible="true" Width="100%" HorizontalAlign="Center" Enabled="false">
                    <table width="100%">
                <tr>    
                    <td align="right"><asp:Label ID="lblPeriodoInicioTGN" runat="server" Text="Matricula:" ></asp:Label> </td>
                    <td align="left" class="auto-style6" >
                        <asp:TextBox ID="txtmatricula1" runat="server" Height="20px" Width="143px" ></asp:TextBox>
                     </td>
                    <td align="right"><asp:Label ID="lblPeriodoFinDevolucion" runat="server" Text="Tramite:"></asp:Label> </td>
                        
                    <td align="left" class="auto-style7">
                        <asp:TextBox ID="txttramite" runat="server" Height="20px" Width="143px" onkeypress="return permite(event, 'num')"></asp:TextBox>
                      </td>
                         <td align="right">Carnet:</td>
                    <td align="left" class="auto-style6" >
                        <asp:TextBox ID="txtCarnet" runat="server" onchange="Actualizar('<%=txtNumeroLiquidacion.ClientID%>');" onkeypress="return permite(event, 'num')" Height="20px" Width="143px"></asp:TextBox>
                    </td>
                </tr> 
                <tr>    
                    <td align="right">Funcionario:</td>
                    <td align="left" class="auto-style6" >
                        <asp:TextBox ID="txtFuncionario" runat="server" onchange="Actualizar('<%=txtNumeroLiquidacion.ClientID%>');" onkeypress="return permite(event, 'num')" Height="20px" Width="143px"></asp:TextBox>
                    </td>
                    <td align="right">
                        Fecha de ingreso al Area</td>
                    <td align="left">
                        <asp:TextBox ID="txtFechaIngreso" runat="server" Height="20px" Width="143px"></asp:TextBox>
                    </td>
                    <td align="right">
                        Expediente</td>
                    <td align="left">
                        <asp:TextBox ID="txtExpediente" runat="server"  Height="20px" Width="144px" ForeColor="Red"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">Paterno:</td>
                    <td align="left" class="auto-style6">
                        <asp:TextBox ID="txtPaterno" runat="server" Width="143px" Height="20px" ></asp:TextBox>
                    </td>     
                     <td align="right">Materno:</td>
                    <td align="left" class="auto-style6">
                        <asp:TextBox ID="txtMaterno" runat="server" Width="143px"  Height="20px" ></asp:TextBox>
                    </td> 
                     <td align="right">Nombres: </td>
                    <td align="left" class="auto-style6">
                        <asp:TextBox ID="txtNombres" runat="server" Width="143px" Height="20px" ></asp:TextBox>
                    </td>               
                </tr>
                         <tr>
                    <td align="right">Departamento Actual: </td>
                    <td align="left" class="auto-style6">
                        <asp:TextBox ID="txtDpto" runat="server" Width="200px" Height="20px" ></asp:TextBox>
                    </td>     
                     <td align="right">Regional: </td>
                    <td align="left" class="auto-style6">
                        <asp:TextBox ID="txtRegional" runat="server" Width="143px"  Height="20px" ></asp:TextBox>
                    </td> 
                     <td align="right">Regimen</td>
                    <td align="left" class="auto-style6">
                        <asp:TextBox ID="txtRegimen" runat="server" Width="143px" Height="20px" ></asp:TextBox>
                        
                    </td> 
                                           
                </tr>
              <tr>
                <td align="right">Sector</td>
                <td align="left" class="auto-style6">
                    <asp:TextBox ID="txtSector" runat="server" Width="143px" Height="20px" ></asp:TextBox>
                </td> 
                <td align="right">Clase Renta</td>
                <td align="left" class="auto-style6">
                    <asp:TextBox ID="txtClaseRenta" runat="server" Width="143px" Height="20px" ></asp:TextBox>
                </td> 
              </tr>
            </table>
            </asp:Panel>
              <asp:Button ID="btnGrupoFamiliar" runat="server" Text="Ver Grupo Fammiliar" Width="150px" OnClick="btnGrupoFamiliar_Click"/>    
            </td>
        </tr>
    
         <tr>
           <td width="100%" align="center" style="background-color:#5D7B9D;" >
                <FONT COLOR="white">
                <label onclick="btnOpenCloseDatos_Click"><h3><asp:ImageButton ID="btnOpenCloseDatos" runat="server" ImageUrl="~/Imagenes/16quitar.png" OnClick="btnOpenCloseDatos_Click" /> DATOS DE UBICACION DEL EXPEDIENTE</h3></label>
            </td>
        </tr>
        <tr>
            <td>
                 <asp:Panel ID="pnlDatosUbicacion" runat="server" Visible="true" Width="100%" HorizontalAlign="Center" BorderColor="Black" BorderWidth="5">
                 <table width="100%" border="0">
                     <tr>
                          <td class="auto-style15">Nave</td>
                          <td class="auto-style10"> <asp:DropDownList ID="ddlNave1" runat="server" Height="19px" Width="235px" style="text-align:center"></asp:DropDownList></td>
                         <td></td>
                         <td rowspan ="4">
                             <asp:GridView ID="gvUbicacion" runat="server" CellPadding="4" ForeColor="#0000ff"  AutoGenerateColumns="False" Visible="False" Font-Size="9pt">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:BoundField DataField="Nave" HeaderText="Nave" />
                                <asp:BoundField DataField="EstanteInicio" HeaderText="EstanteIni" />
                                <asp:BoundField DataField="EstanteFin" HeaderText="EstanteFin" />
                                <asp:BoundField DataField="CajaInicio" HeaderText="CajaIni" />
                                <asp:BoundField DataField="CajaFin" HeaderText="CajaFin" />
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
                            <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#0066CC" Font-Bold="True" ForeColor="#CCFFFF" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView>

                         </td>
                     </tr>  
                     <tr>
                         <td class="auto-style15">
                             Estante
                         </td>
                         <td class="auto-style10">
                            <asp:TextBox ID="txtEstante1" runat="server" Width="300px" MaxLength="10" style="text-align:center"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" 
				            runat="server" FilterType="Numbers"
				            TargetControlID="txtEstante1" ValidChars="">
	                        </cc1:FilteredTextBoxExtender>  
                         </td>
                     </tr>
                     <tr>
                         <td class="auto-style13">
                             Codigo Caja
                         </td>
                         <td class="auto-style14">
                            <asp:TextBox ID="txtCodigoCaja1" runat="server" Width="300px" MaxLength="50" style="text-align:center"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" 
				            runat="server" FilterType="Custom,Numbers"
				            TargetControlID="txtCodigoCaja1" ValidChars="/ -">
	                        </cc1:FilteredTextBoxExtender>  
                         </td>
                     </tr>
                     <tr>
                         <td class="auto-style15">
                             Codigo Caja Anterior
                         </td>
                         <td class="auto-style10">
                            <asp:TextBox ID="txtCodigoCajaAnterior" runat="server" Width="300px" MaxLength="50" style="text-align:center"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" 
				            runat="server" FilterType="UppercaseLetters,Numbers,Custom"
				            TargetControlID="txtCodigoCajaAnterior" ValidChars="/- ">
	                        </cc1:FilteredTextBoxExtender>  
                         </td>
                     </tr>
                     <tr>
                         <td class="auto-style15">
                             Codigo Digitalizacion
                         </td>
                         <td class="auto-style10">
                            <asp:TextBox ID="txtCodigoDigitalizacion" runat="server" Width="300px" MaxLength="50" style="text-align:center"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" 
				            runat="server" FilterType= "Numbers,UppercaseLetters,LowercaseLetters"
				            TargetControlID="txtCodigoDigitalizacion" ValidChars="">
	                        </cc1:FilteredTextBoxExtender> 
                         </td>
                         <td>
                             <asp:Button ID="btnGuardarUbicacion" runat="server" Text="Guardar Ubicacion" OnClick="btnGuardarUbicacion_Click"  OnClientClick="javascript : return confirm('Esta seguro de cancelar? se perderan los datos no guardados');" Width="150px" />
                         </td>
                         <td>
                             <asp:Button ID="btnAsignacionExpediente" runat="server" Text="Asignar Expediente" Width="150px" OnClick="btnAsignacionExpediente_Click" />
                         </td>
                     </tr>
                     <tr><td class="auto-style15">
                             Tipo Observacion
                         </td>
                         
                         <td class="auto-style10">
                              <asp:TextBox ID="txtTipoObservacion" runat="server" Width="300px" MaxLength="200" style="text-align:center"></asp:TextBox>
                         </td>
                         
                         <td>

                             <asp:Button ID="btnModificaUbicacion" runat="server" Text="Modifica Ubicacion" OnClick="btnModificaUbicacion_Click"  OnClientClick="javascript : return confirm('Esta seguro de Modificar la Ubicación?');" Width="150px" />

                         </td>
                          <td>
                             <asp:Button ID="btnDevolucionExpediente" runat="server" Text="Devolucion Expediente" Width="150px" OnClick="btnDevolucionExpediente_Click"  />
                         </td>
                     </tr>
                     <tr><td class="auto-style15">
                            Observacion
                         </td>
                         
                         <td class="auto-style10">
                            <asp:TextBox ID="txtObservacion" runat="server" Width="300px" MaxLength="200" style="text-align:center"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender12" 
				            runat="server" FilterType="Custom,Numbers,UppercaseLetters,LowercaseLetters"
				            TargetControlID="txtObservacion" ValidChars=",./">
	                        </cc1:FilteredTextBoxExtender> 
                         </td>
                
                        <td>
                             <asp:Button ID="btnReUbicacion" runat="server" Text="Re Ubicacion" OnClick="btnReUbicacion_Click"  OnClientClick="javascript : return confirm('Esta seguro de Rehubicar el expediente?');" Width="150px" />

                         </td>
                     </tr>
                </table>
          </asp:Panel>
            </td>
          </tr>
          
           <tr>
           <td width="100%" align="center" style="background-color:#5D7B9D;" >
                <FONT COLOR="white">
                <label onclick="btnOpenCloseDetalles_Click"><h3><asp:ImageButton ID="btnOpenCloseDetalles" runat="server" ImageUrl="~/Imagenes/16quitar.png" OnClick="btnOpenCloseDetalles_Click" /> DETALLES EXTRAS</h3></label>
            </td>
            </tr> 
        <tr>
            <td>

            <asp:Panel ID="pnlDetalle" runat="server" Visible="true" Width="100%" Height="100%" HorizontalAlign="Center" BorderColor="Black" BorderWidth="5">
            <table width="100%" border="0">
         <tr>
            <td width="100%" align="left" class="auto-style5">
                <asp:LinkButton ID="lnkHistorialArchivo" runat="server" OnClick="lnkHistorialArchivo_Click" Font-Bold="True" ForeColor="#0066CC" Visible="true">Ver Historial de Archivo</asp:LinkButton>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="lnkNave" runat="server" OnClick="lnkNave_Click"  Font-Bold="True" ForeColor="#0066CC" Visible="true" >Ver Naves</asp:LinkButton>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="lnkCaja" runat="server" OnClick="lnkCaja_Click"  Font-Bold="True" ForeColor="#0066CC" Visible="true">Ver caja</asp:LinkButton>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="lnkListadoInventario" runat="server" OnClick="lnkListadoInventario_Click" Font-Bold="True" ForeColor="#0066CC" Visible="true">Listado Inventario</asp:LinkButton>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="lnkHistorialAsignacion" runat="server" OnClick="lnkHistorialAsignacion_Click" Font-Bold="True" ForeColor="#0066CC" Visible="true">Historial Asignacion</asp:LinkButton>
            </td>
        </tr>
           <tr>
            <td width="100%" align="center">
                
                <asp:MultiView ID="MultiView1" runat="server" Visible="False">
                    <asp:View ID="Historial" runat="server">

                        <asp:Label ID="lblPagos" runat="server" Text="Historial de Archivo" Font-Underline="True" Font-Size="14pt" ForeColor="#0066CC"></asp:Label>
                  
                        
                            <asp:GridView ID="gvHistorial" runat="server" CellPadding="4" ForeColor="#0000ff" AutoGenerateColumns="False" Font-Size="10pt">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775"  HorizontalAlign="Center" />
                           <Columns>
                                <asp:BoundField DataField="Historial" HeaderText="Historial"  />
                                <asp:BoundField DataField="Nave" HeaderText="Nave" />
                                <asp:BoundField DataField="Estante" HeaderText="Estante" />
                                <asp:BoundField DataField="CodCaja" HeaderText="Cod Caja" />
                                <asp:BoundField DataField="CajaHist" HeaderText="Cod Historiaca" />
                                <asp:BoundField DataField="Observacion" HeaderText="Observacion" />
                                <asp:BoundField DataField="Estado" HeaderText="Estado"/>
                                <asp:BoundField DataField="FechaReg" HeaderText="FechaReg" />
                                <asp:BoundField DataField="FechaMod" HeaderText="FechaMod" />
                                <asp:BoundField DataField="UsuarioReg" HeaderText="Registrado" />
                                <asp:BoundField DataField="UsuarioMod" HeaderText="Modificador" />
                                </Columns>
                            <EmptyDataTemplate>
                                <div align="center" class="CajaDialogoAdvertencia">
                                <br/>
                                <img src="../Imagenes/warning.gif" alt="El asegurado no cuenta con derechohabientes" />
                                <br/>No existe historial del Archivo<br/><br/>
                                </div>
                            </EmptyDataTemplate>
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                            
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333"  HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView>
                  
                    </asp:View>
                    <asp:View ID="Naves" runat="server">
                        <asp:Label ID="lblConciliacion" runat="server" Text="Naves" Font-Underline="True" Font-Size="14pt" ForeColor="#0066CC"></asp:Label>
                        	<div class="container">
			                        <div class="sp-slideshow">
				                        <input id="button-1" type="radio" name="radio-set" class="sp-selector-1" checked="checked" />
				                        <label for="button-1" class="button-label-1"></label>
				
				                        <input id="button-2" type="radio" name="radio-set" class="sp-selector-2" />
				                        <label for="button-2" class="button-label-2"></label>
				
				                        <input id="button-3" type="radio" name="radio-set" class="sp-selector-3" />
				                        <label for="button-3" class="button-label-3"></label>
				
				                        <input id="button-4" type="radio" name="radio-set" class="sp-selector-4" />
				                        <label for="button-4" class="button-label-4"></label>
				
				                        <input id="button-5" type="radio" name="radio-set" class="sp-selector-5" />
				                        <label for="button-5" class="button-label-5"></label>
				
				                        <label for="button-1" class="sp-arrow sp-a1"></label>
				                        <label for="button-2" class="sp-arrow sp-a2"></label>
				                        <label for="button-3" class="sp-arrow sp-a3"></label>
				                        <label for="button-4" class="sp-arrow sp-a4"></label>
				                        <label for="button-5" class="sp-arrow sp-a5"></label>
				
				                        <div class="sp-content">
					                        <div class="sp-parallax-bg"></div>
					                        <ul class="sp-slider clearfix">
						                        <li><img src="images/nave1.png" alt="nave1" width="900px" height="600px" /></li>
						                        <li><img src="images/nave1.png" alt="nave2" width="900px" height="600px" /></li>
						                        <li><img src="images/nave1.png" alt="nave3" width="900px" height="600px" /></li>
						                        <li><img src="images/nave1.png" alt="nave4" width="900px" height="600px" /></li>
						                        <li><img src="images/nave1.png" alt="nave5" width="900px" height="600px" /></li>
					                        </ul>
				                        </div>
			                        </div>
		                        </div>
                    </asp:View>
                    <asp:View ID="Caja" runat="server">

                        <asp:Label ID="lblReposicion" runat="server" Text="Caja" Font-Underline="True" Font-Size="14pt" ForeColor="#0066CC"></asp:Label>

                        <asp:GridView ID="gvGrupo" runat="server" CellPadding="4" ForeColor="#0000ff" AutoGenerateColumns="False" Font-Size="10pt">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:BoundField DataField="Fila" HeaderText="Nro." />
                                <asp:BoundField DataField="Asegurado" HeaderText="Asegurado" />
                                <asp:BoundField DataField="Nave" HeaderText="Nave" />
                                <asp:BoundField DataField="Estante" HeaderText="Estante" />
                                <asp:BoundField DataField="CodCaja" HeaderText="Cod Caja" />
                                <asp:BoundField DataField="CajaHist" HeaderText="CajaHist" />
                                <asp:BoundField DataField="CodDigit" HeaderText="Cod Digit" />
                                <asp:BoundField DataField="Estado" HeaderText="Estado" />
                                <asp:BoundField DataField="FechaReg" HeaderText="FechaReg" />
                                <asp:BoundField DataField="FechaMod" HeaderText="FechaMod" />
                                <asp:BoundField DataField="UsuarioReg" HeaderText="Registrado" />
                                <asp:BoundField DataField="UsuarioMod" HeaderText="Modificador" />
                                <asp:BoundField  DataField="IdUsuarioAsignado" HeaderText="Usuario Asignado" />
                            </Columns>
                            <EmptyDataTemplate>
                                <div align="center" class="CajaDialogoAdvertencia">
                                <br/>
                                <img src="../Imagenes/warning.gif" alt="El asegurado no cuenta con derechohabientes" />
                                <br/>No existe Archivos en la Caja<br/><br/>
                                </div>
                            </EmptyDataTemplate>
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView>
                    </asp:View>
                     <asp:View ID="Inventario" runat="server">
                        <asp:Label ID="Label1" runat="server" Text="Listado Inventario" Font-Underline="True" Font-Size="14pt" ForeColor="#0066CC"></asp:Label>
                          <table border="1" style="border-color:black; border-left:double">
                            <tr>
                                <td colspan ="2">GENERAR LISTA DE  ESTANTES Y CAJAS</td>
                            </tr>
                            <tr>
                                <td>
                                    Nave
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlnave" runat="server"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Estante
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEstante" runat="server" style="text-align:center"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender13" 
				                    runat="server" FilterType="Numbers"
				                    TargetControlID="txtEstante" ValidChars="">
	                                </cc1:FilteredTextBoxExtender> 
                                </td>
                            </tr>
                            <tr>
                                <td>
                                   Codigo Caja
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCodigoCaja" runat="server" style="text-align:center"></asp:TextBox>
                                     <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender14" 
				                    runat="server" FilterType="Numbers"
				                    TargetControlID="txtCodigoCaja" ValidChars="">
	                                </cc1:FilteredTextBoxExtender> 
                                </td>
                            </tr>
                              <tr>
                                  <td colspan ="2">
                                      <asp:Button runat="server" id="btnReporte" Text="GENERAR REPORTE"  OnClick="btnReporte_Click"/>
                                  </td>
                              </tr>
                        </table>
                    </asp:View>
                    <asp:View ID="Asignacion" runat="server">
                        <asp:Label ID="Label6" runat="server" Text="Historial de Asignacion del Archivo" Font-Underline="True" Font-Size="14pt" ForeColor="#0066CC"></asp:Label>

                        <asp:GridView ID="gvHistorialAsignacion" runat="server" CellPadding="4" ForeColor="#0000ff" AutoGenerateColumns="False" Font-Size="10pt">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:BoundField DataField="Fila" HeaderText="Nro." />
                                <asp:BoundField DataField="UsuarioAsignado" HeaderText="UsuarioAsignado" />
                                <asp:BoundField DataField="FechaAsignacion" HeaderText="Fecha Asignacion" />
                                <asp:BoundField DataField="UsuarioEntrego" HeaderText="UsuarioEntrego" />
                                <asp:BoundField DataField="FechaDevolucion" HeaderText="Fecha Devolucion" />
                                <asp:BoundField DataField="UsuarioRecibe" HeaderText="UsuarioRecibe" />
                            </Columns>
                            <EmptyDataTemplate>
                                <div align="center" class="CajaDialogoAdvertencia">
                                <br/>
                                <img src="../Imagenes/warning.gif" alt="El asegurado no cuenta con derechohabientes" />
                                <br/>No existe Archivos en la Caja<br/><br/>
                                </div>
                            </EmptyDataTemplate>
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle CssClass="cssHeaderImg" HorizontalAlign="Center" />
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
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Panel ID="pnlAsignaExpediente" runat="server" CssClass="panelceleste"  HorizontalAlign="Center" Width="700px" style="overflow-y:scroll; " Height="400px">
                    <div>
                        <asp:Label ID="lblTitulo" runat="server" Text="Asignar Expediente"
                            CssClass="etiqueta20" Font-Size="14pt" Font-Underline="True"></asp:Label>
                        <table style="width: 100%;">
                            <tr>
                                <td align="right" class="auto-style35">&nbsp;</td>
                                <td align="left" class="auto-style37">
                                    <asp:Label ID="Label2" runat="server" CssClass="text_obs"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style5" colspan="2">
                                    <asp:Label ID="Label3" runat="server" Text="Usuario: " CssClass="etiqueta10"></asp:Label>
                                </td>
                                <td align="left" class="auto-style5" colspan="4">
                                    <asp:DropDownList ID="ddlUsuario" runat="server" Width="150px">
                                    </asp:DropDownList>
                                    </td>
                            </tr>
                            <tr style="border-width: medium; border-style: groove;">
                                <td align="right" class="auto-style36" colspan="1">
                                    <asp:Label ID="Label4" runat="server" Text="Nro Tramite: " CssClass="etiqueta10"></asp:Label>
                                </td>
                                <td align="left" class="auto-style5" colspan="2"> 

                                    <asp:TextBox ID="txtNroTramite1" runat="server" Width="150px" TextMode="SingleLine"  onkeypress="return permite(event, 'num')" MaxLength="15" Height="22px" style="text-align:center"></asp:TextBox>
                                     <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender16" 
				                    runat="server" FilterType="Custom,UppercaseLetters,LowercaseLetters,Numbers"
				                    TargetControlID="txtNroTramite1" ValidChars="/-\">
	                                </cc1:FilteredTextBoxExtender> 
                                </td>
                                     <td align="right" class="auto-style34" colspan="1">
                                    <asp:Label ID="Label5" runat="server" Text="Matricula " CssClass="etiqueta10"></asp:Label>
                                </td>
                                <td align="left" class="auto-style5" colspan="2"> 

                                    <asp:TextBox ID="txtmatricula3" runat="server" Width="133px" TextMode="SingleLine"  onkeypress="return permite(event, 'num')" MaxLength="15" Height="22px" style="text-align:center"></asp:TextBox>
                                    <asp:ImageButton ID="imgBusquedaTramite" runat="server" ImageUrl="~/Imagenes/16Buscar.png" OnClick="imgBusquedaTramite_Click" />
                                     <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender17" 
				                    runat="server" FilterType="UppercaseLetters,LowercaseLetters,Numbers"
				                    TargetControlID="txtmatricula3" ValidChars="">
	                                </cc1:FilteredTextBoxExtender> 
                                </td>
                            </tr>
                            <tr class="auto-style5" style="border-style: groove; border-width: medium">
                                <td align="right" class="auto-style36">
                                    Nave
                                </td>
                                 <td align="left" class="auto-style27">
                                     <asp:DropDownList ID="ddlnave2" runat="server"></asp:DropDownList>
                                </td>
                                 
                                <td align="right" class="auto-style31">
                                    Estante
                                </td>
                                 <td align="left" class="auto-style34">
                                    <asp:TextBox ID="txtEstante2" runat="server" Width="100px" TextMode="SingleLine"  onkeypress="return permite(event, 'num')" MaxLength="15" Height="22px"></asp:TextBox>
                                     <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender18" 
				                    runat="server" FilterType="Numbers"
				                    TargetControlID="txtEstante2" ValidChars="">
	                                </cc1:FilteredTextBoxExtender> 
                                </td>
                                <td align="right" class="auto-style31">
                                    Caja
                                </td>
                                 <td align="left" class="auto-style28">
                                    <asp:TextBox ID="txtCaja3" runat="server" Width="100px" TextMode="SingleLine"  onkeypress="return permite(event, 'num')" MaxLength="15" Height="22px"></asp:TextBox>
                                    <asp:ImageButton ID="imgMostrarCaja" runat="server" ImageUrl="~/Imagenes/16Buscar.png" OnClick="imgMostrarCaja_Click" />
                                       <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender19" 
				                    runat="server" FilterType="Numbers"
				                    TargetControlID="txtCaja3" ValidChars="">
	                                </cc1:FilteredTextBoxExtender> 
                                 </td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style5"colspan="2">
                                    <asp:Label ID="Label8" runat="server" Text="Fecha Asignacion: " CssClass="etiqueta10"></asp:Label>
                                </td>
                                <td align="left" class="auto-style5" colspan="4">
                                    
                                    <asp:TextBox ID="txtFechaAsignacionExpediente" runat="server" Width="100px" MaxLength="10"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender15" 
							            runat="server" FilterType="Numbers,Custom"
							            TargetControlID="txtFechaAsignacionExpediente" ValidChars="/">
					                 </cc1:FilteredTextBoxExtender> 
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy" PopupButtonID="ImageButton4" TargetControlID="txtFechaAsignacionExpediente" CssClass="cal_Theme1">
                                    </cc1:CalendarExtender>
                                    <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/Imagenes/pequeños/Calendar_32x32.png" />
                                    <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtFechaAsignacionExpediente" ID="RegularExpressionValidator2" ValidationExpression = "^\d{1,2}\/\d{1,2}\/\d{2,4}$" runat="server" ErrorMessage="Formato de Fecha Incorrecta"></asp:RegularExpressionValidator>
                                    
                                </td>
                            </tr>
                            <tr align="center">
                                <td colspan="6" align="center">
                                    <asp:GridView ID="gvAsignacion" runat="server" CellPadding="4" ForeColor="#333333" AutoGenerateColumns="False" Font-Size="10pt">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:BoundField DataField="Fila" HeaderText="Nro." />
                                        <asp:BoundField DataField="Asegurado" HeaderText="Asegurado" />
                                        <asp:BoundField DataField="Tramite" HeaderText="Tramite" />
                                        <asp:BoundField DataField="Matricula" HeaderText="Matricula" />
                                        <asp:BoundField DataField="Nave" HeaderText="Nave" />
                                        <asp:BoundField DataField="Estante" HeaderText="Estante" />
                                        <asp:BoundField DataField="CodCaja" HeaderText="Cod Caja" />
                                        <asp:BoundField DataField="CodCajaHist" HeaderText="Cod Caja Hist." />
                                        <asp:BoundField DataField="Estado" HeaderText="Estado" />
                                        <asp:TemplateField ControlStyle-Height="16"  ItemStyle-Width="5px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" Visible="true">
                                        <HeaderTemplate>
                                        <asp:CheckBox ID="chkTodos" runat="server" onclick = "checkAll(this);"  />
                                         </HeaderTemplate>    
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkEnvio" runat="server" />
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <div align="center" class="CajaDialogoAdvertencia">
                                        <br/>
                                        <img src="../Imagenes/warning.gif" alt="El asegurado no cuenta con derechohabientes" />
                                        <br/>No se encontro expedientes que cumplan este criterio<br/><br/>
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
                                <td align="right" class="auto-style35">
                                    <asp:Label ID="lblIdDeposito" runat="server" Text="0" Visible="false"></asp:Label>
                                </td>
                                <td align="center" class="auto-style20" colspan="6">
                                    <asp:Button ID="btnAccionarND" runat="server"
                                        OnClientClick="javascript : return confirm('Esta seguro de realizar esta accion?');"
                                        Text="Aceptar" CssClass="boton150" OnClick="btnAccionarND_Click" Enabled="false" />
                                    <asp:Button ID="btnCancelar" runat="server" EnableTheming="True"
                                         Text="Cancelar"
                                        CssClass="boton150" />
                                </td>
                            </tr>

                        </table>

                    </div>
                </asp:Panel>
                <cc1:RoundedCornersExtender ID="RoundedCornersExtender1" runat="server"
                    Enabled="True" TargetControlID="pnlAsignaExpediente" Radius="10" BorderColor="Black">
                </cc1:RoundedCornersExtender>
                <cc1:ModalPopupExtender ID="pnlAsignaExpediente_ModalPopupExtender" runat="server"
                    Enabled="True"
                    TargetControlID="lblTitulo"
                    CancelControlID="btnCancelar"
                    PopupControlID="pnlAsignaExpediente"
                    BackgroundCssClass="modalBackground">
                </cc1:ModalPopupExtender>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Panel ID="pnlDevolucionExpediente" runat="server" CssClass="panelceleste"  HorizontalAlign="Center" Width="495px" style="overflow-y:scroll; " Height="155px">
                    <div>
                        <asp:Label ID="lbltituloDevolucionExpedientes" runat="server" Text="Devolucion Expediente"
                            CssClass="etiqueta20" Font-Size="14pt" Font-Underline="True"></asp:Label>
                        <table style="width: 100%;">
                            <tr>
                                <td align="right" class="auto-style42">&nbsp;</td>
                                <td align="left" class="auto-style37">
                                    <asp:Label ID="Label7" runat="server" CssClass="text_obs"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style5" colspan="2">
                                    <asp:Label ID="Label9" runat="server" Text="Usuario: " CssClass="etiqueta10"></asp:Label>
                                </td>
                                <td align="left" class="auto-style5" colspan="3">
                                    <asp:DropDownList ID="ddlUsuarioDevolucion" runat="server" Width="150px">
                                    </asp:DropDownList>
                                    </td>
                                <td align="left" class="auto-style5">
                                    <asp:ImageButton ID="img_buscaDevolucion" runat="server" ImageUrl="~/Imagenes/16Buscar.png" OnClick="img_buscaDevolucion_Click" Height="21px" Width="25px" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style42"colspan="1">
                                    <asp:Label ID="Label12" runat="server" Text="Fecha Inicio Asignacion: " CssClass="etiqueta10" Visible="false"></asp:Label>
                                </td>
                                <td align="left" class="auto-style48" colspan="2">
                                    
                                    <asp:TextBox ID="txtInicioAsignacion" runat="server" Width="100px" MaxLength="10" Visible="false"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" 
							            runat="server" FilterType="Numbers,Custom"
							            TargetControlID="txtInicioAsignacion" ValidChars="/">
					                 </cc1:FilteredTextBoxExtender> 
                                     <asp:ImageButton ID="img3" runat="server" ImageUrl="~/Imagenes/pequeños/Calendar_32x32.png" Visible="false"/>
                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" Format="dd/MM/yyyy" PopupButtonID="img3" TargetControlID="txtInicioAsignacion" CssClass="cal_Theme1">
                                    </cc1:CalendarExtender>
                                    <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtInicioAsignacion" ID="RegularExpressionValidator1" ValidationExpression = "^\d{1,2}\/\d{1,2}\/\d{2,4}$" runat="server" ErrorMessage="Formato de Fecha Incorrecta"></asp:RegularExpressionValidator>
                                    
                                </td>
                                <td align="right" class="auto-style39"colspan="1">
                                    <asp:Label ID="Label10" runat="server" Text="Fecha Fin Asignacion: " CssClass="etiqueta10" Visible="false"></asp:Label>
                                </td>
                                 <td align="left" class="auto-style44" colspan="2">
                                    <asp:TextBox ID="txtFinAsignacion" runat="server" Width="100px" MaxLength="10" Visible="false"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" 
							            runat="server" FilterType="Numbers,Custom"
							            TargetControlID="txtFinAsignacion" ValidChars="/">
					                 </cc1:FilteredTextBoxExtender> 
                                     <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Imagenes/pequeños/Calendar_32x32.png" Visible="false"/>
                                     
                                     
                                     <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Enabled="True" Format="dd/MM/yyyy" PopupButtonID="ImageButton1" TargetControlID="txtFinAsignacion" CssClass="cal_Theme1">
                                    </cc1:CalendarExtender>
                                    <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtFinAsignacion" ID="RegularExpressionValidator3" ValidationExpression = "^\d{1,2}\/\d{1,2}\/\d{2,4}$" runat="server" ErrorMessage="Formato de Fecha Incorrecta"></asp:RegularExpressionValidator>
                                    
                                </td>
                            </tr>
                            <tr align="center">
                                <td colspan="6" align="center">
                                    <asp:GridView ID="gvDevolucionExpediente" runat="server" CellPadding="4" ForeColor="#333333" AutoGenerateColumns="False" Font-Size="10pt">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:BoundField DataField="Fila" HeaderText="Nro." />
                                        <asp:BoundField DataField="IdRegistro" HeaderText="Id" Visible="true" />
                                        <asp:BoundField DataField="Asegurado" HeaderText="Asegurado" />
                                        <asp:BoundField DataField="Tramite" HeaderText="Tramite" />
                                        <asp:BoundField DataField="Nave" HeaderText="Nave" />
                                        <asp:BoundField DataField="Estante" HeaderText="Estante" />
                                        <asp:BoundField DataField="CodCaja" HeaderText="Cod Caja" />
                                        <asp:BoundField DataField="Estado" HeaderText="Estado" />
                                        <asp:TemplateField ControlStyle-Height="16"  ItemStyle-Width="5px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" Visible="true">
                                        <HeaderTemplate>
                                        <asp:CheckBox ID="chkTodos" runat="server" onclick = "checkAll(this);"  />
                                         </HeaderTemplate>    
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkEnvio" runat="server" />
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <div align="center" class="CajaDialogoAdvertencia">
                                        <br/>
                                        <img src="../Imagenes/warning.gif" alt="El asegurado no cuenta con derechohabientes" />
                                        <br/>No existe expedientes asignados a este Usuario<br/><br/>
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
                                <td align="right" class="auto-style42">
                                    <asp:Label ID="Label13" runat="server" Text="0" Visible="false"></asp:Label>
                                </td>
                                <td align="center" class="auto-style20" colspan="6">
                                    <asp:Button ID="btnAceptarDevolucionExpediente" runat="server"
                                        OnClientClick="javascript : return confirm('Esta seguro de realizar esta accion?');"
                                        Text="Aceptar" CssClass="boton150" OnClick="btnAceptarDevolucionExpediente_Click" Enabled="false" />
                                    <asp:Button ID="btnCancelarDevolucionExpediente" runat="server" EnableTheming="True"
                                         Text="Cancelar"
                                        CssClass="boton150" />
                                </td>
                            </tr>

                        </table>

                    </div>
                </asp:Panel>
                <cc1:RoundedCornersExtender ID="RoundedCornersExtender2" runat="server"
                    Enabled="True" TargetControlID="pnlDevolucionExpediente" Radius="10" BorderColor="Black">
                </cc1:RoundedCornersExtender>
                <cc1:ModalPopupExtender ID="mpeDevolucionExpediente" runat="server"
                    Enabled="True"
                    TargetControlID="lbltituloDevolucionExpedientes"
                    CancelControlID="btnCancelarDevolucionExpediente"
                    PopupControlID="pnlDevolucionExpediente"
                    BackgroundCssClass="modalBackground">
                </cc1:ModalPopupExtender>
            </td>
        </tr>        
         <tr>
            <td align="center">
                <asp:Panel ID="pnlGrupoFamiliar" runat="server" CssClass="panelceleste"  HorizontalAlign="Center" Width="800px" style="overflow-y:scroll; " Height="300px">
                    <div>
                        <asp:Label ID="lblGrupoFamiliar" runat="server" Text="GRUPO FAMILIAR"
                            CssClass="etiqueta20" Font-Size="14pt" Font-Underline="True"></asp:Label>
                        <table>
                            <tr>
                                <td>
                                    <asp:GridView ID="gvGrupoFamiliar" runat="server" CellPadding="4" ForeColor="#333333" AutoGenerateColumns="False" Font-Size="10pt">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:BoundField DataField="Matricula" HeaderText="Matricula" Visible="true" />
                                        <asp:BoundField DataField="Nombre" HeaderText="Asegurado" />
                                        <asp:BoundField DataField="NumeroDocumento" HeaderText="NumeroDocumento" />
                                        <asp:BoundField DataField="FechaNacimiento" HeaderText="FechaNacimiento" />
                                        <asp:BoundField DataField="FechaFallecimiento" HeaderText="FechaFallecimiento" />
                                        <asp:BoundField DataField="Tipo" HeaderText="Tipo" />
                                        <asp:BoundField DataField="PeriodoSolicitud" HeaderText="PeriodoSolicitud" />
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <div align="center" class="CajaDialogoAdvertencia">
                                        <br/>
                                        <img src="../Imagenes/warning.gif" alt="El asegurado no cuenta con derechohabientes" />
                                        <br/>No existe expedientes asignados a este Usuario<br/><br/>
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
                                <td>
                                   <asp:Button ID="btnAceptarGupo" runat="server" EnableTheming="True"
                                         Text="Cancelar"
                                        CssClass="boton150" />
                                </td>
                            </tr>
                        </table>

                    </div>
                </asp:Panel>
                <cc1:RoundedCornersExtender ID="RoundedCornersExtender3" runat="server"
                    Enabled="True" TargetControlID="pnlGrupoFamiliar" Radius="10" BorderColor="Black">
                </cc1:RoundedCornersExtender>
                <cc1:ModalPopupExtender ID="mpeGrupoFamiliar" runat="server"
                    Enabled="True"
                    TargetControlID="lblGrupoFamiliar"
                    CancelControlID="btnAceptarGupo"
                    PopupControlID="pnlGrupoFamiliar"
                    BackgroundCssClass="modalBackground">
                </cc1:ModalPopupExtender>
            </td>
        </tr>
       </table>
       </asp:Panel>
          </td>

        </tr>
        </table>


                                            <!--HASTA AQUI -->

</asp:Content>


