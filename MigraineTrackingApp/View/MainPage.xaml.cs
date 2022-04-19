/*
 * Student Name: Michelle Bolger
 * Student Number: C00242743
 * Date: 19/4/2022
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MigraineTrackingApp
{
    public partial class MainPage : ContentPage
    {
        IAuth auth; // put in create user too
        bool isEmailEmpty;
        bool isPassEmpty;
        string userID = "";
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);


            var assemble = typeof(MainPage);


            auth = DependencyService.Get<IAuth>(); // 
            logoImage.Source = ImageSource.FromResource("MigraineTrackingApp.Assets.Images.logo.png", assemble);

        }

        /// <summary>
        /// logs in user with successful email and password combo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void loginButton_Clicked(object sender, EventArgs e)

        {
            //Reference: https://www.lindseybroos.be/2020/03/xamarin-forms-and-firebase-authentication/ 

            isEmailEmpty = string.IsNullOrEmpty(loginEmail.Text); //check if email input empty or null
            isPassEmpty = string.IsNullOrEmpty(loginPassWord.Text); //check if password field is empty
            if(!isEmailEmpty && !isPassEmpty)
            {
                userID = await auth.LoginWithEmailPassword(loginEmail.Text, loginPassWord.Text); //put in create user page
            }

            if (userID != "")
            {
                await Navigation.PushModalAsync(new MainFeedPage(userID, loginEmail.Text,auth));
            }
            else
            {
                await DisplayAlert("error", "Invalid Username or Password", "OK");
            }
        }

        /// <summary>
        /// goes to create account page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void createAccountButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new CreateAccountPage(auth));
        }
        protected override bool OnBackButtonPressed() => true;
    }
}