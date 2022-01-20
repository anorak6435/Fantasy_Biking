using System;
using System.Collections.Generic;
using System.Text;

namespace Fantasy_Biking.Model
{
    public class League
    {
        public string idLeague { get; set; }
        public string strLeague { get; set; }
        public string strSport { get; set; }
        public string strLeagueAlternate { get; set; }
    }

    public class LeagueResponse
    {
        public IList<League> leagues { get; set; }
    }

}
