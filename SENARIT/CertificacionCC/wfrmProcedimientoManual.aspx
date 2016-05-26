<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmProcedimientoManual.aspx.cs" Inherits="CertificacionCC_wfrmProcedimientoManual" Theme="Modal" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 330px;
        }

        .auto-style2 {
            width: 625px;
        }

        .auto-style4 {
            width: 262px;
        }

        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:TextBox ID="TextBox1" runat="server" Visible="false"></asp:TextBox>
    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Imagenes/16calendario.png" Visible="false" />
    <cc1:CalendarExtender ID="CalendarExtender3" runat="server" PopupButtonID="ImageButton1" TargetControlID="TextBox1"></cc1:CalendarExtender>
    <div class="FondoAplicacion">
        <table width="100%" border="0" cellpadding="false" cellspacing="false">
            <tr>
                <td class="auto-style2" align="center">
                    <asp:Label ID="lblTituloSistema" runat="server" Font-Bold="True" ForeColor="Navy" Text="CERTIFICACION DE SALARIO PROCEDIMIENTO MANUAL"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblTitulo" runat="server"></asp:Label></td>

            </tr>
        </table>
    </div>
    <asp:Panel ID="description_HeaderPanel" runat="server" Style="cursor: pointer;">
        <div class="heading">
            <asp:ImageButton ID="Description_ToggleImage" runat="server" ImageUrl="~/Imagenes/collapse.jpg" Enabled="false" />
            <asp:Label ID="lblDatosAsegurado" runat="server" Text="Label" Font-Bold="True" ForeColor="#CC0000" Font-Size="17px"></asp:Label>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlDatosAsegurado" runat="server">
        <table style="width: 100%;">
            <tr>
                <td>
                    <asp:HiddenField ID="hfIdTramite" runat="server" />
                    <asp:HiddenField ID="hfIdGrupoBeneficio" runat="server" />
                    <asp:HiddenField ID="hfVersion" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <table style="width: 100%;" border="1" cellpadding="0" cellspacing="0" class="mTable">
                        <tr>
                            <td align="center">
                                <asp:Label ID="lblPaterno" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblMaterno" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblNombres" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th align="center">PATERNO</th>
                            <th align="center">MATERNO</th>
                            <th align="center">NOMBRES</th>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>

                    <table style="width: 100%;" border="1" cellpadding="0" cellspacing="0" class="mTable">
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
                            <th align="center">DOC.IDENTIDAD</th>
                            <th align="center">FECHA NACIMIENTO</th>
                            <th align="center">FECHA FALLECIMIENTO</th>
                            <th align="center">ESTADO CIVIL</th>
                            <th align="center">REGIONAL</th>
                        </tr>

                    </table>

                </td>
            </tr>
            <tr>
                <td align="center">

                    <table style="width: 100%;" border="1" cellpadding="0" cellspacing="0" class="mTable">
                        <tr>
                            <td align="center">
                                <asp:Label ID="lblMatricula" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblCUA" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblTramite" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblFechaInicio" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th align="center">MATRICULA</th>
                            <th align="center">CUA</th>
                            <th align="center">TRAMITE</th>
                            <th align="center">FECHA INICIO<asp:Label ID="lblFechaAsignacion" runat="server" Text="Label" Visible="false"></asp:Label>
                            </th>
                        </tr>
                    </table>


                </td>
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


    <asp:Panel ID="pnlBotones" runat="server">
