using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fantasy_Biking.Model
{
    public class LeagueNote
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string League_Id { get; set; }

        public string Notitie { get; set; }

        public string Name { get; set; }
    }
}
