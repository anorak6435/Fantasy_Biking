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
    }
}