<div align="left">
   <div align="right" >
       <p><hr  width="60%"/>
        <asp:Label ID="lblTipoReproceso" runat="server" Text="Label" Font-Bold="True" ForeColor="#FF3300" Visible="false"></asp:Label>
                    <asp:Label ID="lblEstadoTramite" runat="server" Text="Label" Font-Bold="True" ForeColor="#FF3300" Visible="false"></asp:Label> <asp:ImageButton ID="imgVolver" runat="server" ImageUrl="~/Imagenes/32Volver.png" ToolTip="Volver a la Página anterior"   OnClick="btnVolver_Click" />
       <hr  width="60%"/>    
       </p>

   </div>
         <table  >
            
                
                <td style="border-style: outset" align="center" >
                    <asp:ImageButton ID="btnRegistrarCancha" runat="server" ImageUrl="~/Imagenes/nueva3/adicioncertificacion32.png" CausesValidation="false" ToolTip="Nuevo Componente" OnClick="btnRegistrarCancha_Click" />
                    <br />
                    <asp:Label ID="lblRegistroAportes" runat="server" Text="Nuevo Componente" Font-Bold="True"></asp:Label>
                </td>
              
                <td style="border-style: outset" align="center" >
                    <asp:ImageButton ID="btnRechaza" runat="server" ImageUrl="~/Imagenes/nueva3/rechazacertificacion32.png" ToolTip="Rechaza Certificación" OnClick="btnRechaza_Click" OnClientClick="return confirm('Esta seguro de reprobar el tramite?');" />
                    <br />
                    <asp:Label ID="lblRechaza" runat="server" Text="Rechazar Certificacion" Font-Bold="True"></asp:Label>
                    </td>
                <td style="border-style: outset" align="center">
                    <asp:ImageButton ID="btnAprobar" runat="server" ImageUrl="~/Imagenes/nueva3/apruebacertificacion32.png" ToolTip="Aprobar Certificación" OnClick="btnAprobar_Click" OnClientClick="return confirm('Esta seguro de aprobar el tramite?');" />
                    <br />
                    <asp:Label ID="lblAprobar" runat="server" Text="Aprobar Certificación" Font-Bold="True"></asp:Label>
                    </td>
                <td style="border-style: outset" align="center" >
                    <asp:ImageButton ID="btnApruebaCertificacion" runat="server" ImageUrl="~/Imagenes/nueva3/apruebacertificacion32.png" ToolTip="Aprobación Final" OnClick="btnApruebaCertificacion_Click" OnClientClick="return confirm('Esta seguro de aprobar el tramite?');" />
                    <br />
                    <asp:Label ID="lblApruebaCertificacion" runat="server" Text="Aprobar Certificación" Font-Bold="True"></asp:Label>
                    </td>
                <td style="border-style: outset" align="center">
                    <asp:ImageButton ID="btnImpresionCertificacion" runat="server"
                        ImageUrl="~/Imagenes/nueva3/certificacionsalario32.png"
                        ToolTip="Confirmación de Impresión" OnClick="btnImpresionCertificacion_Click" CausesValidation="false" />
                    <br />
                    <asp:Label ID="lblImpresionCertificacion" runat="server" Text="Impresión Certificación" Font-Bold="True" Visible="false"></asp:Label>
                    </td>
                <td style="border-style: outset" align="center" >
                    <asp:ImageButton ID="btnImprimeCorrelativo" runat="server"
                        ImageUrl="~/Imagenes/nueva3/imprimecorrelativo32.png"
                        ToolTip="Imprimir Correlativo" OnClick="btnImprimeCorrelativo_Click" CausesValidation="false" Visible="false" />
                    <br />
                    <asp:Label ID="lblImprimeCorrelativo" runat="server" Text="Impresión Correlativo" Visible="False" Font-Bold="True"></asp:Label>
                    </td>
                <td style="border-style: outset" align="center" >
                    <asp:ImageButton ID="btnIngresarInforme" runat="server" ImageUrl="~/Imagenes/verdeImprimir.png" CausesValidation="false" ToolTip="Adicionar Informe" OnClick="btnAdicionarInforme_Click" />
                    <br />
                    <asp:Label ID="lblIngresarInforme" runat="server" Text="Agregar Informe" Font-Bold="True"></asp:Label>
                    </td>
              <%--  <td>
                    <asp:ImageButton ID="btnTraObservado" runat="server" ImageUrl="~/Imagenes/nueva3/observado.png" CausesValidation="false" ToolTip="Adicionar Informe" OnClick="btnTraObservado_Click" />
                </td>--%>
            </tr>
        </table>
    </div>
    </asp:Panel>

    <asp:Panel ID="pnlComponentesNew" runat="server">
        <table  align="center">
            <tr>
                <td align="center">

                    <div style="font-size: small; color: #0000FF;" align="left">* El salario se encuentra en color amarillo cuando un aporte es mayor a OCT/96<br />
                        <br/>

        </div>
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
                        DataKeyNames="IdTramite,IdGrupoBeneficio,Version,RUC,Componente,IdTipoDocSalario,TipoDocSalario,PeriodoSalario,SalarioCotizable,IdMonedaSalario,EstadoSalario,EstadoSalarioDet,IdParametrizacion,GlosaSalario,Certificado,EstadoComponente,IdEstadoComponente,Mitas,SalarioCotizableActualizado,DensidadAportes,IdSector,Sector,Codigo,DetalleGeneral"
                        OnRowCommand="gvDatosComponentes_RowCommand" OnRowDataBound="gvDatosComponentes_RowDataBound">

                        <Columns>
                            <asp:BoundField DataField="Componente" HeaderText="Comp." />
                            <asp:BoundField DataField="Version" HeaderText="Version" Visible="false" />
                            <asp:BoundField DataField="RUC" HeaderText="RUC" />
                            <asp:BoundField DataField="Empresa" HeaderText="Razon Social" />
                            <asp:BoundField DataField="TipoDocSalario" HeaderText="TipoDoc Salario" />
                            <asp:BoundField DataField="PeriodoSalario" HeaderText="Periodo Salario" >
                            <HeaderStyle Width="40px" />
                            </asp:BoundField>
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
                            <asp:BoundField DataField="EstadoComponente" HeaderText="Estado Salario" >
                             <HeaderStyle Width="40px" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Ver Aportes" ItemStyle-Width="40px">
                                <ItemTemplate>
                                    <center>
                                        <asp:ImageButton ID="imgCancha" width="20px" height="20px" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdCancha" ImageUrl="~/imagenes/nueva3/siguiente32.png" ToolTip="Ver detalle aportes" />

                                    </center>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Editar Eliminar" ItemStyle-Width="45px">
                                <ItemTemplate>
                                    <center>
                                        <asp:ImageButton ID="imgEditar" width="20px" height="20px" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdEditar" ImageUrl="~/imagenes/nueva3/editar32.png" ToolTip="Editar Salario Cotizable" />
                                        <asp:ImageButton ID="imgEliminar" width="20px" height="20px" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdEliminar" ImageUrl="~/imagenes/nueva3/eliminar32.png" ToolTip="Eliminar Salario Cotizable" OnClientClick="return confirm('Esta seguro de eliminar el registro?');" />
                                    </center>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Certi" ItemStyle-Width="50px">
                                <ItemTemplate>
                                    <center>
                                        <asp:ImageButton ID="imgCerti" width="20px" height="20px" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdCerti" ImageUrl="~/Imagenes/nueva3/certificacionsalario32.png" ToolTip="Editar Salario Cotizable" />
                                        <asp:ImageButton ID="imgCertificacionSalarioCorrelativo"  width="20px" height="20px" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdCertificacionSalarioCorrelativo" ImageUrl="~/imagenes/nueva3/qr.png" ToolTip="Reporte Certificacion de Salarios" />                                        
                                        
                                    </center>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            <div align="center" class="CajaDialogoAdvertencia">
                                <br />
                                <img src="../Imagenes/warning.gif"
                                    alt="No existen datos que correspondan al criterio especificado"  />
                                <br />
                                No existen datos que correspondan al criterio especificado
                                <br />
                                <br />
                            </div>
                        </EmptyDataTemplate>
                        <SelectedRowStyle BackColor="#FFFF99" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td align="left">
                    <asp:HiddenField ID="hfCantidad" runat="server" />


                    <asp:HiddenField ID="hfCantidadInformes" runat="server" />


                </td>
            </tr>

            <tr>
                <td>
                    <div align="center">
                    <asp:Label ID="lblCertificacionParcial" runat="server" Text="Label" Visible="false" BackColor="#FF3300"></asp:Label>
                    <asp:ImageButton ID="btnCertificacionParcial" runat="server"
                        ImageUrl="~/Imagenes/nueva3/certificacionsalario32.png"
                        ToolTip="Confirmación de Impresión" CausesValidation="false" width="20px" height="20px" OnClick="btnCertificacionParcial_Click" Visible="false" />
                    <br />
                    <asp:Label ID="lblCertSNInforme" runat="server" Text="Label" Visible="false" BackColor="#FF3300"></asp:Label>
                    <br />
                    <asp:Label ID="lblGenerarSalario" runat="server" Text="Label" Visible="false" BackColor="#FF3300"></asp:Label>

                </div>
                    </td>
            </tr>

        </table>
    </asp:Panel>

    <asp:Panel ID="pnlFormularioModifica" runat="server" CssClass="panelceleste" Width="100%">
        <asp:Panel ID="pnlBusqueda" runat="server" Visible="false">
            <table style="width: 100%" align="center" visible="false">
                <tr>
                    <td align="right" width="10%">&nbsp;</td>
                    <td align="right" width="30%">
                        <asp:Label ID="Label1" runat="server" Text="Label">Busqueda Razon Social:</asp:Label></td>
                    <td align="left" width="60%">
                        <asp:TextBox ID="txtDescripcionRUC" runat="server" Width="500px" OnTextChanged="txtDescripcionRUC_TextChanged"></asp:TextBox>
                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" Enabled="True"
                            ServicePath="~/BuscarRazonSocial.asmx" MinimumPrefixLength="2" ServiceMethod="wsBuscarRazonSocial"
                            EnableCaching="true" TargetControlID="txtDescripcionRUC" UseContextKey="True" CompletionSetCount="10"
                            CompletionInterval="200">
                        </cc1:AutoCompleteExtender>
                        &nbsp;</td>
                </tr>
            </table>
        </asp:Panel>

        <table style="width: 100%" align="center">
            <tr>
                <td align="right" width="10%">
                    <asp:CheckBox runat="server" Text="Editar" ID="chkRuc" AutoPostBack="True" OnCheckedChanged="chkRuc_CheckedChanged" />
                    &nbsp;==&gt;</td>
                <td align="right" width="20%">RUC:</td>
                <td align="left" width="70%">
                    <asp:TextBox ID="txtRUC" runat="server" autofocus="autofocus" ReadOnly="true" onfocus="selecciona_value(this)"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtRUC" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right"></td>
                <td align="right">Detalle RUC:</td>
                <td align="left" class="auto-style1">
                    <asp:TextBox ID="txtDetRUC" runat="server" ReadOnly="true" Width="405px" onfocus="selecciona_value(this)"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">&nbsp;</td>
                <td align="right">Sector:</td>
                <td align="left" class="auto-style1">
                    <asp:TextBox ID="txtSector" runat="server" AutoPostBack="True" OnTextChanged="txtSector_TextChanged"></asp:TextBox>
                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" Enabled="True"
                        ServicePath="~/BuscarSector.asmx" MinimumPrefixLength="2" ServiceMethod="wsBuscarSector"
                        EnableCaching="true" TargetControlID="txtSector" UseContextKey="True" CompletionSetCount="10"
                        CompletionInterval="200">
                    </cc1:AutoCompleteExtender>
                </td>
            </tr>
            <tr>
                <td align="right"></td>
                <td align="right">Tipo Documento Presentado:&nbsp;</td>
                <td align="left" class="auto-style4">
                    <asp:DropDownList ID="ddlTipoDocumento" runat="server">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlTipoDocumento" InitialValue="0" ErrorMessage="*" />
                </td>
            </tr>
            <tr>
                <td align="right">&nbsp;</td>
                <td align="right">
                    <%--<cc1:MaskedEditExtender ID="meePeriodoSalario" runat="server" TargetControlID="txtPeriodoSalario" Mask="99/9999" MaskType="None" ClearTextOnInvalid="False" UserDateFormat="None" />--%>
        
        



                    Periodo Salario:</td>
                <td align="left">
                    <asp:TextBox ID="txtPeriodoSalario" runat="server" ReadOnly="false" MaxLength="7" AutoPostBack="True" OnTextChanged="txtPeriodoSalario_TextChanged"></asp:TextBox>
                    <%--<cc1:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="cal_Theme1" Format="MM/yyyy" PopupButtonID="imgcalendarioinicio" TargetControlID="txtPeriodoSalario">
                    </cc1:CalendarExtender>--%>
                    <%--<cc1:MaskedEditExtender ID="meePeriodoSalario" runat="server" TargetControlID="txtPeriodoSalario" Mask="99\/9999" MaskType="None" ClearTextOnInvalid="false"  />--%>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="error en formato" ValidationExpression="((0[1-9]|1[012])[ /](190[0-9]|191[0-9]|192[0-9]|193[0-9]|194[0-9]|195[0-9]|196[0-9]|197[0-9]|198[0-9]|199[0-6]))|((0[1-5])[ /](1997))|((0[1-9]|1[012])[/](4[0-9]|5[0-9]|6[0-9]|7[0-9]|8[0-9]|9[0-9]))" ControlToValidate="txtPeriodoSalario">mm/YYYY</asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPeriodoSalario" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                </td>
                <%--<cc1:MaskedEditValidator ID="MaskedEditValidator5" runat="server"
             ControlExtender="meePeriodoSalario"
            ControlToValidate="txtPeriodoSalario"
            EmptyValueMessage="Date is required"
            InvalidValueMessage="Date is invalid"
            Display="Dynamic"
           TooltipMessage="Input a date"
            EmptyValueBlurredText="*"
            InvalidValueBlurredMessage="*"
            ValidationGroup="MKE" />--%>
            </tr>

            <tr>
                <td align="right">&nbsp;</td>
                <td align="right" style="margin-left: 40px">
                    <asp:Label ID="lblMitas" runat="server" Text="Mitas:" Visible="false"></asp:Label></td>
                <td align="left">
                    <asp:TextBox ID="txtMitas" runat="server" Visible="false" MaxLength="15"></asp:TextBox>
                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Numbers" TargetControlID="txtMitas" />
                </td>
            </tr>

            <tr>
                <td align="right">&nbsp;</td>
                <td align="right">&nbsp;</td>
                <td align="left">
                    <table>
                        <tr>
                            <td style="TEXT-ALIGN: left" class="auto-style4">
                                <asp:RadioButton ID="rdbCertSalMin"
                                    runat="server" GroupName="aplica" Text="Salario Minimo" AutoPostBack="True"
                                    OnCheckedChanged="rdbCertSalMin_CheckedChanged" /></td>
                        </tr>
                        <tr>
                            <td style="TEXT-ALIGN: left" class="auto-style4">
                                <asp:RadioButton ID="rdbCertDS29537"
                                    runat="server" GroupName="aplica" Text="D.S. 29537 - D.S. 822 Art. 74"
                                    AutoPostBack="True" OnCheckedChanged="rdbCertDS29537_CheckedChanged" /></td>
                        </tr>
                        <tr>
                            <td style="TEXT-ALIGN: left" class="auto-style4">
                                <asp:RadioButton ID="rdbCertNormal" runat="server"
                                    GroupName="aplica" Text="Normal" AutoPostBack="True"
                                    OnCheckedChanged="rdbCertNormal_CheckedChanged" Checked="True" /></td>
                        </tr>
                    </table>
                </td>
            </tr>

            <tr>
                <td align="right">
                    <asp:CheckBox ID="chkSalarioCotizable" runat="server" AutoPostBack="True" OnCheckedChanged="chkSalarioCotizable_CheckedChanged" Text="Editar" />
                    &nbsp;==&gt;</td>
                <td align="right">Salario Cotizable:</td>
                <td align="left">
                    <asp:TextBox ID="txtSalarioCotizable" runat="server" onChange="redondeo2decimales(this.id)" onfocus="selecciona_value(this)" onkeyup="validadecimal(this.id)" ReadOnly="true" MaxLength="20"></asp:TextBox>
                    <cc1:FilteredTextBoxExtender ID="txtSalarioCotizable_Filtro" runat="server" Enabled="True" FilterType="Custom, Numbers" TargetControlID="txtSalarioCotizable" ValidChars=".">
                    </cc1:FilteredTextBoxExtender>
                    <%-- <cc1:MaskedEditExtender runat="server" TargetControlID="txtSalarioCotizable" Mask="999,999.99"  InputDirection = "RightToLeft" AcceptNegative="Left"  />--%><%--<cc1:FilteredTextBoxExtender ID="TxtTelefono_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Custom, Numbers" 
