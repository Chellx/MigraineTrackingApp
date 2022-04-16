/*
 * Student Name: Michelle Bolger
 * Student Number C00242743
 */

using MigraineTrackingApp.Models;
using MigraineTrackingApp.ViewModels;
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
    public partial class SelectMonth : ContentPage
    {
        List<string> months;
        string seletedMonth;
        List<Migraine> allRecords;
        private ShowMigraineRecordsViewModel vm = new ShowMigraineRecordsViewModel();
        public SelectMonth(List<Migraine> allRecords,List<string> months)
        {
            InitializeComponent();
            this.months = months;
            this.allRecords = allRecords;
        }
        protected async override void OnAppearing()
        {
            listView.ItemsSource = months;
            base.OnAppearing();
        }
        private async void displayRecord(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            seletedMonth = button.CommandParameter.ToString();
            List<DisplayGraph>recordsForThatMonth = vm.getRecordsForThatMonth(allRecords,seletedMonth);

            await Navigation.PushModalAsync(new DisplayPainIntensityChart(recordsForThatMonth));
        }
    }
}