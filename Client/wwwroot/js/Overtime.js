

const guid = $("#guidEmployee").text();
//table data overtime


$.ajax({
    url: `https://localhost:7165/API-Payroll/Overtime/EmployeeId/${guid}`,
    dataType: "json",
    method: "GET",
    success: function (data) {
        // Proses data yang diperoleh
        console.log(data);
    }
});



/*$(document).ready(function () {
    let table = $("#tableOvertime").DataTable({
        "ajax": {
            "url": `https://localhost:7165/API-Payroll/Overtime/ByEmployee/${guid}`,
            "dataType": "Json",
            "dataSrc": ""
        },
        "columns": [
            { "data": "start_overtime" }, // Ganti dengan nama kolom yang sesuai
            { "data": "end_overtime" }, // Ganti dengan nama kolom yang sesuai
            // Tambahkan kolom lain jika diperlukan
        ]
    })
});

*/        /*,
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
                    return `<button class="btn btn-info" data-toggle="modal" data-target="#modalDetailEmp" onclick="GetDetailOvertimes('${data.nik}','${data.submit}','${data.status}')"><i class="fa-solid fa-info"></i></button>`;
                }
            }
        ]*/
 