using Microcharts;
using MigraineTrackingApp.Models;
using SkiaSharp;
using Syncfusion.SfChart.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MigraineTrackingApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DisplayPainIntensityChart : ContentPage
    {
        List<DisplayGraph> records;
        private List<Microcharts.ChartEntry> chartEntries = new List<Microcharts.ChartEntry>();
        Microcharts.ChartEntry chart;
        public DisplayPainIntensityChart(List<DisplayGraph> allRecords)
        {
            InitializeComponent();
            records = allRecords;
            populateChart();
            MyLineChart.Chart = new LineChart { Entries = chartEntries };
            //LineChart.Chart = new LineChart { chartEntries = _entries };
            //chartView.ItemsSource = allRecords;
        }
       
        private void populateChart()
        {
            foreach (DisplayGraph value in records)
            {
                chart = new Microcharts.ChartEntry(value.PainLevel)
                {
                    Label = value.Date,
                    ValueLabel = value.PainLevel.ToString(),
                    Color = SKColor.Parse("#00AB58")
                };
                chartEntries.Add(chart);
            }
        }
    }
}