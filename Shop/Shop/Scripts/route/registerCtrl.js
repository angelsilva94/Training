/// <reference path="../angular.min.js" />
app.controller("registerCtrl", function ($scope, $http, $location) {

   
    $scope.registerUser = function () {
        var date = new Date();
        var jsonServer = {
            "username": $scope.username,
            "password": $scope.password,
            "name": $scope.name,
            "email": $scope.email,
            "surname": $scope.surname,
            "lastName": $scope.lastName,
            "age": 99,
            "regDate": $scope.regDate,
            "userMode": 0,
            "regDate": date.toISOString()
        };
        $scope.json = jsonServer;

        $http.post("http://localhost:58495/users/api/User", jsonServer)
             .then(function (response) {
                 //console.log(data);
                 console.log(response);
                 $scope.responseServer = response.statusText;
                 $location.path("/login");
             }, function (response) {
                 //console.log(response);
                 $scope.responseServer = response.statusText;

             });
    }

});