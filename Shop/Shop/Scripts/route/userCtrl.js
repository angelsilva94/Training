app.controller("userCtrl", function ($scope, shopFactory, $rootScope) {
    console.log("User Controller");
    $scope.home = function () {
        console.log("Home");

        shopFactory.OrderUser.query({ id: $rootScope.globals.currentUser.userId }, function success(response, headers) {
            console.log("HEADERS-----------------------");
            console.log(headers());
            $scope.timesPurchase = headers("x-total-orders");
            $scope.totalReviews = headers("x-total-reviews");
            $scope.userOrder = response;
            var user = response;
            console.log(user);
            $scope.orderStatus = function (statusCode) {
                console.log("entre ala funcion");
                switch (statusCode) {
                    case 1:
                        return "success";
                        break;
                    case 2:
                        return "warning";
                        break;
                    case 3:
                        return "danger";
                        break;
                    default:
                        return "info";
                        break;
                }

            }
        }, function (error) {
            console.log(error);
        });
        

    };//home function
    $scope.reviews = function () {
        $scope.isCollapsed = true;
        console.log("---Reviews---")
        shopFactory.ReviewsUser.query({ id: $rootScope.globals.currentUser.userId }, function success(response, headers) {
            console.log("RESPONSE SERVER REVIEW------------");
            console.log(response);
            $scope.userReviews = response;
            
        }, function (error) {
            console.log(error);
        });
        $scope.viewReview = function (ReviewProductIdNumber, reviewDesc) {
            console.log("VIEW REVIEW----");
            $scope.reviewDesc = reviewDesc;
            $scope.hoveringOver = function (value) {
                $scope.overStar = value;
                $scope.percent = 100 * (value / $scope.max);
            };
            console.log("calif------------------");
            var aux = $scope.rate;
            console.log(aux);


            $scope.sendReview = function () {
                console.log("sendReview");
                //shopFactory.Review.save({
                //    "ProductId": $scope.productId,
                //    "ratingReview": $scope.rate,
                //    "UserId": $rootScope.globals.currentUser.userId,
                //    "reviewDesc": $scope.reviewDesc
                //}, function succes(value) {
                //    console.log("respuesta es:")
                //    console.log(value);
                //    $route.reload();
                //}, function error(error) {
                //    console.log("ERROR");
                //    console.log(error);
                //});
            };
        }

    };//review function
            
    
});