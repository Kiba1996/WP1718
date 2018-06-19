var WebAPI = angular.module('WebAPI', ['ngRoute']);
var pr;WebAPI.config(function ($routeProvider) {
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
            activeTab: 'Profile'
        }).when('/Profile/:username', {

            controller: 'ProfileController',
            templateUrl: 'MyHtmls/Profile.html',
            activetab: 'Profile'

        }).when('/DriveGet/:username',
        {
            controller: 'ProfileController',
            templateUrl: 'MyHtmls/DriveGet.html',
            activetab: 'none'
        }).when('/AddDrivers/:username', {
            controller: 'LoginController',
            templateUrl: 'MyHtmls/AddDrivers.html',
            activetab: 'AddDrivers'
        }).when('/Edit/:username', {
            controller: 'ProfileController',
            templateUrl: 'MyHtmls/Edit.html',
            activeTab: 'Edit'
        }).when('/Home2/:username', {
            controller: 'Home2Controller',
            templateUrl: 'MyHtmls/MyHome.html',
            activeTab: 'none'
        }).when('/Home3/:username', {
            controller: 'Home3Controller',
            templateUrl: 'MyHtmls/MyHome.html',
            activeTab: 'none'
        }).when('/Filter/:Stat', {
            controller: 'FilterController',
            templateUrl: 'MyHtmls/MyHome.html',
            activeTab: 'none'
        }).when('/Filter2/:Stat', {
            controller: 'Filter2Controller',
            templateUrl: 'MyHtmls/MyHome.html',
            activeTab: 'none'
        }).when('/Sort/', {
            controller: 'FilterController',
            templateUrl: 'MyHtmls/MyHome.html',
            activeTab: 'none'
        })


});
