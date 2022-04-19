/*
 * Student Name: Michelle Bolger
 * Student Number: C00242743
 * Date: 19/4/2022
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
        IAuth auth;
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="email"></param>
        /// <param name="auth"></param>
        public MainFeedPage(string userId,string email, IAuth auth)
        {
            InitializeComponent();
            var assemble = typeof(MainFeedPage);

            this.userId = userId;
            vm.Email = email;
            this.auth = auth;
            logoImage.Source = ImageSource.FromResource("MigraineTrackingApp.Assets.Images.logo.png", assemble);

        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
        }
        /// <summary>
        /// goes to record migraine screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void recordMigraineButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new RecordMigraine(userId,vm.Email,auth));
        }
        /// <summary>
        /// goes to profile screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void profileButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ProfilePage(userId));
        }
        /// <summary>
        /// goes to allergen checker screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void allergenButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AllergenScanner(userId));
        }
       /// <summary>
       /// goes to migraine records screen
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private async void recordsButton_Clicked(object sender, EventArgs e)
        {
            allRecords = await vm.getAllPrevousMigraineRecords(userId);
            await Navigation.PushModalAsync(new showPreviousRecords(userId, vm.Email, allRecords,auth));
        }
        /// <summary>
        /// goes to migraine stats screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void statsButton_Clicked(object sender, EventArgs e)
        {
            allRecords = await vm.getAllPrevousMigraineRecords(userId);
            months = vm.getListOfMonths(allRecords, months);
            await Navigation.PushModalAsync(new SelectMonth(allRecords,months));
        }
       /// <summary>
       /// log out button - logs user put of the app
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private async void logout_Clicked(object sender, EventArgs e)
        {
            userId = "";
            auth.Logout();
            await Navigation.PushModalAsync(new MainPage());
        }
        /// <summary>
        /// stops back button from being used - prevents user going back to login screen after succesfull login
        /// </summary>
        /// <returns></returns>
        protected override bool OnBackButtonPressed() => true;
    }
}