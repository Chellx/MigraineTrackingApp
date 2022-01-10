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
        public MainPage()
        {
            InitializeComponent();

            var assemble = typeof(MainPage);

            logoImage.Source = ImageSource.FromResource("MigraineTrackingApp.Assets.Images.logo.png", assemble);

        }

        private void loginButton_Clicked(object sender, EventArgs e)
        {
            bool isEmailEmpty = string.IsNullOrEmpty(loginEmail.Text); //check if email input empty or null
            bool isPassEmpty = string.IsNullOrEmpty(loginPassWord.Text); //check if password field is empty

            if(isEmailEmpty == true || isPassEmpty == true)
            {

            }
            else
            {
                //authenticated user

                //navigate to home page
                Navigation.PushAsync(new HomePage());
            }



           


        }

        private void createAccountButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreateAccountPage());
        }
    }
}