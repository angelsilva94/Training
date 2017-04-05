/// <reference path="../angular.min.js" />
var app = angular.module("shopModule", ["ngRoute", "ngResource", "ui.bootstrap"]);
app.config(function ($routeProvider) {
    $routeProvider
    .when("/", {
        templateUrl: "template/home.html",
        controller : "homeCtrl"
    })
    .when("/login", {
        templateUrl: "template/login.html",
        controller: "loginCtrl"
    })
    .when("/signup", {
        templateUrl: "template/signup.html",
        controller: "registerCtrl"
    })
    .when("/product", {
        templateUrl: "template/shopItem.html"
    })
    //.when("/contact", {
    //    templateUrl: "template/test.html"
    //})
    .otherwise({
        templateUrl: "template/404.html"
    });
});

app.factory("shopFactory", function ($resource) {
    return {
        User: $resource("http://localhost:58495/users/api/User/?id=:id", { id: "@id" }),
        Category: $resource("http://localhost:58495/category/api/categories"),
        Product: $resource("http://localhost:58495/products/api/Products?from=:from&to=:to",{from:"@from",to:"@to"})
    };

});



