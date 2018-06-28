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

    factory.getUserStatus = function (username) {

        return $http.get('/api/Prof/getUserStatus?username=' + username);
    }


    factory.LoginUser = function (user) {
        return $http.post('/api/Log/Login', {
            Username: user.username,
            Password: user.pwd
        });
    }

    factory.getDrives = function (username) {
        return $http.get('/api/Log/GetDrives?username=' + username);
    }
    factory.getDrives1 = function (username) {
        return $http.get('/api/Log/GetDrivesAdmin?username=' + username);
    }
    factory.getDrives2 = function (username) {
        return $http.get('api/Log/GetDrivesDriver?username=' + username);
    }

    factory.RegisterDriver = function (user) {
        return $http.post('/api/Log/RegisterDriver', {
            Username: user.username,
            Password: user.pwd,
            Ime: user.ime,
            Prezime: user.prezime,
            Pol: user.pol,
            Jmbg: user.jmbg,
            Telefon: user.kontaktTelefon,
            Email: user.email,
            Year: user.year,
            Reg: user.reg,
            tipVoz: user.tipV
        });
    }


    return factory;
});