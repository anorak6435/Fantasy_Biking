using Fantasy_Biking.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fantasy_Biking.Logic
{
    public class NotesLogic
    {


        public static List<object> GetAllNotes()
        {
            SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation);

            var bikernotes = sQLiteConnection.Table<BikerNote>().ToList();
            var leaguesnotes = sQLiteConnection.Table<LeagueNote>().ToList();
            List<object> notes = bikernotes.Cast<object>().Concat(leaguesnotes).ToList();
            return notes;
        }
    }
}
