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
                Id = 0,
                Position = 1,
                Name = "Plapp Luke",
                CountryCode = "au",
                CountryFlag = "https://flagcdn.com/24x18/au.png",
                PointsPerRaceday = 15.0f,
                Points = 15,
                Racedays = 1,
                Cost = 20,
            });

            bikers.Add(new Biker
            {
                Id = 1,
                Position = 2,
                Name = "Lonardi Giovanni",
                CountryCode = "it",
                CountryFlag = "https://flagcdn.com/24x18/it.png",
                PointsPerRaceday = 15.0f,
                Points = 15,
                Racedays = 1,
                Cost = 17,
            });

            bikers.Add(new Biker
            {
                Id = 2,
                Position = 3,
                Name = "Capiot Amaury",
                CountryCode = "be",
                CountryFlag = "https://flagcdn.com/24x18/be.png",
                PointsPerRaceday = 10.0f,
                Points = 10,
                Racedays = 1,
                Cost = 15,
            });

            bikers.Add(new Biker
            {
                Id = 3,
                Position = 4,
                Name = "Papadelli Gordo",
                CountryCode = "fr",
                CountryFlag = "https://flagcdn.com/24x18/fr.png",
                PointsPerRaceday = 10.0f,
                Points = 14,
                Racedays = 1,
                Cost = 16,
            });

            bikers.Add(new Biker
            {
                Id = 4,
                Position = 5,
                Name = "Max verstappen",
                CountryCode = "nl",
                CountryFlag = "https://flagcdn.com/24x18/nl.png",
                PointsPerRaceday = 10.0f,
                Points = 50,
                Racedays = 1000,
                Cost = 25,
            });

            bikers.Add(new Biker
            {
                Id = 5,
                Position = 6,
                Name = "The stig",
                CountryCode = "gb",
                CountryFlag = "https://flagcdn.com/24x18/gb.png",
                PointsPerRaceday = 10.0f,
                Points = 3,
                Racedays = 4,
                Cost = 5,
            });

            bikers.Add(new Biker
            {
                Id = 6,
                Position = 7,
                Name = "Lance Armstrong",
                CountryCode = "us",
                CountryFlag = "https://flagcdn.com/24x18/us.png",
                PointsPerRaceday = 10.0f,
                Points = 28,
                Racedays = 420,
                Cost = 30,
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
