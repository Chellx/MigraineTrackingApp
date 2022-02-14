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
    public partial class CreateAccountPage : ContentPage
    {
        IAuth auth;
        MemberViewModel model = new MemberViewModel();
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
            model.createProfile(memberFirstName.Text,memberLastName.Text,memberDob.Text,memberGender.Text,uid);
        }
    }
}