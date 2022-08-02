var hisTable;

$(document).ready(function () {
    loadhisTable();
})


function loadhisTable() {
    hisTable = $('#HTLoad').DataTable({
        "ajax": {
            "url": "/history/getall/",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "drug_name", "width": "10%" },
            { "data": "comming_date", "width": "10%" },
            { "data": "expirey_date", "width": "10%" },
            { "data": "quantity", "width": "10%" },
            { "data": "unit", "width": "10%" },
            { "data": "expired", "width": "10%" },
            { "data": "finished", "width": "10%" },
            {
                "data": "his_id",
                "render": function (data) {
                    return `<div class = "text-center">
                        <a href="/History/Upsert?id=${data}" class='btn btn-success text-white' style='cursor:pointer; width:80px'>
                            Edit
                        </a>
                        &nbsp
                        <a class='btn btn-danger text-white' style='cursor:pointer; width:80px'
                            onclick=Delete('history/Delete?id='+${data})>
                            Delete
                        </a>
                    </div>`;
                }, "width": "30%",
            }
        ],
        "language": {
            "empty tables": "no data found"
        },
        "width": "100%"

    });
}

//{ "data": "production_date", "width": "10%" },
function Delete(Url) {
    swal({
        title: "Are you sure?",
        text: "once deleted you will not be able to retrive it",
        icon: "warning",
        button: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: Url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        hisTable.ajax.reload();
                    } else {
                        toastr.error(data.message);
                    }
                }
            })
        }
    })
}