using Fantasy_Biking.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fantasy_Biking.Logic
{
    public class TeamLogic
    {
        public static List<Team> GetAllTeams()
        {
            List<Team> teams;
            using (SQLiteConnection con = new SQLiteConnection(App.DatabaseLocation))
            {
                con.CreateTable<Team>();
                // check if the users exists inside the database
                teams = con.Table<Team>().ToList();
            }
            return teams;
        }

        public static void AddPlayerToTeam(Biker player)
        {
            // insert the team into the table
            using (SQLiteConnection con = new SQLiteConnection(App.DatabaseLocation))
            {
                con.CreateTable<Team>();
                // check if the user already has a team
                List<Team> teams = con.Table<Team>().Where(t => t.UserId == MainPage.loggedInUser.Id).ToList();
                if (teams.Count == 1)
                {
                    // add player to team members
                    teams[0].Members.Add(player);
                    con.Update(teams[0]);
                } else
                {
                    Team newTeam = new Team
                    {
                        UserId = MainPage.loggedInUser.Id,
                        Members = new List<Biker> { player }
                    };
                    con.Insert(newTeam);
                }
            }
        }
    }
}
