/// <reference path="../angular.min.js" />

app.controller("homeCtrl", function ($scope, shopFactory, $window) {
    //$scope.testFunc = function () {
    //    $scope.test = "hola";
    //};
    //$scope.user = shopfactory.query();
    //$scope.setData() = function () {
    //    $scope.userTest = shopFactory.get({ id : 1001 });
    //};
    var categoryServer = shopFactory.Category.query({}).$promise.then(function (response) {
        $scope.category = response;
        //console.log(response);
    }, function (error) {
        console.log("ENTRASTE AL ERROR DE CATEGORIA");
        console.log(error);
        //var i = 0;
        //while (error) {
        //    $window.location.reload();
        //    console.log(i);
        //    i++;
        //}
    });

    //var productServer = shopFactory.Product.query({ from: 0, to: 10 }).$promise.then(function (response) {
    //    $scope.product = response;
        
    //    console.log(headersGetter);
    //}, function (error) {
    //    console.log("ENTRASTE AL ERROR DE PRODUCTO");
    //    console.log(error);
    //    //$window.location.reload();
    //});


    var productServer = shopFactory.Product.query({ from: 1, to: 10 },
        function success(value, headers) {
            $scope.product = value;
            
            $scope.bigTotalItems = headers("x-total-count");
            //$scope.bigTotalItems = 1000;
            console.log(value);
            console.log(headers());
            console.log(headers("x-total-count"));
        },
        function error(error) {
            console.log("ERROR");
            console.log(error);
        }
    );

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
        var productServer = shopFactory.Product.query({ from: $scope.pages , to: 10 }).$promise.then(function (response) {
            $scope.product = response;
        });
    };
    //$scope.hoveringOver = function (value) {
    //    $scope.overStar = value;
    //    $scope.percent = 100 * (value / 10);
    //};
});