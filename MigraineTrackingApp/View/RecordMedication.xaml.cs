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
    public partial class RecordMedication : ContentPage
    {
        List<string> selectedMedicationType = new List<string>();
        string[] medicationType;
        RecordMigraneViewModel migraneVM;
        internal RecordMedication(RecordMigraneViewModel migraneVM)
        {
            InitializeComponent();
            this.migraneVM = migraneVM;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            medicationType = new[] { "Paracetemol","Ibuprofen","Frovex","Naproxyn","None"  };
            MedicationTypeListView.ItemsSource = medicationType;
            if (migraneVM.getMedicationTypes().Count != 0)
            {
                showListView.ItemsSource = migraneVM.getMedicationTypes();
            }
        }
        /// <summary>
        /// This method adds to a list of medications
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
                    selectedMedicationType.Add(value);
                }
            }
            else
            {
                if (addMedicationType.Text != null)
                {
                    selectedMedicationType.Add(addMedicationType.Text);
                    addMedicationType.Text = "";
                }
            }
            showListView.ItemsSource = null;
            showListView.ItemsSource = selectedMedicationType;

        }
        /// <summary>
        /// This method removes medications from the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void removeFromList(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            string value = button.CommandParameter.ToString();

            selectedMedicationType.RemoveAll(x => x.StartsWith(value));
            showListView.ItemsSource = null;
            showListView.ItemsSource = selectedMedicationType;
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
        /// This method saves the meds list to a view model
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private async void saveTypes(object sender, EventArgs args)
        {
            if (selectedMedicationType.Count != 0)
            {
                migraneVM.setMedicationTypes(selectedMedicationType);
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Alert", "You Have Not Selected Any Medication", "OK");
            }
        }
    }
}