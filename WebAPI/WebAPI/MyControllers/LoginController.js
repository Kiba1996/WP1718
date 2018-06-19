WebAPI.controller('LoginController', function ($scope, LogCont, $window, $rootScope) {

    $scope.user = {};


    function init() {
        console.log('Login controller initialized');
    };

    init();

    $scope.RegisterUser = function (user) {

        if (user.username == null || user.username == "") {
            alert('Username field cant be empty!');
            return;
        }
        else if (user.ime == null || user.ime == "") {
            alert('Name field cant be empty!');
            return;
        }
        else if (user.prezime == null || user.prezime == "") {
            alert('Surname field cant be empty !');
            return;
        }
        else if (user.pol == null || user.pol == "") {
            alert('You must choose a gender!');
            return;
        }
        else if (user.jmbg == null || user.jmbg == "") {
            alert('Jmbg field cant be empty!');
            return;
        }
        else if (user.jmbg.match(/[a-z]/i)) {
            alert('Jmbg cant contain characters: a-z');
            return;
        }
        else if (user.jmbg.length != 13) {
            alert('Jmbg must contain 13 numbers');
            return;
        }
        else if (user.kontaktTelefon == null || user.kontaktTelefon == "") {
            alert('Phone number cant be empty!');
            return;
        }
        
        else if (user.kontaktTelefon.match(/[a-z]/i)) {
            alert('Phone number cant contain characterse a-z');
            return;
        }
        else if (user.email == null || user.email == "") {
            alert('Email field cant be empty!');
            return;
        }
        else if (!user.email.includes('@')) {
            alert('Email is not valid!');
            return;
        }
        else if (user.pwd == null || user.pwd == "") {
            alert('Password cant be empty!');
            return;
        }
        
        LogCont.RegisterUser(user).then(function (response) {
            if (response.data == true) {
                console.log(response.data);
                $rootScope.RegisterSuccess = "Registration was successful. You can login now.";
                $window.location.href = "#!/Login";
            }
            else {
                alert("Username already exists, try again.");
            }
        });
    };

    $scope.LoginUser = function (user) {
        if (user.username == null || user.username == "") {
            alert('Username cant be empty!');
            return;
        }
        else if (user.pwd == null || user.pwd == "") {
            alert('Password cant be empty!');
            return;
        }

        LogCont.LoginUser(user).then(function (response) {
            if (response.data == null) {
                alert("User with the given username and password does not exist.");
            }
            else {
                console.log(response);
                document.cookie = "user=" + JSON.stringify({
                    username: response.data.UserName,
                    role: response.data.Role,
                    nameSurname: response.data.Name + " " + response.data.Surname
                }) + ";expires=Thu, 01 Jan 2019 00:00:01 GMT;";
                sessionStorage.setItem("username", response.data.UserName);
                sessionStorage.setItem("role", response.data.Role);
                sessionStorage.setItem("nameSurname", response.data.Name + " " + response.data.Surname);

                $rootScope.loggedin = true;
                $rootScope.user = {
                    username: sessionStorage.getItem("username"),
                    role: sessionStorage.getItem("role"),
                    nameSurname: sessionStorage.getItem("nameSurname")
                };
                $window.location.href = "#!/";
            }
        });
    }



    $scope.RegisterDriver = function (user) {

        if (user.username == null || user.username == "") {
            alert('Username field cant be empty!');
            return;
        }
        else if (user.ime == null || user.ime == "") {
            alert('Name field cant be empty!');
            return;
        }
        else if (user.prezime == null || user.prezime == "") {
            alert('Surname field cant be empty !');
            return;
        }
        else if (user.pol == null || user.pol == "") {
            alert('You must choose a gender!');
            return;
        }
        else if (user.jmbg == null || user.jmbg == "") {
            alert('Jmbg field cant be empty!');
            return;
        }
        else if (user.jmbg.match(/[a-z]/i)) {
            alert('Jmbg cant contain characters: a-z');
            return;
        }
        else if (user.jmbg.length != 13) {
            alert('Jmbg must contain 13 numbers');
            return;
        }
        else if (user.kontaktTelefon == null || user.kontaktTelefon == "") {
            alert('Phone number cant be empty!');
            return;
        }

        else if (user.kontaktTelefon.match(/[a-z]/i)) {
            alert('Phone number cant contain characterse a-z');
            return;
        }
        else if (user.email == null || user.email == "") {
            alert('Email field cant be empty!');
            return;
        }
        else if (!user.email.includes('@')) {
            alert('Email is not valid!');
            return;
        }
        else if (user.pwd == null || user.pwd == "") {
            alert('Password cant be empty!');
            return;
        }
        else if (user.reg == null || user.reg == "") {
            alert('Registration number cant be empty!');
            return;
        }
        else if (user.year == null || user.year == "") {
            alert('Year cant be empty!');
            return;
        }
        else if (user.tipV == null || user.tipV == "") {
            alert('Car type cant be empty!');
            return;
        }

        LogCont.RegisterDriver(user).then(function (response) {
            if (response.data == true) {
                console.log(response.data);
                $rootScope.RegisterSuccess = "Registration was successful. You can login now.";
                $window.location.href = "#!/MyHome";
            }
            else {
                alert("Registration number or username already exists, try again.");
            }
        });
    };




});