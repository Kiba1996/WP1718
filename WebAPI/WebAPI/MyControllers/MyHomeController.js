WebAPI.controller('MyHomeController', function ($scope, $rootScope, $route, LogCont, ProfCont, $window) {

    if (!$rootScope.loggedin) {
        $window.location.href = "#!/Login";
    }

    function init() {

        LogCont.getDrives(sessionStorage.getItem("username")).then(function (response) {
            $scope.MyDrives = response.data;
            $rootScope.filtriranje = "Your drives"
            $scope.listaFlag = 1; //MD
            $scope.posebanFlag = 2;// !SVE
            $scope.filtFlag = 0; //NOFILT
            //$scope.MD = true;
            //$scope.AD = false;
            //$scope.CD = false;
            //$scope.SD = false;
            //$scope.FD = false;
            //$scope.SVE = false;

            //$scope.FILT1 = false;
            //$scope.FILT2 = false;
            console.log(response.data);
        });

        ProfCont.getDriverData(sessionStorage.getItem("username")).then(function (response) {

            $scope.DriverData = response.data;

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
            //$scope.AD = true;
            //$scope.MD = false;
            //$scope.CD = false;
            //$scope.SD = false;
            //$scope.FD = false;
            //$scope.SVE = true;
            //$scope.FILT1 = false;
            //$scope.FILT2 = false;
            
            console.log(response.data);
        });
    }

    $scope.getDrives2 = function () {
        LogCont.getDrives2(sessionStorage.getItem("username")).then(function (response) {
            $scope.CreatedDrives = response.data;
            $rootScope.filtriranje = "Drives with created-waiting status"
            $scope.listaFlag = 3; //CD
            $scope.posebanFlag = 3;// !SVE bolje KRE
            $scope.filtFlag = 0; //NOFILT
            //$scope.CD = true;
            //$scope.MD = false;
            //$scope.AD = false;
            //$scope.SD = false;
            //$scope.FD = false;
            //$scope.SVE = false;

            //$scope.FILT1 = false;
            //$scope.FILT2 = false;
            console.log(response.data);
        });
    }
    $scope.Sorting = function (Drives,broj) {
        ProfCont.Sorting(Drives,broj).then(function (response) {

            console.log(response.data);
            //$scope.FilterRez = response.data;
            $scope.SortedDrives = response.data;
            $scope.listaFlag = 4; //SD
            //$scope.posebanFlag = 2;// !SVE
            //$scope.filtFlag = 0; //NOFILT
            //$scope.CD = false;
            //$scope.MD = false;
            //$scope.AD = false;
            //$scope.SD = true;
            //$scope.FD = false;
        });
    }


    $scope.Filter = function (Drives, Status) {
        if (Status == null || Status == "") {
            alert('If you want to filter then choose an option!');
            return;
        }
        ProfCont.Filter(Drives,Status).then(function (response) {
            console.log(response.data);
            //$scope.FilterRez = response.data;
            $scope.FilteredDrives = response.data;
            $scope.listaFlag = 5; //FD
            //$scope.posebanFlag = 2;// !SVE
            $scope.filtFlag = 1; //FILT
            //$scope.CD = false;
            //$scope.MD = false;
            //$scope.AD = false;
            //$scope.SD = false;
            //$scope.FD = true;
            //$scope.FILT1 = true;
            //$scope.FILT2 = true;
           
        });
    }

    $scope.Search = function (Drives, su) {
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
        if (su.OcenaOd == "") {
            su.OcenaOd = null;
        }
        if (su.CenaDo == "") {
            su.CenaDo = null;
        }
        if (su.CenaOd == "") {
            su.CenaDo = null;
        }
        //else {
        if (su.OcenaDo != null) {
            if (!/^\d+$/.test(su.OcenaDo)) {
                alert("Uneta ocena mora biti broj");
                return;
            }
        }
        if (su.OcenaOd != null) {
        //    su.OcenaOd = null;
        //}
        //else {
            if (!/^\d+$/.test(su.OcenaOd)) {
                alert("Uneta ocena mora biti broj");
                return;
            }
        }
        if (su.CenaDo != null) {
        //    su.CenaDo = null;
        //}
        //else {
            if (!/^\d+$/.test(su.CenaDo)) {
                alert("Uneta cena mora biti broj");
                return;
            }
        }
        if (su.CenaOd != null) {
        //    su.CenaOd = null;
        //}
        //else {
            if (!/^\d+$/.test(su.CenaOd)) {
                alert("Uneta cena mora biti broj");
                return;
            }
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
    }

    $scope.CancelDrive = function (drive) {
       
        ProfCont.CancelDrive(drive).then(function (response) {
            console.log(response.data);
            $rootScope.VoznjaZaKomentar = response.data;
            $window.location.href = "#!/Comment";

        });
    }
    $scope.ProcessDrive = function (drive,f) {

        ProfCont.ProcessDrive(drive,f).then(function (response) {
            console.log(response.data);

            if ($scope.listaFlag == 1) {
                $scope.MyDrives = response.data;
                $scope.$evalAsync;//$scope.$apply();
            }


            if ($scope.listaFlag == 2) {
                $scope.AllDrives = response.data;
                $scope.$evalAsync;//$scope.$apply();
            }

            if ($scope.listaFlag == 4) {
                $scope.SortedDrives = response.data;
                $scope.$evalAsync;//$scope.$apply();
            }

            if ($scope.listaFlag == 5) {
                $scope.FilteredDrives = response.data;
                $scope.$evalAsync;//$scope.$apply();
            }

            if ($scope.listaFlag == 6) {
                $scope.SearchedDrives = response.data;
                $scope.$evalAsync;//$scope.$apply();
            }


            //$rootScope.VoznjaZaKomentar = response.data;
            //$window.location.href = "#!/MyHome";
            //$window.location.refresh();
            //if (response.data) {
            //    $route.reload();
            //}
            //if (f == 1) {
            //    $scope.MyDrives = response.data;
            //}
            //if (f == 2) {
            //    $scope.AllDrives = response.data;
            //}
            //if (f == 4) {
            //    $scope.AllDrives = response.data;
            //}
           
        });
    }

    
    $scope.AcceptDrive = function (drive, f) {

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
    }


    
    $scope.EndDrive = function (drive) {
        
        $rootScope.VoznjaZaKomentarVozac = drive;
        $window.location.href = "#!/EndDrive";

        
    }
    $scope.Komentarisi = function (drive) {

        if (drive == null) {
            return;
        }

        $rootScope.VoznjaZaKomentar = drive;

        $window.location.href = "#!/Comment";
    }

});
