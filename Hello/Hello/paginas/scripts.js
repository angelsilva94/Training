var app = angular.module('threeN', []);
app.controller('mainController', function ($scope, $http) {

  $scope.numbSubmit = function () {

    $http.get("http://localhost:56493/api/ThreeN", {
        params: {
          x: $scope.numberx,
          y: $scope.numbery
        }
      })
      .then(function (data) {
        $scope.details = data;
        $scope.data=data;
        $scope.tableR= true;
      }, function (response) {
        //$scope.myWelcome = response.statusText;
        $scope.details = response;
      });

  }
  $scope.myTxt = "You have not yet clicked submit";
  $scope.myFunc = function () {
    $scope.myTxt = "You clicked submit!";
  }

});