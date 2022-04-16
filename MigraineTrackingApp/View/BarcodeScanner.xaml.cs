/*
 * Student Name: Michelle Bolger
 * Student Number C00242743
 */

using MigraineTrackingApp.Services;
using MigraineTrackingApp.ViewModels;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MigraineTrackingApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BarcodeScanner : ContentPage
    {
        OpenFoodFacts food = new OpenFoodFacts();
        RecordMigraneViewModel vm;
        List<string> foodNames = new List<string>();
        string[] foodDetails = new string[2];
        internal BarcodeScanner(RecordMigraneViewModel migraneVM)
        {
            InitializeComponent();
            vm = migraneVM;
        }
        private void ZXingScannerView_OnScanResult(ZXing.Result result)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                foodDetails = await food.getFoodNameFromBarcode(result.Text);
                bool isTrue = foodDetails[0].Equals("Could Not Scan Item!, Please Try Again Or Enter Product Manually On Previous Screen");
                if (isTrue == false)
                {
                    if (foodNames.Contains(foodDetails[0]))
                    {

                    }
                    else
                    {
                        foodNames.Add(foodDetails[0]);
                    }
                }
                scanResultText.Text = foodDetails[0];
            });
        }
        private async void returnPrevious(object sender, EventArgs args)
        {
            vm.setFoodEaten(foodNames);
            string allergen = foodDetails[1];
            string newAllergen = allergen.Substring(3);
            string[] allergens = newAllergen.Split(',');
            vm.setAllAllergenypes(allergens);
            await Navigation.PopAsync();
        }
    }
}