TargetControlID="txtSalarioCotizable" ValidChars=",">
</cc1:FilteredTextBoxExtender>--%><%--<cc1:MaskedEditExtender ID="meeDecimales" runat="server" TargetControlID="txtSalarioCotizable" Mask="$999,999.00"--%><%--MaskType="Number" InputDirection="RightToLeft" />    --%>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtSalarioCotizable" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right">&nbsp;</td>
                <td align="right">Moneda Salario:</td>
                <td align="left">
                    <asp:DropDownList ID="ddlMonedaSalario" runat="server">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlMonedaSalario" InitialValue="0" ErrorMessage="*" />

                </td>
            </tr>
            <tr>
                <td align="right">&nbsp;</td>
                <td align="right">Parametrizacion:</td>
                <td align="left">
                    <asp:DropDownList ID="ddlParametrizacion" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlParametrizacion_SelectedIndexChanged">
                    </asp:DropDownList>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlParametrizacion" InitialValue="0" ErrorMessage="*" />--%>
                </td>
            </tr>
            <tr>
                <td align="right" valign="top">&nbsp;</td>
                <td align="right" valign="top">Glosa Salario:</td>
                <td align="left">
                    <asp:TextBox ID="txtGlosaSalario" runat="server" Style="text-transform: uppercase" TextMode="multiline" Columns="50" Rows="5" onfocus="selecciona_value(this)"></asp:TextBox>
                    <%--<CKEditor:CKEditorControl ID="txtGlosaSalario" runat="server" Height="100px" Width="700px"  ToolbarStartupExpanded="false"></CKEditor:CKEditorControl>--%>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtGlosaSalario" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right" valign="top">&nbsp;</td>
                <td align="right" valign="top">Detalle General:</td>
                <td align="left">
                    <asp:TextBox ID="txtDetalleGeneral" runat="server" Columns="50" onfocus="selecciona_value(this)" Rows="5" Style="text-transform: uppercase" TextMode="multiline"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" valign="top">&nbsp;</td>
                <td align="right" valign="top">&nbsp;</td>
                <td align="left">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" valign="top">&nbsp;</td>
                <td align="right" valign="top">&nbsp;</td>
                <td align="left">
                    <asp:HiddenField ID="hdfOperacion" runat="server" />
                    <asp:HiddenField ID="hfEstadoTramite" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="center" valign="top" colspan="3">&nbsp;<asp:Button ID="btnInsertar" runat="server" OnClick="btnInsertar_Click" Text="Enviar" Width="100px" Style="height: 26px" OnClientClick="return confirm('Esta seguro de realizar la operación?');" />
                    <asp:Button ID="btnCancelar" runat="server" CausesValidation="false" OnClick="btnCancelar_Click" Text="Cancelar" />
                </td>
            </tr>
        </table>

    </asp:Panel>


    <asp:Panel ID="pnlInformes" runat="server">
        <div align="center">
            <asp:Label ID="lblTituloInformes" runat="server" Text="Lista Informes" Style="font-weight: 700"></asp:Label>
            <br /><br />  
            <div style="font-size: small; color: #0000FF;" align="left">* El registro del informe se encuentra en color amarillo cuando el informe se encuentra LEVANTADO<br />
                        
