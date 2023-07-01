const token = $("#token").text();
const guid = $("#guidEmployee").text();


$.ajax({
    url: `https://localhost:7165/API-Payroll/Overtime/ByManager/${guid}`,
    type: "GET",
    headers: {
        "Authorization": "Bearer " + token
    },
    success: (result) => {
        const data = result.data;
        const table = $('#tableOvertimeApproval').DataTable({
            data: data,
            columns: [
                { title: 'NO', data: null },
                { title: 'Name', data: 'fullname' },
                { title: 'Start Overtime', data: 'startOvertime' },
                { title: 'End Overtime', data: 'endOvertime' },
                { title: 'Submit Date', data: 'submitDate' },
                { title: 'Deskripsi', data: 'deskripsi' },
                { title: 'Paid', data: 'paid' },
                { title: 'Actions', data: null }
            ],
            columnDefs: [
                {
                    targets: 0,
                    render: function (data, type, row, meta) {
                        return meta.row + 1;
                    }
                },
                {
                    targets: 2,
                    render: function (data, type, row, meta) {
                        return moment(data).locale('id').format('DD MMMM YYYY [Pukul] HH:mm');
                    }
                },
                {
                    targets: 3,
                    render: function (data, type, row, meta) {
                        return moment(data).locale('id').format('DD MMMM YYYY [Pukul] HH:mm');
                    }
                },
                {
                    targets: 4,
                    render: function (data, type, row, meta) {
                        return moment(data).locale('id').format('DD MMMM YYYY');
                    }
                },
                {
                    targets: 6,
                    render: function (data, type, row, meta) {
                        return "Rp. " + data.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ".");
                    }
                },
                {
                    targets: 7,
                    render: function (data, type, row, meta) {
                        return `<button class="btn btn-success btn-delete" id="approved" onclick="Approved(${meta.row})">Approved</button>` +
                            `<button class="btn btn-danger btn-delete" id="rejected" onclick="Rejected(${meta.row})">Rejected</button>`;
                    }
                }
            ]
        });
    }
});

function Approved(index) {
    const data = $('#tableOvertimeApproval').DataTable().row(index).data();
    const overtime = {
        id: data.id,
        fullname: data.fullname,
        startOvertime: data.startOvertime,
        endOvertime: data.endOvertime,
        submitDate: data.submitDate,
        deskripsi: data.deskripsi,
        paid: data.paid,
        status: 1,
        employee_id: data.employee_id
    };
    console.log(overtime);
    $.ajax({
        headers: {
            "Authorization": "Bearer " + token,
            "Accept": "application/json",
            "Content-Type": "application/json"
        },
        type: "PUT",
        url: `https://localhost:7165/API-Payroll/Overtime/OvertimeApproval/${guid}`,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(overtime)
    }).done((result) => {
        Swal.fire({
            title: 'Updated!',
            icon: 'success',
            showConfirmButton: false,
            timer: 1500
        })
        $('#tblOvertime').DataTable().ajax.reload();
   
    }).fail((error) => {
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: `Something went wrong! ${error.responseJSON.message}`,
        })
        $('#tblOvertime').DataTable().ajax.reload();
    })
}


function Rejected(index) {
    const data = $('#tableOvertimeApproval').DataTable().row(index).data();
    const overtime = {
        id: data.id,
        fullName: data.fullName,
        startOvertime: data.startOvertime,
        endOvertime: data.endOvertime,
        submitDate: data.submitDate,
        deskripsi: data.deskripsi,
        paid: data.paid,
        status: 3,
        employee_id: data.employee_id
    };
    $.ajax({
        headers: {
            "Authorization": "Bearer " + token,
            "Accept": "application/json",
            "Content-Type": "application/json"
        },
        type: "PUT",
        url: `https://localhost:7165/API-Payroll/Overtime/OvertimeApproval/${guid}`,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(overtime)
    }).done((result) => {
        Swal.fire({
            title: 'Updated!',
            icon: 'success',
            showConfirmButton: false,
            timer: 1500
        })
        $('#tblOvertime').DataTable().ajax.reload();

    }).fail((error) => {
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: `Something went wrong! ${error.responseJSON.message}`,
        })
        $('#tblOvertime').DataTable().ajax.reload();
    })
}







/*$.ajax({
    url: `https://localhost:7165/API-Payroll/Overtime/ByManager/${guid}`,
    type: "GET",
    headers: {
        "Authorization": "Bearer " + token
    },
    success: (result) => {
        const data = result.data;
        const table = $('#tableOvertimeApproval').DataTable({
            columns: [
                { title: 'NO' },
                { title: 'Name' },
                { title: 'Start Overtime' },
                { title: 'End Overtime' },
                { title: 'Submit Date' },
                { title: 'Deskripsi' },
                { title: 'Paid' },
                { title: 'Actions' }
            ]
        });
        table.clear();
        $.each(data, (index, val) => {
            const row = [
                index + 1,
                val.name,
                moment(val.startOvertime).locale('id').format('DD MMMM YYYY [Pukul] HH:mm'),
                moment(val.endOvertime).locale('id').format('DD MMMM YYYY [Pukul] HH:mm'),
                moment(val.submitDate).locale('id').format('DD MMMM YYYY'),
                val.deskripsi,
                "Rp. " + val.paid.toString().replace(/\B(?=(\d{3})+(?!\d))/g, "."),
                `<button class="btn btn-success btn-delete" >Approved</button>` +
                `<button class="btn btn-danger btn-delete" >Rejected</button>`
            ];
            table.row.add(row);
        });
        table.draw();
    }
});
*/


























