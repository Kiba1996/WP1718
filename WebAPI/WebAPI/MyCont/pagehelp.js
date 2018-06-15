var WebAPI = angular.module('WebAPI', ['ngRoute']);

WebAPI.config(function ($routeProvider) {
    $routeProvider.when('/',
        {
            redirectTo: '/MyHome'

        }).when('/MyHome',
        {
            controller: 'MyHomeController',
            templateUrl: 'MyHtmls/MyHome.html',
            activeTab: 'Home'

        }).when('/Register',
        {
            controller: 'LoginController',
            templateUrl: 'MyHtmls/Register.html',
            activeTab: 'Register'
  
        }).when('/Login',
         {
            controller: 'LoginController',
            templateUrl: 'MyHtmls/Login.html',
            activeTab: 'Login'
        }).when('/Profile',
        {
            controller: 'ProfileController',
            templateUrl: 'MyHtmls/Profile.html',
            activeTab: 'nijedan'
        }).when('/Profile/:username', {

            controller: 'ProfileController',
            templateUrl: 'MyHtmls/Profile.html',
            activetab: 'nijedan'

        })

});
