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
    public partial class RecordTriggers : ContentPage
    {
        List<string> selectedTriggers = new List<string>();
        string[] triggers;
        RecordMigraneViewModel migraneVM;
        internal RecordTriggers(RecordMigraneViewModel migraneVM)
        {
            InitializeComponent();
            this.migraneVM = migraneVM;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            triggers = new[] { "Stress","Lack Of Sleep","Anxiety","Skipped Meal","Caffeine","Dehydration ","Strong Smell","Neck Pain","Not Sure" };
            TriggersListView.ItemsSource = triggers;
            if (migraneVM.getTriggers().Count != 0)
            {
                showListView.ItemsSource = migraneVM.getTriggers();
            }
        }
        /// <summary>
        /// This method adds to a list of triggers
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
                    selectedTriggers.Add(value);
                }
            }
            else
            {
                if (addTriggers.Text != null)
                {
                    selectedTriggers.Add(addTriggers.Text);
                    addTriggers.Text = "";
                }
            }
            showListView.ItemsSource = null;
            showListView.ItemsSource = selectedTriggers;

        }
        /// <summary>
        /// This method removes triggers from the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void removeFromList(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            string value = button.CommandParameter.ToString();

            selectedTriggers.RemoveAll(x => x.StartsWith(value));
            showListView.ItemsSource = null;
            showListView.ItemsSource = selectedTriggers;
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
            if (selectedTriggers.Count != 0)
            {
                migraneVM.setTriggers(selectedTriggers);
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Alert", "You Have Not Selected Any Triggers", "OK");
            }
        }
    }
}