﻿using Fantasy_Biking.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Fantasy_Biking.Logic
{
    public class APIRequestlogic
    {
        public async static Task<List<League>> GetListOfLeagues()
        {
            List<League> leagues = new List<League>();

            var url = League.GenerateURLListLeagues();

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();

                var leagueListResponse = JsonConvert.DeserializeObject<LeagueResponse>(json);

                leagues = leagueListResponse.leagues as List<League>;
            }

            return leagues;
        }
    }
}
