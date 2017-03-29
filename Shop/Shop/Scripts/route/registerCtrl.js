/// <reference path="../angular.min.js" />
app.controller("registerCtrl", function ($scope, $http) {

   
    $scope.registerUser = function () {
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
            "regDate": filter('date')(new Date(),'yyyy-MM-dd HH:mm:ss Z')
        };
        $scope.json = jsonServer;

        $http.post("http://localhost:58495/users/api/User", jsonServer)
             .then(function (response) {
                 //console.log(data);
                 console.log(response);
                 $scope.responseServer = response.statusText;
             }, function (response) {
                 //console.log(response);
                 $scope.responseServer = response.statusText;

             });
    }

});