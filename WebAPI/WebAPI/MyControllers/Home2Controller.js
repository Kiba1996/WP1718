WebAPI.controller('Home2Controller', function ($scope, $rootScope, LogCont, ProfCont, $window) {

    if (!$rootScope.loggedin) {
        $window.location.href = "#!/Login";
    }

    function init() {
        LogCont.getDrives1(sessionStorage.getItem("username")).then(function (response) {
            $scope.Drives = response.data;
            $rootScope.filtriranje = "All drives"
            $scope.S = true;
            console.log(response.data);
        });
    }

    init();

    //$scope.Filter2 = function (fu) {

    //    ProfCont.Filter2(fu).then(function (response) {
    //        console.log(response.data);
    //        $scope.FilterRez = response.data;

    //    });

    //}

});

