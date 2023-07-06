const polarArea = document.getElementById('doughnut');

new Chart(doughnut, {
    type: 'doughnut',
data: {
    labels: ['Obras', 'Servicos', 'Manutenção', 'Outros'],
datasets: [{
    label: 'Segmentos',
    data: [300, 50, 100, 30],
    backgroundColor: [
    'rgb(255, 99, 132)',
    'rgb(54, 162, 235)',
    'rgb(17, 68, 85)',
    'rgb(255, 205, 86)'
    ],
    hoverOffset: 4
    }]
},
options: {
    scales: {
    y: {
    beginAtZero: true
    }
    }
    }
});