using Fantasy_Biking.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

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
            if (usrs.Count != 1)
            {
                return (null, "Fout in de database!");
            }
            return (usrs[0], "Welkom!");
            

        }

        public static (bool, string) Register(string userName, string password, string passwordRepeat) {
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

            // track how many rows were inserted
            int ins_rows;
            // insert the user into the table
            using (SQLiteConnection con = new SQLiteConnection(App.DatabaseLocation))
            {
                con.CreateTable<User>();
                ins_rows = con.Insert(usr);
            }
            if (ins_rows != 1)
            {
                return (false, "Fout in de database connectie!");
            }
            return (true, "Succesvol toegevoegd!");
        }
    }
}
