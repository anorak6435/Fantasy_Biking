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
        public static int DeleteNote(object note)
        {
            int deletedRows;
            using (SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation))
            {
                sQLiteConnection.CreateTable<BikerNote>();
                sQLiteConnection.CreateTable<LeagueNote>();
                deletedRows = sQLiteConnection.Delete(note);
            }
            return deletedRows;
        }
        public static void UpdateLeagueNote(LeagueNote current_race)
        {
            SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation);
            sQLiteConnection.CreateTable<LeagueNote>();
            sQLiteConnection.Update(current_race);
            sQLiteConnection.Close();
        }

        public static void UpdateBikerNote(BikerNote current_biker)
        {
            SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation);
            sQLiteConnection.CreateTable<BikerNote>();
            sQLiteConnection.Update(current_biker);
            sQLiteConnection.Close();
        }

        public static void InsertBikerNote(BikerNote note)
        {
            SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation);
            sQLiteConnection.CreateTable<BikerNote>();
            int insertedRows = sQLiteConnection.Insert(note);
            sQLiteConnection.Close();
        }

        public static void InsertLeagueNote(LeagueNote note)
        {
            // open connection to insert note into the database
            SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation);
            sQLiteConnection.CreateTable<LeagueNote>();
            int insertedRows = sQLiteConnection.Insert(note);
            sQLiteConnection.Close();
        }

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
