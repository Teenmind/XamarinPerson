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

namespace XamarinPerson.Droid
{
    [Table("People")]
    public class Person
    {     
        [PrimaryKey]
        public int Id { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        public int Age { get; set; }

        public Person() { }
        public Person(int id, string firstName, string lastName, int age)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }
    }
}