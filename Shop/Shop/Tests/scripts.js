var app = angular.module("app", ["ngRoute"]);
app.config(function ($routeProvider) {
    $routeProvider
    .when("/", {
        templateUrl: "home.html"
    })
    .when("/hi", {
        templateUrl: "hi.html"
    })
    .when("/bye", {
        templateUrl: "bye.html"
    });
});