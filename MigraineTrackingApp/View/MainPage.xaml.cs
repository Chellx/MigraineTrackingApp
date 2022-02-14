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
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);



            //Navigation.PushModalAsync(new RecordMigraine());

            var assemble = typeof(MainPage);


            auth = DependencyService.Get<IAuth>(); // put in create user too
            logoImage.Source = ImageSource.FromResource("MigraineTrackingApp.Assets.Images.logo.png", assemble);

        }

        private async void loginButton_Clicked(object sender, EventArgs e)

        {
            //Reference: https://www.lindseybroos.be/2020/03/xamarin-forms-and-firebase-authentication/ 

            bool isEmailEmpty = string.IsNullOrEmpty(loginEmail.Text); //check if email input empty or null
            bool isPassEmpty = string.IsNullOrEmpty(loginPassWord.Text); //check if password field is empty
            string userID = await auth.LoginWithEmailPassword(loginEmail.Text, loginPassWord.Text); //put in create user page
            //string Token = await auth.LoginWithEmailPassword(loginEmail.Text, loginPassWord.Text); stay here for login
            if (userID != "")
            {
                await Navigation.PushAsync(new MainFeedPage(userID));
            }
            else
            {
                await DisplayAlert("error", "invalid username and password", "ok");
            }


            /*if (isEmailEmpty == true || isPassEmpty == true)
            {

            }
            else
            {
                //authenticated user

                //navigate to home page
                
            }*/



           


        }

        private async void googleLoginButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainFeedPage( " "));
        }

        private void createAccountButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreateAccountPage(auth));
        }
    }
}