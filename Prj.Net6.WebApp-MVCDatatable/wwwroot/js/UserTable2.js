$(document).ready(function () {
    var table = $('#userTable2').DataTable({
        "processing": true, // for show progress bar
        //"serverSide": true, // for process server side
        "filter": true, // this is for disable filter (search box)
        "orderMulti": false, // for disable multiple column at once
        "ajax": {
            "url": "/api/Users/getAllUsers",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "sTitle": "Id", "data": "id" },
            { "sTitle": "First Name", "data": "firstName" },
            { "sTitle": "Last Name", "data": "lastName" },
            { "sTitle": "Middle Name", "data": "middleName" },
            { "sTitle": "Contact", "data": "contact" }
        ]
    });
});