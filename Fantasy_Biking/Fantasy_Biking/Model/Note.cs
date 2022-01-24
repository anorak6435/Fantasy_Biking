using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fantasy_Biking.Model
{
    public class Note
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        //public int UserId { get; set; }
        public string Notitie { get; set; }
    }
}
