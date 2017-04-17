app.controller("indexCtrl", function ($scope, $uibModal) {
    console.log("HOLA");
    $scope.showCart = function () {
        console.log("adewntro");
    }
    $scope.showCart = function () {
        console.log("carrito");
        var modal = $uibModal.open({
            animation: true,
            templateUrl: "template/cart.html",
            backdrop: true,
            controller:"modalCtrl"

        });
    };

});


app.controller("modalCtrl", function ($scope) {
    console.log("dentro del controller");
    $scope.test = "afadfadfs";
});