WebAPI.factory('ProfCont', function ($http) {

    var factory = {};
    factory.getUserByUsername = function (username) {
        return $http.get('/api/Prof/GetUserByUsername?username=' + username);
    }

    factory.AddDriveCustomer = function (drive) {
        return $http.post('/api/Prof/AddDriveCustomer', {
            XCoord: drive.XCoord,
            YCoord: drive.YCoord,
            Street: drive.Street,
            Number: drive.Number,
            Town: drive.Town,
            PostalCode: drive.PostalCode,
            tipAuta: drive.tipAuta,
            korisnicko: sessionStorage.getItem("username")
           
        });
    }

    factory.Filter = function (fu) {
        return $http.post('api/Prof/GetFilterUser', {
            Username: sessionStorage.getItem("username"),
            Role: sessionStorage.getItem("role"),
            Stat: fu

        });
    }

    factory.AddDriveDispatcher = function (drive) {
        return $http.post('/api/Prof/AddDriveDispatcher', {
            XCoord: drive.XCoord,
            YCoord: drive.YCoord,
            Street: drive.Street,
            Number: drive.Number,
            Town: drive.Town,
            PostalCode: drive.PostalCode,
            tipAuta: drive.tipAuta,
            korisnicko: sessionStorage.getItem("username")

        });
    }

    //factory.EditUser = function (user) {
    //    return $http.post('/api/Prof/EditUser', {
    //        Username: user.username,
    //        Password: user.pwd,
    //        Ime: user.ime,
    //        Prezime: user.prezime,
    //        Pol: user.pol,
    //        Jmbg: user.jmbg,
    //        Telefon: user.kontaktTelefon,
    //        Email: user.email,
    //        korisnicko: sessionStorage.getItem("username")
    //    });

    //}

    return factory;
});