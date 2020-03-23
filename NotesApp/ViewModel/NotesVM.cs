using NotesApp.Model;
using NotesApp.ViewModel.Commands;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace NotesApp.ViewModel
{
    public class NotesVM
    {
        public ObservableCollection<Notebook> Notebooks { get; set; }

		private Notebook selectedNotebook;

		public Notebook SelectedNotebook
		{
			get { return selectedNotebook; }
			set
			{
				selectedNotebook = value;
				// TODO: get notes
			}
		}

		public ObservableCollection<Note> Notes { get; set; }

		public NewNotebookCommand NewNotebookCommand { get; set; }

		public NewNoteCommand NewNoteCommand { get; set; }

		public NotesVM()
		{
			NewNotebookCommand = new NewNotebookCommand(this);
			NewNoteCommand = new NewNoteCommand(this);
			Notebooks = new ObservableCollection<Notebook>();
			Notes = new ObservableCollection<Note>();

			ReadNotebooks();
		}

		public void CreateNotebook()
		{
			Notebook newNotebook = new Notebook()
			{
				Name = "New Notebook"

			};

			DatabaseHelper.Insert(newNotebook);
		}

		public void CreateNote(int notebookId)
		{
			Note newNote = new Note()
			{
				NotebookId = notebookId,
				CreatedTime = DateTime.Now,
				UpdatedTime = DateTime.Now,
				Title = "New Note"
			};

			DatabaseHelper.Insert(newNote);
		}

		public void ReadNotebooks()
		{
			// get all Notebooks from the database
			using (SQLiteConnection connection = new SQLiteConnection(DatabaseHelper.dbFile))
			{
				connection.CreateTable<Notebook>();
				var notebooks = connection.Table<Notebook>().ToList();

				Notebooks.Clear();
				foreach(Notebook nb in notebooks)
				{
					Notebooks.Add(nb);
				}
			}
		}

		public void ReadNotes()
		{
			using (SQLiteConnection connection = new SQLiteConnection(DatabaseHelper.dbFile))
			{
				connection.CreateTable<Note>();
				// make sure a notebook is selected and filter results for that notebook
				if (selectedNotebook != null)
				{
					var notes = connection.Table<Note>().Where(note => note.NotebookId == selectedNotebook.Id).ToList();
					Notes.Clear();
					foreach (Note note in notes)
					{
						Notes.Add(note);
					}
				}
			}
		}



	}
}
