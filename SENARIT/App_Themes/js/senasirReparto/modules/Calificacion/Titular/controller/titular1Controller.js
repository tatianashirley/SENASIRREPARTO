'use strict';
angular.module('senasir')
    .controller('titular1Controller', function ($scope) {

    })
    .controller("gridBeneficiariosController", function ($scope, HttpRequest) {
        var instanceHttp = HttpRequest.PrototypeRequestHttp();

        $scope.doReloadGrid = function () {

            var primerNombre = $("#primerNombre").val();
            var jsonToSend = {
                "primerNombre": primerNombre
            };
            instanceHttp.shootRequest("wfrmCalificacionDH01.aspx/BuscarTramiteJSON", jsonToSend)
                        .then(function (response) {
                            $("#cc").combobox("loadData", response.data);
                        }, function (error) {
                        });
               
        };
       
        $('#cc').combobox({
            //url: 'combobox_data.json',
            valueField: 'NUP',
            textField: 'PrimerApellido'
        });


        $('#dg').datagrid({
            //url: 'datagrid_data.json',
            data: [],
            columns: [[
                { field: 'NUP', title: 'Code', width: 100 },
                { field: 'IdTipoDocumento', title: 'Name', width: 100 },
                { field: 'PrimerApellido', title: 'Price', width: 100, align: 'right' }
            ]]
        });
    });

