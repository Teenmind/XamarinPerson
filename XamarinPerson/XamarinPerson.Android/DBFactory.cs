using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace XamarinPerson.Droid
{
    class DBFactory
    {
        public static IPersonDAO getInstance(string key)
        {
            IPersonDAO db = null;

            switch (key)
            {
                case "SQLite": db = new PersonDAOSQLite(); break;
                //case "REALM": db = new REALM(); break;
                default: throw new ArgumentException();
            }

            return db;
        }
    }
}