
var app = angular.module("root", ["services"]);
app.config(["messageProvider", function (messageProvider) {
    messageProvider.setText("hola world!");
}]);
app.controller("index", ["$scope","message", function ($scope, message) {
    $scope.product = message.text;
}]);
