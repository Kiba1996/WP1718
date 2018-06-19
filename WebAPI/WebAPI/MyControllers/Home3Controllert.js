WebAPI.controller('Home3Controller', function ($scope, $rootScope, LogCont, $window) {

    if (!$rootScope.loggedin) {
        $window.location.href = "#!/Login";
    }

    function init() {
        LogCont.getDrives2(sessionStorage.getItem("username")).then(function (response) {
            $scope.Drives = response.data;
            $rootScope.filtriranje = "Drives with created-waiting status"
            $scope.S = false;
            console.log(response.data);
        });
    }

    init();

});

