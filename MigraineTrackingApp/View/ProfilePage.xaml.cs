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
        public ProfilePage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {

            base.OnAppearing();
            memberVm = new MemberViewModel();
            List<Member> memberList = await memberVm.getListOfMembers(); //gets list back from viewModel
            memberEmail.Text = memberList[0].Email;
            memberFirstName.Text = memberList[0].FirstName;
            memberLastName.Text = memberList[0].LastName;
            memberGender.Text = memberList[0].Gender;
            memberDob.Text = memberList[0].Dob;
        }
    }
}