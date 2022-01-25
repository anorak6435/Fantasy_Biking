using Fantasy_Biking.Model;
using SQLite;
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

        private async void Edit_ProfileImage_Clicked(object sender, EventArgs e)
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

                // update the current loggedInUser with this file path
                int updatedRows;
                MainPage.loggedInUser.ProfileImageSrc = UserPicturePath;
                using(SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation))
                {
                    sQLiteConnection.CreateTable<Biker>();
                    updatedRows = sQLiteConnection.Update(MainPage.loggedInUser);
                }
                if (updatedRows > 0)
                {
                    _ = DisplayAlert("Edit", "Your Image has been edited", "Ok");
                }
                else
                {
                    _ = DisplayAlert("Failed", "Your Image has not been edited", "Ok");
                }
            }
        }

        private void Edit_Username_Clicked(object sender, EventArgs e)
        {
            ConfirmUsernameEdit.IsVisible = true;
            UsernameBodyEntry.IsVisible = true;
            Edit_Username.IsVisible = false;
        }
        private void Edit_password_Clicked(object sender, EventArgs e)
        {
            ConfirmPasswordEdit.IsVisible = true;
            PasswordBodyEntry.IsVisible = true;
            Edit_password.IsVisible = false;
        }

        private void ConfirmUsernameEdit_Clicked(object sender, EventArgs e)
        {
            int updatedRows;
            MainPage.loggedInUser.Name = UsernameBodyEntry.Text;
            using (SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation))
            {
                sQLiteConnection.CreateTable<Biker>();
                updatedRows = sQLiteConnection.Update(MainPage.loggedInUser);
            }
            if (updatedRows > 0)
            {
                _ = DisplayAlert("Edit", "Your Username has been edited", "Ok");
                ConfirmUsernameEdit.IsVisible = false;
                UsernameBodyEntry.IsVisible = false;
                Edit_Username.IsVisible = true;
                UsernameLabel.Text = MainPage.loggedInUser.Name;
            }
            else
            {
                _ = DisplayAlert("Failed", "Your Username has not been edited", "Ok");
            }
        }

        private void ConfirmPasswordEdit_Clicked(object sender, EventArgs e)
        {
            int updatedRows;
            MainPage.loggedInUser.Password = PasswordBodyEntry.Text;
            using (SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation))
            {
                sQLiteConnection.CreateTable<Biker>();
                updatedRows = sQLiteConnection.Update(MainPage.loggedInUser);
            }
            if (updatedRows > 0)
            {
                _ = DisplayAlert("Edit", "Your Password has been edited", "Ok");
                ConfirmPasswordEdit.IsVisible = false;
                PasswordBodyEntry.IsVisible = false;
                Edit_password.IsVisible = true;
                PasswordLabel.Text = MainPage.loggedInUser.Password;
            }
            else
            {
                _ = DisplayAlert("Failed", "Your Password has not been edited", "Ok");
            }
        }
    }
}