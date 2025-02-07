'use strict';

angular.module('ngCart', ['ngCart.directives'])

    .config([function () {
    }])

    .provider('$ngCart', function () {
        this.$get = function () {
        };
    })

    .run(['$rootScope', 'ngCart', 'ngCartItem', 'store', function ($rootScope, ngCart, ngCartItem, store) {
        $rootScope.$on('ngCart:change', function () {
            ngCart.$save();
        });

        if (angular.isObject(store.get('cart'))) {
            ngCart.$restore(store.get('cart'));
        } else {
            ngCart.init();
        }
    }])

    .service('ngCart', ['$rootScope', 'ngCartItem', 'store', function ($rootScope, ngCartItem, store) {
        this.init = function () {
            this.$cart = {
                shipping: null,
                taxRate: null,
                tax: null,
                items: []
            };
        };

        this.addItem = function (id, name, price, quantity, data) {
            var inCart = this.getItemById(id);

            if (typeof inCart === 'object') {
                //Update quantity of an item if it's already in the cart
                inCart.setQuantity(quantity, false);
            } else {
                var newItem = new ngCartItem(id, name, price, quantity, data);
                this.$cart.items.push(newItem);
                $rootScope.$broadcast('ngCart:itemAdded', newItem);
            }

            $rootScope.$broadcast('ngCart:change', {});
        };

        this.getItemById = function (itemId) {
            var items = this.getCart().items;
            var build = false;

            angular.forEach(items, function (item) {
                if (item.getId() === itemId) {
                    build = item;
                }
            });
            return build;
        };

        this.setShipping = function (shipping) {
            this.$cart.shipping = shipping;
            return this.getShipping();
        };

        this.getShipping = function () {
            if (this.getCart().items.length == 0) return 0;
            return this.getCart().shipping;
        };

        this.setTaxRate = function (taxRate) {
            this.$cart.taxRate = +parseFloat(taxRate).toFixed(2);
            return this.getTaxRate();
        };

        this.getTaxRate = function () {
            return this.$cart.taxRate
        };

        this.getTax = function () {
            return +parseFloat(((this.getSubTotal() / 100) * this.getCart().taxRate)).toFixed(2);
        };

        this.setCart = function (cart) {
            this.$cart = cart;
            return this.getCart();
        };

        this.getCart = function () {
            return this.$cart;
        };

        this.getItems = function () {
            return this.getCart().items;
        };

        this.getTotalItems = function () {
            var count = 0;
            var items = this.getItems();
            angular.forEach(items, function (item) {
                count += item.getQuantity();
            });
            return count;
        };

        this.getTotalUniqueItems = function () {
            return this.getCart().items.length;
        };

        this.getSubTotal = function () {
            var total = 0;
            angular.forEach(this.getCart().items, function (item) {
                total += item.getTotal();
            });
            return +parseFloat(total).toFixed(2);
        };

        this.totalCost = function () {
            return +parseFloat(this.getSubTotal() + this.getShipping() + this.getTax()).toFixed(2);
        };

        this.removeItem = function (index) {
            this.$cart.items.splice(index, 1);
            $rootScope.$broadcast('ngCart:itemRemoved', {});
            $rootScope.$broadcast('ngCart:change', {});
        };

        this.removeItemById = function (id) {
            var cart = this.getCart();
            angular.forEach(cart.items, function (item, index) {
                if (item.getId() === id) {
                    cart.items.splice(index, 1);
                }
            });
            this.setCart(cart);
            $rootScope.$broadcast('ngCart:itemRemoved', {});
            $rootScope.$broadcast('ngCart:change', {});
        };

        this.empty = function () {
            $rootScope.$broadcast('ngCart:change', {});
            this.$cart.items = [];
            localStorage.removeItem('cart');
        };

        this.isEmpty = function () {
            return (this.$cart.items.length > 0 ? false : true);
        };

        this.toObject = function () {
            if (this.getItems().length === 0) return false;

            var items = [];
            angular.forEach(this.getItems(), function (item) {
                items.push(item.toObject());
            });

            return {
                shipping: this.getShipping(),
                tax: this.getTax(),
                taxRate: this.getTaxRate(),
                subTotal: this.getSubTotal(),
                totalCost: this.totalCost(),
                items: items
            }
        };

        this.$restore = function (storedCart) {
            var _self = this;
            _self.init();
            _self.$cart.shipping = storedCart.shipping;
            _self.$cart.tax = storedCart.tax;

            angular.forEach(storedCart.items, function (item) {
                _self.$cart.items.push(new ngCartItem(item._id, item._name, item._price, item._quantity, item._data));
            });
            this.$save();
        };

        this.$save = function () {
            return store.set('cart', JSON.stringify(this.getCart()));
        }
    }])

    .factory('ngCartItem', ['$rootScope', '$log', function ($rootScope, $log) {
        var item = function (id, name, price, quantity, data) {
            this.setId(id);
            this.setName(name);
            this.setPrice(price);
            this.setQuantity(quantity);
            this.setData(data);
        };

        item.prototype.setId = function (id) {
            if (id) this._id = id;
            else {
                $log.error('An ID must be provided');
            }
        };

        item.prototype.getId = function () {
            return this._id;
        };

        item.prototype.setName = function (name) {
            if (name) this._name = name;
            else {
                $log.error('A name must be provided');
            }
        };
        item.prototype.getName = function () {
            return this._name;
        };

        item.prototype.setPrice = function (price) {
            var priceFloat = parseFloat(price);
            if (priceFloat) {
                if (priceFloat <= 0) {
                    $log.error('A price must be over 0');
                } else {
                    this._price = (priceFloat);
                }
            } else {
                $log.error('A price must be provided');
            }
        };
        item.prototype.getPrice = function () {
            return this._price;
        };

        item.prototype.setQuantity = function (quantity, relative) {
            var quantityInt = parseInt(quantity);
            if (quantityInt % 1 === 0) {
                if (relative === true) {
                    this._quantity += quantityInt;
                } else {
                    this._quantity = quantityInt;
                }
                if (this._quantity < 1) this._quantity = 1;
            } else {
                this._quantity = 1;
                $log.info('Quantity must be an integer and was defaulted to 1');
            }
            $rootScope.$broadcast('ngCart:change', {});
        };

        item.prototype.getQuantity = function () {
            return this._quantity;
        };

        item.prototype.setData = function (data) {
            if (data) this._data = data;
        };

        item.prototype.getData = function () {
            if (this._data) return this._data;
            else $log.info('This item has no data');
        };

        item.prototype.getTotal = function () {
            return +parseFloat(this.getQuantity() * this.getPrice()).toFixed(2);
        };

        item.prototype.toObject = function () {
            return {
                id: this.getId(),
                name: this.getName(),
                price: this.getPrice(),
                quantity: this.getQuantity(),
                data: this.getData(),
                total: this.getTotal()
            }
        };

        return item;
    }])

    .service('store', ['$window', function ($window) {
        return {
            get: function (key) {
                if ($window.localStorage[key]) {
                    var cart = angular.fromJson($window.localStorage[key]);
                    return JSON.parse(cart);
                }
                return false;
            },

            set: function (key, val) {
                if (val === undefined) {
                    $window.localStorage.removeItem(key);
                } else {
                    $window.localStorage[key] = angular.toJson(val);
                }
                return $window.localStorage[key];
            }
        }
    }])

    .controller('CartController', ['$scope', 'ngCart', function ($scope, ngCart, $uibModalInstance) {
        $scope.ngCart = ngCart;
        $scope.checkOutDetails = function () {
            console.log($uibModalInstance);
            $uibModalInstance.close();
        };
    }])

    .value('version', '1.0.0');
