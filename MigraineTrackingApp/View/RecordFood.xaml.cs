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
            if (migraneVM.getFoodEaten().Count != 0)
            {
                showListView.ItemsSource = migraneVM.getFoodEaten();
            }
        }
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

        private async void goToScan(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new BarcodeScanner(migraneVM));
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
            await Navigation.PopAsync();
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
                migraneVM.setFoodEaten(food);
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Alert", "You Have Not Entered Any Food!", "OK");
            }
        }
    }
}