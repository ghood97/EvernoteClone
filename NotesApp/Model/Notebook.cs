using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace NotesApp.Model
{
    public class Notebook : INotifyPropertyChanged
    {
		private int id;

		[PrimaryKey, AutoIncrement]
		public int Id
		{
			get { return id; }
			set
			{
				id = value;
				OnPropertyChanged("Id");
			}
		}

		private int userId;

		[Indexed]
		public int UserId
		{
			get { return UserId; }
			set
			{
				UserId = value;
				OnPropertyChanged("UserId");
			}
		}

		private string name;

		public string Name
		{
			get { return name; }
			set
			{
				name = value;
				OnPropertyChanged("Name");
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
		
		private void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}



	}
}