<br />
        </div>

            <asp:GridView ID="gvDatosInformes" runat="server"
                AllowPaging="True" PageSize="15"
                AutoGenerateColumns="False"
                EnableTheming="True"
                Font-Names="Arial"
                Font-Size="9pt"
                CssClass="mGrid"
                PagerStyle-CssClass="pgr"
                AlternatingRowStyle-CssClass="alt"
                GridLines="None"
                DataKeyNames="IdTramite,IdGrupoBeneficio,NroControl,Informe,Verificador,Revisor,FechaInforme,IdRolRevisor,RegistroActivo,IdUsuarioRegistro,NroCrenta,IdTipoInforme,TipoInforme,EstadoRegistro"
                OnRowCommand="gvDatosInformes_RowCommand"
                OnRowDataBound="gvDatosInformes_RowDataBound">

                <Columns>
                    <asp:BoundField DataField="IdTramite" HeaderText="Tramite" />
                    <asp:BoundField DataField="NroControl" HeaderText="Nro de Control" Visible="true" />
                    <asp:BoundField DataField="TipoInforme" HeaderText="Tipo Informe" Visible="true" />
                    <asp:BoundField DataField="FechaInforme" HeaderText="Fecha del Informe" />
                    <asp:BoundField DataField="Verificador" HeaderText="Login Ver." />
                    <asp:BoundField DataField="Revisor" HeaderText="Login Rev." />
                    <asp:BoundField DataField="EstadoRegistro" HeaderText="Estado" />
                    <asp:TemplateField HeaderText="Actividad">
                        <ItemTemplate>
                            <center>
                                <asp:Button ID="imgEditar" runat="server" Text="Editar" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdEditar"  ToolTip="Editar Informe" alt="Editar Informe" />
                                <asp:Button ID="imgLevantar" runat="server" Text="Levantar" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdLevantar"  ToolTip="Levantar Informe" alt="Levantar Informe" OnClientClick="return confirm('Esta seguro de levantar el informe?');" />
                                <asp:Button ID="imgEliminar" runat="server" Text="Eliminar" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdEliminar"  ToolTip="Eliminar Informe" alt="Eliminar Informe" OnClientClick="return confirm('Esta seguro de eliminar el informe?');" />
                                

                                <asp:Button ID="imgVer" runat="server" Text="Imprimir" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdVer" ImageUrl="~/imagenes/32TramiteAcepta.gif" ToolTip="Visualilzar Informe" alt="Visualizar Informe" />
                                
                            </center>
                        </ItemTemplate>
                    </asp:TemplateField>
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
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlEditarInforme" runat="server" Visible="false" HorizontalAlign="Center">
        <asp:Label ID="Label2" runat="server" Text="Informe del tramite" Style="font-weight: 700"></asp:Label>
        <br />
        <br />        
        <div align="center">
        <asp:RadioButtonList ID="rbTipoInforme" runat="server">
            <asp:ListItem Value="1">Observado</asp:ListItem>
            <asp:ListItem Value="2">Certificado</asp:ListItem>

        </asp:RadioButtonList>
            </div>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="rbTipoInforme">Seleccione una opción</asp:RequiredFieldValidator>
        <br />
       <%-- <CKEditor:CKEditorControl ID="ckeInforme" runat="server" Height="200px"></CKEditor:CKEditorControl>--%>

        <asp:TextBox ID="ckeInforme" runat="server" Columns="50" Height="238px" onfocus="selecciona_value(this)" Rows="5" Style="text-transform: uppercase" TextMode="multiline" Width="702px"></asp:TextBox>

        <br />
        <asp:Button ID="btnActualizar" runat="server" OnClick="btnActualizar_Click" Text="Actualizar Informe" Visible="false" />
        <asp:Button ID="btnInsertarInforme" runat="server" OnClick="btnIngresarInforme_Click" Text="Insertar Informe" Visible="false" />
        &nbsp;<asp:Button ID="btnCancelarInforme" runat="server" OnClick="btnCancelarInforme_Click" Text="Cancelar" />
        <br />
    </asp:Panel>

</asp:Content>

