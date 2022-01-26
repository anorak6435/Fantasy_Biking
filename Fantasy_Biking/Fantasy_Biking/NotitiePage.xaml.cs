using Fantasy_Biking.Logic;
using Fantasy_Biking.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace Fantasy_Biking
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotitiePage : ContentPage
    {
        BikerNote note;
        public NotitiePage()
        {
            InitializeComponent();
            using (SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation))
            {
                sQLiteConnection.CreateTable<BikerNote>();
                sQLiteConnection.CreateTable<LeagueNote>();
                My_Noteslist.ItemsSource = NotesLogic.GetAllNotes();
            }

        }
        //button adds new biker note to the My notes list##
        private void Add_Biker_Note_Clicked(object sender, EventArgs e)
        {

            BikerNote note = new BikerNote();
            var SelectedBiker = Bikerlist.SelectedItem as Biker;
            note.Biker_Id = SelectedBiker.Id;
            note.Notitie = NewNotes.Text;
            note.Name = SelectedBiker.Name;
            SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation);
            sQLiteConnection.CreateTable<BikerNote>();
            int insertedRows = sQLiteConnection.Insert(note);

            if (!string.IsNullOrEmpty(NewNotes.Text) && NewNotes.Text.Length > 1 && NewNotes.Text.Length < 200)
            {
                _ = DisplayAlert("Worked!", "Your note has been added", "Ok");
                sQLiteConnection.Close();
                My_Noteslist.ItemsSource = NotesLogic.GetAllNotes();
                BikerTitle.IsVisible = false;
                Add_Biker_Note.IsVisible = false;
                NewNoteFrame.IsVisible = false;
                current_Name_biker.IsVisible = false;
                Create_new_Note.IsVisible = true;
                NewNotes.Text = "";

            }
            else
            {
                Vibration.Vibrate();
                _ = DisplayAlert("To Short", "try to make your note a little longer", "Ok");
                sQLiteConnection.Close();
            }
        }
        //button adds new race note to the My notes list##
        private void Add_Race_Note_Clicked(object sender, EventArgs e)
        {
            LeagueNote note = new LeagueNote();
            var SelectedLeague = Raceslist.SelectedItem as League;
            note.League_Id = SelectedLeague.idLeague;
            note.Notitie = NewNotes.Text;
            note.Name = SelectedLeague.strLeague;
            SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation);
            sQLiteConnection.CreateTable<LeagueNote>();
            int insertedRows = sQLiteConnection.Insert(note);
            if (!string.IsNullOrEmpty(NewNotes.Text) && NewNotes.Text.Length > 1 && NewNotes.Text.Length < 200)
            {
                _ = DisplayAlert("Worked!", "Your note has been added", "Ok");
                sQLiteConnection.Close();
                My_Noteslist.ItemsSource = NotesLogic.GetAllNotes();
                RaceTitle.IsVisible = false;
                Add_Race_Note.IsVisible = false;
                NewNoteFrame.IsVisible = false;
                current_Name_Race.IsVisible = false;
                Create_new_Note.IsVisible = true;
                NewNotes.Text = "";
            }
            else
            {
                Vibration.Vibrate();
                _ = DisplayAlert("To Short", "try to make your note a little longer", "Ok");
                sQLiteConnection.Close();
            }
        }



        //Deletes selected Note in My list##
        private async void Delete_Note_Clicked(object sender, EventArgs e)
        {
            var SelectedNote = My_Noteslist.SelectedItem;
            int deletedRows;
            bool result = await DisplayAlert("Delete Note!", "You are about to delete a Note are you sure?", "Yes", "No");
            if (result)
            {
                using (SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation))
                {
                    sQLiteConnection.CreateTable<BikerNote>();
                    sQLiteConnection.CreateTable<LeagueNote>();
                    deletedRows = sQLiteConnection.Delete(SelectedNote);
                }
                if (deletedRows > 0)
                {
                    _ = DisplayAlert("Deleted", "Your Note has been Deleted", "Ok");
                    Delete_Note.IsVisible = false;
                    Show_Note.IsVisible = false;
                    My_Noteslist.ItemsSource = NotesLogic.GetAllNotes();
                    Note_name.IsVisible = false;
                    Note_info.IsVisible = false;
                }
                else
                {
                    _ = DisplayAlert("Not Deleted", "Your Note has not been Deleted", "Ok");

                }
                using (SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation))
                {
                    My_Noteslist.ItemsSource = NotesLogic.GetAllNotes();
                }
            }
        }

        //Function to show buttons once item in My notes is selected
        private void My_Noteslist_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Delete_Note.IsVisible = true;
            Show_Note.IsVisible = true;
        }

        //Function to show buttons to slected the type of list##
        private void Create_new_Note_Clicked(object sender, EventArgs e)
        {
            Create_new_Note.IsVisible = false;
            Racenote_Button.IsVisible = true;
            Bikernote_Button.IsVisible = true;
            Delete_Note.IsVisible = false;
            Show_Note.IsVisible = false;
            Note_name.IsVisible = false;
            Note_info.IsVisible = false;
        }

        //Shows list of bikers to add the list to
        private void Bikernote_Button_Clicked(object sender, EventArgs e)
        {
            BikerTitle.IsVisible = true;
            Racenote_Button.IsVisible = false;
            Bikernote_Button.IsVisible = false;
            BikerlistFraming.IsVisible = true;
            List<Biker> Bikers = BikerLogic.AllBikers();
            Bikerlist.ItemsSource = Bikers;
        }

        private async void Racenote_Button_Clicked(object sender, EventArgs e)
        {
            RaceTitle.IsVisible = true;
            Racenote_Button.IsVisible = false;
            Bikernote_Button.IsVisible = false;
            RaceslistFraming.IsVisible = true;
            List<League> Leagues = await RaceLogic.GetAllLeagues();
            Raceslist.ItemsSource = Leagues;
        }

        private void Bikerlist_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Biker_selected.IsVisible = true;
        }

        private void Raceslist_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Race_selected.IsVisible = true;
        }

        private void Biker_selected_Clicked(object sender, EventArgs e)
        {
            BikerTitle.IsVisible = false;
            BikerlistFraming.IsVisible = false;
            Biker_selected.IsVisible = false;
            Add_Biker_Note.IsVisible = true;
            NewNoteFrame.IsVisible = true;
            current_Name_biker.IsVisible = true;
            var SelectedBiker = Bikerlist.SelectedItem as Biker;
            current_Name_biker.Text = SelectedBiker.Name;
        }

        private void Race_selected_Clicked(object sender, EventArgs e)
        {
            RaceTitle.IsVisible = false;
            RaceslistFraming.IsVisible = false;
            Race_selected.IsVisible = false;
            Add_Race_Note.IsVisible = true;
            NewNoteFrame.IsVisible = true;
            current_Name_Race.IsVisible = true;
            var SelectedRace = Raceslist.SelectedItem as League;
            current_Name_Race.Text = SelectedRace.strLeague;
        }

        private void Show_Note_Clicked(object sender, EventArgs e)
        {
            var selected_note = My_Noteslist.SelectedItem as object;
            if (selected_note is BikerNote)
            {
                var Current_biker = My_Noteslist.SelectedItem as BikerNote;
                Note_name.Text = Current_biker.Name;
                Note_info.Text = Current_biker.Notitie;
                Note_name.IsVisible = true;
                Note_info.IsVisible = true;
                Edit_info.IsVisible = true;
            }
            if (selected_note is LeagueNote)
            {
                var Current_Race = My_Noteslist.SelectedItem as LeagueNote;
                Note_name.Text = Current_Race.Name;
                Note_info.Text = Current_Race.Notitie;
                Note_name.IsVisible = true;
                Note_info.IsVisible = true;
                Edit_info.IsVisible = true;
            }

        }

        private void Edit_info_Clicked(object sender, EventArgs e)
        {
            Note_info.IsVisible = false;
            EditNotes.Text = Note_info.Text;
            EditNotesFrame.IsVisible = true;
            Add_New_note.IsVisible = true;
            Edit_info.IsVisible = false;
            Show_Note.IsEnabled = false;
        }

        private void Add_New_note_Clicked(object sender, EventArgs e)
        {
            var selected_note = My_Noteslist.SelectedItem as object;
            if (selected_note is BikerNote)
            {
                var Current_biker = My_Noteslist.SelectedItem as BikerNote;
                Current_biker.Notitie = EditNotes.Text;
                SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation);
                sQLiteConnection.CreateTable<BikerNote>();
                sQLiteConnection.Update(Current_biker);
                Note_info.Text = Current_biker.Notitie;
                Note_info.IsVisible = true;
                EditNotesFrame.IsVisible = false;
                Add_New_note.IsVisible = false;
                Show_Note.IsEnabled = true;
                Edit_info.IsVisible = true;
            }
            if (selected_note is LeagueNote)
            {
                var Current_Race = My_Noteslist.SelectedItem as LeagueNote;
                Current_Race.Notitie = EditNotes.Text;
                SQLiteConnection sQLiteConnection = new SQLiteConnection(App.DatabaseLocation);
                sQLiteConnection.CreateTable<LeagueNote>();
                sQLiteConnection.Update(Current_Race);
                Note_info.Text = Current_Race.Notitie;
                Note_info.IsVisible = true;
                EditNotesFrame.IsVisible = false;
                Add_New_note.IsVisible = false;
                Show_Note.IsEnabled = true;
                Edit_info.IsVisible = true;
            }
        }
    }
}