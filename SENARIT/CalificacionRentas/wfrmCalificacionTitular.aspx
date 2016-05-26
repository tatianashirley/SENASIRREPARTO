<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="wfrmCalificacionTitular.aspx.cs" Inherits="CalificacionRentas_wfrmCalificacionTitular" %>
<%@ MasterType VirtualPath="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            height: 26px;
        }
    </style>
    </asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
    <!-- bootstrap framework -->
    <link rel="stylesheet" href="../App_Themes/js/senasirReparto/bower/bootstrap/dist/css/bootstrap.css" /> 
    <script src="../App_Themes/js/senasirReparto/bower/bootstrap/dist/js/bootstrap.min.js"></script>
    <script src="../App_Themes/js/senasirReparto/bower/jquery/dist/jquery.min.js"></script>

    <!-- jquery easy  -->
     <link rel="stylesheet" type="text/css" href="../App_Themes/js/senasirReparto/bower/jquery-easyui-Reparto/themes/default/easyui.css">    
     <link rel="stylesheet" type="text/css" href="../App_Themes/js/senasirReparto/bower/jquery-easyui-Reparto/themes/icon.css">
     <script type="text/javascript" src="../App_Themes/js/senasirReparto/bower/jquery-easyui-Reparto/jquery.min.js"></script>
     <script type="text/javascript" src="../App_Themes/js/senasirReparto/bower/jquery-easyui-Reparto/jquery.easyui.min.js"></script>

    <!-- files-shared -->
    <script src="../App_Themes/js/senasirReparto/bower/angular/angular.min.js"></script>
    
    <script src="../App_Themes/js/senasirReparto/app.js"></script>
    <script src="../App_Themes/js/senasirReparto/shared/directives/usefulFactory.js"></script>
    
    <!-- files-custom -->
    <link rel="stylesheet" type="text/css" href="../App_Themes/js/senasirReparto/shared/css/custom01.css">

    <script src="../App_Themes/js/senasirReparto/modules/Calificacion/Titular/controller/rootController.js"></script>
    <script src="../App_Themes/js/senasirReparto/modules/Calificacion/Titular/controller/liquidacionController.js"></script>
    <script src="../App_Themes/js/senasirReparto/modules/Calificacion/Titular/controller/beneficiarioController.js"></script>
    


    <div ng-app="senasir">
        <div ng-controller="rootController" class="container">
            <%--<button type="button" ng-click="tooglePanel('child_c2');">mostrar vista 222</button>
            <button type="button" ng-click="tooglePanel('child_c1');">mostrar vista 111</button>--%>

            <!-- child-01-controller --> 
            <div ng-show="showPanel.child_c1" ng-include="'../App_Themes/js/senasirReparto/modules/DH/views/beneficiario-view.html'"></div>

            <!-- child-02-controller --> 
            <div ng-show="showPanel.child_c2" ng-include="'../App_Themes/js/senasirReparto/modules/DH/views/liquidacion-view.html'"></div>

        </div>
     </div>

</asp:Content>
c