; 'use strict';

angular.module('ngCart.directives', ['ngCart.fulfilment'])

    .controller('CartController', ['$scope', 'ngCart', function ($scope, ngCart) {
        $scope.ngCart = ngCart;
    }])

    .directive('ngcartAddtocart', ['ngCart', function (ngCart) {
        return {
            restrict: 'E',
            controller: 'CartController',
            scope: {
                id: '@',
                name: '@',
                quantity: '@',
                quantityMax: '@',
                price: '@',
                data: '='
            },
            transclude: true,
            templateUrl: function (element, attrs) {
                if (typeof attrs.templateUrl == 'undefined') {
                    return 'template/ngCart/addtocart.html';
                } else {
                    return attrs.templateUrl;
                }
            },
            link: function (scope, element, attrs) {
                scope.attrs = attrs;
                scope.inCart = function () {
                    return ngCart.getItemById(attrs.id);
                };

                if (scope.inCart()) {
                    scope.q = ngCart.getItemById(attrs.id).getQuantity();
                } else {
                    scope.q = parseInt(scope.quantity);
                }

                scope.qtyOpt = [];
                for (var i = 1; i <= scope.quantityMax; i++) {
                    scope.qtyOpt.push(i);
                }
            }
        };
    }])

    .directive('ngcartCart', [function () {
        return {
            restrict: 'E',
            controller: 'CartController',
            scope: {},
            templateUrl: function (element, attrs) {
                if (typeof attrs.templateUrl == 'undefined') {
                    return 'template/ngCart/cart.html';
                } else {
                    return attrs.templateUrl;
                }
            },
            link: function (scope, element, attrs) {
            }
        };
    }])

    .directive('ngcartSummary', [function () {
        return {
            restrict: 'E',
            controller: 'CartController',
            scope: {},
            transclude: true,
            templateUrl: function (element, attrs) {
                if (typeof attrs.templateUrl == 'undefined') {
                    return 'template/ngCart/summary.html';
                } else {
                    return attrs.templateUrl;
                }
            }
        };
    }])

    .directive('ngcartCheckout', [function () {
        return {
            restrict: 'E',
            controller: ('CartController', ['$rootScope', '$scope', 'ngCart', 'fulfilmentProvider', function ($rootScope, $scope, ngCart, fulfilmentProvider) {
                $scope.ngCart = ngCart;

                $scope.checkout = function () {
                    fulfilmentProvider.setService($scope.service);
                    fulfilmentProvider.setSettings($scope.settings);
                    fulfilmentProvider.checkout()
                        .then(function (data, status, headers, config) {
                            $rootScope.$broadcast('ngCart:checkout_succeeded', data);
                            console.log("success");
                            //console.log(data);
                            //console.log(data.cart.subTotal);
                        })
                        .catch(function (data, status, headers, config) {
                            console.log("hubo un error");
                            $rootScope.$broadcast('ngCart:checkout_failed', {
                                statusCode: status,
                                error: data
                            });
                        });
                }
            }]),
            scope: {
                service: '@',
                settings: '='
            },
            transclude: true,
            templateUrl: function (element, attrs) {
                if (typeof attrs.templateUrl == 'undefined') {
                    return 'template/ngCart/checkout.html';
                } else {
                    return attrs.templateUrl;
                }
            }
        };
    }]);
