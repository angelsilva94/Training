var myApp = angular.module('myApp', ['ng-admin']);
myApp.config(['RestangularProvider', function (RestangularProvider) {
    var login = 'angelsilva94',
        password = 'pwd1234',
        token = window.btoa(login + ':' + password);
    RestangularProvider.setDefaultHeaders({ 'Authorization': 'Basic ' + token });
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
    user.listView()
        .fields([
        //nga.field("UserId"),
            nga.field("name").sortable(false),
            nga.field("username").isDetailLink(true).sortable(false),
            nga.field("email").sortable(false)
        ]).listActions(["edit"]);
    order.listView()
        .fields([
            nga.field("OrderId")
                .isDetailLink(true),
            nga.field("UserId", "reference")
                .targetEntity(user)
                .targetField(nga.field("username"))
                .label("UserName"),
            nga.field("orderStatusCode"),
            nga.field("purchaseDate", "datetime"),
            nga.field("OrderDetails", "embedded_list")
                .targetFields([
            nga.field("Product.productName")
                .label("Product Name"),
            nga.field("quantityOrder")
                .label("Quantity"),
            nga.field("Product.productPrice", "number")
                .format("$0,0.00")
                .label("Product Price"),

                ]),
            nga.field("totalOrderPrice", "number")
                .format("$0,0.00"),

        ]).listActions(["edit"]);
    review.listView()
        .fields([
            //nga.field("ReviewProductIdNumber").isDetailLink(true),
            //nga.field("UserId"),
            nga.field("Product.productName")
                .label("Product Name"),
            nga.field("productUrl", "template")
                .label("")
                .template('<img src="{{entry.values.productUrl}}" width="50" style="vertical-align: text-bottom"/> '),
            nga.field('UserId', 'reference')
                .targetEntity(user)
                .targetField(nga.field('username'))
                .label('UserName').isDetailLink(true),

            nga.field("reviewDesc"),
            nga.field("ratingReview")
                .cssClasses(function (entry) { // add custom CSS classes to inputs and columns
                    if (!entry) return;
                    if (entry.values.ratingReview >= 7.5) {
                        return 'text-center bg-success';
                    }
                    if (entry.values.ratingReview >= 6 && entry.values.ratingReview < 7.5) {
                        return 'text-center bg-warning';
                    }

                    if (entry.values.ratingReview < 6) {
                        return 'text-center bg-danger';
                    }

                }),


        //AQUI ME QUEDE FALTA LIGAR LAS ORDENES !!!!!!!!!

        ]).listActions(["edit"]);
    product.listView()
        .fields([
        //nga.field("ProductId"),
            nga.field("productUrl", "template")
                .label("")
                .template('<img src="{{entry.values.productUrl}}" width="50" style="vertical-align: text-bottom"/> '),
            nga.field("productName")
                .isDetailLink(true),
            nga.field("productDesc"),
            nga.field("productPrice", "number")
                .format("$0,0.00"),
            nga.field("productStock"),
            nga.field("productStatus", "boolean"),
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

        ]).listActions(["edit", "delete"]);

    category.listView()
            .fields([
                nga.field("categoryName")
                    .isDetailLink(true),
                nga.field("categoryDesc"),
                nga.field("categoryImage")
            ]).listActions(["edit"]);

    productCategory.listView()
                    .fields([
                        //nga.field("ProductCategoryId").isDetailLink(true),
                        nga.field("ProductId", "reference")
                           .targetEntity(product)
                           .targetField(nga.field("productName"))
                           .label("Product Name"),
                       nga.field("CategoryId", "reference")
                           .targetEntity(category)
                           .targetField(nga.field("categoryName"))
                           .label("Category Name"),
                    ]).listActions(["edit"]);

    //createView



    user.editionView()
        .title("{{ entry.values.name }} {{ entry.values.lastName }}\'s details")
        .fields([
            nga.field("UserId")
                .editable(false),
            nga.field("name"),
            nga.field("username")
                .isDetailLink(true),
            nga.field("email"),
            nga.field("password"),
            nga.field("regDate", "datetime")
                .editable(false)
                .label("Registration Date"),
            nga.field('comments', 'referenced_list')
              .targetEntity(review)
              .targetReferenceField('UserId')
              .targetFields([ // choose another set of fields
                  nga.field('ratingReview')
                      .label("Rating")
                      .cssClasses(function (entry) { // add custom CSS classes to inputs and columns
                          if (!entry) return;
                          if (entry.values.ratingReview >= 7.5) {
                              return 'text-center bg-success';
                          }
                          if (entry.values.ratingReview >= 6 && entry.values.ratingReview < 7.5) {
                              return 'text-center bg-warning';
                          }

                          if (entry.values.ratingReview < 6) {
                              return 'text-center bg-danger';
                          }

                      }),
                  nga.field('Product.productName')
                      .label("Product Name"),
                  nga.field('reviewDesc')
                      .label("Review Details"),


              ])

        ]);


    review.editionView().fields([
        nga.field("Product.ProductId", "reference")
           .targetEntity(product)
           .targetField(nga.field("productName"))
           .label("Product Name")
           .editable(false),
        //nga.field("User.UserId")
        //    .editable(false)
        //    .label("User Id"),
        nga.field("User.UserId", "reference")
            .targetEntity(user)
            .targetField(nga.field("username"))
            .editable(false)
            .label("UserName")
            .singleApiCall(id => ({ 'id': id })),
        nga.field("UserId", "reference")
            .targetEntity(user)
            .targetField(nga.field('name').map((v, e) => e.name + " " + e.surname + " " + e.lastName))
            .label("Customer")
            .editable(false),
            //.singleApiCall(ids => ({ 'id': ids }))
        nga.field("reviewDesc", "text"),
        nga.field("ratingReview", "choice")
            .choices([
                { value: 1, label: 1 },
                { value: 2, label: 2 },
                { value: 3, label: 3 },
                { value: 4, label: 4 },
                { value: 5, label: 5 },
                { value: 6, label: 6 },
                { value: 7, label: 7 },
                { value: 8, label: 8 },
                { value: 9, label: 9 },
                { value: 10, label: 10 },
            ]),



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
        nga.field("productStock", "number"),
        nga.field("productPublishDate", "datetime"),
        nga.field("productModifyDate", "datetime"),
        nga.field("productStatus", "choice")
            .choices([
                { value: true, label: "enable" },
                { value: false, label: "disable" }
            ]),
        //nga.field("category","reference")
    ]);
    category.creationView()
            .fields([
                //nga.field("CategoryId").editable(false),
                nga.field("categoryName"),
                nga.field("categoryDesc"),
                nga.field("categoryImage"),
            ]);

    productCategory.creationView()
                    .fields([
                        //nga.field('ProductCategoryId'),
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


    //user.editionView().fields(user.creationView().fields());
    //order.editionView().fields(order.creationView().fields());
    review.editionView().fields(review.creationView().fields());
    productCategory.editionView().fields(productCategory.creationView().fields());
    order.editionView()
         .fields([
             nga.field("OrderId"),
             nga.field("totalOrderPrice"),



         ]);
    category.editionView()
            .fields([
                nga.field("CategoryId").editable(false),
                nga.field("categoryName"),
                nga.field("categoryDesc"),
                nga.field("categoryImage"),
            ]);

    product.editionView()
            .fields([
                nga.field("productName"),
                nga.field("productDesc"),
                nga.field("productPrice", "float"),
                nga.field("productUrl"),
                nga.field("productStock", "number"),
                nga.field("productStatus", "choice").choices([
                    { value: true, label: "enable" },
                    { value: false, label: "disable" }
                ]),
        //nga.field("Categorias", "referenced_list")
        //    .targetEntity(productCategory)
        //    .targetReferenceField("ProductId")
        //    .targetFields([ 
        //        nga.field('Category.categoryName').label("Categoria"),

        //    ])

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
    .addChild(nga.menu().title('Catalog').icon('<span class="fa fa-th-list fa-fw"></span>').addChild(nga.menu(product).icon('<span class="fa fa-picture-o fa-fw"></span>')).addChild(nga.menu(category).icon('<span class="fa fa-tag fa-fw"></span>')).addChild(nga.menu(productCategory).title("Add Product to Category").icon('<span class="fa fa-tags fa-fw"></span>')))
    );
    // attach the admin application to the DOM and execute it
    nga.configure(admin);
}]);

