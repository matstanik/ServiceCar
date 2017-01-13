function Models() {
    var self = this;
    self.sexsList = ko.observableArray(['Mężczyzna', 'Kobieta']);
    self.clientList = ko.observableArray([]);
    self.carList = ko.observableArray([]);
    self.partsList = ko.observableArray([]);
    self.carInfo = ko.observableArray([]);
    self.service = ko.observableArray([]);
    self.servicesId = ko.observableArray([]);
    self.clientOrders = ko.observableArray([]);
    self.carId = ko.observable(0);
    self.model = ko.observable('');
    self.brand = ko.observable('');
    self.type = ko.observable('');
    self.capacity = ko.observable('');
    self.engineType = ko.observable('');
    self.bornYear = ko.observable('');
    self.addCarVisible = ko.observable(false);
    self.makeAnOrder = ko.observable(false);
    self.description = ko.observable('');
    self.startDate = ko.observable('');
    self.endDate = ko.observable('');
    self.myDate = ko.observable('');
    self.comments = ko.observable('');

    self.CloseAddCar = function () {
        self.addCarVisible(false);
    }
    
    self.CloseMakeOrder = function () {
        self.makeAnOrder(false);
    }
    
    self.OrdersList = function () {
        $.ajax({
            type: "GET",
            cahce: false,
            url: '/Order/ShowOrdersForClient',
            dataType: "json",
            success: function (result) {
                self.clientOrders(result);
            },
            error: function (errjqXHR, errtextStatus, errerrorThrown) {
                alert(errtextStatus + " | " + errerrorThrown + " | " + errjqXHR.responseText);
            }
        });
    }


    self.ClientList = function ()
    {
        $.ajax({
            type: "GET",
            cahce: false,
            url: '/Client/ClientList',
            dataType: "json",
            success: function (result) {
                self.clientList(result);
            },
            error: function (errjqXHR, errtextStatus, errerrorThrown) {
                alert(errtextStatus + " | " + errerrorThrown + " | " + errjqXHR.responseText);
            }
        });
    }
    
    
    self.AddClient = function () {
        $.ajax({
            type: "POST",
            cahce: false,
            url: '/Client/AddClient',
            dataType: "json",
            data: {
                '__RequestVerificationToken': $("input[name=__RequestVerificationToken]").val(),
                'Name': $('#name').val(),
                'Surname': $('#surname').val(),
                'Sex': $('#sex').val(),
                'PhoneNumber': $('#phoneNumber').val(),
                'City': $('#city').val(),
                'PostalCodeNumber': $('#postalCode').val(),
                'StreetName': $('#street').val(),
                'HouseNumber': $('#houseNumber').val(),
                'CompanyName': $('#companyName').val(),
                'NIP': $('#nip').val(),
                'Email': $('#email').val(),
                'Password': $('#password').val()
            },
            success: function (result) {
                $('#addClient').modal('hide');
                self.ClientList();
            },
            error: function (errjqXHR, errtextStatus, errerrorThrown) {
                alert(errtextStatus + " | " + errerrorThrown + " | " + errjqXHR.responseText);
            }
        });
    }

    self.AddCarVisibility = function () {
        self.addCarVisible(true);
        self.List();
        $('#Brand').val(item.Brand);
        $('#Model').val(item.Model);
        $('#Type').val(item.Type);
        $('#Capacity').val(item.Capacity);
        $('#EngineType').val(item.EngineType);
        $('#BornYear').val(item.BornYear);
    }    

    self.List = function () {
        $.ajax({
            type: "GET",
            cahce: false,
            url: '/Client/CarsList',
            dataType: "json",
            success: function (result) {
                self.carList(result);
            },
            error: function (errjqXHR, errtextStatus, errerrorThrown) {
                alert(errtextStatus + " | " + errerrorThrown + " | " + errjqXHR.responseText);
            }
        });
    }

    self.PartsList = function () {
        $.ajax({
            type: "GET",
            cahce: false,
            url: '/Part/PartsList',
            dataType: "json",
            success: function (result) {
                self.partsList(result);
            },
            error: function (errjqXHR, errtextStatus, errerrorThrown) {
                alert(errtextStatus + " | " + errerrorThrown + " | " + errjqXHR.responseText);
            }
        });
    }
    
    self.AddCar = function () {
        $.ajax({
            type: "POST",
            cahce: false,
            url: '/Client/AddCarToDb',
            dataType: "json",
            data: {
                '__RequestVerificationToken': $("input[name=__RequestVerificationToken]").val(),
                'Brand': $('#Brand').val(),
                'Model': $('#Model').val(),
                'Type': $('#Type').val(),
                'Capacity': $('#Capacity').val(),
                'EngineType': $('#EngineType').val(),
                'BornYear': $('#BornYear').val()
            },
            success: function (result) {
                self.addCarVisible(false);
                self.carInfo(result);
                self.List();
            },
            error: function (errjqXHR, errtextStatus, errerrorThrown) {
                alert(errtextStatus + " | " + errerrorThrown + " | " + errjqXHR.responseText);
            }
        });
    }

    self.AddOrder = function (item) {
        self.makeAnOrder(true);
        self.brand(item.Brand)
        self.model(item.Model);
        self.type(item.Type);
        self.capacity(item.Capacity);
        self.engineType(item.EngineType);
        self.bornYear(item.BornYear);
        self.carId(item.CarId);
        self.PartsList();
        $('#startDate').val('');
        $('#endDate').val('');
        self.service([]);
        self.servicesId([]);
    }

    self.SelectService = function () {
        self.servicesId.push($('#services').val());
        $.ajax({
            type: "POST",
            cahce: false,
            url: '/Service/FindServiceItem',
            dataType: "json",
            data: {
                '__RequestVerificationToken': $("input[name=__RequestVerificationToken]").val(),
                'id': $('#services').val()
            },
            success: function (result) {
                //self.service.push($('#services').val());
                self.service.push(result.Description);
            },
            error: function (errjqXHR, errtextStatus, errerrorThrown) {
                alert(errtextStatus + " | " + errerrorThrown + " | " + errjqXHR.responseText);
            }
        });
    } 
    self.MakeOrder = function () {
        self.convertDate();
    }
    self.convertDate = function () {
        //alert($("#startDate").val());
        self.startDate($("#startDate").val());
        self.endDate($("#endDate").val());
        //var date = new Date($("#startDate").val());
        //var day = date.getDate();
        //var month = date.getMonth();
        //var year = date.getFullYear();

        //self.startDate(year + '-' + month + '-' + day);
        self.SendOrder();
    }
    self.SendOrder = function () {
        $.ajax({
            type: "POST",
            cahce: false,
            url: '/Order/MakeOrder',
            dataType: "json",
            data: {
                '__RequestVerificationToken': $("input[name=__RequestVerificationToken]").val(),
                'carId': self.carId,
                'comments': $('#comments').val(),
                'servicesId': self.servicesId(),
                'StartRepair': $('#startDate').val(),
                'EndOfRepair': $('#endDate').val(),
                'Milage' : $('#milage').val()
            },
            success: function (result) {                
                if (result == 1)
                {
                    AlertWarningShow("<h1><br>Wystąpił błąd!<br></h1>", "<br>Error</br>");
                }
                else
                {
                    self.makeAnOrder(false);
                    AlertWarningShow("<h1><br>Dodano zlecenie!<br></h1>", "<br>Sukces</br>");
                }
            },
            error: function (errjqXHR, errtextStatus, errerrorThrown) {
                alert(errtextStatus + " | " + errerrorThrown + " | " + errjqXHR.responseText);
            }
        });
    }
    
}
function AlertWarningShow(content, title) {
    if (title == null) title = 'Warning';
    $('#divAlert').attr('class', 'alert alert-warning text-center');
    $('#butAlertClose').attr('class', 'btn btn-sm btn-warning');

    $('#strongAlertTitle').html(title);
    $('#spanAlertContent').html(content);

    $('#divAlert').show();
}
