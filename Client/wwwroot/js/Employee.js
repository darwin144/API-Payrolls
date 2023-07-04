function ModalCreateOvertime() {
    $('#createOvertime').modal('show');
}

function closeModal() {
    $('#createOvertime').modal('hide');
}



$(document).ready(function () {
    var startOvertime = $('#endOvertime');
    startOvertime.on('input', function () {
        var selectedDate = new Date(startOvertime.val());
        var selectedDay = selectedDate.getDay();
        var selectedTime = selectedDate.getHours();

        var startTime;
        var endTime;

        if (selectedDay >= 1 && selectedDay <= 5) { // Weekday
            startTime = new Date(selectedDate.getFullYear(), selectedDate.getMonth(), selectedDate.getDate(), 18, 0, 0);
            endTime = new Date(selectedDate.getFullYear(), selectedDate.getMonth(), selectedDate.getDate(), 23, 59, 59);
        } else if (selectedDay === 0 || selectedDay === 6) { // Weekend
            startTime = new Date(selectedDate.getFullYear(), selectedDate.getMonth(), selectedDate.getDate(), 9, 0, 0);
            endTime = new Date(selectedDate.getFullYear(), selectedDate.getMonth(), selectedDate.getDate(), 23, 0, 0);
        }

        if (selectedTime < startTime.getHours()) {
            startOvertime.get(0).setCustomValidity("Waktu yang dimasukkan tidak valid.");
        } else {
            startOvertime.get(0).setCustomValidity('');
        }
    });
});


$(document).ready(function () {
    var startOvertime = $('#startOvertimeX');
    startOvertime.on('input', function () {
        var selectedDate = new Date(startOvertime.val());
        var selectedDay = selectedDate.getDay();
        var selectedHour = selectedDate.getHours();
        var startTime;
        var endTime;

        if (selectedDay >= 1 && selectedDay <= 5) { // Weekday
            startTime = new Date(selectedDate.getFullYear(), selectedDate.getMonth(), selectedDate.getDate(), 17, 0, 0);
            endTime = new Date(selectedDate.getFullYear(), selectedDate.getMonth(), selectedDate.getDate(), 23, 59, 0);
        } else if (selectedDay === 0 || selectedDay === 6) { // Weekend
            startTime = new Date(selectedDate.getFullYear(), selectedDate.getMonth(), selectedDate.getDate(), 9, 0, 0);
            endTime = new Date(selectedDate.getFullYear(), selectedDate.getMonth(), selectedDate.getDate(), 17, 0, 0);
        }

        if (selectedHour < startTime.getHours()) {
            startOvertime.get(0).setCustomValidity("Waktu yang dimasukkan tidak valid. Weekday harus diatas jam 17.00! Weeeken harus diatas pukul 09.00");
        } else {
            startOvertime.get(0).setCustomValidity('');
        }
    });
});


$(document).ready(function () {
    var startOvertime = $('#startOvertimeX');
    var endOvertime = $('#endOvertime');

    startOvertime.on('input', function () {
        validateTimeRange();
    });

    endOvertime.on('input', function () {
        validateTimeRange();
    });

    function validateTimeRange() {
        var startDateTime = new Date(startOvertime.val());
        var endDateTime = new Date(endOvertime.val());

        var today = new Date(); 
        if (startDateTime < today) {
            startOvertime.get(0).setCustomValidity("Tanggal mulai overtime tidak boleh lebih kecil dari hari ini.");
        } else {
            startOvertime.get(0).setCustomValidity('');
        }


        if (startDateTime && endDateTime) {
            if (startDateTime >= endDateTime) {
                endOvertime.get(0).setCustomValidity("Waktu selesai harus lebih besar dari waktu mulai.");
            } else {
                var timeDifference = endDateTime - startDateTime;
                var hoursDifference = timeDifference / 1000 / 60 / 60;

                var selectedDay = startDateTime.getDay();

                if (selectedDay >= 1 && selectedDay <= 5 && hoursDifference > 4) {
                    endOvertime.get(0).setCustomValidity("Pengajuan Overtime pada weekday tidak boleh lebih dari 4 jam.");
                } else if ((selectedDay === 0 || selectedDay === 6) && hoursDifference > 11) {
                    endOvertime.get(0).setCustomValidity("Pengajuan Overtime pada weekend tidak boleh lebih dari 11 jam.");
                } else {
                    endOvertime.get(0).setCustomValidity('');
                }
            }
        }
    }
});
