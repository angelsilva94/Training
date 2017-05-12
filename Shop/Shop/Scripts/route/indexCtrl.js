app.controller("indexCtrl", function ($scope, $uibModal, $cookieStore, $http, shopFactory) {
    //console.log("HOLA");
    $scope.isNavCollapsed = true;
    $scope.search = function () {
        var searchServer = shopFactory.ProductSearch.query({ criteria: $scope.criteria },
        function success(value, headers) {
            console.log(value);
            console.log("SEARCH SUCCESS");
        },
        function error(error) {
            console.log("ERROR SEARCH");
            console.log(error);
        }
    );
        console.log($scope.criteria);
    };
    $scope.showCart = function () {
        console.log("-------------------carrito Index--------------------");
        var modal = $uibModal.open({
            animation: true,
            templateUrl: "template/cartMio.html",
            //template: "<h1>hola</h1>",
            backdrop: true,
            controller: "productCtrl"
        });
    };
    $scope.debug = function () {
        var cookie = $cookieStore.get('globals') || {};
        $http.get("http://localhost:58495/orders/").then(function (response) {
            console.log(response);
        });
        console.log(cookie);
    };
});

//app.controller("modalCtrl", function ($scope) {
//    console.log("dentro del controller");
//    $scope.test = "afadfadfs";
//});