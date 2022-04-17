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
        IAuth auth;
        public showPreviousRecords(string id,string email, List<Migraine> mig, IAuth auth)
        {
            InitializeComponent();
            userId = id;
            this.email = email;
            allRecords = mig;
            this.auth = auth;
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
            int spacePos = recordAtADate.startDate.IndexOf(" ");
            int spacePos2 = recordAtADate.endDate.IndexOf(" ");
            recordAtADate.startDate = recordAtADate.startDate.Substring(0, spacePos);
            recordAtADate.endDate = recordAtADate.endDate.Substring(0, spacePos2);
            await Navigation.PushModalAsync(new ShowMigraineDetails(recordAtADate, email, userId, auth));
        }
    }
}