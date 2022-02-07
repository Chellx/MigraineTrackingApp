﻿using System;
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
        public MainFeedPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false); //make fullscreen
        }



        private async void recordMigraineButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RecordMigraine());
        }

    }
}