using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace FitPartner.Droid.Database
{
    public class DatabaseHandler : IDisposable
    {
        public DatabaseHandler()
        {
            DbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "localdb.db3");
            Db = new SQLiteConnection(DbPath);
        }

        public  SQLiteConnection Db { get; }
        public  string DbPath { get; }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}