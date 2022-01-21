using Fantasy_Biking.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fantasy_Biking.Logic
{
    public class NoteLogic
    {
        public static (bool, string) NewNote(string contents)
        {
            if (string.IsNullOrEmpty(contents))
            {
                return (false, "Kan geen lege note invoegen!");
            }
            // create the note
            Note notitie = new Note();
            notitie.Contents = contents;

            // track how many rows were inserted
            int ins_rows;
            // insert the note into the table
            using (SQLiteConnection con = new SQLiteConnection(App.DatabaseLocation))
            {
                con.CreateTable<Note>();
                ins_rows = con.Insert(notitie);
            }
            if (ins_rows != 1)
            {
                return (false, "Fout in de database connectie!");
            }
            return (true, "Succesvol toegevoegd!");
        }

        // for when you want all the notes
        public static List<Note> AllNotes()
        {
            List<Note> notes = new List<Note>();
            using (SQLiteConnection con = new SQLiteConnection(App.DatabaseLocation))
            {
                con.CreateTable<User>();
                // check if the users exists inside the database
                notes = con.Table<Note>().ToList();
            }
            return notes;
        }
    }
}
