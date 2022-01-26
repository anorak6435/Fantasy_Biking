using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fantasy_Biking.Model
{
    public class BikerNote
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int Biker_Id { get; set; }

        public string Notitie { get; set; }

        public string Name { get; set; }
    }
}
