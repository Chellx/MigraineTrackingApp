/*
 * Student Name: Michelle Bolger
 * Student Number C00242743
 */

using MigraineTrackingApp.ViewModels;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MigraineTrackingApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecordMigraineType : ContentPage
    {
        List<string> selectedMigraneTypes = new List<string>();
        string[] migraineTypes;
        RecordMigraneViewModel migraneVM;
        internal RecordMigraineType(RecordMigraneViewModel migraneVM)
        {
            InitializeComponent();
            this.migraneVM = migraneVM;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            migraineTypes = new[] { "Migraine", "Tension Headache", "Cluster Headache", "Headache", "Sinus Headache", "Not Sure" };

            MigraineTypeListView.ItemsSource = migraineTypes;
            if (migraneVM.getMigraneTypes().Count != 0)
            {
                selectedMigraneTypes.AddRange(migraneVM.getMigraneTypes());
                showListView.ItemsSource = selectedMigraneTypes;
            }
        }
        /// <summary>
        /// This method adds to a list of migrane types
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
                    selectedMigraneTypes.Add(value);
                }
            }
            else
            {
                if(addMigraineType.Text != null)
                {
                    selectedMigraneTypes.Add(addMigraineType.Text);
                    addMigraineType.Text = "";
                }
            }
            showListView.ItemsSource = null;
            showListView.ItemsSource = selectedMigraneTypes;

        }
        /// <summary>
        /// This method removes migrane types from the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void removeFromList(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            string value = button.CommandParameter.ToString();

            selectedMigraneTypes.RemoveAll(x => x.StartsWith(value));
            showListView.ItemsSource = null;
            showListView.ItemsSource = selectedMigraneTypes;
        }
        /// <summary>
        /// Returns to previous menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private async void returnToMenu (object sender, EventArgs args)
        {
            await Navigation.PopAsync();
        }
        /// <summary>
        /// This method saves the migrane type list to a view model
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private async void saveTypes(object sender, EventArgs args)
        {
            if(selectedMigraneTypes.Count != 0)
            {
                migraneVM.setMigraneTypes(selectedMigraneTypes);
                await Navigation.PopModalAsync();
            }
            else
            {
                await DisplayAlert("Alert", "You Have Not Selected Any Migraine Type", "OK");
            }
        }
    }
}