var app = angular.module('blocks', []);

app.controller('mainController', function ($scope, $window) {

  $scope.lenghtSubmit = function () {
    if ($scope.blockLength < 0 || $scope.blockLength > 25) {
      $window.alert("Check your number pls");
      $scope.blockLength = "";
    } else {
      $scope.lenghtPanel = true;
    }

  }
  $scope.moves = [];
  $scope.addMove = function () {
    $scope.moves.push($scope.addMe);
  }
  $scope.removeMove = function (x) {
    $scope.moves.splice(x, 1);
  }



});

/*
app.controller('mainController', function ($scope, $http) {

  $scope.numbSubmit = function () {

    $http.get("http://localhost:56493/api/ThreeN", {
        params: {
          x: $scope.numberx,
          y: $scope.numbery
        }
      })
      .then(function (data) {

        $scope.details = data.status;
        $scope.data = data;
        $scope.tableR = true;
        $scope.alertSuccess = true;
        $scope.saludo = data;


      }, function (response) {
        //$scope.myWelcome = response.statusText;
        //$scope.details = response;
        $scope.tableR = false;
        $scope.error = response.data;
        $scope.alertM = true;

      });


  }
  $scope.myTxt = "You have not yet clicked submit";
  $scope.myFunc = function () {
    $scope.myTxt = "You clicked submit!";
  }


});*/