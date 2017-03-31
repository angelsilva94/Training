app.factory("shopFactory", function ($resource) {
    return $resource("http://localhost:58495/users/api/User/:id", { user: "@id" });

});
$scope.test = function () {
    shopFactory.query();
};