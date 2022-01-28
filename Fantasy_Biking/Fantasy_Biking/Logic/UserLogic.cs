using Fantasy_Biking.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Fantasy_Biking.Logic
{
    public class UserLogic
    {
        public static (User, string) Login(string userName, string password)
        {
            // check the given strings are valid
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                return (null, "Vul zowel de gebruikersnaam als het wachtwoord in!");
            }

            List<User> usrs;
            using (SQLiteConnection con = new SQLiteConnection(App.DatabaseLocation))
            {
                con.CreateTable<User>();
                usrs = con.Table<User>().Where(x => x.Name == userName && x.Password == password).ToList();
            }
            // check that there is one person that meets password and userName
            if (usrs.Count < 1)
            {
                return (null, "Geen gebruiker gevonden!");
            } else if (usrs.Count > 1)
            {
                return (null, "Fout in de database!");
            }
            return (usrs[0], string.Empty);
        }

        public static (bool, string) Register(string userName, string password, string passwordRepeat, string imageSrc)
        {
            // check the incoming data is valid
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(passwordRepeat))
            {
                return (false, "Vul gebruikersnaam en wachtwoord in!");
            }
            if (password != passwordRepeat)
            {
                return (false, "Vul 2 maal het zelfde wachtwoord in!");
            }
            // create the user
            User usr = new User();
            usr.Name = userName;
            usr.Password = password;
            usr.ProfileImageSrc = imageSrc;

            // track how many rows were inserted
            int ins_rows;
            // insert the user into the table
            using (SQLiteConnection con = new SQLiteConnection(App.DatabaseLocation))
            {
                con.CreateTable<User>();
                // check if the users exists inside the database
                List<User> users = con.Table<User>().Where(x => x.Name == userName).ToList();
                if (users.Count > 0)
                {
                    return (false, "Gebruiker bestaat al!");
                }
                ins_rows = con.Insert(usr);
            }
            if (ins_rows != 1)
            {
                return (false, "Fout in de database connectie!");
            }
            return (true, "Succesvol toegevoegd!");
        }
        public static List<User> GetAllUsers()
        {
            SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation);
            sQLiteConnection.CreateTable<User>();
            var users = sQLiteConnection.Table<User>().ToList();
            List<User> userlist = users.Cast<User>().ToList();
            return userlist;
        }
    }
}
