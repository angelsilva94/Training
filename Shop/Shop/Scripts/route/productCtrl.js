app.controller("productCtrl", function ($scope, shopFactory, $routeParams, ngCart, $rootScope,$route) {
    //var productDetailServer = shopFactory.ProductDetail.get({ id: 1 }, function () {
    //});

    //$scope.ejemplo = productDetailServer;
    //console.log(productDetailServer);
    console.log("hola Product");
    var hola = $routeParams.producId;
    console.log(hola);
    var test = shopFactory.ProductDetail.get({ id: $routeParams.producId }).$promise.then(function (response) {
        console.log(response);
        $scope.productUrl = response.productUrl;
        $scope.productName = response.productName;
        $scope.productDesc = response.productDesc;
        $scope.productPrice = response.productPrice;
        $scope.productId = response.ProductId;
        //console.log(response.ReviewProducts[0].ratingReview);
        $scope.OrderDetails = response.OrderDetails;
        for (var i = 0; i < response.OrderDetails.length; i++) {
            if (response.OrderDetails[i].UserId == $rootScope.globals.currentUser.userId) {
                $scope.showReview = true;
                console.log("Si se puede review");
                break;
            }
            //console.log($rootScope.globals.currentUser.userId);
            console.log(response.OrderDetails[i].UserId);
        }
        $scope.ReviewProducts = response.ReviewProducts;
        $scope.totalReviews = response.ReviewProducts.length;
        $scope.averageRating = function () {
            var total = 0;
            var length = response.ReviewProducts.length;
            for (var i = 0; i < length; i++) {
                total += response.ReviewProducts[i].ratingReview;
            }
            var avg = total / length;
            return avg;
        };
        $scope.reviewData = response.ReviewProducts;
        $scope.getStars = function (ReviewProducts) {
            var total = 0;
            for (var i = 0; i < ReviewProducts.length; i++) {
                total += ReviewProducts[i].ratingReview
            }
            var avg = (total / ReviewProducts.length) * 20;
            return avg + "%";
        };
       
    });
    //console.log(test);
    //console.log(test.email);
    var categoryServer = shopFactory.Category.query({}).$promise.then(function (response) {
        $scope.category = response;
        //console.log(response);
    }, function (error) {
        console.log(error);
    });

    $scope.addToCart = function (productUrl, productName, productPrice) {
        console.log("boton añadir a carrito");
        ngCart.setTaxRate(7.5);

        //console.log(productUrl);
        //console.log(productName);
        //console.log(productPrice);
    };

    $scope.checkOutDetails = function () {
        console.log("PRODUCTDS");
        $uibModalInstance.close();
    };
    $scope.isCollapsed = true;
    $scope.max = 10;
    $scope.leaveReview = function () {
        console.log("Leave review");
        $scope.writingReview = true;
        $scope.isCollapsed = false;
        $scope.hoveringOver = function (value) {
            $scope.overStar = value;
            $scope.percent = 100 * (value / $scope.max);
        };
        $scope.sendReview = function () {
            console.log("sendReview");
            console.log("SCORE---------");
            console.log($scope.rate);
            ////console.log($scope.rate);
            ////console.log($scope.reviewDesc);
            //var jsonReview = {
            //    "ProductId": $scope.productId,
            //    "ratingReview": $scope.rate,
            //    "UserId": $rootScope.globals.currentUser.userId,
            //    "reviewDesc": $scope.reviewDesc
            //};
            //console.log(jsonReview);
            shopFactory.Review.save({
                "ProductId": $scope.productId,
                "ratingReview": $scope.rate,
                "UserId": $rootScope.globals.currentUser.userId,
                "reviewDesc": $scope.reviewDesc
            }, function succes (value) {
                console.log("respuesta es:")
                console.log(value);
                $route.reload();
            },function error(error) {
                console.log("ERROR");
                console.log(error);
            });
        };
    };
    $scope.show = true;

    $scope.closeAlert = function (index) {
        $scope.show = false;
    };
});