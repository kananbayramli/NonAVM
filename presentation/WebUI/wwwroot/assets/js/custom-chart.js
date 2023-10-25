// total sale
var options = {
    chart: {
        type: 'area',
        height: 350,
        zoom: {
            enabled: false
        },
        toolbar: {
            show: true
        },
    },
    dataLabels: {
        enabled: false
    },
    series: [{
            data: [
                [1672473600000, 30.95], // 2023 Ocak 1
                [1672560000000, 31.34], // 2023 Ocak 2
                [1672646400000, 31.18], // 2023 Ocak 3
                [1672732800000, 31.50], // 2023 Ocak 4
                [1672819200000, 31.62], // 2023 Ocak 5
                [1672905600000, 31.75], // 2023 Ocak 6
                [1672992000000, 31.88], // 2023 Ocak 7
                [1673078400000, 32.02], // 2023 Ocak 8
                [1673164800000, 32.15], // 2023 Ocak 9
                [1673251200000, 32.28], // 2023 Ocak 10
                [1675929600000, 32.42], // 2023 Şubat 1
                [1676098800000, 32.57], // 2023 Şubat 4
                [1676268000000, 32.71], // 2023 Şubat 7
                [1676437200000, 32.86], // 2023 Şubat 10
                [1679115600000, 33.00], // 2023 Mart 1
                [1679284800000, 33.14], // 2023 Mart 4
                [1679454000000, 33.29], // 2023 Mart 7
                [1679623200000, 33.43], // 2023 Mart 10
                [1682221600000, 33.57], // 2023 Nisan 1
                [1682390800000, 33.71], // 2023 Nisan 4
                [1682560000000, 33.85], // 2023 Nisan 7
                [1682729200000, 33.99], // 2023 Nisan 10
                [1685223600000, 34.13], // 2023 Mayıs 1
                [1685392800000, 34.27], // 2023 Mayıs 4
                [1685562000000, 34.41], // 2023 Mayıs 7
                [1685731200000, 34.55], // 2023 Mayıs 10
            ]
        },

    ],
    markers: {
        size: 0,
        style: 'hollow',
    },
    title: {
        text: 'Ümumi Gəlir',
        align: 'left'
    },
    subtitle: {
        text: 'Qiymət Hərəkətləri',
        align: 'left'
    },
    xaxis: {
        type: 'datetime',
        tickAmount: 8,
        low: 0,
        offsetX: 0,
        offsetY: 0
    },
    yaxis: {
        opposite: true,
        low: 0,
        offsetX: 0,
        offsetY: 0
    },
    stroke: {
        width: [2]
    },
    chart: {
        toolbar: {
            show: false,
        },
    },
    tooltip: {
        x: {
            format: 'dd MMM yyyy'
        }
    },
    colors: ['#ff0073'],
    fill: {
        type: 'gradient',
        gradient: {
            shadeIntensity: 1,
            opacityFrom: 0.6,
            opacityTo: 0.5,
            stops: [0, 100]
        }
    },

}

var chart = new ApexCharts(
    document.querySelector("#chart"),
    options
);

chart.render();


// Sale Chart
var options = {
    series: [50, 35, 45, 40],
    chart: {
        type: 'donut',
        height: 320,
    },
    dataLabels: {
        enabled: false
    },
    title: {
        text: 'Ümumi Satışlar',
        align: 'left'
    },
    labels: ['Son Sifariş', 'Gözləyən Ödənişlər', 'Alınan Ödənişlər', 'Tamamlanan Sifariş'],
    colors: ['#7b76d1', '#ff0073', '#0da487', '#f39437'],
    responsive: [{
        breakpoint: 1430,
        options: {
            chart: {
                width: 280,
                height: 285
            },
            legend: {
                position: 'bottom'
            }
        },
        breakpoint: 1199,
        options: {
            chart: {
                width: 250,
                height: 290
            },
            legend: {
                position: 'bottom'
            }
        }
    }]
};

var chart = new ApexCharts(document.querySelector("#sale"), options);
chart.render();