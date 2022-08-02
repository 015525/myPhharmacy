var drugTable;

$(document).ready(function () {
    loadDrugTable();
})


function loadDrugTable() {
    drugTable = $('#DTLoad').DataTable({
        "ajax": {
            "url": "/drugs/getall/",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "drug_name", "width": "30%" },
            {
                "data": "drug_id",
                "render": function (data) {
                    return `<div class = "text-center">
                        <a href="/Drugs/Upsert?id=${data}" class='btn btn-success text-white' style='cursor:pointer; width:50px'>
                            Edit
                        </a>
                        &nbsp
                        <a class='btn btn-danger text-white' style='cursor:pointer; width:80px'
                            onclick=Delete('drugs/Delete?id='+${data})>
                            Delete
                        </a>
                    </div>`;
                }, "width": "70%",
            }
        ],
        "language": {
            "empty tables": "no data found"
        },
        "width" :"100%"

    });
}

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
                success: function(data){
                    if (data.success) {
                        toastr.success(data.message);
                        drugTable.ajax.reload();
                    } else {
                        toastr.error(data.message);
                    }
            }
            })
        }
    })
}