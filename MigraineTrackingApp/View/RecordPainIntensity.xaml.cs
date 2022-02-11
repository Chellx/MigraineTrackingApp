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
        string painLevel = "";
        internal RecordPainIntensity(RecordMigraneViewModel migraneVM)
        {
            InitializeComponent();
            mvm = migraneVM;
        }
        private async void saveIntensity(object sender, EventArgs args)
        {
           
            if (Intensity.SelectedIndex != -1)
            {
                
                mvm.PainIntensity= Intensity.SelectedItem.ToString();
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Alert", "Pick A Level Of Pain Intensity", "OK");
            }
        }
    }
}