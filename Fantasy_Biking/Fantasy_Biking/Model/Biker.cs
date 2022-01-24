using System;
using System.Collections.Generic;
using System.Text;

namespace Fantasy_Biking.Model
{
    public class Biker
    {
        public int Position { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public string CountryFlag { get; set; }
        public float PointsPerRaceday { get; set; }
        public int Points { get; set; }
        public int Racedays { get; set; }
    }

    public class BikerResponse
    {
        public IList<Biker> Bikers { get; set; }
    }
}
