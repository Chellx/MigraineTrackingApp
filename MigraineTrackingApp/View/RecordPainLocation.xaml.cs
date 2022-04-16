/*
 * Student Name: Michelle Bolger
 * Student Number C00242743
 */

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
    public partial class RecordPainLocation : ContentPage
    {
        List<string> selectedPainLocation = new List<string>();
        string[] painLocation;
        RecordMigraneViewModel migraneVM;
        internal RecordPainLocation(RecordMigraneViewModel migraneVM)
        {
            InitializeComponent();
            this.migraneVM = migraneVM;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            painLocation = new[] { "Right Eye", "Left Eye", "Forehead (Right)", "Forehead (Left)", "Not Sure"};
            PainLocationListView.ItemsSource = painLocation;
            if (migraneVM.getPainLocation().Count != 0)
            {
                showListView.ItemsSource = migraneVM.getPainLocation();
            }                
        }
        /// <summary>
        /// This method adds to a list of pain locations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void addToList(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            if (button.CommandParameter != null)
            {
                string value = button.CommandParameter.ToString();
                if (value != null)
                {
                    selectedPainLocation.Add(value);
                }
            }
            else
            {
                if (addPainLocation.Text != null)
                {
                    selectedPainLocation.Add(addPainLocation.Text);
                    addPainLocation.Text = "";
                }
            }
            showListView.ItemsSource = null;
            showListView.ItemsSource = selectedPainLocation;

        }
        /// <summary>
        /// This method removes pain locations from the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void removeFromList(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            string value = button.CommandParameter.ToString();

            selectedPainLocation.RemoveAll(x => x.StartsWith(value));
            showListView.ItemsSource = null;
            showListView.ItemsSource = selectedPainLocation;
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
        /// This method saves the pain locations list to a view model
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private async void saveTypes(object sender, EventArgs args)
        {
            if (selectedPainLocation.Count != 0)
            {
                migraneVM.setPainLocation(selectedPainLocation);
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Alert", "You Have Not Selected Any Pain Locations", "OK");
            }
        }
    }
}