/// <reference path="../angular.min.js" />
var app = angular.module("shopModule", ["ngRoute", "ngResource", "ngCookies"]);
app.config(function ($routeProvider) {
    $routeProvider
    .when("/", {
        templateUrl: "template/login.html",
        controller: "loginCtrl"
    })
    .when("/login", {
        templateUrl: "template/login.html"
    })
    .when("/signup", {
        templateUrl: "template/signup.html"
    })
    .when("/contact", {
        templateUrl: "template/test.html"
    });
});


app.run(function ($rootScope, $location, $cookieStore, $http) {
    // keep user logged in after page refresh
    $rootScope.globals = $cookieStore.get('globals') || {};
    if ($rootScope.globals.currentUser) {
        $http.defaults.headers.common['Authorization'] = 'Basic ' + $rootScope.globals.currentUser.authdata;
    }

    $rootScope.$on('$locationChangeStart', function (event, next, current) {
        // redirect to login page if not logged in
        if ($location.path() !== '/login' && !$rootScope.globals.currentUser) {
            $location.path('/login');
        }
    });
});

