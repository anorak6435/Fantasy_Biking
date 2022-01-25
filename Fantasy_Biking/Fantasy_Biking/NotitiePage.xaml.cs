using Fantasy_Biking.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fantasy_Biking
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotitiePage : ContentPage
    {
        Note note;
        public NotitiePage()
        {
            InitializeComponent();
            using (SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation))
            {
                sQLiteConnection.CreateTable<Note>();
                var notes = sQLiteConnection.Table<Note>().ToList();
                My_Noteslist.ItemsSource = notes;
            }

        }

        private void Add_Note_Clicked(object sender, EventArgs e)
        {

            Note note = new Note();
            note.Notitie = NewNotes.Text;
            SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation);
            sQLiteConnection.CreateTable<Note>();
            int insertedRows = sQLiteConnection.Insert(note);
            if (insertedRows > 1 || insertedRows < 200)
            {
                _ = DisplayAlert("Gelukt!", "Je vraag is toegevoegd aan de database!", "Ok");
                var notes = sQLiteConnection.Table<Note>().ToList();
                sQLiteConnection.Close();
                My_Noteslist.ItemsSource = notes;
            }
            else
            {
                _ = DisplayAlert("Al wat gedronken?", "probeer je vraag wat langer of korter te maken", "Ok");
                sQLiteConnection.Close();
            }
        }

        private async void Delete_Note_Clicked(object sender, EventArgs e)
        {
            var SelectedNote = My_Noteslist.SelectedItem as Note;
            note = SelectedNote;
            int deletedRows;
            bool result = await DisplayAlert("Delete Question!", "You are about to delete a question are you sure?", "Yes", "No");
            if (result)
            {
                using (SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation))
                {
                    sQLiteConnection.CreateTable<Note>();
                    deletedRows = sQLiteConnection.Delete(note);
                }
                if (deletedRows > 0)
                {
                    _ = DisplayAlert("Deleted", "Your Question has been Deleted", "Ok");
                }
                else
                {
                    _ = DisplayAlert("Not Deleted", "Your Question has not been Deleted", "Ok");

                }
                using (SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation))
                {
                    var notes = sQLiteConnection.Table<Note>().ToList();
                    My_Noteslist.ItemsSource = notes;
                }
            }
        }
    }
}