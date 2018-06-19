﻿WebAPI.controller('FilterController', function ($scope, $rootScope, $routeParams,ProfCont, LogCont, $window) {

    if (!$rootScope.loggedin) {
        $window.location.href = "#!/Login";
    }

    function init() {
        ProfCont.Filter($routeParams.Stat).then(function (response) {
            
            console.log(response.data);
            $scope.FilterRez = response.data;
           
        });
    }

    init();

});