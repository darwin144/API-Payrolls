const token = $("#token").text();
const guid = $("#guidEmployee").text();

$.ajax({
    url: `https://localhost:7165/API-Payroll/Overtime/ByEmployee/${guid}`,
    type: "GET",
    headers: {
        "Authorization": "Bearer " + token
    },
    success: (result) => {
        const data = result.data;
        const table = $('#tableOvertimeBody').DataTable({
            dom: 'Bfrtip',
            buttons: ['pdf', 'print'],
            columns: [
                { title: 'NO' },
                { title: 'Start Overtime' },
                { title: 'End Overtime' },
                { title: 'Submit Date' },
                { title: 'Paid' },
                { title: 'Status' },
                { title: 'Actions' }
            ]
        });
        table.clear(); 
        $.each(data, (index, val) => {
            const row = [
                index + 1,
                moment(val.startOvertime).locale('id').format('DD MMMM YYYY [Pukul] HH:mm'),
                moment(val.endOvertime).locale('id').format('DD MMMM YYYY [Pukul] HH:mm'),
                moment(val.submitDate).locale('id').format('DD MMMM YYYY'),
                "Rp. " + val.paid.toString().replace(/\B(?=(\d{3})+(?!\d))/g, "."),
                getStatusBadge(val.status),
                `<button hidden class="btn btn-danger btn-delete" onclick="deleteRow(${val.id})">Delete</button>`
            ];

            table.row.add(row); 
        });

        table.draw();
    }
});

function getStatusBadge(status) {
    if (status === 0) {
        return `<span class="badge bg-primary">Approval</span>`;
    } else if (status === 1) {
        return `<span class="badge bg-success">Approved</span>`;
    } else {
        return `<span class="badge bg-danger">Rejected</span>`;
           }
}


//payslip table
$.ajax({
    url: `https://localhost:7165/API-Payroll/Payroll/GetByEmployeeId/${guid}`,
    type: "GET",
    headers: {
        "Authorization": "Bearer " + token
    },
    success: (result) => {
        const data = result.data;
        const table = $('#tablepayslip').DataTable({
            dom: 'Bfrtip',
            buttons: ['pdf', 'print'],
            columns: [
                { title: 'NO' },
                { title: 'Pay Date' },
                { title: 'Name' },
                { title: 'Department' },
                { title: 'Title' },
                { title: 'Allowence' },
                { title: 'Overtime' },
                { title: 'Salary Cuts' },
                { title: 'Total Salary' }
                
            ]
        });
        table.clear();
        $.each(data, (index, val) => {
            const row = [
                index + 1,
                moment(val.payDate).locale('id').format('DD MMMM YYYY'),
                (val.fullname),
                (val.department),
                (val.title),
                "Rp. " + val.allowence.toString().replace(/\B(?=(\d{3})+(?!\d))/g, "."),
                "Rp. " + val.overtime.toString().replace(/\B(?=(\d{3})+(?!\d))/g, "."),
                "Rp. " + val.payrollCuts.toString().replace(/\B(?=(\d{3})+(?!\d))/g, "."),
                "Rp. " + val.totalSalary.toString().replace(/\B(?=(\d{3})+(?!\d))/g, "."),
            ];

            table.row.add(row);
        });

        table.draw();
    }
});


/*    $.ajax({
        url: `https://localhost:7165/API-Payroll/Overtime/ByEmployee/${guid}`,
        type: "GET",
        headers: {
            "Authorization": "Bearer " + token
        },
        success: (result) => {
            $('#tableOvertimeBody').empty();
            const tbody = $('#tableOvertimeBody');
            let data = result.data;
            $.each(data, (index, val) => {
                const row = $('<tr>');

                const noCell = $('<td>').text(index + 1);
                const startOvertimeCell = $('<td>').text(moment(val.startOvertime).locale('id').format('DD MMMM YYYY [Pukul] HH: mm'));
                const endOvertimeCell = $('<td>').text(moment(val.endOvertime).locale('id').format('DD MMMM YYYY [Pukul] HH: mm'));
                const submitDateCell = $('<td>').text(moment(val.submitDate).locale('id').format('DD MMMM YYYY'));
                const paidCell = $('<td>').text("Rp. " + val.paid.toString().replace(/\B(?=(\d{3})+(?!\d))/g, "."));
                const statusCell = $('<td>');
                if (val.status === 0) {
                    statusCell.html(`<span class="badge bg-primary">Approval</span>`);
                } else if (val.status === 1) {
                    statusCell.html(`<span class="badge bg-success">Approved</span>`);
                } else {
                    statusCell.html(`<span class="badge bg-danger">Rejected</span>`);
                       } 
                const actionsCell = $('<td>');
                const deleteButton = $('<button>').addClass('btn btn-danger btn-delete').attr({
                    'onclick': `deleteRow(${val.id})`
                }).text('Delete');

                actionsCell.append(deleteButton);
                row.append(noCell, startOvertimeCell, endOvertimeCell, submitDateCell, paidCell, statusCell, actionsCell);
                tbody.append(row);

            })
        }
    });

*/