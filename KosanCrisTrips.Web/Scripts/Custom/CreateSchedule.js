/// <reference path="../jquery.min.js" />

$(document).ready(function () {
    var selectedLocation;
    var selectedNatureOfService;
    alert($('select#natureOfServices').length)
    $('#natureOfServices').change(function () {
        $('#hdnLocation').val($(this).val());

        if ($('#hdnLocation').val() != "" && $('#hdnLocation').val() != 0
                                          && $('#hdnSelectedNatureOfService').val() != ""
                                          && $('#hdnSelectedNatureOfService').val() != 0) {
            selectedLocation = $('#hdnLocation').val();
            selectedNatureOfService = $('#hdnSelectedNatureOfService').val();
            GetWorkOrders(selectedLocation, selectedNatureOfService);

        }

    });

    $('select#customerLocationsLookUp').on('change', function () {
        $('#hdnSelectedNatureOfService').val($(this).val());

        if ($('#hdnLocation').val() != "" && $('#hdnLocation').val() != 0
                                          && $('#hdnSelectedNatureOfService').val() != ""
                                          && $('#hdnSelectedNatureOfService').val() != 0) {
            selectedLocation = $('#hdnLocation').val();
            selectedNatureOfService = $('#hdnSelectedNatureOfService').val();
            GetWorkOrders(selectedLocation, selectedNatureOfService);

        }
    });

    function GetWorkOrders(selectedLocation, selectedNatureOfService)
    {

        $.ajax({
            url: "/LookUp/GetWorkOrders",
            type: "POST",
            dataType: "json",
            data: { selectedLocation: selectedLocation, selectedNatureOfService: selectedNatureOfService },
            success: function (data) {
                //response($.map(data, function (item) {
                //    return { label: item.Name, value: item.Name };
                //}))

            }
        });
    }

    //$('#customerLocationsLookUp').autocomplete({
    //    source: function (request, response) {
    //        $.ajax({
    //            url: "/LookUp/GetCustomerLocations",
    //            type: "POST",
    //            dataType: "json",
    //            data: { searchText: request.term },
    //            success: function (data) {
    //                response($.map(data, function (item) {
    //                    return { label: item.Name, value: item.Name };
    //                }))

    //            }
    //        })
    //    },
    //    messages: {
    //        noResults: "", results: ""
    //    }
    //});
});