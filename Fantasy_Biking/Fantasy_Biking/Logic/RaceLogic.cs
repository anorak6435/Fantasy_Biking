using Fantasy_Biking.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Fantasy_Biking.Logic
{
    public class RaceLogic
    {
        public async static Task<List<League>> GetAllLeagues()
        {
            List<League> leagues = new List<League>();

            var url = Constants.ALL_LEAGUES;

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();
                var leagueResponse = JsonConvert.DeserializeObject<LeagueResponse>(json);
                leagues = leagueResponse.leagues as List<League>;
                leagues = leagues.FindAll(l => l.strSport == "Cycling"); // filter the cycling leagues
            }
            return leagues;
        }
    }
}
