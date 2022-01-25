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
    public partial class Userpage : ContentPage
    {
        private string UserPicturePath = string.Empty;
        public Userpage()
        {
            InitializeComponent();
            UsernameLabel.Text = MainPage.loggedInUser.Name;
            PasswordLabel.Text = MainPage.loggedInUser.Password;

            UserPic.Source = ImageSource.FromFile(MainPage.loggedInUser.ProfileImageSrc);
        }

        private async void ChangeProfileImage_Clicked(object sender, EventArgs e)
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
                // if correct result
                UserPicturePath = result.FullPath;

                // load the image to display
                var stream = await result.OpenReadAsync();
                UserPic.Source = ImageSource.FromStream(() => stream);
            }
        }
    }
}