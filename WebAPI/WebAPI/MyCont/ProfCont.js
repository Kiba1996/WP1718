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
            tipAuta: drive.tipAuta,
            korisnicko: sessionStorage.getItem("username")
           
        });
    }

    factory.Filter = function (Drives, fu) {
       
        return $http.post('api/Prof/GetFilterUser', {
            Username: sessionStorage.getItem("username"),
            Role: sessionStorage.getItem("role"),
            Stat: fu,
            Driv: Drives
        });
    }

    factory.Filter2 = function (fu) {
        return $http.post('api/Prof/GetFilterUserAdm', {
            Username: sessionStorage.getItem("username"),
            Role: sessionStorage.getItem("role"),
            Stat: fu

        });
    }

    //factory.Sorting = function (username) {
    //    return $http.get('api/Prof/SortingUser?k=' + username);
    //}

    factory.Sorting = function (Drives,fu) {
        return $http.post('api/Prof/SortingUser', {
            Username: sessionStorage.getItem("username"),
            Role: sessionStorage.getItem("role"),
            Stat: "none",
            Driv: Drives,
            PoCemu: fu

        });
    }

    factory.Search = function (Drives, su) {
        return $http.post('api/Prof/SearchUser', {
            Username: sessionStorage.getItem("username"),
            Role: sessionStorage.getItem("role"),
            Driv: Drives,
            DatumOd: su.DatumOd,
            DatumDo: su.DatumDo,
            OcenaOd: su.OcenaOd,
            OcenaDo: su.OcenaDo,
            CenaOd: su.CenaOd,
            CenaDo: su.CenaDo,
            VozIme: su.VozIme,
            VozPre: su.VozPre,
            MusIme: su.MusIme,
            MusPre: su.MusPre
        });
    }

    factory.AddDriveDispatcher = function (drive) {
        return $http.post('/api/Prof/AddDriveDispatcher', {
            XCoord: drive.XCoord,
            YCoord: drive.YCoord,
            Street: drive.Street,
            //Number: drive.Number,
            //Town: drive.Town,
            //PostalCode: drive.PostalCode,
            tipAuta: drive.tipAuta,
            korisnicko: sessionStorage.getItem("username")

        });
    }


    factory.DodajVoznjuKonacno = function (novimodel,voznja) {
        return $http.post('/api/Prof/DodajVoznjuKonacno', {
            voz: voznja,
            korisnickoAdmin: sessionStorage.getItem("username"),
            korisnickoVozac: novimodel.selektovaniVozac
        });
    }


    factory.ObradiVoznjuKonacno = function (novimodel, voznja) {
        return $http.post('/api/Prof/ObradiVoznjuKonacno', {
            voz: voznja,
            korisnickoAdmin: sessionStorage.getItem("username"),
            korisnickoVozac: novimodel.selektovaniVozac
        });
    }


    factory.EditUser = function (user) {
        return $http.post('/api/Prof/EditUser', {
            Username: user.username,
            Password: user.pwd,
            Ime: user.ime,
            Prezime: user.prezime,
            Pol: user.pol,
            Jmbg: user.jmbg,
            Telefon: user.kontaktTelefon,
            Email: user.email,
            OldUsername: sessionStorage.getItem("username")
        });

    }

    factory.CancelDrive = function (drive) {
        return $http.post('/api/Prof/CancelDrive', {
            dr: drive
        });
    }

    factory.Commenting = function (ko, voz) {
        return $http.post('/api/Prof/Commenting', {
            KommOpis: ko.Opis,
            KommOcena: ko.Ocena,
            Voz: voz
        });
    }
    factory.ProcessDrive = function (drive) {
        return $http.post('/api/Prof/ProcessDrive', {
            KommOpis: sessionStorage.getItem("username"),
            voz: drive
            
        });
    }

   
    factory.AcceptDrive = function (drive, drives) {
        return $http.post('/api/Prof/AcceptDrive', {
            dr: drive,
            voznje: drives,
            korisnicko: sessionStorage.getItem("username")
        });
    }

    factory.getDriverData = function (username) {
        return $http.get('/api/Prof/getDriverData?username=' + username);
    }

    factory.Comment = function (ko, voz) {
        return $http.post('/api/Prof/Comment', {
            KommOpis: ko.Opis,
           // KommOcena: ko.Ocena,
            Voz: voz
        });
    }

    factory.SuccessDrive = function (drive, dri) {
        return $http.post('/api/Prof/SuccessDrive', {
            XCoord: drive.XCoord,
            YCoord: drive.YCoord,
            Street: drive.Street,
            //Number: drive.Number,
            //Town: drive.Town,
            //PostalCode: drive.PostalCode,
            voznja: dri,
            Cena: drive.Cena
        })
    }


    factory.ChangeDriveCustomer = function (drive) {
        return $http.post('/api/Prof/ChangeDriveCustomer', {
            XCoord: drive.XCoord,
            YCoord: drive.YCoord,
            Street: drive.Street,
            tipAuta: drive.tipAuta,
            korisnicko: sessionStorage.getItem("username"),
            datum: drive.datum
        });
    }


    factory.ChangeLocation = function (drive) {
        return $http.post('/api/Prof/ChangeLocation', {
            XCoord: drive.XCoord,
            YCoord: drive.YCoord,
            Street: drive.Street,
            tipAuta: drive.tipAuta,
            korisnicko: sessionStorage.getItem("username"),
            datum: drive.datum
        });
    }

    factory.getBlockedUsers = function () {
        return $http.get('/api/Prof/getBlockedUsers');
    }
    factory.getUnblockedUsers = function () {
        return $http.get('/api/Prof/getUnblockedUsers');
    }

    factory.Block = function (korisnickoime) {
        return $http.get('/api/Prof/Block?username=' + korisnickoime);
    }
    factory.Unblock = function (korisnickoime) {
        return $http.get('/api/Prof/Unblock?username=' + korisnickoime);
    }

    return factory;
});