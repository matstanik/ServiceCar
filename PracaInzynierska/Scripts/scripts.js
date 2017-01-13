function AlertWarningShow(content, title) {
    //if (title == null) title = 'Success';
    $('#divAlert').attr('class', 'alert alert-success text-center');
    $('#butAlertClose').attr('class', 'btn btn-sm btn-success');

    //$('#strongAlertTitle').html(title);
    $('#spanAlertContent').html(content);

    $('#divAlert').show();
}