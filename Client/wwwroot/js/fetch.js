const token = $("#token").text();
const guid = $("#guidEmployee").text();

fetch(`https://localhost:7165/API-Payroll/Overtime/ChartManagerByGuid/${guid}`, {
    headers: {
        Authorization: `Bearer ${token}`
    }
})
    .then(response => response.json())
    .then(data => {

        const approved = data.data.approved;
        const rejected = data.data.rejected;
        const totalMale = data.data.totalMale;
        const totalFemale = data.data.totalFemale;
        const total = totalMale + totalFemale;

        console.log(total);
        console.log(approved);


        document.getElementById('profile-views').textContent = total;
        document.getElementById('followers').textContent = approved;
        document.getElementById('following').textContent = rejected;
/*        document.getElementById('saved-post').textContent = stock;
*/    })
    .catch(error => console.log(error));


//Pie chart
fetch(`https://localhost:7165/API-Payroll/Overtime/ChartManagerByGuid/${guid}`, {
    headers: {
        Authorization: `Bearer ${token}`
    }
})
    .then(response => response.json())
    .then(data => {
        const totalMale = data.data.totalMale;
        const totalFemale = data.data.totalFemale;

        const chartOptions = {
            series: [totalMale, totalFemale],
            labels: ['Male', 'Female'],
            chart: {
                type: 'donut',
            },
            plotOptions: {
                pie: {
                    donut: {
                        size: '70%',
                    },
                },
            },
            responsive: [{
                breakpoint: 480,
                options: {
                    chart: {
                        width: 200,
                    },
                    legend: {
                        position: 'bottom',
                    },
                },
            }],
        };

        const chart = new ApexCharts(document.querySelector("#chart-gender"), chartOptions);
        chart.render();
    })
    .catch(error => console.log(error));


fetch("https://localhost:7165/API-Payroll/Overtime/ListRemainingOvertimeEmployee")
    .then((response) => response.json())
    .then((data) => {
        const users = data.data;

        const categories = users.map((user) => user.fullname);
        const chartData = users.map((user) => user.remainingOvertime);
        console.log(users);
        var options = {
            series: [
                {
                    data: chartData,
                },
            ],
            chart: {
                height: 350,
                type: "bar",
                events: {
                    click: function (chart, w, e) {
                        // console.log(chart, w, e)
                    },
                },
            },
            plotOptions: {
                bar: {
                    columnWidth: "45%",
                    distributed: true,
                },
            },
            dataLabels: {
                enabled: false,
            },
            legend: {
                show: false,
            },
            xaxis: {
                categories: categories,
                labels: {
                    style: {
                        colors: ["#333"],
                        fontSize: "12px",
                    },
                    title: {
                        text: "Age (years)",
                    },
                },
            },
        };

        var chart = new ApexCharts(
            document.querySelector("#charta"),
            options
        );
        chart.render();
    })
    .catch((error) => console.log(error));


