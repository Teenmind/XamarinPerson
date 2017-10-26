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
using SQLite;
using System.IO;
using Android.Database.Sqlite;

namespace XamarinPerson.Droid
{
    class PersonDAOSQLite : IPersonDAO
    {
        string connectionString = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "dbPeople.db3");


        public void Create(Person p)
        {
            SQLiteConnection connection = new SQLiteConnection(connectionString);
            connection.CreateTable<Person>();
            connection.Insert(p);

        }

        public void Delete(Person p)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("Delete FROM [Persons] " +
                    $"WHERE Id = {p.Id};", connection);
                command.ExecuteNonQuery();
            }
        }

        public List<Person> Read()
        {
            List<Person> persons = new List<Person>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM [Persons];", connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string fn = reader.GetString(1);
                    string ln = reader.GetString(2);
                    int age = reader.GetInt32(3);
                    persons.Add(new Person(id, fn, ln, age));
                }

            }
            return persons;
        }

        public void Update(Person p)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE [Persons]" +
                    $"SET Fn='{p.Fn}', Ln='{p.Ln}', Age={p.Age}" +
                    $"WHERE Id = {p.Id};", connection);
                command.ExecuteNonQuery();
            }
        }
    }
}