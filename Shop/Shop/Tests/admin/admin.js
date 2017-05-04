﻿var myApp = angular.module('myApp', ['ng-admin']);
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
    var category = nga.entity("category").identifier(nga.field("CategoryId"));
    var productCategory = nga.entity("productCategory").identifier(nga.field("ProductCategoryId"));
    //list view
    user.listView().fields([
        nga.field("UserId"),
        nga.field("name"),
        nga.field("username").isDetailLink(true) ,
        nga.field("email")
    ]);
    order.listView().fields([
        nga.field("OrderId").isDetailLink(true), 
        nga.field("UserId", "reference")
        .targetEntity(user)
        .targetField(nga.field("username"))
        .label("UserName"),
        nga.field("orderStatusCode"),
        nga.field("purchaseDate", "datetime"),
        nga.field("OrderDetails", "embedded_list")
        .targetFields([
            nga.field("Product.productName").label("Product Name"),
            nga.field("quantityOrder").label("Quantity"),
            nga.field("Product.productPrice","number").format("$0,0.00").label("Product Price"),
            
        ]),
        nga.field("totalOrderPrice","number").format("$0,0.00"),

    ]);
    review.listView().fields([
        nga.field("ReviewProductIdNumber").isDetailLink(true),
        nga.field("UserId"),
        nga.field('UserId', 'reference')
        .targetEntity(user)
        .targetField(nga.field('username'))
        .label('UserName').isDetailLink(true),
        nga.field("reviewDesc"),
        nga.field("ratingReview"),


    ]);
    product.listView().fields([
        nga.field("ProductId"),
        nga.field("productName").isDetailLink(true),
        nga.field("productDesc"),
        nga.field("productPrice","number").format("$0,0.00"),
        nga.field("productStock"),
        nga.field("productStatus"),
        nga.field("productModifyDate", "datetime"),
        nga.field('ReviewProducts', 'embedded_list') 
          .targetFields([ 
              nga.field('ratingReview').label('rating'),
          ]),
        //nga.field("Category", "referenced_list")
        //    .targetEntity(productCategory)
        //    .targetReferenceField(CategoryId)
        //    .targetFields([ 
        //    nga.field('CategoryId').label('ID'),
            
        //    ])

    ]);

    category.listView().fields([
        nga.field("categoryName").isDetailLink(true),
        nga.field("categoryDesc"),
        nga.field("categoryImage")
    ]);

    productCategory.listView().fields([
       nga.field("ProductCategoryId").isDetailLink(true),
       nga.field("ProductId", "reference")
           .targetEntity(product)
           .targetField(nga.field("productName"))
           .label("Product Name"),
       nga.field("CategoryId", "reference")
           .targetEntity(category)
           .targetField(nga.field("categoryName"))
           .label("Category Name"),
    ]);

    //createView



    user.creationView().fields([
        nga.field("UserId").editable(false),
        nga.field("name"),
        nga.field("username").isDetailLink(true),
        nga.field("email"),
        nga.field("password"),
        nga.field("regDate", "datetime").editable(false).label("Registration Date") ,

    ]);


    review.editionView().fields([
        nga.field("Product.productName").editable(false).label("Product Name"),
        nga.field("User.UserId").editable(false).label("User Id"),
        nga.field("User.username").editable(false).label("UserName"),
        nga.field("reviewDesc"),
        nga.field("ratingReview"),
          
    ]);
    order.creationView().fields([
        nga.field('OrderId'),
        nga.field("totalOrderPrice"),
    ]);
    product.creationView().fields([
        nga.field("productName"),
        nga.field("productDesc"),
        nga.field("productPrice", "float"),
        nga.field("productUrl"),
        nga.field("productStock","number"),
        nga.field("productPublishDate", "datetime"),
        nga.field("productModifyDate","datetime"),
        nga.field("productStatus", "choice").choices([
            { value: true, label: "enable" },
            { value: false, label: "disable" }
        ]),
        //nga.field("category","reference")
    ]);
    category.creationView().fields([
        //nga.field("CategoryId").editable(false),
        nga.field("categoryName"),
        nga.field("categoryDesc"),
        nga.field("categoryImage"),
    ]);

    productCategory.creationView().fields([
        nga.field('ProductCategoryId'),
        nga.field("CategoryId", "reference")
            .targetEntity(category)
            .targetField(nga.field("categoryName"))
            .label("Category:"),
         nga.field("ProductId", "reference")
            .targetEntity(product)
            .targetField(nga.field("productName"))
            .label("Product:"),
        
    ]);
    


    //nga.field("UserId", "reference")
    //    .targetEntity(user)
    //    .targetField(nga.field("username"))
    //    .label("UserName")


    //edition view
    
    user.editionView().fields(user.creationView().fields());
    order.editionView().fields(order.creationView().fields());
    product.editionView().fields(product.creationView().fields());
    
    review.editionView().fields(review.creationView().fields());
    productCategory.editionView().fields(productCategory.creationView().fields());

    category.editionView().fields([
        nga.field("CategoryId").editable(false),
        nga.field("categoryName"),
        nga.field("categoryDesc"),
        nga.field("categoryImage"),
    ]);
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
    admin.addEntity(category);
    admin.addEntity(productCategory);
    
    admin.menu(nga.menu()
    .addChild(nga.menu(user).icon('<span class="glyphicon glyphicon-user"></span>'))
    .addChild(nga.menu(review).icon('<span class="glyphicon glyphicon-pencil"></span>'))
    .addChild(nga.menu(order).icon('<span class="glyphicon glyphicon-shopping-cart"></span>'))
    .addChild(nga.menu().title('Catalog').icon('<span class="fa fa-th-list fa-fw"></span>').addChild(nga.menu(product)).addChild(nga.menu(category)).addChild(nga.menu(productCategory)))
    );
    // attach the admin application to the DOM and execute it
    nga.configure(admin);
}]);

