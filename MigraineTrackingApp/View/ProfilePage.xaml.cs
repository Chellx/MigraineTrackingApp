/*
 * Student Name: Michelle Bolger
 * Student Number C00242743
 */

using MigraineTrackingApp.View;
using MigraineTrackingApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MigraineTrackingApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        MemberViewModel memberVm;
        string Id = "";
        private RadioButton button;
        
        public ProfilePage(string userId)
        {
            InitializeComponent();
            this.Id = userId;

            var assemble = typeof(ProfilePage);

            logoImage.Source = ImageSource.FromResource("MigraineTrackingApp.Assets.Images.logo.png", assemble);
        }

        protected async override void OnAppearing()
        {

            base.OnAppearing();
            memberVm = new MemberViewModel();
            var member = await memberVm.getMember(Id); //gets list back from viewModel
            if(member != null)
            {
                memberFirstName.Text = member.FirstName;
                gen.Text = member.Gender;
                memberDob.Text = member.Dob;
            }
        }
        /// <summary>
        /// This button goes to the update page 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void updateInfo(System.Object sender, System.EventArgs e)
        {
            if(memberFirstName.Text == null)
            {
                memberFirstName.Text = " ";
            }
            if(memberDob.Text == null)
            {
                memberDob.Text = " ";
            }
            if (gen.Text == null)
            {
                gen.Text = " ";
            }
            await Navigation.PushModalAsync(new UpdateProfile(memberFirstName.Text, memberDob.Text, gen.Text, Id));
        }
    }
}