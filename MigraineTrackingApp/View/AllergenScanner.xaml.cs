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
        public AllergenScanner(string userid)
        {
            InitializeComponent();
            id = userid;
            vm = new RecordMigraneViewModel();
        }
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
        private async void checkAllergens(object sender, EventArgs e)
        {
            string allergenResult = "";
            if (allergen != " ")
            {
                string newAllergen = allergen.Substring(3);
                string[] allergens = newAllergen.Split(',');
                allergenResult = await vm.checkScannedItem(id, allergens);
                await DisplayAlert("Allergen Alert!", allergenResult, "OK");

               scanResultText.Text = allergenResult;
                allergen = " ";
            }
        }
    }
}