var myApp = angular.module('myApp', ['ng-admin']);
myApp.config(['RestangularProvider', function(RestangularProvider) {
    var login = 'angelsilva94',
        password = 'pwd1234',
        token = window.btoa(login + ':' + password);
    RestangularProvider.setDefaultHeaders({'Authorization': 'Basic ' + token});
}]);

myApp.config(['NgAdminConfigurationProvider', function (nga) {
    // create an admin application
    var admin = nga.application('Eshop Admin Panel')
        .baseApiUrl('http://localhost:58495/'); // main API endpoint
    // create a user entity
    // the API endpoint for this entity will be 'http://jsonplaceholder.typicode.com/users/:id
    //nga.entity('users')
    var user = nga.entity("users").identifier(nga.field("UserId"));
    var order = nga.entity("orders").identifier(nga.field("OrderId"));
    var review = nga.entity("reviewProducts").identifier(nga.field("ReviewProductIdNumber"));
    var product = nga.entity("products").identifier(nga.field("ProductId"));
    // set the fields of the user entity list view
    user.listView().fields([
        nga.field("UserId"),
        nga.field("name"),
        nga.field("username").isDetailLink(true) ,
        nga.field("email")
    ]);
    order.listView().fields([
        nga.field("OrderId").isDetailLink(true), 
        nga.field("OrderId","reference")
        .targetEntity(user)
        .targetField(nga.field("username"))
        .label("UserName"),
        nga.field("orderStatusCode"),
        nga.field("purchaseDate"),
        nga.field("totalOrderPrice"),

    ]);
    review.listView().fields([
        nga.field("ReviewProductIdNumber").isDetailLink(true),
        nga.field("UserId"),
        nga.field('UserId', 'reference')
        .targetEntity(user)
        .targetField(nga.field('username'))
        .label('UserName'),
        
        nga.field("reviewDesc"),
        nga.field("ratingReview"),

    ]);
    product.listView().fields([
        nga.field("productName").isDetailLink(true),
        nga.field("productDesc"),
        nga.field("productPrice","number").format("$0.00"),
        nga.field("productStock"),
        nga.field("productStatus"),

    ]);
    order.creationView().fields([
        nga.field('OrderId'),
        nga.field("totalOrderPrice"),

        

    ]);
    order.editionView().fields(order.creationView().fields());
    //user.creationView().fields([
    //    nga.field('name'),
    //    nga.field('username'),
    
    //]);
    //user.editionView().fields(user.creationView().fields());
    // add the user entity to the admin application
    admin.addEntity(user);
    admin.addEntity(order);
    admin.addEntity(review);
    admin.addEntity(product);
    admin.menu(nga.menu()
    .addChild(nga.menu(user).icon('<span class="glyphicon glyphicon-user"></span>'))
    .addChild(nga.menu(review).icon('<span class="glyphicon glyphicon-pencil"></span>'))
    .addChild(nga.menu(order).icon('<span class="glyphicon glyphicon-shopping-cart"></span>'))
    .addChild(nga.menu().title('Catalog').icon('<span class="fa fa-th-list fa-fw"></span>').addChild(nga.menu(product)))
    );
    // attach the admin application to the DOM and execute it
    nga.configure(admin);
}]);

