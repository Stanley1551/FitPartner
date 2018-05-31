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

namespace FitPartner.Droid.Database
{
    [Table("User")]
    public sealed class User
    {
        public User()
        { }

        public User(string username, DateTime birth)
        {
            Username = username;
            Birth = birth;
            Age = Birth == DateTime.MinValue ? int.MinValue : (int)(DateTime.Now - birth).TotalDays / 365;
        }

        public User(string username, DateTime birth, string email)
        {
            Username = username;
            Birth = birth;
            Age = Birth == DateTime.MinValue ? int.MinValue : (int)(DateTime.Now - birth).TotalDays / 365;
            Email = email;
        }

        public User(int ID, string username, DateTime birth, string email, int height, int weight)
        {
            this.ID = ID;
            Username = username;
            Birth = birth;
            Age = Birth == DateTime.MinValue ? int.MinValue : (int)(DateTime.Now - birth).TotalDays / 365;
            Email = email;
            Height = height;
            Weight = weight;
        }

        public bool IsInitiativeUser()
        {
            if(Height == 0 && Weight == 0 && Birth == DateTime.MinValue)
                return true;
            return false;
        }
        [Column("ID")]
        [PrimaryKey]
        [AutoIncrement]
        public int ID { get; set; }
        [Column("Username")]
        public string Username { get; set; }
        [Column("Birthday")]
        public DateTime Birth { get; set; }
        [Column("Age")]
        public int Age { get; set; }
        [Column("Email")]
        public string Email { get; set; }
        [Column("Height")]
        public int Height { get; set; }
        [Column("Weight")]
        public int Weight { get; set; }
    }
}