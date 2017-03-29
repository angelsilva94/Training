/// <reference path="../angular.min.js" />

//var app = angular.module("shopModule", [])
app.controller("loginCtrl", function ($scope, $http) {
    $scope.sendServer = function () {
        var jsonServer = {
            "name": $scope.username,
            "pwd": $scope.password
        };
        $http.post("http://localhost:58495/authentication/login", jsonServer)
             .then(function (response) {
                 //console.log(data);
                 $scope.responseServer = response.statusText;
             }, function (response) {
                 //console.log(response);
                 $scope.responseServer = response.statusText;
                 
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