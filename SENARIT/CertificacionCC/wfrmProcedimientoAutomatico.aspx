<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmProcedimientoAutomatico.aspx.cs" Inherits="CertificacionCC_wfrmProcedimientoAutomatico" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">       
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="FondoAplicacion">
        <table width="100%" border="0" cellpadding="false" cellspacing="false">
            <tr>
                <td width="30%">
                    <asp:Label ID="lblTituloSistema" runat="server" Font-Bold="True" ForeColor="Navy" Text="EMISION CC"></asp:Label>
                </td>
                <td width="70%" align="center">
                    <asp:Label ID="lblTitulo" runat="server" Font-Bold="True" ForeColor="#CC0000" Font-Size="17px" Text="Datos del Asegurado"></asp:Label>
                </td>
                <td align="right">
                    &nbsp;</td>
                <td></td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </div>
    <table style="width:100%;">
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                  <table style="width:100%;" border="1" cellpadding="0" cellspacing="0" class="mTable">
                    <tr>
                        <td align="center" >
                            <asp:Label ID="lblPaterno" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td align="center" >
                            <asp:Label ID="lblMaterno" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td align="center" >
                            <asp:Label ID="lblNombres" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th align="center" >PATERNO</th>
                        <th align="center" >MATERNO</th>
                        <th align="center" >NOMBRES</th>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
               
              <table style="width:100%;" border="1" cellpadding="0" cellspacing="0"  class="mTable">
                    <tr>
                        <td align="center">
                            <asp:Label ID="lblDocIdentidad" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:Label ID="lblFechaNacimiento" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:Label ID="lblFechaFallecimiento" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:Label ID="lblEstadoCivil" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td align="center">
                            <asp:Label ID="lblRegional" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th align="center" >DOC.IDENTIDAD</th>
                        <th align="center" >FECHA NACIMIENTO</th>
                        <th align="center" >FECHA FALLECIMIENTO</th>
                        <th align="center" >ESTADO CIVIL</th>
                        <th align="center" >REGIONAL</th>
                    </tr>
                 
                </table>
               
            </td>
        </tr>
        <tr>
            <td align="center">
               
               <table style="width:100%;" border="1" cellpadding="0" cellspacing="0" class="mTable">
                    <tr>
                        <td  align="center">
                            <asp:Label ID="lblMatricula" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td  align="center">
                            <asp:Label ID="lblCUA" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td  align="center">
                            <asp:Label ID="lblTramite" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td  align="center">
                            <asp:Label ID="lblFechaInicio" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th align="center" >MATRICULA</th>
                        <th align="center" >CUA</th>
                        <th align="center" >TRAMITE</th>
                        <th align="center">FECHA INICIO</th>
                    </tr>
                    </table>
                 <table align="center" width="100%"> <tr>
                     
                    <td style="border-style: outset" align="right" bgcolor="White">     
                                                  
                        <asp:HiddenField ID="hfOficinaNotificacion" runat="server" />
                        <asp:HiddenField ID="hfOficinaRegistro" runat="server" />
                                                  
                        <asp:Label ID="lblTipoReproceso" runat="server" Text="Label" Font-Bold="True" ForeColor="#FF3300" Visible="false"></asp:Label>
                        <asp:Label ID="lblEstadoTramite" runat="server" Text="Label" Font-Bold="True" ForeColor="#FF3300" Visible="false"></asp:Label>
                        <asp:Label ID="lblNotificacion" runat="server" Text="Label" Font-Bold="True" ForeColor="Blue" Visible="false"></asp:Label>
                        <asp:TextBox ID="txtFechaCalculo" runat="server" ></asp:TextBox>
                        <asp:ImageButton ID="imgVolver" runat="server"  ImageUrl="~/Imagenes/32Volver.png" ToolTip="Volver a la Página anterior" OnClick="btnVolver_Click" />
                        <asp:ImageButton ID="btnGenerar" runat="server"  ImageUrl="~/Imagenes/nueva3/generar.png" ToolTip="Generar Formulario" OnClick="btnGenerar_Click" />
                        <asp:ImageButton ID="btnFormularioMensual" runat="server"  ImageUrl="~/Imagenes/nueva3/imprimirformulariomensual32.png"  ToolTip="Imprimir Formulario Mensual" OnClick="btnFormularioMensual_Click" />
                        <asp:ImageButton ID="btnFormularioGlobal" runat="server"  ImageUrl="~/Imagenes/nueva3/imprimirformularioglobal32.png"  ToolTip="Imprimir Formulario Global" OnClick="btnFormularioGlobal_Click" />
                        <%--<asp:ImageButton ID="btnConfirmacion" runat="server"  ImageUrl="~/Imagenes/nueva3/confirmacionimpresionWF32.png"  ToolTip="Confirmación de Impresión" OnClick="btnConfirmacionImpresion_Click" />--%>
                        
                    </td>
                    </tr>
                    </table>
               
                <br />
                  <asp:GridView ID="gvDatos" runat="server"             
                        AllowPaging="True" PageSize="15"
                        AutoGenerateColumns="False"                         
                        EnableTheming="True" 
                        Font-Names="Arial" 
                        Font-Size="9pt" 
                        CssClass="mGrid"
                        PagerStyle-CssClass="pgr"
                        AlternatingRowStyle-CssClass="alt"
                        GridLines="None"
                        DataKeyNames="IdTramite,IdGrupoBeneficio,Version,RUC,Componente,IdTipoDocSalario,TipoDocSalario,PeriodoSalario,SalarioCotizable,IdMonedaSalario,EstadoSalario,EstadoSalarioDet,IdEstadoComponente,Correlativo,SalarioCotizableAct,Densidad"  
                          >
                          
                            <Columns>                                
                                <asp:BoundField DataField="Componente" HeaderText="Componente"  />
                                <asp:BoundField DataField="Version" HeaderText="Version"  />
                                <asp:BoundField DataField="RUC" HeaderText="RUC"  />
                                <asp:BoundField DataField="Empresa" HeaderText="Razon Social"  />
                                <%--<asp:BoundField DataField="Componente" HeaderText="Componente"  />--%>
                                <asp:BoundField DataField="TipoDocSalario" HeaderText="TipoDoc Salario"  />
                                <asp:BoundField DataField="PeriodoSalario" HeaderText="Periodo Salario"/>
                                <asp:BoundField DataField="SalarioCotizable" HeaderText="Salario Cotizable" />
                                <asp:BoundField DataField="SalarioCotizableAct" HeaderText="Salario Cotizable Act" />                               
                                <asp:BoundField DataField="Densidad" HeaderText="Densidad" /> 
                                <asp:BoundField DataField="Moneda" HeaderText="Moneda" />
                                <asp:BoundField DataField="TipoCC" HeaderText="Tipo CC" />
                                <asp:BoundField DataField="Correlativo" HeaderText="Correlativo" />
                                <asp:BoundField DataField="EstadoSalarioDet" HeaderText="Estado Salario" />                                                                           
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
                        </asp:GridView><br />
                <asp:HiddenField ID="hfIdTramite" runat="server" />
                <asp:HiddenField ID="hfIdGrupoBeneficio" runat="server" />
                <asp:HiddenField ID="hfFlagM" runat="server" />
                <asp:HiddenField ID="hfFlagG" runat="server" />
                <asp:HiddenField ID="hfEstadoTramite" runat="server" />
                <br />
                <%--<asp:Label ID="lblNotificacion" runat="server" Text="Observacion de la Notificacion"></asp:Label>--%>
                <br />
                <br />
                <%--<asp:TextBox ID="txtObservacion" runat="server" TextMode="multiline" Columns="50" Rows="5"  onfocus="selecciona_value(this)"></asp:TextBox>--%>
               
            &nbsp;<br />
                <%--<asp:Button ID="btnNotificar" runat="server"  Text="Notificar" OnClick="btnNotificar_Click" Visible="false" />--%>
            </td>
        </tr>

    </table>
    
</asp:Content>

