<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmListaTramitesParaEmision.aspx.cs" Inherits="CertificacionCC_wfrmListaTramitesParaEmision" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

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
        </script>  
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="FondoAplicacion">
        <table width="100%" border="0" cellpadding="false" cellspacing="false">
            <tr>
                <td width="30%">
                    <asp:Label ID="lblTituloSistema" runat="server" Font-Bold="True" ForeColor="Navy" Text="EMISION CC"></asp:Label>
                </td>
                <td width="70%" align="center">
                    <asp:Label ID="lblTitulo" runat="server" Font-Bold="True" ForeColor="#CC0000" Font-Size="17px" Text="Lista de Tramites en Emisión"></asp:Label>
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
            <td>
               
              
               
            </td>
        </tr>
        <tr>
            <td align="center">
                <br />
                <asp:Label ID="lblBuscarTramite" runat="server" Text="Buscar Tramite" Font-Bold="True"></asp:Label>
               
               
               
                &nbsp;<asp:TextBox ID="txtIdTramite" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
                <br />
               
               
               
                <br />
                <asp:Panel ID="pnlListaTramites" runat="server" >
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
                        DataKeyNames="IdTramite,IdGrupoBeneficio,FechaInicioTramite,NUP,IdEstadoCivil,CUA,Matricula,NumeroDocumento,PrimerNombre,SegundoNombre,PrimerApellido,SegundoApellido,NombreCompleto,FechaNacimiento,OficinaRegistro,Presidente,Vocal,Secretario" 
                        OnRowDataBound="gvDatos_RowDataBound"   OnRowCommand="gvDatos_RowCommand"                             
                      >
                          
                            <Columns>                                
                                <asp:BoundField DataField="IdTramite" HeaderText="IdTramite"  />
                                <asp:BoundField DataField="IdGrupoBeneficio" HeaderText="IdGrupoBeneficio"  />
                                <asp:BoundField DataField="NombreCompleto" HeaderText="Nombre Completo"  />
                                <asp:BoundField DataField="FechaInicioTramite" HeaderText="Inicio de Tramite"  />                                
                                <asp:BoundField DataField="NUP" HeaderText="NUP"  />
                                <asp:BoundField DataField="Matricula" HeaderText="Matricula"/>
                                <asp:BoundField DataField="NumeroDocumento" HeaderText="CI" />
                                <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha Nacimiento" />                               
                                <asp:TemplateField HeaderText="Presidente CCR">
                                    <ItemTemplate>
                                        <center>                                                                                
                                            <asp:Image ID="imgPresidente" runat="server"  ImageUrl="~/Imagenes/nueva3/aprobado32.png" Visible="false" ToolTip="Tramite evaluado por el Presidente"/>
                                             </center>
                                    </ItemTemplate>
                                </asp:TemplateField>      
                                 <asp:TemplateField HeaderText="Vocal CCR">
                                    <ItemTemplate>
                                        <center>                                                                                
                                            <asp:Image ID="imgVocal" runat="server" ImageUrl="~/Imagenes/nueva3/aprobado32.png" Visible="false" ToolTip="Tramite evaluado por el Vocal"/>
                                             </center>
                                    </ItemTemplate>
                                </asp:TemplateField> 
                                 <asp:TemplateField HeaderText="Secretario CCR">
                                    <ItemTemplate>
                                        <center>                                                                                
                                            <asp:Image ID="imgSecretario" runat="server" ImageUrl="~/Imagenes/nueva3/aprobado32.png" Visible="false" ToolTip="Tramite evaluado por el Secretario"/>
                                             </center>
                                    </ItemTemplate>
                                </asp:TemplateField>                                                                    
                                <asp:TemplateField HeaderText="Seleccionar...">
                                    <ItemTemplate>
                                        <center>                                                                                
                                        <asp:ImageButton ID="btnAprobar" runat="server" CausesValidation="false" CommandArgument='<%#((GridViewRow)Container).RowIndex %>' CommandName="cmdAprobar" ImageUrl="~/imagenes/nueva3/siguiente32.png"  ToolTip="Seleccionar Tramite"/>
                                        
                                        
                                             </center>
                                    </ItemTemplate>
                                </asp:TemplateField>
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
                        </asp:GridView>
                </asp:Panel>
                <br />
                <br />
               
                <br />
             
               
            </td>
        </tr>

    </table>
</asp:Content>

