/*
 * Student Name: Michelle Bolger
 * Student Number C00242743
 */

using MigraineTrackingApp.Models;
using MigraineTrackingApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MigraineTrackingApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowMigraineDetails : ContentPage
    {
        Migraine migraine;
        RecordMigraneViewModel vm = new RecordMigraneViewModel();
        string foodList = "";
        string migraineTypeList = "";
        string medicationTypeList = "";
        string painLocationList = "";
        string symptomsList = "";
        string triggersList = "";
        string email = "";
        string emailMesage = "";
        string userId = "";
        IAuth auth;
        public ShowMigraineDetails(Migraine record,string email,string id, IAuth auth)
        {
            migraine = record;
            vm.StartDate = migraine.startDate;
            vm.EndDate = migraine.endDate;
            vm.StartTimeOfMigraine = migraine.startTime;
            vm.EndTimeOfMigraine = migraine.endTime;
            vm.Humidity = migraine.humidity;
            vm.Location = migraine.location;
            vm.PainIntensity = migraine.painIntensity;
            vm.LengthOfMigraineAttack = migraine.migraineDuration;
            vm.Temperature = migraine.temperature;
            vm.setMigraneTypes(migraine.migraineType);
            vm.setTriggers(migraine.triggers);
            vm.setSymptoms(migraine.symptoms);
            vm.setFoodEaten(migraine.foods);
            vm.setPainLocation(migraine.painLocation);
            vm.setMedicationTypes(migraine.medicationType);
            InitializeComponent();
            this.email = email;
            userId = id;
            this.auth = auth;
        }
        protected async override void OnAppearing()
        {
            
            startD.Text = migraine.startDate;
            emailMesage += "Start Date: "+ startD.Text + "\n";

            endD.Text = migraine.endDate;
            emailMesage += "\n" +"End Date: "+endD.Text + "\n";


            startT.Text = migraine.startTime;
            emailMesage += "\n" + "Start Time: " + startT.Text + "\n";


            endT.Text = migraine.endTime;
            emailMesage += "\n" + "End Time: " + endT.Text + "\n";


            humd.Text = migraine.humidity;
            emailMesage += "\n" + "Humidity: " +humd.Text + "%" + "\n";

            temp.Text = migraine.temperature;
            emailMesage += "\n" + "Temperature: " +temp.Text + "°C" + "\n";


            loc.Text = migraine.location;
            emailMesage += "\n" + "Location: " + loc.Text + "\n";


            migraineD.Text = migraine.migraineDuration;
            emailMesage += "\n" + "Migraine Duration (H:M:S): " + migraineD.Text + "\n";


            painI.Text = migraine.painIntensity;
            emailMesage += "\n" + "Pain Intensity: " + painI.Text + "\n";

            string fList = string.Join("\n ", migraine.foods);
            emailMesage += "\n"+ "Food Eaten: " +"\n" + fList + "\n";


            string migList = string.Join("\n ", migraine.migraineType);
            emailMesage += "\n"+ "Migraine Type: "+ migList + "\n";


            string medList = string.Join("\n ", migraine.medicationType);
            emailMesage += "\n" +"Medication: "+  medList + "\n";


            string pList = string.Join("\n ", migraine.painLocation);
            emailMesage += "\n"+ "Pain Location: "+ pList + "\n";


            string sList = string.Join("\n ", migraine.symptoms);
            emailMesage +="\n"+ "Symptoms: " + sList + "\n";


            string tList = string.Join("\n ", migraine.triggers);
            emailMesage += "\n" + "Triggers: " + tList + "\n";


            food.Text = fList;
            medicationT.Text = medList;
            migraineT.Text = migList;
            painLoc.Text = pList;
            symptom.Text = sList;
            trigger.Text = tList;
            base.OnAppearing();
        }
        private async void OnButtonClicked(object sender, EventArgs e)
        {
            List<string> recipients = new List<string>();
            recipients.Add(email);
            await sendMigraineRecord(recipients, emailMesage);
            //await Navigation.PopAsync();
        }
        private async void updateClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new RecordMigraine(userId,vm,email, auth));
            //await Navigation.PopAsync();
        }
        public async Task<bool> sendMigraineRecord(List<string> recipients,string body)
        {
            try
            {
                EmailMessage message = new EmailMessage
                {
                    Subject = "Migraine Record",
                    Body = body,
                    To = recipients,
                };
                await Email.ComposeAsync(message);
                return true;
            }
            catch (FeatureNotSupportedException ns)
            {
                var value = ns.StackTrace;
                Console.WriteLine(value);
                return false;
            }
            catch (Exception ex)
            {
                var value = ex.StackTrace;
                Console.WriteLine(value);
                return false;
            }
        }
    }
}