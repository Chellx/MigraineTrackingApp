using MigraineTrackingApp.Models;
using MigraineTrackingApp.View;
using MigraineTrackingApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MigraineTrackingApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainFeedPage : ContentPage
    {
        string userId = "";
        string email = "";
        private ShowMigraineRecordsViewModel vm = new ShowMigraineRecordsViewModel();
        List<Migraine> allRecords;
        List<string> months = new List<string>();
        public MainFeedPage(string userId,string email)
        {
            InitializeComponent();
            this.userId = userId;
            this.email = email;
            
        }
        protected async override void OnAppearing()
        {
            //allRecords = await vm.getAllPrevousMigraineRecords(userId);
            base.OnAppearing();
        }
        private async void recordMigraineButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RecordMigraine(userId));
        }
        private async void profileButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfilePage(userId));
        }
        private async void allergenButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AllergenScanner(userId));
        }
        private async void recordsButton_Clicked(object sender, EventArgs e)
        {
            allRecords = await vm.getAllPrevousMigraineRecords(userId);
            await Navigation.PushAsync(new showPreviousRecords(userId, email, allRecords));
        }
        private async void statsButton_Clicked(object sender, EventArgs e)
        {
            allRecords = await vm.getAllPrevousMigraineRecords(userId);
            months = vm.getListOfMonths(allRecords, months);
            await Navigation.PushAsync(new SelectMonth(allRecords,months));
        }
    }
}