/*
 * Student Name: Michelle Bolger
 * Student Number: C00242743
 * Date: 19/4/2021
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
    public partial class RecordFood : ContentPage
    {
        List<string> food = new List<string>();
        RecordMigraneViewModel migraneVM;
        OpenFoodFacts barcode = new OpenFoodFacts();
        internal RecordFood(RecordMigraneViewModel migraneVM)
        {
            InitializeComponent();
            this.migraneVM = migraneVM;
        }
       /// <summary>
       /// populates list view with list of food items
       /// </summary>
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            List<string> scannedItems = migraneVM.getFoodEaten();
            if (food.Count != 0)
            {
                if (scannedItems.Count != 0)
                {
                    food.AddRange(scannedItems);
                    showListView.ItemsSource = null;
                    showListView.ItemsSource = food;
                }
            }
            else
            {
                if (scannedItems.Count != 0)
                {
                    food.AddRange(scannedItems);
                    showListView.ItemsSource = null;
                    showListView.ItemsSource = food;
                }
            }
            migraneVM.resetFoodList();
            if (migraneVM.getFoodEaten().Count != 0 && !migraneVM.getFoodEaten().Contains(" "))
            {
                food.AddRange(migraneVM.getFoodEaten());
                showListView.ItemsSource = migraneVM.getFoodEaten();
            }
        }
       /// <summary>
       /// add scan food to list of food items
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="args"></param>
        private void addToList(object sender, EventArgs args)
        {
            if (addFood.Text != null)
            {
                food.Add(addFood.Text);
                addFood.Text = "";
                showListView.ItemsSource = null;
                showListView.ItemsSource = food;
            }
        }

        /// <summary>
        /// go to barcode scanner
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private async void goToScan(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new BarcodeScanner(migraneVM));
        }


        private void removeFromList(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            string value = button.CommandParameter.ToString();

            food.RemoveAll(x => x.StartsWith(value));
            showListView.ItemsSource = null;
            showListView.ItemsSource = food;
        }
        /// <summary>
        /// Returns to previous menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private async void returnToMenu(object sender, EventArgs args)
        {
            await Navigation.PopModalAsync();
        }
        /// <summary>
        /// This method saves the food list to a view model
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private async void saveFoodList(object sender, EventArgs args)
        {
            if (food.Count != 0)
            {
                migraneVM.getFoodEaten().Clear();
                migraneVM.setFoodEaten(food);
                await Navigation.PopModalAsync();
            }
            else
            {
                await DisplayAlert("Alert", "You Have Not Entered Any Food!", "OK");
            }
        }
    }
}