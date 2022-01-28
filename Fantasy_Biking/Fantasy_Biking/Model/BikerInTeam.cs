using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fantasy_Biking.Model
{
    // connect bikers to teams
    public class BikerInTeam
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int TeamId { get; set; }
        public int BikerId { get; set; }
    }
}
