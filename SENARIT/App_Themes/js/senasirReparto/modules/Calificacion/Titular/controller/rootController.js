'use strict';
angular.module('senasir')
    .controller("rootController", function ($scope) {
        $scope.goBack = function () {
            $scope.$parent.tooglePanel("vista-principal");
        };

        $scope.showPanel = {
            child_c1: true,
            child_c2: false
        };
        $scope.tooglePanel = function (panelNameShow) {
            angular.forEach($scope.showPanel, function (value, key) {
                if (key === panelNameShow) {
                    $scope.showPanel[key] = true;
                }
                else {
                    $scope.showPanel[key] = false;
                }
            });
        };

    });