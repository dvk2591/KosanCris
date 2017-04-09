/// <reference path="D:\MyProjects\KosanCrisPlant\KosanCrisTrips.Web\KosanCrisTrips.Web\js/jquery.min.js" />

$(document).ready(function () {
    $('#scheduleGrid').DataTable({
        "paging": false,
        "ordering": false,
        "info": false,
        "searching": false
    });
    $('#scheduleGrid tbody')
        .on('mouseenter', 'td', function () {
            var colIdx = table.cell(this).index().column;

            $(table.cells().nodes()).removeClass('highlight');
            $(table.column(colIdx).nodes()).addClass('highlight');
        });
})