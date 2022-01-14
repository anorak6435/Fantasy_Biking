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

        private void LoginPage_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new View.TestLoginPage());
        }
    }
}
