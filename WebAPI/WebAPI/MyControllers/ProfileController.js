WebAPI.controller('ProfileController', function ($scope, ProfCont, $routeParams, $window) {

   
    function init() {
        console.log('Profile controller initialized');
     

        ProfCont.getUserByUsername($routeParams.username).then(function (response) {
            console.log(response.data);

            $scope.userProfile = response.data;
           

            });
 
    }

    init();

    $scope.AddDriveCustomer = function (drive) {

        if (drive.XCoord == null || drive.XCoord == "") {
            alert('X coordinate cant be empty!');
            return;
        }
        else if (drive.YCoord == null || drive.YCoord == "") {
            alert('Y coordinate cant be empty!');
            return;
        }
        else if (drive.Street == null || drive.Street == "") {
            alert('Street cant be empty!');
            return;
        }
        else if (drive.Number == null || drive.Number == "") {
            alert('Number cant be empty!');
            return;
        } else if (drive.Town == null || drive.Town == "") {
            alert('Town cant be empty!');
            return;
        } else if (drive.PostalCode == null || drive.PostalCode == "") {
            alert('Postal code cant be empty!');
            return;
        }


        ProfCont.AddDriveCustomer(drive).then(function (response) {
            if (response.data == true) {
                console.log(response.data);
                $scope.newDrive = response.data;
                //$rootScope.RegisterSuccess = "Registration was successful. You can login now.";
                $window.location.href = "#!/MyHome";
            }
            else {
                alert("Drive does not exist.");
            }
        });

        


    }

    //$scope.EditUser = function (user) {

        
    //    //// $scope.userProfile.Surname;
    //    //if (user.username == null || user.username == "") {
    //    //    user.username = $scope.userProfile.UserName;
    //    //}
    //    //else if (user.ime == null || user.ime == "") {
    //    //    user.ime = $scope.userProfile.Name;
    //    //}
    //    //else if (user.prezime == null || user.prezime == "") {
    //    //    user.prezime = $scope.userProfile.Surname;
    //    //}
    //    //else if (user.pol == null || user.pol == "") {
    //    //    user.pol = $scope.userProfile.Gender;
    //    //}
    //    //else
    //    if (user.jmbg == null || user.jmbg == "") {
    //        user.jmbg = $scope.userProfile.Jmbg;
    //        return;
    //    }
       
    //    else if (user.kontaktTelefon == null || user.kontaktTelefon == "") {
    //        user.kontaktTelefon = $scope.userProfile.ContactPhoneNumber;
    //        return;
    //    }
    //    // else if (user.email == null || user.email == "") {
    //    //    user.email = $scope.userProfile.Email;
    //    //}
       
    //    //else if (user.pwd == null || user.pwd == "") {
    //    //    user.pwd = $scope.userProfile.Password
    //    //}


    //    ProfCont.EditUser(user).then(function (response) {
    //        if (response.data == true) {
    //            console.log(response.data);
    //            //$scope.newDrive = response.data;
    //            //$rootScope.RegisterSuccess = "Editing was successful.";
    //            $window.location.href = "#!/MyHome";
    //        }
    //        else {
    //            alert("Username already exists.");
    //        }
    //    });




    //}

    $scope.AddDriveDispatcher = function (drive) {

        if (drive.XCoord == null || drive.XCoord == "") {
            alert('X coordinate cant be empty!');
            return;
        }
        else if (drive.YCoord == null || drive.YCoord == "") {
            alert('Y coordinate cant be empty!');
            return;
        }
        else if (drive.Street == null || drive.Street == "") {
            alert('Street cant be empty!');
            return;
        }
        else if (drive.Number == null || drive.Number == "") {
            alert('Number cant be empty!');
            return;
        } else if (drive.Town == null || drive.Town == "") {
            alert('Town cant be empty!');
            return;
        } else if (drive.PostalCode == null || drive.PostalCode == "") {
            alert('Postal code cant be empty!');
            return;
        }


        ProfCont.AddDriveDispatcher(drive).then(function (response) {

            if (response.data == true) {
                console.log(response.data);
                $scope.newDrive = response.data;
                $window.location.href = "#!/MyHome";
            } else {
                alert("Drve does not exist.");
            }

        });
    }

});