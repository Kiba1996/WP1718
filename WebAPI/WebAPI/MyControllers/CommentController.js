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

        ProfCont.SuccessDrive(drive, $rootScope.VoznjaZaKomentarVozac).then(function (response) {
            console.log(response.data);
            $window.location.href = "#!/MyHome";
        });
    }

});