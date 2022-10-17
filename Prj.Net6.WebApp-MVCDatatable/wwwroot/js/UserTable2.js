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


    //
    var table = $('#userTable3').DataTable({
        "processing": true, // for show progress bar    
        //"serverSide": true, // for process server side    
        "filter": true, // this is for disable filter (search box)    
        "orderMulti": false, // for disable multiple column at once 
        "ajax": {
            'url': "/api/Users/getAllUsers", //'@Url.Action("getAllUsers", "Home")',
            "type": "GET",
            "datatype": "json"

        },
        "columns": [
            {
                "className": 'details-control',
                "orderable": false,
                "data": null,
                "defaultContent": ''
            },
            { "sTitle": "First Name", "data": "firstName" },
            { "sTitle": "Last Name", "data": "lastName" },
            { "sTitle": "Middle Name", "data": "middleName" }
        ]
    });
    // Add event listener for opening and closing details
    $('#userTable3 tbody').on('click', 'td.details-control', function () {
        var tr = $(this).closest('tr');
        var row = table.row(tr);
        if (row.child.isShown()) {
            // This row is already open - close it
            row.child.hide();
            tr.removeClass('shown');
        } else {
            // Open this row
            row.child(child_Table(row.data())).show();
            tr.addClass('shown');
        }
    });

    //
    //$.noConflict();

    ////call function for conversion of table when document is ready 
    jq_Datatable("sampleTable");

});


function child_Table(data) {

    return '<table cellpadding="5" cellspacing="0" border="0" style="padding-left:50px;">' +
        '<tr>' +
        '<td>Full Name:</td>' +
        '<td>' + data.firstName + ' ' + data.lastName + '</td>' +
        '</tr>' +
        '<tr>' +
        '<td>Contact:</td>' +
        '<td>' + data.contact + '</td>' +
        '</tr>' +
        '</table>';
}

//
//function to convert simple table to Datatable
function jq_Datatable(table_ID) {
    var table = "#" + table_ID;

    check_table(table);

    var table = $("#" + table_ID).DataTable();

}

//check if Datatable already exist for dynamic table and remove if it exist
function check_table(table) {

    var currTable = $(table);
    if (currTable) {
        $(".dataTables_filter").remove();
        $(".dataTables_length").remove();
        $(".dataTables_info").remove();
        $(".dataTables_paginate").remove();
        $(".paging_simple_numbers").remove();
        // contains the dataTables master records
        var s = $(document).dataTableSettings;
        if (s != 'undefined') {
            var len = s.length;

            for (var i = 0; i < len; i++) {
                // if already exists, remove from the array
                if (s[i].sInstance = $(table)) {
                    s.splice(i, 1);
                }
            }

        }
    }
}

//load child table
function load_child_table(No) {
    ////Set img for toogle add and minus
    var src = $("#main_table" + No).attr('src');
    var src_add = '../images/arrow down.png';
    var src_minus = '../images/arrow side.png';


    if (src == src_add) {
        $("#main_table" + No).attr('src', src_minus);

    } else if (src == src_minus) {
        $("#main_table" + No).attr('src', src_add);
    }
    //end of toggle


    var tr = $(".main_table" + No).closest('tr');
    var table = $('#sampleTable').DataTable();
    var row = table.row(tr);

    if (row.child.isShown()) {
        // This row is already open - close it
        row.child.hide();
        tr.removeClass('shown');
    }
    else {
        row.child(child_Table3).show();
        tr.addClass('shown');
        $('div.slider', row.child()).slideDown(20000);
    }
}

//child table design
function child_Table3() {
    var result = "<div class='slider'>";
    + "  <table class='table table-bordered'>  "
        + "  <thead>"
        + "    <tr>"
        + "        <th>SAMPLE 1</th>"
        + "        <th>sAMPLE 2</th>"
        + "        <th>SAMPLE 3</th>"
        + "        <th>SAMPLE 4</th>"
        + "    </tr>"
        + "  </thead>"
        + " <tbody>"
        + "    <tr>"
        + "        <td>SAMPLE 1</td>"
        + "        <td>SAMPLE 2</td>"
        + "        <td>SAMPLE 3</td>"
        + "        <td>SAMPLE 4</td>"
        + "    </tr>"
        + "</tbody>"
        + "</table>"
        + "</div>";
    return result;
}
