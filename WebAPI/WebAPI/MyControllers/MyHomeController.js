WebAPI.controller('MyHomeController', function ($scope, $rootScope, LogCont, $window) {

    if (!$rootScope.loggedin) {
        $window.location.href = "#!/Login";
    }

    function init() {
        LogCont.getDrives(sessionStorage.getItem("username")).then(function (response) {
            $scope.Drives = response.data;
            console.log(response.data);
        });
    }

    init();

});

