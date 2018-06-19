WebAPI.controller('Filter2Controller', function ($scope, $rootScope, $routeParams, ProfCont, LogCont, $window) {

    if (!$rootScope.loggedin) {
        $window.location.href = "#!/Login";
    }

    function init() {
        ProfCont.Filter2($routeParams.Stat).then(function (response) {
            
            console.log(response.data);
            $scope.FilterRez2 = response.data;
            $scope.S = true;
           
        });
    }

    init();

   

});