angular.module("problems", []).controller("controller", function ($scope) {
    $scope.nombre = "angel";
    $scope.apellido = "asdfdf";
    $scope.textoLargo = function(){
        return $scope.nombre+" "+$scope.apellido;
    };





});