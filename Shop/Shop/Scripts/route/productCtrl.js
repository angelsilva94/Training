app.controller("productCtrl", function ($scope, shopFactory, $routeParams) {

    //var productDetailServer = shopFactory.ProductDetail.get({ id: 1 }, function () {
    //});

    //$scope.ejemplo = productDetailServer;
    //console.log(productDetailServer);
    console.log("hola");
    var hola = $routeParams.producId;
    console.log(hola);
    var test = shopFactory.ProductDetail.get({ id: $routeParams.producId }).$promise.then(function (response) {
        console.log(response);
        $scope.productUrl = response.productUrl;
        $scope.productName = response.productName;
        $scope.productDesc = response.productDesc;
        $scope.productPrice = response.productPrice;
        //console.log(response.ReviewProducts[0].ratingReview);
        $scope.ReviewProducts = response.ReviewProducts;
        $scope.totalReviews = response.ReviewProducts.length;
        $scope.averageRating = function () {
            var total = 0;
            var length = response.ReviewProducts.length;
            for (var i = 0; i< length; i++) {
                
                total += response.ReviewProducts[i].ratingReview;
            }
            var avg = total / length;
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
        $scope.reviewData = response.ReviewProducts;
    });
    //console.log(test);
    //console.log(test.email);
    var categoryServer = shopFactory.Category.query({}).$promise.then(function (response) {
        $scope.category = response;
        //console.log(response);
    }, function (error) {
        console.log(error);
    });


});