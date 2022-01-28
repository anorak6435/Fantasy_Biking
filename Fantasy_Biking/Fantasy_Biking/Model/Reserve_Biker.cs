﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fantasy_Biking.Model
{
    public class Reserve_Biker
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int TeamId { get; set; }
        public int BikerId { get; set; }
    }
}
