/*
 * Student Name: Michelle Bolger
 * Student Number C00242743
 */

using MigraineTrackingApp.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MigraineTrackingApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecordMigraine : ContentPage
    {
        RecordMigraneViewModel migraneVM = new RecordMigraneViewModel();
        DateTime currentDate;
        string id = "";
        string email = "";
        IAuth auth;
        public RecordMigraine(string userId, string email, IAuth auth)
        {
            InitializeComponent();
            DateTime now = DateTime.Now;
            currentDate = now;
            id = userId;
            this.email = email;
            this.auth = auth;
        }
        internal RecordMigraine(string userId,RecordMigraneViewModel vm,string email, IAuth auth)
        {
            InitializeComponent();
            DateTime now = DateTime.Now;
            currentDate = now;
            id = userId;
            migraneVM = vm;
            this.email = email;
            this.auth = auth;
        }
        private async void savePlan(object sender, EventArgs args)
        {
            if(migraneVM.StartDate != " " && migraneVM.StartTimeOfMigraine == " ")
            {
                migraneVM.checkIfAllergensAreInDB(id);
                migraneVM.sendAllergenInfo(id);
                migraneVM.sendRecordDetailsToDataase(migraneVM.StartDate, id);
            }
            else if(migraneVM.StartDate != null && migraneVM.StartTimeOfMigraine != null)
            {
                int firstSpaceIndex = migraneVM.StartDate.IndexOf(" ");//get first spcae
                string date = migraneVM.StartDate.Substring(0, firstSpaceIndex);
                date = date + " " + migraneVM.StartTimeOfMigraine;
                string newDate = date.Replace("/", "-");
                migraneVM.checkIfAllergensAreInDB(id);
                migraneVM.sendAllergenInfo(id);
                migraneVM.sendRecordDetailsToDataase(newDate, id);
            }
            else
            {
                string newDate = currentDate.ToString("dd'/'MM'/'yyyy HH:mm:ss");

                newDate = newDate.Replace("/", "-");
                migraneVM.StartDate = newDate;
                migraneVM.checkIfAllergensAreInDB(id);
                migraneVM.sendAllergenInfo(id);
                migraneVM.sendRecordDetailsToDataase(newDate, id);
            }
        }

        private async void backButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new MainFeedPage(id, email, auth));
        }

        private async void recordDateButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new View.RecordDate(migraneVM));
        }

        private async void recordTypeButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new View.RecordMigraineType(migraneVM));
        }

        private async void recordpainLocationButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new View.RecordPainLocation(migraneVM));
        }

        private async void recordMedTypeButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new View.RecordMedication(migraneVM));
        }

        private async void recordSymptomsButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new View.RecordSymptoms(migraneVM));
        }

        private async void recordTriggersButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new View.RecordTriggers(migraneVM));
        }

        private async void recordWeatherButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new View.RecordWeather(migraneVM));
        }

        private async void recordTimeButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new View.RecordTime(migraneVM));
        }

        private async void recordFoodButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new View.RecordFood(migraneVM));
        }

        private async void recordPainIntensityButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new View.RecordPainIntensity(migraneVM));
        }
        protected override bool OnBackButtonPressed() => true;

    }
}