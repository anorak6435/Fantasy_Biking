using Fantasy_Biking.Logic;
using Fantasy_Biking.Model;
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
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private async void RegisterBtn_Clicked(object sender, EventArgs e)
        {
            (bool couldRegister, string errMsg) = UserLogic.Register(userNameEntry.Text, PasswordEntry.Text, PasswordRepeatEntry.Text);
            if (!couldRegister)
            {
                await DisplayAlert("Waarschuwing!", errMsg, "cancel");
            }
            
        }
    }
}