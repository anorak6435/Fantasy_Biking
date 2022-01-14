using Fantasy_Biking.Logic;
using Fantasy_Biking.Model;
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
    public partial class TestLoginPage : ContentPage
    {
        public TestLoginPage()
        {
            InitializeComponent();
        }

        private void loginBtn_Clicked(object sender, EventArgs e)
        {
            (User usr, string errMsg) = UserLogic.Login(userNameEntry.Text, passwordEntry.Text);
            msgLbl.TextColor = usr == null ? Color.Red : Color.Green;
            msgLbl.Text = errMsg;
        }

        private void registerBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new View.TestRegisterPage());
        }
    }
}