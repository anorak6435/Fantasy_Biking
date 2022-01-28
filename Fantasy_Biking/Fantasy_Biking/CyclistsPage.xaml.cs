using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fantasy_Biking.Logic;
using Fantasy_Biking.Model;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fantasy_Biking
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CyclistsPage : ContentPage
    {
        public CyclistsPage()
        {
            InitializeComponent();

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            this.Display_Team_Total_Cost();
            this.Display_My_Team();
            this.Display_All_Bikers();
            this.Display_My_Reserve();
        }
        
        private void Display_Team_Total_Cost()
        {
            // get sum of cost in my team
            int costSum = 0;
            foreach (Biker bik in TeamLogic.GetMyTeam())
            {
                costSum += bik.Cost;
            }
            TotalPointsInTeam.Text = Convert.ToString(costSum);
            BudgetLeft.Text = Convert.ToString(TeamLogic.GetMyTeamBudget());
        }
        private void Display_My_Reserve()
        {
            List<Biker> MyTeam = TeamLogic.GetMyReserve();
            Reserve_Cyclists.ItemsSource = MyTeam;
        }

        private void Display_My_Team()
        {
            // load bikers on my team
            List<Biker> MyTeam = TeamLogic.GetMyTeam();
            My_Cyclists.ItemsSource = MyTeam;
        }

        private void Display_All_Bikers()
        {
            // load the total list of available bikers
            List<Biker> Bikers = BikerLogic.AllBikers();
            Swap_Cyclists.ItemsSource = Bikers;
        }

        private void Add_to_team_Clicked(object sender, EventArgs e)
        {
            if (Swap_Cyclists.SelectedItem == null)
            {
               DisplayAlert("Canceling!", "please select a cyclist to add!", "cancel");
            }
            // there is an item selected
            TeamLogic.AddBikerToTeam(Swap_Cyclists.SelectedItem as Biker);

            // reload bikers on my team
            List<Biker> MyTeam = TeamLogic.GetMyTeam();
            My_Cyclists.ItemsSource = MyTeam;

            // reload the total cost of my team
            Display_Team_Total_Cost();
        }

        private void Add_player_to_Reserve_Clicked(object sender, EventArgs e)
        {
            if (Swap_Cyclists.SelectedItem == null)
            {
                DisplayAlert("Canceling!", "please select a cyclist to add!", "cancel");
            }
            // there is an item selected
            TeamLogic.AddBikerToReserve(Swap_Cyclists.SelectedItem as Biker);
            List<Biker> MyTeam = TeamLogic.GetMyReserve();
            Reserve_Cyclists.ItemsSource = MyTeam;

        }

        private void My_Cyclists_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var allbikernotes = NotesLogic.GetAllBikerNotes();
            var currentbiker = My_Cyclists.SelectedItem as Biker;
            var matchesBiker = allbikernotes.Where(x => x.Biker_Id == currentbiker.Id).ToList();
            if (matchesBiker.Count == 0)
            {
                Name_Current_Player.Text = currentbiker.Name;
                Current_cyclis_Flag.Source = currentbiker.CountryFlag;
                Current_cyclist_position.Text = currentbiker.Position.ToString();
                Info_current_player.Text = "";
                Delete_button_myTeam.IsVisible = true;
                Player_Info.IsVisible = true;
            }
            else
            {
                Name_Current_Player.Text = currentbiker.Name;
                Current_cyclis_Flag.Source = currentbiker.CountryFlag;
                Current_cyclist_position.Text = currentbiker.Position.ToString();
                Info_current_player.Text = matchesBiker[0].Notitie;
                Delete_button_myTeam.IsVisible = true;
                Player_Info.IsVisible = true;
            }
        }

        private void Delete_button_myTeam_Clicked(object sender, EventArgs e)
        {

            var currentbiker = My_Cyclists.SelectedItem as Biker;
            TeamLogic.DeleteTeamcyclist(currentbiker);
            Delete_button_myTeam.IsVisible = false;
            Player_Info.IsVisible = false;
            Display_My_Team();
        }

        private void Delete_button_myResreve_Clicked(object sender, EventArgs e)
        {
            var currentbiker = Reserve_Cyclists.SelectedItem as Biker;
            TeamLogic.DeleteReservecyclist(currentbiker);
            Delete_button_myResreve.IsVisible = false;
            Display_My_Reserve();
        }

        private void Reserve_Cyclists_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Delete_button_myResreve.IsVisible = true;
        }
    }
}