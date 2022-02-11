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
    public partial class RecordMigraine : ContentPage
    {
        RecordMigraneViewModel migraneVM = new RecordMigraneViewModel();
        public RecordMigraine()
        {
            InitializeComponent();
        }



        private async void backButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HomePage());
        }

        private async void recordDateButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new View.RecordDate(migraneVM));
        }

        private async void recordTypeButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new View.RecordMigraineType(migraneVM));
        }

        private async void recordpainLocationButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new View.RecordPainLocation(migraneVM));
        }

        private async void recordMedTypeButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new View.RecordMedication(migraneVM));
        }

        private async void recordSymptomsButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new View.RecordSymptoms(migraneVM));
        }

        private async void recordTriggersButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new View.RecordTriggers(migraneVM));
        }

        private async void recordWeatherButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new View.RecordWeather(migraneVM));
        }

        private async void recordTimeButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new View.RecordTime(migraneVM));
        }

        private async void recordFoodButton_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new View.RecordFood(migraneVM));
        }

        private async void recordPainIntensityButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new View.RecordPainIntensity(migraneVM));
        }


    }
}