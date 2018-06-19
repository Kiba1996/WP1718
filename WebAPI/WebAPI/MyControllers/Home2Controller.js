WebAPI.controller('Home2Controller', function ($scope, $rootScope, LogCont, $window) {

    if (!$rootScope.loggedin) {
        $window.location.href = "#!/Login";
    }

    function init() {
        LogCont.getDrives1(sessionStorage.getItem("username")).then(function (response) {
            $scope.Drives = response.data;
            $rootScope.filtriranje = "All drives"
            console.log(response.data);
        });
    }

    init();

});

