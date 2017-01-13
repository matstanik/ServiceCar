function Message() {
    var self = this;

    self.SendMessage = function () {
        $.ajax({
            type: "POST",
            cahce: false,
            url: '/Message/SendMail',
            dataType: "json",
            data: {
                '__RequestVerificationToken': $("input[name=__RequestVerificationToken]").val(),
                'Email': $('#email').val(),
                'Title': $('#title').val(),
                'MessageContent': $('#message').val()
            },
            success: function (result) {
                
                $('#email').val("");
                $('#title').val("");
                $('#message').val("");
                AlertWarningShow(result);
            },
            error: function (errjqXHR, errtextStatus, errerrorThrown) {
                alert(errtextStatus + " | " + errerrorThrown + " | " + errjqXHR.responseText);
            }
        });
    }

}
