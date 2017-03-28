/// <reference path="../angular.min.js" />

var app = angular.module("loginTest", [])
app.controller("loginCtrl", function ($scope, $http) {
    $scope.sendServer = function () {
        var jsonServer = {
            "name": $scope.username,
            "pwd": $scope.password
        };
        $http.post("http://localhost:58495/authentication/login", jsonServer)
             .then(function (response) {
                 console.log(response);
             });
    }


});







//var loginCtrl = function ($scope, $http) {
//    var jsonServer = {
//        user: $scope.username,
//        pwd: $scope.password
//    };
//    $scope.submitServer = function ($http) {
//        $http.post("http://localhost:58495/authentication/login", jsonServer)
//         .then(function (response) {
//             console.log(response)
//         });
//    }
//}
//app.controller("loginCtrl", loginCtrl);