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
            activeTab: 'Profile'
        }).when('/DriveGet',
        {
            controller: 'ProfileController',
            templateUrl: 'MyHtmls/DriveGet.html',
            activetab: 'none'
        }).when('/AddDrivers', {
            controller: 'LoginController',
            templateUrl: 'MyHtmls/AddDrivers.html',
            activetab: 'AddDrivers'
        }).when('/Edit', {
            controller: 'ProfileController',
            templateUrl: 'MyHtmls/Edit.html',
            activeTab: 'Edit'
        }).when('/Comment', {
            controller: 'CommentController',
            templateUrl: 'MyHtmls/Comment.html',
            activeTab: 'none'
        }).when('/EndDrive', {
            controller: 'CommentController',
            templateUrl: 'MyHtmls/EndDrive.html',
            activeTab: 'none'
        }).when('/EditDrive', {
            controller: 'ProfileController',
            templateUrl: 'MyHtmls/EditDrive.html',
            activeTab: 'none'
        }).when('/ChangeLocation', {
            controller: 'ProfileController',
            templateUrl: 'MyHtmls/ChangeLocation.html',
            activeTab: 'none'
        }).when('/ObradiVoznju', {
            controller: 'ProfileController',
            templateUrl: 'MyHtmls/ObradiVoznju.html',
            activeTab: 'none'
        }).when('/BlokUsers', {
            controller: 'BlockController',
            templateUrl: 'MyHtmls/BlokUsers.html',
            activeTab: 'none'
        })

});
