/*
 * Student Name: Michelle Bolger
 * Student Number C00242743
 */

using MigraineTrackingApp.Models;
using MigraineTrackingApp.View;
using MigraineTrackingApp.ViewModels;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MigraineTrackingApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainFeedPage : ContentPage
    {
        string userId = "";
        private ShowMigraineRecordsViewModel vm = new ShowMigraineRecordsViewModel();
        List<Migraine> allRecords;
        List<string> months = new List<string>();
        public MainFeedPage(string userId,string email)
        {
            InitializeComponent();
            var assemble = typeof(MainFeedPage);

            this.userId = userId;
            vm.Email = email;
            logoImage.Source = ImageSource.FromResource("MigraineTrackingApp.Assets.Images.logo.png", assemble);

        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
        }
        private async void recordMigraineButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new RecordMigraine(userId));
        }
        private async void profileButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ProfilePage(userId));
        }
        private async void allergenButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AllergenScanner(userId));
        }
        private async void recordsButton_Clicked(object sender, EventArgs e)
        {
            allRecords = await vm.getAllPrevousMigraineRecords(userId);
            await Navigation.PushModalAsync(new showPreviousRecords(userId, vm.Email, allRecords));
        }
        private async void statsButton_Clicked(object sender, EventArgs e)
        {
            allRecords = await vm.getAllPrevousMigraineRecords(userId);
            months = vm.getListOfMonths(allRecords, months);
            await Navigation.PushModalAsync(new SelectMonth(allRecords,months));
        }
        protected override bool OnBackButtonPressed() => true;
    }
}