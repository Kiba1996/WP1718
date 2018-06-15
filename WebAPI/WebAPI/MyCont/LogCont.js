WebAPI.factory('LogCont', function ($http) {

    var factory = {};
    factory.RegisterUser = function (user) {
        return $http.post('/api/Log/Register', {
            Username: user.username,
            Password: user.pwd,
            Ime: user.ime,
            Prezime: user.prezime,
            Pol: user.pol,
            Jmbg: user.jmbg,
            Telefon: user.kontaktTelefon,
            Email: user.email
        });
    }

    factory.LoginUser = function (user) {
        return $http.post('/api/Log/Login', {
            Username: user.username,
            Password: user.pwd
        });
    }


    return factory;
});