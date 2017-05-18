app.controller("userCtrl", function ($scope, shopFactory, $rootScope) {
    console.log("User Controller");
    $scope.home=function(){
        console.log("Home");
        shopFactory.OrderUser.query({ id: $rootScope.globals.currentUser.userId }).$promise.then(function (response) {
            console.log("llamada orders");
            console.log(response);
            $scope.userOrder = response;
            var user = response;
            console.log(user);
        }, function (error) {
            console.log(error);
        });
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
    };
});