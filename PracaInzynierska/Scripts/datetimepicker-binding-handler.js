ko.bindingHandlers.dateTimePicker = {
    init: function (element, valueAccessor, allBindingsAccessor) {
        var options = allBindingsAccessor().dateTimePickerOptions || {};
        $(element).datetimepicker(options);
        ko.utils.registerEventHandler(element, "dp.change", function (event) {
            var value = valueAccessor();
            if (ko.isObservable(value)) {
                if (event.date != null && event.date != false && !(event.date instanceof Date)) {
                    value(date2DBString(event.date.toDate()));
                } else {
                    value(null);
                }
            }
        });

        ko.utils.domNodeDisposal.addDisposeCallback(element, function () {
            var picker = $(element).data("DateTimePicker");
            if (picker) {
                picker.destroy();
            }
        });
    },
    update: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
        var picker = $(element).data("DateTimePicker");
        if (picker) {
            var koDate = ko.utils.unwrapObservable(valueAccessor());
            if (koDate != null && koDate != false) {
                koDate = (typeof (koDate) !== 'object') ? new Date(koDate) : koDate;
                picker.date(date2DBString(koDate));
            } else {
                picker.clear();
            }
        }
    }
};