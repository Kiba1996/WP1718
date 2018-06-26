WebAPI.controller('BlockController', function ($scope, $rootScope, $route, LogCont, ProfCont, $window) {

    if (!$rootScope.loggedin) {
        $window.location.href = "#!/Login";
    }

    if (sessionStorage.getItem("role") != 1) {
        $window.location.href = "#!/MyHome";
    }

    function init() {
        console.log('Block controller initialized');
        $scope.Blokirani = false;
        $scope.Neblokirani = false;
    }

    init();

    $scope.PrikaziBlokirane = function(){

        $scope.Blokirani = true;
        $scope.Neblokirani = false;

        ProfCont.getBlockedUsers().then(function (response) {
            $scope.listaBlokiranih = response.data;
            console.log(response.data);
        });

    }
    $scope.PrikaziNeblokirane = function () {
        $scope.Blokirani = false;
        $scope.Neblokirani = true;

        ProfCont.getUnblockedUsers().then(function (response) {
            $scope.listaNeblokiranih = response.data;
            console.log(response.data);
        });

    }

    $scope.Block = function (korisnickoime) {

        ProfCont.Block(korisnickoime).then(function (response) {
            $scope.listaNeblokiranih = response.data;
            console.log(response.data);
            $scope.apply;
        });

    }
    $scope.Unblock = function (korisnickoime) {

        ProfCont.Unblock(korisnickoime).then(function (response) {
            $scope.listaBlokiranih = response.data;
            console.log(response.data);
            $scope.apply;
        });

    }

});