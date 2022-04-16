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



            //Navigation.PushModalAsync(new MainFeedPage("y47GLJJZD4ReYJBoWttbi0WVrp62"));

            var assemble = typeof(MainPage);


            auth = DependencyService.Get<IAuth>(); // put in create user too
            logoImage.Source = ImageSource.FromResource("MigraineTrackingApp.Assets.Images.logo.png", assemble);

        }

        private async void loginButton_Clicked(object sender, EventArgs e)

        {
            //Reference: https://www.lindseybroos.be/2020/03/xamarin-forms-and-firebase-authentication/ 

            isEmailEmpty = string.IsNullOrEmpty(loginEmail.Text); //check if email input empty or null
            isPassEmpty = string.IsNullOrEmpty(loginPassWord.Text); //check if password field is empty
            if(!isEmailEmpty && !isPassEmpty)
            {
                userID = await auth.LoginWithEmailPassword(loginEmail.Text, loginPassWord.Text); //put in create user page
            }
            //string Token = await auth.LoginWithEmailPassword(loginEmail.Text, loginPassWord.Text); stay here for login
            if (userID != "")
            {
                await Navigation.PushAsync(new MainFeedPage(userID, loginEmail.Text));
            }
            else
            {
                await DisplayAlert("error", "Invalid Username or Password", "OK");
            }
        }

        private async void googleLoginButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainFeedPage("y47GLJJZD4ReYJBoWttbi0WVrp62", "test@email.com"));
        }

        private void createAccountButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreateAccountPage(auth));
        }
        protected override bool OnBackButtonPressed() => true;
    }
}