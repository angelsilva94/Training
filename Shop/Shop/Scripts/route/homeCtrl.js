/// <reference path="../angular.min.js" />

app.controller("homeCtrl", function ($scope,shopFactory) {
    //$scope.testFunc = function () {
    //    $scope.test = "hola";
    //};
    //$scope.user = shopfactory.query();
    //$scope.setData() = function () {
    //    $scope.userTest = shopFactory.get({ id : 1001 });
    //};
    var categoryServer = shopFactory.Category.query({}).$promise.then(function (response) {
        $scope.category = response;
    }, function (error) {
        console.log(error);
    });
    
    var productServer = shopFactory.Product.query({ from: 0, to: 10 }).$promise.then(function (response) {
        $scope.product = response;
    });
   
    
    $scope.getAvg = function (ReviewProducts) {
        var total = 0;
        for (var i = 0; i < ReviewProducts.length; i++) {
            total += ReviewProducts[i].ratingReview
        }
        var avg = total / ReviewProducts.length;
        $scope.rating = avg;
        return avg;
        
    };
    $scope.getStars = function (ReviewProducts) {
        var total = 0;
        for (var i = 0; i < ReviewProducts.length; i++) {
            total += ReviewProducts[i].ratingReview
        }
        var avg = (total / ReviewProducts.length)*20;
        
        return avg+"%";

    };
    



    //$scope.setData = function () {
    //    //$scope.category = categoryServer[1].categoryName;
    //    angular.forEach(categoryServer, function (value,key) {
    //        //console.log(key + ":" + value);
    //        //console.log(value.categoryName);
    //        console.log(categoryServer)
    //    });
    //};

    $scope.changePage = function () {
        console.log("hola");
        console.log($scope.pages);
        var productServer = shopFactory.Product.query({ from: $scope.pages - 1, to: 10 }).$promise.then(function () {
            $scope.product = productServer;
        });
        
    };
    //$scope.hoveringOver = function (value) {
    //    $scope.overStar = value;
    //    $scope.percent = 100 * (value / 10);
    //};
});