/*
 * Student Name: Michelle Bolger
 * Student Number: C00242743
 * Date: 19/4/2022
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
        string fList = "";
        string migList = "";
        string medList = "";
        string pList = "";
        string sList = "";
        string tList = "";

        IAuth auth;
       /// <summary>
       /// setting migraine record values
       /// </summary>
       /// <param name="record"></param>
       /// <param name="email"></param>
       /// <param name="id"></param>
       /// <param name="auth"></param>
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
            // if null value found in a migraine record detail ignore/ dont fill in 
            if(migraine.migraineType != null)
            {
                vm.setMigraneTypes(migraine.migraineType);
            }
            if (migraine.triggers != null)
            {
                vm.setTriggers(migraine.triggers);
            }
            if (migraine.symptoms != null)
            {
                vm.setSymptoms(migraine.symptoms);
            }
            if (migraine.foods != null)
            {
                vm.setFoodEaten(migraine.foods);
            }
            if (migraine.painLocation != null)
            {
                vm.setPainLocation(migraine.painLocation);
            }
            if (migraine.medicationType != null)
            {
                vm.setMedicationTypes(migraine.medicationType);
            }
            InitializeComponent();
            this.email = email;
            userId = id;
            this.auth = auth;
        }
        /// <summary>
        /// content of email
        /// </summary>
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

            if(migraine.foods != null)
            {
                fList = string.Join("\n ", migraine.foods);
                emailMesage += "\n" + "Food Eaten: " + "\n" + fList + "\n";
            }

            if (migraine.migraineType != null)
            {
                migList = string.Join("\n ", migraine.migraineType);
                emailMesage += "\n" + "Migraine Type: " + migList + "\n";
            }

            if (migraine.medicationType != null)
            {
                medList = string.Join("\n ", migraine.medicationType);
                emailMesage += "\n" + "Medication: " + medList + "\n";
            }
            if (migraine.painLocation != null)
            {
                pList = string.Join("\n ", migraine.painLocation);
                emailMesage += "\n" + "Pain Location: " + pList + "\n";
            }
            if (migraine.symptoms != null)
            {
                sList = string.Join("\n ", migraine.symptoms);
                emailMesage += "\n" + "Symptoms: " + sList + "\n";
            }
            if (migraine.triggers != null)
            {
                tList = string.Join("\n ", migraine.triggers);
                emailMesage += "\n" + "Triggers: " + tList + "\n";
            }

            food.Text = fList;
            medicationT.Text = medList;
            migraineT.Text = migList;
            painLoc.Text = pList;
            symptom.Text = sList;
            trigger.Text = tList;
            base.OnAppearing();
        }
        /// <summary>
        /// sends email with migraine record details
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void OnButtonClicked(object sender, EventArgs e)
        {
            List<string> recipients = new List<string>();
            recipients.Add(email);
            await sendMigraineRecord(recipients, emailMesage);
        }
        /// <summary>
        /// goes to record migraine page to allow user to update record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void updateClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new RecordMigraine(userId,vm,email, auth));
        }
       /// <summary>
       /// this method send the email using Xamarin Essentails email API
       /// </summary>
       /// <param name="recipients"></param>
       /// <param name="body"></param>
       /// <returns></returns>
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
            catch (FeatureNotSupportedException ns) //if phone does not support this API
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