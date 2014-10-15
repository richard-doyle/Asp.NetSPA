(function () {
    'use strict';
    
    angular
        .module('app')
        .controller('Home', ['$http', Home]);

    function Home($http) {
        var vm = this;
        vm.products = [];
        vm.submit = submit;
        vm.name = "";
        vm.price = 0;

        function submit() {
            if (vm.name) {
                var product = { name: vm.name, price: vm.price };
                $http.post('http://localhost:58321/api/products', product).success(function(data) {
                    vm.products.push({ name: data.name, price: data.price });
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