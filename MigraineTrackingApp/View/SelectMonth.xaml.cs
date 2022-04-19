/*
 * Student Name: Michelle Bolger
 * Student Number: C00242743
 * Date: 19/4/2022
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
        List<string> medicationForTheMonth =  new List<string>();
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
        /// <summary>
        /// when month selected pain intensity info and date/time are stored in a list of display graphs and mediction info stored in a string list
        /// display chart for pain intensity and medication taken for the month
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void displayRecord(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            seletedMonth = button.CommandParameter.ToString();
            List<DisplayGraph>recordsForThatMonth = vm.getRecordsForThatMonth(allRecords,seletedMonth,ref medicationForTheMonth);

            await Navigation.PushModalAsync(new DisplayPainIntensityChart(recordsForThatMonth, medicationForTheMonth));
        }
    }
}