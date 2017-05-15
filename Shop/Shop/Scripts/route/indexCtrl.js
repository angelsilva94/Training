app.controller("indexCtrl", function ($scope, $uibModal, $cookieStore, $http, shopFactory, $location) {
    //console.log("HOLA");

    $scope.userPanel = function () {
        console.log("entraste al panel de usuario");
    }

    $scope.isNavCollapsed = true;
    $scope.search = function () {
        var searchServer = shopFactory.ProductSearch.query({ criteria: $scope.criteria },
        function success(value, headers) {
            $scope.product = value;
            console.log(value);
            console.log("SEARCH SUCCESS");
            $location.path("/search/" + $scope.criteria);
            $scope.bigTotalItems = headers("x-total-count");
            $scope.getAvg = function (ReviewProducts) {
                var total = 0;
                for (var i = 0; i < ReviewProducts.length; i++) {
                    total += ReviewProducts[i].ratingReview
                }
                var avg = total / ReviewProducts.length;
                $scope.rating = avg;
                return avg;
            };
            $scope.getStars = function (ReviewProducts) {
                var total = 0;
                for (var i = 0; i < ReviewProducts.length; i++) {
                    total += ReviewProducts[i].ratingReview
                }
                var avg = (total / ReviewProducts.length) * 20;

                return avg + "%";
            };
            $scope.criteria = "";
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