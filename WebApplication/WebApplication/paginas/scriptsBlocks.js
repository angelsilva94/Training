var app = angular.module('blocks', []);

app.controller('mainController', function ($scope, $window, $http) {

  $scope.lenghtSubmit = function () {
    if ($scope.blockLength < 0 || $scope.blockLength > 25) {
      $window.alert("Check your number pls");
      $scope.blockLength = "";
    } else {
      $scope.lenghtPanel = true;
      $scope.panelAsk = true;
    }

  }
  $scope.moves = [];
  $scope.userMoves = [];
  var serverMove = [];
  var serverA = [];
  var serverB = [];

  $scope.addMove = function () {
    $scope.userMoves.push($scope.addA + " " + $scope.addMov + " " + $scope.addB);
    $scope.tableMove = true;
    serverA.push($scope.addA);
    serverB.push($scope.addB);
    serverMove.push($scope.addMov);
  }
  $scope.removeMove = function (x) {
    $scope.userMoves.splice(x, 1);
    serverMove.splice(x, 1);
    serverA.splice(x, 1);
    serverB.splice(x, 1);

  }
  $scope.sendServer = function () {
    $scope.moves.push("end");
    $scope.panelAsk = false;
    $scope.panelIns = true;
    $scope.panelResults = true;


    var jsonS = {
      instructions: [],
      "leng": $scope.blockLength,
      "res": ""
    };
    for (var i = 0; i < serverA.length; i++) {
      jsonS.instructions.push({
        "A": serverA[i],
        "B": serverB[i],
        "move": serverMove[i]
      })
    }

    //$scope.enviar = jsonS;
    $http.post("http://localhost:56493/api/BlocksProblem", jsonS)
      .then(function (data) {
        $scope.result = data;
        $scope.data = data;
        $scope.tableR = true;
        $scope.alertSuccess = true;
      }, function (response) {
        $scope.result = response;
        $scope.alertM = true;
      });






  }



});