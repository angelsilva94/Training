app.controller("indexCtrl", function ($scope, $uibModal, $cookieStore, $http) {
    //console.log("HOLA");

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