/// <reference path="../angular.min.js" />
var app = angular.module("shopModule", ["ngRoute", "ngResource", "ngCookies"]);
app.config(function ($routeProvider) {
    $routeProvider
    .when("/", {
        templateUrl: "template/signup.html",
        controller: "registerCtrl"
    })
    .when("/login", {
        templateUrl: "template/login.html"
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




