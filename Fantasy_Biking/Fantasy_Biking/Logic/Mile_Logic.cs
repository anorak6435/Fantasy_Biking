using Fantasy_Biking.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fantasy_Biking.Logic
{
    public class Mile_Logic
    {
        public async static Task<List<string>> AllLeagueIds()
        {
            List<string> allLeagueIds = new List<string>();
            var allraces = RaceLogic.GetAllLeagues();
            foreach (object x in await allraces)
            {
                var Current_League = x as League;
                allLeagueIds.Add(Current_League.idLeague);
            }
            return allLeagueIds;
        }
        public async static Task<List<Mile>> AllMiles()
        {

            List<string> allIds = await AllLeagueIds();
            List<Mile> miles = new List<Mile>();
            int x = 0;
            miles.Add(new Mile
            {
                LeagueId = allIds[x],
                Miles = 823,
            });
            x++;
            miles.Add(new Mile
            {
                LeagueId = allIds[x],
                Miles = 340,
            });
            x++;
            miles.Add(new Mile
                {
                LeagueId = allIds[x],
                Miles = 557,
            });
            x++;
            miles.Add(new Mile
            {
                LeagueId = allIds[x],
                Miles = 209,
            });
            x++;
            miles.Add(new Mile
            {
                LeagueId = allIds[x],
                Miles = 688,
            });

            return miles;
        }
    }
}
