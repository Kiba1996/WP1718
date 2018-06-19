WebAPI.controller('MyHomeController', function ($scope, $rootScope, LogCont, ProfCont, $window) {

    if (!$rootScope.loggedin) {
        $window.location.href = "#!/Login";
    }

    function init() {
       
        LogCont.getDrives(sessionStorage.getItem("username")).then(function (response) {
            $scope.Drives = response.data;
            $rootScope.filtriranje = "Your drives"
            $scope.S = false;
            console.log(response.data);
        });
    }

    init();



    $scope.Sorting = function () {
        ProfCont.Sorting().then(function (response) {

            console.log(response.data);
            $scope.FilterRez = response.data;
            $scope.S = false;



        });
    }

    //$scope.Filter = function (fu) {

    //  ProfCont.Filter(fu).then(function (response) {
    //        //if (response.data == true) {
    //      console.log(response.data);
    //      $scope.FilterRez = response.data;
    //      $scope.Drives = null;
    //            //$rootScope.RegisterSuccess = "Registration was successful. You can login now.";
    //            //
    //            //$window.location.href = "#!/Filter";
    //        //}
    //        //else {
    //        //    alert("Username already exists, try again.");
    //        //}
    //    });
    //};


});

