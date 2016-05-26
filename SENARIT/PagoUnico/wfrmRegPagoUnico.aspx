<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmRegPagoUnico.aspx.cs" Inherits="PagoUnico_wfrmRegPagoUnico" StylesheetTheme="Modal" %>

<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Assembly="System.Web, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" Namespace="System.Web.UI" TagPrefix="cc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript" language="javascript">

        function activarAniosInsal() {
            if (document.getElementById("<%=chkAniosInsalubre.ClientID%>").checked == true) {
                 document.getElementById("<%=txtAniosInsal.ClientID%>").disabled = false;
                 document.getElementById("<%=txtCalcAniosInsal.ClientID%>").value = "";
             }
             else {
                 document.getElementById("<%=txtAniosInsal.ClientID%>").disabled = true;
                 document.getElementById("<%=txtCalcAniosInsal.ClientID%>").value = 0;
            }
        }

         function calcularEdadJubil() {
             var c;
             var v = document.getElementById("<%=txtAniosInsal.ClientID%>").value;
              if (v <= 10) {
                  c = eval(v / 2);
              } else {
                  c = 5;
              }
              c = Math.trunc(c);

              document.getElementById("<%=txtCalcAniosInsal.ClientID%>").value = c;
              var edad = document.getElementById("<%=txtEdad.ClientID%>").value;

              document.getElementById("<%=txtEdadJubilacion.ClientID%>").value = 55 - c;
          }

          function habilitarListaDoc(checkBoxListId, deshabilitado) {
              var tbl = document.getElementById(checkBoxListId);
              if (tbl == null) return;

              var checkboxCollection = tbl.getElementsByTagName('input');
              if (checkboxCollection == null) return;

              for (var i = 0; i < checkboxCollection.length; i++) {
                  if (checkboxCollection[i].type.toString().toLowerCase() == "checkbox") {
                      checkboxCollection[i].disabled = deshabilitado;
                  }
              }
          }

         function HabilitarPestania(prop, tabIndex) {
              var tab = $find("<%=tcPU.ClientID%>");
             tab.get_tabs()[tabIndex].set_enabled(prop);
         }

         function controlarSolicitante() {
             var list = document.getElementById("<%=rbtnlstSolicitante.ClientID%>");
             var inputs = list.getElementsByTagName("input");
             var selected;
             for (var i = 0; i < inputs.length; i++) {
                 if (inputs[i].checked) {
                     selected = inputs[i];
                     break;
                 }
             }
             if (selected) {
                 if (selected.value == "Titular") {
                     habilitarListaDoc("<%=chklstDocTitular.ClientID%>", false);
                     habilitarListaDoc("<%=chklstDocDH.ClientID%>", true);
                     document.getElementById("<%=rvPorcentaje.ClientID%>").disabled = true;  
                     document.getElementById("<%=rvReceptor.ClientID%>").disabled = true;
                     document.getElementById("<%=txtTotPocentaje.ClientID%>").value = "100";
                     HabilitarPestania(false, 2);
                 } else {
                     habilitarListaDoc("<%=chklstDocTitular.ClientID%>", true);
                     habilitarListaDoc("<%=chklstDocDH.ClientID%>", false);
                     document.getElementById("<%=rvPorcentaje.ClientID%>").disabled = false;  
                     document.getElementById("<%=rvReceptor.ClientID%>").disabled = false;  
                     HabilitarPestania(true, 2);
                  }
             } 
        }

        var minimoCheck = 1;
        function habilitaRegistrar() {  
          var gridview = document.getElementById("<%=gvDH.ClientID%>");
        var inputList = gridview.getElementsByTagName("input");
          var cont = 0;
          for (var i = 0; i < inputList.length; i++) {
              if (inputList[i].type == "checkbox") { // && objRef != inputList[i]) {
                  if (inputList[i].checked) {
                      cont++;
                  }
              }
          }
          document.getElementById("<%=txtContChecks.ClientID%>").value = cont;
        }
        
        function sumarPorcentajes() {
            var gridview = document.getElementById("<%=gvDH.ClientID%>");
            var inputList = gridview.getElementsByTagName("select");
            var cont = 0;
            for (var i = 0; i < inputList.length; i++) {
                if (i % 2 == 0) {
                    cont = cont + parseFloat(inputList[i].value);
                }
            }
            var txtTotPocentaje = document.getElementById("<%=txtTotPocentaje.ClientID%>");
            txtTotPocentaje.value = cont;
        }


    </script>
 

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="pnlGral">
        <asp:Panel ID="pnlSolicitante" runat="server" CssClass="pnlBody">
            <table border="0" cellpadding="2" cellspacing="3" width="100%">
                <tr>
                    <td align="center" colspan="5">
                        <asp:ImageButton ID="imgAux" runat="server" ImageUrl="~/Imagenes/16w.png" />
                        <asp:Label ID="lblTitulo" runat="server" CssClass="texto12" Text="Trámite Pago Único"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="5">&nbsp;</td>
                </tr>
                <tr>
                    <td align="left">&nbsp;</td>
                    <td align="right" style="width: 100px">
                        <asp:Label ID="Label1" runat="server" Text="Solicitante:"></asp:Label>
                    </td>
                    <td align="left" style="width: 100px">
                        <asp:RadioButtonList ID="rbtnlstSolicitante" runat="server" onchange="controlarSolicitante();" Width="153px">
                            <asp:ListItem>Titular</asp:ListItem>
                            <asp:ListItem>Derechohabiente</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td align="left">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="rbtnlstSolicitante" ErrorMessage="Solicitante" ValidationGroup="PreSol"></asp:RequiredFieldValidator>
                    </td>
                    <td align="right" style="margin-left: 40px">
                        <asp:ValidationSummary ID="vSumPreSol" runat="server" DisplayMode="List" ValidationGroup="PreSol" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
    <div align="center">
        <asp:Panel ID="pnlPestania" runat="server">
            <cc1:TabContainer ID="tcPU" runat="server" ActiveTabIndex="2" Style="margin-left: 0px" Width="1165px">
                <cc1:TabPanel ID="tPnlDatTram" runat="server" HeaderText="TabPanel1">
                    <HeaderTemplate>
                        Búsqueda Datos Trámite
                    </HeaderTemplate>
                    <ContentTemplate>
                        <div class="pnlPest">
                            <asp:Panel ID="pnlTram" runat="server">
                                <table style="width: 100%;">
                                    <tr>
                                        <td align="center" colspan="6"></td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label2" runat="server" Text="Matrícula"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtMatricula" runat="server" CssClass="box" onkeyup="this.value=this.value.toUpperCase()" ValidationGroup="Tramite"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvMatricula" runat="server" ErrorMessage="*" ControlToValidate="txtMatricula" ValidationGroup="Tramite"></asp:RequiredFieldValidator>
                                            <asp:RequiredFieldValidator ID="rfvMatriculaPS" runat="server" ErrorMessage="Matrícula" ValidationGroup="PreSol" ControlToValidate="txtMatricula"></asp:RequiredFieldValidator>                                            
                                            <asp:Button ID="btnBuscarMatric" runat="server" CssClass="btnPrin" OnClick="btnBuscarMatric_Click" Text="Buscar" ValidationGroup="Tramite" />
                                        </td>
                                        <td align="right">&nbsp;</td>
                                        <td align="left">&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="right">&nbsp;</td>
                                        <td align="left">&nbsp;</td>
                                        <td align="right">&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label39" runat="server" Text="Trámite Anterior:"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtTramiteCrenta" runat="server" CssClass="box" Enabled="False">
                                            </asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label5" runat="server" Text="NUA:"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtNUA" runat="server" CssClass="box" Enabled="False"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label7" runat="server" Text="Sector:"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlSector" runat="server" CssClass="box" Width="180px" Enabled="False">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label4" runat="server" Text="Certificado:"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtCertificado" runat="server" CssClass="box" Enabled="False"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label6" runat="server" Text="Código AFP:"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtCodAFP" runat="server" CssClass="box" Enabled="False"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label8" runat="server" Text="Regional"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlRegional" runat="server" CssClass="box" Width="180px" Enabled="False">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right"><asp:Label ID="Label3" runat="server" Text="Nuevo Trámite:"></asp:Label></td>
                                        <td align="left"><asp:TextBox ID="txtTramite" runat="server" CssClass="box" Enabled="False"></asp:TextBox></td>
                                        <td align="right">&nbsp;</td>
                                        <td align="left">&nbsp;</td>
                                        <td align="right">&nbsp;</td>
                                        <td align="left">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="6"></td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </div>
                    </ContentTemplate>
                </cc1:TabPanel>
                <cc1:TabPanel ID="tPnlDatTit" runat="server" HeaderText="TabPanel2">
                    <HeaderTemplate>
                        Búsqueda Datos Personales del Titular
                    </HeaderTemplate>
                    <ContentTemplate>
                        <div class="pnlPest">
                            <asp:Panel ID="pnlDatTit" runat="server">
                                <table style="width: 100%;">
                                    <tr>
                                        <td align="right">&nbsp;</td>
                                        <td align="left">&nbsp;</td>
                                        <td align="right">&nbsp;</td>
                                        <td align="left">&nbsp;</td>
                                        <td align="right">&nbsp;</td>
                                        <td align="left">&nbsp;</td>
                                        <td align="right">&nbsp;</td>
                                        <td align="left">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label9" runat="server" Text="Apellido Paterno:"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtPaterno" runat="server" CssClass="box" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label10" runat="server" Text="Apellido Materno:"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtMaterno" runat="server" CssClass="box" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label11" runat="server" Text="Primer Nombre:"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtPrimNom" runat="server" CssClass="box" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label44" runat="server" Text="Segundo Nombre:"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtSegNom" runat="server" CssClass="box" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label54" runat="server" Text="NUA:"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtCUA" runat="server" CssClass="box" onkeyup="this.value=this.value.toUpperCase()" Enabled="False"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label15" runat="server" Text="Género:"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlGenero" runat="server" CssClass="box" Width="103px" Enabled="False">
                                            </asp:DropDownList>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label19" runat="server" Text="Estado Civil:"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlEstadoCivil" runat="server" CssClass="box" Width="144px" Enabled="False">
                                            </asp:DropDownList>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label47" runat="server" Text="NUP:" Visible="False"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtNUP" runat="server" CssClass="box" onkeyup="this.value=this.value.toUpperCase()" Visible="False"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label12" runat="server" Text="Fecha Nacimiento:"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtFechaNac" runat="server" CssClass="box" Width="75px" Enabled="False"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label14" runat="server" Text="Edad Actual:"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtEdad" runat="server" CssClass="box" Enabled="False"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label13" runat="server" Text="Fecha Fallecimiento"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtFechaFallec" runat="server" CssClass="box" Width="75px" Enabled="False"></asp:TextBox>
                                        </td>
                                        <td align="right">&nbsp;</td>
                                        <td align="left">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label16" runat="server" Text="Tipo Documento:"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlTipoDoc" runat="server" CssClass="box" Width="142px" Enabled="False">
                                            </asp:DropDownList>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label17" runat="server" Text="Número Documento:"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtNumDoc" runat="server" CssClass="box"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvNumDoc" runat="server" ErrorMessage="Nº Doc" ValidationGroup="PreSol" ControlToValidate="txtNumDoc"></asp:RequiredFieldValidator>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label18" runat="server" Text="Expedido:"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlExpedido" runat="server" CssClass="box" Width="100px">
                                            </asp:DropDownList>
                                        </td>
                                        <td align="right">
                                              <asp:Label ID="Label33" runat="server" Text="Complemento SEGIP"></asp:Label>
                                        </td>
                                        <td align="left">
                                                <asp:TextBox ID="txtCompleSEGIP" runat="server" CssClass="box"></asp:TextBox>                        
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">&nbsp;</td>
                                        <td align="left">&nbsp;</td>
                                        <td align="right">&nbsp;</td>
                                        <td align="left">&nbsp;</td>
                                        <td align="right">&nbsp;</td>
                                        <td align="left">&nbsp;</td>
                                        <td align="right">&nbsp;</td>
                                        <td align="left">&nbsp;</td>
                                        <tr>
                                            <td align="center" colspan="8">
                                                <asp:Button ID="btnBuscarDatTit" runat="server" CssClass="btnPrin" OnClick="btnBuscarDatTit_Click" Text="Buscar" Width="118px" /></td>
                                        </tr>
                                        <tr>
                                            <td align="right">&nbsp;</td>
                                            <td align="left">&nbsp;</td>
                                            <td align="right">&nbsp;</td>
                                            <td align="left">&nbsp;</td>
                                            <td align="right">&nbsp;</td>
                                            <td align="left">&nbsp;</td>
                                            <td align="right">&nbsp;</td>
                                            <td align="left">&nbsp;</td>
                                            <tr>
                                                <tr>
                                                    <td align="center" colspan="8">
                                                        <asp:GridView ID="gvTitular" runat="server" AllowPaging="True" AutoGenerateColumns="False" BorderColor="#DADADA" DataKeyNames="NUP,CUA" OnSelectedIndexChanged="gvTitular_SelectedIndexChanged" OnPageIndexChanging="gvTitular_PageIndexChanging">
                                                            <Columns>
                                                                <asp:ButtonField ButtonType="Image" CommandName="Select" HeaderText="Elegir" ImageUrl="~/imagenes/16siguiente.png" ShowHeader="True" Text="Button" />
                                                                <asp:BoundField DataField="CUA" HeaderText="NUA" />
                                                                <asp:BoundField DataField="Matricula" HeaderText="Matrícula" />
                                                                <asp:BoundField DataField="PrimerApellido" HeaderText="Apellido Paterno" />
                                                                <asp:BoundField DataField="SegundoApellido" HeaderText="Apellido Materno" />
                                                                <asp:BoundField DataField="PrimerNombre" HeaderText="Primer Nombre" />
                                                                <asp:BoundField DataField="SegundoNombre" HeaderText="Segundo Nombre" />
                                                                <asp:BoundField DataField="FechaNacimiento" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha Nacimiento" />
                                                                <asp:BoundField DataField="FechaFallecimiento" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha Fallecimiento" />
                                                                <asp:BoundField DataField="TIPODOCUMENTO" HeaderText="Tipo Documento" />
                                                                <asp:BoundField DataField="NumeroDocumento" HeaderText="Num. Documento" />
                                                                <asp:BoundField DataField="DescripcionDetalleClasificador" HeaderText="Expedido" />
                                                            </Columns>
                                                            <EmptyDataTemplate>
                                                                <div align="center" class="CajaDialogoAdvertencia">
                                                                    <br />
                                                                    <img src="../Imagenes/warning.gif"
                                                                        alt="No existen registros" />
                                                                    <br />
                                                                    Bandeja Titulares vacía.
                                                <br />
                                                                    <br />
                                                                </div>
                                                            </EmptyDataTemplate>
                                                            <HeaderStyle CssClass="cssHeaderImg" />
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="8">&nbsp;</td>
                                                </tr>
                                </table>
                            </asp:Panel>

                        </div>
                    </ContentTemplate>
                </cc1:TabPanel>
                <cc1:TabPanel ID="tPnlBenef" runat="server" HeaderText="TabPanel4">
                    <HeaderTemplate>
                        Declaración de Derechohabientes
                    </HeaderTemplate>
                    <ContentTemplate>
                        <div class="pnlPest">
                            <asp:Panel ID="pnlDH" runat="server">
                                <table style="width: 100%;">
                        <tr>
                            <td align="right">&nbsp;</td>
                            <td align="left">&nbsp;</td>
                            <td align="right">&nbsp;</td>
                            <td align="left">&nbsp;</td>
                            <td align="right">&nbsp;</td>
                            <td align="left">&nbsp;</td>
                            <td align="right">&nbsp;</td>
                            <td align="left">&nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label20" runat="server" Text="Apellido Paterno:"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtPaternoB" runat="server" CssClass="box" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvPaternoB" runat="server" ErrorMessage="*" ValidationGroup="RegBenef" ControlToValidate="txtPaternoB"></asp:RequiredFieldValidator>
                            </td>
                            <td align="right">
                                <asp:Label ID="Label24" runat="server" Text="Apellido Materno:"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtMaternoB" runat="server" CssClass="box" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ID="rfvMaternoB" runat="server" ErrorMessage="*" ValidationGroup="RegBenef" ControlToValidate="txtMaternoB"></asp:RequiredFieldValidator>--%>
                            </td>
                            <td align="right">
                                <asp:Label ID="Label28" runat="server" Text="Primer Nombre:"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtPrimNomB" runat="server" CssClass="box" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvPrimNomB" runat="server" ErrorMessage="*" ValidationGroup="RegBenef" ControlToValidate="txtPrimNomB"></asp:RequiredFieldValidator>
                            </td>
                            <td align="right">
                                <asp:Label ID="Label45" runat="server" Text="Segundo Nombre:"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtSegNomB" runat="server" CssClass="box" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label21" runat="server" Text="Fecha Nacimiento:"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtFechaNacB" runat="server" CssClass="box" Width="75px"></asp:TextBox>
                                <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" BehaviorID="_content_TextBoxWatermarkExtender1" TargetControlID="txtFechaNacB" WatermarkText="__/__/____">
                                </cc1:TextBoxWatermarkExtender>
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" BehaviorID="_content_CalendarExtender1" Format="dd/MM/yyyy" PopupButtonID="btnCalendario" TargetControlID="txtFechaNacB">
                                </cc1:CalendarExtender>
                                <asp:ImageButton ID="btnCalendario" runat="server" ImageAlign="Bottom" ImageUrl="../Imagenes/pequeños/CalendarC_16x16.png" />
                                <asp:RequiredFieldValidator ID="rfvFecNacB" runat="server" ControlToValidate="txtFechaNacB" ErrorMessage="*" ValidationGroup="RegBenef"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revFecNacB" runat="server" ErrorMessage="dd/mm/yyyy" ControlToValidate="txtFechaNacB" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d" ValidationGroup="RegBenef"></asp:RegularExpressionValidator>
                            </td>
                            <td align="right">
                                <asp:Label ID="Label26" runat="server" Text="Género:"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlGeneroB" runat="server" CssClass="box" Width="103px">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvGeneroB" runat="server" ControlToValidate="ddlGeneroB" ErrorMessage="*" ValidationGroup="RegBenef"></asp:RequiredFieldValidator>
                            </td>
                            <td align="right">
                                <asp:Label ID="Label29" runat="server" Text="Estado Civil:"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlEstadoCivilB" runat="server" CssClass="box" Width="144px">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvEstCivilB" runat="server" ControlToValidate="ddlEstadoCivilB" ErrorMessage="*" ValidationGroup="RegBenef"></asp:RequiredFieldValidator>
                            </td>
                            <td align="right">
                                <asp:Label ID="Label31" runat="server" Text="Parentesco:"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlParentesco" runat="server" CssClass="box" Width="120px">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvParentesco" runat="server" ControlToValidate="ddlParentesco" ErrorMessage="*" ValidationGroup="RegBenef"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label23" runat="server" Text="Tipo Documento:"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlTipoDocB" runat="server" CssClass="box" Width="142px">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvTipoDocB" runat="server" ErrorMessage="*" ValidationGroup="RegBenef" ControlToValidate="ddlTipoDocB"></asp:RequiredFieldValidator>
                            </td>
                            <td align="right">
                                <asp:Label ID="Label27" runat="server" Text="Número Documento:"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtNumDocB" runat="server" CssClass="box"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvNumDocB" runat="server" ErrorMessage="*" ValidationGroup="RegBenef" ControlToValidate="txtNumDocB"></asp:RequiredFieldValidator>
                            </td>
                            <td align="right">
                                <asp:Label ID="Label30" runat="server" Text="Expedido:"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlExpedidoB" runat="server" CssClass="box" Width="140px">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvExoedidoB" runat="server" ErrorMessage="*" ValidationGroup="RegBenef" ControlToValidate="ddlExpedidoB"></asp:RequiredFieldValidator>
                            </td>
                            <td align="right">
                                <asp:Label ID="Label58" runat="server" Text="Complemento SEGIP"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtCompleSEGIPB" runat="server" CssClass="box"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                       
                            </td>
                            <td align="left">
                       
                            </td>                                        
                            <td align="right">
                                <asp:Label ID="Label22" runat="server" Text="Edad:" Visible="False"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtEdadB" runat="server" CssClass="box" Enabled="False" Visible="False"></asp:TextBox>
                            </td>
                            <td align="right">
                                <asp:Label ID="Label46" runat="server" Text="NUP:" Visible="False"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtNUPB" runat="server" CssClass="box" Enabled="False" Visible="False"></asp:TextBox>
                            </td>
                            <td align="right">
                                <asp:Label ID="Label55" runat="server" Text="CUA:" Visible="False"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtCUAB" runat="server" CssClass="box" Enabled="False" Visible="False"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="8">
                                &nbsp;
                            </td>
                    
                        </tr>
                        <tr>
                            <td align="center" colspan="8">
                                <asp:Button ID="btnLimpiarBenef" runat="server" CssClass="btnPrin" OnClick="btnLimpiarBenef_Click" Text="Limpiar" Width="63px" CausesValidation="False" />
                                <asp:Button ID="btnRegBenef" runat="server" CssClass="btnPrin" OnClick="btnRegBenef_Click" Text="Registrar Derechohabiente" ValidationGroup="RegBenef" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="8">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                 <asp:Label ID="Label57" runat="server" Text="Porcentaje:"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtTotPocentaje" runat="server" CssClass="box" Enabled="False" Text="0" Width="50"></asp:TextBox>
                                <asp:RangeValidator ID="rvPorcentaje" runat="server" ErrorMessage="Porcentaje[80-100]" ControlToValidate="txtTotPocentaje" Type="Integer" MinimumValue="50" MaximumValue="100"></asp:RangeValidator>
                            </td>
                            <td align="right">
                                <asp:Label ID="Label34" runat="server" Text="Cont. Recep. Cheque:"></asp:Label>
                        
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtContChecks" runat="server" Enabled="False" Width="50"></asp:TextBox>
                                <asp:RangeValidator ID="rvReceptor" runat="server" ErrorMessage="Un Receptor/G.Flia." ControlToValidate="txtContChecks" Type="Integer" MinimumValue="1" MaximumValue="5"></asp:RangeValidator>
                            </td>
                            <td align="right">
                        
                            </td>
                            <td align="left">
                        
                            </td>
                            <td align="right">&nbsp;</td>
                            <td align="left">&nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" colspan="8">
                                <asp:GridView ID="gvDH" runat="server" AllowPaging="True" AutoGenerateColumns="False" BorderColor="#DADADA" DataKeyNames="NUP,IdParentesco" OnRowDataBound="gvDH_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField ItemStyle-Width="60px">
                                            <HeaderTemplate>
                                                <asp:Label ID="lblReceptor" runat="server" Text="Receptor Cheque"></asp:Label>
                                                <%--<asp:CheckBox ID="chkSelectAll" runat="server" onclick="checkAll(this);" />--%>
                                            </HeaderTemplate>
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkReceptorCheque" runat="server" onclick="habilitaRegistrar();" >
                                                </asp:CheckBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="40px">
                                            <HeaderTemplate>
                                                <asp:Label ID="lblPorcentaje" runat="server" Text="Porcentaje"></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:DropDownList ID="ddlPorcentajes" runat="server" Font-Size="Small" onchange="sumarPorcentajes();">   
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                            <ItemStyle Width="40px" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="40px">
                                            <HeaderTemplate>
                                                <asp:Label ID="lblGrupoFlia" runat="server" Text="Grup.Flia."></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>                                    
                                                <asp:DropDownList ID="ddlGrupFlia" runat="server" Font-Size="Small" >                                    
                                                </asp:DropDownList>
                                                <%--<asp:DropDownList ID="ddlGrupFlia" runat="server"  AutoPostBack="True" DataSourceID="<%# hk() %>" DataTextField="GrupoFamiliar" DataValueField="GrupoFamiliar" SelectedValue='<%# Eval("GrupoFamiliar") %>' Width="100" />--%>                                                                           
                                            </ItemTemplate>
                                  
                                            <ItemStyle Width="40px" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                
                                        <asp:ButtonField ButtonType="Image" CommandName="Select" HeaderText="Elegir" ImageUrl="~/imagenes/16siguiente.png" ShowHeader="True" Text="Button" Visible="False" />
                                        <asp:BoundField DataField="NUP" HeaderText="NUP" />
                                        <asp:BoundField DataField="CUA" HeaderText="CUA" Visible="False" />
                                        <asp:BoundField DataField="Matricula" HeaderText="Matrícula" />
                                        <asp:BoundField DataField="DescripcionDetalleClasificador1" HeaderText="Parentesco" />
                                        <asp:BoundField DataField="PrimerApellido" HeaderText="Apellido Paterno" />
                                        <asp:BoundField DataField="SegundoApellido" HeaderText="Apellido Materno" />
                                        <asp:BoundField DataField="PrimerNombre" HeaderText="Primer Nombre" />
                                        <asp:BoundField DataField="SegundoNombre" HeaderText="Segundo Nombre" />
                                        <asp:BoundField DataField="FechaNacimiento" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fec. Nacimiento" />
                                        <asp:BoundField DataField="TIPODOCUMENTO" HeaderText="Tipo Documento" />
                                        <asp:BoundField DataField="NumeroDocumento" HeaderText="Nº Documento" />
                                        <asp:BoundField DataField="DescripcionDetalleClasificador" HeaderText="Expedido" />
                                        <asp:BoundField DataField="ComplementoSEGIP" HeaderText="Comp. SEGIP" />
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <div align="center" class="CajaDialogoAdvertencia">
                                            <br />
                                            <img src="../Imagenes/warning.gif" alt="No existen registros" />
                                            <br />
                                            Bandeja de Derechohabientes vacia.
                                                        <br />
                                            <br />
                                        </div>
                                    </EmptyDataTemplate>
                                    <HeaderStyle CssClass="cssHeaderImg" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                    <td align="center" colspan="8">&nbsp;</td>
                </tr>
            </table>
                            </asp:Panel>
                        </div>
                    </ContentTemplate>
                </cc1:TabPanel>
                <cc1:TabPanel ID="tPnlDatCertif" runat="server" HeaderText="TabPanel5">
                    <HeaderTemplate>
                        Datos del Certificado
                    </HeaderTemplate>
                    <ContentTemplate>
                        <div class="pnlPest">
                            <asp:Panel ID="pnlDatCertificado" runat="server">
                                <table style="width: 100%;">
                                    <tr>
                                        <td align="left" style="width: 50px;">&nbsp;</td>
                                        <td align="left" style="width: 150px">&nbsp;</td>
                                        <td align="left" style="width: 230px">&nbsp;</td>
                                        <td align="left" style="width: 180px">&nbsp;</td>
                                        <td align="left" style="width: 250px">&nbsp;</td>
                                        <td align="left" style="width: 150px">&nbsp;</td>
                                        <td align="left" style="width: 200px">&nbsp;</td>
                                        <td align="left" style="width: 50px;">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 50px">&nbsp;</td>
                                        <td align="right" style="width: 150px">
                                            <asp:Label ID="Label48" runat="server" Text="Nº Cheque:"></asp:Label>
                                        </td>
                                        <td align="left" style="width: 230px">
                                            <asp:TextBox ID="txtNoCheque" runat="server" CssClass="box" Enabled="False"></asp:TextBox>
                                        </td>
                                        <td align="right" style="width: 180px">
                                            <asp:Label ID="Label50" runat="server" Text="Fecha Emisión Cheque"></asp:Label>
                                        </td>
                                        <td align="left" style="width: 250px">
                                            <asp:TextBox ID="txtFechaEmisionCheque" runat="server" CssClass="box" Enabled="False"></asp:TextBox>
                                        </td>
                                        <td align="right" style="width: 150px">
                                            <asp:Label ID="Label25" runat="server" Text="Estado del cheque:"></asp:Label>
                                        </td>
                                        <td align="left" style="width: 200px">
                                            <asp:TextBox ID="txtEstadoCheque" runat="server" CssClass="box" Enabled="False"></asp:TextBox>
                                        </td>
                                        <td align="left" style="width: 50px">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 50px">&nbsp;</td>
                                        <td align="right" style="width: 150px">
                                            <asp:Label ID="Label32" runat="server" Text="Fecha Emisión Certificado:"></asp:Label>
                                        </td>
                                        <td align="left" style="width: 230px">
                                            <asp:TextBox ID="txtFecEmision" runat="server" CssClass="box" Enabled="False"></asp:TextBox>
                                        </td>
                                        <td align="right" style="width: 180px">

                                            <asp:Label ID="Label35" runat="server" Text="Monto Base:"></asp:Label>
                                        </td>
                                        <td align="left" style="width: 250px">
                                            <asp:TextBox ID="txtMontoBase" runat="server" CssClass="box" Enabled="False"></asp:TextBox>
                                        </td>
                                        <td align="right" style="width: 150px">
                                            <asp:Label ID="Label36" runat="server" Text="Tipo de Cambio:"></asp:Label>
                                        </td>
                                        <td align="left" style="width: 200px">
                                            <asp:TextBox ID="txtTC" runat="server" CssClass="box" Enabled="False"></asp:TextBox>
                                        </td>
                                        <td align="left" style="width: 50px">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 50px">&nbsp;</td>
                                        <td align="right" style="width: 150px">&nbsp;</td>
                                        <td align="left" style="width: 230px">&nbsp;</td>
                                        <td align="right" style="width: 180px">&nbsp;</td>
                                        <td align="left" style="width: 250px">&nbsp;</td>
                                        <td align="right" style="width: 150px">&nbsp;</td>
                                        <td align="left" style="width: 200px">&nbsp;</td>
                                        <td align="left" style="width: 50px">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 50px;">&nbsp;</td>
                                        <td align="right" style="width: 150px">
                                            <asp:Label ID="Label37" runat="server" Text="Monto Actualizado:"></asp:Label>
                                        </td>
                                        <td align="left" style="width: 230px">
                                            <asp:TextBox ID="txtMontoActual" runat="server" CssClass="box" Enabled="False"></asp:TextBox>
                                        </td>
                                        <td align="right" style="width: 180px">
                                            <asp:Label ID="Label40" runat="server" Text="Tipo de Cambio Actual:"></asp:Label>
                                        </td>
                                        <td align="left" style="width: 250px">
                                            <asp:TextBox ID="txtTCActual" runat="server" CssClass="box" Enabled="False"></asp:TextBox>
                                        </td>
                                        <td align="right" style="width: 150px">&nbsp;</td>
                                        <td align="left" style="width: 200px">&nbsp;</td>
                                        <td align="left" style="width: 50px">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 50px">&nbsp;</td>
                                        <td align="right" style="width: 150px">&nbsp;</td>
                                        <td align="left" style="width: 230px">&nbsp;</td>
                                        <td align="right" style="width: 180px">&nbsp;</td>
                                        <td align="left" style="width: 250px">&nbsp;</td>
                                        <td align="right" style="width: 150px">&nbsp;</td>
                                        <td align="left" style="width: 200px">&nbsp;</td>
                                        <td align="left" style="width: 50px">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="8" >
                                            <asp:Panel ID="pnlDatExtPreSol" runat="server" HorizontalAlign="Center">
                                                <table style="width: 100%;">
                                                     <tr>
                                                        <td align="right" style="width: 50px">&nbsp;</td>
                                                        <td align="right" style="width: 150px">
                                                            <asp:CheckBox ID="chkAniosInsalubre" runat="server" onclick="activarAniosInsal();" Text="Años insalubre:" />
                                                        </td>
                                                        <td align="left" style="width: 230px">
                                                            <asp:TextBox ID="txtAniosInsal" runat="server" CssClass="box" onchange="calcularEdadJubil();" Width="50px"></asp:TextBox>
                                                            <cc1:FilteredTextBoxExtender ID="txtAniosInsal_FilteredTextBoxExtender" runat="server" FilterType="Numbers" TargetControlID="txtAniosInsal">
                                                            </cc1:FilteredTextBoxExtender>
                                                        </td>
                                                        <td align="right" style="width: 180px">
                                                            <asp:Label ID="Label56" runat="server" Text="Cálculo Años Insalubre:"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 250px">
                                                            <asp:TextBox ID="txtCalcAniosInsal" runat="server" CssClass="box" Enabled="False" Text="0"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvCalAniosInsal" runat="server" ErrorMessage="Años Insalubres" ValidationGroup="PreSol" ControlToValidate="txtCalcAniosInsal"></asp:RequiredFieldValidator>
                                                        </td>
                                                        <td align="right" style="width: 150px">
                                                            <asp:Label ID="Label38" runat="server" Text="Edad Jubilación:"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 200px">
                                                            <asp:TextBox ID="txtEdadJubilacion" runat="server" Enabled="False" CssClass="box" Text="55"></asp:TextBox>
                                                        </td>
                                                        <td align="left" style="width: 50px">&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" style="width: 50px">&nbsp;</td>
                                                        <td align="right" style="width: 150px">
                                                            <asp:Label ID="Label53" runat="server" Text="Hoja de Ruta:"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 230px">
                                                            <asp:TextBox ID="txtHojaRuta" runat="server" CssClass="box"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvHojaRuta" runat="server" ErrorMessage="Hoja Ruta" ValidationGroup="PreSol" ControlToValidate="txtHojaRuta"></asp:RequiredFieldValidator>
                                                        </td>
                                                        <td align="right" style="width: 180px">
                                                            <asp:Label ID="Label51" runat="server" Text="Fecha Hoja de Ruta:" Visible="False"></asp:Label>
                                                        </td>
                                                        <td align="left" style="width: 250px">
                                                            <asp:TextBox ID="txtFechaHojaRuta" runat="server" CssClass="box" Enabled="False" Visible="False"></asp:TextBox>
                                                        </td>
                                                        <td align="right" style="width: 150px">&nbsp;</td>
                                                        <td align="left" style="width: 200px">&nbsp;</td>
                                                        <td align="left" style="width: 50px">&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" style="width: 50px">&nbsp;</td>
                                                        <td align="right" style="width: 150px">&nbsp;</td>
                                                        <td align="left" style="width: 230px">&nbsp;</td>
                                                        <td align="right" style="width: 180px">&nbsp;</td>
                                                        <td align="left" style="width: 250px">&nbsp;</td>
                                                        <td align="right" style="width: 150px"></td>
                                                        <td align="left" style="width: 200px"></td>
                                                        <td align="left" style="width: 50px">&nbsp;</td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </div>
                    </ContentTemplate>
                </cc1:TabPanel>
                <cc1:TabPanel ID="tPnlDocus" runat="server" HeaderText="TabPanel3">
                    <HeaderTemplate>
                        Documentos Presentados
                    </HeaderTemplate>
                    <ContentTemplate>
                        <asp:Panel ID="pnlDocus" runat="server">
                            <table style="width: 100%;">
                                <tr>
                                    <td valign="top">
                                        <div class="pnlPest">
                                            <table style="width: 100%;">
                                                <tr>
                                                    <td align="center"></td>
                                                </tr>
                                                <tr>
                                                    <td align="center">
                                                        <asp:Label ID="Label52" runat="server" CssClass="etiqueta20" Text="Documentos Presentados por Titular"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td align="center" style="vertical-align: top">
                                                        <asp:CheckBoxList ID="chklstDocTitular" runat="server" RepeatColumns="1">
                                                        </asp:CheckBoxList>
                                                        <asp:CustomValidator ID="cvDocTit" runat="server" ErrorMessage="Debe entregar los documentos obligatorios el Titular" ValidationGroup="PreSol" OnServerValidate="cvDocTit_ServerValidate"></asp:CustomValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;</td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                    <td valign="top">
                                        <div class="pnlPest">
                                            <table style="width: 100%;">
                                                <tr>
                                                    <td align="center">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td align="center">
                                                        <asp:Label ID="Label41" runat="server" CssClass="etiqueta20" Text="Documentos Presentados por Beneficiario"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td align="center" style="vertical-align: top">
                                                        <asp:CheckBoxList ID="chklstDocDH" runat="server" RepeatColumns="1">
                                                        </asp:CheckBoxList>
                                                        <asp:CustomValidator ID="cvDocDH" runat="server" ErrorMessage="Debe entregar los documentos obligatorios el(los) Derechohabiente(s)" ValidationGroup="PreSol" OnServerValidate="cvDocDH_ServerValidate"></asp:CustomValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;</td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </ContentTemplate>
                </cc1:TabPanel>
            </cc1:TabContainer>
        </asp:Panel>
    </div>
    <div class="pnlBody">
       
            <table style="width: 100%;">
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td align="right" style="width: 500px">
                        <asp:ImageButton ID="ibtnLimpiar" runat="server" AlternateText="Limpiar Datos" CausesValidation="False" ImageUrl="~/Imagenes/plomoLimpiar.png" OnClick="ibtnLimpiar_Click" />
                    </td>
                    <td align="left">
                        <asp:Panel ID="pnlBotones" runat="server">
                            <asp:ImageButton ID="ibtnRegistrar" runat="server" ImageUrl="~/Imagenes/plomoRegistrar.png" OnClick="ibtnRegistrar_Click" AlternateText="Registrar Pre-Solicitud" ValidationGroup="PreSol" Enabled="False" />
                            <cc1:ConfirmButtonExtender ID="ibtnRegistrar_ConfirmButtonExtender" runat="server" TargetControlID="ibtnRegistrar" ConfirmText="¿Esta seguro de continuar?">
                            </cc1:ConfirmButtonExtender>
                    
                            <asp:ImageButton ID="ibtnImprimir" runat="server" ImageUrl="~/Imagenes/plomoImprimir.png" OnClick="ibtnImprimir_Click" AlternateText="Imprimir" Enabled="False" />
                        </asp:Panel>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
         
    </div>


</asp:Content>

