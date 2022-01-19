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
    public partial class MainPageFlyout : ContentPage
    {
        public MainPageFlyout()
        {
            InitializeComponent();
        }

        private async void Races_Clicked(object sender, EventArgs e)
        {
<<<<<<< HEAD
            await Navigation.PushAsync(new LeaderboardPage());
=======
            await Navigation.PushAsync(new CyclistsPage());
>>>>>>> CyclistPage
        }

        private async void Cyclists_Clicked(object sender, EventArgs e)
        {
<<<<<<< HEAD
            await Navigation.PushAsync(new LeaderboardPage());
=======
            await Navigation.PushAsync(new CyclistsPage());
>>>>>>> CyclistPage
        }

        private async void Leaderboard_Clicked(object sender, EventArgs e)
        {
<<<<<<< HEAD
            await Navigation.PushAsync(new LeaderboardPage());
=======
            await Navigation.PushAsync(new CyclistsPage());
>>>>>>> CyclistPage
        }
    }
}