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
        public MainFeedPage(string userId)
        {
            InitializeComponent();
            this.userId = userId;
            
        }

        private async void recordMigraineButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RecordMigraine(userId));
        }
        private async void profileButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfilePage(userId));
        }
        private async void statsButton_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new MigraineStatPage());
        }
        private async void recordsButton_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new RecordMigraine());
        }

    }
}