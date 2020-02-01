using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.ViewModel
{
 public   class DatabaseHelper
    {
        public static  string dbFile = Path.Combine(Environment.CurrentDirectory, "notedb.db");

        public static bool Insert<T> (T item)
        {
            bool result = false;
            using (SQLiteConnection sQLiteConnection = new SQLiteConnection(dbFile))
            {
                sQLiteConnection.CreateTable<T>();
              int effectedOfRow =  sQLiteConnection.Insert(item);
                if (effectedOfRow > 0)
                {
                result = true;

                }
            }
                return result; 
        }

        public static bool Update<T>(T item)
        {
            bool result = false;
            using (SQLiteConnection sQLiteConnection = new SQLiteConnection(dbFile))
            {
                sQLiteConnection.CreateTable<T>();
                int effectedOfRow =   sQLiteConnection.Update(item);
                if (effectedOfRow > 0)
                {
                    result = true;

                }
            }
            return result;
        }

        public static bool Delete<T>(T item)
        {
            bool result = false;
            using (SQLiteConnection sQLiteConnection = new SQLiteConnection(dbFile))
            {
                sQLiteConnection.CreateTable<T>();
                int effectedOfRow = sQLiteConnection.Delete(item);
                if (effectedOfRow > 0)
                {
                    result = true;

                }
            }
            return result;
        }
    }
}
