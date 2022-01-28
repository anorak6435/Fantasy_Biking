using Fantasy_Biking.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Fantasy_Biking
{
    public partial class MainPage : FlyoutPage
    {
        public static User loggedInUser;
        public MainPage(User usr)
        {
            InitializeComponent();
            loggedInUser = usr;
        }
    }
}
