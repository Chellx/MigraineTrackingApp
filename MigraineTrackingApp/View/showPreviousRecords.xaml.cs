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
    public partial class showPreviousRecords : ContentPage
    {
        private ShowMigraineRecordsViewModel vm = new ShowMigraineRecordsViewModel();
        List<Migraine> allRecords;
        string selectedDate;
        private string userId;
        Migraine recordAtADate;
        string email = "";
        public showPreviousRecords(string id,string email, List<Migraine> mig)
        {
            InitializeComponent();
            userId = id;
            this.email = email;
            allRecords = mig;
        }
        protected async override void OnAppearing()
        {
            //allRecords = await vm.getAllPrevousMigraineRecords(userId);
            var records = allRecords.Select(i => i.dateEntered).ToList();
            listView.ItemsSource = records;
            base.OnAppearing();
        }
        private async void displayRecord(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            selectedDate = button.CommandParameter.ToString();
            foreach(Migraine record in allRecords)
            {
                if(record.dateEntered == selectedDate)
                {
                    recordAtADate = record;
                    break;
                }
            }
            await Navigation.PushModalAsync(new ShowMigraineDetails(recordAtADate, email, userId));
        }
    }
}