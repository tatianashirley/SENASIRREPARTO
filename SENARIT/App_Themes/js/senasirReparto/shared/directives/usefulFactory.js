'use strict';
angular.module("senasir").factory("HttpRequest", function ($q) {

    var PrototypeRequestHttp = function () {

        var getIdConexion = function () {
            return 
        };
            
            var shootRequest = function (UrlSuffix, ObjectToSend) {
                var deferred = $q.defer();
                var ObjectToSendFinal = angular.isUndefined(ObjectToSend) || ObjectToSend === null ? {} : ObjectToSend;
                
                var objectJsonOnString = JSON.stringify(ObjectToSendFinal);
                $.ajax({
                    type: "POST",
                    //url: "wfrmCalificacionDH01.aspx/BuscarTramiteJSON",
                    url: UrlSuffix,
                    data: objectJsonOnString,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        var arrayJsonResult = JSON.parse(response.d);
                        deferred.resolve({data: arrayJsonResult});
                        //return deferred.promise;
                    },
                    error: function (errorJq, errorStatus,erroThrow) {
                        deferred.reject(errorJq.responseText);
                        //return deferred.promise;
                    }
                });
                return deferred.promise;
                
            };
            

            return {
                shootRequest: shootRequest
            };
        };

        return {
            PrototypeRequestHttp: PrototypeRequestHttp
        };
    });
