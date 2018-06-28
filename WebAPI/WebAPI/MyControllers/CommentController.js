WebAPI.controller('CommentController', function ($scope, $rootScope, LogCont, ProfCont, $window) {

    if (!$rootScope.loggedin) {
        $window.location.href = "#!/Login";
    }


    function init() {


        LogCont.getUserStatus(sessionStorage.getItem("username")).then(function (response) {
            if (response.data == true) {
                alert('Your account is blocked.');

                document.cookie = 'user=;expires=Thu, 01 Jan 1970 00:00:01 GMT;';
                sessionStorage.clear();
                $rootScope.loggedin = false;
                $rootScope.user = {};
                document.location.href = "#!/Login";

            }

            $rootScope.moraKomentar = false;
           // $rootScope.moraKomentarKorisnik = false;
            $scope.PokaziUspesna = false;
            $scope.PokaziNeuspesna = false;
        });
    }

    init();

    $scope.Commenting = function (ko) {

        LogCont.getUserStatus(sessionStorage.getItem("username")).then(function (response) {
            if (response.data == true) {
                alert('Your account is blocked.');

                document.cookie = 'user=;expires=Thu, 01 Jan 1970 00:00:01 GMT;';
                sessionStorage.clear();
                $rootScope.loggedin = false;
                $rootScope.user = {};
                document.location.href = "#!/Login";

            }

            

            if (ko == null) {
                alert('Niste uneli komentar.');
                return;
            }
            if (ko.Opis == "") {
                ko.Opis = null;
            }
            if ($rootScope.moraKomentarKorisnik == true) {
                ko.Ocena = "0";
                if (ko.Opis == null) {
                    alert('Niste uneli komentar.');
                    return;
                }
            }
            if ($rootScope.moraKomentarKorisnik == false) {

                if (ko.Ocena == "") {
                    ko.Ocena = null;
                }
                if (ko.Ocena == null && ko.Opis == null) {
                    alert('Niste uneli komentar.');
                    return;
                }
                if (ko.Ocena != "1" && ko.Ocena != "2" && ko.Ocena != "3" && ko.Ocena != "4" && ko.Ocena != "5") {
                    alert('Rating takes value from 1-5!');
                    return;
                }
               
            }
           

          


            ProfCont.Commenting(ko, $rootScope.VoznjaZaKomentar).then(function (response) {
                console.log(response.data);
               // $rootScope.VoznjaZaKomentar = response.data;
                $rootScope.moraKomentarKorisnik = false;
                $rootScope.$apply;
                $window.location.href = "#!/MyHome";

            });
        });
    }
    $scope.VozUsp = function () {

        LogCont.getUserStatus(sessionStorage.getItem("username")).then(function (response) {
            if (response.data == true) {
                alert('Your account is blocked.');

                document.cookie = 'user=;expires=Thu, 01 Jan 1970 00:00:01 GMT;';
                sessionStorage.clear();
                $rootScope.loggedin = false;
                $rootScope.user = {};
                document.location.href = "#!/Login";

            }


            $scope.PokaziUspesna = true;
            $scope.PokaziNeuspesna = false;
            $scope.PokaziUspesna.$evalAsync; //////////////////////////
            $rootScope.moraKomentar = false;
            $rootScope.$apply
        });
    }

    $scope.VozNeusp = function () {

        LogCont.getUserStatus(sessionStorage.getItem("username")).then(function (response) {
            if (response.data == true) {
                alert('Your account is blocked.');

                document.cookie = 'user=;expires=Thu, 01 Jan 1970 00:00:01 GMT;';
                sessionStorage.clear();
                $rootScope.loggedin = false;
                $rootScope.user = {};
                document.location.href = "#!/Login";

            }

            $scope.PokaziNeuspesna = true;
            $scope.PokaziUspesna = false;
           
            $scope.$apply;//$evalAsync;//$apply();
            $rootScope.moraKomentar = true;
            $rootScope.$apply;
        });
    }


    $scope.Comment = function (ko) {


        LogCont.getUserStatus(sessionStorage.getItem("username")).then(function (response) {
            if (response.data == true) {
                alert('Your account is blocked.');

                document.cookie = 'user=;expires=Thu, 01 Jan 1970 00:00:01 GMT;';
                sessionStorage.clear();
                $rootScope.loggedin = false;
                $rootScope.user = {};
                document.location.href = "#!/Login";

            }




            if (ko == null || ko.Opis == "" || ko.Opis == null) {
                alert('Niste uneli komentar.')
                return;
            }


            ProfCont.Comment(ko, $rootScope.VoznjaZaKomentarVozac).then(function (response) {
                console.log(response.data);
                $rootScope.moraKomentar = false;
                $rootScope.$apply;
                // $rootScope.VoznjaZaKomentar = response.data;
                $window.location.href = "#!/MyHome";

            });

        });
    }

    $scope.SuccessDrive = function (drive) {


        LogCont.getUserStatus(sessionStorage.getItem("username")).then(function (response) {
            if (response.data == true) {
                alert('Your account is blocked.');

                document.cookie = 'user=;expires=Thu, 01 Jan 1970 00:00:01 GMT;';
                sessionStorage.clear();
                $rootScope.loggedin = false;
                $rootScope.user = {};
                document.location.href = "#!/Login";

            }



            if (drive == null) {
                alert('Morate odabrati lokaciju i upisati cenu.')
                return;
            }
            if (drive.Cena <= 0) {
                alert('Price cant be lower than 0');
                return;
            }
            if (document.getElementById("lon").innerHTML == null || document.getElementById("lon").innerHTML == "") {//drive.XCoord == null || drive.XCoord == "") {
                alert('X coordinate cant be empty!');
                return;
            }
            else if (document.getElementById("lat").innerHTML == null || document.getElementById("lat").innerHTML == "") {
                alert('Y coordinate cant be empty!');
                return;
            }
            else if (document.getElementById("address").innerHTML == null || document.getElementById("address").innerHTML == "") {
                alert('Street cant be empty!');
                return;
            }

            drive.XCoord = document.getElementById("lon").innerHTML;
            drive.YCoord = document.getElementById("lat").innerHTML;
            drive.Street = document.getElementById("address").innerHTML;

            ProfCont.SuccessDrive(drive, $rootScope.VoznjaZaKomentarVozac).then(function (response) {
                console.log(response.data);
                $window.location.href = "#!/MyHome";
            });


        });
    }

});