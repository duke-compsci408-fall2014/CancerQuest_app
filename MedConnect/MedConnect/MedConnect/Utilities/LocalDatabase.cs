using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net;
using MedConnect.Models;
using Xamarin.Forms;

namespace MedConnect.Utilities
{
    public class LocalDatabase
    {
        static object locker = new object();

        SQLiteConnection database;

        public LocalDatabase()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();

            database.CreateTable<Session>();
        }

        public string getSession()
        {
            lock (locker)
            {
                return database.Table<Session>().FirstOrDefault(x => x.session != null).session;
            }
        }
        public void addSession(Session toAdd)
        {
            lock (locker)
            {
                database.Insert(toAdd);
            }
        }
        public void deleteSession()
        {
            lock (locker)
            {
                database.DeleteAll<Session>();
            }
        }


    }
}
