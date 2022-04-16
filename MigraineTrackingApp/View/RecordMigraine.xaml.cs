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
        public RecordMigraine(string userId)
        {
            InitializeComponent();
            DateTime now = DateTime.Now;
            currentDate = now;
            id = userId;
        }
        internal RecordMigraine(string userId,RecordMigraneViewModel vm)
        {
            InitializeComponent();
            DateTime now = DateTime.Now;
            currentDate = now;
            id = userId;
            migraneVM = vm;
        }
        private async void savePlan(object sender, EventArgs args)
        {
            if(migraneVM.StartDate != null && migraneVM.StartTimeOfMigraine != null)
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
                migraneVM.checkIfAllergensAreInDB(id);
                migraneVM.sendAllergenInfo(id);
                migraneVM.sendRecordDetailsToDataase(newDate, id);
            }
        }

        private async void backButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
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


    }
}