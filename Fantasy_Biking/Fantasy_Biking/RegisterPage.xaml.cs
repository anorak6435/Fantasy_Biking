using Fantasy_Biking.Logic;
using Fantasy_Biking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fantasy_Biking
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        private string UserPicturePath = string.Empty;
        public RegisterPage()
        {
            InitializeComponent();
        }

        private async void RegisterBtn_Clicked(object sender, EventArgs e)
        {
            (bool couldRegister, string errMsg) = UserLogic.Register(userNameEntry.Text, PasswordEntry.Text, PasswordRepeatEntry.Text, UserPicturePath);
            if (!couldRegister)
            {
                await DisplayAlert("Waarschuwing!", errMsg, "cancel");
            } else
            {
                await Navigation.PopAsync();
            }
        }

        private async void NewProfileImage_Clicked(object sender, EventArgs e)
        {
            var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
            {
                Title = "Kies uw foto"
            });

            if (result is null)
            {
                _ = DisplayAlert("Let Op!", "Geen afbeelding ontvangen!", "terug");
            }
            else
            {
                UserPicturePath = result.FullPath;

                var stream = await result.OpenReadAsync();
                UserPic.Source = ImageSource.FromStream(() => stream);
            }
        }
    }
}