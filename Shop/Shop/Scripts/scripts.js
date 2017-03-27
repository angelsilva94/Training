// <reference path="angular.min.js" />

//Create module
var myApp = angular.module("myModule", []);

// Register controller with the module
myApp.controller("myController", function ($scope) {
    var tec = [
        { name: "c#", like: 0, dislike: 0 },
        { name: "java", like: 0, dislike: 0 },
        { name: "scala", like: 0, dislike: 0 },
        { name: "c", like: 0, dislike: 0 },
    ];
    $scope.tec = tec;
    $scope.inLikes = function (technology) {
        technology.like++;
    };
    $scope.inDislikes = function (technology) {
        technology.dislike++;
    };
});
