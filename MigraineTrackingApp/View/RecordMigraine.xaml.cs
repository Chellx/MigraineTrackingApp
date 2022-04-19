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
            DateTime now = DateTime.Now; // set date to current date
            currentDate = now;
            id = userId;
            migraneVM = vm;
            this.email = email;
            this.auth = auth;
        }
       /// <summary>
       /// depends on which way record migraine is entered
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="args"></param>
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
                string date = migraneVM.StartDate + " " + migraneVM.StartTimeOfMigraine;
                string newDate = date.Replace("/", "-");
                migraneVM.checkIfAllergensAreInDB(id);
                migraneVM.sendAllergenInfo(id);
                migraneVM.sendRecordDetailsToDataase(newDate, id);
            }
            else if (migraneVM.StartDate != null && migraneVM.StartTimeOfMigraine == null)
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
                int firstSpaceIndex = newDate.IndexOf(" ");//get first spcae
                string date = newDate.Substring(0, firstSpaceIndex);
                string time = newDate.Substring(firstSpaceIndex+1);
                newDate = newDate.Replace("/", "-");
                migraneVM.StartDate = date;
                migraneVM.StartTimeOfMigraine = time;
                migraneVM.checkIfAllergensAreInDB(id);
                migraneVM.sendAllergenInfo(id);
                migraneVM.sendRecordDetailsToDataase(newDate, id);
            }
        }

        private async void backButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new MainFeedPage(id, email, auth));
        }

       /// <summary>
       /// go to record date page
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private async void recordDateButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new View.RecordDate(migraneVM));
        }

       /// <summary>
       /// go to record type page
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private async void recordTypeButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new View.RecordMigraineType(migraneVM));
        }

       /// <summary>
       /// go to record pain location page
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private async void recordpainLocationButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new View.RecordPainLocation(migraneVM));
        }

        /// <summary>
        /// go to record medication taken page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void recordMedTypeButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new View.RecordMedication(migraneVM));
        }

       /// <summary>
       /// go to record symptom page
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private async void recordSymptomsButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new View.RecordSymptoms(migraneVM));
        }

      /// <summary>
      /// go to record triggers page
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
        private async void recordTriggersButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new View.RecordTriggers(migraneVM));
        }

        /// <summary>
        /// go to record weather page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void recordWeatherButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new View.RecordWeather(migraneVM));
        }

      /// <summary>
      /// go to record time page
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
        private async void recordTimeButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new View.RecordTime(migraneVM));
        }

       /// <summary>
       /// go to record food page
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private async void recordFoodButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new View.RecordFood(migraneVM));
        }

      /// <summary>
      /// go to record pain intensity page
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
        private async void recordPainIntensityButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new View.RecordPainIntensity(migraneVM));
        }
        protected override bool OnBackButtonPressed() => true;
        

    }
}