// Docs:
// https://yaplex.com/blog/bootstrap-datetimepicker-with-angularjs#disqus_thread
// http://eonasdan.github.io/bootstrap-datetimepicker/

// Useage:
// <div date-time-picker ng-model="ct.dateinmodel" date-only="false" invalid="isValid" disabled="isDisabled" format="DD/MM/YYYY, hh:mm a" form-name="datetimepicker" require="false"></div>

define(function () {
    dateTimePicker.$inject = ['$compile', 'moment'];
    function dateTimePicker($compile, moment) {
        var directive = {
            restrict: 'EA',
            require: 'ngModel',
            replace: true,
            scope: {
                format: "@format", // Date format
                ngModel: "=",
                dateOnly: "@", // turn it into a date picker
                invalid: "@", // Show error
                disabled: "@",
                formName: "@formName",
                require: "=",
                ngChange: "=",
            },
            templateUrl: 'Scripts/proteandirectives/template/_datetimepicker.html',
            link: link
        };

        return directive;
        function link(scope, element, attrs, controller) {

            if (!scope.format) { // Set default format
                switch (navigator.language) {
                    case "en-US":
                        scope.format = (scope.dateOnly === 'true' ? "MM/DD/YYYY" : "MM/DD/YYYY, hh:mm a");
                        break;
                    default:
                        scope.format = (scope.dateOnly === 'true' ? "DD/MM/YYYY" : "DD/MM/YYYY, HH:mm");
                        break;
                }
            }

            if (scope.invalid === undefined) // Set default invalid
                scope.invalid = 'false';

            if (scope.disabled === undefined) // Set default disabled
                scope.disabled = false;

            if (scope.dateOnly === 'true') // Hide time icon if it's just date
                $(element).find(".glyphicon-time").first().hide();

            var parent = $(element).find("input[type=text]").parent(); // Find the input's wrapper

            var dtp = parent.datetimepicker({ // Set up the jQuery control and properties on the wrapper
                sideBySide: (scope.dateOnly !== 'true'), // Don't show time picker if just calendar
                locale: navigator.language,
                format: scope.format,
            });

            dtp.on("dp.change", function (e) { // Handle model change events
                scope.user = true; // Don't trigger model change formatting
                if (e.date !== false) {
                    scope.internal = moment(e.date).format(scope.format); // internal variable to avoid the form becoming dirty as soon as the directive loads
                    scope.ngModel = new Date(e.date);
                }
                else {
                    scope.ngModel = '';
                    scope.internal = '';
                }
                controller.$setViewValue(scope.ngModel);
                if (scope.ngChange)
                    scope.ngChange();
                scope.$apply(); // Make Angular aware
            });

            scope.$watch('ngModel', function (newValue, oldValue) { // Watch the incoming model so we can format the value onload
                if (newValue)
                    if (!scope.user) {
                        if (newValue !== undefined)
                            if (newValue !== moment(oldValue).format(scope.format)) { // Avoiding an infinte loop
                                if (newValue)
                                    scope.internal = moment(newValue).format(scope.format);
                            }
                    }
                    else
                        scope.user = false;
            }, true);

            scope.$watch('internal', function (newValue, oldValue) { // If model loads with a date and the user deletes that date change doesn't fire
                if (newValue === "")
                    scope.ngModel = "";
            }, true);
        }
    }
    return dateTimePicker;
});
