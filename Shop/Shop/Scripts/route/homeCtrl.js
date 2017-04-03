/// <reference path="../angular.min.js" />
app.controller("homeCtrl", function ($scope, $http, shopFactory) {
    //$scope.testFunc = function () {
    //    $scope.test = "hola";
    //};
    //$scope.user = shopfactory.query();
    //$scope.setData() = function () {
    //    $scope.userTest = shopFactory.get({ id : 1001 });
    //};
    var categoryServer = shopFactory.Category.query({}, function () {
        //console.log(categoryServer[1].categoryName);
        //console.log(categoryServer);
    });
    $scope.category = categoryServer;
    $scope.setData = function () {
        //$scope.category = categoryServer[1].categoryName;
        angular.forEach(categoryServer, function (value,key) {
            //console.log(key + ":" + value);
            //console.log(value.categoryName);
            console.log(categoryServer)
        });
    };
});