using System;
using System.Collections.Generic;
using System.Text;

namespace Fantasy_Biking.Model
{
    public class Biker
    {
        public int Id { get; set; }
        public int Position { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public string CountryFlag { get; set; }
        public float PointsPerRaceday { get; set; }
        public int Points { get; set; } // points the player made
        public int Racedays { get; set; }
        public int Cost { get; set; } // how expensive is the player
    }

    public class BikerResponse
    {
        public IList<Biker> Bikers { get; set; }
    }
}
