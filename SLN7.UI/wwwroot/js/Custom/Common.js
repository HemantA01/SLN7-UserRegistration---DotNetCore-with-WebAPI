$(document).ready(function () {
    var table = $('.mydatatable').Datatable({
        paging: true,
        lengthChange: true,
        searching: true,
        ordering: true,
        info: true,
        autoWidth: false,
        responsive: false,
        pageLength: 100,
        order: []
    });

   // $('.mydatatable').DataTable();
});