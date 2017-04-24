app.controller("indexCtrl", function ($scope, $uibModal, $cookieStore) {
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
        
        console.log(cookie);
    };

});


//app.controller("modalCtrl", function ($scope) {
//    console.log("dentro del controller");
//    $scope.test = "afadfadfs";
//});