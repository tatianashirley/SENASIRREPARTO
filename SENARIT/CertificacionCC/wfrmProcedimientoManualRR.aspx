<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmProcedimientoManualRR.aspx.cs" Inherits="CertificacionCC_wfrmProcedimientoManualRR" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
    <style type="text/css">
        .auto-style5
        {
            height: 25px;
        }

        .auto-style7
        {
            height: 48px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="FondoAplicacion">
        <asp:Panel ID="pnlTitulo" runat="server">
            <table width="100%" border="0" cellpadding="false" cellspacing="false">
                <tr>
                    <td width="30%">
                        <asp:Label ID="lblTituloSistema" runat="server" Font-Bold="True" ForeColor="Navy" Text="PROCEDIMIENTO MANUAL"></asp:Label>
                    </td>
                    <td width="70%" align="center">
                        <asp:Label ID="lblTitulo" runat="server" Font-Bold="True" ForeColor="#CC0000" Font-Size="17px" Text="Datos del Asegurado"></asp:Label>
                    </td>
                    <td align="right">&nbsp;</td>
                    <td></td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
    </div>
    <asp:Panel ID="description_HeaderPanel" runat="server" Style="cursor: pointer;">
        <div class="heading" align="left">
            <asp:ImageButton ID="Description_ToggleImage" runat="server" ImageUrl="~/Imagenes/collapse.jpg" Enabled="false" />
            <asp:Label ID="lblDatosAsegurado" runat="server" Text="Label" Font-Bold="True" ForeColor="#CC0000" Font-Size="17px"></asp:Label>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlDatosAsegurado" runat="server">
        <table style="width: 100%;" border="1" cellpadding="0" cellspacing="0">
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
                <td align="center" bgcolor="#CCCCCC">DOC.IDENTIDAD</td>
                <td align="center" bgcolor="#CCCCCC">FECHA NACIMIENTO</td>
                <td align="center" bgcolor="#CCCCCC">FECHA FALLECIMIENTO</td>
                <td align="center" bgcolor="#CCCCCC">ESTADO CIVIL</td>
                <td align="center" bgcolor="#CCCCCC">REGIONAL</td>
            </tr>

        </table>
        <table style="width: 100%;" border="1" cellpadding="0" cellspacing="0">
            <tr>
                <td align="center" class="auto-style5">
                    <asp:Label ID="lblPaterno" runat="server" Text="Label"></asp:Label>
                </td>
                <td align="center" class="auto-style5">
                    <asp:Label ID="lblMaterno" runat="server" Text="Label"></asp:Label>
                </td>
                <td align="center" class="auto-style5">
                    <asp:Label ID="lblNombres" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center" bgcolor="#CCCCCC">PATERNO</td>
                <td align="center" bgcolor="#CCCCCC">MATERNO</td>
                <td align="center" bgcolor="#CCCCCC">NOMBRES</td>
            </tr>
        </table>
        <table style="width: 100%;" border="1" cellpadding="0" cellspacing="0">
            <tr>
                <td class="auto-style5" align="center">
                    <asp:Label ID="lblMatricula" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="auto-style5" align="center">
                    <asp:Label ID="lblCUA" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="auto-style5" align="center">
                    <asp:Label ID="lblTramite" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="auto-style5" align="center">
                    <asp:Label ID="lblFechaInicio" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center" bgcolor="#CCCCCC">MATRICULA</td>
                <td align="center" bgcolor="#CCCCCC">CUA</td>
                <td align="center" bgcolor="#CCCCCC">TRAMITE</td>
                <td align="center" bgcolor="#CCCCCC">FECHA INICIO</td>
            </tr>
        </table>
    </asp:Panel>
    <cc1:CollapsiblePanelExtender ID="cpeDesc" runat="Server"
        TargetControlID="pnlDatosAsegurado"
        ExpandControlID="description_HeaderPanel"
        CollapseControlID="description_HeaderPanel"
        TextLabelID="lblDatosAsegurado"
        CollapsedText="Datos del Asegurado"
        Collapsed="True"
        ImageControlID="description_ToggleImage"
        CollapsedImage="~/Imagenes/collapse.jpg"
        ExpandedImage="~/Imagenes/expand.jpg"
        ExpandedText="Cerrar contenido"
        ExpandDirection="Vertical" />
    <asp:Panel ID="pnlBotonesdeAccion" runat="server">
        <table align="center" width="100%">
            <tr><td>
                &nbsp;</td></tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtIdTramite" runat="server"></asp:TextBox>
                    <asp:Button ID="btnRefresca" runat="server" OnClick="btnRefresca_Click" Text="Buscar" />
                </td>
            <tr>
                <td align="right" class="auto-style7" style="border-style: outset">
                    <asp:HiddenField ID="hfEstadoTramite" runat="server" />
                    <asp:Label ID="lblTipoReproceso" runat="server" Font-Bold="True" ForeColor="#FF3300" Text="Label" Visible="false"></asp:Label>
                    <asp:Label ID="lblEstadoTramite" runat="server" Font-Bold="True" ForeColor="#FF3300" Text="Label" Visible="false"></asp:Label>
                    <asp:ImageButton ID="imgVolver" runat="server" CausesValidation="false" ImageUrl="~/Imagenes/32Volver.png" OnClick="btnVolver_Click" ToolTip="Volver a la Página anterior" />
                    <br />
                    <%-- <asp:ImageButton ID="btnRechazar" runat="server"  
                             ImageUrl="~/Imagenes/nueva3/rechazacertificacion32.png"  
                             ToolTip="Aprobar Certificación" OnClick="btnRechazar_Click" CausesValidation="false" />--%>&nbsp;<br /> </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnlComponentes" runat="server">
        <asp:GridView ID="gvDatosComponentes" runat="server"
            AllowPaging="True" PageSize="15"
            AutoGenerateColumns="False"
            EnableTheming="True"
            Font-Names="Arial"
            Font-Size="9pt"
            CssClass="mGrid"
            PagerStyle-CssClass="pgr"
            AlternatingRowStyle-CssClass="alt"
            GridLines="None"
            DataKeyNames="IdTramite,IdGrupoBeneficio,Version,RUC,Componente,IdTipoDocSalario,TipoDocSalario,PeriodoSalario,SalarioCotizable,IdMonedaSalario,EstadoSalario,EstadoSalarioDet,IdParametrizacion,GlosaSalario,Certificado,EstadoComponente,IdEstadoComponente,Mitas,SalarioCotizableActualizado,DensidadAportes,IdSector,Sector,Codigo,Correlativo,TipoFormulario"
          
            
            >

            <Columns>
                <asp:TemplateField ControlStyle-Height="16" ItemStyle-Width="5px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Componentes a corregir">

                    <ItemTemplate>
                        <center>
                            <asp:CheckBox ID="chkCertificar" runat="server" />
                        </center>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:BoundField DataField="TipoFormulario" HeaderText="Formulario" />
                <asp:BoundField DataField="Correlativo" HeaderText="Correlativo." />
                <asp:BoundField DataField="Componente" HeaderText="Comp." />
                <asp:BoundField DataField="Version" HeaderText="Version" />
                <asp:BoundField DataField="RUC" HeaderText="RUC" />
                <asp:BoundField DataField="Empresa" HeaderText="Razon Social" />
                <asp:BoundField DataField="TipoDocSalario" HeaderText="TipoDoc Salario" />
                <asp:BoundField DataField="PeriodoSalario" HeaderText="Periodo Salario" />
                <asp:BoundField DataField="SalarioCotizable" HeaderText="Salario Cotizable">
                    <HeaderStyle Width="40px" />
                </asp:BoundField>
                <asp:BoundField DataField="SalarioCotizableActualizado" HeaderText="Salario Cotizable Act">
                    <HeaderStyle Width="40px" />
                </asp:BoundField>
                <asp:BoundField DataField="DensidadAportes" HeaderText="Densidad">
                    <HeaderStyle Width="40px" />
                </asp:BoundField>
                <asp:BoundField DataField="Moneda" HeaderText="Moneda" />
                <asp:BoundField DataField="Mitas" HeaderText="Mitas" />
                <asp:BoundField DataField="EstadoComponente" HeaderText="Estado Salario" />

            </Columns>
            <EmptyDataTemplate>
                <div align="center" class="CajaDialogoAdvertencia">
                    <br />
                    <img src="../Imagenes/warning.gif"
                        alt="No existen datos que correspondan al criterio especificado" />
                    <br />
                    No existen datos que correspondan al criterio especificado
                                <br />
                    <br />
                </div>
            </EmptyDataTemplate>
            <SelectedRowStyle BackColor="#FFFF99" />
        </asp:GridView>
    </asp:Panel>
    <div align="center">
        <asp:Button ID="btnAnularCertificacion" runat="server" Text="Procesar..." OnClick="btnAnularCertificacion_Click" OnClientClick="return confirm('Esta seguro de realizar la operación?');" />
        <%--<asp:Button ID="btnAgregarMensual" runat="server" Text="Agregar Certificación Mensual" OnClick="btnAgregarMensual_Click" OnClientClick="return confirm('Esta seguro de realizar la operación?');" />
        <asp:Button ID="btnAgregarGlobal" runat="server" Text="Agregar Certificación Global" OnClick="btnAgregarGlobal_Click" OnClientClick="return confirm('Esta seguro de realizar la operación?');" />
        <asp:Button ID="btnAgregarMyG" runat="server" Text="Agregar Certificación Mensual y Global"  OnClientClick="return confirm('Esta seguro de realizar la operación?');" OnClick="btnAgregarMyG_Click"/>
        --%>

                <asp:Label ID="lblArchivo" runat="server" Text="Coordinar con Archivo Transitorio" Font-Bold="True" ForeColor="#FF3300"></asp:Label>

        <br />
        <br />
        <asp:ImageButton ID="btnSiguiente" runat="server"  ImageUrl="~/Imagenes/nueva3/siguiente32.png"  ToolTip="Continuar con la operación" OnClientClick="return confirm('Esta seguro de realizar la operación?');" OnClick="btnSiguiente_Click" Visible="false"/>
        

    <asp:HiddenField ID="hfIdTramite" runat="server" />
    <asp:HiddenField ID="hfIdGrupoBeneficio" runat="server" />
    <asp:HiddenField ID="hfVersion" runat="server" />
        </div>
    <hr width="60%" />
    <asp:Panel ID="pnlBajaFormulario" runat="server" Visible="false" CssClass="panelprincipal">
    <div>
        <p>
            <asp:Label ID="Label1" runat="server" Text="Dar de baja el Formulario de Cálculo" Font-Bold="True"></asp:Label></p>
        <div width="600">
        <table>
                        <tr>
                           
                            <td style="TEXT-ALIGN: left" class="auto-style4">
                                <asp:RadioButton ID="rdbFCG"
                                    runat="server" GroupName="aplica" Text="Formulario Global"
                                    /></td>
                        </tr>
                        <tr>
                            <td style="TEXT-ALIGN: left" class="auto-style4">
                                <asp:RadioButton ID="rdbFCM"
                                    runat="server" GroupName="aplica" Text="Formulario Mensual"
                                     /></td>
                        </tr>
                        <tr>
                            <td style="TEXT-ALIGN: left" class="auto-style4">
                                <asp:RadioButton ID="rdbFCGM" runat="server"
                                    GroupName="aplica" Text="Ambos"
                                      /></td>
                        </tr>
                    </table>
            </div>
        <br />
        <asp:Button ID="btnCambioEstado" runat="server" Text="Procesar.." OnClick="btnCambioEstado_Click" />

    </div>
           <cc1:ModalPopupExtender ID="pnlBajaFormulario_ModalPopupExtender" runat="server" 
                Enabled="True" 
                TargetControlID="lblTituloSistema" 
                PopupControlID="pnlBajaFormulario" 
                BackgroundCssClass="modalBackground"> 
                </cc1:ModalPopupExtender>
                <cc1:DragPanelExtender ID="DragPanelExtender1" runat="server"
                DragHandleID="pnlBajaFormulario" TargetControlID="pnlBajaFormulario" > 
            </cc1:DragPanelExtender> 
    </asp:Panel>
    
</asp:Content>

