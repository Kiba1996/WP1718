WebAPI.controller('MyHomeController', function ($scope, $rootScope, LogCont, ProfCont, $route, $window) {

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
            
            LogCont.getDrives(sessionStorage.getItem("username")).then(function (response) {
                $scope.MyDrives = response.data;
                $rootScope.filtriranje = "Your drives"
                $scope.listaFlag = 1; //MD
                $scope.posebanFlag = 2;// !SVE
                $scope.filtFlag = 0; //NOFILT
                $rootScope.DozvolaIzmeniVozKorisnik = false;
                $rootScope.DozvolaZaObradu = false;
                $rootScope.DozvolaZaKomentarKorisnik = false;
                $rootScope.DozvolaZavrsiVoznju = false;
                console.log(response.data);
            });

            ProfCont.getDriverData(sessionStorage.getItem("username")).then(function (response) {

                $scope.DriverData = response.data;

            });

            $rootScope.moraKomentarKorisnik = false;
        });
    }

    init();

    $scope.getDrives1 = function () {
        LogCont.getDrives1(sessionStorage.getItem("username")).then(function (response) {
            //$scope.FilterRez = response.data;
            $scope.AllDrives = response.data;
            $rootScope.filtriranje = "All drives"
            $scope.listaFlag = 2; //AD
            $scope.posebanFlag = 1;// SVE
            $scope.filtFlag = 0; //NOFILT
            

            console.log(response.data);
        });
    }

    $scope.getDrives2 = function () {
        LogCont.getUserStatus(sessionStorage.getItem("username")).then(function (response) {
            if (response.data == true) {
                alert('Your account is blocked.');

                document.cookie = 'user=;expires=Thu, 01 Jan 1970 00:00:01 GMT;';
                sessionStorage.clear();
                $rootScope.loggedin = false;
                $rootScope.user = {};
                document.location.href = "#!/Login";

            }


            LogCont.getDrives2(sessionStorage.getItem("username")).then(function (response) {
                $scope.CreatedDrives = response.data;
                $rootScope.filtriranje = "Drives with created-waiting status"
                $scope.listaFlag = 3; //CD
                $scope.posebanFlag = 3;// !SVE bolje KRE
                $scope.filtFlag = 0; //NOFILT

                console.log(response.data);
            });
        });
    }
    $scope.Sorting = function (Drives, broj) {

        LogCont.getUserStatus(sessionStorage.getItem("username")).then(function (response) {
            if (response.data == true) {
                alert('Your account is blocked.');

                document.cookie = 'user=;expires=Thu, 01 Jan 1970 00:00:01 GMT;';
                sessionStorage.clear();
                $rootScope.loggedin = false;
                $rootScope.user = {};
                document.location.href = "#!/Login";

            }


            ProfCont.Sorting(Drives, broj).then(function (response) {

                console.log(response.data);
                //$scope.FilterRez = response.data;
                $scope.SortedDrives = response.data;
                $scope.listaFlag = 4; //SD

            });
        });
    }


    $scope.Filter = function (Drives, Status) {

        LogCont.getUserStatus(sessionStorage.getItem("username")).then(function (response) {
            if (response.data == true) {
                alert('Your account is blocked.');

                document.cookie = 'user=;expires=Thu, 01 Jan 1970 00:00:01 GMT;';
                sessionStorage.clear();
                $rootScope.loggedin = false;
                $rootScope.user = {};
                document.location.href = "#!/Login";

            }

            if (Status == null || Status == "") {
                alert('If you want to filter then choose an option!');
                return;
            }
            ProfCont.Filter(Drives, Status).then(function (response) {
                console.log(response.data);
                //$scope.FilterRez = response.data;
                $scope.FilteredDrives = response.data;
                $scope.listaFlag = 5; //FD
                //$scope.posebanFlag = 2;// !SVE
                $scope.filtFlag = 1; //FILT

            });
        });
    }

    $scope.Search = function (Drives, su) {

        LogCont.getUserStatus(sessionStorage.getItem("username")).then(function (response) {
            if (response.data == true) {
                alert('Your account is blocked.');

                document.cookie = 'user=;expires=Thu, 01 Jan 1970 00:00:01 GMT;';
                sessionStorage.clear();
                $rootScope.loggedin = false;
                $rootScope.user = {};
                document.location.href = "#!/Login";

            }



            if (su == null) {
                // alert('You cant search!Fill in the search fields.');
                return;
            }
            //if (su.DatumOd > su.DatumDo || su.CenaOd> su.CenaDo || su.OcenaOd > su.OcenaDo) {
            //    alert('Incorrect values in search fields.');
            //    return;
            //}
            //if (su.OcenaOd < 0 || su.OcenaDo < 0 || su.CenaOd < 0 || su.CenDo < 0) {
            //    alert('You cant search negative numbers.');
            //    return;
            //}
            //if(su.VozIme == "") {
            //    su.VozIme = null;
            //}
            //if (su.VozPre == "") {
            //    su.VozPre = null;
            //}
            //if (su.MusIme == "") {
            //    su.MusIme = null;
            //}
            //if (su.MusPre == "") {
            //    su.MusPre = null;
            //}
            if (su.OcenaDo == "") {
                su.OcenaDo = null;
            }
            if (su.OcenaDo != null) {
                if (!/^\d+$/.test(su.OcenaDo)) {
                    alert("Uneta ocena mora biti broj");
                    return;
                }
            }

            if (su.OcenaOd == "") {
                su.OcenaOd = null;
            }
            if (su.OcenaOd != null) {

                if (!/^\d+$/.test(su.OcenaOd)) {
                    alert("Uneta ocena mora biti broj");
                    return;
                }
            }

            if (su.CenaDo == "") {
                su.CenaDo = null;
            }
            if (su.CenaDo != null) {

                if (!/^\d+$/.test(su.CenaDo)) {
                    alert("Uneta cena mora biti broj");
                    return;
                }
            }
            if (su.CenaOd == "") {
                su.CenaOd = null;
            }
            //else {
            if (su.CenaOd != null) {

                if (!/^\d+$/.test(su.CenaOd)) {
                    alert("Uneta cena mora biti broj");
                    return;
                }
            }
            
            if (su.VozIme == "") {
                su.VozIme = null;
            }
            if (su.VozPre == "") {
                su.VozPre = null;
            }
            if (su.MusIme == "") {
                su.MusIme = null;
            }
            if (su.MusPre == "") {
                su.MusPre = null;
            }
            
            //if (document.getElementById("DatumOd").value == "") {
            //    su.DatumDo = null;
            //}
            //if (document.getElementById("DatumOd").nodeValue == "") {
            //    su.DatumOd = null;
            //}
            //su.DatumOd = document.getElementById("DatumOd").value;
            //su.DatumDo = document.getElementById("DatumDo").value;
            ProfCont.Search(Drives, su).then(function (response) {
                console.log(response.data);
                $scope.SearchedDrives = response.data;

                $scope.listaFlag = 6; //FD
                //$scope.posebanFlag = 2;// !SVE
                $scope.filtFlag = 2; //FILT
                //$scope.CD = false;
                //$scope.MD = false;
                //$scope.AD = false;
                //$scope.SD = false;
                //$scope.FD = true;
                //$scope.FILT1 = true;
                //$scope.FILT2 = true;

            });
        });
    }

    $scope.CancelDrive = function (drive) {

        LogCont.getUserStatus(sessionStorage.getItem("username")).then(function (response) {
            if (response.data == true) {
                alert('Your account is blocked.');

                document.cookie = 'user=;expires=Thu, 01 Jan 1970 00:00:01 GMT;';
                sessionStorage.clear();
                $rootScope.loggedin = false;
                $rootScope.user = {};
                document.location.href = "#!/Login";

            }

            ProfCont.CancelDrive(drive).then(function (response) {
                console.log(response.data);
                $rootScope.VoznjaZaKomentar = response.data;
                $rootScope.moraKomentarKorisnik = true;

                $rootScope.DozvolaZaKomentarKorisnik = true;
                $window.location.href = "#!/Comment";

            });
        });
    }
    $scope.ProcessDrive = function (drive) { //,f
        $rootScope.VoznjaZaObradu = drive;
        ProfCont.ProcessDrive(drive).then(function (response) {
            //,f
            
            console.log(response.data);
            if (response.data.length == 0) {
                $rootScope.FlagNemaVozaca = true;
            } else {
                $rootScope.FlagNemaVozaca = false;
            }

            $rootScope.PonudjeniVozaci = response.data;

            $rootScope.DozvolaZaObradu = true;
            $window.location.href = "#!/ObradiVoznju";

            //if ($scope.listaFlag == 1) {
            //    $scope.MyDrives = response.data;
            //    $scope.$evalAsync;//$scope.$apply();
            //}


            //if ($scope.listaFlag == 2) {
            //    $scope.AllDrives = response.data;
            //    $scope.$evalAsync;//$scope.$apply();
            //}

            //if ($scope.listaFlag == 4) {
            //    $scope.SortedDrives = response.data;
            //    $scope.$evalAsync;//$scope.$apply();
            //}

            //if ($scope.listaFlag == 5) {
            //    $scope.FilteredDrives = response.data;
            //    $scope.$evalAsync;//$scope.$apply();
            //}

            //if ($scope.listaFlag == 6) {
            //    $scope.SearchedDrives = response.data;
            //    $scope.$evalAsync;//$scope.$apply();
            //}


           
        });
       
    }


    $scope.AcceptDrive = function (drive, f) {

        LogCont.getUserStatus(sessionStorage.getItem("username")).then(function (response) {
            if (response.data == true) {
                alert('Your account is blocked.');

                document.cookie = 'user=;expires=Thu, 01 Jan 1970 00:00:01 GMT;';
                sessionStorage.clear();
                $rootScope.loggedin = false;
                $rootScope.user = {};
                document.location.href = "#!/Login";

            }


            ProfCont.AcceptDrive(drive, f).then(function (response) {
                console.log(response.data);

                $scope.DriverData.zauzet = true;

                if ($scope.listaFlag == 4) {
                    $scope.SortedDrives = response.data;
                    //$scope.$apply();
                    $scope.$evalAsync;
                }


                if ($scope.listaFlag == 6) {
                    $scope.SearchedDrives = response.data;
                    //$scope.$apply();
                    $scope.$evalAsync;
                }

                if ($scope.listaFlag == 3) {
                    $scope.CreatedDrives = response.data;
                    //$scope.$apply();
                    $scope.$evalAsync;
                }
                $scope.$evalAsync;//$apply();

            });
        });
    }



    $scope.EndDrive = function (drive) {

        LogCont.getUserStatus(sessionStorage.getItem("username")).then(function (response) {
            if (response.data == true) {
                alert('Your account is blocked.');

                document.cookie = 'user=;expires=Thu, 01 Jan 1970 00:00:01 GMT;';
                sessionStorage.clear();
                $rootScope.loggedin = false;
                $rootScope.user = {};
                document.location.href = "#!/Login";

            }


            $rootScope.VoznjaZaKomentarVozac = drive;
            $rootScope.DozvolaZavrsiVoznju = true;
            $window.location.href = "#!/EndDrive";

        });
    }
    $scope.Komentarisi = function (drive) {

        
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
                return;
            }
            $rootScope.DozvolaZaKomentarKorisnik = true;
            $rootScope.VoznjaZaKomentar = drive;
            
            $window.location.href = "#!/Comment";
        });
    }


    $scope.EditDrive = function (drive) {

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
                return;
            }

            $rootScope.VoznjaZaIzmenu = drive;
            $rootScope.DozvolaIzmeniVozKorisnik = true;
            $window.location.href = "#!/EditDrive";
        });
    }

    $scope.PromeniLokaciju = function () {

        LogCont.getUserStatus(sessionStorage.getItem("username")).then(function (response) {
            if (response.data == true) {
                alert('Your account is blocked.');

                document.cookie = 'user=;expires=Thu, 01 Jan 1970 00:00:01 GMT;';
                sessionStorage.clear();
                $rootScope.loggedin = false;
                $rootScope.user = {};
                document.location.href = "#!/Login";

            }


            $rootScope.driverpodaci = $scope.DriverData;
            $window.location.href = "#!/ChangeLocation";
        });
    }

});
