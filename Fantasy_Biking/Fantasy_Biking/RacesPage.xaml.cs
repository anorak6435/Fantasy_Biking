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
            Race_List.ItemsSource = leagues;
        }

        private async void Race_List_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var allleaguenotes = NotesLogic.GetAllLeagueNote();
            var currentleague = Race_List.SelectedItem as League;
            var allmiles = await Mile_Logic.AllMiles();
            var allleagues = await RaceLogic.GetAllLeagues();
            var matchesMiles = allmiles.Where(x => x.LeagueId == currentleague.idLeague).ToList();
            var matchesleague = allleaguenotes.Where(x => x.League_Id == currentleague.idLeague).ToList();
            if (matchesleague.Count == 0)
            {
                Name_Current_League.Text = currentleague.strLeague;
                Info_current_League.Text = string.Empty;
                Miles_Current_Race.Text = matchesMiles[0].Miles.ToString()+"KM";
            }
            else
            {
                Name_Current_League.Text = currentleague.strLeague;
                Info_current_League.Text = matchesleague[0].Notitie;
                Miles_Current_Race.Text = matchesMiles[0].Miles.ToString()+"KM";
            }
        }
    }
}