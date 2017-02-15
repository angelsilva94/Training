var angularRoutingApp = angular.module('angularRoutingApp', ['ngRoute']);


angularRoutingApp.config(function ($routeProvider) {

    $routeProvider
        .when('/', {
            templateUrl: 'paginas/welcome.html',
            controller: 'mainController'
        })
        .when('/threen', {
            templateUrl: 'paginas/threen.html',
            controller: 'threenController'
        })
        .when('/bin', {
            templateUrl: 'paginas/bin.html',
            controller: 'binController'
        })
        .when('/blocks', {
            templateUrl: 'paginas/blocks.html',
            controller: 'blocksController'
        })
        .otherwise({
            redirectTo: '/'
        });
});

angularRoutingApp.controller('mainController', function ($scope) {
    //    $scope.message = 'Hola, Mundo!';
});

angularRoutingApp.controller('threenController', function ($scope) {
    //  $scope.message = 'Esta es la página "threenController"';
});

angularRoutingApp.controller('binController', function ($scope) {
    //$scope.message = 'Esta es la página de "binController", aquí podemos poner un formulario';
});
angularRoutingApp.controller('blocksController', function ($scope) {
    //$scope.message = 'Esta es la página de "blocksController", aquí podemos poner un formulario';
});