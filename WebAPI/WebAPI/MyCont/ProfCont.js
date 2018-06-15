WebAPI.factory('ProfCont', function ($http) {

    var factory = {};
    factory.getUserByUsername = function (username) {
        return $http.get('/api/Prof/GetUserByUsername?username=' + username);
    }


    return factory;
});