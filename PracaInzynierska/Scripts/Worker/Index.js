function Workers() {
    var self = this;
    self.workersList = ko.observableArray([]);
    self.salaryList = ko.observableArray([]);
    self.sexsList = ko.observableArray(['Mężczyzna', 'Kobieta']);
    self.rolesList = ko.observableArray(['Worker', 'Admin']);

    self.List = function () {
        $.ajax({
            type: "GET",
            cahce: false,
            url: '/Worker/showWorker',
            dataType: "json",
            success: function (result) {
                self.workersList(result);
            },
            error: function (errjqXHR, errtextStatus, errerrorThrown) {
                alert(errtextStatus + " | " + errerrorThrown + " | " + errjqXHR.responseText);
            }
        });
    }

    self.AddWorker = function () {
        $.ajax({
            type: "POST",
            cahce: false,
            url: '/Worker/addWorker',
            dataType: "json",
            data: {
                '__RequestVerificationToken': $("input[name=__RequestVerificationToken]").val(),
                'Name': $('#name').val(),
                'Surname': $('#surname').val(),
                'NameRole': $('#role').val(),
                'Sex': $('#sex').val(),
                'PhoneNumber': $('#phoneNumber').val(),
                'City': $('#city').val(),
                'PostalCodeNumber': $('#postalCode').val(),
                'StreetName': $('#street').val(),
                'HouseNumber': $('#houseNumber').val(),
                'PositionName': $('#positionName').val(),
                'DateOfEmployment': $('#employDate').val(),
                'DateOfRelease': $('#releaseDate').val(),
                'Email': $('#email').val(),
                'Password': $('#password').val()
            },
            success: function (result) {
                $('#addWorker').modal('hide');
                self.List();
            },
            error: function (errjqXHR, errtextStatus, errerrorThrown) {
                alert(errtextStatus + " | " + errerrorThrown + " | " + errjqXHR.responseText);
            }
        });
    }

    self.SalaryList = function () {
        $.ajax({
            type: "GET",
            cahce: false,
            url: '/Worker/SalaryList',
            dataType: "json",
            success: function (result) {
                self.salaryList(result);
            },
            error: function (errjqXHR, errtextStatus, errerrorThrown) {
                alert(errtextStatus + " | " + errerrorThrown + " | " + errjqXHR.responseText);
            }
        });
    }
}