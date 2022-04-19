/*
 * Student Name: Michelle Bolger
 * Student Number: C00242743
 * Date: 19/4/2022
 */

using MigraineTrackingApp.Services;
using MigraineTrackingApp.ViewModels;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MigraineTrackingApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    
    public partial class AllergenScanner : ContentPage
    {
        OpenFoodFacts food = new OpenFoodFacts();
        RecordMigraneViewModel vm;
        string[] foodDetails = new string[2];
        string id = " ";
        string allergen = " ";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userid"></param>
        public AllergenScanner(string userid)
        {
            InitializeComponent();
            id = userid;
            vm = new RecordMigraneViewModel();
        }
       /// <summary>
       /// scans iten with ZXing barcode scanner 
       /// gets barcode from item sends to openfoodfacts
       /// </summary>
       /// <param name="result"></param>
        private void ZXingScannerView_OnScanResult(ZXing.Result result)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                foodDetails = await food.getFoodNameFromBarcode(result.Text);
                bool isTrue = foodDetails[0].Equals("Could Not Scan Item!");
                if (isTrue == false)
                {
                    scanResultText.Text = "Item Scanned!";
                    allergen = foodDetails[1];
                }
                else{
                    scanResultText.Text = foodDetails[0];
                }
            });
        }
        /// <summary>
        /// button when clicked checks allergens from openfoodfacts against the allergens stored in database for the user
        /// </summary>
        /// <param name="sender"> </param>
        /// <param name="e"></param>
        private async void checkAllergens(object sender, EventArgs e)
        {
            string allergenResult = "";
            if (allergen != "")
            {
                string newAllergen = allergen.Substring(3);
                string[] allergens = newAllergen.Split(',');
                allergenResult = await vm.checkScannedItem(id, allergens);
                await DisplayAlert("Allergen Alert!", allergenResult, "OK");

               scanResultText.Text = allergenResult;
                allergen = " ";
            }
            else
            {
                await DisplayAlert("Alert!","Did Not Find Allergens, Check openfoodfacts.org For More Information", "OK");
            }
        }
    }
}