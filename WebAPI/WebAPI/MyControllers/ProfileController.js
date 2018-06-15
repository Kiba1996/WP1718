WebAPI.controller('ProfileController', function ($scope, ProfCont, $routeParams) {


    function init() {
        console.log('Profile controller initialized');
     

        ProfCont.getUserByUsername($routeParams.username).then(function (response) {
            console.log(response.data);

            $scope.userProfile = response.data;
          

            });
 
    }

    init();




});