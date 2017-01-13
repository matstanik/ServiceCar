function Service() {
    var self = this;
    self.serviceList = ko.observableArray([]);
    self.editResult = ko.observableArray([]);
    self.addService = ko.observable(false);
    self.idService = ko.observable('');
    self.CloseAddService = function()
    {
        self.addService(false);
    }

    self.VisibleAddition = function()
    {
        self.addService(true);
    }

    self.ShowServices = function () {
        $.ajax({
            type: "GET",
            cahce: false,
            url: '/Service/ShowService',
            dataType: "json",
            data: {
                '__RequestVerificationToken': $("input[name=__RequestVerificationToken]").val()
            },
            success: function (result) {
                self.serviceList(result);
            },
            error: function (errjqXHR, errtextStatus, errerrorThrown) {
                alert(errtextStatus + " | " + errerrorThrown + " | " + errjqXHR.responseText);
            }
        });
    }
        
    self.AddService = function () {
        $.ajax({
            type: "POST",
            cahce: false,
            url: '/Service/AddService',
            dataType: "json",
            data: {
                '__RequestVerificationToken': $("input[name=__RequestVerificationToken]").val(),
                'Description': $('#services').val(),
                //'Price': $('#Price').val()
            },
            success: function (result) {
                self.addService(false);
                self.ShowServices();
            },
            error: function (errjqXHR, errtextStatus, errerrorThrown) {
                alert(errtextStatus + " | " + errerrorThrown + " | " + errjqXHR.responseText);
            }
        });
    }
    self.LoadData = function (item) {
        $('#editDescription').val(item.Description);
        $('#editPrice').val(item.Price);
        self.idService(item.ServiceId);
    }

    self.EditService = function () {
        $.ajax({
            type: "POST",
            cahce: false,
            url: '/Service/FindService',
            dataType: "json",
            data: {
                '__RequestVerificationToken': $("input[name=__RequestVerificationToken]").val(),
                'id': self.idService,
                'description': $('#editDescription').val(),        
                'price': $('#editPrice').val()
            },
            success: function (result) {
                self.ShowServices();
                $('#edit').modal('hide');
            },
            error: function (errjqXHR, errtextStatus, errerrorThrown) {
                alert(errtextStatus + " | " + errerrorThrown + " | " + errjqXHR.responseText);
            }
        });
    }

    self.DeleteService = function (item) {
        $.ajax({
            type: "POST",
            cahce: false,
            url: '/Service/DeleteService',
            dataType: "json",
            data: {
                '__RequestVerificationToken': $("input[name=__RequestVerificationToken]").val(),
                'id': item.ServiceId
            },
            success: function (result) {
                self.ShowServices();
            },
            error: function (errjqXHR, errtextStatus, errerrorThrown) {
                alert(errtextStatus + " | " + errerrorThrown + " | " + errjqXHR.responseText);
            }
        });
    }
}