using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NotesApp.ViewModel
{
    public class DatabaseHelper
    {
        public static string dbFile = Path.Combine(Environment.CurrentDirectory, "notesDb.db3");

        public static bool Insert<T>(T item)
        {
            bool result = false;

            using (SQLiteConnection connection = new SQLiteConnection(dbFile))
            {
                // create table if it doesn't exist
                connection.CreateTable<T>();
                int rowsChanged = connection.Insert(item);
                if (rowsChanged > 0)
                    return true;
            }

            return result;
        }

        public static bool Update<T>(T item)
        {
            bool result = false;

            using (SQLiteConnection connection = new SQLiteConnection(dbFile))
            {
                // create table if it doesn't exist
                connection.CreateTable<T>();
                int rowsChanged = connection.Update(item);
                if (rowsChanged > 0)
                    return true;
            }

            return result;
        }

        public static bool Delete<T>(T item)
        {
            bool result = false;

            using (SQLiteConnection connection = new SQLiteConnection(dbFile))
            {
                // create table if it doesn't exist
                connection.CreateTable<T>();
                int rowsChanged = connection.Delete(item);
                if (rowsChanged > 0)
                    return true;
            }

            return result;
        }
    }
}
