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
                DateTime dateTime = DateTime.Parse(migraneVM.StartDate, CultureInfo.CreateSpecificCulture("en-US"));
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

        void Recalculate()
        {
            //Ref: https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/datepicker

            TimeSpan timeSpan = endDatePicker.Date - startDatePicker.Date +
                (includeSwitch.IsToggled ? TimeSpan.FromDays(1) : TimeSpan.Zero);

            resultLabel.Text = String.Format("{0} day{1} between dates",
                                                timeSpan.Days, timeSpan.Days == 1 ? "" : "s");


         
        }

        private async void returnToMenu(object sender, EventArgs args)
        {
            await Navigation.PopModalAsync();
        }

        private async void saveDates(object sender, EventArgs args)
        {
            migraneVM.StartDate = startDatePicker.Date.ToString();
            migraneVM.EndDate = endDatePicker.Date.ToString();
            await Navigation.PopModalAsync();
        }
    }
}