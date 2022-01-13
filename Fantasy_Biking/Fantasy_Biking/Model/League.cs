using System;
using System.Collections.Generic;
using System.Text;

namespace Fantasy_Biking.Model
{
    public class League
    {
        public static string GenerateURLListLeagues()
        {
            return APIConstants.ALL_LEAGUES;
        }
        public string idLeague { get; set; }
        public string strLeague { get; set; }
        public string strSport { get; set; }
        public string strLeagueAlternate { get; set; }
    }
}
