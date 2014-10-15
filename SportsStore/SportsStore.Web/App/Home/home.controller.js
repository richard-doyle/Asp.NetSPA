(function () {
    'use strict';
    
    angular
        .module('app')
        .controller('Home', ['$http', Home]);

    function Home($http) {
        var vm = this;
        vm.products = {};

        $http.get('http://localhost:58321/api/products').success(function (data) {
            vm.products = data;
        });
    }
})();