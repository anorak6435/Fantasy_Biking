﻿using Fantasy_Biking.Model;
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
    public partial class Userpage : ContentPage
    {
        public Userpage()
        {
            InitializeComponent();
            UsernameLabel.Text = MainPage.loggedInUser.Name;
            PasswordLabel.Text = MainPage.loggedInUser.Password;
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
                _ = DisplayAlert("Failed", "Your Question has not been edited", "Ok");
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