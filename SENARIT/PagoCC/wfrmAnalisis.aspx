<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmAnalisis.aspx.cs" Inherits="PagoCC_wfrmAnalisis" %>
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
             var teclas_especiales = [8, 9, 37, 39, 46];
             // 8 = BackSpace, 9=TAB, 46 = Supr, 37 = flecha izquierda, 39 = flecha derecha


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
             var p1 = document.getElementById('<%=txtPeriodoInicio.ClientID%>').value;
             var p2 = document.getElementById('<%=txtPeriodoFinal.ClientID%>').value;
             if (p1 > p2) {
                 document.getElementById('<%=txtPeriodoInicio.ClientID%>').value = p2;
                //alert('Periodo Inicio no puede ser mayor a Periodo Final');
            }
            if (p2 < p1) {
                 document.getElementById('<%=txtPeriodoFinal.ClientID%>').value = p1;
                //alert('Periodo Final no puede ser menor a Periodo Inicio');
            }
        }

    </script>
    
    <style type="text/css">
        .auto-style5
        {
            height: 23px;
        }
        .auto-style6
        {
            color: #FF0000;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" class="panelceleste">
        <tr>
            <td>
    <table width="100%">
        <tr>
            <td width="100%" align="center">
                <asp:ImageButton ID="imgAux" runat="server" ImageUrl="~/Imagenes/pequeños/Favorites_32x32.png" />
                <asp:Label ID="lblTituloAUX" runat="server"
                    Text="Información Persona" CssClass="etiqueta20"></asp:Label>
                </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td width="40%" align="right" colspan="1">
                Primer Apellido: <asp:TextBox ID="txtPrimerApellido" runat="server" Width="150px" onkeyup="this.value=this.value.toUpperCase()" onkeypress="return permite(event, 'car')"></asp:TextBox>
            </td>
            <td width="40%" align="right" colspan="1">
                Segundo Apellido: <asp:TextBox ID="txtSegundoApellido" runat="server" Width="150px" onkeyup="this.value=this.value.toUpperCase()" onkeypress="return permite(event, 'car')"></asp:TextBox>
            </td>
            <td width="20%">

            </td>
        </tr>
        <tr>
            <td width="40%" align="right" colspan="1">
                Primer Nombre: <asp:TextBox ID="txtPrimerNombre" runat="server" Width="150px" onkeyup="this.value=this.value.toUpperCase()" onkeypress="return permite(event, 'car')"></asp:TextBox>
            </td>
            <td width="40%" align="right" colspan="1">
                Segundo Nombre: <asp:TextBox ID="txtSegundoNombre" runat="server" Width="150px" onkeyup="this.value=this.value.toUpperCase()" onkeypress="return permite(event, 'car')"></asp:TextBox>
            </td>
            <td width="20%">

            </td>
        </tr>
        <tr>
            <td width="40%" align="right" colspan="1">
                Documento de Identidad: <asp:TextBox ID="txtCI" runat="server" Width="150px" onkeypress="return permite(event, 'num')"></asp:TextBox>
            </td>
            <td width="40%" align="right" colspan="1">
                Matrícula: <asp:TextBox ID="txtMatricula" runat="server" Width="150px" onkeyup="this.value=this.value.toUpperCase()" onkeypress="return permite(event, 'num_car')"></asp:TextBox>
            </td>
            <td width="20%">

            </td>
        </tr>
        <tr>
            <td width="40%" align="right" colspan="1">
                CUA: <asp:TextBox ID="txtCUA" runat="server" Width="150px" onkeypress="return permite(event, 'num')"></asp:TextBox>
            </td>
            <td width="40%" align="right">
                NUP: <asp:TextBox ID="txtNUP" runat="server" Width="150px" onkeypress="return permite(event, 'num')" ReadOnly="True"></asp:TextBox>
                     <cc1:textboxwatermarkextender id="txtNUP_Textboxwatermarkextender" watermarktext="Solo lectura" watermarkcssclass="MarcaAgua" runat="server" enabled="True" targetcontrolid="txtNUP">                          
                     </cc1:textboxwatermarkextender>
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
                                    <cc1:textboxwatermarkextender id="txtFechaFallecimiento_TextBoxWatermarkExtender" watermarktext="Solo lectura" watermarkcssclass="MarcaAgua" runat="server" enabled="True" targetcontrolid="txtFechaFallecimiento">                          
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
                Tipo de Planilla: <asp:TextBox ID="txtTipoPlanilla" runat="server" Width="150px" ReadOnly="True"></asp:TextBox>
                                    <cc1:textboxwatermarkextender id="txtTipoPlanilla_Textboxwatermarkextender" watermarktext="Solo lectura" watermarkcssclass="MarcaAgua" runat="server" enabled="True" targetcontrolid="txtTipoPlanilla">                          
                                    </cc1:textboxwatermarkextender> 
            </td>
            <td width="40%" align="right" colspan="1">
                Entidad Gestora: <asp:TextBox ID="txtEntidad" runat="server" Width="150px" ReadOnly="True"></asp:TextBox>
                                    <cc1:textboxwatermarkextender id="txtEntidad_Textboxwatermarkextender" watermarktext="Solo lectura" watermarkcssclass="MarcaAgua" runat="server" enabled="True" targetcontrolid="txtEntidad">                          
                                    </cc1:textboxwatermarkextender>
            </td>
            <td width="20%">

                <asp:Button ID="cmdBuscar" runat="server" Text="Buscar" Width="100px" OnClick="cmdBuscar_Click" />
                <asp:Button ID="cmdLimpiar" runat="server" Text="Limpiar" Width="100px" OnClick="cmdLimpiar_Click" />

            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td width="100%" align="left">
                <asp:Label ID="Label1" runat="server" Text="Resultados de la busqueda..."></asp:Label>
            </td>
        </tr>
         <tr>
            <td width="100%" align="center">

                <asp:GridView ID="gvBusqueda" runat="server" CellPadding="4" ForeColor="#333333" AutoGenerateColumns="False" DataKeyNames="Fila,EstadoCivil,TipoPlanilla,FechaNacimiento,FechaFallecimiento,Sexo,Entidad" DataSourceID="odsBuscaPersona" OnSelectedIndexChanged="gvBusqueda_SelectedIndexChanged" Visible="False" Font-Size="10pt">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:BoundField DataField="Fila" HeaderText="Nro." />
                        <asp:BoundField DataField="NUP" HeaderText="NUP" />
                        <asp:BoundField DataField="CUA" HeaderText="CUA" />
                        <asp:BoundField DataField="NumeroCertificado" HeaderText="Certificado" />
                        <asp:BoundField DataField="TipoCC" HeaderText="Tipo CC" />
                        <asp:BoundField DataField="NumeroDocumento" HeaderText="Nro Documento" />
                        <asp:BoundField DataField="PrimerApellido" HeaderText="Paterno" />
                        <asp:BoundField DataField="SegundoApellido" HeaderText="Materno" />
                        <asp:BoundField DataField="PrimerNombre" HeaderText="Primer Nombre" />
                        <asp:BoundField DataField="SegundoNombre" HeaderText="Segundo Nombre" />
                        <asp:BoundField DataField="Matricula" HeaderText="Matricula" />
                        <asp:BoundField DataField="IdHabilitacionTitularCC" HeaderText="IDHT" />
                        <asp:BoundField DataField="TIPO" HeaderText="Tipo" />
                        <asp:BoundField DataField="EstadoCivil" HeaderText="Estado Civil" Visible="False" />
                        <asp:BoundField DataField="TipoPlanilla" HeaderText="Tipo Planilla" Visible="False" />
                        <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha Nacimiento" Visible="False" />
                        <asp:BoundField DataField="FechaFallecimiento" HeaderText="Fecha Fallecimiento" Visible="False" />
                        <asp:BoundField DataField="Sexo" HeaderText="Sexo" Visible="False" />
                        <asp:BoundField DataField="Entidad" HeaderText="Entidad" Visible="False" />
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

                <asp:ObjectDataSource ID="odsBuscaPersona" runat="server" SelectMethod="ObtieneDatos" TypeName="wcfServicioIntercambioPago.Logica.clsPagoCC" OldValuesParameterFormatString="original_{0}">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="VACIO" Name="Tipo" Type="String" />
                        <asp:Parameter Name="Paterno" Type="String" />
                        <asp:Parameter Name="Materno" Type="String" />
                        <asp:Parameter Name="Nombre1" Type="String" />
                        <asp:Parameter Name="Nombre2" Type="String" />
                        <asp:Parameter Name="NumeroDocumento" Type="String" />
                        <asp:Parameter Name="Matricula" Type="String" />
                        <asp:Parameter DefaultValue="" Name="CUA" Type="String" />
                        <asp:Parameter Name="NUP" Type="Int64" />
                    </SelectParameters>
                </asp:ObjectDataSource>

            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="lblTitular" runat="server" ForeColor="#0099FF" Text="Habilitación Titular" Visible="False"></asp:Label>
                <asp:GridView ID="gvTitular" runat="server" CellPadding="4" Font-Size="10pt" ForeColor="#333333" Visible="False">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
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
            <td align="center">
                <asp:Label ID="lblBeneficiario" runat="server" ForeColor="#0099FF" Text="Habilitación Derechohabiente" Visible="False"></asp:Label>
                <asp:GridView ID="gvBeneficiario" runat="server" CellPadding="4" Font-Size="10pt" ForeColor="#333333" Visible="False">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
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
                <div style ="width:1000px; overflow:auto;">
                <asp:Label ID="Label4" runat="server" ForeColor="#0099FF" Text="Envios APS" Visible="False"></asp:Label>
                <asp:GridView ID="gvEnviosAPS" runat="server" CellPadding="4" Font-Size="10pt" ForeColor="#333333" Visible="False">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
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
            </td>
        </tr>
        <tr>
            <td width="100%" align="left" class="auto-style5">
                <asp:LinkButton ID="lnkPagos" runat="server" OnClick="LinkButton1_Click" Font-Bold="True" ForeColor="#0066CC" Visible="False">Pagos...</asp:LinkButton>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="lnkConciliaciones" runat="server" OnClick="LinkButton2_Click" Font-Bold="True" ForeColor="#0066CC" Visible="False">Conciliaciones...</asp:LinkButton>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="lnkReposiciones" runat="server" OnClick="lnkReposiciones_Click" Font-Bold="True" ForeColor="#0066CC" Visible="False">Reposiciones...</asp:LinkButton>
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="lnkSuspensiones" runat="server" OnClick="lnkSuspensiones_Click" Font-Bold="True" ForeColor="#0066CC" Visible="False">Suspensiones...</asp:LinkButton>
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="lnkConvenios" runat="server" OnClick="lnkConvenios_Click" Font-Bold="True" ForeColor="#0066CC" Visible="False">Convenios...</asp:LinkButton>
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="lnkFamilia" runat="server" OnClick="lnkFamilia_Click" Font-Bold="True" ForeColor="#0066CC" Visible="False">Grupo Familiar...</asp:LinkButton>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="lnkMontoGestion" runat="server" OnClick="lnkMontoGestion_Click" Font-Bold="True" ForeColor="#0066CC" Visible="False">Montos Gestión...</asp:LinkButton>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="linkMontoAguinaldo" runat="server" OnClick="linkMontoAguinaldos" Font-Bold="True" ForeColor="#0066CC" Visible="False">Montos Aguinaldo...</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td width="100%" align="center">
                <div style ="width:1000px; overflow:auto;">
                <asp:MultiView ID="MultiView1" runat="server">
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
                  
                    </asp:View>
                    <asp:View ID="Conicliaciones" runat="server">

                        <asp:Label ID="lblConciliacion" runat="server" Text="Historial de Conciliaciones" Font-Underline="True" Font-Size="14pt" ForeColor="#0066CC"></asp:Label>

                        <asp:GridView ID="gvConciliaciones" runat="server" AllowPaging="True" CellPadding="4" ForeColor="#333333" Font-Size="10pt" OnPageIndexChanging="gvConciliaciones_PageIndexChanging">
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

                    </asp:View>
                    <asp:View ID="Reposiciones" runat="server">

                        <asp:Label ID="lblReposicion" runat="server" Text="Historial de Reposiciones" Font-Underline="True" Font-Size="14pt" ForeColor="#0066CC"></asp:Label>

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
                    <asp:View ID="Suspensiones" runat="server">

                        <asp:Label ID="lblSuspensiones" runat="server" Text="Historial de Suspensiones" Font-Underline="True" Font-Size="14pt" ForeColor="#0066CC"></asp:Label>

                        <asp:GridView ID="gvSuspensiones" runat="server" CellPadding="4" ForeColor="#333333" Font-Size="10pt">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <EmptyDataTemplate>
                                <div align="center" class="CajaDialogoAdvertencia">
                                <br/>
                                <img src="../Imagenes/warning.gif" alt="El asegurado no cuenta con registros de Suspensiones" />
                                <br/>El asegurado no cuenta con registros de Susepensiones<br/><br/>
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
                    <asp:View ID="Convenios" runat="server">

                        <asp:Label ID="lblConvenios" runat="server" Text="Historial de Convenios" Font-Underline="True" Font-Size="14pt" ForeColor="#0066CC"></asp:Label>

                        <asp:GridView ID="gvConvenios" runat="server" CellPadding="4" ForeColor="#333333" Font-Size="10pt">
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

                    </asp:View>
                    <asp:View ID="Familia" runat="server">

                        <asp:Label ID="lblFamilia" runat="server" Text="Grupo Familiar" Font-Underline="True" Font-Size="14pt" ForeColor="#0066CC"></asp:Label>

                        <asp:GridView ID="gvFamilia" runat="server" CellPadding="4" ForeColor="#333333" Font-Size="10pt">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <EmptyDataTemplate>
                                <div align="center" class="CajaDialogoAdvertencia">
                                <br/>
                                <img src="../Imagenes/warning.gif" alt="El asegurado no cuenta con Derechohabientes Registrados" />
                                <br/>El asegurado no cuenta con Derechohabientes Registrados<br/><br/>
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
                    <asp:View ID="Gestion" runat="server">

                        <asp:Label ID="Label2" runat="server" Text="Armado de Montos Gestión" Font-Underline="True" Font-Size="14pt" ForeColor="#0066CC"></asp:Label>

                        <asp:GridView ID="gvMontosGestion" runat="server" CellPadding="4" ForeColor="#333333" Font-Size="10pt" AllowPaging="True" OnPageIndexChanging="gvMontosGestion_PageIndexChanging">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <EmptyDataTemplate>
                                <div align="center" class="CajaDialogoAdvertencia">
                                <br/>
                                <img src="../Imagenes/warning.gif" alt="El asegurado no cuenta con Montos Gestión Armados" />
                                <br/>El asegurado no cuenta con Montos Gestión Armados<br/><br/>
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
                        <asp:View ID="Aguinaldo" runat="server">

                        <asp:Label ID="Label3" runat="server" Text="Armado de Montos de Aguinaldo" Font-Underline="True" Font-Size="14pt" ForeColor="#0066CC"></asp:Label>

                        <asp:GridView ID="gvMontosAguinaldo" runat="server" CellPadding="4" ForeColor="#333333" Font-Size="10pt" AllowPaging="True" OnPageIndexChanging="gvMontosAguinaldo_PageIndexChanging">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <EmptyDataTemplate>
                                <div align="center" class="CajaDialogoAdvertencia">
                                <br/>
                                <img src="../Imagenes/warning.gif" alt="El asegurado no cuenta con Montos de Aguinaldos Armados" />
                                <br/>El asegurado no cuenta con Montos de Aguinaldos Armados<br/><br/>
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
            <td width="100%" align="left" class="auto-style5">

                <asp:Label ID="lblExcepciones" runat="server" Font-Bold="False" Font-Underline="True" Text="Exepciones registradas: " Font-Size="14pt" ForeColor="#0066CC" Visible="False"></asp:Label>

            </td>
        </tr>
        <tr>
            <td width="100%" align="center">

                <asp:ImageButton ID="imgNuevo" runat="server" ImageUrl="~/Imagenes/pequeños/Add_32x32.png" ToolTip="Agregar nueva Expeción" OnClick="imgNuevo_Click" Visible="False" />

                <asp:GridView ID="gvExcepciones" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" 
                    DataKeyNames="IdExcepcion,IdCodigoError" Font-Size="10pt" DataSourceID="odsExcepciones" Visible="False" SkinID="GridView" OnRowCommand="gvExcepciones_RowCommand">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="Fila" HeaderText="Nro." />
                        <asp:BoundField DataField="IdExcepcion" HeaderText="IdExcepcion" Visible="False" />
                        <asp:BoundField DataField="IdCodigoError" HeaderText="IdCodigoError" Visible="False" />
                        <asp:BoundField DataField="NUP" HeaderText="NUP" />
                        <asp:BoundField DataField="Proceso" HeaderText="Proceso" />
                        <asp:BoundField DataField="CodigoError" HeaderText="Error" />
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                        <asp:BoundField DataField="FechaRegistro" HeaderText="Fecha Registro" DataFormatString="{0:d}" />
                        <asp:BoundField DataField="CuentaUsuario" HeaderText="Usuario Registro" />
                        <asp:BoundField DataField="Justificacion" HeaderText="Justificación" />
                        <asp:BoundField DataField="PeriodoInicio" HeaderText="Periodo Inicio" />
                        <asp:BoundField DataField="PeriodoFinal" HeaderText="Periodo Final" />
                        <asp:BoundField DataField="Estado" HeaderText="Estado" />
                        <asp:ButtonField Text="Editar" CommandName="cmdEditar" ButtonType="Image" ImageUrl="~/Imagenes/iconos16x16/Edit_16x16.png" />
                        <asp:ButtonField CommandName="cmdDesactivar" Text="Desactivar" ButtonType="Image" ImageUrl="~/Imagenes/iconos16x16/Delete_16x16.png" />
                    </Columns>
                    <EmptyDataTemplate>
                        <div align="center" class="CajaDialogoAdvertencia">
                        <br/>
                        <img src="../Imagenes/warning.gif" alt="El asegurado no cuenta con Excepciones" />
                        <br/>El asegurado no cuenta con Excepciones<br/><br/>
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

                <asp:ObjectDataSource ID="odsExcepciones" runat="server" SelectMethod="ObtieneDatos" TypeName="wcfServicioIntercambioPago.Logica.clsPagoCC">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="Excepcion" Name="Tipo" Type="String" />
                        <asp:Parameter Name="Paterno" Type="String" />
                        <asp:Parameter Name="Materno" Type="String" />
                        <asp:Parameter Name="Nombre1" Type="String" />
                        <asp:Parameter Name="Nombre2" Type="String" />
                        <asp:Parameter Name="NumeroDocumento" Type="String" />
                        <asp:Parameter Name="Matricula" Type="String" />
                        <asp:Parameter Name="CUA" Type="String" />
                        <asp:Parameter Name="NUP" Type="Int64" />
                    </SelectParameters>
                </asp:ObjectDataSource>

            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlDatos" runat="server" CssClass="panelceleste"  HorizontalAlign="Center" Width="700px">
                    <div>
                        <asp:Label ID="lblTitulo" runat="server" Text="Agregar Exepción"
                            CssClass="etiqueta20"></asp:Label>
                        <table style="width: 100%;">
                            <tr>
                                <td align="right" style="width: 30%">&nbsp;</td>
                                <td align="left" width="70%">
                                    <asp:Label ID="lblObservaciones" runat="server" CssClass="text_obs"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style5">
                                    <asp:Label ID="Label5" runat="server" Text="Codigo de Error: " CssClass="etiqueta10"></asp:Label>
                                </td>
                                <td align="left" class="auto-style5">

                                    <asp:DropDownList ID="ddlError" runat="server" ToolTip="Seleccione codigo de error" OnSelectedIndexChanged="ddlError_SelectedIndexChanged" Width="270px" AutoPostBack="True">
                                    </asp:DropDownList>
                                    &nbsp;&nbsp;
                                    <asp:TextBox ID="txtCodigoError" runat="server" Width="30px" ReadOnly="True"></asp:TextBox>
                                    <span class="auto-style6">*</span></td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style5">
                                    <asp:Label ID="Label6" runat="server" Text="Justificación: " CssClass="etiqueta10"></asp:Label>
                                </td>
                                <td align="left" class="auto-style5">

                                    <asp:TextBox ID="txtJustificacion" runat="server" Width="320px" TextMode="MultiLine" Height="60px" MaxLength="400"></asp:TextBox>

                                    <span class="auto-style6">*</span></td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style5">
                                    <asp:Label ID="Label7" runat="server" Text="Periodo Inicio: " CssClass="etiqueta10"></asp:Label>
                                </td>
                                <td align="left" class="auto-style5">
                                    
                                    <asp:TextBox ID="txtPeriodoInicio" runat="server" Width="60px" onkeypress="return permite(event, 'num')" onchange="Periodos();" MaxLength="6"></asp:TextBox>
                                    <cc1:CalendarExtender ID="txtPeriodoInicio_CalendarExtender" runat="server" Enabled="True" Format="yyyyMM" PopupButtonID="ImageButton1" TargetControlID="txtPeriodoInicio" CssClass="cal_Theme1">
                                    </cc1:CalendarExtender>
                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Imagenes/pequeños/Calendar_32x32.png" />
                                    
                                    <span class="auto-style6">*</span></td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style5">
                                    <asp:Label ID="Label8" runat="server" Text="Periodo Final:" CssClass="etiqueta10"></asp:Label>
                                </td>
                                <td align="left" class="auto-style5">

                                    <asp:TextBox ID="txtPeriodoFinal" runat="server" Width="60px" onkeypress="return permite(event, 'num')" onchange="Periodos();" MaxLength="6"></asp:TextBox>
                                    <cc1:CalendarExtender ID="txtPeriodoFinal_CalendarExtender" runat="server" Enabled="True" Format="yyyyMM" PopupButtonID="ImageButton2" TargetControlID="txtPeriodoFinal" CssClass="cal_Theme1">
                                    </cc1:CalendarExtender>
                                    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Imagenes/pequeños/Calendar_32x32.png" />

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
                                        OnClientClick="javascript : return confirm('Esta seguro de realizar esta accion?');"
                                        Text="Adicionar" CssClass="boton150" />
                                </td>
                            </tr>

                        </table>

                    </div>
                </asp:Panel>
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
            </td>
        </tr>
    </table>
</asp:Content>

