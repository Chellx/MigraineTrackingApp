using MigraineTrackingApp.Models;
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
        string foodList = "";
        string migraineTypeList = "";
        string medicationTypeList = "";
        string painLocationList = "";
        string symptomsList = "";
        string triggersList = "";
        string email = "";
        string emailMesage = "";
        public ShowMigraineDetails(Migraine record,string email)
        {
            migraine = record;
            InitializeComponent();
            this.email = email;
        }
        protected async override void OnAppearing()
        {
            endD.Text = migraine.endDate;
            emailMesage += endD.Text + "\n";
            startD.Text = migraine.startDate;
            emailMesage += startD.Text + "\n";
            startT.Text = migraine.startTime;
            emailMesage += startT.Text + "\n";
            endT.Text = migraine.endTime;
            emailMesage += endT.Text + "\n";
            humd.Text = migraine.humidity;
            emailMesage += humd.Text + "\n";
            loc.Text = migraine.location;
            emailMesage += loc.Text + "\n";
            migraineD.Text = migraine.migraineDuration;
            emailMesage += migraineD.Text + "\n";
            painI.Text = migraine.painIntensity;
            emailMesage += painI.Text + "\n";
            temp.Text = migraine.temperature;
            emailMesage += temp.Text + "\n";
            string fList = string.Join(", ", migraine.foods);
            emailMesage += fList + "\n";
            string migList = string.Join(", ", migraine.migraineType);
            emailMesage += migList + "\n";
            string medList = string.Join(", ", migraine.medicationType);
            emailMesage += medList + "\n";
            string pList = string.Join(", ", migraine.painLocation);
            emailMesage += pList + "\n";
            string sList = string.Join(", ", migraine.symptoms);
            emailMesage += sList + "\n";
            string tList = string.Join(", ", migraine.triggers);
            emailMesage += tList + "\n";
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