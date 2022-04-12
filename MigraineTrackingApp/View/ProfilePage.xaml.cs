using MigraineTrackingApp.Models;
using MigraineTrackingApp.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MigraineTrackingApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        MemberViewModel memberVm;
        Stream stream;
        string fileName;
        string Id = "";
        private RadioButton button;
        private string gender = "";
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
                memberLastName.Text = member.LastName;
               // memberDob.Text = member.Dob;
            }
        }

        private void getGender(object sender, CheckedChangedEventArgs e)
        {
            button = sender as RadioButton;
            gender = button.Content.ToString();
        }


        /*  async void Button_Clicked(System.Object sender, System.EventArgs e)
          {
              var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
              {
                  Title = "Please pick a photo"
              });

              if (result != null)
              {
                  stream = await result.OpenReadAsync();
                  fileName = result.FileName;//returns pic name

                  resultImage.Source = ImageSource.FromStream(() => stream);

                  //Image image = ImageSource.FromStream(() => stream);
              }
          }*/
        async void updateInfo(System.Object sender, System.EventArgs e)
        {
           memberVm.createProfile(memberFirstName.Text, memberLastName.Text, memberDob.Date.ToString(), gender,Id, fileName);
            
           // memberVm.uploadPhoto(stream,fileName);
        }
    }
}