/*
 * Student Name: Michelle Bolger
 * Student Number C00242743
 */

using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MigraineTrackingApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateAccountPage : ContentPage
    {
        IAuth auth;
        public CreateAccountPage(IAuth auth)
        {
            InitializeComponent();
            var assemble = typeof(CreateAccountPage);
            logoImage.Source = ImageSource.FromResource("MigraineTrackingApp.Assets.Images.logo.png", assemble);
            this.auth = auth;
        }
        private async void createAccount(object sender, EventArgs e)
        {
            string uid  = await auth.SignupWithEmailPassword(memberEmail.Text, confirmAccPassWord.Text);
            await Navigation.PushModalAsync(new MainFeedPage(uid, memberEmail.Text,auth));
        }
    }
}