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
    public partial class showPreviousRecords : ContentPage
    {
        List<Migraine> allRecords;
        string selectedDate;
        private string userId;
        Migraine recordAtADate;
        string email = "";
        IAuth auth;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="email"></param>
        /// <param name="mig"></param>
        /// <param name="auth"></param>
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
            var records = allRecords.Select(i => i.dateEntered).ToList();
            listView.ItemsSource = records;
            base.OnAppearing();
        }
       /// <summary>
       /// gets selected date from all records passes to show migraine detail page
       /// 
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
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
           
            await Navigation.PushModalAsync(new ShowMigraineDetails(recordAtADate, email, userId, auth));
        }
    }
}