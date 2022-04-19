/*
 * Student Name: Michelle Bolger
 * Student Number: C00242743
 * Date: 19/4/2022
 */

using MigraineTrackingApp.ViewModels;
using System;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MigraineTrackingApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecordDate : ContentPage
    {
        RecordMigraneViewModel migraneVM;
        internal RecordDate(RecordMigraneViewModel migraneVM)
        {
            InitializeComponent();
            this.migraneVM = migraneVM;
            if(migraneVM.StartDate != " " && migraneVM.StartDate != null)
            {
                DateTime dateTime = DateTime.Parse(migraneVM.StartDate, CultureInfo.CreateSpecificCulture("en-US")); //converts date string from database to date time format for date picker
                string newStartDate = dateTime.ToString("dd/MM/yyyy");
                startDatePicker.Date = DateTime.Parse(newStartDate);
            }
            if(migraneVM.EndDate != " " && migraneVM.EndDate != null)
            {
                DateTime dateTime = DateTime.Parse(migraneVM.EndDate, CultureInfo.CreateSpecificCulture("en-US"));
                string newEndDate = dateTime.ToString("dd/MM/yyyy");
                endDatePicker.Date = DateTime.Parse(newEndDate);
            }
        }

        void OnDateSelected(object sender, DateChangedEventArgs args)
        {
            Recalculate();
        }

        void OnSwitchToggled(object sender, ToggledEventArgs args)
        {
           Recalculate();
        }

        /// <summary>
        /// calculates amount of days inbetween start and end date
        /// </summary>
        void Recalculate()
        {
            //Ref: https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/datepicker

            TimeSpan timeSpan = endDatePicker.Date - startDatePicker.Date +
                (includeSwitch.IsToggled ? TimeSpan.FromDays(1) : TimeSpan.Zero);

            resultLabel.Text = String.Format("{0} day{1} between dates",
                                                timeSpan.Days, timeSpan.Days == 1 ? "" : "s");


         
        }

        /// <summary>
        /// return to menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private async void returnToMenu(object sender, EventArgs args)
        {
            await Navigation.PopModalAsync();
        }

       /// <summary>
       /// saves selected start and end dates
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="args"></param>
        private async void saveDates(object sender, EventArgs args)
        {
            string sTime = startDatePicker.Date.ToString();
            string eTime = endDatePicker.Date.ToString();
            int pos = sTime.IndexOf(" ");
            string date  = sTime.Substring(0, pos);
            int ePos = eTime.IndexOf(" ");
            string eDate = eTime.Substring(0, ePos);
            migraneVM.StartDate = date;
            migraneVM.EndDate = eDate;
            await Navigation.PopModalAsync();
        }
    }
}