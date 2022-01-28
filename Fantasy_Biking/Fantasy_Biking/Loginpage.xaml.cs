using Fantasy_Biking.Logic;
using Fantasy_Biking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace Fantasy_Biking
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Loginpage : ContentPage
    {
        public Loginpage()
        {
            InitializeComponent();
            Init();
        }
        protected override bool OnBackButtonPressed()
        {
            return true;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            Accelerometer.ShakeDetected += Accelerometer_ShakeDetected;
            Accelerometer.Start(SensorSpeed.Game);
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Accelerometer.ShakeDetected -= Accelerometer_ShakeDetected;
            Accelerometer.Stop();
        }

        void Init()
        {
            Entry_Username.Completed += (s, e) => Entry_Password.Focus();
            Entry_Password.Completed += (s, e) => CheckInformation(s, e);
        }
        private async void Register_Account(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }

        private void Accelerometer_ShakeDetected(object sender, EventArgs e)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                Entry_Username.Text = string.Empty;
                Entry_Password.Text = string.Empty;
            });
        }
        async private void Reset_Password(object sender, EventArgs e)
        {
            /*bool IsusernameEmpty = string.IsNullOrEmpty(Entry_Username.Text);
            bool IsuserPasswordEmpty = string.IsNullOrEmpty(Entry_Password.Text);


            if (IsusernameEmpty || IsuserPasswordEmpty)
            {
                await DisplayAlert("Invalide Login", "Okay", "Cancel");
            }
            else
            {
                await Navigation.PushAsync(new MainPage());
            }*/
        }
        async private void CheckInformation(object sender, EventArgs e)
        {
            (User usr, string msgErr) = UserLogic.Login(Entry_Username.Text, Entry_Password.Text);

            if (usr == null)
            {
                Vibration.Vibrate();
                await DisplayAlert("Warning!", msgErr, "cancel");
            } else
            {
                var current = Connectivity.NetworkAccess;
                if (current != NetworkAccess.Internet)
                {
                    //makes device vibrate when no internet connection
                    Vibration.Vibrate();
                    //there is no connection with the internet
                    await DisplayAlert("No Connection",
                        "it appears there is no connection. some value's might not be up to date", "proceed!");
                }
                // We found a user
                await Navigation.PushAsync(new MainPage(usr));
            }

            /*bool IsusernameEmpty = string.IsNullOrEmpty(Entry_Username.Text);
            bool IsuserPasswordEmpty = string.IsNullOrEmpty(Entry_Password.Text);


            if (IsusernameEmpty || IsuserPasswordEmpty)
            {
                await DisplayAlert("Invalide Login", "Okay", "Cancel");
            }
            else
            {
                await Navigation.PushAsync(new MainPage());
            }*/
        }
    }
}