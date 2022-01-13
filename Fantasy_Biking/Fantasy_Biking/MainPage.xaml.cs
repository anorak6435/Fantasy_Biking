using Fantasy_Biking.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Fantasy_Biking
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void LeagueListing_Clicked(object sender, EventArgs e)
        {
            var leagues = await APIRequestlogic.GetListOfLeagues();
            
            await Navigation.PushAsync(new View.TestLeaguePage(leagues));
        }

        private async void TeamListing_Clicked(object sender, EventArgs e)
        {
            var teams = await APIRequestlogic.GetListOfTeams();

            await Navigation.PushAsync(new View.TestTeamPage(teams));
        }
    }
}
