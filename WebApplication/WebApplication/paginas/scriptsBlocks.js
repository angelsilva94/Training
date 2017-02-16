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
  }
  $scope.sendServer = function () {
    $scope.moves.push("end");
    $scope.panelAsk = false;
    $scope.panelIns = true;
    $scope.panelResults = true;
    /*
    var objetoJson = {
      "instructions": [{
        "A": $scope.addA,
        "B": $scope.addB,
        "move": $scope.addMov
      }, {
        "A": $scope.addA,
        "B": $scope.addB,
        "move": $scope.addMov
      }],
      "length": $scope.blockLength,
      "res": null
    };*/
    var objetoJson = [];
    /*for (var i = 0; i < serverA.length; i++) {
      objetoJson[i] = {
        "instructions": [{
          "A": serverA[i],
          "B": serverB[i],
          "move": serverMove[i]
        }],
        "length": $scope.blockLength,
        "res": null
      };
    }*/
    Json = {
      "instructions": [{
        "A": $scope.addA,
        "B": $scope.addB,
        "move": $scope.addMov
      }, {
        "A": $scope.addA,
        "B": $scope.addB,
        "move": $scope.addMov
      }],
      "length": $scope.blockLength,
      "res": null
    };

    $http.post("http://localhost:56493/api/BlocksProblem", Json)
      .then(function (data) {
        $scope.result = data;
      }, function (response) {
        $scope.result = response;
      });



  }



});