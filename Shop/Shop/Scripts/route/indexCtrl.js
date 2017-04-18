app.controller("indexCtrl", function ($scope, $uibModal) {
    //console.log("HOLA");
    
    $scope.showCart = function () {
        console.log("-------------------carrito Index--------------------");
        var modal = $uibModal.open({
            animation: true,
            templateUrl: "template/cart.html",
            //template: "<h1>hola</h1>",
            backdrop: true,
            controller: "productCtrl"

        });
    };

});


//app.controller("modalCtrl", function ($scope) {
//    console.log("dentro del controller");
//    $scope.test = "afadfadfs";
//});