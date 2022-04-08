using MigraineTrackingApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MigraineTrackingApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainFeedPage : ContentPage
    {
        string userId = "";
        string email = "";
        public MainFeedPage(string userId,string email)
        {
            InitializeComponent();
            this.userId = userId;
            this.email = email;
            
        }

        private async void recordMigraineButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RecordMigraine("y47GLJJZD4ReYJBoWttbi0WVrp62"));
        }
        private async void profileButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfilePage("y47GLJJZD4ReYJBoWttbi0WVrp62"));
        }
        private async void allergenButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AllergenScanner(userId));
        }
        private async void recordsButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new showPreviousRecords("y47GLJJZD4ReYJBoWttbi0WVrp62", "test@email.com"));
        }
    }
}