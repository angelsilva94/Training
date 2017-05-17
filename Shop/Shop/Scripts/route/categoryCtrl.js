/// <reference path="../angular.min.js" />

app.controller("categoryCtrl", function ($scope, shopFactory, $routeParams) {
    var categoryServer = shopFactory.ProductCategory.query({}).$promise.then(function (response) {
        $scope.category = response;
        //console.log(response);
    }, function (error) {
        console.log(error);
    });

    //console.log($routeParams);
    var ProductCategory = shopFactory.ProductCategoryShop.query({ id: $routeParams.categoryId }).$promise.then(function (response) {
        console.log(response);
        $scope.product = response;
    }, function (error) {
        console.log("hola");
        console.log(error);
        $routeParams = "";
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
        var avg = (total / ReviewProducts.length) * 20;

        return avg + "%";
    };
});