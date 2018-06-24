WebAPI.controller('CommentController', function ($scope, $rootScope, LogCont, ProfCont, $window) {

    function init() {
        $scope.PokaziUspesna = false;
        $scope.PokaziNeuspesna = false;
    }

    init();

    $scope.Commenting = function (ko) {

        if (ko == null) {
            return;
        }


        ProfCont.Commenting(ko, $rootScope.VoznjaZaKomentar).then(function (response) {
            console.log(response.data);
           // $rootScope.VoznjaZaKomentar = response.data;
            $window.location.href = "#!/MyHome";

        });

    }
    $scope.VozUsp = function () {

        $scope.PokaziUspesna = true;
        $scope.PokaziNeuspesna = false;
        $scope.PokaziUspesna.$evalAsync; //////////////////////////
    }

    $scope.VozNeusp = function () {

        $scope.PokaziNeuspesna = true;
        $scope.PokaziUspesna = false;
        $scope.$apply;//$evalAsync;//$apply();
    }


    $scope.Comment = function (ko) {

        if (ko == null) {
            return;
        }


        ProfCont.Comment(ko, $rootScope.VoznjaZaKomentarVozac).then(function (response) {
            console.log(response.data);
            // $rootScope.VoznjaZaKomentar = response.data;
            $window.location.href = "#!/MyHome";

        });
    }

    $scope.SuccessDrive = function (drive) {

        if (drive == null) {
            return;
        }
        if (drive.Cena <= 0) {
            alert('Price cant be lower than 0');
            return;
        }
        if (drive.XCoord == "" || drive.YCoord == "" || drive.Street == "" || drive.Number == "" || drive.Number == "" || drive.Town == "" || drive.PostalCode == "") {
            alert('Sva polja moraju biti popunjena');
            return;
        }
        ProfCont.SuccessDrive(drive, $rootScope.VoznjaZaKomentarVozac).then(function (response) {
            console.log(response.data);
            $window.location.href = "#!/MyHome";
        });
    }

});