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


        // buying the biker
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
                    {   // biker is not already in this team

                        // can we affort the biker
                        if (teams[0].Budget >= biker.Cost)
                        {
                            // update the team balance
                            teams[0].Budget -= biker.Cost;
                            con.Update(teams[0]);

                            // add biker to team
                            con.Insert(new BikerInTeam { BikerId = biker.Id, TeamId = teams[0].Id });
                        }
                        
                    }
                }
                else
                {   // The user has no team
                    Team newTeam = new Team
                    {
                        UserId = MainPage.loggedInUser.Id,
                        Budget = Constants.TEAM_BUDGET - biker.Cost,
                    };
                    con.Insert(newTeam);

                    con.Insert(new BikerInTeam { BikerId = biker.Id, TeamId = newTeam.Id });
                }
            }
        }
        public static void AddBikerToReserve(Biker biker)
        {
            using (SQLiteConnection con = new SQLiteConnection(App.DatabaseLocation))
            {
                con.CreateTable<Reserve>();
                con.CreateTable<ReserveInTeam>();

                List<Reserve> reserve = con.Table<Reserve>().Where(t => t.UserId == MainPage.loggedInUser.Id).ToList();
                if (reserve.Count == 1)
                {
                    // check how many bikers I have
                    if (GetMyReserveBikers().Count < 3)
                    {
                        // check if biker already in my reserves
                        int teamID = reserve[0].Id;
                        List<ReserveInTeam> reserves_team = con.Table<ReserveInTeam>().Where(x => x.BikerId == biker.Id && x.TeamId == teamID).ToList();
                        if (reserves_team.Count == 0)
                        {   // this biker is not in my reserves
                            //can we affort the biker
                            if (reserve[0].Budget >= biker.Cost)
                            {
                                // update reserve budget
                                reserve[0].Budget -= biker.Cost;
                                con.Update(reserve[0]);

                                // add the reserve to the reserves
                                con.Insert(new ReserveInTeam { BikerId = biker.Id, TeamId = reserve[0].Id });
                            }
                        }
                    }
                }
                else
                {   // The user has no team
                    Reserve newreserve = new Reserve
                    {
                        UserId = MainPage.loggedInUser.Id,
                        Budget = Constants.RESERVES_BUDGET
                    };
                    con.Insert(newreserve);

                    con.Insert(new ReserveInTeam { BikerId = biker.Id, TeamId = newreserve.Id });
                }
            }
        }

        /// <summary>
        /// Get all reserve bikers from the logged in user
        /// </summary>
        /// <returns></returns>
        public static List<Biker> GetMyReserveBikers()
        {
            List<Biker> myTeam = new List<Biker>();
            using (SQLiteConnection con = new SQLiteConnection(App.DatabaseLocation))
            {
                con.CreateTable<Reserve>();
                con.CreateTable<ReserveInTeam>();
                // what is my teamID
                List<Reserve> teams = con.Table<Reserve>().Where(t => t.UserId == MainPage.loggedInUser.Id).ToList();
                if (teams.Count > 0)
                {   // User has a reserve team // get bikerIDs from bikers in team
                    int expectedTeamId = teams[0].Id;
                    List<ReserveInTeam> bikerIds = con.Table<ReserveInTeam>().Where(x => x.TeamId == expectedTeamId).ToList();
                    foreach (ReserveInTeam idItems in bikerIds)
                    {
                        List<Biker> bik = BikerLogic.AllBikers().Where(x => x.Id == idItems.BikerId).ToList();
                        myTeam.Add(bik[0]);
                    }
                }
            }
            return myTeam;
        }

        public static List<Biker> GetMyTeamBikers()
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

        public static Team GetMyteam()
        {
            Team myTeam = new Team();
            using (SQLiteConnection con = new SQLiteConnection(App.DatabaseLocation))
            {
                con.CreateTable<Team>();
                con.CreateTable<BikerInTeam>();
                // what is my teamID
                List<Team> teams = con.Table<Team>().Where(t => t.UserId == MainPage.loggedInUser.Id).ToList();
                if (teams.Count > 0)
                {   // User has a team // get bikerIDs from bikers in team
                    myTeam = teams[0];
                }
            }
            return myTeam;
        }

        public static List<Biker> GetMyReserve()
        {
            List<Biker> myreserve = new List<Biker>();
            using (SQLiteConnection con = new SQLiteConnection(App.DatabaseLocation))
            {
                con.CreateTable<Reserve>();
                con.CreateTable<ReserveInTeam>();
                // what is my teamID
                List<Reserve> reserve = con.Table<Reserve>().Where(t => t.UserId == MainPage.loggedInUser.Id).ToList();
                if (reserve.Count > 0)
                {   // User has a team // get bikerIDs from bikers in team
                    int expectedTeamId = reserve[0].Id;
                    List<ReserveInTeam> bikerIds = con.Table<ReserveInTeam>().Where(x => x.TeamId == expectedTeamId).ToList();
                    foreach (ReserveInTeam idItems in bikerIds)
                    {
                        List<Biker> bik = BikerLogic.AllBikers().Where(x => x.Id == idItems.BikerId).ToList();
                        myreserve.Add(bik[0]);
                    }
                }
            }
            return myreserve;
        }
        public static int DeleteTeamcyclist(Biker bikerinteam)
        {
            int deletedRows;
            using (SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation))
            {
                sQLiteConnection.CreateTable<Team>();
                sQLiteConnection.CreateTable<BikerInTeam>();
                List<Team> teams = sQLiteConnection.Table<Team>().Where(t => t.UserId == MainPage.loggedInUser.Id).ToList();
                var currentTeam = new BikerInTeam
                {
                    TeamId = teams[0].Id,
                    BikerId = bikerinteam.Id

                };
                List<BikerInTeam> bit = sQLiteConnection.Table<BikerInTeam>().Where(x => currentTeam.TeamId == x.TeamId && currentTeam.BikerId == x.BikerId).ToList();
                deletedRows = sQLiteConnection.Delete(bit[0]);
            }
            return deletedRows;
        }
        public static int DeleteReservecyclist(Biker bikerinteam)
        {
            int deletedRows;
            using (SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation))
            {
                sQLiteConnection.CreateTable<Reserve>();
                sQLiteConnection.CreateTable<ReserveInTeam>();
                List<Reserve> teams = sQLiteConnection.Table<Reserve>().Where(t => t.UserId == MainPage.loggedInUser.Id).ToList();
                var currentTeam = new ReserveInTeam
                {
                    TeamId = teams[0].Id,
                    BikerId = bikerinteam.Id

                };
                List<ReserveInTeam> bit = sQLiteConnection.Table<ReserveInTeam>().Where(x => currentTeam.TeamId == x.TeamId && currentTeam.BikerId == x.BikerId).ToList();
                deletedRows = sQLiteConnection.Delete(bit[0]);
            }
            return deletedRows;
        }

        public static int GetMyTeamBudget()
        {
            int returnbudget = 0;
            using (SQLiteConnection con = new SQLiteConnection(App.DatabaseLocation))
            {
                con.CreateTable<Team>();
                // what is my teamID
                List<Team> teams = con.Table<Team>().Where(t => t.UserId == MainPage.loggedInUser.Id).ToList();
                if (teams.Count > 0)
                {   // User has a team
                    returnbudget = teams[0].Budget;
                }
            }
            return returnbudget;
        }

        public static int GetMyTotalPoints()
        {
            int pointSum = 0;
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
                    foreach (BikerInTeam idItems in bikerIds)
                    {
                        List<Biker> bik = BikerLogic.AllBikers().Where(x => x.Id == idItems.BikerId).ToList();
                        pointSum += bik[0].Points;
                    }
                }
            }
            return pointSum;
        }
    }
}
