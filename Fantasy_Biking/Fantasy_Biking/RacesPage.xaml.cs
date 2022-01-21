using Fantasy_Biking.Logic;
using Fantasy_Biking.Model;
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
    public partial class RacesPage : ContentPage
    {
        public RacesPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            List<League> leagues = await RaceLogic.GetAllLeagues();
            List<League> cyclingLeagues = leagues.FindAll(l => l.strSport == "Cycling"); // filter the cycling leagues
            Race_List.ItemsSource = cyclingLeagues;
        }
    }
}