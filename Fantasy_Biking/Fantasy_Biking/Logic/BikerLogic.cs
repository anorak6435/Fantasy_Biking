using Fantasy_Biking.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Fantasy_Biking.Logic
{
    public class BikerLogic
    {
        public static List<Biker> AllBikers()
        {
            List<Biker> bikers = new List<Biker>();

            // hardcoded version of request response
            bikers.Add(new Biker
            {
                Position = 1,
                Name = "Plapp Luke",
                CountryCode = "au",
                CountryFlag = "https://flagcdn.com/24x18/au.png",
                PointsPerRaceday = 15.0f,
                Points = 15,
                Racedays = 1,
            });

            bikers.Add(new Biker
            {
                Position = 2,
                Name = "Lonardi Giovanni",
                CountryCode = "it",
                CountryFlag = "https://flagcdn.com/24x18/it.png",
                PointsPerRaceday = 15.0f,
                Points = 15,
                Racedays = 1,
            });

            bikers.Add(new Biker
            {
                Position = 3,
                Name = "Capiot Amaury",
                CountryCode = "be",
                CountryFlag = "https://flagcdn.com/24x18/be.png",
                PointsPerRaceday = 10.0f,
                Points = 10,
                Racedays = 1,
            });

            return bikers;

            //var client = new HttpClient();
            //var request = new HttpRequestMessage
            //{
            //    Method = HttpMethod.Get,
            //   RequestUri = new Uri("https://pro-cycling-stats.p.rapidapi.com/riders"),
            //    Headers =
            //    {
            //        { "x-rapidapi-host", "pro-cycling-stats.p.rapidapi.com" },
            //        { "x-rapidapi-key", API_KEY }, // using placeholder should become API key from enviroment or something
            //    },
            //};
            //using (var response = await client.SendAsync(request))
            //{
            //    response.EnsureSuccessStatusCode();
            //    var json = await response.Content.ReadAsStringAsync();
            //    var bikerResponse = JsonConvert.DeserializeObject<ListingBikerResponse>(json);
            //    bikers = bikerResponse.Bikers as List<AllBikerResponse>;
            //}
        }
    }
}
