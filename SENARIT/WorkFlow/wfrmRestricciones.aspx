<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmRestricciones.aspx.cs" Inherits="WorkFlow_wfrmRestricciones" StylesheetTheme="Modal"%>
<%@ MasterType VirtualPath="~/MasterPage.master" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">   
  
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="pnlGral">
      <asp:Panel ID="pnlDatos" runat="server" CssClass="pnlBody">
        <table style="width: 100%;">
            <tr>
                <td colspan="4" align="center">
                    <asp:ImageButton ID="imgAux" runat="server" ImageUrl="~/Imagenes/16w.png" />
                    <asp:Label ID="lblTituloAUX" runat="server" CssClass="texto12" Text="Registro Restricciones"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 150px">
                    <asp:Label ID="Label1" runat="server" Text="ID Restricción:"></asp:Label>
                </td>
                <td align="left" style="width: 240px">
                    <asp:TextBox ID="txtIdRestriccion" runat="server" CssClass="box" Width="108px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvIdRestriccion" runat="server" ControlToValidate="txtIdRestriccion" ErrorMessage="*"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="ravIdRestriccion" runat="server" ControlToValidate="txtIdRestriccion" ErrorMessage="Fuera de rango" MaximumValue="2147483647" MinimumValue="1" Type="Integer"></asp:RangeValidator>
                </td>
                <td align="right">
                    <asp:Label ID="Label6" runat="server" Text="Descripción:"></asp:Label>
                </td>
                <td align="left">
                    <asp:TextBox ID="txtDescripcion" runat="server" CssClass="box" Width="450px" MaxLength="100"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvDescrpcion" runat="server" ControlToValidate="txtDescripcion" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:RadioButton ID="rbtConcepto" runat="server" AutoPostBack="True" GroupName="SelecOpcional" OnCheckedChanged="rbtConcepto_CheckedChanged" Text="Concepto" TextAlign="Left" />
                </td>
                <td align="left" colspan="3">
                    <asp:DropDownList ID="cboConcepto" runat="server" AutoPostBack="True" CssClass="box" Enabled="False" Width="800px" OnSelectedIndexChanged="cboConcepto_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvConcepto" runat="server" ControlToValidate="cboConcepto" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 150px">
                    <asp:RadioButton ID="rbtTipoDoc" runat="server" AutoPostBack="True" GroupName="SelecOpcional" OnCheckedChanged="rbtTipoDoc_CheckedChanged" Text="Tipo Documento" TextAlign="Left" />
                </td>
                <td align="left" colspan="3">
                    <asp:DropDownList ID="cboTipoDocumento" runat="server" AutoPostBack="True" CssClass="box" Enabled="False" Width="800px" OnSelectedIndexChanged="cboTipoDocumento_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvTipoDoc" runat="server" ControlToValidate="cboTipoDocumento" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 150px">
                    <asp:Label ID="Label4" runat="server" Text="Comentarios:"></asp:Label>
                </td>
                <td align="left" colspan="3" width="220">
                    <asp:TextBox ID="txtComentarios" runat="server" Width="800px" CssClass="box" MaxLength="500"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 150px">
                    <asp:Label ID="Label5" runat="server" Text="Tipo de Restricción:"></asp:Label>
                </td>
                <td align="left" style="width: 240px">
                    <asp:DropDownList ID="cboTipoRestriccion" runat="server" Width="229px" CssClass="box" AutoPostBack="True" OnSelectedIndexChanged="cboTipoRestriccion_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="tfvTipoRestriccion" runat="server" ControlToValidate="cboTipoRestriccion" ErrorMessage="*" InitialValue="Seleccione valor ..."></asp:RequiredFieldValidator>
                </td>
                <td align="right">
                    <asp:Label ID="Label9" runat="server" Text="Negación:"></asp:Label>
                </td>
                <td align="left">
                    <asp:CheckBox ID="chkNegacion" runat="server"/>
                </td>
            </tr>
            <tr>
                <td align="right" colspan="4">
                    
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center" colspan="4">    
                    <asp:Panel ID="pnlValores" runat="server" CssClass="panelceleste" Visible="false" Width="987px">
                        <table style="width: 100%;">
                            <tr>
                                <td style="width: 150px">
                                    <asp:Label ID="Label21" runat="server" Text="Tipo Dato/Concepto:"></asp:Label>
                                </td>
                                <td align="left" style="width: 120px">
                                    <asp:DropDownList ID="cboTipoDato" runat="server" CssClass="box" Enabled="False" Width="100px">                                                                                
                                        <asp:ListItem Value="I">Int</asp:ListItem>
                                        <asp:ListItem Value="M">Money</asp:ListItem>
                                        <asp:ListItem Value="F">Float</asp:ListItem>
                                        <asp:ListItem Value="C">Char</asp:ListItem>
                                        <asp:ListItem Value="D">Date</asp:ListItem>
                                        <asp:ListItem Value="T">caTalog</asp:ListItem>
                                        <asp:ListItem Value="B">Boolean</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td align="center">
                                    <asp:MultiView ID="mvValores" runat="server" ActiveViewIndex="-1">
                                        <asp:View ID="vInt" runat="server">
                                            <table style="width: 100%;">
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="Label12" runat="server" Text="Valor desde:"></asp:Label>
                                                    </td>
                                                    <td width="50">&nbsp;</td>
                                                    <td align="left">
                                                        <asp:Label ID="lblHastaInt" runat="server" Text="Valor hasta:"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="auto-style9">
                                                        <asp:RangeValidator ID="ravIntDesde" runat="server" ControlToValidate="txtValorDesdeInt" ErrorMessage="Fuera de rango" MaximumValue="2147483647" MinimumValue="1" Type="Integer"></asp:RangeValidator>
                                                        <asp:RequiredFieldValidator ID="rfvValDesInt" runat="server" ControlToValidate="txtValorDesdeInt" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                        <asp:TextBox ID="txtValorDesdeInt" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td align="center" class="auto-style9" width="50"></td>
                                                    <td align="left" class="auto-style9" style="margin-left: 40px">
                                                        <asp:TextBox ID="txtValorHastaInt" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvValHasInt" runat="server" ControlToValidate="txtValorHastaInt" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                        <asp:RangeValidator ID="ravIntHasta" runat="server" ControlToValidate="txtValorHastaInt" ErrorMessage="Fuera de rango" MaximumValue="2147483647" MinimumValue="1" Type="Integer"></asp:RangeValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td width="50"></td>
                                                    <td></td>
                                                </tr>
                                            </table>
                                        </asp:View>
                                        <asp:View ID="vMoney" runat="server">
                                            <table style="width: 100%;">
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="Label14" runat="server" Text="Valor desde:"></asp:Label>
                                                    </td>
                                                    <td width="50">&nbsp;</td>
                                                    <td align="left">
                                                        <asp:Label ID="lblMonHasta" runat="server" Text="Valor hasta:"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:RangeValidator ID="ravMonDesde" runat="server" ControlToValidate="txtValorDesdeMon" ErrorMessage="Fuera de rango" MaximumValue="922337203685477,5807" MinimumValue="0,00000001" Type="Double"></asp:RangeValidator>
                                                        <asp:RequiredFieldValidator ID="rfvValDesMon" runat="server" ControlToValidate="txtValorDesdeMon" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                        <asp:TextBox ID="txtValorDesdeMon" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td align="center" width="50"></td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtValorHastaMon" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvValHasMon" runat="server" ControlToValidate="txtValorHastaMon" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                        <asp:RangeValidator ID="ravMonHasta" runat="server" ControlToValidate="txtValorHastaMon" ErrorMessage="Fuera de rango" MaximumValue="922337203685477,5807" MinimumValue="0,00000001" Type="Double"></asp:RangeValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center">&nbsp;</td>
                                                    <td width="50">&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                            </table>
                                        </asp:View>
                                        <asp:View ID="vFloat" runat="server">
                                            <table style="width: 100%;">
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="Label17" runat="server" Text="Valor desde:"></asp:Label>
                                                    </td>
                                                    <td width="50">&nbsp;</td>
                                                    <td align="left">
                                                        <asp:Label ID="lblHastaFloat" runat="server" Text="Valor hasta:"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:RangeValidator ID="ravFloatDesde" runat="server" ControlToValidate="txtValorDesdeFloat" ErrorMessage="Fuera de rango" MaximumValue="922337203685477,5807" MinimumValue="0,00000001" Type="Double"></asp:RangeValidator>
                                                        <asp:RequiredFieldValidator ID="rfvValDesFloat" runat="server" ControlToValidate="txtValorDesdeFloat" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                        <asp:TextBox ID="txtValorDesdeFloat" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td align="center" width="50"></td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtValorHastaFloat" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvValHastaFloat" runat="server" ControlToValidate="txtValorHastaFloat" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                        <asp:RangeValidator ID="ravFloatHasta" runat="server" ControlToValidate="txtValorHastaFloat" ErrorMessage="Fuera de rango" MaximumValue="922337203685477,5807" MinimumValue="0,00000001" Type="Double"></asp:RangeValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td width="50"></td>
                                                    <td></td>
                                                </tr>
                                            </table>
                                        </asp:View>
                                        <asp:View ID="vChar" runat="server">
                                            <table style="width: 100%;">
                                                <tr>
                                                    <td align="center">
                                                        <asp:Label ID="Label18" runat="server" Text="Valor:"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center">
                                                        <asp:TextBox ID="txtValorChar" runat="server" MaxLength="500" Width="400px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvValChar" runat="server" ControlToValidate="txtValorChar" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtValorChar" ErrorMessage="Caracteres (Max. 500)" ValidationExpression="^[\s\S]{0,500}$"></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center">&nbsp;</td>
                                                </tr>
                                            </table>
                                        </asp:View>
                                        <asp:View ID="vDate" runat="server">
                                            <table style="width: 100%;">
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="Label19" runat="server" Text="Valor desde:"></asp:Label>
                                                    </td>
                                                    <td width="50">&nbsp;</td>
                                                    <td align="left">
                                                        <asp:Label ID="lblHastaFec" runat="server" Text="Valor hasta:"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:TextBox ID="txtValorDesdeFec" runat="server" BackColor="#87CEEB" Width="75px"></asp:TextBox>
                                                        <cc1:TextBoxWatermarkExtender ID="txtValorDesdeFec_TextBoxWatermarkExtender" runat="server" Enabled="True" TargetControlID="txtValorDesdeFec" WatermarkText="__/__/____">
                                                        </cc1:TextBoxWatermarkExtender>
                                                        <cc1:CalendarExtender ID="txtValorDesdeFec_CalendarExtender" runat="server" Format="dd/MM/yyyy" PopupButtonID="imgPopupDesde" TargetControlID="txtValorDesdeFec">
                                                        </cc1:CalendarExtender>
                                                        <asp:ImageButton ID="imgPopupDesde" runat="server" ImageAlign="Bottom" ImageUrl="../Imagenes/pequeños/CalendarC_16x16.png" />
                                                    </td>
                                                    <td align="center" width="50"></td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtValorHastaFec" runat="server" BackColor="#87CEEB" Width="75px"></asp:TextBox>
                                                        <cc1:TextBoxWatermarkExtender ID="txtValorHastaFec_TextBoxWatermarkExtender" runat="server" Enabled="True" TargetControlID="txtValorHastaFec" WatermarkText="__/__/____">
                                                        </cc1:TextBoxWatermarkExtender>
                                                        <cc1:CalendarExtender ID="txtValorHastaFec_CalendarExtender" runat="server" Format="dd/MM/yyyy" PopupButtonID="imgPopupHasta" TargetControlID="txtValorHastaFec">
                                                        </cc1:CalendarExtender>
                                                        <asp:ImageButton ID="imgPopupHasta" runat="server" Height="16px" ImageAlign="Bottom" ImageUrl="../Imagenes/pequeños/CalendarC_16x16.png" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;</td>
                                                    <td width="50">&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                            </table>
                                        </asp:View>
                                        <asp:View ID="vCTalog" runat="server">
                                            <table style="width: 100%;">
                                                <tr>
                                                    <td align="center">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td align="center">
                                                        <asp:Label ID="Label2" runat="server" Text="Valor:"></asp:Label>
                                                        <asp:TextBox ID="txtValorCTalog" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvValorCTalog" runat="server" ControlToValidate="txtValorCTalog" ErrorMessage="*"></asp:RequiredFieldValidator>
                                                        <asp:RangeValidator ID="ravCTalog" runat="server" ControlToValidate="txtValorCTalog" ErrorMessage="Fuera de rango" MaximumValue="2147483647" MinimumValue="1" Type="Integer"></asp:RangeValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center">&nbsp;</td>
                                                </tr>
                                            </table>
                                        </asp:View>
                                        <asp:View ID="vBoolean" runat="server">
                                            <table style="width: 100%;">
                                                <tr>
                                                    <td align="center">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td align="center">
                                                        <asp:Label ID="Label3" runat="server" Text="Valor:"></asp:Label>
                                                        <asp:CheckBox ID="chkValorBool" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center">&nbsp;</td>
                                                </tr>
                                            </table>
                                        </asp:View>
                                    </asp:MultiView>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>      
                </td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center" colspan="4" class="filaBtn">
                    <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="btnPrin" OnClick="btnNuevo_Click" CausesValidation="False"/>
                    <asp:Button ID="btnGrabar" runat="server" Text="Grabar" CssClass="btnPrin" OnClick="btnGrabar_Click" />
                    <cc1:ConfirmButtonExtender ID="btnGrabar_ConfirmButtonExtender" runat="server" TargetControlID="btnGrabar" ConfirmText="¿Esta seguro de guardar/modificar el registro?">
                    </cc1:ConfirmButtonExtender>
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btnPrin" Enabled="False" OnClick="btnEliminar_Click" />
                    <cc1:ConfirmButtonExtender ID="btnEliminar_ConfirmButtonExtender" runat="server" TargetControlID="btnEliminar" ConfirmText="¿Esta seguro de eliminar el registro?">
                    </cc1:ConfirmButtonExtender>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="4">&nbsp;</td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    <asp:GridView ID="gvRestricciones" runat="server" OnSelectedIndexChanged="gvRestricciones_SelectedIndexChanged" AllowPaging="True" OnPageIndexChanging="gvRestricciones_PageIndexChanging" AutoGenerateColumns="False" DataKeyNames="IdRestriccion" Width="1130px">
                        <Columns>
                            <asp:CommandField ButtonType="Image" HeaderText="Elegir" SelectImageUrl="~/imagenes/16siguiente.png" SelectText="Seleccionar" ShowHeader="True" ShowSelectButton="True" />
                            <asp:BoundField DataField="IdRestriccion" HeaderText="Restricción" />      
                            <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />      
                            <asp:BoundField DataField="IdConcepto" HeaderText="Concepto" />      
                            <asp:BoundField DataField="IdTipoDocumento" HeaderText="Tipo Documento" />      
                            <asp:BoundField DataField="Comentarios" HeaderText="Comentarios" />        
                            <asp:BoundField DataField="TipoRestriccion" HeaderText="Tipo Restricción" />                                  
                            <asp:CheckBoxField HeaderText="Negación" DataField="FlagNegacion"/>
                            <asp:BoundField DataField="TipoDato" HeaderText="TipoDato" />
                            <asp:BoundField DataField="Valor1" HeaderText="Valor1" />
                            <asp:BoundField DataField="Valor2" HeaderText="Valor2" />
                        </Columns>
                        <HeaderStyle CssClass="cssHeaderImg" />
                         <EmptyDataTemplate>
                                <div align="center" class="CajaDialogoAdvertencia">
                                    <br/>
                                    <img src="../Imagenes/warning.gif" 
                                        alt="No existen registros." />
                                    <br/> 
                                    Bandeja de Restricciones vacía.
                                    <br/>
                                    <br/>
                                </div>
                            </EmptyDataTemplate>
                    </asp:GridView>
                    <br />
                </td>
            </tr>
            <tr>
                <td align="center" colspan="4">&nbsp;</td>
            </tr>
        </table>
      </asp:Panel>
    </div>
</asp:Content>

