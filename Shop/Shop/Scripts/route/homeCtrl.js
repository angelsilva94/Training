﻿/// <reference path="../angular.min.js" />
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
    var productServer = shopFactory.Product.query({}, function () {
        
        //angular.forEach(productServer, function (value, key) {
        //    console.log(key + ":" + value.ReviewProducts.reviewDesc);

        //});
        var longitud = productServer.length;
        
        for (var i = 0; i < longitud; i++) {
            var ratingSum = 0;
            var ratingAverage = 0;
            var reviewNumber = productServer[i].ReviewProducts.length;
            for (var j = 0; j <productServer[i].ReviewProducts.length; j++) {
                //console.log(productServer[i].ReviewProducts[j].reviewDesc);    
                //console.log(productServer[i].ReviewProducts[j].ratingReview);
                
                ratingSum += productServer[i].ReviewProducts[j].ratingReview;
            }
           
           ratingAverage = ratingSum / reviewNumber;
           $scope.reviewsNumber = ratingAverage;
           var x=0;

        }

        //for (var i = 0; i < productServer.length; i++) {
        //    for (var j = 0; j < productServer.ReviewProducts.length; j++) {
        //        console.log(productServer[i].ReviewProducts[j].reviewDesc);
        //    }
        //}
        //var a = performance.now();
        //for(var i=0;i<1000;i++){
        //    console.log("hola");
        //}
        //var b = performance.now();
        //console.log(b-a+" milliseconds");
    });
    $scope.product = productServer;
    //console.log(productServer);
    
    



    $scope.setData = function () {
        //$scope.category = categoryServer[1].categoryName;
        angular.forEach(categoryServer, function (value,key) {
            //console.log(key + ":" + value);
            //console.log(value.categoryName);
            console.log(categoryServer)
        });
    };
});