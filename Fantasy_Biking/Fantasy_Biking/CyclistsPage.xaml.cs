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
            // load bikers on my team
            List<Biker> MyTeam = TeamLogic.GetMyTeam();
            My_Cyclists.ItemsSource = MyTeam;

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
        }
    }
}