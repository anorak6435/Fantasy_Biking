﻿using Fantasy_Biking.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fantasy_Biking
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPageDetail : ContentPage
    {
        public MainPageDetail()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            MyTeam_List.ItemsSource = TeamLogic.GetMyTeam();
            Points.Text = Convert.ToString(TeamLogic.GetMyTotalPoints());
            UsernameLabel.Text = MainPage.loggedInUser.Name;
            var allmiles = await Mile_Logic.AllMiles();
            var lastRace = allmiles.Last();
            var allleagues = await RaceLogic.GetAllLeagues();
            var matchesleague = allleagues.Where(x => x.idLeague == lastRace.LeagueId).ToList();
            NextRace_Title.Text = matchesleague[0].strLeague;
            NextRace_Info.Text = lastRace.Miles.ToString() + "KM";

            // check that not source is null or empty
            if (!string.IsNullOrEmpty(MainPage.loggedInUser.ProfileImageSrc))
            {
                UserPic.Source = ImageSource.FromFile(MainPage.loggedInUser.ProfileImageSrc);
            }
        }
        private async void UserPic_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Userpage());
        }
        
        private async void MyTeam_navigation(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CyclistsPage());
        }
        private async void MyRace_navigation(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RacesPage());
        }
    }
}