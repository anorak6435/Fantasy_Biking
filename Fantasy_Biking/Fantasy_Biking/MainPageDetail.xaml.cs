using Fantasy_Biking.Logic;
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

        protected override void OnAppearing()
        {
            MyTeam_List.ItemsSource = TeamLogic.GetMyTeam();
            UsernameLabel.Text = MainPage.loggedInUser.Name;
        }

        private async void MyTeam_navigation(object sender, EventArgs e)
        {
            {
                await Navigation.PushAsync(new CyclistsPage());
            }
        }

        private async void MyRace_navigation(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RacesPage());
        }

        private async void UserPic_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Userpage());
        }
    }
}