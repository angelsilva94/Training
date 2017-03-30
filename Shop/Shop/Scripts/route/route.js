/// <reference path="../angular.min.js" />
var app = angular.module("shopModule", ["ngRoute"]);
app.config(function ($routeProvider) {
    $routeProvider
    .when("/", {
        templateUrl: "template/home.html"
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
    .when("/contact", {
        templateUrl: "template/test.html"
    });
});