;
angular.module('ngCart.fulfilment', ["ngCookies"])
    .service('fulfilmentProvider', ['$injector', function ($injector) {
        this._obj = {
            service: undefined,
            settings: undefined
        };

        this.setService = function (service) {
            this._obj.service = service;
        };

        this.setSettings = function (settings) {
            this._obj.settings = settings;
        };

        this.checkout = function () {
            var provider = $injector.get('ngCart.fulfilment.' + this._obj.service);
            return provider.checkout(this._obj.settings);
        }
    }])

    .service('ngCart.fulfilment.log', ['$q', '$log', 'ngCart', "$cookieStore", function ($q, $log, ngCart, $cookieStore) {
        this.checkout = function () {
            var deferred = $q.defer();
            $log.info("log service");
            $log.info(ngCart.toObject());
            //console.log(ngCart.toObject().items[0].data);
            var temp = ngCart.toObject();
            var cart = temp.items;
            var userId = $cookieStore.get("globals");
            $log.warn(cart[0].id);
            var json = {
                "UserId": userId.currentUser.userId,
                "purchaseDate": new Date().toISOString(),
                "orderStatusCode": 1,
                "totalOrderPrice": temp.totalCost
            }
            $log.warn(json);
            var tiempo = new Date().toISOString();
            console.log(tiempo);
            var local = new Date("2017-04-21T16:50:07.49");
            console.log(local.toString());
            //var json = angular.toJson(temp, true);
            //angular.forEach(cart, function (value, key) {
            //    //$log.info("key:" + key + ":" + value.data.ProductId);

            //    //angular.forEach(key.items, function (valor, llave) {
            //    //    $log.info(llave + ":" + valor);
            //    //});
            //});
            //$log.warn(json);
            //$log.warn(temp);
            deferred.resolve({
                cart: ngCart.toObject()
            });

            return deferred.promise;
        }
    }])

    .service('ngCart.fulfilment.http', ['$http', 'ngCart', "$cookieStore", "$location", function ($http, ngCart, $cookieStore, $location) {
       

        this.checkout = function (settings) {
            console.log(ngCart.toObject());
            var userId = $cookieStore.get("globals");
            var order = {
                "UserId": userId.currentUser.userId,
                "purchaseDate": new Date().toISOString(),
                "orderStatusCode": 1,
                "totalOrderPrice": ngCart.toObject().totalCost
            }
            console.log(order);

            console.log("CHEKOUT HTTP");
            console.log(settings);
            return $http.post(settings.url, order).then(function (response) {
                console.log("respuesta del server");
                console.log(response);
                console.log(response.data.OrderId);
                for (var i = 0; i < ngCart.toObject().items.length; i++) {
                    console.log("entre al ciclo");
                    var orderDetail = {
                        "ProductId": ngCart.toObject().items[i].id,
                        "OrderId": response.data.OrderId,
                        "quantityOrder": ngCart.toObject().items[i].quantity
                    }
                    $http.post("http://localhost:58495/orderDetail/api/orderDetail", orderDetail).then(function (response) {
                        console.log(response);
                        ngCart.empty();
                        //console.log($location.path());
                        $location.path("/");
                    })
                }
            });
        }
    }])

    .service('ngCart.fulfilment.paypal', ['$http', 'ngCart', function ($http, ngCart) {
    }]);