﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fantasy_Biking.Model
{
    public class Reserve
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int UserId { get; set; }
    }
}
