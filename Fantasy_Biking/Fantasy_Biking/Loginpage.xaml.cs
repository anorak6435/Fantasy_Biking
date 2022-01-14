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
    public partial class Loginpage : ContentPage
    {
        public Loginpage()
        {
            InitializeComponent();
        }
        protected override bool OnBackButtonPressed()
        {
            return true;
        }
        void Init()
        {
            Entry_Username.Completed += (s, e) => Entry_Password.Focus();
        }
        private async void Register_Account(object sender, EventArgs e)
        {

            {
                await Navigation.PushAsync(new MainPage());
            }
        }
        async private void Reset_Password(object sender, EventArgs e)
        {
            bool IsusernameEmpty = string.IsNullOrEmpty(Entry_Username.Text);
            bool IsuserPasswordEmpty = string.IsNullOrEmpty(Entry_Password.Text);


            if (IsusernameEmpty || IsuserPasswordEmpty)
            {
                await DisplayAlert("Invalide Login", "Okay", "Cancel");
            }
            else
            {
                await Navigation.PushAsync(new MainPage());
            }
        }
        async private void CheckInformation(object sender, EventArgs e)
        {
            bool IsusernameEmpty = string.IsNullOrEmpty(Entry_Username.Text);
            bool IsuserPasswordEmpty = string.IsNullOrEmpty(Entry_Password.Text);


            if (IsusernameEmpty || IsuserPasswordEmpty)
            {
                await DisplayAlert("Invalide Login", "Okay", "Cancel");
            }
            else
            {
                await Navigation.PushAsync(new MainPage());
            }
        }
    }
}