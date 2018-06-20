WebAPI.controller('MyHomeController', function ($scope, $rootScope, LogCont, ProfCont, $window) {

    if (!$rootScope.loggedin) {
        $window.location.href = "#!/Login";
    }

    function init() {
       
        LogCont.getDrives(sessionStorage.getItem("username")).then(function (response) {
            $scope.MyDrives = response.data;
            $rootScope.filtriranje = "Your drives"
            $scope.MD = true;
            $scope.AD = false;
            $scope.CD = false;
            $scope.SD = false;
            $scope.FD = false;
            $scope.SVE = false;
            $scope.FILT1 = false;
            $scope.FILT2 = false;
            console.log(response.data);
        });
    }

    init();

    $scope.getDrives1 = function () {
        LogCont.getDrives1(sessionStorage.getItem("username")).then(function (response) {
            //$scope.FilterRez = response.data;
            $scope.AllDrives = response.data;
            $rootScope.filtriranje = "All drives"
            $scope.AD = true;
            $scope.MD = false;
            $scope.CD = false;
            $scope.SD = false;
            $scope.FD = false;
            $scope.SVE = true;
            $scope.FILT1 = false;
            $scope.FILT2 = false;
            //$scope.F = true;
            console.log(response.data);
        });
    }

    $scope.getDrives2 = function () {
        LogCont.getDrives2(sessionStorage.getItem("username")).then(function (response) {
            $scope.CreatedDrives = response.data;
            $rootScope.filtriranje = "Drives with created-waiting status"
            $scope.CD = true;
            $scope.MD = false;
            $scope.AD = false;
            $scope.SD = false;
            $scope.FD = false;
            $scope.SVE = false;

            $scope.FILT1 = false;
            $scope.FILT2 = false;
            console.log(response.data);
        });
    }
    $scope.Sorting = function (Drives) {
        ProfCont.Sorting(Drives).then(function (response) {

            console.log(response.data);
            //$scope.FilterRez = response.data;
            $scope.SortedDrives = response.data;
            $scope.CD = false;
            $scope.MD = false;
            $scope.AD = false;
            $scope.SD = true;
            $scope.FD = false;
            //$scope.F = true;
        });
    }


    $scope.Filter = function (Drives, Status) {
        if (Status == null || Status == "") {
            alert('If you want to filter then choose an option!');
            return;
        }
        ProfCont.Filter(Drives,Status).then(function (response) {
            console.log(response.data);
            //$scope.FilterRez = response.data;
            $scope.FilteredDrives = response.data;
            $scope.CD = false;
            $scope.MD = false;
            $scope.AD = false;
            $scope.SD = false;
            $scope.FD = true;
            $scope.FILT1 = true;
            $scope.FILT2 = true;
            //$scope.F = true;
        });
    }


});
