var app = angular.module("services", []);
app.value("factor", 7);
app.service("multiplier", ["factor", multiplier]);
app.provider("message", [function () {
    var text = "";
    this.setText=function (textString){
        text = textString;
    };
    this.$get = [function () {
        return new message(text);   
    }];
}]);

function multiplier(valueFactor) {
    this.multiply = function (controllerFactor) {
        return valueFactor * controllerFactor;
    };
}

function message(text) {
    this.text = text;
}