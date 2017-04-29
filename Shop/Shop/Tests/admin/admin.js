﻿var myApp = angular.module('myApp', ['ng-admin']);
myApp.config(['NgAdminConfigurationProvider', function (nga) {
    // create an admin application
    var admin = nga.application('My First Admin')
        .baseApiUrl('http://localhost:58495/'); // main API endpoint
    // create a user entity
    // the API endpoint for this entity will be 'http://jsonplaceholder.typicode.com/users/:id
    //nga.entity('users')
    var user = nga.entity('users').identifier(nga.field('UserId'));

    // set the fields of the user entity list view
    user.listView().fields([
        nga.field('UserId'),
        nga.field('name'),
        nga.field('username'),
        nga.field('email'),
    ]);
    // add the user entity to the admin application
    admin.addEntity(user);
    // attach the admin application to the DOM and execute it
    nga.configure(admin);
}]);

