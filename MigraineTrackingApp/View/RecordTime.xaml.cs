/*
 * Student Name: Michelle Bolger
 * Student Number C00242743
 */

using MigraineTrackingApp.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MigraineTrackingApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecordTime : ContentPage
    {
        RecordMigraneViewModel mvm;
        string lengthOfAttack = "";
        internal RecordTime(RecordMigraneViewModel migraneVM)
        {
            InitializeComponent();
            mvm = migraneVM;
            if (migraneVM.StartTimeOfMigraine != " " && migraneVM.StartTimeOfMigraine != null)
            {
                start.Time = TimeSpan.Parse(migraneVM.StartTimeOfMigraine);
            }
            else
            {
                start.Time = DateTime.Now.TimeOfDay;
            }
            if (migraneVM.EndTimeOfMigraine != " " && migraneVM.EndTimeOfMigraine != null)
            {

                start.Time = TimeSpan.Parse(migraneVM.EndTimeOfMigraine);
            }
            else
            {
                end.Time = DateTime.Now.TimeOfDay;
            }   
        }
        void OnSwitchToggled(object sender, ToggledEventArgs args)
        {
            Recalculate();
        }

        void Recalculate()
        {
            var startTime = start.Time;

            var endTime = end.Time;
            var timeDiff = endTime.Subtract(startTime);
            if (startTime > endTime)
            {
                timeDiff = timeDiff.Add(TimeSpan.FromHours(12));
            }
            resultLabel.Text = String.Format("Length Of Migraine Attack: {0} Hours {1} Minutes {2} Seconds", timeDiff.Hours,timeDiff.Minutes,timeDiff.Seconds );
            lengthOfAttack = timeDiff.Hours + ":" + timeDiff.Minutes + ":" + timeDiff.Seconds;
        }


        private async void returnToMenu(object sender, EventArgs args)
        {
            await Navigation.PopAsync();
        }

        private async void recordButton_Clicked(object sender, EventArgs e)
        {
            Recalculate();
            mvm.LengthOfMigraineAttack = lengthOfAttack;
            mvm.StartTimeOfMigraine = start.Time.ToString();
            mvm.EndTimeOfMigraine = end.Time.ToString();
            await Navigation.PopAsync();
        }
    }
}