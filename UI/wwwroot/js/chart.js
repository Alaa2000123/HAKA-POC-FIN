$(function() {
  /* ChartJS
   * -------
   * Data and config for chartjs
   */
  'use strict';
    var yLabels = {
        0: ' ',
        2: 'Request New Car',
        4: 'Request Maintenance',
        6: 'Request Car Information',
        8: 'Request Location',
        10: 'Request Diposable',    
    }

  var multiLineData = {
      labels: ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"],
      
    datasets: [{
        label: 'Car No :18-59582',
        data: [2, 0, 0, 4, 0, 0, 4, 2, 0],
        borderColor: [
          '#587ce4'
        ],
        borderWidth: 2,
        fill: false
      },
      {
          label: 'Car No :13-51515',
        data: [0, 2, 4, 0, 6, 0, 0, 0, 8],
        borderColor: [
          '#ede190'
        ],
        borderWidth: 2,
        fill: false
      },
      {
          label: 'Car No :10-52244',
        data: [2, 0, 0, 0, 6, 4, 0, 0, 10],
        borderColor: [
          '#f44252'
        ],
        borderWidth: 2,
        fill: false
      },
     
    ]
  };
  var options = {
      scales: {
          xAxes: [{
              display: true,
              scaleLabel: {
                  display: true,
                  labelString: 'Month'
              }
          }],

      yAxes: [{
          display: true,
          scaleLabel: {
              display: true,
              labelString: 'Type of Request'
          },
          ticks: {
              beginAtZero: true,
              callback: function (value, index, values) {
                  return yLabels[value];
              }
          }
      }]
    },
    legend: {
      display: true
    },
    elements: {
      point: {
        radius: 0
      }
    }

  };
  

  if ($("#linechart-multi").length) {
    var multiLineCanvas = $("#linechart-multi").get(0).getContext("2d");
    var lineChart = new Chart(multiLineCanvas, {
      type: 'line',
      data: multiLineData,
      options: options
    });
  }

});