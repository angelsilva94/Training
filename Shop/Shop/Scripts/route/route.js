/// <reference path="../angular.min.js" />
var app = angular.module("shopModule", ["ngRoute", "ngResource", "ui.bootstrap", "ngAnimate", "ngCart", "Authentication", "ngCookies"]);
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
        .when("/category/:categoryId", {
            templateUrl: "template/category.html",
            controller: "categoryCtrl"
        }).
        when("/checkout", {
            templateUrl: "template/cartFinal.html"
        })
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
        User: $resource("http://localhost:58495/users/api/User/?id=:id", { id: "@id" }),
        Category: $resource("http://localhost:58495/category/:id", { id: "@id" }),
        Product: $resource("http://localhost:58495/products/?_page=:from&_perPage=:to", { from: "@from", to: "@to" }),
        ProductDetail: $resource("http://localhost:58495/products/:id", { id: "@id" }),
        Test: $resource("https://jsonplaceholder.typicode.com/users/:id", { id: "@id" }),
        ProductCategory: $resource("http://localhost:58495/productCategory/:id", { id: "@id" })
    };
});