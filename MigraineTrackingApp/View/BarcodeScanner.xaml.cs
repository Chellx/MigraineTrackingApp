using MigraineTrackingApp.Services;
using MigraineTrackingApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        internal BarcodeScanner(RecordMigraneViewModel migraneVM)
        {
            InitializeComponent();
            vm = migraneVM;
        }
        private void ZXingScannerView_OnScanResult(ZXing.Result result)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                string value = await food.getFoodNameFromBarcode(result.Text);
                if(value != "Could Not Scan Item!, Please Try Again Or Enter Product Manually On Previous Screen")
                {
                    if (foodNames.Contains(value))
                    {

                    }
                    else
                    {
                        foodNames.Add(value);
                    }
                }
                scanResultText.Text = value;
            });
        }
        private async void returnPrevious(object sender, EventArgs args)
        {
            vm.setFoodEaten(foodNames);
            await Navigation.PopAsync();
        }
    }
}