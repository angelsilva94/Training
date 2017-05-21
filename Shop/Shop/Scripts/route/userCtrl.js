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
        });//close factory
        

    };//home function
    $scope.reviews = function () {
        $scope.isCollapsed = true;
        $scope.max = 10;
        console.log("---Reviews---")
        shopFactory.ReviewsUser.query({ id: $rootScope.globals.currentUser.userId }, function success(response, headers) {
            console.log("RESPONSE SERVER REVIEW------------");
            console.log(response);
            $scope.userReviews = response;
            
        }, function (error) {
            console.log(error);
        });
        $scope.viewReview = function (ReviewProductIdNumber, reviewDesc, rate, reviewDescUpdated, productId) {
            console.log("VIEW REVIEW----");
            $scope.reviewDesc = reviewDesc;
            //$scope.rate = ratingReview;



            $scope.hoveringOver = function (value) {
                $scope.overStar = value;
                $scope.percent = 100 * (value / $scope.max);
            };
            console.log("calif------------------");
            console.log(rate);


            $scope.sendReview = function () {
                console.log("SEND REVIEW");

                console.log(rate);
                if (rate != 0 && rate !=null) {
                    console.log("Si es valido");
                    console.log(rate);
                    console.log(reviewDescUpdated);
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

                    shopFactory.UpdateReview.update({ id: ReviewProductIdNumber }, {
                        "ReviewProductIdNumber": ReviewProductIdNumber,
                        "ProductId": productId,
                        "ratingReview": rate,
                        "UserId": $rootScope.globals.currentUser.userId,
                        "reviewDesc": reviewDescUpdated
                    },
                    function success(value) {
                        console.log(value);
                    },
                    function error(error) {
                        console.log(error);
                    });


                } else {
                    console.log("introduce una calificacion valida, Gracias");
                }
                
            };
        }

    };//review function

    $scope.profile = function () {
        $scope.user = {
            name: "",
            surname: "",
            lastname: "",
            email: "",
        }; 


        shopFactory.User.get({ id: $rootScope.globals.currentUser.userId }, function success(response, headers) {
            console.log("RESPONSE SERVER REVIEW------------");
            console.log($rootScope.globals.currentUser.realName);
            $scope.user.name = response.name;
            $scope.user.surname = response.surname;
            $scope.user.lastname = response.lastName;
            $scope.user.email = response.email;
            
        }, function (error) {
            console.log(error);
        });


        $scope.saveUser = function () {
            //// $scope.user already updated!
            //return $http.post('/saveUser', $scope.user).error(function (err) {
            //    if (err.field && err.msg) {
            //        // err like {field: "name", msg: "Server-side error for this username!"} 
            //        $scope.editableForm.$setError(err.field, err.msg);
            //    } else {
            //        // unknown error
            //        $scope.editableForm.$setError('name', 'Unknown error!');
            //    }
            //});
            console.log("ANTES DE ENVIAR------");
            console.log($scope.user);
            var user = $scope.user;
            //lastName

            shopFactory.UserPersonalInfo.update({ id: $rootScope.globals.currentUser.userId },
                {
                    "name": $scope.user.name,
                    "surname": $scope.user.surname,
                    "lastName": $scope.user.lastname,
                    "email": $scope.user.email,
                },
                function success(value) {
                    console.log(value);
                    $rootScope.globals.currentUser.realName = "";
                },
                function error(error) {
                    console.log(error);
                });
        };

    }//cierre profile
    
});