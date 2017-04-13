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
    .when("/product/:producId", {
        templateUrl: "template/shopItem.html",
        controller: "productCtrl"
    })
    .when("/category/:categoryId", {
        templateUrl: "template/category.html",
        controller : "categoryCtrl"
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
        Category: $resource("http://localhost:58495/category/api/categories:id", {id:"@id"}),
        Product: $resource("http://localhost:58495/products/api/Products?from=:from&to=:to", { from: "@from", to: "@to" }),
        ProductDetail: $resource("http://localhost:58495/products/api/Products?id=:id", { id: "@id" }),
        Test: $resource("https://jsonplaceholder.typicode.com/users/:id", { id: "@id" }),
        ProductCategory: $resource("http://localhost:58495/productCategories/api/productCategory?id=:id", { id: "@id" })
    };

});