/*
let nik = $("#sesNIK").text();

$.ajax({
    url: `https://localhost:44325/api/accounts/master/${nik}`,
    type: "GET"
}).done((result) => {
    $("#DashJob").text(result[0].jobTitle)
    $("#DashName").text(result[0].fullName)
})

$(document).ready(function () {
    let table = $("#tblOvertime").DataTable({
        "ajax": {
            "url": "https://localhost:44325/api/overtimes/list/",
            "dataType": "Json",
            "dataSrc": ""
        },
        "columns": [
            {
                data: null,
                render: function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                }
            },
            { "data": "nik" },
            {
                data: null,
                render: function (data, type, row) {
                    return Date.parse(data.submit).toString("dd MMMM yyyy");
                }
            },
            {
                data: null,
                render: function (data, type, row) {
                    return data.total + " Jam";
                }
            },
            {
                data: null,
                render: function (data, type, row) {
                    return "Rp. " + data.paid.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ".");
                }
            },
            {
                data: null,
                render: function (data, type, row) {
                    if (data.type === "Weekday") {
                        return `<span class="badge badge-pill badge-primary">${data.type}</span>`;
                    } else {
                        return `<span class="badge badge-pill badge-warning">${data.type}</span>`;
                    }
                }
            },
            {
                data: null,
                render: function (data, type, row) {
                    if (data.status === "Approved") {
                        return `<span class="badge badge-pill badge-success">${data.status}</span>`;
                    } else if (data.status === "Rejected") {
                        return `<span class="badge badge-pill badge-danger">${data.status}</span>`;
                    } else if (data.status === "ApprovalManager") {
                        return `<span class="badge badge-pill badge-info">${data.status}</span>`;
                    } else {
                        return `<span class="badge badge-pill badge-warning">${data.status}</span>`;
                    }
                }
            },
            {
                data: null,
                render: function (data, type, row) {
                    return `<button class="btn btn-info" data-toggle="modal" data-target="#modalDetail" onclick="GetDetailOvertimes('${data.nik}','${data.submit}','${data.status}')"><i class="fa-solid fa-info"></i></button>`;
                }
            }
        ]
    });
});

function GetDetailOvertimes(nik, date, status) {
    if (status === "Rejected" || status === "Approved" || status === "ApprovalManager") {
        $('.approval').hide();
    } else {
        $('.approval').show();
    }

    $.ajax({
        type: "GET",
        url: `https://localhost:44325/api/overtimes/detail/${nik}/${date}`,
    }).done((result) => {
        let text = "";
        $.each(result.list, (key, val) => {
            text += `<tr>
                        <td class="text-center">${key + 1}</td>
                        <td class="text-center">${Date.parse(val.startOvertime).toString("HH:mm")}</td>
                        <td class="text-center">${Date.parse(val.endOvertime).toString("HH:mm")}</td>
                        <td class="text-center">${val.description}</td>
                    </tr>`;
        })

        $("#nik").val(result.nik);
        $("#fullName").val(result.fullName);
        $("#submitDate").val(Date.parse(result.submitDate).toString("dd MMMM yyyy"));
        $("#salary").val(result.salary);
        $("#paid").val(result.paid);
        $("#type").val(result.type);
        $("#tblDetail").html(text);

        $(document).on('click', '.approval', function (event) {
            let info = this.id;

            let ovr = new Object();
            ovr.id = result.list[0].overtimeId;
            ovr.submitDate = result.submitDate;
            ovr.paid = result.paid;
            ovr.type = result.type

            if (info === "accepted") {
                ovr.status = 1;
            } else {
                ovr.status = 3;
            }

            Approval(ovr);
        });
    }).fail((error) => {
        console.log(error)
    })
    console.log(GetDetailOvertimes);
}

function Approval(ovr) {
    $.ajax({
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json"
        },
        type: "PUT",
        url: "https://localhost:44325/api/overtimes/",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(ovr)
    }).done((result) => {
        Swal.fire({
            title: 'Updated!',
            icon: 'success',
            showConfirmButton: false,
            timer: 1500
        })
        $('#tblOvertime').DataTable().ajax.reload();
        $('#modalDetail').modal('hide');
    }).fail((error) => {
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: `Something went wrong! ${error.responseJSON.message}`,
        })
        $('#tblOvertime').DataTable().ajax.reload();
    })
}*/