/// <reference path="../angular.min.js" />

//var app = angular.module("shopModule", [])
app.controller("loginCtrl", function ($scope, $http, $location, $rootScope, AuthenticationService) {
    AuthenticationService.ClearCredentials();
    $scope.sendServer = function () {
        $scope.dataLoading = true;

        AuthenticationService.Login($scope.username, $scope.password, function (response) {
            if (response.success) {
                AuthenticationService.SetCredentials($scope.username, $scope.password, $rootScope.userId, $rootScope.realName, $rootScope.regDate);
                $rootScope.logout = true;
                $rootScope.login = true;
                $location.path('/');
            } else {
                $scope.dataLoading = false;
                console.log("error");
                console.log(response);
            }
        });

        //var jsonServer = {
        //    "name": $scope.username,
        //    "pwd": $scope.password
        //};
        //$http.post("http://localhost:58495/authentication/login", jsonServer)
        //     .then(function (response) {
        //         //console.log(data);
        //         $scope.responseServer = response.statusText;
        //         $location.path("/");
        //     }, function (response) {
        //         //console.log(response);
        //         $scope.responseServer = response.statusText;

        //     });
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