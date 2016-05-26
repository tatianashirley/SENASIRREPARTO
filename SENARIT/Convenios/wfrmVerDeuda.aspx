<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmVerDeuda.aspx.cs" Inherits="Convenios_wfrmVerDeuda" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register assembly="System.Web, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="System.Web.UI" tagprefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
        function ModalPopup() {
            var vpRND = Math.random() * 20;
            showModalDialog('\ModalRol.aspx?rn=' + vpRND, '', 'dialogWidth=640px; dialogHeight=320px; center=yes; scrollbars=no');
        }
        function CalcularDescuento() {
            var Porcentaje = document.getElementById('<%=txtPorcentaje.ClientID%>').value;
            var Monto = document.getElementById('<%=hfMontoCC.ClientID%>').value;
           
            if (Monto != 0.00) {
              var prob = (parseFloat(Monto) * parseFloat(Porcentaje)) / 100;
              document.getElementById('<%=txtMontoDescuento.ClientID%>').value = prob.toFixed(2);

                if (document.getElementById('<%=txtPorcentaje.ClientID%>').value == 0 || document.getElementById('<%=txtPorcentaje.ClientID%>').value == "") {
                    document.getElementById('<%=txtPorcentaje.ClientID%>').value = "0.00";
                    document.getElementById('<%=txtMontoDescuento.ClientID%>').value = "0.00";
                }
            }
            if (document.getElementById('<%=txtPorcentaje.ClientID%>').value > 0 && document.getElementById('<%=txtPorcentaje.ClientID%>').value > 100)
            {
                alert('PORCENTAJE NO VALIDO PORFAVOR INTRODUZACA UN PORCENTAJE EN EL RANGO DE 0 A 100')
                document.getElementById('<%=txtPorcentaje.ClientID%>').value = "100.00";
                CalcularDescuento();
            }
        }
        function CalcularProcentaje() {
            var Monto = document.getElementById('<%=hfMontoCC.ClientID%>').value;
            if (Monto != 0, 00) {
                var Descuento = document.getElementById('<%=txtMontoDescuento.ClientID%>').value;
                var res = (parseFloat(Descuento) * 100) / parseFloat(Monto);
                document.getElementById('<%=txtPorcentaje.ClientID%>').value = res.toFixed(2).replace(".", ",");
                if (document.getElementById('<%=txtMontoDescuento.ClientID%>').value == 0) {
                    document.getElementById('<%=txtMontoDescuento.ClientID%>').value = "0.00";
                    document.getElementById('<%=txtPorcentaje.ClientID%>').value = "0.00";
                }
            }
            if (document.getElementById('<%=txtMontoDescuento.ClientID%>').value == '')
            {
                document.getElementById('<%=txtMontoDescuento.ClientID%>').value = "0.00";
                document.getElementById('<%=txtPorcentaje.ClientID%>').value = "0.00";
            }
            if (document.getElementById('<%=txtPorcentaje.ClientID%>').value == '0')
            {
                document.getElementById('<%=txtPorcentaje.ClientID%>').value = "0.00";
            }
        }
        function CalculaFin() {
            if (document.getElementById('<%=txtCuotas.ClientID%>').value == '') {
                document.getElementById('<%=txtCuotas.ClientID%>').value = "0";
              }
            var mesInicio = document.getElementById('<%=txtPeriodoInicio.ClientID%>').value;
            var numCuotas = document.getElementById('<%=txtCuotas.ClientID%>').value;
            // nº de meses = Nº de mes + nº de cuotas
            var meses = parseInt(mesInicio.slice(4)) + parseInt(numCuotas - 1);
            // Año = Año actual + (nº de meses / 12)
            var anno = parseInt(mesInicio.slice(0, 4)) + Math.floor(meses / 12);
            // Mes = Resto de dividir el nº de meses entre 12
            var mes = (meses % 12);
            mes = (mes == 0 ? 1 : mes);
            // Formateamos la cadena
            var mesFin = anno.toString() + (mes < 10 ? '0' : '') + mes.toString();
            // Se asigna el valor al control txxtPeriodoFin
            document.getElementById('<%=txtPeriodoFin.ClientID%>').value = mesFin;
          
        }
        function permite(elEvento, permitidos) {
            // Variables que definen los caracteres permitidos
            var numeros = ",0123456789";
            var caracteres = " abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ";
            var numeros_caracteres = numeros + caracteres;
            var teclas_especiales = [8, 37, 39, 46, 188];
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

        function Probando() {
            var texto = document.getElementById('<%=txtObservaciones.ClientID%>').value;
            if (/^[A-Za-z0-9]{0,80}$/.test(texto)) {
                //alert('paso prueba');
            }
            else {
                //alert('no pasa');
            }
        }

        function Limpiar1(IdElemento)
        {
            var fin = IdElemento.lastIndexOf('.')
           // alert(IdElemento.substring(3, fin));
           if (IdElemento.substring(3, fin) == "txtMontoPrimerDeposito")
           {
               var Monto = document.getElementById('<%=txtMontoPrimerDeposito.ClientID%>').value;

               if (Monto == 0.00) {
                   document.getElementById('<%=txtMontoPrimerDeposito.ClientID%>').value = "";
               }
           }
            if (IdElemento.substring(3, fin) == "txtMontoDescuento")
           {
               var Monto = document.getElementById('<%=txtMontoDescuento.ClientID%>').value;

               if (Monto == 0.00) {
                   document.getElementById('<%=txtMontoDescuento.ClientID%>').value = "";
               }
           }
            if (IdElemento.substring(3, fin) == "txtPorcentaje")
           {
               var Monto = document.getElementById('<%=txtPorcentaje.ClientID%>').value;

               if (Monto == 0.00) {
                   document.getElementById('<%=txtPorcentaje.ClientID%>').value = "";
               }
           }

            if (IdElemento.substring(3, fin) == "txtMontoDeposito") {
                var Monto = document.getElementById('<%=txtMontoDeposito.ClientID%>').value;

                 if (Monto == 0.00) {
                     document.getElementById('<%=txtMontoDeposito.ClientID%>').value = "";
               }
           }
            //alert(IdElemento);

        }
        function Volver(IdElemento) {
            var fin = IdElemento.lastIndexOf('.')
            // alert(IdElemento.substring(3, fin));
            if (IdElemento.substring(3, fin) == "txtMontoPrimerDeposito") {
                var Monto = document.getElementById('<%=txtMontoPrimerDeposito.ClientID%>').value;

               if (Monto == "") {
                   document.getElementById('<%=txtMontoPrimerDeposito.ClientID%>').value = "0.00";
               }
           }
           if (IdElemento.substring(3, fin) == "txtMontoDescuento") {
               var Monto = document.getElementById('<%=txtMontoDescuento.ClientID%>').value;

                if (Monto == "") {
                    document.getElementById('<%=txtMontoDescuento.ClientID%>').value = "0.00";
               }
           }
           if (IdElemento.substring(3, fin) == "txtPorcentaje") {
               var Monto = document.getElementById('<%=txtPorcentaje.ClientID%>').value;

                if (Monto == "") {
                    document.getElementById('<%=txtPorcentaje.ClientID%>').value = "0.00";
               }
           }

           if (IdElemento.substring(3, fin) == "txtMontoDeposito") {
               var Monto = document.getElementById('<%=txtMontoDeposito.ClientID%>').value;

                if (Monto == "") {
                    document.getElementById('<%=txtMontoDeposito.ClientID%>').value = "0.00";
                 }
             }
        }
       
        function Actualizar(IdElemento) {
            //todo esta va bien pero no lo usare ahora 
            //var fin = IdElemento.lastIndexOf('.')
            //if (IdElemento.substring(3, fin) == 'txtNumeroLiquidacion' || IdElemento.substring(3, fin) == 'txtMontoTotal' || IdElemento.substring(3, fin) == 'txtFechaActual') {
             //   alert('deuda');
             //   parteC
           // }
            //else if (IdElemento.substring(3, fin) == 'ddlRegional' || IdElemento.substring(3, fin) == 'ddlMoneda' || IdElemento.substring(3, fin) == 'ddlTipoDeuda') {
             //   alert('registro');
              //  parteC
            //}
            var fin = IdElemento.lastIndexOf('.')
            if (IdElemento.substring(3, fin) == 'txtMontoPrimerDeposito')
            {

                var MontoTotal = document.getElementById('<%=txtMontoTotal.ClientID%>').value//.replace(",", ".");
                var PrimerDeposito = document.getElementById('<%=txtMontoPrimerDeposito.ClientID%>').value//.replace(",", ".");
                if ((MontoTotal - PrimerDeposito) >= 0) {
                    if (document.getElementById('<%=txtMontoPrimerDeposito.ClientID%>').value != '') {
                        var SaldoDeuda = parseFloat(MontoTotal) - parseFloat(PrimerDeposito);
                    }
                    else
                        document.getElementById('<%=txtMontoPrimerDeposito.ClientID%>').value = '0.00';
                    document.getElementById('<%=txtSaldo.ClientID%>').value = SaldoDeuda.toFixed(2);
                    document.getElementById('<%=txtSaldo.ClientID%>').value = document.getElementById('<%=txtSaldo.ClientID%>').value//.replace(".", ",");
                }
                else {
                    alert('Monto del primer deposito mayor al monto de la deuda total Monto deuda Total: ' + MontoTotal + ' Monto que ingreso del Primer deposito: ' + PrimerDeposito)
                    document.getElementById('<%=txtMontoPrimerDeposito.ClientID%>').value = '0.00';
                    var SaldoDeuda = parseFloat(MontoTotal) - parseFloat(0.00);
                    document.getElementById('<%=txtSaldo.ClientID%>').value = SaldoDeuda.toFixed(2);
                    document.getElementById('<%=txtSaldo.ClientID%>').value = document.getElementById('<%=txtSaldo.ClientID%>').value
                }
                
            }

            if (IdElemento.substring(3, fin) == 'txtMontoTotal')
            {
              
                if (document.getElementById('<%=txtMontoTotal.ClientID%>').value == 0) {
                  document.getElementById('<%=txtMontoTotal.ClientID%>').value = '0.00';
                }
                document.getElementById('<%=txtSaldo.ClientID%>').value = document.getElementById('<%=txtMontoTotal.ClientID%>').value;
            }


            if (document.getElementById('<%=hfParte.ClientID%>').value.indexOf('|Deuda') == -1) {
            
                document.getElementById('<%=hfParte.ClientID%>').value += '|Deuda';//colocar est en parte C
            }
            if (document.getElementById('<%=txtMontoPrimerDeposito.ClientID%>').value == 0)
            {
                document.getElementById('<%=txtMontoPrimerDeposito.ClientID%>').value = '0.00';
            }
            if (document.getElementById('<%=txtMontoDeposito.ClientID%>').value == 0)
            {
                document.getElementById('<%=txtMontoDeposito.ClientID%>').value = '0.00';
            }
            if (document.getElementById('<%=txtMontoPrimerDeposito.ClientID%>').value == '') {
                document.getElementById('<%=txtMontoPrimerDeposito.ClientID%>').value = '0.00';
            }
            if (document.getElementById('<%=txtMontoDeposito.ClientID%>').value == '') {
                document.getElementById('<%=txtMontoDeposito.ClientID%>').value = '0.00';
            }
        }

        function textboxMultilineMaxLength(txt, maxLen) {
            try {
                if (txt.value.length > (maxLen - 1)) return false;
                } catch (e) {
                alert(e.GetText());
            }
         }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            //alert("Has pulsado el enlace...nAhora serás enviado a DesarrolloWeb.com");
        });
    </script>
    <style type="text/css">
        .auto-style4
        {}
        .auto-style4
        {}
        .auto-style4
        {}
        .auto-style4
        {}
        .auto-style4
        {}
        .auto-style5 {
            width: 166px;
        }
        .auto-style6 {
            width: 196px;
        }
        .auto-style7 {
            width: 182px;
        }
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%">
        <tr>
            <td width="100%" align="center">
                <asp:ImageButton ID="imgAux" runat="server" ImageUrl="~/Imagenes/pequeños/Favorites_32x32.png" />
                <asp:Label ID="lblTituloAUX" runat="server"
                    Text="Deudas Persona" CssClass="etiqueta20" Font-Size="16pt"></asp:Label>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td width="40%" align="right" colspan="1">
                Primer Apellido: <asp:TextBox ID="txtPrimerApellido" runat="server" Width="150px" onkeyup="this.value=this.value.toUpperCase()" ReadOnly="True" MaxLength="30"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" 
				runat="server" FilterType="Custom,LowercaseLetters,UppercaseLetters"
				TargetControlID="txtPrimerApellido" ValidChars="Ññ">
	            </cc1:FilteredTextBoxExtender>  
            </td>
            <td width="40%" align="right" colspan="1">
                Segundo Apellido: <asp:TextBox ID="txtSegundoApellido" runat="server" Width="150px" onkeyup="this.value=this.value.toUpperCase()" ReadOnly="True" MaxLength="30"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" 
				    runat="server" FilterType="Custom,LowercaseLetters,UppercaseLetters"
				    TargetControlID="txtSegundoApellido" ValidChars="ñÑ">
	                </cc1:FilteredTextBoxExtender>  
            </td>
            <td width="20%">

                <asp:HiddenField ID="hfParte" runat="server" />

            </td>
        </tr>
        <tr>
            <td width="40%" align="right" colspan="1">
                Primer Nombre: <asp:TextBox ID="txtPrimerNombre" runat="server" Width="150px" onkeyup="this.value=this.value.toUpperCase()" ReadOnly="True" MaxLength="30"></asp:TextBox>
                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" 
				    runat="server" FilterType="Custom,LowercaseLetters,UppercaseLetters"
				    TargetControlID="txtPrimerNombre" ValidChars="Ññ">
	                </cc1:FilteredTextBoxExtender>  
            </td>
            <td width="40%" align="right" colspan="1">
                Segundo Nombre: <asp:TextBox ID="txtSegundoNombre" runat="server" Width="150px" onkeyup="this.value=this.value.toUpperCase()" ReadOnly="True"></asp:TextBox>
                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" 
				    runat="server" FilterType="Custom,LowercaseLetters,UppercaseLetters"
				    TargetControlID="txtSegundoNombre" ValidChars="Ññ">
	                </cc1:FilteredTextBoxExtender>  
            </td>
            <td width="20%">

                <asp:HiddenField ID="hfIdBeneficio" runat="server" Value="0" />

            </td>
        </tr>
        <tr>
            <td width="40%" align="right" colspan="1">
                Documento de Identidad: <asp:TextBox ID="txtCI" runat="server" Width="150px" ReadOnly="True" MaxLength="50"></asp:TextBox>
                 <asp:DropDownList ID="ddlExtension" runat="server" Width="100px" DataTextField="ddlExtension" Enabled="false">
                 </asp:DropDownList>
                <cc1:FilteredTextBoxExtender ID="ftbtxtCI" 
				runat="server" FilterType="Numbers"
				TargetControlID="txtCI" ValidChars="">
				</cc1:FilteredTextBoxExtender>  
            </td>
            <td width="40%" align="right" colspan="1">
                Matrícula: <asp:TextBox ID="txtMatricula" runat="server" Width="150px" onkeyup="this.value=this.value.toUpperCase()" ReadOnly="True"></asp:TextBox>
                                 <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender19" 
							    runat="server" FilterType="Custom,UppercaseLetters,LowercaseLetters,Numbers"
							    TargetControlID="txtMatricula" ValidChars="Ññ">
					    </cc1:FilteredTextBoxExtender>
            </td>
            <td width="20%">
                <asp:HiddenField ID="hfMontoCC" runat="server" Value="0" />
            </td>
        </tr>
        <tr>
            <td width="40%" align="right" colspan="1">
                CUA: <asp:TextBox ID="txtCUA" runat="server" Width="150px" ReadOnly="True" MaxLength="10"></asp:TextBox>
                         <cc1:FilteredTextBoxExtender ID="ftetxtCUA" 
							    runat="server" FilterType="Numbers"
							    TargetControlID="txtCUA" ValidChars="">
					    </cc1:FilteredTextBoxExtender>  
            </td>
            <td width="40%" align="right">
                NUP: <asp:TextBox ID="txtNUP" runat="server" Width="150px" onkeyup="this.value=this.value.toUpperCase()" ReadOnly="True" MaxLength="15"></asp:TextBox>
                      <cc1:FilteredTextBoxExtender ID="txtNUP_FilteredTextBoxExtender" 
																runat="server" FilterType="Numbers"
																TargetControlID="txtNUP" ValidChars="">
													    </cc1:FilteredTextBoxExtender>  
            </td>
            <td width="20%">

                <asp:HiddenField ID="hfIdDeuda" runat="server" Value="0" />

            </td>
        </tr>
        <tr>
            <td width="40%" align="right" colspan="1">
                Fecha Nacimiento: <asp:TextBox ID="txtFechaNacimiento" runat="server" Width="150px" ReadOnly="True"></asp:TextBox>
            </td>
            <td width="40%" align="right" colspan="1">
                Fecha Fallecimiento: <asp:TextBox ID="txtFechaFallecimiento" runat="server" Width="150px" onkeyup="this.value=this.value.toUpperCase()" ReadOnly="True"></asp:TextBox>
            </td>
            <td width="20%">

                <asp:HiddenField ID="hfBeneficio" runat="server" />

                </td>
        </tr>
        <tr>
            <td width="40%" align="right" colspan="1">
                Sexo: <asp:TextBox ID="txtSexo" runat="server" Width="150px" ReadOnly="True"></asp:TextBox>
            </td>
            <td width="40%" align="right" colspan="1">
                Estado Civil: <asp:TextBox ID="txtEstadoCivil" runat="server" Width="150px" onkeyup="this.value=this.value.toUpperCase()" ReadOnly="True"></asp:TextBox>
            </td>
            <td width="20%">

                <asp:Label ID="lblSector" runat="server" Text="Label" Visible="false"></asp:Label>

            </td>
        </tr>
         <tr>
            <td width="40%" align="right" colspan="1">
                Dirección actual: <asp:TextBox ID="txtDireccion" runat="server" Width="150px" onkeyup="this.value=this.value.toUpperCase()" MaxLength="150" ReadOnly="true"></asp:TextBox>
                 <asp:DropDownList ID="ddlDepartamento" runat="server" Width="100px" DataTextField="ddlDepartamento" Enabled="false" OnSelectedIndexChanged="ddlDepartamento_SelectedIndexChanged" AutoPostBack="True">
                 </asp:DropDownList>
                 <asp:DropDownList ID="ddlLocalidad" runat="server" Width="100px" DataTextField="ddlLocalidad" Enabled="false">
                 </asp:DropDownList>

                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender23" 
				runat="server" FilterType="Custom,LowercaseLetters,UppercaseLetters,Numbers"
				TargetControlID="txtDireccion" ValidChars="#/.-,() ">
				</cc1:FilteredTextBoxExtender>
                 
            </td>
             <td width="40%" align="right" colspan="1">
                Celular: <asp:TextBox ID="txtCel" runat="server" Width="115px" MaxLength="8" ReadOnly="true"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender20" 
							runat="server" FilterType="Numbers"
							TargetControlID="txtCel" ValidChars="">
				</cc1:FilteredTextBoxExtender>  
                Numero de Referencia: <asp:TextBox ID="txtCelReferencial" runat="server" Width="115px" MaxLength="8" ReadOnly="true" ></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender21" 
				runat="server" FilterType="Numbers"
				TargetControlID="txtCelReferencial" ValidChars="">
				</cc1:FilteredTextBoxExtender>  
            </td>
            <td width="40%" align="right" colspan="1">
             Telefono: <asp:TextBox ID="txtTelefono" runat="server" Width="150px" MaxLength="8" ReadOnly="true"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender22" 
				runat="server" FilterType="Numbers"
				TargetControlID="txtTelefono" ValidChars="">
				</cc1:FilteredTextBoxExtender>  
            </td>
        </tr>
        <tr>
            <td></td><td></td>
            <td>
                <asp:Button ID="cmdLimpiar" runat="server" Text="Limpiar" Width="100px" OnClick="cmdLimpiar_Click" />
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td width="100%" align="left">
            Deudas Registradas:
            </td>
        </tr>
        <tr>
            <td width="100%" align="center">
                <asp:ImageButton ID="imgNuevo" runat="server" ImageUrl="~/Imagenes/pequeños/Add_32x32.png" ToolTip="Agregar Nueva Deuda" OnClick="imgNuevo_Click" />

                <asp:GridView ID="gvDeudas" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Size="9pt" ForeColor="#333333" OnRowCommand="gvDeudas_RowCommand" OnDataBound="gvDeudas_DataBound" OnRowDataBound="gvDeudas_RowDataBound" DataKeyNames="IdDeuda,Sector,Beneficio">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="Fila" HeaderText="Nro." />
                        <asp:BoundField DataField="IdDeuda" HeaderText="IdDeuda" Visible="False" />
                        <asp:BoundField DataField="TipoDeuda" HeaderText="Tipo Deuda" />
                        <asp:BoundField DataField="NumeroLiquidacion" HeaderText="Nro. Liquidación" />
                        <asp:BoundField DataField="Regional" HeaderText="Regional" />
                        <asp:BoundField DataField="MontoDeuda" HeaderText="Monto BS" />
                        <asp:BoundField DataField="FechaRegistroDeuda" HeaderText="Fecha Registro" DataFormatString="{0:d}" />
                        <asp:BoundField DataField="EstadoDeuda" HeaderText="EstadoDeuda" />
                        <asp:BoundField DataField="Sector" HeaderText="Sector" Visible="False" />
                        <asp:BoundField DataField="Beneficio" HeaderText="Beneficio" Visible="False" />
                        <asp:ButtonField CommandName="cmdDetalle" Text="Ver Detalle" HeaderText ="Detalle Convenio" />
                        <asp:ButtonField CommandName="cmdModificar" Text="Modificar" HeaderText ="Modificar Convenio" />
                        <asp:ButtonField CommandName="cmdControl" Text="Control" HeaderText ="Depositos Convenio" />
                        <asp:ButtonField CommandName="cmdEliminar1" Text="Eliminar" Visible="true" HeaderText ="Baja"/>
                        <asp:TemplateField HeaderText="Eliminar" Visible="false">
                          <ItemTemplate>

                            <asp:LinkButton ID="lbtnEliminaConvenio" 
                                CommandArgument= '<%# Eval("Fila") %>'
                                CommandName="cmdEliminar" runat="server"
                                OnClientClick="return confirm('¿ESTA SEGURO DE DAR DE BAJA EL CONVENIO?');">
                              Eliminar </asp:LinkButton>
                          </ItemTemplate>
                        </asp:TemplateField> 
                            
                    </Columns>
                    <EmptyDataTemplate>
                        <div align="center" class="CajaDialogoAdvertencia">
                        <br/>
                        <img src="../Imagenes/warning.gif" alt="La persona no cuenta con Deudas Registradas" />
                        <br/>La persona no cuenta con Deudas Registradas<br/><br/>
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
    <table width="100%" >
        <tr>
            <td align="center">
                <asp:Panel ID="pnlDeuda" runat="server">
                 <table width="70%" BORDER ="1">
        <tr>
            <td width="100%" align="center" >
                 <table width="100%" >
                <tr>
                    <td width="100%" align="center" height ="50%" style="background-color:#5D7B9D;" >
                        <FONT COLOR="white" size="6">
                <label onclick="btnOpenCloseRegistro_Click"><asp:ImageButton ID="btnOpenCloseRegistro" runat="server" ImageUrl="~/Imagenes/16adicionar.png" OnClick="btnOpenCloseRegistro_Click" /> Registro de la Deuda</label>
                            </FONT></td>

                </tr></table>
                <asp:Panel ID="pnlRegistro" runat="server" Width="100%" HorizontalAlign="Center" Visible="False">
                    <table width="100%">
                    <tr>
                <td align="right">Regional:</td>
                <td align="left">
                    <asp:DropDownList ID="ddlRegional" runat="server" Width="200px" AutoPostBack="true" DataTextField="Regional" onchange="Actualizar('<%=ddlRegional.ClientID%>');" OnSelectedIndexChanged="ddlRegional_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td align="right">Tipo Deuda:</td>
                <td align="left">
                    <asp:DropDownList ID="ddlTipoDeuda" runat="server" Width="200px" DataTextField="TipoDeuda" onchange="Actualizar('<%=ddlTipoDeuda.ClientID%>');"  OnSelectedIndexChanged="ddlEstadoDeuda_SelectedIndexChanged"  AutoPostBack="true">
                    </asp:DropDownList>
                </td>
            </tr>          
            <tr>
                <td align="right">Moneda:</td>
                <td align="left">
                    <asp:DropDownList ID="ddlMoneda" runat="server" Width="200px" DataTextField="Moneda" onchange="Actualizar('<%=ddlMoneda.ClientID%>');">
                    </asp:DropDownList>
                </td>
                <td align="right">Estado Deuda:</td>
                <td align="left">
                    <asp:DropDownList ID="ddlEstadoDeuda" runat="server" Width="200px" DataTextField="EstadoDeuda" >
                    </asp:DropDownList>
                </td>
              </tr>
            <tr>
                <td></td>
                <td>  <asp:UpdatePanel ID="UpdatePanel1" runat="server" Visible="true">
                        <ContentTemplate>
                            <asp:LinkButton ID="lnkTipoCambio" runat="server" Font-Underline="true" OnClick="lnkTipoCambio_Click"> 
                                 Ingresar Tipo Cambio
                            </asp:LinkButton>
                        </ContentTemplate>
                        </asp:UpdatePanel></td>
                <td>
                    <asp:Label ID="lblInsitucion" runat="server" Text="Label">Institución: </asp:Label>
                </td>
                <td align="left">
                <asp:DropDownList ID="ddlInstitucion" runat="server" Width="200px">

    			</asp:DropDownList>
                     <asp:Label ID="lblIdInstitucion" runat="server" Text="" Visible="false"></asp:Label>
	    		</td>
            </tr>
        </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table width="100%">
                <tr>
                    <td width="100%" align="center" style="background-color:#5D7B9D;" >
                        <FONT COLOR="white" size="6">
                        <label onclick="btnOpenCloseLiquidacion_Click" style="background-color:#5D7B9D; "><asp:ImageButton ID="btnOpenCloseLiquidacion" runat="server" ImageUrl="~/Imagenes/16adicionar.png" OnClick="btnOpenCloseLiquidacion_Click" /> Liquidación de la Deuda</label>
                    </td>
                </tr>
                </table>
              <asp:Panel ID="pnlLiquidacion" runat="server" Visible="False" Width="100%" HorizontalAlign="Center">
              <table width="100%" >
              <tr>
              <td colspan="4">
                  <asp:Panel ID="pnMontoLiquidacion" runat="server" Visible="False" Width="100%" HorizontalAlign="Center">
                    <table>
                        <tr>    
                    <td align="right"><asp:Label ID="lblPeriodoInicioTGN" runat="server" Text="Periodo Inicio Devolucion TGN:" Visible="true"></asp:Label> </td>
                    <td align="left" class="auto-style6" >
                        <asp:TextBox ID="txtPeriodoInicioDevTGN" runat="server" Height="20px" Width="143px" Visible="true" MaxLength="6"></asp:TextBox>
                        
                         <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" 
							    runat="server" FilterType="Numbers"
							    TargetControlID="txtPeriodoInicioDevTGN" ValidChars="">
					    </cc1:FilteredTextBoxExtender>  

                        <asp:ImageButton ID="ImageButton5" runat="server" ImageUrl="~/Imagenes/pequeños/Calendar_32x32.png" style="height: 32px" Visible="true" />
                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" Format="yyyyMM" PopupButtonID="ImageButton5" TargetControlID="txtPeriodoInicioDevTGN" CssClass="cal_Theme1">
                        </cc1:CalendarExtender>
                        <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtPeriodoInicioDevTGN" ID="RegularExpressionValidator9" ValidationExpression = "((([2][0-9][0-9][0-9]))(0[123456789]|10|11|12))$" runat="server" ErrorMessage="Periodo Incorrecto"></asp:RegularExpressionValidator>
                    </td>
                    <td align="right"><asp:Label ID="lblPeriodoFinDevolucion" runat="server" Text="Periodo Fin Devolucion TGN:" Visible="true"></asp:Label> </td>
                        
                    <td align="left" class="auto-style7">
                        <asp:TextBox ID="txtPeriodoFinDevTGN" runat="server" Height="20px" Width="135px" Visible="true"  onkeypress="return permite(event, 'num')" MaxLength="6"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" 
							    runat="server" FilterType="Numbers"
							    TargetControlID="txtPeriodoFinDevTGN" ValidChars="">
					    </cc1:FilteredTextBoxExtender>  
                        <asp:ImageButton ID="ImageButton6" runat="server" ImageUrl="~/Imagenes/pequeños/Calendar_32x32.png" style="height: 32px" Visible="false" />
                        <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Enabled="True" Format="yyyyMM" PopupButtonID="ImageButton6" TargetControlID="txtPeriodoFinDevTGN" CssClass="cal_Theme1">
                        </cc1:CalendarExtender>
                        
                        <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtPeriodoFinDevTGN" ID="RegularExpressionValidator8" ValidationExpression = "((([2][0-9][0-9][0-9]))(0[123456789]|10|11|12))$" runat="server" ErrorMessage="Periodo Incorrecto"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                        <tr>
                            <td colspan="3">
                                <asp:GridView ID="gvPeriodos" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Size="9pt" ForeColor="#333333" Width="583px" OnRowCommand="gvPeriodos_RowCommand">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                <asp:BoundField DataField="Fila" HeaderText="Nº" />
                                <asp:BoundField DataField="PeriodoInicioTGN" HeaderText="PERIODO INICIO TGN" />
                                <asp:BoundField DataField="PeriodoFinTGN" HeaderText="PERIODO FIN TGN" />
                                <asp:BoundField DataField="CantidadDuodecimas" HeaderText="CANTIDAD DE PAGOS EN EL PERIODO"/>
                                <asp:ButtonField ButtonType="Image" CommandName="cmdEliminar" ImageUrl="~/Imagenes/16eliminar.png" Text="Eliminar" />
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
                            <td align="left">

                                <asp:Button ID="btnAgregarPeriodo" runat="server" Text="AgregarPeriodo" OnClick="btnAgregarPeriodo_Click"  Width="120px" Visible="true"/>
                                <br />
                                <asp:Button ID="btnListaPago" runat="server" Text="MostrarPagos" OnClick="btnListaPago_Click"  Width="120px" Visible="true"/>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:GridView ID="gvListaPago" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Size="9pt" ForeColor="#333333" Width="375px">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                <asp:BoundField DataField="FechaInicio" HeaderText="FECHA INICIO" />
                                <asp:BoundField DataField="FechaFin" HeaderText="FECHA FIN" />
                                <asp:BoundField DataField="Monto" HeaderText="MONTO" />
                                <asp:BoundField DataField="CUA" HeaderText="CUA"/>
                                <asp:BoundField DataField="NumeroDocumento" HeaderText="CI" />
                                 <asp:TemplateField ControlStyle-Height="16"  ItemStyle-Width="5px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" Visible="true">
                                <HeaderTemplate>
                                <asp:CheckBox ID="chkTodos" runat="server" onclick = "checkAll(this);"  />
                                 </HeaderTemplate>    
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkEnvio" runat="server" Checked="false" />
                                </ItemTemplate>
                              </asp:TemplateField>
								<asp:CheckBoxField DataField="Activo" HeaderText="AGUINALDO"/>
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
                            <!-- <asp:GridView ID="gvVerPagos" runat="server" AutoGenerateColumns="False"   AllowPaging="True"  
                                          PageSize="10" SkinID="GridView" 
                                          EnableTheming="True" 
                                          Font-Names="Arial" 
                                            Font-Size="9pt" 
                                            CssClass="mGrid"
                                            PagerStyle-CssClass="pgr"
                                            AlternatingRowStyle-CssClass="alt"
                                            GridLines="None">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                <asp:BoundField DataField="FechaInicio" HeaderText="FECHA INICIO" />
                                <asp:BoundField DataField="FechaFin" HeaderText="FECHA FIN" />
                                <asp:BoundField DataField="Monto" HeaderText="MONTO" />
                                <asp:BoundField DataField="CUA" HeaderText="CUA"/>
                                <asp:BoundField DataField="NumeroDocumento" HeaderText="CI" />
                                
                                <asp:TemplateField ControlStyle-Height="16"  ItemStyle-Width="5px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" Visible="true">
  
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkEnvio" runat="server" Checked="false" />
                                </ItemTemplate>
                              </asp:TemplateField>
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
                        </asp:GridView>-->
                            </td>
                            <td colspan="2">
                                <asp:GridView ID="gvListaAguinaldo" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Size="9pt" ForeColor="#333333" Width="335px" OnRowDataBound="gvListaAguinaldo_RowDataBound">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                <asp:BoundField DataField="Gestion" HeaderText="GESTION" />
                                 <asp:BoundField DataField="MontoAguinaldo" HeaderText="MONTO" />
                                <asp:BoundField DataField="CUA" HeaderText="CUA"/>
                                <asp:BoundField DataField="NumeroDocumento" HeaderText="CI" />
                                <asp:BoundField DataField="" HeaderText="NUMERO DUODECIMA" />
                                 <asp:BoundField DataField="" HeaderText="MONTO" />
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



                <tr>    
                    <td align="right">Número Liquidación:</td>
                    <td align="left" class="auto-style6" >
                        <asp:TextBox ID="txtNumeroLiquidacion" runat="server" onchange="Actualizar('<%=txtNumeroLiquidacion.ClientID%>');" onkeypress="return permite(event, 'num')" Height="20px" Width="143px" Enabled="false"></asp:TextBox>
                    </td>
                    <td align="right">
                        <asp:Button ID="btnCalcularDeuda" runat="server" Text="Calcular Deuda" OnClick="btnCalcularDeuda_Click" Visible="false" style="margin-bottom: 0px" />
                        Monto Total Deuda:

                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtMontoTotal" runat="server" onchange="Actualizar('<%=txtMontoTotal.ClientID%>');" onkeypress="return permite(event, 'num')" Height="20px" Width="135px" MaxLength="10"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender17" 
							    runat="server" FilterType="Numbers,Custom"
							    TargetControlID="txtMontoTotal" ValidChars=".">
					         </cc1:FilteredTextBoxExtender> 
                    </td>
                </tr>
                <tr>
                    <td align="right">Fecha Actual:</td>
                    <td align="left" class="auto-style6">
                        <asp:TextBox ID="txtFechaActual" runat="server" Width="143px" AutoPostBack="true" onchange="Actualizar('<%=txtFechaActual.ClientID%>');" Height="20px" OnTextChanged="txtFechaActual_TextChanged" MaxLength="10"></asp:TextBox>
                           <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender16" 
						    runat="server" FilterType="Numbers,Custom"
						    TargetControlID="txtFechaActual" ValidChars="/">
					        </cc1:FilteredTextBoxExtender>
                        <cc1:CalendarExtender ID="txtFechaActual_CalendarExtender" runat="server" Enabled="True" Format="dd/MM/yyyy" PopupButtonID="btnFechaCambio" TargetControlID="txtFechaActual" CssClass="cal_Theme1">
                        </cc1:CalendarExtender>
                        <asp:ImageButton ID="btnFechaCambio" runat="server" ImageUrl="~/Imagenes/pequeños/Calendar_32x32.png" style="height: 32px" />
                        <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtFechaActual" ID="RegularExpressionValidator7" ValidationExpression = "^\d{1,2}\/\d{1,2}\/\d{2,4}$" runat="server" ErrorMessage="Formato de Fecha Incorrecta"></asp:RegularExpressionValidator>                        
                    </td>                   
                    <td align="right">
                      
                    </td>
                    <td></td>
                </tr>
            </table>
            <table width="100%">
                <tr>
                    <td align="center">
                        <asp:GridView ID="gvLiquidacionDeuda" runat="server" AutoGenerateColumns="False"  CellPadding="4" Font-Size="9pt" ForeColor="#333333" DataKeyNames="IdTipoMoneda">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:BoundField DataField="FechaCambio" HeaderText="Fecha de Cambio" DataFormatString="{0:d}" />
                                <asp:BoundField DataField="IdTipoMoneda" HeaderText="IdTM" Visible="False" />
                                <asp:BoundField DataField="TipoMoneda" HeaderText="Tipo Moneda" />
                                <asp:BoundField DataField="TasaCambio" HeaderText="Tasa de Cambio" />
                                <asp:BoundField DataField="MontoDeuda" HeaderText="Monto Deuda" />
                            </Columns>
                            <EmptyDataTemplate>
                                <div align="center" class="CajaDialogoAdvertencia">
                                <br/>
                                <img src="../Imagenes/warning.gif" alt="No existen Tipos de Cambio para la fecha Especificada" />
                                <br/>No existen Tipos de Cambio para la fecha Especificada<br/><br/>
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
                        <asp:Button ID="btnRegistraTC" runat="server" Text="Registrar Tipos de Cambio" OnClick="btnRegistraTC_Click" Visible="false" />
                    </td>
                </tr>
            </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td width="100%" align="center">
                 <table width="100%">
                <tr>
                    <td width="100%" align="center" style="background-color:#5D7B9D;" >
                        <FONT COLOR="white" size="6">
                <label onclick="btnOpenClosePlan_Click"><asp:ImageButton ID="btnOpenClosePlan" runat="server" ImageUrl="~/Imagenes/16adicionar.png" OnClick="btnOpenClosePlan_Click" /> Plan de Recuperación</label>
                            </FONT></td></tr></table>
                <asp:Panel ID="pnlPlan" runat="server" Visible="False" Width="100%" HorizontalAlign="Center">
                <table width="100%">
                    <tr>
                        <td></td><td></td>
                         <td align="right">Monto CC:</td>
                            <td align="left">
                        <asp:TextBox ID="txtRentaCC" runat="server" Enabled="false"></asp:TextBox>
                    </td>
                    </tr>
                <tr>                
                    <td align="right">Aplica:</td>
                    <td align="left" >
                        <asp:DropDownList ID="ddlAplica" runat="server" Width="250px" DataTextField="TipoDescuento">
                            <asp:ListItem Value="True">Aplica descuento automático</asp:ListItem>
                            <asp:ListItem Value="False">No aplica descuento</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td align="right">Porcentaje:</td>
                    <td align="left">
                        <asp:TextBox  ID="txtPorcentaje" runat="server" onchange="CalcularDescuento();" onkeypress="return permite(event, 'num')"  onFocus="Limpiar1('<%=txtPorcentaje.ClientID%>')" onBlur="Volver('<%=txtPorcentaje.ClientID%>')" MaxLength="5"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" 
							    runat="server" FilterType="Numbers,Custom"
							    TargetControlID="txtPorcentaje" ValidChars=".">
					         </cc1:FilteredTextBoxExtender> 
                    </td>
                   
                </tr>
                <tr>
                    <td align="right">Monto Primer Deposito:</td>
                    <td align="left">
                        <asp:TextBox ID="txtMontoPrimerDeposito" runat="server" onchange="Actualizar('<%=txtMontoPrimerDeposito.ClientID%>');" onFocus="Limpiar1('<%=txtMontoPrimerDeposito.ClientID%>')" onBlur="Volver('<%=txtMontoPrimerDeposito.ClientID%>')" onkeypress="return permite(event, 'num')" MaxLength="10"></asp:TextBox>
                             <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" 
							    runat="server" FilterType="Numbers,Custom"
							    TargetControlID="txtMontoPrimerDeposito" ValidChars=".">
					         </cc1:FilteredTextBoxExtender> 
                    </td>  
                    <td align="right">Saldo</td>
                    <td align="left" ><asp:TextBox ID="txtSaldo" runat="server" onkeypress="return permite(event, 'num')" Enabled="false" MaxLength="10" ></asp:TextBox>
                        
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" 
							    runat="server" FilterType="Numbers,Custom"
							    TargetControlID="txtSaldo" ValidChars=".">
					     </cc1:FilteredTextBoxExtender> 
                     </td>
                </tr>
                <tr>                
                    <td align="right">Monto Fijo Dep&oacute;sito:</td>
                    <td align="left">
                        <asp:TextBox ID="txtMontoDeposito" runat="server" onchange="Actualizar('<%=txtMontoDeposito.ClientID%>');"  onkeypress="return permite(event, 'num')" onFocus="Limpiar1('<%=txtMontoDeposito.ClientID%>')" onBlur="Volver('<%=txtMontoDeposito.ClientID%>')" style="margin-top: 0px" MaxLength="10"></asp:TextBox>
                         <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" 
							    runat="server" FilterType="Numbers,Custom"
							    TargetControlID="txtMontoDeposito" ValidChars=".">
					     </cc1:FilteredTextBoxExtender> 
                    </td>
                    <td align="right">Cuotas:</td>
                    <td align="left"><asp:TextBox ID="txtCuotas" runat="server" onchange="CalculaFin();" onkeypress="return permite(event, 'num')" MaxLength="10"></asp:TextBox>
                         <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender12" 
							    runat="server" FilterType="Numbers"
							    TargetControlID="txtCuotas" ValidChars="">
					     </cc1:FilteredTextBoxExtender> 
                    </td>
                </tr>
                <tr>                
                    <td align="right">Monto Fijo Descuento:</td>
                    <td align="left">
                        <asp:TextBox ID="txtMontoDescuento" runat="server" onchange="CalcularProcentaje();" onFocus="Limpiar1('<%=txtMontoDescuento.ClientID%>')" onBlur="Volver('<%=txtMontoDescuento.ClientID%>')" onkeypress="return permite(event, 'num')" MaxLength="10"></asp:TextBox>
                             <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" 
							    runat="server" FilterType="Numbers,Custom"
							    TargetControlID="txtMontoDescuento" ValidChars=".">
					     </cc1:FilteredTextBoxExtender> 
                    </td>
                    <td align="right">Periodo Inicio:</td>
                    <td align="left">
                        <asp:TextBox ID="txtPeriodoInicio" runat="server" MaxLength="6" Enabled="false"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtPeriodoInicio_CalendarExtender" runat="server" Enabled="True" Format="yyyyMM" PopupButtonID="ImageButton2" TargetControlID="txtPeriodoInicio" CssClass="cal_Theme1">
                        </cc1:CalendarExtender>
                        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Imagenes/pequeños/Calendar_32x32.png" />
                        <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtPeriodoInicio" ID="RegularExpressionValidator5" ValidationExpression = "^[0-9]{6,6}$" runat="server" ErrorMessage="Periodo Incorrecto"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>                
                    <td align="right">Observaciones:</td>
                    <td align="left">
                        &nbsp;<asp:TextBox ID="txtObservaciones" runat="server"  MaxLength="6"  Width="250px" onblur="Probando();" TextMode="MultiLine" onkeypress="return textboxMultilineMaxLength(this,200)" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                    </td>
                    <td align="right">Periodo Fin:</td>                                            
                    <td align="left">
                        <asp:TextBox ID="txtPeriodoFin" runat="server" MaxLength="6" Visible="true" Enabled="false"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtPeriodoFin_CalendarExtender" runat="server" Enabled="True" Format="yyyyMM" PopupButtonID="ImageButton3" TargetControlID="txtPeriodoFin" CssClass="cal_Theme1">
                        </cc1:CalendarExtender>
                        <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Imagenes/pequeños/Calendar_32x32.png" Visible="false"/>
                        <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtPeriodoFin" ID="RegularExpressionValidator6" ValidationExpression = "^[0-9]{6,6}$" runat="server" ErrorMessage="Periodo Incorrecto"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td><asp:Button ID="btnPlanPagos" runat="server" Text="Generar Plan de Pagos" OnClick="btnPlanPagos_Click" style="height: 26px; margin-top: 0px;"/></td>
                    <td>
                       <font SIZE=2>Edad A la Hora de Firmar Contrato:
                           <asp:Label ID="EdadActual" runat="server" Text="" Visible="true"></asp:Label>
                       </font>     
                    </td>
                    <td>
                         <font SIZE=2>Edad al terminar de pagar la Deuda:
                         <asp:Label ID="EdadFinal" runat="server" Text="" Visible="true"></asp:Label>
                         </font>
                    </td>
                </tr>
            </table>
            <table width="100%">
                 <tr>
                    <td align="left">
                        Plan de Pagos Proyectado:
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="gvPlanPagos" runat="server" AutoGenerateColumns="False"  CellPadding="4" Font-Size="9pt" ForeColor="#333333">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:BoundField DataField="Numero" HeaderText="Nro Cuota" />
                                <asp:BoundField DataField="Tipo" HeaderText="Tipo" />
                                <asp:BoundField DataField="Periodo" HeaderText="Periodo" />
                                <asp:BoundField DataField="Monto" HeaderText="Monto" />
                                <asp:BoundField DataField="Referencial" HeaderText="% Referencial" />
                            </Columns>
                            <EmptyDataTemplate>
                                <div align="center" class="CajaDialogoAdvertencia">
                                <br/>
                                <img src="../Imagenes/warning.gif" alt="No existe Plan de Pagos registrado para la deuda" />
                                <br/>No existe Plan de Pagos registrado para la deuda<br/><br/>
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
              <td align="center">
                  <asp:Button ID="btnImprimirPlan" runat="server" Text="Imprimir" OnClick="btnImprimirPlan_Click"/>
              </td>
        </tr>
        <tr>
            <td width="100%" align="center">
                 <table width="100%">
                <tr>
                    <td width="100%" align="center" style="background-color:#5D7B9D;" >
                        <FONT COLOR="white" size="6">
                            <label onclick="btnOpenCloseDocumentos_Click"><asp:ImageButton ID="btnOpenCloseDocumentos" runat="server" ImageUrl="~/Imagenes/16adicionar.png" OnClick="btnOpenCloseDocumentos_Click" /> Registro de la Documentación</label>
                            </FONT></td></tr></table>
                <asp:Panel ID="pnlDocumentos" runat="server" Visible="False" Width="100%" HorizontalAlign="Center">
                    <table >
                <tr>                
                    <td align="right">Tipo Documento:</td>
                    <td align="left">
                        <asp:DropDownList ID="ddlTipoDocumento" runat="server" Width="250px" DataTextField="TipoDocumento" OnSelectedIndexChanged="ddlTipoDocumento_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                    </td>
                    <td align="right">Nro. Documento:</td><td align="left">
                        <asp:TextBox ID="txtNroDoc" runat="server" MaxLength="20"></asp:TextBox>
                         <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender18" 
				        runat="server" FilterType="LowercaseLetters,UppercaseLetters,Numbers,Custom"
				        TargetControlID="txtNroDoc" ValidChars="/-">
	                    </cc1:FilteredTextBoxExtender>
                    </td>
                    
                </tr>
                <tr>                
                    <td align="right">Referencia:</td>
                    <td align="left" >
                        <asp:TextBox ID="txtReferencia" runat="server" Width="250px" TextMode="MultiLine" 
                            onkeyup="this.value=this.value.toUpperCase()"
                            onkeypress="return textboxMultilineMaxLength(this,200)"></asp:TextBox>
                    </td>
                    <td align="right">Observaciones:</td>
                    <td align="left">
                        <asp:TextBox ID="txtObservacionDoc" runat="server"  Width="250px" Height="35px" MaxLength="10" TextMode="MultiLine" onkeypress="return textboxMultilineMaxLength(this,200)" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                   </td>
                </tr>
                <tr>                
                    <td align="right">Fecha Documento:</td>
                    <td align="left">
                        <asp:TextBox ID="txtFechaDocumento" runat="server" Width="100px" MaxLength="10"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtFechaDocumento_CalendarExtender" runat="server" Enabled="True" Format="dd/MM/yyyy" PopupButtonID="ibtnFechaDocumento" TargetControlID="txtFechaDocumento" CssClass="cal_Theme1">
                        </cc1:CalendarExtender>
                        <asp:ImageButton ID="ibtnFechaDocumento" runat="server" ImageUrl="~/Imagenes/pequeños/Calendar_32x32.png" />
                        <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtFechaDocumento" ID="RegularExpressionValidator4" ValidationExpression = "^\d{1,2}\/\d{1,2}\/\d{2,4}$" runat="server" ErrorMessage="Formato de Fecha Incorrecta"></asp:RegularExpressionValidator>
                    </td>
                    <td>
                        <asp:Label ID="lblFilaDocumento" runat="server" Text="0" Visible="false"></asp:Label>
                        <asp:Label ID="lblIdDocumento" runat="server" Text="0" Visible="false"></asp:Label>
                    </td>                                            
                    <td>
                        <asp:Button ID="btnAgregarDoc" runat="server" Text="Agregar Documento" OnClick="btnAgregarDoc_Click"/>
                        <asp:Button ID="btnGuardarDoc" runat="server" Text="Guardar" OnClick="btnGuardarDoc_Click" Visible="false"/>
                    </td>
                </tr> 
            </table>
            <table>                                 
                <tr>
                    <td colspan="5">
                        <asp:GridView ID="gvDocumentos" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Size="9pt" ForeColor="#333333" OnRowCommand="gvDocumentos_RowCommand" DataKeyNames="IdDocumento,IdTipoDocumentoDeuda">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:BoundField DataField="Fila" HeaderText="Nº" />
                                <asp:BoundField DataField="IdDocumento" HeaderText="IdDocumento" Visible="False" />
                                <asp:BoundField DataField="IdTipoDocumentoDeuda" HeaderText="IdTipoDocumento" Visible="False" />
                                <asp:BoundField DataField="TipoDocumento" HeaderText="TIPO DOCUMENTO" />
                                <asp:BoundField DataField="NumeroDocumento" HeaderText="NRO DOCUMENTO" />
                                <asp:BoundField DataField="FechaDocumento" HeaderText="FECHA DOCUMENTO" DataFormatString="{0:d}" />
                                <asp:BoundField DataField="ReferenciaDocumento" HeaderText="REFERENCIA" />
                                <asp:BoundField DataField="Observaciones" HeaderText="OBSERVACIONES" />
                                <asp:BoundField DataField="FechaRegistroDeuda" HeaderText="FECHA DE REGISTRO" DataFormatString="{0:d}" />
                                <asp:ButtonField ButtonType="Image" CommandName="cmdEditar" ImageUrl="~/Imagenes/16modificar.png" Text="Editar" />
                                <asp:ButtonField ButtonType="Image" CommandName="cmdEliminar" ImageUrl="~/Imagenes/16eliminar.png" Text="Eliminar" />
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
            <table style="width:100%">                             
                <tr>
                    <td align="center">
                        <asp:Button ID="btnRegistrarDeuda" runat="server" Text="Registrar Deuda" OnClick="btnRegistrarDeuda_Click" Enabled="false"/>
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" OnClientClick="javascript : return confirm('Esta seguro de cancelar? se perderan los datos no guardados');"/>
                    </td>
                </tr>
            </table> 
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="lblMesRetiro" runat="server" Text="Mes de Retiro" CssClass="etiqueta20" Font-Size="10" Visible="false"></asp:Label>
                <asp:TextBox ID="txtMesRetiro" runat="server" Width="100px" MaxLength="10" Visible="false"></asp:TextBox>
                 <cc1:CalendarExtender ID="CalendarExtender4" runat="server" Enabled="True" Format="yyyyMM" PopupButtonID="ImageButton7" TargetControlID="txtMesRetiro" CssClass="cal_Theme1" >
                 </cc1:CalendarExtender>
                 <asp:ImageButton ID="ImageButton7" runat="server" ImageUrl="~/Imagenes/pequeños/Calendar_32x32.png" Visible="false"/>
                 <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtMesRetiro" ID="RegularExpressionValidator1" ValidationExpression = "^\d{6,6}$" runat="server" ErrorMessage="Formato de Fecha Incorrecta"></asp:RegularExpressionValidator>       
                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender24" 
							    runat="server" FilterType="Numbers"
							    TargetControlID="txtMesRetiro" ValidChars="">
					    </cc1:FilteredTextBoxExtender>


                 <asp:Label ID="lblFechaPago" runat="server" Text="Fecha de Pago" CssClass="etiqueta20" Font-Size="10" Visible="false"></asp:Label>
                 <asp:TextBox ID="txtFechaPago" runat="server" Width="100px" MaxLength="10" Visible="false"></asp:TextBox>
                 <cc1:CalendarExtender ID="CalendarExtender5" runat="server" Enabled="True" Format="dd/MM/yyyy" PopupButtonID="ImageButton8" TargetControlID="txtFechaPago" CssClass="cal_Theme1" >
                 </cc1:CalendarExtender>
                 <asp:ImageButton ID="ImageButton8" runat="server" ImageUrl="~/Imagenes/pequeños/Calendar_32x32.png" Visible="false"/>
                 <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtFechaPago" ID="RegularExpressionValidator10" ValidationExpression = "^\d{1,2}\/\d{1,2}\/\d{2,4}$" runat="server" ErrorMessage="Formato de Fecha Incorrecta"></asp:RegularExpressionValidator>       
                 <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender25" 
				 runat  ="server" FilterType="Custom,Numbers"
				TargetControlID="txtFechaPago" ValidChars="/">
				</cc1:FilteredTextBoxExtender>
                <asp:Button ID="btnImprimirDeuda" runat="server" Text="Imprimir" OnClick="btnImprimirDeuda_Click"/></td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlTipoCambio" runat="server" CssClass="panelceleste"  HorizontalAlign="Center" Width="700px">
                    <div>
                        <asp:Label ID="lblTitulo" runat="server" Text="Agregar Tipo de Cambio"
                            CssClass="etiqueta20" Font-Size="14pt" Font-Underline="True"></asp:Label>
                        <table style="width: 100%;">
                            <tr>
                                <td align="right" style="width: 30%">&nbsp;</td>
                                <td align="left" width="70%">
                                    <asp:Label ID="lblObservaciones" runat="server" CssClass="text_obs"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style5">
                                    <asp:Label ID="Label5" runat="server" Text="Moneda: " CssClass="etiqueta10"></asp:Label>
                                </td>
                                <td align="left" class="auto-style5">
                                    <asp:DropDownList ID="ddlTipoMonedaTC" runat="server" Width="150px">
                                    </asp:DropDownList>
                                    </td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style5">
                                    <asp:Label ID="Label6" runat="server" Text="Tipo de Cambio: " CssClass="etiqueta10"></asp:Label>
                                </td>
                                <td align="left" class="auto-style5">

                                    <asp:TextBox ID="txtTipoCambioTC" runat="server" Width="150px" TextMode="SingleLine" onkeypress="return permite(event, 'num')"></asp:TextBox>

                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style5">
                                    <asp:Label ID="Label7" runat="server" Text="Fecha Tipo de Cambio: " CssClass="etiqueta10"></asp:Label>
                                </td>
                                <td align="left" class="auto-style5">
                                    
                                    <asp:TextBox ID="txtFechaTC" runat="server" Width="100px" Enabled="True"></asp:TextBox>
                                    <cc1:CalendarExtender ID="txtFechaTC_CalendarExtender" runat="server" Enabled="True" Format="dd/MM/yyyy" PopupButtonID="ImageButton1" TargetControlID="txtFechaTC" CssClass="cal_Theme1">
                                    </cc1:CalendarExtender>
                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Imagenes/pequeños/Calendar_32x32.png" />
                                    <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtFechaTC" ID="RegularExpressionValidator3" ValidationExpression = "^\d{1,2}\/\d{1,2}\/\d{2,4}$" runat="server" ErrorMessage="Formato de Fecha Incorrecta"></asp:RegularExpressionValidator>

                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 50%">&nbsp;</td>
                                <td align="left">
                                    <asp:Button ID="btnAccionar" runat="server" OnClick="btnAccionar_Click"
                                        OnClientClick="javascript : return confirm('Esta seguro de realizar esta accion?');"
                                        Text="Aceptar" CssClass="boton150" />
                                    <asp:Button ID="btnCancelarTC" runat="server" EnableTheming="True"
                                        OnClick="btnCancelarTC_Click" Text="Cancelar"
                                        CssClass="boton150" />
                                </td>
                            </tr>

                        </table>

                    </div>
                </asp:Panel>
                <cc1:RoundedCornersExtender ID="pnlTipoCambio_RoundedCornersExtender" runat="server"
                    Enabled="True" TargetControlID="pnlTipoCambio" Radius="10" BorderColor="Black">
                </cc1:RoundedCornersExtender>
                <cc1:ModalPopupExtender ID="pnlTipoCambio_ModalPopupExtender" runat="server"
                    Enabled="True"
                    TargetControlID="lblTitulo"
                    CancelControlID="btnCancelarTC"
                    PopupControlID="pnlTipoCambio"
                    BackgroundCssClass="modalBackground">
                </cc1:ModalPopupExtender>
            </td>
        </tr>
    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td align="center">
                <asp:Panel ID="pnlControl" runat="server">
                    <table width="100%">
                        <tr>
                            <td align="left" height="50px">
                                Detalle del Historial de Depósitos efectuados por el Asegurado - Actualizado a la Fecha:
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:ImageButton ID="btnNuevoDeposito" runat="server" ToolTip="Registrar Nuevo Deposito" ImageUrl="~/Imagenes/pequeños/Add_32x32.png" OnClick="btnNuevoDeposito_Click" Enabled="true" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:GridView ID="gvDepositos" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Size="9pt" ForeColor="#333333" OnRowCommand="gvDepositos_RowCommand" AllowPaging="True" DataKeyNames="IdMonedaDeposito,IdCuenta,IdDeposito" OnPageIndexChanging="gvDepositos_PageIndexChanging" OnDataBound ="gvDepositos_DataBound">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:BoundField DataField="Fila" HeaderText="Nro." />
                                        <asp:BoundField DataField="FechaDeposito" HeaderText="Fecha Depósito" DataFormatString="{0:d}" />
                                        <asp:BoundField DataField="IdMonedaDeposito" HeaderText="IdMonedaDeposito" Visible="False" />
                                        <asp:BoundField DataField="IdCuenta" HeaderText="IdCuentaBanco" Visible="False" />
                                        <asp:BoundField DataField="NumeroDepositoBanco" HeaderText="Número Depoósito" />
                                        <asp:BoundField DataField="CuentaBanco" HeaderText="Banco" />
                                        <asp:BoundField DataField="MontoBS" HeaderText="Monto BS" DataFormatString="{0:F}" />
                                        <asp:BoundField DataField="CuentaUsuario" HeaderText="Usuario" />
                                        <asp:BoundField DataField="FechaRegistroDeposito" HeaderText="Fecha Registro" DataFormatString="{0:d}" />
                                        <asp:BoundField DataField="IdDeposito" HeaderText="IdDeposito" Visible="False" />
                                        <asp:ButtonField ButtonType="Image" CommandName="cmdEditar" ImageUrl="~/Imagenes/16modificar.png" Text="Editar..." />
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <div align="center" class="CajaDialogoAdvertencia">
                                        <br/>
                                        <img src="../Imagenes/warning.gif" alt="No se tienen depósitos registrados" />
                                        <br/>No se tienen depósitos registrados<br/><br/>
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
                            <td align="left" height="50px">
                                Detalle del Historial de Descuentos Automáticos Pagos CC - Actualizado a la Fecha:
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:GridView ID="gvRecuperaciones" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Size="9pt" ForeColor="#333333" AllowPaging="True" OnPageIndexChanging="gvRecuperaciones_PageIndexChanging">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:BoundField DataField="Fila" HeaderText="Nro." />
                                        <asp:BoundField DataField="PeriodoSolicitud" HeaderText="Periodo Planilla" />
                                        <asp:BoundField DataField="FechaInicio" HeaderText="Fecha Inicio" />
                                        <asp:BoundField DataField="FechaFin" HeaderText="Fecha Fin" />
                                        <asp:BoundField DataField="MontoCC" HeaderText="Monto CC Bs." />
                                        <asp:BoundField DataField="CodigoTransaccion" HeaderText="Transacción" />
                                        <asp:BoundField DataField="MontoDescuento" HeaderText="Monto Descuento Convenio Bs." />
                                    </Columns>
                                    <EmptyDataTemplate>
                                        <div align="center" class="CajaDialogoAdvertencia">
                                        <br/>
                                        <img src="../Imagenes/warning.gif" alt="No se tienen recuperaciones registrados" />
                                        <br/>No se tienen recuperaciones registrados<br/><br/>
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
                            <td align="center">
                                TOTAL DEPOSITOS: <asp:TextBox ID="txtTotalDepositos" runat="server" ReadOnly="True" Width="80px"></asp:TextBox>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                TOTAL DESCUENTOS: <asp:TextBox ID="txtTotalDescuentos" runat="server" ReadOnly="True" Width="80px"></asp:TextBox>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                SALDO DEUDA: <asp:TextBox ID="txtSaldoDeuda" runat="server" ReadOnly="True" Width="80px"></asp:TextBox>
                                <asp:Label ID="txtSaldoAux" runat="server" Width="80px" Visible="false"></asp:Label>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <asp:Button ID="btnExportarDepositos" runat="server" Text="Exportar..." OnClick="btnExportarDepositos_Click" Visible="false" />
                                </ContentTemplate>
                                <Triggers>
                                    <asp:PostBackTrigger ControlID="btnExportarDepositos" />
                                </Triggers>
                                </asp:UpdatePanel>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnImprimirDepositos" runat="server" Text="Imprimir..." OnClick="btnImprimirDepositos_Click" />
                            </td>
                        </tr>
                        
                        <tr>
                            <td>
                                
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td align="center">
                <asp:Panel ID="pnlDeposito" runat="server" CssClass="panelceleste"  HorizontalAlign="Center" Width="700px">
                    <div>
                        <asp:Label ID="lblTituloND" runat="server" Text="Agregar Nuevo Depósito"
                            CssClass="etiqueta20" Font-Size="14pt" Font-Underline="True"></asp:Label>
                        <table style="width: 100%;">
                            <tr>
                                <td align="right" style="width: 30%">&nbsp;</td>
                                <td align="left" width="70%">
                                    <asp:Label ID="Label2" runat="server" CssClass="text_obs"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style5">
                                    <asp:Label ID="Label3" runat="server" Text="Moneda: " CssClass="etiqueta10"></asp:Label>
                                </td>
                                <td align="left" class="auto-style5">
                                    <asp:DropDownList ID="ddlTipoMonedaND" runat="server" Width="150px">
                                    </asp:DropDownList>
                                    </td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style5">
                                    <asp:Label ID="Label4" runat="server" Text="Monto: " CssClass="etiqueta10"></asp:Label>
                                </td>
                                <td align="left" class="auto-style5">

                                    <asp:TextBox ID="txtMontoDepositoND" runat="server" Width="100px" TextMode="SingleLine"  onkeypress="return permite(event, 'num')" MaxLength="10"></asp:TextBox>
                                      <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender13" 
							    runat="server" FilterType="Numbers,Custom"
							    TargetControlID="txtMontoDepositoND" ValidChars=".">
					         </cc1:FilteredTextBoxExtender> 
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="auto-style5">
                                    <asp:Label ID="Label8" runat="server" Text="Fecha Depósito: " CssClass="etiqueta10"></asp:Label>
                                </td>
                                <td align="left" class="auto-style5">
                                    
                                    <asp:TextBox ID="txtFechaDepositoND" runat="server" Width="100px" MaxLength="10"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender15" 
							            runat="server" FilterType="Numbers,Custom"
							            TargetControlID="txtFechaDepositoND" ValidChars="/">
					                 </cc1:FilteredTextBoxExtender> 

                                    <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/Imagenes/pequeños/Calendar_32x32.png" />
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy" PopupButtonID="ImageButton4" TargetControlID="txtFechaDepositoND" CssClass="cal_Theme1">
                                    </cc1:CalendarExtender>
                                     <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtFechaDepositoND" ID="RegularExpressionValidator2" ValidationExpression = "^\d{1,2}\/\d{1,2}\/\d{2,4}$" runat="server" ErrorMessage="Formato de Fecha Incorrecta"></asp:RegularExpressionValidator>
                                    
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label9" runat="server" Text="Número Depósito: " CssClass="etiqueta10"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtNumeroDepositoND" runat="server" Width="150px"  onkeypress="return permite(event, 'num')" MaxLength="20"></asp:TextBox>
                                       <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender14" 
							    runat="server" FilterType="Numbers,UppercaseLetters,LowercaseLetters"
							    TargetControlID="txtNumeroDepositoND" ValidChars="">
					         </cc1:FilteredTextBoxExtender> 
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label10" runat="server" Text="Banco/Cuenta: " CssClass="etiqueta10"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlCuentasBancoND" runat="server" Width="250px"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 50%">
                                    <asp:Label ID="lblIdDeposito" runat="server" Text="0" Visible="false"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Button ID="btnAccionarND" runat="server" OnClick="btnAccionarND_Click"
                                        OnClientClick="javascript : return confirm('Esta seguro de realizar esta accion?');"
                                        Text="Aceptar" CssClass="boton150" />
                                    <asp:Button ID="btnCancelarND" runat="server" EnableTheming="True"
                                        OnClick="btnCancelarND_Click" Text="Cancelar"
                                        CssClass="boton150" />
                                </td>
                            </tr>

                        </table>

                    </div>
                </asp:Panel>
                <cc1:RoundedCornersExtender ID="RoundedCornersExtender1" runat="server"
                    Enabled="True" TargetControlID="pnlDeposito" Radius="10" BorderColor="Black">
                </cc1:RoundedCornersExtender>
                <cc1:ModalPopupExtender ID="pnlDeposito_ModalPopupExtender" runat="server"
                    Enabled="True"
                    TargetControlID="lblTituloND"
                    CancelControlID="btnCancelarND"
                    PopupControlID="pnlDeposito"
                    BackgroundCssClass="modalBackground">
                </cc1:ModalPopupExtender>
            </td>
        </tr>
        <tr>
            <td>
         
                <asp:Panel runat="server"  ID="pnlJustificar" CssClass="panelceleste" HorizontalAlign="Center">
                    <table align="center" cellpadding="0" cellspacing="0" width="700px">
                        <tr>
                            <td align="center" colspan="2">
                                <asp:Label ID="lblObservadoi" runat="server"><h2>Justificación de Baja de Convenio</h2></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <label style="color: red">*</label>
                                <asp:Label ID="lblMotivoi" runat="server" CssClass="etiqueta10">Motivo:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtMotivoi" runat="server" Width="385px" onkeyup="this.value=this.value.toUpperCase()" MaxLength="100"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <label style="color: red">*</label>
                                <label class="etiqueta10">Autorizador:</label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtAutorizadori" runat="server" Width="200px" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <label style="color: red">*</label>
                                <label class="etiqueta10">Observaciones:</label></td>
                            <td align="left">
                                <asp:TextBox ID="txtObservacioni" runat="server" Height="100px" TextMode="MultiLine" Width="300px" MaxLength="10" onkeyup="this.value=this.value.toUpperCase()"></asp:TextBox>
                                <cc1:FilteredTextBoxExtender ID="txtObservacioni_FilteredTextBoxExtender"
                                    runat="server" FilterType="Custom, LowercaseLetters, UppercaseLetters,Numbers"
                                    TargetControlID="txtObservacioni" ValidChars="'áéíóúÁÉÍÓÚñÑ.#/ ">
                                </cc1:FilteredTextBoxExtender>
                                
                                <cc1:RoundedCornersExtender ID="RoundedCornersExtender2" runat="server"
                                Enabled="True" TargetControlID="pnlJustificar" Radius="10" BorderColor="Black">
                                </cc1:RoundedCornersExtender>
                                <cc1:ModalPopupExtender ID="ModalPopupExtender3pnlJustificar" runat="server" CancelControlID="btnNoJustificar" TargetControlID="lblObservadoi" PopupControlID="pnlJustificar" BackgroundCssClass="modalBackground" Enabled="True">
                                </cc1:ModalPopupExtender>
                 
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                        <asp:Button CssClass="buttonGreen" Text="Si, Continuar" runat="server" ID="btnSiJustificar" OnClick="btnSiJustificar_Click"  
                              OnClientClick="javascript : return confirm('Esta seguro de realizar esta accion?');"/>&nbsp;
                        <asp:Button CssClass="buttonRed" Text="No, Verificar" runat="server" ID="btnNoJustificar" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>

            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel runat="server"  ID="pnlMensaje" CssClass="panelceleste" HorizontalAlign="Center">
                    <table align="center" cellpadding="0" cellspacing="0" width="700px">
                        <tr>
                            <td align="center" colspan="2">
                                <h2><asp:Label ID="lblMensaje" runat="server"></asp:Label></h2>
                            </td>
                        </tr>
                        <tr>
                        <td>
                            <cc1:RoundedCornersExtender ID="RoundedCornersExtender3" runat="server"
                            Enabled="True" TargetControlID="pnlMensaje" Radius="10" BorderColor="Black">
                            </cc1:RoundedCornersExtender>
                            <cc1:ModalPopupExtender ID="ModalPopupExtender3pnlMensaje" runat="server" CancelControlID="btnAcepetar" TargetControlID="lblMensaje" PopupControlID="pnlMensaje" BackgroundCssClass="modalBackground" Enabled="True">
                            </cc1:ModalPopupExtender>
                        </td>
                        </tr>
                        <tr>
                        <td colspan="2" align="center">
                            <asp:Button CssClass="buttonRed" Text="Aceptar" runat="server" ID="btnAcepetar" />
                        </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>

