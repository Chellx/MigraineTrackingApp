/*
 * Student Name: Michelle Bolger
 * Student Number: C00242743
 * Date: 19/4/2022
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
    public partial class RecordSymptoms : ContentPage
    {
        List<string> selectedSymptoms = new List<string>();
        string[] symptoms;
        RecordMigraneViewModel migraneVM;
        internal RecordSymptoms(RecordMigraneViewModel migraneVM)
        {
            InitializeComponent();
            this.migraneVM = migraneVM;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            symptoms = new[] { "Pounding Pain","Throbbing Pain","Nausea","Light Sensitivity", "Noise Sensitivity","Vomiting","None" };
            SymptomsListView.ItemsSource = symptoms;
            if (migraneVM.getSymptoms().Count != 0 && !migraneVM.getSymptoms().Contains(" "))
            {
                selectedSymptoms.AddRange(migraneVM.getSymptoms());
                showListView.ItemsSource = migraneVM.getSymptoms();
            }
        }
        /// <summary>
        /// This method adds to a list of symptoms
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
                    selectedSymptoms.Add(value);
                }
            }
            else
            {
                if (addSymptoms.Text != null)
                {
                    selectedSymptoms.Add(addSymptoms.Text);
                    addSymptoms.Text = "";
                }
            }
            showListView.ItemsSource = null;
            showListView.ItemsSource = selectedSymptoms;

        }
        /// <summary>
        /// This method removes symptoms from the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void removeFromList(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            string value = button.CommandParameter.ToString();

            selectedSymptoms.RemoveAll(x => x.StartsWith(value));
            showListView.ItemsSource = null;
            showListView.ItemsSource = selectedSymptoms;
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
        /// This method saves the symptom list to a view model
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private async void saveTypes(object sender, EventArgs args)
        {
            if (selectedSymptoms.Count != 0)
            {
                migraneVM.getSymptoms().Clear();
                migraneVM.setSymptoms(selectedSymptoms);
                await Navigation.PopModalAsync();
            }
            else
            {
                await DisplayAlert("Alert", "You Have Not Selected Any Pain Locations", "OK");
            }
        }
    }
}