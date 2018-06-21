WebAPI.controller('CommentController', function ($scope, $rootScope, LogCont, ProfCont, $window) {

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


});