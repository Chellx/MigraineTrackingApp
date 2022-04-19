/*
 * Student Name: Michelle Bolger
 * Student Number: C00242743
 * Date: 19/4/2022
 */

using MigraineTrackingApp.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MigraineTrackingApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecordPainIntensity : ContentPage
    {
        RecordMigraneViewModel mvm;
        
        internal RecordPainIntensity(RecordMigraneViewModel migraneVM)
        {
            InitializeComponent();
            mvm = migraneVM;
            if(migraneVM.PainIntensity != " " && migraneVM.PainIntensity != null)
            {
                Intensity.SelectedItem = migraneVM.PainIntensity;
            }
        }

       /// <summary>
       /// go to main menu
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="args"></param>
        private async void returnToMenu(object sender, EventArgs args)
        {
            await Navigation.PopAsync();
        }

        /// <summary>
        /// saves pain intensity 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private async void saveIntensity(object sender, EventArgs args)
        {
           
            if (Intensity.SelectedIndex != -1)
            {
                
                mvm.PainIntensity= Intensity.SelectedItem.ToString();
                await Navigation.PopModalAsync();
            }
            else
            {
                await DisplayAlert("Alert", "Please Selecr A Level Of Pain Intensity", "OK");
            }
        }
    }
}