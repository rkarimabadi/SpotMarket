export let chartInstances = {};
export function loadChartJs(scriptUrl) {
    if (document.querySelector(`script[src="${scriptUrl}"]`)) {
        return; // Already loaded
    }
    const script = document.createElement('script');
    script.src = scriptUrl;
    document.body.appendChild(script);
}

export function renderDoughnutChart(canvasId, labels, data) {
    const canvas = document.getElementById(canvasId);
    if (!canvas) return;
    const ctx = canvas.getContext('2d');

    if (chartInstances[canvasId]) {
        chartInstances[canvasId].destroy();
    }

    if (!labels || labels.length === 0) {
        ctx.clearRect(0, 0, canvas.width, canvas.height);
        ctx.font = "14px 'PeydaWebFaNum'"; // فونت فارسی
        ctx.fillStyle = 'grey';
        ctx.textAlign = 'center';
        ctx.fillText('داده‌ای برای نمایش نمودار وجود ندارد', canvas.width / 2, canvas.height / 2);
        return;
    }

    chartInstances[canvasId] = new Chart(ctx, {
        type: 'doughnut',
        data: {
            labels: labels,
            datasets: [{
                data: data,
                backgroundColor: ['#5e72e4', '#ffb300', '#26a69a', '#f57c00', '#673ab7', '#d32f2f', '#78909c'],
                borderWidth: 1,
                borderColor: '#fff'
            }]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            plugins: {
                legend: {
                    position: 'bottom',
                    labels: {
                        // استفاده از نام فونت صحیح
                        font: {
                            family: 'PeydaWebFaNum'
                        }
                    }
                },
                tooltip: {
                    // استفاده از نام فونت صحیح
                    titleFont: {
                        family: 'PeydaWebFaNum'
                    },
                    bodyFont: {
                        family: 'PeydaWebFaNum'
                    },
                    footerFont: {
                        family: 'PeydaWebFaNum'
                    },
                    rtl: true
                }
            }
        }
    });
}
