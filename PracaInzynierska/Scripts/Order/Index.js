function OrderModel() {
    var self = this;
    self.detailsList = ko.observableArray([]);
    self.ordersList = ko.observableArray([]);
    self.moreList = ko.observableArray([]);
    self.workersList = ko.observableArray([]);
    self.workersOrder = ko.observableArray([]);
    self.statusList = ko.observableArray(['Nowe', 'W realizacji', 'Zakończone']);
    self.orderId = ko.observable('');
    self.status = ko.observable('');
    self.showDetails = ko.observable(false);
    //self.closeDetails = function () {
    //    self.showDetails(false);
    //}
    self.List = function () {
        $.ajax({
            type: "GET",
            cahce: false,
            url: '/Order/ShowOrders',
            dataType: "json",
            success: function (result) {
                self.ordersList(result);
            },
            error: function (errjqXHR, errtextStatus, errerrorThrown) {
                alert(errtextStatus + " | " + errerrorThrown + " | " + errjqXHR.responseText);
            }
        });
    }

    self.OrdersList = function () {
        $.ajax({
            type: "GET",
            cahce: false,
            url: '/Order/ShowOrdersForWorker',
            dataType: "json",
            success: function (result) {
                
                self.workersOrder(result);
            },
            error: function (errjqXHR, errtextStatus, errerrorThrown) {
                alert(errtextStatus + " | " + errerrorThrown + " | " + errjqXHR.responseText);
            }
        });
    }
    self.Edit = function (item) {
        //self.showDetails(true);
        $.ajax({
            type: "POST",
            cahce: false,
            url: '/Order/EditStatus',
            dataType: "json",
            data: {
                '__RequestVerificationToken': $("input[name=__RequestVerificationToken]").val(),
                'id': self.orderId,
                'status': $('#Status').val()
            },
            success: function (result) {
                self.OrdersList();
            },
            error: function (errjqXHR, errtextStatus, errerrorThrown) {
                alert(errtextStatus + " | " + errerrorThrown + " | " + errjqXHR.responseText);
            }
        });
    }

    self.Details = function (item) {
        //self.showDetails(true);
        $.ajax({
            type: "POST",
            cahce: false,
            url: '/Order/FindDefects',
            dataType: "json",
            data: {
                '__RequestVerificationToken': $("input[name=__RequestVerificationToken]").val(),
                'id': item.OrderId
            },
            success: function (result) {
                    self.detailsList(result);

            },
            error: function (errjqXHR, errtextStatus, errerrorThrown) {
                alert(errtextStatus + " | " + errerrorThrown + " | " + errjqXHR.responseText);
            }
        });
    }

    self.More = function (item)
    {
        self.orderId = item.OrderId;
        $.ajax({
            type: "POST",
            cahce: false,
            url: '/Order/FindOrder',
            dataType: "json",
            data: {
                '__RequestVerificationToken': $("input[name=__RequestVerificationToken]").val(),
                'id': item.OrderId
            },
            success: function (result) {
                $('#OrderDateRepair').val(result.OrderDate)
                $('#StartRepair').val(result.StartRepair)
                $('#EndOfRepair').val(result.EndOfRepair)
                $('#Comments').val(result.Comments)
                $('#Status').val(result.Status)
                $('#Worker').val(result.WorkerId)
                self.moreList(result);
                self.SelectWorker();
            },
            error: function (errjqXHR, errtextStatus, errerrorThrown) {
                alert(errtextStatus + " | " + errerrorThrown + " | " + errjqXHR.responseText);
            }
        });
    }
    
    self.AddStatusToOrder = function () {
        //self.servicesId.push($('#services').val());
        $.ajax({
            type: "POST",
            cahce: false,
            url: '/Order/AddStatusToOrder',
            dataType: "json",
            data: {
                '__RequestVerificationToken': $("input[name=__RequestVerificationToken]").val(),
                'id': self.orderId,
                'status': $('#Status').val()
            },
            success: function (result) {
                //self.service.push($('#services').val());
                self.List();
            },
            error: function (errjqXHR, errtextStatus, errerrorThrown) {
                alert(errtextStatus + " | " + errerrorThrown + " | " + errjqXHR.responseText);
            }
        });
    }

    //self.AddWorkerToOrder = function () {
    //    //self.servicesId.push($('#services').val());
    //    $.ajax({
    //        type: "POST",
    //        cahce: false,
    //        url: '/Order/AddWorkerToOrder',
    //        dataType: "json",
    //        data: {
    //            '__RequestVerificationToken': $("input[name=__RequestVerificationToken]").val(),
    //            'id': self.orderId,
    //            'workerId': $('#Worker').val()
    //        },
    //        success: function (result) {
    //            //self.service.push($('#services').val());
    //            self.List();
    //        },
    //        error: function (errjqXHR, errtextStatus, errerrorThrown) {
    //            alert(errtextStatus + " | " + errerrorThrown + " | " + errjqXHR.responseText);
    //        }
    //    });
    //}

    self.SelectWorker = function () {
        $.ajax({
            type: "GET",
            cahce: false,
            url: '/SalaryReport/WorkerList',
            dataType: "json",
            success: function (result) {
                self.workersList(result);
            },
            error: function (errjqXHR, errtextStatus, errerrorThrown) {
                alert(errtextStatus + " | " + errerrorThrown + " | " + errjqXHR.responseText);
            }
        });
    }

    self.AddWorkerToOrder = function () {
        //self.servicesId.push($('#services').val());
        $.ajax({
            type: "POST",
            cahce: false,
            url: '/Order/AddWorkerToOrder',
            dataType: "json",
            data: {
                '__RequestVerificationToken': $("input[name=__RequestVerificationToken]").val(),
                'id': self.orderId,
                'workerId': $('#Worker').val()
            },
            success: function (result) {
                //self.service.push($('#services').val());
                self.List();
                $('#more').modal('hide');
            },
            error: function (errjqXHR, errtextStatus, errerrorThrown) {
                alert(errtextStatus + " | " + errerrorThrown + " | " + errjqXHR.responseText);
            }
        });
    }
}