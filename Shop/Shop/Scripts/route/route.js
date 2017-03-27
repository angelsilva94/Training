/// <reference path="../angular.min.js" />

var app = angular.module("shopModule", ["ngRoute"])
                 .config(function ($routeProvider) {
                     $routeProvider
                        .when("/home", {
                            templateUrl: "template/home.html",
                            controller: "homeController"
                        })
                        .when("/login", {
                            templateUrl: "template/login.html",
                            controller: "loginController"
                        })
                        .when("/signup", {
                            templateUrl: "template/signup.html",
                            controller: "signupController"
                        })



                 })
                 .controller("homeController", function ($scope) {

                 })
                 .controller("loginController", function ($scope) {

                 })
                 .controller("signupController", function ($scope) {

                 })



