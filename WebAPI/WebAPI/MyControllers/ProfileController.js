WebAPI.controller('ProfileController', function ($scope, $rootScope, ProfCont, $routeParams, $window) {

   
    function init() {
        console.log('Profile controller initialized');

        $scope.drive = {};
        $scope.EditUN = false;
        $scope.EditN = false;
        $scope.EditSN = false;
        $scope.EditG = false;
        $scope.EditJmbg = false;
        $scope.EditPhone = false;
        $scope.EditE = false;
        $scope.EditPas = false;
        $scope.najblizivozaci = false;
        $scope.prznalista = false;
        //$scope.XCoord1 = "";
        //$scope.YCoord1 = "";
        ProfCont.getUserByUsername($routeParams.username).then(function (response) {
            console.log(response.data);

            $scope.userProfile = response.data;
           

            });
 
    }

    init();

    $scope.OtovriUN = function () {

        $scope.EditUN = true;
        $scope.apply;
    }
    $scope.OtovriN = function () {

        $scope.EditN = true;
        $scope.apply;
    }
    $scope.OtovriSN = function () {

        $scope.EditSN = true;
        $scope.apply;
    }
    $scope.OtovriG = function () {

        $scope.EditG = true;
        $scope.apply;
    }
    $scope.OtovriJmbg = function () {

        $scope.EditJmbg = true;
        $scope.apply;
    }
    $scope.OtovriPhone = function () {

        $scope.EditPhone = true;
        $scope.apply;
    }
    $scope.OtovriE = function () {

        $scope.EditE = true;
        $scope.apply;
    }
    $scope.OtovriPas = function () {

        $scope.EditPas = true;
        $scope.apply;
    }
    


    $scope.AddDriveCustomer = function (drive) {

        //var p = $scope.XCoord1;

        if (document.getElementById("lon").value == null || document.getElementById("lon").value ==""){//drive.XCoord == null || drive.XCoord == "") {
            alert('X coordinate cant be empty!');
            return;
        }
        else if (document.getElementById("lat").value == null || document.getElementById("lat").value == "") {
            alert('Y coordinate cant be empty!');
            return;
        }
        else if (document.getElementById("address").innerHTML == null || document.getElementById("address").innerHTML == "") {
            alert('Street cant be empty!');
            return;
        }
       
        drive.XCoord = document.getElementById("lon").value;
        drive.YCoord = document.getElementById("lat").value;
        drive.Street = document.getElementById("address").innerHTML;

        ProfCont.AddDriveCustomer(drive).then(function (response) {
            if (response.data == true) {
                console.log(response.data);
                $scope.newDrive = response.data;
                //$rootScope.RegisterSuccess = "Registration was successful. You can login now.";
                $window.location.href = "#!/MyHome";
            }
            else {
                alert("Drive does not exist.");
            }
        });

        


    }

    $scope.EditUser = function (user) {

        
        
        if (user.username == null || user.username == "") {
            user.username = $scope.userProfile.UserName;
        }
        if (user.ime == null || user.ime == "") {
            user.ime = $scope.userProfile.Name;
        }
        if (user.prezime == null || user.prezime == "") {
            user.prezime = $scope.userProfile.Surname;
        }
        if (user.pol == null || user.pol == "") {
            user.pol = $scope.userProfile.Gender;
        }
        if (user.jmbg == null || user.jmbg == "") {
            user.jmbg = $scope.userProfile.JMBG;
            
        }
       
        if (user.kontaktTelefon == null || user.kontaktTelefon == "") {
            user.kontaktTelefon = $scope.userProfile.ContactPhoneNumber;
            
        }
        if (user.email == null || user.email == "") {
            user.email = $scope.userProfile.Email;
        }
       
        if (user.pwd == null || user.pwd == "") {
            user.pwd = $scope.userProfile.Password;
        }

        //user.OldUsername = $scope.userProfile.UserName;
        ProfCont.EditUser(user).then(function (response) {
            // if (response.data == true) {
            if (response.data !=3) {
                console.log(response.data);
                //var cookieInfo = document.cookie.substring(5, document.cookie.length);
                //var parsed1 = JSON.parse(cookieInfo)
                document.cookie = "user=" + JSON.stringify({
                    username: user.username, //response.data.UserName,
                    role: response.data, //response.data.Role,
                    nameSurname: user.ime + " " + user.prezime //response.data.Name + " " + response.data.Surname
                }) + ";expires=Thu, 01 Jan 2019 00:00:01 GMT;";

                sessionStorage.setItem("username", user.username);
                sessionStorage.setItem("role", response.data);
                sessionStorage.setItem("nameSurname", user.ime + " " + user.prezime);

                //$rootScope.loggedin = true;
                $rootScope.user.username = sessionStorage.getItem("username");
                $rootScope.user.nameSurname = sessionStorage.getItem("nameSurname");
                   // = {
                //    username: sessionStorage.getItem("username"),
                //    role: sessionStorage.getItem("role"),
                //    nameSurname: sessionStorage.getItem("nameSurname")
                //};


                $window.location.href = "#!/MyHome";
            }
            else {
                alert("Username already exists.");
            }
        });




    }

    $scope.AddDriveDispatcher = function (drive) {

        if (document.getElementById("lon").value == null || document.getElementById("lon").value == "") {//drive.XCoord == null || drive.XCoord == "") {
            alert('X coordinate cant be empty!');
            return;
        }
        else if (document.getElementById("lat").value == null || document.getElementById("lat").value == "") {
            alert('Y coordinate cant be empty!');
            return;
        }
        else if (document.getElementById("address").innerHTML == null || document.getElementById("address").innerHTML == "") {
            alert('Street cant be empty!');
            return;
        }

        drive.XCoord = document.getElementById("lon").value;
        drive.YCoord = document.getElementById("lat").value;
        drive.Street = document.getElementById("address").innerHTML;

        $scope.VoznjaDodavanjeDispecer = drive;

        ProfCont.AddDriveDispatcher(drive).then(function (response) {
            console.log(response.data);
            $scope.ListaNajblizih = response.data;

            if (response.data.length == 0) {
                $scope.prznalista = true;

            }

           // if (response.data == true) {
            
            $scope.najblizivozaci = true;
            $scope.apply;
               // $scope.newDrive = response.data;
               // $window.location.href = "#!/MyHome";
          //  } else {
            //    alert("Drve does not exist.");
          //  }

        });
    }

    $scope.DodajVoznjuKonacno = function (novimodel) {

        if (novimodel == null) {
            alert('Morate da izaberrte slobodnog vozaca.');
            return;
        }

        ProfCont.DodajVoznjuKonacno(novimodel, $scope.VoznjaDodavanjeDispecer).then(function (response) {
            if (response.data == true) {
                console.log(response.data);
                $window.location.href = "#!/MyHome";
            }
            else {
                alert("neuspesno dodavanje voznje.");
            }


        });


    }



    $scope.ChangeDriveCustomer = function (drive) {

        if (drive == null) {
            drive = {};
            drive.tipAuta = $rootScope.VoznjaZaIzmenu.CarType;
        }

        if (drive.tipAuta == null || drive.tipAuta == "") {
            drive.tipAuta = $rootScope.VoznjaZaIzmenu.CarType;
        }

        if (document.getElementById("lon").value == null || document.getElementById("lon").value == "") {
           
            drive.XCoord = $rootScope.VoznjaZaIzmenu.Arrival.X;
        }
        else {
            drive.XCoord = document.getElementById("lon").value;
        }


        if (document.getElementById("lat").value == null || document.getElementById("lat").value == "") {
           
            drive.YCoord = $rootScope.VoznjaZaIzmenu.Arrival.Y;
        }
        else {
            drive.YCoord = document.getElementById("lat").value;
        }


        if (document.getElementById("address").innerText == null || document.getElementById("address").innerText == "") {
       
            drive.Street = $rootScope.VoznjaZaIzmenu.Arrival.Address.AddressFormat;
        }else {
            drive.Street = document.getElementById("address").innerText;
        }

        drive.datum = $rootScope.VoznjaZaIzmenu.DataAndTime;

        ProfCont.ChangeDriveCustomer(drive).then(function (response) {
            if (response.data == true) {
                console.log(response.data);
                // $scope.newDrive = response.data;

                $window.location.href = "#!/MyHome";
            }
            else {
                alert("Drive does not exist.");
            }
        });


    }


    $scope.ChangeLocation = function () {

        drive = {};

        if (document.getElementById("lon").value == null || document.getElementById("lon").value == "" || document.getElementById("lat").value == null || document.getElementById("lat").value == "" || document.getElementById("address").innerText == null || document.getElementById("address").innerText == "") {

            //$window.location.href = "#!/MyHome";
            alert('missing an address or coordinates');
            
        } else {
           
            
            drive.XCoord = document.getElementById("lon").value;
            drive.YCoord = document.getElementById("lat").value;
            drive.Street = document.getElementById("address").innerText;
        }

        

        ProfCont.ChangeLocation(drive).then(function (response) {
            if (response.data == true) {
                console.log(response.data);
                // $scope.newDrive = response.data;

                $window.location.href = "#!/MyHome";
            }
            else {
                alert("Drive does not exist.");
            }
        });


    }


});