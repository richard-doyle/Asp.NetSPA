var sportsStore = angular.module('sportsStore', []);

sportsStore.controller('HomeController', ['$http', function($http) {
    var controller = this;

    this.products = {};

    $http.get('http://localhost:58321/api/products').success(function(data) {
        controller.products = data;
    });
}]);