using Fantasy_Biking.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public static void AddBikerToTeam(Biker biker)
        {
            // insert the team into the table
            using (SQLiteConnection con = new SQLiteConnection(App.DatabaseLocation))
            {
                con.CreateTable<Team>();
                con.CreateTable<BikerInTeam>();

                // check if the user already has a team
                List<Team> teams = con.Table<Team>().Where(t => t.UserId == MainPage.loggedInUser.Id).ToList();
                if (teams.Count == 1)
                {   // the user has a team
                    // check if biker in bikerTeam table
                    int teamID = teams[0].Id;
                    List<BikerInTeam> bikeInTeam = con.Table<BikerInTeam>().Where(x => x.BikerId == biker.Id && x.TeamId == teamID).ToList();
                    if (bikeInTeam.Count == 0)
                    {   // no team with this biker found
                        // add biker to team
                        con.Insert(new BikerInTeam { BikerId = biker.Id, TeamId = teams[0].Id });
                    }
                }
                else
                {   // The user has no team
                    Team newTeam = new Team
                    {
                        UserId = MainPage.loggedInUser.Id
                    };
                    con.Insert(newTeam);

                    con.Insert(new BikerInTeam { BikerId = biker.Id, TeamId = newTeam.Id });
                }
            }
        }

        public static List<Biker> GetMyTeam()
        {
            List<Biker> myTeam = new List<Biker>();
            using (SQLiteConnection con = new SQLiteConnection(App.DatabaseLocation))
            {
                con.CreateTable<Team>();
                con.CreateTable<BikerInTeam>();
                // what is my teamID
                List<Team> teams = con.Table<Team>().Where(t => t.UserId == MainPage.loggedInUser.Id).ToList();
                if (teams.Count > 0)
                {   // User has a team // get bikerIDs from bikers in team
                    int expectedTeamId = teams[0].Id;
                    List<BikerInTeam> bikerIds = con.Table<BikerInTeam>().Where(x => x.TeamId == expectedTeamId).ToList();
                    foreach(BikerInTeam idItems in bikerIds) {
                        List<Biker> bik = BikerLogic.AllBikers().Where(x => x.Id == idItems.BikerId).ToList();
                        myTeam.Add(bik[0]);
                    }
                }
            }
            return myTeam;
        }
    }
}
