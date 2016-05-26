<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmConvenios.aspx.cs" Inherits="PagoCC_wfrmConvenios" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript" language="javascript">
        function ModalPopup() {
            var vpRND = Math.random() * 20;
            showModalDialog('\ModalRol.aspx?rn=' + vpRND, '', 'dialogWidth=640px; dialogHeight=320px; center=yes; scrollbars=no');
        }

        function permite(elEvento, permitidos) {
            // Variables que definen los caracteres permitidos
            var numeros = "0123456789";
            var caracteres = " abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ";
            var numeros_caracteres = numeros + caracteres;
            var teclas_especiales = [8, 37, 39, 46];
            // 8 = BackSpace, 46 = Supr, 37 = flecha izquierda, 39 = flecha derecha


            // Seleccionar los caracteres a partir del parámetro de la función
            switch (permitidos) {
                case 'num':
                    permitidos = numeros;
                    break;
                case 'car':
                    permitidos = caracteres;
                    break;
                case 'num_car':
                    permitidos = numeros_caracteres;
                    break;
            }

            // Obtener la tecla pulsada 
            var evento = elEvento || window.event;
            var codigoCaracter = evento.charCode || evento.keyCode;
            var caracter = String.fromCharCode(codigoCaracter);

            // Comprobar si la tecla pulsada es alguna de las teclas especiales
            // (teclas de borrado y flechas horizontales)
            var tecla_especial = false;
            for (var i in teclas_especiales) {
                if (codigoCaracter == teclas_especiales[i]) {
                    tecla_especial = true;
                    break;
                }
            }

            // Comprobar si la tecla pulsada se encuentra en los caracteres permitidos
            // o si es una tecla especial
            return permitidos.indexOf(caracter) != -1 || tecla_especial;
        }

        function Periodos() {
            var p1 = document.getElementById('<%=ddlInicio.ClientID%>').value;
            var p2 = document.getElementById('<%=ddlFinal.ClientID%>').value;
            if (p1 > p2) {
                document.getElementById('<%=ddlInicio.ClientID%>').value = p2;
                //alert('Periodo Inicio no puede ser mayor a Periodo Final');
            }
            if (p2 < p1) {
                document.getElementById('<%=ddlFinal.ClientID%>').value = p1;
                //alert('Periodo Final no puede ser menor a Periodo Inicio');
            }
        }

        function Probando() {
            var texto = document.getElementById('<%=txtObservaciones.ClientID%>').value;
            if (/^[A-Za-z0-9]{0,80}$/.test(texto)) {
                //alert('paso prueba');
            }
            else {
                //alert('no pasa');
            }
        }

    </script>
    <style type="text/css">
        .auto-style1
        {
            height: 31px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%">
        <tr>
            <td width="100%" align="center">
                <asp:ImageButton ID="imgAux" runat="server" ImageUrl="~/Imagenes/pequeños/Favorites_32x32.png" />
                <asp:Label ID="lblTituloAUX" runat="server"
                    Text="Tareas Adicionales" CssClass="etiqueta20" Font-Size="16pt"></asp:Label>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td width="50%" align="right">
                Entidad:&nbsp;&nbsp;&nbsp;
            </td>
            <td width="50%" align="left">
                <asp:DropDownList ID="ddlEntidad" runat="server" Width="200px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td width="50%" align="right">
                Periodo:&nbsp;&nbsp;&nbsp;
            </td>
            <td width="50%" align="left">
                <asp:DropDownList ID="ddlPeriodo" runat="server" Width="100px">
                </asp:DropDownList>
            </td>
        </tr>
         <tr>
            <td width="50%" align="right">
                Proceso:&nbsp;&nbsp;&nbsp;
            </td>
            <td width="50%" align="left">
                <asp:DropDownList ID="ddlProceso" runat="server" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="ddlProceso_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td width="100%" align="center">
                <asp:Panel ID="pnlPagos" runat="server" Visible="False">
                    <table width="100%">
                        <tr>
                            <td width="100%" align="center">
                                <asp:Button ID="btnIncrementoGestion" runat="server" OnClick="btnIncrementoGestion_Click" Text="Incrementos de Gestión" />     
                            </td>
                        </tr>
                        <tr>
                            <td width="100%" align="center">
                                <asp:Button ID="btnConvenios" runat="server" OnClick="btnConvenios_Click" Text="Generar Transacciones" OnClientClick="javascript : return confirm('Esta seguro de realizar esta accion?');" />
                            </td>
                        </tr>
                        <tr>
                            <td width="100%" align="center">
                                <asp:Button ID="btnConsolidar" runat="server" OnClick="btnConsolidar_Click" Text="Consolidar Pagos CC" OnClientClick="javascript : return confirm('Esta seguro de realizar esta accion?');" />
                            </td>
                        </tr>
                        <tr>
                            <td width="100%" align="center">

                                <asp:Button ID="btnFormC31" runat="server" OnClick="btnFormC31_Click" Text="Registrar Form C31" />

                            </td>
                        </tr>
                        <tr>
                            <td width="100%" align="center" height="35px" valign="bottom">
                                <asp:Label ID="lblTituloResumen" runat="server" Font-Size="14pt" ForeColor="#0099FF" Text="Resumen Transacciones Generadas" Visible="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="100%" align="center">

                                <asp:GridView ID="gvResumen" runat="server" CellPadding="4" ForeColor="#333333" AutoGenerateColumns="False" Visible="False">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:BoundField DataField="Fila" HeaderText="Nro." />
                                        <asp:BoundField DataField="TipoConvenio" HeaderText="Tipo Convenio" />
                                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad de Casos" />
                                </Columns>
                                <EmptyDataTemplate>
                                    <div align="center" class="CajaDialogoAdvertencia">
                                    <br/>
                                    <img src="../Imagenes/warning.gif" alt="No existen datos de convenios" />
                                    <br/>No existen datos de convenios<br/><br/>
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
                            <td width="100%" align="center">
                                <asp:Button ID="btnTransacciones" runat="server" Text="Detallar Transacciones" Visible="False" OnClick="btnTransacciones_Click" />
                        </td>
                        </tr>
                        <tr>
                            <td width="100%" align="center" height="35px" valign="bottom">
                                <asp:Label ID="lblTituloDetalle" runat="server" Font-Size="14pt" ForeColor="#0099FF" Text="Detalle Transacciones de Convenio" Visible="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="100%" align="center">
                                <asp:GridView ID="gvDetalle" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Size="9pt" ForeColor="#333333" AllowPaging="True" Visible="False" OnPageIndexChanging="gvDetalle_PageIndexChanging" OnRowCommand="gvDetalle_RowCommand">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:BoundField DataField="Fila" HeaderText="Nro." />
                                        <asp:BoundField DataField="Entidad" HeaderText="Entidad" />
                                        <asp:BoundField DataField="CodigoPlanilla" HeaderText="Planilla" />
                                        <asp:BoundField DataField="PeriodoPlanilla" HeaderText="Periodo" />
                                        <asp:BoundField DataField="CUA" HeaderText="CUA" />
                                        <asp:BoundField DataField="NumeroCertificado" HeaderText="Nro. Certificado" />
                                        <asp:BoundField DataField="TipoCC" HeaderText="Tipo CC" />
                                        <asp:BoundField DataField="NumeroDocumento" HeaderText="Numero Documento" />
                                        <asp:BoundField DataField="CodigoTransaccion" HeaderText="Transacción" />
                                        <asp:BoundField DataField="MontoTransaccion" HeaderText="Monto" />
                                        <asp:BoundField DataField="FechaInicio" HeaderText="Fecha Inicio" />
                                        <asp:BoundField DataField="FechaFin" HeaderText="Fecha Fin" />
                                        <asp:BoundField DataField="Regional" HeaderText="Regional" />
                                        <asp:BoundField DataField="TipoPlanilla" HeaderText="Tipo Planilla" />
                                        <asp:ButtonField ButtonType="Image" CommandName="cmdEditar" ImageUrl="~/Imagenes/iconos16x16/Edit_16x16.png" />
                                        <asp:ButtonField ButtonType="Image" CommandName="cmdEliminar" ImageUrl="~/Imagenes/iconos16x16/Delete_16x16.png" />
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <div align="center" class="CajaDialogoAdvertencia">
                                        <br/>
                                        <img src="../Imagenes/warning.gif" alt="No existen Transacciones de Convenio Genradas" />
                                        <br/>No existen Transacciones de Convenio Genradas<br/><br/>
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
                            <td width="100%" align="center">
                                <asp:Button ID="btnInsertar" runat="server" Text="Insertar Transacciones" Visible="False" OnClientClick="javascript : return confirm('Esta seguro de realizar esta accion?');" OnClick="btnInsertar_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td width="100%" align="center">

                                <asp:Label ID="lblTituloIncrementos" runat="server" Font-Size="14pt" ForeColor="#0099FF" Text="Detalle Incrementos de Gestión" Visible="False"></asp:Label>

                            </td>
                        </tr>
                        <tr>
                            <td width="100%" align="center">
                                <asp:GridView ID="gvIncrementos" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" Font-Size="10pt" ForeColor="#333333" OnPageIndexChanging="gvIncrementos_PageIndexChanging" OnRowCommand="gvIncrementos_RowCommand" DataKeyNames="IdTipoCC">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:BoundField DataField="Fila" HeaderText="Nro." />
                                        <asp:BoundField DataField="Gestion" HeaderText="Gestión" />
                                        <asp:BoundField DataField="IdIntervalo" HeaderText="Intervalo" />
                                        <asp:BoundField DataField="IdTipoCC" HeaderText="IdTipoCC" />
                                        <asp:BoundField DataField="TipoCC" HeaderText="Tipo CC" />
                                        <asp:BoundField DataField="MontoInferiorBs" HeaderText="Monto Inferiror" />
                                        <asp:BoundField DataField="MontoSuperiorBs" HeaderText="Monto Superior" />
                                        <asp:BoundField DataField="IncrementoBs" HeaderText="Incremento" />
                                        <asp:BoundField DataField="PorcentajeIncremento" HeaderText="Porcentaje" />
                                        <asp:BoundField DataField="Estado" HeaderText="Estado" />
                                        <asp:ButtonField ButtonType="Image" CommandName="cmdEditar" ImageUrl="~/Imagenes/iconos16x16/Edit_16x16.png" />
                                        <asp:ButtonField ButtonType="Image" CommandName="cmdEliminar" ImageUrl="~/Imagenes/iconos16x16/Delete_16x16.png" />
                                    </Columns>
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
                            <td width="100%" align="center">

                                <asp:Button ID="btnRegistraIncremento" runat="server" Text="Nuevo Incremento Gestión" OnClick="btnRegistraIncremento_Click" Visible="False" />

                            </td>
                        </tr>
                        <tr>
                            <td width="100%" align="center">

                                <asp:Label ID="lblTituloConsolidado" runat="server" Font-Size="14pt" ForeColor="#0099FF" Text="Detalle Consolidación" Visible="False"></asp:Label>

                            </td>
                        </tr>
                        <tr>
                            <td width="100%" align="center">

                                <asp:GridView ID="gvConsolidados" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Size="10pt" ForeColor="#333333">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:BoundField DataField="PR" HeaderText="Total Pagos Regulares" />
                                        <asp:BoundField DataField="PF" HeaderText="Total Pagos FFAA" />
                                        <asp:BoundField DataField="ATR" HeaderText="Titulares Regulares" />
                                        <asp:BoundField DataField="ATF" HeaderText="Titulares FFAA" />
                                        <asp:BoundField DataField="ABR" HeaderText="Derechohabientes Regulares" />
                                        <asp:BoundField DataField="ABF" HeaderText="Derechohabientes FFAA" />
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <div align="center" class="CajaDialogoAdvertencia">
                                        <br/>
                                        <img src="../Imagenes/warning.gif" alt="No existen datos de la consolidadción" />
                                        <br/>No existen datos de la consolidadción<br/><br/>
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
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td width="100%" align="center">
                <asp:Panel ID="pnlConciliaciones" runat="server" Visible="False">
                    <table width="100%">
                        <tr>
                            <td width="100%" align="center"> 
                                <asp:Button ID="btnGeneraMedios" runat="server" OnClick="btnGeneraMedios_Click" Text="Generar Medios de Respuesta" OnClientClick="javascript : return confirm('Esta seguro de realizar esta accion?');" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <asp:LinkButton ID="lblDescargaMedioOk" runat="server" OnClick="lblDescargaMedioOk_Click" Visible="False">Descarga Aceptados</asp:LinkButton>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:PostBackTrigger ControlID="lblDescargaMedioOk" />
                                </Triggers>
                                </asp:UpdatePanel>

                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:LinkButton ID="lblDescargaMediosError" runat="server" OnClick="lblDescargaMediosError_Click" Visible="False">Descarga Erroneos</asp:LinkButton>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:PostBackTrigger ControlID="lblDescargaMediosError" />
                                </Triggers>
                                </asp:UpdatePanel>
                                
                            </td>
                        </tr>
                        <tr>
                            <td width="100%" align="center"> 
                                <asp:Button ID="btnConsolidarCon" runat="server" OnClick="btnConsolidar_Click" Text="Consolidar Conciliaciones" OnClientClick="javascript : return confirm('Esta seguro de realizar esta accion?');" />
                            </td>
                        </tr>
                        <tr>
                            <td width="100%" align="center">                   
                                <asp:TextBox ID="txtComprobante" runat="server" Width="300px"></asp:TextBox>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnComprobante" runat="server" Text="Comprobante Devolución" OnClick="btnComprobante_Click" OnClientClick="javascript : return confirm('Esta seguro de forzar esta accion?');" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" width="100%">
                                <asp:Label ID="lblTituloFiltros" runat="server" Font-Size="14pt" ForeColor="#0099FF" Text="Filtros de Información" Visible="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="100%" align="center">
                                <table width="100%">
                                    <tr>
                                        <td width="35%">
                                            Tipo Consulta:
                                            <asp:DropDownList ID="ddlFiltroDatos" runat="server" Width="300px" OnSelectedIndexChanged="ddlFiltroDatos_SelectedIndexChanged">
                                            <asp:ListItem Value="MontosActas">Montos para las Actas</asp:ListItem>
                                            <asp:ListItem Value="CantidadesCasos">Cantidad de Casos Conciliados</asp:ListItem>
                                            <asp:ListItem Value="CasosPendientes">Casos Pendientes de Conciliación</asp:ListItem>
                                            <asp:ListItem Value="CasosPendientesMontos">Montos de Casos Pendientes</asp:ListItem>
                                            <asp:ListItem Value="MontosTipoDevolucion">Montos por Tipo de Devolucion</asp:ListItem>
                                            <asp:ListItem Value="CobrosTipoBeneficiario">Cobros por Tipo de Beneficiario</asp:ListItem>
                                            <asp:ListItem Value="MontosCodigoTransaccion">Montos por Transaccion</asp:ListItem>
                                            <asp:ListItem Value="CobrosIndebidos">Cobros Indebidos</asp:ListItem>
                                            <asp:ListItem Value="ReversionesConsecutivas"></asp:ListItem>
                                            <asp:ListItem Value="MontosRegional">Montos por Regional</asp:ListItem>
                                            <asp:ListItem Value="CantidadErrores">Cantidad de Errores por tipo</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td width="21%">
                                            Tipo Planilla:
                                            <asp:DropDownList ID="ddlTipoPlanillaFiltros" runat="server" Width="150px">
                                            <asp:ListItem Value="CR">Conciliaciones Regulares</asp:ListItem>
                                            <asp:ListItem Value="CF">Conciliaciones FFAA</asp:ListItem>
                                            <asp:ListItem Value="CT">Conciliaciones Pagos Temporales</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td width="18%" align="right">
                                            Periodo Inicio:
                                            <asp:DropDownList ID="ddlInicio" runat="server" Width="80px" onchange="Periodos();"></asp:DropDownList>
                                        </td>
                                        <td width="18%">
                                            Periodo Final:
                                            <asp:DropDownList ID="ddlFinal" runat="server" Width="80px" onchange="Periodos();"></asp:DropDownList>
                                        </td>
                                        <td width="8%" align="left">
                                            <asp:Button ID="btnFiltrar" runat="server" OnClick="btnFiltrar_Click" Text="Filtrar..." />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td width="100%" align="center">
                                <asp:GridView ID="gvFiltrado" runat="server" CellPadding="4" Font-Size="10pt" ForeColor="#333333">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <EmptyDataTemplate>
                                        <div align="center" class="CajaDialogoAdvertencia">
                                        <br/>
                                        <img src="../Imagenes/warning.gif" alt="No existen datos para el criterio de filtro" />
                                        <br/>No existen datos para el criterio de filtro<br/><br/>
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
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td width="100%" align="center">
                <asp:Panel ID="pnlReposiciones" runat="server" Visible="False">
                    <table width="100%">
                        <tr>
                            <td width="100%" align="center" class="auto-style1">
                                <asp:Button ID="btnConsolidarRep" runat="server" OnClick="btnConsolidar_Click" Text="Consolidar Reposiciones" OnClientClick="javascript : return confirm('Esta seguro de realizar esta accion?');" />
                            </td>
                        </tr>
                        <tr>
                            <td width="100%" align="center">

                                <asp:Label ID="lblTitulosRepos" runat="server" Font-Size="14pt" ForeColor="#0099FF" Text="Detalle Reposiciones" Visible="False"></asp:Label>

                            </td>
                        </tr>
                        <tr>
                            <td width="100%" align="center">
                                <asp:GridView ID="gvDetalleRepos" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" Font-Size="10pt" ForeColor="#333333" GridLines="None" OnPageIndexChanging="gvDetalleRepos_PageIndexChanging" Visible="False">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:BoundField DataField="Entidad" HeaderText="Entidad" />
                                        <asp:BoundField DataField="CodigoPlanilla" HeaderText="Planilla" />
                                        <asp:BoundField DataField="CUA" HeaderText="CUA" />
                                        <asp:BoundField DataField="NumeroCertificado" HeaderText="Certificado" />
                                        <asp:BoundField DataField="NumeroDocumento" HeaderText="Documento" />
                                        <asp:BoundField DataField="PeriodoPlanilla" HeaderText="Periodo Planilla" />
                                        <asp:BoundField DataField="FechaInicio" HeaderText="Fecha Inicio" />
                                        <asp:BoundField DataField="Transaccion" HeaderText="Trans" />
                                        <asp:BoundField DataField="Monto" HeaderText="Monto" />
                                        <asp:BoundField DataField="PeriodoSolicitud" HeaderText="Periodo Solicitud" />
                                    </Columns>
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
                </asp:Panel>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td>
                <asp:Panel ID="pnlFormC31" runat="server" CssClass="panelceleste"  HorizontalAlign="Center" Width="700px">
                    <div>
                        <asp:Label ID="lblTitulo" runat="server" Text="Registrar Fomulario C31"
                            CssClass="etiqueta20"></asp:Label>
                        <table style="width: 100%;">
                            <tr>
                                <td align="right" style="width: 30%">&nbsp;</td>
                                <td align="left" width="70%">
                                    <asp:Label ID="lblObservaciones" runat="server" CssClass="text_obs"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style5">
                                    <asp:Label ID="Label8" runat="server" Text="Número Formulario:" CssClass="etiqueta10"></asp:Label>
                                </td>
                                <td align="left" class="auto-style5">

                                    <asp:TextBox ID="txtNumeroC31" runat="server" onkeypress="return permite(event, 'num')"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style5">
                                    <asp:Label ID="Label9" runat="server" Text="Año:" CssClass="etiqueta10"></asp:Label>
                                </td>
                                <td align="left" class="auto-style5">
                                    
                                    <asp:DropDownList ID="ddlAnio" runat="server">
                                    </asp:DropDownList>
                                  
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style5">
                                    <asp:Label ID="Label10" runat="server" Text="Mes:" CssClass="etiqueta10"></asp:Label>
                                </td>
                                <td align="left" class="auto-style5">

                                    <asp:DropDownList ID="ddlMes" runat="server">
                                    </asp:DropDownList>

                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style5">
                                    <asp:Label ID="Label1" runat="server" Text="Entidad Financiera:" CssClass="etiqueta10"></asp:Label>
                                </td>
                                <td align="left" class="auto-style5">

                                    <asp:DropDownList ID="ddlFinanciera" runat="server" Width="300px">
                                    </asp:DropDownList>

                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style5">
                                    <asp:Label ID="Label2" runat="server" Text="Grupo Beneficio:" CssClass="etiqueta10"></asp:Label>
                                </td>
                                <td align="left" class="auto-style5">

                                    <asp:DropDownList ID="ddlGrupoBeneficio" runat="server" Width="300px" AutoPostBack="true" OnSelectedIndexChanged="ddlGrupoBeneficio_SelectedIndexChanged">
                                    </asp:DropDownList>

                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style5">
                                    <asp:Label ID="Label6" runat="server" Text="Beneficio:" CssClass="etiqueta10"></asp:Label>
                                </td>
                                <td align="left" class="auto-style5">

                                    <asp:DropDownList ID="ddlBeneficio" runat="server" Width="300px">
                                    </asp:DropDownList>

                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style5">
                                    <asp:Label ID="Label3" runat="server" Text="Monto:" CssClass="etiqueta10"></asp:Label>
                                </td>
                                <td align="left" class="auto-style5">

                                    <asp:TextBox ID="txtMonto" runat="server" ReadOnly="True"></asp:TextBox>

                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style5">
                                    <asp:Label ID="Label4" runat="server" Text="Observaciones:" CssClass="etiqueta10"></asp:Label>
                                </td>
                                <td align="left" class="auto-style5">

                                    <asp:TextBox ID="txtObservaciones" runat="server" Rows="4" TextMode="MultiLine" Width="300px"></asp:TextBox>

                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 50%">
                                    <asp:HiddenField ID="hfIdArchivo" runat="server" />
                                </td>
                                <td align="left">
                                    &nbsp;</td>
                            </tr>

                            <tr>
                                <td align="right" style="width: 50%">&nbsp;</td>
                                <td align="left">
                                    <asp:Button ID="btnCancelar" runat="server" EnableTheming="True"
                                        OnClick="btnCancelar_Click" Text="Cancelar"
                                        CssClass="boton150" />
                                    <asp:Button ID="btnAccionar" runat="server" OnClick="btnAccionar_Click"
                                        OnClientClick="javascript : return confirm('Esta seguro de forzar esta accion?');"
                                        Text="Adicionar" CssClass="boton150" />
                                </td>
                            </tr>

                        </table>

                    </div>
                </asp:Panel>
                <cc1:RoundedCornersExtender ID="pnlFormC31_RoundedCornersExtender" runat="server"
                    Enabled="True" TargetControlID="pnlFormC31" Radius="10" BorderColor="Black">
                </cc1:RoundedCornersExtender>
                <cc1:ModalPopupExtender ID="pnlFormC31_ModalPopupExtender" runat="server"
                    Enabled="True"
                    TargetControlID="lblTitulo"
                    CancelControlID="btnCancelar"
                    PopupControlID="pnlFormC31"
                    BackgroundCssClass="modalBackground">
                </cc1:ModalPopupExtender>
            </td>
        </tr>
        <tr>
            <td width="100%">

            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlIncremento" runat="server" CssClass="panelceleste"  HorizontalAlign="Center" Width="700px">
                    <div>
                        <asp:Label ID="lblTituloIncremento" runat="server" Text="Registrar parametros para Incremento"
                            CssClass="etiqueta20"></asp:Label>
                        <table style="width: 100%;">
                            <tr>
                                <td align="right" style="width: 30%">&nbsp;</td>
                                <td align="left" width="70%">
                                    <asp:Label ID="Label12" runat="server" CssClass="text_obs"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style5">
                                    <asp:Label ID="Label13" runat="server" Text="Getión:" CssClass="etiqueta10"></asp:Label>
                                </td>
                                <td align="left" class="auto-style5">

                                    <asp:DropDownList ID="ddlGestion" runat="server" ToolTip="Seleccione codigo de error"  Width="100px">
                                    </asp:DropDownList>
                                    &nbsp;&nbsp;
                                    </td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style5">
                                    <asp:Label ID="Label14" runat="server" Text="Tipo CC:" CssClass="etiqueta10"></asp:Label>
                                </td>
                                <td align="left" class="auto-style5">

                                    <asp:DropDownList ID="ddlTipoCC" runat="server" Width="60px">
                                        <asp:ListItem Value="358">M</asp:ListItem>
                                        <asp:ListItem Value="359">G</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style5">
                                    <asp:Label ID="Label15" runat="server" Text="Monto Inferior Bs:" CssClass="etiqueta10"></asp:Label>
                                </td>
                                <td align="left" class="auto-style5">

                                    <asp:TextBox ID="txtMontoInferior" runat="server" onkeypress="return permite(event, 'num')"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style5">
                                    <asp:Label ID="Label16" runat="server" Text="Monto Superior Bs:" CssClass="etiqueta10"></asp:Label>
                                </td>
                                <td align="left" class="auto-style5">
                                    
                                    <asp:TextBox ID="txtMontoSuperior" runat="server" onkeypress="return permite(event, 'num')"></asp:TextBox>
                                  
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style5">
                                    <asp:Label ID="Label17" runat="server" Text="Incremento Bs:" CssClass="etiqueta10"></asp:Label>
                                </td>
                                <td align="left" class="auto-style5">

                                    <asp:TextBox ID="txtIncremento" runat="server" onkeypress="return permite(event, 'num')"></asp:TextBox>

                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style5">
                                    <asp:Label ID="Label18" runat="server" Text="Porcentaje Incremento:" CssClass="etiqueta10"></asp:Label>
                                </td>
                                <td align="left" class="auto-style5">

                                    <asp:TextBox ID="txtPorcentaje" runat="server" onkeypress="return permite(event, 'num')"></asp:TextBox>

                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 50%">
                                    <asp:HiddenField ID="hfIdArchivoIncremento" runat="server" />
                                </td>
                                <td align="left">
                                    &nbsp;</td>
                            </tr>

                            <tr>
                                <td align="right" style="width: 50%">&nbsp;</td>
                                <td align="left">
                                    <asp:Button ID="btnCancelarIncremento" runat="server" OnClick="btnCancelarIncremento_Click"
                                        Text="Cancelar" CssClass="boton150" />
                                    <asp:Button ID="btnAccionarIncremento" runat="server" EnableTheming="True"
                                        OnClick="btnAccionarIncremento_Click" Text="Adicionar"
                                        CssClass="boton150" OnClientClick="javascript : return confirm('Esta seguro de realizar esta accion?');" />
                                </td>
                            </tr>

                        </table>

                    </div>
                </asp:Panel>
                <cc1:RoundedCornersExtender ID="pnlIncremento_RoundedCornersExtender1" runat="server"
                    Enabled="True" TargetControlID="pnlIncremento" Radius="10" BorderColor="Black">
                </cc1:RoundedCornersExtender>
                <cc1:ModalPopupExtender ID="pnlIncremento_ModalPopupExtender" runat="server"
                    Enabled="True"
                    TargetControlID="lblTituloIncremento"
                    CancelControlID="btnCancelarIncremento"
                    PopupControlID="pnlIncremento"
                    BackgroundCssClass="modalBackground">
                </cc1:ModalPopupExtender>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlConvenios" runat="server" CssClass="panelceleste"  HorizontalAlign="Center" Width="700px">
                    <div>
                        <asp:Label ID="lblTituloConvenios" runat="server" Text="Modificar el monto de Convenio"
                            CssClass="etiqueta20"></asp:Label>
                        <table style="width: 100%;">
                            <tr>
                                <td align="right" style="width: 30%">&nbsp;</td>
                                <td align="left" width="70%">
                                    <asp:Label ID="Label7" runat="server" CssClass="text_obs"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style5">
                                    <asp:Label ID="Label22" runat="server" Text="Monto Convenio Bs:" CssClass="etiqueta10"></asp:Label>
                                </td>
                                <td align="left" class="auto-style5">

                                    <asp:TextBox ID="txtMontoConv" runat="server" onkeypress="return permite(event, 'num')"></asp:TextBox>

                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 50%">
                                    <asp:HiddenField ID="hfConvenio" runat="server" />
                                </td>
                                <td align="left">
                                    &nbsp;</td>
                            </tr>

                            <tr>
                                <td align="right" style="width: 50%">&nbsp;</td>
                                <td align="left">
                                    <asp:Button ID="btnCancelarConv" runat="server" OnClick="btnCancelarConv_Click"
                                        Text="Cancelar" CssClass="boton150" />
                                    <asp:Button ID="btnAccionarConv" runat="server" EnableTheming="True"
                                        OnClick="btnAccionarConv_Click" Text="Adicionar"
                                        CssClass="boton150" OnClientClick="javascript : return confirm('Esta seguro de realizar esta accion?');" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </asp:Panel>
                <cc1:RoundedCornersExtender ID="RoundedCornersExtender1" runat="server"
                    Enabled="True" TargetControlID="pnlConvenios" Radius="10" BorderColor="Black">
                </cc1:RoundedCornersExtender>
                <cc1:ModalPopupExtender ID="pnlConvenios_ModalPopupExtender" runat="server"
                    Enabled="True"
                    TargetControlID="lblTituloConvenios"
                    CancelControlID="btnCancelarConv"
                    PopupControlID="pnlConvenios"
                    BackgroundCssClass="modalBackground">
                </cc1:ModalPopupExtender>
            </td>
        </tr>
    </table>
</asp:Content>

