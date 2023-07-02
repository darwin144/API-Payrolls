

fetch('https://dummyjson.com/products')
    .then(response => response.json())
    .then(data => {
        const product = data.products[0];

        const price = product.price;
        const discountPercentage = product.discountPercentage;
        const rating = product.rating;
        const stock = product.stock;

        document.getElementById('profile-views').textContent = price;
        document.getElementById('followers').textContent = discountPercentage;
        document.getElementById('following').textContent = rating;
        document.getElementById('saved-post').textContent = stock;
    })
    .catch(error => console.log(error));


  /*  //chart
// Fetch data from API
fetch("https://jsonplaceholder.typicode.com/users")
    .then((response) => response.json())
    .then((data) => {
        const maidenNames = data.map((user) => user.name);
        const postalCodes = data.map((user) => user.address.zipcode);
        const cardTypes = data.map((user) => user.company.name);

        // Prepare data for chart
        const chartData = [
            {
                name: "Maiden Name",
                data: maidenNames,
            },
            {
                name: "Postal Code",
                data: postalCodes,
            },
            {
                name: "Card Type",
                data: cardTypes,
            },
        // Create and render the chart
        const chartOptions = {
            chart: {
                type: "line",
            },
            series: chartData,
            xaxis: {
                categories: ["User 1", "User 2", "User 3", "User 4", "User 5"], // Adjust categories as per your data
            },
            responsive: [
                {
                    breakpoint: 480,
                    options: {
                        chart: {
                            width: 300,
                        },
                        legend: {
                            position: "bottom",
                        },
                    },
                },
            ],
        };

        const chart = new ApexCharts(
            document.querySelector("#chart"),
            chartOptions
        );
        chart.render();
    })
    .catch((error) => {
        console.error("Error:", error);
    });*/


    //apexchart
fetch("https://dummyjson.com/users?limit=8&skip=10&select=firstName,age")
    .then((response) => response.json())
    .then((data) => {
        const users = data.users;

        const categories = users.map((user) => user.firstName);
        const chartData = users.map((user) => user.age);

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
