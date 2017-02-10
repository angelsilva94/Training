angular.module("test", []).controller("controller", function ($scope) {
    $scope.nombre = "angel";
    $scope.apellido = "asdfdf";
    $scope.textoLargo = function(){
        return $scope.nombre+" "+$scope.apellido;
    };





    /*
    "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut laoreet, nibh quis dapibus eleifend, mi libero sodales lacus,et pulvinar neque turpis ut justo.In euismod justo quis arcu efficitur, ac tempus erat ullamcorper.Quisque ac nulla est.Praesent tincidunt arcu eget erat blandit convallis.Phasellus malesuada iaculis magna, nec pretium ligula feugiat id.Aenean eget dolor congue, vulputate risus vel, iaculis odio.Phasellus lorem purus, luctus commodo porta ac, sodales vitae turpis.Nam in bibendum nibh.Nulla vel fermentum nulla.Nulla mollis tellus id maximus tempor.Praesent vitae dolor ut nibh porta sodales.Sed at ante a mauris ultrices molestie.Maecenas lacus lectus, molestie ut sodales a, interdum sit amet ipsum."
    */
});