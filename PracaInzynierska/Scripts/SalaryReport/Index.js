function SalaryModel() {
    var self = this;
    self.workerList = ko.observableArray([]);
    self.Name = ko.observable("Mateusz");
    self.userSalaryList = ko.observableArray([]);
    self.salaryVisibility = ko.observable(false);
    self.workerListVisibility = ko.observable(true);
    self.workerName = ko.observable('');
    self.workerSurname = ko.observable('');
    self.workerID = ko.observable('');
    self.ReturnToList = function ()
    {
        self.salaryVisibility(false);
        self.workerListVisibility(true);
    }
    self.SalaryList = function(item)
    {
        self.workerID = item.WorkerId;
        $.ajax({
            type: "POST",
            cahce: false,
            url: '/SalaryReport/UserSalaryList',
            dataType: "json",
            data: {
                '__RequestVerificationToken' : $("input[name=__RequestVerificationToken]").val(),
                'WorkerId' : item.WorkerId
            },
            success: function (result) {
                self.salaryVisibility(true);
                self.workerListVisibility(false);
                self.userSalaryList(result);
                self.workerName(item.Name);
                self.workerSurname(item.Surname);
            },
            error: function (errjqXHR, errtextStatus, errerrorThrown) {
                alert(errtextStatus + " | " + errerrorThrown + " | " + errjqXHR.responseText);
            }
        });
    }

    self.List = function () {
        $.ajax({
            type: "GET",
            cahce: false,
            url: '/SalaryReport/WorkerList',
            dataType: "json",
            success: function (result) {
                self.workerList(result);
            },
            error: function (errjqXHR, errtextStatus, errerrorThrown) {
                alert(errtextStatus + " | " + errerrorThrown + " | " + errjqXHR.responseText);
            }
        });
    }

    self.Add = function () {
        $.ajax({
            type: "POST",
            cahce: false,
            url: '/SalaryReport/Add',
            dataType: "json",
            data: {
                '__RequestVerificationToken': $("input[name=__RequestVerificationToken]").val(),
                'WorkerId': self.workerID,
                'CountingStartTime': $('#countingStartTime').val(),
                'CountingEndTime': $('#countingEndTime').val(),
                'Salary': $('#salary').val(),
                'Bonus': $('#bonus').val()

            },
            success: function (result) {
                self.List();
            },
            error: function (errjqXHR, errtextStatus, errerrorThrown) {
                alert(errtextStatus + " | " + errerrorThrown + " | " + errjqXHR.responseText);
            }
        });
    }

    self.Remove = function (item) {
        $.ajax({
            type: "POST",
            cahce: false,
            url: '/SalaryReport/Remove',
            dataType: "json",
            data: {
                '__RequestVerificationToken': $("input[name=__RequestVerificationToken]").val(),
                'salaryReportId': item.SalaryReportId
            },
            success: function (result) {
                self.List();
            },
            error: function (errjqXHR, errtextStatus, errerrorThrown) {
                alert(errtextStatus + " | " + errerrorThrown + " | " + errjqXHR.responseText);
            }
        });
    }
}
    

