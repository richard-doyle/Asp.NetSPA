(function () {
    'use strict';
    
    angular
        .module('app')
        .controller('Home', ['$http', Home]);

    function Home($http) {
        var vm = this;
        var apiRoot = 'http://localhost:58321/api/';
        vm.products = [];
        vm.removeProduct = removeProduct;
        vm.submit = submit;
        vm.name = "";
        vm.price = 0;

        function removeProduct(productId) {
            $http.delete(apiRoot + 'products/' + productId).success(function() {
                vm.products = vm.products.filter(function(p) {
                    return p.id !== productId;
                });
            });
        }

        function submit() {
            if (vm.name) {
                var product = { name: vm.name, price: vm.price };
                $http.post(apiRoot + '/products', product).success(function(data) {
                    vm.products.push(data);
                    vm.name = "";
                    vm.price = 0;
                }).error(function(data) {
                    alert("Opps, something went wrong! " + data);
                });
            }
        }

        $http.get('http://localhost:58321/api/products').success(function (data) {
            vm.products = data;
        });
    }
})();