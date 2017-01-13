function ViewModel() {
    var self = this;
    self.firstName = ko.observable("Bert");
    self.lastName = ko.observable("Bertington");
    self.listaLokalizacji = ko.observableArray([]);
    self.shouldShowMessage = ko.observable(false);
    
    self.submit = function () {
        $.ajax({
            type: "GET",
            cahce: false,
            url: '/Home/GetRoleName',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data == "Client") {
                    //self.clientLogged(data);
                    self.shouldShowClientMenu(true);
                    self.shouldShowWorkerMenu(false);
                }
                
            },
            error: function (err) {
                alert(err.status + " : " + err.statusText);
            }
        });
    };
}

//function ViewModel() {
//    var self = this;
//    sel.listaLokalizacji = ko.observableArray([]);
//    self.numer = ko.observable(5);
//    this.textpierwszy = ko.observable("hellllllo kurwa!");
//};

//var vm = new ViewModel();

//function Lokalizacje() {
//    $.ajax({
//        type: 'POST',
//        cahce: false,
//        url: '/Home/Lista',
//        dataType: 'json',
//        data: {
//            '__RequestVerificationToken': $("input[name=__RequestVerificationToken]").val()
//            //'dodal' : $('#filtrDodal').val(),
//            //'adresNazwa' : vm.przesylkiSort()
//        },
//        beforeSend: function () {
//            self.listaLokalizacji([]);
//        },
//        success: function (result) {
//            if (result.code == 0) {
//                self.listaLokalizacji(result.data);
//            } else {
//                alert(result.message);
//            }
//        },
//        error: function (jqXHR, textStatus, errorThrown) { }
//    });
//};
