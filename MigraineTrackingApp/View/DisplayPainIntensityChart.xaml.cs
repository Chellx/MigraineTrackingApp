/*
 * Student Name: Michelle Bolger
 * Student Number: C00242743
 * Date: 19/4/2022
 */

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
       /// <summary>
       /// populates listview for medication taken for the month
       /// </summary>
       /// <param name="allRecords">list of pain intensity and date/time</param>
       /// <param name="meds">string list of medication taken</param>
        public DisplayPainIntensityChart(List<DisplayGraph> allRecords,List<string> meds)
        {
            InitializeComponent();
            records = allRecords;
            populateChart();
            MyLineChart.Chart = new LineChart { Entries = chartEntries };
            showListView.ItemsSource = meds;
        }
       
        /// <summary>
        /// populates microchart with pain intensity value and date/time
        /// </summary>
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