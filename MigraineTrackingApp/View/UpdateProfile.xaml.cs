using MigraineTrackingApp.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MigraineTrackingApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdateProfile : ContentPage
    {
        MemberViewModel memberVm = new MemberViewModel();
        string Id = "";
        private RadioButton button;
        private string gender = "";
        string firstName = "";
        string dob = "";

        public UpdateProfile(string memberFirstName,string memberDob,string gen,string userId)
        {
            InitializeComponent();
            this.Id = userId;
            firstName = memberFirstName;
            dob = memberDob;
            this.gender = gen;
            var assemble = typeof(ProfilePage);

            logoImage.Source = ImageSource.FromResource("MigraineTrackingApp.Assets.Images.logo.png", assemble);
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            memberFirstName.Text = firstName;
            memberDob.Date = DateTime.Parse(dob);
        }
        /// <summary>
        /// This button gets the gender from the picked radio button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void getGender(object sender, CheckedChangedEventArgs e)
        {
            button = sender as RadioButton;
            gender = button.Content.ToString();
        }

        /// <summary>
        /// This button sends the firstname dob and gender to database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void updateInfo(System.Object sender, System.EventArgs e)
        {
            string dateAndTime = memberDob.Date.ToString();
            int spacePosition = dateAndTime.IndexOf(" ");
            string dateOnly = dateAndTime.Substring(0,spacePosition);
            memberVm.createProfile(memberFirstName.Text, dateOnly, gender, Id);
        }
    }
}