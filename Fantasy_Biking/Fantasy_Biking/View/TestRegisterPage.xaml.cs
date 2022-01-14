using Fantasy_Biking.Logic;
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
    public partial class TestRegisterPage : ContentPage
    {
        public TestRegisterPage()
        {
            InitializeComponent();
        }

        private void RegisterBtn_Clicked(object sender, EventArgs e)
        {
            (bool succes, string msg) = UserLogic.Register(userNameEntry.Text, PasswordEntry.Text, PasswordRepeatEntry.Text);
            msgLbl.TextColor = succes ? Color.Green : Color.Red;
            msgLbl.Text = msg;
        }
    }
}