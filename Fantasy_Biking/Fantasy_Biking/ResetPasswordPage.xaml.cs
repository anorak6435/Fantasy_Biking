using Fantasy_Biking.Logic;
using Fantasy_Biking.Model;
using SQLite;
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
    public partial class ResetPasswordPage : ContentPage
    {
        public ResetPasswordPage()
        {
            InitializeComponent();
        }

        private void Confirm_Username_Clicked(object sender, EventArgs e)
        {
            var allusers = UserLogic.GetAllUsers();
            var username = Username.Text;
            var Usercheck = allusers.Where(x => x.Name == username).ToList();
            if (Usercheck.Count == 0)
            {
                _ = DisplayAlert("Warning!", "No user found!", "cancel");
            }
            else
            {
                What_username.IsVisible = false;
                Username.IsVisible = false;
                Confirm_Username.IsVisible = false;
                what_password.IsVisible = true;
                Password.IsVisible = true;
                Password_Confirm.IsVisible = true;
                Confirm_New_Password.IsVisible = true;
            }




        }

        private async void Confirm_New_Password_Clicked(object sender, EventArgs e)
        {
            if (Password.Text == Password_Confirm.Text)
            {
                var allusers = UserLogic.GetAllUsers();
                var username = Username.Text;
                var Usercheck = allusers.Where(x => x.Name == username).ToList();
                int updatedRows;
                Usercheck[0].Password = Password_Confirm.Text;
                using (SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation))
                {
                    sQLiteConnection.CreateTable<User>();
                    updatedRows = sQLiteConnection.Update(Usercheck[0]);
                }
                if (updatedRows > 0)
                {
                    _ = DisplayAlert("Edit", "Your Password has been edited", "Ok");
                    Password.IsVisible = false;
                    Password_Confirm.IsVisible = false;
                    Confirm_New_Password.IsVisible = true;
                    await Navigation.PushAsync(new Loginpage());
                }
                else
                {
                    _ = DisplayAlert("Failed", "Your Password has not been edited", "Ok");
                }
            }
            else
            {
                _ = DisplayAlert("Failed", "Make shure both passwords match", "Ok");
            }

        }
    }
}