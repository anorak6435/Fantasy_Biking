using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fantasy_Biking.Logic;
using Fantasy_Biking.Model;
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
    }
}