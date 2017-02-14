/* para identificar id es con # para identificar clases es con .nombreClase
   con asterisco seleccionas todo(comodin)
   [href]
 */

/*$(document).ready(function () {
    $(".test").click(function () { 
        $(this).hide();
    });
});*/

//$(document).ready(function () {
    //alert("valor:"+$("#form-name").val());
    /*var name=$("#form-name").val();
    if(name!="angel"){
        alert("ESTA MAL EL NOMBRE");
    }
    else{
        alert("esta bien el nombre");
    }*/
   // $("#btn-ok").click(function () {
        /*$.getJSON("http://localhost:56493/api/ThreeN", function (data) {
            console.log(data);
            $.each(data, function (i, field) {
                alert(i + ": " + field);
            });
        });*/
       // $.getJSON("http://localhost:56493/api/ThreeN", {
           //     x: 10,
                y: 20
           // },
           // function (data, textStatus) {
           //     console.log(data);
           // }
        //);
   // });




//});

var app = angular.module('threeN', ['ui.bootstrap']);
app.controller('mainController', function ($scope) {
  $scope.isCollapsed = false;
});