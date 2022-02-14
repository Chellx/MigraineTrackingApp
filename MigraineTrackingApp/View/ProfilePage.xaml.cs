using MigraineTrackingApp.Models;
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
    public partial class ProfilePage : ContentPage
    {
        MemberViewModel memberVm;
        string Id = "";
        public ProfilePage(string userId)
        {
            InitializeComponent();
            this.Id = userId;
        }

        protected async override void OnAppearing()
        {

            base.OnAppearing();
            memberVm = new MemberViewModel();
            var member = await memberVm.getMember(Id); //gets list back from viewModel
            memberEmail.Text = member.Email;
            memberFirstName.Text = member.FirstName;
            memberLastName.Text = member.LastName;
            memberGender.Text = member.Gender;
            memberDob.Text = member.Dob;
        }
    }
}