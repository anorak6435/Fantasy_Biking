using Fantasy_Biking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fantasy_Biking.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestLeaguePage : ContentPage
    {
        public TestLeaguePage(List<League> leagues)
        {
            InitializeComponent();
            LeagueListView.ItemsSource = leagues;
        }
    }
}