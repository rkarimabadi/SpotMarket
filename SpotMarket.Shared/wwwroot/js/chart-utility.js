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

// پالت نمودارهای گفتگو؛ هم‌راستا با متغیرهای رنگ برنامه در app.css
const chatChartPalette = ['#5e72e4', '#2dce89', '#fb6340', '#ffb300', '#673ab7', '#26a69a', '#f5365c'];

// رسم نمودار پیشنهادی دستیار. spec همان ساختار بلاک chart در پاسخ مدل است و
// پیش از رسیدن به اینجا سمت کلاینت اعتبارسنجی شده است.
export function renderChatChart(canvasId, spec) {
    const canvas = document.getElementById(canvasId);
    if (!canvas || !spec || typeof Chart === 'undefined') return;

    const ctx = canvas.getContext('2d');
    if (chartInstances[canvasId]) {
        chartInstances[canvasId].destroy();
    }

    const isLine = spec.type === 'line';
    const datasets = spec.series.map((series, index) => {
        const color = chatChartPalette[index % chatChartPalette.length];
        return {
            label: series.name || spec.title || '',
            data: series.values,
            backgroundColor: isLine ? 'transparent' : color,
            borderColor: color,
            borderWidth: isLine ? 2 : 0,
            borderRadius: isLine ? 0 : 6,
            tension: 0.3,
            pointRadius: isLine ? 3 : 0,
            fill: false
        };
    });

    const font = { family: 'PeydaWebFaNum' };
    // راهنما فقط وقتی معنا دارد که بیش از یک سری داده روی نمودار باشد.
    const showLegend = datasets.length > 1;
    const unitSuffix = spec.unit ? ' ' + spec.unit : '';

    chartInstances[canvasId] = new Chart(ctx, {
        type: isLine ? 'line' : 'bar',
        data: { labels: spec.labels, datasets: datasets },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            plugins: {
                legend: { display: showLegend, position: 'bottom', labels: { font: font } },
                tooltip: {
                    rtl: true,
                    titleFont: font,
                    bodyFont: font,
                    callbacks: {
                        label: (item) => item.formattedValue + unitSuffix
                    }
                }
            },
            scales: {
                x: { ticks: { font: font }, grid: { display: false } },
                y: { ticks: { font: font }, beginAtZero: true }
            }
        }
    });
}

export function destroyChart(canvasId) {
    if (chartInstances[canvasId]) {
        chartInstances[canvasId].destroy();
        delete chartInstances[canvasId];
    }
}
