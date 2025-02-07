﻿/// <reference path="../angular.min.js" />
var app = angular.module("shopModule", ["ngRoute", "ngResource", "ui.bootstrap", "ngAnimate", "ngCart", "Authentication", "ngCookies","xeditable"]);
angular.module('Authentication', []);
app.config(function ($routeProvider) {
    $routeProvider
        .when("/", {
            templateUrl: "template/home.html",
            controller: "homeCtrl"
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
        .when("/search/:criteria", {
            templateUrl: "template/search.html",
            controller: "indexCtrl"
        })
        .when("/category/:categoryId", {
            templateUrl: "template/category.html",
            controller: "categoryCtrl"
        })
        .when("/checkout", {
            templateUrl: "template/cartFinal.html"
        })
        .when("/user", {
            templateUrl: "template/userPage.html",
            controller: "userCtrl"
        })
        //.when("/admin", {
        //    templateUrl: "Tests/admin/index.html"
        //})
    
        //.when("/contact", {
        //    templateUrl: "template/test.html"
        //})
        .otherwise({
            templateUrl: "template/404.html"
        });
});

app.run(['$rootScope', '$location', '$cookieStore', '$http',
    function ($rootScope, $location, $cookieStore, $http) {
        // keep user logged in after page refresh
        $rootScope.globals = $cookieStore.get('globals') || {};
        if ($rootScope.globals.currentUser) {
            $http.defaults.headers.common['Authorization'] = 'Basic ' + $rootScope.globals.currentUser.authdata; // jshint ignore:line
        }

        $rootScope.$on('$locationChangeStart', function (event, next, current) {
            // redirect to login page if not logged in
            if ($location.path() !== '/login' && !$rootScope.globals.currentUser) {
                $location.path('/signup');
            }
        });
    }]);

app.factory("shopFactory", function ($resource) {
    return {
        User: $resource("http://localhost:58495/users/:id", { id: "@id" }),
        Category: $resource("http://localhost:58495/category/:id", { id: "@id" }),
        Product: $resource("http://localhost:58495/products/?_page=:from&_perPage=:to", { from: "@from", to: "@to" }),
        ProductDetail: $resource("http://localhost:58495/products/:id", { id: "@id" }),
        Test: $resource("https://jsonplaceholder.typicode.com/users/:id", { id: "@id" }),
        ProductCategory: $resource("http://localhost:58495/productCategory/:id", { id: "@id" }),
        ProductCategoryShop: $resource("http://localhost:58495/productCategory/shop/:id", { id: "@id" }),
        ProductSearch: $resource("http://localhost:58495/products/search/?criteria=:criteria", { criteria: "@criteria" }),
        Review: $resource("http://localhost:58495/reviewProducts/", {}),
        OrderUser: $resource("http://localhost:58495/orders/users/:id", { id: "@id" }),
        ReviewsUser: $resource("http://localhost:58495/reviewProducts/user/:id", { id: "@id" }),
        UpdateReview: $resource("http://localhost:58495/reviewProducts/:id", { id: "@id" }, { update: { method: "PUT" } }),
        UserPersonalInfo:$resource("http://localhost:58495/users/info/:id", { id: "@id" }, { update: { method: "PUT" } })
    };
});